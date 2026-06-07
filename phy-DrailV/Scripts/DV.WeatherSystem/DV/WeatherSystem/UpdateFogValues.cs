using SCPE;
using UnityEngine;
using UnityEngine.XR;

namespace DV.WeatherSystem
{
	public class UpdateFogValues : MonoBehaviour
	{
		private readonly int PLAYER_CAMERA_WORLD_HEIGHT = Shader.PropertyToID("_playerCameraWorldHeight");

		private readonly int CLIP_TO_WORLD = Shader.PropertyToID("clipToWorld");

		private readonly int FAR_CLIPPING_PLANE = Shader.PropertyToID("_FarClippingPlane");

		private readonly int SCENE_FOG_PARAMS = Shader.PropertyToID("_SceneFogParams");

		private readonly int SCENE_FOG_MODE = Shader.PropertyToID("_SceneFogMode");

		private readonly int DENSITY_PARAMS = Shader.PropertyToID("_DensityParams");

		private readonly int HEIGHT_PARAMS = Shader.PropertyToID("_HeightParams");

		private readonly int DISTANCE_PARAMS = Shader.PropertyToID("_DistanceParams");

		private readonly int FOG_COLOR = Shader.PropertyToID("_FogColor");

		private readonly int SKYBOX_PARAMS = Shader.PropertyToID("_SkyboxParams");

		private readonly int DIR_LIGHT_PARAMS = Shader.PropertyToID("_DirLightParams");

		private readonly int DIR_LIGHT_COLOR = Shader.PropertyToID("_DirLightColor");

		private readonly int INV_CAM_PROJ_MAT = Shader.PropertyToID("invCamProjMat");

		private readonly int CAM_TO_WORLD_MAT = Shader.PropertyToID("camToWorldMat");

		private readonly int WATER_FOG_COLOR = Shader.PropertyToID("DV_WaterFogColor");

		private const float UNDERWATER_TRANSITION_DISTANCE = 0.05f;

		private const float sunIntensityOnFogMult = 1f;

		public float distanceDensity = 1f;

		public float height = 10f;

		public float heightDensity = 0.75f;

		private WeatherPresetManager weatherPresetManager;

		private Camera cam;

		private Matrix4x4[] clipToWorld = new Matrix4x4[2];

		private Matrix4x4[] invCamProjMat = new Matrix4x4[2];

		private Matrix4x4[] camToWorldMat = new Matrix4x4[2];

		private Vector4[] _DirLightParams = new Vector4[2];

		private Vector4[] _HeightParams = new Vector4[2];

		private void Start()
		{
			weatherPresetManager = Object.FindObjectOfType<WeatherPresetManager>();
			cam = GetComponent<Camera>();
			if (!cam)
			{
				Debug.LogError("UpdateFogValues is missing the Camera component!", this);
			}
		}

		private void OnPreRender()
		{
			UpdateFog();
		}

		private void OnPostRender()
		{
			UpdateFog(probe: true);
		}

		private void LateUpdate()
		{
			float value = Vector3.Dot(base.transform.forward, Vector3.down);
			value = Mathf.Clamp01(value);
			Color color = ((TOD_Sky.Instance == null) ? Color.clear : TOD_Sky.Instance.Fog.UnderwaterColor);
			Shader.SetGlobalColor(WATER_FOG_COLOR, color * (1f - value * 0.2f));
			if ((bool)weatherPresetManager)
			{
				distanceDensity = weatherPresetManager.fogDistanceDensity;
				heightDensity = weatherPresetManager.FogHeightDensity;
				height = weatherPresetManager.fogHeight;
			}
			UpdateFog(probe: true);
			Shader.SetGlobalFloat(PLAYER_CAMERA_WORLD_HEIGHT, base.transform.position.y);
		}

		private void UpdateFog(bool probe = false)
		{
			if (!cam)
			{
				return;
			}
			int num = ((!cam.stereoEnabled) ? 1 : 2);
			for (int i = 0; i < num; i++)
			{
				if (num == 1)
				{
					Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(cam.projectionMatrix, renderIntoTexture: false);
					float value = (gPUProjectionMatrix[3, 2] = 0f);
					gPUProjectionMatrix[2, 3] = value;
					gPUProjectionMatrix[3, 3] = 1f;
					clipToWorld[i] = Matrix4x4.Inverse(gPUProjectionMatrix * cam.worldToCameraMatrix) * Matrix4x4.TRS(new Vector3(0f, 0f, 0f - gPUProjectionMatrix[2, 2]), Quaternion.identity, Vector3.one);
					invCamProjMat[i] = GL.GetGPUProjectionMatrix(cam.projectionMatrix, renderIntoTexture: true).inverse;
					camToWorldMat[i] = cam.cameraToWorldMatrix;
				}
				else
				{
					Matrix4x4 stereoProjectionMatrix = cam.GetStereoProjectionMatrix((Camera.StereoscopicEye)i);
					Matrix4x4 gPUProjectionMatrix2 = GL.GetGPUProjectionMatrix(stereoProjectionMatrix, renderIntoTexture: false);
					Matrix4x4 stereoViewMatrix = cam.GetStereoViewMatrix((Camera.StereoscopicEye)i);
					float value = (gPUProjectionMatrix2[3, 2] = 0f);
					gPUProjectionMatrix2[2, 3] = value;
					gPUProjectionMatrix2[3, 3] = 1f;
					clipToWorld[i] = Matrix4x4.Inverse(gPUProjectionMatrix2 * stereoViewMatrix) * Matrix4x4.TRS(new Vector3(0f, 0f, 0f - gPUProjectionMatrix2[2, 2]), Quaternion.identity, Vector3.one);
					invCamProjMat[i] = GL.GetGPUProjectionMatrix(stereoProjectionMatrix, renderIntoTexture: true).inverse;
					camToWorldMat[i] = stereoViewMatrix.inverse;
				}
				Vector3 obj = ((num == 1) ? cam.transform.position : (Quaternion.Inverse(InputTracking.GetLocalRotation((XRNode)i)) * InputTracking.GetLocalPosition((XRNode)i)));
				float num4 = obj.y;
				if (probe)
				{
					num4 = GetWaterLevelY();
				}
				float num5 = num4 - height;
				float z = ((num5 <= 0f) ? 1f : 0f);
				_HeightParams[i] = new Vector4(height, num5, z, heightDensity * 0.5f);
				Vector3 sunDirection = FogLightSource.sunDirection;
				float intensity = FogLightSource.intensity;
				_DirLightParams[i] = new Vector4(sunDirection.x, sunDirection.y, sunDirection.z, intensity * 1f);
			}
			float x = 0f;
			float z2 = 1f;
			float w = 1f;
			int num6 = 0;
			FogMode fogMode = RenderSettings.fogMode;
			float fogDensity = RenderSettings.fogDensity;
			float fogStartDistance = RenderSettings.fogStartDistance;
			float fogEndDistance = RenderSettings.fogEndDistance;
			bool flag = fogMode == FogMode.Linear;
			float num7 = (flag ? (fogEndDistance - fogStartDistance) : 0f);
			float num8 = ((Mathf.Abs(num7) > 0.0001f) ? (1f / num7) : 0f);
			Vector4 value2 = default(Vector4);
			value2.x = fogDensity * 1.2011224f;
			value2.y = fogDensity * 1.442695f;
			value2.z = (flag ? (0f - num8) : 0f);
			value2.w = (flag ? (fogEndDistance * num8) : 0f);
			float farClipPlane = cam.farClipPlane;
			Color color = FogLightSource.color;
			if ((bool)weatherPresetManager)
			{
				color = weatherPresetManager.LerpedSnapshot.skyColorDay;
			}
			Shader.SetGlobalVector(DIR_LIGHT_COLOR, new Vector4(color.r, color.g, color.b, 0f));
			Shader.SetGlobalFloat(FAR_CLIPPING_PLANE, farClipPlane);
			Shader.SetGlobalVector(SCENE_FOG_PARAMS, value2);
			Shader.SetGlobalVector(SCENE_FOG_MODE, new Vector4((float)fogMode, 1f, num6, 0f));
			Shader.SetGlobalVector(DISTANCE_PARAMS, new Vector4(0f - fogStartDistance, 0f, z2, w));
			Shader.SetGlobalVector(SKYBOX_PARAMS, new Vector4(x, 0f, 0f, 0f));
			Shader.SetGlobalVector(DENSITY_PARAMS, new Vector4(distanceDensity, 0f, 0f, 0f));
			Shader.SetGlobalColor(FOG_COLOR, RenderSettings.fogColor);
			Shader.SetGlobalMatrixArray(CLIP_TO_WORLD, clipToWorld);
			Shader.SetGlobalMatrixArray(INV_CAM_PROJ_MAT, invCamProjMat);
			Shader.SetGlobalMatrixArray(CAM_TO_WORLD_MAT, camToWorldMat);
			Shader.SetGlobalVectorArray(DIR_LIGHT_PARAMS, _DirLightParams);
			Shader.SetGlobalVectorArray(HEIGHT_PARAMS, _HeightParams);
		}

		protected virtual float GetWaterLevelY()
		{
			return 0f;
		}
	}
}
