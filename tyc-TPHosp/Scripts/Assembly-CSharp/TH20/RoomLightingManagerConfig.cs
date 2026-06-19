using System;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Room Lighting Manager", order = 1113)]
	public class RoomLightingManagerConfig : ScriptableObjectWithID
	{
		[Serializable]
		public struct FadeConfig
		{
			public float FadeInDistance;

			public float FadeOutDistance;
		}

		public bool UseDeferredRoomLighting;

		public Vector3 RoomLightOffset;

		public bool UseLightFalloff;

		public bool UpdateCharaterLayers;

		public bool ShowDebugReflectionSpheres;

		public float UnderneathLightHeight;

		public float OverheadLightHeight;

		[Header("Default Materials and Cubemaps")]
		public Material DefaultRoomLightMaterial;

		public Cubemap DefaultRoomLightCubemap;

		public Material DefaultRoomClosedLightMaterial;

		public Cubemap DefaultRoomClosedLightCubemap;

		public Material OutdoorRoomLightMaterial;

		public Cubemap OutdoorRoomLightCubemap;

		[Space]
		public Material InteriorInstanceLightMaterial;

		public Material ExteriorInstanceLightMaterial;

		public Material VolumeShadowCastingMaterial;

		[Space]
		public Material ReflectionTestMaterial;

		[Range(0f, 100f)]
		public float RoomLightHeight = 5f;

		public float RoomLightBaseBias = -0.01f;

		[Header("Interior Directional Light")]
		public Vector3 InteriorLightRotation = new Vector3(70f, -50f, 0f);

		public Vector3 InteriorShadowRotation = new Vector3(70f, -50f, 0f);

		[Range(0f, 1f)]
		public float InteriorShadowStrength = 1f;

		[Header("Interior Shadow Fade")]
		public FadeConfig NearShadowFade;

		public FadeConfig MediumShadowFade;

		public FadeConfig FarShadowFade;

		[Header("Clippable Light Fade")]
		public FadeConfig NearClippableFade;

		public FadeConfig MediumClippableFade;

		public FadeConfig FarClippableFade;

		[Header("Exterior Directional Light")]
		public Vector3 ExteriorLightRotation = new Vector3(70f, -50f, 0f);

		[Range(0f, 1f)]
		public float ExteriorShadowStrength = 1f;

		[Range(0f, 1f)]
		public float ExteriorShadowBias = 0.2f;

		[Range(0f, 1f)]
		public float ExteriorShadowNormalBias = 0.3f;

		[Space]
		public GameObject IndoorLightingPrefab;

		public Material ClippableSpotLightMaterial;

		public Material ClippablePointLightMaterial;

		public Texture2D DefaultSpotLightCookie;

		[Header("Out Of Bounds Lighting")]
		[Range(0f, 10000f)]
		public int OutOfBoundsLightDistance = 1000;

		[Range(0f, 1000f)]
		public float OutOfBoundsLightHeight = 100f;
	}
}
