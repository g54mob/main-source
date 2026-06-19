using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Services.Save.Settings
{
	public class SceneGraphicsSettingsRegistry : ISaveable, ILateDisposable
	{
		private readonly ISaveService _saveService;

		private SettingsData _data = new SettingsData
		{
			GraphicsSettings = new GraphicsSettingsData()
		};

		public string SaveKey => "GraphicsSettings";

		public int Priority => 5;

		public SettingsData Data => _data;

		public event Action OnSaveStarted;

		public event Action OnLoadCompleted;

		public SceneGraphicsSettingsRegistry(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void Save(SettingsData data)
		{
			_data = data;
		}

		public bool TryGet(out SettingsData data)
		{
			data = _data;
			return data.GraphicsSettings != null;
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, _data);
		}

		public async UniTask OnLoad()
		{
			Debug.Log("[SceneGraphicsSettingsRegistry] OnLoad called");
			if (_saveService.TryRead<SettingsData>(SaveKey, out var data))
			{
				Debug.Log("[SceneGraphicsSettingsRegistry] Settings loaded from file");
				_data = data;
			}
			else
			{
				Debug.LogWarning("[SceneGraphicsSettingsRegistry] No saved settings — using defaults.");
			}
			this.OnLoadCompleted?.Invoke();
			await UniTask.CompletedTask;
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
