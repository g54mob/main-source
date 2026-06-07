using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Flower2Projectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundFx;

		[SerializeField]
		private PhaserSprite _FlowerSprite;

		private Circle _a;

		private bool _particlesGenerated;

		private Timer _bounceTimer;

		private MultiTargetTween _angleTween;

		private MultiTargetTween _scaleTween;

		private float _saveVelX;

		private float _saveVelY;

		private MultiTargetTween _speedTween;

		private float _initialVelocityX;

		private float _initialVelocityY;

		public float _BombDeceleration;

		private GravityWell _well;

		private Vector2 _aimVec;

		private bool _canBounce;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween1;

		private float _bounceAreaMod;

		private int _radius;

		private List<string> _flowerNames;

		private ParticleEmitterManager _particles;

		private ParticleSystem _fwEmitter2;

		private Vector2 _previousVector;

		private Vector2 _newAim;

		public float _ScaleAfterBounceMod;

		private Timer _hitboxTimer;

		private uint[] _onEmitCustomTint;

		private SfxType[] _soundArray;

		private Transform _cachedRendererTransform;

		private Transform _cachedFlowerTransform;

		private Tween _colliderTween;

		private PhaserSprite sprSplash;

		private PhaserSprite sprFlower;

		private MultiTargetTween splashTweenIn;

		private MultiTargetTween splashTweenOut;

		private bool ExplosionTriggered;

		private Flower2Weapon trueWeapon;

		public HashSet<IDamageable> objectsHit => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void MakeProfusionSprites()
		{
		}

		public void SizeUp()
		{
		}

		public void Explode()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void FadeOut()
		{
		}

		private float MyScale()
		{
			return 0f;
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}
	}
}
