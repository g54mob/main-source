using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Logic.Job
{
	public class Station
	{
		public readonly string name;

		public readonly string ID;

		public readonly Yard yard;

		public List<Job> availableJobs;

		public List<Job> takenJobs;

		public List<Job> abandonedJobs;

		public List<Job> completedJobs;

		public event Action JobAddedToStation;

		public Station(string name, string ID, Yard yard)
		{
			this.name = name;
			this.ID = ID;
			this.yard = yard;
			availableJobs = new List<Job>();
			takenJobs = new List<Job>();
			abandonedJobs = new List<Job>();
			completedJobs = new List<Job>();
		}

		public void AddJobToStation(Job job)
		{
			if (availableJobs.Contains(job))
			{
				Debug.LogError("Trying to add the same job[" + job.ID + "] multiple times to station! Skipping, trying to recover.");
				return;
			}
			availableJobs.Add(job);
			job.JobTaken += OnJobTaken;
			job.JobExpired += OnJobExpired;
			this.JobAddedToStation?.Invoke();
		}

		public void ExpireAllAvailableJobsInStation()
		{
			for (int num = availableJobs.Count - 1; num >= 0; num--)
			{
				availableJobs[num].ExpireJob();
			}
		}

		private void OnJobAbandoned(Job abandonedJob)
		{
			abandonedJob.JobCompleted -= OnJobCompleted;
			abandonedJob.JobAbandoned -= OnJobAbandoned;
			takenJobs.Remove(abandonedJob);
			abandonedJobs.Add(abandonedJob);
		}

		private void OnJobCompleted(Job completedJob)
		{
			completedJob.JobCompleted -= OnJobCompleted;
			completedJob.JobAbandoned -= OnJobAbandoned;
			takenJobs.Remove(completedJob);
			completedJobs.Add(completedJob);
		}

		private void OnJobTaken(Job takenJob, bool _)
		{
			takenJob.JobTaken -= OnJobTaken;
			takenJob.JobExpired -= OnJobExpired;
			takenJob.JobCompleted += OnJobCompleted;
			takenJob.JobAbandoned += OnJobAbandoned;
			availableJobs.Remove(takenJob);
			takenJobs.Add(takenJob);
		}

		private void OnJobExpired(Job expiredJob)
		{
			expiredJob.JobTaken -= OnJobTaken;
			expiredJob.JobExpired -= OnJobExpired;
			if (!availableJobs.Contains(expiredJob))
			{
				Debug.LogError("Trying to remove a job[" + expiredJob.ID + "] that is not available at this station! Skipping, trying to recover.");
			}
			else
			{
				availableJobs.Remove(expiredJob);
			}
		}
	}
}
