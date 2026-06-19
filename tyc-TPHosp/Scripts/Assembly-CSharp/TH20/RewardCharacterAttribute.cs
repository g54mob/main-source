using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardCharacterAttribute : IRewardCharacter
	{
		[SerializeField]
		private CharacterAttributes.Type _attribute;

		[SerializeField]
		private float _amount;

		public override void Apply(Character character)
		{
			character.GetCharacterAttributes().GetAttribute(_attribute)?.Modify(_amount, 1f);
		}

		public override string Description(Objective objective)
		{
			return $"{StringUtils.FormatPercentageValue(_amount / 100f, prefixPlus: true)} {CharacterAttributes.GetAttributeNameLoc(_attribute)}";
		}
	}
}
