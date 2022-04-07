using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class PopupModel 
{
    //sets the type of the popup
    public Enums.PopupType popupType;

    //sets the prefab of the popup
    public GameObject popupPrefab;

}
