using UnityEngine;

[System.Serializable]
public class UserData
{
    [Header("유저 정보")]
    public string id;
    public string password;
    public string name;
    public int money;
    public ulong balance;

    public UserData()
    {

    }

    public UserData(string id, string password, string name, int money, ulong balance)
    {
        this.id = id;
        this.password = password;
        this.name = name;
        this.money = money;
        this.balance = balance;
    }
}