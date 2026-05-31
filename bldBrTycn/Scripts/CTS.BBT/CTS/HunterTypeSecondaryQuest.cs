using UnityEngine;

namespace CTS
{
	public abstract class HunterTypeSecondaryQuest<T> : BaseNumericSecondaryQuest<T> where T : QuestNumericGoal
	{
		[SerializeField]
		private bool _artificialSpawn = true;

		private Coroutine _spawns;

		protected override void StopObservingObjectives()
		{
			if (_spawns != null)
			{
				StopCoroutine(_spawns);
			}
			base.StopObservingObjectives();
		}

		protected override void StartObservingObjectives()
		{
			if (_artificialSpawn)
			{
				_spawns = StartCoroutine(SpawnersHelper.HuntersSpreadOutSpawnsCoroutine());
			}
			base.StartObservingObjectives();
		}
	}
}
