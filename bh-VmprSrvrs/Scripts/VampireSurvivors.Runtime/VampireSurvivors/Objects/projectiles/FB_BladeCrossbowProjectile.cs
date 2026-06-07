using Unity.Mathematics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_BladeCrossbowProjectile : Projectile
	{
		private enum BladeCrossbowState
		{
			GoingOutwards = 0,
			Paused = 1,
			Returning = 2
		}

		private BladeCrossbowState _state;

		private float2 _positionBeforeReturning;

		private float _returningT;

		private float2 _originalPosition;

		private float _age;

		protected virtual string _FrameName => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void PauseAttack()
		{
		}

		private void ClearEnemiesHit()
		{
		}

		private void RecallProjectile()
		{
		}

		public override void Despawn()
		{
		}
	}
}
