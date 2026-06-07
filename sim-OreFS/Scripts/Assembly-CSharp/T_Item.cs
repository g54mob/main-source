using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class T_Item : NetworkBehaviour, IGameSave
{
	[Serializable]
	public class ItemSaveData
	{
		public string itemId;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public float rotW;

		public bool isOnBelt;

		public string beltBuildingId;

		public float beltT;

		public int beltLaneIndex;
	}

	[CompilerGenerated]
	private sealed class _003CCo_AttachToNearestBeltDelayed_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_Item _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CCo_AttachToNearestBeltDelayed_003Ed__37(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			T_Item t_Item = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(0.1f);
				_003C_003E1__state = 2;
				return true;
			case 2:
			{
				_003C_003E1__state = -1;
				if (!t_Item.isActiveAndEnabled)
				{
					return false;
				}
				float tOnSpline;
				int laneIndex;
				T_ConveyorBelt t_ConveyorBelt = T_ConveyorBelt.FindClosestBelt(t_Item.transform.position, t_Item.beltSearchMaxDistance, out tOnSpline, out laneIndex);
				if (t_ConveyorBelt != null)
				{
					t_Item.Server_SetBelt(t_ConveyorBelt, tOnSpline, laneIndex);
				}
				else
				{
					t_Item.currentBelt = null;
					t_Item.NetworkcurrentBeltNetId = 0u;
				}
				return false;
			}
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class _003CGoToTargetPallet_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_Item _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGoToTargetPallet_003Ed__42(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			T_Item t_Item = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(0.1f);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				if (t_Item == null || t_Item.gameObject == null || t_Item.targetPallet == null || t_Item.targetPallet.gameObject == null)
				{
					return false;
				}
				if (t_Item.targetPallet.ServerTryAddItemFromBelt(t_Item))
				{
					t_Item.DebugLog("GoToTargetPallet SUCCESS | itemId=" + t_Item.itemId + " added to pallet");
					t_Item.targetPallet = null;
				}
				else
				{
					t_Item.DebugLog("GoToTargetPallet FAILED | itemId=" + t_Item.itemId + " pallet rejected item");
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Debug")]
	[SerializeField]
	private bool enableDebugLogging;

	[Header("Runtime")]
	[SyncVar(hook = "OnItemIdChanged")]
	public string itemId;

	[SyncVar(hook = "OnActiveChanged")]
	private bool isActive = true;

	[SyncVar]
	private string uniqueId;

	[SerializeField]
	public T_ItemSO so;

	[Header("Refs")]
	[SerializeField]
	private Rigidbody rb;

	[Header("Pickup Around")]
	public float pickupRadius = 1f;

	[Header("Node System")]
	[SyncVar(hook = "OnIsNodeChanged")]
	public bool isNode;

	public readonly SyncList<int> pieceHealthList = new SyncList<int>();

	public readonly SyncList<int> pieceCollectAmounts = new SyncList<int>();

	private List<T_NodePiece> nodePieces = new List<T_NodePiece>();

	[Header("Belt System")]
	[SyncVar]
	public uint currentBeltNetId;

	[HideInInspector]
	public T_ConveyorBelt currentBelt;

	[HideInInspector]
	public float currentT;

	[HideInInspector]
	public int currentBeltLaneIndex;

	[HideInInspector]
	public T_Pallet targetPallet;

	[Header("Belt Auto Attach")]
	[Tooltip("Server'da spawn olduğunda en yakın belti otomatik arar.")]
	public bool checkForBeltOnSpawn;

	[Tooltip("Spawn sonrası belt arama maksimum mesafesi.")]
	public float beltSearchMaxDistance = 3f;

	[SerializeField]
	private bool isMovingOnBelt;

	private float beltMoveStartT;

	private float beltMoveEndT;

	private float beltMoveDuration;

	private double beltMoveStartTime;

	public Transform parentTransform;

	private T_ItemAreaSpawner areaSpawner;

	private GameObject spawnedVisualPrefab;

	public Action<string, string> _Mirror_SyncVarHookDelegate_itemId;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isActive;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isNode;

	public string UniqueId => uniqueId;

	public string SaveID => "item-" + uniqueId;

	public bool IsShared => false;

	public Type SaveType => typeof(ItemSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public string NetworkitemId
	{
		get
		{
			return itemId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref itemId, 1uL, _Mirror_SyncVarHookDelegate_itemId);
		}
	}

	public bool NetworkisActive
	{
		get
		{
			return isActive;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isActive, 2uL, _Mirror_SyncVarHookDelegate_isActive);
		}
	}

	public string NetworkuniqueId
	{
		get
		{
			return uniqueId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref uniqueId, 4uL, null);
		}
	}

	public bool NetworkisNode
	{
		get
		{
			return isNode;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isNode, 8uL, _Mirror_SyncVarHookDelegate_isNode);
		}
	}

	public uint NetworkcurrentBeltNetId
	{
		get
		{
			return currentBeltNetId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentBeltNetId, 16uL, null);
		}
	}

	public static event Action<string> OnNodePieceBroken;

	public void SetUniqueId(string id)
	{
		NetworkuniqueId = id;
	}

	private void OnEnable()
	{
		CheckReferences();
	}

	private void CheckReferences()
	{
		if (!rb)
		{
			rb = GetComponentInChildren<Rigidbody>();
		}
		if (T_ItemAreaSpawner.instance != null && areaSpawner == null)
		{
			areaSpawner = T_ItemAreaSpawner.instance;
		}
	}

	public override void OnStartServer()
	{
		if (so != null && string.IsNullOrEmpty(itemId))
		{
			NetworkitemId = so.GetItemID();
		}
		if (so == null && !string.IsNullOrEmpty(itemId))
		{
			so = Resolve(itemId);
		}
		if (string.IsNullOrEmpty(uniqueId))
		{
			NetworkuniqueId = Guid.NewGuid().ToString();
		}
		ApplySO();
		ApplyActive();
		if (so != null && !isNode)
		{
			DynamicObjectSpawner.Instance?.RegisterItem(this);
			SaveLoadManager.Subscribe(this, 65);
		}
		if (checkForBeltOnSpawn)
		{
			StartCoroutine(Co_AttachToNearestBeltDelayed());
		}
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		if (so != null && !so.isNode)
		{
			DynamicObjectSpawner.Instance?.UnregisterItem(uniqueId);
			SaveLoadManager.Unsubscribe(this);
		}
	}

	[IteratorStateMachine(typeof(_003CCo_AttachToNearestBeltDelayed_003Ed__37))]
	[Server]
	private IEnumerator Co_AttachToNearestBeltDelayed()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_Item::Co_AttachToNearestBeltDelayed()' called when server was not active");
			return null;
		}
		return new _003CCo_AttachToNearestBeltDelayed_003Ed__37(0)
		{
			_003C_003E4__this = this
		};
	}

	public override void OnStartClient()
	{
		if (so == null && !string.IsNullOrEmpty(itemId))
		{
			so = Resolve(itemId);
		}
		SyncList<int> syncList = pieceHealthList;
		syncList.Callback = (Action<SyncList<int>.Operation, int, int, int>)Delegate.Combine(syncList.Callback, new Action<SyncList<int>.Operation, int, int, int>(OnPieceHealthChanged));
		ApplySO();
		ApplyActive();
	}

	private void OnPieceHealthChanged(SyncList<int>.Operation op, int index, int oldValue, int newValue)
	{
		if (index >= 0 && index < nodePieces.Count && nodePieces[index] != null)
		{
			nodePieces[index].OnHealthChanged(newValue, (so != null) ? so.nodeHealth : 3);
			if (newValue <= 0)
			{
				nodePieces[index].Break();
			}
		}
	}

	[Server]
	public void Server_SetBelt(T_ConveyorBelt belt, float startT = 0f, int laneIndex = 0)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::Server_SetBelt(T_ConveyorBelt,System.Single,System.Int32)' called when server was not active");
		}
		else if (!(belt == null))
		{
			DebugLog($"Server_SetBelt | itemId={itemId} beltNetId={belt.netIdentity.netId} startT={startT} lane={laneIndex}");
			currentBelt = belt;
			NetworkcurrentBeltNetId = belt.netIdentity.netId;
			currentT = startT;
			currentBeltLaneIndex = laneIndex;
			belt.Server_RegisterItem(this, startT, laneIndex);
		}
	}

	[Server]
	public void Server_RemoveFromBelt()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::Server_RemoveFromBelt()' called when server was not active");
			return;
		}
		DebugLog($"Server_RemoveFromBelt | itemId={itemId} hadPallet={targetPallet != null}");
		currentBelt = null;
		NetworkcurrentBeltNetId = 0u;
		isMovingOnBelt = false;
		Rpc_EnableRigidbody();
		if (targetPallet != null && targetPallet.gameObject != null)
		{
			StartCoroutine(GoToTargetPallet());
		}
	}

	[IteratorStateMachine(typeof(_003CGoToTargetPallet_003Ed__42))]
	[Server]
	private IEnumerator GoToTargetPallet()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_Item::GoToTargetPallet()' called when server was not active");
			return null;
		}
		return new _003CGoToTargetPallet_003Ed__42(0)
		{
			_003C_003E4__this = this
		};
	}

	[Server]
	public void SetTargetPallet(T_Pallet pallet)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::SetTargetPallet(T_Pallet)' called when server was not active");
			return;
		}
		DebugLog($"SetTargetPallet | itemId={itemId} pallet={pallet?.name} onBelt={currentBelt != null}");
		targetPallet = pallet;
		if (currentBelt == null && currentBeltNetId == 0)
		{
			StartCoroutine(GoToTargetPallet());
		}
	}

	[Client]
	public void Client_StartConveyorMove(T_ConveyorBelt belt, int laneIndex, float startT, float endT, double startTime, float duration)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogWarning("[Client] function 'System.Void T_Item::Client_StartConveyorMove(T_ConveyorBelt,System.Int32,System.Single,System.Single,System.Double,System.Single)' called when client was not active");
			return;
		}
		currentBelt = belt;
		currentBeltLaneIndex = laneIndex;
		beltMoveStartT = startT;
		beltMoveEndT = endT;
		beltMoveStartTime = startTime;
		beltMoveDuration = Mathf.Max(duration, 0.0001f);
		isMovingOnBelt = true;
	}

	[ClientRpc]
	public void Rpc_StartConveyorMove(uint beltNetId, int laneIndex, float startT, float endT, double startTime, float duration)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(beltNetId);
		writer.WriteVarInt(laneIndex);
		writer.WriteFloat(startT);
		writer.WriteFloat(endT);
		writer.WriteDouble(startTime);
		writer.WriteFloat(duration);
		SendRPCInternal("System.Void T_Item::Rpc_StartConveyorMove(System.UInt32,System.Int32,System.Single,System.Single,System.Double,System.Single)", 941135359, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void Rpc_EnableRigidbody()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Item::Rpc_EnableRigidbody()", -187406709, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Update()
	{
		if (isMovingOnBelt && currentBelt != null)
		{
			BeltSystem_UpdateMovement();
		}
	}

	private void BeltSystem_UpdateMovement()
	{
		float num = Mathf.Clamp01((float)(NetworkTime.time - beltMoveStartTime) / beltMoveDuration);
		float t = (currentT = Mathf.Lerp(beltMoveStartT, beltMoveEndT, num));
		if (currentBelt != null && currentBelt.EvaluateOnSpline(currentBeltLaneIndex, t, out var pos, out var tan))
		{
			base.transform.position = pos;
			if (!math.all(tan == float3.zero))
			{
				base.transform.rotation = Quaternion.LookRotation(tan);
			}
		}
		if (num >= 1f)
		{
			isMovingOnBelt = false;
		}
	}

	[Server]
	public void ServerSnap(Vector3 pos, Quaternion rot, bool zeroVelocity = true, int ruleID = -1)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::ServerSnap(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean,System.Int32)' called when server was not active");
			return;
		}
		base.transform.SetPositionAndRotation(pos, rot);
		if ((bool)rb)
		{
			rb.position = pos;
			rb.rotation = rot;
		}
		RpcSnap(pos, rot, zeroVelocity, ruleID);
	}

	[ClientRpc(channel = 0)]
	private void RpcSnap(Vector3 pos, Quaternion rot, bool zeroVelocity, int RuleID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteQuaternion(rot);
		writer.WriteBool(zeroVelocity);
		writer.WriteVarInt(RuleID);
		SendRPCInternal("System.Void T_Item::RpcSnap(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean,System.Int32)", -1779488272, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerPreAssignSO(T_ItemSO asset)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::ServerPreAssignSO(T_ItemSO)' called when server was not active");
		}
		else if ((bool)asset)
		{
			so = asset;
			NetworkitemId = so.GetItemID();
			NetworkisActive = true;
			ApplySO();
			ApplyActive();
		}
	}

	[Server]
	public void ServerAssignByItemId(string id)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::ServerAssignByItemId(System.String)' called when server was not active");
		}
		else if (!string.IsNullOrEmpty(id))
		{
			NetworkitemId = id;
			so = Resolve(id);
			NetworkisActive = true;
			ApplySO();
			ApplyActive();
		}
	}

	public void TryPickup()
	{
		if (isActive && (bool)so && !isNode)
		{
			DebugLog("TryPickup called | itemId=" + itemId + " uniqueId=" + uniqueId);
			GameManager.Instance.localBag.AddItem(so);
			if (base.isServer)
			{
				ServerHandlePickup(null);
			}
			else
			{
				CmdRequestPickup();
			}
		}
	}

	public void PickupAround()
	{
		if (!isActive || !so || isNode)
		{
			return;
		}
		TryPickup();
		Collider[] array = Physics.OverlapSphere(base.transform.position, pickupRadius);
		foreach (Collider collider in array)
		{
			T_Item t_Item = collider.GetComponent<T_Item>();
			if (t_Item == null)
			{
				t_Item = collider.GetComponentInParent<T_Item>();
			}
			if (!(t_Item == null) && !(t_Item == this) && t_Item.isActive && !t_Item.isNode && !(t_Item.itemId != itemId))
			{
				t_Item.TryPickup();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdRequestPickup(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestPickup__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Item::CmdRequestPickup(Mirror.NetworkConnectionToClient)", -1946421413, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerHandlePickup(NetworkConnectionToClient sender)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::ServerHandlePickup(Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else if (isActive && (bool)so && !isNode)
		{
			DebugLog($"ServerHandlePickup | itemId={itemId} uniqueId={uniqueId} sender={sender?.connectionId}");
			RpcPlayPickupVFX(base.transform.position);
			DeactivateAndDespawn();
		}
	}

	[Server]
	private void DeactivateAndDespawn()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::DeactivateAndDespawn()' called when server was not active");
			return;
		}
		DebugLog("DeactivateAndDespawn | itemId=" + itemId + " uniqueId=" + uniqueId);
		NetworkServer.Destroy(base.gameObject);
	}

	[Command(requiresAuthority = false)]
	public void CmdDamagePiece(int pieceIndex, Vector3 piecePos, int damage, int bagAvailableCapacity, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdDamagePiece__Int32__Vector3__Int32__Int32__NetworkConnectionToClient(pieceIndex, piecePos, damage, bagAvailableCapacity, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(pieceIndex);
		writer.WriteVector3(piecePos);
		writer.WriteVarInt(damage);
		writer.WriteVarInt(bagAvailableCapacity);
		SendCommandInternal("System.Void T_Item::CmdDamagePiece(System.Int32,UnityEngine.Vector3,System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", 141759505, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void Server_DamagePiece(int pieceIndex, Vector3 piecePos, int damage, int bagAvailableCapacity, NetworkConnectionToClient attacker)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::Server_DamagePiece(System.Int32,UnityEngine.Vector3,System.Int32,System.Int32,Mirror.NetworkConnectionToClient)' called when server was not active");
		}
		else
		{
			if (!isNode || !so || pieceIndex < 0 || pieceIndex >= pieceHealthList.Count || pieceHealthList[pieceIndex] <= 0)
			{
				return;
			}
			if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && !TutorialManager.Instance.CanDamageNodeDuringTutorial(itemId))
			{
				if (attacker != null)
				{
					TargetRpc_TutorialItemBlocked(attacker);
				}
				else
				{
					ShowTutorialItemBlockedNotificationLocal();
				}
				return;
			}
			bool flag = attacker == null;
			uint excludeConnId = ((attacker != null && attacker.identity != null) ? attacker.identity.netId : 0u);
			int num = pieceHealthList[pieceIndex];
			int num2 = Mathf.Max(0, num - damage);
			if (num2 <= 0)
			{
				int num3 = ((pieceIndex >= pieceCollectAmounts.Count) ? 1 : pieceCollectAmounts[pieceIndex]);
				if (!((!flag) ? (bagAvailableCapacity >= num3) : ((!(GameManager.Instance != null) || !(GameManager.Instance.localBag != null)) ? (bagAvailableCapacity >= num3) : GameManager.Instance.localBag.HasSpaceFor(num3))))
				{
					if (attacker != null)
					{
						TargetRpc_BagFullNotification(attacker);
					}
					else
					{
						ShowBagFullNotificationLocal();
					}
					return;
				}
			}
			Rpc_PlayHitVFXExcept(piecePos, excludeConnId, flag);
			pieceHealthList[pieceIndex] = num2;
			DebugLog($"Server_DamagePiece | itemId={itemId} piece={pieceIndex} health={num}->{num2} damage={damage}");
			if (pieceHealthList[pieceIndex] <= 0)
			{
				DebugLog($"Server_DamagePiece | piece={pieceIndex} DESTROYED | itemId={itemId}");
				Rpc_PlayMiningVFXExcept(piecePos, excludeConnId, flag);
				if (attacker != null)
				{
					TargetRpc_PlayMiningVFX(attacker, piecePos);
				}
				else
				{
					PlayMiningVFXAtPosition(piecePos);
				}
				int amount = ((pieceIndex >= pieceCollectAmounts.Count) ? 1 : pieceCollectAmounts[pieceIndex]);
				if (attacker != null)
				{
					TargetRpc_GiveOre(attacker, amount);
				}
				else
				{
					Server_GiveOreToHost(amount);
				}
				T_Item.OnNodePieceBroken?.Invoke(itemId);
				if (AllPiecesBroken())
				{
					DebugLog("AllPiecesBroken | itemId=" + itemId + " node fully destroyed, despawning");
					NetworkServer.Destroy(base.gameObject);
				}
			}
		}
	}

	[Server]
	private void Server_GiveOreToHost(int amount)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::Server_GiveOreToHost(System.Int32)' called when server was not active");
		}
		else if (!(so == null))
		{
			if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && TutorialManager.Instance.CurrentSubStep == TutorialSubStepType.MineOreTarget && amount < 2)
			{
				amount = 2;
			}
			for (int i = 0; i < amount; i++)
			{
				GameManager.Instance.localBag.AddItem(so);
			}
		}
	}

	private bool AllPiecesBroken()
	{
		foreach (int pieceHealth in pieceHealthList)
		{
			if (pieceHealth > 0)
			{
				return false;
			}
		}
		return true;
	}

	[TargetRpc]
	private void TargetRpc_GiveOre(NetworkConnection conn, int amount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(amount);
		SendTargetRPCInternal(conn, "System.Void T_Item::TargetRpc_GiveOre(Mirror.NetworkConnection,System.Int32)", -692673841, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void Rpc_PlayHitVFXExcept(Vector3 pos, uint excludeConnId, bool isHostAttacker)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteVarUInt(excludeConnId);
		writer.WriteBool(isHostAttacker);
		SendRPCInternal("System.Void T_Item::Rpc_PlayHitVFXExcept(UnityEngine.Vector3,System.UInt32,System.Boolean)", -1300751523, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void Rpc_PlayMiningVFXExcept(Vector3 pos, uint excludeConnId, bool isHostAttacker)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		writer.WriteVarUInt(excludeConnId);
		writer.WriteBool(isHostAttacker);
		SendRPCInternal("System.Void T_Item::Rpc_PlayMiningVFXExcept(UnityEngine.Vector3,System.UInt32,System.Boolean)", -1349449578, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpc_PlayMiningVFX(NetworkConnection conn, Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendTargetRPCInternal(conn, "System.Void T_Item::TargetRpc_PlayMiningVFX(Mirror.NetworkConnection,UnityEngine.Vector3)", 710049302, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpc_TutorialItemBlocked(NetworkConnection conn)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(conn, "System.Void T_Item::TargetRpc_TutorialItemBlocked(Mirror.NetworkConnection)", -1111267492, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void ShowTutorialItemBlockedNotificationLocal()
	{
		if (GameManager.Instance == null || GameManager.Instance.notificationManager == null)
		{
			return;
		}
		string value = ((TutorialManager.Instance != null) ? TutorialManager.Instance.TutorialLockedItemId : "");
		string text = "";
		if (!string.IsNullOrEmpty(value) && ItemSOManager.Instance != null)
		{
			T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(value);
			if (itemSOById != null)
			{
				text = LocalizationManager.GetTranslation(itemSOById.Name);
			}
		}
		string text2 = LocalizationManager.GetTranslation("Notification_TutorialOnlyLockedItem");
		if (!string.IsNullOrEmpty(text))
		{
			text2 = text2.Replace("{0}", text);
		}
		GameManager.Instance.notificationManager.ShowNotification(text2);
	}

	[TargetRpc]
	private void TargetRpc_BagFullNotification(NetworkConnection conn)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(conn, "System.Void T_Item::TargetRpc_BagFullNotification(Mirror.NetworkConnection)", 1403240611, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	private void ShowBagFullNotificationLocal()
	{
		if (!(GameManager.Instance == null) && !(GameManager.Instance.notificationManager == null))
		{
			GameManager.Instance.notificationManager.ShowNotification(LocalizationManager.GetTranslation("Notification_BagFullKey"));
		}
	}

	private void PlayHitVFXAtPosition(Vector3 pos)
	{
		if (!(GameManager.Instance == null) && !(GameManager.Instance.poolingManager == null) && !(so == null))
		{
			LayerVFX nodeHitVFX = so.nodeHitVFX;
			GameObject pooledObjectByType = GameManager.Instance.poolingManager.GetPooledObjectByType(nodeHitVFX);
			if (pooledObjectByType != null)
			{
				pooledObjectByType.transform.position = pos;
				pooledObjectByType.transform.rotation = Quaternion.identity;
				pooledObjectByType.SetActive(value: true);
			}
			LayerSFX nodeHitSFX = so.nodeHitSFX;
			if (SoundManager.Instance != null)
			{
				SoundManager.Instance.PlaySFXAtPosition(nodeHitSFX, pos);
			}
		}
	}

	private void PlayMiningVFXAtPosition(Vector3 pos)
	{
		if (!(so == null) && !(so.MiningVFX == null))
		{
			UnityEngine.Object.Destroy(UnityEngine.Object.Instantiate(so.MiningVFX, pos, Quaternion.identity), 3f);
		}
	}

	public T_NodePiece GetPieceFromRaycastHit(RaycastHit hit)
	{
		if (hit.collider == null)
		{
			return null;
		}
		T_NodePiece t_NodePiece = hit.collider.GetComponent<T_NodePiece>();
		if (t_NodePiece == null)
		{
			t_NodePiece = hit.collider.GetComponentInParent<T_NodePiece>();
		}
		return t_NodePiece;
	}

	public int GetPieceIndexFromHit(RaycastHit hit)
	{
		T_NodePiece pieceFromRaycastHit = GetPieceFromRaycastHit(hit);
		if (!(pieceFromRaycastHit != null))
		{
			return -1;
		}
		return pieceFromRaycastHit.pieceIndex;
	}

	public int GetPieceHealth(int pieceIndex)
	{
		if (pieceIndex < 0 || pieceIndex >= pieceHealthList.Count)
		{
			return 0;
		}
		return pieceHealthList[pieceIndex];
	}

	public int GetPieceCount()
	{
		return pieceHealthList.Count;
	}

	public List<int> GetAllPieceHealths()
	{
		return new List<int>(pieceHealthList);
	}

	[Server]
	public void PreFillPieceHealths(List<int> healths)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::PreFillPieceHealths(System.Collections.Generic.List`1<System.Int32>)' called when server was not active");
		}
		else
		{
			if (healths == null || healths.Count == 0)
			{
				return;
			}
			pieceHealthList.Clear();
			foreach (int health in healths)
			{
				pieceHealthList.Add(health);
			}
		}
	}

	[Server]
	public void RestorePieceHealths(List<int> healths)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Item::RestorePieceHealths(System.Collections.Generic.List`1<System.Int32>)' called when server was not active");
		}
		else
		{
			if (healths == null || healths.Count == 0)
			{
				return;
			}
			pieceHealthList.Clear();
			foreach (int health in healths)
			{
				pieceHealthList.Add(health);
			}
			UpdateBrokenPiecesVisual();
		}
	}

	private void UpdateBrokenPiecesVisual()
	{
		if (spawnedVisualPrefab == null)
		{
			return;
		}
		T_NodePiece[] componentsInChildren = spawnedVisualPrefab.GetComponentsInChildren<T_NodePiece>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length && i < pieceHealthList.Count; i++)
		{
			if (pieceHealthList[i] <= 0)
			{
				componentsInChildren[i].gameObject.SetActive(value: false);
			}
		}
	}

	private void OnItemIdChanged(string _, string newId)
	{
		DebugLog("OnItemIdChanged | newId=" + newId);
		so = Resolve(newId);
		ApplySO();
	}

	private void OnActiveChanged(bool _, bool __)
	{
		ApplyActive();
	}

	private void OnIsNodeChanged(bool _, bool newValue)
	{
		DebugLog($"OnIsNodeChanged | isNode={newValue} itemId={itemId}");
		ApplySO();
		base.gameObject.layer = 18;
	}

	private void ApplySO()
	{
		if (!so)
		{
			return;
		}
		if (spawnedVisualPrefab != null)
		{
			UnityEngine.Object.Destroy(spawnedVisualPrefab);
			spawnedVisualPrefab = null;
		}
		GameObject gameObject = ((isNode && so.NodeVisualPrefab != null) ? so.NodeVisualPrefab : so.VisualPrefab);
		if (gameObject != null)
		{
			spawnedVisualPrefab = UnityEngine.Object.Instantiate(gameObject, base.transform);
			spawnedVisualPrefab.transform.localPosition = Vector3.zero;
			spawnedVisualPrefab.transform.localRotation = Quaternion.identity;
			spawnedVisualPrefab.transform.localScale = Vector3.one;
			if (isNode)
			{
				InitializeNodePieces();
				return;
			}
			RegisterRenderersToInteractable();
			base.transform.SetParent(GameManager.Instance.factorySpawnParent, worldPositionStays: true);
		}
	}

	private void InitializeNodePieces()
	{
		nodePieces.Clear();
		if (spawnedVisualPrefab == null)
		{
			return;
		}
		Collider[] componentsInChildren = spawnedVisualPrefab.GetComponentsInChildren<Collider>();
		Array.Sort(componentsInChildren, (Collider a, Collider b) => string.Compare(a.gameObject.name, b.gameObject.name, StringComparison.Ordinal));
		int num = componentsInChildren.Length;
		if (num == 0)
		{
			return;
		}
		if (base.isServer)
		{
			if (pieceHealthList.Count == 0)
			{
				pieceHealthList.Clear();
				pieceCollectAmounts.Clear();
				for (int num2 = 0; num2 < num; num2++)
				{
					pieceHealthList.Add(so.nodeHealth);
					int item = UnityEngine.Random.Range(so.collectAmountMin, so.collectAmountMax + 1);
					pieceCollectAmounts.Add(item);
				}
			}
			else if (pieceCollectAmounts.Count == 0)
			{
				pieceCollectAmounts.Clear();
				for (int num3 = 0; num3 < pieceHealthList.Count; num3++)
				{
					int item2 = UnityEngine.Random.Range(so.collectAmountMin, so.collectAmountMax + 1);
					pieceCollectAmounts.Add(item2);
				}
			}
		}
		for (int num4 = 0; num4 < componentsInChildren.Length; num4++)
		{
			T_NodePiece t_NodePiece = componentsInChildren[num4].gameObject.GetComponent<T_NodePiece>();
			if (t_NodePiece == null)
			{
				t_NodePiece = componentsInChildren[num4].gameObject.AddComponent<T_NodePiece>();
			}
			int collectAmt = ((num4 < pieceCollectAmounts.Count) ? pieceCollectAmounts[num4] : 0);
			t_NodePiece.Initialize(this, num4, collectAmt);
			nodePieces.Add(t_NodePiece);
			if (num4 < pieceHealthList.Count && pieceHealthList[num4] <= 0)
			{
				t_NodePiece.Break();
			}
		}
		if (pieceHealthList.Count <= 0 || !(so != null))
		{
			return;
		}
		for (int num5 = 0; num5 < nodePieces.Count && num5 < pieceHealthList.Count; num5++)
		{
			int num6 = pieceHealthList[num5];
			if (num6 > 0 && num6 < so.nodeHealth)
			{
				nodePieces[num5].OnHealthChanged(num6, so.nodeHealth);
			}
		}
	}

	private void ApplyActive()
	{
		if (spawnedVisualPrefab != null)
		{
			spawnedVisualPrefab.SetActive(isActive);
		}
	}

	private void RegisterRenderersToInteractable()
	{
		if (spawnedVisualPrefab == null)
		{
			return;
		}
		Interactable component = GetComponent<Interactable>();
		if (component == null)
		{
			return;
		}
		component.renderers.Clear();
		component.skinnedRenderers.Clear();
		MeshRenderer[] componentsInChildren = spawnedVisualPrefab.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		foreach (MeshRenderer meshRenderer in componentsInChildren)
		{
			if (meshRenderer != null)
			{
				component.renderers.Add(meshRenderer);
			}
		}
		SkinnedMeshRenderer[] componentsInChildren2 = spawnedVisualPrefab.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			if (skinnedMeshRenderer != null)
			{
				component.skinnedRenderers.Add(skinnedMeshRenderer);
			}
		}
	}

	[ClientRpc]
	private void RpcPlayPickupVFX(Vector3 pos)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(pos);
		SendRPCInternal("System.Void T_Item::RpcPlayPickupVFX(UnityEngine.Vector3)", 86702779, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void DebugLog(string message)
	{
		if (enableDebugLogging)
		{
			UnityEngine.Debug.Log("[T_Item] " + message);
		}
	}

	private bool TrySetParentByRuleID(List<T_ItemSpawnRule> rules, int ruleID)
	{
		foreach (T_ItemSpawnRule rule in rules)
		{
			if (rule.spawnRuleID == ruleID)
			{
				base.transform.SetParent(rule.transform);
				return true;
			}
		}
		return false;
	}

	private T_ItemSO Resolve(string id)
	{
		return ItemSOManager.Instance.GetItemSOById(id);
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		if (so != null && so.isNode)
		{
			return null;
		}
		DebugLog($"GetSaveData START | itemId={itemId} uniqueId={uniqueId} onBelt={currentBeltNetId != 0}");
		Vector3 vector = ((rb != null) ? rb.position : base.transform.position);
		Quaternion quaternion2 = ((rb != null) ? rb.rotation : base.transform.rotation);
		ItemSaveData itemSaveData = new ItemSaveData
		{
			itemId = itemId,
			posX = vector.x,
			posY = vector.y,
			posZ = vector.z,
			rotX = quaternion2.x,
			rotY = quaternion2.y,
			rotZ = quaternion2.z,
			rotW = quaternion2.w,
			isOnBelt = (currentBeltNetId != 0 && currentBelt != null)
		};
		if (itemSaveData.isOnBelt && currentBelt != null)
		{
			BuildingObject component = currentBelt.GetComponent<BuildingObject>();
			if (component != null)
			{
				itemSaveData.beltBuildingId = component.UniqueBuildingId;
				itemSaveData.beltT = currentT;
				itemSaveData.beltLaneIndex = currentBeltLaneIndex;
			}
		}
		DebugLog($"GetSaveData DONE | itemId={itemId} isOnBelt={itemSaveData.isOnBelt}");
		return itemSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		DebugLog("OnLoad START | uniqueId=" + uniqueId + " valueType=" + value?.GetType().Name);
		if (!(value is ItemSaveData itemSaveData))
		{
			UnityEngine.Debug.LogWarning("[T_Item] OnLoad - Invalid data type for item: " + uniqueId);
			return Task.CompletedTask;
		}
		if (!string.IsNullOrEmpty(itemSaveData.itemId))
		{
			NetworkitemId = itemSaveData.itemId;
			so = Resolve(itemId);
		}
		if (so != null && so.isNode)
		{
			return Task.CompletedTask;
		}
		ApplySO();
		Vector3 position = new Vector3(itemSaveData.posX, itemSaveData.posY, itemSaveData.posZ);
		Quaternion rotation = new Quaternion(itemSaveData.rotX, itemSaveData.rotY, itemSaveData.rotZ, itemSaveData.rotW);
		if (itemSaveData.isOnBelt && !string.IsNullOrEmpty(itemSaveData.beltBuildingId))
		{
			DebugLog($"OnLoad DONE | itemId={itemId} restoring on belt={itemSaveData.beltBuildingId} t={itemSaveData.beltT}");
			StartCoroutine(Co_RestoreOnBelt(itemSaveData));
		}
		else
		{
			DebugLog($"OnLoad DONE | itemId={itemId} free position=({position.x:F1},{position.y:F1},{position.z:F1})");
			if (rb != null)
			{
				SaveLoadGameManager.RegisterKinematicForLoad(rb);
				rb.position = position;
				rb.rotation = rotation;
			}
			base.transform.SetPositionAndRotation(position, rotation);
		}
		return Task.CompletedTask;
	}

	private IEnumerator Co_RestoreOnBelt(ItemSaveData data)
	{
		T_ConveyorBelt targetBelt = null;
		float timeout = 5f;
		float elapsed = 0f;
		while (targetBelt == null && elapsed < timeout)
		{
			foreach (T_ConveyorBelt allBelt in T_ConveyorBelt.AllBelts)
			{
				BuildingObject component = allBelt.GetComponent<BuildingObject>();
				if (component != null && component.UniqueBuildingId == data.beltBuildingId)
				{
					targetBelt = allBelt;
					break;
				}
			}
			elapsed += Time.deltaTime;
			yield return null;
		}
		if (targetBelt != null)
		{
			DebugLog($"Co_RestoreOnBelt | found belt={data.beltBuildingId}, setting kinematic=true, registering at t={data.beltT} lane={data.beltLaneIndex}");
			if (rb != null)
			{
				rb.isKinematic = true;
			}
			targetBelt.Server_RegisterItem(this, data.beltT, data.beltLaneIndex);
		}
		else
		{
			DebugLog("Co_RestoreOnBelt FAILED | belt not found=" + data.beltBuildingId + ", using fallback position");
			UnityEngine.Debug.LogWarning("[T_Item] Belt bulunamadı: " + data.beltBuildingId + ", fallback pozisyon kullanılıyor");
			if (rb != null)
			{
				SaveLoadGameManager.RegisterKinematicForLoad(rb);
			}
		}
	}

	public T_Item()
	{
		InitSyncObject(pieceHealthList);
		InitSyncObject(pieceCollectAmounts);
		_Mirror_SyncVarHookDelegate_itemId = OnItemIdChanged;
		_Mirror_SyncVarHookDelegate_isActive = OnActiveChanged;
		_Mirror_SyncVarHookDelegate_isNode = OnIsNodeChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_Rpc_StartConveyorMove__UInt32__Int32__Single__Single__Double__Single(uint beltNetId, int laneIndex, float startT, float endT, double startTime, float duration)
	{
		if (NetworkClient.spawned.TryGetValue(beltNetId, out var value))
		{
			T_ConveyorBelt component = value.GetComponent<T_ConveyorBelt>();
			if (!(component == null))
			{
				Client_StartConveyorMove(component, laneIndex, startT, endT, startTime, duration);
			}
		}
	}

	protected static void InvokeUserCode_Rpc_StartConveyorMove__UInt32__Int32__Single__Single__Double__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC Rpc_StartConveyorMove called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_Rpc_StartConveyorMove__UInt32__Int32__Single__Single__Double__Single(reader.ReadVarUInt(), reader.ReadVarInt(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadDouble(), reader.ReadFloat());
		}
	}

	protected void UserCode_Rpc_EnableRigidbody()
	{
		DebugLog("Rpc_EnableRigidbody | itemId=" + itemId + " setting kinematic=false gravity=true");
		if (rb != null)
		{
			rb.isKinematic = false;
			rb.useGravity = true;
		}
	}

	protected static void InvokeUserCode_Rpc_EnableRigidbody(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC Rpc_EnableRigidbody called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_Rpc_EnableRigidbody();
		}
	}

	protected void UserCode_RpcSnap__Vector3__Quaternion__Boolean__Int32(Vector3 pos, Quaternion rot, bool zeroVelocity, int RuleID)
	{
		base.transform.SetPositionAndRotation(pos, rot);
		if ((bool)rb)
		{
			rb.position = pos;
			rb.rotation = rot;
			if (zeroVelocity && !rb.isKinematic)
			{
				rb.linearVelocity = Vector3.zero;
				rb.angularVelocity = Vector3.zero;
			}
		}
		if (!base.isServer && RuleID >= 0)
		{
			T_ItemAreaSpawner instance = T_ItemAreaSpawner.instance;
			if (!TrySetParentByRuleID(instance.surface, RuleID) && !TrySetParentByRuleID(instance.mid, RuleID))
			{
				TrySetParentByRuleID(instance.deep, RuleID);
			}
		}
	}

	protected static void InvokeUserCode_RpcSnap__Vector3__Quaternion__Boolean__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcSnap called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_RpcSnap__Vector3__Quaternion__Boolean__Int32(reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadBool(), reader.ReadVarInt());
		}
	}

	protected void UserCode_CmdRequestPickup__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerHandlePickup(sender);
	}

	protected static void InvokeUserCode_CmdRequestPickup__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestPickup called on client.");
		}
		else
		{
			((T_Item)obj).UserCode_CmdRequestPickup__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdDamagePiece__Int32__Vector3__Int32__Int32__NetworkConnectionToClient(int pieceIndex, Vector3 piecePos, int damage, int bagAvailableCapacity, NetworkConnectionToClient sender)
	{
		Server_DamagePiece(pieceIndex, piecePos, damage, bagAvailableCapacity, sender);
	}

	protected static void InvokeUserCode_CmdDamagePiece__Int32__Vector3__Int32__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdDamagePiece called on client.");
		}
		else
		{
			((T_Item)obj).UserCode_CmdDamagePiece__Int32__Vector3__Int32__Int32__NetworkConnectionToClient(reader.ReadVarInt(), reader.ReadVector3(), reader.ReadVarInt(), reader.ReadVarInt(), senderConnection);
		}
	}

	protected void UserCode_TargetRpc_GiveOre__NetworkConnection__Int32(NetworkConnection conn, int amount)
	{
		if (!(so == null))
		{
			if (TutorialManager.Instance != null && TutorialManager.Instance.IsTutorialRunning && TutorialManager.Instance.CurrentSubStep == TutorialSubStepType.MineOreTarget && amount < 2)
			{
				amount = 2;
			}
			for (int i = 0; i < amount; i++)
			{
				GameManager.Instance.localBag.AddItem(so);
			}
		}
	}

	protected static void InvokeUserCode_TargetRpc_GiveOre__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpc_GiveOre called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_TargetRpc_GiveOre__NetworkConnection__Int32(null, reader.ReadVarInt());
		}
	}

	protected void UserCode_Rpc_PlayHitVFXExcept__Vector3__UInt32__Boolean(Vector3 pos, uint excludeConnId, bool isHostAttacker)
	{
		if ((!isHostAttacker || !NetworkServer.active) && (isHostAttacker || NetworkClient.connection == null || !(NetworkClient.connection.identity != null) || NetworkClient.connection.identity.netId != excludeConnId))
		{
			PlayHitVFXAtPosition(pos);
		}
	}

	protected static void InvokeUserCode_Rpc_PlayHitVFXExcept__Vector3__UInt32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC Rpc_PlayHitVFXExcept called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_Rpc_PlayHitVFXExcept__Vector3__UInt32__Boolean(reader.ReadVector3(), reader.ReadVarUInt(), reader.ReadBool());
		}
	}

	protected void UserCode_Rpc_PlayMiningVFXExcept__Vector3__UInt32__Boolean(Vector3 pos, uint excludeConnId, bool isHostAttacker)
	{
		if ((!isHostAttacker || !NetworkServer.active) && (isHostAttacker || NetworkClient.connection == null || !(NetworkClient.connection.identity != null) || NetworkClient.connection.identity.netId != excludeConnId))
		{
			PlayMiningVFXAtPosition(pos);
		}
	}

	protected static void InvokeUserCode_Rpc_PlayMiningVFXExcept__Vector3__UInt32__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC Rpc_PlayMiningVFXExcept called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_Rpc_PlayMiningVFXExcept__Vector3__UInt32__Boolean(reader.ReadVector3(), reader.ReadVarUInt(), reader.ReadBool());
		}
	}

	protected void UserCode_TargetRpc_PlayMiningVFX__NetworkConnection__Vector3(NetworkConnection conn, Vector3 pos)
	{
		PlayMiningVFXAtPosition(pos);
	}

	protected static void InvokeUserCode_TargetRpc_PlayMiningVFX__NetworkConnection__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpc_PlayMiningVFX called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_TargetRpc_PlayMiningVFX__NetworkConnection__Vector3(null, reader.ReadVector3());
		}
	}

	protected void UserCode_TargetRpc_TutorialItemBlocked__NetworkConnection(NetworkConnection conn)
	{
		ShowTutorialItemBlockedNotificationLocal();
	}

	protected static void InvokeUserCode_TargetRpc_TutorialItemBlocked__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpc_TutorialItemBlocked called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_TargetRpc_TutorialItemBlocked__NetworkConnection(null);
		}
	}

	protected void UserCode_TargetRpc_BagFullNotification__NetworkConnection(NetworkConnection conn)
	{
		ShowBagFullNotificationLocal();
	}

	protected static void InvokeUserCode_TargetRpc_BagFullNotification__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpc_BagFullNotification called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_TargetRpc_BagFullNotification__NetworkConnection(null);
		}
	}

	protected void UserCode_RpcPlayPickupVFX__Vector3(Vector3 pos)
	{
		if ((bool)so && (bool)so.PickupVFX)
		{
			UnityEngine.Object.Destroy(UnityEngine.Object.Instantiate(so.PickupVFX, pos, Quaternion.identity), 3f);
		}
	}

	protected static void InvokeUserCode_RpcPlayPickupVFX__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcPlayPickupVFX called on server.");
		}
		else
		{
			((T_Item)obj).UserCode_RpcPlayPickupVFX__Vector3(reader.ReadVector3());
		}
	}

	static T_Item()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Item), "System.Void T_Item::CmdRequestPickup(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestPickup__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Item), "System.Void T_Item::CmdDamagePiece(System.Int32,UnityEngine.Vector3,System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdDamagePiece__Int32__Vector3__Int32__Int32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::Rpc_StartConveyorMove(System.UInt32,System.Int32,System.Single,System.Single,System.Double,System.Single)", InvokeUserCode_Rpc_StartConveyorMove__UInt32__Int32__Single__Single__Double__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::Rpc_EnableRigidbody()", InvokeUserCode_Rpc_EnableRigidbody);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::RpcSnap(UnityEngine.Vector3,UnityEngine.Quaternion,System.Boolean,System.Int32)", InvokeUserCode_RpcSnap__Vector3__Quaternion__Boolean__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::Rpc_PlayHitVFXExcept(UnityEngine.Vector3,System.UInt32,System.Boolean)", InvokeUserCode_Rpc_PlayHitVFXExcept__Vector3__UInt32__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::Rpc_PlayMiningVFXExcept(UnityEngine.Vector3,System.UInt32,System.Boolean)", InvokeUserCode_Rpc_PlayMiningVFXExcept__Vector3__UInt32__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::RpcPlayPickupVFX(UnityEngine.Vector3)", InvokeUserCode_RpcPlayPickupVFX__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::TargetRpc_GiveOre(Mirror.NetworkConnection,System.Int32)", InvokeUserCode_TargetRpc_GiveOre__NetworkConnection__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::TargetRpc_PlayMiningVFX(Mirror.NetworkConnection,UnityEngine.Vector3)", InvokeUserCode_TargetRpc_PlayMiningVFX__NetworkConnection__Vector3);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::TargetRpc_TutorialItemBlocked(Mirror.NetworkConnection)", InvokeUserCode_TargetRpc_TutorialItemBlocked__NetworkConnection);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Item), "System.Void T_Item::TargetRpc_BagFullNotification(Mirror.NetworkConnection)", InvokeUserCode_TargetRpc_BagFullNotification__NetworkConnection);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(itemId);
			writer.WriteBool(isActive);
			writer.WriteString(uniqueId);
			writer.WriteBool(isNode);
			writer.WriteVarUInt(currentBeltNetId);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(itemId);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(isActive);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteString(uniqueId);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteBool(isNode);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteVarUInt(currentBeltNetId);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref itemId, _Mirror_SyncVarHookDelegate_itemId, reader.ReadString());
			GeneratedSyncVarDeserialize(ref isActive, _Mirror_SyncVarHookDelegate_isActive, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref uniqueId, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref isNode, _Mirror_SyncVarHookDelegate_isNode, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref currentBeltNetId, null, reader.ReadVarUInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref itemId, _Mirror_SyncVarHookDelegate_itemId, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isActive, _Mirror_SyncVarHookDelegate_isActive, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref uniqueId, null, reader.ReadString());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isNode, _Mirror_SyncVarHookDelegate_isNode, reader.ReadBool());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentBeltNetId, null, reader.ReadVarUInt());
		}
	}
}
