using System;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class GarbageChuteMovement
	{
		[NonSerialized]
		public PhaserSprite ChuteSprite;

		[NonSerialized]
		public PhaserSprite ChuteSpriteLeft;

		[NonSerialized]
		public PhaserSprite ChuteSpriteRight;

		[NonSerialized]
		public MultiTargetTween ChuteMoveTweens;

		[NonSerialized]
		public bool ChuteActive;

		[NonSerialized]
		public bool ChuteFollowingScreen;

		[NonSerialized]
		public float ChuteOffsetX;

		[NonSerialized]
		public float ChuteOffsetY;

		private float _chuteSpeed;

		private GarbageChuteWeapon _trueWeapon;

		private int _chuteIndex;

		private Timer _moveChuteTimer;

		private Timer _projectileStartTimer;

		private Timer _projectileEndTimer;

		private Timer _projectileLeftScreenTimer;

		public void createChute(GarbageChuteWeapon weapon, int index)
		{
		}

		public void startChute()
		{
		}

		private void moveChuteAcross()
		{
		}

		private void moveChuteDown()
		{
		}

		private void hideChute()
		{
		}

		public void ManuallyHideChute()
		{
		}

		private float calcNewChuteXPos()
		{
			return 0f;
		}

		public void Cleanup()
		{
		}
	}
}
