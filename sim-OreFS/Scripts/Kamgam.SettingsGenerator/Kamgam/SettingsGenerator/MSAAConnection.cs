using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class MSAAConnection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		public override List<string> GetOptionLabels()
		{
			if (_labels == null)
			{
				_labels = new List<string>();
				_labels.Add("Disabled");
				_labels.Add("2x");
				_labels.Add("4x");
				_labels.Add("8x");
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			if (optionLabels == null || optionLabels.Count != 4)
			{
				Debug.LogError("Invalid new labels. Need to be four (disabled, 2, 4, 8).");
			}
			else
			{
				_labels = optionLabels;
			}
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		public override int Get()
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset == null)
			{
				return 0;
			}
			if (universalRenderPipelineAsset.msaaSampleCount <= 1)
			{
				return 0;
			}
			if (universalRenderPipelineAsset.msaaSampleCount == 2)
			{
				return 1;
			}
			if (universalRenderPipelineAsset.msaaSampleCount == 4)
			{
				return 2;
			}
			if (universalRenderPipelineAsset.msaaSampleCount >= 8)
			{
				return 3;
			}
			return 0;
		}

		public override void Set(int index)
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (!(universalRenderPipelineAsset == null))
			{
				if (index <= 0)
				{
					universalRenderPipelineAsset.msaaSampleCount = 1;
				}
				else if (index == 1)
				{
					universalRenderPipelineAsset.msaaSampleCount = 2;
				}
				else if (index == 2)
				{
					universalRenderPipelineAsset.msaaSampleCount = 4;
				}
				else if (index >= 3)
				{
					universalRenderPipelineAsset.msaaSampleCount = 8;
				}
				NotifyListenersIfChanged(index);
			}
		}
	}
}
