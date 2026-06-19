using System;
using I2.Loc;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class JobRoom : Job
	{
		protected readonly Room _room;

		private readonly StaffRequired _required;

		private Staff _staffOnJob;

		public Room Room => _room;

		public JobRoom(StaffRequired staffRequired, Room room)
		{
			_room = room;
			_required = staffRequired;
			_room.Level.StatusIconManager.ShowStatusIcon(_room, StatusIcon.Type.StaffRequired);
		}

		public override string Description(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_WorkIn_CS_M : ScriptLocalization.Staff.Status_WorkIn_CS_F, "{[ROOM]}", _room.Definition.GetLocalisedName());
		}

		public override string DescriptionDoing(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_WorkingIn_CS_M : ScriptLocalization.Staff.Status_WorkingIn_CS_F, "{[ROOM]}", _room.GetRoomName());
		}

		public override string DebugDescription()
		{
			return $"working in {_room}";
		}

		public override Sprite Icon()
		{
			return _room.Definition._icon;
		}

		public override bool IsReadyForWork()
		{
			if (_room.QueueLength == 0 && !_room.ArePatientsInRoom())
			{
				return _room.Definition._type == RoomDefinition.Type.Reception;
			}
			return true;
		}

		public override void MakeAvailable()
		{
			if (_assignedStaff != null)
			{
				_room.AssignedStaff.Remove(_assignedStaff);
			}
			if (_room.Level.StatusIconManager != null)
			{
				_room.Level.StatusIconManager.ShowStatusIcon(_room, StatusIcon.Type.StaffRequired);
			}
			base.MakeAvailable();
		}

		public override bool IsInRoom(Room room)
		{
			return _room == room;
		}

		public override bool IsWithinDropRadius(Vector3 position)
		{
			return true;
		}

		private bool StartedFromDrop(Staff staff)
		{
			if (base.JobStartedFromDrop && staff != null)
			{
				return !staff.HasPendingModeChange();
			}
			return false;
		}

		public override bool CanLeave()
		{
			if (!_room.Definition.CanStaffAlwaysLeave())
			{
				if (_room.CharacterEntering != null || _room.ArePatientsInRoom())
				{
					return false;
				}
				if (StartedFromDrop(_assignedStaff))
				{
					return false;
				}
			}
			return base.CanLeave();
		}

		public override bool CanLeaveIgnoringDroppedCheck()
		{
			if (!_room.Definition.CanStaffAlwaysLeave() && (_room.CharacterEntering != null || _room.ArePatientsInRoom()))
			{
				return false;
			}
			return base.CanLeave();
		}

		public override void AssignStaff(Staff staff, Room room)
		{
			base.AssignStaff(staff, room);
			room.AssignedStaff.AddUnique(staff);
		}

		public override float GetJobScore(Staff staff)
		{
			return GameAlgorithms.CalculateRoomJobScore(_room, staff, _assignedStaff, this);
		}

		public override StaffRequired StaffRequired()
		{
			return _required;
		}

		public override StaffDefinition.Type StaffType()
		{
			return _required.Definition._type;
		}

		public override StaffDefinition.Type AltStaffType()
		{
			if (_required.AlternativeDefinition == null)
			{
				return StaffDefinition.Type.None;
			}
			return _required.AlternativeDefinition._type;
		}

		public override QualificationDefinition RequiredQualification()
		{
			return _required.QualificationInstance;
		}

		public override void OnAddedToScheduler()
		{
			_room.AddJob(this);
		}

		public override void OnRemovedFromScheduler()
		{
			_room.RemoveJob(this);
		}

		public override bool IsSuitable(Staff staff, bool checkExclusion, out string reason)
		{
			if (!_room.IsFunctional())
			{
				reason = "room isn't functional";
				return false;
			}
			if (!_required.IsSuitable(staff))
			{
				reason = "staff isn't right type or doesn't have qualification";
				return false;
			}
			if (!_room.HasValidRequiredItems())
			{
				reason = "room hasn't got required items";
				return false;
			}
			if (!StartedFromDrop(staff) && checkExclusion && staff.IsJobExcluded(this))
			{
				reason = "job is exluded";
				return false;
			}
			reason = "OK";
			return true;
		}

		public override void BecomeHighPriority()
		{
			_room.Level.StatusIconManager.ShowStatusIcon(_room, StatusIcon.Type.StaffRequired);
			base.BecomeHighPriority();
		}

		public override bool StartJob(Staff staff)
		{
			AssignStaff(staff, _room);
			GotoRoom(staff, _room, ReasonUseRoom.Work);
			return base.StartJob(staff);
		}

		protected override void StartRoomBehaviour(Staff staff)
		{
			staff.SetBehaviour(_required.Behaviour);
			staff.BehaviorTree.SetVariable("Room", new RoomRef(_room));
			staff.BehaviorTree.SetVariable("Item", new ItemRef(null));
			BindJobFinishedEvent(staff);
		}

		private void BindJobFinishedEvent(Staff staff)
		{
			_staffOnJob = staff;
			CharacterBehaviorTree.FinishedEvent jobFinishedEvent = null;
			jobFinishedEvent = delegate(bool success, GameObject behavior)
			{
				_staffOnJob = null;
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, jobFinishedEvent);
				staff.Level.CharacterEvents.OnStaffCompletedJob.InvokeSafe(staff, this, success);
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, jobFinishedEvent);
		}

		public override bool StartFromStaffDrop(Staff staff)
		{
			if (_room.EnterRoom(staff, ReasonUseRoom.Work))
			{
				StartRoomBehaviour(staff);
				return base.StartFromStaffDrop(staff);
			}
			return false;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_staffOnJob != null && _staffOnJob.BehaviorTree != null)
			{
				BindJobFinishedEvent(_staffOnJob);
			}
			_room.Level.StatusIconManager.ShowStatusIcon(_room, StatusIcon.Type.StaffRequired);
		}

		public override ICursorSelectable Highlight()
		{
			return _room;
		}

		public override Vector3 GetWorldPosition()
		{
			return _room.FloorPlan.Door.WorldPosition;
		}

		public override void RemoveStaffFromRoom(Staff staff)
		{
			_room.StaffLeaveRoom(staff);
		}
	}
}
