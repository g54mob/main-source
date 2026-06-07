using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class RefreshRateConnection : ConnectionWithOptions<string>
	{
		public bool CacheRefreshRates = true;

		public bool LimitToCurrentResolution;

		public int MinRate;

		public int MaxRate = 1000;

		protected List<RefreshRate> _values;

		protected List<string> _labels;

		protected string _rateNameInOptionLabel = "Hz";

		protected RefreshRate? lastKnownRefreshRate;

		protected int lastSetFrame;

		protected List<RefreshRate> getRefreshRates()
		{
			if (_values == null)
			{
				_values = new List<RefreshRate>();
				_values.Add(Screen.currentResolution.refreshRateRatio);
				Resolution[] resolutions = Screen.resolutions;
				for (int i = 0; i < resolutions.Length; i++)
				{
					Resolution resolution = resolutions[i];
					if ((!LimitToCurrentResolution || (resolution.width == Screen.currentResolution.width && resolution.height == Screen.currentResolution.height)) && !contains(_values, resolution.refreshRateRatio) && !(resolution.refreshRateRatio.value < (double)MinRate) && !(resolution.refreshRateRatio.value > (double)MaxRate))
					{
						_values.Add(resolution.refreshRateRatio);
					}
				}
				_values.Sort((RefreshRate a, RefreshRate b) => Mathf.RoundToInt((float)(a.value - b.value)));
			}
			return _values;
		}

		protected bool contains(List<RefreshRate> rates, RefreshRate rate)
		{
			if (rates == null || rates.Count == 0)
			{
				return false;
			}
			int num = Mathf.RoundToInt((float)rate.value);
			for (int i = 0; i < rates.Count; i++)
			{
				if (Mathf.RoundToInt((float)rates[i].value) == num)
				{
					return true;
				}
			}
			return false;
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels == null || !CacheRefreshRates)
			{
				_labels = new List<string>();
				foreach (RefreshRate refreshRate in getRefreshRates())
				{
					string item = Mathf.RoundToInt((float)refreshRate.value) + _rateNameInOptionLabel;
					_labels.Add(item);
				}
			}
			return _labels;
		}

		public override void RefreshOptionLabels()
		{
			_labels = null;
			GetOptionLabels();
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			if (optionLabels != null && optionLabels.Count != 0)
			{
				SetOptionLabel(optionLabels[0]);
				Logger.LogWarning("Setting each label name is not supported. Use SetOptionLabel() instead. Using the firast given as the new base label.");
			}
		}

		public void SetOptionLabel(string rateNameInOptionLabel)
		{
			_rateNameInOptionLabel = rateNameInOptionLabel;
			RefreshOptionLabels();
		}

		public override int Get()
		{
			if (Time.frameCount - lastSetFrame > 3)
			{
				lastKnownRefreshRate = null;
			}
			RefreshRate refreshRate = Screen.currentResolution.refreshRateRatio;
			if (lastKnownRefreshRate.HasValue)
			{
				refreshRate = lastKnownRefreshRate.Value;
			}
			List<RefreshRate> refreshRates = getRefreshRates();
			for (int i = 0; i < refreshRates.Count; i++)
			{
				if (Mathf.Abs((float)(refreshRates[i].value - refreshRate.value)) < 0.01f)
				{
					return i;
				}
			}
			return 0;
		}

		public override void Set(int index)
		{
			List<RefreshRate> refreshRates = getRefreshRates();
			index = Mathf.Clamp(index, 0, refreshRates.Count - 1);
			RefreshRate refreshRate = refreshRates[index];
			ScreenOrchestrator.Instance.RequestRefreshRate(refreshRate);
			lastSetFrame = Time.frameCount;
			lastKnownRefreshRate = refreshRate;
			NotifyListenersIfChanged(index);
		}
	}
}
