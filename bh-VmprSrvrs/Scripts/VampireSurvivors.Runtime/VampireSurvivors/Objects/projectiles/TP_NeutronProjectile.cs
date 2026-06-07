using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_NeutronProjectile : Projectile
	{
		private float _displaySpritePxSize;

		private float _innerRadius;

		private MultiTargetTween _tween1;

		private PhaserSprite _displaySprite;

		private int frameIndex;

		private float frameTime;

		private bool _isActivated;

		private MultiTargetTween _tween2;

		private bool _canUpdate;

		private bool _isUnionWeapon;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void ActivateBomb()
		{
		}

		private void PlaySfx()
		{
		}

		public override void Despawn()
		{
		}
	}
}
