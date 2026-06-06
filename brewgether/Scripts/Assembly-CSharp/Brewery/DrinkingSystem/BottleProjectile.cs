using InventorySystem;
using ParticleEffects;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.DrinkingSystem
{
	[RequireComponent(typeof(Collider))]
	[RequireComponent(typeof(Rigidbody))]
	public class BottleProjectile : MonoBehaviour
	{
		[Tooltip("Primary particle effect on impact (glass shatter)")]
		[SerializeField]
		private ParticleEffectManager.ParticleType impactParticle;

		[Tooltip("Secondary particle effect on impact (e.g. destruction debris)")]
		[SerializeField]
		private ParticleEffectManager.ParticleType secondaryImpactParticle;

		private bool hasSecondaryEffect;

		private bool hasImpacted;

		private NetworkObject ownerNetObj;

		private Item bottleItem;

		private string bottleItemId;

		private bool IsServer => false;

		public void Configure(ParticleEffectManager.ParticleType particleType)
		{
		}

		public void Configure(ParticleEffectManager.ParticleType primaryParticle, ParticleEffectManager.ParticleType secondaryParticle)
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
	}
}
