using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    private int itemsCollected = 0;
    public int maxItems = 4;
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text ProgressText;
    public Button WinButton;

    void Start()
    {
        ItemText.text += itemsCollected;
        HealthText.text += playerHP;
    }

    public int Items
    {
        get {return itemsCollected;}
        set
        {
            itemsCollected = value;
            ItemText.text = "Items: " + Items;
            
            if (itemsCollected >= maxItems)
            {
                ProgressText.text = "You've found all the items!";

                WinButton.gameObject.SetActive(true);

                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Items found, only " + (maxItems - itemsCollected) + " more!";
            }
        }
    }

    private int playerHP = 10;
    public int HP
    {
        get{return playerHP;}
        set
        {
            playerHP = value;
            HealthText.text = "Health: " + HP;
            Debug.LogFormat("Lives: {0}", playerHP);
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
