using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DV.Utils;
using UnityEngine;

public class StationProceduralJobsController : MonoBehaviour
{
	private const int JOB_GENERATION_ATTEMPTS = 30;

	private const int LICENSED_JOBS_GENERATION_ATTEMPTS = 10;

	private const int WAIT_FRAMES_BETWEEN_JOBS = 12;

	public StationController stationController;

	private List<JobChainController> jobChainControllers;

	private StationProceduralJobGenerator procJobGenerator;

	private StationProceduralJobsRuleset generationRuleset;

	private Coroutine generationCoro;

	public bool IsJobGenerationActive => generationCoro != null;

	public event Action JobGenerationAttempt;

	private void Awake()
	{
		stationController = GetComponent<StationController>();
		if (stationController == null)
		{
			Debug.LogError("There was no StationController found on the same GO as StationProceduralJobsController! This should never happen!", this);
		}
		generationRuleset = stationController.proceduralJobsRuleset;
		procJobGenerator = new StationProceduralJobGenerator(stationController);
		jobChainControllers = new List<JobChainController>();
	}

	public List<JobChainController> GetCurrentJobChains()
	{
		return jobChainControllers;
	}

	public void TryToGenerateJobs()
	{
		StopJobGeneration();
		generationCoro = StartCoroutine(GenerateProceduralJobsCoro());
	}

	public void StopJobGeneration()
	{
		if (generationCoro != null)
		{
			Debug.Log($"{stationController.stationInfo.YardID} job generation stopped ({stationController.logicStation.availableJobs.Count} generated)!");
			StopCoroutine(generationCoro);
			generationCoro = null;
		}
	}

	private IEnumerator GenerateProceduralJobsCoro()
	{
		int generateJobsAttempts = 0;
		bool forcePlayerLicensedJobGeneration = true;
		StringBuilder log = new StringBuilder();
		Debug.Log(stationController.stationInfo.YardID + " job generation started");
		while (stationController.logicStation.availableJobs.Count < generationRuleset.jobsCapacity && generateJobsAttempts < 30)
		{
			yield return WaitFor.FixedUpdate;
			if (generateJobsAttempts > 10 && forcePlayerLicensedJobGeneration)
			{
				log.AppendLine("Couldn't generate any player licensed job");
				forcePlayerLicensedJobGeneration = false;
			}
			int tickCount = Environment.TickCount;
			System.Random rng = new System.Random(tickCount);
			JobChainController jobChainController = procJobGenerator.GenerateJobChain(rng, forcePlayerLicensedJobGeneration);
			this.JobGenerationAttempt?.Invoke();
			if (jobChainController != null)
			{
				if (forcePlayerLicensedJobGeneration)
				{
					forcePlayerLicensedJobGeneration = false;
				}
				log.AppendLine($"Generated {jobChainController.jobChainGO.name} ({jobChainController.currentJobInChain.ID}) | rng seed: {tickCount}");
				for (int i = 0; i < 12; i++)
				{
					yield return null;
				}
			}
			else
			{
				generateJobsAttempts++;
				yield return null;
			}
		}
		Debug.Log(log.ToString());
		generationCoro = null;
	}

	public void AddJobChainController(JobChainController jobChainController)
	{
		jobChainControllers.Add(jobChainController);
		SetupChainControllerListeners(jobChainController, set: true);
	}

	public void RemoveJobChainController(JobChainController jobChainController)
	{
		jobChainControllers.Remove(jobChainController);
		SetupChainControllerListeners(jobChainController, set: false);
	}

	private void SetupChainControllerListeners(JobChainController jobChainController, bool set)
	{
		if (set)
		{
			jobChainController.JobOfChainExpired += DeleteChainController;
			jobChainController.JobChainCompleted += DeleteChainController;
			jobChainController.JobOfChainAbandoned += DeleteChainController;
		}
		else
		{
			jobChainController.JobOfChainExpired -= DeleteChainController;
			jobChainController.JobChainCompleted -= DeleteChainController;
			jobChainController.JobOfChainAbandoned -= DeleteChainController;
		}
	}

	private void DeleteChainController(JobChainController chainToDelete)
	{
		chainToDelete.JobOfChainExpired -= DeleteChainController;
		chainToDelete.JobChainCompleted -= DeleteChainController;
		chainToDelete.JobOfChainAbandoned -= DeleteChainController;
		SingletonBehaviour<UnusedTrainCarDeleter>.Instance.MarkForDelete(chainToDelete.carsForJobChain);
		jobChainControllers.Remove(chainToDelete);
		chainToDelete.DestroyChain();
	}
}
