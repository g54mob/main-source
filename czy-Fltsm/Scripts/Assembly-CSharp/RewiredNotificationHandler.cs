using UnityEngine;

public class RewiredNotificationHandler : RewiredComponent, IUIFlagsProvider
{
	[Header("Rewired Notification Handler")]
	[SerializeField]
	private SelectableGroup _notificationGroup;

	[SerializeField]
	private RewiredAction _openNotificationAction;

	[SerializeField]
	private RewiredAction _removeNotificationAction;

	[SerializeField]
	private RewiredAction _cancelAction;

	[Header("UIFlags Provider")]
	[SerializeField]
	private PanelContainerFlags _uiFlags;

	private bool _reinitializeNotificationGroup;

	public PanelContainerFlags Flags => _uiFlags;

	public bool BlockCancel => false;

	protected override void Awake()
	{
		base.Awake();
		_notificationGroup.enabled = false;
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, UpdateEnabled);
		GameEventDispatcher.AddListener(GameEventType.NotificationsUpdated, OnNotificationUpdate);
		GameEventDispatcher.AddListener(GameEventType.UIFlagsUpdated, UpdateState);
		OnActiveInputUpdated();
	}

	protected override void Update()
	{
		base.Update();
		if (base.Interactable && _notificationGroup.enabled)
		{
			if (_openNotificationAction.GetButtonDown())
			{
				NotificationBase.SelectedNotification?.OnLeftClick();
			}
			else if (_removeNotificationAction.GetButtonDown())
			{
				NotificationBase.SelectedNotification?.OnRightClick();
			}
			else if (_cancelAction.GetButtonDown())
			{
				DisableNotificationGroup();
			}
		}
	}

	private void LateUpdate()
	{
		if (_reinitializeNotificationGroup)
		{
			_notificationGroup.Initialize();
			_reinitializeNotificationGroup = false;
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, UpdateEnabled);
		GameEventDispatcher.RemoveListener(GameEventType.NotificationsUpdated, OnNotificationUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.UIFlagsUpdated, UpdateState);
	}

	protected override void OnButtonDown()
	{
		if (IsInteractable())
		{
			_notificationGroup.Initialize();
			_notificationGroup.enabled = true;
			UIManager.AddFlagsProvider(this);
			UpdateGlyph();
			UIManager.AddRewiredActionInfoToContext(this, _openNotificationAction, _removeNotificationAction, _cancelAction);
		}
	}

	protected override void UpdateGlyph()
	{
		if (IsInteractable() && !_notificationGroup.enabled)
		{
			base.UpdateGlyph();
		}
		else if ((bool)base.ActionImage)
		{
			base.ActionImage.gameObject.SetActive(value: false);
		}
	}

	private void DisableNotificationGroup()
	{
		if (_notificationGroup.enabled)
		{
			_notificationGroup.enabled = false;
			UIManager.RemoveFlagsProvider(this);
			UpdateGlyph();
			UIManager.DisableRewiredActionInfoContext(this);
		}
	}

	private void UpdateEnabled(GameEvent gameEvent = null)
	{
		base.enabled = HasInteractableInput();
		UpdateState();
	}

	private void OnNotificationUpdate(GameEvent gameEvent = null)
	{
		UpdateState();
		_reinitializeNotificationGroup = _notificationGroup.enabled;
	}

	private void UpdateState(GameEvent gameEvent = null)
	{
		if (IsInteractable())
		{
			UIManager.AddRewiredActionInfo(this);
		}
		else
		{
			DisableNotificationGroup();
			UIManager.RemoveRewiredActionInfo(this);
		}
		UpdateGlyph();
	}

	private bool IsInteractable()
	{
		if (HasInteractableInput() && 0 < NotificationBase.ActiveNotifications.Count)
		{
			return UIManager.HasFlagsNotSet(PanelContainerFlags.BlockNotificationHandler);
		}
		return false;
	}
}
