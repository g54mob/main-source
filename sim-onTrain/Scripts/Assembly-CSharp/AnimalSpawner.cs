using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class AnimalSpawner : NetworkBehaviour
{
	[Tooltip("Animal biome data with spawn weights")]
	public AnimalBiomeData biomeData;

	[Tooltip("Layer for ground detection")]
	public LayerMask groundLayer = 1;

	[Tooltip("Layer for obstacles to avoid")]
	public LayerMask obstacleLayer = -1;

	[Tooltip("Parent object containing terrains (optional - if not set, uses Terrain.activeTerrains)")]
	public Transform terrainParent;

	[Tooltip("Size of the scan area (X = width, Y = depth)")]
	public Vector2 scanAreaSize = new Vector2(100f, 100f);

	[Tooltip("Spacing between spawn points in the grid")]
	[Range(5f, 100f)]
	public float pointSpacing = 15f;

	[Tooltip("Number of raycast attempts per grid point")]
	[Range(1f, 5f)]
	public int raycastAttemptsPerPoint = 3;

	[Tooltip("Animal point prefab to instantiate")]
	public GameObject animalPointPrefab;

	[Tooltip("How high above check position to start raycast")]
	[Range(100f, 2000f)]
	public float raycastStartHeight = 1000f;

	[Tooltip("Total raycast distance downwards")]
	[Range(500f, 4000f)]
	public float raycastDistance = 2000f;

	[Tooltip("Minimum distance from player to spawn")]
	[Range(10f, 50f)]
	public float minPlayerDistance = 20f;

	[Tooltip("Maximum distance from player to spawn")]
	[Range(20f, 100f)]
	public float maxPlayerDistance = 50f;

	[Tooltip("Check interval for spawning (seconds)")]
	[Range(1f, 30f)]
	public float spawnCheckInterval = 5f;

	[Tooltip("Number of rapid spawn checks at start")]
	[Range(1f, 50f)]
	public int initialBurstCount = 20;

	[Tooltip("Interval between burst spawn checks (seconds)")]
	[Range(0.05f, 1f)]
	public float burstSpawnInterval = 0.15f;

	[Tooltip("Maximum animals per spawn point")]
	[Range(1f, 10f)]
	public int maxAnimalsPerPoint = 3;

	[Tooltip("Despawn distance - if no player is within this range, animal gets destroyed")]
	[Range(100f, 500f)]
	public float despawnDistance = 300f;

	[Tooltip("Maximum slope angle for valid ground")]
	[Range(0f, 90f)]
	public float maxSlopeAngle = 45f;

	[Tooltip("Sphere check radius for obstacles")]
	[Range(0.5f, 5f)]
	public float obstacleCheckRadius = 1f;

	[SerializeField]
	private List<TSPlayerController> nearbyPlayers = new List<TSPlayerController>();

	[SerializeField]
	private int totalSpawnedAnimals;

	private List<Transform> animalPoints = new List<Transform>();

	private Dictionary<Transform, List<GameObject>> spawnedAnimalsPerPoint = new Dictionary<Transform, List<GameObject>>();

	private Coroutine spawnCoroutine;

	private void Start()
	{
		CollectAnimalPoints();
		if (NetworkServer.active)
		{
			StartSpawning();
		}
	}

	private void OnDestroy()
	{
		if (spawnCoroutine != null)
		{
			StopCoroutine(spawnCoroutine);
		}
	}

	public void GenerateAnimalPointsButton()
	{
		GenerateAnimalPoints();
	}

	public void ClearAllPointsButton()
	{
	}

	private void GenerateAnimalPoints()
	{
	}

	private Terrain FindTerrainAtPosition(Vector3 worldPos, Terrain[] terrains)
	{
		foreach (Terrain terrain in terrains)
		{
			if (!(terrain == null))
			{
				Vector3 position = terrain.transform.position;
				Vector3 size = terrain.terrainData.size;
				if (worldPos.x >= position.x && worldPos.x <= position.x + size.x && worldPos.z >= position.z && worldPos.z <= position.z + size.z)
				{
					return terrain;
				}
			}
		}
		return null;
	}

	private void CollectAnimalPoints()
	{
		animalPoints.Clear();
		spawnedAnimalsPerPoint.Clear();
		foreach (Transform item in base.transform)
		{
			animalPoints.Add(item);
			spawnedAnimalsPerPoint[item] = new List<GameObject>();
		}
	}

	[Server]
	public void StartSpawning()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AnimalSpawner::StartSpawning()' called when server was not active");
			return;
		}
		if (spawnCoroutine != null)
		{
			StopCoroutine(spawnCoroutine);
		}
		spawnCoroutine = StartCoroutine(SpawnLoop());
	}

	[Server]
	public void StopSpawning()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AnimalSpawner::StopSpawning()' called when server was not active");
		}
		else if (spawnCoroutine != null)
		{
			StopCoroutine(spawnCoroutine);
			spawnCoroutine = null;
		}
	}

	private IEnumerator SpawnLoop()
	{
		for (int i = 0; i < initialBurstCount; i++)
		{
			yield return new WaitForSeconds(burstSpawnInterval);
			if (biomeData == null)
			{
				continue;
			}
			UpdateNearbyPlayers();
			foreach (Transform animalPoint in animalPoints)
			{
				CheckAndSpawnAtPoint(animalPoint);
			}
		}
		while (true)
		{
			yield return new WaitForSeconds(spawnCheckInterval);
			if (biomeData == null)
			{
				Debug.LogWarning("[AnimalSpawner] BiomeData is null!");
				continue;
			}
			UpdateNearbyPlayers();
			DespawnDistantAnimals();
			foreach (Transform animalPoint2 in animalPoints)
			{
				CheckAndSpawnAtPoint(animalPoint2);
			}
		}
	}

	private void UpdateNearbyPlayers()
	{
		nearbyPlayers.Clear();
		TSPlayerController[] array = Object.FindObjectsOfType<TSPlayerController>();
		foreach (TSPlayerController tSPlayerController in array)
		{
			if (!(tSPlayerController != null) || tSPlayerController.isDeath)
			{
				continue;
			}
			foreach (Transform animalPoint in animalPoints)
			{
				float num = Vector3.Distance(tSPlayerController.transform.position, animalPoint.position);
				if (num >= minPlayerDistance && num <= maxPlayerDistance)
				{
					if (!nearbyPlayers.Contains(tSPlayerController))
					{
						nearbyPlayers.Add(tSPlayerController);
					}
					break;
				}
			}
		}
	}

	[Server]
	private void DespawnDistantAnimals()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AnimalSpawner::DespawnDistantAnimals()' called when server was not active");
			return;
		}
		TSPlayerController[] array = Object.FindObjectsOfType<TSPlayerController>();
		foreach (KeyValuePair<Transform, List<GameObject>> item in spawnedAnimalsPerPoint)
		{
			for (int num = item.Value.Count - 1; num >= 0; num--)
			{
				GameObject gameObject = item.Value[num];
				if (gameObject == null)
				{
					item.Value.RemoveAt(num);
				}
				else
				{
					bool flag = false;
					TSPlayerController[] array2 = array;
					foreach (TSPlayerController tSPlayerController in array2)
					{
						if (tSPlayerController != null && !tSPlayerController.isDeath && Vector3.Distance(gameObject.transform.position, tSPlayerController.transform.position) <= despawnDistance)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						item.Value.RemoveAt(num);
						totalSpawnedAnimals--;
						NetworkServer.Destroy(gameObject);
					}
				}
			}
		}
	}

	[Server]
	private void CheckAndSpawnAtPoint(Transform spawnPoint)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AnimalSpawner::CheckAndSpawnAtPoint(UnityEngine.Transform)' called when server was not active");
		}
		else
		{
			if (spawnPoint == null)
			{
				return;
			}
			if (spawnedAnimalsPerPoint.ContainsKey(spawnPoint))
			{
				spawnedAnimalsPerPoint[spawnPoint].RemoveAll((GameObject a) => a == null);
			}
			else
			{
				spawnedAnimalsPerPoint[spawnPoint] = new List<GameObject>();
			}
			if (spawnedAnimalsPerPoint[spawnPoint].Count >= maxAnimalsPerPoint)
			{
				return;
			}
			bool flag = false;
			float num = float.MaxValue;
			foreach (TSPlayerController nearbyPlayer in nearbyPlayers)
			{
				if (nearbyPlayer != null)
				{
					float num2 = Vector3.Distance(nearbyPlayer.transform.position, spawnPoint.position);
					if (num2 < num)
					{
						num = num2;
					}
					if (num2 >= minPlayerDistance && num2 <= maxPlayerDistance)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				SpawnAnimalAtPoint(spawnPoint);
			}
		}
	}

	[Server]
	private void SpawnAnimalAtPoint(Transform spawnPoint)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void AnimalSpawner::SpawnAnimalAtPoint(UnityEngine.Transform)' called when server was not active");
		}
		else
		{
			if (biomeData == null)
			{
				return;
			}
			GameObject randomAnimalPrefab = biomeData.GetRandomAnimalPrefab();
			Vector3 spawnPosition;
			if (randomAnimalPrefab == null)
			{
				Debug.LogWarning("[AnimalSpawner] Failed to get random animal prefab!");
			}
			else if (TryFindValidSpawnPosition(spawnPoint.position, out spawnPosition))
			{
				GameObject gameObject = Object.Instantiate(randomAnimalPrefab, spawnPosition, Quaternion.identity);
				if (!spawnedAnimalsPerPoint.ContainsKey(spawnPoint))
				{
					spawnedAnimalsPerPoint[spawnPoint] = new List<GameObject>();
				}
				spawnedAnimalsPerPoint[spawnPoint].Add(gameObject);
				totalSpawnedAnimals++;
				NetworkServer.Spawn(gameObject);
			}
		}
	}

	private bool TryFindValidSpawnPosition(Vector3 centerPoint, out Vector3 spawnPosition)
	{
		spawnPosition = Vector3.zero;
		int num = 5;
		float num2 = 1.5f;
		for (int i = 0; i < num; i++)
		{
			Vector2 vector = Random.insideUnitCircle * num2;
			Vector3 position = centerPoint + new Vector3(vector.x, 0f, vector.y);
			if (IsValidGroundPosition(position, out var groundPosition))
			{
				spawnPosition = groundPosition;
				return true;
			}
		}
		spawnPosition = centerPoint + Vector3.up * 0.1f;
		return true;
	}

	private bool IsValidGroundPosition(Vector3 position, out Vector3 groundPosition)
	{
		groundPosition = Vector3.zero;
		if (Physics.Raycast(position + Vector3.up * 10f, Vector3.down, out var hitInfo, 200f, groundLayer) && Vector3.Angle(hitInfo.normal, Vector3.up) <= maxSlopeAngle)
		{
			LayerMask layerMask = (int)obstacleLayer & ~(int)groundLayer;
			if (!Physics.CheckSphere(hitInfo.point + Vector3.up * 0.5f, obstacleCheckRadius, layerMask))
			{
				groundPosition = hitInfo.point + Vector3.up * 0.1f;
				return true;
			}
		}
		return false;
	}

	public void RegisterPlayer(TSPlayerController player)
	{
		if (player != null && !nearbyPlayers.Contains(player))
		{
			nearbyPlayers.Add(player);
		}
	}

	public void UnregisterPlayer(TSPlayerController player)
	{
		if (player != null && nearbyPlayers.Contains(player))
		{
			nearbyPlayers.Remove(player);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(0f, 1f, 0f, 0.8f);
		Gizmos.DrawWireCube(base.transform.position, new Vector3(scanAreaSize.x, 2f, scanAreaSize.y));
	}

	public override bool Weaved()
	{
		return true;
	}
}
