using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    [SerializeField] GameObject[] signs;
    [SerializeField] TextMeshProUGUI coins;
    private int numberOfLevel;
    private bool doorIsOpen;
    public void ChangeDoorStatus(bool statement)
    {
        doorIsOpen = statement;
    }
    public bool GetDoorStatus()
    {
        return doorIsOpen;
    }
    public void NextLevel()
    {
        doorIsOpen = false;
        Destroy(levels[numberOfLevel]);
        Destroy(signs[numberOfLevel]);
        numberOfLevel += 1;
        levels[numberOfLevel].SetActive(true);
        signs[numberOfLevel].SetActive(true);
    }
    public void IncreaseCoins()
    {
        coins.text = (int.Parse(coins.text) + 1).ToString();
    }
}
