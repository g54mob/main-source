using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class PartyWeapon : Weapon
	{
		private ParticleEmitterManager _pfxEmitter;

		private ParticleSystem _emitter1;

		private GravityWell _well1;

		protected uint[] CircleColors;

		protected uint[] StarColors;

		protected uint[] TriangleColors;

		protected uint[] HeartColors;

		private int _colorIndex;

		private readonly int _maxColors;

		private PartyCounterWeapon _counterWeapon;

		private WeaponType _counterWeaponType;

		[NonSerialized]
		public int FireType;

		[NonSerialized]
		public bool FrontFiring;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void PickType()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public uint GetRandomCircleColor()
		{
			return 0u;
		}

		public uint GetRandomStarColor()
		{
			return 0u;
		}

		public uint GetRandomTriangleColor()
		{
			return 0u;
		}

		public uint GetRandomHeartColor()
		{
			return 0u;
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void ParadoxFire()
		{
		}
	}
}
