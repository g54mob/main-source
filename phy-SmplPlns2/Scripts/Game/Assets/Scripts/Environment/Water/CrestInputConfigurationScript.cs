using System;
using Assets.Scripts.Settings;
using Jundroo.Common.Settings;
using UnityEngine;
using WaveHarmonic.Crest;

namespace Assets.Scripts.Environment.Water
{
	public class CrestInputConfigurationScript : MonoBehaviour
	{
		private AnimatedWavesLodInput _animatedWaves;

		private FlowLodInput _flow;

		private FoamLodInput _foam;

		private EnumSetting<WaterQualitySettings.FoamSimRate> _foamSimRateSetting;

		private LevelLodInput _level;

		private BoolSetting _riversAndWavesSetting;

		[SerializeField]
		private bool _setGameObjectActiveToRiversAndWaves;

		private EnumSetting<WaterQualitySettings.WaterQualityLevel> _waterQualitySetting;

		protected virtual void Awake()
		{
			_animatedWaves = GetComponent<AnimatedWavesLodInput>();
			_foam = GetComponent<FoamLodInput>();
			_flow = GetComponent<FlowLodInput>();
			_level = GetComponent<LevelLodInput>();
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
				Renderer renderer = _flow.GetData<RendererLodInputData>()?.Renderer;
				if (renderer != null)
				{
					renderer.enabled = flag;
				}
			}
			if (_foam != null)
			{
				_foam.enabled = flag2;
				Renderer renderer2 = _foam.GetData<RendererLodInputData>()?.Renderer;
				if (renderer2 != null)
				{
					renderer2.enabled = flag2;
				}
			}
			if (_level != null)
			{
				_level.enabled = value;
				Renderer renderer3 = _level.GetData<RendererLodInputData>()?.Renderer;
				if (renderer3 != null)
				{
					renderer3.enabled = value;
				}
			}
			if (_animatedWaves != null)
			{
				_animatedWaves.enabled = value;
				Renderer renderer4 = _animatedWaves.GetData<RendererLodInputData>()?.Renderer;
				if (renderer4 != null)
				{
					renderer4.enabled = value;
				}
			}
			if (_setGameObjectActiveToRiversAndWaves)
			{
				base.gameObject.SetActive(value);
			}
		}

		private void OnWaterQualitySettingsChanged(object sender, EventArgs e)
		{
			ApplyQualitySettings();
		}
	}
}
