using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class WindowModeConnection : ConnectionWithOptions<string>
	{
		protected List<FullScreenMode> _values;

		protected List<string> _labels;

		protected FullScreenMode? lastKnownMode;

		protected int lastSetFrame;

		public override List<string> GetOptionLabels()
		{
			if (_labels.IsNullOrEmpty())
			{
				_labels = new List<string>();
				_labels.Add("Borderless");
				_labels.Add("Windowed");
			}
			return _labels;
		}

		public override void SetOptionLabels(List<string> optionLabels)
		{
			List<FullScreenMode> windowOptions = getWindowOptions();
			if (optionLabels == null || optionLabels.Count != windowOptions.Count)
			{
				Debug.LogError("Invalid new labels. Need to be " + windowOptions.Count + ".");
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

		protected List<FullScreenMode> getWindowOptions()
		{
			if (_values.IsNullOrEmpty())
			{
				_values = new List<FullScreenMode>();
				_values.Add(FullScreenMode.FullScreenWindow);
				_values.Add(FullScreenMode.Windowed);
			}
			return _values;
		}

		public override int Get()
		{
			if (Time.frameCount - lastSetFrame > 3)
			{
				lastKnownMode = null;
			}
			FullScreenMode fullScreenMode = Screen.fullScreenMode;
			if (lastKnownMode.HasValue)
			{
				fullScreenMode = lastKnownMode.Value;
			}
			List<FullScreenMode> windowOptions = getWindowOptions();
			for (int i = 0; i < windowOptions.Count; i++)
			{
				if (windowOptions[i] == fullScreenMode)
				{
					return i;
				}
			}
			return 0;
		}

		public override void Set(int index)
		{
			List<FullScreenMode> windowOptions = getWindowOptions();
			index = Mathf.Clamp(index, 0, windowOptions.Count - 1);
			FullScreenMode fullScreenMode = windowOptions[index];
			ScreenOrchestrator.Instance.RequestFullScreenMode(fullScreenMode);
			lastSetFrame = Time.frameCount;
			lastKnownMode = fullScreenMode;
			NotifyListenersIfChanged(index);
		}
	}
}
