using System.Collections.Generic;
using Timberborn.AssetSystem;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

namespace Timberborn.Localization
{
	internal class PanelTextSettingsUpdater
	{
		private static readonly string PanelTextSettingsPath = "UI/Fonts/PanelTextSettings";

		private static readonly string StaticKeyword = " - Static";

		private static readonly string DynamicKeyword = " - Dynamic";

		private static readonly string MediumName = "NotoSansDisplay-Medium SDF";

		private static readonly string RegularName = "NotoSans-Regular SDF";

		private static readonly string SymbolsName = "NotoSansSymbols2-Regular";

		private static readonly string JapaneseName = "NotoSansJP-Regular SDF";

		private static readonly string KoreanName = "NotoSansKR-Regular SDF";

		private static readonly string SimplifiedChineseName = "NotoSansSC-Regular SDF";

		private static readonly string TraditionalChineseName = "NotoSansTC-Regular SDF";

		private static readonly string ThaiName = "NotoSansTH-Medium SDF";

		private readonly IAssetLoader _assetLoader;

		private PanelTextSettings _panelTextSettings;

		public PanelTextSettingsUpdater(IAssetLoader assetLoader)
		{
			_assetLoader = assetLoader;
		}

		public void Update(string languageCode)
		{
			List<FontAsset> fallbackFontAssets = _assetLoader.Load<PanelTextSettings>(PanelTextSettingsPath).fallbackFontAssets;
			fallbackFontAssets.Clear();
			if (languageCode == LocalizationCodes.Japanese)
			{
				AddFontsInJapaneseOrder(fallbackFontAssets);
			}
			else if (languageCode == LocalizationCodes.Korean)
			{
				AddFontsInKoreanOrder(fallbackFontAssets);
			}
			else if (languageCode == LocalizationCodes.SimplifiedChinese)
			{
				AddFontsInSimplifiedChineseOrder(fallbackFontAssets);
			}
			else if (languageCode == LocalizationCodes.TraditionalChinese)
			{
				AddFontsInTraditionalChineseOrder(fallbackFontAssets);
			}
			else if (languageCode == LocalizationCodes.Thai)
			{
				AddFontsInThaiOrder(fallbackFontAssets);
			}
			else
			{
				AddFontsInDefaultOrder(fallbackFontAssets);
			}
		}

		private void AddFontsInDefaultOrder(List<FontAsset> fallbackFontAssets)
		{
			AddFontsInJapaneseOrder(fallbackFontAssets);
		}

		private void AddFontsInJapaneseOrder(List<FontAsset> fallbackFontAssets)
		{
			AddDefaultStaticFonts(fallbackFontAssets);
			AddFontsInJapaneseOrder(fallbackFontAssets, StaticKeyword);
			AddDefaultDynamicFonts(fallbackFontAssets);
			AddFontsInJapaneseOrder(fallbackFontAssets, DynamicKeyword);
		}

		private void AddFontsInKoreanOrder(List<FontAsset> fallbackFontAssets)
		{
			AddDefaultStaticFonts(fallbackFontAssets);
			AddFontsInKoreanOrder(fallbackFontAssets, StaticKeyword);
			AddDefaultDynamicFonts(fallbackFontAssets);
			AddFontsInKoreanOrder(fallbackFontAssets, DynamicKeyword);
		}

		private void AddFontsInSimplifiedChineseOrder(List<FontAsset> fallbackFontAssets)
		{
			AddDefaultStaticFonts(fallbackFontAssets);
			AddFontsInSimplifiedChineseOrder(fallbackFontAssets, StaticKeyword);
			AddDefaultDynamicFonts(fallbackFontAssets);
			AddFontsInSimplifiedChineseOrder(fallbackFontAssets, DynamicKeyword);
		}

		private void AddFontsInTraditionalChineseOrder(List<FontAsset> fallbackFontAssets)
		{
			AddDefaultStaticFonts(fallbackFontAssets);
			AddFontsInTraditionalChineseOrder(fallbackFontAssets, StaticKeyword);
			AddDefaultDynamicFonts(fallbackFontAssets);
			AddFontsInTraditionalChineseOrder(fallbackFontAssets, DynamicKeyword);
		}

		private void AddFontsInThaiOrder(List<FontAsset> fallbackFontAssets)
		{
			AddDefaultStaticFonts(fallbackFontAssets);
			AddFontsInThaiOrder(fallbackFontAssets, StaticKeyword);
			AddDefaultDynamicFonts(fallbackFontAssets);
			AddFontsInThaiOrder(fallbackFontAssets, DynamicKeyword);
		}

		private void AddDefaultStaticFonts(List<FontAsset> fallbackFontAssets)
		{
			Add(fallbackFontAssets, RegularName, StaticKeyword);
			Add(fallbackFontAssets, SymbolsName, StaticKeyword);
		}

		private void AddDefaultDynamicFonts(List<FontAsset> fallbackFontAssets)
		{
			Add(fallbackFontAssets, MediumName, DynamicKeyword);
			Add(fallbackFontAssets, RegularName, DynamicKeyword);
			Add(fallbackFontAssets, SymbolsName, DynamicKeyword);
		}

		private void AddFontsInJapaneseOrder(List<FontAsset> fallbackFontAssets, string keyword)
		{
			Add(fallbackFontAssets, JapaneseName, keyword);
			Add(fallbackFontAssets, KoreanName, keyword);
			Add(fallbackFontAssets, SimplifiedChineseName, keyword);
			Add(fallbackFontAssets, TraditionalChineseName, keyword);
			Add(fallbackFontAssets, ThaiName, keyword);
		}

		private void AddFontsInKoreanOrder(List<FontAsset> fallbackFontAssets, string keyword)
		{
			Add(fallbackFontAssets, KoreanName, keyword);
			Add(fallbackFontAssets, JapaneseName, keyword);
			Add(fallbackFontAssets, SimplifiedChineseName, keyword);
			Add(fallbackFontAssets, TraditionalChineseName, keyword);
			Add(fallbackFontAssets, ThaiName, keyword);
		}

		private void AddFontsInSimplifiedChineseOrder(List<FontAsset> fallbackFontAssets, string keyword)
		{
			Add(fallbackFontAssets, SimplifiedChineseName, keyword);
			Add(fallbackFontAssets, TraditionalChineseName, keyword);
			Add(fallbackFontAssets, JapaneseName, keyword);
			Add(fallbackFontAssets, KoreanName, keyword);
			Add(fallbackFontAssets, ThaiName, keyword);
		}

		private void AddFontsInTraditionalChineseOrder(List<FontAsset> fallbackFontAssets, string keyword)
		{
			Add(fallbackFontAssets, TraditionalChineseName, keyword);
			Add(fallbackFontAssets, SimplifiedChineseName, keyword);
			Add(fallbackFontAssets, JapaneseName, keyword);
			Add(fallbackFontAssets, KoreanName, keyword);
			Add(fallbackFontAssets, ThaiName, keyword);
		}

		private void AddFontsInThaiOrder(List<FontAsset> fallbackFontAssets, string keyword)
		{
			Add(fallbackFontAssets, ThaiName, keyword);
			Add(fallbackFontAssets, JapaneseName, keyword);
			Add(fallbackFontAssets, KoreanName, keyword);
			Add(fallbackFontAssets, SimplifiedChineseName, keyword);
			Add(fallbackFontAssets, TraditionalChineseName, keyword);
		}

		private void Add(List<FontAsset> fallbackFontAssets, string name, string type)
		{
			fallbackFontAssets.Add(_assetLoader.Load<FontAsset>("UI/Fonts/" + name + type));
		}
	}
}
