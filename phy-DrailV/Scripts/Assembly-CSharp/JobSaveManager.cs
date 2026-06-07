using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Booklets;
using DV.Booklets.Rendered;
using DV.CabControls;
using DV.InventorySystem;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using Newtonsoft.Json;
using UnityEngine;

public class JobSaveManager : SingletonBehaviour<JobSaveManager>
{
	private StationProceduralJobsController[] _stationJobControllers;

	public static JsonSerializerSettings serializeSettings = new JsonSerializerSettings
	{
		TypeNameHandling = TypeNameHandling.All
	};

	private StationProceduralJobsController[] StationJobControllers
	{
		get
		{
			if (_stationJobControllers == null)
			{
				_stationJobControllers = UnityEngine.Object.FindObjectsOfType<StationProceduralJobsController>();
			}
			return _stationJobControllers;
		}
	}

	public new static string AllowAutoCreate()
	{
		return "[JobSaveManager]";
	}

	public JobsSaveGameData GetJobsSaveGameData()
	{
		List<JobChainSaveData> list = new List<JobChainSaveData>();
		StationProceduralJobsController[] stationJobControllers = StationJobControllers;
		for (int i = 0; i < stationJobControllers.Length; i++)
		{
			foreach (JobChainController currentJobChain in stationJobControllers[i].GetCurrentJobChains())
			{
				JobChainSaveData jobChainSaveData = currentJobChain.GetJobChainSaveData();
				list.Add(jobChainSaveData);
			}
		}
		return new JobsSaveGameData(list.ToArray(), SingletonBehaviour<JobsManager>.Instance.Time);
	}

	public void LoadJobSaveGameData(JobsSaveGameData saveData)
	{
		if (DeleteAllNonActiveJobChains())
		{
			Debug.LogError("Unexpected existing job chains deleted! Need to have clean state before job chain load!");
		}
		SingletonBehaviour<JobsManager>.Instance.LoadTime(saveData.logicTimer);
		List<JobBooklet> list = (from jbi in SingletonBehaviour<StorageController>.Instance.GetAllStorageItems()
			where jbi.GetComponent<JobBooklet>() != null
			select jbi.GetComponent<JobBooklet>()).ToList();
		JobChainSaveData[] jobChains = saveData.jobChains;
		foreach (JobChainSaveData chainSaveData in jobChains)
		{
			GameObject gameObject = LoadJobChain(chainSaveData, list);
			if (gameObject != null)
			{
				Debug.Log("Successfully loaded job chain: " + gameObject.name);
			}
		}
		if (list.Count > 0)
		{
			Debug.LogError(string.Format("{0} {1}s are left uninitialized. Destroying them all, because they are unused!", list.Count, "JobBooklet"));
			foreach (JobBooklet item in list)
			{
				Debug.LogError("Destroying JobBooklet with saved jobId[" + item.jobIdLoadedData + "]");
				item.DestroyJobBooklet();
			}
		}
		list = null;
		StationProceduralJobsController[] stationJobControllers = StationJobControllers;
		for (int num = 0; num < stationJobControllers.Length; num++)
		{
			stationJobControllers[num].stationController.OverridePlayerEnteredJobGenerationZoneFlag();
		}
	}

	public GameObject LoadJobChain(JobChainSaveData chainSaveData, List<JobBooklet> jobBooklets)
	{
		List<Car> carsFromCarGuids = GetCarsFromCarGuids(chainSaveData.trainCarGuids);
		if (carsFromCarGuids == null)
		{
			Debug.LogError("Couldn't find carsForJobChain with trainCarGuids from chainSaveData! Skipping load of this job chain!");
			return null;
		}
		GameObject gameObject = new GameObject();
		List<StaticJobDefinition> list = new List<StaticJobDefinition>();
		JobType jobType = JobType.Custom;
		for (int i = 0; i < chainSaveData.jobChainData.Length; i++)
		{
			JobDefinitionDataBase jobDefinitionDataBase = chainSaveData.jobChainData[i];
			if (jobDefinitionDataBase is TransportJobDefinitionData transportJobDefinitionData)
			{
				StaticTransportJobDefinition staticTransportJobDefinition = gameObject.AddComponent<StaticTransportJobDefinition>();
				if (i == 0)
				{
					jobType = JobType.Transport;
					staticTransportJobDefinition.ForceJobId(chainSaveData.firstJobId);
				}
				Station stationWithId = GetStationWithId(transportJobDefinitionData.stationId);
				if (stationWithId == null)
				{
					Debug.LogError("Couldn't find corresponding Station with ID: " + transportJobDefinitionData.stationId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				if (transportJobDefinitionData.timeLimitForJob < 0f || transportJobDefinitionData.initialWage < 0f || string.IsNullOrEmpty(transportJobDefinitionData.originStationId) || string.IsNullOrEmpty(transportJobDefinitionData.destinationStationId))
				{
					Debug.LogError("Invalid data! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				if (!IsValidForParsingToJobLicense(transportJobDefinitionData.requiredLicenses))
				{
					Debug.LogError("Undefined job licenses requirement! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				staticTransportJobDefinition.PopulateBaseJobDefinition(stationWithId, transportJobDefinitionData.timeLimitForJob, transportJobDefinitionData.initialWage, new StationsChainData(transportJobDefinitionData.originStationId, transportJobDefinitionData.destinationStationId), (JobLicenses)transportJobDefinitionData.requiredLicenses);
				Track yardTrackWithId = GetYardTrackWithId(transportJobDefinitionData.startTrackId);
				if (yardTrackWithId == null)
				{
					Debug.LogError("Couldn't find corresponding start Track with ID: " + transportJobDefinitionData.startTrackId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				Track yardTrackWithId2 = GetYardTrackWithId(transportJobDefinitionData.destinationTrackId);
				if (yardTrackWithId2 == null)
				{
					Debug.LogError("Couldn't find corresponding destination Track with ID: " + transportJobDefinitionData.destinationTrackId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				List<Car> carsFromCarGuids2 = GetCarsFromCarGuids(transportJobDefinitionData.transportCarGuids);
				if (carsFromCarGuids2 == null)
				{
					Debug.LogError("Couldn't find all carsToTransport with transportCarGuids! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				if (transportJobDefinitionData.transportedCargoPerCar.Length != carsFromCarGuids2.Count || transportJobDefinitionData.cargoAmountPerCar.Length != carsFromCarGuids2.Count)
				{
					Debug.LogError("Unmatching number of carsToTransport and transportedCargoPerCar or cargoAmountPerCar! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				staticTransportJobDefinition.startingTrack = yardTrackWithId;
				staticTransportJobDefinition.carsToTransport = carsFromCarGuids2;
				staticTransportJobDefinition.transportedCargoPerCar = transportJobDefinitionData.transportedCargoPerCar.ToList();
				staticTransportJobDefinition.cargoAmountPerCar = transportJobDefinitionData.cargoAmountPerCar.ToList();
				staticTransportJobDefinition.destinationTrack = yardTrackWithId2;
				staticTransportJobDefinition.forceCorrectCargoStateOnCars = false;
				list.Add(staticTransportJobDefinition);
			}
			if (jobDefinitionDataBase is EmptyHaulJobDefinitionData emptyHaulJobDefinitionData)
			{
				StaticEmptyHaulJobDefinition staticEmptyHaulJobDefinition = gameObject.AddComponent<StaticEmptyHaulJobDefinition>();
				if (i == 0)
				{
					jobType = JobType.EmptyHaul;
					staticEmptyHaulJobDefinition.ForceJobId(chainSaveData.firstJobId);
				}
				Station stationWithId2 = GetStationWithId(emptyHaulJobDefinitionData.stationId);
				if (stationWithId2 == null)
				{
					Debug.LogError("Couldn't find corresponding Station with ID: " + emptyHaulJobDefinitionData.stationId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				if (emptyHaulJobDefinitionData.timeLimitForJob < 0f || emptyHaulJobDefinitionData.initialWage < 0f || string.IsNullOrEmpty(emptyHaulJobDefinitionData.originStationId) || string.IsNullOrEmpty(emptyHaulJobDefinitionData.destinationStationId))
				{
					Debug.LogError("Invalid data! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				if (!IsValidForParsingToJobLicense(emptyHaulJobDefinitionData.requiredLicenses))
				{
					Debug.LogError("Undefined job licenses requirement! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				staticEmptyHaulJobDefinition.PopulateBaseJobDefinition(stationWithId2, emptyHaulJobDefinitionData.timeLimitForJob, emptyHaulJobDefinitionData.initialWage, new StationsChainData(emptyHaulJobDefinitionData.originStationId, emptyHaulJobDefinitionData.destinationStationId), (JobLicenses)emptyHaulJobDefinitionData.requiredLicenses);
				Track yardTrackWithId3 = GetYardTrackWithId(emptyHaulJobDefinitionData.startTrackId);
				if (yardTrackWithId3 == null)
				{
					Debug.LogError("Couldn't find corresponding start Track with ID: " + emptyHaulJobDefinitionData.startTrackId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				Track yardTrackWithId4 = GetYardTrackWithId(emptyHaulJobDefinitionData.destinationTrackId);
				if (yardTrackWithId4 == null)
				{
					Debug.LogError("Couldn't find corresponding destination Track with ID: " + emptyHaulJobDefinitionData.destinationTrackId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				List<Car> carsFromCarGuids3 = GetCarsFromCarGuids(emptyHaulJobDefinitionData.transportCarGuids);
				if (carsFromCarGuids3 == null)
				{
					Debug.LogError("Couldn't find all carsToTransport with transportCarGuids! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				staticEmptyHaulJobDefinition.startingTrack = yardTrackWithId3;
				staticEmptyHaulJobDefinition.carsToTransport = carsFromCarGuids3;
				staticEmptyHaulJobDefinition.destinationTrack = yardTrackWithId4;
				list.Add(staticEmptyHaulJobDefinition);
			}
			if (jobDefinitionDataBase is LoadJobDefinitionData loadJobDefinitionData)
			{
				StaticShuntingLoadJobDefinition staticShuntingLoadJobDefinition = gameObject.AddComponent<StaticShuntingLoadJobDefinition>();
				if (i == 0)
				{
					jobType = JobType.ShuntingLoad;
					staticShuntingLoadJobDefinition.ForceJobId(chainSaveData.firstJobId);
				}
				Station stationWithId3 = GetStationWithId(loadJobDefinitionData.stationId);
				if (stationWithId3 == null)
				{
					Debug.LogError("Couldn't find corresponding Station with ID: " + loadJobDefinitionData.stationId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				if (loadJobDefinitionData.timeLimitForJob < 0f || loadJobDefinitionData.initialWage < 0f || string.IsNullOrEmpty(loadJobDefinitionData.originStationId) || string.IsNullOrEmpty(loadJobDefinitionData.destinationStationId))
				{
					Debug.LogError("Invalid data! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				if (!IsValidForParsingToJobLicense(loadJobDefinitionData.requiredLicenses))
				{
					Debug.LogError("Undefined job licenses requirement! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				staticShuntingLoadJobDefinition.PopulateBaseJobDefinition(stationWithId3, loadJobDefinitionData.timeLimitForJob, loadJobDefinitionData.initialWage, new StationsChainData(loadJobDefinitionData.originStationId, loadJobDefinitionData.destinationStationId), (JobLicenses)loadJobDefinitionData.requiredLicenses);
				List<CarsPerTrack> list2 = new List<CarsPerTrack>();
				for (int j = 0; j < loadJobDefinitionData.carGuidsPerStartingTrackId.Length; j++)
				{
					Track yardTrackWithId5 = GetYardTrackWithId(loadJobDefinitionData.carGuidsPerStartingTrackId[j].trackId);
					if (yardTrackWithId5 == null)
					{
						Debug.LogError("Couldn't find corresponding start Track with ID: " + loadJobDefinitionData.carGuidsPerStartingTrackId[j].trackId + "! Skipping load of this job chain!");
						UnityEngine.Object.Destroy(gameObject);
						return null;
					}
					List<Car> carsFromCarGuids4 = GetCarsFromCarGuids(loadJobDefinitionData.carGuidsPerStartingTrackId[j].carGuids);
					if (carsFromCarGuids4 == null)
					{
						Debug.LogError("Couldn't find all carsForStartTrack with carGuids! Skipping load of this job chain!");
						UnityEngine.Object.Destroy(gameObject);
						return null;
					}
					list2.Add(new CarsPerTrack(yardTrackWithId5, carsFromCarGuids4));
				}
				List<CarsPerCargoType> list3 = new List<CarsPerCargoType>();
				for (int k = 0; k < loadJobDefinitionData.carGuidsPerLoadCargo.Length; k++)
				{
					CargoType cargo = loadJobDefinitionData.carGuidsPerLoadCargo[k].cargo;
					List<Car> carsFromCarGuids5 = GetCarsFromCarGuids(loadJobDefinitionData.carGuidsPerLoadCargo[k].carGuids);
					if (carsFromCarGuids5 == null)
					{
						Debug.LogError("Couldn't find all carsForCargo with carGuids! Skipping load of this job chain!");
						UnityEngine.Object.Destroy(gameObject);
						return null;
					}
					float totalCargoAmount = loadJobDefinitionData.carGuidsPerLoadCargo[k].totalCargoAmount;
					list3.Add(new CarsPerCargoType(cargo, carsFromCarGuids5, totalCargoAmount));
				}
				WarehouseMachine warehouseMachineWithId = GetWarehouseMachineWithId(loadJobDefinitionData.loadMachineId);
				if (warehouseMachineWithId == null)
				{
					Debug.LogError("Couldn't find corresponding WarehouseMachine with ID: " + loadJobDefinitionData.loadMachineId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				Track yardTrackWithId6 = GetYardTrackWithId(loadJobDefinitionData.destinationTrackId);
				if (yardTrackWithId6 == null)
				{
					Debug.LogError("Couldn't find corresponding destination Track with ID: " + loadJobDefinitionData.destinationTrackId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				staticShuntingLoadJobDefinition.carsPerStartingTrack = list2;
				staticShuntingLoadJobDefinition.loadMachine = warehouseMachineWithId;
				staticShuntingLoadJobDefinition.loadData = list3;
				staticShuntingLoadJobDefinition.destinationTrack = yardTrackWithId6;
				staticShuntingLoadJobDefinition.forceCorrectCargoStateOnCars = false;
				list.Add(staticShuntingLoadJobDefinition);
			}
			if (!(jobDefinitionDataBase is UnloadJobDefinitionData unloadJobDefinitionData))
			{
				continue;
			}
			StaticShuntingUnloadJobDefinition staticShuntingUnloadJobDefinition = gameObject.AddComponent<StaticShuntingUnloadJobDefinition>();
			if (i == 0)
			{
				jobType = JobType.ShuntingUnload;
				staticShuntingUnloadJobDefinition.ForceJobId(chainSaveData.firstJobId);
			}
			Station stationWithId4 = GetStationWithId(unloadJobDefinitionData.stationId);
			if (stationWithId4 == null)
			{
				Debug.LogError("Couldn't find corresponding Station with ID: " + unloadJobDefinitionData.stationId + "! Skipping load of this job chain!");
				UnityEngine.Object.Destroy(gameObject);
				return null;
			}
			if (unloadJobDefinitionData.timeLimitForJob < 0f || unloadJobDefinitionData.initialWage < 0f || string.IsNullOrEmpty(unloadJobDefinitionData.originStationId) || string.IsNullOrEmpty(unloadJobDefinitionData.destinationStationId))
			{
				Debug.LogError("Invalid data! Skipping load of this job chain!");
				UnityEngine.Object.Destroy(gameObject);
				return null;
			}
			if (!IsValidForParsingToJobLicense(unloadJobDefinitionData.requiredLicenses))
			{
				Debug.LogError("Undefined job licenses requirement! Skipping load of this job chain!");
				UnityEngine.Object.Destroy(gameObject);
				return null;
			}
			staticShuntingUnloadJobDefinition.PopulateBaseJobDefinition(stationWithId4, unloadJobDefinitionData.timeLimitForJob, unloadJobDefinitionData.initialWage, new StationsChainData(unloadJobDefinitionData.originStationId, unloadJobDefinitionData.destinationStationId), (JobLicenses)unloadJobDefinitionData.requiredLicenses);
			Track yardTrackWithId7 = GetYardTrackWithId(unloadJobDefinitionData.startingTrackId);
			if (yardTrackWithId7 == null)
			{
				Debug.LogError("Couldn't find corresponding starting Track with ID: " + unloadJobDefinitionData.startingTrackId + "! Skipping load of this job chain!");
				UnityEngine.Object.Destroy(gameObject);
				return null;
			}
			List<CarsPerCargoType> list4 = new List<CarsPerCargoType>();
			for (int l = 0; l < unloadJobDefinitionData.carGuidsPerUnloadCargo.Length; l++)
			{
				CargoType cargo2 = unloadJobDefinitionData.carGuidsPerUnloadCargo[l].cargo;
				List<Car> carsFromCarGuids6 = GetCarsFromCarGuids(unloadJobDefinitionData.carGuidsPerUnloadCargo[l].carGuids);
				if (carsFromCarGuids6 == null)
				{
					Debug.LogError("Couldn't find all carsForCargo with carGuids! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				float totalCargoAmount2 = unloadJobDefinitionData.carGuidsPerUnloadCargo[l].totalCargoAmount;
				list4.Add(new CarsPerCargoType(cargo2, carsFromCarGuids6, totalCargoAmount2));
			}
			WarehouseMachine warehouseMachineWithId2 = GetWarehouseMachineWithId(unloadJobDefinitionData.unloadMachineId);
			if (warehouseMachineWithId2 == null)
			{
				Debug.LogError("Couldn't find corresponding WarehouseMachine with ID: " + unloadJobDefinitionData.unloadMachineId + "! Skipping load of this job chain!");
				UnityEngine.Object.Destroy(gameObject);
				return null;
			}
			List<CarsPerTrack> list5 = new List<CarsPerTrack>();
			for (int m = 0; m < unloadJobDefinitionData.carGuidsPerDestinationTrackId.Length; m++)
			{
				Track yardTrackWithId8 = GetYardTrackWithId(unloadJobDefinitionData.carGuidsPerDestinationTrackId[m].trackId);
				if (yardTrackWithId8 == null)
				{
					Debug.LogError("Couldn't find corresponding destination Track with ID: " + unloadJobDefinitionData.carGuidsPerDestinationTrackId[m].trackId + "! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				List<Car> carsFromCarGuids7 = GetCarsFromCarGuids(unloadJobDefinitionData.carGuidsPerDestinationTrackId[m].carGuids);
				if (carsFromCarGuids7 == null)
				{
					Debug.LogError("Couldn't find all carsForDestTrack with carGuids! Skipping load of this job chain!");
					UnityEngine.Object.Destroy(gameObject);
					return null;
				}
				list5.Add(new CarsPerTrack(yardTrackWithId8, carsFromCarGuids7));
			}
			staticShuntingUnloadJobDefinition.startingTrack = yardTrackWithId7;
			staticShuntingUnloadJobDefinition.unloadMachine = warehouseMachineWithId2;
			staticShuntingUnloadJobDefinition.unloadData = list4;
			staticShuntingUnloadJobDefinition.carsPerDestinationTrack = list5;
			staticShuntingUnloadJobDefinition.forceCorrectCargoStateOnCars = false;
			list.Add(staticShuntingUnloadJobDefinition);
		}
		JobChainController jobChainController = ((jobType != JobType.EmptyHaul) ? new JobChainControllerWithEmptyHaulGeneration(gameObject) : new JobChainController(gameObject));
		jobChainController.carsForJobChain = carsFromCarGuids;
		for (int n = 0; n < list.Count; n++)
		{
			jobChainController.AddJobDefinitionToChain(list[n]);
		}
		gameObject.name = $"[LOADED] ChainJob[{jobType}]: {list[0].chainData.chainOriginYardId} - {list[0].chainData.chainDestinationYardId}";
		jobChainController.FinalizeSetupAndGenerateFirstJob(jobLoadedFromSavegame: true);
		if (chainSaveData.jobTaken)
		{
			SingletonBehaviour<JobsManager>.Instance.TakeJob(jobChainController.currentJobInChain, takenViaLoadGame: true);
			if (chainSaveData.currentJobTaskData != null)
			{
				jobChainController.currentJobInChain.OverrideTasksStates(chainSaveData.currentJobTaskData);
			}
			else
			{
				Debug.LogError("Job from chain was taken, but there is no task data! Task data won't be loaded!");
			}
			InitializeCorrespondingJobBooklet(jobChainController.currentJobInChain, jobBooklets);
		}
		return jobChainController.jobChainGO;
	}

	public bool IsValidForParsingToJobLicense(int jobLicensesInt)
	{
		JobLicenses jobLicenses = JobLicenses.Basic;
		foreach (JobLicenses value in Enum.GetValues(typeof(JobLicenses)))
		{
			jobLicenses |= value;
		}
		return ((uint)(~jobLicenses) & (uint)jobLicensesInt) == 0;
	}

	public bool DeleteAllNonActiveJobChains()
	{
		bool result = false;
		StationProceduralJobsController[] stationJobControllers = StationJobControllers;
		foreach (StationProceduralJobsController stationProceduralJobsController in stationJobControllers)
		{
			if (stationProceduralJobsController.GetCurrentJobChains().Count > 0)
			{
				Debug.LogWarning("Forced deleting of job chains in station: " + stationProceduralJobsController.stationController.stationInfo.YardID + "!");
				stationProceduralJobsController.stationController.ExpireAllAvailableJobsInStation();
				result = true;
			}
		}
		return result;
	}

	public void MarkAllNonJobCarsAsUnused()
	{
		List<Car> list = (from tc in UnityEngine.Object.FindObjectsOfType<TrainCar>()
			select tc.logicCar).ToList();
		StationProceduralJobsController[] stationJobControllers = StationJobControllers;
		for (int num = 0; num < stationJobControllers.Length; num++)
		{
			foreach (JobChainController currentJobChain in stationJobControllers[num].GetCurrentJobChains())
			{
				foreach (Car item in currentJobChain.carsForJobChain)
				{
					list.Remove(item);
				}
			}
		}
		list.RemoveAll((Car car) => car.uniqueCar);
		SingletonBehaviour<UnusedTrainCarDeleter>.Instance.MarkForDelete(list);
	}

	private void InitializeCorrespondingJobBooklet(Job job, List<JobBooklet> jobBooklets)
	{
		int num = jobBooklets.FindIndex((JobBooklet jb) => jb.jobIdLoadedData == job.ID && !jb.HasJobAssigned());
		if (num != -1)
		{
			JobBooklet jobBooklet = jobBooklets[num];
			jobBooklets.RemoveAt(num);
			jobBooklet.AssignJob(job);
			BookletCreator_Job.Render(jobBooklet.gameObject, new Job_data(job));
			Debug.Log("Matched job and job booklet [" + job.ID + "]", jobBooklet);
		}
		else
		{
			Debug.LogError("Couldn't find JobBooklet for corresponding job[" + job.ID + "]. Recovering by creating a new JobBooklet. Error is expected if loaded savegame is from build 75 or lower");
			SingletonBehaviour<CoroutineManager>.Instance.Run(CreateAndInitializeJobBookletForJob(job));
		}
	}

	private IEnumerator CreateAndInitializeJobBookletForJob(Job job)
	{
		JobBooklet jobBooklet = BookletCreator.CreateJobBooklet(job, Vector3.zero, Quaternion.identity, WorldMover.OriginShiftParent);
		yield return null;
		jobBooklet.SetToBeEssentialItem(set: true);
		RespawnOnDrop respawner = jobBooklet.GetComponent<RespawnOnDrop>();
		respawner.enabled = false;
		while (!jobBooklet.GetComponent<RenderedTexturesBase>().IsGenerated())
		{
			yield return null;
		}
		if ((bool)SingletonBehaviour<Inventory>.Instance && SingletonBehaviour<Inventory>.Instance.HasFreeSlots())
		{
			SingletonBehaviour<Inventory>.Instance.AddItemToInventory(jobBooklet.gameObject);
		}
		else if (PlayerManager.PlayerCamera != null)
		{
			jobBooklet.transform.position = PlayerManager.PlayerCamera.transform.position + PlayerManager.PlayerCamera.transform.forward * 0.75f;
			Rigidbody component = jobBooklet.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			if ((bool)SingletonBehaviour<StorageController>.Instance)
			{
				SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorage(jobBooklet.gameObject);
			}
			else
			{
				Debug.LogError("StorageController doesn't exist! Can't add item to WorldStorage!");
			}
		}
		else
		{
			Debug.LogError("Unexpected: No free space in inventory and PlayerCamera not found!");
		}
		respawner.enabled = true;
	}

	private Track GetYardTrackWithId(string trackId)
	{
		if (SingletonBehaviour<YardTracksOrganizer>.Instance.yardTrackIdToTrack.TryGetValue(trackId, out var value) && value != null)
		{
			return value;
		}
		return null;
	}

	private Station GetStationWithId(string stationId)
	{
		if ((bool)SingletonBehaviour<LogicController>.Instance && SingletonBehaviour<LogicController>.Instance.YardIdToStationController.TryGetValue(stationId, out var value) && value.logicStation != null)
		{
			return value.logicStation;
		}
		return null;
	}

	private WarehouseMachine GetWarehouseMachineWithId(string warehouseMachineId)
	{
		List<WarehouseMachineController> allControllers = WarehouseMachineController.allControllers;
		if (allControllers == null || allControllers.Count == 0)
		{
			return null;
		}
		for (int i = 0; i < allControllers.Count; i++)
		{
			if (allControllers[i].warehouseMachine.ID == warehouseMachineId)
			{
				return allControllers[i].warehouseMachine;
			}
		}
		return null;
	}

	private List<Car> GetCarsFromCarGuids(string[] carGuids)
	{
		if (carGuids == null || carGuids.Length == 0)
		{
			Debug.LogError("carGuids are null or empty!");
			return null;
		}
		List<Car> list = new List<Car>();
		for (int i = 0; i < carGuids.Length; i++)
		{
			if (SingletonBehaviour<IdGenerator>.Instance.carGuidToCar.TryGetValue(carGuids[i], out var value) && value != null)
			{
				list.Add(value);
				continue;
			}
			Debug.LogError("Couldn't find corresponding Car for carGuid:" + carGuids[i] + "!");
			return null;
		}
		return list;
	}
}
