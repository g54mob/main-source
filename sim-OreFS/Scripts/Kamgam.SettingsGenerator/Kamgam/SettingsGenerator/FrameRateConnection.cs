using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class FrameRateConnection : ConnectionWithOptions<string>
	{
		public List<int> _values;

		public List<string> _labels;

		protected List<int> getFrameRates()
		{
			if (_values == null)
			{
				_values = new List<int>();
				_values.Add(-1);
				_values.Add(30);
				_values.Add(60);
				_values.Add(120);
				_values.Add(144);
			}
			return _values;
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels == null)
			{
				_labels = new List<string>();
				_labels.Add("Uncapped");
				List<int> frameRates = getFrameRates();
				for (int i = 1; i < frameRates.Count; i++)
				{
					string item = frameRates[i] + " FPS";
					_labels.Add(item);
				}
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			List<int> frameRates = getFrameRates();
			if (optionLabels == null || optionLabels.Count != frameRates.Count)
			{
				Debug.LogError("Invalid new labels. Need to be " + frameRates.Count + ".");
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
			List<int> frameRates = getFrameRates();
			for (int i = 0; i < frameRates.Count; i++)
			{
				if (frameRates[i] == Application.targetFrameRate)
				{
					return i;
				}
			}
			return 0;
		}

		public override void Set(int index)
		{
			List<int> frameRates = getFrameRates();
			index = Mathf.Clamp(index, 0, frameRates.Count - 1);
			Application.targetFrameRate = frameRates[index];
			NotifyListenersIfChanged(index);
		}
	}
}
