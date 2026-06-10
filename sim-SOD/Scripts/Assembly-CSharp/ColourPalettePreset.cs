using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "colourpalette_data", menuName = "Database/Colour Palette")]
public class ColourPalettePreset : SoCustomComparison
{
	[Serializable]
	public class MaterialSettings
	{
		public Color colour;

		[Range(1f, 5f)]
		public int weighting;
	}

	[Header("Colours")]
	[ReorderableList]
	public List<MaterialSettings> colours;

	[Header("Suited Personality")]
	public HEXACO hexaco;
}
