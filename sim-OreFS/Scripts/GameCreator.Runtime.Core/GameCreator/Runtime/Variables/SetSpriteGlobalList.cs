using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Global List Variable")]
	[Category("Variables/Global List Variable")]
	[Description("Sets the Sprite value of a Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	public class SetSpriteGlobalList : PropertyTypeSetSprite
	{
		[SerializeField]
		protected FieldSetGlobalList m_Variable = new FieldSetGlobalList(ValueSprite.TYPE_ID);

		public static PropertySetSprite Create => new PropertySetSprite(new SetSpriteGlobalList());

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
