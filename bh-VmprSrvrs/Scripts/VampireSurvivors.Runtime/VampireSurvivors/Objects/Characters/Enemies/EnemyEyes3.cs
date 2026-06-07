using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyEyes3 : EnemyController
	{
		private bool _hasGeneratedSprites;

		private PhaserSprite _eyes;

		private MultiTargetTween _onEnterTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateEyes()
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		private void GenerateSprites()
		{
		}
	}
}
