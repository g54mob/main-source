using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Integer")]
	[Category("Reflection/Field Integer")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'integer' value of a public or private field of a component")]
	public class SetNumberReflectionFieldInteger : PropertyTypeSetNumber
	{
		[SerializeField]
		private ReflectionFieldInteger m_Field = new ReflectionFieldInteger();

		public override string String => m_Field.ToString();

		public override void Set(double value, Args args)
		{
			m_Field.Value = (int)value;
		}

		public override double Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
