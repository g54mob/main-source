using System;
using System.Collections.Generic;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Logic.Job
{
	public class Job
	{
		public readonly JobType jobType;

		public readonly string ID;

		public readonly List<Task> tasks;

		public readonly StationsChainData chainData;

		public JobLicenses requiredLicenses;

		private float startTime;

		private float finishTime;

		private float initialWage;

		public JobState State { get; private set; }

		public float TimeLimit { get; private set; }

		public event Action<Job, bool> JobTaken;

		public event Action<Job> JobAbandoned;

		public event Action<Job> JobCompleted;

		public event Action<Job> JobExpired;

		public Job(List<Task> tasks, bool timedJobCalculateTimefromTasks, JobType jobType = JobType.Custom, float initialWage = 0f, StationsChainData chainData = null, string forcedId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			this.tasks = tasks;
			this.chainData = chainData;
			this.jobType = jobType;
			this.initialWage = initialWage;
			this.requiredLicenses = requiredLicenses;
			State = JobState.Available;
			startTime = 0f;
			finishTime = 0f;
			TimeLimit = 0f;
			foreach (Task task in tasks)
			{
				task.SetJobBelonging(this);
				if (timedJobCalculateTimefromTasks)
				{
					TimeLimit += task.TimeLimit;
				}
			}
			bool flag = string.IsNullOrEmpty(forcedId);
			ID = (flag ? SingletonBehaviour<IdGenerator>.Instance.GenerateJobID(jobType, chainData) : forcedId);
			if (!flag)
			{
				SingletonBehaviour<IdGenerator>.Instance.RegisterJobId(ID);
			}
		}

		public Job(List<Task> tasks, JobType jobType = JobType.Custom, float TimeLimit = 0f, float initialWage = 0f, StationsChainData chainData = null, string forcedId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			this.tasks = tasks;
			this.jobType = jobType;
			this.initialWage = initialWage;
			this.chainData = chainData;
			this.requiredLicenses = requiredLicenses;
			State = JobState.Available;
			startTime = 0f;
			finishTime = 0f;
			this.TimeLimit = TimeLimit;
			foreach (Task task in tasks)
			{
				task.SetJobBelonging(this);
			}
			bool flag = string.IsNullOrEmpty(forcedId);
			ID = (flag ? SingletonBehaviour<IdGenerator>.Instance.GenerateJobID(jobType, chainData) : forcedId);
			if (!flag)
			{
				SingletonBehaviour<IdGenerator>.Instance.RegisterJobId(ID);
			}
		}

		public Job(Task task, bool timedJobCalculateTimefromTasks, JobType jobType = JobType.Custom, float initialWage = 0f, StationsChainData chainData = null, string forcedId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			this.jobType = jobType;
			this.initialWage = initialWage;
			this.chainData = chainData;
			this.requiredLicenses = requiredLicenses;
			State = JobState.Available;
			tasks = new List<Task>();
			tasks.Add(task);
			task.SetJobBelonging(this);
			TimeLimit = (timedJobCalculateTimefromTasks ? task.TimeLimit : 0f);
			bool flag = string.IsNullOrEmpty(forcedId);
			ID = (flag ? SingletonBehaviour<IdGenerator>.Instance.GenerateJobID(jobType, chainData) : forcedId);
			if (!flag)
			{
				SingletonBehaviour<IdGenerator>.Instance.RegisterJobId(ID);
			}
		}

		public Job(Task task, JobType jobType = JobType.Custom, float TimeLimit = 0f, float initialWage = 0f, StationsChainData chainData = null, string forcedId = null, JobLicenses requiredLicenses = JobLicenses.Basic)
		{
			this.jobType = jobType;
			this.initialWage = initialWage;
			this.chainData = chainData;
			this.requiredLicenses = requiredLicenses;
			State = JobState.Available;
			tasks = new List<Task>();
			tasks.Add(task);
			task.SetJobBelonging(this);
			this.TimeLimit = TimeLimit;
			bool flag = string.IsNullOrEmpty(forcedId);
			ID = (flag ? SingletonBehaviour<IdGenerator>.Instance.GenerateJobID(jobType, chainData) : forcedId);
			if (!flag)
			{
				SingletonBehaviour<IdGenerator>.Instance.RegisterJobId(ID);
			}
		}

		public bool ValidateJobFinished()
		{
			if (State != JobState.InProgress)
			{
				return State == JobState.Completed;
			}
			foreach (Task task in tasks)
			{
				if (!task.IsTaskCompleted())
				{
					return false;
				}
			}
			finishTime = SingletonBehaviour<JobsManager>.Instance.Time;
			return true;
		}

		public float GetWageForTheJob()
		{
			return 0f + GetBasePaymentForTheJob() + GetBonusPaymentForTheJob();
		}

		public float GetBasePaymentForTheJob()
		{
			float num = 0f;
			foreach (Task task in tasks)
			{
				num += task.GetTaskPrice();
			}
			return num + initialWage;
		}

		public float GetBonusPaymentForTheJob()
		{
			if (State == JobState.Completed)
			{
				if (GetJobCompletionTime() <= TimeLimit + 60f)
				{
					return GetPotentialBonusPaymentForTheJob();
				}
			}
			else if (State == JobState.InProgress && GetTimeOnJob() <= TimeLimit + 60f)
			{
				return GetPotentialBonusPaymentForTheJob();
			}
			return 0f;
		}

		public float GetPotentialBonusPaymentForTheJob()
		{
			return GetBasePaymentForTheJob() * 0.5f;
		}

		public float GetTimeOnJob()
		{
			return SingletonBehaviour<JobsManager>.Instance.Time - startTime;
		}

		public float GetJobCompletionTime()
		{
			return finishTime - startTime;
		}

		public void TakeJob(bool takenViaLoadGame)
		{
			State = JobState.InProgress;
			startTime = SingletonBehaviour<JobsManager>.Instance.Time;
			foreach (Task task in tasks)
			{
				task.StartTask();
			}
			try
			{
				this.JobTaken?.Invoke(this, takenViaLoadGame);
			}
			catch (Exception exception)
			{
				Debug.LogWarning("The following exception was caught while firing JobTaken event");
				Debug.LogException(exception);
			}
		}

		public void AbandonJob()
		{
			State = JobState.Abandoned;
			try
			{
				this.JobAbandoned?.Invoke(this);
			}
			catch (Exception exception)
			{
				Debug.LogWarning("The following exception was caught while firing JobAbandoned event");
				Debug.LogException(exception);
			}
			SingletonBehaviour<IdGenerator>.Instance.UnregisterJobId(ID);
		}

		public void CompleteJob()
		{
			State = JobState.Completed;
			try
			{
				this.JobCompleted?.Invoke(this);
			}
			catch (Exception exception)
			{
				Debug.LogWarning("The following exception was caught while firing JobCompleted event");
				Debug.LogException(exception);
			}
			SingletonBehaviour<IdGenerator>.Instance.UnregisterJobId(ID);
		}

		public void ExpireJob()
		{
			State = JobState.Expired;
			try
			{
				this.JobExpired?.Invoke(this);
			}
			catch (Exception exception)
			{
				Debug.LogWarning("The following exception was caught while firing JobExpired event");
				Debug.LogException(exception);
			}
			SingletonBehaviour<IdGenerator>.Instance.UnregisterJobId(ID);
		}

		public TaskSaveData[] GetTasksSaveData()
		{
			TaskSaveData[] array = new TaskSaveData[tasks.Count];
			for (int i = 0; i < tasks.Count; i++)
			{
				array[i] = tasks[i].GetTaskSaveData();
			}
			return array;
		}

		public void OverrideTasksStates(TaskSaveData[] tasksData)
		{
			if (tasksData.Length != tasks.Count)
			{
				throw new Exception("Unmatching count of tasksData and tasks!");
			}
			startTime = tasksData[0].taskStartTime;
			for (int i = 0; i < tasksData.Length; i++)
			{
				tasks[i].OverrideTaskState(tasksData[i]);
			}
		}
	}
}
