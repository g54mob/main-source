using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Player;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(NetworkObject))]
	public class StandUpgradeManager : NetworkBehaviour, ISaveable
	{
		[Header("Upgrade Configuration")]
		[Tooltip("Upgrade definitions in sequential order")]
		[SerializeField]
		private StandUpgradeData[] upgradeData;

		[Tooltip("Visual GameObjects activated per upgrade (parallel array with upgradeData)")]
		[SerializeField]
		private GameObject[] upgradeVisuals;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<int> _purchasedCount;

		private float _totalPatienceMultiplier;

		private float _totalPriceMultiplier;

		private int _totalShelfCapacityBonus;

		private float _totalDetectionRadiusBonus;

		private int _totalMaxQueueLengthBonus;

		private float _totalVisitChanceBonus;

		private float _extendedHoursUntil;

		private bool _vipCustomersEnabled;

		public int PurchasedCount => 0;

		public int TotalUpgrades => 0;

		public bool CanUpgrade => false;

		public float TotalPatienceMultiplier => 0f;

		public float TotalPriceMultiplier => 0f;

		public int TotalShelfCapacityBonus => 0;

		public float TotalDetectionRadiusBonus => 0f;

		public int TotalMaxQueueLengthBonus => 0;

		public float TotalVisitChanceBonus => 0f;

		public float ExtendedHoursUntil => 0f;

		public bool VIPCustomersEnabled => false;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<int> OnUpgradePurchased
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

		public event Action OnUpgradeCountChanged
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

		public StandUpgradeData GetNextUpgrade()
		{
			return null;
		}

		public int GetNextUpgradeCost()
		{
			return 0;
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void HandleUpgradeCountChanged(int oldValue, int newValue)
		{
		}

		private void SpawnUpgradeEffect(int upgradeIndex)
		{
		}

		private void PopUpgradeVisual(int upgradeIndex)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestUpgradeServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private PlayerCurrency GetPlayerCurrency(ulong clientId)
		{
			return null;
		}

		private void ApplyUpgradeState(int upgradeCount)
		{
		}

		private void ApplyStatsToManagers()
		{
		}

		[ClientRpc]
		private void NotifyUpgradeSuccessClientRpc(string upgradeName, int index)
		{
		}

		[ClientRpc]
		private void NotifyUpgradeFailedClientRpc(ulong targetClientId)
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

		private static void __rpc_handler_1184627450(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1884012444(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_384097302(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
