using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Aggro.Core
{
	public class ResolutionSettingUI : AggroSettingUI
	{
		private struct ResolutionEntry : IEquatable<ResolutionEntry>, IComparable<ResolutionEntry>
		{
			public int width;

			public int height;

			public bool Equals(ResolutionEntry other)
			{
				if (width == other.width)
				{
					return height == other.height;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is ResolutionEntry other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(width, height);
			}

			public int CompareTo(ResolutionEntry other)
			{
				int num = width.CompareTo(other.width);
				if (num != 0)
				{
					return num;
				}
				return height.CompareTo(other.height);
			}

			public override string ToString()
			{
				return $"{width} x {height}";
			}
		}

		public TMP_Dropdown dropdown;

		private ResolutionSetting _setting;

		private List<ResolutionEntry> _resolutions = new List<ResolutionEntry>();

		private int _prevWidth;

		private int _prevHeight;

		public override void Set(AggroSettingBase setting)
		{
			if (setting is ResolutionSetting setting2)
			{
				_setting = setting2;
				BuildResolutionEntries();
			}
			else
			{
				Debug.LogWarning("[SETTINGS] Invalid setting type for ResolutionSettingUI!");
			}
		}

		public override void Refresh()
		{
			dropdown.SetValueWithoutNotify(GetCurrentResolutionIndex());
		}

		private int GetCurrentResolutionIndex()
		{
			for (int i = 0; i < _resolutions.Count; i++)
			{
				ResolutionEntry resolutionEntry = _resolutions[i];
				if (resolutionEntry.width == Screen.width && resolutionEntry.height == Screen.height)
				{
					return i;
				}
			}
			return -1;
		}

		private void BuildResolutionEntries()
		{
			HashSet<ResolutionEntry> hashSet = new HashSet<ResolutionEntry>();
			_resolutions.Clear();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				if (resolution.width >= _setting.minWidth && resolution.width <= _setting.maxWidth && resolution.height >= _setting.minHeight && resolution.height <= _setting.maxHeight && (float)resolution.width / (float)resolution.height >= _setting.minAspectRatio - 0.001f)
				{
					ResolutionEntry item = new ResolutionEntry
					{
						width = resolution.width,
						height = resolution.height
					};
					if (!hashSet.Contains(item))
					{
						hashSet.Add(item);
						_resolutions.Add(item);
					}
				}
			}
			if (GetCurrentResolutionIndex() < 0)
			{
				ResolutionEntry item2 = new ResolutionEntry
				{
					width = Screen.width,
					height = Screen.height
				};
				_resolutions.Add(item2);
			}
			_resolutions.Sort();
			List<string> list = new List<string>();
			for (int j = 0; j < _resolutions.Count; j++)
			{
				list.Add(_resolutions[j].ToString());
			}
			dropdown.ClearOptions();
			dropdown.AddOptions(list);
			dropdown.SetValueWithoutNotify(GetCurrentResolutionIndex());
			_prevWidth = Screen.width;
			_prevHeight = Screen.height;
		}

		public void OnDropDownValueChanged(int index)
		{
			ResolutionEntry resolutionEntry = _resolutions[index];
			_setting.SetResolution(resolutionEntry.width, resolutionEntry.height);
			_setting.Save();
		}

		private void Update()
		{
			if (Screen.width != _prevWidth || Screen.height != _prevHeight)
			{
				BuildResolutionEntries();
			}
		}
	}
}
