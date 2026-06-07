using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Local Name Variable")]
	[Category("Variables/Local Name Variable")]
	[Image(typeof(IconNameVariable), ColorTheme.Type.Purple)]
	[Description("Returns the Sprite value of a Local Name Variable")]
	public class GetSpriteLocalName : PropertyTypeGetSprite
	{
		[SerializeField]
		protected FieldGetLocalName m_Variable = new FieldGetLocalName(ValueSprite.TYPE_ID);

		public override string String => m_Variable.ToString();

		public override Sprite Get(Args args)
		{
			return m_Variable.Get<Sprite>(args);
		}
	}
}
