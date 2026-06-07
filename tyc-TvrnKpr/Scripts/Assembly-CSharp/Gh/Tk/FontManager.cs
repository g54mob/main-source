using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class FontManager : SingletonMonoBehaviour<FontManager>
	{
		private readonly Dictionary<string, string> _languagesWithFontPrefixes;

		public List<string> availableCustomFontNames;

		public List<string> availableCustomFontMaterialNames;

		private readonly Dictionary<string, TMP_FontAsset> _loadedFonts;

		private readonly Dictionary<string, Material> _loadedMaterials;

		private readonly Dictionary<string, List<FontData>> _fontData;

		public override void Awake()
		{
		}

		private void OnAfterLanguageChanged(object sender, ValueChangedEventArgs<string> e)
		{
		}

		private void OnBeforeLanguageChanged(object sender, ValueChangedEventArgs<string> e)
		{
		}

		private void UpdateFontsForLanguage(string languageCode)
		{
		}

		private void AddFontsForLanguage(string fontPrefix)
		{
		}

		public TMP_FontAsset GetFont(string searchName)
		{
			return null;
		}

		public int RegisterFont(TMP_FontAsset fontAsset, Material material)
		{
			return 0;
		}

		private int GetIndex(TMP_FontAsset fontAsset, Material material)
		{
			return 0;
		}

		public FontData GetFontData(int index, string language)
		{
			return null;
		}
	}
}
