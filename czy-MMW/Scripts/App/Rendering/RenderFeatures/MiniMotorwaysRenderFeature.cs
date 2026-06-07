using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Utils;

namespace Rendering.RenderFeatures
{
	public class MiniMotorwaysRenderFeature : ScriptableRendererFeature
	{
		[Serializable]
		public class FeatureSettings
		{
			public Shader highestMotorwayShader;

			public Shader shadowTypeShader;

			public Shader shadowFadeoutShader;

			public Shader headlightOcclusionShader;

			public Material headlightMaterial;
		}

		public FeatureSettings settings = new FeatureSettings();

		private HighestMotorwayPass _highestMotorwayPass;

		private ShadowTypeRenderPass _shadowTypeRenderPass;

		private ShadowFadeoutPass _shadowFadeoutPass;

		private HeadlightOcclusionPass _headlightOcclusionPass;

		private HeadlightRenderPass _headlightRenderPass;

		public MiniMotorwaysRenderFeature()
		{
			RTHandles.Initialize(Screen.width, Screen.height);
		}

		public override void Create()
		{
			_highestMotorwayPass = new HighestMotorwayPass(settings.highestMotorwayShader);
			_shadowTypeRenderPass = new ShadowTypeRenderPass(settings.shadowTypeShader);
			_shadowFadeoutPass = new ShadowFadeoutPass(settings.shadowFadeoutShader);
			_headlightOcclusionPass = new HeadlightOcclusionPass(settings.headlightOcclusionShader);
			_headlightRenderPass = new HeadlightRenderPass(settings.headlightMaterial);
			RenderPipelineManager.beginCameraRendering += delegate(ScriptableRenderContext context, Camera camera)
			{
				RTHandles.SetReferenceSize(Screen.width, Screen.height);
				context.SetupCameraProperties(camera);
			};
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
			if (renderingData.cameraData.camera.gameObject.GetComponent<MiniMotorwaysRenderFeatureCameraMarker>() != null)
			{
				renderer.EnqueuePass(_highestMotorwayPass);
				renderer.EnqueuePass(_shadowTypeRenderPass);
				renderer.EnqueuePass(_headlightOcclusionPass);
				renderer.EnqueuePass(_shadowFadeoutPass);
				renderer.EnqueuePass(_headlightRenderPass);
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
			{
				_highestMotorwayPass.Dispose();
				_shadowTypeRenderPass.Dispose();
				_headlightOcclusionPass.Dispose();
				_shadowFadeoutPass.Dispose();
				_headlightRenderPass.Dispose();
			}
		}
	}
}
