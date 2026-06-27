using System.Collections.Generic;
using Restory.Data.Equipment;
using UnityEngine;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingPalettesContainer : MonoBehaviour
	{
		private readonly List<PaintingPaletteInfo> containedPalettes = new List<PaintingPaletteInfo>();

		public IReadOnlyList<PaintingPaletteInfo> ContainedPalettes => containedPalettes;

		public void AddPalette(PaintingPaletteInfo palette)
		{
			containedPalettes.Add(palette);
		}

		public void Clear()
		{
			containedPalettes.Clear();
		}
	}
}
