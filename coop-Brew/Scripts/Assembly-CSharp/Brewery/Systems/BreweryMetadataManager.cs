using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Brewery.Items;
using Brewery.Stations;
using Brewery.Systems.Processing;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Systems
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class BreweryMetadataManager : NetworkBehaviour, ISaveable
	{
		private static BreweryMetadataManager instance;

		private static readonly HashSet<VehicleBedItemDisplay> _registeredDisplays;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Update Settings")]
		[SerializeField]
		private float updateIntervalSeconds;

		[SerializeField]
		private float worldCheckIntervalSeconds;

		[Header("Fermentation Settings")]
		[SerializeField]
		private float fermentationDurationSeconds;

		[SerializeField]
		private float wineAgingDurationSeconds;

		[SerializeField]
		private float spoilDurationSeconds;

		private readonly Dictionary<MetadataKey, BarrelMetadata> barrelMetadata;

		private readonly Dictionary<MetadataKey, WineProcessMetadata> wineProcessMetadata;

		private readonly Dictionary<MetadataKey, SpiritsProcessMetadata> spiritsProcessMetadata;

		private readonly Dictionary<MetadataKey, CrateMetadata> crateMetadata;

		private readonly Dictionary<MetadataKey, double> fermentationTargets;

		private readonly Dictionary<MetadataKey, double> wineAgingTargets;

		private readonly Dictionary<MetadataKey, BoilingProcessMetadata> boilingProcessData;

		private readonly Dictionary<ProcessMetadataKey, object> genericProcessMetadata;

		private readonly Dictionary<ulong, StationUpgradeData> stationUpgradeData;

		private readonly Dictionary<MetadataKey, double> spoilTargets;

		private readonly List<MetadataKey> fermentationScratch;

		private readonly List<MetadataKey> wineAgingScratch;

		private readonly List<MetadataKey> spoilScratch;

		private readonly List<BarrelItemData> worldBarrels;

		private readonly Dictionary<CrateItemMetadataKey, BeerDataSnapshot> crateItemBeverageMetadata;

		private readonly Dictionary<CrateItemMetadataKey, BarrelMetadata> crateItemBarrelMetadata;

		private readonly Dictionary<string, BoilingProcessMetadata> pendingBoilingMetadata;

		private readonly Dictionary<string, SpiritsProcessMetadata> pendingSpiritsMetadata;

		private readonly Dictionary<string, WineProcessMetadata> pendingWineMetadata;

		private double nextInventoryUpdate;

		private double nextWorldUpdate;

		public float FermentationDurationSeconds => 0f;

		public float WineAgingDurationSeconds => 0f;

		public float SpoilDurationSeconds => 0f;

		public static BreweryMetadataManager Instance => null;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<ulong, int, InventoryType> OnCrateMetadataChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ulong, int, int, InventoryType> OnCrateItemBeverageMetadataChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void RegisterDisplay(VehicleBedItemDisplay display)
		{
		}

		public static void UnregisterDisplay(VehicleBedItemDisplay display)
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		private Dictionary<ulong, string> BuildNetworkIdToStationIdLookup()
		{
			return null;
		}

		private Dictionary<string, ulong> BuildStationIdToNetworkIdLookup()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void ClearNonPlayerCrateMetadata()
		{
		}

		private void ClearNonPlayerCrateItemBeverageMetadata()
		{
		}

		private void ClearNonPlayerCrateItemBarrelMetadata()
		{
		}

		private List<Dictionary<string, object>> SerializeBarrelMetadata()
		{
			return null;
		}

		private void DeserializeBarrelMetadata(List<object> data)
		{
		}

		private List<Dictionary<string, object>> SerializeCrateMetadata()
		{
			return null;
		}

		private void DeserializeCrateMetadata(List<object> data)
		{
		}

		private List<Dictionary<string, object>> SerializeFermentationTargets()
		{
			return null;
		}

		private void DeserializeFermentationTargets(List<object> data)
		{
		}

		private List<Dictionary<string, object>> SerializeWineAgingTargets()
		{
			return null;
		}

		private void DeserializeWineAgingTargets(List<object> data)
		{
		}

		private List<Dictionary<string, object>> SerializeSpoilTargets()
		{
			return null;
		}

		private void DeserializeSpoilTargets(List<object> data)
		{
		}

		private List<Dictionary<string, object>> SerializeWineProcessMetadata(Dictionary<ulong, string> networkIdToStationId)
		{
			return null;
		}

		private void DeserializeWineProcessMetadata(List<object> data, Dictionary<string, ulong> stationIdToNetworkId)
		{
		}

		private List<Dictionary<string, object>> SerializeSpiritsProcessMetadata(Dictionary<ulong, string> networkIdToStationId)
		{
			return null;
		}

		private void DeserializeSpiritsProcessMetadata(List<object> data, Dictionary<string, ulong> stationIdToNetworkId)
		{
		}

		private List<Dictionary<string, object>> SerializeBoilingProcessMetadata(Dictionary<ulong, string> networkIdToStationId)
		{
			return null;
		}

		private void DeserializeBoilingProcessMetadata(List<object> data, Dictionary<string, ulong> stationIdToNetworkId)
		{
		}

		private List<Dictionary<string, object>> SerializeCrateItemBeverageMetadata()
		{
			return null;
		}

		private void DeserializeCrateItemBeverageMetadata(List<object> data)
		{
		}

		private List<Dictionary<string, object>> SerializeCrateItemBarrelMetadata()
		{
			return null;
		}

		private void DeserializeCrateItemBarrelMetadata(List<object> data)
		{
		}

		private bool TryGetNetworkObjectOwnerClientId(ulong networkObjectId, out ulong clientId)
		{
			clientId = default(ulong);
			return false;
		}

		private void Awake()
		{
		}

		public override void OnDestroy()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public bool TryGetStationUpgradeData(ulong stationNetworkObjectId, out StationUpgradeData data)
		{
			data = default(StationUpgradeData);
			return false;
		}

		public StationUpgradeData GetStationUpgradeData(ulong stationNetworkObjectId)
		{
			return default(StationUpgradeData);
		}

		public void SetStationUpgradeData(ulong stationNetworkObjectId, StationUpgradeData data)
		{
		}

		public void RemoveStationUpgradeData(ulong stationNetworkObjectId)
		{
		}

		public bool TryGetProcessMetadata<TStep>(ulong stationId, string key, out ProcessMetadata<TStep> metadata) where TStep : struct, Enum
		{
			metadata = default(ProcessMetadata<TStep>);
			return false;
		}

		public ProcessMetadata<TStep> GetProcessMetadata<TStep>(ulong stationId, string key) where TStep : struct, Enum
		{
			return default(ProcessMetadata<TStep>);
		}

		public void SetProcessMetadata<TStep>(ulong stationId, string key, ProcessMetadata<TStep> metadata) where TStep : struct, Enum
		{
		}

		public void ClearProcessMetadata<TStep>(ulong stationId, string key) where TStep : struct, Enum
		{
		}

		public void ClearAllStationUpgradeData()
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		[ClientRpc]
		private void RefreshVehicleDisplaysClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void Update()
		{
		}

		public static BarrelMetadata AdjustTimestampsForLoad(BarrelMetadata meta, double savedServerTime)
		{
			return default(BarrelMetadata);
		}

		public void SetBarrelMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, BarrelMetadata metadata)
		{
		}

		public bool TryGetBarrelMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public bool TryGetStationOutputBarrelMetadata(ulong stationNetworkObjectId, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public void RemoveBarrelMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public void StartBarrelFermentation(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public void StartWineAging(ulong ownerId, int slotIndex, InventoryType inventoryType, int initialBottleCount)
		{
		}

		public void SetSpiritsReady(ulong ownerId, int slotIndex, InventoryType inventoryType, int bottleCount)
		{
		}

		private void EnsureFermentationTimer(MetadataKey key, BarrelMetadata metadata)
		{
		}

		private void EnsureWineAgingTimer(MetadataKey key, BarrelMetadata metadata)
		{
		}

		private void ProcessInventoryFermentations(double now)
		{
		}

		private void ProcessInventoryWineAging(double now)
		{
		}

		private void ProcessInventorySpoilage(double now)
		{
		}

		public void UpdateEmbeddedBarrelMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, BarrelMetadata metadata)
		{
		}

		private void UpdateEmbeddedSlotBarrelMetadata(MetadataKey key, BarrelMetadata updatedMetadata)
		{
		}

		private void UpdateEmbeddedSlotBarrelMetadataNoSync(MetadataKey key, BarrelMetadata updatedMetadata)
		{
		}

		private void NotifyFermentationComplete(MetadataKey key)
		{
		}

		[ClientRpc]
		private void NotifyFermentationCompleteClientRpc(ulong ownerId, int slotIndex, int inventoryType, BarrelMetadata metadata)
		{
		}

		private void NotifyWineAgingComplete(MetadataKey key)
		{
		}

		[ClientRpc]
		private void NotifyWineAgingCompleteClientRpc(ulong ownerId, int slotIndex, int inventoryType, BarrelMetadata metadata)
		{
		}

		private void NotifySpoilageComplete(MetadataKey key)
		{
		}

		[ClientRpc]
		private void NotifySpoilageCompleteClientRpc(ulong ownerId, int slotIndex, int inventoryType, BeverageType beverageType)
		{
		}

		[ClientRpc]
		private void SyncBarrelMetadataToClientRpc(ulong ownerId, int slotIndex, int inventoryType, BarrelMetadata metadata, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void UpdateLocalSlotBarrelMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, BarrelMetadata metadata)
		{
		}

		public void SyncBarrelMetadataToOwner(ulong inventoryNetworkObjectId, int slotIndex, InventoryType inventoryType, BarrelMetadata metadata)
		{
		}

		public void SetBoilingMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, BoilingProcessMetadata metadata)
		{
		}

		public bool TryGetBoilingMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, out BoilingProcessMetadata metadata)
		{
			metadata = default(BoilingProcessMetadata);
			return false;
		}

		public void RemoveBoilingMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public void StartBoilingProcess(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public bool TryGetWineMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, out WineProcessMetadata metadata)
		{
			metadata = default(WineProcessMetadata);
			return false;
		}

		public void SetWineMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, WineProcessMetadata metadata)
		{
		}

		public void RemoveWineMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public WineProcessMetadata StartWineProcess(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
			return default(WineProcessMetadata);
		}

		public bool TryGetSpiritsMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, out SpiritsProcessMetadata metadata)
		{
			metadata = default(SpiritsProcessMetadata);
			return false;
		}

		public void SetSpiritsMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, SpiritsProcessMetadata metadata)
		{
		}

		public void RemoveSpiritsMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public SpiritsProcessMetadata StartSpiritsProcess(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
			return default(SpiritsProcessMetadata);
		}

		public void ApplyPendingMetadataForStation(string stationId, ulong networkObjectId)
		{
		}

		public void SetCrateMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, CrateMetadata metadata)
		{
		}

		public bool TryGetCrateMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType, out CrateMetadata metadata)
		{
			metadata = default(CrateMetadata);
			return false;
		}

		public void RemoveCrateMetadata(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public CrateMetadata CreateEmptyCrate(ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
			return default(CrateMetadata);
		}

		[ClientRpc]
		private void SyncCrateMetadataToClientRpc(ulong ownerId, int slotIndex, int inventoryType, CrateMetadata metadata, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public void SyncCrateMetadataToOwner(ulong inventoryNetworkObjectId, int slotIndex, InventoryType inventoryType, CrateMetadata metadata)
		{
		}

		public void SetCrateItemBeverageMetadata(CrateItemMetadataKey key, BeerDataSnapshot snapshot)
		{
		}

		public void SetCrateItemBeverageMetadata(ulong ownerId, int containerSlot, InventoryType inventoryType, int itemSlotInCrate, BeerDataSnapshot snapshot)
		{
		}

		public bool TryGetCrateItemBeverageMetadata(CrateItemMetadataKey key, out BeerDataSnapshot snapshot)
		{
			snapshot = default(BeerDataSnapshot);
			return false;
		}

		public bool TryGetCrateItemBeverageMetadata(ulong ownerId, int containerSlot, InventoryType inventoryType, int itemSlotInCrate, out BeerDataSnapshot snapshot)
		{
			snapshot = default(BeerDataSnapshot);
			return false;
		}

		public void RemoveCrateItemBeverageMetadata(CrateItemMetadataKey key)
		{
		}

		public void RemoveCrateItemBeverageMetadata(ulong ownerId, int containerSlot, InventoryType inventoryType, int itemSlotInCrate)
		{
		}

		public void SetCrateItemBarrelMetadata(CrateItemMetadataKey key, BarrelMetadata metadata)
		{
		}

		public void SetCrateItemBarrelMetadata(ulong ownerId, int containerSlot, InventoryType inventoryType, int itemSlotInCrate, BarrelMetadata metadata)
		{
		}

		public bool TryGetCrateItemBarrelMetadata(CrateItemMetadataKey key, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public bool TryGetCrateItemBarrelMetadata(ulong ownerId, int containerSlot, InventoryType inventoryType, int itemSlotInCrate, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public void RemoveCrateItemBarrelMetadata(CrateItemMetadataKey key)
		{
		}

		public void RemoveCrateItemBarrelMetadata(ulong ownerId, int containerSlot, InventoryType inventoryType, int itemSlotInCrate)
		{
		}

		public void ClearAllCrateItemMetadata(ulong ownerId, int containerSlot, InventoryType inventoryType)
		{
		}

		public void TransferCrateItemMetadata(ulong sourceOwnerId, int sourceContainerSlot, InventoryType sourceInventoryType, ulong targetOwnerId, int targetContainerSlot, InventoryType targetInventoryType)
		{
		}

		[ClientRpc]
		private void SyncCrateItemBeverageMetadataToClientRpc(ulong ownerId, int containerSlot, int inventoryType, int itemSlotInCrate, BeerDataSnapshot snapshot, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public void SyncCrateItemBeverageMetadataToOwner(ulong inventoryNetworkObjectId, int containerSlot, int itemSlotInCrate, InventoryType inventoryType, BeerDataSnapshot snapshot)
		{
		}

		[ClientRpc]
		private void SyncCrateItemBarrelMetadataToClientRpc(ulong ownerId, int containerSlot, int inventoryType, int itemSlotInCrate, BarrelMetadata metadata, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public void SyncCrateItemBarrelMetadataToOwner(ulong inventoryNetworkObjectId, int containerSlot, int itemSlotInCrate, InventoryType inventoryType, BarrelMetadata metadata)
		{
		}

		public void OnBarrelPickedUp(BarrelItemData barrelData, ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public void OnBarrelDropped(BarrelItemData barrelData, ulong ownerId, int slotIndex, InventoryType inventoryType)
		{
		}

		public void RegisterWorldBarrel(BarrelItemData barrelData)
		{
		}

		public void UnregisterWorldBarrel(BarrelItemData barrelData)
		{
		}

		private void ProcessWorldFermentations(double now)
		{
		}

		private void ProcessWorldWineAging(double now)
		{
		}

		private void ProcessWorldSpoilage(double now)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1431117335(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_31576975(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1035436492(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1095156330(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2959187371(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2222943233(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1144301477(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3339075512(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
