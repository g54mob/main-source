using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local List Variable")]
	[Category("Variables/Local List Variable")]
	[Description("Sets the Sprite value of a Local List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal)]
	public class SetSpriteLocalList : PropertyTypeSetSprite
	{
		[SerializeField]
		protected FieldSetLocalList m_Variable = new FieldSetLocalList(ValueSprite.TYPE_ID);

		public static PropertySetSprite Create => new PropertySetSprite(new SetSpriteLocalList());

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
