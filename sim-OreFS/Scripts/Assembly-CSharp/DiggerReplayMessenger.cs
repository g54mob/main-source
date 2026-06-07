using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Digger.Modules.Core.Sources;
using Digger.Modules.Core.Sources.Operations;
using Digger.Modules.Runtime.Sources;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using UnityEngine;

[DisallowMultipleComponent]
public class DiggerReplayMessenger : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class ReplaySaveData
	{
		public List<ReplayOp> operations = new List<ReplayOp>();
	}

	[Serializable]
	public struct ReplayOp
	{
		public Vector3 pos;

		public Vector3 vfxPos;

		public Vector3 vfxRot;

		public byte brush;

		public byte action;

		public float size;

		public float opacity;

		public sbyte textureIndex;
	}

	public struct ClientReadyForReplayMsg : NetworkMessage
	{
		public int lastKnownIndex;
	}

	public struct ReplayBeginMsg : NetworkMessage
	{
		public int expectedTotal;

		public int startIndex;
	}

	public struct ReplayChunkMsg : NetworkMessage
	{
		public List<ReplayOp> chunk;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ReplayEndMsg : NetworkMessage
	{
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct ReplayCompleteMsg : NetworkMessage
	{
	}

	[Header("Stream Settings (Server)")]
	[Tooltip("Sunucunun her mesajda yollayacağı op sayısı")]
	public int REPLAY_CHUNK_SIZE = 128;

	[Header("Coalesce Settings")]
	[Tooltip("Bu mesafe içindeki ardışık op'lar birleştirilir (replay log küçülür).")]
	[SerializeField]
	private float coalesceDistance = 0.25f;

	[Tooltip("Bu süre içindeki ardışık op'lar birleştirilir.")]
	[SerializeField]
	private float coalesceTime = 0.2f;

	[Header("Debug")]
	[SerializeField]
	private bool enableDebugLogging;

	[Header("Server OpLog (Runtime)")]
	[SerializeField]
	private List<ReplayOp> serverOpLog = new List<ReplayOp>();

	private float _lastAppendTime;

	private readonly Queue<ReplayOp> _queue = new Queue<ReplayOp>();

	private Coroutine _consumeCo;

	private DiggerMasterRuntime _digger;

	private int _replayExpectedTotal;

	private int _replayProcessed;

	private bool _replayInProgress;

	[Header("Terrain Reset")]
	public Terrain targetTerrain;

	private readonly HashSet<int> _pendingReady = new HashSet<int>();

	private readonly HashSet<int> _replayingClients = new HashSet<int>();

	public static DiggerReplayMessenger Instance { get; private set; }

	public int ServerOpLogCount => serverOpLog.Count;

	private bool IsHost
	{
		get
		{
			if (NetworkServer.active)
			{
				return NetworkClient.isConnected;
			}
			return false;
		}
	}

	public string SaveID => "digger-replay-messenger";

	public bool IsShared => false;

	public Type SaveType => typeof(ReplaySaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public ReplayOp GetServerOp(int index)
	{
		return serverOpLog[index];
	}

	public void ServerAppendOp(ReplayOp op)
	{
		float time = Time.time;
		int num = serverOpLog.Count - 1;
		if (num >= 0)
		{
			ReplayOp value = serverOpLog[num];
			bool num2 = time - _lastAppendTime <= coalesceTime;
			bool flag = Vector3.SqrMagnitude(value.pos - op.pos) <= coalesceDistance * coalesceDistance;
			bool flag2 = value.brush == op.brush && value.action == op.action && Mathf.Abs(value.size - op.size) < 0.05f && Mathf.Abs(value.opacity - op.opacity) < 0.05f && value.textureIndex == op.textureIndex;
			if (num2 && flag && flag2)
			{
				value.pos = (value.pos + op.pos) * 0.5f;
				serverOpLog[num] = value;
				_lastAppendTime = time;
				return;
			}
		}
		serverOpLog.Add(op);
		_lastAppendTime = time;
		if (serverOpLog.Count > 500000)
		{
			serverOpLog.RemoveRange(0, serverOpLog.Count - 500000);
		}
	}

	public void ClearOpLog()
	{
		serverOpLog.Clear();
	}

	private static bool IsLocalHostConnection(NetworkConnectionToClient conn)
	{
		if (conn != null)
		{
			if (conn != NetworkServer.localConnection)
			{
				return conn is LocalConnectionToClient;
			}
			return true;
		}
		return false;
	}

	public bool IsConnectionPendingReady(int connectionId)
	{
		return _pendingReady.Contains(connectionId);
	}

	private void Awake()
	{
		Instance = this;
		ResolveLocalDiggerAndNav();
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		if (!SaveLoadGameManager.IsLoadPendingOrInProgress)
		{
			StartCoroutine(Co_ClearDiggerForNewGame());
		}
		NetworkServer.RegisterHandler<ClientReadyForReplayMsg>(OnMsg_ClientReady);
		NetworkServer.RegisterHandler<ReplayCompleteMsg>(OnMsg_ReplayComplete);
		NetworkServer.OnConnectedEvent = (Action<NetworkConnectionToClient>)Delegate.Combine(NetworkServer.OnConnectedEvent, new Action<NetworkConnectionToClient>(OnServerClientConnected));
		NetworkServer.OnDisconnectedEvent = (Action<NetworkConnectionToClient>)Delegate.Combine(NetworkServer.OnDisconnectedEvent, new Action<NetworkConnectionToClient>(OnServerClientDisconnected));
		foreach (NetworkConnectionToClient value in NetworkServer.connections.Values)
		{
			if (value != null && !IsLocalHostConnection(value))
			{
				_pendingReady.Add(value.connectionId);
			}
		}
		SaveLoadManager.Subscribe(this, 32);
		if (enableDebugLogging)
		{
			Debug.Log("[ReplayMessenger][Server] Started.");
		}
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		NetworkServer.UnregisterHandler<ClientReadyForReplayMsg>();
		NetworkServer.UnregisterHandler<ReplayCompleteMsg>();
		NetworkServer.OnConnectedEvent = (Action<NetworkConnectionToClient>)Delegate.Remove(NetworkServer.OnConnectedEvent, new Action<NetworkConnectionToClient>(OnServerClientConnected));
		NetworkServer.OnDisconnectedEvent = (Action<NetworkConnectionToClient>)Delegate.Remove(NetworkServer.OnDisconnectedEvent, new Action<NetworkConnectionToClient>(OnServerClientDisconnected));
		_pendingReady.Clear();
		_replayingClients.Clear();
		SaveLoadManager.Unsubscribe(this);
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		if (!SaveLoadGameManager.IsLoadingFromSave)
		{
			StartCoroutine(Co_FillAllHoles());
		}
		if (!IsHost)
		{
			ResolveLocalDiggerAndNav();
			_replayInProgress = true;
			LoadingManagerUI.Show(LoadingType.Digger);
			SaveLoadGameManager.RegisterPendingLoadOperation("Loading_Digger");
			NetworkClient.RegisterHandler<ReplayBeginMsg>(OnMsg_Begin);
			NetworkClient.RegisterHandler<ReplayChunkMsg>(OnMsg_Chunk);
			NetworkClient.RegisterHandler<ReplayEndMsg>(OnMsg_End);
			StartCoroutine(Co_ClientAnnounceReady());
			if (enableDebugLogging)
			{
				Debug.Log("[ReplayMessenger][Client] Started.");
			}
		}
	}

	public override void OnStopClient()
	{
		base.OnStopClient();
		if (!IsHost)
		{
			CompleteReplayLoading();
			NetworkClient.UnregisterHandler<ReplayBeginMsg>();
			NetworkClient.UnregisterHandler<ReplayChunkMsg>();
			NetworkClient.UnregisterHandler<ReplayEndMsg>();
		}
	}

	private IEnumerator Co_FillAllHoles()
	{
		yield return new WaitForSeconds(1f);
		while (!NetworkClient.isConnected || NetworkClient.connection == null || !NetworkClient.connection.isReady)
		{
			yield return null;
		}
		FillAllHoles();
		if (enableDebugLogging)
		{
			Debug.Log("[ReplayMessenger] Terrain holes filled.");
		}
	}

	private void FillAllHoles()
	{
		if (targetTerrain == null)
		{
			targetTerrain = Terrain.activeTerrain;
		}
		if (targetTerrain == null)
		{
			Debug.LogError("[ReplayMessenger] Terrain bulunamadı.");
			return;
		}
		TerrainData terrainData = targetTerrain.terrainData;
		int holesResolution = terrainData.holesResolution;
		if (holesResolution <= 0)
		{
			return;
		}
		bool[,] array = new bool[holesResolution, holesResolution];
		for (int i = 0; i < holesResolution; i++)
		{
			for (int j = 0; j < holesResolution; j++)
			{
				array[i, j] = true;
			}
		}
		terrainData.SetHoles(0, 0, array);
	}

	private IEnumerator Co_ClientAnnounceReady()
	{
		yield return new WaitForSeconds(1f);
		while (!NetworkClient.isConnected || NetworkClient.connection == null || !NetworkClient.connection.isReady)
		{
			yield return null;
		}
		yield return new WaitForSeconds(1f);
		float timeout = Time.time + 10f;
		while (_digger == null && Time.time < timeout)
		{
			ResolveLocalDiggerAndNav();
			yield return null;
		}
		yield return null;
		NetworkClient.Send(new ClientReadyForReplayMsg
		{
			lastKnownIndex = 0
		});
		if (enableDebugLogging)
		{
			Debug.Log("[ReplayMessenger][Client] Sent ClientReadyForReplayMsg");
		}
	}

	private void OnServerClientConnected(NetworkConnectionToClient conn)
	{
		if (base.isServer && !IsLocalHostConnection(conn))
		{
			_pendingReady.Add(conn.connectionId);
			Debug.Log($"[ReplayMessenger][Server] Client connected: conn={conn.connectionId}");
		}
	}

	private void OnServerClientDisconnected(NetworkConnectionToClient conn)
	{
		_pendingReady.Remove(conn.connectionId);
		if (_replayingClients.Remove(conn.connectionId) && _replayingClients.Count == 0 && NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerHideLoading(LoadingType.Digger);
		}
	}

	private void OnMsg_ClientReady(NetworkConnectionToClient conn, ClientReadyForReplayMsg msg)
	{
		if (!base.isServer || IsLocalHostConnection(conn) || !_pendingReady.Contains(conn.connectionId))
		{
			return;
		}
		_pendingReady.Remove(conn.connectionId);
		int count = serverOpLog.Count;
		if (count > 0)
		{
			_replayingClients.Add(conn.connectionId);
			if (NetworkLoadingSync.Instance != null)
			{
				NetworkLoadingSync.Instance.ServerShowLoadingExcept(conn, LoadingType.Digger);
			}
			conn.Send(new ReplayBeginMsg
			{
				expectedTotal = count,
				startIndex = 0
			});
			SendChunksTo(conn, 0, count);
		}
		conn.Send(default(ReplayEndMsg));
		Debug.Log($"[ReplayMessenger][Server] Full history sent to conn {conn.connectionId}: {count} ops");
	}

	private void OnMsg_ReplayComplete(NetworkConnectionToClient conn, ReplayCompleteMsg msg)
	{
		if (base.isServer)
		{
			if (_replayingClients.Remove(conn.connectionId) && _replayingClients.Count == 0 && NetworkLoadingSync.Instance != null)
			{
				NetworkLoadingSync.Instance.ServerHideLoading(LoadingType.Digger);
			}
			Debug.Log($"[ReplayMessenger][Server] Client replay complete: conn={conn.connectionId}");
		}
	}

	private void SendChunksTo(NetworkConnectionToClient conn, int startIndex, int count)
	{
		if (count > 0)
		{
			int num = Mathf.Clamp(startIndex, 0, serverOpLog.Count);
			int num2 = Mathf.Clamp(startIndex + count, 0, serverOpLog.Count);
			List<ReplayOp> range = serverOpLog.GetRange(num, num2 - num);
			for (int i = 0; i < range.Count; i += REPLAY_CHUNK_SIZE)
			{
				int count2 = Mathf.Min(REPLAY_CHUNK_SIZE, range.Count - i);
				conn.Send(new ReplayChunkMsg
				{
					chunk = range.GetRange(i, count2)
				});
			}
		}
	}

	private void OnMsg_Begin(ReplayBeginMsg msg)
	{
		if (!IsHost)
		{
			_replayExpectedTotal = msg.expectedTotal;
			_replayProcessed = 0;
			UpdateReplayProgressText();
			if (enableDebugLogging)
			{
				Debug.Log($"[ReplayMessenger][Client] BEGIN exp={msg.expectedTotal} start={msg.startIndex}");
			}
		}
	}

	private void OnMsg_Chunk(ReplayChunkMsg msg)
	{
		if (!IsHost && msg.chunk != null && msg.chunk.Count != 0)
		{
			for (int i = 0; i < msg.chunk.Count; i++)
			{
				_queue.Enqueue(msg.chunk[i]);
			}
			if (_consumeCo == null)
			{
				_consumeCo = StartCoroutine(Co_ConsumeQueue());
			}
			if (enableDebugLogging)
			{
				Debug.Log($"[ReplayMessenger][Client] CHUNK +{msg.chunk.Count} queued={_queue.Count}");
			}
		}
	}

	private void OnMsg_End(ReplayEndMsg _)
	{
		if (!IsHost)
		{
			if (_queue.Count == 0 && _consumeCo == null)
			{
				CompleteReplayLoading();
			}
			if (enableDebugLogging)
			{
				Debug.Log("[ReplayMessenger][Client] END");
			}
		}
	}

	private void ResolveLocalDiggerAndNav()
	{
		GameManager instance = GameManager.Instance;
		if (instance != null)
		{
			_digger = (instance.DiggerMasterRuntime ? instance.DiggerMasterRuntime : _digger);
		}
		if (!_digger)
		{
			_digger = UnityEngine.Object.FindFirstObjectByType<DiggerMasterRuntime>();
		}
	}

	private IEnumerator Co_ConsumeQueue()
	{
		if (!_digger)
		{
			ResolveLocalDiggerAndNav();
		}
		float timeout = Time.time + 15f;
		while (!_digger && Time.time < timeout)
		{
			ResolveLocalDiggerAndNav();
			yield return null;
		}
		if (!_digger)
		{
			Debug.LogError("[ReplayMessenger][Client] DiggerMasterRuntime bulunamadı, playback iptal.");
			_queue.Clear();
			_consumeCo = null;
			CompleteReplayLoading();
			yield break;
		}
		DiggerSystem[] diggerSystems = UnityEngine.Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
		if (diggerSystems == null || diggerSystems.Length == 0)
		{
			Debug.LogError("[ReplayMessenger][Client] DiggerSystem bulunamadı, playback iptal.");
			_queue.Clear();
			_consumeCo = null;
			CompleteReplayLoading();
			yield break;
		}
		Debug.Log($"[ReplayMessenger][Client] Playback start: {_queue.Count} ops (ModifyWithoutMeshes mode)");
		BasicOperation basicOp = new BasicOperation();
		KernelOperation kernelOp = new KernelOperation();
		int opsSinceMeshBuild = 0;
		while (_queue.Count > 0)
		{
			if (!_digger)
			{
				Debug.LogWarning("[ReplayMessenger][Client] Digger destroyed, playback durdu.");
				_queue.Clear();
				break;
			}
			ReplayOp replayOp = _queue.Dequeue();
			if (!IsReplayPositionValid(replayOp.pos, diggerSystems))
			{
				Debug.LogWarning($"[ReplayMessenger] SKIP replay op: Position {replayOp.pos} outside terrain bounds.");
				_replayProcessed++;
				if (_replayProcessed % 32 == 0)
				{
					UpdateReplayProgressText();
				}
				continue;
			}
			ModificationParameters mp = new ModificationParameters
			{
				Position = replayOp.pos,
				Brush = (BrushType)replayOp.brush,
				CustomBrush = null,
				Action = (ActionType)replayOp.action,
				TextureIndex = replayOp.textureIndex,
				Opacity = replayOp.opacity,
				Size = replayOp.size,
				StalagmiteUpsideDown = false,
				OpacityIsTarget = false,
				PaintWhileDigging = (replayOp.action == 1),
				Callback = null
			};
			bool isKernel = mp.Action == ActionType.Smooth || mp.Action == ActionType.BETA_Sharpen;
			DiggerSystem[] array = diggerSystems;
			foreach (DiggerSystem diggerSystem in array)
			{
				if (!(diggerSystem == null))
				{
					if (isKernel)
					{
						kernelOp.Params = mp;
						yield return diggerSystem.ModifyWithoutMeshes(kernelOp);
					}
					else
					{
						basicOp.Params = mp;
						yield return diggerSystem.ModifyWithoutMeshes(basicOp);
					}
				}
			}
			_replayProcessed++;
			opsSinceMeshBuild++;
			if (_replayProcessed % 32 == 0)
			{
				UpdateReplayProgressText();
			}
			if (opsSinceMeshBuild < 32)
			{
				continue;
			}
			Debug.Log($"[ReplayMessenger][Client] Batch mesh build at op {_replayProcessed}");
			array = diggerSystems;
			foreach (DiggerSystem diggerSystem2 in array)
			{
				if (!(diggerSystem2 == null))
				{
					yield return diggerSystem2.BuildPendingMeshesAsync(useBackgroundThreads: false);
				}
			}
			opsSinceMeshBuild = 0;
		}
		if (opsSinceMeshBuild > 0)
		{
			Debug.Log($"[ReplayMessenger][Client] Final mesh build ({opsSinceMeshBuild} pending ops)");
			DiggerSystem[] array = diggerSystems;
			foreach (DiggerSystem diggerSystem3 in array)
			{
				if (!(diggerSystem3 == null))
				{
					yield return diggerSystem3.BuildPendingMeshesAsync(useBackgroundThreads: false);
				}
			}
		}
		Debug.Log("[ReplayMessenger][Client] Playback finished.");
		UpdateReplayProgressText();
		CompleteReplayLoading();
		_consumeCo = null;
	}

	private bool IsReplayPositionValid(Vector3 pos, DiggerSystem[] cachedDiggerSystems)
	{
		foreach (DiggerSystem diggerSystem in cachedDiggerSystems)
		{
			if (!(diggerSystem.Terrain == null))
			{
				Vector3 position = diggerSystem.Terrain.transform.position;
				Vector3 size = diggerSystem.Terrain.terrainData.size;
				if (pos.x >= position.x && pos.x <= position.x + size.x && pos.z >= position.z && pos.z <= position.z + size.z && pos.y >= position.y - size.y && pos.y <= position.y + size.y * 2f)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void UpdateReplayProgressText()
	{
		if (_replayInProgress)
		{
			string translation = LocalizationManager.GetTranslation("Loading_Digger");
			LoadingManagerUI.UpdateReason($"{translation} ({_replayProcessed}/{_replayExpectedTotal})");
		}
	}

	private void CompleteReplayLoading()
	{
		if (_replayInProgress)
		{
			_replayInProgress = false;
			SaveLoadGameManager.CompletePendingLoadOperation("Loading_Digger");
			LoadingManagerUI.Hide(LoadingType.Digger);
			if (NetworkClient.isConnected)
			{
				NetworkClient.Send(default(ReplayCompleteMsg));
			}
			Debug.Log($"[ReplayMessenger][Client] Replay loading completed: {_replayProcessed}/{_replayExpectedTotal}");
		}
	}

	private IEnumerator Co_ClearDiggerForNewGame()
	{
		Debug.Log("[DiggerClear] Yeni oyun temizlik başladı");
		if (_consumeCo != null)
		{
			StopCoroutine(_consumeCo);
			_consumeCo = null;
		}
		_queue.Clear();
		yield return null;
		DiggerMasterRuntime diggerMasterRuntime = UnityEngine.Object.FindFirstObjectByType<DiggerMasterRuntime>();
		if (diggerMasterRuntime != null)
		{
			diggerMasterRuntime.ClearBuffer();
			diggerMasterRuntime.ClearScene();
		}
		ClearOpLog();
		_digger = diggerMasterRuntime;
		yield return null;
		FillAllHoles();
		Debug.Log("[DiggerClear] Yeni oyun temizlik tamamlandı");
	}

	public object GetSaveData(bool includeNonSavable)
	{
		ReplaySaveData replaySaveData = new ReplaySaveData
		{
			operations = new List<ReplayOp>(serverOpLog)
		};
		if (replaySaveData.operations.Count > 0)
		{
			Debug.Log($"[ReplayMessenger] Save: {replaySaveData.operations.Count} ops kaydedildi.");
		}
		return replaySaveData;
	}

	public Task OnLoad(object value)
	{
		if (!(value is ReplaySaveData replaySaveData))
		{
			return Task.CompletedTask;
		}
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (replaySaveData.operations == null || replaySaveData.operations.Count == 0)
		{
			Debug.Log("[ReplayMessenger] Load: Kaydedilmiş op yok.");
			return Task.CompletedTask;
		}
		serverOpLog.Clear();
		serverOpLog.AddRange(replaySaveData.operations);
		DiggerSystem[] array = UnityEngine.Object.FindObjectsByType<DiggerSystem>(FindObjectsSortMode.None);
		foreach (DiggerSystem diggerSystem in array)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(diggerSystem.PersistentRuntimePathData);
			int num = (directoryInfo.Exists ? directoryInfo.GetFiles("*.vox3").Length : 0);
			int num2 = diggerSystem.GetComponentsInChildren<VoxelChunk>().Length;
			Debug.Log($"[ReplayMessenger] Load diag: {diggerSystem.name} vox3Files={num}, loadedChunks={num2}");
		}
		Debug.Log($"[ReplayMessenger] Load: {replaySaveData.operations.Count} ops serverOpLog'a yüklendi.");
		return Task.CompletedTask;
	}

	public override bool Weaved()
	{
		return true;
	}
}
