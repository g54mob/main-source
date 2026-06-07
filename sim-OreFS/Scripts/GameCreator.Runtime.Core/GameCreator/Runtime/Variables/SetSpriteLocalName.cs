using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Description("Sets the Sprite value of a Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	public class SetSpriteLocalName : PropertyTypeSetSprite
	{
		[SerializeField]
		protected FieldSetLocalName m_Variable = new FieldSetLocalName(ValueSprite.TYPE_ID);

		public static PropertySetSprite Create => new PropertySetSprite(new SetSpriteLocalName());

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
