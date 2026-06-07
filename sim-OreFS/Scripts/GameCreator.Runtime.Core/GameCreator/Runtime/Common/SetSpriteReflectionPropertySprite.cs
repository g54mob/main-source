using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Sprite")]
	[Category("Reflection/Property Sprite")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Sprite' value of a property of a component")]
	public class SetSpriteReflectionPropertySprite : PropertyTypeSetSprite
	{
		[SerializeField]
		private ReflectionPropertySprite m_Property = new ReflectionPropertySprite();

		public override string String => m_Property.ToString();

		public override void Set(Sprite value, Args args)
		{
			m_Property.Value = value;
		}

		public override Sprite Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
