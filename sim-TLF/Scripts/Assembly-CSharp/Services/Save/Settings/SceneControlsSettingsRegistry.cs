using Cysharp.Threading.Tasks;
using StarterAssets;
using UnityEngine;
using Zenject;

namespace Services.Save.Settings
{
	public class SceneControlsSettingsRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private ControlsSettingsData _data = new ControlsSettingsData();

		public string SaveKey => "ControlsSettings";

		public int Priority => 5;

		public ControlsSettingsData Data => _data;

		public SceneControlsSettingsRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Set(ControlsSettingsData data)
		{
			if (data != null)
			{
				_data = data;
			}
		}

		public bool TryGet(out ControlsSettingsData data)
		{
			data = _data;
			return data != null;
		}

		public void OnSave()
		{
			_saveService.Write(SaveKey, _data);
			Debug.Log("[SceneControlsSettingsRegistry] Controls settings saved.");
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<ControlsSettingsData>(SaveKey, out var data) && data != null)
			{
				_data = data;
				Apply(_data);
				Debug.Log("[SceneControlsSettingsRegistry] Controls settings loaded and applied.");
			}
			else
			{
				Debug.LogWarning("[SceneControlsSettingsRegistry] No saved controls settings — using defaults.");
			}
			await UniTask.CompletedTask;
		}

		private void Apply(ControlsSettingsData data)
		{
			if (data.ResolutionWidth > 0 && data.ResolutionHeight > 0)
			{
				FullScreenMode fullscreenMode = ((!data.Windowed) ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
				Screen.SetResolution(data.ResolutionWidth, data.ResolutionHeight, fullscreenMode);
			}
			FirstPersonController firstPersonController = Object.FindFirstObjectByType<FirstPersonController>();
			if (firstPersonController != null)
			{
				firstPersonController.RotationSpeed = data.MouseSensitivity;
			}
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
