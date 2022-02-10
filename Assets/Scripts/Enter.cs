using UnityEngine;
using UnityEngine.Events;

public class Enter : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;

    private bool _isNear;

    private void Update()
    {
        if (_isNear && Input.GetKeyDown(KeyCode.E))
        {
            _entered.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            _isNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent<Thief>(out Thief thief))
        {
            _isNear = false;
        }
    }
}
