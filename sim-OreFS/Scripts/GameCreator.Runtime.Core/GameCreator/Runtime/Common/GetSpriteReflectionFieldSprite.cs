using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Field Sprite")]
	[Category("Reflection/Field Sprite")]
	[Image(typeof(IconComponent), ColorTheme.Type.Yellow)]
	[Description("A 'Sprite' value of a public or private field of a component")]
	[Keywords(new string[] { "Component", "Script", "Property", "Member", "Variable", "Value" })]
	public class GetSpriteReflectionFieldSprite : PropertyTypeGetSprite
	{
		[SerializeField]
		private ReflectionFieldSprite m_Field = new ReflectionFieldSprite();

		public override string String => m_Field.ToString();

		public override Sprite Get(Args args)
		{
			return m_Field.Value;
		}
	}
}
