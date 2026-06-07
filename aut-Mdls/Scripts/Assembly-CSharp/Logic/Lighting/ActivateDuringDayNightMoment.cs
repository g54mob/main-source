using System.Collections.Generic;
using Data.Lighting;
using Events.Lighting;
using UnityEngine;

namespace Logic.Lighting
{
	public abstract class ActivateDuringDayNightMoment : MonoBehaviour
	{
		[SerializeField]
		private SetDayNightCycleMomentEventSO _setDayNightCycleMomentEvent;

		[SerializeField]
		private List<DayNightCycleMomentSO> _activeMoments = new List<DayNightCycleMomentSO>();

		private bool _previousActive;

		private void OnEnable()
		{
			Activate(setActive: false);
			_previousActive = false;
			_setDayNightCycleMomentEvent.Register(OnSetDayNightCycleMoment);
		}

		private void OnDisable()
		{
			_setDayNightCycleMomentEvent.UnRegister(OnSetDayNightCycleMoment);
		}

		private void OnSetDayNightCycleMoment(DayNightCycleMomentSO moment)
		{
			TryActivate(_activeMoments.Contains(moment));
		}

		private void TryActivate(bool setActive)
		{
			if (_previousActive != setActive)
			{
				Activate(setActive);
				_previousActive = setActive;
			}
		}

		protected abstract void Activate(bool setActive);
	}
}
