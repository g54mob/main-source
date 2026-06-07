using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Property Sprite")]
	[Category("Reflection/Property Sprite")]
	[Image(typeof(IconComponent), ColorTheme.Type.Blue)]
	[Description("A 'Sprite' value of a property of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetSpriteReflectionPropertySprite : PropertyTypeGetSprite
	{
		[SerializeField]
		private ReflectionPropertySprite m_Property = new ReflectionPropertySprite();

		public override string String => m_Property.ToString();

		public override Sprite Get(Args args)
		{
			return m_Property.Value;
		}
	}
}
