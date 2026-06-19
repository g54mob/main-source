using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class JobFire : Job
	{
		private enum EAction
		{
			EnterRoom = 0,
			PickupExtinguisher = 1,
			PutOutFire = 2,
			Panic = 3,
			MoveToFire = 4
		}

		private EAction _action;

		private RoomItem _item;

		private RoomItemFireExtinguisherComponent _extinguisher;

		private RoomItemFlammableComponent _flammableComponent;

		public JobFire(RoomItem item)
		{
			_item = item;
			_flammableComponent = _item.GetComponent<RoomItemFlammableComponent>();
		}

		public override string Description(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_FireFight_CS_M : ScriptLocalization.Staff.Status_FireFight_CS_F, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DescriptionDoing(Character.Sex gender)
		{
			return LocalisedString.Replace((gender == Character.Sex.Male) ? ScriptLocalization.Staff.Status_FireFighting_CS_M : ScriptLocalization.Staff.Status_FireFighting_CS_F, "{[ITEM]}", _item.LocalisedName);
		}

		public override string DebugDescription()
		{
			return $"fire fighting {_item}";
		}

		public override Sprite Icon()
		{
			if (_item == null)
			{
				return null;
			}
			StatusIcon statusIcon = _item.Level.StatusIconManager.GetStatusIcon(StatusIcon.Type.Fire);
			if (statusIcon == null)
			{
				return null;
			}
			return statusIcon.Icon;
		}

		public override void AssignStaff(Staff staff, Room room)
		{
			base.AssignStaff(staff, room);
			if (staff.ModifiersComponent != null)
			{
				staff.ModifiersComponent.AddStatusEffect(_flammableComponent.Config.StatusEffectJanitor.Instance);
				if (_flammableComponent.Config.StatusEffectPanic.NotNull())
				{
					staff.ModifiersComponent.RemoveStatusEffect(_flammableComponent.Config.StatusEffectPanic.Instance);
				}
			}
		}

		public override void MakeAvailable()
		{
			BuildEvents buildEvents = _item.Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			if (_assignedStaff != null && _assignedStaff.ModifiersComponent != null)
			{
				_assignedStaff.ModifiersComponent.RemoveStatusEffect(_flammableComponent.Config.StatusEffectJanitor.Instance);
			}
			base.MakeAvailable();
		}

		public override bool IsReadyForWork()
		{
			return _item.GetComponent<EntityNavFailedComponent>() == null;
		}

		public override float GetJobScore(Staff staff)
		{
			return GameAlgorithms.CalculateFireJobScore(_item, staff, this);
		}

		public override bool IsSuitable(Staff staff, bool checkExclusion, out string reason)
		{
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
			reason = "OK";
			return true;
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

		public override bool IsInRoom(Room room)
		{
			return _item.OwningRoom == room;
		}

		public override bool IsWithinDropRadius(Vector3 position)
		{
			return _item.WorldPosition.SquareDistance2D(position) < MathUtils.Square(GameAlgorithms.Config.JobStaffDropRadius);
		}

		public override bool CanLeave()
		{
			if (_action == EAction.PickupExtinguisher || _action == EAction.PutOutFire)
			{
				return false;
			}
			return base.CanLeave();
		}

		public override ICursorSelectable Highlight()
		{
			return _item;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_assignedStaff != null)
			{
				switch (_action)
				{
				case EAction.EnterRoom:
					BindEnterRoomFinishedEvent(_assignedStaff);
					break;
				case EAction.PickupExtinguisher:
					BindPickupFinishedEvent(_assignedStaff, _extinguisher);
					break;
				case EAction.PutOutFire:
					BindPutOutFireFinishedEvent(_assignedStaff);
					break;
				case EAction.Panic:
					BindPanicFinishedEvent(_assignedStaff);
					break;
				case EAction.MoveToFire:
					BindMoveToFireFinishedEvent(_assignedStaff);
					break;
				}
			}
		}

		public override bool StartFromStaffDrop(Staff staff)
		{
			if (_item.OwningRoom.EnterRoom(staff, ReasonUseRoom.Maintenance))
			{
				EnterRoom(staff);
				return base.StartFromStaffDrop(staff);
			}
			return false;
		}

		public override bool StartJob(Staff staff)
		{
			AssignStaff(staff, _item.OwningRoom);
			GotoRoom(staff, _item.OwningRoom, ReasonUseRoom.Maintenance);
			return base.StartJob(staff);
		}

		protected override void StartRoomBehaviour(Staff staff)
		{
			if (_item.OwningRoom.Definition.IsHospitalOrBay)
			{
				StartNextTask(staff);
			}
			else
			{
				EnterRoom(staff);
			}
		}

		private void StartNextTask(Staff staff)
		{
			if (staff.GetComponent<HasFireExtinguisherComponent>() != null)
			{
				PutOutFire(staff);
				return;
			}
			RoomItemFireExtinguisherComponent roomItemFireExtinguisherComponent = FindExtinguisher(staff);
			if (roomItemFireExtinguisherComponent != null)
			{
				PickupFireExtinguisher(staff, roomItemFireExtinguisherComponent);
			}
			else if (_item.OwningRoom.Definition.IsHospitalOrBay && staff.RoomUsing != _item.OwningRoom)
			{
				MoveToFire(staff);
			}
			else
			{
				PanicInRoom(staff);
			}
		}

		private void EnterRoom(Staff staff)
		{
			_action = EAction.EnterRoom;
			staff.SetBehaviour(_flammableComponent.Config.EnterRoomBehaviour);
			BindEnterRoomFinishedEvent(staff);
		}

		private void BindEnterRoomFinishedEvent(Staff staff)
		{
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				if (success)
				{
					StartNextTask(staff);
				}
				else if (_action == EAction.EnterRoom)
				{
					MakeAvailable();
				}
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void PickupFireExtinguisher(Staff staff, RoomItemFireExtinguisherComponent extinguisher)
		{
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			RoomItem owner = extinguisher.GetOwner<RoomItem>();
			_action = EAction.PickupExtinguisher;
			extinguisher.AssignStaff(staff);
			staff.SetBehaviour(_flammableComponent.Config.PickupExtinguisherBehaviour);
			behaviorTree.SetVariable("Room", new RoomRef(owner.OwningRoom));
			behaviorTree.SetVariable("Extinguisher", new ItemRef(owner));
			BindPickupFinishedEvent(staff, extinguisher);
		}

		private void BindPickupFinishedEvent(Staff staff, RoomItemFireExtinguisherComponent extinguisher)
		{
			_extinguisher = extinguisher;
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				if (_extinguisher != null)
				{
					_extinguisher.AssignStaff(null);
				}
				if (success)
				{
					staff.GetOrAddComponent<HasFireExtinguisherComponent>();
					if (_extinguisher != null && !_extinguisher.HasBeenDestroyed())
					{
						_extinguisher.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(_extinguisher.GetOwner<RoomItem>());
					}
					_extinguisher = null;
					PutOutFire(staff);
				}
				else
				{
					_extinguisher = null;
					MakeAvailable();
					EndJob(staff);
				}
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void PutOutFire(Staff staff)
		{
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			ObjectInteraction closestInteractionByName = InteractionAlgorithms.GetClosestInteractionByName(_item, "PutOutFire", staff.Position, (ObjectInteraction objectInteraction) => objectInteraction.Valid);
			_action = EAction.PutOutFire;
			staff.SetBehaviour(_flammableComponent.Config.PutOutFireBehaviour);
			behaviorTree.SetVariable("Item", new ItemRef(_item));
			behaviorTree.SetVariable("Room", new RoomRef(_item.OwningRoom));
			behaviorTree.SetVariable("Interaction", new ObjectInteractionRef(closestInteractionByName));
			BindPutOutFireFinishedEvent(staff);
		}

		private void BindPutOutFireFinishedEvent(Staff staff)
		{
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				EndJob(staff);
				if (success)
				{
					staff.RemoveComponents<HasFireExtinguisherComponent>();
					if (_item.MaintenanceLevel.Value() > GameAlgorithms.Config.ItemSetOnFireThreshold)
					{
						_item.MaintenanceLevel.SetValue(GameAlgorithms.Config.ItemSetOnFireThreshold - 1f, callCallbacks: true);
					}
					_item.Level.StaffWorkScheduler.StartRoomItemJobForStaff<JobMaintenance>(staff, _item);
				}
				else if (_action == EAction.PutOutFire)
				{
					MakeAvailable();
				}
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void MoveToFire(Staff staff)
		{
			if (!RoomAlgorithms.GetRandomFreeTileWithinRadius(_item.FloorPlan, _item.WorldPosition, 6f, out var worldPositionOut))
			{
				worldPositionOut = _item.WorldPosition;
			}
			_action = EAction.MoveToFire;
			staff.SetBehaviour(_flammableComponent.Config.MoveToFireBehavior);
			staff.BehaviorTree.SetVariable("Destination", worldPositionOut);
			BindMoveToFireFinishedEvent(staff);
		}

		private void BindMoveToFireFinishedEvent(Staff staff)
		{
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				if (success)
				{
					StartNextTask(staff);
				}
				else if (_action == EAction.MoveToFire)
				{
					EndJob(staff);
				}
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
		}

		private void PanicInRoom(Staff staff)
		{
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			_action = EAction.Panic;
			staff.SetBehaviour(_flammableComponent.Config.PanicBehaviour);
			behaviorTree.SetVariable("Room", new RoomRef(_item.OwningRoom));
			BindPanicFinishedEvent(staff);
			staff.Level.StatusIconManager.ShowStatusIcon(staff, StatusIcon.Type.FireExtinguisher);
		}

		private void BindPanicFinishedEvent(Staff staff)
		{
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				staff.Level.StatusIconManager.DestroyStatusIcon(staff);
				BuildEvents buildEvents3 = _item.Level.BuildEvents;
				buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
				if (success)
				{
					StartNextTask(staff);
				}
				else if (_action == EAction.Panic)
				{
					EndJob(staff);
				}
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
			BuildEvents buildEvents = _item.Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _item.Level.BuildEvents;
			buildEvents2.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			RoomItemFireExtinguisherComponent component = roomItem.GetComponent<RoomItemFireExtinguisherComponent>();
			if (component != null && !component.StaffAssigned)
			{
				BuildEvents buildEvents = _item.Level.BuildEvents;
				buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
				if (_assignedStaff != null && _action == EAction.Panic)
				{
					PickupFireExtinguisher(_assignedStaff, component);
				}
			}
		}

		private RoomItemFireExtinguisherComponent FindExtinguisher(Staff staff)
		{
			List<RoomItemFireExtinguisherComponent> extinguishers = new List<RoomItemFireExtinguisherComponent>();
			RoomAlgorithms.IterateRoomItemsWithComponent(_item.OwningRoom, delegate(RoomItemFireExtinguisherComponent component)
			{
				if (!component.StaffAssigned)
				{
					extinguishers.Add(component);
				}
			});
			Room roomUsing = staff.RoomUsing;
			if (roomUsing != null)
			{
				HospitalMap hospitalMap = roomUsing.FloorPlan.HospitalMap;
				if (extinguishers.Count == 0)
				{
					RoomAlgorithms.IterateRoomItemsWithComponent(hospitalMap.FloorPlan.OwningRoom, delegate(RoomItemFireExtinguisherComponent component)
					{
						if (!component.StaffAssigned)
						{
							extinguishers.Add(component);
						}
					});
					if (extinguishers.Count == 0)
					{
						foreach (Room allRoom in staff.Level.WorldState.AllRooms)
						{
							RoomAlgorithms.IterateRoomItemsWithComponent(allRoom, delegate(RoomItemFireExtinguisherComponent component)
							{
								if (!component.StaffAssigned)
								{
									extinguishers.Add(component);
								}
							});
						}
					}
				}
			}
			if (extinguishers.Count != 0)
			{
				Vector3 staffPos = staff.Position;
				extinguishers.Sort(delegate(RoomItemFireExtinguisherComponent ex1, RoomItemFireExtinguisherComponent ex2)
				{
					float extinguisherScore = GetExtinguisherScore(ex1.GetOwner<RoomItem>(), staffPos);
					float extinguisherScore2 = GetExtinguisherScore(ex2.GetOwner<RoomItem>(), staffPos);
					return extinguisherScore.CompareTo(extinguisherScore2);
				});
				return extinguishers[0];
			}
			return null;
		}

		private float GetExtinguisherScore(RoomItem extinguisher, Vector3 staffPos)
		{
			return staffPos.SquareDistance2D(extinguisher.WorldPosition);
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
