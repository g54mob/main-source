using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.Universal;

public class EdgeDetection : ScriptableRendererFeature
{
	private class EdgeDetectionPass : ScriptableRenderPass
	{
		private class PassData
		{
		}

		private Material material;

		private static readonly int OutlineThicknessProperty = Shader.PropertyToID("_OutlineThickness");

		private static readonly int OutlineColorProperty = Shader.PropertyToID("_OutlineColor");

		public EdgeDetectionPass()
		{
			base.profilingSampler = new ProfilingSampler("EdgeDetectionPass");
		}

		public void Setup(ref EdgeDetectionSettings settings, ref Material edgeDetectionMaterial)
		{
			material = edgeDetectionMaterial;
			base.renderPassEvent = settings.renderPassEvent;
			material.SetFloat(OutlineThicknessProperty, settings.outlineThickness);
			material.SetColor(OutlineColorProperty, settings.outlineColor);
		}

		public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
		{
			UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
			PassData passData;
			using IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<PassData>("Edge Detection", out passData, "C:\\Users\\roman\\Desktop\\Game Projects\\MyLittleCoffeeNightmare\\Projekt\\MyLittleCoffeeNightmare\\Assets\\VFX\\Shader\\Shader\\Outline\\EdgeDetection.cs", 38);
			rasterRenderGraphBuilder.SetRenderAttachment(universalResourceData.activeColorTexture, 0);
			rasterRenderGraphBuilder.UseAllGlobalTextures(enable: true);
			rasterRenderGraphBuilder.AllowPassCulling(value: false);
			rasterRenderGraphBuilder.SetRenderFunc(delegate(PassData _, RasterGraphContext context)
			{
				Blitter.BlitTexture(context.cmd, Vector2.one, material, 0);
			});
		}
	}

	[Serializable]
	public class EdgeDetectionSettings
	{
		public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;

		[Range(0f, 15f)]
		public int outlineThickness = 3;

		public Color outlineColor = Color.black;
	}

	[SerializeField]
	private EdgeDetectionSettings settings;

	private Material edgeDetectionMaterial;

	private EdgeDetectionPass edgeDetectionPass;

	public override void Create()
	{
		if (edgeDetectionPass == null)
		{
			edgeDetectionPass = new EdgeDetectionPass();
		}
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (renderingData.cameraData.cameraType == CameraType.Preview || renderingData.cameraData.cameraType == CameraType.Reflection || UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
		{
			return;
		}
		if (edgeDetectionMaterial == null)
		{
			edgeDetectionMaterial = CoreUtils.CreateEngineMaterial(Shader.Find("Hidden/Edge Detection"));
			if (edgeDetectionMaterial == null)
			{
				Debug.LogWarning("Not all required materials could be created. Edge Detection will not render.");
				return;
			}
		}
		edgeDetectionPass.ConfigureInput(ScriptableRenderPassInput.Depth | ScriptableRenderPassInput.Normal | ScriptableRenderPassInput.Color);
		edgeDetectionPass.requiresIntermediateTexture = true;
		edgeDetectionPass.Setup(ref settings, ref edgeDetectionMaterial);
		renderer.EnqueuePass(edgeDetectionPass);
	}

	protected override void Dispose(bool disposing)
	{
		edgeDetectionPass = null;
		CoreUtils.Destroy(edgeDetectionMaterial);
	}
}
