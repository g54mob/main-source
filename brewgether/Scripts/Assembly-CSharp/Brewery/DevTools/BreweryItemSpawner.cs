using System.Collections.Generic;
using Brewery.Core;
using Brewery.Data;
using InventorySystem;
using Player;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.DevTools
{
	public class BreweryItemSpawner : NetworkBehaviour
	{
		private enum ItemType
		{
			PlainBeer = 1,
			CatalyzedBeer = 2,
			PlainWine = 3,
			CatalyzedWine = 4,
			PlainSpirits = 5,
			CatalyzedSpirits = 6,
			Barrel = 7,
			Yeast = 8,
			BoilingStation = 9,
			CornGrinderStation = 10,
			StompingStation = 11,
			WinemakingStation = 12,
			SpiritsStation = 13,
			AutoContinueSensor = 14,
			AutoMaterialSensorKit = 15
		}

		[Header("References")]
		[SerializeField]
		private InventoryManager inventoryManager;

		[Header("Settings")]
		[SerializeField]
		private bool enableDevTools;

		[SerializeField]
		private int plainBeverageQuantity;

		[SerializeField]
		private int resourceQuantity;

		[Header("Item Paths")]
		[SerializeField]
		private string plainBeerPath;

		[SerializeField]
		private string catalyzedBeerPath;

		[SerializeField]
		private string plainWinePath;

		[SerializeField]
		private string catalyzedWinePath;

		[SerializeField]
		private string plainSpiritsPath;

		[SerializeField]
		private string catalyzedSpiritsPath;

		[Header("Random Catalysts for Catalyzed Items")]
		[SerializeField]
		private List<CatalystData> availableCatalysts;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestSpawnItemServerRpc(int itemType, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private InventoryManager GetInventoryForClient(ulong clientId)
		{
			return null;
		}

		private void SpawnPlainBeer(InventoryManager targetInventory)
		{
		}

		private void SpawnPlainWine(InventoryManager targetInventory)
		{
		}

		private void SpawnPlainSpirits(InventoryManager targetInventory)
		{
		}

		private void SpawnCatalyzedBeer(InventoryManager targetInventory)
		{
		}

		private void SpawnCatalyzedWine(InventoryManager targetInventory)
		{
		}

		private void SpawnCatalyzedSpirits(InventoryManager targetInventory)
		{
		}

		private void SpawnCatalyzedBeverage(InventoryManager targetInventory, string resourcePath, string registryId, BaseType baseType, string itemTypeName)
		{
		}

		private List<CatalystData> GenerateRandomCatalysts()
		{
			return null;
		}

		private void SpawnBarrel(InventoryManager targetInventory)
		{
		}

		private void SetEmptyBarrelMetadata(InventoryManager targetInventory)
		{
		}

		private void SpawnYeast(InventoryManager targetInventory)
		{
		}

		private void SpawnResource(InventoryManager targetInventory, string itemId, int quantity)
		{
		}

		private void SpawnStation(InventoryManager targetInventory, string itemId, string displayName)
		{
		}

		private void SpawnSensor(InventoryManager targetInventory, string itemId, string displayName)
		{
		}

		private int FindNewestSlotIndex(InventoryManager inventory, Item item)
		{
			return 0;
		}

		private T LoadItem<T>(string resourcePath, string registryId) where T : Item
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestAddMoneyServerRpc(int amount, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestSetMoneyServerRpc(int amount, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private PlayerCurrency GetPlayerCurrencyForClient(ulong clientId)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3714816818(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3270026511(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3054112768(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
