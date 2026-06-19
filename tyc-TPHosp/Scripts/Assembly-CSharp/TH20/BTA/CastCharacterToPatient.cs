using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CastCharacterToPatient : CharacterAction
	{
		[Tooltip("Character")]
		public SharedCharacterRef _character;

		[Tooltip("Patient")]
		public SharedPatientRef _patient;

		public override TaskStatus OnUpdate()
		{
			if (_character.Get is Patient patient)
			{
				_patient.Value = new PatientRef(patient);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
