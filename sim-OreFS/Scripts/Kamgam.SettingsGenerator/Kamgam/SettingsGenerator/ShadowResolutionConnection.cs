using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class ShadowResolutionConnection : ConnectionWithOptions<string>
	{
		public static bool SetAdditionalLightResolution = true;

		public static int AdditionalToMainResolutionFactor = 4;

		protected List<int> _values;

		protected List<string> _labels;

		private static void setResolution(UniversalRenderPipelineAsset asset, int resolution)
		{
			try
			{
				UniversalRenderPipelineUtils.SetMainLightShadowResolution(resolution, asset);
				if (SetAdditionalLightResolution)
				{
					UniversalRenderPipelineUtils.SetAdditionalLightShadowResolution(Mathf.Max(resolution / AdditionalToMainResolutionFactor, 256), asset);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("ShadowResolutionConnection reflection execution failed. Maybe the API has changed? \n" + ex.Message);
			}
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels == null)
			{
				_labels = new List<string> { "Low", "Mid", "High", "Very High", "Ultra" };
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			List<int> resolutions = getResolutions();
			if (optionLabels == null || optionLabels.Count != resolutions.Count)
			{
				Debug.LogError("Invalid new labels. Need to be " + resolutions?.ToString() + ".");
			}
			else
			{
				_labels = optionLabels;
			}
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		public override int Get()
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset == null)
			{
				return 0;
			}
			List<int> resolutions = getResolutions();
			for (int i = 0; i < resolutions.Count; i++)
			{
				if (resolutions[i] == universalRenderPipelineAsset.mainLightShadowmapResolution)
				{
					return i;
				}
			}
			return Mathf.Min(QualitySettings.GetQualityLevel(), resolutions.Count);
		}

		private List<int> getResolutions()
		{
			if (_values == null)
			{
				_values = new List<int> { 256, 512, 1024, 2048, 4096 };
			}
			return _values;
		}

		public override void Set(int index)
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset == null)
			{
				return;
			}
			List<int> resolutions = getResolutions();
			if (resolutions != null && resolutions.Count > 0)
			{
				if (resolutions.Count > index)
				{
					setResolution(universalRenderPipelineAsset, resolutions[index]);
				}
				else
				{
					setResolution(universalRenderPipelineAsset, resolutions[resolutions.Count - 1]);
				}
			}
			NotifyListenersIfChanged(index);
		}
	}
}
