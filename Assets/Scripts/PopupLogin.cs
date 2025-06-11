using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogin : MonoBehaviour
{
    [SerializeField] private GameObject popupBankUI;
    [SerializeField] private GameObject popupSignUpUI;

    public InputField idInputField;
    public InputField passwordInputField;

    private void Start()
    {
        popupBankUI.SetActive(false);
        popupSignUpUI.SetActive(false);
        gameObject.SetActive(true);
    }

    public void OnClickLogin()
    {
        string id = idInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrEmpty(id))
        {
            PopupError.Instance.ShowError("ID 를 입력해주세요.");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            PopupError.Instance.ShowError("Password 를 입력해주세요.");
            return;
        }

        string path = Application.dataPath + "/database/" + id + ".json";

        if (File.Exists(path))
        {
            string loadJson = File.ReadAllText(path);
            UserData loadedUser = JsonUtility.FromJson<UserData>(loadJson);

            if (loadedUser.password == password)
            {
                GameManager.Instance.userData = loadedUser;

                popupBankUI.SetActive(true);

                PopupBank popupBank = FindObjectOfType<PopupBank>();
                if (popupBank != null)
                {
                    popupBank.OpenBankUI();
                }

                gameObject.SetActive(false);
            }
            else
            {
                PopupError.Instance.ShowError("비밀번호가 일치하지 않습니다.");
            }
        }
        else
        {
            PopupError.Instance.ShowError("해당 ID 는 존재하지 않습니다.");
        }
    }

    public void OnClickSignUp()
    {
        popupSignUpUI.SetActive(true);
    }
}
