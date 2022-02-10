using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _textValue = "enter 'e' to enter the house";

    private void Start()
    {
        _text.text = _textValue;
    }
}
