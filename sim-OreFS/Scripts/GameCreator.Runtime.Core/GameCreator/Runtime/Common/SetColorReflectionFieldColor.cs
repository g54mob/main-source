using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Color")]
	[Category("Reflection/Field Color")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Color' value of a public or private field of a component")]
	public class SetColorReflectionFieldColor : PropertyTypeSetColor
	{
		[SerializeField]
		private ReflectionFieldColor m_Field = new ReflectionFieldColor();

		public override string String => m_Field.ToString();

		public override void Set(Color value, Args args)
		{
			m_Field.Value = value;
		}

		public override Color Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
