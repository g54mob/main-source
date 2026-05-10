using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class NotifAssignation : CTSBehaviour
	{
		[SerializeField]
		private NotificationData _notificationData;

		[SerializeField]
		[NavArea(true)]
		private int _areaMask;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Notifications _notificationManager;

		private bool _assignationValid;

		private readonly LockToggle _timeLock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_timeLock.Add(MonoSingleton<TimeController>.Instance);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			RoomAssingationMenu.OnRoomAssignationChanged += OnRoomAssignationChanged;
			ConstructionSystem.OnConstructionModeChanged += OnConstructionModeChanged;
			EntranceResolver.EntrancesChecked += OnEntrancesRecalculated;
			Recalculate();
			OnConstructionModeChanged();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			RoomAssingationMenu.OnRoomAssignationChanged -= OnRoomAssignationChanged;
			ConstructionSystem.OnConstructionModeChanged -= OnConstructionModeChanged;
			EntranceResolver.EntrancesChecked -= OnEntrancesRecalculated;
		}

		private void OnConstructionModeChanged()
		{
			if (MonoSingleton<ConstructionSystem>.InstanceExists() && MonoSingleton<ConstructionSystem>.Instance.CurrentMode == EConstructionMode.None && !_assignationValid)
			{
				_notificationManager.ShowNotification(_notificationData, removable: false);
				_timeLock.Lock();
			}
		}

		private void OnEntrancesRecalculated()
		{
			Recalculate();
		}

		private void OnRoomAssignationChanged(RoomBuilding obj)
		{
			Recalculate();
		}

		private void OnEntranceCountChanged(int count)
		{
			Recalculate();
		}

		private bool IsAtLeastOneRoomBuilt()
		{
			foreach (BuildingRoomContainer roomManager in MonoSingleton<BuildingRoomsContainerManager>.Instance.RoomManagers)
			{
				foreach (KeyValuePair<int, RoomBuilding> generatedRoom in roomManager.GeneratedRooms)
				{
					generatedRoom.Deconstruct(out var key, out var _);
					if (key != 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void Recalculate()
		{
			bool flag = EntranceResolver.EntranceExists(_areaMask) || !IsAtLeastOneRoomBuilt();
			if (_assignationValid != flag)
			{
				_assignationValid = flag;
				if (_assignationValid)
				{
					_notificationManager.RemoveAll(_notificationData);
					_timeLock.Unlock();
				}
			}
		}
	}
}
