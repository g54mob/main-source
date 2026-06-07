using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UI.PajamaLlama;

public class NotificationLog : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ScrollRectSelectionScroller.IProvider, IUIFlagsProvider, ICancelable
{
	[SerializeField]
	private int _lineHeight = 36;

	[SerializeField]
	private ScrollRect _scrollRect;

	[SerializeField]
	private LayoutElement _scrollRectLayoutElement;

	[SerializeField]
	private int _scrollRectMaxLines = 5;

	[SerializeField]
	private ChildBehaviourCache<NotificationLogLine> _lineCache;

	[SerializeField]
	private NotificationLogSelectableGroup _selectableGroup;

	[SerializeField]
	private float _maximumNotificationExpirationTime = 300f;

	[Header("UI Flags")]
	[SerializeField]
	private PanelContainerFlags _uiFlags;

	[SerializeField]
	private InputFlags _uiFlagsInputs = InputFlags.Joystick;

	private List<NotificationProperties> _propertiesList = new List<NotificationProperties>();

	private List<NotificationData> _notifications = new List<NotificationData>();

	private List<NotificationLogLine> _lines = new List<NotificationLogLine>();

	private float _scrollRectHeightMax;

	private float _scrollRectHeight;

	private HorizontalOrVerticalLayoutGroup _contentLayoutGroup;

	private LayoutElementTweener _layoutElementTweener;

	private Coroutine _openCloseCoroutine;

	private Scrollbar _verticalScrollBar;

	private bool _updateLines;

	public GameObject SelectedGameObject
	{
		get
		{
			if (!_selectableGroup || !_selectableGroup.Selected)
			{
				return null;
			}
			return _selectableGroup.Selected.gameObject;
		}
	}

	public bool IsOpen { get; private set; }

	public PanelContainerFlags Flags => _uiFlags;

	public bool BlockCancel => false;

	public float MaximumNotificationExpirationTime => _maximumNotificationExpirationTime;

	private void Awake()
	{
		_contentLayoutGroup = _scrollRect.content.GetComponent<HorizontalOrVerticalLayoutGroup>();
		_scrollRectHeightMax = GetLineCountHeight(_scrollRectMaxLines);
		_layoutElementTweener.SetTarget(_scrollRectLayoutElement);
		_verticalScrollBar = _scrollRect.verticalScrollbar;
		_verticalScrollBar.gameObject.SetActive(value: false);
		_scrollRect.verticalScrollbar = null;
		_scrollRectLayoutElement.minHeight = _lineHeight;
		_selectableGroup.Initialize(_lines);
	}

	private void LateUpdate()
	{
		float now = GameManager.TimeManager.ReturnTotalTimePlayed();
		int count = _notifications.Count;
		while (0 < count--)
		{
			NotificationData notificationData = _notifications[count];
			if (IsNotificationExpired(notificationData.Timestamp, notificationData.Properties.Expiration, now))
			{
				notificationData.Dispose();
				_notifications.RemoveAt(count);
				_updateLines = true;
			}
		}
		if (_updateLines)
		{
			UpdateLines();
		}
	}

	public bool AddNotification(NotificationProperties properties, INotificationObjectOfInterest objectOfInterest, float timestamp)
	{
		if (objectOfInterest.ObjectOfInterestType == ObjectType.Day && objectOfInterest is DayObjectOfInterest dayObjectOfInterest)
		{
			if (dayObjectOfInterest.DayIndex >= GameManager.TimeManager.Days.Count)
			{
				Debug.LogException(new Exception($"Trying to restore a daily report for a day that did not happen ({dayObjectOfInterest.DayIndex + 1})!"));
				return false;
			}
			foreach (NotificationData notification in _notifications)
			{
				if (notification.ObjectOfInterest is DayObjectOfInterest dayObjectOfInterest2 && dayObjectOfInterest2.DayIndex == dayObjectOfInterest.DayIndex)
				{
					if (!LoadingScreen.IsLoading)
					{
						Debug.LogException(new Exception($"A duplicate notification is being added for daily report {dayObjectOfInterest.DayIndex + 1}, this is a bug!"));
					}
					return false;
				}
			}
		}
		float num = GameManager.TimeManager.ReturnTotalTimePlayed();
		if (num < timestamp)
		{
			Debug.LogException(new Exception($"A notification with timestamp {timestamp}, which is larger than the current play time ({num}), is being added tot the notfication log." + "Clamping it to the current play time"));
			timestamp = num;
		}
		if (properties == null || IsNotificationExpired(timestamp, properties.Expiration, num))
		{
			return false;
		}
		if (_propertiesList.AddUnique(properties))
		{
			Debug.Log($"'{properties.name}' has expiration: {properties.Expiration}");
		}
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
		}
		_notifications.Add(NotificationData.Get(properties, objectOfInterest, timestamp));
		_updateLines = true;
		if (IsOpen)
		{
			Open();
		}
		else
		{
			_scrollRect.verticalNormalizedPosition = 1f;
		}
		return true;
	}

	public void RemoveNotification(NotificationData notification)
	{
		if (_notifications.Remove(notification))
		{
			notification.Dispose();
			_updateLines = true;
		}
	}

	public bool TryCancel()
	{
		Close();
		return true;
	}

	private void UpdateLines()
	{
		_lineCache.Reset();
		_lines.Clear();
		foreach (NotificationData notification in _notifications)
		{
			NotificationLogLine notificationLogLine = _lineCache.Get();
			notificationLogLine.Initialize(notification, this);
			notificationLogLine.interactable = IsOpen;
			_lines.Add(notificationLogLine);
		}
		_lineCache.Trim();
		_scrollRectHeight = Mathf.Min(GetLineCountHeight(_lines.Count), _scrollRectHeightMax);
		_updateLines = false;
		if (_notifications.Count == 0)
		{
			Close();
		}
	}

	private float GetLineCountHeight(int lineCount)
	{
		return Mathf.Max(_lineHeight, lineCount * _lineHeight);
	}

	private void SetLinesInteractable(bool interactable)
	{
		for (int i = 0; i < _lineCache.Count; i++)
		{
			_lineCache.Instances[i].interactable = interactable;
		}
	}

	public void Open()
	{
		if (_openCloseCoroutine != null)
		{
			StopCoroutine(_openCloseCoroutine);
		}
		_openCloseCoroutine = StartCoroutine(OpenRoutine());
	}

	public void Close()
	{
		if (_openCloseCoroutine != null)
		{
			StopCoroutine(_openCloseCoroutine);
		}
		_openCloseCoroutine = StartCoroutine(CloseRoutine());
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_scrollRect.verticalNormalizedPosition = 1f;
		_scrollRect.gameObject.SetActive(value: true);
		Open();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Close();
	}

	private IEnumerator CloseRoutine()
	{
		IsOpen = false;
		_scrollRect.verticalScrollbar = null;
		_verticalScrollBar.gameObject.SetActive(value: false);
		_selectableGroup.enabled = false;
		FlotsamInputManager.RemoveCancelable(this);
		SetLinesInteractable(interactable: false);
		UIManager.RemoveFlagsProvider(this);
		_layoutElementTweener.InitializeProperty(LayoutElementTweener.Properties.PreferrredHeight, _lineHeight);
		yield return Tweener.TweenRoutine(0.1f, Easing.SineOut, true, _layoutElementTweener);
		_scrollRect.verticalNormalizedPosition = 1f;
	}

	private IEnumerator OpenRoutine()
	{
		SetLinesInteractable(interactable: true);
		_layoutElementTweener.InitializeProperty(LayoutElementTweener.Properties.PreferrredHeight, _scrollRectHeight);
		yield return Tweener.TweenRoutine(0.25f, Easing.SineIn, true, _layoutElementTweener);
		if (_scrollRectMaxLines < _lines.Count)
		{
			_scrollRect.verticalScrollbar = _verticalScrollBar;
		}
		_selectableGroup.enabled = true;
		FlotsamInputManager.PushCancelable(this);
		if (FlotsamInputManager.HasActiveInput(_uiFlagsInputs))
		{
			UIManager.AddFlagsProvider(this);
		}
		IsOpen = true;
	}

	private bool IsNotificationExpired(float timeStamp, float expirationTime, float now)
	{
		expirationTime = ((expirationTime <= 0f) ? _maximumNotificationExpirationTime : Mathf.Min(expirationTime, _maximumNotificationExpirationTime));
		return expirationTime < now - timeStamp;
	}
}
