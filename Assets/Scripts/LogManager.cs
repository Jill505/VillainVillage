using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    public TextMeshProUGUI newestTextTMP;
    public TextMeshProUGUI allTextTMP;
    public RectMask2D rectMask;
    public GameObject scrollViewGameObject;

    public bool isInspectingPast;

    public ScrollRect scrollRect;

    public bool OnlyShowLastMessage;
    public int maxShowingLineCount = 14;

    public List<string> receiveLogs = new List<string>();
    string myLogs;

    public int inspectingLogIndex;

    public void RegisterLogs(string str)
    {
        receiveLogs.Add(str);
        newestTextTMP.text = str;   
        ReflashLogs();
    }

    public void SwitchIsMasking()
    {
        rectMask.enabled = OnlyShowLastMessage;
    }
    public void ReflashLogs()
    {
        allTextTMP.text = "";
        myLogs = "";

        for (int i = 0; i < receiveLogs.Count; i++)
        {
            myLogs += receiveLogs[i];
            myLogs += "\n";
        }

        allTextTMP.text = myLogs;
    }
    public void SyncNewestTextUI()
    {
        //ReflashLogs();
    }   

    public void ScrollBarToDown()
    {
        scrollRect.verticalNormalizedPosition = 0;
    }

    void Start()
    {
        ReflashLogs();
        scrollViewGameObject.SetActive(isInspectingPast);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RegisterLogs("Test log - ³y¦¨¶Ë®`");
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Return trigger");
            isInspectingPast = !isInspectingPast;
            scrollViewGameObject.SetActive(isInspectingPast);
            rectMask.enabled = !isInspectingPast;
        }
    }
    public void FixedUpdate()
    {
        SwitchIsMasking();
    }
}
