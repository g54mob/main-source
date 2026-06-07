using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class StaticShuntingLoadJobDefinition : StaticJobDefinition
{
	[Header("ShuntingLoad job parameters")]
	[Tooltip("Set of cars per their starting track")]
	public List<CarsPerTrack> carsPerStartingTrack;

	[Tooltip("WarehouseMachine where cars should be loaded with cargo")]
	public WarehouseMachine loadMachine;

	[Tooltip("Set of cars per cargo type they should load")]
	public List<CarsPerCargoType> loadData;

	[Tooltip("Destination track for cars after loading cargo")]
	public Track destinationTrack;

	[Tooltip("Set to true, if you want to force correct state of the cars, otherwise if state of cars regarding cargo is not correct, it will generate errors")]
	public bool forceCorrectCargoStateOnCars;

	public override JobDefinitionDataBase GetJobDefinitionSaveData()
	{
		CarGuidsPerTrackId[] array = new CarGuidsPerTrackId[carsPerStartingTrack.Count];
		for (int i = 0; i < carsPerStartingTrack.Count; i++)
		{
			CarsPerTrack carsPerTrack = carsPerStartingTrack[i];
			string[] guidsFromCars = StaticJobDefinition.GetGuidsFromCars(carsPerTrack.cars);
			if (guidsFromCars == null)
			{
				throw new Exception("Couldn't extract carGuidsPerStartingTrack");
			}
			string fullID = carsPerTrack.track.ID.FullID;
			array[i] = new CarGuidsPerTrackId(fullID, guidsFromCars);
		}
		CarGuidsPerCargo[] array2 = new CarGuidsPerCargo[loadData.Count];
		for (int j = 0; j < loadData.Count; j++)
		{
			CarsPerCargoType carsPerCargoType = loadData[j];
			string[] guidsFromCars2 = StaticJobDefinition.GetGuidsFromCars(carsPerCargoType.cars);
			if (guidsFromCars2 == null)
			{
				throw new Exception("Couldn't extract carGuidsPerCargo");
			}
			array2[j] = new CarGuidsPerCargo(carsPerCargoType.cargoType, guidsFromCars2, carsPerCargoType.totalCargoAmount);
		}
		return new LoadJobDefinitionData(timeLimitForJob, initialWage, logicStation.ID, chainData.chainOriginYardId, chainData.chainDestinationYardId, (int)requiredLicenses, array, array2, loadMachine.ID, destinationTrack.ID.FullID);
	}

	public override List<TrackReservation> GetRequiredTrackReservations()
	{
		CarSpawner instance = SingletonBehaviour<CarSpawner>.Instance;
		float num = 0f;
		int num2 = 0;
		for (int i = 0; i < carsPerStartingTrack.Count; i++)
		{
			num += instance.GetTotalCarsLength(carsPerStartingTrack[i].cars);
			num2 += carsPerStartingTrack[i].cars.Count;
		}
		float reservedLength = num + instance.GetSeparationLengthBetweenCars(num2);
		return new List<TrackReservation>
		{
			new TrackReservation(destinationTrack, reservedLength)
		};
	}

	protected override void GenerateJob(Station jobOriginStation, float jobTimeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
	{
		if (carsPerStartingTrack != null && carsPerStartingTrack.Count > 0 && loadMachine != null && loadData != null && loadData.Count > 0 && destinationTrack != null)
		{
			base.job = JobsGenerator.CreateShuntingLoadJob(jobOriginStation, chainData, carsPerStartingTrack, destinationTrack, loadMachine, loadData, forceCorrectCargoStateOnCars, jobTimeLimit, initialWage, forcedJobId, requiredLicenses);
			return;
		}
		carsPerStartingTrack = null;
		loadMachine = null;
		loadData = null;
		destinationTrack = null;
		base.job = null;
		Debug.LogError("ShuntingLoad job not created, bad parameters", this);
	}
}
