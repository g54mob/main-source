using System;
using System.Collections;
using ModIO.Util;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class Glyphs : SelfInstancingMonoSingleton<Glyphs>
	{
		private ColorScheme colorScheme;

		public Color glyphColorFallback;

		public Sprite fallbackSprite;

		public Color fallbackColor = Color.white;

		private bool hasStarted;

		public GlyphPlatforms PlatformType { get; internal set; }

		private void Start()
		{
			colorScheme = SharedUi.colorScheme;
			if (PlatformType == GlyphPlatforms.PC)
			{
				ChangeGlyphs(SharedUi.settings.GlyphPlatform);
			}
		}

		public void SetColor(ColorSetterType colorSetter, Action<Color> setter)
		{
			StartCoroutine(InternalSetColor(colorSetter, setter));
		}

		private IEnumerator InternalSetColor(ColorSetterType colorSetter, Action<Color> setter)
		{
			while (!hasStarted)
			{
				yield return new WaitForEndOfFrame();
			}
			setter(GetColor(colorSetter));
		}

		public Color GetColor(ColorSetterType colorSetter)
		{
			Color schemeColor = colorScheme.GetSchemeColor(colorSetter);
			if (!(schemeColor == default(Color)))
			{
				return schemeColor;
			}
			return fallbackColor;
		}

		public void ChangeGlyphs(GlyphPlatforms platform)
		{
			PlatformType = platform;
			SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Publish(new MessageGlyphUpdate());
		}

		[ExposeMethodInEditor]
		public void ChangeToPc()
		{
			ChangeGlyphs(GlyphPlatforms.PC);
		}

		[ExposeMethodInEditor]
		public void ChangeToXbox()
		{
			ChangeGlyphs(GlyphPlatforms.XBOX);
		}

		[ExposeMethodInEditor]
		public void ChangeToNintendoSwitch()
		{
			ChangeGlyphs(GlyphPlatforms.NINTENDO_SWITCH);
		}

		[ExposeMethodInEditor]
		public void ChangeToPs4()
		{
			ChangeGlyphs(GlyphPlatforms.PLAYSTATION_4);
		}

		[ExposeMethodInEditor]
		public void ChangeToPs5()
		{
			ChangeGlyphs(GlyphPlatforms.PLAYSTATION_5);
		}
	}
}
