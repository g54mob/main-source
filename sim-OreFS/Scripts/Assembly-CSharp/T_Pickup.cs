using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;

public class T_Pickup : NetworkBehaviour
{
	[Header("State")]
	[SyncVar(hook = "OnHasOwnerChanged")]
	public bool hasOwner;

	[SyncVar]
	public uint ownerNetId;

	public ItemType itemType;

	public UnityEvent onPickup;

	[Header("References")]
	public Collider col;

	private Rigidbody rb;

	private NetworkTransformReliable networkTransform;

	private bool isPickupAnimating;

	private Coroutine pickupAnimCoroutine;

	[HideInInspector]
	public bool smoothPickup;

	[Header("Pickup Animation")]
	[Tooltip("Pickup animasyon süresi (saniye)")]
	[SerializeField]
	private float pickupAnimDuration = 0.25f;

	[Tooltip("Pickup animasyon eğrisi")]
	[SerializeField]
	private AnimationCurve pickupAnimCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	private Coroutine clientAtRestCoroutine;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_hasOwner;

	public bool NetworkhasOwner
	{
		get
		{
			return hasOwner;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref hasOwner, 1uL, _Mirror_SyncVarHookDelegate_hasOwner);
		}
	}

	public uint NetworkownerNetId
	{
		get
		{
			return ownerNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref ownerNetId, 2uL, null);
		}
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		networkTransform = GetComponent<NetworkTransformReliable>();
	}

	public void TryRequestPickup()
	{
		TryRequestPickup(animate: true);
	}

	public void TryRequestPickup(bool animate)
	{
		smoothPickup = animate;
		if (NetworkClient.localPlayer != null && GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
			if (pickupItem != null)
			{
				T_Pickup component = pickupItem.GetComponent<T_Pickup>();
				if (component != null && (component.itemType == ItemType.Building || component.itemType == ItemType.Pickup))
				{
					GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_NotPickupAvailable"));
					return;
				}
			}
		}
		if (base.isServer && base.isClient)
		{
			bool success = HandlePickupOnServer(NetworkServer.localConnection);
			RpcPickupResult(NetworkServer.localConnection.connectionId, success);
		}
		else if (base.isClient)
		{
			CmdTryPickup();
		}
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.PlaceMachine, TutorialSubStepType.PickUpBox);
	}

	[Command(requiresAuthority = false)]
	private void CmdTryPickup(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTryPickup__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Pickup::CmdTryPickup(Mirror.NetworkConnectionToClient)", 1988246348, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public bool HandlePickupOnServer(NetworkConnectionToClient sender)
	{
		if (sender == null || sender.identity == null)
		{
			return false;
		}
		if (hasOwner && base.transform.parent != null)
		{
			return false;
		}
		NetworkhasOwner = true;
		NetworkownerNetId = sender.identity.netId;
		if (rb != null)
		{
			rb.isKinematic = true;
		}
		if (col != null)
		{
			col.enabled = false;
		}
		if (networkTransform != null)
		{
			networkTransform.enabled = false;
		}
		if (base.netIdentity.connectionToClient != null)
		{
			base.netIdentity.RemoveClientAuthority();
		}
		base.netIdentity.AssignClientAuthority(sender);
		return true;
	}

	[ClientRpc]
	public void RpcPickupResult(int senderID, bool success)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(senderID);
		writer.WriteBool(success);
		SendRPCInternal("System.Void T_Pickup::RpcPickupResult(System.Int32,System.Boolean)", -1772567582, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnPickupResultReceived(int senderID, bool success)
	{
		Debug.Log($"[T_Pickup] OnPickupResultReceived | senderID={senderID} | success={success} | isServer={base.isServer}");
		if (!success)
		{
			return;
		}
		if (clientAtRestCoroutine != null)
		{
			StopCoroutine(clientAtRestCoroutine);
			clientAtRestCoroutine = null;
		}
		GameObject gameObject = FindPlayerByConnectionId(senderID);
		if (gameObject == null)
		{
			return;
		}
		bool flag = NetworkClient.localPlayer != null && gameObject == NetworkClient.localPlayer.gameObject;
		Debug.Log($"[T_Pickup] OnPickupResultReceived | targetPlayer={gameObject.name} | isLocalPlayer={flag}");
		if (rb != null)
		{
			rb.isKinematic = true;
		}
		if (col != null)
		{
			col.enabled = false;
		}
		if (networkTransform != null)
		{
			networkTransform.enabled = false;
		}
		onPickup.Invoke();
		if (flag)
		{
			if (GameManager.Instance == null || GameManager.Instance.localEquipments == null)
			{
				return;
			}
			GameManager.Instance.localEquipments.TryEquipByItemType(itemType);
			GameManager.Instance.localEquipments.pickupItem = base.gameObject;
			Transform transform = ((GameManager.Instance.localEquipments.pickupRoot != null) ? GameManager.Instance.localEquipments.pickupRoot.transform : null);
			if (!(transform == null))
			{
				if (smoothPickup)
				{
					StartPickupAnimation(transform);
					smoothPickup = false;
				}
				else
				{
					base.transform.SetParent(transform, worldPositionStays: false);
					base.transform.localPosition = Vector3.zero;
					base.transform.localRotation = Quaternion.identity;
				}
				T_Sack component = GetComponent<T_Sack>();
				if (component != null)
				{
					component.OnPickupSuccess();
					GameManager.Instance.UImanager.CloseLastOpenedUITab();
				}
				T_Building component2 = GetComponent<T_Building>();
				if (component2 != null)
				{
					component2.OnBuildingPickupSuccess();
				}
			}
			return;
		}
		T_Equipments component3 = gameObject.GetComponent<T_Equipments>();
		if (!(component3 == null) && !(component3.pickupNetworkRoot == null))
		{
			Transform parent = component3.pickupNetworkRoot.transform;
			base.transform.SetParent(parent, worldPositionStays: false);
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			T_Sack component4 = GetComponent<T_Sack>();
			if (component4 != null)
			{
				component4.OnPickupSuccess();
			}
		}
	}

	private void StartPickupAnimation(Transform anchor)
	{
		_ = base.transform.position;
		_ = base.transform.rotation;
		base.transform.SetParent(anchor, worldPositionStays: true);
		Vector3 localPosition = base.transform.localPosition;
		Quaternion localRotation = base.transform.localRotation;
		if (pickupAnimCoroutine != null)
		{
			StopCoroutine(pickupAnimCoroutine);
		}
		pickupAnimCoroutine = StartCoroutine(PickupAnimationRoutine(localPosition, localRotation));
	}

	private IEnumerator PickupAnimationRoutine(Vector3 fromLocalPos, Quaternion fromLocalRot)
	{
		isPickupAnimating = true;
		float elapsed = 0f;
		while (elapsed < pickupAnimDuration)
		{
			if (this == null || base.gameObject == null)
			{
				yield break;
			}
			elapsed += Time.deltaTime;
			float t = pickupAnimCurve.Evaluate(Mathf.Clamp01(elapsed / pickupAnimDuration));
			base.transform.localPosition = Vector3.Lerp(fromLocalPos, Vector3.zero, t);
			base.transform.localRotation = Quaternion.Slerp(fromLocalRot, Quaternion.identity, t);
			yield return null;
		}
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		isPickupAnimating = false;
		pickupAnimCoroutine = null;
	}

	public GameObject FindPlayerByConnectionId(int connectionId)
	{
		foreach (KeyValuePair<uint, NetworkIdentity> item in NetworkClient.spawned)
		{
			NetworkIdentity value = item.Value;
			if (!(value == null) && value.TryGetComponent<GamePlayer>(out var component) && component.ownerConnectionId == connectionId)
			{
				return value.gameObject;
			}
		}
		return null;
	}

	public void TryRelease(Vector3 direction, float power)
	{
		Debug.Log($"[T_Pickup] TryRelease called | ownerNetId={ownerNetId} | dir={direction} | power={power} | isServer={base.isServer}");
		if (pickupAnimCoroutine != null)
		{
			StopCoroutine(pickupAnimCoroutine);
			pickupAnimCoroutine = null;
			isPickupAnimating = false;
		}
		LocalUnparent();
		if (col != null)
		{
			col.enabled = true;
		}
		if (rb != null)
		{
			rb.isKinematic = false;
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.AddForce(direction.normalized * power, ForceMode.Impulse);
			Debug.Log($"[T_Pickup] Force applied | vel={rb.linearVelocity}");
		}
		if (clientAtRestCoroutine != null)
		{
			StopCoroutine(clientAtRestCoroutine);
		}
		clientAtRestCoroutine = StartCoroutine(ClientMonitorUntilAtRest());
		if (base.isServer)
		{
			Debug.Log("[T_Pickup] Host path → HandleReleaseOnServer directly");
			HandleReleaseOnServer();
		}
		else
		{
			CmdTryRelease();
		}
	}

	private void LocalUnparent()
	{
		Debug.Log(string.Format("[T_Pickup] LocalUnparent | hasParent={0} | parent={1}", base.transform.parent != null, (base.transform.parent != null) ? base.transform.parent.name : "null"));
		if (base.transform.parent != null)
		{
			SafeUnparent();
			Physics.SyncTransforms();
			Debug.Log($"[T_Pickup] LocalUnparent done | pos={base.transform.position}");
		}
	}

	private void SafeUnparent()
	{
		Vector3 position = base.transform.position;
		Quaternion rotation = base.transform.rotation;
		base.transform.SetParent(null, worldPositionStays: false);
		base.transform.position = position;
		base.transform.rotation = rotation;
	}

	[Command(requiresAuthority = false)]
	private void CmdTryRelease(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTryRelease__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Pickup::CmdTryRelease(Mirror.NetworkConnectionToClient)", -1502054715, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	private bool HandleReleaseOnServer()
	{
		if (!hasOwner)
		{
			return false;
		}
		if (base.transform.parent != null)
		{
			SafeUnparent();
		}
		if (col != null)
		{
			col.enabled = true;
		}
		if (networkTransform != null)
		{
			networkTransform.enabled = true;
			networkTransform.ResetState();
		}
		if (rb != null && !base.isClient)
		{
			rb.isKinematic = true;
		}
		RpcOnReleased(ownerNetId);
		return true;
	}

	private IEnumerator ClientMonitorUntilAtRest()
	{
		uint myOwnerNetId = ownerNetId;
		yield return new WaitForSeconds(0.5f);
		Vector3 lastPos = base.transform.position;
		int stableCount = 0;
		while (stableCount < 3)
		{
			if (ownerNetId != myOwnerNetId || !hasOwner)
			{
				clientAtRestCoroutine = null;
				yield break;
			}
			bool flag = ((!(rb != null)) ? (Vector3.Distance(base.transform.position, lastPos) < 0.01f) : (rb.IsSleeping() || rb.linearVelocity.magnitude <= 0.1f));
			stableCount = (flag ? (stableCount + 1) : 0);
			lastPos = base.transform.position;
			yield return new WaitForSeconds(0.2f);
		}
		if (ownerNetId != myOwnerNetId || !hasOwner)
		{
			clientAtRestCoroutine = null;
			yield break;
		}
		Debug.Log(string.Format("[T_Pickup] Item at rest | pos={0} | vel={1}", base.transform.position, (rb != null) ? rb.linearVelocity.ToString() : "null"));
		if (rb != null)
		{
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.isKinematic = true;
		}
		if (base.isServer)
		{
			if (NetworkServer.localConnection != null && NetworkServer.localConnection.identity != null && NetworkServer.localConnection.identity.netId == ownerNetId)
			{
				ServerReclaimAuthority();
			}
		}
		else
		{
			CmdNotifyAtRest();
		}
		clientAtRestCoroutine = null;
	}

	[Command(requiresAuthority = false)]
	private void CmdNotifyAtRest(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdNotifyAtRest__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Pickup::CmdNotifyAtRest(Mirror.NetworkConnectionToClient)", 788058465, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerReclaimAuthority()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_Pickup::ServerReclaimAuthority()' called when server was not active");
			return;
		}
		Debug.Log("[T_Pickup] ServerReclaimAuthority — reclaiming authority to server");
		NetworkhasOwner = false;
		NetworkownerNetId = 0u;
		if (base.netIdentity.connectionToClient != null)
		{
			base.netIdentity.RemoveClientAuthority();
		}
		if (rb != null)
		{
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.isKinematic = false;
		}
	}

	[ClientRpc]
	private void RpcOnReleased(uint throwerNetId)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(throwerNetId);
		SendRPCInternal("System.Void T_Pickup::RpcOnReleased(System.UInt32)", -37213987, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnHasOwnerChanged(bool oldValue, bool newValue)
	{
		Debug.Log($"[T_Pickup] OnHasOwnerChanged | old={oldValue} | new={newValue} | hasParent={base.transform.parent != null} | isServer={base.isServer}");
		if (col != null)
		{
			col.enabled = !newValue;
		}
		if (rb != null)
		{
			if (newValue)
			{
				rb.isKinematic = true;
			}
			else
			{
				rb.isKinematic = !base.isServer;
			}
		}
		if (!newValue && base.transform.parent != null)
		{
			SafeUnparent();
		}
	}

	public override void OnStopServer()
	{
		if (hasOwner)
		{
			NetworkhasOwner = false;
			NetworkownerNetId = 0u;
			if (networkTransform != null)
			{
				networkTransform.enabled = true;
				networkTransform.ResetState();
			}
			Rigidbody component = GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = false;
			}
		}
	}

	public T_Pickup()
	{
		_Mirror_SyncVarHookDelegate_hasOwner = OnHasOwnerChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdTryPickup__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && !(sender.identity == null))
		{
			bool success = HandlePickupOnServer(sender);
			RpcPickupResult(sender.identity.connectionToClient.connectionId, success);
		}
	}

	protected static void InvokeUserCode_CmdTryPickup__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTryPickup called on client.");
		}
		else
		{
			((T_Pickup)obj).UserCode_CmdTryPickup__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcPickupResult__Int32__Boolean(int senderID, bool success)
	{
		OnPickupResultReceived(senderID, success);
	}

	protected static void InvokeUserCode_RpcPickupResult__Int32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPickupResult called on server.");
		}
		else
		{
			((T_Pickup)obj).UserCode_RpcPickupResult__Int32__Boolean(reader.ReadVarInt(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdTryRelease__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		HandleReleaseOnServer();
	}

	protected static void InvokeUserCode_CmdTryRelease__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTryRelease called on client.");
		}
		else
		{
			((T_Pickup)obj).UserCode_CmdTryRelease__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdNotifyAtRest__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		if (sender != null && sender.identity != null && sender.identity.netId == ownerNetId)
		{
			ServerReclaimAuthority();
		}
	}

	protected static void InvokeUserCode_CmdNotifyAtRest__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdNotifyAtRest called on client.");
		}
		else
		{
			((T_Pickup)obj).UserCode_CmdNotifyAtRest__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcOnReleased__UInt32(uint throwerNetId)
	{
		bool flag = NetworkClient.localPlayer != null && NetworkClient.localPlayer.netId == throwerNetId;
		Debug.Log($"[T_Pickup] RpcOnReleased | isThrower={flag} | throwerNetId={throwerNetId} | hasParent={base.transform.parent != null} | pos={base.transform.position}");
		if (base.transform.parent != null)
		{
			SafeUnparent();
		}
		if (col != null)
		{
			col.enabled = true;
		}
		if (networkTransform != null)
		{
			networkTransform.enabled = true;
			networkTransform.ResetState();
		}
		if (!flag && rb != null)
		{
			rb.isKinematic = true;
		}
	}

	protected static void InvokeUserCode_RpcOnReleased__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcOnReleased called on server.");
		}
		else
		{
			((T_Pickup)obj).UserCode_RpcOnReleased__UInt32(reader.ReadVarUInt());
		}
	}

	static T_Pickup()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Pickup), "System.Void T_Pickup::CmdTryPickup(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTryPickup__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Pickup), "System.Void T_Pickup::CmdTryRelease(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTryRelease__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Pickup), "System.Void T_Pickup::CmdNotifyAtRest(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdNotifyAtRest__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Pickup), "System.Void T_Pickup::RpcPickupResult(System.Int32,System.Boolean)", InvokeUserCode_RpcPickupResult__Int32__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Pickup), "System.Void T_Pickup::RpcOnReleased(System.UInt32)", InvokeUserCode_RpcOnReleased__UInt32);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteBool(hasOwner);
			writer.WriteVarUInt(ownerNetId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteBool(hasOwner);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarUInt(ownerNetId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref hasOwner, _Mirror_SyncVarHookDelegate_hasOwner, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref ownerNetId, null, reader.ReadVarUInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref hasOwner, _Mirror_SyncVarHookDelegate_hasOwner, reader.ReadBool());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref ownerNetId, null, reader.ReadVarUInt());
		}
	}
}
