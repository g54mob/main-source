using System.Collections.Generic;
using Data.Lighting;
using Data.Variables;
using Events;
using Events.Lighting;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Logic.Lighting
{
	public class DayNightCycleManager : MonoBehaviour
	{
		public enum CycleState
		{
			RegularCycle = 0,
			FixedDay = 1,
			FixedSunset = 2,
			FixedNight = 3,
			FixedSunrise = 4
		}

		[Expandable]
		[SerializeField]
		private List<DayNightCycleMomentSO> _dayNightCycleMoments = new List<DayNightCycleMomentSO>();

		[SerializeField]
		private float _transitionDurationInSec;

		[SerializeField]
		private Material _cloudsMaterial;

		[Header("Locators & Events")]
		[SerializeField]
		private DirectionalLightManagerLocator _directionalLightManagerLocator;

		[SerializeField]
		private GlobalVolumeManagerLocator _globalVolumeManagerLocator;

		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private SetLightingConfigEventSO _setLightingConfigEvent;

		[SerializeField]
		private BaseEvent _resetToDefaultLightingConfigEvent;

		[SerializeField]
		private SetDayNightCycleMomentEventSO _setDayNightCycleMomentEvent;

		[SerializeField]
		private IntVariableSO _dayNightCycleStateSO;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private BoolVariableSO _dayNightCycleUnlockedSO;

		private float _cycleTime;

		private float _transitionTimer;

		private DayNightCycleMomentSO _lastMoment;

		private DayNightCycleMomentSO _nextMoment;

		private bool _transitioning;

		private bool _paused;

		private Light _mainLight;

		private bool _customLightingIsActive;

		private static readonly int CloudsColorHighProperty = Shader.PropertyToID("_ColorHigh");

		private static readonly int CloudsColorLowProperty = Shader.PropertyToID("_ColorLow");

		private static readonly int Night = Shader.PropertyToID("_Night");

		public Color CloudsColorHigh => _cloudsMaterial.GetColor(CloudsColorHighProperty);

		public Color CloudsColorLow => _cloudsMaterial.GetColor(CloudsColorLowProperty);

		private void OnEnable()
		{
			_setLightingConfigEvent.Register(HandleSetLightingConfig);
			_resetToDefaultLightingConfigEvent.Register(HandleResetToDefaultLightingConfig);
		}

		private void OnDisable()
		{
			_setLightingConfigEvent.UnRegister(HandleSetLightingConfig);
			_resetToDefaultLightingConfigEvent.UnRegister(HandleResetToDefaultLightingConfig);
			_dayNightCycleStateSO.ValueChanged -= OnDayNightCycleStateChanged;
		}

		private void HandleSetLightingConfig(LightingConfig customLighting)
		{
			_customLightingIsActive = true;
		}

		private void HandleResetToDefaultLightingConfig()
		{
			_customLightingIsActive = false;
			if (!_transitioning)
			{
				ApplyMomentSettings(_lastMoment);
			}
		}

		private void Start()
		{
			_mainLight = _directionalLightManagerLocator.Value.DirectionalLight;
			if (VolumeManager.instance.isInitialized)
			{
				SetSavedCycleState();
			}
			else
			{
				RenderPipelineManager.activeRenderPipelineCreated += OnActiveRenderPipelineCreated;
			}
		}

		private void OnActiveRenderPipelineCreated()
		{
			RenderPipelineManager.activeRenderPipelineCreated -= OnActiveRenderPipelineCreated;
			SetSavedCycleState();
		}

		private void SetSavedCycleState()
		{
			SetCycleState((CycleState)_dayNightCycleStateSO.Value);
			_dayNightCycleStateSO.ValueChanged += OnDayNightCycleStateChanged;
		}

		private void OnDayNightCycleStateChanged(int newState)
		{
			SetCycleState((CycleState)newState);
		}

		private void SetCycleState(CycleState cycleState)
		{
			if (cycleState == CycleState.RegularCycle)
			{
				_paused = false;
				SetDayNightCycleMoment(0);
			}
			else
			{
				_paused = true;
				SetDayNightCycleMoment((int)(cycleState - 1));
			}
		}

		private void SetDayNightCycleMoment(int index)
		{
			float num = 0f;
			for (int i = 0; i < index; i++)
			{
				num += _dayNightCycleMoments[i].DurationInSec;
			}
			_cycleTime = num;
			_transitioning = false;
			_nextMoment = _dayNightCycleMoments[index];
			ApplyMomentSettings(_nextMoment);
		}

		private void Update()
		{
			if (_paused || _customLightingIsActive || !_dayNightCycleUnlockedSO.Value)
			{
				return;
			}
			if (_transitioning)
			{
				Transitioning();
				return;
			}
			DayNightCycleMomentSO currentMoment = GetCurrentMoment();
			if (_lastMoment == null || _lastMoment != currentMoment)
			{
				_nextMoment = currentMoment;
				_transitionTimer = 0f;
				_transitioning = true;
			}
			_cycleTime += Time.deltaTime;
		}

		private DayNightCycleMomentSO GetCurrentMoment()
		{
			float num = 0f;
			foreach (DayNightCycleMomentSO dayNightCycleMoment in _dayNightCycleMoments)
			{
				num += dayNightCycleMoment.DurationInSec;
				if (_cycleTime < num)
				{
					return dayNightCycleMoment;
				}
			}
			_cycleTime = 0f;
			return _dayNightCycleMoments[0];
		}

		private void Transitioning()
		{
			float t = Mathf.SmoothStep(0f, 1f, _transitionTimer / _transitionDurationInSec);
			_mainLight.color = Color.Lerp(_lastMoment.MainLightColor, _nextMoment.MainLightColor, t);
			_mainLight.transform.forward = Vector3.Lerp(_lastMoment.MainLightDirection, _nextMoment.MainLightDirection, t);
			_mainLight.intensity = Mathf.Lerp(_lastMoment.MainLightIntensity, _nextMoment.MainLightIntensity, t);
			_mainLight.colorTemperature = Mathf.Lerp(_lastMoment.MainLightTemperature, _nextMoment.MainLightTemperature, t);
			_mainLight.shadowStrength = Mathf.Lerp(_lastMoment.ShadowsIntensity, _nextMoment.ShadowsIntensity, t);
			RenderSettings.ambientLight = Color.Lerp(_lastMoment.AmbientColor, _nextMoment.AmbientColor, t);
			_cloudsMaterial.SetColor(CloudsColorHighProperty, Color.Lerp(_lastMoment.CloudsColorHigh, _nextMoment.CloudsColorHigh, t));
			_cloudsMaterial.SetColor(CloudsColorLowProperty, Color.Lerp(_lastMoment.CloudsColorLow, _nextMoment.CloudsColorLow, t));
			_globalVolumeManagerLocator.Value.Bloom.intensity.Override(Mathf.Lerp(_lastMoment.BloomIntensity, _nextMoment.BloomIntensity, t));
			_globalVolumeManagerLocator.Value.Bloom.threshold.Override(Mathf.Lerp(_lastMoment.BloomThreshold, _nextMoment.BloomThreshold, t));
			_globalVolumeManagerLocator.Value.ColorAdjustments.contrast.Override(Mathf.Lerp(_lastMoment.Contrast, _nextMoment.Contrast, t));
			_globalVolumeManagerLocator.Value.ColorAdjustments.saturation.Override(Mathf.Lerp(_lastMoment.Saturation, _nextMoment.Saturation, t));
			_globalVolumeManagerLocator.Value.ColorAdjustments.postExposure.Override(Mathf.Lerp(_lastMoment.PostExposure, _nextMoment.PostExposure, t));
			_cameraLocator.Camera.UpdateVolumeStack();
			Shader.SetGlobalFloat(Night, Mathf.Lerp(_lastMoment.Night, _nextMoment.Night, t));
			_audioManagerLocator.AudioManager.SetDaytimeParameter(Mathf.Lerp(_lastMoment.DaytimeSFXParameter, _nextMoment.DaytimeSFXParameter, t));
			_transitionTimer += Time.deltaTime;
			if (_transitionTimer >= _transitionDurationInSec)
			{
				_transitioning = false;
				ApplyMomentSettings(_nextMoment);
			}
		}

		public void ApplyMomentSettings(DayNightCycleMomentSO nextMoment)
		{
			_lastMoment = (_nextMoment = nextMoment);
			_mainLight.color = nextMoment.MainLightColor;
			_mainLight.transform.forward = nextMoment.MainLightDirection;
			_mainLight.intensity = nextMoment.MainLightIntensity;
			_mainLight.colorTemperature = nextMoment.MainLightTemperature;
			_mainLight.shadowStrength = nextMoment.ShadowsIntensity;
			_cloudsMaterial.SetColor(CloudsColorHighProperty, nextMoment.CloudsColorHigh);
			_cloudsMaterial.SetColor(CloudsColorLowProperty, nextMoment.CloudsColorLow);
			_globalVolumeManagerLocator.Value.ColorLookup.texture.Override(nextMoment.LookUpTexture);
			_globalVolumeManagerLocator.Value.Bloom.intensity.Override(nextMoment.BloomIntensity);
			_globalVolumeManagerLocator.Value.Bloom.threshold.Override(nextMoment.BloomThreshold);
			_globalVolumeManagerLocator.Value.ColorAdjustments.contrast.Override(nextMoment.Contrast);
			_globalVolumeManagerLocator.Value.ColorAdjustments.saturation.Override(nextMoment.Saturation);
			_globalVolumeManagerLocator.Value.ColorAdjustments.postExposure.Override(nextMoment.PostExposure);
			_cameraLocator.Camera.UpdateVolumeStack();
			Shader.SetGlobalFloat(Night, nextMoment.Night);
			RenderSettings.ambientLight = nextMoment.AmbientColor;
			_audioManagerLocator.AudioManager.SetDaytimeParameter(nextMoment.DaytimeSFXParameter);
			_setDayNightCycleMomentEvent.Fire(nextMoment);
		}
	}
}
