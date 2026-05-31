using System;
using System.Collections.Generic;
using System.Reflection;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	[Constructor("Construct")]
	public class BBTPalette : CTSBehaviour
	{
		private static readonly Dictionary<StringKey<PaletteData>, Color> _colors = new Dictionary<StringKey<PaletteData>, Color>();

		[Header("Button Background")]
		[SerializeField]
		private PaletteData _buttonBackgroundNormalKey;

		[SerializeField]
		private PaletteData _buttonBackgroundSelectedKey;

		[SerializeField]
		private PaletteData _buttonBackgroundDisabledKey;

		[SerializeField]
		private PaletteData _buttonBackgroundHighlightedKey;

		[Header("Button Content")]
		[SerializeField]
		private PaletteData _buttonContentNormalKey;

		[SerializeField]
		private PaletteData _buttonContentSelectedKey;

		[SerializeField]
		private PaletteData _buttonContentDisabledKey;

		[SerializeField]
		private PaletteData _buttonContentHighlightedKey;

		[Header("Emotes")]
		[SerializeField]
		private PaletteData _emoteRed;

		[SerializeField]
		private PaletteData _emoteWhite;

		[SerializeField]
		private PaletteData _emoteBlack;

		public static StringKey<PaletteData> ButtonBackgroundNormalKey { get; private set; }

		public static StringKey<PaletteData> ButtonBackgroundSelectedKey { get; private set; }

		public static StringKey<PaletteData> ButtonBackgroundDisabledKey { get; private set; }

		public static StringKey<PaletteData> ButtonBackgroundHighlightedKey { get; private set; }

		public static StringKey<PaletteData> ButtonContentNormalKey { get; private set; }

		public static StringKey<PaletteData> ButtonContentSelectedKey { get; private set; }

		public static StringKey<PaletteData> ButtonContentDisabledKey { get; private set; }

		public static StringKey<PaletteData> ButtonContentHighlightedKey { get; private set; }

		public static StringKey<PaletteData> EmoteRed { get; private set; }

		public static StringKey<PaletteData> EmoteWhite { get; private set; }

		public static StringKey<PaletteData> EmoteBlack { get; private set; }

		public static Color GetColor(StringKey<PaletteData> key)
		{
			if (_colors.TryGetValue(key, out var value))
			{
				return value;
			}
			return Color.black;
		}

		private void Construct()
		{
			_colors.Clear();
			Type typeFromHandle = typeof(BBTPalette);
			Type typeFromHandle2 = typeof(PaletteData);
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!(fieldInfo.FieldType != typeFromHandle2))
				{
					PaletteData paletteData = (PaletteData)fieldInfo.GetValue(this);
					typeFromHandle.GetProperty(ToPascalCase(fieldInfo.Name), BindingFlags.Static | BindingFlags.Public)?.SetValue(this, new StringKey<PaletteData>(paletteData));
					if ((bool)paletteData)
					{
						_colors.TryAdd(paletteData, paletteData.GetColor());
					}
				}
			}
		}

		public static string ToPascalCase(string text)
		{
			text = text.TrimStart('_');
			string text2 = char.ToUpper(text[0]).ToString();
			string text3 = text;
			text = text2 + text3.Substring(1, text3.Length - 1);
			return text;
		}
	}
}
