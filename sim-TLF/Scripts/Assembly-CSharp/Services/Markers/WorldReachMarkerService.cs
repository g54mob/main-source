using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Services.Missions;
using Services.Save.Missions;
using UnityEngine;
using UnityEngine.AddressableAssets;
using WorldEnvironment.Islands;
using Zenject;

namespace Services.Markers
{
	public class WorldReachMarkerService : IWorldReachMarkerService, IInitializable
	{
		private string _markerAssetID = "DestinationMarker";

		private readonly IslandWorldSpawner _islandWorldSpawner;

		private readonly MissionSaveService _missionSaveService;

		private readonly MissionEventBus _missionEventBus;

		public WorldReachMarkerService(IslandWorldSpawner islandWorldSpawner, MissionSaveService missionSaveService, MissionEventBus eventBus)
		{
			_islandWorldSpawner = islandWorldSpawner;
			_missionSaveService = missionSaveService;
			_missionEventBus = eventBus;
			_missionSaveService.OnLoadComplete += RestoreMarkersForActiveMissions;
		}

		async UniTask<WorldMarkerObjectView> IWorldReachMarkerService.CreateMarker(Vector3 pos)
		{
			WorldMarkerObjectView worldMarkerObjectView = Object.Instantiate((await Addressables.LoadAssetAsync<GameObject>(_markerAssetID)).GetComponent<WorldMarkerObjectView>());
			worldMarkerObjectView.transform.position = pos;
			return worldMarkerObjectView;
		}

		void IInitializable.Initialize()
		{
		}

		private async void RestoreMarkersForActiveMissions()
		{
			IEnumerable<MissionInstance> activeMissions = _missionSaveService.ActiveMissions.Where((MissionInstance x) => x.Status == MissionStatus.Active);
			foreach (IslandObjectView island in _islandWorldSpawner.SpawnedIslands)
			{
				if (activeMissions.Any((MissionInstance x) => x.MissionId == island.CoordinatesString))
				{
					(await ((IWorldReachMarkerService)this).CreateMarker(island.TerrainCenter)).Init(delegate
					{
						_missionEventBus.Emit("reach", island.CoordinatesString);
					});
				}
			}
		}
	}
}
