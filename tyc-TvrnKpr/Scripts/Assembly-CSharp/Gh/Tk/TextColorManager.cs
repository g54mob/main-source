using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[CreateAssetMenu(fileName = "TextColorManager", menuName = "Greenheart Custom/Misc/Create TextColorManager")]
	public class TextColorManager : ScriptableObject
	{
		[Serializable]
		public class ColorEntry
		{
			public string Id;

			public Color Color;

			[NonSerialized]
			public string HexColor;

			[NonSerialized]
			public string HexWithAlpha;

			public static ColorEntry CreateEntry(string id, Color color)
			{
				return null;
			}
		}

		public static Dictionary<TextStyleId, TextColorManager> AllStyles;

		public TextStyleId _textStyleId;

		[SerializeField]
		private List<ColorEntry> _presetColors;

		private ColorEntry _invalidColor;

		private Dictionary<string, ColorEntry> _colors;

		public static TextColorManager DefaultStyle => null;

		public static TextColorManager GetStyle(TextStyleId id)
		{
			return null;
		}

		public void RegisterStyle()
		{
		}

		private void OnDestroy()
		{
		}

		private void AddPresetColor(string id, Color color)
		{
		}

		private void AddPresetColor(string id, string hexColor)
		{
		}

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}

		public void EnsureCorrectSettings()
		{
		}

		public void AddColor(string id, Color color)
		{
		}

		public void AddColor(string id, string hexColor)
		{
		}

		private bool HasColorEntry(string id)
		{
			return false;
		}

		private ColorEntry GetColorEntry(string id)
		{
			return null;
		}

		public static ColorEntry GetColorEntry(string id, TextStyleId styleId)
		{
			return null;
		}
	}
}
