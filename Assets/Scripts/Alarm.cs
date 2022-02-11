using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm;

    private float _duration = 1000;
    private float _runningTime;
    private AudioSource _source;
    private bool _isThief;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.volume = 0;
    }

    private void Start()
    {
            StartCoroutine(VolumeUp());
            _alarm.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Thief thief))
        {
             _isThief = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Thief thief))
        {
             _isThief = true;
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
