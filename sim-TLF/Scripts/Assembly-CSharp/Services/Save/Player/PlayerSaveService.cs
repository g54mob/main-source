using System;
using Cysharp.Threading.Tasks;
using Data.Save;
using UnityEngine;
using WorldEnvironment.Islands;
using Zenject;

namespace Services.Save.Player
{
	public class PlayerSaveService : ISaveable, ILateDisposable
	{
		public PlayerSaveData PlayerData = new PlayerSaveData();

		private readonly ISaveService _saveService;

		private readonly WorldParams _worldParams;

		public string SaveKey => "Player";

		public int Priority => 10;

		public bool IsLoaded { get; private set; }

		public event Action OnSaveStarted;

		public event Action OnLoadCompleted;

		public PlayerSaveService(ISaveService saveService, WorldParams worldParams)
		{
			_saveService = saveService;
			_worldParams = worldParams;
			_saveService.Register(this);
		}

		public async UniTask OnLoad()
		{
			if (!_saveService.TryRead<PlayerSaveData>(SaveKey, out var data))
			{
				PlayerData.GameData.WorldSeed = UnityEngine.Random.Range(1, int.MaxValue);
				_worldParams.Seed = PlayerData.GameData.WorldSeed;
				IsLoaded = true;
				this.OnLoadCompleted?.Invoke();
				return;
			}
			PlayerData = data;
			if (PlayerData.GameData.WorldSeed != 0)
			{
				_worldParams.Seed = PlayerData.GameData.WorldSeed;
			}
			IsLoaded = true;
			this.OnLoadCompleted?.Invoke();
			await UniTask.CompletedTask;
		}

		public void OnSave()
		{
			this.OnSaveStarted?.Invoke();
			_saveService.Write(SaveKey, new PlayerSaveData
			{
				Position = PlayerData.Position,
				Rotation = PlayerData.Rotation,
				Alcohol = PlayerData.Alcohol,
				Nicotine = PlayerData.Nicotine,
				MoneyData = PlayerData.MoneyData,
				GameData = PlayerData.GameData
			});
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
