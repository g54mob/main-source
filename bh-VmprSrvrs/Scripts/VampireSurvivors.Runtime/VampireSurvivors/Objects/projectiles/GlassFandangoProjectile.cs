using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GlassFandangoProjectile : Projectile
	{
		[SerializeField]
		private PhaserSprite _lanceSprite;

		[SerializeField]
		private PhaserSprite _lanceTipSprite;

		[SerializeField]
		private bool IsEvolved;

		private Vector2 _collisionPos;

		private Vector2 _spritePos;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private int _sfxIndex;

		private readonly SfxType[] _sounds;

		private uint[] _colors;

		private readonly BlendMode[] _blendModes;

		private readonly float[] _timeFreezeAngles;

		private readonly float[] _angles;

		private SoundManager.SoundConfig _soundConfig;

		public float _life;

		private Transform _cachedSpriteTransform;

		private Transform _cachedSpriteTipTransform;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		public override float ProjectileSpeed => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void OnRecycle()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}
	}
}
