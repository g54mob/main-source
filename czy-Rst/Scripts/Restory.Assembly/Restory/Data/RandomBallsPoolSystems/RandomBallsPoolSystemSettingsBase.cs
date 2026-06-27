using UnityEngine;

namespace Restory.Data.RandomBallsPoolSystems
{
	public class RandomBallsPoolSystemSettingsBase : ScriptableObject
	{
		[SerializeField]
		private int remainingBallsCountToRefillPool;

		public int RemainingBallsCountToRefillPool => remainingBallsCountToRefillPool;
	}
}
