using System;
using System.Collections.Generic;
using Actors.Enemies;

namespace Assets.Scripts.Game.Spawning.New.Timelines
{
	[Serializable]
	public class StageTimeline
	{
		public float stageTime;

		public float checkNewEnemyInterval;

		public List<EEnemy> startEnemies;

		public List<TimelineEvent> events;

		public EnemyData boss;

		public List<EEnemy> minibosses;

		public float GetStageTime()
		{
			return 0f;
		}

		public void Sort()
		{
		}
	}
}
