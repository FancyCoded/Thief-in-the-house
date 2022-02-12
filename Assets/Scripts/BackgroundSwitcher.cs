using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    [SerializeField] private Indoor _indoorTemplate;
    [SerializeField] private Outdoor _outdoorTemplate;
    [SerializeField] private House _house;

    private Door _door;
    private Thief _thief;

    private void Start()
    {
        _door = FindObjectOfType<Door>();
        _thief = FindObjectOfType<Thief>();

        Initialize();
    }

    public void ToOutdoor()
    {
        GameObject indoor = GameObject.FindGameObjectWithTag("Indoor");

        Destroy(indoor);

        _door.transform.position = new Vector2(1.4f, -1.98f);
        _thief.transform.position = new Vector2(1, -2.08f);

        Instantiate(_outdoorTemplate, new Vector2(0, -0.42f), Quaternion.identity);
        Instantiate(_house, new Vector2(1.05f, -1.24f), Quaternion.identity);
    }

    public void ToIndoor()
    {
        GameObject outdoor = GameObject.FindGameObjectWithTag("Outdoor");
        GameObject house = GameObject.FindGameObjectWithTag("House");

        Destroy(outdoor);
        Destroy(house);

        _door.transform.position = new Vector2(-2.4f, -2);
        _thief.transform.position = new Vector2(-2.8f, -2.08f);
        Instantiate(_indoorTemplate, new Vector2(0, 0.26f), Quaternion.identity);
    }

    private void Initialize()
    {
        _thief.transform.position = new Vector2(-1.8f, -2.08f);
        Instantiate(_outdoorTemplate, new Vector2(0, -0.42f), Quaternion.identity);
        Instantiate(_house, new Vector2(1.05f, -1.24f), Quaternion.identity);
    }
}
