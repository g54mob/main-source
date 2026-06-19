using System;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Level Lighting", order = 1110)]
	public class LevelLightingConfig : ScriptableObjectWithID
	{
		[Serializable]
		public struct FogSettingsConfig
		{
			public float FogFadeOutHeight;

			public float FogFadeInHeight;

			public Color FogColor;
		}

		[Serializable]
		public struct CausticsConfig
		{
			public bool Enabled;

			public Vector3 CausticsVolumePosition;

			public Vector3 CausticsVolumeScale;
		}

		[Serializable]
		public struct FloatOverride
		{
			public bool UseOverride;

			public float Value;
		}

		[Serializable]
		public struct IntOverride
		{
			public bool UseOverride;

			public int Value;
		}

		public float ShadowPlaneHeight;

		public float ShadowPlaneFadeDistance;

		public Material OutdoorLightMaterialOverride;

		public Cubemap OutdoorCubemapOverride;

		public bool EnableHeightFog;

		public FogSettingsConfig FogSettings;

		public FloatOverride RoomLightBaseBias;

		public FloatOverride RoomLightHeight;

		public IntOverride OutOfBoundsLightDistance;

		public FloatOverride TopDownCameraFarClipPlane;

		public bool UseUnderneathLight;

		public CausticsConfig Caustics;
	}
}
