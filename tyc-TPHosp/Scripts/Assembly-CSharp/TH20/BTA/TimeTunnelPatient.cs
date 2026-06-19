using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Patient")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TimeTunnelPatient : Action
	{
		[Tooltip("Patient")]
		public SharedPatientRef _patient;

		public override TaskStatus OnUpdate()
		{
			if (_patient.IsValid())
			{
				Patient get = _patient.Get;
				get.Level.CharacterEvents.OnPatientTimeTunnel.InvokeSafe(get);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
