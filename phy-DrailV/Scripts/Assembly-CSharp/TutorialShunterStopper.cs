using DV;
using DV.Simulation.Cars;
using UnityEngine;

public class TutorialShunterStopper : MonoBehaviour
{
	private const float MAX_SQR_DISTANCE_TO_PLAYER = 625f;

	private TrainCar carToStop;

	private BaseControlsOverrider controlsOverrider;

	private bool initialized;

	private bool isStopping;

	private void OnDestroy()
	{
		PlayerManager.CarChanged -= OnCarChanged;
	}

	public void Initialize(TrainCar carToStop)
	{
		if (carToStop == null)
		{
			Debug.LogError("TutorialShunterStopper requires a valid car reference. Destroying self.");
			Object.Destroy(base.gameObject);
			return;
		}
		this.carToStop = carToStop;
		controlsOverrider = carToStop.SimController?.controlsOverrider;
		PlayerManager.CarChanged += OnCarChanged;
		base.gameObject.SetActive(value: true);
		initialized = true;
	}

	private void OnCarChanged(TrainCar car)
	{
		if (isStopping && car == carToStop)
		{
			isStopping = false;
		}
	}

	private void Update()
	{
		if (initialized && TimeUtil.IsFlowing && !(PlayerManager.Car == carToStop) && !isStopping && !((PlayerManager.PlayerTransform.position - carToStop.transform.position).sqrMagnitude < 625f) && carToStop.GetAbsSpeed() > 0.05f)
		{
			controlsOverrider.Handbrake?.Set(1f);
			controlsOverrider.Throttle?.Set(0f);
			isStopping = true;
		}
	}
}
