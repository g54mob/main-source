using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Double")]
	[Category("Reflection/Field Double")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'double' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetDecimalReflectionFieldDouble : PropertyTypeGetDecimal
	{
		[SerializeField]
		private ReflectionFieldDouble m_Field = new ReflectionFieldDouble();

		public override string String => m_Field.ToString();

		public override double Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
