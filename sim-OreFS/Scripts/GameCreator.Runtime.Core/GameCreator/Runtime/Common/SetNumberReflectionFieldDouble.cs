using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Double")]
	[Category("Reflection/Field Double")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'double' value of a public or private field of a component")]
	public class SetNumberReflectionFieldDouble : PropertyTypeSetNumber
	{
		[SerializeField]
		private ReflectionFieldDouble m_Field = new ReflectionFieldDouble();

		public override string String => m_Field.ToString();

		public override void Set(double value, Args args)
		{
			m_Field.Value = value;
		}

		public override double Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
