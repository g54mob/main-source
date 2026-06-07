using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Color")]
	[Category("Reflection/Property Color")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Color' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetColorReflectionPropertyColor : PropertyTypeGetColor
	{
		[SerializeField]
		private ReflectionPropertyColor m_Property = new ReflectionPropertyColor();

		public override string String => m_Property.ToString();

		public override Color Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
