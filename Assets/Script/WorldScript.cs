﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuState
{
    mainMenu,
    introMode,
    merchantMode,
    storyMode
}

public class WorldScript : MonoBehaviour {
    public static MenuState menuState;

    public GameObject _mainMenuMode;
    public GameObject _merchantMode;
    public GameObject _player;
    public GameObject _storyMode;

    public playerScript player;
    public customerScript customer;


    void Awake()
    {
        _mainMenuMode = GameObject.FindGameObjectWithTag("mainMenuMode");
        _merchantMode = GameObject.FindGameObjectWithTag("merchantMode");
        _player = GameObject.FindGameObjectWithTag("Player");
        _storyMode = GameObject.FindGameObjectWithTag("storyMode");

        _mainMenuMode.SetActive(true);
        _merchantMode.SetActive(false);
        _player.SetActive(false);
        _storyMode.SetActive(false);
    }

	// Use this for initialization
	void Start () {
        menuState = MenuState.mainMenu;
	}
	
	// Update is called once per frame
	void Update () {
		if (menuState == MenuState.mainMenu)
        {
            //Debug.Log("we are in main menu mode");
        }

        if (menuState == MenuState.merchantMode)
        {
            //Debug.Log("we are in merchant mode");

            _merchantMode.SetActive(true);
            _player.SetActive(true);
            _mainMenuMode.SetActive(false);
            _storyMode.SetActive(false);
        }

        if (menuState == MenuState.storyMode)
        {
            _merchantMode.SetActive(false);
            _mainMenuMode.SetActive(false);
            _storyMode.SetActive(true);
        }
    }

    public void changeState()
    {
        if (menuState == MenuState.mainMenu)
        {
            menuState = MenuState.merchantMode;
           // Debug.Log("change state");
        }

        else if (menuState == MenuState.merchantMode)
        {
            menuState = MenuState.storyMode;
        }
        
    }

    public void endDay()
    {
        menuState = MenuState.merchantMode;
        player.day++;
        if(customer.charaState %2 == 0)
        {
            customer.charaState++;
            customer.setChara();
            player.money += 50;
            player.reputation += 10;
        }
    }
}
