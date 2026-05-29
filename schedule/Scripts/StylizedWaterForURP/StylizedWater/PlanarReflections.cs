using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace StylizedWater
{
	[HelpURL("https://alexander-ameye.gitbook.io/stylized-water/")]
	[AddComponentMenu("Effects/Planar Reflections")]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	public class PlanarReflections : MonoBehaviour
	{
		private class PlanarReflectionSettingData
		{
			private readonly bool fog;

			private readonly int maximumLODLevel;

			private readonly float lodBias;

			public void Set()
			{
			}

			public void Restore()
			{
			}
		}

		[Range(0.01f, 1f)]
		public float renderScale;

		public LayerMask reflectionLayer;

		public bool reflectSkybox;

		public GameObject reflectionTarget;

		[Range(-2f, 3f)]
		public float reflectionPlaneOffset;

		private static Camera _reflectionCamera;

		private UniversalAdditionalCameraData cameraData;

		private static RenderTexture _reflectionTexture;

		private RenderTextureDescriptor previousDescriptor;

		private readonly int _planarReflectionTextureId;

		public bool hideReflectionCamera;

		public static event Action<ScriptableRenderContext, Camera> BeginPlanarReflections
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void CleanUp()
		{
		}

		private void SafeDestroyObject(UnityEngine.Object obj)
		{
		}

		private void UpdateReflectionCamera(Camera realCamera)
		{
		}

		private void UpdateCamera(Camera src, Camera dest)
		{
		}

		private Camera InitializeReflectionCamera()
		{
			return null;
		}

		private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign)
		{
			return default(Vector4);
		}

		private RenderTextureDescriptor GetDescriptor(Camera camera, float pipelineRenderScale)
		{
			return default(RenderTextureDescriptor);
		}

		private void CreateReflectionTexture(Camera camera)
		{
		}

		private void DoPlanarReflections(ScriptableRenderContext context, Camera camera)
		{
		}

		public static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMatrix, Vector4 plane)
		{
		}

		public static Vector3 ReflectPosition(Vector3 pos)
		{
			return default(Vector3);
		}

		public static bool Compare(Vector2 a, Vector2 b)
		{
			return false;
		}
	}
}
