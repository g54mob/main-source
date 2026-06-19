using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AddStatusEffect : CharacterAction
	{
		[SerializeField]
		private SharedInstance_TH20TH20_CharacterStatusEffectDefinition _statusEffect;

		public override TaskStatus OnUpdate()
		{
			if (base.Character.ModifiersComponent != null)
			{
				base.Character.ModifiersComponent.AddStatusEffect(_statusEffect.Instance);
			}
			return TaskStatus.Success;
		}
	}
}
