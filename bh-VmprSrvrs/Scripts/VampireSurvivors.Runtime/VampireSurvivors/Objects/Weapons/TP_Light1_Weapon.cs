using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Light1_Weapon : Weapon
	{
		private BulletPool _orbitersPool;

		[SerializeField]
		protected Projectile _orbiterPrefab;

		[NonSerialized]
		public int OrbitAmount;

		private WeaponType[] _lightDarkWeapons;

		public float ProjScaledAlpha { get; set; }

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void SetVisible(bool visible)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public Projectile SpawnOrbitProjectile(float2 pos, int index)
		{
			return null;
		}

		public override bool LevelUp()
		{
			return false;
		}
	}
}
