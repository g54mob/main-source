using System.Collections.Generic;
using FMOD;
using FMODUnity;
using TMPro;
using UnityEngine;

namespace Aggro.Core
{
	public class FMODAudioOutputSettingUI : AggroSettingUI
	{
		public TMP_Dropdown dropdown;

		private FMODAudioOutputSetting _setting;

		private int _driverIndex;

		private int _prevDeviceCount;

		private List<int> _driverIndices = new List<int>();

		private List<string> _options = new List<string>();

		public override void Set(AggroSettingBase setting)
		{
			if (setting is FMODAudioOutputSetting setting2)
			{
				_setting = setting2;
				RuntimeManager.CoreSystem.getNumDrivers(out var numdrivers);
				BuildDevices(numdrivers);
			}
			else
			{
				UnityEngine.Debug.LogWarning("[SETTINGS] Invalid setting type for FMODAudioOutputSetting!");
			}
		}

		public override void Refresh()
		{
			RuntimeManager.CoreSystem.getNumDrivers(out var numdrivers);
			BuildDevices(numdrivers);
		}

		private void BuildDevices(int numOfDrivers)
		{
			_prevDeviceCount = numOfDrivers;
			RuntimeManager.CoreSystem.getDriver(out var driver);
			_driverIndices.Clear();
			_options.Clear();
			int num = 0;
			for (int i = 0; i < numOfDrivers; i++)
			{
				if (RuntimeManager.CoreSystem.getDriverInfo(i, out var item, 256, out var _, out var _, out var _, out var _) == RESULT.OK)
				{
					if (driver == i)
					{
						num = _options.Count;
					}
					_driverIndices.Add(i);
					_options.Add(item);
				}
			}
			dropdown.ClearOptions();
			dropdown.AddOptions(_options);
			dropdown.SetValueWithoutNotify(num);
			if (num >= 0 && num < _driverIndices.Count)
			{
				dropdown.interactable = true;
				_setting.SetDriverIndex(_driverIndices[num]);
			}
			else
			{
				dropdown.interactable = false;
				_setting.SetDriverIndex(0);
			}
		}

		public void OnDropDownValueChanged(int index)
		{
			_setting.SetDriverIndex(_driverIndices[index]);
			_setting.Save();
		}

		private void Update()
		{
			if (RuntimeManager.CoreSystem.getNumDrivers(out var numdrivers) == RESULT.OK && numdrivers != _prevDeviceCount)
			{
				BuildDevices(numdrivers);
			}
		}
	}
}
