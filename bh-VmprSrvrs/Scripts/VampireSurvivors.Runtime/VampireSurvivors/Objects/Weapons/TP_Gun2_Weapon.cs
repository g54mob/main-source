using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Gun2_Weapon : TP_Gun1_Weapon
	{
		private ParticleSystem _jewelPickupVfx;

		private List<Color32> _colors;

		protected override void Awake()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public void ShowBigDamage(float value, Vector3 position)
		{
		}
	}
}
