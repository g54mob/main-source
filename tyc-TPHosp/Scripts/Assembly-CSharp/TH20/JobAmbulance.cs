#define LOG_LEVEL_VERBOSE
using System;
using System.Linq;
using I2.Loc;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class JobAmbulance : Job
	{
		private readonly StaffRequired _staffRequired;

		private readonly RoomItem _item;

		private PlayerAmbulance _ambulance;

		private bool _isInvalid;

		private ObjectInteraction _interaction;

		private const float JobDropRadiusShrinkAmount = 1.75f;

		public PlayerAmbulance Ambulance
		{
			get
			{
				return _ambulance;
			}
			set
			{
				_ambulance = value;
			}
		}

		public JobAmbulance(StaffRequired staffRequired, RoomItem item, PlayerAmbulance ambulance)
		{
			_staffRequired = staffRequired;
			_item = item;
			_ambulance = ambulance;
		}

		public override string Description(Character.Sex gender)
		{
			return LocalisedString.Replace(ScriptLocalization.Staff.JobAmbulanceDrop, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DescriptionDoing(Character.Sex gender)
		{
			return LocalisedString.Replace(ScriptLocalization.Staff.JobAmbulanceEmbarking, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DebugDescription()
		{
			return $"{_item} ({ScriptLocalization.Staff.JobAmbulanceEmbarking})";
		}

		public override Sprite Icon()
		{
			return _item.Icon;
		}

		public override bool IsReadyForWork()
		{
			if (_item.GetComponent<EntityNavFailedComponent>() == null)
			{
				return _assignedStaff == null;
			}
			return false;
		}

		public override float GetJobScore(Staff staff)
		{
			return GameAlgorithms.CalculateJobAmbulanceScore(_item, staff, this);
		}

		public override bool IsSuitable(Staff staff, bool checkExclusion, out string reason)
		{
			if (!CanLeave())
			{
				reason = "current staff can't leave yet";
				return false;
			}
			if (checkExclusion && staff.IsJobExcluded(this))
			{
				reason = "job is excluded";
				return false;
			}
			if (staff?.Definition == null)
			{
				reason = "invalid staff member";
				return false;
			}
			if (staff.Qualifications.All((QualificationSlot x) => x.Definition != _staffRequired.QualificationInstance))
			{
				reason = "not qualified";
				return false;
			}
			if (_isInvalid)
			{
				reason = "no longer valid, pending removal from job scheduler";
				return false;
			}
			reason = "OK";
			return true;
		}

		public override StaffRequired StaffRequired()
		{
			return _staffRequired;
		}

		public override StaffDefinition.Type StaffType()
		{
			return _staffRequired.Definition._type;
		}

		public override StaffDefinition.Type AltStaffType()
		{
			return StaffDefinition.Type.None;
		}

		public override QualificationDefinition RequiredQualification()
		{
			return _staffRequired.QualificationInstance;
		}

		public override void OnAddedToScheduler()
		{
			_item.OwningRoom.AddJob(this);
		}

		public override void OnRemovedFromScheduler()
		{
			_item.OwningRoom.RemoveJob(this);
		}

		public override bool IsInRoom(Room room)
		{
			return _item.OwningRoom == room;
		}

		public override bool IsWithinDropRadius(Vector3 position)
		{
			return _item.WorldPosition.SquareDistance2D(position) < MathUtils.Square(GameAlgorithms.Config.JobStaffDropRadius / 1.75f);
		}

		public override bool StartFromStaffDrop(Staff staff)
		{
			if (_item.OwningRoom.EnterRoom(staff, ReasonUseRoom.AmbulanceAssignment))
			{
				MakeAvailable();
				if (StartJob(staff))
				{
					return base.StartFromStaffDrop(staff);
				}
			}
			return false;
		}

		public override bool StartJob(Staff staff)
		{
			_interaction = InteractionAlgorithms.GetClosestInteractionByName(_item, "Embark", staff.Position, (ObjectInteraction objectInteraction) => objectInteraction.Valid);
			if (_interaction == null || !InteractionAlgorithms.InteractionReachable(staff, _interaction))
			{
				if (!_item.HasBeenDestroyed())
				{
					_item.GetOrAddComponent<EntityNavFailedComponent>().Init();
				}
				_interaction = null;
				return true;
			}
			staff.SetBehaviour(staff.Definition._behaviourGoToAmbulance);
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.SetVariable("Room", new RoomRef(_item.OwningRoom));
			behaviorTree.SetVariable("AmbulanceInteraction", new ObjectInteractionRef(_interaction));
			AssignStaff(staff, _item.OwningRoom);
			_ambulance.StaffAssignedAmbulance(staff, this);
			BindBehaviourFinishedEvent(staff);
			return base.StartJob(staff);
		}

		public override void AssignStaff(Staff staff, Room room)
		{
			if (_assignedStaff != null && _assignedStaff != staff)
			{
				Logging.Warning("new staff");
			}
			base.AssignStaff(staff, room);
		}

		private void BindBehaviourFinishedEvent(Staff staff)
		{
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				if (success)
				{
					_ambulance.StaffArrivedAmbulance(staff);
				}
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		public void PostLoadFixUpEvent(Staff staff)
		{
			BindBehaviourFinishedEvent(staff);
		}

		public void JobDone(Staff staff, bool success)
		{
			staff.Level.CharacterEvents.OnStaffCompletedJob.InvokeSafe(staff, this, success);
		}

		public override ICursorSelectable Highlight()
		{
			return _item;
		}

		public override bool RemoveOnRoomClosed()
		{
			return false;
		}

		public override Vector3 GetWorldPosition()
		{
			return _item.WorldPosition;
		}

		public override void RemoveStaffFromRoom(Staff staff)
		{
			_item.OwningRoom.StaffLeaveRoom(staff);
		}

		public override bool CanLeave()
		{
			if (_ambulance.IsGettingReady && !_ambulance.StaffOnBoarding)
			{
				return true;
			}
			return false;
		}

		public override void MakeAvailable()
		{
			_assignedStaff?.ModifiersComponent?.RemoveStatusEffect(_staffRequired.Definition.StatusEffectFasterRun.Instance);
			base.MakeAvailable();
			_ambulance.JobReset(this);
		}

		public void SetInvalid()
		{
			_isInvalid = true;
		}
	}
}
