using Brewery.NPC.Simple;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	[RequireComponent(typeof(AStarNPCMotor))]
	[RequireComponent(typeof(NetworkObject))]
	public class EmployeeNPCController : NetworkBehaviour
	{
		public enum EmployeeState
		{
			AtHome = 0,
			WalkingToWork = 1,
			AtWork = 2,
			WalkingHome = 3
		}

		[Header("Components")]
		[SerializeField]
		private AStarNPCMotor motor;

		[SerializeField]
		private SimpleNPCAnimator npcAnimator;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private EmployeeData employeeData;

		private int slotIndex;

		private int shiftStartHour;

		private int shiftEndHour;

		private Transform workZone;

		private EmployeeState currentState;

		private bool isAtWorkZone;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public void Initialize(EmployeeData data, int startHour, int endHour, Transform workZoneTransform, int slot)
		{
		}

		private void Update()
		{
		}

		private void CheckShiftTiming()
		{
		}

		private bool IsShiftActive(int currentHour)
		{
			return false;
		}

		private void UpdateState()
		{
		}

		private void LeaveForWork()
		{
		}

		private void ArriveAtWork()
		{
		}

		private void EndShift()
		{
		}

		private void StartWalkingHome()
		{
		}

		private void ArriveAtHome()
		{
		}

		private bool HasArrived()
		{
			return false;
		}

		public bool IsWorking()
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
