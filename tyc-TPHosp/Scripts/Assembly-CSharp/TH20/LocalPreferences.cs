#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public class LocalPreferences
	{
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class VideoPreferences
		{
			public enum HospitalLightingQualityMode
			{
				Low = 0,
				Medium = 1,
				High = 2
			}

			public enum ParticleQualityMode
			{
				Low = 0,
				High = 1
			}

			public enum ShadowFadeDistanceMode
			{
				Near = 0,
				Medium = 1,
				Far = 2
			}

			public enum LightFadeDistanceMode
			{
				Near = 0,
				Medium = 1,
				Far = 2
			}

			[NonSerialized]
			private int _currentQualityDefaultMasterTextureLimit;

			private int? _customMasterTextureLimit;

			[NonSerialized]
			private AnisotropicFiltering _currentQualityDefaultAnisotropicFiltering;

			private AnisotropicFiltering? _customAnisotropicFiltering;

			[NonSerialized]
			private ShadowQuality _currentQualityDefaultShadowQuality;

			private ShadowQuality? _customShadowQuality;

			[NonSerialized]
			private ShadowResolution _currentQualityDefaultShadowResolution;

			private ShadowResolution? _customShadowResolution;

			[NonSerialized]
			private int _currentQualityDefaultVSyncCount;

			private int? _customVSyncCount;

			[NonSerialized]
			private float _currentQualityDefaultLODBias;

			private float? _customLODBias;

			public static readonly float MinLODBias = 1f;

			public static readonly float MaxLODBias = 3f;

			private bool _ambientOcclusion = true;

			private bool _bloom = true;

			private bool _antialiasing = true;

			private bool _depthOfField = true;

			private ParticleQualityMode _particles = ParticleQualityMode.High;

			private ShadowFadeDistanceMode _hospitalShadowDistance = ShadowFadeDistanceMode.Far;

			private LightFadeDistanceMode _lightFadeDistance = LightFadeDistanceMode.Far;

			private HospitalLightingQualityMode _hospitalLightingQuality = HospitalLightingQualityMode.High;

			private int _maximumFPS = 150;

			public static readonly int MinimumMaximumFPS = 30;

			public static readonly int MaximumMaximumFPS = 300;

			private float _characterDrawDistance = 1f;

			public int QualitySettingsIndex
			{
				get
				{
					return QualitySettings.GetQualityLevel();
				}
				set
				{
					Logging.Info(LogChannels.Preferences, "Changing quality level from {0} to {1} (resetting to defaults first)", QualitySettings.GetQualityLevel(), value);
					QualitySettings.SetQualityLevel(value, applyExpensiveChanges: true);
					StoreCurrentQualitySettingValues();
					ResetToBaseQualityLevel();
				}
			}

			public int? CustomMasterTextureLimit
			{
				get
				{
					return _customMasterTextureLimit;
				}
				set
				{
					if (value.HasValue)
					{
						Logging.Info(LogChannels.Preferences, "Changing CustomMasterTextureLimit to {0}", value.Value);
						QualitySettings.masterTextureLimit = value.Value;
					}
					else
					{
						Logging.Info(LogChannels.Preferences, "Resetting CustomMasterTextureLimit to default of {0}", _currentQualityDefaultMasterTextureLimit);
						QualitySettings.masterTextureLimit = _currentQualityDefaultMasterTextureLimit;
					}
					_customMasterTextureLimit = value;
				}
			}

			public AnisotropicFiltering? CustomAnisotropicFiltering
			{
				get
				{
					return _customAnisotropicFiltering;
				}
				set
				{
					if (value.HasValue)
					{
						Logging.Info(LogChannels.Preferences, "Changing CustomAnisotropicFiltering to {0}", value.Value);
						QualitySettings.anisotropicFiltering = value.Value;
					}
					else
					{
						Logging.Info(LogChannels.Preferences, "Resetting CustomAnisotropicFiltering to default of {0}", _currentQualityDefaultAnisotropicFiltering);
						QualitySettings.anisotropicFiltering = _currentQualityDefaultAnisotropicFiltering;
					}
					_customAnisotropicFiltering = value;
				}
			}

			public ShadowQuality? CustomShadowQuality
			{
				get
				{
					return _customShadowQuality;
				}
				set
				{
					if (value.HasValue)
					{
						Logging.Info(LogChannels.Preferences, "Changing CustomShadowQuality to {0}", value.Value);
						QualitySettings.shadows = value.Value;
					}
					else
					{
						Logging.Info(LogChannels.Preferences, "Resetting CustomShadowQuality to default of {0}", _currentQualityDefaultShadowQuality);
						QualitySettings.shadows = _currentQualityDefaultShadowQuality;
					}
					_customShadowQuality = value;
				}
			}

			public ShadowResolution? CustomShadowResolution
			{
				get
				{
					return _customShadowResolution;
				}
				set
				{
					if (value.HasValue)
					{
						Logging.Info(LogChannels.Preferences, "Changing CustomShadowResolution to {0}", value.Value);
						QualitySettings.shadowResolution = value.Value;
					}
					else
					{
						Logging.Info(LogChannels.Preferences, "Resetting CustomShadowResolution to default of {0}", _currentQualityDefaultShadowResolution);
						QualitySettings.shadowResolution = _currentQualityDefaultShadowResolution;
					}
					_customShadowResolution = value;
				}
			}

			public int? CustomVSyncCount
			{
				get
				{
					return _customVSyncCount;
				}
				set
				{
					if (value.HasValue)
					{
						Logging.Info(LogChannels.Preferences, "Changing CustomVSyncCount to {0}", value.Value);
						QualitySettings.vSyncCount = value.Value;
					}
					else
					{
						Logging.Info(LogChannels.Preferences, "Resetting CustomVSyncCount to default of {0}", _currentQualityDefaultVSyncCount);
						QualitySettings.vSyncCount = _currentQualityDefaultVSyncCount;
					}
					_customVSyncCount = value;
					if (this.OnCustomVSyncCountChange != null)
					{
						this.OnCustomVSyncCountChange(value.HasValue ? value.Value : _currentQualityDefaultVSyncCount);
					}
				}
			}

			public float? CustomLODBias
			{
				get
				{
					return _customLODBias;
				}
				set
				{
					if (value.HasValue)
					{
						Logging.Info(LogChannels.Preferences, "Changing CustomLODBias to {0}", value.Value);
						QualitySettings.lodBias = value.Value;
					}
					else
					{
						Logging.Info(LogChannels.Preferences, "Resetting CustomLODBias to default of {0}", _currentQualityDefaultLODBias);
						QualitySettings.lodBias = _currentQualityDefaultLODBias;
					}
					_customLODBias = value;
				}
			}

			public float ActiveLODBias => QualitySettings.lodBias;

			public bool AmbientOcclusion
			{
				get
				{
					return _ambientOcclusion;
				}
				set
				{
					_ambientOcclusion = value;
					Logging.Info(LogChannels.Preferences, "Changing AmbientOcclusion to {0}", value);
					if (this.OnAmbientOcclusionChange != null)
					{
						this.OnAmbientOcclusionChange(value);
					}
				}
			}

			public bool Bloom
			{
				get
				{
					return _bloom;
				}
				set
				{
					_bloom = value;
					Logging.Info(LogChannels.Preferences, "Changing Bloom to {0}", value);
					if (this.OnBloomChange != null)
					{
						this.OnBloomChange(value);
					}
				}
			}

			public bool Antialiasing
			{
				get
				{
					return _antialiasing;
				}
				set
				{
					_antialiasing = value;
					Logging.Info(LogChannels.Preferences, "Changing Antialiasing to {0}", value);
					if (this.OnAntialiasingChange != null)
					{
						this.OnAntialiasingChange(value);
					}
				}
			}

			public bool DepthOfField
			{
				get
				{
					return _depthOfField;
				}
				set
				{
					_depthOfField = value;
					Logging.Info(LogChannels.Preferences, "Changing Depth of Field to {0}", value);
					if (this.OnDepthOfFieldChange != null)
					{
						this.OnDepthOfFieldChange(value);
					}
				}
			}

			public ParticleQualityMode Particles
			{
				get
				{
					return _particles;
				}
				set
				{
					_particles = value;
					Logging.Info(LogChannels.Preferences, "Changing Particles to {0}", value);
					if (_particles == ParticleQualityMode.Low)
					{
						ParticleQualityController[] array = UnityEngine.Object.FindObjectsOfType<ParticleQualityController>();
						foreach (ParticleQualityController particleQualityController in array)
						{
							if (!particleQualityController.ParticleSystem.isStopped)
							{
								particleQualityController.ParticleSystem.Stop();
								particleQualityController.ParticleSystem.Clear();
							}
						}
					}
					else if (_particles == ParticleQualityMode.High)
					{
						ParticleQualityController[] array = UnityEngine.Object.FindObjectsOfType<ParticleQualityController>();
						foreach (ParticleQualityController particleQualityController2 in array)
						{
							if (!particleQualityController2.ParticleSystem.isPlaying)
							{
								particleQualityController2.ParticleSystem.Simulate(2f);
								particleQualityController2.ParticleSystem.Play();
							}
						}
					}
					if (this.OnParticlesChange != null)
					{
						this.OnParticlesChange(value);
					}
				}
			}

			public ShadowFadeDistanceMode ShadowFadeDistance
			{
				get
				{
					return _hospitalShadowDistance;
				}
				set
				{
					_hospitalShadowDistance = value;
					Logging.Info(LogChannels.Preferences, "Changing Shadow Fade Distance to {0}", value);
					if (this.OnShadowFadeDistanceChange != null)
					{
						this.OnShadowFadeDistanceChange(value);
					}
				}
			}

			public LightFadeDistanceMode LightFadeDistance
			{
				get
				{
					return _lightFadeDistance;
				}
				set
				{
					_lightFadeDistance = value;
					Logging.Info(LogChannels.Preferences, "Changing Light Fade Distance to {0}", value);
					if (this.OnLightFadeDistanceChange != null)
					{
						this.OnLightFadeDistanceChange(value);
					}
				}
			}

			public HospitalLightingQualityMode HospitalLightingQuality
			{
				get
				{
					return _hospitalLightingQuality;
				}
				set
				{
					_hospitalLightingQuality = value;
					Logging.Info(LogChannels.Preferences, "Changing HospitalLightingQuality to {0}", value);
					switch (_hospitalLightingQuality)
					{
					case HospitalLightingQualityMode.Low:
						Shader.EnableKeyword("VOLUME_LIGHT_LOW_QUALITY");
						Shader.DisableKeyword("VOLUME_LIGHT_MEDIUM_QUALITY");
						Shader.DisableKeyword("VOLUME_LIGHT_HIGH_QUALITY");
						break;
					case HospitalLightingQualityMode.Medium:
						Shader.DisableKeyword("VOLUME_LIGHT_LOW_QUALITY");
						Shader.EnableKeyword("VOLUME_LIGHT_MEDIUM_QUALITY");
						Shader.DisableKeyword("VOLUME_LIGHT_HIGH_QUALITY");
						break;
					case HospitalLightingQualityMode.High:
						Shader.DisableKeyword("VOLUME_LIGHT_LOW_QUALITY");
						Shader.DisableKeyword("VOLUME_LIGHT_MEDIUM_QUALITY");
						Shader.EnableKeyword("VOLUME_LIGHT_HIGH_QUALITY");
						break;
					}
				}
			}

			public int MaximumFPS
			{
				get
				{
					return _maximumFPS;
				}
				set
				{
					_maximumFPS = value;
					Logging.Info(LogChannels.Preferences, "Changing Maximum FPS to {0}", value);
					Application.targetFrameRate = _maximumFPS;
				}
			}

			public float CharacterDrawDistance
			{
				get
				{
					return _characterDrawDistance;
				}
				set
				{
					_characterDrawDistance = value;
					Logging.Info(LogChannels.Preferences, "Changing CharacterDrawDistance to {0}", value);
					if (this.OnCharacterDrawDistanceChange != null)
					{
						this.OnCharacterDrawDistanceChange(value);
					}
				}
			}

			public event Action<bool> OnAmbientOcclusionChange;

			public event Action<bool> OnBloomChange;

			public event Action<bool> OnAntialiasingChange;

			public event Action<bool> OnDepthOfFieldChange;

			public event Action<ParticleQualityMode> OnParticlesChange;

			public event Action<int> OnCustomVSyncCountChange;

			public event Action<ShadowFadeDistanceMode> OnShadowFadeDistanceChange;

			public event Action<LightFadeDistanceMode> OnLightFadeDistanceChange;

			public event Action<float> OnCharacterDrawDistanceChange;

			public VideoPreferences()
			{
				StoreCurrentQualitySettingValues();
				Logging.Info(LogChannels.Preferences, "Video settings at startup");
				LogCurrentValues();
			}

			public void SetQualityLevelAutomatically()
			{
				Logging.AlwaysLog(LogChannels.Preferences, "Setting quality level automatically based on system properties.");
				Logging.AlwaysLog(LogChannels.Preferences, "Settings used by autodetect:" + $"\n\tVRAM: {SystemInfo.graphicsMemorySize}" + $"\n\tRAM: {SystemInfo.systemMemorySize}" + $"\n\tCPU freq: {SystemInfo.processorFrequency}" + "\n\tCPU type: " + SystemInfo.processorType + $"\n\tCPU count: {SystemInfo.processorCount}" + "\n\tGPU name: " + SystemInfo.graphicsDeviceName + "\n\tGPU vendor: " + SystemInfo.graphicsDeviceVendor + "\n\tGPU version: " + SystemInfo.graphicsDeviceVersion + "\n\tdevide model: " + SystemInfo.deviceModel);
				switch (Application.platform)
				{
				case RuntimePlatform.WindowsPlayer:
				case RuntimePlatform.WindowsEditor:
				case RuntimePlatform.LinuxPlayer:
				case RuntimePlatform.LinuxEditor:
					if (SystemInfo.graphicsMemorySize <= 1024 || SystemInfo.graphicsDeviceVendor.Contains("Intel", StringComparison.InvariantCultureIgnoreCase) || SystemInfo.processorFrequency < 2000)
					{
						QualitySettingsIndex = 0;
						LimitTo720p();
					}
					else if (SystemInfo.graphicsMemorySize <= 1500 || SystemInfo.systemMemorySize < 4000 || SystemInfo.processorFrequency < 2300)
					{
						QualitySettingsIndex = 1;
						LimitTo1080p();
					}
					else if (SystemInfo.graphicsMemorySize <= 2048 || SystemInfo.processorFrequency < 2800)
					{
						QualitySettingsIndex = 2;
					}
					else if (SystemInfo.graphicsMemorySize <= 3072 || SystemInfo.processorFrequency < 3300)
					{
						QualitySettingsIndex = 3;
					}
					else
					{
						QualitySettingsIndex = 4;
					}
					break;
				case RuntimePlatform.OSXEditor:
				case RuntimePlatform.OSXPlayer:
				{
					string deviceModel = SystemInfo.deviceModel;
					if (deviceModel.Contains("iMacPro1,", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 3;
					}
					else if (deviceModel.Contains("iMacPro", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 4;
					}
					else if (deviceModel.Contains("iMac18,1", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 2;
						LimitTo1080p();
					}
					else if (deviceModel.Contains("iMac18,", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 3;
						LimitTo1080p();
					}
					else if (deviceModel.Contains("iMac19,", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 4;
						LimitTo1080p();
					}
					else if (deviceModel.Contains("MacBookPro14,3", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 1;
						LimitTo1080p();
					}
					else if (deviceModel.Contains("MacBookPro15,1", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 3;
						LimitTo1080p();
					}
					else if (deviceModel.Contains("MacBookPro15,2", StringComparison.InvariantCultureIgnoreCase))
					{
						QualitySettingsIndex = 1;
						LimitTo1080p();
					}
					else
					{
						QualitySettingsIndex = 2;
						LimitTo1080p();
					}
					break;
				}
				default:
					QualitySettingsIndex = 2;
					break;
				}
			}

			private void LimitTo720p()
			{
				Resolution[] array = ResolutionUtils.SortAndFilterResolutions(Screen.resolutions);
				Resolution currentResolution = new Resolution
				{
					width = 1280,
					height = 720,
					refreshRate = Screen.currentResolution.refreshRate
				};
				int num = ResolutionUtils.LowerOrEqualResolutionIndex(array, currentResolution);
				if (num >= 0 && num < array.Length)
				{
					Resolution resolution = array[num];
					Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
				}
			}

			private void LimitTo1080p()
			{
				Resolution[] array = ResolutionUtils.SortAndFilterResolutions(Screen.resolutions);
				Resolution currentResolution = new Resolution
				{
					width = 1920,
					height = 1080,
					refreshRate = Screen.currentResolution.refreshRate
				};
				int num = ResolutionUtils.LowerOrEqualResolutionIndex(array, currentResolution);
				if (num >= 0 && num < array.Length)
				{
					Resolution resolution = array[num];
					Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
				}
			}

			public void LogCurrentValues()
			{
				Logging.Info(LogChannels.Preferences, "Quality level: {0} ({1})", QualitySettings.GetQualityLevel(), QualitySettings.names[QualitySettings.GetQualityLevel()]);
				if (CustomMasterTextureLimit.HasValue)
				{
					Logging.Info(LogChannels.Preferences, "CustomMasterTextureLimit: {0}", CustomMasterTextureLimit);
				}
				if (CustomAnisotropicFiltering.HasValue)
				{
					Logging.Info(LogChannels.Preferences, "CustomAnisotropicFiltering: {0}", CustomAnisotropicFiltering);
				}
				if (CustomShadowQuality.HasValue)
				{
					Logging.Info(LogChannels.Preferences, "CustomShadowQuality: {0}", CustomShadowQuality);
				}
				if (CustomShadowResolution.HasValue)
				{
					Logging.Info(LogChannels.Preferences, "CustomShadowResolution: {0}", CustomShadowResolution);
				}
				if (CustomVSyncCount.HasValue)
				{
					Logging.Info(LogChannels.Preferences, "CustomVSyncCount: {0}", CustomVSyncCount);
				}
				if (CustomLODBias.HasValue)
				{
					Logging.Info(LogChannels.Preferences, "CustomLODBias: {0}", CustomLODBias);
				}
				Logging.Info(LogChannels.Preferences, "AmbientOcclusion: {0}", AmbientOcclusion);
				Logging.Info(LogChannels.Preferences, "Bloom: {0}", Bloom);
				Logging.Info(LogChannels.Preferences, "Depth of Field: {0}", DepthOfField);
				Logging.Info(LogChannels.Preferences, "Particles: {0}", Particles);
				Logging.Info(LogChannels.Preferences, "HospitalLightingQuality: {0}", HospitalLightingQuality);
				Logging.Info(LogChannels.Preferences, "CharacterDrawDistance: {0}", CharacterDrawDistance);
				Logging.Info(LogChannels.Preferences, "MaximumFPS: {0}", MaximumFPS);
			}

			public void ResetToBaseQualityLevel()
			{
				Logging.Info(LogChannels.Preferences, "Resetting video settings to defaults for current quality level");
				CustomMasterTextureLimit = null;
				CustomAnisotropicFiltering = null;
				CustomShadowQuality = null;
				CustomShadowResolution = null;
				CustomVSyncCount = null;
				CustomLODBias = null;
				switch (QualitySettings.GetQualityLevel())
				{
				case 0:
					AmbientOcclusion = false;
					Bloom = false;
					Antialiasing = false;
					DepthOfField = false;
					Particles = ParticleQualityMode.Low;
					ShadowFadeDistance = ShadowFadeDistanceMode.Near;
					LightFadeDistance = LightFadeDistanceMode.Near;
					HospitalLightingQuality = HospitalLightingQualityMode.Low;
					CharacterDrawDistance = 0f;
					break;
				case 1:
					AmbientOcclusion = false;
					Bloom = true;
					Antialiasing = false;
					DepthOfField = false;
					Particles = ParticleQualityMode.Low;
					ShadowFadeDistance = ShadowFadeDistanceMode.Near;
					LightFadeDistance = LightFadeDistanceMode.Near;
					HospitalLightingQuality = HospitalLightingQualityMode.Medium;
					CharacterDrawDistance = 0.25f;
					break;
				case 2:
					AmbientOcclusion = false;
					Bloom = true;
					Antialiasing = true;
					DepthOfField = false;
					Particles = ParticleQualityMode.High;
					ShadowFadeDistance = ShadowFadeDistanceMode.Near;
					LightFadeDistance = LightFadeDistanceMode.Medium;
					HospitalLightingQuality = HospitalLightingQualityMode.High;
					CharacterDrawDistance = 0.5f;
					break;
				case 3:
					AmbientOcclusion = true;
					Bloom = true;
					Antialiasing = true;
					DepthOfField = true;
					Particles = ParticleQualityMode.High;
					ShadowFadeDistance = ShadowFadeDistanceMode.Medium;
					LightFadeDistance = LightFadeDistanceMode.Medium;
					HospitalLightingQuality = HospitalLightingQualityMode.High;
					CharacterDrawDistance = 0.75f;
					break;
				case 4:
					AmbientOcclusion = true;
					Bloom = true;
					Antialiasing = true;
					DepthOfField = true;
					Particles = ParticleQualityMode.High;
					ShadowFadeDistance = ShadowFadeDistanceMode.Far;
					LightFadeDistance = LightFadeDistanceMode.Far;
					HospitalLightingQuality = HospitalLightingQualityMode.High;
					CharacterDrawDistance = 1f;
					break;
				}
			}

			public void Apply()
			{
				if (CustomMasterTextureLimit.HasValue)
				{
					QualitySettings.masterTextureLimit = CustomMasterTextureLimit.Value;
				}
				if (CustomAnisotropicFiltering.HasValue)
				{
					QualitySettings.anisotropicFiltering = CustomAnisotropicFiltering.Value;
				}
				if (CustomShadowQuality.HasValue)
				{
					QualitySettings.shadows = CustomShadowQuality.Value;
				}
				if (CustomShadowResolution.HasValue)
				{
					QualitySettings.shadowResolution = CustomShadowResolution.Value;
				}
				if (CustomVSyncCount.HasValue)
				{
					QualitySettings.vSyncCount = CustomVSyncCount.Value;
				}
				if (CustomLODBias.HasValue)
				{
					QualitySettings.lodBias = CustomLODBias.Value;
				}
				Application.targetFrameRate = MaximumFPS;
			}

			private void StoreCurrentQualitySettingValues()
			{
				_currentQualityDefaultMasterTextureLimit = QualitySettings.masterTextureLimit;
				_currentQualityDefaultAnisotropicFiltering = QualitySettings.anisotropicFiltering;
				_currentQualityDefaultShadowQuality = QualitySettings.shadows;
				_currentQualityDefaultShadowResolution = QualitySettings.shadowResolution;
				_currentQualityDefaultVSyncCount = QualitySettings.vSyncCount;
				_currentQualityDefaultLODBias = QualitySettings.lodBias;
			}

			public static float LODBiasAs0To1(float actualLodBias)
			{
				return (actualLodBias - MinLODBias) / (MaxLODBias - MinLODBias);
			}

			public static float LODBiasFrom0To1(float lodBias0To1)
			{
				return lodBias0To1 * (MaxLODBias - MinLODBias) + MinLODBias;
			}
		}

		public class AudioPreferences
		{
			[NonSerialized]
			private static readonly float _defaultMasterVolume = 1f;

			[NonSerialized]
			private static readonly float _defaultMusicVolume = 1f;

			[NonSerialized]
			private static readonly float _defaultSfxVolume = 1f;

			[NonSerialized]
			private static readonly float _defaultTannoyVolume = 0.3079183f;

			[NonSerialized]
			private static readonly float _defaultDjVolume = 0.16405f;

			private float _musicVolume;

			private float _masterVolume;

			private float _sfxVolume;

			private float _tannoyVolume;

			private float _djVolume;

			public Action<float> MusicVolumeChanged;

			public Action<float> MasterVolumeChanged;

			public Action<float> SFXVolumeChanged;

			public Action<float> TannoyVolumeChanged;

			public Action<float> DJVolumeChanged;

			public float MaxMasterVolume => _defaultMasterVolume;

			public float MaxMusicVolume => _defaultMusicVolume;

			public float MaxSFXVolume => _defaultSfxVolume;

			public float MaxTannoyVolume => _defaultTannoyVolume;

			public float MaxDJVolume => _defaultDjVolume;

			public float MusicVolume
			{
				get
				{
					return _musicVolume;
				}
				set
				{
					_musicVolume = value;
					MusicVolumeChanged.InvokeSafe(_musicVolume);
				}
			}

			public float MasterVolume
			{
				get
				{
					return _masterVolume;
				}
				set
				{
					_masterVolume = value;
					MasterVolumeChanged.InvokeSafe(_masterVolume);
				}
			}

			public float SFXVolume
			{
				get
				{
					return _sfxVolume;
				}
				set
				{
					_sfxVolume = value;
					SFXVolumeChanged.InvokeSafe(_sfxVolume);
				}
			}

			public float TannoyVolume
			{
				get
				{
					return _tannoyVolume;
				}
				set
				{
					_tannoyVolume = value;
					TannoyVolumeChanged.InvokeSafe(_tannoyVolume);
				}
			}

			public float DJVolume
			{
				get
				{
					return _djVolume;
				}
				set
				{
					_djVolume = value;
					DJVolumeChanged.InvokeSafe(_djVolume);
				}
			}

			public AudioPreferences()
			{
				_musicVolume = _defaultMusicVolume;
				_masterVolume = _defaultMasterVolume;
				_sfxVolume = _defaultSfxVolume;
				_tannoyVolume = _defaultTannoyVolume;
				_djVolume = _defaultDjVolume;
			}

			public void ResetToDefaultValues()
			{
				MusicVolume = _defaultMusicVolume;
				MasterVolume = _defaultMasterVolume;
				SFXVolume = _defaultSfxVolume;
				TannoyVolume = _defaultTannoyVolume;
				DJVolume = _defaultDjVolume;
			}
		}

		private VideoPreferences _videoPreferences = new VideoPreferences();

		private AudioPreferences _audioPreferences = new AudioPreferences();

		public VideoPreferences Video => _videoPreferences;

		public AudioPreferences Audio => _audioPreferences;

		public static string PreferencesFilePath => Path.Combine(Directories.GameOutputDirectory, "localpreferences.json");

		public void SaveToFile()
		{
			PreferencesUtils.SavePreferencesToLocalFile(PreferencesFilePath, this);
		}

		public static LocalPreferences LoadOrCreateNew()
		{
			LocalPreferences localPreferences = PreferencesUtils.LoadLocalPreferencesFromFile<LocalPreferences>(PreferencesFilePath);
			bool flag = Environment.CommandLine.Contains("--force-very-low-quality");
			bool flag2 = Environment.CommandLine.Contains("--force-vsync-off");
			if (localPreferences != null)
			{
				string validityCheckMessages = string.Empty;
				if (ValidatePreferences(localPreferences, ref validityCheckMessages))
				{
					Logging.Warning(LogChannels.Preferences, "LocalPreferences loaded successfully but had to be fixed during validation. Messages: {0}", validityCheckMessages);
				}
				if (flag)
				{
					localPreferences.Video.QualitySettingsIndex = 0;
				}
				if (flag2)
				{
					localPreferences.Video.CustomVSyncCount = 0;
				}
				localPreferences.Video.Apply();
			}
			else
			{
				Logging.Info(LogChannels.Preferences, "Created new Preferences");
				localPreferences = new LocalPreferences();
				localPreferences.Video.Apply();
				if (flag)
				{
					localPreferences.Video.QualitySettingsIndex = 0;
				}
				else
				{
					localPreferences.Video.SetQualityLevelAutomatically();
				}
				if (flag2)
				{
					localPreferences.Video.CustomVSyncCount = 0;
				}
				localPreferences.SaveToFile();
			}
			return localPreferences;
		}

		private static bool ValidatePreferences(LocalPreferences preferences, ref string validityCheckMessages)
		{
			bool result = false;
			if (preferences.Video == null)
			{
				validityCheckMessages += "Video preferences missing; using default. ";
				preferences._videoPreferences = new VideoPreferences();
			}
			else if (preferences.Video.CustomVSyncCount.HasValue)
			{
				if (preferences.Video.CustomVSyncCount.Value < 0 || preferences.Video.CustomVSyncCount.Value > 4)
				{
					validityCheckMessages += $"Custom VSync \"{preferences.Video.CustomVSyncCount.Value}\" not in range [0,4]; clamping. ";
					preferences.Video.CustomVSyncCount = MathUtils.Clamp(preferences.Video.CustomVSyncCount.Value, 0, 4);
					result = true;
				}
			}
			else if (preferences.Video.CustomMasterTextureLimit.HasValue && (preferences.Video.CustomMasterTextureLimit.Value < 0 || preferences.Video.CustomMasterTextureLimit.Value > 4))
			{
				validityCheckMessages += $"CustomMasterTextureLimit \"{preferences.Video.CustomMasterTextureLimit.Value}\" not in range [0,4]; clamping. ";
				preferences.Video.CustomMasterTextureLimit = MathUtils.Clamp(preferences.Video.CustomMasterTextureLimit.Value, 0, 4);
				result = true;
			}
			if (preferences.Audio == null)
			{
				validityCheckMessages += "Audio preferences missing; using default. ";
				preferences._audioPreferences = new AudioPreferences();
			}
			else if (preferences.Audio.MusicVolume < 0f || preferences.Audio.MusicVolume > 1f)
			{
				validityCheckMessages += $"Music volume \"{preferences.Audio.MusicVolume}\" not in range [0,1]; clamping. ";
				preferences.Audio.MusicVolume = Mathf.Clamp(preferences.Audio.MusicVolume, 0f, 1f);
				result = true;
			}
			return result;
		}

		public static IEnumerator ReloadPostProcessingCoroutine()
		{
			List<PostProcessLayer> layers = new List<PostProcessLayer>(UnityEngine.Object.FindObjectsOfType<PostProcessLayer>());
			layers.RemoveAll((PostProcessLayer l) => !l.isActiveAndEnabled);
			foreach (PostProcessLayer item in layers)
			{
				item.enabled = false;
			}
			yield return null;
			yield return new WaitForSecondsRealtime(2f);
			foreach (PostProcessLayer item2 in layers)
			{
				item2.enabled = true;
			}
		}
	}
}
