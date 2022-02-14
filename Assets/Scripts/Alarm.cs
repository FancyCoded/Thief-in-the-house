using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _burst;

    private Door _door;
    private AudioSource _source;
    private float _duration;
    private float _runningTime;
    private bool _isBurst;
    private bool _isVolumeReduced;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _door = gameObject.GetComponent<Door>();
        _source.volume = 0;
        _duration = 1000;
    }

    private void Update()
    {
        if(_door.IsIndoor && _isBurst == false)
        {
            _source.Stop();
            _isBurst = true;
            _isVolumeReduced = false;

            StopCoroutine("VolumeDown");
            _burst.Invoke();
            StartCoroutine("VolumeUp");
        }
        else if (_door.IsIndoor == false && _isVolumeReduced == false && _door.IsEscaped)
        {
            _isBurst = false;
            _isVolumeReduced = true;

            StopCoroutine("VolumeUp");
            StartCoroutine("VolumeDown");
        }
    }

    private IEnumerator VolumeDown()
    {
        float normalizedRunningTime;
        _runningTime = 0;

        while(_source.volume > 0)
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
        _runningTime = 0;

        while (_source.volume <= 1)
        {
            _runningTime += Time.deltaTime;

            normalizedRunningTime = _runningTime / _duration;
            _source.volume += normalizedRunningTime;
            yield return null;
        }
    }
}
