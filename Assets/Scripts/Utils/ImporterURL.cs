using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImporterURL : Singleton<ImporterURL>
{

    public void FetchImageFromURL(Image img)
    {
        StartCoroutine(FetchImage(img));
    }

    IEnumerator FetchImage(Image tempImage)
        {
            WWW www = new WWW(URLs.gotItGreenButtonImage);
            yield return www;
            tempImage.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        Debug.Log("Image Loaded!");
        }
    

    private void OnFetchImageComplete(Image imageReady)
    {
        
    }
}
