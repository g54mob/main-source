using System.Collections.Generic;
using Ezereal;
using ParticleEffects;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Destruction
{
	[RequireComponent(typeof(Rigidbody))]
	public class VehicleDestructionHandler : NetworkBehaviour
	{
		[Header("Settings")]
		[Tooltip("Reference to DestroyableSettings ScriptableObject")]
		[SerializeField]
		private DestroyableSettings settings;

		[Header("Collision Detection")]
		[Tooltip("Cooldown between destruction events for the same object (prevents spam)")]
		[SerializeField]
		private float destructionCooldown;

		[Tooltip("Use vehicle velocity for force calculation (vs contact velocity)")]
		[SerializeField]
		private bool useVehicleVelocity;

		[Header("VFX")]
		[Tooltip("Offset VFX along contact normal (pushes effect outside collision point)")]
		[SerializeField]
		private float vfxNormalOffset;

		[Header("Speed Source")]
		[Tooltip("Reference to EzerealCarController for accurate speed readings (optional, falls back to rigidbody)")]
		[SerializeField]
		private EzerealCarController carController;

		private Rigidbody vehicleRigidbody;

		private Dictionary<GameObject, float> lastDestructionTime;

		private Dictionary<string, Queue<GameObject>> vfxPool;

		private void Awake()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private bool IsOnDestroyableLayer(GameObject obj)
		{
			return false;
		}

		private bool IsOnCooldown(GameObject obj)
		{
			return false;
		}

		private GameObject GetDestroyableRoot(GameObject hitObject)
		{
			return null;
		}

		private void ProcessDestructionLocal(GameObject targetObject, Vector3 impactForce, Vector3 impactPoint, Vector3 impactNormal)
		{
		}

		[Rpc(SendTo.Server)]
		private void RequestDestructionRpc(Vector3 objectPosition, Vector3 impactForce, Vector3 impactPoint, Vector3 impactNormal, string tag, RpcParams rpcParams = default(RpcParams))
		{
		}

		[ClientRpc]
		private void BroadcastDestructionClientRpc(Vector3 objectPosition, Vector3 impactForce, Vector3 impactPoint, Vector3 impactNormal, string tag, ulong senderClientId)
		{
		}

		private GameObject FindDestroyableAtPosition(Vector3 position, float searchRadius = 2f)
		{
			return null;
		}

		private void SpawnVFX(string tag, Vector3 contactPoint, Vector3 contactNormal)
		{
		}

		private void PlayBumpAnimation(GameObject targetObject, Vector3 impactForce)
		{
		}

		private ParticleEffectManager.ParticleType GetParticleTypeForTag(string tag)
		{
			return default(ParticleEffectManager.ParticleType);
		}

		private void PlayDestructionSound(string tag, Vector3 position)
		{
		}

		public void TriggerDestruction(GameObject target, Vector3 force)
		{
		}

		public void ClearCooldowns()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4104834612(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3354358495(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
