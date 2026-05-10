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
		public static List<PlanarReflectionRenderer> Instances;

		public Dictionary<Camera, Camera> reflectionCameras;

		[Tooltip("If enabled, the reflection plane will be based on this transform's up vector (green arrow).\n\nOtherwise the world's upwards direction is assumed")]
		public bool rotatable;

		[Tooltip("Set the layers that should be rendered into the reflection. The \"Water\" layer is always excluded")]
		public LayerMask cullingMask;

		[Tooltip("The renderer used by the reflection camera. It's recommend to create a separate renderer, so any custom render features aren't executed for the reflection")]
		public int rendererIndex;

		[Min(0f)]
		public float offset;

		[Tooltip("When disabled, the skybox reflection comes from a Reflection Probe. This has the benefit of being omni-directional rather than flat/planar. Enabled this to render the skybox into the planar reflection anyway.\n\nNote that enabling this will override Screen Space Reflections completely!")]
		public bool includeSkybox;

		[Tooltip("Render Unity's default scene fog in the reflection. Note that this doesn't strictly work correctly on large triangles, as it is incompatible with oblique camera projections.\n\nThis does not include to post-processing fog effects!")]
		public bool enableFog;

		public bool renderShadows;

		[Tooltip("Objects beyond this range aren't rendered into the reflection. Note that this may causes popping for large/tall objects.")]
		public float renderRange;

		[Tooltip("A multiplier for the rendering resolution, based on the current screen resolution. The render scale, as configured in the pipeline settings is multiplied over this.")]
		[Range(0.25f, 1f)]
		public float renderScale;

		[Tooltip("Do not render LOD objects lower than this value. Example: With a value of 1, LOD0 for LOD Groups will not be used")]
		[Range(0f, 4f)]
		public int maximumLODLevel;

		[SerializeField]
		public List<WaterObject> waterObjects;

		[Tooltip("If enabled, the center of the rendering bounds (that wraps around the water objects) moves with the Transform position\n\nYou must however ensure you are only moving on the XZ axis")]
		public bool moveWithTransform;

		[HideInInspector]
		public Bounds bounds;

		private float m_renderScale;

		private float m_renderRange;

		private static readonly int _PlanarReflectionsEnabledID;

		private static readonly int _PlanarReflectionID;

		[NonSerialized]
		public bool isRendering;

		private Camera m_reflectionCamera;

		private static UniversalAdditionalCameraData m_cameraData;

		private static readonly Plane[] frustrumPlanes;

		private static Vector4 reflectionPlane;

		private static Matrix4x4 reflectionBase;

		private static Vector3 oldCamPos;

		private static Matrix4x4 worldToCamera;

		private static Matrix4x4 viewMatrix;

		private static Matrix4x4 projectionMatrix;

		private static Vector4 clipPlane;

		private static readonly float[] layerCullDistances;

		public static bool AllowReflections { get; private set; }

		private void Reset()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void InitializeValues()
		{
		}

		public void ApplyToAllWaterInstances()
		{
		}

		public static void SetQuality(bool enableReflections, float renderScale = -1f, float renderRange = -1f, int maxLodLevel = -1)
		{
		}

		public void EnableReflections()
		{
		}

		public void DisableReflections()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public Bounds CalculateBounds()
		{
			return default(Bounds);
		}

		public void RecalculateBounds()
		{
		}

		public static bool InvalidContext(Camera camera)
		{
			return false;
		}

		private void OnWillRenderCamera(ScriptableRenderContext context, Camera camera)
		{
		}

		private void RenderReflection(ScriptableRenderContext context, Camera target)
		{
		}

		private void SetFogState(bool value)
		{
		}

		private float GetRenderScale()
		{
			return 0f;
		}

		public void SetRendererIndex(int index)
		{
		}

		public void ToggleShadows(bool state)
		{
		}

		public void AddWaterObject(WaterObject waterObject)
		{
		}

		public void RemoveWaterObject(WaterObject waterObject)
		{
		}

		public void EnableMaterialReflectionSampling()
		{
		}

		public void ToggleMaterialReflectionSampling(bool state)
		{
		}

		private void ToggleMaterialReflectionSampling(WaterObject waterObject, bool state)
		{
		}

		private void CreateReflectionCamera(Camera source)
		{
		}

		private void CreateRenderTexture(Camera targetCamera, Camera source)
		{
		}

		public bool WaterObjectsVisible(Camera targetCamera)
		{
			return false;
		}

		private void UpdateWaterProperties(Camera cam)
		{
		}

		private void UpdateCameraProperties(Camera source, Camera reflectionCam)
		{
		}

		private void UpdatePerspective(Camera source, Camera reflectionCam)
		{
		}

		private void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
		{
		}

		private Vector4 CameraSpacePlane(Matrix4x4 worldToCameraMatrix, Vector3 pos, Vector3 normal, float sideSign)
		{
			return default(Vector4);
		}

		public RenderTexture TryGetReflectionTexture(Camera targetCamera)
		{
			return null;
		}
	}
}
