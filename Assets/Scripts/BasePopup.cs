using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePopup : MonoBehaviour
{
    public virtual void Open()
    {
        if (!IsActive())
        {
            this.gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENED);
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
        else
        {
            Debug.LogError(this + ".Open() – trying to open a popup that is active!");
        }
    }
    public virtual void Close()
    {
        if (IsActive())
        {
            this.gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        }
        else
        {
            Debug.LogError(this + ".Close() – trying to close a popup that is inactive!");
        }
        //gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
