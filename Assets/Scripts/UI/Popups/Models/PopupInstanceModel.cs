using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is similar to the PopupModel but was created to avoid bugs in the popupQueue.
public class PopupInstanceModel 
{
    //sets the type of the popup
    public string popupName;

    //sets the prefab of the popup
    public GameObject popupInstance;
}
