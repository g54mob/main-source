using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Fibonacci2_Weapon : LEM_Fibonacci1_Weapon
	{
		[SerializeField]
		private Transform FlushVFX;

		private MultiTargetTween _scaleTween;

		public int FireCounter { get; private set; }

		public override float StartingAngle => 0f;

		protected override float WeaponTriggerChance => 0f;

		protected override int NumWeaponsToTrigger => 0;

		public float PAreaMax => 0f;

		public override float PArea()
		{
			return 0f;
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public void ScaleInFlush()
		{
		}

		private void PlayFlushSfx()
		{
		}

		protected override void MakeLevelOne()
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		private int GetNumWeaponsToTrigger()
		{
			return 0;
		}

		public override void SetVisible(bool visible)
		{
		}

		public override void Cleanup()
		{
		}
	}
}
