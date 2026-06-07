using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Unified.UniversalBlur.Runtime
{
	public class UniversalBlurFeature : ScriptableRendererFeature
	{
		[Header("Blur Settings")]
		[Range(1f, 8f)]
		[SerializeField]
		private int iterations;

		[Range(0f, 1f)]
		[SerializeField]
		public float intensity;

		[Range(1f, 10f)]
		[SerializeField]
		private float downsample;

		[Range(0f, 10f)]
		[SerializeField]
		private float scale;

		[Range(0f, 10f)]
		[SerializeField]
		private float offset;

		[Space]
		[Header("Advanced Settings")]
		[SerializeField]
		private ScaleBlurWith scaleBlurWith;

		[SerializeField]
		private float scaleReferenceSize;

		[Space]
		[SerializeField]
		[ShowAsPass("_material")]
		public int shaderPass;

		[Tooltip("For Overlay Canvas: AfterRenderingPostProcessing\n\nOther: BeforeRenderingTransparents (will hide transparents)")]
		[SerializeField]
		private RenderPassEvent injectionPoint;

		[SerializeField]
		[HideInInspector]
		[Reload("Shaders/Blur.shader", ReloadAttribute.Package.Root)]
		private Shader shader;

		private Material _material;

		private UniversalBlurPass _blurPass;

		private float _renderScale;

		public override void Create()
		{
		}

		public override void OnCameraPreCull(ScriptableRenderer renderer, in CameraData cameraData)
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private bool TrySetShadersAndMaterials()
		{
			return false;
		}

		private BlurPassData GetBlurPassData(in RenderingData renderingData)
		{
			return default(BlurPassData);
		}

		private (int, int) GetTargetResolution(in RenderingData renderingData)
		{
			return default((int, int));
		}

		private float CalculateScale()
		{
			return 0f;
		}
	}
}
