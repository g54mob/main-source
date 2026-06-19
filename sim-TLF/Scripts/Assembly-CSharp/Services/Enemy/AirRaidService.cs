using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Services.Enemy
{
	public class AirRaidService : IAirRaidService
	{
		private const string _PREFAB_REF_NAME = "DefaultEnemyAIWithWayPoints";

		[Inject]
		private DiContainer _diContainer;

		void IAirRaidService.InvokeAirRaid(Vector3 pos)
		{
			SpawnAiRaid(pos).Forget();
		}

		private async UniTaskVoid SpawnAiRaid(Vector3 pos)
		{
			GameObject prefab = await Addressables.LoadAssetAsync<GameObject>("DefaultEnemyAIWithWayPoints");
			_diContainer.InstantiatePrefab(prefab, pos, Quaternion.identity, null);
		}
	}
}
