using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Patient")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/{SkinColor}WanderIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WaitForRoom : Action
	{
		[Tooltip("Patient")]
		public SharedPatientRef _patient;

		[Tooltip("Room Type")]
		public RoomDefinition.Type _type;

		[Tooltip("Reason")]
		public ReasonUseRoom _reason;

		public override TaskStatus OnUpdate()
		{
			if (!_patient.IsValid())
			{
				return TaskStatus.Failure;
			}
			_patient.Get.WaitForRoomToBeBuilt(_type, _reason, GameAlgorithms.Config.PatientWaitLongTime);
			return TaskStatus.Success;
		}
	}
}
