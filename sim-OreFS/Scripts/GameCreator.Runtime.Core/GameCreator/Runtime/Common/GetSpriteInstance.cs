using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Sprite")]
	[Category("Sprite")]
	[Image(typeof(IconSprite), ColorTheme.Type.Purple)]
	[Description("A reference to a Sprite texture")]
	[Keywords(new string[] { "Sprite", "UI", "2D" })]
	[HideLabelsInEditor(true)]
	public class GetSpriteInstance : PropertyTypeGetSprite
	{
		[SerializeField]
		protected Sprite m_Sprite;

		public override string String => m_Sprite.ToString();

		public override Sprite EditorValue => m_Sprite;

		public override Sprite Get(Args args)
		{
			return m_Sprite;
		}

		public override Sprite Get(GameObject gameObject)
		{
			return m_Sprite;
		}

		public GetSpriteInstance()
		{
		}

		public GetSpriteInstance(Sprite sprite)
			: this()
		{
			m_Sprite = sprite;
		}

		public static PropertyGetSprite Create(Sprite value = null)
		{
			return new PropertyGetSprite(new GetSpriteInstance(value));
		}
	}
}
