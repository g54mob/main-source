using System;
using UnityEngine;

namespace Aura2API
{
	[Serializable]
	[CreateAssetMenu(fileName = "New Aura Quality Settings", menuName = "Aura 2/Quality Settings", order = 1)]
	public class AuraQualitySettings : ScriptableObject
	{
		public bool displayVolumetricLightingBuffer;

		public Vector3Int frustumGridResolution = new Vector3Int(160, 90, 128);

		public bool enableAutomaticStereoResizing = true;

		public float farClipPlaneDistance = 128f;

		public float depthBiasCoefficient = 0.35f;

		public bool enableVolumes = true;

		public bool enableVolumesTexture2DMask = true;

		public bool enableVolumesTexture3DMask = true;

		public bool enableVolumesNoiseMask = true;

		public bool enableAmbientLighting = true;

		public bool enableDirectionalLights = true;

		public bool enableDirectionalLightsShadows = true;

		public bool enableSpotLights = true;

		public bool enableSpotLightsShadows = true;

		public bool enablePointLights = true;

		public bool enablePointLightsShadows = true;

		public bool enableLightsCookies = true;

		public bool enableDithering = true;

		public Texture3DFiltering texture3DFiltering = Texture3DFiltering.Cubic;

		public bool EXPERIMENTAL_enableDenoisingFilter;

		public DenoisingFilterRange EXPERIMENTAL_denoisingFilterRange;

		public bool EXPERIMENTAL_enableBlurFilter;

		public BlurFilterRange EXPERIMENTAL_blurFilterRange;

		public BlurFilterType EXPERIMENTAL_blurFilterType;

		public float EXPERIMENTAL_blurFilterGaussianDeviation = 0.0025f;

		public bool enableTemporalReprojection = true;

		[Range(0f, 1f)]
		public float temporalReprojectionFactor = 0.95f;

		public bool enableOcclusionCulling = true;

		public bool debugOcclusionCulling;

		public OcclusionCullingAccuracy occlusionCullingAccuracy;

		public bool enableLightProbes;

		public Vector3Int GetFrustumGridResolution(Camera camera)
		{
			StereoMode cameraStereoMode = camera.GetCameraStereoMode();
			Vector3Int result = frustumGridResolution;
			if (enableAutomaticStereoResizing)
			{
				switch (cameraStereoMode)
				{
				case StereoMode.MultiPass:
					result.x /= 2;
					break;
				case StereoMode.SinglePass:
					result.x *= 2;
					break;
				}
			}
			return result;
		}

		public void SetFrustumGridResolution(Vector3Int resolution)
		{
			frustumGridResolution = resolution;
			AuraCamera[] array = UnityEngine.Object.FindObjectsOfType<AuraCamera>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].frustumSettings.QualitySettings == this)
				{
					array[i].SetFrustumGridResolution(frustumGridResolution);
				}
			}
		}
	}
}
