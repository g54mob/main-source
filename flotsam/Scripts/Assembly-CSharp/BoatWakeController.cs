using PajamaLlama.Math;
using UnityEngine;

public class BoatWakeController : MonoBehaviour
{
	private RateOverDistance[] _rateOverDistances;

	private Vector3 _previousPosition;

	private Navigator _navigator;

	private bool _isNavigating;

	private void Start()
	{
		_rateOverDistances = GetComponentsInChildren<RateOverDistance>();
		_navigator = GetComponentInParent<Navigator>();
		_isNavigating = false;
	}

	private void FixedUpdate()
	{
		Vector3 vector = base.transform.position.Leveled();
		float value = ((!(_navigator == null) && !IsNavigating(_navigator.State)) ? 0f : ((vector - _previousPosition) / Time.deltaTime).magnitude);
		for (int i = 0; i < _rateOverDistances.Length; i++)
		{
			_rateOverDistances[i].SetParticleSpeed(Mathf.Clamp(value, 0f, 1f));
		}
		_previousPosition = vector;
	}

	private bool IsNavigating(NavigatorState navigatorState)
	{
		if (navigatorState == NavigatorState.Navigating)
		{
			if (_isNavigating)
			{
				return true;
			}
			_isNavigating = true;
		}
		else
		{
			_isNavigating = false;
		}
		return false;
	}
}
