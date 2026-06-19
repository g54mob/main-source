using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HasTrait : CharacterConditional
	{
		[Tooltip("Character trait")]
		public SharedInstance_TH20TH20_CharacterTraitDefinition _trait;

		public override TaskStatus OnUpdate()
		{
			CharacterTraitDefinition trait = ((_trait != null) ? _trait.Instance : null);
			if (!base.Character.Traits.HasTrait(trait))
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}
	}
}
