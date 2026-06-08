using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace LogoMaker
{
	public class DynamicFont : MonoBehaviour
	{
		public TextAsset FontDefinitions;

		public FontList FontProperties;

		public List<TMP_FontAsset> Fonts;

		public bool MultifontMode;

		public TMP_FontAsset GetFont => Fonts[UnityEngine.Random.Range(0, Fonts.Count - 1)];

		public TMP_FontAsset Playful => ByProperty((FontProperties f) => f.personality < 0.45f);

		public TMP_FontAsset Serious => ByProperty((FontProperties f) => f.personality > 0.55f);

		public TMP_FontAsset ByProperty(Func<FontProperties, bool> condition)
		{
			List<FontProperties> list = FontProperties.Fonts.Where(condition).ToList();
			return ByName(list[UnityEngine.Random.Range(0, list.Count - 1)].name);
		}

		public TMP_FontAsset ByName(string name)
		{
			return Fonts.First((TMP_FontAsset f) => f.sourceFontFile.name == name);
		}

		private void LoadProperties()
		{
			FontProperties = JsonUtility.FromJson<FontList>(FontDefinitions.text);
		}

		private void Run()
		{
			TextMeshPro[] componentsInChildren = GetComponentsInChildren<TextMeshPro>();
			TextMeshPro[] array;
			if (MultifontMode)
			{
				array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].font = Fonts[UnityEngine.Random.Range(0, Fonts.Count - 1)];
				}
				return;
			}
			TMP_FontAsset font = Fonts[UnityEngine.Random.Range(0, Fonts.Count - 1)];
			array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].font = font;
			}
		}
	}
}
