using System;
using System.Collections.Generic;
using FMOD;
using FMODUnity;
using TMPro;
using UnityEngine;

namespace Aggro.Core
{
	public class FMODAudioInputSettingUI : AggroSettingUI
	{
		public TMP_Dropdown dropdown;

		private FMODAudioInputSetting _setting;

		private int _driverIndex;

		private int _prevDeviceCount;

		private List<Guid> _driverGuids = new List<Guid>();

		private List<string> _options = new List<string>();

		public override void Set(AggroSettingBase setting)
		{
			if (setting is FMODAudioInputSetting setting2)
			{
				_setting = setting2;
				RuntimeManager.CoreSystem.getRecordNumDrivers(out var numdrivers, out var _);
				BuildDevices(numdrivers);
			}
			else
			{
				UnityEngine.Debug.LogWarning("[SETTINGS] Invalid setting type for FMODAudioInputSettingUI!");
			}
		}

		public override void Refresh()
		{
			RuntimeManager.CoreSystem.getRecordNumDrivers(out var numdrivers, out var _);
			BuildDevices(numdrivers);
		}

		private void BuildDevices(int numOfDrivers)
		{
			_prevDeviceCount = numOfDrivers;
			int num = -1;
			int num2 = -1;
			_driverGuids.Clear();
			_options.Clear();
			for (int i = 0; i < numOfDrivers; i++)
			{
				if (RuntimeManager.CoreSystem.getRecordDriverInfo(i, out var item, 256, out var guid, out var _, out var _, out var _, out var state) == RESULT.OK && (state & DRIVER_STATE.CONNECTED) != 0)
				{
					if ((state & DRIVER_STATE.DEFAULT) != 0)
					{
						num2 = _driverGuids.Count;
					}
					if (guid == _setting.driverGuid)
					{
						num = _driverGuids.Count;
					}
					_driverGuids.Add(guid);
					_options.Add(item);
				}
			}
			dropdown.ClearOptions();
			dropdown.AddOptions(_options);
			if (_options.Count == 0)
			{
				dropdown.interactable = false;
				return;
			}
			dropdown.interactable = true;
			if (num < 0)
			{
				if (num2 < 0)
				{
					num2 = 0;
				}
				num = num2;
				_setting.SetDriverGuid(_driverGuids[num2]);
			}
			dropdown.SetValueWithoutNotify(num);
		}

		public void OnDropDownValueChanged(int index)
		{
			_setting.SetDriverGuid(_driverGuids[index]);
			_setting.Save();
		}

		private void Update()
		{
			if (RuntimeManager.CoreSystem.getRecordNumDrivers(out var numdrivers, out var _) == RESULT.OK && numdrivers != _prevDeviceCount)
			{
				BuildDevices(numdrivers);
			}
		}
	}
}
