using UnityEngine;

public class StroyManager : MonoBehaviour
{
    public AK_StoryManager AKSM;

    public AKSO_Story AKSOS;// AnKhra Scriptable Object Stroy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AKSM.ReceiveAKSO_Story(AKSOS);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
