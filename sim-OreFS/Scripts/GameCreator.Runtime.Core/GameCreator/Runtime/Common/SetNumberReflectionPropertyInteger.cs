using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Integer")]
	[Category("Reflection/Property Integer")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'integer' value of a property of a component")]
	public class SetNumberReflectionPropertyInteger : PropertyTypeSetNumber
	{
		[SerializeField]
		private ReflectionPropertyInteger m_Property = new ReflectionPropertyInteger();

		public override string String => m_Property.ToString();

		public override void Set(double value, Args args)
		{
			m_Property.Value = (int)value;
		}

		public override double Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
