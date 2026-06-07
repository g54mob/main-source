using System;
using System.Collections.Generic;
using DV;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

public class StationProceduralJobGenerator
{
	private enum ChainJobType
	{
		Invalid = 0,
		Out = 1,
		In = 2,
		Empty = 3
	}

	private class CarTypesPerTrackData
	{
		public readonly Track track;

		public readonly List<TrainCarLivery> carTypesForTrack;

		public readonly float totalRequiredLength;

		public CarTypesPerTrackData(Track track, List<TrainCarLivery> carTypesForTrack, float totalRequiredLength)
		{
			this.track = track;
			this.carTypesForTrack = carTypesForTrack;
			this.totalRequiredLength = totalRequiredLength;
		}
	}

	private class CarTypesPerCargoTypeData
	{
		public readonly List<TrainCarLivery> carTypes;

		public readonly CargoType cargoType;

		public readonly float totalCargoAmount;

		public CarTypesPerCargoTypeData(List<TrainCarLivery> carTypes, CargoType cargoType, float totalCargoAmount)
		{
			this.carTypes = carTypes;
			this.cargoType = cargoType;
			this.totalCargoAmount = totalCargoAmount;
		}
	}

	public const bool RANDOM_CAR_ORIENTATION = true;

	private const float FORCE_HAUL_JOBS_OUT_TRACKS_PERCENTAGE = 0.6f;

	private StationProceduralJobsRuleset generationRuleset;

	private StationController stationController;

	private Yard stYard;

	private YardTracksOrganizer yto;

	private CarSpawner cs;

	private LicenseManager licenseManager;

	private System.Random currentRng_;

	private System.Random currentRng
	{
		get
		{
			if (currentRng_ == null)
			{
				currentRng_ = new System.Random(Environment.TickCount);
				Debug.LogError("This shouldn't happen, trying to use currentRng, but it's not initialized. Creating new instance, but this shouldn't happen, check it out!");
			}
			return currentRng_;
		}
		set
		{
			if (currentRng_ != value)
			{
				currentRng_ = value;
			}
		}
	}

	public StationProceduralJobGenerator(StationController stationController)
	{
		this.stationController = stationController;
		stYard = stationController.logicStation.yard;
		generationRuleset = stationController.proceduralJobsRuleset;
		licenseManager = SingletonBehaviour<LicenseManager>.Instance;
		yto = SingletonBehaviour<YardTracksOrganizer>.Instance;
		cs = SingletonBehaviour<CarSpawner>.Instance;
	}

	public JobChainController GenerateJobChain(System.Random rng, bool forceJobWithLicenseRequirementFulfilled)
	{
		if (!generationRuleset.loadStartingJobSupported && !generationRuleset.haulStartingJobSupported && !generationRuleset.unloadStartingJobSupported && !generationRuleset.emptyHaulStartingJobSupported)
		{
			return null;
		}
		currentRng = rng;
		List<JobType> list = new List<JobType>();
		if (generationRuleset.loadStartingJobSupported)
		{
			list.Add(JobType.ShuntingLoad);
		}
		if (generationRuleset.emptyHaulStartingJobSupported)
		{
			list.Add(JobType.EmptyHaul);
		}
		int count = yto.FilterOutOccupiedTracks(stYard.TransferOutTracks).Count;
		if (generationRuleset.haulStartingJobSupported && count > 0)
		{
			list.Add(JobType.Transport);
		}
		int count2 = yto.FilterOutReservedTracks(yto.FilterOutOccupiedTracks(stYard.TransferInTracks)).Count;
		if (generationRuleset.unloadStartingJobSupported && count2 > 0)
		{
			list.Add(JobType.ShuntingUnload);
		}
		JobChainController result = null;
		if (forceJobWithLicenseRequirementFulfilled)
		{
			if (list.Contains(JobType.Transport) && licenseManager.IsJobLicenseAcquired(JobLicenses.FreightHaul.ToV2()))
			{
				result = GenerateOutChainJob(JobType.Transport, forceFulfilledLicenseRequirements: true);
				if (result != null)
				{
					return result;
				}
			}
			if (list.Contains(JobType.EmptyHaul) && licenseManager.IsJobLicenseAcquired(JobLicenses.LogisticalHaul.ToV2()))
			{
				result = GenerateEmptyHaul(forceFulfilledLicenseRequirements: true);
				if (result != null)
				{
					return result;
				}
			}
			if (list.Contains(JobType.ShuntingLoad) && licenseManager.IsJobLicenseAcquired(JobLicenses.Shunting.ToV2()))
			{
				result = GenerateOutChainJob(JobType.ShuntingLoad, forceFulfilledLicenseRequirements: true);
				if (result != null)
				{
					return result;
				}
			}
			if (list.Contains(JobType.ShuntingUnload) && licenseManager.IsJobLicenseAcquired(JobLicenses.Shunting.ToV2()))
			{
				result = GenerateInChainJob(JobType.ShuntingUnload, forceFulfilledLicenseRequirements: true);
				if (result != null)
				{
					return result;
				}
			}
			return null;
		}
		if (list.Contains(JobType.Transport) && count > Mathf.FloorToInt(0.39999998f * (float)stYard.TransferOutTracks.Count))
		{
			JobType startingJobType = JobType.Transport;
			result = GenerateOutChainJob(startingJobType);
		}
		else
		{
			if (list.Count == 0)
			{
				return null;
			}
			JobType startingJobType = GetRandomFromList(list);
			switch (GetChainGroup(startingJobType))
			{
			case ChainJobType.Out:
				result = GenerateOutChainJob(startingJobType);
				break;
			case ChainJobType.In:
				result = GenerateInChainJob(startingJobType);
				break;
			case ChainJobType.Empty:
				result = GenerateEmptyHaul();
				break;
			}
		}
		currentRng = null;
		return result;
	}

	private JobChainController GenerateInChainJob(JobType startingJobType, bool forceFulfilledLicenseRequirements = false)
	{
		List<CargoGroup> list;
		int maxNumberOfCars;
		if (forceFulfilledLicenseRequirements)
		{
			list = FilterOutUnlicensedCargoGroups(startingJobType);
			maxNumberOfCars = licenseManager.GetMaxNumberOfCarsPerJobWithAcquiredJobLicenses();
		}
		else
		{
			list = generationRuleset.inputCargoGroups;
			maxNumberOfCars = generationRuleset.maxCarsPerJob;
		}
		if (list.Count == 0)
		{
			return null;
		}
		List<CargoType> cargoTypes;
		List<TrainCarLivery> allCarLiveries;
		CargoGroup pickedCargoGroup;
		List<CarTypesPerCargoTypeData> list2 = GenerateBaseCargoTrainData(generationRuleset.minCarsPerJob, maxNumberOfCars, list, out cargoTypes, out allCarLiveries, out pickedCargoGroup);
		HashSet<JobLicenseType_v2> hashSet = new HashSet<JobLicenseType_v2>();
		hashSet.UnionWith(licenseManager.GetRequiredLicensesForCargoTypes(cargoTypes));
		JobLicenseType_v2 requiredLicenseForNumberOfTransportedCars = licenseManager.GetRequiredLicenseForNumberOfTransportedCars(allCarLiveries.Count);
		if (requiredLicenseForNumberOfTransportedCars != null)
		{
			hashSet.Add(requiredLicenseForNumberOfTransportedCars);
		}
		float approxLengthOfWholeTrain = cs.GetTotalCarLiveriesLength(allCarLiveries, includeSeparationBetweenCars: true);
		List<Track> tracks = yto.FilterOutReservedTracks(yto.FilterOutOccupiedTracks(stYard.TransferInTracks));
		tracks = yto.FilterOutTracksWithoutRequiredFreeSpace(tracks, approxLengthOfWholeTrain);
		Track track = ((tracks.Count > 0) ? GetRandomFromList(tracks) : null);
		if (track == null)
		{
			return null;
		}
		List<WarehouseMachine> warehouseMachinesThatSupportCargoTypes = stationController.logicStation.yard.GetWarehouseMachinesThatSupportCargoTypes(cargoTypes);
		if (warehouseMachinesThatSupportCargoTypes.Count == 0)
		{
			Debug.LogError("Starting station[" + stationController.logicStation.ID + "] doesn't have required warehouse machine that supports all cargo types for the job. This shouldn't happen ever!", stationController);
			return null;
		}
		warehouseMachinesThatSupportCargoTypes.RemoveAll((WarehouseMachine machine) => machine.WarehouseTrack.length < (double)approxLengthOfWholeTrain);
		if (warehouseMachinesThatSupportCargoTypes.Count == 0)
		{
			return null;
		}
		WarehouseMachine randomFromList = GetRandomFromList(warehouseMachinesThatSupportCargoTypes);
		List<CarTypesPerTrackData> randomSortingOfCarLiveriesOnTracks = GetRandomSortingOfCarLiveriesOnTracks(stYard.StorageTracks, allCarLiveries, generationRuleset.maxShuntingStorageTracks);
		if (randomSortingOfCarLiveriesOnTracks == null)
		{
			return null;
		}
		List<StationController> stations = pickedCargoGroup.stations;
		if (stations.Count == 0)
		{
			Debug.LogError("There is no station that delivers all cargoTypes to this station! This should never happen. Setup for generationRuleset is bad! This chain job won't be generated!", stationController);
			return null;
		}
		StationController randomFromList2 = GetRandomFromList(stations);
		GameObject gameObject = new GameObject($"ChainJob[{startingJobType}]: {randomFromList2.logicStation.ID} - {stationController.logicStation.ID}");
		gameObject.transform.SetParent(stationController.transform);
		JobChainControllerWithEmptyHaulGeneration jobChainControllerWithEmptyHaulGeneration = new JobChainControllerWithEmptyHaulGeneration(gameObject);
		StationsChainData stationsChainData = new StationsChainData(randomFromList2.stationInfo.YardID, stationController.stationInfo.YardID);
		if (startingJobType == JobType.ShuntingUnload)
		{
			int count = randomSortingOfCarLiveriesOnTracks.Count;
			float bonusTimeLimit = JobPaymentCalculator.CalculateShuntingBonusTimeLimit(count);
			float distanceInMeters = (float)count * 500f;
			float initialWage = JobPaymentCalculator.CalculateJobPayment(JobType.ShuntingUnload, distanceInMeters, ExtractPaymentCalculationData(list2));
			StaticShuntingUnloadJobDefinition staticShuntingUnloadJobDefinition = null;
			if (jobChainControllerWithEmptyHaulGeneration.IsFirstJobInChainInitialized() && jobChainControllerWithEmptyHaulGeneration.AreCarsInitialized())
			{
				Debug.LogError($"This should not happen. {JobType.ShuntingUnload} job should always have already spawned cars!", stationController);
			}
			else
			{
				Track startingTrack = track;
				HashSet<JobLicenseType_v2> hashSet2 = new HashSet<JobLicenseType_v2>();
				hashSet2.UnionWith(hashSet);
				hashSet2.UnionWith(licenseManager.GetRequiredLicensesForJobType(JobType.ShuntingUnload));
				staticShuntingUnloadJobDefinition = PopulateShuntingUnloadJobDefinitionWithCarSpawning(jobChainControllerWithEmptyHaulGeneration, stationController.logicStation, startingTrack, randomFromList, list2, randomSortingOfCarLiveriesOnTracks, allCarLiveries, bonusTimeLimit, initialWage, stationsChainData, JobLicenseType_v2.ListToFlags(hashSet2));
			}
			if (staticShuntingUnloadJobDefinition == null)
			{
				jobChainControllerWithEmptyHaulGeneration.DestroyChain();
				return null;
			}
			jobChainControllerWithEmptyHaulGeneration.AddJobDefinitionToChain(staticShuntingUnloadJobDefinition);
		}
		else
		{
			Debug.LogError(string.Format("Unexpected {0}: {1}!", "startingJobType", startingJobType));
		}
		jobChainControllerWithEmptyHaulGeneration.FinalizeSetupAndGenerateFirstJob();
		return jobChainControllerWithEmptyHaulGeneration;
	}

	private JobChainController GenerateOutChainJob(JobType startingJobType, bool forceFulfilledLicenseRequirements = false)
	{
		List<CargoGroup> list;
		int maxNumberOfCars;
		if (forceFulfilledLicenseRequirements)
		{
			list = FilterOutUnlicensedCargoGroups(startingJobType);
			maxNumberOfCars = licenseManager.GetMaxNumberOfCarsPerJobWithAcquiredJobLicenses();
		}
		else
		{
			list = generationRuleset.outputCargoGroups;
			maxNumberOfCars = generationRuleset.maxCarsPerJob;
		}
		if (list.Count == 0)
		{
			return null;
		}
		List<CargoType> cargoTypes;
		List<TrainCarLivery> allCarLiveries;
		CargoGroup pickedCargoGroup;
		List<CarTypesPerCargoTypeData> list2 = GenerateBaseCargoTrainData(generationRuleset.minCarsPerJob, maxNumberOfCars, list, out cargoTypes, out allCarLiveries, out pickedCargoGroup);
		HashSet<JobLicenseType_v2> hashSet = new HashSet<JobLicenseType_v2>();
		hashSet.UnionWith(licenseManager.GetRequiredLicensesForCargoTypes(cargoTypes));
		JobLicenseType_v2 requiredLicenseForNumberOfTransportedCars = licenseManager.GetRequiredLicenseForNumberOfTransportedCars(allCarLiveries.Count);
		if (requiredLicenseForNumberOfTransportedCars != null)
		{
			hashSet.Add(requiredLicenseForNumberOfTransportedCars);
		}
		float approxLengthOfWholeTrain = cs.GetTotalCarLiveriesLength(allCarLiveries, includeSeparationBetweenCars: true);
		List<Track> tracks = ((startingJobType == JobType.Transport) ? yto.FilterOutOccupiedTracks(stYard.TransferOutTracks) : stYard.TransferOutTracks);
		tracks = yto.FilterOutTracksWithoutRequiredFreeSpace(tracks, approxLengthOfWholeTrain);
		Track track = ((tracks.Count > 0) ? GetRandomFromList(tracks) : null);
		if (track == null)
		{
			return null;
		}
		List<WarehouseMachine> warehouseMachinesThatSupportCargoTypes = this.stationController.logicStation.yard.GetWarehouseMachinesThatSupportCargoTypes(cargoTypes);
		if (warehouseMachinesThatSupportCargoTypes.Count == 0)
		{
			Debug.LogError("Starting station[" + this.stationController.logicStation.ID + "] doesn't have required warehouse machine that supports all cargo types for the job. This shouldn't happen ever!", this.stationController);
			return null;
		}
		warehouseMachinesThatSupportCargoTypes.RemoveAll((WarehouseMachine machine) => machine.WarehouseTrack.length < (double)approxLengthOfWholeTrain);
		if (warehouseMachinesThatSupportCargoTypes.Count == 0)
		{
			return null;
		}
		WarehouseMachine randomFromList = GetRandomFromList(warehouseMachinesThatSupportCargoTypes);
		List<StationController> list3 = new List<StationController>(pickedCargoGroup.stations);
		if (list3 == null || list3.Count == 0)
		{
			Debug.LogError(string.Format("There is no destination station that accepts {0}: {1}! This should never happen. Setup for {2} is bad! This chain job won't be generated!", "cargoTypes", cargoTypes, "generationRuleset"), this.stationController);
			return null;
		}
		StationController stationController = null;
		Track track2 = null;
		List<CarTypesPerTrackData> list4 = null;
		WarehouseMachine unloadMachine = null;
		while (true)
		{
			bool flag = true;
			stationController = GetRandomFromList(list3);
			List<Track> tracks2 = yto.FilterOutOccupiedTracks(stationController.logicStation.yard.TransferInTracks);
			tracks2 = yto.FilterOutTracksWithoutRequiredFreeSpace(tracks2, approxLengthOfWholeTrain);
			track2 = ((tracks2.Count > 0) ? GetRandomFromList(tracks2) : null);
			if (track2 == null)
			{
				flag = false;
			}
			List<WarehouseMachine> warehouseMachinesThatSupportCargoTypes2 = stationController.logicStation.yard.GetWarehouseMachinesThatSupportCargoTypes(cargoTypes);
			if (warehouseMachinesThatSupportCargoTypes2.Count > 0)
			{
				warehouseMachinesThatSupportCargoTypes2.RemoveAll((WarehouseMachine machine) => machine.WarehouseTrack.length < (double)approxLengthOfWholeTrain);
				if (warehouseMachinesThatSupportCargoTypes2.Count > 0)
				{
					unloadMachine = GetRandomFromList(warehouseMachinesThatSupportCargoTypes2);
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				Debug.LogError("Destination station[" + stationController.logicStation.ID + "] doesn't have required warehouse machine that supports all cargo types for the job. This shouldn't happen ever!", stationController);
				flag = false;
			}
			list4 = GetRandomSortingOfCarLiveriesOnTracks(stationController.logicStation.yard.StorageTracks, allCarLiveries, stationController.proceduralJobsRuleset.maxShuntingStorageTracks);
			if (list4 == null)
			{
				flag = false;
			}
			if (flag)
			{
				break;
			}
			list3.Remove(stationController);
			if (list3.Count == 0)
			{
				return null;
			}
		}
		GameObject gameObject = new GameObject($"ChainJob[{startingJobType}]: {this.stationController.logicStation.ID} - {stationController.logicStation.ID}");
		gameObject.transform.SetParent(this.stationController.transform);
		JobChainControllerWithEmptyHaulGeneration jobChainControllerWithEmptyHaulGeneration = new JobChainControllerWithEmptyHaulGeneration(gameObject);
		StationsChainData stationsChainData = new StationsChainData(this.stationController.stationInfo.YardID, stationController.stationInfo.YardID);
		switch (startingJobType)
		{
		case JobType.ShuntingLoad:
		{
			List<CarTypesPerTrackData> randomSortingOfCarLiveriesOnTracks = GetRandomSortingOfCarLiveriesOnTracks(stYard.StorageTracks, allCarLiveries, generationRuleset.maxShuntingStorageTracks);
			if (randomSortingOfCarLiveriesOnTracks == null)
			{
				jobChainControllerWithEmptyHaulGeneration.DestroyChain();
				return null;
			}
			int count = randomSortingOfCarLiveriesOnTracks.Count;
			float bonusTimeLimit = JobPaymentCalculator.CalculateShuntingBonusTimeLimit(count);
			float distanceInMeters = (float)count * 500f;
			float initialWage = JobPaymentCalculator.CalculateJobPayment(JobType.ShuntingLoad, distanceInMeters, ExtractPaymentCalculationData(list2));
			Track destinationTrack = track;
			StaticShuntingLoadJobDefinition staticShuntingLoadJobDefinition = null;
			if (jobChainControllerWithEmptyHaulGeneration.IsFirstJobInChainInitialized() && jobChainControllerWithEmptyHaulGeneration.AreCarsInitialized())
			{
				Debug.LogError($"This should not happen. {JobType.ShuntingLoad} job should always spawn cars!", this.stationController);
			}
			else
			{
				HashSet<JobLicenseType_v2> hashSet2 = new HashSet<JobLicenseType_v2>();
				hashSet2.UnionWith(hashSet);
				hashSet2.UnionWith(licenseManager.GetRequiredLicensesForJobType(JobType.ShuntingLoad));
				staticShuntingLoadJobDefinition = PopulateShuntingLoadJobDefinitionWithCarSpawning(jobChainControllerWithEmptyHaulGeneration, this.stationController.logicStation, randomSortingOfCarLiveriesOnTracks, randomFromList, list2, destinationTrack, bonusTimeLimit, initialWage, stationsChainData, JobLicenseType_v2.ListToFlags(hashSet2));
			}
			if (staticShuntingLoadJobDefinition == null)
			{
				jobChainControllerWithEmptyHaulGeneration.DestroyChain();
				return null;
			}
			jobChainControllerWithEmptyHaulGeneration.AddJobDefinitionToChain(staticShuntingLoadJobDefinition);
			goto case JobType.Transport;
		}
		case JobType.Transport:
		{
			List<CargoType> list5 = new List<CargoType>();
			List<float> list6 = new List<float>();
			for (int num = 0; num < list2.Count; num++)
			{
				float num2 = list2[num].totalCargoAmount;
				int count2 = list2[num].carTypes.Count;
				for (int num3 = 0; num3 < count2; num3++)
				{
					list5.Add(list2[num].cargoType);
					list6.Add(1f);
					num2 -= 1f;
				}
				if (num2 != 0f)
				{
					Debug.LogError(string.Format("This shouldn't happen ever. Sum of {0} for cargo type and totalCargoAmount in {1}[{2}] are not matching! This might be because {3} is not used anymore!", "cargoAmountPerCar", "jobCargoData", num, "TRAINCAR_DEFAULT_CAPACITY"));
					jobChainControllerWithEmptyHaulGeneration.DestroyChain();
					return null;
				}
			}
			Track startingTrack = track;
			Track destinationTrack2 = track2;
			float distanceBetweenStations = JobPaymentCalculator.GetDistanceBetweenStations(this.stationController, stationController);
			float bonusTimeLimit2 = JobPaymentCalculator.CalculateHaulBonusTimeLimit(distanceBetweenStations);
			float initialWage2 = JobPaymentCalculator.CalculateJobPayment(JobType.Transport, distanceBetweenStations, ExtractPaymentCalculationData(list2));
			StaticTransportJobDefinition staticTransportJobDefinition = null;
			HashSet<JobLicenseType_v2> hashSet3 = new HashSet<JobLicenseType_v2>();
			hashSet3.UnionWith(hashSet);
			hashSet3.UnionWith(licenseManager.GetRequiredLicensesForJobType(JobType.Transport));
			if (jobChainControllerWithEmptyHaulGeneration.IsFirstJobInChainInitialized() && jobChainControllerWithEmptyHaulGeneration.AreCarsInitialized())
			{
				List<Car> carsForJobChain = jobChainControllerWithEmptyHaulGeneration.carsForJobChain;
				staticTransportJobDefinition = PopulateHaulJobDefinitionWithExistingCars(jobChainControllerWithEmptyHaulGeneration.jobChainGO, this.stationController.logicStation, startingTrack, destinationTrack2, carsForJobChain, list5, list6, bonusTimeLimit2, initialWage2, stationsChainData, JobLicenseType_v2.ListToFlags(hashSet3));
			}
			else
			{
				staticTransportJobDefinition = PopulateHaulJobDefinitionWithCarSpawning(jobChainControllerWithEmptyHaulGeneration, this.stationController.logicStation, startingTrack, destinationTrack2, allCarLiveries, list5, list6, bonusTimeLimit2, initialWage2, stationsChainData, JobLicenseType_v2.ListToFlags(hashSet3));
			}
			if (staticTransportJobDefinition == null)
			{
				jobChainControllerWithEmptyHaulGeneration.DestroyChain();
				return null;
			}
			jobChainControllerWithEmptyHaulGeneration.AddJobDefinitionToChain(staticTransportJobDefinition);
			goto case JobType.ShuntingUnload;
		}
		case JobType.ShuntingUnload:
		{
			int count3 = list4.Count;
			float bonusTimeLimit3 = JobPaymentCalculator.CalculateShuntingBonusTimeLimit(count3);
			float distanceInMeters2 = (float)count3 * 500f;
			float initialWage3 = JobPaymentCalculator.CalculateJobPayment(JobType.ShuntingLoad, distanceInMeters2, ExtractPaymentCalculationData(list2));
			StaticShuntingUnloadJobDefinition staticShuntingUnloadJobDefinition = null;
			if (jobChainControllerWithEmptyHaulGeneration.IsFirstJobInChainInitialized() && jobChainControllerWithEmptyHaulGeneration.AreCarsInitialized())
			{
				Track startingTrack2 = track2;
				List<Car> carsForJobChain2 = jobChainControllerWithEmptyHaulGeneration.carsForJobChain;
				List<CarsPerCargoType> list7 = ExtractCarsPerCargoType(carsForJobChain2, list2);
				if (list7 == null)
				{
					Debug.LogError("Unexpected error: Couldn't extract carsPerCargoType from orderedLogicCars and jobCargoData!");
					jobChainControllerWithEmptyHaulGeneration.DestroyChain();
					return null;
				}
				List<CarsPerTrack> list8 = ExtractCarsPerTracks(carsForJobChain2, list4);
				if (list8 == null)
				{
					Debug.LogError("Unexpected error: Couldn't extract carsPerDestinationTrack from carsForJobChain and destStorageCarTypesPerTrackData!");
					jobChainControllerWithEmptyHaulGeneration.DestroyChain();
					return null;
				}
				HashSet<JobLicenseType_v2> hashSet4 = new HashSet<JobLicenseType_v2>();
				hashSet4.UnionWith(hashSet);
				hashSet4.UnionWith(licenseManager.GetRequiredLicensesForJobType(JobType.ShuntingUnload));
				staticShuntingUnloadJobDefinition = PopulateShuntingUnloadJobDefinitionWithExistingCars(jobChainControllerWithEmptyHaulGeneration.jobChainGO, stationController.logicStation, startingTrack2, unloadMachine, list7, list8, bonusTimeLimit3, initialWage3, stationsChainData, JobLicenseType_v2.ListToFlags(hashSet4));
			}
			else
			{
				Debug.LogError($"This should not happen. {JobType.ShuntingUnload} job should always have already spawned cars!", this.stationController);
			}
			if (staticShuntingUnloadJobDefinition == null)
			{
				jobChainControllerWithEmptyHaulGeneration.DestroyChain();
				return null;
			}
			jobChainControllerWithEmptyHaulGeneration.AddJobDefinitionToChain(staticShuntingUnloadJobDefinition);
			break;
		}
		default:
			Debug.LogError(string.Format("Unexpected {0}: {1}!", "startingJobType", startingJobType));
			break;
		}
		jobChainControllerWithEmptyHaulGeneration.FinalizeSetupAndGenerateFirstJob();
		return jobChainControllerWithEmptyHaulGeneration;
	}

	private JobChainController GenerateEmptyHaul(bool forceFulfilledLicenseRequirements = false)
	{
		List<CargoGroup> list;
		int maxNumberOfCars;
		if (forceFulfilledLicenseRequirements)
		{
			list = FilterOutUnlicensedCargoGroups(JobType.EmptyHaul);
			maxNumberOfCars = licenseManager.GetMaxNumberOfCarsPerJobWithAcquiredJobLicenses();
		}
		else
		{
			list = generationRuleset.inputCargoGroups;
			maxNumberOfCars = generationRuleset.maxCarsPerJob;
		}
		if (list.Count == 0)
		{
			return null;
		}
		List<TrainCarLivery> list2 = GenerateEmptyHaulBaseData(generationRuleset.minCarsPerJob, maxNumberOfCars, list);
		float totalCarLiveriesLength = cs.GetTotalCarLiveriesLength(list2, includeSeparationBetweenCars: true);
		List<Track> list3 = yto.FilterOutTracksWithoutRequiredFreeSpace(stYard.StorageTracks, totalCarLiveriesLength);
		Track track = ((list3.Count > 0) ? GetRandomFromList(list3) : null);
		if (track == null)
		{
			return null;
		}
		JobChainController jobChainController = EmptyHaulJobProceduralGenerator.GenerateEmptyHaulJobWithCarSpawning(stationController, track, list2, currentRng);
		if (jobChainController == null)
		{
			return null;
		}
		jobChainController.FinalizeSetupAndGenerateFirstJob();
		return jobChainController;
	}

	private List<CarTypesPerCargoTypeData> GenerateBaseCargoTrainData(int minNumberOfCars, int maxNumberOfCars, List<CargoGroup> availableCargoGroups, out List<CargoType> cargoTypes, out List<TrainCarLivery> allCarLiveries, out CargoGroup pickedCargoGroup)
	{
		List<CarTypesPerCargoTypeData> list = new List<CarTypesPerCargoTypeData>();
		allCarLiveries = new List<TrainCarLivery>();
		int num = currentRng.Next(minNumberOfCars, maxNumberOfCars + 1);
		pickedCargoGroup = GetRandomFromList(availableCargoGroups);
		List<CargoType> cargoTypes2 = pickedCargoGroup.cargoTypes;
		cargoTypes = GetMultipleRandomsFromList(cargoTypes2, Mathf.Min(num, currentRng.Next(1, cargoTypes2.Count + 1)));
		int count = cargoTypes.Count;
		int num2 = num / count;
		int num3 = num % count;
		int num4 = num;
		for (int i = 0; i < count; i++)
		{
			int num5 = ((i < num3) ? (num2 + 1) : num2);
			num4 -= num5;
			List<TrainCarType_v2> list2 = Globals.G.Types.CargoToLoadableCarTypes[cargoTypes[i].ToV2()];
			TrainCarType_v2 randomFromList = GetRandomFromList(list2);
			float num6 = 0f;
			List<TrainCarLivery> list3 = new List<TrainCarLivery>();
			for (int j = 0; j < num5; j++)
			{
				list3.Add(GetRandomFromList(randomFromList.liveries));
				num6 += 1f;
			}
			list.Add(new CarTypesPerCargoTypeData(list3, cargoTypes[i], num6));
			allCarLiveries.AddRange(list3);
		}
		return list;
	}

	private List<TrainCarLivery> GenerateEmptyHaulBaseData(int minNumberOfCars, int maxNumberOfCars, List<CargoGroup> availableCargoTypeGroups)
	{
		List<TrainCarLivery> list = new List<TrainCarLivery>();
		int num = currentRng.Next(minNumberOfCars, maxNumberOfCars + 1);
		List<CargoType> cargoTypes = GetRandomFromList(availableCargoTypeGroups).cargoTypes;
		List<CargoType> multipleRandomsFromList = GetMultipleRandomsFromList(cargoTypes, Mathf.Min(num, currentRng.Next(1, cargoTypes.Count + 1)));
		int count = multipleRandomsFromList.Count;
		int num2 = num / count;
		int num3 = num % count;
		int num4 = num;
		for (int i = 0; i < count; i++)
		{
			int num5 = ((i < num3) ? (num2 + 1) : num2);
			num4 -= num5;
			List<TrainCarType_v2> list2 = Globals.G.Types.CargoToLoadableCarTypes[multipleRandomsFromList[i].ToV2()];
			TrainCarType_v2 randomFromList = GetRandomFromList(list2);
			List<TrainCarLivery> list3 = new List<TrainCarLivery>();
			for (int j = 0; j < num5; j++)
			{
				list3.Add(GetRandomFromList(randomFromList.liveries));
			}
			list.AddRange(list3);
		}
		return list;
	}

	private T GetRandomFromList<T>(List<T> list)
	{
		return list[currentRng.Next(0, list.Count)];
	}

	private List<T> GetMultipleRandomsFromList<T>(List<T> list, int numberOfRandoms)
	{
		List<T> list2 = new List<T>(list);
		if (numberOfRandoms > list2.Count)
		{
			Debug.LogError("Trying to get more random items from list than it contains. Returning all items from list.");
			return list2;
		}
		List<T> list3 = new List<T>();
		for (int i = 0; i < numberOfRandoms; i++)
		{
			int index = currentRng.Next(0, list2.Count);
			list3.Add(list2[index]);
			list2.RemoveAt(index);
		}
		return list3;
	}

	private List<CarTypesPerTrackData> GetRandomSortingOfCarLiveriesOnTracks(List<Track> tracks, List<TrainCarLivery> allCarLiveriesForJobChain, int maxNumberOfStorageTracks)
	{
		if (tracks == null || tracks.Count == 0)
		{
			return null;
		}
		int num = Mathf.Min(currentRng.Next(1, maxNumberOfStorageTracks + 1), tracks.Count, allCarLiveriesForJobChain.Count);
		int num2 = Mathf.FloorToInt((float)allCarLiveriesForJobChain.Count * 1f / (float)num);
		List<int> list = new List<int>();
		int count = allCarLiveriesForJobChain.Count;
		int num3 = 0;
		for (int i = 0; i < num; i++)
		{
			int num4 = ((i != num - 1) ? currentRng.Next(1, num2 + 1) : (count - num3));
			if (num4 <= 0)
			{
				Debug.LogError("This should not happen ever. We should always pick one random element per track!", stationController);
			}
			list.Add(num4);
			num3 += num4;
		}
		list.Sort();
		list.Reverse();
		int num5 = 0;
		List<CarTypesPerTrackData> list2 = new List<CarTypesPerTrackData>();
		tracks = new List<Track>(tracks);
		for (int j = 0; j < list.Count; j++)
		{
			List<TrainCarLivery> range = allCarLiveriesForJobChain.GetRange(num5, list[j]);
			num5 += list[j];
			float totalCarLiveriesLength = cs.GetTotalCarLiveriesLength(range, includeSeparationBetweenCars: true);
			List<Track> list3 = yto.FilterOutTracksWithoutRequiredFreeSpace(tracks, totalCarLiveriesLength);
			Track track = ((list3.Count > 0) ? GetRandomFromList(list3) : null);
			if (track == null)
			{
				return null;
			}
			tracks.Remove(track);
			list2.Add(new CarTypesPerTrackData(track, range, totalCarLiveriesLength));
		}
		return list2;
	}

	private StaticShuntingLoadJobDefinition PopulateShuntingLoadJobDefinitionWithCarSpawning(JobChainController chainController, Station logicStation, List<CarTypesPerTrackData> startingTracksData, WarehouseMachine loadMachine, List<CarTypesPerCargoTypeData> loadData, Track destinationTrack, float bonusTimeLimit, float initialWage, StationsChainData stationsChainData, JobLicenses requiredLicense)
	{
		List<CarSpawner.SpawnData> list = new List<CarSpawner.SpawnData>();
		for (int i = 0; i < startingTracksData.Count; i++)
		{
			RailTrack railTrack = startingTracksData[i].track.RailTrack();
			CarSpawner.SpawnData trackMiddleBasedSpawnDataRandomOrientation = CarSpawner.GetTrackMiddleBasedSpawnDataRandomOrientation(startingTracksData[i].carTypesForTrack, railTrack);
			if (trackMiddleBasedSpawnDataRandomOrientation.result != CarSpawner.SpawnDataResult.OK)
			{
				return null;
			}
			list.Add(trackMiddleBasedSpawnDataRandomOrientation);
		}
		CarSpawner instance = SingletonBehaviour<CarSpawner>.Instance;
		List<TrainCar> list2 = new List<TrainCar>();
		List<Car> list3 = new List<Car>();
		List<CarsPerTrack> list4 = new List<CarsPerTrack>();
		for (int j = 0; j < list.Count; j++)
		{
			CarSpawner.SpawnData spawnData = list[j];
			List<TrainCar> list5 = instance.SpawnCars(spawnData, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true);
			if (list5 == null)
			{
				Debug.LogError("Unexpected error: trainCarsToAssemblePerStartingTrack shouldn't ever be null");
				if (list2.Count > 0)
				{
					instance.DeleteTrainCars(list2, forceInstantDestroy: true);
				}
				return null;
			}
			List<Car> list6 = TrainCar.ExtractLogicCars(list5);
			if (list6 == null)
			{
				Debug.LogError("Couldn't extract logic cars. Deleting all spawned trainCars!", stationController);
				if (list2.Count > 0)
				{
					instance.DeleteTrainCars(list2, forceInstantDestroy: true);
				}
				return null;
			}
			list4.Add(new CarsPerTrack(spawnData.track.LogicTrack(), list6));
			list3.AddRange(list6);
			list2.AddRange(list5);
		}
		chainController.carsForJobChain = list3;
		List<CarsPerCargoType> list7 = ExtractCarsPerCargoType(list3, loadData);
		if (list7 == null)
		{
			Debug.LogError("Unexpected error: Couldn't extract carsPerCargoType from orderedLogicCars and loadData!");
			instance.DeleteTrainCars(list2, forceInstantDestroy: true);
			return null;
		}
		return PopulateShuntingLoadJobDefinitionWithExistingCars(chainController.jobChainGO, logicStation, list4, loadMachine, list7, destinationTrack, bonusTimeLimit, initialWage, stationsChainData, requiredLicense);
	}

	private StaticShuntingLoadJobDefinition PopulateShuntingLoadJobDefinitionWithExistingCars(GameObject chainJobGO, Station logicStation, List<CarsPerTrack> carsPerStartingTrack, WarehouseMachine loadMachine, List<CarsPerCargoType> carsPerCargoType, Track destinationTrack, float bonusTimeLimit, float initialWage, StationsChainData stationsChainData, JobLicenses requiredLicense)
	{
		StaticShuntingLoadJobDefinition staticShuntingLoadJobDefinition = chainJobGO.AddComponent<StaticShuntingLoadJobDefinition>();
		staticShuntingLoadJobDefinition.PopulateBaseJobDefinition(logicStation, bonusTimeLimit, initialWage, stationsChainData, requiredLicense);
		staticShuntingLoadJobDefinition.carsPerStartingTrack = carsPerStartingTrack;
		staticShuntingLoadJobDefinition.loadMachine = loadMachine;
		staticShuntingLoadJobDefinition.loadData = carsPerCargoType;
		staticShuntingLoadJobDefinition.destinationTrack = destinationTrack;
		staticShuntingLoadJobDefinition.forceCorrectCargoStateOnCars = true;
		return staticShuntingLoadJobDefinition;
	}

	private StaticShuntingUnloadJobDefinition PopulateShuntingUnloadJobDefinitionWithCarSpawning(JobChainController chainController, Station logicStation, Track startingTrack, WarehouseMachine unloadMachine, List<CarTypesPerCargoTypeData> unloadData, List<CarTypesPerTrackData> destinationTracksData, List<TrainCarLivery> orderedCarLiveriesToUnload, float bonusTimeLimit, float initialWage, StationsChainData stationsChainData, JobLicenses requiredLicense)
	{
		RailTrack railTrack = startingTrack.RailTrack();
		CarSpawner instance = SingletonBehaviour<CarSpawner>.Instance;
		List<TrainCar> list = instance.SpawnCarTypesOnTrackRandomOrientation(orderedCarLiveriesToUnload, railTrack, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true);
		if (list == null)
		{
			return null;
		}
		List<Car> list2 = TrainCar.ExtractLogicCars(list);
		if (list2 == null)
		{
			Debug.LogError("Couldn't extract logic cars. Deleting all spawned trainCars!", stationController);
			if (list.Count > 0)
			{
				instance.DeleteTrainCars(list, forceInstantDestroy: true);
			}
			return null;
		}
		chainController.carsForJobChain = list2;
		List<CarsPerCargoType> list3 = ExtractCarsPerCargoType(list2, unloadData);
		if (list3 == null)
		{
			Debug.LogError("Unexpected error: Couldn't extract carsPerCargoType from  orderedLogicCars and unloadData!");
			if (list.Count > 0)
			{
				instance.DeleteTrainCars(list, forceInstantDestroy: true);
			}
			return null;
		}
		List<CarsPerTrack> list4 = ExtractCarsPerTracks(list2, destinationTracksData);
		if (list4 == null)
		{
			Debug.LogError("Unexpected error: Couldn't extract carsPerDestinationTrack from orderedLogicCars and destinationTracksData!");
			if (list.Count > 0)
			{
				instance.DeleteTrainCars(list, forceInstantDestroy: true);
			}
			return null;
		}
		return PopulateShuntingUnloadJobDefinitionWithExistingCars(chainController.jobChainGO, logicStation, startingTrack, unloadMachine, list3, list4, bonusTimeLimit, initialWage, stationsChainData, requiredLicense);
	}

	private StaticShuntingUnloadJobDefinition PopulateShuntingUnloadJobDefinitionWithExistingCars(GameObject chainJobGO, Station logicStation, Track startingTrack, WarehouseMachine unloadMachine, List<CarsPerCargoType> carsPerCargoType, List<CarsPerTrack> carsPerDestinationTrack, float bonusTimeLimit, float initialWage, StationsChainData stationsChainData, JobLicenses requiredLicenses)
	{
		StaticShuntingUnloadJobDefinition staticShuntingUnloadJobDefinition = chainJobGO.AddComponent<StaticShuntingUnloadJobDefinition>();
		staticShuntingUnloadJobDefinition.PopulateBaseJobDefinition(logicStation, bonusTimeLimit, initialWage, stationsChainData, requiredLicenses);
		staticShuntingUnloadJobDefinition.startingTrack = startingTrack;
		staticShuntingUnloadJobDefinition.unloadMachine = unloadMachine;
		staticShuntingUnloadJobDefinition.unloadData = carsPerCargoType;
		staticShuntingUnloadJobDefinition.carsPerDestinationTrack = carsPerDestinationTrack;
		staticShuntingUnloadJobDefinition.forceCorrectCargoStateOnCars = true;
		return staticShuntingUnloadJobDefinition;
	}

	private StaticTransportJobDefinition PopulateHaulJobDefinitionWithCarSpawning(JobChainController chainController, Station logicStation, Track startingTrack, Track destinationTrack, List<TrainCarLivery> trainCarTypesToHaul, List<CargoType> cargoTypePerCar, List<float> cargoAmountPerCar, float bonusTimeLimit, float initialWage, StationsChainData stationsChainData, JobLicenses requiredLicenses)
	{
		List<TrainCar> list = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnTrackRandomOrientation(trainCarTypesToHaul, startingTrack.RailTrack(), preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true);
		if (list == null)
		{
			return null;
		}
		List<Car> list2 = TrainCar.ExtractLogicCars(list);
		if (list2 == null)
		{
			Debug.LogError("Couldn't extract logic cars. Deleting spawned trainCars!", stationController);
			SingletonBehaviour<CarSpawner>.Instance.DeleteTrainCars(list, forceInstantDestroy: true);
			return null;
		}
		chainController.carsForJobChain = list2;
		return PopulateHaulJobDefinitionWithExistingCars(chainController.jobChainGO, logicStation, startingTrack, destinationTrack, list2, cargoTypePerCar, cargoAmountPerCar, bonusTimeLimit, initialWage, stationsChainData, requiredLicenses);
	}

	private StaticTransportJobDefinition PopulateHaulJobDefinitionWithExistingCars(GameObject chainJobGO, Station logicStation, Track startingTrack, Track destinationTrack, List<Car> logicCarsToHaul, List<CargoType> cargoTypePerCar, List<float> cargoAmountPerCar, float bonusTimeLimit, float initialWage, StationsChainData stationsChainData, JobLicenses requiredLicenses)
	{
		StaticTransportJobDefinition staticTransportJobDefinition = chainJobGO.AddComponent<StaticTransportJobDefinition>();
		staticTransportJobDefinition.PopulateBaseJobDefinition(logicStation, bonusTimeLimit, initialWage, stationsChainData, requiredLicenses);
		staticTransportJobDefinition.startingTrack = startingTrack;
		staticTransportJobDefinition.carsToTransport = logicCarsToHaul;
		staticTransportJobDefinition.transportedCargoPerCar = cargoTypePerCar;
		staticTransportJobDefinition.cargoAmountPerCar = cargoAmountPerCar;
		staticTransportJobDefinition.forceCorrectCargoStateOnCars = true;
		staticTransportJobDefinition.destinationTrack = destinationTrack;
		return staticTransportJobDefinition;
	}

	private ChainJobType GetChainGroup(JobType startingJobType)
	{
		switch (startingJobType)
		{
		case JobType.ShuntingLoad:
		case JobType.Transport:
			return ChainJobType.Out;
		case JobType.ShuntingUnload:
			return ChainJobType.In;
		case JobType.EmptyHaul:
			return ChainJobType.Empty;
		default:
			Debug.LogError("startingJobType has unexpected value! Error, can't extract ChainJobType!", stationController);
			return ChainJobType.Invalid;
		}
	}

	private List<CargoGroup> FilterOutUnlicensedCargoGroups(JobType startingJobType)
	{
		List<CargoGroup> list = new List<CargoGroup>();
		if (startingJobType - 1 > JobType.ShuntingUnload)
		{
			if (startingJobType == JobType.EmptyHaul)
			{
				foreach (CargoGroup inputCargoGroup in generationRuleset.inputCargoGroups)
				{
					if (licenseManager.IsLicensedForJob(JobLicenseType_v2.ToV2List(inputCargoGroup.CarRequiredLicenses)))
					{
						list.Add(inputCargoGroup);
					}
				}
			}
			else
			{
				Debug.LogError(string.Format("Unexpected {0}: {1}", "startingJobType", startingJobType));
			}
		}
		else
		{
			foreach (CargoGroup item in (startingJobType == JobType.ShuntingUnload) ? generationRuleset.inputCargoGroups : generationRuleset.outputCargoGroups)
			{
				if (licenseManager.IsLicensedForJob(JobLicenseType_v2.ToV2List(item.CargoRequiredLicenses)))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	private List<TrainCarsPerRailtrack> ExtractTrainCarsPerRailTracks(List<TrainCar> orderedTrainCars, List<CarTypesPerTrackData> carTypesPerTrackData)
	{
		int num = 0;
		List<TrainCarsPerRailtrack> list = new List<TrainCarsPerRailtrack>();
		for (int i = 0; i < carTypesPerTrackData.Count; i++)
		{
			RailTrack railTrack = carTypesPerTrackData[i].track.RailTrack();
			int count = carTypesPerTrackData[i].carTypesForTrack.Count;
			List<TrainCar> range = orderedTrainCars.GetRange(num, count);
			num += count;
			list.Add(new TrainCarsPerRailtrack(range, railTrack));
		}
		if (num != orderedTrainCars.Count || carTypesPerTrackData.Count != list.Count)
		{
			return null;
		}
		return list;
	}

	private List<CarsPerTrack> ExtractCarsPerTracks(List<Car> orderedCars, List<CarTypesPerTrackData> carTypesPerTrackData)
	{
		int num = 0;
		List<CarsPerTrack> list = new List<CarsPerTrack>();
		for (int i = 0; i < carTypesPerTrackData.Count; i++)
		{
			int count = carTypesPerTrackData[i].carTypesForTrack.Count;
			List<Car> range = orderedCars.GetRange(num, count);
			num += count;
			list.Add(new CarsPerTrack(carTypesPerTrackData[i].track, range));
		}
		if (num != orderedCars.Count || carTypesPerTrackData.Count != list.Count)
		{
			return null;
		}
		return list;
	}

	private List<TrainCarsPerCargoType> ExtractTrainCarsPerCargoType(List<TrainCar> orderedTrainCars, List<CarTypesPerCargoTypeData> carsPerCargoData)
	{
		List<TrainCarsPerCargoType> list = new List<TrainCarsPerCargoType>();
		int num = 0;
		for (int i = 0; i < carsPerCargoData.Count; i++)
		{
			int count = carsPerCargoData[i].carTypes.Count;
			List<TrainCar> range = orderedTrainCars.GetRange(num, count);
			num += count;
			list.Add(new TrainCarsPerCargoType(range, carsPerCargoData[i].cargoType, carsPerCargoData[i].totalCargoAmount));
		}
		if (num != orderedTrainCars.Count || carsPerCargoData.Count != list.Count)
		{
			return null;
		}
		return list;
	}

	private List<CarsPerCargoType> ExtractCarsPerCargoType(List<Car> orderedCars, List<CarTypesPerCargoTypeData> carTypesPerCargoData)
	{
		if (orderedCars == null || carTypesPerCargoData == null)
		{
			return null;
		}
		List<CarsPerCargoType> list = new List<CarsPerCargoType>();
		int num = 0;
		for (int i = 0; i < carTypesPerCargoData.Count; i++)
		{
			int count = carTypesPerCargoData[i].carTypes.Count;
			List<Car> range = orderedCars.GetRange(num, count);
			num += count;
			list.Add(new CarsPerCargoType(carTypesPerCargoData[i].cargoType, range, carTypesPerCargoData[i].totalCargoAmount));
		}
		if (num != orderedCars.Count || carTypesPerCargoData.Count != list.Count)
		{
			return null;
		}
		return list;
	}

	private PaymentCalculationData ExtractPaymentCalculationData(List<CarTypesPerCargoTypeData> carTypesPerCargoData)
	{
		if (carTypesPerCargoData == null)
		{
			return null;
		}
		Dictionary<TrainCarLivery, int> dictionary = new Dictionary<TrainCarLivery, int>();
		Dictionary<CargoType, int> dictionary2 = new Dictionary<CargoType, int>();
		foreach (CarTypesPerCargoTypeData carTypesPerCargoDatum in carTypesPerCargoData)
		{
			if (!dictionary2.ContainsKey(carTypesPerCargoDatum.cargoType))
			{
				dictionary2[carTypesPerCargoDatum.cargoType] = 0;
			}
			dictionary2[carTypesPerCargoDatum.cargoType] += carTypesPerCargoDatum.carTypes.Count;
			foreach (TrainCarLivery carType in carTypesPerCargoDatum.carTypes)
			{
				if (!dictionary.ContainsKey(carType))
				{
					dictionary[carType] = 0;
				}
				dictionary[carType]++;
			}
		}
		return new PaymentCalculationData(dictionary, dictionary2);
	}
}
