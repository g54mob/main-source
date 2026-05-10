using System;
using UnityEngine;

namespace CTS
{
	[AttributeUsage(AttributeTargets.Field)]
	public class UniqueFlagAttribute : PropertyAttribute
	{
		public Type EnumType { get; }

		public bool ValidateEnumType { get; }

		public UniqueFlagAttribute(Type p_enumType, bool validateEnumType = true)
		{
			EnumType = p_enumType;
			ValidateEnumType = validateEnumType;
		}

		public UniqueFlagAttribute(bool validateEnumType = true)
		{
			EnumType = null;
			ValidateEnumType = validateEnumType;
		}
	}
}
