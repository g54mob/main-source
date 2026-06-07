using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyMinHealth_KillRatio : EnemyController
	{
		private Sequence _onEnterTween;

		private int _lives;

		public TweenerCore<float, float, FloatOptions> AccelTween { get; set; }

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void OnTeleportOnCull()
		{
		}

		private void Accelerate()
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}
	}
}
