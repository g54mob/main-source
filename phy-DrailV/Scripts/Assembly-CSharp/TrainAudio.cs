using DV.Utils;
using UnityEngine;

public abstract class TrainAudio : MonoBehaviour
{
	protected TrainCar car;

	public void SetupForCar(TrainCar trainCar)
	{
		if (trainCar == null)
		{
			Debug.LogError(base.name + " is assigned to a null train car. Destroying audio object.", this);
			Object.Destroy(base.gameObject);
			return;
		}
		car = trainCar;
		base.transform.parent = car.interior.transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		car.OnCarAboutToBeDestroyed += ReturnToPool;
		base.gameObject.SetActive(value: true);
		base.enabled = true;
		Initialize(car);
	}

	protected abstract void Initialize(TrainCar trainCar);

	protected abstract void Deinitialize();

	private void ReturnToPool()
	{
		if (car == null)
		{
			Debug.LogError("car is missing. " + base.name + " cannot be returned to pool. Destroying audio object.", this);
			Object.Destroy(base.gameObject);
			return;
		}
		car.OnCarAboutToBeDestroyed -= ReturnToPool;
		SingletonBehaviour<TrainComponentPool>.Instance.ReturnAudioToPool(car, this);
		car = null;
		Deinitialize();
	}
}
