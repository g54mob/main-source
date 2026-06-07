using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using UnityEngine;

namespace SettingScripts
{
	public class SettingsChanger : ISaveable
	{
		[NonSerialized]
		public Dictionary<Setting<float>, float> settingsBases = new Dictionary<Setting<float>, float>();

		[SerializeField]
		public SettingsChangeType changeType;

		[SerializeField]
		public float start;

		[SerializeField]
		public float target;

		[SerializeField]
		public float offset;

		[SerializeField]
		public float amplitude;

		[SerializeField]
		public double startTime;

		[SerializeField]
		public float period;

		[SerializeField]
		public float lastFactor = 1f;

		[SerializeField]
		public bool started;

		[NonSerialized]
		public bool ended;

		public void Update(double time)
		{
			if (ended)
			{
				return;
			}
			if (!started)
			{
				if (time < startTime)
				{
					return;
				}
				started = true;
			}
			else if (changeType == SettingsChangeType.Linear && time > startTime + (double)period)
			{
				ended = true;
				return;
			}
			float num = (float)((time - startTime) % (double)period) / period;
			float num2 = changeType switch
			{
				SettingsChangeType.Linear => start * (num - 1f) + target * num, 
				SettingsChangeType.Sinus => offset + amplitude * Mathf.Sin(MathF.PI * 2f * num), 
				SettingsChangeType.Sawtooth => offset + amplitude * (4f * Mathf.Abs((num + 0.75f) % 1f - 0.5f) - 1f), 
				_ => 1f, 
			};
			if (float.IsNaN(num2))
			{
				return;
			}
			foreach (KeyValuePair<Setting<float>, float> settingsBasis in settingsBases)
			{
				settingsBasis.Key.SetValue(settingsBasis.Value * num2);
			}
			lastFactor = num2;
		}

		public JObject SaveState()
		{
			JObject jObject = SerializationHelper.SerializeGeneralObject(this);
			JObject jObject2 = new JObject();
			foreach (KeyValuePair<Setting<float>, float> settingsBasis in settingsBases)
			{
				string keyOfSetting = SettingsReferenceParser.GetKeyOfSetting(settingsBasis.Key);
				if (keyOfSetting != null)
				{
					jObject2[keyOfSetting] = settingsBasis.Value;
				}
			}
			jObject["settingsBases"] = jObject2;
			return jObject;
		}

		public void LoadState(JObject state)
		{
			SerializationHelper.DeserializeGeneralObject(this, state);
			settingsBases.Clear();
			if (!(state["settingsBases"] is JObject jObject))
			{
				return;
			}
			foreach (KeyValuePair<string, JToken> item in jObject)
			{
				if (SettingsReferenceParser.GetSetting(item.Key) is Setting<float> key)
				{
					settingsBases.Add(key, item.Value.ToObject<float>());
				}
			}
		}
	}
}
