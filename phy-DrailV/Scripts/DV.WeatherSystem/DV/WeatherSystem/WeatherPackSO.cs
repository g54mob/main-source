using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DV.WeatherSystem
{
	[CreateAssetMenu(menuName = "DV/Weather Pack")]
	public class WeatherPackSO : ScriptableObject
	{
		public Weather24hPresetSO[] presets;

		public int GetNeighborPresetIndex(int currentIndex, bool next)
		{
			int num = currentIndex + (next ? 1 : (-1));
			if (num < 0)
			{
				return presets.Length - 1;
			}
			if (num >= presets.Length)
			{
				return 0;
			}
			return num;
		}

		public Weather24hPresetSO GetNeighborPreset(int currentIndex, bool next)
		{
			return presets[GetNeighborPresetIndex(currentIndex, next)];
		}

		public void Validate()
		{
			new HashSet<Weather24hPresetSO>();
			Weather24hPresetSO[] array = presets;
			foreach (Weather24hPresetSO weather24hPresetSO in array)
			{
				if (!(weather24hPresetSO == null))
				{
					weather24hPresetSO.ValidateSnapshots();
					if (weather24hPresetSO.highZoneVariant != null && presets.Contains(weather24hPresetSO.highZoneVariant))
					{
						Debug.LogError("Preset " + weather24hPresetSO.name + " has " + weather24hPresetSO.highZoneVariant.name + " as high-zone variant, but the latter also appears stand-alone in presets list in this pack, please remove it from there");
					}
				}
			}
		}
	}
}
