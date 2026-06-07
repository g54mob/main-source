using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Float")]
	[Category("Reflection/Property Float")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'float' value of a property of a component")]
	public class SetNumberReflectionPropertyFloat : PropertyTypeSetNumber
	{
		[SerializeField]
		private ReflectionPropertyFloat m_Property = new ReflectionPropertyFloat();

		public override string String => m_Property.ToString();

		public override void Set(double value, Args args)
		{
			m_Property.Value = (float)value;
		}

		public override double Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
