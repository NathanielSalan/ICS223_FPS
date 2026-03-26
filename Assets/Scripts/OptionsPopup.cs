using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : BasePopup
{
    [SerializeField] private UIManager UIManager;
    [SerializeField] private SettingsPopup SettingsPopup;

    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");
        Close();
        SettingsPopup.Open();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        UIManager.SetGameActive(true);
        Close();
    }
}
