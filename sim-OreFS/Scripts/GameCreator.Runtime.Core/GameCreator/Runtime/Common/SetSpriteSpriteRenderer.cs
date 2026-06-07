using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Sprite Renderer")]
	[Category("Game Objects/Sprite Renderer")]
	[Image(typeof(IconSprite), ColorTheme.Type.Purple, typeof(OverlayDot))]
	[Description("The Sprite value attached to the Sprite Renderer")]
	public class SetSpriteSpriteRenderer : PropertyTypeSetSprite
	{
		[SerializeField]
		private PropertyGetGameObject m_SpriteRenderer = GetGameObjectInstance.Create();

		public override string String => $"{m_SpriteRenderer} Sprite";

		public override void Set(Sprite value, Args args)
		{
			SpriteRenderer spriteRenderer = m_SpriteRenderer.Get<SpriteRenderer>(args);
			if (!(spriteRenderer == null))
			{
				spriteRenderer.sprite = value;
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
	}
}
