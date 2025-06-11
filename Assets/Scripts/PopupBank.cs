using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject atmUI;
    [SerializeField] private GameObject depositUI;
    [SerializeField] private GameObject withdrawUI;
    [SerializeField] private GameObject remittanceUI;

    [SerializeField] private Money cashDisplay;
    [SerializeField] private Money balanceDisplay;

    [SerializeField] private InputField depositInputField;
    [SerializeField] private InputField withdrawInputField;
    [SerializeField] private InputField remittanceInputField;
    [SerializeField] private InputField targetInputField;

    [SerializeField] private Text userNameText;

    private void Start()
    {
        ShowATM();
    }

    public void RefreshUI()
    {
        cashDisplay.Refresh();
        balanceDisplay.Refresh();
        
    }

    public void OpenBankUI()
    {
        ShowATM();
        RefreshUI();
        userNameText.text = GameManager.Instance.userData.name;
    }

    public void ShowATM()
    {
        atmUI.SetActive(true);
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
        remittanceUI.SetActive(false);
        PopupError.Instance.CloseError();
    }

    public void ShowDeposit()
    {
        atmUI.SetActive(false);
        depositUI.SetActive(true);
        withdrawUI.SetActive(false);
        remittanceUI.SetActive(false);
    }

    public void ShowWithdraw()
    {
        atmUI.SetActive(false);
        depositUI.SetActive(false);
        withdrawUI.SetActive(true);
        remittanceUI.SetActive(false);
    }

    public void ShowRemittance()
    {
        atmUI.SetActive(false);
        depositUI.SetActive(false);
        withdrawUI.SetActive(false);
        remittanceUI.SetActive(true);
    }

    public void Deposit(int amount)
    {
        UserData user = GameManager.Instance.userData;

        if (user.money >= amount)
        {
            user.money -= amount;
            user.balance += (ulong)amount;

            RefreshUI();

            GameManager.Instance.SaveUserData(GameManager.Instance.userData);
        }
        else
        {
            PopupError.Instance.ShowError("잔액이 부족합니다.");
        }
    }

    public void DepositInput()
    {
        UserData user = GameManager.Instance.userData;
        int amount;

        if (int.TryParse(depositInputField.text, out amount) && amount > 0)
        {
            if (user.money >= amount)
            {
                user.money -= amount;
                user.balance += (ulong)amount;

                RefreshUI();

                GameManager.Instance.SaveUserData(GameManager.Instance.userData);
            }
            else
            {
                PopupError.Instance.ShowError("잔액이 부족합니다.");
            }
        }
        else
        {
            Debug.Log("값을 제대로 입력하세요.");
        }
    }

    public void Withdrawal(int amount)
    {
        UserData user = GameManager.Instance.userData;

        if (user.balance >= (ulong)amount)
        {
            user.balance -= (ulong)amount;
            user.money += amount;

            RefreshUI();

            GameManager.Instance.SaveUserData(GameManager.Instance.userData);
        }
        else
        {
            PopupError.Instance.ShowError("잔액이 부족합니다.");
        }
    }

    public void WithdrawalInput()
    {
        UserData user = GameManager.Instance.userData;
        int amount;

        if (int.TryParse(withdrawInputField.text, out amount) && amount > 0)
        {
            if (user.balance >= (ulong)amount)
            {
                user.balance -= (ulong)amount;
                user.money += amount;

                RefreshUI();

                GameManager.Instance.SaveUserData(GameManager.Instance.userData);
            }
            else
            {
                PopupError.Instance.ShowError("잔액이 부족합니다.");
            }
        }
        else
        {
            Debug.Log("값을 제대로 입력하세요.");
        }
    }

    public void Remittance()
    {
        int amount;

        // 송금 대상이 비어있을 때 에러
        if (string.IsNullOrEmpty(targetInputField.text))
        {
            PopupError.Instance.ShowError("송금 대상을 확인해주세요.");
            return;
        }

        // (금액이 비어있을 때) || (int 가 아닐 때) || (0 보다 작을 때) 에러
        if (string.IsNullOrEmpty(remittanceInputField.text) || !int.TryParse(remittanceInputField.text, out amount) || amount <= 0)
        {
            PopupError.Instance.ShowError("금액을 확인해주세요.");
            return;
        }

        UserData user = GameManager.Instance.userData;

        // 잔액이 부족할 때 에러
        if (user.balance < (ulong)amount)
        {
            PopupError.Instance.ShowError("잔액이 부족합니다.");
            return;
        }

        // 송금 대상 유저 파일 확인
        string targetPath = Application.dataPath + "/database/" + targetInputField.text + ".json";

        if (!File.Exists(targetPath))
        {
            PopupError.Instance.ShowError("대상이 없습니다.");
            return;
        }

        // 송금 대상 유저 데이터 로드
        string targetJson = File.ReadAllText(targetPath);
        UserData targetUser = JsonUtility.FromJson<UserData>(targetJson);

        // 송금
        user.balance -= (ulong)amount;
        targetUser.balance += (ulong)amount;

        // 저장
        GameManager.Instance.SaveUserData(user);
        GameManager.Instance.SaveUserData(targetUser);

        // UI 갱신
        RefreshUI();

        // 송금 완료 창
        PopupError.Instance.ShowError("송금이 완료되었습니다.");
    }
}