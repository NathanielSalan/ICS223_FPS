using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, GameActive);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, GameInactive);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, GameActive);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, GameInactive);
    }

    public void GameActive()
    {
        this.enabled = true;
    }

    public void GameInactive()
    {
        this.enabled = false;
    }

}
