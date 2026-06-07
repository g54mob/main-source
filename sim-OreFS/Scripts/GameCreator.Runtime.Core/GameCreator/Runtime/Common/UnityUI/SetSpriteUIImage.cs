using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.Common.UnityUI
{
	[Serializable]
	[Title("Image")]
	[Category("UI/Image")]
	[Description("Sets the Image's sprite value")]
	[Image(typeof(IconUIImage), ColorTheme.Type.TextLight)]
	public class SetSpriteUIImage : PropertyTypeSetSprite
	{
		[SerializeField]
		protected bool m_OverrideSprite = true;

		[SerializeField]
		private PropertyGetGameObject m_Image = GetGameObjectInstance.Create();

		public static PropertySetSprite Create => new PropertySetSprite(new SetSpriteUIImage());

		public override string String => m_Image.ToString();

		public override void Set(Sprite value, Args args)
		{
			GameObject gameObject = m_Image.Get(args);
			if (gameObject == null)
			{
				return;
			}
			Image image = gameObject.Get<Image>();
			if (!(image == null))
			{
				if (m_OverrideSprite)
				{
					image.overrideSprite = value;
				}
				else
				{
					image.sprite = value;
				}
			}
		}

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
	}
}
