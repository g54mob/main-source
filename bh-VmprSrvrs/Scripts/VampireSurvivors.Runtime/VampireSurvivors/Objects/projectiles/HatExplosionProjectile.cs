using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class HatExplosionProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _cherryRenderer;

		[SerializeField]
		private SpriteRenderer _ringRenderer;

		[SerializeField]
		private SpriteRenderer _rainbowRenderer;

		[SerializeField]
		private SpriteRenderer _raysRenderer;

		private ParticleEmitterManager _particles;

		private ParticleSystem _fwEmitter;

		private float _initialVelocityX;

		private float _initialVelocityY;

		private GravityWell _well;

		private Vector2 _aimVec;

		private MultiTargetTween _ttween6;

		private MultiTargetTween _ttween5;

		private MultiTargetTween _ttween3;

		private MultiTargetTween _ttween4;

		private MultiTargetTween _ttween4Alpha;

		private MultiTargetTween _ttween2;

		private MultiTargetTween _ttween1;

		private HatWeapon _trueWeapon;

		private bool _alreadyRecycled;

		private uint[] _onEmitcustomTint2;

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
