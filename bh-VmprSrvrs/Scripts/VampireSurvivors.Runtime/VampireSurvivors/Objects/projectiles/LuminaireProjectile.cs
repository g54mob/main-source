using System;
using Unity.Mathematics;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LuminaireProjectile : Projectile
	{
		private bool _alreadyRecycled;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _scaleTween;

		[NonSerialized]
		public float radius;

		private float2 _pfxLocation;

		public uint[] _colors;

		public int[] _detunes;

		private LuminaireWeapon _trueWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}
	}
}
