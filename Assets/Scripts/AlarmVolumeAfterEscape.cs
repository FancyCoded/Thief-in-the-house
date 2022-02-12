using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class AlarmVolumeAfterEscape : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm;

    private float _duration = 1000;
    private float _runningTime;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.volume = 1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent(out Thief thief))
        {
            if (thief.IsBreakIn == true)
            {
                _alarm.Invoke();
                StartCoroutine(VolumeDown());
            }
        }
    }

    private IEnumerator VolumeDown()
    {
        float normalizedRunningTime;

        for (float i = 0; i <= _duration; i++)
        {
            _runningTime += Time.deltaTime;

            normalizedRunningTime = _runningTime / _duration;
            _source.volume -= normalizedRunningTime;
            yield return null;
        }
    }
}
