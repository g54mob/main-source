using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Patient")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GetRoomGoingTo : CharacterAction
	{
		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Patient")]
		public SharedPatientRef _patient;

		public override TaskStatus OnUpdate()
		{
			if (_patient.IsValid())
			{
				_room.Value = new RoomRef(_patient.Get.GoingToRoom);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
