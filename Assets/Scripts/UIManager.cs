using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private GameOverScript gameOverPopup;

    private int popupsActive = 0;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.POPUP_OPENED, onPopupOpened); 
        Messenger.AddListener(GameEvent.POPUP_CLOSED, onPopupClosed);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, onPopupOpened);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, onPopupClosed);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.fillAmount = 1;
        healthBar.color = Color.green;
        SetGameActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //!optionsPopup.IsActive() && !settingsPopup.IsActive()
        if (Input.GetKeyDown(KeyCode.Escape) && popupsActive == 0)
        {
            //SetGameActive(false);
            optionsPopup.Open();
        }
    }

    // update score display
    public void UpdateScore(int newScore)
    {
        score.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }

    private void onPopupOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
    }
    private void onPopupClosed()
    {
        popupsActive--;
        if (popupsActive == 0)
        {
            SetGameActive(true);
        }
    }

    public void ShowGameOverPopup()
    {
        gameOverPopup.Open();
    }
}
