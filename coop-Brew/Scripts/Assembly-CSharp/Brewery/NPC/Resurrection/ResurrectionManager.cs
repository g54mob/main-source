using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.NPC.Resurrection
{
	[RequireComponent(typeof(NetworkObject))]
	public class ResurrectionManager : NetworkBehaviour, ISaveable
	{
		private static ResurrectionManager _instance;

		[Header("Configuration")]
		[Tooltip("Resurrection cost and timing configuration.")]
		[SerializeField]
		private ResurrectionConfig config;

		[Header("Cemetery")]
		[Tooltip("Pre-placed grave objects in the cemetery scene. Order determines assignment priority.")]
		[SerializeField]
		private GraveController[] graves;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkList<DeadNPCEntry> deadNPCs;

		private NetworkVariable<bool> ceremonyActive;

		private NetworkVariable<int> syncedTotalResurrections;

		private readonly Dictionary<string, int> deadNpcIndexMap;

		private readonly HashSet<int> occupiedGraves;

		private readonly List<string> ceremonyQueue;

		private ulong ceremonyInitiatorClientId;

		private int totalResurrectionsCompleted;

		public static ResurrectionManager Instance => null;

		public string SaveableId => null;

		public int SavePriority => 0;

		public int DeadNPCCount => 0;

		public bool IsCeremonyActive => false;

		public ResurrectionConfig Config => null;

		public int TotalResurrectionsCompleted => 0;

		public event Action<string, int> OnNPCDied
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

		public event Action<string, int> OnNPCResurrected
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

		public event Action OnDeadNPCListChanged
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

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void Awake()
		{
		}

		public new void OnDestroy()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		public void RegisterDeath(string npcId, string displayName)
		{
		}

		private int FindNextAvailableGrave()
		{
			return 0;
		}

		public bool IsNPCDead(string npcId)
		{
			return false;
		}

		public List<DeadNPCEntry> GetDeadNPCs()
		{
			return null;
		}

		public float GetTotalMoneyCost(int count)
		{
			return 0f;
		}

		public int GetTotalWineCost(int count)
		{
			return 0;
		}

		public float GetMoneyCostForNPC(int queueIndex)
		{
			return 0f;
		}

		public int GetWineCostForNPC(int queueIndex)
		{
			return 0;
		}

		public GraveController GetGrave(int graveIndex)
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestResurrectionServerRpc(FixedString64Bytes[] npcIds, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private int CalculateMaxAffordable(float availableMoney, int availableWine, int startTier, int maxCount)
		{
			return 0;
		}

		public int GetMaxAffordableCount(float availableMoney, int availableWine, int maxCount)
		{
			return 0;
		}

		public void CompleteResurrection(string npcId)
		{
		}

		public void CompleteCeremony()
		{
		}

		public IReadOnlyList<string> GetCeremonyQueue()
		{
			return null;
		}

		private void RespawnNPC(string npcId, int graveIndex)
		{
		}

		private void RebuildIndexMap()
		{
		}

		private void HandleDeadNPCListChanged(NetworkListEvent<DeadNPCEntry> changeEvent)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2046576339(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
