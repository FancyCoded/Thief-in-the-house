using UnityEngine;
using UnityEngine.Events;

public class Enter : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _escaped;

    private bool _isNear;
    private bool _isIndoor;

    private void Update()
    {
        if (_isNear && Input.GetKeyDown(KeyCode.E) && _isIndoor)
        {
            _escaped.Invoke();
            _isIndoor = false;
        }
        else if(_isNear && Input.GetKeyDown(KeyCode.E))
        {
            _isIndoor = true;
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
