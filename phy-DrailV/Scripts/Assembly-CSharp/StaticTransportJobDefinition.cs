using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class StaticTransportJobDefinition : StaticJobDefinition
{
	[Header("Transport job parameters")]
	[Tooltip("Cars to transport to destination")]
	public List<Car> carsToTransport;

	[Tooltip("Starting track of carsToTransport")]
	public Track startingTrack;

	[Tooltip("Destination track for cars")]
	public Track destinationTrack;

	public List<CargoType> transportedCargoPerCar;

	public List<float> cargoAmountPerCar;

	[Tooltip("Set to true, if you want to force correct state of the cars, otherwise if state of cars regarding cargo is not correct, it will generate errors")]
	public bool forceCorrectCargoStateOnCars;

	public override JobDefinitionDataBase GetJobDefinitionSaveData()
	{
		string[] guidsFromCars = StaticJobDefinition.GetGuidsFromCars(carsToTransport);
		if (guidsFromCars == null)
		{
			throw new Exception("Couldn't extract transportCarsGuids");
		}
		return new TransportJobDefinitionData(timeLimitForJob, initialWage, logicStation.ID, chainData.chainOriginYardId, chainData.chainDestinationYardId, (int)requiredLicenses, guidsFromCars, transportedCargoPerCar.ToArray(), cargoAmountPerCar.ToArray(), startingTrack.ID.FullID, destinationTrack.ID.FullID);
	}

	public override List<TrackReservation> GetRequiredTrackReservations()
	{
		float totalCarsLength = SingletonBehaviour<CarSpawner>.Instance.GetTotalCarsLength(carsToTransport, includeSeparationBetweenCars: true);
		return new List<TrackReservation>
		{
			new TrackReservation(destinationTrack, totalCarsLength)
		};
	}

	protected override void GenerateJob(Station jobOriginStation, float jobTimeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
	{
		if (carsToTransport != null && carsToTransport.Count > 0 && transportedCargoPerCar.Count == carsToTransport.Count && cargoAmountPerCar.Count == carsToTransport.Count && startingTrack != null && destinationTrack != null)
		{
			base.job = JobsGenerator.CreateTransportJob(jobOriginStation, chainData, carsToTransport, destinationTrack, startingTrack, transportedCargoPerCar, cargoAmountPerCar, forceCorrectCargoStateOnCars, jobTimeLimit, initialWage, forcedJobId, requiredLicenses);
			return;
		}
		carsToTransport = null;
		startingTrack = null;
		destinationTrack = null;
		transportedCargoPerCar = null;
		cargoAmountPerCar = null;
		base.job = null;
		Debug.LogError("Transport job not created, bad parameters!");
	}
}
