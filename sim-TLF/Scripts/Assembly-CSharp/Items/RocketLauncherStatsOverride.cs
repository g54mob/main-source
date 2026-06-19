using System;
using UnityEngine;

namespace Items
{
	[Serializable]
	public class RocketLauncherStatsOverride
	{
		[Tooltip("If false, this weapon uses the launcher's existing stats unchanged.")]
		public bool overrideStats = true;

		[Header("Projectile")]
		[Tooltip("Override projectile prefab. Leave null to keep launcher's current prefab.")]
		public GameObject projectilePrefab;

		[Range(10f, 500f)]
		public float initialSpeed = 80f;

		[Range(0.1f, 50f)]
		public float projectileMass = 1f;

		[Range(0f, 5f)]
		public float gravityScale = 1f;

		[Range(0f, 5f)]
		public float airDrag = 0.05f;

		[Range(0f, 5f)]
		public float angularDrag = 0.5f;

		[Header("Explosion (on launcher; used if launcher passes them to projectile)")]
		[Range(1f, 50f)]
		public float explosionRadius = 8f;

		[Range(100f, 10000f)]
		public float explosionForce = 1500f;

		[Tooltip("Override explosion VFX prefab. Leave null to keep launcher's current one.")]
		public GameObject explosionEffectPrefab;

		[Header("Fire")]
		[Range(0f, 5f)]
		public float fireRate = 0.8f;
	}
}
