using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyUpDown : EnemyController
	{
		public const string ANIM_ALIAS_IDLE = "Alias_Idle";

		public const string ANIM_ALIAS_DEATH = "Alias_Death";

		private bool _useAlias;

		private EnemyData _alias;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}
	}
}
