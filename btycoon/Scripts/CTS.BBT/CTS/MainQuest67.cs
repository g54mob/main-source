using UnityEngine;

namespace CTS
{
	public class MainQuest67 : Quest
	{
		[SerializeField]
		private BBTBloodBagProductionGoal _bloodGoal;

		[SerializeField]
		private BBTGranitasProductionGoal _granitasGoal;

		[SerializeField]
		private BBTSmokedBloodProductionGoal _smokedGoal;

		[SerializeField]
		private BBTShakeBloodProductionGoal _shakeGoal;

		protected override void StartObservingObjectives()
		{
			_bloodGoal.StartObserving(this);
			_granitasGoal.StartObserving(this);
			_smokedGoal.StartObserving(this);
			_shakeGoal.StartObserving(this);
		}
	}
}
