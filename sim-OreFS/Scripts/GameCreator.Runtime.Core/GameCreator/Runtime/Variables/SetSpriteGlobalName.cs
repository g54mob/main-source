using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global Name Variable")]
	[Category("Variables/Global Name Variable")]
	[Description("Sets the Sprite value of a Global Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple, typeof(OverlayDot))]
	public class SetSpriteGlobalName : PropertyTypeSetSprite
	{
		[SerializeField]
		protected FieldSetGlobalName m_Variable = new FieldSetGlobalName(ValueSprite.TYPE_ID);

		public static PropertySetSprite Create => new PropertySetSprite(new SetSpriteGlobalName());

		public override string String => m_Variable.ToString();

		public override void Set(Sprite value, Args args)
		{
			m_Variable.Set(value, args);
		}

		public override Sprite Get(Args args)
		{
			return m_Variable.Get(args) as Sprite;
		}
	}
}
