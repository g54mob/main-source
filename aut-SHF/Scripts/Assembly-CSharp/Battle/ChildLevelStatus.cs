using System;

namespace Battle
{
	[Serializable]
	public struct ChildLevelStatus
	{
		[Label("レベル")]
		public int level;

		[Label("ステータス")]
		public BaseEnemy.EnemyBaseInfo childStatus;
	}
}
