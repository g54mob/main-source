using System;
using System.Linq;
using Restory.Gameplay.GameSettings;
using UnityEngine;

namespace Restory.Data.GameConfigs
{
	[CreateAssetMenu(fileName = "GraphicsQualityPresetList", menuName = "Restory/Graphics Quality Presets", order = 0)]
	public class GraphicsQualityPresetList : ScriptableObject
	{
		[SerializeField]
		private PlatformDependentGraphicPresets[] presets = new PlatformDependentGraphicPresets[0];

		public IndexedQualityPattern[] GetSupportedQualityPatterns(GraphicsPlatformType platformType)
		{
			if (!presets.Any((PlatformDependentGraphicPresets x) => x.Platform == platformType))
			{
				return Array.Empty<IndexedQualityPattern>();
			}
			return presets.First((PlatformDependentGraphicPresets x) => x.Platform == platformType).Patterns;
		}

		public int GetQualityIndex(GraphicsPlatformType platformType, GameSettingsManager.GraphicsPattern quality)
		{
			if (presets == null || !presets.Any((PlatformDependentGraphicPresets x) => x.Platform == platformType))
			{
				return -1;
			}
			PlatformDependentGraphicPresets platformDependentGraphicPresets = presets.First((PlatformDependentGraphicPresets x) => x.Platform == platformType);
			if (!platformDependentGraphicPresets.Patterns.Any((IndexedQualityPattern x) => x.Quality == quality))
			{
				return -1;
			}
			return platformDependentGraphicPresets.Patterns.First((IndexedQualityPattern x) => x.Quality == quality).UnityPlayerQualityIndex;
		}

		public GraphicsPlatformType GetGraphicsPlatformType()
		{
			switch (Application.platform)
			{
			case RuntimePlatform.WindowsPlayer:
			case RuntimePlatform.WindowsEditor:
				return GraphicsPlatformType.Windows;
			case RuntimePlatform.OSXEditor:
			case RuntimePlatform.OSXPlayer:
				return GraphicsPlatformType.MacOS;
			case RuntimePlatform.Switch:
				return GraphicsPlatformType.SwitchPortable;
			case RuntimePlatform.PS4:
				return GraphicsPlatformType.PS4;
			case RuntimePlatform.XboxOne:
				return GraphicsPlatformType.XONE;
			default:
				return GraphicsPlatformType.Unknown;
			}
		}
	}
}
