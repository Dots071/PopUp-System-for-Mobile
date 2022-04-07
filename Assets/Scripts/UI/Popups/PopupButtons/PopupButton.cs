using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupButton : MonoBehaviour
{
    [SerializeField] GameObject popup;
    [SerializeField] Button thisButton;
    public Image buttonImage;

    public Enums.ButtonAction buttonAction;

    private void Start()
    {

        //Registers to thi
        thisButton.onClick.AddListener(HandleButtonClicked);
    }

    private void HandleButtonClicked()
    {
        switch(buttonAction)
        {
            case Enums.ButtonAction.ClosePopup:
                ClosePopupButton();
                break;

            case Enums.ButtonAction.OpenURL:
                break;

            case Enums.ButtonAction.PlayAnimation:
                break;

        }
    }

    private void ClosePopupButton()
    {
        PopupManager.Instance.UnshowPopup(popup);
    }
}
