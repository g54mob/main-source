using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class BBTSubSpeciesServiceGoal : BBTGoal<SubSpeciesServiceGoal>
	{
		public ESubSpecies SubSpeciesToServe;

		public bool ForceSpawns;

		[ShowIf("ForceSpawns")]
		[AllowNesting]
		[Min(0f)]
		public float FirstSpawnDelay;

		[ShowIf("ForceSpawns")]
		[AllowNesting]
		[Min(1f)]
		public float SpawnCooldown = 60f;

		[ShowIf("ForceSpawns")]
		[AllowNesting]
		[Min(0f)]
		public int AmountPerSpawn = 1;

		private Coroutine _spawns;

		protected override void InstantiateGoal()
		{
			Goal = new SubSpeciesServiceGoal(Quest, Entry, Variable, Target, SubSpeciesToServe);
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
				_spawns = Quest.StartCoroutine(SpawnersHelper.CustomerSpreadOutSpawnsCoroutine(SubSpeciesToServe, FirstSpawnDelay, SpawnCooldown, AmountPerSpawn));
			}
		}
	}
}
