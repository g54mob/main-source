using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Bool")]
	[Category("Reflection/Property Bool")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'boolean' value of a property of a component")]
	public class SetBoolReflectionPropertyBool : PropertyTypeSetBool
	{
		[SerializeField]
		private ReflectionPropertyBool m_Property = new ReflectionPropertyBool();

		public override string String => m_Property.ToString();

		public override void Set(bool value, Args args)
		{
			m_Property.Value = value;
		}

		public override bool Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
