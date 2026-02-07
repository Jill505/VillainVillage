using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;

    public void CreateCaracter()
    {
        SaveSystem.SF.playerData.spawnCharacter();
    }

    public void RemoveCharacter(int index)
    {
        SaveSystem.SF.playerData.removeCharacter(index);
    }

}

[SerializeField]
public class PlayerData
{
    public string nickName;
    public string title;

    public int ReincarnationCount;

    public int HistoryKill;
    public int HistoryPassiveKill;

    public int HistoryDeath;

    public int HistoryWin_ToPlayer;
    public int HistoryWin_ToMob;
    public int HistoryWin_ToBoss;

    public List<CharacterData> myCharacters = new List<CharacterData>();

    public void spawnCharacter()
    {
        CharacterData spawnCharData = new CharacterData();

        myCharacters.Add(spawnCharData);
    }

    public void removeCharacter(int index)
    {
        myCharacters.RemoveAt(index);
    }

    public bool SetNickName(string p_Name)
    {
        if (p_Name.Length < 20 )
        {
            nickName = p_Name;
            return true;
        }
        else
        {
            return false;    
        }
    }

    public void SetTitle(string p_Title)
    {
        title = p_Title;    
    }
}


[System.Serializable]
public class CharacterData
{
    public string CharacterName;
    public string CharacterAvatarID;

    public int level;
    public long exp;

    public int MAX_HP;
    public int ATK;
    
    public int DEF;

    public int STR;
    public int END;
    public int INT;
    public int AGI;
    public int SPR;

    public int inFight_SpeedBarPos;
}