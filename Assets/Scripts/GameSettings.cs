using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private int settings;
    private const int SettingNumber = 2; 
    public enum EPair
    {
        ENone = 0, 
        E10 = 10, 
        E15 = 15,
        E20 = 20 
    }
    public enum EPuzzleCategory
    {
        ENone, 
        EVeg, 
        EFruit
    }

    public struct setting
    {
        public EPair pair_number;
        public EPuzzleCategory puzzle_category; 
    }

    private setting game_setting;

    public static GameSettings Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(this); 
        }
    }

    void Start()
    {
        game_setting = new setting();
        ResetGameSetting(); 
    }

    
    public void SetPairNumber(EPair number)
    {
        if (game_setting.pair_number == EPair.ENone)
            settings++; 
        game_setting.pair_number = number;
    }
    public void SetPuzzleCategory(EPuzzleCategory cat)
    {
        if (game_setting.puzzle_category == EPuzzleCategory.ENone)
            settings++;
        game_setting.puzzle_category = cat; 
    }
    public EPair GetPairNumber()
    {
        return game_setting.pair_number; 
    }
    public EPuzzleCategory GetPuzzleCategory()
    {
        return game_setting.puzzle_category; 
    }
    public void ResetGameSetting()
    {
        settings = 0; 
        game_setting.pair_number = EPair.ENone;
        game_setting.puzzle_category = EPuzzleCategory.ENone;
    }
    public bool AllSettingReady()
    {
        return settings == SettingNumber; 
    }
}
