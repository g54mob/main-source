using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Player;
using Unity.Netcode;
using UnityEngine;

namespace Property
{
	[RequireComponent(typeof(NetworkObject))]
	public class PropertyManager : NetworkBehaviour, ISaveable
	{
		public const ulong NO_OWNER = ulong.MaxValue;

		public const float SECONDS_PER_RENT_DAY = 1440f;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public NetworkList<HouseOwnership> HouseOwnerships;

		private Dictionary<string, HouseData> houseDataLookup;

		public static PropertyManager Instance { get; private set; }

		public int OwnedHouseCount => 0;

		public bool IsRestoringState { get; private set; }

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<string, ulong> OnHousePurchased
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

		public event Action<string, string> OnHouseRentedToVisitor
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

		public event Action<string, int, ulong> OnRentCollected
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

		public new event Action OnOwnershipChanged
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

		public event Action<string, ulong> OnOwnershipChanged_Detailed
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

		public static event Action<bool, string, int, bool> OnHaggleResult
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

		public static event Action<bool, string, int> OnRentCollectionResult
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

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void BuildHouseLookup()
		{
		}

		private void InitializeServer()
		{
		}

		private void OnHouseOwnershipListChanged(NetworkListEvent<HouseOwnership> changeEvent)
		{
		}

		public HouseData GetHouseData(string houseId)
		{
			return null;
		}

		public IReadOnlyList<HouseData> GetAllHouseData()
		{
			return null;
		}

		public HouseOwnership? GetOwnership(string houseId)
		{
			return null;
		}

		public (ulong, bool) GetHouseOwnership(string houseId)
		{
			return default((ulong, bool));
		}

		public bool IsHouseAvailable(string houseId)
		{
			return false;
		}

		public bool IsHouseOwnedBy(string houseId, ulong playerId)
		{
			return false;
		}

		public bool IsHouseOwned(string houseId)
		{
			return false;
		}

		public bool IsHouseRented(string houseId)
		{
			return false;
		}

		public List<HouseData> GetPlayerOwnedHouses(ulong playerId)
		{
			return null;
		}

		public List<(HouseData, string)> GetOccupiedHouses()
		{
			return null;
		}

		public List<HouseData> GetHousesForSale(ulong playerId)
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		public void PurchaseHouseServerRpc(string houseId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void PurchaseResultClientRpc(bool success, string message, string houseId, ulong targetClientId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void MakeRentOfferServerRpc(string houseId, string visitorNpcId, int offerRent, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void HaggleResultClientRpc(bool success, string message, int salePrice, bool visitorWillReturn, ulong targetClientId)
		{
		}

		public void SetHouseOccupiedForTesting(string houseId, string residentNpcId)
		{
		}

		private void UpdateOwnership(string houseId, ulong ownerId, bool isOccupied, string residentNpcId, int negotiatedDailyRent = 0, double rentStartRealTime = 0.0, double lastCollectedRealTime = 0.0)
		{
		}

		public bool ValidateHouseFurniture(string houseId)
		{
			return false;
		}

		public int GetCorrectFurnitureCount(string houseId)
		{
			return 0;
		}

		public static double GetCurrentRealTime()
		{
			return 0.0;
		}

		public int CalculateRentDays(string houseId)
		{
			return 0;
		}

		public int CalculateAccumulatedRent(string houseId)
		{
			return 0;
		}

		public float GetSecondsUntilNextRent(string houseId)
		{
			return 0f;
		}

		public int CalculateBaseDailyRent(string houseId)
		{
			return 0;
		}

		public void CollectRentDirect(string houseId, ulong clientId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void CollectRentServerRpc(string houseId, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void CollectRentInternal(string houseId, ulong clientId)
		{
		}

		[ClientRpc]
		private void RentCollectionResultClientRpc(bool success, string message, int rentAmount, ulong targetClientId)
		{
		}

		private void UpdateRentCollectionTime(string houseId)
		{
		}

		private PlayerCurrency GetPlayerCurrency(ulong clientId)
		{
			return null;
		}

		private int GetPlayerMoney(ulong clientId)
		{
			return 0;
		}

		private bool DeductPlayerMoney(ulong clientId, int amount)
		{
			return false;
		}

		private void AddPlayerMoney(ulong clientId, int amount)
		{
		}

		public void DebugLogAllHouses()
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void NotifyAllOwnershipRestored()
		{
		}

		private List<Dictionary<string, object>> ConvertToListOfDictionaries(object obj)
		{
			return null;
		}

		private Dictionary<string, object> ConvertToDictionary(object obj)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_85318599(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_436331142(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3283968952(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2044290452(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1897237513(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_850751596(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
