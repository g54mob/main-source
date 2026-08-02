using JUTPS.ItemSystem;
using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.WeaponSystem
{
	[AddComponentMenu("JU TPS/Weapon System/Granade")]
	public class Granade : ThrowableItem
	{
		[JUHeader("Granade Settings")]
		public GameObject ExplosionPrefab;

		public float TimeToExplode;

		public float TimeToDestroyExplosionPrefab = 5f;

		private float currentTimeToExplode;

		public override void Update()
		{
			base.Update();
			if (IsThrowed)
			{
				currentTimeToExplode += Time.deltaTime;
				if (currentTimeToExplode >= TimeToExplode)
				{
					Object.Destroy(Object.Instantiate(ExplosionPrefab, base.transform.position, Quaternion.identity), TimeToDestroyExplosionPrefab);
					Object.Destroy(base.gameObject);
				}
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
