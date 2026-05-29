using System.Collections.Generic;
using System.Reflection;
using EPOOutline;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class URPOutlineFeature : ScriptableRendererFeature
{
	private class SRPOutline : ScriptableRenderPass
	{
		private static List<Outlinable> temporaryOutlinables;

		public ScriptableRenderer Renderer;

		public bool UseColorTargetForDepth;

		public Outliner Outliner;

		public OutlineParameters Parameters;

		private List<Outliner> outliners;

		private FieldInfo nameId;

		private bool IsDepthTextureAvailable(ScriptableRenderer renderer)
		{
			return false;
		}

		private RenderTargetIdentifier GetDepthTarget(ScriptableRenderer renderer)
		{
			return default(RenderTargetIdentifier);
		}

		private RenderTargetIdentifier GetColorTarget(ScriptableRenderer renderer)
		{
			return default(RenderTargetIdentifier);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}
	}

	private class Pool
	{
		private Stack<SRPOutline> outlines;

		private List<SRPOutline> createdOutlines;

		public SRPOutline Get()
		{
			return null;
		}

		public void ReleaseAll()
		{
		}
	}

	private GameObject lastSelectedCamera;

	private Pool outlinePool;

	private List<Outliner> outliners;

	private bool GetOutlinersToRenderWith(RenderingData renderingData, List<Outliner> outliners)
	{
		return false;
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
	}

	public override void Create()
	{
	}
}
