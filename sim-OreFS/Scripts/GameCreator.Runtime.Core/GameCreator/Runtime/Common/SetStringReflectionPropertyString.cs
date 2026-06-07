using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property String")]
	[Category("Reflection/Property String")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'string' value of a property of a component")]
	public class SetStringReflectionPropertyString : PropertyTypeSetString
	{
		[SerializeField]
		private ReflectionPropertyString m_Property = new ReflectionPropertyString();

		public override string String => m_Property.ToString();

		public override void Set(string value, Args args)
		{
			m_Property.Value = value;
		}

		public override string Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
