using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Notification : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[Tooltip("Displayed image component for notification icon.")]
	[SerializeField]
	private Image _icon;

	[Tooltip("Text component of this notification.")]
	[SerializeField]
	private TextMeshProUGUI _text;

	[Tooltip("Time text component of this notification.")]
	[SerializeField]
	private TextMeshProUGUI _timeText;

	private bool _enabled = true;

	private Button _button;

	private Tooltip _tooltip;

	private UnityEvent _onLeftClick = new UnityEvent();

	private UnityEvent _onMiddleClick = new UnityEvent();

	private UnityEvent _onRightClick = new UnityEvent();

	public NotificationData Data { get; private set; }

	public bool InGameCanvas { get; private set; }

	public float TimeStamp { get; private set; }

	public static List<Notification> Notifications { get; private set; } = new List<Notification>();

	public void Initialize(NotificationData data, bool inGameCanvas)
	{
		_button = GetComponent<Button>();
		_tooltip = GetComponent<Tooltip>();
		Data = data;
		_icon.sprite = data.Properties.Icon;
		InGameCanvas = inGameCanvas;
		TimeStamp = data.Timestamp;
		if (_tooltip != null)
		{
			_tooltip.LocalizedText = Data.Properties.LocalizedDescription;
		}
		_text.text = Data.ToString();
		_timeText.text = GameManager.TimeManager.ReturnTimeInHoursMinutes(TimeStamp, includeUnits: false);
		_onLeftClick.AddListener(delegate
		{
			LeftClick();
		});
		_onRightClick.AddListener(delegate
		{
			RightClick();
		});
		AudioManager.Play(Data.Properties.Audio);
		_enabled = true;
		Notifications.Add(this);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (_enabled)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				_onLeftClick.Invoke();
			}
			else if (eventData.button == PointerEventData.InputButton.Middle)
			{
				_onMiddleClick.Invoke();
			}
			else if (eventData.button == PointerEventData.InputButton.Right)
			{
				_onRightClick.Invoke();
			}
		}
	}

	public void Remove()
	{
		_enabled = false;
		Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		Notifications.Remove(this);
	}

	public void LeftClick()
	{
		if (!(Data.ObjectOfInterest.ToString() == "null"))
		{
			Data.ObjectOfInterest.NotificationLeftClick();
		}
	}

	public void RightClick()
	{
	}

	public void Enter()
	{
		_ = _enabled;
	}

	public void Exit()
	{
		_ = _enabled;
	}

	public void SetActive(bool active)
	{
		_button.interactable = active;
	}

	private void DeactivateButton(bool deactivate)
	{
		SetActive(!deactivate);
	}

	public static bool Exists(NotificationProperties properties, INotificationObjectOfInterest objectOfInterest)
	{
		List<Notification> notifications = Notifications;
		int count = notifications.Count;
		for (int i = 0; i < count; i++)
		{
			Notification notification = notifications[i];
			if (notification.Data.Properties == properties && notification.Data.ObjectOfInterest.IsMatch(objectOfInterest))
			{
				return true;
			}
		}
		return false;
	}
}
