using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_SpellFirerProjectile : Projectile
	{
		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private EME_RapierWeapon _trueWeapon;

		private ParticleSystem _pfxEmitter;

		private ParticleSystem _pfxEmitter2;

		private ParticleSystem _pfxEmitter3;

		private bool _initialisedParticles;

		[SerializeField]
		private MeshRenderer _Model1;

		[SerializeField]
		private MeshRenderer _Model2;

		[SerializeField]
		private MeshRenderer _Model3;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private Timer _DespawnTimer;

		private PhaserSprite _displayImage;

		private Transform _M1CachedT;

		private Transform _M2CachedT;

		private Transform _M3CachedT;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnRecycle()
		{
		}

		private void FadeOut(float fadeDuration)
		{
		}

		public override void Despawn()
		{
		}
	}
}
