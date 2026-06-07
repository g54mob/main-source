using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Doppleganger_Runetracer : EnemyProjectile
	{
		public TrailRenderer _Trail;

		public SpriteRenderer _SpriteRenderer;

		private Timer _expireTimer;

		private float _saveVelX;

		private float _saveVelY;

		private TrailRendererPauseController _pauseController;

		protected override void Awake()
		{
		}

		public override void InitProjectile(int index, float2 direction, EnemyBulletPool pool)
		{
		}

		private void FadeOutAndDispose()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		private void SetupTrails()
		{
		}

		public override void OnHitPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}
	}
}
