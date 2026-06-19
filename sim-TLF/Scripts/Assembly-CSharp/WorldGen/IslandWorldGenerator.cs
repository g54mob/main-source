using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldGen
{
	public class IslandWorldGenerator : MonoBehaviour
	{
		[Header("References")]
		public Transform player;

		public Transform chunksParent;

		[Header("Prefabs")]
		public List<IslandPrefabEntry> islandPrefabs = new List<IslandPrefabEntry>();

		[Header("Chunk Settings")]
		public int gridSize = 3;

		public float chunkSize = 1000f;

		public int maxIslandsPerChunk = 8;

		[Header("Noise & Spawn")]
		public float noiseScale = 0.005f;

		[Range(0f, 1f)]
		public float spawnThreshold = 0.6f;

		public int globalSeed = 12345;

		[Header("Runtime")]
		public bool drawGizmos;

		private Dictionary<Vector2Int, Chunk> chunks = new Dictionary<Vector2Int, Chunk>();

		private Vector2Int currentCenterChunk = new Vector2Int(int.MinValue, int.MinValue);

		private void Start()
		{
			if (player == null)
			{
				Transform transform = Camera.main?.transform;
				if (transform != null)
				{
					player = transform;
				}
			}
			if (chunksParent == null)
			{
				GameObject gameObject = new GameObject("ChunksParent");
				gameObject.transform.SetParent(base.transform, worldPositionStays: false);
				chunksParent = gameObject.transform;
			}
			if (gridSize % 2 == 0)
			{
				Debug.LogWarning("gridSize must be odd. Incrementing by 1.");
				gridSize++;
			}
			UpdateCenterChunk(force: true);
		}

		private void Update()
		{
			UpdateCenterChunk(force: false);
		}

		private void LateUpdate()
		{
			if (!(player == null))
			{
				float num = chunkSize * (float)(gridSize / 2 - 1);
				Vector3 position = player.position;
				bool flag = false;
				if (Mathf.Abs(position.x) > num || Mathf.Abs(position.z) > num)
				{
					Vector3 vector = new Vector3((float)Mathf.RoundToInt(position.x / chunkSize) * chunkSize, 0f, (float)Mathf.RoundToInt(position.z / chunkSize) * chunkSize);
					player.position -= vector;
					chunksParent.position -= vector;
					flag = true;
				}
				if (flag)
				{
					UpdateCenterChunk(force: true);
				}
			}
		}

		private void UpdateCenterChunk(bool force)
		{
			if (!(player == null))
			{
				Vector2Int vector2Int = WorldPosToChunk(player.position);
				if (force || vector2Int != currentCenterChunk)
				{
					currentCenterChunk = vector2Int;
					RebuildActiveChunks(vector2Int);
				}
			}
		}

		private Vector2Int WorldPosToChunk(Vector3 worldPos)
		{
			int x = Mathf.FloorToInt(worldPos.x / chunkSize);
			int y = Mathf.FloorToInt(worldPos.z / chunkSize);
			return new Vector2Int(x, y);
		}

		private void RebuildActiveChunks(Vector2Int center)
		{
			int num = gridSize / 2;
			HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
			for (int i = -num; i <= num; i++)
			{
				for (int j = -num; j <= num; j++)
				{
					hashSet.Add(new Vector2Int(center.x + i, center.y + j));
				}
			}
			List<Vector2Int> list = new List<Vector2Int>();
			foreach (KeyValuePair<Vector2Int, Chunk> chunk in chunks)
			{
				if (!hashSet.Contains(chunk.Key))
				{
					list.Add(chunk.Key);
				}
			}
			foreach (Vector2Int item in list)
			{
				chunks[item].DestroyChunk();
				chunks.Remove(item);
			}
			foreach (Vector2Int item2 in hashSet)
			{
				if (!chunks.ContainsKey(item2))
				{
					Chunk value = CreateChunk(item2);
					chunks.Add(item2, value);
				}
			}
		}

		private Chunk CreateChunk(Vector2Int coord)
		{
			GameObject gameObject = new GameObject($"Chunk_{coord.x}_{coord.y}");
			if (chunksParent != null)
			{
				gameObject.transform.SetParent(chunksParent, worldPositionStays: false);
			}
			Chunk chunk = gameObject.AddComponent<Chunk>();
			chunk.Initialize(coord, chunkSize, this);
			return chunk;
		}

		internal void PopulateChunk(Chunk chunk)
		{
			int num = HashInts(chunk.coord.x, chunk.coord.y, globalSeed);
			System.Random random = new System.Random(num);
			int num2 = maxIslandsPerChunk * 4;
			int num3 = 0;
			for (int i = 0; i < num2; i++)
			{
				if (num3 >= maxIslandsPerChunk)
				{
					break;
				}
				float num4 = (float)random.NextDouble();
				float num5 = (float)random.NextDouble();
				Vector3 localPos = new Vector3(num4 * chunkSize, 0f, num5 * chunkSize);
				Vector3 worldPosition = chunk.GetWorldPosition(localPos);
				float num6 = Mathf.PerlinNoise((worldPosition.x + (float)num) * noiseScale, (worldPosition.z + (float)num) * noiseScale);
				if (!(num6 < spawnThreshold))
				{
					float num7 = Mathf.Lerp(0.6f, 1.6f, num6);
					GameObject gameObject = SamplePrefabByWeight(random);
					if (!(gameObject == null))
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, worldPosition + Vector3.up * 0.1f, Quaternion.Euler(0f, (float)random.NextDouble() * 360f, 0f), chunk.transform);
						gameObject2.transform.localScale *= num7;
						chunk.RegisterIsland(gameObject2);
						num3++;
					}
				}
			}
		}

		private GameObject SamplePrefabByWeight(System.Random rnd)
		{
			if (islandPrefabs == null || islandPrefabs.Count == 0)
			{
				return null;
			}
			float num = 0f;
			foreach (IslandPrefabEntry islandPrefab in islandPrefabs)
			{
				num += Mathf.Max(0.0001f, islandPrefab.weight);
			}
			float num2 = (float)rnd.NextDouble() * num;
			foreach (IslandPrefabEntry islandPrefab2 in islandPrefabs)
			{
				num2 -= Mathf.Max(0.0001f, islandPrefab2.weight);
				if (num2 <= 0f)
				{
					return islandPrefab2.prefab;
				}
			}
			return islandPrefabs[islandPrefabs.Count - 1].prefab;
		}

		private static int HashInts(int a, int b, int c)
		{
			return ((17 * 31 + a) * 31 + b) * 31 + c;
		}

		private void OnDrawGizmosSelected()
		{
			if (!drawGizmos || player == null)
			{
				return;
			}
			Vector2Int vector2Int = WorldPosToChunk(player.position);
			Gizmos.color = Color.green;
			int num = gridSize / 2;
			for (int i = -num; i <= num; i++)
			{
				for (int j = -num; j <= num; j++)
				{
					Gizmos.DrawWireCube(new Vector3((float)(vector2Int.x + i) * chunkSize, 0f, (float)(vector2Int.y + j) * chunkSize) + new Vector3(chunkSize, 0f, chunkSize) * 0.5f, new Vector3(chunkSize, 0f, chunkSize));
				}
			}
		}
	}
}
