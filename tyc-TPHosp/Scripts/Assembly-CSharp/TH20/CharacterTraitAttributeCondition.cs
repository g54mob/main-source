using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterTraitAttributeCondition : CharacterTraitCondition
	{
		private enum Comparison
		{
			Equal = 0,
			LessThan = 1,
			GreaterThan = 2
		}

		[SerializeField]
		private CharacterAttributes.Type _type;

		[SerializeField]
		private Comparison _comparison;

		[SerializeField]
		private float _compareValue;

		public bool IsValid(Character character)
		{
			AttributeFloat attribute = character.GetCharacterAttributes().GetAttribute(_type);
			if (attribute != null)
			{
				return Compare(attribute.Value(), _compareValue) == _comparison;
			}
			return false;
		}

		private static Comparison Compare(float lhs, float rhs)
		{
			if (lhs < rhs)
			{
				return Comparison.LessThan;
			}
			if (lhs > rhs)
			{
				return Comparison.GreaterThan;
			}
			return Comparison.Equal;
		}
	}
}
