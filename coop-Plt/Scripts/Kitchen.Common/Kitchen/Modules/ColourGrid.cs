using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Modules
{
	public class ColourGrid : ModuleGrid
	{
		public const int ColourWheelSteps = 20;

		private static readonly List<Color> _Colours = new List<Color>();

		public static List<Color> Colours
		{
			get
			{
				if (_Colours == null || _Colours.Count == 0)
				{
					BuildColours();
				}
				return _Colours;
			}
		}

		public event Action<Color> OnColourSelect = delegate
		{
		};

		private static void BuildColours()
		{
			for (int i = 0; i < 20; i++)
			{
				_Colours.Add(Color.HSVToRGB(0.05f * (float)i, 0.75f, 0.75f));
			}
		}

		public ColourGrid(Transform parent)
		{
			Padding = 0.2f;
			RowLength = 10;
			ColumnLength = 5;
			XSpacing = 0.2f;
			YSpacing = 0.2f;
			ColourSelectorElement prefab = ModuleDirectory.Main.GetPrefab<ColourSelectorElement>();
			foreach (Color c in Colours)
			{
				ColourSelectorElement colourSelectorElement = UnityEngine.Object.Instantiate(prefab, parent, worldPositionStays: true);
				colourSelectorElement.SetColour(c);
				colourSelectorElement.OnActivate += delegate
				{
					this.OnColourSelect(c);
				};
				AddModule(colourSelectorElement);
			}
		}
	}
}
