using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Double")]
	[Category("Reflection/Property Double")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'double' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetDecimalReflectionPropertyDouble : PropertyTypeGetDecimal
	{
		[SerializeField]
		private ReflectionPropertyDouble m_Property = new ReflectionPropertyDouble();

		public override string String => m_Property.ToString();

		public override double Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
