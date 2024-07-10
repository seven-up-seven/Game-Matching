using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameButton : MonoBehaviour
{
    public enum EButtonType
    {
        None, 
        PairNumberBtn, 
        PuzzleCategoryBtn
    }
    public EButtonType ButtonType = EButtonType.None;
    [HideInInspector] public GameSettings.EPair PairNumber = GameSettings.EPair.ENone;
    [HideInInspector] public GameSettings.EPuzzleCategory PuzzleCategory = GameSettings.EPuzzleCategory.ENone; 
    void Start()
    {
        
    }
    public void SetGameOption(string GameSceneName)
    {
        var comp = gameObject.GetComponent<SetGameButton>(); 
        switch(comp.ButtonType)
        {
            case SetGameButton.EButtonType.PairNumberBtn:
                GameSettings.Instance.SetPairNumber(comp.PairNumber);
                break;
            case SetGameButton.EButtonType.PuzzleCategoryBtn:
                GameSettings.Instance.SetPuzzleCategory(comp.PuzzleCategory);
                break; 
        }
        if (GameSettings.Instance.AllSettingReady())
            SceneManager.LoadScene(GameSceneName); 
    }
}
