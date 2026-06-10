using UnityEngine;

namespace SSMS
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("OCASM/Image Effects/SSMS Global Fog")]
	[ImageEffectAllowedInSceneView]
	public class SSMSGlobalFog : MonoBehaviour
	{
		[Tooltip("Apply distance-based fog?")]
		public bool distanceFog = true;

		[Tooltip("Exclude far plane pixels from distance-based fog? (Skybox or clear color)")]
		public bool excludeFarPixels = true;

		[Tooltip("Distance fog is based on radial distance from camera when checked")]
		public bool useRadialDistance;

		[Tooltip("Apply height-based fog?")]
		public bool heightFog = true;

		[Tooltip("Fog top Y coordinate")]
		public float height = 1f;

		[Range(0.001f, 100f)]
		public float heightDensity = 2f;

		[Tooltip("Push fog away from the camera by this amount")]
		public float startDistance;

		[Tooltip("Clips max fog value. Allows bright lights to shine through.")]
		[Range(0f, 1f)]
		public float maxDensity = 0.999f;

		[Tooltip("How much light is absorbed by the fog. Not physically correct at all.")]
		[Range(0f, 100f)]
		public float energyLoss;

		[Tooltip("Tints the color of this instance of Global Fog.")]
		public Color fogTint = Color.white;

		private bool saveFogRT = true;

		public Shader fogShader;

		[Header("Global Fog Settings")]
		[Tooltip("Overrides global settings.")]
		public bool setGlobalSettings;

		public Color fogColor;

		public FogMode fogMode;

		[Tooltip("For exponential modes only.")]
		[Range(0f, 1f)]
		public float fogDensity;

		[Tooltip("For linear mode only.")]
		public float fogStart;

		[Tooltip("For linear mode only.")]
		public float fogEnd;

		private Material fogMaterial;

		[HideInInspector]
		public RenderTexture fogRT;

		private Camera comCamera;

		private void OnEnable()
		{
			fogShader = Shader.Find("Hidden/SSMS Global Fog");
			if (fogMaterial == null)
			{
				fogMaterial = new Material(fogShader);
				fogMaterial.hideFlags = HideFlags.DontSave;
			}
		}

		private void OnDisable()
		{
			Object.DestroyImmediate(fogMaterial);
			fogMaterial = null;
		}

		private void OnDestroy()
		{
			if (fogRT != null)
			{
				fogRT.Release();
				Object.DestroyImmediate(fogRT);
				fogRT = null;
			}
		}

		[ImageEffectOpaque]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (setGlobalSettings)
			{
				if (fogStart < 0f)
				{
					fogStart = 0f;
				}
				if (fogEnd < 0f)
				{
					fogEnd = 0f;
				}
				RenderSettings.fogColor = fogColor;
				RenderSettings.fogMode = this.fogMode;
				RenderSettings.fogDensity = fogDensity;
				RenderSettings.fogStartDistance = fogStart;
				RenderSettings.fogEndDistance = fogEnd;
			}
			if (!distanceFog && !heightFog)
			{
				Graphics.Blit(source, destination);
				return;
			}
			if (saveFogRT && (fogRT == null || fogRT.height < source.height || fogRT.width < source.width))
			{
				fogRT = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.Default);
				fogRT.name = base.gameObject.name + " SSMS Global Fog RT";
			}
			if (comCamera == null)
			{
				comCamera = GetComponent<Camera>();
			}
			Camera camera = comCamera;
			Transform obj = camera.transform;
			Vector3[] array = new Vector3[4];
			camera.CalculateFrustumCorners(new Rect(0f, 0f, 1f, 1f), camera.farClipPlane, camera.stereoActiveEye, array);
			Vector3 vector = obj.TransformVector(array[0]);
			Vector3 vector2 = obj.TransformVector(array[1]);
			Vector3 vector3 = obj.TransformVector(array[2]);
			Vector3 vector4 = obj.TransformVector(array[3]);
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetRow(0, vector);
			identity.SetRow(1, vector4);
			identity.SetRow(2, vector2);
			identity.SetRow(3, vector3);
			Vector3 position = obj.position;
			float num = position.y - height;
			float z = ((num <= 0f) ? 1f : 0f);
			float y = (excludeFarPixels ? 1f : 2f);
			fogMaterial.SetMatrix("_FrustumCornersWS", identity);
			fogMaterial.SetVector("_CameraWS", position);
			fogMaterial.SetVector("_HeightParams", new Vector4(height, num, z, heightDensity * 0.5f));
			fogMaterial.SetVector("_DistanceParams", new Vector4(0f - Mathf.Max(startDistance, 0f), y, 0f, 0f));
			FogMode fogMode = RenderSettings.fogMode;
			float num2 = RenderSettings.fogDensity;
			float fogStartDistance = RenderSettings.fogStartDistance;
			float fogEndDistance = RenderSettings.fogEndDistance;
			bool flag = fogMode == FogMode.Linear;
			float num3 = (flag ? (fogEndDistance - fogStartDistance) : 0f);
			float num4 = ((Mathf.Abs(num3) > 0.0001f) ? (1f / num3) : 0f);
			Vector4 value = default(Vector4);
			value.x = num2 * 1.2011224f;
			value.y = num2 * 1.442695f;
			value.z = (flag ? (0f - num4) : 0f);
			value.w = (flag ? (fogEndDistance * num4) : 0f);
			fogMaterial.SetVector("_SceneFogParams", value);
			fogMaterial.SetVector("_SceneFogMode", new Vector4((float)fogMode, useRadialDistance ? 1 : 0, 0f, 0f));
			fogMaterial.SetColor("_FogTint", fogTint);
			fogMaterial.SetFloat("_MaxValue", maxDensity);
			fogMaterial.SetFloat("_EnLoss", energyLoss);
			int num5 = 0;
			if (distanceFog && heightFog)
			{
				num5 = 0;
				if (saveFogRT)
				{
					Graphics.Blit(source, fogRT, fogMaterial, 3);
				}
			}
			else if (distanceFog)
			{
				num5 = 1;
				if (saveFogRT)
				{
					Graphics.Blit(source, fogRT, fogMaterial, 4);
				}
			}
			else
			{
				num5 = 2;
				if (saveFogRT)
				{
					Graphics.Blit(source, fogRT, fogMaterial, 5);
				}
			}
			Graphics.Blit(source, destination, fogMaterial, num5);
			Shader.SetGlobalTexture("_FogTex", fogRT);
			if (!saveFogRT && fogRT != null)
			{
				fogRT.Release();
			}
		}
	}
}
