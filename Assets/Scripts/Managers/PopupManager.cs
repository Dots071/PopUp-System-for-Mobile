using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The Popup Manager is in charge of showing/removing and queueing popups to the screen.
public class PopupManager : Singleton<PopupManager>
{
    private Queue<GameObject> popupQueue;
    private List<GameObject> activePopupsInScene;

    private void Start()
    {
        popupQueue = new Queue<GameObject>();
        activePopupsInScene = new List<GameObject>();
    }

    // Retrieves a popup from the pool and updates it according to the user input from the TestPanel.
    public void CreatePopup(PopupModel model, string title, string content, bool immediateOpen)
    {
        
        GameObject popup = PopupPool.Instance.GetPopupFromPool(model);

        //Finds the current object's Popup script and initializes it with the user input.
        var popupInstanceScript = popup.GetComponent<Popup>();

        ImporterURL.Instance.FetchImageFromURL(popupInstanceScript.popupButton.buttonImage);
        popupInstanceScript.InitializePopup(title, content);

        if (!immediateOpen && anyPopupsShowing())
        {
            popupQueue.Enqueue(popup);
        }
        else
        {
            ShowPopUp(popup);
        }
    }

    //Takes out a popup from the queue and shows it on screen.
    private void DequeuePopup()
    {
        GameObject nextPopup = popupQueue.Dequeue();
        ShowPopUp(nextPopup);
    }

    //Show popup on screen
    public void ShowPopUp(GameObject popup)
    {
        if (!anyPopupsShowing())
        {
            //Fades the non-relevant background.
            AnimationManager.Instance.FadeInBackground();
        }
        activePopupsInScene.Add(popup);
        popup.SetActive(true);
        AnimationManager.Instance.OpenPopupAnimation(popup);
    }

    //Remove popup from screen and 
    public void UnshowPopup(GameObject popup)
    {
        AnimationManager.Instance.ClosePopupAnimation(popup);
        activePopupsInScene.Remove(popup);

        //Return the popup object to the popup pool
        PopupPool.Instance.PoolPopup(popup);

        if (!anyPopupsShowing())
        {
            if (anyPopupsInQueue())
            {
                DequeuePopup();
            } else
            {
                AnimationManager.Instance.FadeOutBackground(); //Unfades the background.
            }
        }
    }




    //Checks if there are any popups active on screen;
    private bool anyPopupsShowing() =>  activePopupsInScene.Count > 0;

    //Checks if there are any popups waiting in queue;
    private bool anyPopupsInQueue() => popupQueue.Count > 0;

}
