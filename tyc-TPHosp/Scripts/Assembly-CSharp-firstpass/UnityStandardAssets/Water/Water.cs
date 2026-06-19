using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Water
{
	[ExecuteInEditMode]
	public class Water : MonoBehaviour
	{
		public enum WaterMode
		{
			Simple = 0,
			Reflective = 1,
			Refractive = 2
		}

		public WaterMode waterMode = WaterMode.Refractive;

		public bool disablePixelLights = true;

		public int textureSize = 256;

		public float clipPlaneOffset = 0.07f;

		public LayerMask reflectLayers = -1;

		public LayerMask refractLayers = -1;

		private Dictionary<Camera, Camera> m_ReflectionCameras = new Dictionary<Camera, Camera>();

		private Dictionary<Camera, Camera> m_RefractionCameras = new Dictionary<Camera, Camera>();

		private RenderTexture m_ReflectionTexture;

		private RenderTexture m_RefractionTexture;

		private WaterMode m_HardwareWaterSupport = WaterMode.Refractive;

		private int m_OldReflectionTextureSize;

		private int m_OldRefractionTextureSize;

		private static bool s_InsideWater;

		private Material m_Material;

		private MaterialPropertyBlock m_MaterialPropertyBlock;

		private List<Camera> _CachedCamerasToRemove = new List<Camera>();

		private Material GetMaterial()
		{
			if (m_Material == null)
			{
				m_Material = GetComponent<Renderer>().sharedMaterial;
			}
			return m_Material;
		}

		private MaterialPropertyBlock GetMaterialPropertyBlock()
		{
			if (m_MaterialPropertyBlock == null)
			{
				m_MaterialPropertyBlock = new MaterialPropertyBlock();
				GetComponent<Renderer>().GetPropertyBlock(m_MaterialPropertyBlock);
			}
			return m_MaterialPropertyBlock;
		}

		private void ApplyMaterialPropertyBlock()
		{
			if (m_MaterialPropertyBlock != null)
			{
				GetComponent<Renderer>().SetPropertyBlock(m_MaterialPropertyBlock);
			}
		}

		protected void OnEnable()
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(OnCamPreRender));
		}

		private void OnCamPreRender(Camera cam)
		{
			if (base.enabled && (bool)GetComponent<Renderer>() && (bool)GetComponent<Renderer>().sharedMaterial && GetComponent<Renderer>().enabled && !(cam == null) && !cam.orthographic && (cam.enabled || cam.cameraType == CameraType.SceneView) && (cam.cullingMask & LayerMask.GetMask("Water")) != 0 && !s_InsideWater)
			{
				s_InsideWater = true;
				m_HardwareWaterSupport = FindHardwareWaterSupport();
				WaterMode waterMode = GetWaterMode();
				CreateWaterObjects(cam, out var reflectionCamera, out var refractionCamera);
				Vector3 position = base.transform.position;
				Vector3 up = base.transform.up;
				int pixelLightCount = QualitySettings.pixelLightCount;
				if (disablePixelLights)
				{
					QualitySettings.pixelLightCount = 0;
				}
				UpdateCameraModes(cam, reflectionCamera);
				UpdateCameraModes(cam, refractionCamera);
				if (waterMode >= WaterMode.Reflective)
				{
					reflectionCamera.ResetWorldToCameraMatrix();
					reflectionCamera.ResetProjectionMatrix();
					float d = 0f - Vector3.Dot(up, position) - clipPlaneOffset;
					Vector3 vector = new Plane(up, d).ClosestPointOnPlane(cam.transform.position);
					float num = Vector3.Dot(cam.transform.position - position, up);
					Vector3 position2 = vector - up * num;
					Vector3 forward = cam.transform.forward - 2f * Vector3.Dot(cam.transform.forward, up) * up;
					reflectionCamera.transform.SetPositionAndRotation(position2, Quaternion.LookRotation(forward, -up));
					reflectionCamera.projectionMatrix *= Matrix4x4.Scale(new Vector3(-1f, 1f, 1f));
					reflectionCamera.cullingMask = 0;
					reflectionCamera.clearFlags = CameraClearFlags.Skybox;
					reflectionCamera.Render();
					reflectionCamera.targetTexture = m_ReflectionTexture;
					bool invertCulling = GL.invertCulling;
					GL.invertCulling = true;
					Vector4 clipPlane = CameraSpacePlane(reflectionCamera, position, up, 1f);
					reflectionCamera.projectionMatrix = cam.CalculateObliqueMatrix(clipPlane) * Matrix4x4.Scale(new Vector3(-1f, 1f, 1f));
					reflectionCamera.cullingMask = -17 & reflectLayers.value;
					reflectionCamera.clearFlags = CameraClearFlags.Depth;
					reflectionCamera.Render();
					GL.invertCulling = invertCulling;
					GetMaterialPropertyBlock().SetTexture("_ReflectionTex", m_ReflectionTexture);
				}
				if (waterMode >= WaterMode.Refractive)
				{
					refractionCamera.worldToCameraMatrix = cam.worldToCameraMatrix;
					Vector4 clipPlane2 = CameraSpacePlane(refractionCamera, position, up, -1f);
					refractionCamera.projectionMatrix = cam.CalculateObliqueMatrix(clipPlane2);
					refractionCamera.cullingMatrix = cam.projectionMatrix * cam.worldToCameraMatrix;
					refractionCamera.cullingMask = -17 & refractLayers.value;
					refractionCamera.targetTexture = m_RefractionTexture;
					refractionCamera.transform.position = cam.transform.position;
					refractionCamera.transform.rotation = cam.transform.rotation;
					refractionCamera.Render();
					GetMaterialPropertyBlock().SetTexture("_RefractionTex", m_RefractionTexture);
				}
				if (disablePixelLights)
				{
					QualitySettings.pixelLightCount = pixelLightCount;
				}
				switch (waterMode)
				{
				case WaterMode.Simple:
					Shader.EnableKeyword("WATER_SIMPLE");
					Shader.DisableKeyword("WATER_REFLECTIVE");
					Shader.DisableKeyword("WATER_REFRACTIVE");
					break;
				case WaterMode.Reflective:
					Shader.DisableKeyword("WATER_SIMPLE");
					Shader.EnableKeyword("WATER_REFLECTIVE");
					Shader.DisableKeyword("WATER_REFRACTIVE");
					break;
				case WaterMode.Refractive:
					Shader.DisableKeyword("WATER_SIMPLE");
					Shader.DisableKeyword("WATER_REFLECTIVE");
					Shader.EnableKeyword("WATER_REFRACTIVE");
					break;
				}
				s_InsideWater = false;
				ApplyMaterialPropertyBlock();
			}
		}

		private void OnDisable()
		{
			Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(OnCamPreRender));
			if ((bool)m_ReflectionTexture)
			{
				UnityEngine.Object.DestroyImmediate(m_ReflectionTexture);
				m_ReflectionTexture = null;
			}
			if ((bool)m_RefractionTexture)
			{
				UnityEngine.Object.DestroyImmediate(m_RefractionTexture);
				m_RefractionTexture = null;
			}
			foreach (KeyValuePair<Camera, Camera> reflectionCamera in m_ReflectionCameras)
			{
				UnityEngine.Object.DestroyImmediate(reflectionCamera.Value.gameObject);
			}
			m_ReflectionCameras.Clear();
			foreach (KeyValuePair<Camera, Camera> refractionCamera in m_RefractionCameras)
			{
				UnityEngine.Object.DestroyImmediate(refractionCamera.Value.gameObject);
			}
			m_RefractionCameras.Clear();
		}

		private void Update()
		{
			if ((bool)GetComponent<Renderer>())
			{
				Material material = GetMaterial();
				MaterialPropertyBlock materialPropertyBlock = GetMaterialPropertyBlock();
				Vector4 vector = material.GetVector("WaveSpeed");
				float num = material.GetFloat("_WaveScale");
				Vector4 value = new Vector4(num, num, num * 0.4f, num * 0.45f);
				double num2 = (double)Time.unscaledTime / 20.0;
				Vector4 value2 = new Vector4((float)Math.IEEERemainder((double)(vector.x * value.x) * num2, 1.0), (float)Math.IEEERemainder((double)(vector.y * value.y) * num2, 1.0), (float)Math.IEEERemainder((double)(vector.z * value.z) * num2, 1.0), (float)Math.IEEERemainder((double)(vector.w * value.w) * num2, 1.0));
				materialPropertyBlock.SetVector("_WaveOffset", value2);
				materialPropertyBlock.SetVector("_WaveScale4", value);
				ApplyMaterialPropertyBlock();
				CleanupWaterObjects();
			}
		}

		private void UpdateCameraModes(Camera src, Camera dest)
		{
			if (!(dest == null))
			{
				dest.clearFlags = src.clearFlags;
				dest.backgroundColor = src.backgroundColor;
				_ = src.clearFlags;
				_ = 1;
				dest.farClipPlane = src.farClipPlane;
				dest.nearClipPlane = src.nearClipPlane;
				dest.orthographic = src.orthographic;
				dest.fieldOfView = src.fieldOfView;
				dest.aspect = src.aspect;
				dest.orthographicSize = src.orthographicSize;
			}
		}

		private void CleanupWaterObjects()
		{
			_CachedCamerasToRemove.Clear();
			foreach (KeyValuePair<Camera, Camera> reflectionCamera in m_ReflectionCameras)
			{
				if (!(reflectionCamera.Key != null))
				{
					_CachedCamerasToRemove.Add(reflectionCamera.Key);
					if (!(reflectionCamera.Value == null))
					{
						UnityEngine.Object.DestroyImmediate(reflectionCamera.Value.gameObject);
					}
				}
			}
			foreach (Camera item in _CachedCamerasToRemove)
			{
				m_ReflectionCameras.Remove(item);
			}
			_CachedCamerasToRemove.Clear();
			foreach (KeyValuePair<Camera, Camera> refractionCamera in m_RefractionCameras)
			{
				if (!(refractionCamera.Key != null))
				{
					_CachedCamerasToRemove.Add(refractionCamera.Key);
					if (!(refractionCamera.Value == null))
					{
						UnityEngine.Object.DestroyImmediate(refractionCamera.Value.gameObject);
					}
				}
			}
			foreach (Camera item2 in _CachedCamerasToRemove)
			{
				m_RefractionCameras.Remove(item2);
			}
		}

		private void CreateWaterObjects(Camera currentCamera, out Camera reflectionCamera, out Camera refractionCamera)
		{
			WaterMode waterMode = GetWaterMode();
			reflectionCamera = null;
			refractionCamera = null;
			if (waterMode >= WaterMode.Reflective)
			{
				if (!m_ReflectionTexture || m_OldReflectionTextureSize != textureSize)
				{
					if ((bool)m_ReflectionTexture)
					{
						UnityEngine.Object.DestroyImmediate(m_ReflectionTexture);
					}
					m_ReflectionTexture = new RenderTexture(textureSize, textureSize, 16);
					m_ReflectionTexture.name = "__WaterReflection" + GetInstanceID();
					m_ReflectionTexture.isPowerOfTwo = true;
					m_ReflectionTexture.hideFlags = HideFlags.DontSave;
					m_OldReflectionTextureSize = textureSize;
				}
				m_ReflectionCameras.TryGetValue(currentCamera, out reflectionCamera);
				if (!reflectionCamera)
				{
					GameObject gameObject = new GameObject("Water Refl Camera id" + GetInstanceID() + " for " + currentCamera.GetInstanceID(), typeof(Camera));
					reflectionCamera = gameObject.GetComponent<Camera>();
					reflectionCamera.gameObject.SetActive(value: false);
					reflectionCamera.enabled = false;
					reflectionCamera.transform.position = base.transform.position;
					reflectionCamera.transform.rotation = base.transform.rotation;
					gameObject.hideFlags = HideFlags.DontSave;
					m_ReflectionCameras[currentCamera] = reflectionCamera;
				}
			}
			if (waterMode < WaterMode.Refractive)
			{
				return;
			}
			if (!m_RefractionTexture || m_OldRefractionTextureSize != textureSize)
			{
				if ((bool)m_RefractionTexture)
				{
					UnityEngine.Object.DestroyImmediate(m_RefractionTexture);
				}
				m_RefractionTexture = new RenderTexture(textureSize, textureSize, 16);
				m_RefractionTexture.name = "__WaterRefraction" + GetInstanceID();
				m_RefractionTexture.isPowerOfTwo = true;
				m_RefractionTexture.hideFlags = HideFlags.DontSave;
				m_OldRefractionTextureSize = textureSize;
			}
			m_RefractionCameras.TryGetValue(currentCamera, out refractionCamera);
			if (!refractionCamera)
			{
				GameObject gameObject2 = new GameObject("Water Refr Camera id" + GetInstanceID() + " for " + currentCamera.GetInstanceID(), typeof(Camera));
				refractionCamera = gameObject2.GetComponent<Camera>();
				refractionCamera.gameObject.SetActive(value: false);
				refractionCamera.enabled = false;
				refractionCamera.transform.position = base.transform.position;
				refractionCamera.transform.rotation = base.transform.rotation;
				gameObject2.hideFlags = HideFlags.DontSave;
				m_RefractionCameras[currentCamera] = refractionCamera;
			}
		}

		private WaterMode GetWaterMode()
		{
			if (m_HardwareWaterSupport < waterMode)
			{
				return m_HardwareWaterSupport;
			}
			return waterMode;
		}

		private WaterMode FindHardwareWaterSupport()
		{
			if (!GetComponent<Renderer>())
			{
				return WaterMode.Simple;
			}
			Material material = GetMaterial();
			if (!material)
			{
				return WaterMode.Simple;
			}
			string text = material.GetTag("WATERMODE", searchFallbacks: false);
			if (text == "Refractive")
			{
				return WaterMode.Refractive;
			}
			if (text == "Reflective")
			{
				return WaterMode.Reflective;
			}
			return WaterMode.Simple;
		}

		private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
		{
			Vector3 point = pos + normal * clipPlaneOffset;
			Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
			Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
			Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
			return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
		}

		private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
		{
			reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
			reflectionMat.m01 = -2f * plane[0] * plane[1];
			reflectionMat.m02 = -2f * plane[0] * plane[2];
			reflectionMat.m03 = -2f * plane[3] * plane[0];
			reflectionMat.m10 = -2f * plane[1] * plane[0];
			reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
			reflectionMat.m12 = -2f * plane[1] * plane[2];
			reflectionMat.m13 = -2f * plane[3] * plane[1];
			reflectionMat.m20 = -2f * plane[2] * plane[0];
			reflectionMat.m21 = -2f * plane[2] * plane[1];
			reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
			reflectionMat.m23 = -2f * plane[3] * plane[2];
			reflectionMat.m30 = 0f;
			reflectionMat.m31 = 0f;
			reflectionMat.m32 = 0f;
			reflectionMat.m33 = 1f;
		}
	}
}
