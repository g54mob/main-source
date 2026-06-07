using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScheduleOneFogFeature : ScriptableRendererFeature
{
	[Serializable]
	public class Settings
	{
		public RenderPassEvent RenderPassEvent;

		public Shader Shader;

		public Color Color;

		[Range(0f, 100f)]
		public float Start;

		[Range(0f, 5000f)]
		public float End;

		[Range(0f, 1f)]
		public float Density;

		[Range(0f, 10f)]
		public float BlurStrength;

		public float StartHeightFade;

		public float EndHeightFade;
	}

	public Settings _settings;

	private ScheduleOneFogPass _pass;

	private Material _material;

	public override void Create()
	{
	}

	public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
	{
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}
}
