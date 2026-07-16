using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Game.Graphics
{
	public class GraphicsSettings
	{
		public static void SetResolution(int width, int height, double refreshRate)
		{
			RefreshRate refreshRateRatio = Screen.resolutions.FirstOrDefault((Resolution r) => r.refreshRateRatio.value == refreshRate).refreshRateRatio;
			Screen.SetResolution(width, height, (FullScreenMode)GameSettings.GetActiveConfig().graphics.fullscreenMode, refreshRateRatio);
		}

		public static void SetMonitor(int value)
		{
			List<DisplayInfo> displayLayout = DisplayUtility.GetDisplayLayout();
			int currentDisplayIndex = DisplayUtility.GetCurrentDisplayIndex();
			if (value != currentDisplayIndex)
			{
				if (displayLayout[value].width < displayLayout[currentDisplayIndex].width || displayLayout[value].height < displayLayout[currentDisplayIndex].height)
				{
					GameSettings.GetActiveConfig().graphics.resolutionX = displayLayout[value].width;
					GameSettings.GetActiveConfig().graphics.resolutionY = displayLayout[value].height;
					GameSettings.SaveConfig();
					SetResolution(displayLayout[value].width, displayLayout[value].height, Screen.currentResolution.refreshRateRatio.value);
				}
				Screen.MoveMainWindowTo(displayLayout[value], new Vector2Int(displayLayout[currentDisplayIndex].width / 2, displayLayout[currentDisplayIndex].height / 2));
			}
		}

		public static void SetFullscreen(int value)
		{
			if (value == 0)
			{
				value = 1;
			}
			Screen.SetResolution(GameSettings.GetActiveConfig().graphics.resolutionX, GameSettings.GetActiveConfig().graphics.resolutionY, (FullScreenMode)value);
		}

		public static void SetVSync(int value)
		{
			QualitySettings.vSyncCount = value;
		}

		public static void SetRenderScale(float value)
		{
			((UniversalRenderPipelineAsset)QualitySettings.renderPipeline).renderScale = value;
		}

		public static void SetBrightness(float value)
		{
			((UniversalRenderPipelineAsset)QualitySettings.renderPipeline).volumeProfile.TryGet<ShadowsMidtonesHighlights>(out var component);
			if (!(component == null))
			{
				Vector4 x = new Vector4(0f, 0f, 0f, Mathf.InverseLerp(0f, 5f, value));
				component.shadows.Override(x);
			}
		}

		public static void SetMainQuality(int value)
		{
			_ = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;
			switch (value)
			{
			case 0:
				QualitySettings.globalTextureMipmapLimit = 0;
				QualitySettings.particleRaycastBudget = 256;
				QualitySettings.maximumLODLevel = 0;
				break;
			case 1:
				QualitySettings.globalTextureMipmapLimit = 0;
				QualitySettings.particleRaycastBudget = 128;
				QualitySettings.maximumLODLevel = 0;
				break;
			case 2:
				QualitySettings.globalTextureMipmapLimit = 1;
				QualitySettings.particleRaycastBudget = 64;
				QualitySettings.maximumLODLevel = 1;
				break;
			case 3:
				QualitySettings.globalTextureMipmapLimit = 2;
				QualitySettings.particleRaycastBudget = 32;
				QualitySettings.maximumLODLevel = 2;
				break;
			}
		}

		public static void SetShadowQuality(int value)
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = (UniversalRenderPipelineAsset)QualitySettings.renderPipeline;
			switch (value)
			{
			case 0:
				universalRenderPipelineAsset.mainLightShadowmapResolution = 2048;
				universalRenderPipelineAsset.additionalLightsShadowmapResolution = 2048;
				break;
			case 1:
				universalRenderPipelineAsset.mainLightShadowmapResolution = 1024;
				universalRenderPipelineAsset.additionalLightsShadowmapResolution = 1024;
				break;
			case 2:
				universalRenderPipelineAsset.mainLightShadowmapResolution = 512;
				universalRenderPipelineAsset.additionalLightsShadowmapResolution = 512;
				break;
			case 3:
				universalRenderPipelineAsset.mainLightShadowmapResolution = 256;
				universalRenderPipelineAsset.additionalLightsShadowmapResolution = 256;
				break;
			}
		}
	}
}
