using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Zenject;

namespace Services.Save.Settings
{
	[RequireComponent(typeof(Volume))]
	public class GraphicsSettingsSaveHandler : MonoBehaviour
	{
		[Inject]
		private SceneGraphicsSettingsRegistry _registry;

		private Volume _volume;

		private Vignette _vignette;

		private MotionBlur _motionBlur;

		private void Awake()
		{
			_volume = GetComponent<Volume>();
			_volume.profile.TryGet<Vignette>(out _vignette);
			_volume.profile.TryGet<MotionBlur>(out _motionBlur);
			_registry.OnSaveStarted += OnSave;
			_registry.OnLoadCompleted += OnLoad;
		}

		private void OnDestroy()
		{
			_registry.OnSaveStarted -= OnSave;
			_registry.OnLoadCompleted -= OnLoad;
		}

		private void OnSave()
		{
			SettingsData data = new SettingsData
			{
				GraphicsSettings = new GraphicsSettingsData
				{
					VsyncEnabled = (QualitySettings.vSyncCount > 0),
					VignetteEnabled = (_vignette != null && _vignette.active),
					MotionBlurEnabled = (_motionBlur != null && _motionBlur.active),
					TargetFPS = Application.targetFrameRate
				}
			};
			_registry.Save(data);
			Debug.Log("[GraphicsSettingsSaveHandler] Settings saved.");
		}

		private void OnLoad()
		{
			if (_registry.TryGet(out var data))
			{
				GraphicsSettingsData graphicsSettings = data.GraphicsSettings;
				QualitySettings.vSyncCount = (graphicsSettings.VsyncEnabled ? 1 : 0);
				if (_vignette != null)
				{
					_vignette.active = graphicsSettings.VignetteEnabled;
				}
				if (_motionBlur != null)
				{
					_motionBlur.active = graphicsSettings.MotionBlurEnabled;
				}
				Application.targetFrameRate = graphicsSettings.TargetFPS;
				Debug.Log($"[GraphicsSettingsSaveHandler] Settings applied: vsync={graphicsSettings.VsyncEnabled}, vignette={graphicsSettings.VignetteEnabled}, motionBlur={graphicsSettings.MotionBlurEnabled}");
			}
		}
	}
}
