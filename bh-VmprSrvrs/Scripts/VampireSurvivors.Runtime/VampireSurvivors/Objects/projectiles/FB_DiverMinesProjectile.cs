using Unity.Mathematics;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_DiverMinesProjectile : Projectile
	{
		private enum ScreenEdge
		{
			None = 0,
			Top = 1,
			Bottom = 2,
			Left = 3,
			Right = 4
		}

		private bool _anticlockwiseSpin;

		private bool _hasHitAnything;

		private Timer _explosionTimer;

		private ScreenEdge _screenEdge;

		private float2 _lastVelocity;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void DoExplode()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void HandleScreenEdges()
		{
		}

		private void StickToScreenEdge(ScreenEdge nextEdge, ArcadeRect playArea)
		{
		}

		private bool HitsTop(ArcadeRect playArea)
		{
			return false;
		}

		private bool HitsBottom(ArcadeRect playArea)
		{
			return false;
		}

		private bool HitsRight(ArcadeRect playArea)
		{
			return false;
		}

		private bool HitsLeft(ArcadeRect playArea)
		{
			return false;
		}

		private void StickToWall(float2 normal)
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}
	}
}
