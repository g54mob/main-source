using System;
using System.Collections.Generic;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Logic.Job
{
	public class JobsManager : SingletonBehaviour<JobsManager>
	{
		[NonSerialized]
		public List<Job> currentJobs = new List<Job>();

		[NonSerialized]
		public List<Job> finishedJobs = new List<Job>();

		[NonSerialized]
		public List<Job> abandonedJobs = new List<Job>();

		private Dictionary<Job, HashSet<Car>> jobToJobCars = new Dictionary<Job, HashSet<Car>>();

		private List<Job> allJobs = new List<Job>();

		private float _time;

		public float Time => _time;

		public new static string AllowAutoCreate()
		{
			return "[JobsManager]";
		}

		public void LoadTime(float time)
		{
			_time = time;
		}

		public void AdvanceTime(float amountOfTimeToSkip)
		{
			if (currentJobs.Count > 0)
			{
				_time += amountOfTimeToSkip;
				{
					foreach (Job currentJob in currentJobs)
					{
						foreach (Task task in currentJob.tasks)
						{
							task.UpdateTaskState();
						}
					}
					return;
				}
			}
			_time = 0f;
		}

		private void Update()
		{
			AdvanceTime(UnityEngine.Time.deltaTime);
		}

		public void TakeJob(Job job, bool takenViaLoadGame = false)
		{
			currentJobs.Add(job);
			job.TakeJob(takenViaLoadGame);
		}

		public void AbandonJob(Job job)
		{
			if (!currentJobs.Contains(job))
			{
				throw new Exception("Trying to abandon job that is not in currentJobs list");
			}
			currentJobs.Remove(job);
			abandonedJobs.Add(job);
			job.AbandonJob();
		}

		public void AbandonAllJobs()
		{
			for (int num = currentJobs.Count - 1; num >= 0; num--)
			{
				AbandonJob(currentJobs[num]);
			}
		}

		public void CompleteTheJob(Job job)
		{
			if (!currentJobs.Contains(job))
			{
				throw new Exception("Trying to complete the job that is not in currentJobs list");
			}
			currentJobs.Remove(job);
			finishedJobs.Add(job);
			job.CompleteJob();
		}

		public JobState TryToCompleteAJob(Job job)
		{
			if (job.ValidateJobFinished())
			{
				CompleteTheJob(job);
			}
			return job.State;
		}

		public List<Job> CheckCurrentJobsCompletion()
		{
			List<Job> list = new List<Job>();
			foreach (Job currentJob in currentJobs)
			{
				if (currentJob.ValidateJobFinished())
				{
					list.Add(currentJob);
				}
			}
			foreach (Job item in list)
			{
				CompleteTheJob(item);
			}
			return list;
		}

		public void RegisterGeneratedJob(Job job, HashSet<Car> cars)
		{
			jobToJobCars.Add(job, cars);
			allJobs.Add(job);
		}

		public void UnregisterJob(Job job)
		{
			if (!jobToJobCars.Remove(job))
			{
				Debug.LogError("Unexpected situation, couldn't find job[" + job.ID + "] in jobToJobCars!");
			}
			if (!allJobs.Remove(job))
			{
				Debug.LogError("Unexpected situation, couldn't find job[" + job.ID + "] in allJobs!");
			}
		}

		public Job GetJobOfCar(Car car, bool onlyActiveJobs = false)
		{
			foreach (Job item in onlyActiveJobs ? currentJobs : allJobs)
			{
				if (jobToJobCars[item].Contains(car))
				{
					return item;
				}
			}
			return null;
		}
	}
}
