using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Double")]
	[Category("Reflection/Property Double")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'double' value of a property of a component")]
	public class SetNumberReflectionPropertyDouble : PropertyTypeSetNumber
	{
		[SerializeField]
		private ReflectionPropertyDouble m_Property = new ReflectionPropertyDouble();

		public override string String => m_Property.ToString();

		public override void Set(double value, Args args)
		{
			m_Property.Value = value;
		}

		public override double Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
