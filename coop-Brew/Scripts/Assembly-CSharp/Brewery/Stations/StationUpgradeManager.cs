using System.Collections.Generic;
using BrewGame.SaveSystem.Integration;
using Brewery.Systems;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stations
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(BaseBreweryStation))]
	[RequireComponent(typeof(NetworkObject))]
	public class StationUpgradeManager : NetworkBehaviour, ISaveable
	{
		[Header("Upgrade Prefab References")]
		[SerializeField]
		private UpgradePrefabReferences prefabReferences;

		[Header("Sensor Item IDs")]
		[SerializeField]
		private string tier1SensorItemId;

		[SerializeField]
		private string tier2SensorItemId;

		[Header("Debug")]
		[SerializeField]
		private bool logInstallActions;

		private BaseBreweryStation station;

		private BreweryMetadataManager metadataManager;

		private readonly NetworkVariable<bool> tier1Active;

		private readonly NetworkVariable<bool> tier2Active;

		public bool HasTier1Sensor => false;

		public bool HasTier2Sensor => false;

		public string SaveableId => null;

		public int SavePriority => 0;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void LoadUpgradeStateFromMetadata()
		{
		}

		private void HandleTier1StateChanged(bool previous, bool current)
		{
		}

		private void HandleTier2StateChanged(bool previous, bool current)
		{
		}

		private void ApplyPrefabState()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void InstallTier1SensorServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void InstallTier2SensorServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void LoadSensorMaterialServerRpc(string materialItemId, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public StationUpgradeData GetUpgradeData()
		{
			return default(StationUpgradeData);
		}

		public bool TryConsumeSensorMaterial(string materialItemId)
		{
			return false;
		}

		private bool TryGetInventoryForClient(ulong clientId, out InventoryManager inventory)
		{
			inventory = null;
			return false;
		}

		private bool TryConsumeSensorItem(InventoryManager inventory, Item sensorItem, ulong clientId)
		{
			return false;
		}

		[ClientRpc]
		private void SendInstallFailedClientRpc(string message, ulong targetClientId)
		{
		}

		[ClientRpc]
		private void SendUpgradeInstalledClientRpc(int tier)
		{
		}

		[ClientRpc]
		private void SyncSensorInventoryClientRpc(StationUpgradeData data)
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1769024159(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3016242865(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3015572845(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1047297838(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1547589129(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_925278591(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
