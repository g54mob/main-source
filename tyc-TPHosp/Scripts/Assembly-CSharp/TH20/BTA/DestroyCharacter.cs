using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DestroyCharacter : CharacterAction
	{
		public override TaskStatus OnUpdate()
		{
			if (base.Character is Patient)
			{
				base.Character.Level.CharacterEvents.OnPatientDied.InvokeSafe((Patient)base.Character);
			}
			base.Character.Level.CharacterEvents.OnDestroyCharacter.InvokeSafe(base.Character);
			return TaskStatus.Success;
		}
	}
}
