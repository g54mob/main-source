using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierLocoAnimationGraph : CharacterModifier
	{
		public int Priority;

		public RuntimeAnimatorController[] LocoGraphs;

		public MovementSpeedModifierSettings? MovementSpeedModifierSettings;

		public override void Add(Character character)
		{
			character.RefreshLocoAnimationGraph();
		}

		public override void Remove(Character character)
		{
			character.RefreshLocoAnimationGraph();
		}
	}
}
