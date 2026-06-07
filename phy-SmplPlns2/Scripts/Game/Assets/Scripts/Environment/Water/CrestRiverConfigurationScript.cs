using System;
using Assets.Scripts.Settings;
using Jundroo.Common.Settings;
using UnityEngine;
using WaveHarmonic.Crest;

namespace Assets.Scripts.Environment.Water
{
	public class CrestRiverConfigurationScript : MonoBehaviour
	{
		private FlowLodInput _flow;

		private FoamLodInput _foam;

		private EnumSetting<WaterQualitySettings.FoamSimRate> _foamSimRateSetting;

		private BoolSetting _riversAndWavesSetting;

		private EnumSetting<WaterQualitySettings.WaterQualityLevel> _waterQualitySetting;

		protected virtual void Awake()
		{
			_foam = GetComponent<FoamLodInput>();
			_flow = GetComponent<FlowLodInput>();
			WaterQualitySettings water = Game.Instance.Settings.Quality.Water;
			_waterQualitySetting = water.WaterQuality;
			_riversAndWavesSetting = water.RiversAndWaves;
			_foamSimRateSetting = water.FoamSimulationRate;
			_waterQualitySetting.Changed += OnWaterQualitySettingsChanged;
			_riversAndWavesSetting.Changed += OnWaterQualitySettingsChanged;
			_foamSimRateSetting.Changed += OnWaterQualitySettingsChanged;
			ApplyQualitySettings();
		}

		protected virtual void OnDestroy()
		{
			if (_waterQualitySetting != null)
			{
				_waterQualitySetting.Changed -= OnWaterQualitySettingsChanged;
			}
			if (_riversAndWavesSetting != null)
			{
				_riversAndWavesSetting.Changed -= OnWaterQualitySettingsChanged;
			}
			if (_foamSimRateSetting != null)
			{
				_foamSimRateSetting.Changed -= OnWaterQualitySettingsChanged;
			}
		}

		private void ApplyQualitySettings()
		{
			bool value = _riversAndWavesSetting.Value;
			bool flag = _waterQualitySetting.Value >= WaterQualitySettings.WaterQualityLevel.Medium;
			bool flag2 = _foamSimRateSetting.Value >= WaterQualitySettings.FoamSimRate.Low;
			if (_flow != null)
			{
				_flow.enabled = flag;
			}
			if (_foam != null)
			{
				_foam.enabled = flag2;
			}
			base.gameObject.SetActive(value);
		}

		private void OnWaterQualitySettingsChanged(object sender, EventArgs e)
		{
			ApplyQualitySettings();
		}
	}
}
