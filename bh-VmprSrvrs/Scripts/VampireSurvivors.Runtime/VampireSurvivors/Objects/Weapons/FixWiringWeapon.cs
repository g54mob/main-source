using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class FixWiringWeapon : Weapon
	{
		private int currentLineNum;

		private List<FixWiringProjectile> _wireList;

		private List<uint> _colourList;

		private List<int> _remainingWireList;

		private List<float2> _wireLeftPosY;

		private List<float2> _wireRightPosY;

		private List<PhaserSprite> _leftSprites;

		private List<PhaserSprite> _rightSprites;

		private List<PhaserSprite> _endCapRightSprites;

		private MultiTargetTween alphaTween;

		public int failedAttempts;

		private BulletPool _wireSparkPool;

		private Timer _completeTimer;

		private Random _random;

		public override float SecondaryPPower()
		{
			return 0f;
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void ScreenShake()
		{
		}

		public void LineComplete()
		{
		}

		public override void Cleanup()
		{
		}

		private void shufflePositions()
		{
		}

		private void drawSides()
		{
		}

		private void shuffleWirePositions()
		{
		}

		private void setWireCaps()
		{
		}

		private void fireSpark(FixWiringProjectile wire, float speedMultiplier = 1f)
		{
		}

		private void PickNewTarget()
		{
		}

		private void checkIfAllLinesComplete()
		{
		}

		private void HideWeapon()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
