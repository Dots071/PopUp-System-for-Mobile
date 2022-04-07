using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Popup : MonoBehaviour
{
    [Header("Assets:")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI contentText;

    public PopupButton popupButton;

    private void Start()
    {
   
    }

    public void InitializePopup(string title, string content)
    {
        titleText.text = title;
        contentText.text = content;
        
    }
    
    
}

