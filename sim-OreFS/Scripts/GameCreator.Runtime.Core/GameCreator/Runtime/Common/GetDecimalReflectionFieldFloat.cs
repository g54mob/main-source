using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Float")]
	[Category("Reflection/Field Float")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'float' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetDecimalReflectionFieldFloat : PropertyTypeGetDecimal
	{
		[SerializeField]
		private ReflectionFieldFloat m_Field = new ReflectionFieldFloat();

		public override string String => m_Field.ToString();

		public override double Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
