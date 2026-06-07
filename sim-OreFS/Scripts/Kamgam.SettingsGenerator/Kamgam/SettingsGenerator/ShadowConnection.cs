using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class ShadowConnection : Connection<bool>
	{
		protected Dictionary<RenderPipelineAsset, float> previousValue;

		public override bool Get()
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset == null)
			{
				return false;
			}
			remember();
			if (!(universalRenderPipelineAsset.shadowDistance > 0.001f))
			{
				return false;
			}
			return true;
		}

		public override void Set(bool enable)
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (!(universalRenderPipelineAsset == null))
			{
				remember();
				if (enable)
				{
					revert();
				}
				else
				{
					universalRenderPipelineAsset.shadowDistance = 0f;
				}
				NotifyListenersIfChanged(enable);
			}
		}

		protected void remember()
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (!(universalRenderPipelineAsset == null))
			{
				if (previousValue == null)
				{
					previousValue = new Dictionary<RenderPipelineAsset, float>();
				}
				if (!previousValue.ContainsKey(GraphicsSettings.currentRenderPipeline))
				{
					previousValue.Add(GraphicsSettings.currentRenderPipeline, universalRenderPipelineAsset.shadowDistance);
				}
				else if (universalRenderPipelineAsset.shadowDistance > 0.01f)
				{
					previousValue[GraphicsSettings.currentRenderPipeline] = universalRenderPipelineAsset.shadowDistance;
				}
			}
		}

		protected void revert()
		{
			foreach (KeyValuePair<RenderPipelineAsset, float> item in previousValue)
			{
				if (!(item.Key == null) && (item.Key as UniversalRenderPipelineAsset).shadowDistance < 0.001f)
				{
					(item.Key as UniversalRenderPipelineAsset).shadowDistance = item.Value;
				}
			}
		}
	}
}
