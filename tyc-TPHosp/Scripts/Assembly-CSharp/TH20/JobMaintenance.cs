#define LOG_LEVEL_VERBOSE
using System;
using FullInspector;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class JobMaintenance : Job
	{
		public enum JobDescription
		{
			None = 0,
			BrokenMachine = 1,
			BlockedToilet = 2,
			OutOfStock = 3,
			WiltedPlant = 4,
			Litter = 5,
			MedicalWaste = 6,
			Ghost = 7,
			Vehicular = 8,
			Max = 9
		}

		private readonly RoomItem _item;

		private readonly float _cachedInitialMaintenanceValue;

		private Staff _staffOnJob;

		private ObjectInteraction _interaction;

		public RoomItem Item => _item;

		public float InitialMaintenanceValue => _cachedInitialMaintenanceValue;

		public float MaintenanceValue
		{
			get
			{
				if (_staffOnJob == null)
				{
					return _item.MaintenanceLevel.Value();
				}
				return InitialMaintenanceValue;
			}
		}

		public JobMaintenance(RoomItem item)
		{
			_item = item;
			_cachedInitialMaintenanceValue = _item.MaintenanceLevel.Value();
		}

		public override string Description(Character.Sex gender)
		{
			return LocalisedString.Replace(GameStringUtils.GetJobActionString(_item.Definition.MaintenanceDescription), "{[ITEM]}", _item.LocalisedName);
		}

		public override string DescriptionDoing(Character.Sex gender)
		{
			return LocalisedString.Replace(GameStringUtils.GetJobDescriptionString(_item.Definition.MaintenanceDescription), "{[ITEM]}", _item.LocalisedName);
		}

		public override string DebugDescription()
		{
			return $"maintaining {_item} ({_item.Definition.MaintenanceDescription})";
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
			return null;
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
			if (staff == null || staff.Definition == null)
			{
				reason = "invalid staff member";
				return false;
			}
			if (staff.Definition._type != StaffDefinition.Type.Janitor)
			{
				reason = "not a janitor";
				return false;
			}
			if (_item == null || _item.OwningRoom == null || _item.OwningRoom.FloorPlan == null || _item.OwningRoom.FloorPlan.HospitalMap == null || _item.OwningRoom.FloorPlan.HospitalMap.Plot == null)
			{
				reason = "invalid plot";
				return false;
			}
			if (!_item.OwningRoom.FloorPlan.HospitalMap.Plot.Bought)
			{
				reason = "plot not owned";
				return false;
			}
			if (checkExclusion && staff.IsJobExcluded(this))
			{
				reason = "job is exluded";
				return false;
			}
			RoomItemUpgradeComponent component = _item.GetComponent<RoomItemUpgradeComponent>();
			if (component != null && component.Job != null && component.Job.GetStaff() != null)
			{
				reason = "item is being upgraded";
				return false;
			}
			RoomItemFlammableComponent component2 = _item.GetComponent<RoomItemFlammableComponent>();
			if (component2 != null && component2.Job != null)
			{
				reason = "item is on fire!";
				return false;
			}
			RoomItemMaintenanceChallengeComponent component3 = _item.GetComponent<RoomItemMaintenanceChallengeComponent>();
			RoboJanitorComponent component4 = staff.GetComponent<RoboJanitorComponent>();
			if (component3 != null && component4 == null)
			{
				reason = "item requires robo-janitor";
				return false;
			}
			if (IsVehicular() && !staff.CanRepairVehicles)
			{
				reason = "Not qualified for Vehicle Maintenance";
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
			return GameAlgorithms.CalculateMaintenanceJobScore(_item, staff, this);
		}

		public override bool StartJob(Staff staff)
		{
			_interaction = InteractionAlgorithms.GetClosestInteractionByName(_item, "Maintenance", staff.Position, (ObjectInteraction objectInteraction) => objectInteraction.Valid);
			if (_interaction == null || !InteractionAlgorithms.InteractionReachable(staff, _interaction))
			{
				if (!_item.HasBeenDestroyed())
				{
					_item.GetOrAddComponent<EntityNavFailedComponent>().Init();
				}
				_interaction = null;
				return true;
			}
			staff.SetBehaviour(staff.Definition._behaviourMaintenance);
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.SetVariable("Room", new RoomRef(_item.OwningRoom));
			behaviorTree.SetVariable("Interaction", new ObjectInteractionRef(_interaction));
			AssignStaff(staff, _item.OwningRoom);
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
					JobDescription maintenanceDescription = _item.Definition.MaintenanceDescription;
					if (maintenanceDescription == JobDescription.Litter || maintenanceDescription == JobDescription.MedicalWaste || maintenanceDescription == JobDescription.Ghost)
					{
						EndJob(staff);
					}
					else
					{
						bool flag = maintenanceDescription == JobDescription.None || maintenanceDescription == JobDescription.BrokenMachine || maintenanceDescription == JobDescription.Vehicular;
						if (flag && !_item.IsFullyRepaired())
						{
							StartJob(staff);
						}
						else if (!flag && !_item.IsRepaired())
						{
							StartJob(staff);
						}
						else
						{
							EndJob(staff);
						}
					}
				}
				else
				{
					if (staff.CurrentMode == Staff.Mode.Work)
					{
						staff.Idle();
					}
					staff.GetOrAddComponent<StaffFailedToStartJobComponent>();
				}
				staff.Level.CharacterEvents.OnStaffCompletedJob.InvokeSafe(staff, this, success);
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		protected override void EndJob(Staff staff)
		{
			base.EndJob(staff);
			staff.Level.BuildEvents.OnRoomItemMaintenanceComplete.InvokeSafe(_item, staff, this);
		}

		public override bool StartFromStaffDrop(Staff staff)
		{
			if (_item.OwningRoom.EnterRoom(staff, ReasonUseRoom.Maintenance) && StartJob(staff))
			{
				return base.StartFromStaffDrop(staff);
			}
			return false;
		}

		public override void BecomeHighPriority()
		{
			base.BecomeHighPriority();
			_item.Level.StatusIconManager.ShowStatusIcon(_item, StatusIcon.Type.MaintenanceWarning);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_staffOnJob != null)
			{
				BindJobFinishedEvent(_staffOnJob);
			}
			Level level = _item.Level;
			level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
			{
				if (base.HighPriority)
				{
					_item.Level.StatusIconManager.ShowStatusIcon(_item, StatusIcon.Type.MaintenanceWarning);
				}
				else if (_item.Definition.ShowStatusIcon && _item.MaintenanceLevel.Value() >= 100f)
				{
					_item.Level.StatusIconManager.ShowStatusIcon(_item, StatusIcon.Type.MaintenanceRequired);
				}
				if (_item.FloorPlan.Definition.IsHospitalOrBay)
				{
					IRoomItemDefinition definition = _item.Definition;
					if ((definition.MaintenanceDescription == JobDescription.Litter || definition.MaintenanceDescription == JobDescription.MedicalWaste) && !_item.HasBeenDestroyed() && !_item.FloorPlan.HospitalMap.PositionConnectsToEntrance(_item.WorldPosition.ToGridCoord()))
					{
						Logging.Warning(LogChannels.StaffWork, "Destroying invalid litter/waste item {0}", _item);
						_item.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(_item);
					}
				}
			});
		}

		public override ICursorSelectable Highlight()
		{
			return _item;
		}

		public override void Interrupt()
		{
			base.Interrupt();
			if ((_item.Definition.MaintenanceDescription == JobDescription.None || _item.Definition.MaintenanceDescription == JobDescription.BrokenMachine || _item.Definition.MaintenanceDescription == JobDescription.Vehicular) && _item.IsRepaired() && _staffOnJob != null)
			{
				_staffOnJob.Level.BuildEvents.OnRoomItemMaintenanceComplete.InvokeSafe(_item, _staffOnJob, this);
			}
		}

		public int GetCost()
		{
			int num = 0;
			if (_interaction != null)
			{
				InteractionAttributeModifier[] interactionAttributeModifiers = _item.Definition.InteractionAttributeModifiers;
				foreach (InteractionAttributeModifier interactionAttributeModifier in interactionAttributeModifiers)
				{
					if (interactionAttributeModifier._interactionType == _interaction.Type && (string.IsNullOrEmpty(interactionAttributeModifier._interactionName) || interactionAttributeModifier._interactionName == _interaction.Name))
					{
						SharedInstance<FinanceModifier> financeModifier = interactionAttributeModifier._financeModifier;
						if (financeModifier.NotNull())
						{
							num += financeModifier.Instance.GetCost(InitialMaintenanceValue / 100f);
						}
					}
				}
			}
			return num;
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
