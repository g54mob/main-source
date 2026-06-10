using UnityEngine;

namespace Aura2API
{
	public struct FrustumSettingsParameters
	{
		public bool enableVolumes;

		public bool enableVolumesTextureMask;

		public bool enableVolumesNoiseMask;

		public bool enableDirectionalLights;

		public bool enableDirectionalLightsShadows;

		public bool enableSpotLights;

		public bool enableSpotLightsShadows;

		public bool enablePointLights;

		public bool enablePointLightsShadows;

		public bool enableLightsCookies;

		public bool enableOcclusionCulling;

		public OcclusionCullingAccuracy occlusionCullingAccuracy;

		public bool enableTemporalReprojection;

		[Range(0f, 1f)]
		public float temporalReprojectionFactor;

		public Vector3Int resolution;

		public float farClipPlaneDistance;

		public void Init()
		{
			enableVolumes = true;
			enableVolumesTextureMask = true;
			enableVolumesNoiseMask = true;
			enableDirectionalLights = true;
			enableDirectionalLightsShadows = true;
			enableSpotLights = true;
			enableSpotLightsShadows = true;
			enablePointLights = true;
			enablePointLightsShadows = true;
			enableLightsCookies = true;
			enableOcclusionCulling = true;
			enableTemporalReprojection = true;
			temporalReprojectionFactor = 0.9f;
			resolution = new Vector3Int(160, 90, 128);
			farClipPlaneDistance = 25f;
		}
	}
}
