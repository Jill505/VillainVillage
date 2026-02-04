using System.IO;
using UnityEngine;
using AnkrhaDebugLogSystem;

public class SaveSystem : MonoBehaviour
{
    static public SaveFile SF;

    [Header("存檔可視化")]
    ///<summery> 開啟- 關閉顯示存檔 / 關閉 - 同步顯示存檔 <summery>
    [SerializeField] bool isTesting;
    [SerializeField] SaveFile SFShowCase;

    static public string saveFilePath = "SaveFile" + 0;

    private void Awake()
    {
        Debug.Log("載入儲存單元");
        LoadSF();
    }

    private void Update()
    {
        if (isTesting)
        {
            SFShowCase = SF;

            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("測試 - 手動儲存");
                SaveSF();
            }
        }
    }

    static public void SaveSF()
    {
        string fullPath = Application.persistentDataPath + saveFilePath;
        File.WriteAllText(fullPath, JsonUtility.ToJson(SF));
    }

    static public void LoadSF()
    {
        string fullPath = Application.persistentDataPath + saveFilePath;

        if (string.IsNullOrEmpty(fullPath) || !File.Exists(fullPath))
        {
            Debug.Log("載入失敗：路徑是空的或找不到檔案，嘗試生成一個新的檔案。");
            ResetSF();
        }

        SaveFile sSF = JsonUtility.FromJson<SaveFile>(File.ReadAllText(fullPath));
        SF = sSF;
    }

    static public void ResetSF()
    {
        string fullPath = Application.persistentDataPath + saveFilePath;

        SaveFile sSF = new SaveFile();
        File.WriteAllText(fullPath, JsonUtility.ToJson(sSF));

        SF = sSF;
    }
}

[System.Serializable]
public class SaveFile
{
    //SaveFile Sets
    public string SaveName;

    //Player System Setting
    public float BgmVolume = 1f;
    public float SFXVolume = 1f;

    //Game Process

    //Player GamePlay Setting

    //Stats


}