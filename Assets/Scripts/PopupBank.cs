using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject atmUI;
    [SerializeField] private GameObject depositUI;
    [SerializeField] private GameObject withdrawUI;

    [SerializeField] private Money cashDisplay;
    [SerializeField] private Money balanceDisplay;

    [SerializeField] private InputField depositInputField;
    [SerializeField] private InputField withdrawInputField;

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
        PopupError.Instance.CloseError();
    }

    public void ShowDeposit()
    {
        atmUI.SetActive(false);
        depositUI.SetActive(true);
        withdrawUI.SetActive(false);
    }

    public void ShowWithdraw()
    {
        atmUI.SetActive(false);
        depositUI.SetActive(false);
        withdrawUI.SetActive(true);
    }

    public void Deposit(int amount)
    {
        UserData user = GameManager.Instance.userData;

        if (user.money >= amount)
        {
            user.money -= amount;
            user.balance += (ulong)amount;

            cashDisplay.Refresh();
            balanceDisplay.Refresh();

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

                cashDisplay.Refresh();
                balanceDisplay.Refresh();

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

            cashDisplay.Refresh();
            balanceDisplay.Refresh();

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

                cashDisplay.Refresh();
                balanceDisplay.Refresh();

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
}