using UnityEngine;
using UnityEngine.UI;

public class PopupError : MonoBehaviour
{
    [SerializeField] private Text errorText;
    [SerializeField] private GameObject popupUI;

    public static PopupError Instance;

    private void Awake()
    {
        Instance = this;
        popupUI.SetActive(false);
    }

    public void ShowError(string message)
    {
        errorText.text = message;
        popupUI.SetActive(true);
    }

    public void CloseError()
    {
        popupUI.SetActive(false);
    }
}
