using System;
using System.Collections.Generic;
using Restory.Data.Equipment;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.Equipment.DevicePaintingTools.DeviceAdditionalProperties
{
	[Serializable]
	public class DevicePaintedAdditionalProperty : InteractiveObjectAdditionalProperty
	{
		[SerializeField]
		private Dictionary<PaintingPaletteInfo, int> usedPalettesCount;

		public IReadOnlyDictionary<PaintingPaletteInfo, int> UsedPalettesCount => usedPalettesCount;

		public DevicePaintedAdditionalProperty(IReadOnlyDictionary<PaintingPaletteInfo, int> palettes)
		{
			usedPalettesCount = new Dictionary<PaintingPaletteInfo, int>(palettes);
		}

		public void UpdateAppliedPalettes(IReadOnlyDictionary<PaintingPaletteInfo, int> newAppliedPalettes)
		{
			usedPalettesCount.Clear();
			foreach (KeyValuePair<PaintingPaletteInfo, int> newAppliedPalette in newAppliedPalettes)
			{
				usedPalettesCount[newAppliedPalette.Key] = newAppliedPalette.Value;
			}
		}
	}
}
