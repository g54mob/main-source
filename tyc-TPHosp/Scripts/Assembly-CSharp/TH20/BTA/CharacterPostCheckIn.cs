using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterPostCheckIn : CharacterAction
	{
		public override TaskStatus OnUpdate()
		{
			if (base.Character is Patient patient && patient.IsLeavingHospital())
			{
				return TaskStatus.Success;
			}
			base.Character.RemoveComponents<CharacterCheckInComponent>();
			base.Character.SetBehaviour(base.Character.Definition._behaviourPostCheckIn);
			return TaskStatus.Success;
		}
	}
}
