using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicChunkManager : MonoBehaviour
{
	[Header("References")]
	[Tooltip("Player'ın transform'u - otomatik bulunur")]
	public Transform player;

	[Tooltip("Tüm chunk'ların listesi")]
	public List<ChunkDataHolder> allChunks = new List<ChunkDataHolder>();

	[Header("Loading Settings")]
	[Tooltip("Player'dan kaç chunk mesafede yüklensin (1 = 3x3, 2 = 5x5, 3 = 7x7)")]
	[Range(1f, 5f)]
	public int loadRadius = 2;

	[Tooltip("Player'dan kaç chunk mesafede kaldırılsın")]
	[Range(2f, 8f)]
	public int unloadRadius = 4;

	[Tooltip("Kaç saniyede bir player pozisyonunu kontrol et")]
	[Range(0.1f, 2f)]
	public float updateInterval = 0.5f;

	[Tooltip("Her update'te kaç chunk yükle (FPS koruması)")]
	[Range(1f, 5f)]
	public int maxChunksPerUpdate = 2;

	[Header("Debug")]
	public int activeChunkCount;

	public Vector2Int currentPlayerChunk;

	public List<Vector2Int> loadedChunkPositions = new List<Vector2Int>();

	private readonly HashSet<ChunkDataHolder> activeChunks = new HashSet<ChunkDataHolder>();

	private readonly Queue<ChunkDataHolder> chunksToLoad = new Queue<ChunkDataHolder>();

	private readonly Dictionary<Vector2Int, ChunkDataHolder> chunkPositionMap = new Dictionary<Vector2Int, ChunkDataHolder>();

	private Vector3 lastPlayerPosition;

	private Coroutine updateCoroutine;

	private void Start()
	{
		if (player == null)
		{
			TSPlayerController tSPlayerController = Object.FindObjectOfType<TSPlayerController>();
			if (tSPlayerController != null)
			{
				player = tSPlayerController.transform;
			}
		}
		BuildChunkMap();
		if (player != null)
		{
			lastPlayerPosition = player.position;
			updateCoroutine = StartCoroutine(DynamicChunkUpdateLoop());
		}
		else
		{
			Debug.LogError("[DynamicChunkManager] Player not found! Dynamic loading disabled.");
		}
	}

	private void OnDestroy()
	{
		if (updateCoroutine != null)
		{
			StopCoroutine(updateCoroutine);
		}
	}

	private void BuildChunkMap()
	{
		chunkPositionMap.Clear();
		foreach (ChunkDataHolder allChunk in allChunks)
		{
			Vector2Int key = WorldToChunkPosition(allChunk.transform.position);
			chunkPositionMap[key] = allChunk;
			allChunk.gameObject.SetActive(value: false);
		}
		Debug.Log($"[DynamicChunkManager] Mapped {chunkPositionMap.Count} chunks");
	}

	private Vector2Int WorldToChunkPosition(Vector3 worldPos)
	{
		float num = 500f;
		if (allChunks.Count > 0 && allChunks[0].allCells.Count > 0)
		{
			num = allChunks[0].allCells[0].size.x;
		}
		return new Vector2Int(Mathf.FloorToInt(worldPos.x / num), Mathf.FloorToInt(worldPos.z / num));
	}

	private IEnumerator DynamicChunkUpdateLoop()
	{
		while (true)
		{
			yield return new WaitForSeconds(updateInterval);
			if (!(player == null) && !(Vector3.Distance(player.position, lastPlayerPosition) < 10f))
			{
				lastPlayerPosition = player.position;
				currentPlayerChunk = WorldToChunkPosition(player.position);
				UpdateChunkLoadQueue();
				UnloadDistantChunks();
				yield return StartCoroutine(LoadQueuedChunks());
				UpdateDebugInfo();
			}
		}
	}

	private void UpdateChunkLoadQueue()
	{
		chunksToLoad.Clear();
		for (int i = -loadRadius; i <= loadRadius; i++)
		{
			for (int j = -loadRadius; j <= loadRadius; j++)
			{
				Vector2Int key = currentPlayerChunk + new Vector2Int(i, j);
				if (chunkPositionMap.TryGetValue(key, out var value) && !activeChunks.Contains(value))
				{
					chunksToLoad.Enqueue(value);
				}
			}
		}
	}

	private IEnumerator LoadQueuedChunks()
	{
		int loadedThisUpdate = 0;
		while (chunksToLoad.Count > 0 && loadedThisUpdate < maxChunksPerUpdate)
		{
			ChunkDataHolder chunk = chunksToLoad.Dequeue();
			yield return StartCoroutine(LoadChunk(chunk));
			activeChunks.Add(chunk);
			loadedThisUpdate++;
			yield return null;
		}
		if (loadedThisUpdate > 0)
		{
			Debug.Log($"[DynamicChunkManager] Loaded {loadedThisUpdate} chunks. Active: {activeChunks.Count}");
		}
	}

	private IEnumerator LoadChunk(ChunkDataHolder chunk)
	{
		chunk.gameObject.SetActive(value: true);
		if (chunk.spawnedObjects.Count == 0)
		{
			Debug.Log($"[DynamicChunkManager] Generating chunk {chunk.chunkID} at position {WorldToChunkPosition(chunk.transform.position)}");
			chunk.PlaceObjects();
			float timeout = 10f;
			float elapsed = 0f;
			while (chunk.spawnedObjects.Count == 0 && elapsed < timeout)
			{
				yield return new WaitForSeconds(0.1f);
				elapsed += 0.1f;
			}
		}
		else
		{
			Debug.Log($"[DynamicChunkManager] Reactivating chunk {chunk.chunkID} (already generated)");
		}
	}

	private void UnloadDistantChunks()
	{
		List<ChunkDataHolder> list = new List<ChunkDataHolder>();
		foreach (ChunkDataHolder activeChunk in activeChunks)
		{
			Vector2Int vector2Int = WorldToChunkPosition(activeChunk.transform.position);
			if (Mathf.Max(Mathf.Abs(vector2Int.x - currentPlayerChunk.x), Mathf.Abs(vector2Int.y - currentPlayerChunk.y)) > unloadRadius)
			{
				list.Add(activeChunk);
			}
		}
		foreach (ChunkDataHolder item in list)
		{
			UnloadChunk(item);
			activeChunks.Remove(item);
		}
		if (list.Count > 0)
		{
			Debug.Log($"[DynamicChunkManager] Unloaded {list.Count} chunks. Active: {activeChunks.Count}");
		}
	}

	private void UnloadChunk(ChunkDataHolder chunk)
	{
		chunk.gameObject.SetActive(value: false);
	}

	private void UpdateDebugInfo()
	{
		activeChunkCount = activeChunks.Count;
		loadedChunkPositions.Clear();
		foreach (ChunkDataHolder activeChunk in activeChunks)
		{
			loadedChunkPositions.Add(WorldToChunkPosition(activeChunk.transform.position));
		}
	}

	public void LoadChunkAtPosition(Vector2Int chunkPos)
	{
		if (chunkPositionMap.TryGetValue(chunkPos, out var value) && !activeChunks.Contains(value))
		{
			StartCoroutine(LoadChunk(value));
			activeChunks.Add(value);
		}
	}

	public void UnloadAllChunks()
	{
		foreach (ChunkDataHolder activeChunk in activeChunks)
		{
			UnloadChunk(activeChunk);
		}
		activeChunks.Clear();
		Debug.Log("[DynamicChunkManager] All chunks unloaded");
	}

	public void ForceReloadNearbyChunks()
	{
		if (player != null)
		{
			currentPlayerChunk = WorldToChunkPosition(player.position);
			UpdateChunkLoadQueue();
			StartCoroutine(LoadQueuedChunks());
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (player == null)
		{
			return;
		}
		Vector2Int vector2Int = WorldToChunkPosition(player.position);
		float num = 500f;
		Gizmos.color = Color.green;
		for (int i = -loadRadius; i <= loadRadius; i++)
		{
			for (int j = -loadRadius; j <= loadRadius; j++)
			{
				Gizmos.DrawWireCube(new Vector3((float)(vector2Int.x + i) * num + num / 2f, player.position.y, (float)(vector2Int.y + j) * num + num / 2f), new Vector3(num, 10f, num));
			}
		}
		Gizmos.color = Color.red;
		for (int k = -unloadRadius; k <= unloadRadius; k++)
		{
			for (int l = -unloadRadius; l <= unloadRadius; l++)
			{
				if (Mathf.Abs(k) > loadRadius || Mathf.Abs(l) > loadRadius)
				{
					Gizmos.DrawWireCube(new Vector3((float)(vector2Int.x + k) * num + num / 2f, player.position.y, (float)(vector2Int.y + l) * num + num / 2f), new Vector3(num, 5f, num));
				}
			}
		}
	}
}
