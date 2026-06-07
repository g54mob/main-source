using UnityEngine;

namespace EpicToonFX
{
	public class ETFXProjectileScript : MonoBehaviour
	{
		public GameObject impactParticle;

		public GameObject projectileParticle;

		public GameObject muzzleParticle;

		[Header("Adjust if not using Sphere Collider")]
		public float colliderRadius;

		[Range(0f, 1f)]
		public float collideOffset;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
