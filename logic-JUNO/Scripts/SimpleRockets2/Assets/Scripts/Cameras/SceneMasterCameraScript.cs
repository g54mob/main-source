using System;
using ModApi;
using ModApi.Cameras;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

namespace Assets.Scripts.Cameras
{
	public class SceneMasterCameraScript : MonoBehaviour, ISceneMasterCamera
	{
		[Serializable]
		private class RenderTextureData
		{
			public bool CheckHealth;

			public RenderTextureDescriptor Descriptor;

			public bool SettingsChanged;

			private string _name;

			private RenderTexture _texture;

			public bool Enabled { get; private set; }

			public RenderTextureData(string name, bool enabled, int width, int height, RenderTextureFormat format, bool depth)
			{
				_name = name;
				Enabled = enabled;
				Descriptor = new RenderTextureDescriptor(Screen.width, Screen.height, Utilities.Texture.GetDefaultRenderTextureFormat(), depth ? 24 : 0);
			}

			public void CreateTexture()
			{
				if (Enabled)
				{
					if (_texture != null)
					{
						UnloadTexture();
					}
					_texture = new RenderTexture(Descriptor);
					_texture.name = $"{_name} ({Descriptor.width}x{Descriptor.height})";
					SettingsChanged = false;
					CheckHealth = false;
				}
			}

			public RenderTexture GetTexture()
			{
				if (!Enabled)
				{
					return null;
				}
				if (SettingsChanged)
				{
					CreateTexture();
				}
				else if (CheckHealth)
				{
					CheckHealth = false;
					if (_texture == null)
					{
						CreateTexture();
					}
					else if (!_texture.IsCreated() && !_texture.Create())
					{
						Debug.LogError("Unable to create render texture '" + _texture.name + "'.");
					}
				}
				return _texture;
			}

			public void SetEnabled(bool enabled)
			{
				if (!enabled && _texture != null)
				{
					UnloadTexture();
				}
				else
				{
					SettingsChanged = true;
					CheckHealth = true;
				}
				Enabled = enabled;
			}

			public void UnloadTexture()
			{
				if (_texture != null)
				{
					_texture.Release();
					UnityEngine.Object.Destroy(_texture);
					_texture = null;
				}
				SettingsChanged = true;
				CheckHealth = true;
			}
		}

		private Antialiasing _antiAliasingImageEffect;

		private int? _pendingHeight;

		private int? _pendingWidth;

		private int _previousHeight;

		private int _previousWidth;

		private RenderTextureData _renderTextureCraftMask;

		private RenderTextureData _renderTextureScene;

		public Camera Camera { get; private set; }

		public RenderTexture RenderTextureCraftMask => _renderTextureCraftMask?.GetTexture();

		public RenderTexture RenderTextureScene => _renderTextureScene.GetTexture();

		public event EventHandler<EventArgs> ScreenResolutionChanged;

		protected virtual void Awake()
		{
			InitializeTextures();
			Camera = GetComponent<Camera>();
			Camera.allowHDR = Game.Instance.Settings.Quality.ImageEffects.HdrEnabled.Value;
			_antiAliasingImageEffect = GetComponent<Antialiasing>();
			DisplayQualitySettings display = Game.Instance.Settings.Quality.Display;
			EnumSetting<DisplayQualitySettings.AntiAliasingType> antiAliasing = display.AntiAliasing;
			antiAliasing.Changed += AntialiasingChanged;
			ApplyAntiAliasingSettings(antiAliasing);
			NumericSetting<float> resolutionScale = display.ResolutionScale;
			resolutionScale.Changed += ResolutionScaleChanged;
			ApplyResolutionSettings(resolutionScale);
			EnumSetting<ImageEffectsQualitySettings.ReEntryQuality> reEntry = Game.Instance.QualitySettings.ImageEffects.ReEntry;
			reEntry.Changed += ReentryEffectsSettingsChanged;
			ApplyReentryEffectsSettings(reEntry);
			_previousWidth = Screen.width;
			_previousHeight = Screen.height;
			_pendingWidth = null;
			_pendingHeight = null;
		}

		protected virtual void LateUpdate()
		{
			RequireHealthCheck();
			int width = Screen.width;
			int height = Screen.height;
			if (_pendingWidth.HasValue || _pendingHeight.HasValue)
			{
				if (width == _pendingWidth && height == _pendingHeight)
				{
					ApplyResolutionSettings(Game.Instance.Settings.Quality.Display.ResolutionScale);
					_previousWidth = width;
					_previousHeight = height;
					_pendingWidth = null;
					_pendingHeight = null;
					this.ScreenResolutionChanged?.Invoke(this, EventArgs.Empty);
				}
				else
				{
					_pendingWidth = width;
					_pendingHeight = height;
				}
			}
			else if (width != _previousWidth || height != _previousHeight)
			{
				_pendingWidth = width;
				_pendingHeight = height;
			}
		}

		protected virtual void OnDestroy()
		{
			DisplayQualitySettings display = Game.Instance.Settings.Quality.Display;
			display.AntiAliasing.Changed -= AntialiasingChanged;
			display.ResolutionScale.Changed -= ResolutionScaleChanged;
			UnloadTextures();
		}

		protected virtual void OnEnable()
		{
			RequireHealthCheck();
		}

		protected virtual void Start()
		{
			SceneCameraScript.UpdateDepthTextureState();
		}

		private void AntialiasingChanged(object sender, SettingChangedEventArgs<DisplayQualitySettings.AntiAliasingType> e)
		{
			ApplyAntiAliasingSettings(e.Setting);
		}

		private void ApplyAntiAliasingSettings(DisplayQualitySettings.AntiAliasingType setting)
		{
			QualitySettings.antiAliasing = 1;
			int msaa = 1;
			AAMode? aAMode = null;
			switch (setting)
			{
			case DisplayQualitySettings.AntiAliasingType.MSAA2:
				msaa = 2;
				break;
			case DisplayQualitySettings.AntiAliasingType.MSAA4:
				msaa = 4;
				break;
			case DisplayQualitySettings.AntiAliasingType.MSAA8:
				msaa = 8;
				break;
			case DisplayQualitySettings.AntiAliasingType.DLAA:
				aAMode = AAMode.DLAA;
				break;
			case DisplayQualitySettings.AntiAliasingType.FXAA1:
				aAMode = AAMode.FXAA1PresetA;
				break;
			case DisplayQualitySettings.AntiAliasingType.FXAA2:
				aAMode = AAMode.FXAA2;
				break;
			case DisplayQualitySettings.AntiAliasingType.FXAA3:
				aAMode = AAMode.FXAA3Console;
				break;
			default:
				aAMode = null;
				break;
			}
			UpdateTextureAntiAliasing(msaa);
			if (_antiAliasingImageEffect != null)
			{
				_antiAliasingImageEffect.enabled = aAMode.HasValue;
				if (aAMode.HasValue)
				{
					_antiAliasingImageEffect.mode = aAMode.Value;
				}
			}
			UpdateRenderMethod();
		}

		private void ApplyReentryEffectsSettings(ImageEffectsQualitySettings.ReEntryQuality reentryQuality)
		{
			_renderTextureCraftMask?.SetEnabled(reentryQuality != ImageEffectsQualitySettings.ReEntryQuality.Off);
			UpdateRenderMethod();
		}

		private void ApplyResolutionSettings(float resolutionScale)
		{
			UpdateTextureResolution(resolutionScale);
			UpdateRenderMethod();
		}

		private void CreateDebugImage(RenderTextureData texture, Canvas canvas, int index)
		{
			if (texture != null)
			{
				RenderTexture texture2 = texture.GetTexture();
				if (!(texture2 == null))
				{
					GameObject obj = new GameObject(texture2.name.Remove(texture2.name.LastIndexOf(' ')));
					RectTransform rectTransform = obj.AddComponent<RectTransform>();
					obj.AddComponent<RawImage>().texture = texture2;
					int num = Screen.width / 4;
					int num2 = Screen.height / 4;
					rectTransform.SetParent(canvas.transform, worldPositionStays: false);
					rectTransform.anchorMin = new Vector2(0f, 1f);
					rectTransform.anchorMax = new Vector2(0f, 1f);
					rectTransform.pivot = new Vector2(0f, 1f);
					rectTransform.localPosition = new Vector3(num, -num2 * index, 0f);
					rectTransform.sizeDelta = new Vector2(num, num2);
				}
			}
		}

		[ContextMenu("Create Debug Images")]
		private void CreateDebugImages()
		{
			Canvas canvas = new GameObject("Debug Canvas").AddComponent<Canvas>();
			canvas.transform.SetParent(base.transform, worldPositionStays: false);
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			CreateDebugImage(_renderTextureScene, canvas, 0);
			CreateDebugImage(_renderTextureCraftMask, canvas, 1);
		}

		private void InitializeCraftMaskTexture()
		{
			_renderTextureCraftMask = new RenderTextureData("CraftMask RT", enabled: false, Screen.width, Screen.height, Utilities.Texture.GetDefaultRenderTextureFormat(), depth: false);
			SetRenderTextureDescriptorDefaults(ref _renderTextureCraftMask.Descriptor);
		}

		private void InitializeSceneTexture()
		{
			_renderTextureScene = new RenderTextureData("Scene RT", enabled: true, Screen.width, Screen.height, Utilities.Texture.GetDefaultRenderTextureFormat(), depth: true);
			SetRenderTextureDescriptorDefaults(ref _renderTextureScene.Descriptor);
		}

		private void InitializeTextures()
		{
			InitializeSceneTexture();
			if (Game.InFlightScene)
			{
				InitializeCraftMaskTexture();
			}
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			RenderTexture texture = _renderTextureScene.GetTexture();
			Graphics.Blit(texture, destination);
			texture.DiscardContents();
		}

		private void ReentryEffectsSettingsChanged(object sender, SettingChangedEventArgs<ImageEffectsQualitySettings.ReEntryQuality> e)
		{
			ApplyReentryEffectsSettings(e.Setting);
		}

		private void RequireHealthCheck()
		{
			_renderTextureScene.CheckHealth = true;
			if (_renderTextureCraftMask != null)
			{
				_renderTextureCraftMask.CheckHealth = true;
			}
		}

		private void ResolutionScaleChanged(object sender, SettingChangedEventArgs<float> e)
		{
			ApplyResolutionSettings(e.Setting);
		}

		private void SetRenderTextureDescriptorDefaults(ref RenderTextureDescriptor d)
		{
			d.autoGenerateMips = false;
			d.bindMS = false;
			d.enableRandomWrite = false;
			d.memoryless = RenderTextureMemoryless.None;
			d.msaaSamples = 1;
			d.shadowSamplingMode = ShadowSamplingMode.None;
			d.sRGB = true;
			d.useMipMap = false;
			d.volumeDepth = 1;
			d.vrUsage = VRTextureUsage.None;
		}

		private void UnloadTextures()
		{
			_renderTextureScene.UnloadTexture();
			_renderTextureCraftMask?.UnloadTexture();
		}

		private void UpdateRenderMethod()
		{
			DisplayQualitySettings display = Game.Instance.QualitySettings.Display;
			ImageEffectsQualitySettings imageEffects = Game.Instance.QualitySettings.ImageEffects;
			DisplayQualitySettings.AntiAliasingType value = display.AntiAliasing.Value;
			bool flag = value == DisplayQualitySettings.AntiAliasingType.DLAA || value == DisplayQualitySettings.AntiAliasingType.FXAA1 || value == DisplayQualitySettings.AntiAliasingType.FXAA2 || value == DisplayQualitySettings.AntiAliasingType.FXAA3;
			_renderTextureScene.SetEnabled(display.ResolutionScale.Value != 1f || flag || imageEffects.ReEntry.Value != ImageEffectsQualitySettings.ReEntryQuality.Off);
			base.enabled = _renderTextureScene.Enabled;
			Camera.enabled = _renderTextureScene.Enabled;
			QualitySettings.antiAliasing = 1;
			if (!base.enabled && !flag)
			{
				switch (value)
				{
				case DisplayQualitySettings.AntiAliasingType.MSAA2:
					QualitySettings.antiAliasing = 2;
					break;
				case DisplayQualitySettings.AntiAliasingType.MSAA4:
					QualitySettings.antiAliasing = 4;
					break;
				case DisplayQualitySettings.AntiAliasingType.MSAA8:
					QualitySettings.antiAliasing = 8;
					break;
				}
			}
		}

		private void UpdateTextureAntiAliasing(int msaa)
		{
			UpdateTextureAntiAliasing(_renderTextureScene, msaa);
			UpdateTextureAntiAliasing(_renderTextureCraftMask, msaa);
		}

		private void UpdateTextureAntiAliasing(RenderTextureData texture, int msaa)
		{
			if (texture != null)
			{
				texture.SettingsChanged = texture.Descriptor.msaaSamples != msaa;
				texture.Descriptor.msaaSamples = msaa;
			}
		}

		private void UpdateTextureResolution(float scale)
		{
			UpdateTextureResolution(_renderTextureScene, scale);
			UpdateTextureResolution(_renderTextureCraftMask, scale);
		}

		private void UpdateTextureResolution(RenderTextureData texture, float scale)
		{
			if (texture != null)
			{
				int num = (int)((float)Screen.width * scale);
				int num2 = (int)((float)Screen.height * scale);
				texture.SettingsChanged = texture.Descriptor.width != num || texture.Descriptor.height != num2;
				texture.Descriptor.width = num;
				texture.Descriptor.height = num2;
			}
		}
	}
}
