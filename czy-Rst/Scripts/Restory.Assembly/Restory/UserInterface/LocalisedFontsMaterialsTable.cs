using System;
using TMPro;
using UnityEngine;

namespace Restory.UserInterface
{
	[CreateAssetMenu(menuName = "Restory/UserInterface/FontsLocalisation/LocalisedFontsMaterialsTable", fileName = "LocalisedFontsMaterialsTable")]
	public class LocalisedFontsMaterialsTable : ScriptableObject
	{
		[Serializable]
		private class FontToMaterial
		{
			public TMP_FontAsset Font;

			public Material Material;
		}

		[Serializable]
		private class Entry
		{
			public string StyleName;

			public FontToMaterial[] FontsToMaterials = new FontToMaterial[0];
		}

		[SerializeField]
		private Entry[] entries = new Entry[0];

		public bool TryGetMaterialByNewFontAndInitialSettings(TMP_FontAsset initialFont, Material initialMaterial, TMP_FontAsset targetFont, out Material targetMaterial)
		{
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry == null || entry.FontsToMaterials.Length == 0)
				{
					continue;
				}
				FontToMaterial[] fontsToMaterials = entry.FontsToMaterials;
				foreach (FontToMaterial fontToMaterial in fontsToMaterials)
				{
					if (!(fontToMaterial.Font == initialFont) || !(fontToMaterial.Material == initialMaterial))
					{
						continue;
					}
					FontToMaterial[] fontsToMaterials2 = entry.FontsToMaterials;
					foreach (FontToMaterial fontToMaterial2 in fontsToMaterials2)
					{
						if (fontToMaterial2.Font == targetFont)
						{
							targetMaterial = fontToMaterial2.Material;
							return targetMaterial;
						}
					}
					break;
				}
			}
			targetMaterial = null;
			return false;
		}
	}
}
