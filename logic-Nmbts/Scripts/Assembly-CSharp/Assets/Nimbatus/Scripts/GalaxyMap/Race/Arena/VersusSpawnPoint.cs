using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race.Arena
{
	public class VersusSpawnPoint : MonoBehaviour
	{
		public VersusSpawnPoint[] SpawnPoints;

		public VersusSpawnPoint GetNewSpawnPoint()
		{
			return SpawnPoints[Random.Range(0, SpawnPoints.Length)];
		}
	}
}
