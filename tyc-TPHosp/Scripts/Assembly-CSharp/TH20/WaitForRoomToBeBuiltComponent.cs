using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WaitForRoomToBeBuiltComponent : EntityTickComponent
	{
		private float _time;

		private List<RoomDefinition.Type> _roomTypes;

		private bool _waitingForReception;

		public float Time => _time;

		public List<RoomDefinition.Type> RoomTypes => _roomTypes;

		public bool WaitingForReception => _waitingForReception;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		private bool RoomTypesAreDifferent(List<RoomDefinition.Type> newTypes)
		{
			if (_roomTypes == null || newTypes.Count != _roomTypes.Count)
			{
				return true;
			}
			for (int i = 0; i < newTypes.Count; i++)
			{
				if (newTypes[i] != _roomTypes[i])
				{
					return true;
				}
			}
			return false;
		}

		public void Initialise(List<RoomDefinition.Type> roomTypes, float waitTime)
		{
			if (RoomTypesAreDifferent(roomTypes))
			{
				_time = waitTime;
				_roomTypes = roomTypes;
			}
			if (_roomTypes.Contains(RoomDefinition.Type.Reception))
			{
				_waitingForReception = true;
			}
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			RegisterEvents();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
		}

		private void UnregisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			if (RoomTypes.Contains(room.Definition._type))
			{
				Destroy();
			}
		}

		public override void Tick()
		{
			base.Tick();
			Character owner = GetOwner<Character>();
			Patient patient = owner as Patient;
			_time -= GameTime.deltaTime;
			base.Level.StatusIconManager.ShowStatusIcon(owner, StatusIcon.Type.WaitForBuiltRoom);
			bool waitingForReceptionist;
			if (_time <= 0f)
			{
				if (patient != null)
				{
					patient.WasWaitingForRoom = _roomTypes[0];
					patient.RageQuit();
				}
				else
				{
					owner.LeaveHospital(Character.ReasonForLeavingHospital.RageQuit);
				}
				if (!HasBeenDestroyed())
				{
					Destroy();
				}
			}
			else if (_waitingForReception && base.Level.ReceptionManager.IsReceptionValid(out waitingForReceptionist))
			{
				patient?.StopWaitingForRoom();
				Destroy();
			}
		}
	}
}
