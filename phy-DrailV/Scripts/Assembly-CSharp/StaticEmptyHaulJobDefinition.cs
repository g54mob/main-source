using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class StaticEmptyHaulJobDefinition : StaticJobDefinition
{
	[Tooltip("Cars to transport to destination")]
	[Header("EmptyHaul job parameters")]
	public List<Car> carsToTransport;

	[Tooltip("Starting track of carsToTransport")]
	public Track startingTrack;

	[Tooltip("Destination track for TrainCars")]
	public Track destinationTrack;

	public override JobDefinitionDataBase GetJobDefinitionSaveData()
	{
		string[] guidsFromCars = StaticJobDefinition.GetGuidsFromCars(carsToTransport);
		if (guidsFromCars == null)
		{
			throw new Exception("Couldn't extract transportCarsGuids");
		}
		return new EmptyHaulJobDefinitionData(timeLimitForJob, initialWage, logicStation.ID, chainData.chainOriginYardId, chainData.chainDestinationYardId, (int)requiredLicenses, guidsFromCars, startingTrack.ID.FullID, destinationTrack.ID.FullID);
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
		if (carsToTransport != null && carsToTransport.Count > 0 && startingTrack != null && destinationTrack != null)
		{
			base.job = JobsGenerator.CreateEmptyHaulJob(jobOriginStation, chainData, carsToTransport, startingTrack, destinationTrack, jobTimeLimit, initialWage, forcedJobId, requiredLicenses);
			return;
		}
		carsToTransport = null;
		startingTrack = null;
		destinationTrack = null;
		base.job = null;
		Debug.LogError("EmptyHaul job was not created, bad parameters");
	}
}
