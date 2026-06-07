using System;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using SINetworking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
	public enum DropType
	{
		None = -1,
		Simple = 0,
		List = 1
	}

	public enum NotificationType
	{
		Issue = 0,
		Warning = 1,
		Good = 2,
		Neutral = 3,
		Hint = 4
	}

	public enum HeaderType
	{
		Hint = 0,
		Issue = 1,
		Messages = 2,
		Old = 3
	}

	public static NotificationManager Instance;

	public UINotificationDropdown[] DropDownPrefabs;

	public UINotification NotificationPrefab;

	public NotificationHeader[] Headers;

	public RectTransform Self;

	public RectTransform Holder;

	public Text OldHeader;

	public float ScrollDelta = 16f;

	[NonSerialized]
	private float _lastScreenWidth = -1f;

	[NonSerialized]
	private Dictionary<KeyValuePair<Type, uint>, NotificationMessage> _aggregates = new Dictionary<KeyValuePair<Type, uint>, NotificationMessage>();

	[NonSerialized]
	private List<NotificationMessage> _threadedQueue = new List<NotificationMessage>();

	public Image MuteIcon;

	private Sequence _activeSequence;

	[NonSerialized]
	private int _refreshOffset;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		UpdateY(null, false);
		OldHeader.text = ((GameSettings.DaysPerMonth > 1) ? "Yesterday".Loc() : "Lastmonth".Loc());
	}

	public static bool CheckAggregates<T>(IEnumerable<object> os, uint id = 0u) where T : NotificationMessage
	{
		if (Instance == null)
		{
			return true;
		}
		lock (Instance._aggregates)
		{
			NotificationMessage value;
			if (Instance._aggregates.TryGetValue(new KeyValuePair<Type, uint>(typeof(T), id), out value))
			{
				bool flag = false;
				foreach (object o in os)
				{
					flag |= value.AddItem(o);
				}
				if (flag && value.UIItem.Parent == Instance.GetHeader(HeaderType.Old))
				{
					value.UIItem.Parent.Notifications.Remove(value.UIItem);
					NotificationHeader header = Instance.GetHeader(HeaderType.Messages);
					header.Notifications.Add(value.UIItem);
					value.UIItem.Parent = header;
				}
				return true;
			}
		}
		return false;
	}

	public static bool CheckAggregate<T>(object o, uint id = 0u, bool createNewIfOld = false) where T : NotificationMessage
	{
		return CheckAggregate(typeof(T), o, id, createNewIfOld);
	}

	public static bool CheckAggregate(Type mType, object o, uint id = 0u, bool createNewIfOld = false)
	{
		if (Instance == null)
		{
			return true;
		}
		lock (Instance._aggregates)
		{
			NotificationMessage value;
			if (Instance._aggregates.TryGetValue(new KeyValuePair<Type, uint>(mType, id), out value))
			{
				if (createNewIfOld && value.UIItem.Parent == Instance.GetHeader(HeaderType.Old))
				{
					return false;
				}
				if (value.AddItem(o) && value.UIItem.Parent == Instance.GetHeader(HeaderType.Old))
				{
					value.UIItem.Parent.Notifications.Remove(value.UIItem);
					NotificationHeader header = Instance.GetHeader(HeaderType.Messages);
					header.Notifications.Add(value.UIItem);
					value.UIItem.Parent = header;
					Instance.UpdateY();
				}
				return true;
			}
		}
		return false;
	}

	public void ToggleMute()
	{
		GameSettings.Instance.MuteIssues = !GameSettings.Instance.MuteIssues;
		UpdateMuteSprite();
	}

	public void UpdateMuteSprite()
	{
		MuteIcon.sprite = ObjectDatabase.GetIcon(GameSettings.Instance.MuteIssues ? "SpeakerOff" : "Speaker");
	}

	public void OnScroll(BaseEventData e)
	{
		PointerEventData pointerEventData = e as PointerEventData;
		if (pointerEventData != null)
		{
			Scroll(pointerEventData.scrollDelta.y);
		}
	}

	public void Scroll(float delta)
	{
		Self.anchoredPosition = new Vector2(Self.anchoredPosition.x, Mathf.Clamp(Self.anchoredPosition.y - delta * ScrollDelta, 0f, Mathf.Max(0f, Self.rect.height - Holder.rect.height)));
	}

	public static void RemoveAggregate<T>(object o, uint id = 0u) where T : NotificationMessage
	{
		if (Instance == null)
		{
			return;
		}
		lock (Instance._aggregates)
		{
			NotificationMessage value;
			if (Instance._aggregates.TryGetValue(new KeyValuePair<Type, uint>(typeof(T), id), out value))
			{
				value.RemoveItem(o);
			}
		}
	}

	public NotificationHeader GetHeader(HeaderType t)
	{
		return Headers[(int)t];
	}

	public static void AddNotification(string msg, string icon, NotificationType type)
	{
		AddNotification(new NotificationMessage(msg, icon, type));
	}

	public static void AddNotification(string msg, string icon, NotificationType type, UniqueNotification.MessageID id)
	{
		if (!UniqueNotification.CheckForPresence(id))
		{
			AddNotification(new UniqueNotification(msg, icon, id, type));
		}
	}

	public static void SendNotification(NotificationMessage msg, byte targetID)
	{
		SendNotification(msg, NetworkMessaging.MessageTarget.Specifically, targetID);
	}

	public static void SendNotification(NotificationMessage msg, NetworkMessaging.MessageTarget target, byte targetID)
	{
		NetworkMessaging.SendNotification(msg, target, targetID);
	}

	public static void AddNotification(NotificationMessage msg)
	{
		if (Instance == null || SelectorController.Instance == null || !SelectorController.Instance.DoneLoading)
		{
			return;
		}
		if (Thread.CurrentThread != ModController.MainThread)
		{
			bool flag = true;
			if (msg.IsAggregate())
			{
				lock (Instance._aggregates)
				{
					KeyValuePair<Type, uint> key = new KeyValuePair<Type, uint>(msg.GetType(), msg.AggregateID());
					if (Instance._aggregates.ContainsKey(key))
					{
						flag = false;
					}
					else
					{
						Instance._aggregates[key] = msg;
					}
				}
			}
			if (flag)
			{
				lock (Instance._threadedQueue)
				{
					Instance._threadedQueue.Add(msg);
				}
			}
		}
		else
		{
			Instance.SubAddNotification(msg);
		}
	}

	public static void AddHint(HintController.Hints hint)
	{
		if (!CheckAggregate<HintNotification>(null, (uint)hint))
		{
			AddNotification(new HintNotification(hint));
		}
	}

	public NotificationMessage[][] SerializeAll()
	{
		return new NotificationMessage[4][]
		{
			SerializeHeader(HeaderType.Hint),
			SerializeHeader(HeaderType.Issue),
			SerializeHeader(HeaderType.Messages),
			SerializeHeader(HeaderType.Old)
		};
	}

	public void DeserializeAll(NotificationMessage[][] messages)
	{
		DeserializeHeader(messages[0], HeaderType.Hint);
		DeserializeHeader(messages[1], HeaderType.Issue);
		DeserializeHeader(messages[2], HeaderType.Messages);
		DeserializeHeader(messages[3], HeaderType.Old);
		UpdateY(null, false);
	}

	public NotificationMessage[] SerializeHeader(HeaderType header)
	{
		return GetHeader(header).Notifications.SelectInPlace((UINotification x) => x.Message);
	}

	public void DeserializeHeader(NotificationMessage[] messages, HeaderType header)
	{
		NotificationHeader header2 = GetHeader(header);
		foreach (NotificationMessage notificationMessage in messages)
		{
			if (notificationMessage.IsAggregate())
			{
				KeyValuePair<Type, uint> key = new KeyValuePair<Type, uint>(notificationMessage.GetType(), notificationMessage.AggregateID());
				lock (_aggregates)
				{
					if (_aggregates.ContainsKey(key))
					{
						continue;
					}
					_aggregates[key] = notificationMessage;
					goto IL_006f;
				}
			}
			goto IL_006f;
			IL_006f:
			UINotification uINotification = (notificationMessage.UIItem = UnityEngine.Object.Instantiate(NotificationPrefab));
			uINotification.transform.SetParent(base.transform, false);
			uINotification.transform.SetAsFirstSibling();
			uINotification.Set(notificationMessage);
			header2.Notifications.Add(uINotification);
			uINotification.Parent = header2;
		}
	}

	private void SubAddNotification(NotificationMessage msg)
	{
		if (msg.IgnoreNotification())
		{
			return;
		}
		if (msg.IsAggregate())
		{
			lock (_aggregates)
			{
				KeyValuePair<Type, uint> key = new KeyValuePair<Type, uint>(msg.GetType(), msg.AggregateID());
				NotificationMessage value;
				if (_aggregates.TryGetValue(key, out value) && value != msg)
				{
					return;
				}
				_aggregates[key] = msg;
			}
		}
		if (msg.Type == NotificationType.Hint)
		{
			UISoundFX.PlaySFX("NotificationGood");
		}
		else if (msg.Type != NotificationType.Issue || !GameSettings.Instance.MuteIssues)
		{
			UISoundFX.PlaySFX("Notification" + msg.Type);
		}
		UINotification uINotification = (msg.UIItem = UnityEngine.Object.Instantiate(NotificationPrefab));
		uINotification.transform.SetParent(base.transform, false);
		uINotification.transform.SetAsFirstSibling();
		uINotification.Set(msg);
		if (msg.Type == NotificationType.Hint)
		{
			NotificationHeader header = GetHeader(HeaderType.Hint);
			header.Notifications.Add(uINotification);
			uINotification.Parent = header;
		}
		else if (msg.Type == NotificationType.Issue)
		{
			NotificationHeader header2 = GetHeader(HeaderType.Issue);
			header2.Notifications.Add(uINotification);
			uINotification.Parent = header2;
		}
		else
		{
			NotificationHeader header3 = GetHeader(HeaderType.Messages);
			header3.Notifications.Add(uINotification);
			uINotification.Parent = header3;
		}
		if (!uINotification.Parent.Toggled)
		{
			uINotification.Parent.NoticeMe();
		}
		else
		{
			UISoundFX.PlaySFX("SlideIn2", -1f, -0.6f);
		}
		UpdateY(uINotification.Self);
		Vector2 sizeDelta = uINotification.Self.sizeDelta;
		Vector2 anchoredPosition = uINotification.Self.anchoredPosition;
		uINotification.Self.sizeDelta = new Vector2(32f, sizeDelta.y);
		uINotification.Self.anchoredPosition = new Vector2(-32f, anchoredPosition.y);
		uINotification.Self.DOSizeDelta(sizeDelta, 0.5f, true);
		uINotification.Self.DOAnchorPos(anchoredPosition, 0.5f, true);
	}

	public void Remove(UINotification n)
	{
		n.Parent.Notifications.Remove(n);
		RemoveAggregate(n.Message);
		UpdateY();
	}

	public void RemoveAggregate(NotificationMessage m)
	{
		if (!m.IsAggregate())
		{
			return;
		}
		lock (_aggregates)
		{
			KeyValuePair<Type, uint> key = new KeyValuePair<Type, uint>(m.GetType(), m.AggregateID());
			NotificationMessage value;
			if (_aggregates.TryGetValue(key, out value) && value == m)
			{
				_aggregates.Remove(key);
			}
		}
	}

	public void UpdateY(RectTransform ignore = null, bool animate = true)
	{
		if (_activeSequence != null)
		{
			_activeSequence.Kill();
		}
		_activeSequence = DOTween.Sequence();
		float offset = ((HUD.Instance != null && HUD.Instance.BuildMode) ? (-48f) : 0f);
		for (int i = 0; i < Headers.Length; i++)
		{
			Headers[i].UpdateY(ref offset, _activeSequence, ignore, animate);
		}
		Self.sizeDelta = new Vector2(Self.sizeDelta.x, 0f - offset);
		Scroll(0f);
		_activeSequence.OnComplete(delegate
		{
			_activeSequence = null;
			RefreshNotifications();
		});
	}

	public void RollDay()
	{
		NotificationHeader old = GetHeader(HeaderType.Old);
		NotificationHeader header = GetHeader(HeaderType.Messages);
		old.Notifications.ForEach(delegate(UINotification x)
		{
			x.Remove();
		});
		old.Notifications.AddRange(header.Notifications);
		header.Notifications.ForEach(delegate(UINotification x)
		{
			x.Parent = old;
		});
		header.Notifications.Clear();
		UpdateY();
	}

	private void RefreshNotifications()
	{
		for (int i = 0; i < Headers.Length; i++)
		{
			Headers[i].RefreshNotificationActive();
		}
	}

	public IEnumerable<UINotification> AllMessages()
	{
		for (int j = 0; j < Headers.Length; j++)
		{
			NotificationHeader header = Headers[j];
			for (int i = 0; i < header.Notifications.Count; i++)
			{
				yield return header.Notifications[i];
			}
		}
	}

	public int GetNotificationWidth()
	{
		return Mathf.FloorToInt(Holder.sizeDelta.x) - ((Screen.width != 1024) ? 32 : 0);
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull() || !SelectorController.Instance.DoneLoading)
		{
			return;
		}
		lock (_threadedQueue)
		{
			for (int i = 0; i < _threadedQueue.Count; i++)
			{
				NotificationMessage notificationMessage = _threadedQueue[i];
				SubAddNotification(notificationMessage);
				notificationMessage.LastBlip = (notificationMessage.Created = Time.realtimeSinceStartup);
			}
			_threadedQueue.Clear();
		}
		float num = HUD.Instance.MainContentPanel.rect.width / Options.UISize;
		if (_lastScreenWidth != num)
		{
			_lastScreenWidth = num;
			Holder.sizeDelta = new Vector2(Mathf.Min(512f, HUD.Instance.MainContentPanel.rect.width / 2f - 325f), Holder.sizeDelta.y);
			foreach (UINotification item in AllMessages())
			{
				item.Self.sizeDelta = new Vector2(GetNotificationWidth(), 0f);
				item.Refresh(true);
			}
			UpdateY();
		}
		List<UINotification> notifications = GetHeader(HeaderType.Issue).Notifications;
		for (int j = 0; j < notifications.Count; j++)
		{
			int num2 = (j + _refreshOffset) % notifications.Count;
			UINotification uINotification = notifications[num2];
			if (uINotification.IsRemoving)
			{
				continue;
			}
			if (uINotification.Message.HasRefresh())
			{
				if ((uINotification.Message.Created < 0f || Time.realtimeSinceStartup - uINotification.Message.Created > 5f) && uINotification.Message.Refresh())
				{
					uINotification.Remove();
				}
			}
			else if (SDateTime.GetMonths(uINotification.Message.Date, SDateTime.Now()) > 1f)
			{
				uINotification.Remove();
			}
			_refreshOffset = num2 + 1;
			break;
		}
	}

	public void CloseDropDowns()
	{
		DropDownPrefabs.ForEachEnum(delegate(UINotificationDropdown x)
		{
			x.Close();
		});
	}
}
