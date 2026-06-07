using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class MonitorConnection : ConnectionWithOptions<string>
	{
		public static bool AllowMonitorChangeOnMobile = false;

		public static bool ForceMonitorUpdate = false;

		public static int FramesToWaitAfterMonitorSwitch = 3;

		public bool RefreshResolversAfterCompletion = true;

		protected List<DisplayInfo> _values;

		protected List<string> _labels;

		protected int _lastKnownMonitorIndex = -1;

		protected int _lastSetFrame = -1;

		protected AsyncOperation _moveOperation;

		protected bool _moveOperationFailed;

		public event Action OnComplete;

		protected List<DisplayInfo> getDisplayInfos()
		{
			if (_values.IsNullOrEmpty())
			{
				_values = new List<DisplayInfo>();
				Screen.GetDisplayLayout(_values);
				if (_values.Count == 0)
				{
					DisplayInfo item = default(DisplayInfo);
					item.name = "Monitor 1";
					item.width = 1920;
					item.height = 1080;
					item.refreshRate = new RefreshRate
					{
						denominator = 60000u,
						numerator = 1001u
					};
					item.workArea = new RectInt(0, 0, item.width, item.height);
					_values.Add(item);
				}
			}
			return _values;
		}

		public override List<string> GetOptionLabels()
		{
			if (_labels.IsNullOrEmpty())
			{
				_labels = new List<string>();
				foreach (DisplayInfo displayInfo in getDisplayInfos())
				{
					string item = displayInfo.name + " (" + displayInfo.width + "x" + displayInfo.height + ")";
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
			List<DisplayInfo> displayInfos = getDisplayInfos();
			if (optionLabels == null || optionLabels.Count != displayInfos.Count)
			{
				Logger.LogError("Invalid new labels. Need to be " + displayInfos.Count + ".");
			}
			_labels = new List<string>(optionLabels);
		}

		public override int Get()
		{
			if (((_moveOperation != null && _moveOperation.isDone) || _moveOperationFailed) && Time.frameCount - _lastSetFrame > FramesToWaitAfterMonitorSwitch)
			{
				_lastKnownMonitorIndex = -1;
				_lastSetFrame = -1;
				_moveOperation = null;
				_moveOperationFailed = false;
			}
			if (_lastKnownMonitorIndex >= 0)
			{
				return _lastKnownMonitorIndex;
			}
			return getDisplayInfos().IndexOf(Screen.mainWindowDisplayInfo);
		}

		public override void Set(int index)
		{
			_lastSetFrame = Time.frameCount;
			_lastKnownMonitorIndex = index;
			moveToMonitor(index);
			NotifyListenersIfChanged(index);
		}

		private void moveToMonitor(int index)
		{
			try
			{
				_moveOperationFailed = false;
				DisplayInfo display = _values[index];
				Vector2Int mainWindowPosition = Screen.mainWindowPosition;
				if (Screen.fullScreenMode != FullScreenMode.Windowed)
				{
					mainWindowPosition.x += display.width / 2;
					mainWindowPosition.y += display.height / 2;
				}
				if (Screen.mainWindowDisplayInfo.name != display.name || ForceMonitorUpdate)
				{
					_moveOperation = Screen.MoveMainWindowTo(in display, mainWindowPosition);
					waitForMonitorSwitchToComplete();
				}
			}
			catch
			{
				_moveOperationFailed = true;
			}
		}

		private async void waitForMonitorSwitchToComplete()
		{
			while (!_moveOperation.isDone || Time.frameCount - _lastSetFrame <= FramesToWaitAfterMonitorSwitch)
			{
				await Task.Yield();
			}
			if (RefreshResolversAfterCompletion && SettingsProvider.LastUsedSettingsProvider != null && SettingsProvider.LastUsedSettingsProvider.HasSettings())
			{
				SettingsProvider.LastUsedSettingsProvider.Settings.RefreshRegisteredResolversWithConnection<ResolutionConnection>();
				SettingsProvider.LastUsedSettingsProvider.Settings.RefreshRegisteredResolversWithConnection<RefreshRateConnection>();
			}
			this.OnComplete?.Invoke();
		}
	}
}
