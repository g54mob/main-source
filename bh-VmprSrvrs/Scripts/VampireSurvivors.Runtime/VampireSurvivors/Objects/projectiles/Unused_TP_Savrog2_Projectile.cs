using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Unused_TP_Savrog2_Projectile : TP_Savrog_Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		[SerializeField]
		private TrailRenderer _Trail2;

		private Unused_TP_Savrog2_Weapon _trueWeapon;

		private bool _isYeeted;

		private MultiTargetTween _tintTween;

		private int _tintCounter;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitTrails()
		{
		}

		private void UpdateTrailTints()
		{
		}

		private void DoTintTween()
		{
		}

		public void Yeet(Vector2 vector)
		{
		}

		public override void Despawn()
		{
		}
	}
}
