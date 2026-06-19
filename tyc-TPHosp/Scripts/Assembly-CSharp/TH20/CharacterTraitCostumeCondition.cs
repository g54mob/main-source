using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterTraitCostumeCondition : CharacterTraitCondition
	{
		private enum Comparison
		{
			Is = 0,
			IsNot = 1
		}

		[SerializeField]
		private CustomisationOption _costume;

		[SerializeField]
		private Comparison _comparison;

		public bool IsValid(Character character)
		{
			return Compare(character.Visual.CustomisationOption, _costume) == _comparison;
		}

		private static Comparison Compare(CustomisationOption currentCostume, CustomisationOption compareCostume)
		{
			if (currentCostume == compareCostume)
			{
				return Comparison.Is;
			}
			return Comparison.IsNot;
		}
	}
}
