using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Patient")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ProcessDiagnosisTreatment : CharacterAction
	{
		public override TaskStatus OnUpdate()
		{
			base.Character.GetComponent<DiagnosisTreatmentComponent>()?.Process();
			return TaskStatus.Success;
		}
	}
}
