using UnityEngine;
using UnityEngine.Events;

public class Enter : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _escaped;
    
    private bool _isNear;

    [HideInInspector] public bool IsIndoor { get; private set; }

    private void Update()
    {
        if (_isNear && Input.GetKeyDown(KeyCode.E) && IsIndoor)
        {
            _escaped.Invoke();
            IsIndoor = false;
        }
        else if(_isNear && Input.GetKeyDown(KeyCode.E))
        {
            IsIndoor = true;
            _entered.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.TryGetComponent(out Thief thief))
        {
            _isNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent(out Thief thief))
        {
            _isNear = false;
        }
    }
}
