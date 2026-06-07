using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class PlayerActionNotificationManager : NetworkBehaviour
{
	[Header("Prefab")]
	[Tooltip("PlayerActionNotificationUI scripti içeren bildirim prefab'ı")]
	[SerializeField]
	private GameObject notificationPrefab;

	[Header("Container")]
	[Tooltip("Bildirimlerin spawn edileceği container (VerticalLayoutGroup önerilir)")]
	[SerializeField]
	private Transform notificationContainer;

	public static PlayerActionNotificationManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	[Server]
	public void ShowPlayerActionNotification(string playerName, PlayerActionNotificationType actionType)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerActionNotificationManager::ShowPlayerActionNotification(System.String,PlayerActionNotificationType)' called when server was not active");
		}
		else if (actionType != PlayerActionNotificationType.None)
		{
			RpcShowNotification(playerName, actionType);
		}
	}

	[Server]
	public void OnPlayerLeft(string playerName)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void PlayerActionNotificationManager::OnPlayerLeft(System.String)' called when server was not active");
		}
		else
		{
			ShowPlayerActionNotification(playerName, PlayerActionNotificationType.ActionNotificationPlayerLeft);
		}
	}

	public void RequestPlayerJoinedNotification(string playerName)
	{
		if (NetworkClient.active)
		{
			CmdRequestPlayerJoinedNotification(playerName);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestPlayerJoinedNotification(string playerName)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestPlayerJoinedNotification__String(playerName);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(playerName);
		SendCommandInternal("System.Void PlayerActionNotificationManager::CmdRequestPlayerJoinedNotification(System.String)", -643565428, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void RpcShowNotification(string playerName, PlayerActionNotificationType actionType)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(playerName);
		GeneratedNetworkCode._Write_PlayerActionNotificationType(writer, actionType);
		SendRPCInternal("System.Void PlayerActionNotificationManager::RpcShowNotification(System.String,PlayerActionNotificationType)", 1475967111, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CreateNotification(string playerName, PlayerActionNotificationType actionType)
	{
		if (notificationPrefab == null)
		{
			Debug.LogError("[PlayerActionNotificationManager] Notification prefab atanmamış!");
			return;
		}
		if (notificationContainer == null)
		{
			Debug.LogError("[PlayerActionNotificationManager] Notification container atanmamış!");
			return;
		}
		GameObject gameObject = Object.Instantiate(notificationPrefab, notificationContainer);
		PlayerActionNotificationUI component = gameObject.GetComponent<PlayerActionNotificationUI>();
		if (component == null)
		{
			Debug.LogError("[PlayerActionNotificationManager] Prefab'da PlayerActionNotificationUI component'i bulunamadı!");
			Object.Destroy(gameObject);
		}
		else
		{
			component.Initialize(playerName, actionType);
		}
	}

	public void ClearAllNotifications()
	{
		if (notificationContainer == null)
		{
			return;
		}
		foreach (Transform item in notificationContainer)
		{
			Object.Destroy(item.gameObject);
		}
	}

	[ContextMenu("Test: Player Joined (Local)")]
	private void TestPlayerJoinedLocal()
	{
		CreateNotification("TestPlayer", PlayerActionNotificationType.ActionNotificationPlayerJoined);
	}

	[ContextMenu("Test: Player Left (Local)")]
	private void TestPlayerLeftLocal()
	{
		CreateNotification("TestPlayer", PlayerActionNotificationType.ActionNotificationPlayerLeft);
	}

	[ContextMenu("Test: Player Joined (Server -> All)")]
	private void TestPlayerJoinedServer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[PlayerActionNotificationManager] Server aktif değil!");
		}
		else
		{
			ShowPlayerActionNotification("TestPlayer", PlayerActionNotificationType.ActionNotificationPlayerJoined);
		}
	}

	[ContextMenu("Test: Player Left (Server -> All)")]
	private void TestPlayerLeftServer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[PlayerActionNotificationManager] Server aktif değil!");
		}
		else
		{
			ShowPlayerActionNotification("TestPlayer", PlayerActionNotificationType.ActionNotificationPlayerLeft);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestPlayerJoinedNotification__String(string playerName)
	{
		ShowPlayerActionNotification(playerName, PlayerActionNotificationType.ActionNotificationPlayerJoined);
	}

	protected static void InvokeUserCode_CmdRequestPlayerJoinedNotification__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestPlayerJoinedNotification called on client.");
		}
		else
		{
			((PlayerActionNotificationManager)obj).UserCode_CmdRequestPlayerJoinedNotification__String(reader.ReadString());
		}
	}

	protected void UserCode_RpcShowNotification__String__PlayerActionNotificationType(string playerName, PlayerActionNotificationType actionType)
	{
		CreateNotification(playerName, actionType);
	}

	protected static void InvokeUserCode_RpcShowNotification__String__PlayerActionNotificationType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcShowNotification called on server.");
		}
		else
		{
			((PlayerActionNotificationManager)obj).UserCode_RpcShowNotification__String__PlayerActionNotificationType(reader.ReadString(), GeneratedNetworkCode._Read_PlayerActionNotificationType(reader));
		}
	}

	static PlayerActionNotificationManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PlayerActionNotificationManager), "System.Void PlayerActionNotificationManager::CmdRequestPlayerJoinedNotification(System.String)", InvokeUserCode_CmdRequestPlayerJoinedNotification__String, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PlayerActionNotificationManager), "System.Void PlayerActionNotificationManager::RpcShowNotification(System.String,PlayerActionNotificationType)", InvokeUserCode_RpcShowNotification__String__PlayerActionNotificationType);
	}
}
