using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


// The Animation Manager is in charge of animating the selected objects on screen.
public class AnimationManager : Singleton<AnimationManager>
{
    [SerializeField] Image backgroundImage;

    public void OpenPopupAnimation(GameObject popup)
    {
        popup.transform.DOScale(1, 0.2f);
        popup.transform.DOShakeRotation(1, 50, 5, 45, true);
    }

    public void ClosePopupAnimation(GameObject popup)
    {
        popup.transform.DOScale(0, 1).OnComplete(() => popup.SetActive(false));
    }

    public void FadeInBackground()
    {
        backgroundImage.DOFade(.75f, 0.5f);
    }

    public void FadeOutBackground()
    {
        backgroundImage.DOFade(0, 1);
    }
}
