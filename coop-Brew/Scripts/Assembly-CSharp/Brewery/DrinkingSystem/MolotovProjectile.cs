using InventorySystem;
using ParticleEffects;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.DrinkingSystem
{
	[RequireComponent(typeof(Collider))]
	[RequireComponent(typeof(Rigidbody))]
	public class MolotovProjectile : MonoBehaviour
	{
		[Header("Impact Effects")]
		[Tooltip("Particle effect for bottle shatter")]
		[SerializeField]
		private ParticleEffectManager.ParticleType shatterParticle;

		[Tooltip("Particle effect for fiery explosion")]
		[SerializeField]
		private ParticleEffectManager.ParticleType explosionParticle;

		[Header("Detection")]
		[Tooltip("Radius to search for WagonBurnTarget on impact (simulates splash effect)")]
		[SerializeField]
		private float wagonDetectionRadius;

		[Tooltip("Layer mask for wagon detection (leave default for all layers)")]
		[SerializeField]
		private LayerMask wagonDetectionMask;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool hasImpacted;

		private NetworkObject ownerNetObj;

		private Item molotovItem;

		private string molotovItemId;

		private bool IsServer => false;

		public void Configure(ParticleEffectManager.ParticleType shatter, ParticleEffectManager.ParticleType explosion)
		{
		}

		public void SetOwner(NetworkObject owner)
		{
		}

		public void SetItem(Item item)
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void CheckWagonHit(Vector3 impactPoint)
		{
		}
	}
}
