using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Sprite Renderer")]
	[Category("Game Objects/Sprite Renderer")]
	[Image(typeof(IconSprite), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("A reference to a Sprite Renderer's Sprite value")]
	[Keywords(new string[] { "Sprite", "2D" })]
	public class GetSpriteSpriteRenderer : PropertyTypeGetSprite
	{
		[SerializeField]
		private PropertyGetGameObject m_SpriteRenderer = GetGameObjectInstance.Create();

		public override string String => m_SpriteRenderer.ToString();

		public override Sprite EditorValue
		{
			get
			{
				GameObject editorValue = m_SpriteRenderer.EditorValue;
				if (editorValue == null)
				{
					return null;
				}
				SpriteRenderer component = editorValue.GetComponent<SpriteRenderer>();
				if (!(component != null))
				{
					return null;
				}
				return component.sprite;
			}
		}

		public override Sprite Get(Args args)
		{
			SpriteRenderer spriteRenderer = m_SpriteRenderer.Get<SpriteRenderer>(args);
			if (!(spriteRenderer != null))
			{
				return null;
			}
			return spriteRenderer.sprite;
		}

		public override Sprite Get(GameObject gameObject)
		{
			SpriteRenderer spriteRenderer = m_SpriteRenderer.Get<SpriteRenderer>(gameObject);
			if (!(spriteRenderer != null))
			{
				return null;
			}
			return spriteRenderer.sprite;
		}

		public static PropertyGetSprite Create()
		{
			return new PropertyGetSprite(new GetSpriteSpriteRenderer());
		}
	}
}
