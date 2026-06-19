using System;
using I2.Loc;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class JobUpgrade : Job
	{
		private readonly RoomItem _item;

		private Staff _staffOnJob;

		public RoomItem Item => _item;

		public JobUpgrade(RoomItem item)
		{
			_item = item;
		}

		public override string Description(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_Upgrade_CS_M : ScriptLocalization.Staff.Status_Upgrade_CS_F, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DescriptionDoing(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_Upgrading_CS_M : ScriptLocalization.Staff.Status_Upgrading_CS_F, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DebugDescription()
		{
			return $"upgrading {_item}";
		}

		public override Sprite Icon()
		{
			return _item.Icon;
		}

		public override StaffRequired StaffRequired()
		{
			return null;
		}

		public override StaffDefinition.Type StaffType()
		{
			return StaffDefinition.Type.Janitor;
		}

		public override StaffDefinition.Type AltStaffType()
		{
			return StaffDefinition.Type.None;
		}

		public override QualificationDefinition RequiredQualification()
		{
			return _item.UpgradeQualification;
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
			QualificationDefinition qualificationDefinition = RequiredQualification();
			if (qualificationDefinition != null && !staff.HasCompletedQualification(qualificationDefinition))
			{
				reason = "hasn't got upgrade qualification";
				return false;
			}
			if (staff.Definition._type != StaffDefinition.Type.Janitor)
			{
				reason = "not a janitor";
				return false;
			}
			if (checkExclusion && staff.IsJobExcluded(this))
			{
				reason = "job is exluded";
				return false;
			}
			RoomItemFlammableComponent component = _item.GetComponent<RoomItemFlammableComponent>();
			if (component != null && component.Job != null)
			{
				reason = "item is on fire!";
				return false;
			}
			reason = "OK";
			return true;
		}

		public override bool IsVehicular()
		{
			return _item.Definition.BaseAmbulanceConfig != null;
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

		public override float GetJobScore(Staff staff)
		{
			return GameAlgorithms.CalculateUpgradeJobScore(_item, staff, this);
		}

		public override bool StartJob(Staff staff)
		{
			ObjectInteraction closestInteractionByName = InteractionAlgorithms.GetClosestInteractionByName(_item, "Upgrade", staff.Position, (ObjectInteraction objectInteraction) => objectInteraction.Valid);
			if (closestInteractionByName == null || !InteractionAlgorithms.InteractionReachable(staff, closestInteractionByName))
			{
				if (!_item.HasBeenDestroyed())
				{
					_item.GetOrAddComponent<EntityNavFailedComponent>().Init();
				}
				return true;
			}
			AssignStaff(staff, _item.OwningRoom);
			staff.SetBehaviour(staff.Definition._behaviourMaintenance);
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.SetVariable("Room", new RoomRef(_item.OwningRoom));
			behaviorTree.SetVariable("Interaction", new ObjectInteractionRef(closestInteractionByName));
			BindJobFinishedEvent(staff);
			return base.StartJob(staff);
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
				if (success)
				{
					RoomItemUpgradeComponent component = _item.GetComponent<RoomItemUpgradeComponent>();
					if (component != null && component.Progress < 1f)
					{
						StartJob(staff);
					}
					else
					{
						EndJob(staff);
					}
				}
				else
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
			if (_item.OwningRoom.EnterRoom(staff, ReasonUseRoom.Maintenance) && StartJob(staff))
			{
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
	}
}
