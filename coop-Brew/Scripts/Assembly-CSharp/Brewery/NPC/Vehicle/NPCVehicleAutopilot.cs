using System.Collections.Generic;
using Ezereal;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace Brewery.NPC.Vehicle
{
	[RequireComponent(typeof(EzerealCarController))]
	public class NPCVehicleAutopilot : NetworkBehaviour, IEzerealVehicleInputSource
	{
		[Header("Pathfinding")]
		[SerializeField]
		private int navMeshAreaMask;

		[SerializeField]
		private float waypointTolerance;

		[SerializeField]
		private float maxPlanDistance;

		[Header("Driving")]
		[SerializeField]
		private float desiredCruiseSpeed;

		[SerializeField]
		private float brakingDistance;

		[SerializeField]
		private float steeringResponsiveness;

		[SerializeField]
		private float cornerSlowdownAngle;

		[SerializeField]
		private float reverseThreshold;

		[Header("Debug")]
		[SerializeField]
		private bool drawPath;

		private EzerealCarController carController;

		private readonly NavMeshPath navPath;

		private readonly List<Vector3> waypoints;

		private int currentWaypointIndex;

		private float throttle;

		private float brake;

		private float handbrake;

		private float steering;

		private bool wantsReverse;

		private bool wantsEngineOn;

		private Vector3 _lastDestination;

		private float _lastPathCalculationTime;

		private const float PATH_RECALC_COOLDOWN = 0.5f;

		private const float DESTINATION_TOLERANCE = 1.5f;

		public bool WantsEngineOn => false;

		public bool WantsReverse => false;

		public float Throttle => 0f;

		public float Brake => 0f;

		public float Handbrake => 0f;

		public float Steering => 0f;

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

		private void UpdateDrivingLogic(float deltaTime)
		{
		}

		public bool SetDestination(Vector3 destination)
		{
			return false;
		}

		public bool HasDestination()
		{
			return false;
		}

		public void ClearDestination()
		{
		}

		public bool IsAtDestination()
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
