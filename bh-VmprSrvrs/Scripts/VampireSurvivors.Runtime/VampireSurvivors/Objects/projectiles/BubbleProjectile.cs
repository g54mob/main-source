using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BubbleProjectile : Projectile
	{
		private MultiTargetTween _speedTween;

		private MultiTargetTween _tween1;

		private float _saveVelX;

		private float _saveVelY;

		private bool _canBounce;

		private Vector2 _aimVec;

		public float _BombDeceleration;

		protected override void Awake()
		{
		}

		public void SetColor(uint color)
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void FadeOut()
		{
		}

		private void Bounce(Body bdy, bool up, bool down, bool left, bool right)
		{
		}

		public void Decelerate()
		{
		}

		private void JustBounce()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}
	}
}
