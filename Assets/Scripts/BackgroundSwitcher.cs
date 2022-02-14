using UnityEngine;

public class BackgroundSwitcher : MonoBehaviour
{
    [SerializeField] private Indoor _indoorTemplate;
    [SerializeField] private Outdoor _outdoorTemplate;
    [SerializeField] private House _houseTemplate;
    [SerializeField] private Door _door;
    [SerializeField] private Thief _thief;

    private Outdoor _outdoor;
    private Indoor _indoor;
    private House _house;

    private void Start()
    {
        Initialize();
    }

    public void ExitToOutdoor()
    {
        Destroy(_indoor.gameObject);

        _door.transform.position = new Vector2(1.4f, -1.98f);
        _thief.transform.position = new Vector2(1, -2.08f);
         _outdoor = Instantiate(_outdoorTemplate, new Vector2(0, -0.42f), Quaternion.identity);
        _house = Instantiate(_houseTemplate, new Vector2(1.05f, -1.24f), Quaternion.identity);
    }

    public void EnterToIndoor()
    {
        Destroy(_outdoor.gameObject);
        Destroy(_house.gameObject);

        _door.transform.position = new Vector2(-2.4f, -2);
        _thief.transform.position = new Vector2(-1.8f, -2.08f);
        _indoor = Instantiate(_indoorTemplate, new Vector2(0, 0.26f), Quaternion.identity);
    }

    private void Initialize()
    {
        _thief.transform.position = new Vector2(-1.8f, -2.08f);
        _outdoor = Instantiate(_outdoorTemplate, new Vector2(0, -0.42f), Quaternion.identity);
        _house = Instantiate(_houseTemplate, new Vector2(1.05f, -1.24f), Quaternion.identity);
    }
}
