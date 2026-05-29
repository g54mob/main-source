using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GrabScreenFeature : ScriptableRendererFeature
{
	[Serializable]
	public class Settings
	{
		public string TextureName;

		public LayerMask LayerMask;
	}

	public class GrabPass : ScriptableRenderPass
	{
		private Settings settings;

		private RTHandle m_GrabbedTextureHandle;

		private RTHandle m_CameraColorHandle;

		public GrabPass(Settings s)
		{
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public void Dispose()
		{
		}
	}

	private class RenderPass : ScriptableRenderPass
	{
		private Settings settings;

		private List<ShaderTagId> m_ShaderTagIdList;

		private FilteringSettings m_FilteringSettings;

		private RenderStateBlock m_RenderStateBlock;

		public RenderPass(Settings settings)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}
	}

	private GrabPass grabPass;

	private RenderPass renderPass;

	[SerializeField]
	private Settings settings;

	public override void Create()
	{
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
	}

	protected override void Dispose(bool disposing)
	{
	}
}
