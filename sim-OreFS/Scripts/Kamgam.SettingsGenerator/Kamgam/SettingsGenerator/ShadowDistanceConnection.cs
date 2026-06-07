using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class ShadowDistanceConnection : ConnectionWithOptions<string>
	{
		public List<float> QualityDistances;

		public bool UseQualitySettingsAsFallback;

		protected List<float> _distancesFromSettings;

		protected List<string> _labels;

		public ShadowDistanceConnection(List<float> qualityDistances, bool useQualitySettingsAsFallback = true)
		{
			QualityDistances = qualityDistances;
			UseQualitySettingsAsFallback = useQualitySettingsAsFallback;
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels == null)
			{
				_labels = QualitySettings.names.ToList();
				if (QualitySettingUtils.AreQualitiesOrderedLowToHigh())
				{
					_labels.Reverse();
				}
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			List<float> distances = getDistances();
			if (optionLabels == null || optionLabels.Count != distances.Count)
			{
				Debug.LogError("Invalid new labels. Need to be " + distances.Count + ".");
			}
			else
			{
				_labels = new List<string>(optionLabels);
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
			List<float> distances = getDistances();
			for (int i = 0; i < distances.Count; i++)
			{
				if (distances[i] == universalRenderPipelineAsset.shadowDistance)
				{
					return i;
				}
			}
			return QualitySettings.GetQualityLevel();
		}

		private List<float> getDistances()
		{
			if (!UseQualitySettingsAsFallback || (QualityDistances != null && QualityDistances.Count > 0))
			{
				return QualityDistances;
			}
			if (_distancesFromSettings == null)
			{
				_distancesFromSettings = new List<float>();
				int num = QualitySettings.names.Length;
				for (int i = 0; i < num; i++)
				{
					UniversalRenderPipelineAsset universalRenderPipelineAsset = QualitySettings.GetRenderPipelineAssetAt(i) as UniversalRenderPipelineAsset;
					_distancesFromSettings.Add(universalRenderPipelineAsset.shadowDistance);
				}
			}
			return _distancesFromSettings;
		}

		public override void Set(int index)
		{
			UniversalRenderPipelineAsset universalRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
			if (universalRenderPipelineAsset == null)
			{
				return;
			}
			List<float> distances = getDistances();
			if (distances != null && distances.Count > 0)
			{
				if (distances.Count > index)
				{
					universalRenderPipelineAsset.shadowDistance = distances[index];
				}
				else
				{
					universalRenderPipelineAsset.shadowDistance = distances[distances.Count - 1];
				}
			}
			NotifyListenersIfChanged(index);
		}
	}
}
