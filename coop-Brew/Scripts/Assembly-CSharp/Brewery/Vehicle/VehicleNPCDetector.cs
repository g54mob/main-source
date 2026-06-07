using System.Collections.Generic;
using Brewery.NPC;
using Ezereal;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Vehicle
{
	public class VehicleNPCDetector : MonoBehaviour
	{
		[Header("Detection")]
		[Tooltip("Minimum vehicle speed (m/s) to trigger NPC ragdoll")]
		[SerializeField]
		private float minSpeedToTrigger;

		[Tooltip("Cooldown before the same NPC can be hit again (seconds)")]
		[SerializeField]
		private float hitCooldown;

		[Header("Impact")]
		[Tooltip("Force multiplier applied to ragdoll based on vehicle velocity")]
		[SerializeField]
		private float impactForceMultiplier;

		[Tooltip("Additional upward force for dramatic effect")]
		[SerializeField]
		private float upwardForceBonus;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Rigidbody vehicleRigidbody;

		private Collider triggerCollider;

		private NetworkObject vehicleNetworkObject;

		private HashSet<Collider> npcsInZone;

		private Dictionary<GameObject, float> recentlyHitNPCs;

		private IVehicleController cachedVehicleController;

		private EzerealCarController cachedCarController;

		private void Awake()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerStay(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private void TryHitNPC(Collider other)
		{
		}

		private NPCVehicleCollisionHandler FindNPCCollisionHandler(Collider col)
		{
			return null;
		}

		private bool GetHasDriver()
		{
			return false;
		}

		private void Update()
		{
		}
	}
}
