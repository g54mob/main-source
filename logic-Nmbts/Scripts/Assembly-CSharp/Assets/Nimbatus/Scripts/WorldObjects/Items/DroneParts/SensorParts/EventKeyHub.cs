using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts
{
	public class EventKeyHub : MonoBehaviour
	{
		protected struct KeyPressInfo
		{
			public int Count;

			public float LastActiveTime;

			public KeyPressInfo(int count, float time)
			{
				Count = count;
				LastActiveTime = time;
			}
		}

		public bool CheckInput;

		protected Dictionary<KeyCode, KeyPressInfo> PressedKeys = new Dictionary<KeyCode, KeyPressInfo>();

		protected Dictionary<KeyCode, KeyPressInfo> PressedKeysPreviousFrame = new Dictionary<KeyCode, KeyPressInfo>();

		protected Dictionary<string, KeyPressInfo> PressedKeyStrings = new Dictionary<string, KeyPressInfo>();

		protected Dictionary<string, KeyPressInfo> PressedKeyStringsPreviousFrame = new Dictionary<string, KeyPressInfo>();

		private bool _wasChanged;

		private bool _shouldCheckInput;

		public void OnEnable()
		{
			_shouldCheckInput = true;
			List<DronePrecondition> preconditions = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
			_shouldCheckInput = preconditions == null || !preconditions.Any((DronePrecondition c) => c is NoInputAllowed) || RunningModeSpecifics.Has(ERunningModeSpecific.AlwaysAllowInput);
		}

		public void LateUpdate()
		{
			if (_wasChanged)
			{
				foreach (KeyValuePair<KeyCode, KeyPressInfo> item in PressedKeysPreviousFrame)
				{
					if (PressedKeys.ContainsKey(item.Key))
					{
						PressedKeys[item.Key] = item.Value;
					}
					else
					{
						PressedKeys.Add(item.Key, item.Value);
					}
				}
				foreach (KeyValuePair<string, KeyPressInfo> item2 in PressedKeyStringsPreviousFrame)
				{
					if (PressedKeyStrings.ContainsKey(item2.Key))
					{
						PressedKeyStrings[item2.Key] = item2.Value;
					}
					else
					{
						PressedKeyStrings.Add(item2.Key, item2.Value);
					}
				}
			}
			_wasChanged = false;
		}

		public bool GetKey(KeyCode key)
		{
			bool flag = false;
			if (CheckInput && _shouldCheckInput)
			{
				flag = Input.GetKey(key);
			}
			if (!flag)
			{
				KeyPressInfo value;
				PressedKeys.TryGetValue(key, out value);
				if (value.Count < 1)
				{
					return Time.time <= value.LastActiveTime + Time.fixedDeltaTime;
				}
				return true;
			}
			return true;
		}

		public bool GetKey(string key)
		{
			KeyPressInfo value;
			PressedKeyStrings.TryGetValue(key, out value);
			if (value.Count < 1)
			{
				return Time.time <= value.LastActiveTime + Time.fixedDeltaTime;
			}
			return true;
		}

		public void PressKey(bool press, KeyCode keyCode)
		{
			if (PressedKeysPreviousFrame.ContainsKey(keyCode))
			{
				KeyPressInfo value = PressedKeysPreviousFrame[keyCode];
				value.Count += (press ? 1 : (-1));
				value.LastActiveTime = Time.time;
				PressedKeysPreviousFrame[keyCode] = value;
			}
			else
			{
				PressedKeysPreviousFrame.Add(keyCode, new KeyPressInfo(press ? 1 : 0, Time.time));
			}
			_wasChanged = true;
		}

		public void PressKey(bool press, string keyCode)
		{
			if (PressedKeyStringsPreviousFrame.ContainsKey(keyCode))
			{
				KeyPressInfo value = PressedKeyStringsPreviousFrame[keyCode];
				value.Count += (press ? 1 : (-1));
				value.LastActiveTime = Time.time;
				PressedKeyStringsPreviousFrame[keyCode] = value;
			}
			else
			{
				PressedKeyStringsPreviousFrame.Add(keyCode, new KeyPressInfo(press ? 1 : 0, Time.time));
			}
			_wasChanged = true;
		}
	}
}
