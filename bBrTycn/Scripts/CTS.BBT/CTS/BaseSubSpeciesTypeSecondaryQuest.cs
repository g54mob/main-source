using System;
using UnityEngine;

namespace CTS
{
	public abstract class BaseSubSpeciesTypeSecondaryQuest<T> : BaseNumericSecondaryQuest<T> where T : BaseSpecificSubSpeciesNumericalGoal
	{
		[SerializeField]
		private CustomerParameters _subSpeciesSO;

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
				_spawns = StartCoroutine(SpawnersHelper.CustomerSpreadOutSpawnsCoroutine(_subSpeciesSO));
			}
			Goal = (T)Activator.CreateInstance(typeof(T), this, Entry, Progress, Target, _subSpeciesSO.Type);
			Goal?.StartObserving();
		}
	}
}
