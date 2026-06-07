using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Integer")]
	[Category("Reflection/Field Integer")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'integer' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetDecimalReflectionFieldInteger : PropertyTypeGetDecimal
	{
		[SerializeField]
		private ReflectionFieldInteger m_Field = new ReflectionFieldInteger();

		public override string String => m_Field.ToString();

		public override double Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
