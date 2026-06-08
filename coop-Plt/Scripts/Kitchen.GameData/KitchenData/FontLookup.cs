using System.Collections.Generic;
using Sirenix.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Font Lookup", menuName = "Kitchen/Font Lookup")]
	public class FontLookup : KitchenObject
	{
		[FormerlySerializedAs("BaseFont")]
		public List<TMP_FontAsset> BaseFonts = new List<TMP_FontAsset>();

		public Dictionary<Locale, TMP_FontAsset> Substitutions = new Dictionary<Locale, TMP_FontAsset>();

		private HashSet<TMP_FontAsset> TempAssets = new HashSet<TMP_FontAsset>();

		public void SetLocale(Locale l)
		{
			ClearCache();
			foreach (TMP_FontAsset baseFont in BaseFonts)
			{
				if (baseFont != null)
				{
					baseFont.fallbackFontAssetTable.Clear();
					baseFont.fallbackFontAssetTable.Add(GetFont(l, baseFont));
				}
			}
		}

		private void ValidateFont(TMP_FontAsset font)
		{
			if (!font.glyphTable.IsNullOrEmpty())
			{
				Debug.LogWarning($"Base font {font} has glyphs - it should contain no glyphs so that it uses fallbacks correctly", font);
			}
			if (font.atlasPopulationMode == AtlasPopulationMode.Dynamic)
			{
				Debug.LogWarning($"Base font {font} is Dynamic - it should be static to prevent it adding glyphs", font);
			}
		}

		private void ClearCache()
		{
			TempAssets.Clear();
		}

		private TMP_FontAsset GetFont(Locale l, TMP_FontAsset base_font)
		{
			if (!Substitutions.TryGetValue(l, out var value))
			{
				return Substitutions[Locale.Default];
			}
			return value;
		}
	}
}
