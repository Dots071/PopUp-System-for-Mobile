using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// The test panel gets the popup data from the user and passes it to the popup manager.
public class TestPanel : Singleton<TestPanel>
{
    [Header("Data Input Menu")]
    public Dropdown popupTypeDropdown;
    public InputField titleInputField;
    public InputField contentInputField;

    [Header("Popup Layouts")]
    public List<PopupModel> popupModels;

    private void Start()
    {
        UpdateTypesInDropdown();
    }

    //Gets the popupType from the dropdown menu and passes it to the PopUpManager for Opening.
    public void OpenPopup()
    {
        PopupManager.Instance.CreatePopup(popupModels[popupTypeDropdown.value], titleInputField.text, contentInputField.text, true);
       
    }

    public void QueuePopup()
    {
        PopupManager.Instance.CreatePopup(popupModels[popupTypeDropdown.value], titleInputField.text, titleInputField.text, false);

    }


    //Clears and fills the dropdown options with the popupModel List.
    private void UpdateTypesInDropdown()
    {
        popupTypeDropdown.ClearOptions();


        foreach (PopupModel model in popupModels)
        {
            popupTypeDropdown.options.Add(new Dropdown.OptionData() { text = model.popupType.ToString() });
        }

        popupTypeDropdown.RefreshShownValue();
    }
}
