using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPattern : MonoBehaviour
{
    public Text characterTitle;
    public Text characterName;
    public Image characterAvatar;

    public Text ATK_Text;
    public Text DEF_Text;

    public Text STR_Text;
    public Text END_Text;
    public Text AGI_Text;
    public Text INT_Text;
    public Text SPR_Text;

    public Button AddPropertyButton_STR;
    public Button AddPropertyButton_END;
    public Button AddPropertyButton_AGI;
    public Button AddPropertyButton_INT;
    public Button AddPropertyButton_SPR;

    public int currentLeftPropertyPointLeft;

    private void Start()
    {

    }

    public void InterfaceInformationLoad()
    {
        currentLeftPropertyPointLeft = SaveSystem.SF.playerData.StatsPointIndex - SaveSystem.SF.playerData.currentCharacter.usedStatsPointIndex;
    }

    public void LoadCurrentCharacterData()
    {
        CharacterData cData = SaveSystem.SF.playerData.currentCharacter;

        characterAvatar.sprite = Resources.Load<Sprite>("Avatar/" + cData.CharacterAvatarID);
        characterName.text= cData.CharacterName;
        
        ATK_Text.text= "基礎攻擊 ATK：" + cData.ATK;
        DEF_Text.text = "基礎防禦 DEF：" + cData.DEF;

        STR_Text.text = "力量 STR：" + cData.STR;
        END_Text.text = "體能 END：" + cData.END;
        AGI_Text.text = "敏捷 AGI：" + cData.AGI;
        INT_Text.text = "智慧 INT：" + cData.INT;
        SPR_Text.text = "精神 SPR：" + cData.SPR;
    }

    public void UpdateStateButtons()
    {
        if (currentLeftPropertyPointLeft > 0)
        {
            AddPropertyButton_STR.interactable = true;
            AddPropertyButton_END.interactable = true;
            AddPropertyButton_AGI.interactable = true;
            AddPropertyButton_INT.interactable = true;
            AddPropertyButton_SPR.interactable = true;
        }
        else
        {
            AddPropertyButton_STR.interactable = false;
            AddPropertyButton_END.interactable = false;
            AddPropertyButton_AGI.interactable = false;
            AddPropertyButton_INT.interactable = false;
            AddPropertyButton_SPR.interactable = false;
        }
    }
}
