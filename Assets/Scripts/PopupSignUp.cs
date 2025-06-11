using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PopupSignUp : MonoBehaviour
{
    public InputField idInputField;
    public InputField nameInputField;
    public InputField passwordInputField;
    public InputField passwordConfirmInputField;

    public void OnClickSignUp()
    {
        if (string.IsNullOrEmpty(idInputField.text))
        {
            PopupError.Instance.ShowError("ID 를 확인해주세요.");
            return;
        }

        if (string.IsNullOrEmpty(nameInputField.text))
        {
            PopupError.Instance.ShowError("Name 을 확인해주세요.");
            return;
        }

        if (string.IsNullOrEmpty(passwordInputField.text))
        {
            PopupError.Instance.ShowError("Password 를 확인해주세요.");
            return;
        }

        if (string.IsNullOrEmpty(passwordConfirmInputField.text))
        {
            PopupError.Instance.ShowError("Password Confirm 을 확인해주세요.");
            return;
        }

        if (passwordInputField.text != passwordConfirmInputField.text)
        {
            PopupError.Instance.ShowError("Password 가 서로 일치하지 않습니다.");
            return;
        }

        string path = Application.dataPath + "/database/" + idInputField.text + ".json";

        if (File.Exists(path))
        {
            PopupError.Instance.ShowError("이미 존재하는 계정입니다.");
            return;
        }

        UserData newUser = new UserData(
            idInputField.text,
            passwordInputField.text,
            nameInputField.text,
            100000,
            50000
        );

        GameManager.Instance.SaveUserData(newUser);

        PopupError.Instance.ShowError("회원가입 완료");
        gameObject.SetActive(false);
    }

    public void OnClickCancel()
    {
        gameObject.SetActive(false);
    }
}
