using UnityEngine;

public class NebulaBerrySpawnHandler : MonoBehaviour
{
	public GameObject berryPrefab;

	private NebulaBerryManager ourManager;

	[Header("Spawn Timing")]
	[SerializeField]
	private float growthSpeedMultiplier = 1f;

	[SerializeField]
	private float spawnTimer_Max;

	private float spawnTime_Curr;

	private void Awake()
	{
		ourManager = GetComponentInParent<NebulaBerryManager>();
	}

	private void Start()
	{
		spawnTime_Curr = spawnTimer_Max;
	}

	public void UpdateSpawnHandler()
	{
		if (spawnTime_Curr > 0f)
		{
			spawnTime_Curr -= Time.deltaTime * growthSpeedMultiplier;
			return;
		}
		ourManager.SpawnNebulaBerry(berryPrefab);
		spawnTime_Curr = spawnTimer_Max;
	}
}
