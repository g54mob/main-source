using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Brewery.Employee.AI;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	[RequireComponent(typeof(NetworkObject))]
	public class BreweryEmployeeManager : NetworkBehaviour, ISaveable
	{
		private const string TAG = "BREW_EMP|MGR";

		[Header("Building")]
		[SerializeField]
		private BreweryBuildingZone buildingZone;

		[Tooltip("Unique ID for this building's employee manager (for save/load)")]
		[SerializeField]
		private string uniqueManagerId;

		[Header("Employee Configuration")]
		[SerializeField]
		private BreweryEmployeeProfileSO[] availableProfiles;

		[Tooltip("Maximum employees that can be hired in this building")]
		[SerializeField]
		private int maxEmployees;

		[Header("Payment Settings")]
		[Tooltip("How often (in days) employees need to be paid")]
		[SerializeField]
		private int paymentIntervalDays;

		[Tooltip("Days after payment due before employee goes on strike")]
		[SerializeField]
		private int gracePeriodDays;

		[Header("Work Schedule")]
		[SerializeField]
		private int workStartHour;

		[SerializeField]
		private int workEndHour;

		[Header("Spawning")]
		[Tooltip("Where employees spawn and walk home to at the end of their shift. Falls back to profile homeId if unset.")]
		[SerializeField]
		private Transform spawnPoint;

		[Header("Idle")]
		[Tooltip("Where employees stand when there is no work. Falls back to building zone position if unset.")]
		[SerializeField]
		private Transform idlePoint;

		[Header("Mastery & Perks")]
		[Tooltip("ScriptableObject with all mastery/perk tuning values. Create via Brewery > Mastery Settings.")]
		[SerializeField]
		private BreweryMasterySettingsSO masterySettings;

		[Header("Catalyst Assignments")]
		[Tooltip("Maximum number of auto-catalyze brew assignments")]
		[SerializeField]
		private int maxCatalystAssignments;

		private NetworkList<BreweryEmployeeSlot> employeeSlots;

		private NetworkList<CatalystAssignment> catalystAssignments;

		private int lastKnownDayIndex;

		public BreweryBuildingZone BuildingZone => null;

		public BreweryEmployeeProfileSO[] AvailableProfiles => null;

		public int MaxEmployees => 0;

		public int WorkStartHour => 0;

		public int WorkEndHour => 0;

		public int PaymentIntervalDays => 0;

		public Vector3 IdlePosition => default(Vector3);

		public int HiredCount => 0;

		public int SlotCount => 0;

		public int MaxCatalystAssignments => 0;

		public int CatalystAssignmentCount => 0;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action OnEmployeesChanged
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

		public event Action OnCatalystAssignmentsChanged
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

		private void InitializeSlots()
		{
		}

		private void Update()
		{
		}

		private void CheckDayChange()
		{
		}

		private void CheckShiftTiming()
		{
		}

		private void SpawnEmployeeNPC(int slotIndex)
		{
		}

		private void SendEmployeeHome(int slotIndex)
		{
		}

		public void OnEmployeeArrivedHome(int slotIndex)
		{
		}

		private void DespawnEmployeeNPC(int slotIndex)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void HireEmployeeServerRpc(int profileIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void FireEmployeeServerRpc(int slotIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void PaySalaryServerRpc(int slotIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void UpgradeEmployeeServerRpc(int slotIndex, int track, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void SelectPerkServerRpc(int slotIndex, byte perkFlag, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void UnequipPerkServerRpc(int slotIndex, byte perkFlag, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ResetSpecializationServerRpc(int slotIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void DebugMaxMasteryServerRpc(int slotIndex)
		{
		}

		public void AwardXP(int slotIndex, BreweryTaskType taskType, BeverageType taskBeverage)
		{
		}

		public BreweryEmployeeSlot GetSlot(int index)
		{
			return default(BreweryEmployeeSlot);
		}

		public BreweryEmployeeProfileSO GetProfile(int profileIndex)
		{
			return null;
		}

		public bool IsProfileHired(int profileIndex)
		{
			return false;
		}

		private void OnSlotsChanged(NetworkListEvent<BreweryEmployeeSlot> changeEvent)
		{
		}

		private void OnAssignmentsChanged(NetworkListEvent<CatalystAssignment> changeEvent)
		{
		}

		public CatalystAssignment GetCatalystAssignment(int index)
		{
			return default(CatalystAssignment);
		}

		public List<CatalystAssignment> GetActiveCatalystAssignments()
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		public void AddCatalystAssignmentServerRpc(BaseType baseType, FixedString32Bytes cat1, FixedString32Bytes cat2, FixedString32Bytes cat3, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RemoveCatalystAssignmentServerRpc(int index, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ToggleCatalystAssignmentServerRpc(int index, ServerRpcParams rpcParams = default(ServerRpcParams))
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

		private static void __rpc_handler_1009011327(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2896742141(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_746989129(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_517228768(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3132623846(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3751976709(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3211551886(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2770471151(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1520463116(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3097959944(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4192665453(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
