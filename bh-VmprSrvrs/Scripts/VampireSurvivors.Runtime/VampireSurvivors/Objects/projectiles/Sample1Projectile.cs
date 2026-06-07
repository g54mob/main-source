using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Sample1Projectile : Projectile
	{
		private string[] frameNames;

		private PhaserSprite sampleSprite;

		private PhaserSprite crystalSprite;

		private MultiTargetTween crystalTween;

		private Sample1Weapon trueWeapon;

		protected int[] tints;

		protected SfxType[] dropSounds;

		protected SfxType[] stepSounds;

		private bool isInitialised;

		private MultiTargetTween _moveXTween;

		private MultiTargetTween _moveYTween;

		private bool isBreaking;

		private Timer _expireTimer;

		private MultiTargetTween despawnTween;

		public virtual void makeSprites()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetFloorTarget(float duration, float2 targetPos)
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
	}
}
