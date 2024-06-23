using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public int mylevel;
    public Button[] levelButtons;

    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        mylevel = GameManager.Instance.levelCurrent;
        DisableLockedLevel();
        AddChangeSceneListener();
//         CheckStartPanelExp();
    }

//     #region Panel Management
//     //Region ini mengatur agar start panel tidak muncul 2x
//     [Header("Panel Start")]

//     public int sceneIndex=0;
    void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {   
            if (i > mylevel) levelButtons[i].interactable = false;
        }
    }
    void AddChangeSceneListener()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1; 
            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }

//     #endregion

//     #region Panel Management
//     //Region ini mengatur agar start panel tidak muncul 2x
//     [Header("Panel Start")]
//     public GameObject startPanel;
//     [Header("Panel Level")]
//     public GameObject levelPanel;
//     public void ShowStartPanel()
//     {
//         startPanel.SetActive(true);
//         levelPanel.SetActive(false);
//     }
//     public void ShowLevelPanel() //panggil dibutton Start
//     {
//         startPanel.SetActive(false);
//         levelPanel.SetActive(true);
//         GameManager.Instance.isStart = true;
//     }
    
//     private void CheckStartPanelExp()
//     {
//         if (isStart())
//         {
//             ShowLevelPanel();
            
//         }
//         else
//         {
//             ShowStartPanel();
//         }
//     }

//     private bool isStart()
//     {
//         return GameManager.Instance.isStart;
//     }
//     #endregion

}
