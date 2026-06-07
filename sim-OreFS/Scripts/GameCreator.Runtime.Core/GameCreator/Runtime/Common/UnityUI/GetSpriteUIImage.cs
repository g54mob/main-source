using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Image")]
	[Category("UI/Image")]
	[Image(typeof(IconUIImage), ColorTheme.Type.TextLight)]
	[Description("The Sprite texture of an Image component")]
	public class GetSpriteUIImage : PropertyTypeGetSprite
	{
		[SerializeField]
		protected bool m_OverrideSprite = true;

		[SerializeField]
		protected PropertyGetGameObject m_Image = GetGameObjectInstance.Create();

		public override string String => m_Image.ToString();

		public override Sprite Get(Args args)
		{
			GameObject gameObject = m_Image.Get(args);
			if (gameObject == null)
			{
				return null;
			}
			Image image = gameObject.Get<Image>();
			if (image == null)
			{
				return null;
			}
			if (m_OverrideSprite)
			{
				return image.overrideSprite;
			}
			return image.sprite;
		}

		public GetSpriteUIImage()
		{
		}

		public GetSpriteUIImage(Image image)
			: this()
		{
			m_Image = GetGameObjectInstance.Create((image != null) ? image.gameObject : null);
		}

		public static PropertyGetSprite Create(Image image)
		{
			return new PropertyGetSprite(new GetSpriteUIImage(image));
		}
	}
}
