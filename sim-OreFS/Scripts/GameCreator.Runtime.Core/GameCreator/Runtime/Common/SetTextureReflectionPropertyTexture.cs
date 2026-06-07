using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Texture")]
	[Category("Reflection/Property Texture")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Texture' value of a property of a component")]
	public class SetTextureReflectionPropertyTexture : PropertyTypeSetTexture
	{
		[SerializeField]
		private ReflectionPropertyTexture m_Property = new ReflectionPropertyTexture();

		public override string String => m_Property.ToString();

		public override void Set(Texture value, Args args)
		{
			m_Property.Value = value;
		}

		public override Texture Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
