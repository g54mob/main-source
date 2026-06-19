using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HasStatusEffect : CharacterConditional
	{
		public SharedInstance_TH20TH20_CharacterStatusEffectDefinition _statusEffect;

		public override TaskStatus OnUpdate()
		{
			CharacterStatusEffectDefinition characterStatusEffectDefinition = ((_statusEffect != null) ? _statusEffect.Instance : null);
			if (characterStatusEffectDefinition == null || base.Character.ModifiersComponent == null)
			{
				return TaskStatus.Failure;
			}
			if (!base.Character.ModifiersComponent.StatusEffects.ContainsKey(characterStatusEffectDefinition))
			{
				return TaskStatus.Failure;
			}
			return TaskStatus.Success;
		}
	}
}
