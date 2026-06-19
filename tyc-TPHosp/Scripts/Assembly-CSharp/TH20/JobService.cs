using System;
using I2.Loc;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class JobService : Job
	{
		public enum JobDescription
		{
			None = 0,
			ReceptionCheckIn = 1,
			KioskCustomer = 2
		}

		private readonly RoomItem _item;

		private readonly RoomItemJobComponent _jobComponent;

		private Staff _staffOnJob;

		public IRoomItemDefinition RoomItemDefinition => _item.Definition;

		public RoomItem Item => _item;

		public JobService(RoomItem item, RoomItemJobComponent jobComponent)
		{
			_item = item;
			_jobComponent = jobComponent;
			_item.Level.StatusIconManager.ShowStatusIcon(_item, StatusIcon.Type.StaffRequired);
		}

		public override string Description(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_Service_CS_M : ScriptLocalization.Staff.Status_Service_CS_F, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DescriptionDoing(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_Servicing_CS_M : ScriptLocalization.Staff.Status_Servicing_CS_F, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DebugDescription()
		{
			return $"servicing {_item}";
		}

		public override Sprite Icon()
		{
			return _item.Icon;
		}

		public override StaffRequired StaffRequired()
		{
			return _jobComponent.StaffRequired;
		}

		public override StaffDefinition.Type StaffType()
		{
			return _jobComponent.StaffRequired.Definition._type;
		}

		public override StaffDefinition.Type AltStaffType()
		{
			if (_jobComponent.StaffRequired.AlternativeDefinition == null)
			{
				return StaffDefinition.Type.None;
			}
			return _jobComponent.StaffRequired.AlternativeDefinition._type;
		}

		public override QualificationDefinition RequiredQualification()
		{
			return _jobComponent.StaffRequired.QualificationInstance;
		}

		public override void OnAddedToScheduler()
		{
			_item.OwningRoom.AddJob(this);
		}

		public override void OnRemovedFromScheduler()
		{
			_item.OwningRoom.RemoveJob(this);
		}

		public override bool IsSuitable(Staff staff, bool checkExclusion, out string reason)
		{
			if (checkExclusion && staff.IsJobExcluded(this))
			{
				reason = "job is exluded";
				return false;
			}
			if (!_jobComponent.StaffRequired.IsSuitable(staff))
			{
				reason = "staff isn't right type or doesn't have qualification";
				return false;
			}
			reason = "OK";
			return true;
		}

		public override bool IsReadyForWork()
		{
			return _item.GetComponent<EntityNavFailedComponent>() == null;
		}

		public override bool IsInRoom(Room room)
		{
			return _item.OwningRoom == room;
		}

		public override bool IsWithinDropRadius(Vector3 position)
		{
			return _item.WorldPosition.SquareDistance2D(position) < MathUtils.Square(GameAlgorithms.Config.JobStaffDropRadius);
		}

		public override void MakeAvailable()
		{
			base.MakeAvailable();
			if (_item.Level.StatusIconManager != null)
			{
				_item.Level.StatusIconManager.ShowStatusIcon(_item, StatusIcon.Type.StaffRequired);
			}
		}

		public override float GetJobScore(Staff staff)
		{
			return GameAlgorithms.CalculateServiceJobScore(_item, staff, this);
		}

		public override bool StartJob(Staff staff)
		{
			staff.Idle();
			AssignStaff(staff, _item.OwningRoom);
			GotoRoom(staff, _item.OwningRoom, ReasonUseRoom.Work);
			return base.StartJob(staff);
		}

		protected override void StartRoomBehaviour(Staff staff)
		{
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			staff.SetBehaviour(_jobComponent.StaffRequired.Behaviour);
			behaviorTree.SetVariable("Item", new ItemRef(_item));
			behaviorTree.SetVariable("Room", new RoomRef(_item.OwningRoom));
			BindJobFinishedEvent(staff);
		}

		private void BindJobFinishedEvent(Staff staff)
		{
			_staffOnJob = staff;
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				_staffOnJob = null;
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				if (staff == GetStaff())
				{
					MakeAvailable();
				}
				EndJob(staff);
				if (!success)
				{
					staff.GetOrAddComponent<StaffFailedToStartJobComponent>();
				}
				staff.Level.CharacterEvents.OnStaffCompletedJob.InvokeSafe(staff, this, success);
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		public override bool StartFromStaffDrop(Staff staff)
		{
			if (_item.OwningRoom.EnterRoom(staff, ReasonUseRoom.Work))
			{
				StartRoomBehaviour(staff);
				return base.StartFromStaffDrop(staff);
			}
			return false;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_staffOnJob != null)
			{
				BindJobFinishedEvent(_staffOnJob);
			}
			else
			{
				_item.Level.StatusIconManager.ShowStatusIcon(_item, StatusIcon.Type.StaffRequired);
			}
		}

		public override ICursorSelectable Highlight()
		{
			return _item;
		}

		public override Vector3 GetWorldPosition()
		{
			return _item.WorldPosition;
		}

		public override void RemoveStaffFromRoom(Staff staff)
		{
			_item.OwningRoom.StaffLeaveRoom(staff);
		}
	}
}
