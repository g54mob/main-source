using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyLeftRight : EnemyController
	{
		public const string ANIM_ALIAS_IDLE = "Alias_Idle";

		public const string ANIM_ALIAS_DEATH = "Alias_Death";

		protected EnemyData _alias;

		private bool _useAlias;

		public EnemyData Alias => null;

		private void CheckAlias()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		protected override void Die()
		{
		}
	}
}
