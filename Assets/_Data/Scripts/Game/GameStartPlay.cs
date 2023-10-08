using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPlay : MonoBehaviour
{
    [SerializeField] GameObject towerPanel;
    [SerializeField] GameObject InfoPanel;
    [SerializeField] GameObject SelectPanel;

    public void BtnStartGameOnLick()
    {
        towerPanel.GetComponent<Animator>().SetBool("playGame", true);
        InfoPanel.GetComponent<Animator>().SetBool("hide", true);
        SelectPanel.GetComponent<Animator>().SetBool("hide", true);
    }
}
