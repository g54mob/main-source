using System;
using System.Collections.Generic;
using System.Linq;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class EmptyHaulJobProceduralGenerator
{
	public static JobChainController GenerateEmptyHaulJobWithCarSpawning(StationController startingStation, Track startingTrack, List<TrainCarLivery> emptyCarLiveries, System.Random rng)
	{
		_ = SingletonBehaviour<YardTracksOrganizer>.Instance;
		_ = SingletonBehaviour<CarSpawner>.Instance;
		HashSet<TrainCarType_v2> hashSet = new HashSet<TrainCarType_v2>();
		foreach (TrainCarLivery emptyCarLivery in emptyCarLiveries)
		{
			hashSet.Add(emptyCarLivery.parentType);
		}
		float totalCarLiveriesLength = SingletonBehaviour<CarSpawner>.Instance.GetTotalCarLiveriesLength(emptyCarLiveries, includeSeparationBetweenCars: true);
		Tuple<StationController, Track> randomDestinationStationThatUsesCarTypes = GetRandomDestinationStationThatUsesCarTypes(hashSet, startingStation, totalCarLiveriesLength, rng);
		if (randomDestinationStationThatUsesCarTypes == null)
		{
			return null;
		}
		StationController item = randomDestinationStationThatUsesCarTypes.Item1;
		Track item2 = randomDestinationStationThatUsesCarTypes.Item2;
		RailTrack railTrack = startingTrack.RailTrack();
		List<TrainCar> list = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnTrackRandomOrientation(emptyCarLiveries, railTrack, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true);
		if (list == null)
		{
			return null;
		}
		List<Car> cars = list.Select((TrainCar tc) => tc.logicCar).ToList();
		CalculateBonusTimeLimitAndWage(startingStation, item, emptyCarLiveries, out var bonusTimeLimit, out var initialWage);
		LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
		HashSet<JobLicenseType_v2> hashSet2 = new HashSet<JobLicenseType_v2>();
		hashSet2.UnionWith(instance.GetRequiredLicensesForJobType(JobType.EmptyHaul));
		hashSet2.UnionWith(instance.GetRequiredLicensesForCarTypes(hashSet));
		JobLicenseType_v2 requiredLicenseForNumberOfTransportedCars = instance.GetRequiredLicenseForNumberOfTransportedCars(list.Count);
		if (requiredLicenseForNumberOfTransportedCars != null)
		{
			hashSet2.Add(requiredLicenseForNumberOfTransportedCars);
		}
		return GenerateEmptyHaulChainController(startingStation, item, startingTrack, cars, item2, bonusTimeLimit, initialWage, JobLicenseType_v2.ListToFlags(hashSet2));
	}

	public static JobChainController GenerateEmptyHaulJobWithExistingCars(StationController startingStation, Track startingTrack, List<Car> transportedCars, System.Random rng)
	{
		_ = SingletonBehaviour<YardTracksOrganizer>.Instance;
		CarSpawner instance = SingletonBehaviour<CarSpawner>.Instance;
		HashSet<TrainCarType_v2> hashSet = new HashSet<TrainCarType_v2>();
		foreach (Car transportedCar in transportedCars)
		{
			hashSet.Add(transportedCar.carType.parentType);
		}
		float totalTrainCarsLength = instance.GetTotalTrainCarsLength(transportedCars, includeSeparationBetweenCars: true);
		Tuple<StationController, Track> randomDestinationStationThatUsesCarTypes = GetRandomDestinationStationThatUsesCarTypes(hashSet, startingStation, totalTrainCarsLength, rng);
		if (randomDestinationStationThatUsesCarTypes == null)
		{
			return null;
		}
		StationController item = randomDestinationStationThatUsesCarTypes.Item1;
		Track item2 = randomDestinationStationThatUsesCarTypes.Item2;
		List<TrainCarLivery> transportedCarLiveries = transportedCars.Select((Car tc) => tc.carType).ToList();
		CalculateBonusTimeLimitAndWage(startingStation, item, transportedCarLiveries, out var bonusTimeLimit, out var initialWage);
		LicenseManager instance2 = SingletonBehaviour<LicenseManager>.Instance;
		HashSet<JobLicenseType_v2> hashSet2 = new HashSet<JobLicenseType_v2>();
		hashSet2.UnionWith(instance2.GetRequiredLicensesForJobType(JobType.EmptyHaul));
		hashSet2.UnionWith(instance2.GetRequiredLicensesForCarTypes(hashSet));
		JobLicenseType_v2 requiredLicenseForNumberOfTransportedCars = instance2.GetRequiredLicenseForNumberOfTransportedCars(transportedCars.Count);
		if (requiredLicenseForNumberOfTransportedCars != null)
		{
			hashSet2.Add(requiredLicenseForNumberOfTransportedCars);
		}
		return GenerateEmptyHaulChainController(startingStation, item, startingTrack, transportedCars, item2, bonusTimeLimit, initialWage, JobLicenseType_v2.ListToFlags(hashSet2));
	}

	private static JobChainController GenerateEmptyHaulChainController(StationController startingStation, StationController destStation, Track startingTrack, List<Car> cars, Track destStorageTrack, float bonusTimeLimit, float initialWage, JobLicenses requiredLicenses)
	{
		GameObject gameObject = new GameObject($"ChainJob[{JobType.EmptyHaul}]: {startingStation.logicStation.ID} - {destStation.logicStation.ID}");
		gameObject.transform.SetParent(startingStation.transform);
		JobChainController jobChainController = new JobChainController(gameObject);
		StationsChainData chainData = new StationsChainData(startingStation.stationInfo.YardID, destStation.stationInfo.YardID);
		jobChainController.carsForJobChain = cars;
		StaticEmptyHaulJobDefinition staticEmptyHaulJobDefinition = gameObject.AddComponent<StaticEmptyHaulJobDefinition>();
		staticEmptyHaulJobDefinition.PopulateBaseJobDefinition(startingStation.logicStation, bonusTimeLimit, initialWage, chainData, requiredLicenses);
		staticEmptyHaulJobDefinition.startingTrack = startingTrack;
		staticEmptyHaulJobDefinition.carsToTransport = cars;
		staticEmptyHaulJobDefinition.destinationTrack = destStorageTrack;
		jobChainController.AddJobDefinitionToChain(staticEmptyHaulJobDefinition);
		return jobChainController;
	}

	private static void CalculateBonusTimeLimitAndWage(StationController startingStation, StationController destStation, List<TrainCarLivery> transportedCarLiveries, out float bonusTimeLimit, out float initialWage)
	{
		float distanceBetweenStations = JobPaymentCalculator.GetDistanceBetweenStations(startingStation, destStation);
		bonusTimeLimit = JobPaymentCalculator.CalculateHaulBonusTimeLimit(distanceBetweenStations);
		initialWage = JobPaymentCalculator.CalculateJobPayment(JobType.EmptyHaul, distanceBetweenStations, ExtractEmptyHaulPaymentCalculationData(transportedCarLiveries));
	}

	private static Tuple<StationController, Track> GetRandomDestinationStationThatUsesCarTypes(HashSet<TrainCarType_v2> carTypesSet, StationController startingStation, float trainLength, System.Random rng)
	{
		List<StationController> stationsThatUseCarTypes = SingletonBehaviour<LogicController>.Instance.GetStationsThatUseCarTypes(carTypesSet, startingStation);
		if (stationsThatUseCarTypes.Count == 0)
		{
			Debug.LogError("Unexpected error! There is no station that uses all carTypesSets!");
			return null;
		}
		List<Tuple<StationController, Track>> stationsThatHaveEnoughSpaceForTrain = GetStationsThatHaveEnoughSpaceForTrain(stationsThatUseCarTypes, trainLength, rng);
		if (stationsThatHaveEnoughSpaceForTrain.Count == 0)
		{
			return null;
		}
		return GetRandomFromList(stationsThatHaveEnoughSpaceForTrain, rng);
	}

	private static List<Tuple<StationController, Track>> GetStationsThatHaveEnoughSpaceForTrain(List<StationController> stations, float requiredLength, System.Random rng)
	{
		List<Tuple<StationController, Track>> list = new List<Tuple<StationController, Track>>();
		YardTracksOrganizer instance = SingletonBehaviour<YardTracksOrganizer>.Instance;
		for (int i = 0; i < stations.Count; i++)
		{
			List<Track> storageTracks = stations[i].logicStation.yard.StorageTracks;
			List<Track> list2 = instance.FilterOutTracksWithoutRequiredFreeSpace(storageTracks, requiredLength);
			if (list2.Count > 0)
			{
				Track randomFromList = GetRandomFromList(list2, rng);
				list.Add(new Tuple<StationController, Track>(stations[i], randomFromList));
			}
		}
		return list;
	}

	private static PaymentCalculationData ExtractEmptyHaulPaymentCalculationData(List<TrainCarLivery> orderedCarLiveries)
	{
		if (orderedCarLiveries == null)
		{
			return null;
		}
		Dictionary<TrainCarLivery, int> dictionary = new Dictionary<TrainCarLivery, int>();
		foreach (TrainCarLivery orderedCarLivery in orderedCarLiveries)
		{
			if (!dictionary.ContainsKey(orderedCarLivery))
			{
				dictionary[orderedCarLivery] = 0;
			}
			dictionary[orderedCarLivery]++;
		}
		Dictionary<CargoType, int> cargoData = new Dictionary<CargoType, int>();
		return new PaymentCalculationData(dictionary, cargoData);
	}

	private static T GetRandomFromList<T>(List<T> list, System.Random rng)
	{
		return list[rng.Next(0, list.Count)];
	}
}
