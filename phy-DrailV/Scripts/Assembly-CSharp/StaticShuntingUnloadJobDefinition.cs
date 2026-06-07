using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class StaticShuntingUnloadJobDefinition : StaticJobDefinition
{
	[Header("ShuntingUnload job parameters")]
	[Tooltip("Starting track for cars")]
	public Track startingTrack;

	[Tooltip("WarehouseMachine where cars should unload cargo")]
	public WarehouseMachine unloadMachine;

	[Tooltip("Set of cars per cargo type they should unload")]
	public List<CarsPerCargoType> unloadData;

	[Tooltip("Set of cars per their destination track")]
	public List<CarsPerTrack> carsPerDestinationTrack;

	[Tooltip("Set to true, if you want to force correct state of the cars, otherwise if state of cars regarding cargo is not correct, it will generate errors")]
	public bool forceCorrectCargoStateOnCars;

	public override JobDefinitionDataBase GetJobDefinitionSaveData()
	{
		CarGuidsPerTrackId[] array = new CarGuidsPerTrackId[carsPerDestinationTrack.Count];
		for (int i = 0; i < carsPerDestinationTrack.Count; i++)
		{
			CarsPerTrack carsPerTrack = carsPerDestinationTrack[i];
			string[] guidsFromCars = StaticJobDefinition.GetGuidsFromCars(carsPerTrack.cars);
			if (guidsFromCars == null)
			{
				throw new Exception("Couldn't extract carGuidsPerDestinationTrack");
			}
			string fullID = carsPerTrack.track.ID.FullID;
			array[i] = new CarGuidsPerTrackId(fullID, guidsFromCars);
		}
		CarGuidsPerCargo[] array2 = new CarGuidsPerCargo[unloadData.Count];
		for (int j = 0; j < unloadData.Count; j++)
		{
			CarsPerCargoType carsPerCargoType = unloadData[j];
			string[] guidsFromCars2 = StaticJobDefinition.GetGuidsFromCars(carsPerCargoType.cars);
			if (guidsFromCars2 == null)
			{
				throw new Exception("Couldn't extract carGuidsPerCargo");
			}
			array2[j] = new CarGuidsPerCargo(carsPerCargoType.cargoType, guidsFromCars2, carsPerCargoType.totalCargoAmount);
		}
		return new UnloadJobDefinitionData(timeLimitForJob, initialWage, logicStation.ID, chainData.chainOriginYardId, chainData.chainDestinationYardId, (int)requiredLicenses, startingTrack.ID.FullID, array, array2, unloadMachine.ID);
	}

	public override List<TrackReservation> GetRequiredTrackReservations()
	{
		CarSpawner instance = SingletonBehaviour<CarSpawner>.Instance;
		List<TrackReservation> list = new List<TrackReservation>();
		for (int i = 0; i < carsPerDestinationTrack.Count; i++)
		{
			float totalCarsLength = instance.GetTotalCarsLength(carsPerDestinationTrack[i].cars, includeSeparationBetweenCars: true);
			list.Add(new TrackReservation(carsPerDestinationTrack[i].track, totalCarsLength));
		}
		return list;
	}

	protected override void GenerateJob(Station jobOriginStation, float jobTimeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
	{
		if (startingTrack != null && unloadMachine != null && unloadData != null && unloadData.Count > 0 && carsPerDestinationTrack != null && carsPerDestinationTrack.Count > 0)
		{
			base.job = JobsGenerator.CreateShuntingUnloadJob(jobOriginStation, chainData, startingTrack, carsPerDestinationTrack, unloadMachine, unloadData, forceCorrectCargoStateOnCars, jobTimeLimit, initialWage, forcedJobId, requiredLicenses);
			return;
		}
		base.job = null;
		Debug.LogError("ShuntingUnload job not created, bad parameters", this);
	}
}
