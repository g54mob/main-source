using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ServicePenalty;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class JobChainController
{
	public GameObject jobChainGO;

	public List<Car> carsForJobChain;

	protected List<StaticJobDefinition> jobChain;

	protected StationController responsibleStationForJobChain;

	public Job currentJobInChain;

	private Dictionary<StaticJobDefinition, List<TrackReservation>> jobDefToCurrentlyReservedTracks;

	public event Action<JobChainController> JobChainCompleted;

	public event Action<JobChainController> JobOfChainAbandoned;

	public event Action<JobChainController> JobOfChainExpired;

	public JobChainController(GameObject jobChainGO)
	{
		this.jobChainGO = jobChainGO;
		jobChain = new List<StaticJobDefinition>();
		jobDefToCurrentlyReservedTracks = new Dictionary<StaticJobDefinition, List<TrackReservation>>();
		responsibleStationForJobChain = null;
		carsForJobChain = null;
	}

	public void AddJobDefinitionToChain(StaticJobDefinition jobInChain)
	{
		jobChain.Add(jobInChain);
		jobDefToCurrentlyReservedTracks.Add(jobInChain, jobInChain.GetRequiredTrackReservations());
	}

	public bool IsFirstJobInChainInitialized()
	{
		return jobChain.Count > 0;
	}

	public bool IsChainActive()
	{
		if (currentJobInChain != null)
		{
			return currentJobInChain.State == JobState.InProgress;
		}
		return false;
	}

	public bool AreCarsInitialized()
	{
		if (carsForJobChain != null)
		{
			return carsForJobChain.Count > 0;
		}
		return false;
	}

	public void FinalizeSetupAndGenerateFirstJob(bool jobLoadedFromSavegame = false)
	{
		ChainJobDefinitions();
		RegisterEventHandlersForJobChain();
		ReserveRequiredTracks(jobLoadedFromSavegame);
		if (IsFirstJobInChainInitialized())
		{
			GenerateFirstJobInChain();
			return;
		}
		throw new Exception("Shouldn't happen, ever! ChainJob initialized but no job definitions!");
	}

	public void DestroyChain()
	{
		ReleaseRemainingReservations();
		if (jobChainGO != null)
		{
			UnityEngine.Object.Destroy(jobChainGO);
		}
		jobChain = null;
	}

	private void ChainJobDefinitions()
	{
		for (int i = 0; i < jobChain.Count - 1; i++)
		{
			jobChain[i].JobsToGenerateWhenThisJobCompleted = new List<StaticJobDefinition> { jobChain[i + 1] };
		}
	}

	private void RegisterEventHandlersForJobChain()
	{
		foreach (StaticJobDefinition item in jobChain)
		{
			item.JobGenerated += OnJobGenerated;
		}
		jobChain[jobChain.Count - 1].JobGenerated += OnLastJobInChainGenerated;
	}

	private void ReserveRequiredTracks(bool ignoreOccupiedTrackLength)
	{
		for (int i = 0; i < jobChain.Count; i++)
		{
			StaticJobDefinition key = jobChain[i];
			if (jobDefToCurrentlyReservedTracks.ContainsKey(key))
			{
				List<TrackReservation> list = jobDefToCurrentlyReservedTracks[key];
				for (int j = 0; j < list.Count; j++)
				{
					SingletonBehaviour<YardTracksOrganizer>.Instance.ReserveSpace(list[j].track, list[j].reservedLength, ignoreOccupiedTrackLength);
				}
			}
			else
			{
				Debug.LogError(string.Format("No reservation data for {0}[{1}] found! Reservation data can be empty, but it needs to be in {2}.", "jobChain", i, "jobDefToCurrentlyReservedTracks"), jobChain[i]);
			}
		}
	}

	private void GenerateFirstJobInChain()
	{
		jobChain[0].TryToGenerateJob();
	}

	private void OnJobGenerated(StaticJobDefinition jobDefinition, Job generatedJob)
	{
		generatedJob.JobAbandoned += OnAnyJobFromChainAbandoned;
		generatedJob.JobCompleted += OnJobCompleted;
		generatedJob.JobExpired += OnAnyJobFromChainExpired;
		StationController stationController = SingletonBehaviour<LogicController>.Instance.YardIdToStationController[jobDefinition.logicStation.ID];
		if (responsibleStationForJobChain == null)
		{
			responsibleStationForJobChain = stationController;
			responsibleStationForJobChain.ProceduralJobsController.AddJobChainController(this);
			jobChainGO.transform.SetParent(responsibleStationForJobChain.transform, worldPositionStays: false);
		}
		else if (responsibleStationForJobChain != stationController)
		{
			responsibleStationForJobChain.ProceduralJobsController.RemoveJobChainController(this);
			responsibleStationForJobChain = stationController;
			responsibleStationForJobChain.ProceduralJobsController.AddJobChainController(this);
			jobChainGO.transform.SetParent(responsibleStationForJobChain.transform, worldPositionStays: false);
		}
		SingletonBehaviour<JobDebtController>.Instance.RegisterGeneratedJob(generatedJob, carsForJobChain);
		SingletonBehaviour<JobsManager>.Instance.RegisterGeneratedJob(generatedJob, new HashSet<Car>(carsForJobChain));
		currentJobInChain = generatedJob;
		UpdateTrainCarPlatesOfCarsOnJob(generatedJob.ID);
	}

	private void OnJobCompleted(Job completedJob)
	{
		bool flag = false;
		for (int i = 0; i < jobChain.Count; i++)
		{
			StaticJobDefinition staticJobDefinition = jobChain[i];
			if (staticJobDefinition.job != completedJob)
			{
				continue;
			}
			if (jobDefToCurrentlyReservedTracks.ContainsKey(staticJobDefinition))
			{
				List<TrackReservation> list = jobDefToCurrentlyReservedTracks[staticJobDefinition];
				for (int j = 0; j < list.Count; j++)
				{
					SingletonBehaviour<YardTracksOrganizer>.Instance.ReleaseReservedSpace(list[j].track, list[j].reservedLength);
				}
				jobDefToCurrentlyReservedTracks.Remove(staticJobDefinition);
			}
			else
			{
				Debug.LogError(string.Format("No reservation data for {0}[{1}] found! Reservation data can be empty, but it needs to be in {2}.", "jobChain", i, "jobDefToCurrentlyReservedTracks"), jobChain[i]);
			}
			if (i < jobChain.Count - 1)
			{
				jobChain.Remove(staticJobDefinition);
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			Debug.LogError("Couldn't find Job[" + completedJob.ID + "] corresponding job definition in jobChain!");
		}
		SingletonBehaviour<JobsManager>.Instance.UnregisterJob(completedJob);
	}

	private void OnLastJobInChainGenerated(StaticJobDefinition lastJobDefinition, Job lastJobInChain)
	{
		lastJobInChain.JobCompleted += OnLastJobInChainCompleted;
	}

	protected virtual void OnLastJobInChainCompleted(Job lastJobInChain)
	{
		jobChain.RemoveAt(jobChain.Count - 1);
		SingletonBehaviour<JobDebtController>.Instance.RegisterJoblessCars(carsForJobChain);
		UpdateTrainCarPlatesOfCarsOnJob(string.Empty);
		this.JobChainCompleted?.Invoke(this);
	}

	private void OnAnyJobFromChainAbandoned(Job abandonedJob)
	{
		ReleaseRemainingReservations();
		SingletonBehaviour<JobDebtController>.Instance.RegisterJoblessCars(carsForJobChain);
		SingletonBehaviour<JobsManager>.Instance.UnregisterJob(abandonedJob);
		UpdateTrainCarPlatesOfCarsOnJob(string.Empty);
		this.JobOfChainAbandoned?.Invoke(this);
	}

	private void OnAnyJobFromChainExpired(Job expiredJob)
	{
		SingletonBehaviour<JobDebtController>.Instance.RegisterJoblessCars(carsForJobChain);
		SingletonBehaviour<JobsManager>.Instance.UnregisterJob(expiredJob);
		UpdateTrainCarPlatesOfCarsOnJob(string.Empty);
		this.JobOfChainExpired?.Invoke(this);
	}

	private void ReleaseRemainingReservations()
	{
		foreach (StaticJobDefinition key in jobDefToCurrentlyReservedTracks.Keys)
		{
			List<TrackReservation> list = jobDefToCurrentlyReservedTracks[key];
			for (int i = 0; i < list.Count; i++)
			{
				SingletonBehaviour<YardTracksOrganizer>.Instance.ReleaseReservedSpace(list[i].track, list[i].reservedLength);
			}
		}
		jobDefToCurrentlyReservedTracks.Clear();
	}

	private void UpdateTrainCarPlatesOfCarsOnJob(string jobId)
	{
		TrainCarRegistry instance = SingletonBehaviour<TrainCarRegistry>.Instance;
		foreach (Car item in carsForJobChain)
		{
			if (item != null)
			{
				instance.logicCarToTrainCar[item].UpdateJobIdOnCarPlates(jobId);
			}
		}
	}

	public JobChainSaveData GetJobChainSaveData()
	{
		if (!AreCarsInitialized() || jobChain == null || jobChain.Count == 0 || responsibleStationForJobChain == null)
		{
			throw new Exception("Uninitialized chain controller!");
		}
		JobDefinitionDataBase[] array = new JobDefinitionDataBase[jobChain.Count];
		for (int i = 0; i < jobChain.Count; i++)
		{
			array[i] = jobChain[i].GetJobDefinitionSaveData();
		}
		string[] array2 = new string[carsForJobChain.Count];
		for (int j = 0; j < carsForJobChain.Count; j++)
		{
			array2[j] = ((carsForJobChain[j] != null) ? carsForJobChain[j].carGuid : string.Empty);
		}
		bool flag = IsChainActive();
		return new JobChainSaveData(array, array2, flag, flag ? currentJobInChain.GetTasksSaveData() : null, currentJobInChain.ID);
	}
}
