using System;
using Assets.Scripts.Settings;
using Beautify.Universal;
using HorizonBasedAmbientOcclusion.Universal;
using Jundroo.Common.Settings;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Rendering
{
	public class PostProcessingSettingsScript : MonoBehaviour
	{
		private class BeautifyDefaultValues
		{
			public float BloomIntensity { get; }

			public float Brightness { get; }

			public float Contrast { get; }

			public float Saturation { get; }

			public BeautifyDefaultValues(global::Beautify.Universal.Beautify beautify)
			{
				if (!(beautify == null))
				{
					Brightness = beautify.brightness.value;
					Contrast = beautify.contrast.value;
					Saturation = beautify.saturate.value;
					BloomIntensity = beautify.bloomIntensity.value;
				}
			}
		}

		private class HBAODefaultValues
		{
			public float Intensity { get; }

			public HBAODefaultValues(HBAO hbao)
			{
				if (!(hbao == null))
				{
					Intensity = hbao.intensity.value;
				}
			}
		}

		private global::Beautify.Universal.Beautify _beautify;

		private BeautifyDefaultValues _beautifyDefaultValues;

		private HBAO _hbao;

		private HBAODefaultValues _hbaoDefaultValues;

		private PostProcessingQualitySettings _settings;

		private Volume _volume;

		public HBAO AmbientOcclusion => _hbao;

		public global::Beautify.Universal.Beautify Beautify => _beautify;

		protected virtual void Awake()
		{
			_volume = GetComponent<Volume>();
			if (_volume == null)
			{
				Debug.LogError("The 'PostProcessingSettingsScript' was unable to find the post processing volume.", this);
				base.gameObject.SetActive(value: false);
				return;
			}
			if (!_volume.profile.TryGet<global::Beautify.Universal.Beautify>(out _beautify))
			{
				Debug.LogError("The 'PostProcessingSettingsScript' was unable to find the 'Beautify' post processing volume component.", this);
			}
			if (!_volume.profile.TryGet<HBAO>(out _hbao))
			{
				Debug.LogError("The 'PostProcessingSettingsScript' was unable to find the 'HBAO' post processing volume component.", this);
			}
			_beautifyDefaultValues = new BeautifyDefaultValues(_beautify);
			_hbaoDefaultValues = new HBAODefaultValues(_hbao);
			_settings = Game.Instance.Settings.Quality.PostProcessing;
			_settings.AmbientOcclusion.Changed += OnPostProcessingSettingsChanged;
			_settings.AmbientOcclusionIntensity.Changed += OnPostProcessingSettingsChanged;
			_settings.Brightness.Changed += OnPostProcessingSettingsChanged;
			_settings.Contrast.Changed += OnPostProcessingSettingsChanged;
			_settings.Saturation.Changed += OnPostProcessingSettingsChanged;
			_settings.BloomIntensity.Changed += OnPostProcessingSettingsChanged;
			ApplyPostProcessingSettings();
		}

		protected virtual void OnDestroy()
		{
			_settings.AmbientOcclusion.Changed -= OnPostProcessingSettingsChanged;
			_settings.AmbientOcclusionIntensity.Changed -= OnPostProcessingSettingsChanged;
			_settings.Brightness.Changed -= OnPostProcessingSettingsChanged;
			_settings.Contrast.Changed -= OnPostProcessingSettingsChanged;
			_settings.Saturation.Changed -= OnPostProcessingSettingsChanged;
			_settings.BloomIntensity.Changed -= OnPostProcessingSettingsChanged;
		}

		private void ApplyPostProcessingSettings()
		{
			_hbao.intensity.value = LerpSetting(_settings.AmbientOcclusionIntensity, 0f, 2f, _hbaoDefaultValues.Intensity);
			_hbao.active = _settings.AmbientOcclusion.Value && _hbao.intensity.value > 0f;
			_beautify.brightness.value = LerpSetting(_settings.Brightness, 0.1f, 2f, _beautifyDefaultValues.Brightness);
			_beautify.contrast.value = LerpSetting(_settings.Contrast, 0.5f, 1.5f, _beautifyDefaultValues.Contrast);
			_beautify.saturate.value = LerpSetting(_settings.Saturation, -2f, 3f, _beautifyDefaultValues.Saturation);
			_beautify.bloomIntensity.value = LerpSetting(_settings.BloomIntensity, 0f, 3f, _beautifyDefaultValues.BloomIntensity);
		}

		private float LerpSetting(NumericSetting<float> setting, float min, float max, float mid)
		{
			float num = (setting.Max - setting.Min) / 2f;
			float num2 = setting.Min + num;
			if (setting.Value < num2)
			{
				return Mathf.Lerp(min, mid, (setting.Value - setting.Min) / num);
			}
			if (setting.Value > num2)
			{
				return Mathf.Lerp(mid, max, (setting.Value - num2) / num);
			}
			return mid;
		}

		private void OnPostProcessingSettingsChanged(object sender, EventArgs e)
		{
			ApplyPostProcessingSettings();
		}
	}
}
