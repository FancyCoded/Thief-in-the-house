using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ThiefMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 _horizontal = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        _animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        transform.position += _horizontal * _speed * Time.deltaTime;
    }
}
