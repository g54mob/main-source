using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class Glyphable : MonoBehaviour
	{
		public Image image;

		public GlyphSetting config;

		private SimpleMessageUnsubscribeToken subToken;

		public void OnValidate()
		{
			image = ((image == null) ? GetComponent<Image>() : image);
		}

		private void Start()
		{
			UpdateGlyphs();
			subToken = SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Subscribe<MessageGlyphUpdate>(delegate
			{
				UpdateGlyphs();
			});
		}

		public void UpdateGlyphs()
		{
			Sprite glyphFromDisplayType = GetGlyphFromDisplayType();
			if (glyphFromDisplayType != null)
			{
				base.gameObject.SetActive(value: true);
				image.sprite = glyphFromDisplayType;
				SelfInstancingMonoSingleton<Glyphs>.Instance.SetColor(config.color, delegate(Color x)
				{
					image.color = x;
				});
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private Sprite GetGlyphFromDisplayType()
		{
			switch (SelfInstancingMonoSingleton<Glyphs>.Instance.PlatformType)
			{
			case GlyphPlatforms.PC:
				return config.PC;
			case GlyphPlatforms.XBOX:
				return config.Xbox;
			case GlyphPlatforms.PLAYSTATION_4:
				return config.Playstation4;
			case GlyphPlatforms.PLAYSTATION_5:
				return config.Playstation5;
			case GlyphPlatforms.NINTENDO_SWITCH:
				return config.NintendoSwitch;
			default:
				Debug.LogWarning($"{base.gameObject.name} is missing configuration for {SelfInstancingMonoSingleton<Glyphs>.Instance.PlatformType}");
				return SelfInstancingMonoSingleton<Glyphs>.Instance.fallbackSprite;
			}
		}

		private void OnDestroy()
		{
			subToken?.Unsubscribe();
		}
	}
}
