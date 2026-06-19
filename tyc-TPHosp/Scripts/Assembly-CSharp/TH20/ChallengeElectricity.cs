using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TH20
{
	public class ChallengeElectricity : Challenge
	{
		public enum ElectricityType
		{
			Rooms = 0,
			Applicants = 1,
			PatientFlow = 2
		}

		[Serializable]
		public class ChallengeElectricityEvent : UnityEvent
		{
		}

		[SerializeField]
		private ChallengeElectricityEvent _onTotalElectricityChanged = new ChallengeElectricityEvent();

		[SerializeField]
		private ChallengeElectricityEvent _onAllocatedElectricityChanged = new ChallengeElectricityEvent();

		[SerializeField]
		private ChallengeElectricityEvent _onRoomListChanged = new ChallengeElectricityEvent();

		[SerializeField]
		private ChallengeElectricityEvent _onRoomAllocationChanged = new ChallengeElectricityEvent();

		private readonly ChallengeElectricityConfig _config;

		private readonly Level _level;

		private int _totalElectricity;

		private readonly Dictionary<ElectricityType, int> _electricityAllocation = new Dictionary<ElectricityType, int>();

		private readonly List<Room> _activeRoomList = new List<Room>();

		private readonly List<Room> _allRoomList = new List<Room>();

		private bool _menuNeedsInit;

		private float _closedRoomsAdvisorTimer;

		private float _closedRoomsAdvisorWarmupTimer;

		private bool _closedRoomsAdvisorQueued;

		public ChallengeElectricityEvent OnTotalElectricityChanged => _onTotalElectricityChanged;

		public ChallengeElectricityEvent OnAllocatedElectricityChanged => _onAllocatedElectricityChanged;

		public ChallengeElectricityEvent OnRoomListChanged => _onRoomListChanged;

		public ChallengeElectricityEvent OnRoomAllocationChanged => _onRoomAllocationChanged;

		public int TotalRooms => _allRoomList.Count;

		public ChallengeElectricityConfig Config => _config;

		public int TotalElectricity => _totalElectricity;

		public int AllocatedElectricity
		{
			get
			{
				int num = 0;
				foreach (ElectricityType value in Enum.GetValues(typeof(ElectricityType)))
				{
					num += _electricityAllocation[value];
				}
				return num;
			}
		}

		public ChallengeElectricity(ChallengeConfig definition, Level level)
			: base(definition, level)
		{
			_config = GetConfig<ChallengeElectricityConfig>();
			_level = level;
			_totalElectricity = 0;
			foreach (ElectricityType value in Enum.GetValues(typeof(ElectricityType)))
			{
				_electricityAllocation[value] = 0;
			}
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalOrBay && !allRoom.Definition.IsHospitalUnbuilt)
				{
					allRoom.Close();
					_allRoomList.AddUnique(allRoom);
				}
			}
			InitMenu();
		}

		public int GetElectricityAllocation(ElectricityType type)
		{
			return _electricityAllocation[type];
		}

		public bool HasSpareAllocation()
		{
			return _totalElectricity > AllocatedElectricity;
		}

		public bool IncrementAllocation(ElectricityType type)
		{
			if (HasSpareAllocation())
			{
				_electricityAllocation[type]++;
				switch (type)
				{
				case ElectricityType.PatientFlow:
					UpdatePatientArrivalModifier();
					break;
				case ElectricityType.Applicants:
					UpdateStaffApplicantRateModifier();
					break;
				}
				_onAllocatedElectricityChanged.Invoke();
				return true;
			}
			return false;
		}

		public bool DecrementAllocation(ElectricityType type)
		{
			if (_electricityAllocation[type] > 0)
			{
				_electricityAllocation[type]--;
				switch (type)
				{
				case ElectricityType.PatientFlow:
					UpdatePatientArrivalModifier();
					break;
				case ElectricityType.Applicants:
					UpdateStaffApplicantRateModifier();
					break;
				}
				_onAllocatedElectricityChanged.Invoke();
				return true;
			}
			return false;
		}

		private void UpdatePatientArrivalModifier()
		{
			_level.CharacterManager.PatientArrivalRateMultiplier = 1f + _config.PatientArrivalRatePerUnit * (float)_electricityAllocation[ElectricityType.PatientFlow];
		}

		private void UpdateStaffApplicantRateModifier()
		{
			_level.JobApplicantManager.EnergyStaffApplicantRateModifier = _config.StaffApplicantRate * (float)_electricityAllocation[ElectricityType.Applicants];
		}

		public override void Update(float timeDelta)
		{
			base.Update(timeDelta);
			if (_menuNeedsInit)
			{
				InitMenu();
			}
			_closedRoomsAdvisorTimer = Math.Max(_closedRoomsAdvisorTimer - timeDelta, 0f);
			if (_closedRoomsAdvisorTimer <= 0f && !_closedRoomsAdvisorQueued)
			{
				foreach (Room allRoom in _allRoomList)
				{
					if (!allRoom.IsOpen)
					{
						_closedRoomsAdvisorTimer = _config.MinClosedRoomsAdvisorMessageInterval;
						_closedRoomsAdvisorWarmupTimer = _config.ClosedRoomsAdvisorWarmupTimer;
						_closedRoomsAdvisorQueued = true;
						break;
					}
				}
			}
			if (_closedRoomsAdvisorQueued)
			{
				_closedRoomsAdvisorWarmupTimer -= timeDelta;
				if (_closedRoomsAdvisorWarmupTimer <= 0f)
				{
					ShowClosedRoomsAdvisorMessage();
					_closedRoomsAdvisorQueued = false;
				}
			}
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnHospitalPlotBuilt = (Action<HospitalPlot>)Delegate.Combine(buildEvents.OnHospitalPlotBuilt, new Action<HospitalPlot>(OnPlotBuilt));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents3.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents4 = base.Level.BuildEvents;
			buildEvents4.OnRoomOpened = (Action<Room>)Delegate.Combine(buildEvents4.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents5 = base.Level.BuildEvents;
			buildEvents5.OnRoomClosed = (Action<Room>)Delegate.Combine(buildEvents5.OnRoomClosed, new Action<Room>(OnRoomClosed));
			BuildEvents buildEvents6 = base.Level.BuildEvents;
			buildEvents6.OnRoomAdded = (Action<Room>)Delegate.Combine(buildEvents6.OnRoomAdded, new Action<Room>(OnRoomAdded));
			BuildEvents buildEvents7 = base.Level.BuildEvents;
			buildEvents7.OnRoomRemoved = (Action<Room>)Delegate.Combine(buildEvents7.OnRoomRemoved, new Action<Room>(OnRoomRemoved));
			OnTotalElectricityChanged.AddListener(UpdateGeneratedEnergyStat);
		}

		private void UnregisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnHospitalPlotBuilt = (Action<HospitalPlot>)Delegate.Remove(buildEvents.OnHospitalPlotBuilt, new Action<HospitalPlot>(OnPlotBuilt));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents3 = base.Level.BuildEvents;
			buildEvents3.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents3.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents4 = base.Level.BuildEvents;
			buildEvents4.OnRoomOpened = (Action<Room>)Delegate.Remove(buildEvents4.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents5 = base.Level.BuildEvents;
			buildEvents5.OnRoomClosed = (Action<Room>)Delegate.Remove(buildEvents5.OnRoomClosed, new Action<Room>(OnRoomClosed));
			BuildEvents buildEvents6 = base.Level.BuildEvents;
			buildEvents6.OnRoomAdded = (Action<Room>)Delegate.Remove(buildEvents6.OnRoomAdded, new Action<Room>(OnRoomAdded));
			BuildEvents buildEvents7 = base.Level.BuildEvents;
			buildEvents7.OnRoomRemoved = (Action<Room>)Delegate.Remove(buildEvents7.OnRoomRemoved, new Action<Room>(OnRoomRemoved));
			OnTotalElectricityChanged.RemoveListener(UpdateGeneratedEnergyStat);
		}

		private void InitLocalEvents()
		{
			_onTotalElectricityChanged = new ChallengeElectricityEvent();
			_onAllocatedElectricityChanged = new ChallengeElectricityEvent();
			_onRoomListChanged = new ChallengeElectricityEvent();
			_onRoomAllocationChanged = new ChallengeElectricityEvent();
		}

		protected override void InitMenu()
		{
			if (!(_config.HUDPrefab != null))
			{
				return;
			}
			GeneralNotificationMenu generalNotificationMenu = _level.HUD.FindMenu<GeneralNotificationMenu>();
			if (generalNotificationMenu != null)
			{
				ElectricityMenu componentInChildren = generalNotificationMenu.GetComponentInChildren<ElectricityMenu>(includeInactive: true);
				if ((bool)componentInChildren)
				{
					GameObjectUtils.SetActive(componentInChildren.gameObject, isActive: true);
					componentInChildren.Setup(this);
				}
				_menuNeedsInit = false;
			}
			else
			{
				_menuNeedsInit = true;
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (base.ChallengeStatus == ChallengeState.InProgress)
			{
				InitLocalEvents();
				RegisterEvents();
				InitMenu();
			}
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			RegisterEvents();
		}

		protected override void OnChallengeFinished()
		{
			UnregisterEvents();
			base.OnChallengeFinished();
		}

		private void UpdateGeneratedEnergyStat()
		{
			PlatformStatsAndAchievements.SetStatValue(Stat.EnergyGenerated, _totalElectricity);
		}

		private void OnRoomAdded(Room room)
		{
			if ((!room.Definition.IsHospitalOrBay || room.Definition.IsHospitalUnbuilt) && _allRoomList.AddUnique(room))
			{
				_onRoomListChanged.Invoke();
			}
		}

		private void OnRoomRemoved(Room room)
		{
			if ((!room.Definition.IsHospitalOrBay || room.Definition.IsHospitalUnbuilt) && _allRoomList.Remove(room))
			{
				_onRoomListChanged.Invoke();
			}
		}

		private void OnRoomClosed(Room room)
		{
			if ((!room.Definition.IsHospitalOrBay || room.Definition.IsHospitalUnbuilt) && _activeRoomList.Contains(room))
			{
				_activeRoomList.Remove(room);
				_electricityAllocation[ElectricityType.Rooms] = _activeRoomList.Count;
				_onAllocatedElectricityChanged.Invoke();
				_onRoomAllocationChanged.Invoke();
			}
		}

		private void OnRoomOpened(Room room)
		{
			if ((!room.Definition.IsHospitalOrBay || room.Definition.IsHospitalUnbuilt) && !_activeRoomList.Contains(room))
			{
				_activeRoomList.Add(room);
				_electricityAllocation[ElectricityType.Rooms] = _activeRoomList.Count;
				_onAllocatedElectricityChanged.Invoke();
				_onRoomAllocationChanged.Invoke();
			}
		}

		private void OnRoomItemAdded(RoomItem item, FloorPlan floorPlan)
		{
			if (item.Definition.GeneratesElectricity)
			{
				_totalElectricity++;
				_onTotalElectricityChanged.Invoke();
			}
		}

		private void OnRoomItemRemoved(RoomItem item, FloorPlan floorPlan)
		{
			if (item.Definition.GeneratesElectricity)
			{
				_totalElectricity--;
				_onTotalElectricityChanged.Invoke();
			}
		}

		private void OnPlotBuilt(HospitalPlot plot)
		{
			int energyUnitsGenerated = plot.Definition.EnergyUnitsGenerated;
			if (energyUnitsGenerated > 0)
			{
				_totalElectricity += energyUnitsGenerated;
				_onTotalElectricityChanged.Invoke();
			}
		}

		private void ShowClosedRoomsAdvisorMessage()
		{
			if (!_config.ClosedRoomsAdvisorMessage.IsNull())
			{
				base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = _config.ClosedRoomsAdvisorMessage.Translation,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: false, Advisor.PriorityLevel.Medium);
			}
		}

		public override bool ShouldShowTooltip()
		{
			return true;
		}

		public override string GetObjectiveMenuItemTooltip()
		{
			return null;
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}
	}
}
