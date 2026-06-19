using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Room")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetNextPatientInQueue : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Patient")]
		public SharedPatientRef _patient;

		[Tooltip("Call into room?")]
		public bool _callIntoRoom = true;

		[Tooltip("Check patient can use room?")]
		public bool _checkCanUseRoom = true;

		public override void OnStart()
		{
			base.OnStart();
			_patient.Value = new PatientRef(null);
		}

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid())
			{
				Room get = _room.Get;
				if (get.QueueLength != 0 && (!(base.Character is Staff staff) || staff.CanCallPeopleIntoRoom()) && get.GetFrontOfQueue() is Patient patient && !patient.HasBeenCalledIntoRoom() && patient.CanBeCalledIntoRoom() && (!_checkCanUseRoom || CanRoomBeUsed(get)))
				{
					_patient.Value = new PatientRef(patient);
					get.RemoveFromQueue(patient);
					if (_callIntoRoom)
					{
						patient.CalledIntoRoom = true;
						get.CharacterEntering = patient;
						patient.InterruptNeedSatisfaction();
					}
					return TaskStatus.Success;
				}
				return TaskStatus.Running;
			}
			return TaskStatus.Failure;
		}

		private static bool CanRoomBeUsed(Room room)
		{
			if (room.CharacterEntering != null)
			{
				return false;
			}
			if (!room.IsFunctional())
			{
				return false;
			}
			if (!room.IsStaffed())
			{
				return false;
			}
			if (room.IsAtMaxCapacity())
			{
				return false;
			}
			if (room.MachineUpgradeInProgress() || room.MachineRepairInProgress())
			{
				bool flag = false;
				foreach (RoomItem item in room.FloorPlan.Items)
				{
					bool num = !room.IsItemBeingRepaired(item);
					bool flag2 = !room.IsItemBeingUpgraded(item);
					bool flag3 = item.IsFunctional();
					if (num && flag2 && flag3)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}
	}
}
