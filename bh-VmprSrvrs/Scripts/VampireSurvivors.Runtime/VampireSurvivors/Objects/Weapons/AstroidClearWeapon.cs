using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class AstroidClearWeapon : Weapon
	{
		[NonSerialized]
		public PhaserSprite _crosshairSprite;

		private PhaserSprite _bulletSprite1;

		private PhaserSprite _bulletSprite2;

		private List<PhaserSprite> _asteroidSprites;

		private List<bool> _asteroidActive;

		private List<bool> _asteroidShootable;

		private List<Vector2> _asteroidVelocity;

		private List<float> _asteroidRotation;

		private MultiTargetTween _moveTween;

		private int _asteroidHitNum;

		[NonSerialized]
		public float CrosshairOffsetX;

		[NonSerialized]
		public float CrosshairOffsetY;

		private int _maxAsteroids;

		private MultiTargetTween explodeScaleTween;

		private float sureFire;

		private bool justFired;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Cleanup()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void fireAsteroid(int asteroidInt, bool shootable)
		{
		}

		private Vector2 getBorderPosition()
		{
			return default(Vector2);
		}

		private Vector2 getRandomCentralPoint()
		{
			return default(Vector2);
		}

		private int getNextAvailableAsteroid()
		{
			return 0;
		}

		private int findClosestCentralAsteroid()
		{
			return 0;
		}

		private void moveTarget()
		{
		}

		private void checkAsteroidCollision()
		{
		}

		private void AsteroidExplode()
		{
		}

		private void OnExplodeComplete(int asteroidNum)
		{
		}

		private void LateUpdate()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
