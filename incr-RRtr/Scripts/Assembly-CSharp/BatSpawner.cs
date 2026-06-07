using UnityEngine;
using UnityEngine.UI;

public class BatSpawner : MonoBehaviour
{
	[SerializeField]
	private Toggle batSetting;

	private float timer = 5f;

	private float individualBatTimer = 1f;

	private float clusterTimer = 1800f;

	[SerializeField]
	private VampireBat[] batPrefabs;

	public VampireBat.Direction direction;

	[Header("Spawn area")]
	[SerializeField]
	private Vector2Int spawnAreaSize = new Vector2Int(14, 8);

	[Header("Cluster Spawn")]
	[SerializeField]
	private VampireBat clusterBatPrefab;

	[SerializeField]
	private Transform[] clusterSpawnPos;

	private void Start()
	{
		if (direction == VampireBat.Direction.Up || direction == VampireBat.Direction.Left)
		{
			clusterTimer = 3600f;
		}
	}

	private void Update()
	{
		if (timer <= 0f)
		{
			SpawnBats();
		}
		else
		{
			timer -= Time.deltaTime;
		}
		if (individualBatTimer <= 0f)
		{
			SpawnOneBat();
			if (Random.value > 0.5f)
			{
				SpawnOneBat();
			}
			individualBatTimer = Random.Range(18f, 90f) / (float)calculateBlockedLandsCleared();
		}
		else
		{
			individualBatTimer -= Time.deltaTime;
		}
		if (clusterTimer <= 0f)
		{
			SpawnCluster();
		}
		else
		{
			clusterTimer -= Time.deltaTime;
		}
	}

	private void SpawnBats()
	{
		int num = calculateBlockedLandsCleared();
		timer = 100f - (float)num * 3f;
		for (int i = 0; i < num * 3; i++)
		{
			SpawnOneBat();
		}
	}

	private void SpawnCluster()
	{
		clusterTimer = 3600f;
		if (!batSetting || batSetting.isOn)
		{
			for (int i = 0; i < clusterSpawnPos.Length; i++)
			{
				Object.Instantiate(clusterBatPrefab, clusterSpawnPos[i].position, Quaternion.identity, base.transform).direction = direction;
			}
		}
	}

	private int calculateBlockedLandsCleared()
	{
		int num = 1;
		for (int i = 0; i < GameManager.ins.blockedLands.Length; i++)
		{
			if (GameManager.ins.blockedLands[i] == BlockedLand.State.Cleared)
			{
				num++;
			}
		}
		return num;
	}

	private void SpawnOneBat()
	{
		if (!batSetting || batSetting.isOn)
		{
			VampireBat vB = getVB();
			Vector3 vector = new Vector2(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2), Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2));
			Object.Instantiate(vB, base.transform.position + vector, Quaternion.identity, base.transform).direction = direction;
		}
	}

	private VampireBat getVB()
	{
		int num2;
		int num = (num2 = Mathf.FloorToInt((float)(calculateBlockedLandsCleared() - 1) / 2f));
		int num3 = num + 1;
		int num4 = num + 2;
		if (num2 >= batPrefabs.Length)
		{
			num2 = batPrefabs.Length - 1;
		}
		if (num3 >= batPrefabs.Length)
		{
			num3 = batPrefabs.Length - 1;
		}
		if (num4 >= batPrefabs.Length)
		{
			num4 = batPrefabs.Length - 1;
		}
		return pickRandomlyBetween(batPrefabs[num2], batPrefabs[num3], batPrefabs[num4]);
	}

	private VampireBat pickRandomlyBetween(VampireBat bat1, VampireBat bat2, VampireBat bat3)
	{
		float value = Random.value;
		if (value < 0.75f)
		{
			return bat1;
		}
		if (value < 0.97f)
		{
			return bat2;
		}
		return bat3;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(base.transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y));
	}
}
