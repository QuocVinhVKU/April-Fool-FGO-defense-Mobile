using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoServantPanel : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI detailServant;

    public void InitInfoSerVantUI(Sprite _icon, string _detailServant)
    {
        icon.sprite = _icon;
        icon.SetNativeSize();
        detailServant.text = _detailServant;
    }
}
