using System;
using System.Collections;
using System.Reflection;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Settings;
using Jundroo.Common.Settings;
using UnityEngine;
using WaveHarmonic.Crest;
using WaveHarmonic.Crest.Internal;

namespace Assets.Scripts.Environment.Water
{
	public class CrestWaterConfigurationScript : MonoBehaviour, ITimeProvider
	{
		private static class ShaderPropertyIds
		{
			public static readonly int CausticsEnabled = Shader.PropertyToID("_Crest_CausticsEnabled");

			public static readonly int PlanarReflectionsEnabled = (int)typeof(WaterRenderer).GetNestedType("ShaderIDs", BindingFlags.Static | BindingFlags.NonPublic).GetField("s_PlanarReflectionsEnabled", BindingFlags.Static | BindingFlags.Public).GetValue(null);
		}

		private EnumSetting<WaterQualitySettings.FoamSimRate> _foamSimRateSetting;

		private FlightSceneNetworkScript _fsn;

		private BoolSetting _reflectionsSetting;

		private BoolSetting _riversAndWavesSetting;

		private Material _waterMaterial;

		private EnumSetting<WaterQualitySettings.WaterQualityLevel> _waterQualitySetting;

		public float Delta => UnityEngine.Time.fixedDeltaTime;

		public float Time => _fsn.PhysicsTime;

		protected virtual void OnDestroy()
		{
			if (_reflectionsSetting != null)
			{
				_reflectionsSetting.Changed -= OnWaterQualitySettingsChanged;
			}
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
			if (_waterMaterial != null)
			{
				UnityEngine.Object.Destroy(_waterMaterial);
			}
		}

		protected IEnumerator Start()
		{
			WaterRenderer instance;
			while ((instance = ManagerBehaviour<WaterRenderer>.Instance) == null)
			{
				yield return null;
			}
			FlightSceneScript instance2 = FlightSceneScript.Instance;
			if (instance2 != null)
			{
				_fsn = instance2.FlightSceneNetwork;
				instance.Viewer = instance2.CameraScript.MainCamera;
				instance.PrimaryLight = instance2.Environment.Light;
				instance.TimeProviders.Push(this);
			}
			_waterMaterial = UnityEngine.Object.Instantiate(instance.Surface.Material);
			instance.Surface.Material = _waterMaterial;
			WaterQualitySettings water = Game.Instance.Settings.Quality.Water;
			_reflectionsSetting = water.WaterReflections;
			_waterQualitySetting = water.WaterQuality;
			_riversAndWavesSetting = water.RiversAndWaves;
			_foamSimRateSetting = water.FoamSimulationRate;
			_reflectionsSetting.Changed += OnWaterQualitySettingsChanged;
			_waterQualitySetting.Changed += OnWaterQualitySettingsChanged;
			_riversAndWavesSetting.Changed += OnWaterQualitySettingsChanged;
			_foamSimRateSetting.Changed += OnWaterQualitySettingsChanged;
			ApplyQualitySettings();
		}

		private void ApplyQualitySettings()
		{
			WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
			Material material = instance.Surface.Material;
			bool flag = _waterQualitySetting.Value >= WaterQualitySettings.WaterQualityLevel.High;
			bool flag2 = _waterQualitySetting.Value >= WaterQualitySettings.WaterQualityLevel.Medium;
			bool flag3 = _foamSimRateSetting.Value >= WaterQualitySettings.FoamSimRate.Low;
			instance.Reflections.Enabled = _reflectionsSetting.Value;
			material.SetFloat(ShaderPropertyIds.PlanarReflectionsEnabled, _reflectionsSetting.Value ? 1 : 0);
			bool value = _riversAndWavesSetting.Value;
			instance.AnimatedWavesLod.Enabled = value;
			instance.LevelLod.Enabled = value;
			instance.LodLevels = ((!value) ? 4 : (flag ? 9 : 7));
			instance.FoamLod.Enabled = flag3;
			if (flag3)
			{
				switch (_foamSimRateSetting.Value)
				{
				default:
					instance.FoamLod.SimulationFrequency = 15;
					break;
				case WaterQualitySettings.FoamSimRate.Medium:
					instance.FoamLod.SimulationFrequency = 30;
					break;
				case WaterQualitySettings.FoamSimRate.High:
					instance.FoamLod.SimulationFrequency = 60;
					break;
				}
			}
			instance.FlowLod.Enabled = flag2;
			instance.DynamicWavesLod.Enabled = flag2 && value;
			instance.AbsorptionLod.Enabled = flag2 && value;
			instance.ScatteringLod.Enabled = flag2 && value;
			material.SetFloat(ShaderPropertyIds.CausticsEnabled, flag2 ? 1 : 0);
			ShapeFFT componentInChildren = GetComponentInChildren<ShapeFFT>(includeInactive: true);
			if (componentInChildren != null)
			{
				componentInChildren.enabled = value;
				componentInChildren.gameObject.SetActive(value);
			}
			StartCoroutine(ToggleUnderwaterRenderer());
		}

		private void OnWaterQualitySettingsChanged(object sender, EventArgs e)
		{
			ApplyQualitySettings();
		}

		private IEnumerator ToggleUnderwaterRenderer()
		{
			WaterRenderer renderer = ManagerBehaviour<WaterRenderer>.Instance;
			renderer.Underwater.Enabled = false;
			yield return null;
			renderer.Underwater.Enabled = true;
		}
	}
}
