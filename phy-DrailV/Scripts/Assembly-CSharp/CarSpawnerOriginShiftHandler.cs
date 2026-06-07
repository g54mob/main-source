using DV.Utils;
using UnityEngine;

public class CarSpawnerOriginShiftHandler : MonoBehaviour
{
	private void Start()
	{
		if (!SingletonBehaviour<WorldMover>.Instance)
		{
			Debug.Log("CarSpawnerOriginShiftHandler couldn't find WorldMover, removing itself.");
			Object.Destroy(this);
		}
		else
		{
			SetupListeners(on: true);
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<CarSpawner>.Instance.CarSpawned += OnCarSpawned;
			SingletonBehaviour<CarSpawner>.Instance.CarAboutToBeDeleted += OnCarAboutToBeDeleted;
		}
		else
		{
			SingletonBehaviour<CarSpawner>.Instance.CarSpawned -= OnCarSpawned;
			SingletonBehaviour<CarSpawner>.Instance.CarAboutToBeDeleted -= OnCarAboutToBeDeleted;
		}
	}

	private void OnCarSpawned(TrainCar car)
	{
		SingletonBehaviour<WorldMover>.Instance.AddObjectToMove(car.transform);
	}

	private void OnCarAboutToBeDeleted(TrainCar car)
	{
		int num = SingletonBehaviour<WorldMover>.Instance.objectsToMove.IndexOf(car.transform);
		if (num >= 0)
		{
			SingletonBehaviour<WorldMover>.Instance.objectsToMove.RemoveAt(num);
		}
	}
}
