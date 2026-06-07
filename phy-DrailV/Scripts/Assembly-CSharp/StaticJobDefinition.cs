using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;
using UnityEngine;

public abstract class StaticJobDefinition : MonoBehaviour
{
	[Tooltip("Chained jobs definitions that will be generated when this job is completed")]
	public List<StaticJobDefinition> JobsToGenerateWhenThisJobCompleted;

	[Tooltip("Time job should be completed for, 0 means you have unlimited time")]
	public float timeLimitForJob;

	[Tooltip("Initial wage for the job")]
	public float initialWage;

	[Tooltip("Station for which job is generated")]
	public Station logicStation;

	[Tooltip("YardIds for job chain origin and destination station")]
	public StationsChainData chainData;

	protected JobLicenses requiredLicenses;

	private string forcedJobId;

	public Job job { get; protected set; }

	public event Action<StaticJobDefinition, Job> JobGenerated;

	public void TryToGenerateJob()
	{
		if (job != null)
		{
			Debug.LogWarning("New static job not generated, job was already generated before!", this);
			return;
		}
		GenerateJob(logicStation, timeLimitForJob, initialWage, forcedJobId, requiredLicenses);
		if (job != null)
		{
			this.JobGenerated?.Invoke(this, job);
			List<StaticJobDefinition> jobsToGenerateWhenThisJobCompleted = JobsToGenerateWhenThisJobCompleted;
			if (jobsToGenerateWhenThisJobCompleted != null && jobsToGenerateWhenThisJobCompleted.Count > 0)
			{
				job.JobCompleted += OnJobCompleted;
			}
		}
	}

	public void PopulateBaseJobDefinition(Station logicStation, float timeLimitForJob, float initialWage, StationsChainData chainData = null, JobLicenses requiredLicenses = JobLicenses.Basic)
	{
		this.logicStation = logicStation;
		this.timeLimitForJob = timeLimitForJob;
		this.initialWage = initialWage;
		this.chainData = chainData;
		this.requiredLicenses = requiredLicenses;
	}

	public void ForceJobId(string forcedJobId)
	{
		this.forcedJobId = forcedJobId;
	}

	protected abstract void GenerateJob(Station jobOriginStation, float timeLimit = 0f, float initialWage = 0f, string forcedJobId = null, JobLicenses requiredLicenses = JobLicenses.Basic);

	public abstract List<TrackReservation> GetRequiredTrackReservations();

	public abstract JobDefinitionDataBase GetJobDefinitionSaveData();

	private void OnJobCompleted(Job jobCompleted)
	{
		job.JobCompleted -= OnJobCompleted;
		foreach (StaticJobDefinition item in JobsToGenerateWhenThisJobCompleted)
		{
			if (item.job != null)
			{
				Debug.LogError("Chained job was already generated, this is not correct behaviour", this);
			}
			item.TryToGenerateJob();
		}
	}

	public static string[] GetGuidsFromCars(List<Car> cars)
	{
		if (cars == null || cars.Count == 0)
		{
			return null;
		}
		string[] array = new string[cars.Count];
		for (int i = 0; i < cars.Count; i++)
		{
			array[i] = cars[i].carGuid;
		}
		return array;
	}
}
