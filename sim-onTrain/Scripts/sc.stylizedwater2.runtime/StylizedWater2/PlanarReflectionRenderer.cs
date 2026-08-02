using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace StylizedWater2
{
	[ExecuteInEditMode]
	[AddComponentMenu("Stylized Water 2/Planar Reflection Renderer")]
	[HelpURL("https://staggart.xyz/unity/stylized-water-2/sws-2-docs/?section=planar-reflections")]
	public class PlanarReflectionRenderer : MonoBehaviour
	{
		public static List<PlanarReflectionRenderer> Instances = new List<PlanarReflectionRenderer>();

		public Dictionary<Camera, Camera> reflectionCameras = new Dictionary<Camera, Camera>();

		[Tooltip("Set the layers that should be rendered into the reflection. The \"Water\" layer is always excluded")]
		public LayerMask cullingMask = -1;

		[Tooltip("The renderer used by the reflection camera. It's recommend to create a separate renderer, so any custom render features aren't executed for the reflection")]
		public int rendererIndex = -1;

		[Min(0f)]
		public float offset = 0.05f;

		[Tooltip("When disabled, the skybox reflection comes from a Reflection Probe. This has the benefit of being omni-directional rather than flat/planar. Enabled this to render the skybox into the planar reflection anyway")]
		public bool includeSkybox;

		public bool renderShadows;

		[Tooltip("Objects beyond this range aren't rendered into the reflection. Note that this may causes popping for large/tall objects.")]
		public float renderRange = 500f;

		[Range(0.25f, 1f)]
		[Tooltip("A multiplier for the rendering resolution, based on the current screen resolution")]
		public float renderScale = 0.75f;

		[Range(0f, 4f)]
		[Tooltip("Do not render LOD objects lower than this value. Example: With a value of 1, LOD0 for LOD Groups will not be used")]
		public int maximumLODLevel;

		[SerializeField]
		public List<WaterObject> waterObjects = new List<WaterObject>();

		[Tooltip("If enabled, the center of the rendering bounds (that wraps around the water objects) moves with the Transform position")]
		public bool moveWithTransform;

		[HideInInspector]
		public Bounds bounds;

		private Camera reflectionCamera;

		private float m_renderScale = 1f;

		private float m_renderRange;

		private static bool m_allowReflections = true;

		private static readonly int _PlanarReflectionsEnabledID = Shader.PropertyToID("_PlanarReflectionsEnabled");

		private static readonly int _PlanarReflectionLeftID = Shader.PropertyToID("_PlanarReflectionLeft");

		private static UniversalAdditionalCameraData cameraData;

		private UniversalRenderPipeline.SingleCameraRequest requestData = new UniversalRenderPipeline.SingleCameraRequest();

		[NonSerialized]
		public bool isRendering;

		private static readonly Plane[] frustrumPlanes = new Plane[6];

		private static Vector4 reflectionPlane;

		private static Matrix4x4 reflectionBase;

		private static Vector3 oldCamPos;

		private static Matrix4x4 worldToCamera;

		private static Matrix4x4 viewMatrix;

		private static Matrix4x4 projectionMatrix;

		private static Vector4 clipPlane;

		private static readonly float[] layerCullDistances = new float[32];

		public static bool AllowReflections => m_allowReflections;

		private void Reset()
		{
			base.gameObject.name = "Planar Reflection Renderer";
		}

		private void OnEnable()
		{
			InitializeValues();
			Instances.Add(this);
			EnableReflections();
		}

		private void OnDisable()
		{
			Instances.Remove(this);
			DisableReflections();
		}

		public void InitializeValues()
		{
			m_renderScale = renderScale;
			m_renderRange = renderRange;
		}

		public void ApplyToAllWaterInstances()
		{
			waterObjects = new List<WaterObject>(WaterObject.Instances);
			RecalculateBounds();
			EnableMaterialReflectionSampling();
		}

		public static void SetQuality(bool enableReflections, float renderScale = -1f, float renderRange = -1f, int maxLodLevel = -1)
		{
			m_allowReflections = enableReflections;
			foreach (PlanarReflectionRenderer instance in Instances)
			{
				if (renderScale > 0f)
				{
					instance.renderScale = renderScale;
				}
				if (renderRange > 0f)
				{
					instance.renderRange = renderRange;
				}
				if (maxLodLevel >= 0)
				{
					instance.maximumLODLevel = maxLodLevel;
				}
				instance.InitializeValues();
				if (enableReflections)
				{
					instance.EnableReflections();
				}
				if (!enableReflections)
				{
					instance.DisableReflections();
				}
			}
		}

		public void EnableReflections()
		{
			if (AllowReflections && !XRGraphics.enabled)
			{
				RenderPipelineManager.beginCameraRendering += OnWillRenderCamera;
				ToggleMaterialReflectionSampling(state: true);
			}
		}

		public void DisableReflections()
		{
			RenderPipelineManager.beginCameraRendering -= OnWillRenderCamera;
			ToggleMaterialReflectionSampling(state: false);
			foreach (KeyValuePair<Camera, Camera> reflectionCamera in reflectionCameras)
			{
				if (!(reflectionCamera.Value == null) && (bool)reflectionCamera.Value)
				{
					RenderTexture.ReleaseTemporary(reflectionCamera.Value.targetTexture);
					UnityEngine.Object.DestroyImmediate(reflectionCamera.Value.gameObject);
				}
			}
			reflectionCameras.Clear();
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = ((bounds.size.y > 0.01f) ? Color.yellow : Color.white);
			Gizmos.DrawWireCube(bounds.center, bounds.size);
		}

		public Bounds CalculateBounds()
		{
			Bounds result = new Bounds(Vector3.zero, Vector3.zero);
			if (waterObjects == null)
			{
				return result;
			}
			if (waterObjects.Count == 0)
			{
				return result;
			}
			Vector3 vector = Vector3.one * float.PositiveInfinity;
			Vector3 vector2 = Vector3.one * float.NegativeInfinity;
			for (int i = 0; i < waterObjects.Count; i++)
			{
				if ((bool)waterObjects[i])
				{
					vector = Vector3.Min(waterObjects[i].meshRenderer.bounds.min, vector);
					vector2 = Vector3.Max(waterObjects[i].meshRenderer.bounds.max, vector2);
				}
			}
			result.SetMinMax(vector, vector2);
			result.size = new Vector3(result.size.x, 0f, result.size.z);
			return result;
		}

		public void RecalculateBounds()
		{
			bounds = CalculateBounds();
		}

		private void OnWillRenderCamera(ScriptableRenderContext context, Camera camera)
		{
			if (camera.cameraType != CameraType.SceneView && (camera.cameraType == CameraType.Reflection || camera.cameraType == CameraType.Preview || camera.hideFlags != HideFlags.None))
			{
				return;
			}
			if (moveWithTransform)
			{
				bounds.center = base.transform.position;
			}
			isRendering = IsVisible(camera);
			if (!isRendering)
			{
				return;
			}
			cameraData = camera.GetComponent<UniversalAdditionalCameraData>();
			if ((bool)cameraData && cameraData.renderType == CameraRenderType.Overlay)
			{
				return;
			}
			reflectionCameras.TryGetValue(camera, out reflectionCamera);
			if (reflectionCamera == null)
			{
				CreateReflectionCamera(camera);
			}
			if ((bool)reflectionCamera)
			{
				if (renderScale != m_renderScale)
				{
					RenderTexture.ReleaseTemporary(reflectionCamera.targetTexture);
					CreateRenderTexture(reflectionCamera, camera);
					m_renderScale = renderScale;
				}
				UpdateWaterProperties(reflectionCamera);
				UpdateCameraProperties(camera, reflectionCamera);
				UpdatePerspective(camera, reflectionCamera);
				bool fog = RenderSettings.fog;
				if (fog)
				{
					RenderSettings.fog = false;
				}
				int num = QualitySettings.maximumLODLevel;
				QualitySettings.maximumLODLevel = maximumLODLevel;
				GL.invertCulling = true;
				requestData.destination = reflectionCamera.targetTexture;
				requestData.slice = -1;
				UniversalRenderPipeline.RenderSingleCamera(context, reflectionCamera);
				if (fog)
				{
					RenderSettings.fog = true;
				}
				QualitySettings.maximumLODLevel = num;
				GL.invertCulling = false;
			}
		}

		private float GetRenderScale()
		{
			return Mathf.Clamp(renderScale * UniversalRenderPipeline.asset.renderScale, 0.25f, 1f);
		}

		public void SetRendererIndex(int index)
		{
			index = PipelineUtilities.ValidateRenderer(index);
			foreach (KeyValuePair<Camera, Camera> reflectionCamera in reflectionCameras)
			{
				if (!(reflectionCamera.Value == null))
				{
					cameraData = reflectionCamera.Value.GetComponent<UniversalAdditionalCameraData>();
					cameraData.SetRenderer(index);
				}
			}
		}

		public void ToggleShadows(bool state)
		{
			foreach (KeyValuePair<Camera, Camera> reflectionCamera in reflectionCameras)
			{
				if (!(reflectionCamera.Value == null))
				{
					cameraData = reflectionCamera.Value.GetComponent<UniversalAdditionalCameraData>();
					cameraData.renderShadows = state;
				}
			}
		}

		public void AddWaterObject(WaterObject waterObject)
		{
			ToggleMaterialReflectionSampling(waterObject, state: true);
			waterObjects.Add(waterObject);
			RecalculateBounds();
		}

		public void RemoveWaterObject(WaterObject waterObject)
		{
			ToggleMaterialReflectionSampling(waterObject, state: false);
			waterObjects.Remove(waterObject);
			RecalculateBounds();
		}

		public void EnableMaterialReflectionSampling()
		{
			ToggleMaterialReflectionSampling(m_allowReflections);
		}

		public void ToggleMaterialReflectionSampling(bool state)
		{
			if (waterObjects == null)
			{
				return;
			}
			for (int i = 0; i < waterObjects.Count; i++)
			{
				if (!(waterObjects[i] == null))
				{
					ToggleMaterialReflectionSampling(waterObjects[i], state);
				}
			}
		}

		private void ToggleMaterialReflectionSampling(WaterObject waterObject, bool state)
		{
			waterObject.props.SetFloat(_PlanarReflectionsEnabledID, state ? 1f : 0f);
			waterObject.ApplyInstancedProperties();
		}

		private void CreateReflectionCamera(Camera source)
		{
			Camera camera = new GameObject(source.name + "_reflection")
			{
				hideFlags = (HideFlags.DontSave | HideFlags.HideInHierarchy)
			}.AddComponent<Camera>();
			camera.hideFlags = HideFlags.DontSave;
			camera.CopyFrom(source);
			camera.cullingMask = -17 & (int)cullingMask;
			camera.cameraType = CameraType.Game;
			camera.depth = source.depth - 1f;
			camera.rect = new Rect(0f, 0f, 1f, 1f);
			camera.enabled = false;
			camera.clearFlags = (includeSkybox ? CameraClearFlags.Skybox : CameraClearFlags.Depth);
			camera.backgroundColor = Color.clear;
			camera.useOcclusionCulling = false;
			UniversalAdditionalCameraData universalAdditionalCameraData = camera.gameObject.AddComponent<UniversalAdditionalCameraData>();
			universalAdditionalCameraData.requiresDepthTexture = false;
			universalAdditionalCameraData.requiresColorTexture = false;
			universalAdditionalCameraData.renderShadows = renderShadows;
			rendererIndex = PipelineUtilities.ValidateRenderer(rendererIndex);
			universalAdditionalCameraData.SetRenderer(rendererIndex);
			CreateRenderTexture(camera, source);
			reflectionCameras[source] = camera;
		}

		private void CreateRenderTexture(Camera targetCamera, Camera source)
		{
			RenderTextureFormat format = ((UniversalRenderPipeline.asset.supportsHDR && SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.DefaultHDR)) ? RenderTextureFormat.DefaultHDR : RenderTextureFormat.Default);
			float num = GetRenderScale();
			targetCamera.targetTexture = RenderTexture.GetTemporary(Mathf.RoundToInt((float)source.scaledPixelWidth * num), Mathf.RoundToInt((float)source.scaledPixelHeight * num), 16, format);
		}

		private bool IsVisible(Camera targetCamera)
		{
			GeometryUtility.CalculateFrustumPlanes(targetCamera.projectionMatrix * targetCamera.worldToCameraMatrix, frustrumPlanes);
			return GeometryUtility.TestPlanesAABB(frustrumPlanes, bounds);
		}

		private void UpdateWaterProperties(Camera cam)
		{
			for (int i = 0; i < waterObjects.Count; i++)
			{
				if (!(waterObjects[i] == null))
				{
					waterObjects[i].props.SetTexture(_PlanarReflectionLeftID, cam.targetTexture);
					waterObjects[i].ApplyInstancedProperties();
				}
			}
		}

		private void UpdateCameraProperties(Camera source, Camera reflectionCam)
		{
			reflectionCam.fieldOfView = source.fieldOfView;
			reflectionCam.orthographic = source.orthographic;
			reflectionCam.orthographicSize = source.orthographicSize;
			reflectionCam.useOcclusionCulling = source.useOcclusionCulling;
		}

		private void UpdatePerspective(Camera source, Camera reflectionCam)
		{
			if (!source || !reflectionCam)
			{
				return;
			}
			Vector3 vector = bounds.center + Vector3.up * offset;
			float w = 0f - Vector3.Dot(Vector3.up, vector);
			reflectionPlane = new Vector4(Vector3.up.x, Vector3.up.y, Vector3.up.z, w);
			reflectionBase = Matrix4x4.identity;
			reflectionBase *= Matrix4x4.Scale(new Vector3(1f, -1f, 1f));
			CalculateReflectionMatrix(ref reflectionBase, reflectionPlane);
			oldCamPos = source.transform.position - new Vector3(0f, vector.y * 2f, 0f);
			reflectionCam.transform.forward = Vector3.Scale(source.transform.forward, new Vector3(1f, -1f, 1f));
			worldToCamera = source.worldToCameraMatrix;
			viewMatrix = worldToCamera * reflectionBase;
			oldCamPos.y = 0f - oldCamPos.y;
			reflectionCam.transform.position = oldCamPos;
			clipPlane = CameraSpacePlane(reflectionCam.worldToCameraMatrix, vector - Vector3.up * 0.1f, Vector3.up, 1f);
			projectionMatrix = source.CalculateObliqueMatrix(clipPlane);
			reflectionCam.cullingMask = -17 & (int)cullingMask;
			reflectionCamera.clearFlags = (includeSkybox ? CameraClearFlags.Skybox : CameraClearFlags.Depth);
			if (m_renderRange != renderRange)
			{
				m_renderRange = renderRange;
				for (int i = 0; i < layerCullDistances.Length; i++)
				{
					layerCullDistances[i] = renderRange;
				}
			}
			reflectionCam.projectionMatrix = projectionMatrix;
			reflectionCam.worldToCameraMatrix = viewMatrix;
			reflectionCam.layerCullDistances = layerCullDistances;
			reflectionCam.layerCullSpherical = true;
		}

		private void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
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

		private Vector4 CameraSpacePlane(Matrix4x4 worldToCameraMatrix, Vector3 pos, Vector3 normal, float sideSign)
		{
			Vector3 point = pos + normal * offset;
			Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
			Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
			return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
		}
	}
}
