using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace VampireSurvivors.Graphics.RenderPass;

public class PixelateRenderFeature : FullScreenPassRendererFeature
{
	private Material _BlitMaterial;

	public Material BlitMaterial => _BlitMaterial;

	public PixelateRenderFeature()
	{
		//IL_0025: Expected I4, but got I8
		injectionPoint = InjectionPoint.AfterRenderingPostProcessing;
		fetchColorBuffer = true;
		base.m_Version = FullScreenPassRendererFeature.Version.Uninitialised;
		((ScriptableRendererFeature)this).m_Active = true;
		((ScriptableObject)this)._002Ector();
	}
}
