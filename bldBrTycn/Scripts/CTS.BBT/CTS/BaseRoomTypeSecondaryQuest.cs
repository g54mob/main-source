using System;
using UnityEngine;

namespace CTS
{
	public class BaseRoomTypeSecondaryQuest<T> : BaseNumericSecondaryQuest<T> where T : BaseSpecificRoomTypeNumericalGoal
	{
		[SerializeField]
		private NavigationArea[] _navAreas;

		protected override void StartObservingObjectives()
		{
			Goal = (T)Activator.CreateInstance(typeof(T), this, Entry, Progress, Target, _navAreas);
			Goal?.StartObserving();
		}
	}
}
