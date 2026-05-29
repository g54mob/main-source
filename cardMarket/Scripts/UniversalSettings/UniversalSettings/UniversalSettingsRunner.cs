using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

namespace UniversalSettings
{
	[AddComponentMenu("Universal Settings/Universal Settings Runner")]
	[DisallowMultipleComponent]
	public sealed class UniversalSettingsRunner : MonoBehaviour
	{
		[Serializable]
		public class AudioMixerConfig
		{
			public AudioMixer audioMixer;

			public string volumeVariable;
		}

		private class DisplayBuffer
		{
			public int width;

			public int height;

			public int refreshRate;

			public FullScreenMode fullScreenMode;
		}

		[SerializeField]
		private SettingsProfile defaultSettings;

		[SerializeField]
		private List<SettingsProfile> qualitySettings = new List<SettingsProfile>();

		[SerializeField]
		private List<int> fpsOptions = new List<int> { 30, 60, 120, 240, -1 };

		[SerializeField]
		private List<AudioMixerConfig> audioMixerConfigs = new List<AudioMixerConfig>();

		[SerializeField]
		private List<PostProcessProfile> postProcessProfiles = new List<PostProcessProfile>();

		public bool enableBrightness = true;

		public bool enableFps = true;

		public bool enableFullscreen = true;

		public bool enableResolution = true;

		public bool enableRefreshRate = true;

		public bool enableVsync = true;

		public bool enableAntiAliasing = true;

		public bool enableShadow = true;

		public bool enableShadowDistance = true;

		public bool enableShadowResolution = true;

		public bool enableTextureResolution = true;

		public bool enablePostProcessing = true;

		public bool enableRenderFeature = true;

		public bool enableMasterVolume = true;

		public bool enableAudioMixerVolume = true;

		private static RenderPipelineAsset DefaultRenderPipeline = null;

		private int supportedRefreshRateFallback = 60;

		private List<SettingsComponent> settingsComponents = new List<SettingsComponent>();

		private List<SettingsButton> settingsButtons = new List<SettingsButton>();

		private SettingsProfile appliedSettings;

		internal SettingsProfile viewSettings;

		private bool updatingDisplay;

		private DisplayBuffer displayBuffer = new DisplayBuffer();

		private List<string> fpsTextOptions;

		private List<string> resolutionTextOptions;

		private List<string>[] refreshRateTextOptions;

		private List<string> refreshRateTextFallbackOptions;

		private List<string> antiAliasingOptions;

		private List<string> shadowModeOptions;

		private List<string> shadowDistanceOptions;

		private List<string> shadowResolutionOptions;

		private List<string> textureResolutionOptions;

		private static readonly string DefaultSaveKey = "UniversalSettings:Player";

		public static UniversalSettingsRunner Instance { get; private set; } = null;

		public bool Initialized { get; private set; }

		public Resolution[] SupportedScreenResolution { get; private set; }

		public List<int>[] SupportedRefreshRate { get; private set; }

		internal bool IsDirty { get; private set; }

		public event UnityAction onApplySettings;

		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Initialize();
		}

		private void Initialize()
		{
			Initialized = false;
			CheckRequisites();
			CloneDefaultRenderPipeline();
			CreateTemporarySettingsProfiles();
			ComputeResolutions();
			UpdateDropdownOptions();
			UpdateRendererFeatureAssetsList();
			SetSettings(LoadPlayerSettings());
			RegisterSceneButtons();
			RegisterSceneComponents();
			Initialized = true;
		}

		private void Start()
		{
			for (int i = 0; i < 10; i++)
			{
				SetAudioMixerVolume_Internal(i, appliedSettings.audioMixerVolume[i]);
			}
		}

		private void OnEnable()
		{
			StartCoroutine(UpdateSettings());
		}

		private IEnumerator UpdateSettings()
		{
			yield return new WaitUntil(() => Initialized);
			while (true)
			{
				if (updatingDisplay)
				{
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
					yield return new WaitForEndOfFrame();
					updatingDisplay = false;
				}
				else
				{
					if (FixExternalChanges())
					{
						SavePlayerSettings(appliedSettings);
						UpdateUI();
					}
					yield return new WaitForSeconds(1f);
				}
			}
		}

		private bool FixExternalChanges()
		{
			ClearDisplayBuffer();
			int num = (int)(0u | (FixResolution() ? 1u : 0u)) | (FixFullscreen() ? 1 : 0);
			if (num != 0)
			{
				ApplyDisplayBuffer();
			}
			return (byte)num != 0;
		}

		private bool FixFullscreen()
		{
			if (!enableFullscreen)
			{
				return false;
			}
			if (Screen.fullScreenMode != appliedSettings.GetFullScreenMode())
			{
				SetFullscreen_Internal(Screen.fullScreen);
				return true;
			}
			return false;
		}

		private bool FixResolution()
		{
			if (!enableResolution)
			{
				return false;
			}
			int num = SupportedScreenResolution.Length;
			for (int i = 0; i < SupportedScreenResolution.Length; i++)
			{
				if (IsCurrentResolution(SupportedScreenResolution[i]))
				{
					num = i;
					break;
				}
			}
			if (num != appliedSettings.resolutionIndex)
			{
				SetResolution_Internal(num);
				return true;
			}
			return false;
		}

		private void CheckRequisites()
		{
			if (defaultSettings == null)
			{
				defaultSettings = ScriptableObject.CreateInstance<SettingsProfile>();
				Debug.LogError("Default settings cannot be empty because it's used to set default values for all properties.", base.gameObject);
			}
		}

		private void UpdateRendererFeatureAssetsList()
		{
		}

		private int GetRefreshRateFromIndex(int refreshRateIndex)
		{
			int result = supportedRefreshRateFallback;
			if (appliedSettings.resolutionIndex < SupportedRefreshRate.Length && refreshRateIndex < SupportedRefreshRate[appliedSettings.resolutionIndex].Count)
			{
				int index = SupportedRefreshRate[appliedSettings.resolutionIndex].Count - 1 - refreshRateIndex;
				result = SupportedRefreshRate[appliedSettings.resolutionIndex][index];
			}
			return result;
		}

		private bool IsCurrentResolution(Resolution resolution)
		{
			if (resolution.width == Screen.width)
			{
				return resolution.height == Screen.height;
			}
			return false;
		}

		private void CloneDefaultRenderPipeline()
		{
			if (GraphicsSettings.defaultRenderPipeline != null)
			{
				DefaultRenderPipeline = GraphicsSettings.defaultRenderPipeline;
				GraphicsSettings.defaultRenderPipeline = UnityEngine.Object.Instantiate(GraphicsSettings.defaultRenderPipeline);
			}
		}

		private void CreateTemporarySettingsProfiles()
		{
			defaultSettings.UpdateStruct();
			appliedSettings = UnityEngine.Object.Instantiate(defaultSettings);
			viewSettings = UnityEngine.Object.Instantiate(defaultSettings);
		}

		private void RegisterSceneButtons()
		{
			SettingsButton[] array = UnityEngine.Object.FindObjectsOfType<SettingsButton>();
			foreach (SettingsButton button in array)
			{
				RegisterButton(button);
			}
		}

		internal void RegisterButton(SettingsButton button)
		{
			settingsButtons.Add(button);
			button.Initialize(this);
			button.UpdateButton(viewSettings);
		}

		private void UpdateButtons()
		{
			foreach (SettingsButton settingsButton in settingsButtons)
			{
				if (!(settingsButton == null))
				{
					settingsButton.UpdateButton(viewSettings);
				}
			}
		}

		private void RegisterSceneComponents()
		{
			SettingsComponent[] array = UnityEngine.Object.FindObjectsOfType<SettingsComponent>();
			foreach (SettingsComponent component in array)
			{
				RegisterComponent(component);
			}
		}

		internal void RegisterComponent(SettingsComponent component)
		{
			settingsComponents.Add(component);
			component.Initialize(this);
			component.UpdateComponent(viewSettings);
		}

		private void UpdateComponents()
		{
			foreach (SettingsComponent settingsComponent in settingsComponents)
			{
				if (!(settingsComponent == null))
				{
					settingsComponent.UpdateComponent(viewSettings);
				}
			}
		}

		internal void RegisterSettingsChange()
		{
			if (Initialized)
			{
				IsDirty = true;
				UpdateUI();
			}
		}

		private void UpdateUI()
		{
			UpdateComponents();
			UpdateButtons();
		}

		private void ComputeResolutions()
		{
			Dictionary<string, Resolution> dictionary = new Dictionary<string, Resolution>();
			Dictionary<string, List<int>> dictionary2 = new Dictionary<string, List<int>>();
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution value = resolutions[i];
				string key = $"{value.width}x{value.height}";
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, value);
				}
				if (!dictionary2.ContainsKey(key))
				{
					dictionary2.Add(key, new List<int>());
				}
				dictionary2[key].Add(value.refreshRate);
			}
			SupportedScreenResolution = new Resolution[dictionary.Count];
			SupportedRefreshRate = new List<int>[dictionary.Count];
			int num = 0;
			foreach (KeyValuePair<string, Resolution> item in dictionary)
			{
				SupportedScreenResolution[num] = item.Value;
				SupportedRefreshRate[num] = dictionary2[item.Key];
				num++;
			}
			supportedRefreshRateFallback = Screen.currentResolution.refreshRate;
		}

		public SettingsProfile GetNotAppliedSettings()
		{
			return viewSettings;
		}

		public SettingsProfile GetAppliedSettings()
		{
			return appliedSettings;
		}

		public List<SettingsProfile> GetQualitySettings()
		{
			return qualitySettings;
		}

		internal void ClearDisplayBuffer()
		{
			displayBuffer.width = Screen.width;
			displayBuffer.height = Screen.height;
			displayBuffer.refreshRate = Screen.currentResolution.refreshRate;
			displayBuffer.fullScreenMode = Screen.fullScreenMode;
		}

		internal void ApplyDisplayBuffer()
		{
			Screen.SetResolution(displayBuffer.width, displayBuffer.height, displayBuffer.fullScreenMode, displayBuffer.refreshRate);
			updatingDisplay = true;
		}

		private void CallApplySettingsCallback()
		{
			this.onApplySettings?.Invoke();
		}

		public void SetSettings(SettingsProfile settingsProfile)
		{
			ClearDisplayBuffer();
			SetBrightness_Internal(settingsProfile.brightness);
			SetFps_Internal(settingsProfile.fpsIndex);
			SetFullscreen_Internal(settingsProfile.fullscreen);
			SetResolution_Internal(settingsProfile.resolutionIndex);
			SetVsync_Internal(settingsProfile.vsync);
			SetRefreshRate_Internal(settingsProfile.refreshRateIndex);
			SetAntiAliasing_Internal(settingsProfile.antiAliasingIndex);
			SetShadowMode_Internal(settingsProfile.shadowModeIndex);
			SetShadowDistance_Internal(settingsProfile.shadowDistanceIndex);
			SetShadowResolution_Internal(settingsProfile.shadowResolutionIndex);
			SetTextureResolution_Internal(settingsProfile.textureResolutionIndex);
			SetPostProcessing_Internal(settingsProfile.postProcessing);
			for (int i = 0; i < Enum.GetNames(typeof(PostProcessingEffect)).Length; i++)
			{
				SetPostProcessingEffect_Internal((PostProcessingEffect)i, settingsProfile.postProcessingEffect[i]);
			}
			SetMasterVolume_Internal(settingsProfile.masterVolume);
			for (int j = 0; j < 10; j++)
			{
				SetAudioMixerVolume_Internal(j, settingsProfile.audioMixerVolume[j]);
			}
			for (int k = 0; k < 10; k++)
			{
				SetCustomFloat_Internal(k, settingsProfile.customFloat[k]);
			}
			for (int l = 0; l < 11; l++)
			{
				SetCustomBoolean_Internal(l, settingsProfile.customBoolean[l]);
			}
			for (int m = 0; m < 10; m++)
			{
				SetCustomInteger_Internal(m, settingsProfile.customInteger[m]);
			}
			ApplyDisplayBuffer();
			IsDirty = false;
			UpdateUI();
			SavePlayerSettings(appliedSettings);
			CallApplySettingsCallback();
		}

		public void ApplySettings()
		{
			SetSettings(viewSettings);
		}

		public void UndoSettings()
		{
			viewSettings = UnityEngine.Object.Instantiate(appliedSettings);
			IsDirty = false;
			UpdateUI();
		}

		public void ResetSettings()
		{
			SetSettings(defaultSettings);
		}

		internal void SetRefreshRate_Internal(int refreshRateIndex)
		{
			if (enableRefreshRate)
			{
				viewSettings.refreshRateIndex = refreshRateIndex;
				appliedSettings.refreshRateIndex = refreshRateIndex;
				displayBuffer.refreshRate = GetRefreshRateFromIndex(refreshRateIndex);
			}
		}

		public void SetRefreshRate(int refreshRateIndex)
		{
			if (enableRefreshRate)
			{
				ClearDisplayBuffer();
				SetRefreshRate_Internal(refreshRateIndex);
				ApplyDisplayBuffer();
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public int GetRefreshRate()
		{
			return appliedSettings.refreshRateIndex;
		}

		internal void SetVsync_Internal(bool value)
		{
			if (enableVsync)
			{
				viewSettings.vsync = value;
				appliedSettings.vsync = value;
				if (value)
				{
					Application.targetFrameRate = -1;
				}
				QualitySettings.vSyncCount = (value ? 1 : 0);
			}
		}

		public void SetVsync(bool value)
		{
			if (enableVsync)
			{
				SetVsync_Internal(value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public bool GetVsync()
		{
			return appliedSettings.vsync;
		}

		internal void SetResolution_Internal(int value)
		{
			if (enableResolution)
			{
				viewSettings.resolutionIndex = value;
				appliedSettings.resolutionIndex = value;
				if (value < SupportedScreenResolution.Length)
				{
					displayBuffer.width = SupportedScreenResolution[value].width;
					displayBuffer.height = SupportedScreenResolution[value].height;
				}
			}
		}

		public void SetResolution(int value)
		{
			if (enableResolution)
			{
				ClearDisplayBuffer();
				SetResolution_Internal(value);
				ApplyDisplayBuffer();
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public int GetResolution()
		{
			return appliedSettings.resolutionIndex;
		}

		internal void SetFullscreen_Internal(bool value)
		{
			if (enableFullscreen)
			{
				viewSettings.fullscreen = value;
				appliedSettings.fullscreen = value;
				displayBuffer.fullScreenMode = appliedSettings.GetFullScreenMode();
			}
		}

		public void SetFullscreen(bool value)
		{
			if (enableFullscreen)
			{
				ClearDisplayBuffer();
				SetFullscreen_Internal(value);
				ApplyDisplayBuffer();
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public bool GetFullscreen()
		{
			return appliedSettings.fullscreen;
		}

		internal void SetFps_Internal(int value)
		{
			if (enableFps)
			{
				viewSettings.fpsIndex = value;
				appliedSettings.fpsIndex = value;
				int num = Math.Min(value, fpsOptions.Count - 1);
				int targetFrameRate = -1;
				if (num >= 0)
				{
					targetFrameRate = fpsOptions[num];
				}
				Application.targetFrameRate = targetFrameRate;
			}
		}

		public void SetFps(int value)
		{
			if (enableFps)
			{
				SetFps_Internal(value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public int GetFps()
		{
			return appliedSettings.fpsIndex;
		}

		internal void SetBrightness_Internal(float value)
		{
			if (!enableBrightness)
			{
				return;
			}
			viewSettings.brightness = value;
			appliedSettings.brightness = value;
			float x = Mathf.Lerp(-2f, 2f, value);
			if (!(GraphicsSettings.defaultRenderPipeline == null))
			{
				return;
			}
			foreach (PostProcessProfile postProcessProfile in postProcessProfiles)
			{
				if (!(postProcessProfile == null) && postProcessProfile.TryGetSettings<ColorGrading>(out var outSetting))
				{
					outSetting.postExposure.Override(x);
				}
			}
		}

		public void SetBrightness(float value)
		{
			if (enableBrightness)
			{
				SetBrightness_Internal(value);
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public float GetBrightness()
		{
			return appliedSettings.brightness;
		}

		internal void SetAntiAliasing_Internal(int value)
		{
			if (enableAntiAliasing)
			{
				if (value > 3)
				{
					value = 3;
				}
				viewSettings.antiAliasingIndex = value;
				appliedSettings.antiAliasingIndex = value;
				int num = 1;
				for (int i = 0; i < value; i++)
				{
					num *= 2;
				}
				QualitySettings.antiAliasing = num;
			}
		}

		public void SetAntiAliasing(AntiAliasing value)
		{
			if (enableAntiAliasing)
			{
				SetAntiAliasing_Internal((int)value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public AntiAliasing GetAntiAliasing()
		{
			return (AntiAliasing)appliedSettings.antiAliasingIndex;
		}

		internal void SetShadowMode_Internal(int value)
		{
			if (enableShadow)
			{
				if (value > 2)
				{
					value = 2;
				}
				viewSettings.shadowModeIndex = value;
				appliedSettings.shadowModeIndex = value;
				switch (value)
				{
				case 0:
					QualitySettings.shadows = ShadowQuality.Disable;
					break;
				case 1:
					QualitySettings.shadows = ShadowQuality.HardOnly;
					break;
				case 2:
					QualitySettings.shadows = ShadowQuality.All;
					break;
				}
			}
		}

		public void SetShadowMode(ShadowMode value)
		{
			if (enableShadow)
			{
				SetShadowMode_Internal((int)value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public ShadowMode GetShadowMode()
		{
			return (ShadowMode)appliedSettings.shadowModeIndex;
		}

		internal void SetShadowDistance_Internal(int value)
		{
			if (!enableShadowDistance)
			{
				return;
			}
			if (value > 3)
			{
				value = 3;
			}
			viewSettings.shadowDistanceIndex = value;
			appliedSettings.shadowDistanceIndex = value;
			if (appliedSettings.shadowModeIndex != 0)
			{
				switch (value)
				{
				case 0:
					QualitySettings.shadowDistance = 10f;
					QualitySettings.shadowCascades = 1;
					break;
				case 1:
					QualitySettings.shadowDistance = 30f;
					QualitySettings.shadowCascades = 2;
					break;
				case 2:
					QualitySettings.shadowDistance = 75f;
					QualitySettings.shadowCascades = 4;
					break;
				case 3:
					QualitySettings.shadowDistance = 150f;
					QualitySettings.shadowCascades = 4;
					break;
				}
			}
		}

		public void SetShadowDistance(ShadowDistance value)
		{
			if (enableShadowDistance)
			{
				SetShadowDistance_Internal((int)value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public ShadowDistance GetShadowDistance()
		{
			return (ShadowDistance)appliedSettings.shadowDistanceIndex;
		}

		internal void SetShadowResolution_Internal(int value)
		{
			if (!enableShadowResolution)
			{
				return;
			}
			if (value > 3)
			{
				value = 3;
			}
			viewSettings.shadowResolutionIndex = value;
			appliedSettings.shadowResolutionIndex = value;
			if (appliedSettings.shadowModeIndex != 0)
			{
				switch (value)
				{
				case 0:
					QualitySettings.shadowResolution = UnityEngine.ShadowResolution.Low;
					break;
				case 1:
					QualitySettings.shadowResolution = UnityEngine.ShadowResolution.Medium;
					break;
				case 2:
					QualitySettings.shadowResolution = UnityEngine.ShadowResolution.High;
					break;
				case 3:
					QualitySettings.shadowResolution = UnityEngine.ShadowResolution.VeryHigh;
					break;
				}
			}
		}

		public void SetShadowResolution(ShadowResolution value)
		{
			if (enableShadowResolution)
			{
				SetShadowResolution_Internal((int)value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public ShadowResolution GetShadowResolution()
		{
			return (ShadowResolution)appliedSettings.shadowResolutionIndex;
		}

		internal void SetTextureResolution_Internal(int value)
		{
			if (enableTextureResolution)
			{
				if (value > 3)
				{
					value = 3;
				}
				viewSettings.textureResolutionIndex = value;
				appliedSettings.textureResolutionIndex = value;
				QualitySettings.masterTextureLimit = value;
			}
		}

		public void SetTextureResolution(TextureResolution value)
		{
			if (enableTextureResolution)
			{
				SetTextureResolution_Internal((int)value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public TextureResolution GetTextureResolution()
		{
			return (TextureResolution)appliedSettings.textureResolutionIndex;
		}

		internal void SetPostProcessing_Internal(bool value)
		{
			if (enablePostProcessing)
			{
				viewSettings.postProcessing = value;
				appliedSettings.postProcessing = value;
			}
		}

		public void SetPostProcessing(bool value)
		{
			if (enablePostProcessing)
			{
				SetPostProcessing_Internal(value);
				for (int i = 0; i < Enum.GetNames(typeof(PostProcessingEffect)).Length; i++)
				{
					SetPostProcessingEffect_Internal((PostProcessingEffect)i, viewSettings.postProcessingEffect[i]);
				}
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public bool GetPostProcessing()
		{
			return appliedSettings.postProcessing;
		}

		internal void SetPostProcessingEffect_Internal(PostProcessingEffect postProcessingEffect, bool value)
		{
			if (!enablePostProcessing)
			{
				return;
			}
			viewSettings.postProcessingEffect[(int)postProcessingEffect] = value;
			appliedSettings.postProcessingEffect[(int)postProcessingEffect] = value;
			value &= appliedSettings.postProcessing;
			if (GraphicsSettings.defaultRenderPipeline == null)
			{
				switch (postProcessingEffect)
				{
				case PostProcessingEffect.Bloom:
					SetPostProcessingEffectActive_Builtin<Bloom>(value);
					break;
				case PostProcessingEffect.ChromaticAberration:
					SetPostProcessingEffectActive_Builtin<ChromaticAberration>(value);
					break;
				case PostProcessingEffect.DepthOfField:
					SetPostProcessingEffectActive_Builtin<DepthOfField>(value);
					break;
				case PostProcessingEffect.FilmGrain:
					SetPostProcessingEffectActive_Builtin<Grain>(value);
					break;
				case PostProcessingEffect.LensDistortion:
					SetPostProcessingEffectActive_Builtin<LensDistortion>(value);
					break;
				case PostProcessingEffect.MotionBlur:
					SetPostProcessingEffectActive_Builtin<MotionBlur>(value);
					break;
				case PostProcessingEffect.Vignette:
					SetPostProcessingEffectActive_Builtin<Vignette>(value);
					break;
				case PostProcessingEffect.AutoExposure:
					SetPostProcessingEffectActive_Builtin<AutoExposure>(value);
					break;
				case PostProcessingEffect.ScreenSpaceReflections:
					SetPostProcessingEffectActive_Builtin<ScreenSpaceReflections>(value);
					break;
				case PostProcessingEffect.AmbientOcclusion:
					SetPostProcessingEffectActive_Builtin<AmbientOcclusion>(value);
					break;
				case PostProcessingEffect.PaniniProjection:
					break;
				}
			}
		}

		public void SetPostProcessingEffect(PostProcessingEffect postProcessingEffect, bool value)
		{
			if (enablePostProcessing)
			{
				SetPostProcessingEffect_Internal(postProcessingEffect, value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public bool GetPostProcessingEffect(PostProcessingEffect postProcessingEffect)
		{
			return appliedSettings.postProcessingEffect[(int)postProcessingEffect];
		}

		private void SetPostProcessingEffectActive_Builtin<T>(bool value) where T : PostProcessEffectSettings
		{
			if (!(GraphicsSettings.defaultRenderPipeline == null))
			{
				return;
			}
			foreach (PostProcessProfile postProcessProfile in postProcessProfiles)
			{
				if (!(postProcessProfile == null) && postProcessProfile.TryGetSettings<T>(out var outSetting))
				{
					outSetting.active = value;
				}
			}
		}

		internal void SetRendererFeature_Internal(int id, bool value)
		{
		}

		public void SetRendererFeature(int index, bool value)
		{
		}

		public bool GetRendererFeature(int index)
		{
			return appliedSettings.rendererFeatures[index];
		}

		internal void SetMasterVolume_Internal(float value)
		{
			if (enableMasterVolume)
			{
				viewSettings.masterVolume = value;
				appliedSettings.masterVolume = value;
				AudioListener.volume = value;
			}
		}

		public void SetMasterVolume(float value)
		{
			if (enableMasterVolume)
			{
				SetMasterVolume_Internal(value);
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public float GetMasterVolume()
		{
			return appliedSettings.masterVolume;
		}

		internal void SetAudioMixerVolume_Internal(int id, float value)
		{
			if (enableAudioMixerVolume && id < audioMixerConfigs.Count)
			{
				viewSettings.audioMixerVolume[id] = value;
				appliedSettings.audioMixerVolume[id] = value;
				if (!(audioMixerConfigs[id].audioMixer == null))
				{
					float value2 = Mathf.Log10(0.0001f + value) * 20f;
					audioMixerConfigs[id].audioMixer.SetFloat(audioMixerConfigs[id].volumeVariable, value2);
				}
			}
		}

		public void SetAudioMixerVolume(int id, float value)
		{
			if (enableAudioMixerVolume && id < audioMixerConfigs.Count)
			{
				SetAudioMixerVolume_Internal(id, value);
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public float GetAudioMixerVolume(int id)
		{
			return appliedSettings.audioMixerVolume[id];
		}

		internal void SetCustomFloat_Internal(int id, float value)
		{
			if (id < 10)
			{
				viewSettings.customFloat[id] = value;
				appliedSettings.customFloat[id] = value;
			}
		}

		public void SetCustomFloat(int id, float value)
		{
			if (id < 10)
			{
				SetCustomFloat_Internal(id, value);
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public float GetCustomFloat(int id)
		{
			return appliedSettings.customFloat[id];
		}

		internal void SetCustomBoolean_Internal(int id, bool value)
		{
			if (id < 11)
			{
				viewSettings.customBoolean[id] = value;
				appliedSettings.customBoolean[id] = value;
			}
		}

		public void SetCustomBoolean(int id, bool value)
		{
			if (id < 11)
			{
				SetCustomBoolean_Internal(id, value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public bool GetCustomBoolean(int id)
		{
			return appliedSettings.customBoolean[id];
		}

		internal void SetCustomInteger_Internal(int id, int value)
		{
			if (id < 10)
			{
				viewSettings.customInteger[id] = value;
				appliedSettings.customInteger[id] = value;
			}
		}

		public void SetCustomInteger(int id, int value)
		{
			if (id < 10)
			{
				SetCustomInteger_Internal(id, value);
				UpdateUI();
				SavePlayerSettings(appliedSettings);
				CallApplySettingsCallback();
			}
		}

		public int GetCustomInteger(int id)
		{
			return appliedSettings.customInteger[id];
		}

		private void UpdateFpsOptions()
		{
			fpsTextOptions = new List<string>();
			foreach (int fpsOption in fpsOptions)
			{
				string item = ((fpsOption != -1) ? $"{fpsOption} FPS" : "Unlimited FPS");
				fpsTextOptions.Add(item);
			}
		}

		private void UpdateResolutionOptions()
		{
			resolutionTextOptions = new List<string>();
			Resolution[] supportedScreenResolution = SupportedScreenResolution;
			for (int i = 0; i < supportedScreenResolution.Length; i++)
			{
				Resolution resolution = supportedScreenResolution[i];
				resolutionTextOptions.Add($"{resolution.width}x{resolution.height}");
			}
		}

		private void UpdateRefreshRateOptions()
		{
			refreshRateTextOptions = new List<string>[SupportedRefreshRate.Length];
			for (int i = 0; i < refreshRateTextOptions.Length; i++)
			{
				refreshRateTextOptions[i] = new List<string>();
				foreach (int item in SupportedRefreshRate[i])
				{
					refreshRateTextOptions[i].Add($"{item} Hz");
				}
			}
			refreshRateTextFallbackOptions = new List<string>();
			refreshRateTextFallbackOptions.Add($"{Screen.currentResolution.refreshRate} Hz");
		}

		private void UpdateAntiAliasingOptions()
		{
			antiAliasingOptions = new List<string>();
			antiAliasingOptions.Add("Disabled");
			antiAliasingOptions.Add("2x MSAA");
			antiAliasingOptions.Add("4x MSAA");
			antiAliasingOptions.Add("8x MSAA");
		}

		private void UpdateShadowOptions()
		{
			shadowModeOptions = new List<string>();
			shadowModeOptions.Add("No shadows");
			shadowModeOptions.Add("Hard shadows");
			shadowModeOptions.Add("Soft shadows");
		}

		private void UpdateShadowDistanceOptions()
		{
			shadowDistanceOptions = new List<string>();
			shadowDistanceOptions.Add("Low");
			shadowDistanceOptions.Add("Medium");
			shadowDistanceOptions.Add("High");
			shadowDistanceOptions.Add("Ultra");
		}

		private void UpdateShadowResolutionOptions()
		{
			shadowResolutionOptions = new List<string>();
			shadowResolutionOptions.Add("Low");
			shadowResolutionOptions.Add("Medium");
			shadowResolutionOptions.Add("High");
			shadowResolutionOptions.Add("Ultra");
		}

		private void UpdateTextureResolutionOptions()
		{
			textureResolutionOptions = new List<string>();
			textureResolutionOptions.Add("Full Resolution");
			textureResolutionOptions.Add("Half Resolution");
			textureResolutionOptions.Add("Quarter Resolution");
			textureResolutionOptions.Add("Eighth Resolution");
		}

		public void UpdateDropdownOptions()
		{
			UpdateFpsOptions();
			UpdateResolutionOptions();
			UpdateRefreshRateOptions();
			UpdateAntiAliasingOptions();
			UpdateShadowOptions();
			UpdateShadowDistanceOptions();
			UpdateShadowResolutionOptions();
			UpdateTextureResolutionOptions();
		}

		public List<string> GetDropdownFpsOptions()
		{
			return fpsTextOptions;
		}

		public List<string> GetDropdownResolutionOptions()
		{
			return resolutionTextOptions;
		}

		public List<string> GetDropdownRefreshRateOptions(int resolutionIndex, FullScreenMode fullScreenMode)
		{
			if (resolutionIndex >= refreshRateTextOptions.Length || fullScreenMode == FullScreenMode.Windowed)
			{
				return refreshRateTextFallbackOptions;
			}
			return refreshRateTextOptions[resolutionIndex];
		}

		public List<string> GetDropdownAntiAliasingOptions()
		{
			return antiAliasingOptions;
		}

		public List<string> GetDropdownShadowModeOptions()
		{
			return shadowModeOptions;
		}

		public List<string> GetDropdownShadowDistanceOptions()
		{
			return shadowDistanceOptions;
		}

		public List<string> GetDropdownShadowResolutionOptions()
		{
			return shadowResolutionOptions;
		}

		public List<string> GetDropdownTextureResolutionOptions()
		{
			return textureResolutionOptions;
		}

		private SettingsProfile LoadPlayerSettings()
		{
			string json = PlayerPrefs.GetString(DefaultSaveKey, JsonUtility.ToJson(defaultSettings));
			SettingsProfile settingsProfile = ScriptableObject.CreateInstance<SettingsProfile>();
			JsonUtility.FromJsonOverwrite(json, settingsProfile);
			settingsProfile.UpdateStruct();
			return settingsProfile;
		}

		private void SavePlayerSettings(SettingsProfile settingsPreset)
		{
			string value = JsonUtility.ToJson(settingsPreset);
			PlayerPrefs.SetString(DefaultSaveKey, value);
			PlayerPrefs.Save();
		}
	}
}
