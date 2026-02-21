using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterPattern : MonoBehaviour
{
    public CharacterData nowLoadCharacterData;

    public Image CharacterImage;
    public Text CharacterName;
    public Text CharacterDesc;

    public Button ToNextCharacterButton;
    public Button ToLastCharacterButton;
    public Button CreateCharacterButton;
    public GameObject LockGrayImage;

    public int currentInspectingCharacter;
    public PlayerManager playerManager;

    public GameObject RetireCharacterQuestionPanel;


    private void Start()
    {
        playerManager = FindFirstObjectByType<PlayerManager>();
    }

    public void LoadCharacter()
    {
        LoadCharacter(currentInspectingCharacter);
    }
    public void LoadCharacter(int index)
    {
        InterfaceObjectActiveStateCheck();

        CharacterData cData = playerManager.SystemCharacterPool[currentInspectingCharacter].characterData;
        CharacterImage.sprite = Resources.Load<Sprite>("Avatar/" + cData.CharacterAvatarID);
        CharacterName.text = cData.CharacterName;
        CharacterDesc.text = cData.CharacterShortDesc;
        CharacterDesc.text += "\n\n";
        CharacterDesc.text += "基礎力量" + cData.STR + "\n";
        CharacterDesc.text += "基礎體力" + cData.END + "\n";
        CharacterDesc.text += "基礎敏捷" + cData.AGI + "\n";
        CharacterDesc.text += "基礎智慧" + cData.INT + "\n";
        CharacterDesc.text += "基礎精神" + cData.SPR + "\n";
    }

    public void InterfaceObjectActiveStateCheck()
    {
        if (SaveSystem.SF.playerData.playerUnlockCharacterPool[currentInspectingCharacter])
        {
            //Allow create character
            LockGrayImage.SetActive(false);
            CreateCharacterButton.interactable = true;
        }
        else
        {
            LockGrayImage.SetActive(true);
            CreateCharacterButton.interactable = false;
        }
    }

    public void OpenCharacterRetireQuestionWindows()
    {
        RetireCharacterQuestionPanel.SetActive(true);
    }
    public void CloseCharacterRetireQuestionWindows()
    {
        RetireCharacterQuestionPanel.SetActive(false);
    }
    public void LetCurrentCharacterRetireButton()
    {
        playerManager.RetireCurrentCharacter();
        CloseCharacterRetireQuestionWindows();
    }

    public void CreateCharacter()
    {
        if (SaveSystem.SF.playerData.currentCharacter.isCharacterDie == true || SaveSystem.SF.playerData.currentCharacter.isCharacterRetire == true)
        {
            //Allow Create Directly
            CreateCharacter(currentInspectingCharacter);
        }
        else
        {
            //A windows to let player comfirm let player character go retire.
            OpenCharacterRetireQuestionWindows();
        }
    }

    public void CreateCharacter(int index)
    {
        SaveSystem.SF.playerData.currentCharacter = playerManager.SystemCharacterPool[index].characterData;
        SaveSystem.SaveSF();
    }

    public void LoadNextCharacter()
    {
        if (currentInspectingCharacter + 1 >= playerManager.SystemCharacterPool.Length)
        {
            currentInspectingCharacter = 0;
        }
        else
        {
            currentInspectingCharacter += 1;
        }
        LoadCharacter(currentInspectingCharacter);
    }

    public void LoadLastCharacter()
    {
        if (currentInspectingCharacter - 1 < 0)
        {
            currentInspectingCharacter = playerManager.SystemCharacterPool.Length -1;
        }
        else
        {
            currentInspectingCharacter -= 1;
        }
        LoadCharacter(currentInspectingCharacter);
    }
}
