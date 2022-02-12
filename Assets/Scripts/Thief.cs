using UnityEngine;

public class Thief : MonoBehaviour
{
    [HideInInspector] public bool IsBreakIn { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Indoor indoor))
        {
            IsBreakIn = true;
        }
        else if(collision.gameObject.TryGetComponent(out Outdoor outdoor))
        {
            IsBreakIn = false;
        }
    }
}
