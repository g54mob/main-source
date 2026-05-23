#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_WARNINGS
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/Settings/ConnectedExtraDevicesSO", fileName = "ConnectedExtraDevicesSO", order = 0)]
	public class ConnectedExtraDevicesSO : ScriptableObject
	{
		private readonly Dictionary<string, InputDevice> _currentlyConnectedDevices = new Dictionary<string, InputDevice>();

		private readonly Dictionary<string, bool> _savedConnectedDevices = new Dictionary<string, bool>();

		private int _mouseCount;

		private int _keyboardCount;

		public bool HasOneMouseAndOneKeyboard
		{
			get
			{
				if (_mouseCount == 1)
				{
					return _keyboardCount == 1;
				}
				return false;
			}
		}

		public event Action OnConnectedDevicesUpdate = delegate
		{
		};

		private void OnEnable()
		{
			InputSystem.onDeviceChange += OnDeviceChange;
		}

		private void OnDisable()
		{
			InputSystem.onDeviceChange -= OnDeviceChange;
		}

		public void ApplySaveDataConnectedDevices(List<string> deviceNames, List<bool> deviceEnable)
		{
			if (deviceNames.IsNullOrEmpty())
			{
				ResetToDefault();
				return;
			}
			_savedConnectedDevices.Clear();
			for (int i = 0; i < deviceNames.Count; i++)
			{
				_savedConnectedDevices.Add(deviceNames[i], deviceEnable[i]);
			}
			ClearConnectedDevices();
			foreach (InputDevice device in InputSystem.devices)
			{
				AddConnectedDevice(device);
				if (_savedConnectedDevices.TryGetValue(device.name, out var value))
				{
					if (value)
					{
						InputSystem.EnableDevice(device);
					}
					else
					{
						InputSystem.DisableDevice(device);
					}
				}
				else
				{
					InputSystem.EnableDevice(device);
					_savedConnectedDevices.Add(device.name, value: true);
				}
			}
			this.OnConnectedDevicesUpdate();
		}

		public bool TrySetConnectedDevices(int bitmask)
		{
			List<InputDevice> currentlyConnectedDevices = GetCurrentlyConnectedDevices();
			bool flag = false;
			for (int i = 0; i < currentlyConnectedDevices.Count; i++)
			{
				InputDevice inputDevice = currentlyConnectedDevices[i];
				if ((bitmask & (1 << i)) != 0 && inputDevice is Mouse)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.LogWarning("Trying to disable all 'Mouse' input devices would result in a softlock.", "TrySetConnectedDevices", 90);
				return false;
			}
			for (int j = 0; j < currentlyConnectedDevices.Count; j++)
			{
				InputDevice inputDevice2 = currentlyConnectedDevices[j];
				bool flag2 = (bitmask & (1 << j)) != 0;
				_savedConnectedDevices[inputDevice2.name] = flag2;
				if (flag2)
				{
					InputSystem.EnableDevice(inputDevice2);
				}
				else
				{
					InputSystem.DisableDevice(inputDevice2);
				}
			}
			return true;
		}

		public int GetInputsBitmask()
		{
			List<InputDevice> currentlyConnectedDevices = GetCurrentlyConnectedDevices();
			int num = 0;
			for (int i = 0; i < currentlyConnectedDevices.Count; i++)
			{
				if (currentlyConnectedDevices[i].enabled)
				{
					num |= 1 << i;
				}
			}
			return num;
		}

		private void OnDeviceChange(InputDevice device, InputDeviceChange change)
		{
			switch (change)
			{
			case InputDeviceChange.Added:
			case InputDeviceChange.Reconnected:
				if (!_currentlyConnectedDevices.ContainsKey(device.name))
				{
					AddConnectedDevice(device);
					if (!_savedConnectedDevices.TryGetValue(device.name, out var value))
					{
						value = !HasOneMouseAndOneKeyboard || device is Mouse || device is Keyboard;
						_savedConnectedDevices.Add(device.name, value);
					}
					if (value)
					{
						InputSystem.EnableDevice(device);
					}
					else
					{
						InputSystem.DisableDevice(device);
					}
					this.OnConnectedDevicesUpdate();
				}
				break;
			case InputDeviceChange.Removed:
			case InputDeviceChange.Disconnected:
				RemoveConnectedDevice(device);
				this.OnConnectedDevicesUpdate();
				break;
			}
		}

		public void ResetToDefault()
		{
			ClearConnectedDevices();
			_savedConnectedDevices.Clear();
			foreach (InputDevice device in InputSystem.devices)
			{
				if (_currentlyConnectedDevices.ContainsKey(device.name))
				{
					return;
				}
				AddConnectedDevice(device);
				_savedConnectedDevices[device.name] = true;
			}
			if (!HasOneMouseAndOneKeyboard)
			{
				this.LogWarning($"Multiple mouses {_mouseCount} and/or keyboards {_keyboardCount} detected. Enabling all devices.", "ResetToDefault", 176);
				return;
			}
			this.Log("Single mouse and keyboard detected, disabling other devices.", "ResetToDefault", 180);
			foreach (KeyValuePair<string, InputDevice> currentlyConnectedDevice in _currentlyConnectedDevices)
			{
				if (currentlyConnectedDevice.Value is Mouse || currentlyConnectedDevice.Value is Keyboard)
				{
					_savedConnectedDevices[currentlyConnectedDevice.Key] = true;
					InputSystem.EnableDevice(currentlyConnectedDevice.Value);
				}
				else
				{
					_savedConnectedDevices[currentlyConnectedDevice.Key] = false;
					InputSystem.DisableDevice(currentlyConnectedDevice.Value);
				}
			}
		}

		private void AddConnectedDevice(InputDevice device)
		{
			_currentlyConnectedDevices.Add(device.name, device);
			if (device is Mouse)
			{
				_mouseCount++;
			}
			if (device is Keyboard)
			{
				_keyboardCount++;
			}
		}

		private void RemoveConnectedDevice(InputDevice device)
		{
			_currentlyConnectedDevices.Remove(device.name);
			if (device is Mouse)
			{
				_mouseCount--;
			}
			if (device is Keyboard)
			{
				_keyboardCount--;
			}
		}

		private void ClearConnectedDevices()
		{
			_currentlyConnectedDevices.Clear();
			_mouseCount = 0;
			_keyboardCount = 0;
		}

		public List<InputDevice> GetCurrentlyConnectedDevices()
		{
			List<InputDevice> list = new List<InputDevice>();
			foreach (InputDevice value in _currentlyConnectedDevices.Values)
			{
				list.Add(value);
			}
			return list;
		}

		public List<string> GetSavedDeviceNames()
		{
			List<string> list = new List<string>();
			foreach (string key in _savedConnectedDevices.Keys)
			{
				list.Add(key);
			}
			return list;
		}

		public List<bool> GetSavedDeviceEnable()
		{
			List<bool> list = new List<bool>();
			foreach (bool value in _savedConnectedDevices.Values)
			{
				list.Add(value);
			}
			return list;
		}
	}
}
