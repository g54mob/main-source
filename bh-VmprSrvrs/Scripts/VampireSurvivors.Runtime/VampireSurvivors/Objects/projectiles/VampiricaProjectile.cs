using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class VampiricaProjectile : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private SpriteRenderer _ghost1;

		private SpriteRenderer _ghost2;

		private bool _doneInit;

		private float _previousArea;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}
	}
}
