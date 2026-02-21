using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;

    public SO_Character[] SystemCharacterPool;
    public bool[] playerUnlockCharacterPool;

    public void CreateCaracter(SO_Character SOC)
    {
        SaveSystem.SF.playerData.createCharacter(SOC);
    }

    public void RetireCurrentCharacter()
    {
        SaveSystem.SF.playerData.currentCharacter.isCharacterRetire = true; 
        //Add Skill Point to player account;
        SaveSystem.SF.playerData.StatsPointIndex += (SaveSystem.SF.playerData.currentCharacter.level / 5);
        //SaveSystem.SF.playerData.currentCharacter = null;
    }
}

[System.Serializable]
public class PlayerData
{
    public string AccountTitle = "無名的";
    public string AccountNickName = "Tav" ;
    public string AccountAvatarID = "";

    public int ReincarnationCount;
    public int StatsPointIndex;

    public int HistoryKill;
    public int HistoryPassiveKill;

    public int HistoryDeath;

    public int HistoryWin_ToPlayer;
    public int HistoryWin_ToMob;
    public int HistoryWin_ToBoss;

    public CharacterData currentCharacter = new CharacterData();
    public List<CharacterData> historyCharacters = new List<CharacterData>();

    public bool[] playerUnlockCharacterPool = new bool[512];

    public void createCharacter(SO_Character soC)
    {
        CharacterData spawnCharData = new CharacterData();

        //init
        spawnCharData.CharacterName = soC.characterData.CharacterName;

        historyCharacters.Add(spawnCharData);
    }

    public bool SetAccountNickName(string p_Name)
    {
        if (p_Name.Length < 20 )
        {
            AccountNickName = p_Name;
            return true;
        }
        else
        {
            return false;    
        }
    }

    public void SetAccountTitle(string p_Title)
    {
        AccountTitle = p_Title;    
    }
}


[System.Serializable]
public class CharacterData
{
    public string CharacterTitle;
    public string CharacterName;
    public string CharacterAvatarID;
    public string CharacterShortDesc;
    public string CharacterLongDesc;

    public List<string> CharacterStory;

    public int level;
    public long exp;

    public int MAX_HP;
    public int currentHP;
    public int ATK;
    
    public int DEF;

    public int STR; //力
    public int END; //體
    public int INT; //智
    public int AGI; //敏
    public int SPR; //精

    //Set up data
    public int usedStatsPointIndex;

    public bool isCharacterDie = false;
    public bool isCharacterRetire = false;
}

[System.Serializable]
public class BattleCharacterData
{
    public string CharacterName;
    public string CharacterAvatarID;

    public int level;
    public long exp;

    public int MAX_HP;
    public int currentHP;
    public int ATK;

    public int DEF;

    public int STR;
    public int END;
    public int INT;
    public int AGI;
    public int SPR;

    //public in battle data
    public int roundUsed;
    public int violentEnergy;
}