using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class T_DartManager : NetworkBehaviour
{
	[Header("Prefab")]
	[SerializeField]
	private GameObject dartPrefab;

	[Header("Throw Settings")]
	[SerializeField]
	private Transform throwPoint;

	[SerializeField]
	private Camera playerCamera;

	[SerializeField]
	private float throwForwardOffset = 1f;

	[SerializeField]
	private float throwUpwardAngle = 5f;

	[SyncVar]
	private int remainingDarts;

	[SyncVar]
	private bool isInDartGame;

	private T_Dartboard activeDartboard;

	private readonly List<T_Dart> myDarts = new List<T_Dart>();

	private readonly List<T_Dart> localDartRefs = new List<T_Dart>();

	public bool IsInDartGame => isInDartGame;

	public int RemainingDarts => remainingDarts;

	public int NetworkremainingDarts
	{
		get
		{
			return remainingDarts;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref remainingDarts, 1uL, null);
		}
	}

	public bool NetworkisInDartGame
	{
		get
		{
			return isInDartGame;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isInDartGame, 2uL, null);
		}
	}

	public void GiveDarts(T_Dartboard board, int count)
	{
		if (base.isLocalPlayer && !isInDartGame)
		{
			activeDartboard = board;
			if (GameManager.Instance != null)
			{
				GameManager.Instance.localEquipments.TryEquipByItemType(ItemType.Dart);
				CmdGiveDarts(board.netId, count);
			}
		}
	}

	[Command]
	private void CmdGiveDarts(uint boardNetId, int count)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdGiveDarts__UInt32__Int32(boardNetId, count);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(boardNetId);
		writer.WriteVarInt(count);
		SendCommandInternal("System.Void T_DartManager::CmdGiveDarts(System.UInt32,System.Int32)", 1871054408, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	public void ThrowDart(float chargeForce)
	{
		if (base.isLocalPlayer && isInDartGame && remainingDarts > 0)
		{
			Vector3 throwPosition = GetThrowPosition();
			Vector3 throwDirection = GetThrowDirection();
			CmdSpawnDart(throwPosition, throwDirection, chargeForce);
		}
	}

	[Command]
	private void CmdSpawnDart(Vector3 position, Vector3 direction, float chargeForce)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdSpawnDart__Vector3__Vector3__Single(position, direction, chargeForce);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(position);
		writer.WriteVector3(direction);
		writer.WriteFloat(chargeForce);
		SendCommandInternal("System.Void T_DartManager::CmdSpawnDart(UnityEngine.Vector3,UnityEngine.Vector3,System.Single)", 609578851, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerSpawnDart(Vector3 position, Vector3 direction, float chargeForce)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DartManager::ServerSpawnDart(UnityEngine.Vector3,UnityEngine.Vector3,System.Single)' called when server was not active");
			return;
		}
		if (dartPrefab == null)
		{
			Debug.LogError("T_DartManager: dartPrefab is null!");
			return;
		}
		GameObject gameObject = Object.Instantiate(dartPrefab, position, Quaternion.LookRotation(direction));
		NetworkServer.Spawn(gameObject);
		T_Dart component = gameObject.GetComponent<T_Dart>();
		if (component == null)
		{
			Debug.LogError("T_DartManager: Dart prefab'ında T_Dart component'i yok!");
			NetworkServer.Destroy(gameObject);
			return;
		}
		GamePlayer component2 = GetComponent<GamePlayer>();
		string text = ((component2 != null) ? component2.playerName : "");
		Debug.Log($"[T_DartManager] ServerSpawnDart - gamePlayer: {component2 != null}, playerName: '{text}'");
		component.ServerSetOwnerPlayer(base.netId, text);
		if (activeDartboard != null)
		{
			component.ServerSetDartboard(activeDartboard);
		}
		myDarts.Add(component);
		TargetDartCreated(base.connectionToClient, component.netId, direction, chargeForce);
	}

	[Server]
	public void ServerOnDartStuck()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_DartManager::ServerOnDartStuck()' called when server was not active");
			return;
		}
		NetworkremainingDarts = remainingDarts - 1;
		if (remainingDarts <= 0)
		{
			NetworkisInDartGame = false;
			activeDartboard = null;
			TargetOnAllDartsThrown(base.connectionToClient);
		}
	}

	public void CancelDartGame()
	{
		if (base.isLocalPlayer)
		{
			CmdCancelDartGame();
		}
	}

	[Command]
	private void CmdCancelDartGame()
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdCancelDartGame();
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_DartManager::CmdCancelDartGame()", -749357329, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private Vector3 GetThrowPosition()
	{
		if (throwPoint != null)
		{
			return throwPoint.position;
		}
		return base.transform.position + base.transform.forward * throwForwardOffset + Vector3.up * 1.5f;
	}

	private Vector3 GetThrowDirection()
	{
		Camera main = playerCamera;
		if (main == null)
		{
			main = Camera.main;
		}
		Vector3 vector = ((!(main != null)) ? base.transform.forward : main.transform.forward);
		if (throwUpwardAngle > 0f)
		{
			Vector3 axis = ((main != null) ? main.transform.right : base.transform.right);
			vector = Quaternion.AngleAxis(0f - throwUpwardAngle, axis) * vector;
		}
		return vector.normalized;
	}

	[TargetRpc]
	private void TargetDartCreated(NetworkConnectionToClient target, uint dartNetId, Vector3 throwDirection, float chargeForce)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(dartNetId);
		writer.WriteVector3(throwDirection);
		writer.WriteFloat(chargeForce);
		SendTargetRPCInternal(target, "System.Void T_DartManager::TargetDartCreated(Mirror.NetworkConnectionToClient,System.UInt32,UnityEngine.Vector3,System.Single)", 2135443537, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private IEnumerator WaitAndThrowDart(uint dartNetId, Vector3 throwDirection, float chargeForce)
	{
		float timeout = 2f;
		float elapsed = 0f;
		while (!NetworkClient.spawned.ContainsKey(dartNetId) && elapsed < timeout)
		{
			elapsed += Time.deltaTime;
			yield return null;
		}
		if (NetworkClient.spawned.TryGetValue(dartNetId, out var value))
		{
			T_Dart component = value.GetComponent<T_Dart>();
			if (component != null && !localDartRefs.Contains(component))
			{
				localDartRefs.Add(component);
				component.ClientThrow(throwDirection, chargeForce);
			}
		}
	}

	[TargetRpc]
	private void TargetOnAllDartsThrown(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_DartManager::TargetOnAllDartsThrown(Mirror.NetworkConnectionToClient)", -1014729522, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void OnDestroy()
	{
		if (base.isServer)
		{
			foreach (T_Dart myDart in myDarts)
			{
				if (myDart != null)
				{
					NetworkServer.Destroy(myDart.gameObject);
				}
			}
			myDarts.Clear();
		}
		localDartRefs.Clear();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdGiveDarts__UInt32__Int32(uint boardNetId, int count)
	{
		if (!isInDartGame && NetworkServer.spawned.TryGetValue(boardNetId, out var value))
		{
			T_Dartboard component = value.GetComponent<T_Dartboard>();
			if (!(component == null))
			{
				activeDartboard = component;
				NetworkremainingDarts = count;
				NetworkisInDartGame = true;
			}
		}
	}

	protected static void InvokeUserCode_CmdGiveDarts__UInt32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdGiveDarts called on client.");
		}
		else
		{
			((T_DartManager)obj).UserCode_CmdGiveDarts__UInt32__Int32(reader.ReadVarUInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdSpawnDart__Vector3__Vector3__Single(Vector3 position, Vector3 direction, float chargeForce)
	{
		if (isInDartGame && remainingDarts > 0)
		{
			ServerSpawnDart(position, direction, chargeForce);
		}
	}

	protected static void InvokeUserCode_CmdSpawnDart__Vector3__Vector3__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnDart called on client.");
		}
		else
		{
			((T_DartManager)obj).UserCode_CmdSpawnDart__Vector3__Vector3__Single(reader.ReadVector3(), reader.ReadVector3(), reader.ReadFloat());
		}
	}

	protected void UserCode_CmdCancelDartGame()
	{
		NetworkremainingDarts = 0;
		NetworkisInDartGame = false;
		activeDartboard = null;
	}

	protected static void InvokeUserCode_CmdCancelDartGame(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdCancelDartGame called on client.");
		}
		else
		{
			((T_DartManager)obj).UserCode_CmdCancelDartGame();
		}
	}

	protected void UserCode_TargetDartCreated__NetworkConnectionToClient__UInt32__Vector3__Single(NetworkConnectionToClient target, uint dartNetId, Vector3 throwDirection, float chargeForce)
	{
		StartCoroutine(WaitAndThrowDart(dartNetId, throwDirection, chargeForce));
	}

	protected static void InvokeUserCode_TargetDartCreated__NetworkConnectionToClient__UInt32__Vector3__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetDartCreated called on server.");
		}
		else
		{
			((T_DartManager)obj).UserCode_TargetDartCreated__NetworkConnectionToClient__UInt32__Vector3__Single(null, reader.ReadVarUInt(), reader.ReadVector3(), reader.ReadFloat());
		}
	}

	protected void UserCode_TargetOnAllDartsThrown__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		T_Equipments component = GetComponent<T_Equipments>();
		if (component != null)
		{
			component.TryUnequip();
		}
	}

	protected static void InvokeUserCode_TargetOnAllDartsThrown__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC TargetOnAllDartsThrown called on server.");
		}
		else
		{
			((T_DartManager)obj).UserCode_TargetOnAllDartsThrown__NetworkConnectionToClient(null);
		}
	}

	static T_DartManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_DartManager), "System.Void T_DartManager::CmdGiveDarts(System.UInt32,System.Int32)", InvokeUserCode_CmdGiveDarts__UInt32__Int32, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(T_DartManager), "System.Void T_DartManager::CmdSpawnDart(UnityEngine.Vector3,UnityEngine.Vector3,System.Single)", InvokeUserCode_CmdSpawnDart__Vector3__Vector3__Single, requiresAuthority: true);
		RemoteProcedureCalls.RegisterCommand(typeof(T_DartManager), "System.Void T_DartManager::CmdCancelDartGame()", InvokeUserCode_CmdCancelDartGame, requiresAuthority: true);
		RemoteProcedureCalls.RegisterRpc(typeof(T_DartManager), "System.Void T_DartManager::TargetDartCreated(Mirror.NetworkConnectionToClient,System.UInt32,UnityEngine.Vector3,System.Single)", InvokeUserCode_TargetDartCreated__NetworkConnectionToClient__UInt32__Vector3__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(T_DartManager), "System.Void T_DartManager::TargetOnAllDartsThrown(Mirror.NetworkConnectionToClient)", InvokeUserCode_TargetOnAllDartsThrown__NetworkConnectionToClient);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(remainingDarts);
			writer.WriteBool(isInDartGame);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(remainingDarts);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(isInDartGame);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref remainingDarts, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref isInDartGame, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref remainingDarts, null, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isInDartGame, null, reader.ReadBool());
		}
	}
}
