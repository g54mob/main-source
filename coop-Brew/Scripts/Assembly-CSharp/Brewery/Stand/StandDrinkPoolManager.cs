using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.Bar.PhysicalServing;
using Brewery.NPC.Simple;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(NetworkObject))]
	public class StandDrinkPoolManager : NetworkBehaviour
	{
		[Header("References")]
		[SerializeField]
		private StandInventoryManager inventoryManager;

		[SerializeField]
		private StandServingManager servingManager;

		[Header("Settings")]
		[Tooltip("How often to recalculate drink assignments (seconds)")]
		[SerializeField]
		private float recalculationInterval;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly List<DrinkPoolEntry> _drinkPool;

		private readonly Dictionary<string, int> _assignedCounts;

		private readonly Dictionary<ulong, DrinkPoolEntry> _npcAssignments;

		private readonly HashSet<ulong> _loggedFailedAssignments;

		private float _nextRecalculationTime;

		private bool _poolDirty;

		public static StandDrinkPoolManager Instance { get; private set; }

		public event Action<Dictionary<ulong, DrinkPoolEntry>> OnAssignmentsChanged
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

		public override void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void MarkPoolDirty()
		{
		}

		private void HandleServingQueueUpdated()
		{
		}

		private void HandleInventoryUpdated()
		{
		}

		private void RebuildDrinkPool()
		{
		}

		private void RecalculateAllAssignments()
		{
		}

		public DrinkPoolEntry FindBestDrinkForNPC(ulong npcNetworkId)
		{
			return default(DrinkPoolEntry);
		}

		private void AutoServeNPC(ulong npcId, DrinkPoolEntry entry)
		{
		}

		[ClientRpc]
		private void PlayBottleClinkClientRpc(Vector3 position)
		{
		}

		[ClientRpc]
		private void RingBellClientRpc()
		{
		}

		public DrinkPoolEntry GetAssignmentForNPC(ulong npcNetworkId)
		{
			return default(DrinkPoolEntry);
		}

		public IReadOnlyDictionary<ulong, DrinkPoolEntry> GetAllAssignments()
		{
			return null;
		}

		public void OnNPCServed(ulong npcNetworkId)
		{
		}

		public void OnNPCReceivedWrongDrink(ulong npcNetworkId)
		{
		}

		private void BroadcastAssignments()
		{
		}

		[ClientRpc]
		private void SyncStandAssignmentsClientRpc(NPCDrinkAssignment[] assignments)
		{
		}

		private SimpleNPCController GetNPCController(ulong npcNetworkId)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4120319786(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3678888374(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1499135520(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
