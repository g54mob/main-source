#define LOG_LEVEL_VERBOSE
using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class GuestTrainer : Staff
	{
		private bool _enabled;

		private Room _waitingForRoom;

		public bool Enabled => _enabled;

		public new GuestTrainerDefinition Definition { get; private set; }

		public GuestTrainer(JobApplicant applicant, Level level, VisualManager visualManager, int id)
			: base(applicant, level, visualManager, id, Vector3.zero, navDisabled: true)
		{
			Definition = applicant.Definition as GuestTrainerDefinition;
			SetEnabled(enabled: false);
			SetBehaviour(applicant.Definition._behaviourIdle);
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			base.Destroy();
		}

		public void SetEnabled(bool enabled)
		{
			_enabled = enabled;
			base.Visual.SetActive(enabled);
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			SetEnabled(_enabled);
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			if (!IsAssignedToTraining())
			{
				Logging.Warning(LogChannels.Behaviour, "Found {0} who is not assigned to a training room. Sending them out of the hospital", this);
				Level level = base.Level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, new Action(Idle));
			}
		}

		public override void FixupMissingBehaviour()
		{
			Logging.Warning(LogChannels.Behaviour, "Trying to fix up {0} as they failed to load correctly", this);
			if (_enabled && base.Position == Vector3.zero && (int)base.RotationY == 0)
			{
				Logging.Warning(LogChannels.Behaviour, "{0} is looking like a zombie trainer, destroy!", this);
				base.Level.CharacterManager.DestroyOrphan(this);
				return;
			}
			if (base.RoomUsing == null)
			{
				ForceUpdateRoomUsing(base.Level.WorldState.GetRoomAtWorldCoord(base.Position, includeHospital: true, includeClosedPlots: false));
			}
			if (base.Interaction != null)
			{
				base.Interaction.InterruptInteraction(this, characterDestroyed: false);
			}
			if (base.NavPath.IsKinematic)
			{
				base.NavPath.StopBeingKinematic();
			}
			Idle();
		}

		public override void Update(float deltaTime)
		{
			if (_enabled)
			{
				base.Update(deltaTime);
			}
		}

		public override void Idle()
		{
			SetCurrentMode(Mode.Work);
			LeaveHospital(ReasonForLeavingHospital.None);
		}

		public override bool CanSatisfyNeeds()
		{
			return false;
		}

		public void WaitForTrainingRoom(Room room)
		{
			base.NavPath.Halt();
			base.GoingToRoom = null;
			_waitingForRoom = room;
			SetBehaviour(Definition._behaviourIdle);
		}

		public override bool StartTraining(QualificationDefinition qualification, Room room)
		{
			if (base.CurrentMode != Mode.Training && !IsInteractingWithRoomDoor())
			{
				bool result = base.TeachingQualification != qualification;
				_waitingForRoom = null;
				base.TeachingQualification = qualification;
				SetCurrentMode(Mode.Training);
				if (base.RoomUsing != room)
				{
					GotoRoom(room, ReasonUseRoom.Work, setByPlayer: false);
					return result;
				}
				room.GetComponent<RoomLogicTrainingRoom>().StartTeacherBehaviour(this);
				return result;
			}
			return false;
		}

		public override string GetStatusText()
		{
			if (Enabled)
			{
				if (base.CurrentMode != Mode.Work)
				{
					return base.GetStatusText();
				}
				return ScriptLocalization.HospitalEvent.VIPLeaving_CS;
			}
			return string.Empty;
		}

		public override Sprite GetStatusSprite()
		{
			if (base.CurrentMode != Mode.Work)
			{
				return base.GetStatusSprite();
			}
			return Definition.TrainingRoomIcon;
		}

		private bool IsAssignedToTraining()
		{
			foreach (Room allRoom in base.Level.WorldState.AllRooms)
			{
				RoomLogicTrainingRoom component = allRoom.GetComponent<RoomLogicTrainingRoom>();
				if (component != null && component.IsTrainerAssigned(this))
				{
					return true;
				}
			}
			return false;
		}

		private void OnRoomDeleted(Room room)
		{
			if (room == _waitingForRoom)
			{
				_waitingForRoom = null;
				Idle();
			}
		}
	}
}
