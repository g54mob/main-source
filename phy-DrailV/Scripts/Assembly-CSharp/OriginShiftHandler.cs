using DV.Utils;
using UnityEngine;

public class OriginShiftHandler : MonoBehaviour
{
	private void OnEnable()
	{
		SetupListeners(on: true);
	}

	private void OnDisable()
	{
		SetupListeners(on: false);
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			PlayerManager.CarChanged += OnCarChanged;
		}
		else
		{
			PlayerManager.CarChanged -= OnCarChanged;
		}
	}

	private void OnCarChanged(TrainCar car)
	{
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			bool flag = car != null;
			SingletonBehaviour<WorldMover>.Instance.playerTracker.SetShouldApplyOriginShift(!flag);
		}
	}
}
