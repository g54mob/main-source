using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotificationLogLine : Button
{
	[Header("Notification Log Line")]
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _label;

	public NotificationData Data { get; private set; }

	public NotificationLog Log { get; private set; }

	public void Initialize(NotificationData notification, NotificationLog log)
	{
		Data = notification;
		Log = log;
		if (Data == null)
		{
			_icon.overrideSprite = null;
			_label.gameObject.SetActive(value: false);
		}
		else
		{
			_icon.overrideSprite = notification.Properties.Icon;
			_label.gameObject.SetActive(value: true);
			_label.text = notification.ToString();
		}
		base.gameObject.SetActive(value: true);
	}

	public void Initialize(LocalizedString label)
	{
		_icon.overrideSprite = null;
		_label.text = label;
		base.gameObject.SetActive(value: true);
	}

	public override void OnSubmit(BaseEventData eventData)
	{
		if (base.currentSelectionState == SelectionState.Selected)
		{
			Data?.ObjectOfInterest?.NotificationLeftClick();
			base.OnSubmit(eventData);
			if (Data.Properties.CloseOnInteraction)
			{
				Log.RemoveNotification(Data);
			}
		}
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Data != null)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				Data?.ObjectOfInterest?.NotificationLeftClick();
				if (Data.Properties.CloseOnInteraction)
				{
					Log.RemoveNotification(Data);
				}
			}
			else if (eventData.button == PointerEventData.InputButton.Right)
			{
				Log.RemoveNotification(Data);
			}
		}
		base.OnPointerClick(eventData);
	}
}
