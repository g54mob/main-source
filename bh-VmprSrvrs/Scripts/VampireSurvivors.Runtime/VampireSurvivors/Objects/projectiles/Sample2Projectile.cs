using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Sample2Projectile : Projectile
	{
		private PhaserSprite sampleSprite;

		private PhaserSprite crystalSprite;

		private MultiTargetTween crystalTween;

		private Sample2Weapon trueWeapon;

		protected int[] tints;

		protected SfxType[] dropSounds;

		protected SfxType[] stepSounds;

		private bool isInitialised;

		private MultiTargetTween _moveXTween;

		private MultiTargetTween _moveYTween;

		private bool isBreaking;

		private Timer _expireTimer;

		private MultiTargetTween despawnTween;

		private PhaserSprite overlaySprite;

		private PhaserSprite numberSprite;

		private MultiTargetTween overlayAlphaTween;

		private MultiTargetTween numberSpriteTween;

		private Timer _activationTimer;

		private MultiTargetTween enterTween;

		private int assignedNumber;

		private float2 playerOffset;

		private bool followOwner;

		protected override void Awake()
		{
		}

		public virtual void makeSprites()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetFloorTarget(int showNumber, float2 targetPos, float delay, float activationDelay)
		{
		}

		public void Dropped()
		{
		}

		public void Break()
		{
		}

		protected void dropSound()
		{
		}

		protected void breakSound()
		{
		}

		public void StartDespawn()
		{
		}

		public void Shrink(bool alsoDespawn = false)
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void checkOverlap(int tries)
		{
		}
	}
}
