using UnityEngine;

namespace Aura2API
{
	public class FrustumSettingsToId
	{
		private AuraCamera _auraComponent;

		private FrustumParameters _frustumParameters;

		private FrustumSettings _frustumSettings;

		private VolumesManager _volumesManager;

		private SpotLightsManager _spotLightsManager;

		private PointLightsManager _pointLightsManager;

		public FrustumSettingsToId(FrustumSettings settings, AuraCamera auraComponent, VolumesManager volumesManager, SpotLightsManager spotLightsManager, PointLightsManager pointLightsManager)
		{
			_frustumSettings = settings;
			_auraComponent = auraComponent;
			_volumesManager = volumesManager;
			_spotLightsManager = spotLightsManager;
			_pointLightsManager = pointLightsManager;
		}

		public int GetKernelId()
		{
			return QualitySettings.shadowCascades switch
			{
				1 => 0, 
				2 => 1, 
				_ => 2, 
			};
		}

		public int GetKernelId(Camera camera)
		{
			int kernelId = GetKernelId();
			kernelId += ((camera.GetCameraStereoMode() == StereoMode.SinglePass) ? 3 : 0);
			return ((!camera.orthographic) ? kernelId : 0) + (HasFlags(FrustumParameters.EnableOcclusionCulling) ? 6 : 0);
		}

		public void ComputeFlags()
		{
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableOcclusionCulling, _frustumSettings.QualitySettings.enableOcclusionCulling);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableTemporalReprojection, _frustumSettings.QualitySettings.enableTemporalReprojection && _auraComponent.FrameId > 1 && !Mathf.Approximately(_frustumSettings.QualitySettings.temporalReprojectionFactor, 0f));
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableVolumes, _frustumSettings.QualitySettings.enableVolumes && _volumesManager.HasVisibleVolumes);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableVolumesNoiseMask, _frustumSettings.QualitySettings.enableVolumesNoiseMask && _frustumParameters.HasFlags(FrustumParameters.EnableVolumes));
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableVolumesTexture2DMask, _frustumSettings.QualitySettings.enableVolumesTexture2DMask && _frustumParameters.HasFlags(FrustumParameters.EnableVolumes) && AuraCamera.CommonDataManager.VolumesCommonDataManager.HasTexture2DMasks);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableVolumesTexture3DMask, _frustumSettings.QualitySettings.enableVolumesTexture3DMask && _frustumParameters.HasFlags(FrustumParameters.EnableVolumes) && AuraCamera.CommonDataManager.VolumesCommonDataManager.HasTexture3DMasks);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableAmbientLighting, _frustumSettings.BaseSettings.useAmbientLighting && _frustumSettings.QualitySettings.enableAmbientLighting && !Mathf.Approximately(_frustumSettings.BaseSettings.ambientLightingStrength, 0f));
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableLightProbes, _frustumSettings.QualitySettings.enableLightProbes && AuraCamera.CommonDataManager.VolumesCommonDataManager.HasRegisteredLightProbesProxyVolumes && LightProbeProxyVolume.isFeatureSupported && LightmapSettings.lightProbes != null && LightmapSettings.lightProbes.count > 0);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableDirectionalLights, _frustumSettings.QualitySettings.enableDirectionalLights && AuraCamera.CommonDataManager.LightsCommonDataManager.DirectionalLightsManager.HasCandidateLights);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableDirectionalLightsShadows, _frustumSettings.QualitySettings.enableDirectionalLightsShadows && _frustumParameters.HasFlags(FrustumParameters.EnableDirectionalLights) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasDirectionalShadowCasters);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.DirectionalLightsShadowsOneCascade, QualitySettings.shadowCascades == 1 && _frustumParameters.HasFlags(FrustumParameters.EnableDirectionalLights));
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.DirectionalLightsShadowsTwoCascades, QualitySettings.shadowCascades == 2 && _frustumParameters.HasFlags(FrustumParameters.EnableDirectionalLights));
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.DirectionalLightsShadowsFourCascades, QualitySettings.shadowCascades == 4 && _frustumParameters.HasFlags(FrustumParameters.EnableDirectionalLights));
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableSpotLights, _frustumSettings.QualitySettings.enableSpotLights && _spotLightsManager.HasVisibleLights);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableSpotLightsShadows, _frustumSettings.QualitySettings.enableSpotLightsShadows && _frustumParameters.HasFlags(FrustumParameters.EnableSpotLights) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasSpotShadowCasters);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnablePointLights, _frustumSettings.QualitySettings.enablePointLights && _pointLightsManager.HasVisibleLights);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnablePointLightsShadows, _frustumSettings.QualitySettings.enablePointLightsShadows && _frustumParameters.HasFlags(FrustumParameters.EnablePointLights) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasPointShadowCasters);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableLightsCookies, _frustumSettings.QualitySettings.enableLightsCookies && ((_frustumParameters.HasFlags(FrustumParameters.EnablePointLights) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasPointCookieCasters) || (_frustumParameters.HasFlags(FrustumParameters.EnableSpotLights) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasSpotCookieCasters) || (_frustumParameters.HasFlags(FrustumParameters.EnableDirectionalLights) && AuraCamera.CommonDataManager.LightsCommonDataManager.HasDirectionalCookieCasters)));
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableDenoisingFilter, _frustumSettings.QualitySettings.EXPERIMENTAL_enableDenoisingFilter);
			_frustumParameters = _frustumParameters.ReplaceFlags(FrustumParameters.EnableBlurFilter, _frustumSettings.QualitySettings.EXPERIMENTAL_enableBlurFilter);
		}

		public bool HasFlags(FrustumParameters flags)
		{
			return _frustumParameters.HasFlags(flags);
		}
	}
}
