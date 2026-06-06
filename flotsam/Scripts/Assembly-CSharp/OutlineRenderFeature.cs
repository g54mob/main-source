using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OutlineRenderFeature : ScriptableRendererFeature
{
	[Serializable]
	public class Settings
	{
		[Header("Mode")]
		public bool _singlePass = true;

		[Header("Command Buffer")]
		public RenderPassEvent RenderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

		[Header("Outline")]
		public Material RenderMaterialOverride;

		public bool UpdateOutlineColorsEachFrame;

		[Space(10f)]
		public Color OutlineColor = new Color(0.75f, 0.75f, 0.75f, 1f);

		public Color OutlineHighlightedColor = new Color(1f, 1f, 1f, 1f);

		[Space(10f)]
		public OutlineColorDefinitionScriptableObject ColorDefinition;

		[Space(10f)]
		[Tooltip("How many times do we want to blur our shape?")]
		public int BlurIterations = 3;

		[Tooltip("With each blur how far should we spread the shape in all six directions (in pixels)")]
		public int BlurMinSpread = 1;

		[Tooltip("How much should the blurminspread increase with each blur iteration? (ex:BlurIterations = 3,BlurMinSpread = 1,BlurIterationSpread = 3 -> blur at iteration 3 will be 1+(3*3) ")]
		public int BlurIterationSpread;

		[Range(0f, 1f)]
		[Tooltip("Controls how much the blur alpha should be reduced with each blur pass. Lower values= soft feather. 1 =  hard outline")]
		public float BlurIntensityFalloff = 1f;
	}

	public struct Materials
	{
		public Material Outline;

		public Material Composite;
	}

	public Settings settings;

	[Header("Shaders")]
	[SerializeField]
	private Shader _outlineShader;

	[SerializeField]
	private Shader _compositeShader;

	private OutlinePass _pass;

	private Materials _materials;

	public override void Create()
	{
		_materials = new Materials
		{
			Outline = CoreUtils.CreateEngineMaterial(_outlineShader),
			Composite = CoreUtils.CreateEngineMaterial(_compositeShader)
		};
		if (settings._singlePass)
		{
			_pass = new OutlinePass(settings, _materials);
		}
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		if (_pass != null)
		{
			renderer.EnqueuePass(_pass);
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
}
