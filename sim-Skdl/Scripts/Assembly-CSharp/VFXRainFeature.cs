using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VFXRainFeature : ScriptableRendererFeature
{
	[Serializable]
	public class Settings
	{
		public RenderPassEvent RenderPassEvent;

		public LayerMask LayerMask;
	}

	public Settings _settings;

	private VFXRainPass _pass;

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
