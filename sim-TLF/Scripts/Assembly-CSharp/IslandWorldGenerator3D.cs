using System;
using System.Collections.Generic;
using UnityEngine;

public class IslandWorldGenerator3D : MonoBehaviour
{
	[Header("Player & World")]
	public Transform player;

	public float playerRadius = 2000f;

	public float visibleRadius = 4000f;

	public float chunkSize = 1000f;

	public int seed = 12345;

	[Header("Islands / Density")]
	public GameObject[] islandPrefabs;

	[Tooltip("Максимальна кількість островів у чанку")]
	public int maxIslandsPerChunk = 3;

	[Tooltip("Масштаб шуму для визначення густини (Perlin)")]
	public float noiseScale = 0.08f;

	[Tooltip("Мінімальна значення шуму для появи островів у чанку")]
	[Range(0f, 1f)]
	public float spawnThreshold = 0.15f;

	[Tooltip("Відступ від країв чанку при спавні островів")]
	public float chunkSpawnMargin = 20f;

	[Header("Cleanup")]
	[Tooltip("Мультиплікатор для видалення дуже далеких чанків (щоб мати невеликий буфер)")]
	public float cleanupDistanceMultiplier = 1.25f;

	private Transform islandRoot;

	private Dictionary<Vector2Int, List<GameObject>> activeIslands = new Dictionary<Vector2Int, List<GameObject>>();

	private Vector2Int lastPlayerChunk;

	private void Awake()
	{
		if (islandRoot == null)
		{
			GameObject gameObject = new GameObject("IslandRoot");
			gameObject.transform.parent = base.transform;
			islandRoot = gameObject.transform;
		}
	}

	private void Start()
	{
		if (player == null)
		{
			Debug.LogError("[IslandWorldGenerator3D] Player not assigned!");
			base.enabled = false;
		}
		else
		{
			lastPlayerChunk = WorldToChunk(player.position);
			UpdateVisibleIslands();
		}
	}

	private void Update()
	{
		CheckWrap();
		CleanupFarIslands();
	}

	private void CheckWrap()
	{
		Vector3 zero = Vector3.zero;
		if (player.position.x > playerRadius)
		{
			zero.x = -2f * playerRadius;
		}
		else if (player.position.x < 0f - playerRadius)
		{
			zero.x = 2f * playerRadius;
		}
		if (player.position.z > playerRadius)
		{
			zero.z = -2f * playerRadius;
		}
		else if (player.position.z < 0f - playerRadius)
		{
			zero.z = 2f * playerRadius;
		}
		if (zero != Vector3.zero)
		{
			WrapWorld(zero);
			lastPlayerChunk = WorldToChunk(player.position);
			Vector2Int vector2Int = lastPlayerChunk;
			Debug.Log("Last Player Chunk: " + vector2Int.ToString());
		}
	}

	private void WrapWorld(Vector3 offset)
	{
		player.position += offset;
		islandRoot.position += offset;
		UpdateVisibleIslands();
	}

	private void UpdateVisibleIslands()
	{
		Vector2 b = new Vector2(player.position.x, player.position.z);
		Vector2Int vector2Int = WorldToChunk(player.position);
		int num = Mathf.CeilToInt(visibleRadius / chunkSize);
		for (int i = -num; i <= num; i++)
		{
			for (int j = -num; j <= num; j++)
			{
				Vector2Int vector2Int2 = new Vector2Int(vector2Int.x + i, vector2Int.y + j);
				Vector3 vector = ChunkCenterToWorld(vector2Int2);
				if (!(Vector2.Distance(new Vector2(vector.x, vector.z), b) > visibleRadius) && !activeIslands.ContainsKey(vector2Int2))
				{
					SpawnChunk(vector2Int2);
				}
			}
		}
	}

	private void SpawnChunk(Vector2Int chunk)
	{
		if (islandPrefabs == null || islandPrefabs.Length == 0)
		{
			return;
		}
		float x = ((float)chunk.x + (float)seed * 0.123f) * noiseScale;
		float y = ((float)chunk.y + (float)seed * 0.456f) * noiseScale;
		float num = Mathf.PerlinNoise(x, y);
		if (num < spawnThreshold)
		{
			return;
		}
		System.Random random = new System.Random(Hash(chunk.x, chunk.y, seed));
		int num2 = Mathf.FloorToInt(num * (float)maxIslandsPerChunk);
		if (num2 < maxIslandsPerChunk && random.NextDouble() < (double)(num * (float)maxIslandsPerChunk - (float)num2))
		{
			num2++;
		}
		num2 = Mathf.Clamp(num2, 0, maxIslandsPerChunk);
		if (num2 != 0)
		{
			float num3 = (float)chunk.x * chunkSize;
			float num4 = (float)chunk.y * chunkSize;
			List<GameObject> list = new List<GameObject>(num2);
			for (int i = 0; i < num2; i++)
			{
				float num5 = (float)random.NextDouble() * (chunkSize - 2f * chunkSpawnMargin) + chunkSpawnMargin;
				float num6 = (float)random.NextDouble() * (chunkSize - 2f * chunkSpawnMargin) + chunkSpawnMargin;
				Vector3 position = new Vector3(num3 + num5 + islandRoot.position.x, 0f, num4 + num6 + islandRoot.position.y);
				int num7 = random.Next(islandPrefabs.Length);
				GameObject original = islandPrefabs[num7];
				float y2 = (float)(random.NextDouble() * 360.0);
				float num8 = 1f + ((float)random.NextDouble() - 0.5f) * 0.3f;
				GameObject gameObject = UnityEngine.Object.Instantiate(original, position, Quaternion.Euler(0f, y2, 0f), islandRoot);
				gameObject.transform.localScale = gameObject.transform.localScale * num8;
				list.Add(gameObject);
			}
			activeIslands.Add(chunk, list);
		}
	}

	private void CleanupFarIslands()
	{
		Vector2 b = new Vector2(player.position.x, player.position.z);
		float num = visibleRadius * cleanupDistanceMultiplier;
		List<Vector2Int> list = new List<Vector2Int>();
		foreach (KeyValuePair<Vector2Int, List<GameObject>> activeIsland in activeIslands)
		{
			Vector3 vector = ChunkCenterToWorld(activeIsland.Key);
			if (Vector2.Distance(new Vector2(vector.x, vector.z), b) > num)
			{
				list.Add(activeIsland.Key);
			}
		}
		foreach (Vector2Int item in list)
		{
			foreach (GameObject item2 in activeIslands[item])
			{
				if (item2 != null)
				{
					UnityEngine.Object.Destroy(item2);
				}
			}
			activeIslands.Remove(item);
		}
	}

	private Vector2Int WorldToChunk(Vector3 worldPos)
	{
		float num = worldPos.x - islandRoot.position.x;
		float num2 = worldPos.z - islandRoot.position.y;
		int x = Mathf.FloorToInt(num / chunkSize);
		int y = Mathf.FloorToInt(num2 / chunkSize);
		return new Vector2Int(x, y);
	}

	private Vector3 ChunkCenterToWorld(Vector2Int chunk)
	{
		float num = (float)chunk.x * chunkSize + chunkSize * 0.5f;
		return new Vector3(z: (float)chunk.y * chunkSize + chunkSize * 0.5f + islandRoot.position.y, x: num + islandRoot.position.x, y: 0f);
	}

	private int Hash(int x, int y, int s)
	{
		return (((((0x7FFFFFFF ^ x) * 16777619) ^ y) * 16777619) ^ s) * 16777619;
	}
}
