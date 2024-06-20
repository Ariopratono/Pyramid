using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagement : MonoBehaviour
{
    #region Panel Management
    //Region ini mengatur agar start panel tidak muncul 2x
    [Header("Panel Start")]
    public GameObject startPanel;
    [Header("Panel Level")]
    public GameObject levelPanel;
    public void ShowStartPanel()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
    public void ShowLevelPanel() //panggil dibutton Start
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
        GameManager.Instance.isStart = true;
    }
    
    private void CheckStartPanelExp()
    {
        if (isStart())
        {
            ShowLevelPanel();
            
        }
        else
        {
            ShowStartPanel();
        }
    }

    private bool isStart()
    {
        return GameManager.Instance.isStart;
    }
    #endregion
}
