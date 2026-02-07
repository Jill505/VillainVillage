using System.Collections;
using UnityEngine;

public class FIghtManager : MonoBehaviour
{

    public LogManager logManager;

    public bool stopFightFlag = false;

    public CharacterData playerCharacterData;
    public CharacterData mobCharacterData;

    public float fightSpeedDur;

    public void StartFight()
    {

    }

    public void Next()
    {

    }

    public IEnumerator FightCoroutine()
    {
        while (stopFightFlag == false)
        {

            yield return new WaitForSeconds(fightSpeedDur);  
        }
        yield return null;
    }
}
