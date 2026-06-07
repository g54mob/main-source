using System.Collections.Generic;
using System.Linq;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public class T_SortingStation : NetworkBehaviour
{
	[Header("Interaction")]
	[Tooltip("Interactable referansı - HandleSortingMachineInteraction için kullanılacak Interactable component'i (manuel atanır)")]
	[SerializeField]
	private Interactable Interactable;

	[Header("Spline Movement")]
	[Tooltip("Sack'in üzerinde hareket edeceği SplineContainer (belt spline'ı)")]
	[SerializeField]
	private SplineContainer sackSpline;

	[Tooltip("Sack'in spline üzerinde başlayacağı nokta (0-1)")]
	[SerializeField]
	private float splineStartT;

	[Tooltip("Sack'in spline üzerinde biteceği nokta (0-1)")]
	[SerializeField]
	private float splineEndT = 1f;

	[Tooltip("Sack'in spline üzerinde hareket süresi (saniye)")]
	[SerializeField]
	private float splineMoveDuration = 3f;

	[Header("Events")]
	public UnityEvent<T_Sack> OnSackProcessed;

	public UnityEvent<int> OnItemsAdded;

	private StorageManager storageManager;

	private void Awake()
	{
		if (GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
			if (storageManager == null)
			{
				Debug.LogWarning("T_SortingStation: GameManager'da StorageManager referansı atanmamış! GameManager Inspector'dan StorageManager'ı atayın.");
			}
		}
		else
		{
			Debug.LogWarning("T_SortingStation: GameManager.Instance null! StorageManager alınamadı.");
		}
	}

	public void TryTransferSackFromPlayer()
	{
		if (GameManager.Instance == null || GameManager.Instance.localEquipments == null)
		{
			Debug.LogWarning("T_SortingStation: TryTransferSackFromPlayer - GameManager veya localEquipments null!");
			return;
		}
		GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
		if (pickupItem == null)
		{
			Debug.LogWarning("T_SortingStation: TryTransferSackFromPlayer - Player'ın elinde item yok!");
			return;
		}
		T_Sack component = pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			Debug.LogWarning("T_SortingStation: TryTransferSackFromPlayer - Elindeki item T_Sack değil!");
			return;
		}
		if (component.ItemCount == 0)
		{
			Debug.LogWarning("T_SortingStation: TryTransferSackFromPlayer - Sack boş!");
			return;
		}
		if (storageManager == null && GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
		}
		if (storageManager == null)
		{
			Debug.LogWarning("T_SortingStation: TryTransferSackFromPlayer - StorageManager null!");
		}
		else if (base.isServer)
		{
			if (TransferItemsFromSack(component))
			{
				GameManager.Instance.localEquipments.ClearPickupItem();
				GameManager.Instance.localEquipments.TryUnequip();
			}
		}
		else
		{
			CmdTransferItemsFromSack(component.netId);
		}
	}

	public bool CanTransferSackFromPlayer()
	{
		if (GameManager.Instance == null || GameManager.Instance.localEquipments == null)
		{
			return false;
		}
		GameObject pickupItem = GameManager.Instance.localEquipments.pickupItem;
		if (pickupItem == null)
		{
			return false;
		}
		T_Sack component = pickupItem.GetComponent<T_Sack>();
		if (component == null)
		{
			return false;
		}
		if (component.ItemCount == 0)
		{
			return false;
		}
		if (storageManager == null && GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
		}
		if (storageManager == null)
		{
			return false;
		}
		return true;
	}

	[Command(requiresAuthority = false)]
	public void CmdTransferItemsFromSack(uint sackNetId, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(sackNetId, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarUInt(sackNetId);
		SendCommandInternal("System.Void T_SortingStation::CmdTransferItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", -338705458, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[TargetRpc]
	private void RpcClearPlayerPickupItem(NetworkConnection target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendTargetRPCInternal(target, "System.Void T_SortingStation::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", -164513687, writer, 0);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public bool TransferItemsFromSack(T_Sack sack)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean T_SortingStation::TransferItemsFromSack(T_Sack)' called when server was not active");
			return default(bool);
		}
		if (sack == null)
		{
			Debug.LogWarning("T_SortingStation: TransferItemsFromSack - Sack null!");
			return false;
		}
		if (storageManager == null && GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
		}
		if (storageManager == null)
		{
			Debug.LogWarning("T_SortingStation: TransferItemsFromSack - StorageManager null!");
			return false;
		}
		Dictionary<string, int> storedItemCounts = sack.GetStoredItemCounts();
		if (storedItemCounts == null || storedItemCounts.Count == 0)
		{
			Debug.LogWarning("T_SortingStation: TransferItemsFromSack - Sack boş!");
			return false;
		}
		storageManager.RequestAddItemsFromSack(sack);
		int num = storedItemCounts.Values.Sum();
		OnSackProcessed?.Invoke(sack);
		OnItemsAdded?.Invoke(num);
		Debug.Log($"T_SortingStation: {num} item sack'ten StorageManager'a aktarıldı!");
		if (TutorialManager.Instance != null)
		{
			TutorialManager.Instance.TryCompleteSubStep(TutorialConfigType.Mining, TutorialStepType.ReturnToFactory, TutorialSubStepType.PlaceInSortingStation);
		}
		StartSackSplineMovement(sack);
		return true;
	}

	[Server]
	private void StartSackSplineMovement(T_Sack sack)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void T_SortingStation::StartSackSplineMovement(T_Sack)' called when server was not active");
		}
		else if (sack == null)
		{
			Debug.LogWarning("T_SortingStation: StartSackSplineMovement - Sack null!");
		}
		else if (sackSpline == null)
		{
			Debug.LogWarning("T_SortingStation: StartSackSplineMovement - SplineContainer atanmamış! Sack direkt destroy edilecek.");
			NetworkServer.Destroy(sack.gameObject);
		}
		else
		{
			sack.transform.SetParent(null);
			sack.ServerStartSplineMove(sackSpline, splineStartT, splineEndT, splineMoveDuration);
			Debug.Log($"T_SortingStation: Sack spline hareketi başlatıldı - Duration: {splineMoveDuration}s");
		}
	}

	public void HandleSortingMachineInteraction()
	{
		if (Interactable == null)
		{
			Debug.LogWarning("T_SortingStation: HandleSortingMachineInteraction - caseInteractable atanmamış! Inspector'dan atayın.");
		}
		else if (Interactable.currentPrimaryState == PrimaryState.Place)
		{
			TryTransferSackFromPlayer();
		}
		else
		{
			Debug.LogWarning($"T_SortingStation: HandleSortingMachineInteraction - Desteklenmeyen PrimaryState: {Interactable.currentPrimaryState}");
		}
	}

	public void SetStorageManager(StorageManager manager)
	{
		storageManager = manager;
	}

	public StorageManager GetStorageManager()
	{
		return storageManager;
	}

	public SplineContainer GetSplineContainer()
	{
		return sackSpline;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(uint sackNetId, NetworkConnectionToClient sender)
	{
		if (sackNetId == 0)
		{
			Debug.LogWarning("T_SortingStation: CmdTransferItemsFromSack - Sack NetId geçersiz!");
			return;
		}
		if (!NetworkServer.spawned.TryGetValue(sackNetId, out var value))
		{
			Debug.LogWarning($"T_SortingStation: CmdTransferItemsFromSack - Sack NetId ({sackNetId}) bulunamadı!");
			return;
		}
		T_Sack component = value.GetComponent<T_Sack>();
		if (component == null)
		{
			Debug.LogWarning("T_SortingStation: CmdTransferItemsFromSack - Bulunan obje T_Sack değil!");
			return;
		}
		if (storageManager == null && GameManager.Instance != null)
		{
			storageManager = GameManager.Instance.storageManager;
		}
		if (storageManager == null)
		{
			Debug.LogWarning("T_SortingStation: CmdTransferItemsFromSack - StorageManager null!");
		}
		else if (TransferItemsFromSack(component) && sender != null)
		{
			RpcClearPlayerPickupItem(sender);
		}
	}

	protected static void InvokeUserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTransferItemsFromSack called on client.");
		}
		else
		{
			((T_SortingStation)obj).UserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient(reader.ReadVarUInt(), senderConnection);
		}
	}

	protected void UserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkConnection target)
	{
		if (GameManager.Instance != null && GameManager.Instance.localEquipments != null)
		{
			GameManager.Instance.localEquipments.ClearPickupItem();
			GameManager.Instance.localEquipments.TryUnequip();
		}
	}

	protected static void InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("TargetRPC RpcClearPlayerPickupItem called on server.");
		}
		else
		{
			((T_SortingStation)obj).UserCode_RpcClearPlayerPickupItem__NetworkConnection(null);
		}
	}

	static T_SortingStation()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(T_SortingStation), "System.Void T_SortingStation::CmdTransferItemsFromSack(System.UInt32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdTransferItemsFromSack__UInt32__NetworkConnectionToClient, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(T_SortingStation), "System.Void T_SortingStation::RpcClearPlayerPickupItem(Mirror.NetworkConnection)", InvokeUserCode_RpcClearPlayerPickupItem__NetworkConnection);
	}
}
