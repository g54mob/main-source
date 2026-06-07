using System;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_DraculaHand_Projectile : Projectile
	{
		[NonSerialized]
		public bool _isMoving;

		private PhaserSprite _arm;

		private int _armFrameCount;

		private float _armProgress;

		private int _armFrame;

		private bool animsSetup;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitAnims()
		{
		}

		private void SetArmFrame(int frame)
		{
		}

		public void Swipe()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
