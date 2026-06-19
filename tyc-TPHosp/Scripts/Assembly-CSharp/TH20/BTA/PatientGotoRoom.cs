using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Patient")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PatientGotoRoom : Action
	{
		[Tooltip("Patient")]
		public SharedPatientRef _patient;

		[Tooltip("Room")]
		public SharedRoomRef _room;

		[Tooltip("Reason")]
		public SharedReasonUseRoomRef _reason;

		public override TaskStatus OnUpdate()
		{
			if (_room.IsValid() && _patient.IsValid())
			{
				ReasonUseRoom reason = (_reason.IsValid() ? _reason.Get : ReasonUseRoom.Diagnosis);
				_patient.Get.GotoRoom(_room.Get, reason, false);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
