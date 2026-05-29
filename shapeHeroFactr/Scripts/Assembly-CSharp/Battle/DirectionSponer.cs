using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class DirectionSponer
	{
		[Serializable]
		public struct SameTimingGroup
		{
			public int unlockLevel;

			[Tooltip("エネミーグループ：敵1体の集合")]
			public List<SpawnLabel> enemyGroup;

			public List<SpawnLabel> GetTargetLevelEnemyGroups(int nowLevel)
			{
				return null;
			}
		}

		[Serializable]
		public struct SpawnLabel
		{
			public int unlockLevel;

			[Label("敵出現候補ラベル")]
			public eSpawnGroupLabel spawnLabel;
		}

		[Tooltip("SameTiming Group:同タイミングで出現するエネミーグループの集合")]
		[Label("同タイミング")]
		public List<SameTimingGroup> someTimingGroups;

		[Label("ばらつき度")]
		public float spawnRnage;

		public List<SameTimingGroup> GetTargetLevelSameTimingGroups(int nowLevel)
		{
			return null;
		}
	}
}
