using UnityEngine;

public class CoinSpawnerManager : MonoBehaviour
{
	[Header("Prefabs")]
	[SerializeField]
	private GameObject coinPrefab_Penny;

	[Header("Spawning")]
	[SerializeField]
	private Transform coinSpawnLocation;

	[SerializeField]
	private float spawnTimer_Max;

	private float spawnTimer_Curr;

	private void Start()
	{
		spawnTimer_Curr = spawnTimer_Max;
	}
}
