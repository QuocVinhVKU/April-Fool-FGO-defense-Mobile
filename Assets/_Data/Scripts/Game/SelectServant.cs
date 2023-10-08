using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectServant : MonoBehaviour
{
    [SerializeField] PanelTower panelTower;
    [SerializeField] GameObject panelSelected;
    [SerializeField] InfoServantPanel servantPanel;
    private bool isSelected = false;

    [SerializeField] private Sprite iconServant;
    [SerializeField] private GameObject charPrefab;
    public void SelectThisServant()
    {
        isSelected = !isSelected;

        if (isSelected)
        {
            AddServantToTowerPanel();
            SetUIInfoServant();
        }
        else
        {
            RemoveServantFromTowerPanel();
        }
    }
    private void AddServantToTowerPanel()
    {
        foreach (var slot in panelTower.listSlot)
        {
            if (slot.GetComponent<SlotStatus>().isEmpty)
            {
                Spawniving spawniving = slot.GetComponent<Spawniving>();
                spawniving.enabled = true;
                spawniving.icon.sprite = iconServant;
                spawniving.icon.SetNativeSize();
                spawniving.CharPrefab = charPrefab;
                spawniving.InitUI();

                spawniving.gameObject.GetComponent<Image>().raycastTarget = true;
                panelSelected.SetActive(true);

                slot.GetComponent<SlotStatus>().isEmpty = false;
                return;
            }
        }
    }
    private void RemoveServantFromTowerPanel()
    {
        foreach (var slot in panelTower.listSlot)
        {
            if (!slot.GetComponent<SlotStatus>().isEmpty)
            {
                Spawniving spawniving = slot.GetComponent<Spawniving>();
                if (spawniving.CharPrefab == charPrefab)
                {
                    spawniving.gameObject.GetComponent<Image>().raycastTarget = false;

                    spawniving.icon.sprite = spawniving.defaultIcon;
                    spawniving.icon.SetNativeSize();
                    spawniving.CharPrefab = null;
                    spawniving.price.text = "x";
                    panelSelected.SetActive(false);
                    slot.GetComponent<SlotStatus>().isEmpty = true;

                    spawniving.enabled = false;
                    return;
                }
            }
        }
    }
    private void SetUIInfoServant()
    {
        Servant servant = charPrefab.GetComponent<Servant>();
        string detail = $"heal: {servant.health} <br>" +
                        $"damage: {servant.dame} <br>" +
                        $"<color=#fa21a0>{servant.ServantName }</color> {servant.servantDetail}";
        servantPanel.InitInfoSerVantUI(iconServant, detail);
    }
}
