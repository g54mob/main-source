using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class NotifDoors : CTSBehaviour
	{
		[SerializeField]
		private NotificationData _notificationData;

		[SerializeField]
		private bool _alsoLockWhenEmpty;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		private bool _isAccessible;

		private LockToggle _timeToggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_timeToggle.Add(MonoSingleton<TimeController>.Instance);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			BuildingRoomsContainerManager.OnAccessToExteriorChanged += OnAccessChanged;
			ConstructionSystem.OnConstructionModeChanged += OnConstructionModeChanged;
			OnAccessChanged(MonoSingleton<BuildingRoomsContainerManager>.Instance.AllRoomHaveExteriorAccess);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			BuildingRoomsContainerManager.OnAccessToExteriorChanged -= OnAccessChanged;
			ConstructionSystem.OnConstructionModeChanged -= OnConstructionModeChanged;
		}

		private void OnConstructionModeChanged()
		{
			if (MonoSingleton<ConstructionSystem>.InstanceExists() && MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.None && !_isAccessible)
			{
				_notificationManager.ShowNotification(_notificationData, removable: false);
				_timeToggle.Lock();
			}
		}

		private void OnAccessChanged(EAccess access)
		{
			bool flag = IsAccessValid(access);
			if (_isAccessible != flag)
			{
				_isAccessible = flag;
				if (_isAccessible)
				{
					_notificationManager.RemoveAll(_notificationData);
					_timeToggle.Unlock();
				}
			}
		}

		private bool IsAccessValid(EAccess access)
		{
			if (access == EAccess.Inaccessible)
			{
				return false;
			}
			if (_alsoLockWhenEmpty && access == EAccess.Empty)
			{
				return false;
			}
			return true;
		}
	}
}
