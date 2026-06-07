using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	[RequireComponent(typeof(NetworkObject))]
	public class EmployeeManager : NetworkBehaviour, ISaveable
	{
		[Header("Employee Configuration")]
		[Tooltip("Assign Employee ScriptableObject profiles. Schedules are selected at hire time.")]
		[SerializeField]
		private EmployeeScriptableObject[] employeeProfiles;

		[Header("Wage Settings")]
		[Tooltip("Days unpaid before employee quits")]
		[SerializeField]
		private int daysUntilQuit;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkList<EmployeeSlot> employeeSlots;

		private int lastKnownDayIndex;

		private static Dictionary<string, EmployeeHomePoint> homePoints;

		public static EmployeeManager Instance { get; private set; }

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action OnEmployeeHired
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

		public event Action OnEmployeeFired
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

		public event Action OnEmployeeSalaryChanged
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

		public event Action OnEmployeeQuit
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

		private void Update()
		{
		}

		private void CheckEmployeeSpawning()
		{
		}

		public static void RegisterHomePoint(EmployeeHomePoint point)
		{
		}

		public static void UnregisterHomePoint(EmployeeHomePoint point)
		{
		}

		private EmployeeHomePoint GetHomePoint(string homeId)
		{
			return null;
		}

		private void InitializeEmployeeSlots()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void HireEmployeeServerRpc(int slotIndex, ulong clientId, ulong barNetworkId, int shiftStartHour, int shiftEndHour)
		{
		}

		[ClientRpc]
		private void NotifyHireFailedClientRpc(ulong targetClientId, string reason)
		{
		}

		[ClientRpc]
		private void NotifyHireSuccessClientRpc(ulong targetClientId, string employeeName, int shiftStart, int shiftEnd)
		{
		}

		[ClientRpc]
		private void NotifyEmployeeQuitClientRpc(string employeeName, int daysUnpaid)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void FireEmployeeServerRpc(int slotIndex, ulong clientId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void PaySalaryServerRpc(int slotIndex, ulong clientId)
		{
		}

		private void OnDayChanged()
		{
		}

		private void SpawnEmployeeNPC(int slotIndex)
		{
		}

		private void DespawnEmployeeNPC(int slotIndex)
		{
		}

		public void DespawnEmployeeAtHome(int slotIndex)
		{
		}

		public EmployeeSlot[] GetAllEmployeeSlots()
		{
			return null;
		}

		public EmployeeSlot GetEmployeeSlot(int slotIndex)
		{
			return default(EmployeeSlot);
		}

		public bool IsEmployeeWorking(int slotIndex)
		{
			return false;
		}

		public Transform GetEmployeeHomeLocation(int slotIndex)
		{
			return null;
		}

		public EmployeeScriptableObject GetEmployeeProfile(int slotIndex)
		{
			return null;
		}

		public float GetSalaryForSchedule(int slotIndex, int shiftStartHour)
		{
			return 0f;
		}

		public float GetCurrentServingTime()
		{
			return 0f;
		}

		public bool IsScheduleTakenAtBar(ulong barNetworkId, int shiftStartHour)
		{
			return false;
		}

		private Transform GetWorkZoneForEmployee(EmployeeSlot slot)
		{
			return null;
		}

		private bool IsShiftActive(int currentHour, int shiftStart, int shiftEnd)
		{
			return false;
		}

		[ContextMenu("Validate All Employee States")]
		public void ValidateEmployeeStates()
		{
		}

		[ContextMenu("Debug: Force Reset All Employees")]
		public void ForceResetAllEmployees()
		{
		}

		public void ForceResetEmployee(int slotIndex)
		{
		}

		private void OnEmployeeSlotsChanged(NetworkListEvent<EmployeeSlot> changeEvent)
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

		private static void __rpc_handler_1158197798(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3176491756(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_467379096(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3062897064(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3130359887(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_656738623(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
