using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Texture")]
	[Category("Reflection/Field Texture")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Texture' value of a public or private field of a component")]
	public class SetTextureReflectionFieldTexture : PropertyTypeSetTexture
	{
		[SerializeField]
		private ReflectionFieldTexture m_Field = new ReflectionFieldTexture();

		public override string String => m_Field.ToString();

		public override void Set(Texture value, Args args)
		{
			m_Field.Value = value;
		}

		public override Texture Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
