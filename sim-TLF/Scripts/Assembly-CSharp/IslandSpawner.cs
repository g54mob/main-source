using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
	[Header("References")]
	public Transform player;

	public List<GameObject> islandPrefabs;

	public float viewRadius = 10000f;

	public float chunkSize = 2000f;

	public int seed = 12345;

	public float noiseScale = 0.001f;

	public float spawnThreshold = 0.5f;

	private Dictionary<Vector2Int, GameObject> activeIslands = new Dictionary<Vector2Int, GameObject>();

	private void Update()
	{
		if (player == null)
		{
			return;
		}
		Vector2 vector = new Vector2(player.position.x, player.position.z);
		Vector2Int vector2Int = WorldToChunk(vector);
		int num = Mathf.CeilToInt(viewRadius / chunkSize);
		HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
		for (int i = -num; i <= num; i++)
		{
			for (int j = -num; j <= num; j++)
			{
				Vector2Int vector2Int2 = new Vector2Int(vector2Int.x + i, vector2Int.y + j);
				if ((ChunkToWorld(vector2Int2) - vector).sqrMagnitude <= viewRadius * viewRadius)
				{
					hashSet.Add(vector2Int2);
				}
			}
		}
		foreach (Vector2Int item in hashSet)
		{
			if (!activeIslands.ContainsKey(item) && ShouldSpawnIsland(item, out var prefabIndex))
			{
				GameObject value = Object.Instantiate(position: new Vector3((float)item.x * chunkSize + GetChunkOffset(item.x), 0f, (float)item.y * chunkSize + GetChunkOffset(item.y)), original: islandPrefabs[prefabIndex], rotation: Quaternion.identity, parent: base.transform);
				activeIslands.Add(item, value);
			}
		}
		List<Vector2Int> list = new List<Vector2Int>();
		foreach (KeyValuePair<Vector2Int, GameObject> activeIsland in activeIslands)
		{
			if ((ChunkToWorld(activeIsland.Key) - vector).sqrMagnitude > viewRadius * viewRadius)
			{
				list.Add(activeIsland.Key);
			}
		}
		foreach (Vector2Int item2 in list)
		{
			Object.Destroy(activeIslands[item2]);
			activeIslands.Remove(item2);
		}
	}

	private Vector2Int WorldToChunk(Vector2 worldPos)
	{
		return new Vector2Int(Mathf.FloorToInt(worldPos.x / chunkSize), Mathf.FloorToInt(worldPos.y / chunkSize));
	}

	private Vector2 ChunkToWorld(Vector2Int chunk)
	{
		return new Vector2((float)chunk.x * chunkSize + chunkSize * 0.5f, (float)chunk.y * chunkSize + chunkSize * 0.5f);
	}

	private bool ShouldSpawnIsland(Vector2Int chunk, out int prefabIndex)
	{
		prefabIndex = 0;
		float num = Mathf.PerlinNoise((float)(chunk.x + seed) * noiseScale, (float)(chunk.y + seed) * noiseScale);
		if (num < spawnThreshold)
		{
			return false;
		}
		prefabIndex = Mathf.FloorToInt(num * (float)islandPrefabs.Count) % islandPrefabs.Count;
		return true;
	}

	private float GetChunkOffset(int value)
	{
		return Mathf.PerlinNoise((float)value * 0.37f + (float)seed, (float)value * 0.91f + (float)seed) * chunkSize * 0.5f - chunkSize * 0.25f;
	}
}
