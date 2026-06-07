using Unity.Mathematics;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_MetalClawProjectile : Projectile
	{
		private MultiTargetTween _tweenOffSetIn;

		private MultiTargetTween _tweenOffSetOut;

		private float _previousArea;

		private float _detuneMul;

		private float2 startOffsetRight;

		private float2 finishOffsetRight;

		private float2 startOffsetLeft;

		private float2 finishOffsetLeft;

		public float offsetX;

		public float offsetY;

		private float _areaScale;

		private float _hitboxRadius;

		private PhaserSprite _displaySprite;

		public void SetDetune(float value = 0f)
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
