using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using I2.Loc;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class T_Sack : ItemContainerBase, IGameSave
{
	[Serializable]
	public class SackSaveData
	{
		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public float rotW;

		public List<ItemStackData> items = new List<ItemStackData>();
	}

	[CompilerGenerated]
	private sealed class _003CDestroyNextFrame_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public T_Sack _003C_003E4__this;

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
		public _003CDestroyNextFrame_003Ed__75(int _003C_003E1__state)
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
			T_Sack t_Sack = _003C_003E4__this;
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
				NetworkServer.Destroy(t_Sack.gameObject);
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

	[CompilerGenerated]
	private sealed class _003CServerWaitAndDestroy_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public T_Sack _003C_003E4__this;

		public bool destroyOnComplete;

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
		public _003CServerWaitAndDestroy_003Ed__48(int _003C_003E1__state)
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
			T_Sack t_Sack = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForSeconds(duration);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				t_Sack.NetworkisMovingOnSpline = false;
				if (destroyOnComplete)
				{
					UnityEngine.Debug.Log("T_Sack: Spline hareketi tamamlandı, destroy ediliyor");
					NetworkServer.Destroy(t_Sack.gameObject);
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

	[Header("Sack Settings")]
	[SerializeField]
	private GameObject sackVisual;

	[SerializeField]
	private Collider sackCollider;

	[SerializeField]
	private Interactable interactable;

	[Header("Sack ID")]
	[SyncVar]
	private string sackId;

	[Header("Physics")]
	[SerializeField]
	private Rigidbody rb;

	[SerializeField]
	private float throwForce = 10f;

	[SerializeField]
	private Vector3 throwDirection = Vector3.forward;

	[Header("Pickup Settings")]
	[SerializeField]
	private float pickupRadius = 2f;

	private bool hasBeenPickedUp;

	[SyncVar(hook = "OnAutoPickupSackChanged")]
	private bool isAutoPickupSack;

	[Header("Spline Movement")]
	[SyncVar]
	private bool isMovingOnSpline;

	private SplineContainer currentSpline;

	private float splineMoveDuration;

	private double splineMoveStartTime;

	private bool shouldDestroyOnComplete;

	private uint sortingStationNetId;

	private bool hasTriggerTransferred;

	public Action<bool, bool> _Mirror_SyncVarHookDelegate_isAutoPickupSack;

	public static int MaxItemsPerSack => GameManager.Instance.MaxItemsPerSack;

	public override bool SupportsCapacity => true;

	public override int CurrentItemCount => ItemCount;

	public override int TotalCapacity => MaxItemsPerSack;

	public string UniqueId => sackId;

	public bool HasBeenPickedUp => hasBeenPickedUp;

	public bool IsMovingOnSpline => isMovingOnSpline;

	public bool IsBeingCarried
	{
		get
		{
			T_Pickup component = GetComponent<T_Pickup>();
			if (component != null)
			{
				return component.hasOwner;
			}
			return false;
		}
	}

	public string SaveID => "sack-" + sackId;

	public bool IsShared => false;

	public Type SaveType => typeof(SackSaveData);

	public LoadMode LoadMode => LoadMode.Lazy;

	public string NetworksackId
	{
		get
		{
			return sackId;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref sackId, 1uL, null);
		}
	}

	public bool NetworkisAutoPickupSack
	{
		get
		{
			return isAutoPickupSack;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isAutoPickupSack, 2uL, _Mirror_SyncVarHookDelegate_isAutoPickupSack);
		}
	}

	public bool NetworkisMovingOnSpline
	{
		get
		{
			return isMovingOnSpline;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref isMovingOnSpline, 4uL, null);
		}
	}

	public void SetSackId(string id)
	{
		NetworksackId = id;
	}

	public void SetHasBeenPickedUp()
	{
		hasBeenPickedUp = true;
	}

	protected override void Awake()
	{
		base.Awake();
		EnsureRefs();
		NetworksackId = Guid.NewGuid().ToString();
	}

	protected override void OnItemCountsUpdated()
	{
		UnityEngine.Debug.Log($"T_Sack: {itemCounts.Count} benzersiz item türü, toplam {ItemCount} item client'ta güncellendi");
	}

	private void EnsureRefs()
	{
		if (!rb)
		{
			rb = GetComponent<Rigidbody>();
		}
		if (!sackVisual)
		{
			sackVisual = base.gameObject;
		}
	}

	protected override void OnServerStarted()
	{
		EnsureRefs();
		if ((bool)rb)
		{
			rb.isKinematic = false;
			rb.useGravity = true;
			rb.linearDamping = 0.5f;
		}
		if (sackCollider != null && !sackCollider.enabled)
		{
			sackCollider.enabled = true;
			UnityEngine.Debug.LogWarning("T_Sack: Collider kapalıydı! Aktif edildi.");
		}
		else if (sackCollider == null)
		{
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			sackCollider = boxCollider;
			UnityEngine.Debug.LogWarning("T_Sack: Collider yok! Otomatik BoxCollider eklendi.");
		}
		DynamicObjectSpawner.Instance?.RegisterSack(this);
		SaveLoadManager.Subscribe(this, 60);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		DynamicObjectSpawner.Instance?.UnregisterSack(sackId);
	}

	private void OnDestroy()
	{
		SaveLoadManager.Unsubscribe(this);
	}

	protected override void OnClientStarted()
	{
		base.OnClientStarted();
		if (isAutoPickupSack)
		{
			if (sackVisual != null)
			{
				sackVisual.SetActive(value: false);
			}
			if (sackCollider != null)
			{
				sackCollider.enabled = false;
			}
			if (interactable != null)
			{
				interactable.enabled = false;
			}
		}
	}

	public void SetAsAutoPickupSack()
	{
		NetworkisAutoPickupSack = true;
		if (sackCollider != null)
		{
			sackCollider.enabled = false;
		}
		if (interactable != null)
		{
			interactable.enabled = false;
		}
	}

	private void OnAutoPickupSackChanged(bool oldValue, bool newValue)
	{
		if (sackVisual != null)
		{
			sackVisual.SetActive(!newValue);
		}
		if (sackCollider != null)
		{
			sackCollider.enabled = !newValue;
		}
		if (interactable != null)
		{
			interactable.enabled = !newValue;
		}
	}

	public void OnPickupSuccess()
	{
		if (sackVisual != null)
		{
			sackVisual.SetActive(value: true);
		}
		if (isAutoPickupSack && base.isServer)
		{
			if (sackCollider != null)
			{
				sackCollider.enabled = true;
			}
			if (interactable != null)
			{
				interactable.enabled = true;
			}
			NetworkisAutoPickupSack = false;
		}
	}

	[Server]
	public void ServerThrow(Vector3 position, Vector3 direction, float force)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Sack::ServerThrow(UnityEngine.Vector3,UnityEngine.Vector3,System.Single)' called when server was not active");
			return;
		}
		if (rb == null)
		{
			EnsureRefs();
		}
		base.transform.position = position;
		if ((bool)rb)
		{
			rb.isKinematic = false;
			rb.useGravity = true;
			rb.linearVelocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.AddForce(direction * force, ForceMode.VelocityChange);
			UnityEngine.Debug.Log($"T_Sack: Çuval fırlatıldı - Yön: {direction}, Force: {force}, Velocity: {rb.linearVelocity}");
		}
		else
		{
			UnityEngine.Debug.LogError("T_Sack: ServerThrow - Rigidbody bulunamadı! Fiziksel tepkime olmayacak!");
		}
	}

	public void TryPickupSack()
	{
		if (!hasBeenPickedUp)
		{
			if (base.isServer)
			{
				ServerHandlePickup();
			}
			else
			{
				CmdRequestPickup();
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
		SendCommandInternal("System.Void T_Sack::CmdRequestPickup(Mirror.NetworkConnectionToClient)", 635792562, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerHandlePickup()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Sack::ServerHandlePickup()' called when server was not active");
		}
		else if (!hasBeenPickedUp)
		{
			hasBeenPickedUp = true;
			RpcOnSackPickedUp();
			NetworkServer.Destroy(base.gameObject);
		}
	}

	[ClientRpc]
	private void RpcOnSackPickedUp()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Sack::RpcOnSackPickedUp()", 1626438743, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(base.transform.position, pickupRadius);
	}

	[Server]
	public void ServerStartSplineMove(SplineContainer spline, float startT, float endT, float duration, bool destroyOnComplete = true)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Sack::ServerStartSplineMove(UnityEngine.Splines.SplineContainer,System.Single,System.Single,System.Single,System.Boolean)' called when server was not active");
			return;
		}
		if (spline == null)
		{
			UnityEngine.Debug.LogWarning("T_Sack: ServerStartSplineMove - Spline null!");
			return;
		}
		T_SortingStation componentInParent = spline.GetComponentInParent<T_SortingStation>();
		if (componentInParent == null)
		{
			UnityEngine.Debug.LogWarning("T_Sack: ServerStartSplineMove - T_SortingStation bulunamadı!");
			return;
		}
		sortingStationNetId = componentInParent.netId;
		NetworkisMovingOnSpline = true;
		if (rb != null)
		{
			rb.isKinematic = true;
			rb.useGravity = false;
		}
		if (sackCollider != null)
		{
			sackCollider.enabled = false;
		}
		if (spline.Spline != null)
		{
			spline.Spline.Evaluate(startT, out var position, out var tangent, out var _);
			Vector3 position2 = spline.transform.TransformPoint(position);
			base.transform.position = position2;
			if (!math.all(tangent == float3.zero))
			{
				Vector3 normalized = spline.transform.TransformDirection(tangent).normalized;
				base.transform.rotation = Quaternion.LookRotation(normalized);
			}
		}
		currentSpline = spline;
		splineMoveStartTime = NetworkTime.time;
		splineMoveDuration = Mathf.Max(duration, 0.0001f);
		shouldDestroyOnComplete = destroyOnComplete;
		double time = NetworkTime.time;
		RpcStartSplineMove(sortingStationNetId, startT, endT, time, duration, destroyOnComplete);
		StartCoroutine(ServerWaitAndDestroy(duration, destroyOnComplete));
		UnityEngine.Debug.Log($"T_Sack: Spline hareketi başlatıldı - Duration: {duration}s, DestroyOnComplete: {destroyOnComplete}");
	}

	[IteratorStateMachine(typeof(_003CServerWaitAndDestroy_003Ed__48))]
	[Server]
	private IEnumerator ServerWaitAndDestroy(float duration, bool destroyOnComplete)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_Sack::ServerWaitAndDestroy(System.Single,System.Boolean)' called when server was not active");
			return null;
		}
		return new _003CServerWaitAndDestroy_003Ed__48(0)
		{
			_003C_003E4__this = this,
			duration = duration,
			destroyOnComplete = destroyOnComplete
		};
	}

	[ClientRpc]
	private void RpcStartSplineMove(uint sortingStationNetId, float startT, float endT, double startTime, float duration, bool destroyOnComplete)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sortingStationNetId);
		writer.WriteFloat(startT);
		writer.WriteFloat(endT);
		writer.WriteDouble(startTime);
		writer.WriteFloat(duration);
		writer.WriteBool(destroyOnComplete);
		SendRPCInternal("System.Void T_Sack::RpcStartSplineMove(System.UInt32,System.Single,System.Single,System.Double,System.Single,System.Boolean)", -1004687711, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Client_StartSplineMove(SplineContainer spline, float startT, float endT, double startTime, float duration, bool destroyOnComplete)
	{
		currentSpline = spline;
		splineMoveStartTime = startTime;
		splineMoveDuration = Mathf.Max(duration, 0.0001f);
		shouldDestroyOnComplete = destroyOnComplete;
		NetworkisMovingOnSpline = true;
		base.transform.SetParent(null);
		if (sackVisual != null)
		{
			sackVisual.SetActive(value: true);
		}
		base.gameObject.SetActive(value: true);
		if (rb != null)
		{
			rb.isKinematic = true;
			rb.useGravity = false;
		}
		if (sackCollider != null)
		{
			sackCollider.enabled = true;
		}
		if (interactable != null)
		{
			interactable.enabled = false;
		}
		if (spline != null && spline.Spline != null)
		{
			spline.Spline.Evaluate(startT, out var position, out var tangent, out var _);
			Vector3 position2 = spline.transform.TransformPoint(position);
			base.transform.position = position2;
			if (!math.all(tangent == float3.zero))
			{
				Vector3 normalized = spline.transform.TransformDirection(tangent).normalized;
				base.transform.rotation = Quaternion.LookRotation(normalized);
			}
		}
		UnityEngine.Debug.Log($"T_Sack: Client spline hareketi başladı - StartT: {startT}, EndT: {endT}, Duration: {duration}s");
	}

	private void Update()
	{
		if (isMovingOnSpline && currentSpline != null)
		{
			SplineMovement_Update();
		}
	}

	private void SplineMovement_Update()
	{
		float num = Mathf.Clamp01((float)(NetworkTime.time - splineMoveStartTime) / splineMoveDuration);
		float t = Mathf.Lerp(0f, 2f, num);
		if (currentSpline != null && currentSpline.Spline != null)
		{
			currentSpline.Spline.Evaluate(t, out var position, out var tangent, out var _);
			Vector3 position2 = currentSpline.transform.TransformPoint(position);
			base.transform.position = position2;
			if (!math.all(tangent == float3.zero))
			{
				Vector3 normalized = currentSpline.transform.TransformDirection(tangent).normalized;
				base.transform.rotation = Quaternion.LookRotation(normalized);
			}
		}
		if (num >= 1f)
		{
			NetworkisMovingOnSpline = false;
			currentSpline = null;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		UnityEngine.Debug.Log($"[T_Sack] OnTriggerEnter ÇAĞRILDI! Çarpan obje: '{other.gameObject.name}', Tag: '{other.tag}', Layer: {other.gameObject.layer}, IsTrigger: {other.isTrigger}, Sack: '{base.gameObject.name}', SackNetId: {base.netId}");
		if (hasTriggerTransferred)
		{
			UnityEngine.Debug.LogWarning("[T_Sack] ENGEL: hasTriggerTransferred=true, zaten aktarılmış! Sack: '" + base.gameObject.name + "'");
			return;
		}
		if (hasBeenPickedUp)
		{
			UnityEngine.Debug.LogWarning("[T_Sack] ENGEL: hasBeenPickedUp=true, zaten alınmış! Sack: '" + base.gameObject.name + "'");
			return;
		}
		if (isMovingOnSpline)
		{
			UnityEngine.Debug.LogWarning("[T_Sack] ENGEL: isMovingOnSpline=true, spline hareketi sırasında! Sack: '" + base.gameObject.name + "'");
			return;
		}
		if (isAutoPickupSack)
		{
			UnityEngine.Debug.Log("[T_Sack] ENGEL: isAutoPickupSack=true, truck'tan spawn edilen sack geri aktarılmaz! Sack: '" + base.gameObject.name + "'");
			return;
		}
		if (base.transform.parent != null)
		{
			UnityEngine.Debug.Log("[T_Sack] ENGEL: Sack elde tutuluyor (parent=" + base.transform.parent.name + "), truck'a aktarılamaz! Sack: '" + base.gameObject.name + "'");
			return;
		}
		T_Pickup component = GetComponent<T_Pickup>();
		if (component != null && component.hasOwner)
		{
			if (!base.isOwned)
			{
				return;
			}
		}
		else if (!base.isServer)
		{
			return;
		}
		bool flag = other.CompareTag("SackTrigger");
		UnityEngine.Debug.Log($"[T_Sack] Tag karşılaştırması: '{other.tag}' == 'SackTrigger' ? {flag}");
		if (!flag)
		{
			return;
		}
		if (ItemCount == 0)
		{
			UnityEngine.Debug.LogWarning("[T_Sack] ENGEL: Sack boş (ItemCount=0), aktarılacak item yok!");
			return;
		}
		T_Truck componentInParent = other.GetComponentInParent<T_Truck>();
		UnityEngine.Debug.Log("[T_Sack] SackTrigger bulundu! Parent'ta T_Truck aranıyor... Sonuç: " + ((componentInParent != null) ? componentInParent.gameObject.name : "NULL"));
		if (componentInParent != null)
		{
			UnityEngine.Debug.Log($"[T_Sack] ItemCount: {ItemCount}, isServer: {base.isServer}, isClient: {base.isClient}");
			hasTriggerTransferred = true;
			if (base.isServer)
			{
				UnityEngine.Debug.Log($"[T_Sack] SERVER/HOST: ServerTransferToTruck çağrılıyor. Truck: '{componentInParent.gameObject.name}', TruckNetId: {componentInParent.netId}");
				ServerTransferToTruck(componentInParent);
			}
			else
			{
				UnityEngine.Debug.Log($"[T_Sack] CLIENT: CmdTriggerTransferToTruck gönderiliyor. TruckNetId: {componentInParent.netId}");
				CmdTriggerTransferToTruck(componentInParent.netId);
			}
			return;
		}
		T_SortingStation componentInParent2 = other.GetComponentInParent<T_SortingStation>();
		UnityEngine.Debug.Log("[T_Sack] Parent'ta T_SortingStation aranıyor... Sonuç: " + ((componentInParent2 != null) ? componentInParent2.gameObject.name : "NULL"));
		if (componentInParent2 != null)
		{
			UnityEngine.Debug.Log($"[T_Sack] ItemCount: {ItemCount}, isServer: {base.isServer}, isClient: {base.isClient}");
			hasTriggerTransferred = true;
			if (base.isServer)
			{
				UnityEngine.Debug.Log($"[T_Sack] SERVER/HOST: ServerTransferToSortingStation çağrılıyor. Station: '{componentInParent2.gameObject.name}', NetId: {componentInParent2.netId}");
				ServerTransferToSortingStation(componentInParent2);
			}
			else
			{
				UnityEngine.Debug.Log($"[T_Sack] CLIENT: CmdTriggerTransferToSortingStation gönderiliyor. StationNetId: {componentInParent2.netId}");
				CmdTriggerTransferToSortingStation(componentInParent2.netId);
			}
		}
		else
		{
			string text = ((other.transform.parent != null) ? other.transform.parent.name : "YOK");
			UnityEngine.Debug.LogWarning("[T_Sack] ENGEL: SackTrigger'a çarpıldı ama parent hiyerarşisinde T_Truck veya T_SortingStation bulunamadı! Collider parent: '" + text + "'");
		}
	}

	[Server]
	private void ServerTransferToTruck(T_Truck truck)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Sack::ServerTransferToTruck(T_Truck)' called when server was not active");
		}
		else if (!hasBeenPickedUp)
		{
			if (base.transform.parent != null)
			{
				UnityEngine.Debug.LogWarning("[T_Sack] ServerTransferToTruck ENGEL: Sack elde tutuluyor (parent=" + base.transform.parent.name + "), truck'a aktarılmaz!");
				hasTriggerTransferred = false;
			}
			else if (truck.TransferItemsFromSack(this))
			{
				hasBeenPickedUp = true;
				truck.RpcPlaySackPlacedEffectsPublic();
				UnityEngine.Debug.Log("T_Sack: SackTrigger ile truck'a item aktarıldı, sack destroy ediliyor.");
				NetworkServer.Destroy(base.gameObject);
			}
			else
			{
				hasTriggerTransferred = false;
				UnityEngine.Debug.LogWarning("T_Sack: Truck'a item aktarımı başarısız! (Truck dolu olabilir)");
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTriggerTransferToTruck(uint truckNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTriggerTransferToTruck__UInt32__NetworkConnectionToClient(truckNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(truckNetId);
		SendCommandInternal("System.Void T_Sack::CmdTriggerTransferToTruck(System.UInt32,Mirror.NetworkConnectionToClient)", 250320112, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTransferToSortingStation(T_SortingStation sortingStation)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Sack::ServerTransferToSortingStation(T_SortingStation)' called when server was not active");
		}
		else if (!hasBeenPickedUp)
		{
			if (base.transform.parent != null)
			{
				UnityEngine.Debug.LogWarning("[T_Sack] ServerTransferToSortingStation ENGEL: Sack elde tutuluyor (parent=" + base.transform.parent.name + "), SortingStation'a aktarılmaz!");
				hasTriggerTransferred = false;
			}
			else if (sortingStation.TransferItemsFromSack(this))
			{
				hasBeenPickedUp = true;
				UnityEngine.Debug.Log("T_Sack: SackTrigger ile SortingStation'a item aktarıldı, sack spline hareketi başlatıldı.");
			}
			else
			{
				hasTriggerTransferred = false;
				UnityEngine.Debug.LogWarning("T_Sack: SortingStation'a item aktarımı başarısız!");
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTriggerTransferToSortingStation(uint stationNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTriggerTransferToSortingStation__UInt32__NetworkConnectionToClient(stationNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(stationNetId);
		SendCommandInternal("System.Void T_Sack::CmdTriggerTransferToSortingStation(System.UInt32,Mirror.NetworkConnectionToClient)", -645487691, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void OnSecondaryInteract()
	{
		if (!(interactable == null) && interactable.currentSecondaryState == SecondaryState.AddToInventory)
		{
			if (isMovingOnSpline)
			{
				UnityEngine.Debug.Log("T_Sack: Spline hareketi sırasında envantere eklenemez!");
			}
			else if (!hasBeenPickedUp)
			{
				TryAddToInventory();
			}
		}
	}

	public void TryAddToInventoryFromHand()
	{
		if (!isMovingOnSpline && !hasBeenPickedUp)
		{
			CmdAddToInventoryFromHand();
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdAddToInventoryFromHand(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddToInventoryFromHand__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Sack::CmdAddToInventoryFromHand(Mirror.NetworkConnectionToClient)", 1394341886, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void TryAddToInventory()
	{
		CmdAddToInventory();
	}

	[Command(requiresAuthority = false)]
	private void CmdAddToInventory(NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdAddToInventory__NetworkConnectionToClient(sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void T_Sack::CmdAddToInventory(Mirror.NetworkConnectionToClient)", 1400782211, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerAddToInventory(NetworkConnectionToClient sender)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Void T_Sack::ServerAddToInventory(Mirror.NetworkConnectionToClient)' called when server was not active");
			return;
		}
		if (hasBeenPickedUp)
		{
			UnityEngine.Debug.Log("T_Sack: Zaten alınmış, envantere eklenemez!");
			return;
		}
		if (storedItemStacks.Count == 0)
		{
			UnityEngine.Debug.Log("T_Sack: Sack boş, envantere eklenecek item yok!");
			return;
		}
		NetworkConnectionToClient networkConnectionToClient = sender ?? NetworkServer.localConnection;
		T_Bag t_Bag = FindBagForConnection(networkConnectionToClient);
		if (t_Bag == null)
		{
			UnityEngine.Debug.LogWarning($"T_Sack: FindBagForConnection ile T_Bag bulunamadı! Connection: {networkConnectionToClient?.connectionId}");
		}
		if (t_Bag == null)
		{
			UnityEngine.Debug.LogWarning("T_Sack: ServerAddToInventory - T_Bag bulunamadı!");
			return;
		}
		List<T_ItemSO> list = new List<T_ItemSO>();
		if (ItemSOManager.Instance != null)
		{
			foreach (ItemStack stack in storedItemStacks)
			{
				if (stack == null || !stack.IsValid())
				{
					continue;
				}
				T_ItemSO t_ItemSO = ItemSOManager.Instance.GetAllItemSOs().FirstOrDefault((T_ItemSO so) => so != null && so.GetItemID() == stack.itemId);
				if (t_ItemSO != null)
				{
					for (int num = 0; num < stack.count; num++)
					{
						list.Add(t_ItemSO);
					}
				}
			}
		}
		if (list.Count == 0)
		{
			UnityEngine.Debug.LogWarning("T_Sack: ServerAddToInventory - Geçerli item bulunamadı!");
			return;
		}
		List<T_ItemSO> list2 = new List<T_ItemSO>();
		List<T_ItemSO> list3 = new List<T_ItemSO>();
		foreach (T_ItemSO item in list)
		{
			if (t_Bag.CanAddItem(item))
			{
				t_Bag.AddItem(item, countForTutorial: false);
				list2.Add(item);
			}
			else
			{
				list3.Add(item);
			}
		}
		if (list2.Count > 0)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			List<string> list4 = new List<string>();
			foreach (T_ItemSO item2 in list2)
			{
				string itemID = item2.GetItemID();
				list4.Add(itemID);
				if (dictionary.ContainsKey(itemID))
				{
					dictionary[itemID]++;
				}
				else
				{
					dictionary[itemID] = 1;
				}
			}
			ServerRemoveItems(dictionary);
			if (networkConnectionToClient != null && networkConnectionToClient != NetworkServer.localConnection)
			{
				TargetRpcAddItemsToBag(networkConnectionToClient, list4);
			}
		}
		UnityEngine.Debug.Log($"T_Sack: {list2.Count} item envantere eklendi, {list3.Count} item eklenemedi (çanta dolu)");
		if (storedItemStacks.Count == 0 || ItemCount == 0)
		{
			if (networkConnectionToClient != null)
			{
				TargetRpcInventoryAddSuccess(networkConnectionToClient, list2.Count);
			}
			hasBeenPickedUp = true;
			T_Pickup component = GetComponent<T_Pickup>();
			if (component != null && component.hasOwner)
			{
				component.NetworkhasOwner = false;
				component.NetworkownerNetId = 0u;
				if (base.transform.parent != null)
				{
					base.transform.SetParent(null, worldPositionStays: true);
				}
			}
			RpcOnSackEmptied();
			StartCoroutine(DestroyNextFrame());
		}
		else if (networkConnectionToClient != null)
		{
			if (list2.Count == 0)
			{
				TargetRpcInventoryFull(networkConnectionToClient);
			}
			else
			{
				TargetRpcInventoryPartialAdd(networkConnectionToClient, list2.Count, list3.Count);
			}
		}
	}

	private T_Bag FindBagForConnection(NetworkConnectionToClient sender)
	{
		if (sender == null)
		{
			return null;
		}
		if (sender.identity != null)
		{
			T_Bag componentInChildren = sender.identity.GetComponentInChildren<T_Bag>();
			if (componentInChildren != null)
			{
				return componentInChildren;
			}
		}
		foreach (KeyValuePair<uint, NetworkIdentity> item in NetworkServer.spawned)
		{
			NetworkIdentity value = item.Value;
			if (!(value == null) && value.connectionToClient == sender)
			{
				T_Bag component = value.GetComponent<T_Bag>();
				if (component != null)
				{
					return component;
				}
			}
		}
		GamePlayer[] array = UnityEngine.Object.FindObjectsByType<GamePlayer>(FindObjectsSortMode.None);
		foreach (GamePlayer gamePlayer in array)
		{
			if (gamePlayer.connectionToClient == sender)
			{
				T_Bag componentInChildren2 = gamePlayer.GetComponentInChildren<T_Bag>();
				if (componentInChildren2 != null)
				{
					return componentInChildren2;
				}
			}
		}
		return null;
	}

	[ClientRpc]
	private void RpcOnSackEmptied()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void T_Sack::RpcOnSackEmptied()", -1182713908, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpcAddItemsToBag(NetworkConnectionToClient target, List<string> itemIds)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(writer, itemIds);
		SendTargetRPCInternal(target, "System.Void T_Sack::TargetRpcAddItemsToBag(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<System.String>)", -1103124863, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpcInventoryAddSuccess(NetworkConnectionToClient target, int addedCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(addedCount);
		SendTargetRPCInternal(target, "System.Void T_Sack::TargetRpcInventoryAddSuccess(Mirror.NetworkConnectionToClient,System.Int32)", 1963730308, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpcInventoryPartialAdd(NetworkConnectionToClient target, int addedCount, int failedCount)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(addedCount);
		writer.WriteVarInt(failedCount);
		SendTargetRPCInternal(target, "System.Void T_Sack::TargetRpcInventoryPartialAdd(Mirror.NetworkConnectionToClient,System.Int32,System.Int32)", -196020083, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void TargetRpcInventoryFull(NetworkConnectionToClient target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_Sack::TargetRpcInventoryFull(Mirror.NetworkConnectionToClient)", 596845586, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[IteratorStateMachine(typeof(_003CDestroyNextFrame_003Ed__75))]
	[Server]
	private IEnumerator DestroyNextFrame()
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogWarning("[Server] function 'System.Collections.IEnumerator T_Sack::DestroyNextFrame()' called when server was not active");
			return null;
		}
		return new _003CDestroyNextFrame_003Ed__75(0)
		{
			_003C_003E4__this = this
		};
	}

	public object GetSaveData(bool includeNonSavable)
	{
		if (!base.isServer)
		{
			return null;
		}
		Vector3 vector = ((rb != null) ? rb.position : base.transform.position);
		Quaternion quaternion2 = ((rb != null) ? rb.rotation : base.transform.rotation);
		SackSaveData sackSaveData = new SackSaveData
		{
			posX = vector.x,
			posY = vector.y,
			posZ = vector.z,
			rotX = quaternion2.x,
			rotY = quaternion2.y,
			rotZ = quaternion2.z,
			rotW = quaternion2.w
		};
		foreach (ItemStack storedItemStack in storedItemStacks)
		{
			if (storedItemStack != null && storedItemStack.IsValid())
			{
				sackSaveData.items.Add(new ItemStackData(storedItemStack.itemId, storedItemStack.count));
			}
		}
		UnityEngine.Debug.Log($"[T_Sack] GetSaveData - ID: {sackId}, Items: {sackSaveData.items.Count}");
		return sackSaveData;
	}

	public Task OnLoad(object value)
	{
		if (!base.isServer)
		{
			return Task.CompletedTask;
		}
		if (!(value is SackSaveData sackSaveData))
		{
			UnityEngine.Debug.LogWarning("[T_Sack] OnLoad - Invalid data type for sack: " + sackId);
			return Task.CompletedTask;
		}
		Vector3 position = new Vector3(sackSaveData.posX, sackSaveData.posY, sackSaveData.posZ);
		Quaternion rotation = new Quaternion(sackSaveData.rotX, sackSaveData.rotY, sackSaveData.rotZ, sackSaveData.rotW);
		if (rb != null)
		{
			SaveLoadGameManager.RegisterKinematicForLoad(rb);
			rb.position = position;
			rb.rotation = rotation;
		}
		base.transform.SetPositionAndRotation(position, rotation);
		storedItemStacks.Clear();
		foreach (ItemStackData item in sackSaveData.items)
		{
			if (!string.IsNullOrEmpty(item.itemId) && item.count > 0)
			{
				storedItemStacks.Add(new ItemStack(item.itemId, item.count));
			}
		}
		UnityEngine.Debug.Log($"[T_Sack] OnLoad - ID: {sackId}, Items: {storedItemStacks.Count}");
		return Task.CompletedTask;
	}

	public T_Sack()
	{
		_Mirror_SyncVarHookDelegate_isAutoPickupSack = OnAutoPickupSackChanged;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestPickup__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerHandlePickup();
	}

	protected static void InvokeUserCode_CmdRequestPickup__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdRequestPickup called on client.");
		}
		else
		{
			((T_Sack)obj).UserCode_CmdRequestPickup__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcOnSackPickedUp()
	{
		if ((bool)sackVisual)
		{
			sackVisual.SetActive(value: false);
		}
	}

	protected static void InvokeUserCode_RpcOnSackPickedUp(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnSackPickedUp called on server.");
		}
		else
		{
			((T_Sack)obj).UserCode_RpcOnSackPickedUp();
		}
	}

	protected void UserCode_RpcStartSplineMove__UInt32__Single__Single__Double__Single__Boolean(uint sortingStationNetId, float startT, float endT, double startTime, float duration, bool destroyOnComplete)
	{
		if (!NetworkClient.spawned.TryGetValue(sortingStationNetId, out var value))
		{
			UnityEngine.Debug.LogWarning($"T_Sack: RpcStartSplineMove - SortingStation bulunamadı! NetId: {sortingStationNetId}");
			return;
		}
		T_SortingStation component = value.GetComponent<T_SortingStation>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("T_Sack: RpcStartSplineMove - T_SortingStation component bulunamadı!");
			return;
		}
		SplineContainer splineContainer = component.GetSplineContainer();
		if (splineContainer == null)
		{
			UnityEngine.Debug.LogWarning("T_Sack: RpcStartSplineMove - SplineContainer bulunamadı!");
		}
		else
		{
			Client_StartSplineMove(splineContainer, startT, endT, startTime, duration, destroyOnComplete);
		}
	}

	protected static void InvokeUserCode_RpcStartSplineMove__UInt32__Single__Single__Double__Single__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcStartSplineMove called on server.");
		}
		else
		{
			((T_Sack)obj).UserCode_RpcStartSplineMove__UInt32__Single__Single__Double__Single__Boolean(reader.ReadVarUInt(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadDouble(), reader.ReadFloat(), reader.ReadBool());
		}
	}

	protected void UserCode_CmdTriggerTransferToTruck__UInt32__NetworkConnectionToClient(uint truckNetId, NetworkConnectionToClient sender)
	{
		if (hasBeenPickedUp)
		{
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(truckNetId, out var value))
		{
			UnityEngine.Debug.LogWarning($"T_Sack: CmdTriggerTransferToTruck - Truck NetId ({truckNetId}) bulunamadı!");
			return;
		}
		T_Truck component = value.GetComponent<T_Truck>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("T_Sack: CmdTriggerTransferToTruck - Bulunan obje T_Truck değil!");
		}
		else
		{
			ServerTransferToTruck(component);
		}
	}

	protected static void InvokeUserCode_CmdTriggerTransferToTruck__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTriggerTransferToTruck called on client.");
		}
		else
		{
			((T_Sack)obj).UserCode_CmdTriggerTransferToTruck__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdTriggerTransferToSortingStation__UInt32__NetworkConnectionToClient(uint stationNetId, NetworkConnectionToClient sender)
	{
		if (hasBeenPickedUp)
		{
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(stationNetId, out var value))
		{
			UnityEngine.Debug.LogWarning($"T_Sack: CmdTriggerTransferToSortingStation - Station NetId ({stationNetId}) bulunamadı!");
			return;
		}
		T_SortingStation component = value.GetComponent<T_SortingStation>();
		if (component == null)
		{
			UnityEngine.Debug.LogWarning("T_Sack: CmdTriggerTransferToSortingStation - Bulunan obje T_SortingStation değil!");
		}
		else
		{
			ServerTransferToSortingStation(component);
		}
	}

	protected static void InvokeUserCode_CmdTriggerTransferToSortingStation__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdTriggerTransferToSortingStation called on client.");
		}
		else
		{
			((T_Sack)obj).UserCode_CmdTriggerTransferToSortingStation__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_CmdAddToInventoryFromHand__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerAddToInventory(sender);
	}

	protected static void InvokeUserCode_CmdAddToInventoryFromHand__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdAddToInventoryFromHand called on client.");
		}
		else
		{
			((T_Sack)obj).UserCode_CmdAddToInventoryFromHand__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_CmdAddToInventory__NetworkConnectionToClient(NetworkConnectionToClient sender)
	{
		ServerAddToInventory(sender);
	}

	protected static void InvokeUserCode_CmdAddToInventory__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			UnityEngine.Debug.LogError("Command CmdAddToInventory called on client.");
		}
		else
		{
			((T_Sack)obj).UserCode_CmdAddToInventory__NetworkConnectionToClient(senderConnection);
		}
	}

	protected void UserCode_RpcOnSackEmptied()
	{
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null && GameManager.Instance.localEquipments.pickupItem == base.gameObject)
		{
			GameManager.Instance.localEquipments.ClearPickupItem();
			GameManager.Instance.localEquipments.TryUnequip();
		}
		if (base.transform.parent != null)
		{
			base.transform.SetParent(null, worldPositionStays: true);
		}
		if (sackVisual != null)
		{
			sackVisual.SetActive(value: false);
		}
		UnityEngine.Debug.Log("T_Sack: Tüm itemler envantere eklendi, sack boşaltıldı.");
	}

	protected static void InvokeUserCode_RpcOnSackEmptied(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("RPC RpcOnSackEmptied called on server.");
		}
		else
		{
			((T_Sack)obj).UserCode_RpcOnSackEmptied();
		}
	}

	protected void UserCode_TargetRpcAddItemsToBag__NetworkConnectionToClient__List_00601(NetworkConnectionToClient target, List<string> itemIds)
	{
		T_Bag t_Bag = GameManager.Instance?.localBag;
		if (t_Bag == null || ItemSOManager.Instance == null)
		{
			return;
		}
		foreach (string itemId in itemIds)
		{
			T_ItemSO itemSOById = ItemSOManager.Instance.GetItemSOById(itemId);
			if (itemSOById != null)
			{
				t_Bag.AddItem(itemSOById, countForTutorial: false);
			}
		}
		UnityEngine.Debug.Log($"T_Sack: Client - {itemIds.Count} item envantere eklendi");
	}

	protected static void InvokeUserCode_TargetRpcAddItemsToBag__NetworkConnectionToClient__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcAddItemsToBag called on server.");
		}
		else
		{
			((T_Sack)obj).UserCode_TargetRpcAddItemsToBag__NetworkConnectionToClient__List_00601(null, GeneratedNetworkCode._Read_System_002ECollections_002EGeneric_002EList_00601_003CSystem_002EString_003E(reader));
		}
	}

	protected void UserCode_TargetRpcInventoryAddSuccess__NetworkConnectionToClient__Int32(NetworkConnectionToClient target, int addedCount)
	{
		if (GameManager.Instance != null && GameManager.Instance.UImanager != null && GameManager.Instance.UImanager.holdInputFillUI != null)
		{
			GameManager.Instance.UImanager.holdInputFillUI.ShowPackAllNotification(addedCount, "Notification_SackAddedToInventory");
		}
		UnityEngine.Debug.Log($"T_Sack: {addedCount} item envantere eklendi (notification gösterildi)");
	}

	protected static void InvokeUserCode_TargetRpcInventoryAddSuccess__NetworkConnectionToClient__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcInventoryAddSuccess called on server.");
		}
		else
		{
			((T_Sack)obj).UserCode_TargetRpcInventoryAddSuccess__NetworkConnectionToClient__Int32(null, reader.ReadVarInt());
		}
	}

	protected void UserCode_TargetRpcInventoryPartialAdd__NetworkConnectionToClient__Int32__Int32(NetworkConnectionToClient target, int addedCount, int failedCount)
	{
		if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
		{
			string message = string.Format(LocalizationManager.GetTranslation("Notification_SackItemsAdded"), addedCount, failedCount);
			GameManager.Instance.notificationManager.ShowNotification(message);
		}
		UnityEngine.Debug.Log($"T_Sack: Kısmi ekleme - {addedCount} eklendi, {failedCount} eklenemedi");
	}

	protected static void InvokeUserCode_TargetRpcInventoryPartialAdd__NetworkConnectionToClient__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcInventoryPartialAdd called on server.");
		}
		else
		{
			((T_Sack)obj).UserCode_TargetRpcInventoryPartialAdd__NetworkConnectionToClient__Int32__Int32(null, reader.ReadVarInt(), reader.ReadVarInt());
		}
	}

	protected void UserCode_TargetRpcInventoryFull__NetworkConnectionToClient(NetworkConnectionToClient target)
	{
		if (GameManager.Instance != null && GameManager.Instance.notificationManager != null)
		{
			string translation = LocalizationManager.GetTranslation("Notification_BagFullKey");
			GameManager.Instance.notificationManager.ShowNotification(translation);
		}
		UnityEngine.Debug.Log("T_Sack: Çanta dolu - hiçbir item eklenemedi, sack elde kalmaya devam ediyor");
	}

	protected static void InvokeUserCode_TargetRpcInventoryFull__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			UnityEngine.Debug.LogError("TargetRPC TargetRpcInventoryFull called on server.");
		}
		else
		{
			((T_Sack)obj).UserCode_TargetRpcInventoryFull__NetworkConnectionToClient(null);
		}
	}

	static T_Sack()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_Sack), "System.Void T_Sack::CmdRequestPickup(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestPickup__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Sack), "System.Void T_Sack::CmdTriggerTransferToTruck(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTriggerTransferToTruck__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Sack), "System.Void T_Sack::CmdTriggerTransferToSortingStation(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTriggerTransferToSortingStation__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Sack), "System.Void T_Sack::CmdAddToInventoryFromHand(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdAddToInventoryFromHand__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(T_Sack), "System.Void T_Sack::CmdAddToInventory(Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdAddToInventory__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Sack), "System.Void T_Sack::RpcOnSackPickedUp()", InvokeUserCode_RpcOnSackPickedUp);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Sack), "System.Void T_Sack::RpcStartSplineMove(System.UInt32,System.Single,System.Single,System.Double,System.Single,System.Boolean)", InvokeUserCode_RpcStartSplineMove__UInt32__Single__Single__Double__Single__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Sack), "System.Void T_Sack::RpcOnSackEmptied()", InvokeUserCode_RpcOnSackEmptied);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Sack), "System.Void T_Sack::TargetRpcAddItemsToBag(Mirror.NetworkConnectionToClient,System.Collections.Generic.List`1<System.String>)", InvokeUserCode_TargetRpcAddItemsToBag__NetworkConnectionToClient__List_00601);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Sack), "System.Void T_Sack::TargetRpcInventoryAddSuccess(Mirror.NetworkConnectionToClient,System.Int32)", InvokeUserCode_TargetRpcInventoryAddSuccess__NetworkConnectionToClient__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Sack), "System.Void T_Sack::TargetRpcInventoryPartialAdd(Mirror.NetworkConnectionToClient,System.Int32,System.Int32)", InvokeUserCode_TargetRpcInventoryPartialAdd__NetworkConnectionToClient__Int32__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(T_Sack), "System.Void T_Sack::TargetRpcInventoryFull(Mirror.NetworkConnectionToClient)", InvokeUserCode_TargetRpcInventoryFull__NetworkConnectionToClient);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteString(sackId);
			writer.WriteBool(isAutoPickupSack);
			writer.WriteBool(isMovingOnSpline);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(sackId);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(isAutoPickupSack);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(isMovingOnSpline);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref sackId, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref isAutoPickupSack, _Mirror_SyncVarHookDelegate_isAutoPickupSack, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref isMovingOnSpline, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref sackId, null, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isAutoPickupSack, _Mirror_SyncVarHookDelegate_isAutoPickupSack, reader.ReadBool());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref isMovingOnSpline, null, reader.ReadBool());
		}
	}
}
