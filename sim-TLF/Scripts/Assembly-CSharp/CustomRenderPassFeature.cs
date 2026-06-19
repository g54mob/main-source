using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CustomRenderPassFeature : ScriptableRendererFeature
{
	[Serializable]
	public class CustomRenderPassSettings
	{
		public Material material;

		public RenderPassEvent renderPassEvent = RenderPassEvent.AfterRenderingTransparents;
	}

	private CustomRenderPass m_ScriptablePass;

	public CustomRenderPassSettings settings = new CustomRenderPassSettings();

	public override void Create()
	{
		m_ScriptablePass = new CustomRenderPass(settings);
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
		renderer.EnqueuePass(m_ScriptablePass);
	}
}
