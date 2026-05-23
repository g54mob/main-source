using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using NaughtyAttributes;
using UnityEngine;

namespace Utils
{
	[CreateAssetMenu(menuName = "Variables/ColorLibrary", fileName = "ColorLibrary", order = 0)]
	public class ColorLibrarySO : ScriptableObject
	{
		[SerializeField]
		private SerializedDictionary<Color, string> _colors;

		[SerializeField]
		[ReadOnly]
		private SerializedDictionary<string, string> _hexCodeColors;

		public SerializedDictionary<Color, string> ColorDictionary => _colors;

		public SerializedDictionary<string, string> HexCodeColorDictionary => _hexCodeColors;

		private void OnValidate()
		{
			_hexCodeColors.Clear();
			foreach (KeyValuePair<Color, string> color in _colors)
			{
				_hexCodeColors.Add(ColorUtility.ToHtmlStringRGB(color.Key), color.Value);
			}
		}

		public List<Color> GetColors()
		{
			return _colors.Keys.ToList();
		}

		public string GetNameOfColor(Color color)
		{
			string key = ColorUtility.ToHtmlStringRGB(color);
			if (!_hexCodeColors.ContainsKey(key))
			{
				return null;
			}
			return _hexCodeColors[key];
		}
	}
}
