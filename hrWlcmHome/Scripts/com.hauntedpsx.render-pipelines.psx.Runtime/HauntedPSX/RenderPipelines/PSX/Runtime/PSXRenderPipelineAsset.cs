using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace HauntedPSX.RenderPipelines.PSX.Runtime
{
	public class PSXRenderPipelineAsset : RenderPipelineAsset<PSXRenderPipeline>
	{
		[SerializeField]
		public PSXRenderPipelineResources renderPipelineResources;

		private PSXRenderPipelineAsset()
		{
		}

		protected override RenderPipeline CreatePipeline()
		{
			PSXRenderPipeline result = null;
			try
			{
				result = new PSXRenderPipeline(this);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			return result;
		}

		protected override void OnValidate()
		{
			if (GraphicsSettings.defaultRenderPipeline == this)
			{
				base.OnValidate();
			}
		}
	}
}
