using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.ScriptableSettings;
using UnityEngine;
using UnityEngine.Audio;

namespace CTS
{
	public class SoundSettings : CTSSingleton<SoundSettings>
	{
		[SerializeField]
		private SettingObject<float> _globalVolume;

		[SerializeField]
		private SoundType _globalVolumeKey;

		[SerializeField]
		private SerializableDictionary<SoundType, SettingObject<float>> _settings = new SerializableDictionary<SoundType, SettingObject<float>>();

		[SerializeField]
		private AudioMixer _masterMixer;

		private readonly Dictionary<StringKey<SoundType>, SettingObject<float>> _keyedSettings = new Dictionary<StringKey<SoundType>, SettingObject<float>>();

		protected override void SingletonAwake()
		{
			_globalVolume.ValueChanged += OnVolumeValueChanged;
			_keyedSettings.Add(_globalVolumeKey, _globalVolume);
			foreach (var (soundType2, settingObject2) in _settings)
			{
				_keyedSettings.Add(soundType2, settingObject2);
				settingObject2.ValueChanged += OnVolumeValueChanged;
			}
		}

		private void Start()
		{
			UpdateVolume();
		}

		protected override void OnSingletonDestroy()
		{
			_globalVolume.ValueChanged -= OnVolumeValueChanged;
			foreach (KeyValuePair<SoundType, SettingObject<float>> setting in _settings)
			{
				setting.Deconstruct(out var _, out var value);
				value.ValueChanged -= OnVolumeValueChanged;
			}
		}

		private void OnVolumeValueChanged(float obj)
		{
			UpdateVolume();
		}

		private void UpdateVolume()
		{
			SetMixerFloat(_globalVolumeKey, _globalVolume);
			foreach (var (key, setting) in _settings)
			{
				SetMixerFloat(key, setting);
			}
		}

		private void SetMixerFloat(SoundType key, SettingObject<float> setting)
		{
			float f = setting.GetValue().Remap(0f, 100f, 0.0001f, 1f);
			_masterMixer.SetFloat(key.Key, Mathf.Log10(f) * 20f);
		}
	}
}
