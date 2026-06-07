using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Sample1ExplosionProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _ringRenderer;

		[SerializeField]
		private SpriteRenderer _rainbowRenderer;

		[SerializeField]
		private SpriteRenderer _raysRenderer;

		[SerializeField]
		private Transform _spritesContainer;

		private MultiTargetTween _ttween4;

		private MultiTargetTween _ttween3;

		private MultiTargetTween _ttween2;

		private MultiTargetTween _ttween1;

		private Weapon _trueWeapon;

		private MultiTargetTween scaleTween;

		private float SelfRadius;

		private Timer _expireTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Detonate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
