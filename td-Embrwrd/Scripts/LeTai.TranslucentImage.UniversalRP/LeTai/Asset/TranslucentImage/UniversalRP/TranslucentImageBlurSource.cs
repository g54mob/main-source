using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting.APIUpdating;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	[MovedFrom("LeTai.Asset.TranslucentImage.LWRP")]
	public class TranslucentImageBlurSource : ScriptableRendererFeature
	{
		public enum RenderOrder
		{
			AfterPostProcessing = 0,
			BeforePostProcessing = 1
		}

		public RenderOrder renderOrder;

		public bool canvasDisappearWorkaround;

		internal RendererType rendererType;

		private readonly Dictionary<Camera, TranslucentImageSource> blurSourceCache;

		private readonly Dictionary<Camera, Camera> baseCameraCache;

		private URPRendererInternal urpRendererInternal;

		private TranslucentImageBlurRenderPass pass;

		private IBlurAlgorithm blurAlgorithm;

		private Material previewMaterial;

		private readonly FieldInfo cameraDataPixelRectField;

		private Material PreviewMaterial => null;

		public void RegisterSource(TranslucentImageSource source)
		{
		}

		public override void Create()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		private void SetupSRP(ScriptableRenderer renderer)
		{
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		private TranslucentImageSource GetBlurSource(Camera camera)
		{
			return null;
		}

		private Camera GetBaseCamera(Camera camera)
		{
			return null;
		}

		public Rect GetPixelRect(CameraData cameraData)
		{
			return default(Rect);
		}
	}
}
