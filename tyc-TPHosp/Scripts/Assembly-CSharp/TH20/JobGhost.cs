#define LOG_LEVEL_VERBOSE
using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class JobGhost : Job, INavPathResult
	{
		[CanBeNull]
		private Character _ghost;

		private Staff _ghostCatcher;

		private RoomItem _captureItem;

		[CanBeNull]
		private GhostComponent _ghostComponent;

		private float _lastNavFailTime;

		private bool _pathingToGhost;

		private RoomItemEctoVatComponent _ectoVatComponent;

		private StaffRequired _staffRequired;

		public bool IsEctoVatAssigned => _ectoVatComponent != null;

		public JobGhost(Character ghost)
		{
			_ghost = ghost;
			_ghostComponent = ghost.GetComponent<GhostComponent>();
			if (_ghostComponent != null)
			{
				_staffRequired = _ghostComponent.StaffRequired;
			}
		}

		public override string Description(Character.Sex gender)
		{
			if (gender != Character.Sex.Male)
			{
				return ScriptLocalization.Staff.Status_Ghostbust_CS_F;
			}
			return ScriptLocalization.Staff.Status_Ghostbust_CS_M;
		}

		public override string DescriptionDoing(Character.Sex gender)
		{
			if (gender != Character.Sex.Male)
			{
				return ScriptLocalization.Staff.Status_Ghostbusting_CS_F;
			}
			return ScriptLocalization.Staff.Status_Ghostbusting_CS_M;
		}

		public override string DebugDescription()
		{
			return $"capturing {_ghost}";
		}

		public override Sprite Icon()
		{
			if (_ghost == null)
			{
				return null;
			}
			return _ghost.Definition._icon;
		}

		public override bool IsReadyForWork()
		{
			return GameTime.time - _lastNavFailTime > GameAlgorithms.Config.GhostCaptureNavFailTimeOut;
		}

		public override float GetJobScore(Staff staff)
		{
			if (_ectoVatComponent == null)
			{
				if (_ghostComponent == null || _ghost == null)
				{
					return 0f;
				}
				return GameAlgorithms.CalculateGhostJobScore(_ghostComponent, staff, this);
			}
			return 100f;
		}

		public override StaffRequired StaffRequired()
		{
			return _staffRequired;
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
			return _staffRequired.QualificationInstance;
		}

		public override void OnAddedToScheduler()
		{
		}

		public override void OnRemovedFromScheduler()
		{
		}

		public override bool IsSuitable(Staff staff, bool checkExclusion, out string reason)
		{
			if (staff == _ghostCatcher)
			{
				reason = "OK";
				return true;
			}
			if (_ghostComponent == null)
			{
				reason = "there is no ghost";
				return false;
			}
			if (!_ghostComponent.CanSeeGhost(staff))
			{
				reason = "can't see ghost";
				return false;
			}
			if (!_ghostComponent.StaffRequired.IsSuitable(staff))
			{
				reason = "staff isn't right type or doesn't have qualification";
				return false;
			}
			if (checkExclusion && staff.IsJobExcluded(this))
			{
				reason = "job is excluded";
				return false;
			}
			reason = "OK";
			return true;
		}

		public override bool IsInRoom(Room room)
		{
			if (_ghost != null)
			{
				return _ghost.RoomUsing == room;
			}
			return false;
		}

		public override bool IsWithinDropRadius(Vector3 position)
		{
			if (_ghost != null)
			{
				return _ghost.Position.SquareDistance2D(position) < MathUtils.Square(GameAlgorithms.Config.JobStaffDropRadius);
			}
			return false;
		}

		public override bool CanLeave()
		{
			if (_ectoVatComponent == null && _ghostCatcher == null)
			{
				return base.CanLeave();
			}
			return false;
		}

		public override void MakeAvailable()
		{
			if (_ghostCatcher != null)
			{
				if (_pathingToGhost)
				{
					_ghostCatcher.Resume();
				}
				_ghostCatcher.NavPath.ClearExistingCallback(this);
			}
			base.MakeAvailable();
		}

		private RoomItem SpawnCaptureItem()
		{
			if (_ghost == null || _ghost.HasBeenDestroyed() || !_ghost.HasBeenRestored)
			{
				return null;
			}
			return RoomItemAlgorithms.SpawnItem(_ghost.GetDefinition<GhostDefinition>().CaptureItem.Instance, _ghost.Position, 0f, _ghost.RotationY, _ghost.Level, _ghost.RoomUsing);
		}

		public override bool StartJob(Staff staff)
		{
			if (_ghost == null)
			{
				Logging.Error(LogChannels.StaffWork, "Ghost is no longer valid for {0}", staff);
				return false;
			}
			staff.Idle();
			staff.Interrupt();
			_ghostCatcher = staff;
			AssignStaff(staff, _ghost.RoomUsing);
			_pathingToGhost = true;
			if (_ghost != null)
			{
				staff.NavPath.MoveTo(_ghost.Position, this, 2f);
			}
			return base.StartJob(staff);
		}

		public void OnStartPath()
		{
		}

		public void OnPathComplete(EPathStatus pathStatus)
		{
			Staff ghostCatcher = _ghostCatcher;
			ghostCatcher.Resume();
			_pathingToGhost = false;
			if (pathStatus == EPathStatus.Success && _ghostComponent != null && _ghostComponent.CanSeeGhost(ghostCatcher))
			{
				RoomItem roomItem = SpawnCaptureItem();
				if (roomItem != null && _ghostComponent != null)
				{
					_ghostComponent.BeginCapture();
					ghostCatcher.SetBehaviour(_ghostComponent.StaffRequired.Behaviour);
					ghostCatcher.BehaviorTree.SetVariable("Ghost", new CharacterRef(_ghost));
					ghostCatcher.BehaviorTree.SetVariable("CaptureItem", new ItemRef(roomItem));
					BindCaptureFinishedEvent(ghostCatcher, roomItem);
					return;
				}
			}
			_lastNavFailTime = GameTime.time;
			MakeAvailable();
			_ghostCatcher = null;
		}

		private void BindCaptureFinishedEvent(Staff staff, RoomItem captureItem)
		{
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate(bool success, GameObject behaviour)
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				staff.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(_captureItem);
				if (_ghost == null || _ghost.HasBeenDestroyed())
				{
					_ghost = null;
					success = false;
				}
				if (!success)
				{
					if (_ghost != null && _ghostComponent != null)
					{
						_ghost.Idle();
						_ghostComponent.EndCapture();
					}
					MakeAvailable();
				}
				else
				{
					_ghostComponent = null;
					staff.Level.CharacterEvents.OnGhostCaptured.InvokeSafe(_ghost, staff);
					_ghost = null;
					staff.GetOrAddComponent<CarryEctoplasmComponent>().Amount++;
				}
				staff.Level.CharacterEvents.OnStaffCompletedJob.InvokeSafe(staff, this, success);
				if (!StartEctoVatInteraction(staff))
				{
					EndJob(staff);
					_ectoVatComponent = null;
					_ghostCatcher = null;
				}
				_captureItem = null;
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
			_captureItem = captureItem;
			_ghostCatcher = staff;
		}

		private bool StartEctoVatInteraction(Staff staff)
		{
			CarryEctoplasmComponent component = staff.GetComponent<CarryEctoplasmComponent>();
			if (component == null)
			{
				return false;
			}
			_ectoVatComponent = RoomItemEctoVatComponent.Find(staff.Position);
			if (_ectoVatComponent == null)
			{
				return false;
			}
			if ((float)component.Amount < _ectoVatComponent.MinToDropOff)
			{
				return false;
			}
			RoomItem owner = _ectoVatComponent.GetOwner<RoomItem>();
			ObjectInteraction closestInteractionByName = InteractionAlgorithms.GetClosestInteractionByName(owner, "UseStaff", staff.Position, (ObjectInteraction objectInteraction) => objectInteraction.Valid);
			if (closestInteractionByName == null)
			{
				return false;
			}
			staff.SetBehaviour(_ectoVatComponent.Behaviour);
			staff.BehaviorTree.SetVariable("Character", new CharacterRef(staff));
			staff.BehaviorTree.SetVariable("Room", new RoomRef(owner.OwningRoom));
			staff.BehaviorTree.SetVariable("Interaction", new ObjectInteractionRef(closestInteractionByName));
			BindEctoVatInteraction(staff);
			return true;
		}

		private void BindEctoVatInteraction(Staff staff)
		{
			CharacterBehaviorTree.FinishedEvent finishedEvent = null;
			finishedEvent = delegate
			{
				CharacterBehaviorTree behaviorTree2 = staff.BehaviorTree;
				behaviorTree2.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Remove(behaviorTree2.OnFinishedEvent, finishedEvent);
				MakeAvailable();
				EndJob(staff);
				_ghostCatcher = null;
				staff.Level.StaffWorkScheduler.RemoveJob(this, complete: true);
			};
			CharacterBehaviorTree behaviorTree = staff.BehaviorTree;
			behaviorTree.OnFinishedEvent = (CharacterBehaviorTree.FinishedEvent)Delegate.Combine(behaviorTree.OnFinishedEvent, finishedEvent);
			_ghostCatcher = staff;
		}

		public override bool StartFromStaffDrop(Staff staff)
		{
			if (StartJob(staff))
			{
				return base.StartFromStaffDrop(staff);
			}
			return false;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_ghost != null)
			{
				Level level = _ghost.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
				{
					if (!_ghost.HasBeenRestored)
					{
						_ghost = null;
					}
				});
			}
			if (_staffRequired == null && _ghostComponent != null)
			{
				_staffRequired = _ghostComponent.StaffRequired;
			}
			if (_captureItem != null)
			{
				BindCaptureFinishedEvent(_ghostCatcher, _captureItem);
			}
			if (_ectoVatComponent != null && _ghostCatcher != null)
			{
				BindEctoVatInteraction(_ghostCatcher);
			}
		}

		public override ICursorSelectable Highlight()
		{
			return _ghost;
		}

		public override Vector3 GetWorldPosition()
		{
			if (_ghost != null)
			{
				return _ghost.Position;
			}
			if (_ectoVatComponent != null)
			{
				return _ectoVatComponent.GetOwner<RoomItem>().WorldPosition;
			}
			return new Vector3(0f, 0f, 0f);
		}

		public override void RemoveStaffFromRoom(Staff staff)
		{
			if (_ghost != null)
			{
				_ghost.RoomUsing.StaffLeaveRoom(staff);
			}
		}
	}
}
