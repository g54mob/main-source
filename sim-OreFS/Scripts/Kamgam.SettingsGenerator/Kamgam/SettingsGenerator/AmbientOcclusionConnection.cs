using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class AmbientOcclusionConnection : Connection<bool>
	{
		public static bool UseActiveStateToDisable;

		protected Dictionary<UniversalRenderPipelineAsset, float> _lastKnownIntensities = new Dictionary<UniversalRenderPipelineAsset, float>();

		protected ScriptableRenderer getRenderer()
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset != null)
			{
				ScriptableRenderer scriptableRenderer = universalRenderPipelineAsset.scriptableRenderer;
				if (scriptableRenderer != null)
				{
					return scriptableRenderer;
				}
			}
			return null;
		}

		private static float getIntensity(UniversalRenderPipelineAsset rpAsset)
		{
			if (rpAsset == null)
			{
				return 0f;
			}
			return UniversalRenderPipelineUtils.GetRendererFeatureChild<float>(UniversalRenderPipelineUtils.GetRendererFeature("ScreenSpaceAmbientOcclusion", rpAsset), "m_Settings", "Intensity");
		}

		private static void setIntensity(UniversalRenderPipelineAsset rpAsset, float intensity)
		{
			if (!(rpAsset == null))
			{
				ScriptableRendererFeature rendererFeature = UniversalRenderPipelineUtils.GetRendererFeature("ScreenSpaceAmbientOcclusion", rpAsset);
				UniversalRenderPipelineUtils.SetRendererFeatureChild(intensity, rendererFeature, "m_Settings", "Intensity");
			}
		}

		protected void updateLastKnownIntensity(UniversalRenderPipelineAsset rpAsset)
		{
			if (!_lastKnownIntensities.ContainsKey(rpAsset))
			{
				_lastKnownIntensities.Add(rpAsset, getIntensity(rpAsset));
			}
		}

		public override bool Get()
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset == null)
			{
				return false;
			}
			ScriptableRendererFeature rendererFeature = UniversalRenderPipelineUtils.GetRendererFeature("ScreenSpaceAmbientOcclusion", universalRenderPipelineAsset);
			if (UseActiveStateToDisable)
			{
				return rendererFeature.isActive;
			}
			updateLastKnownIntensity(universalRenderPipelineAsset);
			return getIntensity(universalRenderPipelineAsset) > 0.001f;
		}

		public override void Set(bool enable)
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset == null)
			{
				return;
			}
			ScriptableRendererFeature rendererFeature = UniversalRenderPipelineUtils.GetRendererFeature("ScreenSpaceAmbientOcclusion", universalRenderPipelineAsset);
			if (rendererFeature != null)
			{
				if (UseActiveStateToDisable)
				{
					rendererFeature.SetActive(enable);
				}
				else
				{
					updateLastKnownIntensity(universalRenderPipelineAsset);
					float intensity = (enable ? _lastKnownIntensities[universalRenderPipelineAsset] : 0.001f);
					setIntensity(universalRenderPipelineAsset, intensity);
				}
			}
			NotifyListenersIfChanged(enable);
		}
	}
}
