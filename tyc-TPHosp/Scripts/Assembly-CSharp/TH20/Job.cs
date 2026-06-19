using System;
using UnityEngine;

namespace TH20
{
	public abstract class Job
	{
		protected Staff _assignedStaff;

		private Staff _staffGoingToRoom;

		public float IdleTime;

		private float DropStartTime;

		public bool JobStartedFromDrop => DropStartTime > GameTime.time;

		public bool HighPriority { get; private set; }

		public abstract string Description(Character.Sex gender);

		public abstract string DescriptionDoing(Character.Sex gender);

		public abstract string DebugDescription();

		public abstract Sprite Icon();

		public abstract bool IsReadyForWork();

		public abstract float GetJobScore(Staff staff);

		public abstract bool IsSuitable(Staff staff, bool checkExclusion, out string reason);

		public abstract StaffRequired StaffRequired();

		public abstract StaffDefinition.Type StaffType();

		public abstract StaffDefinition.Type AltStaffType();

		public abstract QualificationDefinition RequiredQualification();

		public abstract void OnAddedToScheduler();

		public abstract void OnRemovedFromScheduler();

		public Staff GetStaff()
		{
			return _assignedStaff;
		}

		public bool Available()
		{
			return _assignedStaff == null;
		}

		public virtual void MakeAvailable()
		{
			if (_assignedStaff != null)
			{
				_assignedStaff.CurrentJob = null;
			}
			HighPriority = false;
			_assignedStaff = null;
			DropStartTime = 0f;
		}

		public virtual void Interrupt()
		{
		}

		public bool IsAssigned(Staff staff)
		{
			return _assignedStaff == staff;
		}

		public virtual void AssignStaff(Staff staff, Room room)
		{
			bool param = staff.CurrentMode == Staff.Mode.Break;
			IdleTime = 0f;
			_assignedStaff = staff;
			_assignedStaff.StartWork(this);
			staff.Level.CharacterEvents.OnStaffAssignedJob.InvokeSafe(room, staff, this, param);
		}

		public abstract bool IsInRoom(Room room);

		public abstract bool IsWithinDropRadius(Vector3 position);

		public virtual bool IsVehicular()
		{
			return false;
		}

		public virtual bool CanLeave()
		{
			if (_assignedStaff != null)
			{
				return _assignedStaff.InteractionInterruptable;
			}
			return true;
		}

		public virtual bool CanLeaveIgnoringDroppedCheck()
		{
			return CanLeave();
		}

		public virtual bool StartJob(Staff staff)
		{
			return true;
		}

		protected virtual void EndJob(Staff staff)
		{
			if (staff.CurrentMode == Staff.Mode.Work)
			{
				staff.Idle();
			}
		}

		public virtual bool StartFromStaffDrop(Staff staff)
		{
			DropStartTime = GameTime.time + GameAlgorithms.Config.MaxTimeStaffIdleOnJob;
			return true;
		}

		public virtual void BecomeHighPriority()
		{
			HighPriority = true;
		}

		public virtual void BecomeNormalPriority()
		{
			HighPriority = false;
		}

		protected void GotoRoom(Staff staff, Room room, ReasonUseRoom reason)
		{
			if (staff.RoomUsing == room)
			{
				bool success = room.IsStaffMember(staff) || room.EnterRoom(staff, reason);
				ArrivedAtRoom(staff, success);
			}
			else
			{
				staff.GotoRoom(room, reason, setByPlayer: false);
				BindGotoRoomFinishedEvent(staff);
			}
		}

		private void BindGotoRoomFinishedEvent(Staff staff)
		{
			_staffGoingToRoom = staff;
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				ArrivedAtRoom(staff, success);
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void ArrivedAtRoom(Staff staff, bool success)
		{
			_staffGoingToRoom = null;
			if (!success && _assignedStaff == staff)
			{
				MakeAvailable();
				EndJob(staff);
				staff.GetOrAddComponent<StaffFailedToStartJobComponent>();
			}
			else if (_assignedStaff != null && _assignedStaff != staff)
			{
				EndJob(staff);
			}
			else if (success)
			{
				StartRoomBehaviour(staff);
			}
		}

		protected virtual void StartRoomBehaviour(Staff staff)
		{
		}

		public virtual void RestoreFromSave()
		{
			if (_staffGoingToRoom != null)
			{
				BindGotoRoomFinishedEvent(_staffGoingToRoom);
			}
		}

		public abstract ICursorSelectable Highlight();

		public virtual bool RemoveOnRoomClosed()
		{
			return true;
		}

		public abstract Vector3 GetWorldPosition();

		public abstract void RemoveStaffFromRoom(Staff staff);
	}
}
