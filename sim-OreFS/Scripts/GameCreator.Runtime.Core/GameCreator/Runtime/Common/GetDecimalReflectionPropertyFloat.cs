using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Float")]
	[Category("Reflection/Property Float")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'float' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetDecimalReflectionPropertyFloat : PropertyTypeGetDecimal
	{
		[SerializeField]
		private ReflectionPropertyFloat m_Property = new ReflectionPropertyFloat();

		public override string String => m_Property.ToString();

		public override double Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
