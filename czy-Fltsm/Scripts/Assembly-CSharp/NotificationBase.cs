using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class NotificationBase : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
{
	[Header("Notification Base")]
	[SerializeField]
	protected TextMeshProUGUI _text;

	public static List<NotificationBase> ActiveNotifications = new List<NotificationBase>(8);

	public static NotificationBase SelectedNotification;

	private void OnEnable()
	{
		if (ActiveNotifications.AddUnique(this))
		{
			GameEventDispatcher.Dispatch(GameEventType.NotificationsUpdated);
		}
	}

	private void OnDisable()
	{
		if (ActiveNotifications.Remove(this))
		{
			GameEventDispatcher.Dispatch(GameEventType.NotificationsUpdated);
		}
	}

	public abstract void OnLeftClick();

	public abstract void OnRightClick();

	public void OnPointerClick(PointerEventData eventData)
	{
		switch (eventData.button)
		{
		case PointerEventData.InputButton.Left:
			OnLeftClick();
			break;
		case PointerEventData.InputButton.Right:
			OnRightClick();
			break;
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		SelectedNotification = this;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		if (SelectedNotification == this)
		{
			SelectedNotification = null;
		}
	}
}
