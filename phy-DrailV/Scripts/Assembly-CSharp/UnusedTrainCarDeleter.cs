using System.Collections;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class UnusedTrainCarDeleter : SingletonBehaviour<UnusedTrainCarDeleter>
{
	public const float REQUIRED_SQR_DISTANCE_FROM_LOCO_TO_DELETE_IT = 16000000f;

	private const float DELETE_SQR_DISTANCE_FROM_TRAINCAR = 360000f;

	private const float DELETE_SQR_DISTANCE_FROM_PLAYER_SPAWNED_TRAINCAR = 9000000f;

	private const float DELETE_CARS_CHECK_PERIOD = 0.5f;

	private List<TrainCar> unusedTrainCarsMarkedForDelete;

	public new static string AllowAutoCreate()
	{
		return "[UnusedTrainCarDeleter]";
	}

	public List<TrainCar> GetUnusedTrainCarsList()
	{
		return unusedTrainCarsMarkedForDelete;
	}

	protected override void Awake()
	{
		base.Awake();
		unusedTrainCarsMarkedForDelete = new List<TrainCar>();
	}

	private void OnEnable()
	{
		StartCoroutine(TrainCarsDeleteCheck(0.5f));
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	public void ClearInvalidCarReferencesAfterManualDelete()
	{
		for (int num = unusedTrainCarsMarkedForDelete.Count - 1; num >= 0; num--)
		{
			TrainCar trainCar = unusedTrainCarsMarkedForDelete[num];
			if (trainCar == null || trainCar.logicCar == null)
			{
				unusedTrainCarsMarkedForDelete.RemoveAt(num);
			}
		}
	}

	public void MarkForDelete(Car unusedCar)
	{
		unusedTrainCarsMarkedForDelete.Add(unusedCar.TrainCar());
	}

	public void MarkForDelete(List<Car> unusedCars)
	{
		Dictionary<Car, TrainCar> logicCarToTrainCar = SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar;
		foreach (Car unusedCar in unusedCars)
		{
			unusedTrainCarsMarkedForDelete.Add(logicCarToTrainCar[unusedCar]);
		}
	}

	public void UnmarkFromDeleteList(TrainCar carToUnmark)
	{
		StopAllCoroutines();
		RemoveCarFromDeleteList(carToUnmark);
		StartCoroutine(TrainCarsDeleteCheck(0.5f));
	}

	public void UnmarkFromDeleteList(List<TrainCar> carsToUnmark)
	{
		StopAllCoroutines();
		foreach (TrainCar item in carsToUnmark)
		{
			RemoveCarFromDeleteList(item);
		}
		StartCoroutine(TrainCarsDeleteCheck(0.5f));
	}

	private void RemoveCarFromDeleteList(TrainCar carToRemoveFromList)
	{
		if (!unusedTrainCarsMarkedForDelete.Remove(carToRemoveFromList))
		{
			Debug.LogError("Unexpected state: carToRemoveFromList[" + carToRemoveFromList.ID + "] was not marked for deletion, but unmarking is attempted!");
		}
	}

	public void InstantConditionalDeleteOfUnusedCars(List<TrainCar> ignoreDeleteCars = null)
	{
		if (unusedTrainCarsMarkedForDelete.Count == 0)
		{
			return;
		}
		List<TrainCar> list = new List<TrainCar>();
		for (int num = unusedTrainCarsMarkedForDelete.Count - 1; num >= 0; num--)
		{
			TrainCar trainCar = unusedTrainCarsMarkedForDelete[num];
			if (trainCar == null || trainCar.logicCar == null)
			{
				unusedTrainCarsMarkedForDelete.RemoveAt(num);
			}
			else if ((ignoreDeleteCars == null || !ignoreDeleteCars.Contains(trainCar)) && AreDeleteConditionsFulfilled(trainCar))
			{
				unusedTrainCarsMarkedForDelete.RemoveAt(num);
				list.Add(trainCar);
			}
		}
		if (list.Count != 0)
		{
			SingletonBehaviour<CarSpawner>.Instance.DeleteTrainCars(list, forceInstantDestroy: true);
		}
	}

	public void ForceDeleteAllUnusedTrainCars()
	{
		if (unusedTrainCarsMarkedForDelete.Count != 0)
		{
			StopAllCoroutines();
			SingletonBehaviour<CarSpawner>.Instance.DeleteTrainCars(new List<TrainCar>(unusedTrainCarsMarkedForDelete), forceInstantDestroy: true);
			unusedTrainCarsMarkedForDelete.Clear();
			StartCoroutine(TrainCarsDeleteCheck(0.5f));
		}
	}

	public IEnumerator TrainCarsDeleteCheck(float period)
	{
		List<TrainCar> trainCarsToDelete = new List<TrainCar>();
		List<TrainCar> trainCarCandidatesForDelete = new List<TrainCar>();
		while (true)
		{
			yield return WaitFor.Seconds(period);
			if (PlayerManager.PlayerTransform == null || FastTravelController.IsFastTravelling || unusedTrainCarsMarkedForDelete.Count == 0)
			{
				continue;
			}
			trainCarCandidatesForDelete.Clear();
			for (int num = unusedTrainCarsMarkedForDelete.Count - 1; num >= 0; num--)
			{
				TrainCar trainCar = unusedTrainCarsMarkedForDelete[num];
				if (trainCar == null || trainCar.logicCar == null)
				{
					unusedTrainCarsMarkedForDelete.RemoveAt(num);
				}
				else if (AreDeleteConditionsFulfilled(trainCar))
				{
					unusedTrainCarsMarkedForDelete.RemoveAt(num);
					trainCarCandidatesForDelete.Add(trainCar);
				}
			}
			if (trainCarCandidatesForDelete.Count == 0)
			{
				continue;
			}
			yield return WaitFor.Seconds(period);
			trainCarsToDelete.Clear();
			for (int num2 = trainCarCandidatesForDelete.Count - 1; num2 >= 0; num2--)
			{
				TrainCar trainCar2 = trainCarCandidatesForDelete[num2];
				if (trainCar2 == null || trainCar2.logicCar == null)
				{
					trainCarCandidatesForDelete.RemoveAt(num2);
				}
				else if (AreDeleteConditionsFulfilled(trainCar2))
				{
					trainCarCandidatesForDelete.RemoveAt(num2);
					trainCarsToDelete.Add(trainCar2);
				}
				else
				{
					Debug.LogWarning("Returning " + trainCar2.name + " to unusedTrainCarsMarkedForDelete list. PlayerTransform was outside of DELETE_SQR_DISTANCE_FROM_TRAINCAR range of train car, but after short period it was back in range!");
					trainCarCandidatesForDelete.RemoveAt(num2);
					unusedTrainCarsMarkedForDelete.Add(trainCar2);
				}
			}
			if (trainCarsToDelete.Count != 0)
			{
				SingletonBehaviour<CarSpawner>.Instance.DeleteTrainCars(new List<TrainCar>(trainCarsToDelete));
			}
		}
	}

	private bool AreDeleteConditionsFulfilled(TrainCar trainCar)
	{
		if (trainCar.preventDelete)
		{
			return false;
		}
		if (trainCar.uniqueCar)
		{
			return false;
		}
		if (trainCar.carLivery.parentType.unusedCarDeletePreventionMode == TrainCarType_v2.UnusedCarDeletePreventionMode.OnlyManualDeletePossible)
		{
			return false;
		}
		Trainset trainset = trainCar.trainset;
		List<int> locoIndices = trainset.locoIndices;
		if (!trainCar.IsLoco)
		{
			if (locoIndices.Count > 0)
			{
				return false;
			}
		}
		else if (locoIndices.Count > 1)
		{
			for (int i = 0; i < locoIndices.Count; i++)
			{
				int index = locoIndices[i];
				TrainCar trainCar2 = trainset.cars[index];
				if (trainCar2.visitChecker != null && trainCar2.visitChecker.IsRecentlyVisited)
				{
					return false;
				}
			}
		}
		float sqrMagnitude = (trainCar.transform.position - PlayerManager.PlayerTransform.position).sqrMagnitude;
		float num = (CarTypes.IsAnyLocomotiveOrTender(trainCar.carLivery) ? 16000000f : (trainCar.playerSpawnedCar ? 9000000f : 360000f));
		if (!(sqrMagnitude > num))
		{
			return false;
		}
		if (trainCar.visitChecker != null && trainCar.visitChecker.IsRecentlyVisited)
		{
			return false;
		}
		if (trainCar.IsLoco)
		{
			foreach (TrainCar car in trainset.cars)
			{
				if (SingletonBehaviour<JobsManager>.Instance.GetJobOfCar(car.logicCar, onlyActiveJobs: true) != null)
				{
					return false;
				}
			}
		}
		return true;
	}
}
