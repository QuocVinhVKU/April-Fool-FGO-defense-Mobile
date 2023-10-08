using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitFirstUI : MonoBehaviour
{
    [SerializeField] private GameObject SelectServantPanel;
    [SerializeField] private GameObject InfoServantPanel;
    [SerializeField] private GameObject PanelTower;

    private void Start()
    {
        InitUIFirstTime();
    }

    void InitUIFirstTime()
    {
        StartCoroutine(DelayShowPanelFirstTime(SelectServantPanel, InfoServantPanel, PanelTower));
    }
    IEnumerator DelayShowPanelFirstTime(GameObject select, GameObject info, GameObject tower)
    {
        select.SetActive(false);
        info.SetActive(false);
        tower.SetActive(false);
        yield return new WaitForSeconds(3f);
        select.SetActive(true);
        info.SetActive(true);
        tower.SetActive(true);
    }

}
