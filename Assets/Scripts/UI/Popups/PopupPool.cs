using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PopupPool : Singleton<PopupPool>
{
    private List<GameObject> popupPool;

    //[SerializeField] Transform popupParentTransform;
    private void Start()
    {
        popupPool = new List<GameObject>();
    }

    public GameObject GetPopupFromPool(PopupModel model)
    {
        GameObject popupInstance = popupPool.FirstOrDefault(popup => popup.name == model.popupPrefab.name);
        if(popupInstance != null)
        {
            popupPool.Remove(popupInstance);
            return popupInstance;
        } else
        {
           popupInstance = CreateNewPopup(model);
            return popupInstance;
        }

    }


    public void PoolPopup(GameObject popup)
    {
        popupPool.Add(popup);
    }

    private GameObject CreateNewPopup(PopupModel model)
    {
            GameObject instance = Instantiate(model.popupPrefab, transform);
            instance.name = model.popupPrefab.name;
            instance.transform.localPosition = Vector2.zero;
            instance.SetActive(false);
            return instance;       
    }
}
