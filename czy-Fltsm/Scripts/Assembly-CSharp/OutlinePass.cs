using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.Rendering.RenderGraphModule.Util;
using UnityEngine.Rendering.Universal;

public class OutlinePass : ScriptableRenderPass
{
	private class RasterPassData
	{
		internal OutlinePass This;

		internal bool IsHighlight;
	}

	private static readonly Color _bufferClearColor = new Color(0f, 0f, 0f, 0f);

	private OutlineRenderFeature.Materials _materials;

	private MaterialPropertyBlock _mpb = new MaterialPropertyBlock();

	private TextureHandle _source;

	private TextureHandle _destination;

	private TextureHandle _outline;

	private TextureHandle _outlineComposite;

	private TextureHandle _outlinePingPong;

	private const string cString_OutlineColor = "_Color";

	private const string cString_OutlineBlurOffset = "_BlurOffset";

	private const string cString_Intensity = "_Intensity";

	private const string cString_Outline = "_Outline";

	private const string cSting_Cutout = "_Cutout";

	private const string cString_Original = "_Original";

	public readonly int OutlineColorMatId = Shader.PropertyToID("_Color");

	private static readonly int _outlineBlurOffsetMatID = Shader.PropertyToID("_BlurOffset");

	private static readonly int _intensityMatID = Shader.PropertyToID("_Intensity");

	private static readonly int _outlineMatID = Shader.PropertyToID("_Outline");

	private static readonly int _cutoutMatID = Shader.PropertyToID("_Cutout");

	private static readonly int _originalMatID = Shader.PropertyToID("_Original");

	protected OutlineRenderFeature.Settings Settings { get; private set; }

	public Material NoHighlightMaterial { get; private set; }

	public Material HighlightMaterial { get; private set; }

	public OutlinePass(OutlineRenderFeature.Settings settings, OutlineRenderFeature.Materials materials)
	{
		Settings = settings;
		_materials = materials;
		base.renderPassEvent = settings.RenderPassEvent;
		if ((bool)settings.RenderMaterialOverride)
		{
			NoHighlightMaterial = new Material(settings.RenderMaterialOverride);
		}
		else
		{
			NoHighlightMaterial = new Material(Shader.Find("Custom/PostProcessing/CommandBufferPP/Outline/OutlineReplacement"));
		}
		if (NoHighlightMaterial == null)
		{
			Debug.LogError("[CommandBufferPP_Silhouette] - UNABLE TO LOAD A VALID RENDER MATERIAL.");
		}
		HighlightMaterial = new Material(NoHighlightMaterial);
		if ((bool)settings.ColorDefinition)
		{
			NoHighlightMaterial.SetColor(OutlineColorMatId, settings.ColorDefinition.OutlineColor);
			HighlightMaterial.SetColor(OutlineColorMatId, settings.ColorDefinition.HighlightColor);
		}
		else
		{
			NoHighlightMaterial.SetColor(OutlineColorMatId, settings.OutlineColor);
			HighlightMaterial.SetColor(OutlineColorMatId, settings.OutlineHighlightedColor);
		}
	}

	public override void RecordRenderGraph(RenderGraph renderGraph, ContextContainer frameData)
	{
		UniversalResourceData universalResourceData = frameData.Get<UniversalResourceData>();
		UniversalCameraData universalCameraData = frameData.Get<UniversalCameraData>();
		RenderTextureDescriptor desc = new RenderTextureDescriptor(universalCameraData.cameraTargetDescriptor.width, universalCameraData.cameraTargetDescriptor.height, RenderTextureFormat.ARGB32, 0);
		desc.useMipMap = false;
		_source = universalResourceData.activeColorTexture;
		_outline = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "Outline", clear: false);
		_outlineComposite = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "Outline  Composite", clear: false);
		_outlinePingPong = UniversalRenderer.CreateRenderGraphTexture(renderGraph, desc, "Ping Pong Texture", clear: false);
		ExecuteOutlinePass(renderGraph, isHighlight: false, _source, _outlineComposite);
		ExecuteOutlinePass(renderGraph, isHighlight: true, _outlineComposite, _outlinePingPong);
		universalResourceData.cameraColor = _outlinePingPong;
	}

	private void ExecuteOutlinePass(RenderGraph renderGraph, bool isHighlight, TextureHandle source, TextureHandle destination)
	{
		RasterPassData passData;
		using (IRasterRenderGraphBuilder rasterRenderGraphBuilder = renderGraph.AddRasterRenderPass<RasterPassData>("Outline - Highlight " + (isHighlight ? "On" : "Off"), out passData, "F:\\workspace\\p\\Assets\\Code\\URP\\Outline\\OutlinePass.cs", 109))
		{
			passData.This = this;
			passData.IsHighlight = isHighlight;
			rasterRenderGraphBuilder.AllowPassCulling(value: false);
			rasterRenderGraphBuilder.SetRenderAttachment(destination, 0);
			rasterRenderGraphBuilder.SetRenderFunc<RasterPassData>(ExecuteRasterGraphPass);
		}
		RenderOutline(renderGraph, destination, _outline);
		RenderComposite(renderGraph, source, destination, _materials.Composite);
	}

	private void RenderOutline(RenderGraph renderGraph, TextureHandle source, TextureHandle destination)
	{
		_materials.Outline.SetFloat(_intensityMatID, Settings.BlurIntensityFalloff);
		_materials.Outline.SetFloat(_outlineBlurOffsetMatID, Settings.BlurMinSpread);
		Blit(renderGraph, source, destination, _materials.Outline, 0, "Outline - Outline");
	}

	private void RenderComposite(RenderGraph renderGraph, TextureHandle Source, TextureHandle Destination, Material material)
	{
		if ((bool)material)
		{
			RenderGraphUtils.BlitMaterialParameters blitParameters = new RenderGraphUtils.BlitMaterialParameters(Source, Destination, material, 0);
			RenderGraphBlitUtility.AddBlitPass(renderGraph, blitParameters, delegate(IUnsafeRenderGraphBuilder builder)
			{
				builder.UseTexture(in _outline);
			}, delegate(MaterialPropertyBlock mpb)
			{
				mpb.SetTexture(_outlineMatID, _outline);
			}, "Composite Pass", "F:\\workspace\\p\\Assets\\Code\\URP\\Outline\\OutlinePass.cs", 136);
		}
		else
		{
			Blit(renderGraph, Source, Destination);
		}
	}

	private static void ExecuteRasterGraphPass(RasterPassData passData, RasterGraphContext context)
	{
		context.cmd.ClearRenderTarget(clearDepth: true, clearColor: true, _bufferClearColor);
		OutlineRenderManager.Instance.FillBuffer(passData.This, passData.IsHighlight, context.cmd);
	}

	private void Blit(RenderGraph renderGraph, TextureHandle source, TextureHandle destination, string passName = "Outline - Blit")
	{
		renderGraph.AddBlitPass(source, destination, Vector2.one, Vector2.zero, 0, 0, -1, 0, 0, 1, RenderGraphUtils.BlitFilterMode.ClampBilinear, passName, returnBuilder: false, "F:\\workspace\\p\\Assets\\Code\\URP\\Outline\\OutlinePass.cs", 160);
	}

	private void Blit(RenderGraph renderGraph, TextureHandle source, TextureHandle destination, Material material, int shaderPass = 0, string passName = "Outline - Blit w. Material")
	{
		RenderGraphUtils.BlitMaterialParameters blitParameters = new RenderGraphUtils.BlitMaterialParameters(source, destination, material, shaderPass);
		renderGraph.AddBlitPass(blitParameters, passName, returnBuilder: false, "F:\\workspace\\p\\Assets\\Code\\URP\\Outline\\OutlinePass.cs", 166);
	}

	public Material ReturnRenderingMaterial(bool isHighlight)
	{
		if (!isHighlight)
		{
			return NoHighlightMaterial;
		}
		return HighlightMaterial;
	}
}
