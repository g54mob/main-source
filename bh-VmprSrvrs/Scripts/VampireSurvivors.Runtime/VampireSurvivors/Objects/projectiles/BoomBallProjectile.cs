using System.Collections.Generic;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BoomBallProjectile : Projectile
	{
		private bool alreadyRecycled;

		private bool alreadyGenerated;

		private bool IsExploding;

		private BallState State;

		private float maximizedTimer;

		private Flower2Weapon trueWeapon;

		private bool isFrozen;

		private float SpeedX;

		private float SpeedY;

		private float Radius;

		private float ExplodingSpeed;

		private float MAXRADIUS;

		private float MAXTIMER;

		private float OffsetX;

		private float OffsetY;

		private float MoveSpeed;

		private MultiTargetTween splashTweenIn;

		private MultiTargetTween splashTweenOut;

		private MultiTargetTween finalTweenOut;

		private List<uint> tints;

		private MultiTargetTween enterTween;

		private MultiTargetTween flowerTweenIn;

		private PhaserSprite sprSplash;

		private PhaserSprite sprFlower;

		private PhaserSprite _GroundFx;

		private PhaserSprite displaySprite;

		public HashSet<IDamageable> objectsHit => null;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void Reset()
		{
		}

		public override void InternalUpdate()
		{
		}

		public void CheckOverlap()
		{
		}

		public void Detonate()
		{
		}

		public override void Despawn()
		{
		}

		public void MakeProfusionSprites()
		{
		}

		public void PlayAnim()
		{
		}

		public void StopAnim()
		{
		}
	}
}
