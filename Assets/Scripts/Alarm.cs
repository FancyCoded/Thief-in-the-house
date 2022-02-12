using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm;

    private Enter _enter;
    private AudioSource _source;
    private float _duration = 1000;
    private float _runningTime;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.volume = 0;
        _enter = FindObjectOfType<Door>().GetComponent<Enter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            if (_enter.IsIndoor)
            {
                _alarm.Invoke();
                StartCoroutine(VolumeUp());
            }
            if (_enter.IsIndoor == false && thief.IsBreakIn)
            {
                _alarm.Invoke();
                StartCoroutine(VolumeDown());
            }
        }
    }

    private IEnumerator VolumeDown()
    {
        float normalizedRunningTime;
        _source.volume = 1;

        for (float i = 0; i <= _duration; i++)
        {
            _runningTime += Time.deltaTime;

            normalizedRunningTime = _runningTime / _duration;
            _source.volume -= normalizedRunningTime;
            yield return null;
        }
    }

    private IEnumerator VolumeUp()
    {
        float normalizedRunningTime;

        for (float i = 0; i <= _duration; i += Time.deltaTime)
        {
            _runningTime += Time.deltaTime;

            normalizedRunningTime = _runningTime / _duration;
            _source.volume += normalizedRunningTime;
            yield return null;
        }
    }
}
