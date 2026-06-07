using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace ToonyColorsPro.Runtime
{
	[ExecuteInEditMode]
	public class TCP2_PlanarReflection : MonoBehaviour
	{
		public int textureSize = 1024;

		public RenderTextureFormat renderTextureFormat = RenderTextureFormat.Default;

		public LayerMask reflectLayers = -1;

		public bool disablePixelLights;

		public float clipPlaneOffset = 0.07f;

		[Space]
		public bool useCustomBackgroundColor;

		public Color backgroundColor = Color.black;

		[Space]
		public bool applyBlur;

		public Shader blurShader;

		[Range(1f, 4f)]
		public int blurIterations = 1;

		[Range(1f, 8f)]
		public float blurDistance = 1f;

		private bool useBlurDepth;

		private float blurDepthRange = 2f;

		private Camera reflectionCamera;

		private RenderTexture reflectionRenderTexture;

		private Material blurMaterial;

		private CommandBuffer commandBufferBlur;

		private Shader reflectionDepthShader;

		private RenderTexture reflectionDepthRenderTexture;

		private bool isURP;

		private static bool s_InsideRendering;

		private static int _ShaderID_ReflectionTex = -1;

		private static int _ShaderID_ReflectionDepthTex = -1;

		private static int _ShaderID_ReflectivePlaneY = -1;

		private static int _ShaderID_ReflectionDepthRange = -1;

		private static int _ShaderID_UseReflectionDepth = -1;

		private static int ShaderID_ReflectionTex
		{
			get
			{
				if (_ShaderID_ReflectionTex < 0)
				{
					_ShaderID_ReflectionTex = Shader.PropertyToID("_ReflectionTex");
				}
				return _ShaderID_ReflectionTex;
			}
		}

		private static int ShaderID_ReflectionDepthTex
		{
			get
			{
				if (_ShaderID_ReflectionDepthTex < 0)
				{
					_ShaderID_ReflectionDepthTex = Shader.PropertyToID("_ReflectionDepthTex");
				}
				return _ShaderID_ReflectionDepthTex;
			}
		}

		private static int ShaderID_ReflectivePlaneY
		{
			get
			{
				if (_ShaderID_ReflectivePlaneY < 0)
				{
					_ShaderID_ReflectivePlaneY = Shader.PropertyToID("_ReflectivePlaneY");
				}
				return _ShaderID_ReflectivePlaneY;
			}
		}

		private static int ShaderID_ReflectionDepthRange
		{
			get
			{
				if (_ShaderID_ReflectionDepthRange < 0)
				{
					_ShaderID_ReflectionDepthRange = Shader.PropertyToID("_ReflectionDepthRange");
				}
				return _ShaderID_ReflectionDepthRange;
			}
		}

		private static int ShaderID_UseReflectionDepth
		{
			get
			{
				if (_ShaderID_UseReflectionDepth < 0)
				{
					_ShaderID_UseReflectionDepth = Shader.PropertyToID("_UseReflectionDepth");
				}
				return _ShaderID_UseReflectionDepth;
			}
		}

		private void OnValidate()
		{
			UpdateRenderTexture();
			UpdateCommandBuffer();
		}

		private void OnEnable()
		{
			isURP = GraphicsSettings.currentRenderPipeline != null && GraphicsSettings.currentRenderPipeline.GetType().Name.Contains("Universal");
			if (isURP)
			{
				RenderPipelineManager.beginCameraRendering += BeginCameraRendering_URP;
			}
			else
			{
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(BeginCameraRendering_Bultin));
			}
			UpdateRenderTexture();
			UpdateCommandBuffer();
		}

		private void OnDisable()
		{
			if (isURP)
			{
				RenderPipelineManager.beginCameraRendering -= BeginCameraRendering_URP;
			}
			else
			{
				Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(BeginCameraRendering_Bultin));
			}
			ClearCommandBuffer();
			ClearRenderTexture();
		}

		private void UpdateRenderTexture()
		{
			if (reflectionRenderTexture != null)
			{
				ClearRenderTexture();
			}
			reflectionRenderTexture = new RenderTexture(textureSize, textureSize, 16, renderTextureFormat, RenderTextureReadWrite.sRGB);
			reflectionRenderTexture.name = "Planar Reflection for " + GetInstanceID();
			reflectionRenderTexture.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
		}

		private void ClearRenderTexture()
		{
			if (reflectionRenderTexture != null)
			{
				reflectionRenderTexture.Release();
				UnityEngine.Object.DestroyImmediate(reflectionRenderTexture);
			}
		}

		private void UpdateCommandBuffer()
		{
			if (commandBufferBlur != null)
			{
				ClearCommandBuffer();
			}
			if (!applyBlur)
			{
				return;
			}
			if (blurMaterial == null)
			{
				if (blurShader == null)
				{
					Debug.LogError("[TCP2 Planar Reflection] Can't find Gaussian Blur Filter shader!", base.gameObject);
					return;
				}
				blurMaterial = new Material(blurShader);
				blurMaterial.name = "Planar Reflection Blur";
			}
			blurMaterial.SetFloat("_SamplingDistance", blurDistance);
			if (!(reflectionRenderTexture == null) && !(reflectionCamera == null))
			{
				commandBufferBlur = new CommandBuffer();
				int num = Shader.PropertyToID("_PlanarReflectionTempRT");
				commandBufferBlur.GetTemporaryRT(num, textureSize, textureSize, 16, FilterMode.Bilinear, reflectionRenderTexture.format, RenderTextureReadWrite.sRGB);
				commandBufferBlur.CopyTexture(reflectionRenderTexture, num);
				commandBufferBlur.Blit(num, reflectionRenderTexture, blurMaterial, 0);
				for (int i = 0; i < blurIterations; i++)
				{
					commandBufferBlur.Blit(reflectionRenderTexture, num, blurMaterial, 1);
					commandBufferBlur.Blit(num, reflectionRenderTexture, blurMaterial, 2);
				}
				commandBufferBlur.ReleaseTemporaryRT(num);
				reflectionCamera.AddCommandBuffer(CameraEvent.AfterEverything, commandBufferBlur);
			}
		}

		private void ClearCommandBuffer()
		{
			if (reflectionCamera != null && reflectionCamera.commandBufferCount > 0)
			{
				reflectionCamera.RemoveCommandBuffer(CameraEvent.AfterEverything, commandBufferBlur);
			}
			if (commandBufferBlur != null)
			{
				commandBufferBlur.Clear();
				commandBufferBlur.Release();
				commandBufferBlur = null;
			}
		}

		public void BeginCameraRendering_Bultin(Camera camera)
		{
			if ((camera.cameraType & (CameraType.Game | CameraType.SceneView)) != 0)
			{
				if (reflectionCamera == null)
				{
					GameObject gameObject = new GameObject("Planar Reflection Camera", typeof(Camera));
					reflectionCamera = gameObject.GetComponent<Camera>();
					reflectionCamera.enabled = false;
					gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
					UpdateRenderTexture();
					UpdateCommandBuffer();
					reflectionCamera.targetTexture = reflectionRenderTexture;
				}
				RenderPlanarReflection(camera);
			}
		}

		public void BeginCameraRendering_URP(ScriptableRenderContext context, Camera camera)
		{
			if ((camera.cameraType & (CameraType.Game | CameraType.SceneView)) != 0)
			{
				if (reflectionCamera == null)
				{
					GameObject gameObject = new GameObject("Planar Reflection Camera", typeof(Camera));
					reflectionCamera = gameObject.GetComponent<Camera>();
					reflectionCamera.enabled = false;
					gameObject.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
					UpdateRenderTexture();
					UpdateCommandBuffer();
					reflectionCamera.targetTexture = reflectionRenderTexture;
				}
				RenderPlanarReflection(camera);
			}
		}

		public void RenderPlanarReflection(Camera worldCamera)
		{
			if (worldCamera == null)
			{
				return;
			}
			Renderer component = GetComponent<Renderer>();
			if (!base.enabled || !component || !component.sharedMaterial || !component.enabled || s_InsideRendering)
			{
				return;
			}
			s_InsideRendering = true;
			Vector3 position = base.transform.position;
			Vector3 up = base.transform.up;
			int pixelLightCount = QualitySettings.pixelLightCount;
			if (disablePixelLights)
			{
				QualitySettings.pixelLightCount = 0;
			}
			reflectionCamera.CopyFrom(worldCamera);
			if (useCustomBackgroundColor)
			{
				reflectionCamera.clearFlags = CameraClearFlags.Color;
				reflectionCamera.backgroundColor = backgroundColor;
			}
			float w = 0f - Vector3.Dot(up, position) - clipPlaneOffset;
			Vector4 plane = new Vector4(up.x, up.y, up.z, w);
			Matrix4x4 reflectionMat = Matrix4x4.zero;
			CalculateReflectionMatrix(ref reflectionMat, plane);
			Vector3 position2 = worldCamera.transform.position;
			Vector3 position3 = reflectionMat.MultiplyPoint(position2);
			reflectionCamera.worldToCameraMatrix = worldCamera.worldToCameraMatrix * reflectionMat;
			Vector4 clipPlane = CameraSpacePlane(reflectionCamera, position, up, 1f);
			Matrix4x4 projectionMatrix = worldCamera.CalculateObliqueMatrix(clipPlane);
			reflectionCamera.projectionMatrix = projectionMatrix;
			reflectionCamera.targetTexture = reflectionRenderTexture;
			reflectionCamera.cullingMask = ~(1 << base.gameObject.layer) & reflectLayers.value;
			GL.invertCulling = true;
			reflectionCamera.transform.position = position3;
			Vector3 eulerAngles = worldCamera.transform.eulerAngles;
			reflectionCamera.transform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
			if (applyBlur && useBlurDepth)
			{
				if (reflectionDepthShader == null)
				{
					reflectionDepthShader = Shader.Find("Hidden/TCP2 Planar Reflection Depth");
				}
				if (reflectionDepthRenderTexture == null)
				{
					reflectionDepthRenderTexture = new RenderTexture(textureSize, textureSize, 16, RenderTextureFormat.RHalf, RenderTextureReadWrite.Linear);
					blurMaterial.SetTexture(ShaderID_ReflectionDepthTex, reflectionDepthRenderTexture);
				}
				RenderTexture targetTexture = reflectionCamera.targetTexture;
				reflectionCamera.targetTexture = reflectionDepthRenderTexture;
				reflectionCamera.RenderWithShader(reflectionDepthShader, null);
				reflectionCamera.targetTexture = targetTexture;
				blurMaterial.SetFloat(ShaderID_ReflectivePlaneY, base.transform.position.y + clipPlaneOffset);
				blurMaterial.SetFloat(ShaderID_ReflectionDepthRange, blurDepthRange);
				blurMaterial.SetFloat(ShaderID_UseReflectionDepth, 1f);
			}
			else if (applyBlur && !useBlurDepth)
			{
				blurMaterial.SetFloat(ShaderID_UseReflectionDepth, 0f);
			}
			else if (reflectionDepthRenderTexture != null)
			{
				reflectionDepthRenderTexture.Release();
				reflectionDepthRenderTexture = null;
			}
			reflectionCamera.Render();
			reflectionCamera.transform.position = position2;
			GL.invertCulling = false;
			Material[] sharedMaterials = component.sharedMaterials;
			foreach (Material material in sharedMaterials)
			{
				if (material.HasProperty(ShaderID_ReflectionTex))
				{
					material.SetTexture(ShaderID_ReflectionTex, reflectionRenderTexture);
				}
				if (material.HasProperty(ShaderID_ReflectionDepthTex))
				{
					material.SetTexture(ShaderID_ReflectionDepthTex, reflectionDepthRenderTexture);
				}
			}
			if (disablePixelLights)
			{
				QualitySettings.pixelLightCount = pixelLightCount;
			}
			s_InsideRendering = false;
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
