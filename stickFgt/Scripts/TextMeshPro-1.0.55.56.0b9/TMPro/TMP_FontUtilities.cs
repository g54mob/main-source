using System.Collections.Generic;

namespace TMPro
{
	public static class TMP_FontUtilities
	{
		public static TMP_FontAsset SearchForGlyph(TMP_FontAsset font, int character, out TMP_Glyph glyph)
		{
			glyph = null;
			if (font == null)
			{
				return null;
			}
			if (font.characterDictionary.TryGetValue(character, out glyph))
			{
				return font;
			}
			if (font.fallbackFontAssets != null && font.fallbackFontAssets.Count > 0)
			{
				for (int i = 0; i < font.fallbackFontAssets.Count; i++)
				{
					if (glyph != null)
					{
						break;
					}
					if (!(font.fallbackFontAssets[i] == null) && font.fallbackFontAssets[i].GetInstanceID() != font.GetInstanceID())
					{
						TMP_FontAsset tMP_FontAsset = SearchForGlyph(font.fallbackFontAssets[i], character, out glyph);
						if (tMP_FontAsset != null)
						{
							return tMP_FontAsset;
						}
					}
				}
			}
			return null;
		}

		public static TMP_FontAsset SearchForGlyph(List<TMP_FontAsset> fonts, int character, out TMP_Glyph glyph)
		{
			glyph = null;
			if (fonts != null && fonts.Count > 0)
			{
				for (int i = 0; i < fonts.Count; i++)
				{
					TMP_FontAsset tMP_FontAsset = SearchForGlyph(fonts[i], character, out glyph);
					if (tMP_FontAsset != null)
					{
						return tMP_FontAsset;
					}
				}
			}
			return null;
		}
	}
}
