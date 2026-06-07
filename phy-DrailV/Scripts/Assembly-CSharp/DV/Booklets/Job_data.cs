using System;
using System.Linq;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	[Serializable]
	public class Job_data
	{
		public string ID;

		public JobType type;

		public JobState state;

		public float completionTime;

		public float timeOnJob;

		public float timeLimit;

		public float basePayment;

		public float bonusPayment;

		public float totalPayment;

		public JobLicenses requiredLicenses;

		public Task_data[] tasksData;

		public StationInfo chainOriginStationInfo;

		public StationInfo chainDestinationStationInfo;

		public Job_data(string ID, JobType type, JobState state, float completionTime, float timeOnJob, float timeLimit, float basePayment, float bonusPayment, float totalPayment, JobLicenses requiredLicenses, Task_data[] tasksData, StationInfo chainOriginStationInfo, StationInfo chainDestinationStationInfo)
		{
			this.ID = ID;
			this.type = type;
			this.state = state;
			this.completionTime = completionTime;
			this.timeOnJob = timeOnJob;
			this.timeLimit = timeLimit;
			this.basePayment = basePayment;
			this.bonusPayment = bonusPayment;
			this.totalPayment = totalPayment;
			this.requiredLicenses = requiredLicenses;
			this.tasksData = tasksData;
			this.chainOriginStationInfo = chainOriginStationInfo;
			this.chainDestinationStationInfo = chainDestinationStationInfo;
		}

		public Job_data(Job job)
		{
			ID = job.ID;
			type = job.jobType;
			state = job.State;
			completionTime = job.GetJobCompletionTime();
			timeOnJob = job.GetTimeOnJob();
			timeLimit = job.TimeLimit;
			basePayment = job.GetBasePaymentForTheJob();
			bonusPayment = job.GetBonusPaymentForTheJob();
			totalPayment = job.GetWageForTheJob();
			tasksData = job.tasks.Select((Task t) => new Task_data(t)).ToArray();
			requiredLicenses = job.requiredLicenses;
			chainOriginStationInfo = GetRuntimeStationInfo(job.chainData.chainOriginYardId);
			chainDestinationStationInfo = GetRuntimeStationInfo(job.chainData.chainDestinationYardId);
		}

		private StationInfo GetRuntimeStationInfo(string yardId)
		{
			if (SingletonBehaviour<LogicController>.Instance != null && SingletonBehaviour<LogicController>.Instance.YardIdToStationController != null && SingletonBehaviour<LogicController>.Instance.YardIdToStationController.TryGetValue(yardId, out var value))
			{
				return value.stationInfo;
			}
			Debug.LogError("Yard " + yardId + " does not exist. There is no StationController with this yard ID! This should happen, initialize StationControllers properly!");
			return null;
		}
	}
}
