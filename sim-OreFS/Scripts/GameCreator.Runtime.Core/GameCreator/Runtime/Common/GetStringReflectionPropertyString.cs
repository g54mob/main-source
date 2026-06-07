using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property String")]
	[Category("Reflection/Property String")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'string' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetStringReflectionPropertyString : PropertyTypeGetString
	{
		[SerializeField]
		private ReflectionPropertyString m_Property = new ReflectionPropertyString();

		public override string String => m_Property.ToString();

		public override string Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
