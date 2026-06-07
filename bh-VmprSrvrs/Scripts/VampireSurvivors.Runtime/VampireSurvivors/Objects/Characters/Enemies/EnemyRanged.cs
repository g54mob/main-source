using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyRanged : EnemyController
	{
		private EnemyType _originalBullet;

		private float _keepMoving;

		private float _fireDelay;

		private float _previousDistance;

		private Tween _onEnterTween;

		private Timer _onFireTimer;

		private new const float Distance = 50000f;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		public override void Despawn()
		{
		}

		private void Fire()
		{
		}
	}
}
