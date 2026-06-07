using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Color")]
	[Category("Reflection/Property Color")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Color' value of a property of a component")]
	public class SetColorReflectionPropertyColor : PropertyTypeSetColor
	{
		[SerializeField]
		private ReflectionPropertyColor m_Property = new ReflectionPropertyColor();

		public override string String => m_Property.ToString();

		public override void Set(Color value, Args args)
		{
			m_Property.Value = value;
		}

		public override Color Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
