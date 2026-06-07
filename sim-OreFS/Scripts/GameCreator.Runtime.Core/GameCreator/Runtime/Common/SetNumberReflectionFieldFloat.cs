using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Float")]
	[Category("Reflection/Field Float")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'float' value of a public or private field of a component")]
	public class SetNumberReflectionFieldFloat : PropertyTypeSetNumber
	{
		[SerializeField]
		private ReflectionFieldFloat m_Field = new ReflectionFieldFloat();

		public override string String => m_Field.ToString();

		public override void Set(double value, Args args)
		{
			m_Field.Value = (float)value;
		}

		public override double Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
