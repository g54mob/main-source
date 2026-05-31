using System;
using UnityEngine;

namespace CTS
{
	public class BaseSpecificSpeciesSecondaryQuest<T> : BaseNumericSecondaryQuest<T> where T : BaseSpecificSpeciesNumericalGoal
	{
		[SerializeField]
		protected ESpecies Species;

		protected override void StartObservingObjectives()
		{
			Goal = (T)Activator.CreateInstance(typeof(T), this, Entry, Progress, Target, Species);
			Goal?.StartObserving();
		}
	}
}
