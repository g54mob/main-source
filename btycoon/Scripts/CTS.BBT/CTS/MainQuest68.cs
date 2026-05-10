using UnityEngine;

namespace CTS
{
	public class MainQuest68 : Quest
	{
		[SerializeField]
		private BBTBloodBagQualityProductionGoal _bloodGoal;

		[SerializeField]
		private BBTGranitasQualityProductionGoal _granitasGoal;

		[SerializeField]
		private BBTSmokedBloodQualityProductionGoal _smokedGoal;

		[SerializeField]
		private BBTShakeBloodQualityProductionGoal _shakeGoal;

		protected override void StartObservingObjectives()
		{
			_bloodGoal.StartObserving(this);
			_granitasGoal.StartObserving(this);
			_smokedGoal.StartObserving(this);
			_shakeGoal.StartObserving(this);
		}
	}
}
