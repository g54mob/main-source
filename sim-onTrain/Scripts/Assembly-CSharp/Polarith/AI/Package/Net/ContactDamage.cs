using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Package.Net
{
	[AddComponentMenu("Polarith AI » Examples/Network/Contact Damage")]
	public sealed class ContactDamage : MonoBehaviour
	{
		[Tooltip("The amount of damage that applied to the othe EntityInfo. A positive value means damage, a negative value would heal the other entity.")]
		public float Amount;

		[Tooltip("Only other colliders with this material are considered as valid targets. Using a material instead of the collision matrix is a workaround. We have to do this because we cannot work with Tags and Layers for a package project.")]
		public List<PhysicsMaterial2D> TargetMaterials;

		[Tooltip("A template that is spawned when the collider hit something, e.g. a particle system.")]
		public GameObject HitParticles;

		[Tooltip("A template that is spawned when the other EntityInfo is destroyed, e.g. a particle system.")]
		public GameObject Deathparticles;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (!TargetMaterials.Contains(collision.sharedMaterial))
			{
				return;
			}
			EntityInfo component = collision.GetComponent<EntityInfo>();
			if (component != null)
			{
				if (component.CurrentHitpoints - Amount <= 0f && Deathparticles != null)
				{
					Object.Instantiate(Deathparticles).transform.position = base.transform.position;
				}
				component.TakeDamge(Amount);
			}
			if (HitParticles != null)
			{
				Object.Instantiate(HitParticles).transform.position = base.transform.position;
			}
			Object.Destroy(base.gameObject);
		}
	}
}
