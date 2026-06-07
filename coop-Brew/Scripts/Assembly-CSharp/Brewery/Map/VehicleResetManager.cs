using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Map
{
	public class VehicleResetManager : NetworkBehaviour
	{
		[Header("Spawn Points")]
		[Tooltip("Assign transforms for reset spawn points (position and rotation are used)")]
		[SerializeField]
		private List<Transform> resetSpawnPoints;

		[Header("Settings")]
		[Tooltip("Radius to check for other vehicles at spawn point")]
		[SerializeField]
		private float occupancyCheckRadius;

		[Tooltip("Layer mask for detecting vehicles")]
		[SerializeField]
		private LayerMask vehicleLayerMask;

		[Tooltip("Height offset when spawning vehicle")]
		[SerializeField]
		private float spawnHeightOffset;

		[Header("Gizmo Settings")]
		[Tooltip("Size of the vehicle preview box in gizmos")]
		[SerializeField]
		private Vector3 vehicleGizmoSize;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public static VehicleResetManager Instance { get; private set; }

		private void Awake()
		{
		}

		public override void OnDestroy()
		{
		}

		public Transform GetNearestAvailableSpawnPoint(Vector3 fromPosition)
		{
			return null;
		}

		private bool IsSpawnPointOccupied(Transform spawnPoint)
		{
			return false;
		}

		[Rpc(SendTo.Server)]
		public void RequestVehicleResetRpc(ulong vehicleNetworkId, RpcParams rpcParams = default(RpcParams))
		{
		}

		[ClientRpc]
		private void NotifyVehicleResetResultClientRpc(ulong targetClientId, bool success, string vehicleName, string failReason)
		{
		}

		private string GetVehicleDisplayName(NetworkObject vehicleNetObj)
		{
			return null;
		}

		public int GetSpawnPointCount()
		{
			return 0;
		}

		public int GetAvailableSpawnPointCount()
		{
			return 0;
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1958043186(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2447662334(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
