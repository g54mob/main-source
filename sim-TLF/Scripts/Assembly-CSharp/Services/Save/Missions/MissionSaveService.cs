using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Services.Missions;
using Zenject;

namespace Services.Save.Missions
{
	public class MissionSaveService : ISaveable, ILateDisposable
	{
		private const string ObsoleteDestroyEnemyPlanesMissionId = "post_tutorial_destroy_enemy_planes";

		private readonly ISaveService _saveService;

		private MissionSaveData _data = new MissionSaveData();

		public string SaveKey => "Missions";

		public int Priority => 10;

		public List<MissionInstance> ActiveMissions => _data.ActiveMissions;

		public IReadOnlyList<MissionInstance> CompletedMissions => _data.CompletedMissions;

		public bool IsLoaded { get; private set; }

		public event Action OnLoadComplete;

		public MissionSaveService(ISaveService saveService)
		{
			_saveService = saveService;
			_saveService.Register(this);
		}

		public void OnSave()
		{
			_saveService.Write(SaveKey, _data);
		}

		public async UniTask OnLoad()
		{
			if (_saveService.TryRead<MissionSaveData>(SaveKey, out var data))
			{
				_data = data ?? new MissionSaveData();
			}
			if (_data.ActiveMissions.RemoveAll((MissionInstance x) => x.MissionId == "post_tutorial_destroy_enemy_planes") + _data.CompletedMissions.RemoveAll((MissionInstance x) => x.MissionId == "post_tutorial_destroy_enemy_planes") > 0)
			{
				_saveService.Write(SaveKey, _data);
			}
			await UniTask.CompletedTask;
			IsLoaded = true;
			this.OnLoadComplete?.Invoke();
		}

		public void AddActiveMission(MissionInstance mission)
		{
			_data.ActiveMissions.RemoveAll((MissionInstance x) => x.MissionId == mission.MissionId);
			_data.ActiveMissions.Add(mission);
		}

		public void CompleteMission(MissionInstance mission)
		{
			_data.ActiveMissions.RemoveAll((MissionInstance x) => x.MissionId == mission.MissionId);
			_data.CompletedMissions.Add(mission);
		}

		public void RemoveMission(MissionInstance mission)
		{
			_data.ActiveMissions.RemoveAll((MissionInstance x) => x.MissionId == mission.MissionId);
		}

		public void LateDispose()
		{
			_saveService.Unregister(this);
		}
	}
}
