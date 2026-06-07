using System;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Settings;
using Enviro;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;
using WaveHarmonic.Crest;
using WaveHarmonic.Crest.Internal;

namespace Assets.Scripts.Environment
{
	public class VolumetricEnvironment : IEnvironment, IDisposable
	{
		private static FieldInfo _enviroInstanceField;

		private bool _bloomEnabled;

		private EnumSetting<EnvironmentQualitySettings.CloudQualityLevel> _cloudsSetting;

		private bool _disposed;

		private bool _enabled = true;

		private EnviroManager _enviroManager;

		private bool _isNight;

		private float _timeTransitionCurrentTime;

		private float _timeTransitionFromValue;

		private float? _timeTransitionTargetTime;

		private float _timeTransitionToValue;

		private bool _timeTransitionWhilePaused;

		public float Brightness => _enviroManager.Weather.targetWeatherType.lightingOverride.directLightIntensityModifier;

		public Vector3 CloudAnimation1
		{
			get
			{
				return _enviroManager.VolumetricClouds.cloudAnimLayer1;
			}
			set
			{
				_enviroManager.VolumetricClouds.cloudAnimLayer1 = value;
			}
		}

		public Vector3 CloudAnimation2
		{
			get
			{
				return _enviroManager.VolumetricClouds.cloudAnimNonScaledLayer1;
			}
			set
			{
				_enviroManager.VolumetricClouds.cloudAnimNonScaledLayer1 = value;
			}
		}

		public float CloudsCoverage => _enviroManager.Weather.targetWeatherType.cloudsOverride.coverageLayer1;

		public bool DynamicWeatherEnabled { get; set; }

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
				_enviroManager.gameObject.SetActive(value);
			}
		}

		public float Fogginess => _enviroManager.Weather.targetWeatherType.fogOverride.fogDensity;

		public bool IsNight
		{
			get
			{
				if (!(TimeOfDay > 18f))
				{
					return TimeOfDay < 6f;
				}
				return true;
			}
		}

		public float LengthOfDay
		{
			get
			{
				return _enviroManager.Time.Settings.cycleLengthInMinutes;
			}
			set
			{
				_enviroManager.Time.Settings.simulate = value > 0f;
				if (_enviroManager.Time.Settings.cycleLengthInMinutes != value)
				{
					_enviroManager.Time.Settings.cycleLengthInMinutes = value;
				}
			}
		}

		public Light Light { get; private set; }

		public bool PauseTimeProgression
		{
			get
			{
				return !_enviroManager.Time.Settings.simulate;
			}
			set
			{
				_enviroManager.Time.Settings.simulate = !value;
			}
		}

		public float TargetTimeOfDay
		{
			get
			{
				if (!_timeTransitionTargetTime.HasValue)
				{
					return TimeOfDay;
				}
				return _timeTransitionToValue;
			}
		}

		public float TimeOfDay
		{
			get
			{
				return _enviroManager.Time.GetTimeOfDay();
			}
			set
			{
				_enviroManager.Time.SetTimeOfDay(value);
			}
		}

		public bool UserSettingsEnabled { get; set; }

		public WeatherPreset WeatherType { get; private set; }

		public VolumetricEnvironment(EnviroManager enviroManager = null)
		{
			_enviroManager = enviroManager;
			_cloudsSetting = Game.Instance.Settings.Quality.Environment.Clouds;
			if (_cloudsSetting.ApplyType == SettingApplyType.Immediate)
			{
				_cloudsSetting.Changed += OnCloudsSettingChanged;
			}
			if (_enviroManager != null)
			{
				ApplyQualitySettings();
			}
		}

		~VolumetricEnvironment()
		{
			Dispose(disposing: false);
		}

		public static void UnsetEnviroInstance()
		{
			if (_enviroInstanceField == null)
			{
				_enviroInstanceField = typeof(EnviroManager).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic);
				if (_enviroInstanceField == null)
				{
					Debug.LogError("Could not find the EnviroManager '_instance' field.");
					return;
				}
			}
			_enviroInstanceField.SetValue(null, null);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public void OnBloomEnabled(bool enabled)
		{
			if (_bloomEnabled != enabled)
			{
				_bloomEnabled = enabled;
			}
		}

		public void OnLevelLoaded()
		{
			string text = "Environment/Sky/VolumetricEnvironment";
			UnityEngine.Object obj = Resources.Load(text);
			if (obj == null)
			{
				Debug.LogError("Could not find the sky dome prefab: " + text);
				return;
			}
			GameObject obj2 = UnityEngine.Object.Instantiate(obj) as GameObject;
			obj2.transform.SetParent(FlightSceneScript.Instance.RenderingManager.transform, worldPositionStays: false);
			obj2.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
			obj2.transform.localScale = Vector3.one;
			if (!obj2.TryGetComponent<EnviroManager>(out var component))
			{
				Debug.LogError("Could not find the time of day sky script.");
				return;
			}
			_enviroManager = component;
			ApplyQualitySettings();
			Camera mainCamera = FlightSceneScript.Instance.CameraScript.MainCamera;
			_enviroManager.Camera = mainCamera;
			mainCamera.clearFlags = CameraClearFlags.Skybox;
			GameObject gameObject = new GameObject("VolumetricEnvironmentAnchor");
			gameObject.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			gameObject.transform.position = Vector3.zero;
			_enviroManager.Cameras.Add(new EnviroCameras
			{
				camera = null,
				quality = null
			});
			_enviroManager.Objects.worldAnchor = gameObject;
			Light = _enviroManager.Objects.directionalLight;
			GameWorld.Instance.FloatingOriginChanged += FloatingOriginChanged;
			UpdateWeather(WeatherPreset.FewClouds, 0f, ignorePause: true);
			OnNightStateChanged(IsNight);
		}

		public void OnLevelUnloaded()
		{
			GameWorld.Instance.FloatingOriginChanged -= FloatingOriginChanged;
			_enviroManager = null;
		}

		public void OnRestartLevel()
		{
		}

		public void OnStartClient(bool isServer)
		{
			if (!isServer)
			{
				_enviroManager.Environment.Settings.windSpeed = 0f;
				_enviroManager.Weather.globalAutoWeatherChange = false;
			}
		}

		public void RegisterCamera(Camera camera)
		{
			_enviroManager.Cameras.Add(new EnviroCameras
			{
				camera = camera,
				quality = null
			});
		}

		public void UnregisterCamera(Camera camera)
		{
			EnviroCameras item = _enviroManager.Cameras.Where((EnviroCameras x) => x.camera == camera).First();
			_enviroManager.Cameras.Remove(item);
		}

		public void Update(float deltaTime, float unscaledDeltaTime)
		{
			if (Enabled)
			{
				LerpTime(deltaTime, unscaledDeltaTime);
				if (_isNight != IsNight)
				{
					OnNightStateChanged(IsNight);
				}
			}
		}

		public void UpdateTimeOfDay(float timeOfDay, float transitionTime)
		{
			UpdateTimeOfDay(timeOfDay, transitionTime, allowReverseTimeTransition: true, ignorePause: true);
		}

		public void UpdateWeather(WeatherPreset preset, float transitionTime, bool ignorePause)
		{
			if (IsEnabled())
			{
				if (ManagerBehaviour<WaterRenderer>.Instance != null)
				{
					WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
					instance.WindSpeed = preset switch
					{
						WeatherPreset.Clear => 25, 
						WeatherPreset.FewClouds => 40, 
						WeatherPreset.ScatteredClouds => 50, 
						WeatherPreset.BrokenClouds => 70, 
						WeatherPreset.Overcast => 100, 
						WeatherPreset.Stormy => 150, 
						WeatherPreset.LightFog => 70, 
						WeatherPreset.HeavyFog => 100, 
						_ => 25, 
					};
				}
				WeatherType = preset;
				string text = preset switch
				{
					WeatherPreset.Clear => "Clear", 
					WeatherPreset.FewClouds => "FewClouds", 
					WeatherPreset.ScatteredClouds => "ScatteredClouds", 
					WeatherPreset.BrokenClouds => "BrokenClouds", 
					WeatherPreset.Overcast => "Overcast", 
					WeatherPreset.Stormy => "Stormy", 
					WeatherPreset.LightFog => "LightFog", 
					WeatherPreset.HeavyFog => "HeavyFog", 
					_ => null, 
				};
				if (!string.IsNullOrEmpty(text))
				{
					UpdateWeather(text);
				}
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (_cloudsSetting.ApplyType == SettingApplyType.Immediate)
				{
					_cloudsSetting.Changed -= OnCloudsSettingChanged;
				}
				_disposed = true;
			}
		}

		private void ApplyQualitySettings()
		{
			if (!(_enviroManager == null))
			{
				string cloudQualityName = _cloudsSetting.Value.ToString();
				EnviroQuality enviroQuality = _enviroManager.Quality.Settings.Qualities.FirstOrDefault((EnviroQuality x) => x.name == cloudQualityName);
				if (enviroQuality != null)
				{
					_enviroManager.Quality.Settings.defaultQuality = enviroQuality;
				}
				else
				{
					Debug.LogError("Could not find cloud quality '" + cloudQualityName + "'");
				}
				Shader.SetGlobalTexture("_EnviroClouds", Texture2D.blackTexture);
			}
		}

		private void ApplyQualitySettingsWeather(EnviroWeatherType weather)
		{
			float fogColorBlend = 1f;
			if (_enviroManager.Quality.Settings.defaultQuality.flatCloudsOverride.flatClouds && (WeatherType == WeatherPreset.Overcast || WeatherType == WeatherPreset.Stormy))
			{
				fogColorBlend = 0f;
			}
			weather.fogOverride.fogColorBlend = fogColorBlend;
		}

		private void FloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			UpdateSeaLevel();
		}

		private bool IsEnabled()
		{
			return _enviroManager?.gameObject.activeSelf ?? false;
		}

		private void LerpTime(float deltaTime, float unscaledDeltaTime)
		{
			if (!_timeTransitionTargetTime.HasValue)
			{
				return;
			}
			_timeTransitionCurrentTime += (_timeTransitionWhilePaused ? unscaledDeltaTime : deltaTime);
			float t = _timeTransitionCurrentTime / _timeTransitionTargetTime.Value;
			if (Mathf.Abs(_timeTransitionToValue - _timeTransitionFromValue) > 12f)
			{
				float num = _timeTransitionFromValue;
				float num2 = _timeTransitionToValue;
				if (num < num2)
				{
					num += 24f;
				}
				else
				{
					num2 += 24f;
				}
				float num3 = Mathf.Lerp(num, num2, t);
				if (num3 > 24f)
				{
					num3 -= 24f;
				}
				TimeOfDay = num3;
			}
			else
			{
				TimeOfDay = Mathf.Lerp(_timeTransitionFromValue, _timeTransitionToValue, t);
			}
			if (_timeTransitionCurrentTime >= _timeTransitionTargetTime.Value)
			{
				_timeTransitionTargetTime = null;
				_timeTransitionWhilePaused = false;
			}
		}

		private void OnCloudsSettingChanged(object sender, SettingChangedEventArgs<EnvironmentQualitySettings.CloudQualityLevel> e)
		{
			ApplyQualitySettings();
		}

		private void OnNightStateChanged(bool isNight)
		{
			_isNight = isNight;
		}

		private void UpdateSeaLevel()
		{
		}

		private void UpdateTimeOfDay(float timeOfDay, float transitionTime, bool allowReverseTimeTransition, bool ignorePause)
		{
			_timeTransitionFromValue = ((TimeOfDay > timeOfDay && !allowReverseTimeTransition) ? (TimeOfDay - 24f) : TimeOfDay);
			_timeTransitionToValue = timeOfDay;
			_timeTransitionTargetTime = transitionTime;
			_timeTransitionCurrentTime = 0f;
			_timeTransitionWhilePaused = ignorePause;
		}

		private void UpdateWeather(string weatherName)
		{
			EnviroWeatherType enviroWeatherType = _enviroManager.Weather.Settings.weatherTypes.FirstOrDefault((EnviroWeatherType x) => string.CompareOrdinal(x.name, weatherName) == 0);
			if (enviroWeatherType != null)
			{
				ApplyQualitySettingsWeather(enviroWeatherType);
				_enviroManager.Weather.ChangeWeather(enviroWeatherType);
			}
			else
			{
				Debug.LogWarning("Could not find weather " + weatherName);
			}
		}
	}
}
