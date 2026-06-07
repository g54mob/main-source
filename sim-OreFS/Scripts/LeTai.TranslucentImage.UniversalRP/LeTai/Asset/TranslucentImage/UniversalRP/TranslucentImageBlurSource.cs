using System.Collections.Generic;
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

		private readonly Dictionary<Camera, TranslucentImageSource> blurSourceCache = new Dictionary<Camera, TranslucentImageSource>();

		private readonly Dictionary<Camera, Camera> baseCameraCache = new Dictionary<Camera, Camera>();

		private URPRendererInternal urpRendererInternal;

		private TranslucentImageBlurRenderPass pass;

		private IBlurAlgorithm blurAlgorithm;

		public void RegisterSource(TranslucentImageSource source)
		{
			blurSourceCache[source.GetComponent<Camera>()] = source;
		}

		public override void Create()
		{
			blurAlgorithm = new ScalableBlur();
			urpRendererInternal = new URPRendererInternal();
			RenderPassEvent renderPassEvent = ((renderOrder == RenderOrder.BeforePostProcessing) ? RenderPassEvent.BeforeRenderingPostProcessing : RenderPassEvent.AfterRenderingPostProcessing);
			pass = new TranslucentImageBlurRenderPass(urpRendererInternal)
			{
				renderPassEvent = renderPassEvent
			};
			blurSourceCache.Clear();
		}

		private void SetupSRP(ScriptableRenderer renderer)
		{
			urpRendererInternal.CacheRenderer(renderer);
			if (renderer is UniversalRenderer)
			{
				rendererType = RendererType.Universal;
			}
			else
			{
				rendererType = RendererType.Renderer2D;
			}
			pass.SetupSRP(new TranslucentImageBlurRenderPass.SRPassData
			{
				canvasDisappearWorkaround = canvasDisappearWorkaround
			});
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
			if (!(GetBlurSource(renderingData.cameraData.camera) == null))
			{
				SetupSRP(renderer);
			}
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			CameraData cameraData = renderingData.cameraData;
			if (cameraData.cameraType == CameraType.Game)
			{
				Camera camera = renderingData.cameraData.camera;
				TranslucentImageSource blurSource = GetBlurSource(camera);
				if (!(blurSource == null) && !(blurSource.BlurConfig == null))
				{
					blurSource.CamRectOverride = Rect.zero;
					blurAlgorithm.Init(blurSource.BlurConfig, isBirp: false);
					pass.Setup(new TranslucentImageBlurRenderPass.PassData
					{
						blurAlgorithm = blurAlgorithm,
						blurSource = blurSource,
						camPixelSize = Vector2Int.RoundToInt(GetPixelSize(cameraData).size),
						shouldUpdateBlur = blurSource.ShouldUpdateBlur(),
						isPreviewing = blurSource.Preview
					});
					renderer.EnqueuePass(pass);
				}
			}
		}

		private TranslucentImageSource GetBlurSource(Camera camera)
		{
			if (!blurSourceCache.ContainsKey(camera))
			{
				blurSourceCache.Add(camera, camera.GetComponent<TranslucentImageSource>());
			}
			return blurSourceCache[camera];
		}

		public Rect GetPixelSize(CameraData cameraData)
		{
			return cameraData.camera.pixelRect;
		}
	}
}
