using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FlareExplosionProjectile : Projectile
	{
		private MultiTargetTween _fadeoutTween;

		private MultiTargetTween _scaleTween;

		private PhaserSprite _starSprite;

		private PhaserSprite _sideSprite;

		private PhaserSprite _flatSprite;

		private bool _isLight;

		private string[] _sideNames;

		private string[] _starNames;

		private string[] _flatNames;

		private MultiTargetTween _flatTween;

		private MultiTargetTween _sideTween;

		private MultiTargetTween _starTween;

		private PhaserSprite _exploSprite;

		private MultiTargetTween _exploTween;

		private WeaponType[] _darkWeapons;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _PfxEmitter;

		private bool _particlesGenerated;

		public float _BodyScale;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Explode()
		{
		}

		private void FadeOut()
		{
		}

		public override void Despawn()
		{
		}
	}
}
