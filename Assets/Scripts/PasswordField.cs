using UnityEngine;
using UnityEngine.UI;

public class PasswordField : MonoBehaviour
{
    public InputField inputField;
    public Text asteriskText;

    private string password = "";

    void Start()
    {
        inputField.onValueChanged.AddListener(OnPasswordValueChanged);
    }

    void OnPasswordValueChanged(string input)
    {
        password = inputField.text;
        asteriskText.text = new string('*', password.Length);
    }
}
