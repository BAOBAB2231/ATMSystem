using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject popupLoginUI;
    [SerializeField] private GameObject popupBankUI;

    public UserData userData;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            userData = new UserData("admin", "admin", "김영진", 100000, 50000);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        popupLoginUI.SetActive(true);
        popupBankUI.SetActive(false);
    }

    public void SaveUserData(UserData userData)
    {
        string folderPath = Application.dataPath + "/database/";

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string json = JsonUtility.ToJson(userData, true);

        string path = folderPath + userData.id + ".json";

        File.WriteAllText(path, json);
    }

    public void LoadUserData(string id)
    {
        string path = Application.dataPath + "/database/" + id + ".json";

        if (File.Exists(path))
        {
            string loadJson = File.ReadAllText(path);
            userData = JsonUtility.FromJson<UserData>(loadJson);

            PopupBank popupBank = FindObjectOfType<PopupBank>();
            if (popupBank != null)
            {
                popupBank.RefreshUI();
            }
        }
        else
        {
            PopupError.Instance.ShowError("해당 ID는 존재하지 않습니다.");
        }
    }
}
