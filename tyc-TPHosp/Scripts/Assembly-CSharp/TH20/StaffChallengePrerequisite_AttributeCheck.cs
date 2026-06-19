using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffChallengePrerequisite_AttributeCheck : StaffChallengePrerequisite
	{
		private enum Operator
		{
			Equals = 0,
			LessThan = 1,
			GreaterThan = 2
		}

		[SerializeField]
		private CharacterAttributes.Type _attribute;

		[SerializeField]
		private Operator _operator;

		[SerializeField]
		private float _value;

		public bool IsValid(Level level, Staff staff)
		{
			AttributeFloat attribute = staff.GetCharacterAttributes().GetAttribute(_attribute);
			if (attribute != null)
			{
				return CompareValues(attribute.Value(), _value) == _operator;
			}
			return false;
		}

		private Operator CompareValues(float lhs, float rhs)
		{
			if (lhs < rhs)
			{
				return Operator.LessThan;
			}
			if (lhs > rhs)
			{
				return Operator.GreaterThan;
			}
			return Operator.Equals;
		}
	}
}
