using System;
using System.Collections;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class SpawnCarsTutorial : MonoBehaviour
{
	public Transform locoSpawnPoint;

	public TrainCarLivery locoLivery;

	public bool flipSpawnLoco;

	public Transform otherTrainCarSpawnPoint;

	public TrainCarLivery otherCarLivery;

	public bool flipSpawnOtherTrainCar;

	public TrainCar spawnedLoco;

	public TrainCar spawnedOtherCar;

	private Coroutine spawnCoro;

	[InspectorButton("SpawnTutorialCarsDebug", true, true)]
	public bool spawnTutorialCarsDebug;

	private IEnumerator DelayedSpawnCars(bool derailCargo, bool bothOnCargoTrack, Action callback = null)
	{
		while (SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress)
		{
			yield return null;
		}
		spawnedOtherCar = SingletonBehaviour<CarSpawner>.Instance.SpawnCarOnClosestTrack(otherTrainCarSpawnPoint.position, otherCarLivery, flipSpawnOtherTrainCar, playerSpawnedCar: false, uniqueCar: false);
		Debug.Log("[!!!] Cargo car kinematic before derail: " + spawnedOtherCar.rb.isKinematic, spawnedOtherCar);
		Vector3 locoSpawnPosition = (bothOnCargoTrack ? otherTrainCarSpawnPoint.position : locoSpawnPoint.position);
		if (bothOnCargoTrack)
		{
			yield return null;
		}
		spawnedLoco = SingletonBehaviour<CarSpawner>.Instance.SpawnCarOnClosestTrack(locoSpawnPosition, locoLivery, flipSpawnLoco, playerSpawnedCar: false, uniqueCar: false);
		if (derailCargo && (bool)spawnedOtherCar)
		{
			yield return null;
			spawnedOtherCar.Derail(suppressDerailSound: true);
			Vector3 eulerAngles = spawnedOtherCar.transform.rotation.eulerAngles;
			eulerAngles.y += 4f;
			spawnedOtherCar.transform.rotation = Quaternion.Euler(eulerAngles);
			Debug.Log("[!!!] Cargo car kinematic after derail: " + spawnedOtherCar.rb.isKinematic, spawnedOtherCar);
			SingletonBehaviour<CoroutineManager>.Instance.Run(FixRigidBodyKinematic(spawnedOtherCar));
		}
		if (spawnedLoco == null || spawnedOtherCar == null)
		{
			Debug.LogError("Unsuccessful spawning!");
			if (spawnedOtherCar != null)
			{
				SingletonBehaviour<CarSpawner>.Instance.DeleteCar(spawnedOtherCar);
			}
			if (spawnedLoco != null)
			{
				SingletonBehaviour<CarSpawner>.Instance.DeleteCar(spawnedLoco);
			}
		}
		spawnCoro = null;
		callback?.Invoke();
	}

	private IEnumerator FixRigidBodyKinematic(TrainCar car)
	{
		car.rb.isKinematic = false;
		while (Time.timeScale == 0f)
		{
			yield return null;
		}
		for (int i = 0; i < 30; i++)
		{
			car.rb.isKinematic = false;
			yield return null;
		}
	}

	private void SpawnTutorialCarsDebug()
	{
		SpawnTutorialCars(derailCargo: true, bothOnCargoTrack: false);
	}

	public void SpawnTutorialCars(bool derailCargo, bool bothOnCargoTrack, Action callback = null)
	{
		if (spawnCoro != null)
		{
			StopCoroutine(spawnCoro);
		}
		spawnCoro = StartCoroutine(DelayedSpawnCars(derailCargo, bothOnCargoTrack, callback));
	}
}
