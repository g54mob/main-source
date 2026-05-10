using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BBTKillInvestigatorGoal : BBTGoal<KillInvestigatorGoal>
	{
		public bool ForceSpawns;

		[SerializeField]
		[ShowIf("ForceSpawns")]
		[AllowNesting]
		private AutoSpawnData _autoSpawnData;

		private Coroutine _spawns;

		protected override void InstantiateGoal()
		{
			base.InstantiateGoal();
			Goal.Achieved += OnGoalAchieved;
		}

		private void OnGoalAchieved()
		{
			if (_spawns != null)
			{
				Quest.StopCoroutine(_spawns);
			}
		}

		public override void StopObserving()
		{
			Goal.Achieved -= OnGoalAchieved;
			if (_spawns != null)
			{
				Quest.StopCoroutine(_spawns);
			}
			base.StopObserving();
		}

		public override void StartObserving(Quest quest, params Action[] actionsAchieved)
		{
			base.StartObserving(quest, actionsAchieved);
			if (ForceSpawns)
			{
				if (_spawns != null)
				{
					Quest.StopCoroutine(_spawns);
				}
				_spawns = Quest.StartCoroutine(SpawnersHelper.InvestigatorSpreadOutSpawnsCoroutine(_autoSpawnData));
			}
		}
	}
}
