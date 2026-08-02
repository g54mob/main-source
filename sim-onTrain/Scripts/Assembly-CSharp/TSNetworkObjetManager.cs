using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TSNetworkObjetManager : Singleton<TSNetworkObjetManager>
{
	public List<GameObject> playerConnections = new List<GameObject>();

	public List<TsPlayerNetworkHelper> playerNetworkHelpers = new List<TsPlayerNetworkHelper>();

	[HideInInspector]
	public UnityEvent<TSPlayerController> OnServerInitialize = new UnityEvent<TSPlayerController>();

	[SerializeField]
	private TrainBuildManager trainBuildManager;

	private ZombieSpawner[] cachedSpawners;

	private ChunkDataHolder[] cachedChunks;

	private bool isCached;

	private Queue<TSPlayerController> initQueue = new Queue<TSPlayerController>();

	private bool isProcessingQueue;

	private void Start()
	{
		if (trainBuildManager == null)
		{
			Debug.LogWarning("TrainBuildManager bulunamadı! Yeni oyuncu sync'i çalışmayabilir.");
		}
	}

	private void CacheReferences()
	{
		if (!isCached)
		{
			cachedSpawners = Object.FindObjectsOfType<ZombieSpawner>();
			cachedChunks = Object.FindObjectsOfType<ChunkDataHolder>();
			isCached = true;
		}
	}

	public void InvalidateCache()
	{
		isCached = false;
	}

	public void Initialize(TSPlayerController player)
	{
		if (player != null && !playerConnections.Contains(player.gameObject))
		{
			playerConnections.Add(player.gameObject);
			Debug.Log($"Oyuncu {player.name} listeye eklendi. Toplam oyuncu sayısı: {playerConnections.Count}");
			TsPlayerNetworkHelper component = player.GetComponent<TsPlayerNetworkHelper>();
			if (component != null && !playerNetworkHelpers.Contains(component))
			{
				playerNetworkHelpers.Add(component);
			}
		}
		foreach (GameObject playerConnection in playerConnections)
		{
			playerConnection.SetActive(value: true);
		}
		initQueue.Enqueue(player);
		if (!isProcessingQueue)
		{
			StartCoroutine(ProcessInitQueue());
		}
	}

	private IEnumerator ProcessInitQueue()
	{
		isProcessingQueue = true;
		CacheReferences();
		while (initQueue.Count > 0)
		{
			TSPlayerController tSPlayerController = initQueue.Dequeue();
			if (tSPlayerController == null)
			{
				continue;
			}
			if (trainBuildManager != null)
			{
				trainBuildManager.OnPlayerConnected(tSPlayerController);
			}
			if (cachedSpawners != null)
			{
				ZombieSpawner[] array = cachedSpawners;
				foreach (ZombieSpawner zombieSpawner in array)
				{
					if (zombieSpawner != null)
					{
						zombieSpawner.RegisterPlayer(tSPlayerController);
					}
				}
			}
			if (cachedChunks != null)
			{
				ChunkDataHolder[] array2 = cachedChunks;
				foreach (ChunkDataHolder chunkDataHolder in array2)
				{
					if (chunkDataHolder != null)
					{
						chunkDataHolder.RegisterPlayer(tSPlayerController);
					}
				}
			}
			OnServerInitialize.Invoke(tSPlayerController);
			Debug.Log("Oyuncu " + tSPlayerController.name + " için initialization tamamlandı ve data sync edildi.");
			if (initQueue.Count > 0)
			{
				yield return null;
			}
		}
		isProcessingQueue = false;
	}

	public void RemovePlayer(TSPlayerController player)
	{
		if (player == null)
		{
			return;
		}
		if (playerConnections.Contains(player.gameObject))
		{
			playerConnections.Remove(player.gameObject);
			Debug.Log($"Oyuncu {player.name} listeden çıkarıldı. Kalan oyuncu sayısı: {playerConnections.Count}");
			TsPlayerNetworkHelper component = player.GetComponent<TsPlayerNetworkHelper>();
			if (component != null && playerNetworkHelpers.Contains(component))
			{
				playerNetworkHelpers.Remove(component);
			}
		}
		CacheReferences();
		if (cachedSpawners != null)
		{
			ZombieSpawner[] array = cachedSpawners;
			foreach (ZombieSpawner zombieSpawner in array)
			{
				if (zombieSpawner != null)
				{
					zombieSpawner.UnregisterPlayer(player);
				}
			}
		}
		if (cachedChunks == null)
		{
			return;
		}
		ChunkDataHolder[] array2 = cachedChunks;
		foreach (ChunkDataHolder chunkDataHolder in array2)
		{
			if (chunkDataHolder != null)
			{
				chunkDataHolder.UnregisterPlayer(player);
			}
		}
	}
}
