using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class SireWeapon : Weapon
	{
		[SerializeField]
		private SpriteRenderer _WhiteDot;

		[SerializeField]
		private SpriteRenderer _GroundSeal;

		[SerializeField]
		private GameObject _ExplosionVFXPrefab;

		public float _R;

		public float _G;

		public float _B;

		public float _A;

		private ObjectPool _explosionPool;

		private MultiTargetTween _rgbTween;

		private MultiTargetTween _alphaTween;

		private bool _canFlash;

		private Projectile _activeProjectile;

		public ObjectPool ExplosionPool => null;

		public SpriteRenderer WhiteDot => null;

		protected override bool UseOnlineTimer => false;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void InternalUpdate()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireSire(bool skipTriggers)
		{
		}

		public void FlashScreen(Projectile projectile)
		{
		}

		public void SpinSeal(float durationMillis, float scale, float alpha, Projectile projectile)
		{
		}

		public void HideSeal(Projectile projectile)
		{
		}

		protected override void MakeLevelOne()
		{
		}

		private void InitGroundSeal()
		{
		}

		private void ShowSeal()
		{
		}

		private void MakeWhiteDot()
		{
		}

		private void GeneratePool()
		{
		}
	}
}
