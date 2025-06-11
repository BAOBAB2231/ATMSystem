using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public enum Moneytype
    {
        Cash,
        Balance
    }

    [SerializeField] private Text text;
    [SerializeField] private Moneytype moneytype;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        UserData userData = GameManager.Instance.userData;

        if (moneytype == Moneytype.Cash)
            text.text = string.Format("{0:#,0}", userData.money);
        else if (moneytype == Moneytype.Balance)
            text.text = "Balance    " + string.Format("{0:#,0}", userData.balance);
    }
}
