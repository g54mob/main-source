using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class Flower2Weapon : Weapon
	{
		public float BoomBallExplodingSpeed;

		public float BoomBallMAXRADIUS;

		private float _mul;

		private bool _explosionTriggered;

		private Timer _chainTimer;

		private bool _canChainExplosion;

		[NonSerialized]
		public float WORLD_RIGHT;

		[NonSerialized]
		public float WORLD_LEFT;

		[NonSerialized]
		public float WORLD_TOP;

		[NonSerialized]
		public float WORLD_BOTTOM;

		private BulletPool _boomBallPool;

		[NonSerialized]
		public PhysicsGroup _activeBalls;

		private float _firingTimes;

		private List<Vector2> _positions;

		private List<float> _offsetsX;

		private List<float> _offsetsY;

		private PhaserSprite _sprCore;

		private PhaserSprite _sprFlower;

		private PhaserSprite _sprPond;

		private PhaserSprite _sprSplash;

		private PhaserSprite _sprGrass;

		private bool _hasFlex;

		private bool _hasCharacterFlex;

		protected override void OnStart()
		{
		}

		public void createFlex()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void PrepareArrays(float amount)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateFlex()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void DetonateBoomBalls()
		{
		}

		private bool onBulletOverlapsBullet(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void ResetFiringTimer()
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool onBoomBallOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public bool CircleOnCircle(float2 v1, float r1, float2 v2, float r2)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
