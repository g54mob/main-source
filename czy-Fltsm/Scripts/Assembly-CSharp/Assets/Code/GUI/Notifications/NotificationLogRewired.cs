using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.GUI.Notifications
{
	public class NotificationLogRewired : RewiredComponent
	{
		[Header("Notification Log")]
		[SerializeField]
		private NotificationLog _notificationLog;

		[SerializeField]
		private NotificationLogSelectableGroup _selectableGroup;

		private bool _showActionInfo;

		protected override void Awake()
		{
			base.Awake();
			if (_notificationLog != null)
			{
				GameEventDispatcher.AddListener(GameEventType.UIFlagsUpdated, UpdateEnabled);
				GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, UpdateEnabled);
				UpdateEnabled();
			}
			else
			{
				base.enabled = false;
				Debug.LogError("_notificationLog is NULL");
			}
		}

		private void LateUpdate()
		{
			bool flag = HasInteractableInput();
			bool flag2 = flag && !_notificationLog.IsOpen;
			if (_showActionInfo != flag2)
			{
				_showActionInfo = flag2;
				if (_showActionInfo)
				{
					UIManager.AddRewiredActionInfo(this);
				}
				else
				{
					UIManager.RemoveRewiredActionInfo(this);
				}
			}
			if (flag && FlotsamInputManager.GetUISubmit() && (bool)_selectableGroup && _selectableGroup.Selected is Button button)
			{
				button.OnSubmit(null);
			}
		}

		private void OnDestroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.UIFlagsUpdated, UpdateEnabled);
			GameEventDispatcher.RemoveListener(GameEventType.ActiveInputUpdated, UpdateEnabled);
		}

		protected override void OnButtonDown()
		{
			_notificationLog.Open();
		}

		private void UpdateEnabled(GameEvent gameEvent = null)
		{
			base.enabled = HasInteractableInput() && !UIManager.HasFlagsSet(PanelContainerFlags.BlockNotificationHandler);
		}
	}
}
