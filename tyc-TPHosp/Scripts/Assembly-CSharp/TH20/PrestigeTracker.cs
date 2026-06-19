using System;
using JetBrains.Annotations;
using TH20.EventStaffHired;

namespace TH20
{
	public class PrestigeTracker : MustCallDestroy, Interface, IGameEventCallback
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class PrestigeLevel
		{
			public float Points;

			public float PatientArrivalRate = 1f;

			public int ExtraJobApplicantSlots;
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public PrestigeLevel[] Levels;
		}

		public Action<PrestigeTracker> OnPrestigeChangedEvent;

		private readonly Config _config;

		private readonly BuildEvents _buildEvents;

		private readonly CharacterEvents _characterEvents;

		private float _totalPoints;

		private int _level;

		private Level _levelObject;

		private float _progress;

		private PrestigeLevel _data;

		public PrestigeLevel Data => _data;

		public int Level => _level + 1;

		public int Points => (int)_totalPoints;

		public float Progress => _progress;

		public int MaximumExtraJobApplicantSlots
		{
			get
			{
				int result = 0;
				PrestigeLevel[] levels = _config.Levels;
				if (levels != null && levels.Length != 0)
				{
					result = levels[levels.Length - 1].ExtraJobApplicantSlots;
				}
				return result;
			}
		}

		public PrestigeTracker(Config config, Level level, BuildEvents buildEvents, CharacterEvents characterEvents)
		{
			_config = config;
			_buildEvents = buildEvents;
			_characterEvents = characterEvents;
			_levelObject = level;
			RegisterEvents();
			_characterEvents.OnStaffHired.Add(this);
			level.PostConstruct = (System.Action)Delegate.Combine(level.PostConstruct, (System.Action)delegate
			{
				Modify(0f);
			});
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents5 = _buildEvents;
			buildEvents5.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents5.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnCharacterLeftHospital = (Action<Character>)Delegate.Remove(characterEvents2.OnCharacterLeftHospital, new Action<Character>(OnCharacterLeftHospital));
			_characterEvents.OnStaffHired.Remove(this);
			base.Destroy();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents5 = _buildEvents;
			buildEvents5.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents5.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnCharacterLeftHospital = (Action<Character>)Delegate.Combine(characterEvents2.OnCharacterLeftHospital, new Action<Character>(OnCharacterLeftHospital));
		}

		private void Modify(float points)
		{
			int level = _level;
			_totalPoints += points;
			int num = _config.Levels.Length;
			if (num <= 0)
			{
				return;
			}
			_level = 0;
			_data = _config.Levels[0];
			for (int i = 1; i < num; i++)
			{
				PrestigeLevel prestigeLevel = _config.Levels[i - 1];
				if (_totalPoints >= prestigeLevel.Points)
				{
					_level = i;
					_data = _config.Levels[i];
				}
			}
			if (_level >= num - 1)
			{
				_progress = 1f;
			}
			else
			{
				float points2 = Data.Points;
				float num2 = ((_level != 0) ? _config.Levels[_level - 1].Points : 0f);
				float num3 = points2 - num2;
				float num4 = _totalPoints - num2;
				_progress = num4 / num3;
			}
			OnPrestigeChangedEvent.InvokeSafe(this);
			if (_level > level)
			{
				PlatformStatsAndAchievements.SetStatValue(Stat.HospitalLevelReached, _level + 1);
				AudioManager.Instance.Play("LevelUp");
			}
		}

		public int GetPointsRequired(int level)
		{
			if (level >= 0 && level < _config.Levels.Length)
			{
				return (int)_config.Levels[level].Points;
			}
			return -1;
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			Modify(room.Definition.Prestige);
		}

		private void OnRoomDeleted(Room room)
		{
			Modify(0f - room.Definition.Prestige);
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			Modify(roomItem.Definition.HospitalLevelPoints);
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			Modify(0f - roomItem.Definition.HospitalLevelPoints);
		}

		private void OnEnterEditFloorPlanState(Room roomBeingEdited, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			Modify(0f - roomBeingEdited.Definition.Prestige);
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant applicant, int fee)
		{
			if (staff.RankDefinition != null)
			{
				Modify(staff.RankDefinition.Prestige);
			}
		}

		private void OnCharacterLeftHospital(Character character)
		{
			if (character is Staff staff && !(staff is GuestTrainer) && staff.RankDefinition != null)
			{
				Modify(0f - staff.RankDefinition.Prestige);
			}
		}

		private void OnStaffPromoted(Staff staff)
		{
			float prestige = staff.Definition._rank[staff.Rank].Prestige;
			float prestige2 = staff.Definition._rank[staff.Rank - 1].Prestige;
			Modify(prestige - prestige2);
		}

		public int FindLevelFromJobApplicantSlot(int slot)
		{
			int num = 0;
			for (int i = 0; i < _config.Levels.Length; i++)
			{
				if (slot >= _config.Levels[i].ExtraJobApplicantSlots)
				{
					num = i + 1;
				}
			}
			return num + 1;
		}
	}
}
