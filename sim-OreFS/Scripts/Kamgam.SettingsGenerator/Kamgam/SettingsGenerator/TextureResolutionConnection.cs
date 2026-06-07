using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class TextureResolutionConnection : ConnectionWithOptions<string>
	{
		protected List<string> _labels;

		protected List<int> _values;

		protected List<int> getValues()
		{
			if (_values.IsNullOrEmpty())
			{
				_values = new List<int>();
				_values.Add(0);
				_values.Add(1);
				_values.Add(2);
				_values.Add(3);
				if (QualitySettingUtils.AreQualitiesOrderedLowToHigh())
				{
					_values.Reverse();
				}
			}
			return _values;
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels.IsNullOrEmpty())
			{
				_labels = new List<string>();
				_labels.Add("High");
				_labels.Add("Medium");
				_labels.Add("Low");
				_labels.Add("Very Low");
				if (QualitySettingUtils.AreQualitiesOrderedLowToHigh())
				{
					_labels.Reverse();
				}
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			List<int> values = getValues();
			if (optionLabels == null || optionLabels.Count != values.Count)
			{
				Debug.LogError("Invalid new labels. Need to be " + values.Count + ".");
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
			List<int> values = getValues();
			for (int i = 0; i < values.Count; i++)
			{
				if (values[i] == QualitySettings.globalTextureMipmapLimit)
				{
					return i;
				}
			}
			return 0;
		}

		public override void Set(int index)
		{
			List<int> values = getValues();
			index = Mathf.Clamp(index, 0, values.Count - 1);
			QualitySettings.globalTextureMipmapLimit = values[index];
			NotifyListenersIfChanged(index);
		}
	}
}
