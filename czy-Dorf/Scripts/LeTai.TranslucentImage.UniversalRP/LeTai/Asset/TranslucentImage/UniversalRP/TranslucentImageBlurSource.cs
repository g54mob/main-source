using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting.APIUpdating;

namespace LeTai.Asset.TranslucentImage.UniversalRP
{
	[MovedFrom("LeTai.Asset.TranslucentImage.LWRP")]
	public class TranslucentImageBlurSource : ScriptableRendererFeature
	{
		private readonly Dictionary<Camera, TranslucentImageSource> tisCache = new Dictionary<Camera, TranslucentImageSource>();

		private TranslucentImageBlurRenderPass pass;

		private IBlurAlgorithm blurAlgorithm;

		public void RegisterSource(TranslucentImageSource source)
		{
			tisCache[source.GetComponent<Camera>()] = source;
		}

		public override void Create()
		{
			ShaderId.Init(32);
			blurAlgorithm = new ScalableBlur();
			pass = new TranslucentImageBlurRenderPass();
			pass.renderPassEvent = RenderPassEvent.AfterRendering;
			tisCache.Clear();
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			TranslucentImageSource tIS = GetTIS(renderingData.cameraData.camera);
			if (!(tIS == null) && tIS.shouldUpdateBlur())
			{
				tIS.OnBeforeBlur();
				blurAlgorithm.Init(tIS.BlurConfig);
				TISPassData passData = new TISPassData
				{
					cameraColorTarget = renderer.cameraColorTarget,
					blurAlgorithm = blurAlgorithm,
					blurSource = tIS,
					isPreviewing = tIS.preview
				};
				pass.Setup(passData);
				renderer.EnqueuePass(pass);
			}
		}

		private TranslucentImageSource GetTIS(Camera camera)
		{
			if (!tisCache.ContainsKey(camera))
			{
				tisCache.Add(camera, camera.GetComponent<TranslucentImageSource>());
			}
			return tisCache[camera];
		}
	}
}
