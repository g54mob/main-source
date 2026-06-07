using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class ResolutionConnection : ConnectionWithOptions<string>
	{
		public static bool AllowResolutionChangeOnMobile;

		public bool CacheResolutions = true;

		public bool LimitToCurrentRefreshRate;

		public bool LimitToUniqueResolutions = true;

		public bool LimitMaxResolutionToDisplayResolution;

		public bool SkipRefreshRatesWith59Hz = true;

		public bool AddRefreshRateToLabels;

		public List<Vector2Int> AllowedAspectRatios = new List<Vector2Int>();

		public float AllowedAspectRatioDelta = 0.02f;

		protected List<Resolution> _values;

		protected List<string> _labels;

		protected string _resolutionFormat = "{0}x{1}";

		protected string _refreshRateFormat = " ({0}Hz)";

		protected Vector2Int _lastMonitorMaxResolution;

		protected Resolution? lastKnownResolution;

		protected int lastSetFrame;

		public event Action OnMaxResolutionChanged;

		protected Vector2Int getCurrentMaxResolution()
		{
			Resolution[] resolutions = Screen.resolutions;
			return new Vector2Int(resolutions[^1].width, resolutions[^1].height);
		}

		protected List<Resolution> getUniqueResolutions()
		{
			if (_values == null || _values.Count == 0 || !CacheResolutions)
			{
				_values = new List<Resolution>();
				Resolution[] resolutions = Screen.resolutions;
				fillResolutionsList(resolutions, limitAspectRatios: true);
				if (_values.Count == 0)
				{
					Logger.LogWarning("Resolution aspect ratio limiting resulted in an empty list. Disabling filtering (all resolutions will be listed).");
					fillResolutionsList(resolutions, limitAspectRatios: false);
				}
				if (_values.Count == 0)
				{
					Resolution item = new Resolution
					{
						width = 1024,
						height = 768,
						refreshRateRatio = new RefreshRate
						{
							numerator = 60000u,
							denominator = 1001u
						}
					};
					_values.Add(item);
				}
			}
			return _values;
		}

		private void fillResolutionsList(Resolution[] resolutions, bool limitAspectRatios)
		{
			float num = 0f;
			float num2 = 0f;
			if (LimitMaxResolutionToDisplayResolution)
			{
				Display[] displays = Display.displays;
				foreach (Display display in displays)
				{
					num = Mathf.Max(num, display.systemWidth);
					num2 = Mathf.Max(num2, display.systemHeight);
				}
			}
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				if ((SkipRefreshRatesWith59Hz && !LimitToCurrentRefreshRate && getRoundedRefreshRate(resolution) == 59 && findResolution(resolutions, resolution.width, resolution.height, 60).HasValue) || (LimitToCurrentRefreshRate && Mathf.Abs(getRoundedRefreshRate(Screen.currentResolution) - getRoundedRefreshRate(resolution)) > 1) || (LimitToUniqueResolutions && contains(_values, resolution)) || (LimitMaxResolutionToDisplayResolution && num > 0f && ((float)resolution.width > num || (float)resolution.height > num2)))
				{
					continue;
				}
				if (limitAspectRatios && AllowedAspectRatios != null && AllowedAspectRatios.Count > 0)
				{
					float num3 = (float)resolution.width / (float)resolution.height;
					foreach (Vector2Int allowedAspectRatio in AllowedAspectRatios)
					{
						float num4 = (float)allowedAspectRatio.x / (float)allowedAspectRatio.y;
						if (Mathf.Abs(num3 - num4) <= AllowedAspectRatioDelta)
						{
							_values.Add(resolution);
							break;
						}
					}
				}
				else
				{
					_values.Add(resolution);
				}
			}
			if (!LimitToUniqueResolutions)
			{
				return;
			}
			for (int num5 = _values.Count - 1; num5 >= 0; num5--)
			{
				Resolution res = _values[num5];
				int num6 = Mathf.Abs(getRoundedRefreshRate(Screen.currentResolution) - getRoundedRefreshRate(res));
				int num7 = int.MaxValue;
				foreach (Resolution value in _values)
				{
					if (value.width == res.width && value.height == res.height)
					{
						num7 = Mathf.Abs(getRoundedRefreshRate(Screen.currentResolution) - getRoundedRefreshRate(value));
						if (num7 < num6)
						{
							break;
						}
					}
				}
				if (num7 < num6)
				{
					_values.RemoveAt(num5);
				}
			}
		}

		protected Resolution? findResolution(Resolution[] resolutions, int width, int height, int refreshRate)
		{
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				int roundedRefreshRate = getRoundedRefreshRate(resolution);
				if (resolution.width == width && resolution.height == height && roundedRefreshRate == refreshRate)
				{
					return resolution;
				}
			}
			return null;
		}

		protected int getRoundedRefreshRate(Resolution res)
		{
			return Mathf.RoundToInt((float)res.refreshRateRatio.value);
		}

		protected bool contains(List<Resolution> resolutions, Resolution resolution)
		{
			if (resolutions == null || resolutions.Count == 0)
			{
				return false;
			}
			for (int i = 0; i < resolutions.Count; i++)
			{
				bool flag = Mathf.Abs(getRoundedRefreshRate(resolutions[i]) - getRoundedRefreshRate(resolution)) <= 1;
				if (resolution.width == resolutions[i].width && resolution.height == resolutions[i].height && flag)
				{
					return true;
				}
			}
			return false;
		}

		public override List<string> GetOptionLabels()
		{
			Vector2Int currentMaxResolution = getCurrentMaxResolution();
			if (currentMaxResolution != _lastMonitorMaxResolution)
			{
				_lastMonitorMaxResolution = currentMaxResolution;
				_values = null;
				_labels = null;
				this.OnMaxResolutionChanged?.Invoke();
			}
			if (_labels == null || _labels.Count == 0 || !CacheResolutions)
			{
				_labels = new List<string>();
				foreach (Resolution uniqueResolution in getUniqueResolutions())
				{
					string text = string.Format(_resolutionFormat, uniqueResolution.width, uniqueResolution.height);
					if (AddRefreshRateToLabels)
					{
						text += string.Format(_refreshRateFormat, getRoundedRefreshRate(uniqueResolution));
					}
					_labels.Add(text);
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
			List<Resolution> uniqueResolutions = getUniqueResolutions();
			if (optionLabels == null || optionLabels.Count != uniqueResolutions.Count)
			{
				Logger.LogError("Invalid new labels. Need to be " + uniqueResolutions.Count + ".");
			}
			_labels = new List<string>(optionLabels);
		}

		public string GetResolutionFormat()
		{
			return _resolutionFormat;
		}

		public void SetResolutionFormat(string format)
		{
			_resolutionFormat = format;
			RefreshOptionLabels();
		}

		public string GetRefreshRateFormat()
		{
			return _refreshRateFormat;
		}

		public void SetRefreshRateFormat(string format)
		{
			_refreshRateFormat = format;
			RefreshOptionLabels();
		}

		public override int Get()
		{
			if (Time.frameCount - lastSetFrame > 3)
			{
				lastKnownResolution = null;
			}
			Resolution resolution = Screen.currentResolution;
			if (lastKnownResolution.HasValue)
			{
				resolution = lastKnownResolution.Value;
			}
			List<Resolution> uniqueResolutions = getUniqueResolutions();
			int num = int.MaxValue;
			int result = 0;
			for (int i = 0; i < uniqueResolutions.Count; i++)
			{
				int num2 = Mathf.Abs(uniqueResolutions[i].width - resolution.width) + Mathf.Abs(uniqueResolutions[i].height - resolution.height);
				if (num2 < num)
				{
					num = num2;
					result = i;
					if (num == 0)
					{
						return i;
					}
				}
			}
			return result;
		}

		public override void Set(int index)
		{
			List<Resolution> uniqueResolutions = getUniqueResolutions();
			index = Mathf.Clamp(index, 0, Mathf.Max(0, uniqueResolutions.Count - 1));
			Resolution resolution = uniqueResolutions[index];
			ScreenOrchestrator.Instance.RequestResolution(resolution);
			lastSetFrame = Time.frameCount;
			lastKnownResolution = resolution;
			NotifyListenersIfChanged(index);
		}
	}
}
