using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject characterControlCanvas;
    public GameObject createCharacterCanvas;
    public GameObject storyCanvas;
    public GameObject playerAccountCanvas;
    public GameObject systemCanvas;

    public CanvasFocus myCanvasFocus;
    public float UIShowDur = 0.4f;

    public float focusPos = 660;

    public void ClearCanvasFocus()
    {
        myCanvasFocus = CanvasFocus.noFocus;
    }


    public void OpenCanvas_Modify(CanvasFocus onFocusCanva)
    {
        if (myCanvasFocus == onFocusCanva)
        {
            myCanvasFocus = CanvasFocus.noFocus;
        }
        else
        {
            myCanvasFocus = onFocusCanva;
        }
    }

    public void OpenCharacterControlCanvas() { OpenCanvas_Modify(CanvasFocus.characterControl); }
    public void OpenCreateCharacterCanvas() { OpenCanvas_Modify(CanvasFocus.createCharacter); }
    public void OpenStoryCanvas() { OpenCanvas_Modify(CanvasFocus.story); }
    public void OpenPlayerAccountCanvas() { OpenCanvas_Modify(CanvasFocus.playerAccount); }
    public void OpenSystemCanvas() { OpenCanvas_Modify(CanvasFocus.system); }

    public void SyncCanvas()
    {
        switch (myCanvasFocus)
        {
            case CanvasFocus.noFocus:
                characterControlCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                createCharacterCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                storyCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                playerAccountCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                systemCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                break;

            case CanvasFocus.characterControl:
                characterControlCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(focusPos, 0), UIShowDur); //FOCUS
                createCharacterCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                storyCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                playerAccountCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                systemCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                break;

            case CanvasFocus.createCharacter:
                characterControlCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                createCharacterCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(focusPos, 0), UIShowDur); //FOCUS
                storyCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                playerAccountCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                systemCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                break;

            case CanvasFocus.story:
                characterControlCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                createCharacterCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                storyCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(focusPos, 0), UIShowDur); //FOCUS
                playerAccountCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                systemCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                break;

            case CanvasFocus.playerAccount:
                characterControlCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                createCharacterCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                storyCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                playerAccountCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(focusPos, 0), UIShowDur); //FOCUS
                systemCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                break;

            case CanvasFocus.system:
                characterControlCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                createCharacterCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                storyCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                playerAccountCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1970, 0), UIShowDur);
                systemCanvas.GetComponent<RectTransform>().DOAnchorPos(new Vector2(focusPos, 0), UIShowDur); //FOCUS
                break;
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        SyncCanvas();
    }
}

public enum CanvasFocus
{
    noFocus,
    characterControl,

    createCharacter,
    story,
    playerAccount,
    system
}