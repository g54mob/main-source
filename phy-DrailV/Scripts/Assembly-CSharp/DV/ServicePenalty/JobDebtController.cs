using System;
using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class JobDebtController : SingletonBehaviour<JobDebtController>
	{
		private const string EXISTING_JOB_DEBT_ID_KEY = "id";

		private const string EXISTING_JOB_DEBT_ACTIVATION_TIME_KEY = "t";

		private const string STAGED_JOBS_DEBT_DATA_KEY = "d";

		private const string STAGED_JOBS_DEBT_ACTIVATION_TIME_KEY = "t";

		private const string EXISTING_JOBLESS_CARS_DEBT_ACTIVATION_TIME_KEY = "t";

		private const string DELETED_JOBLESS_CARS_DEBTS_KEY = "d";

		private const string DELETED_JOBLESS_CARS_DEBT_ACTIVATION_TIME_KEY = "t";

		private Dictionary<Job, ExistingJobDebt> jobToExistingJobDebt = new Dictionary<Job, ExistingJobDebt>();

		public List<ExistingJobDebt> existingTrackedJobs = new List<ExistingJobDebt>();

		public List<StagedJobDebt> stagedJobsDebts = new List<StagedJobDebt>();

		public ExistingOtherDebt existingJoblessCarDebts = new ExistingOtherDebt();

		public StagedOtherDebt deletedJoblessCarDebts = new StagedOtherDebt();

		public DisplayableDebt LastStagedJobDebt { get; private set; }

		public new static string AllowAutoCreate()
		{
			return "[JobDebtController]";
		}

		public void RegisterGeneratedJob(Job job, List<Car> cars)
		{
			Dictionary<Car, TrainCar> logicCarToTrainCar = SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar;
			DebtTrackerCar[] array = new DebtTrackerCar[cars.Count];
			for (int i = 0; i < array.Length; i++)
			{
				CarDebtController component = logicCarToTrainCar[cars[i]].GetComponent<CarDebtController>();
				if (cars[i].playerSpawnedCar || component == null || component.IsDummy)
				{
					Debug.LogError("Bad job logic, player spawned car [" + cars[i].ID + "] used in job! Skipping");
				}
				else
				{
					array[i] = component.CarDebtTracker;
				}
			}
			ExistingJobDebt existingJobDebt = new ExistingJobDebt(new JobDebtTracker(job.ID, array), job);
			existingTrackedJobs.Add(existingJobDebt);
			SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(existingJobDebt);
			jobToExistingJobDebt.Add(job, existingJobDebt);
			job.JobAbandoned += OnJobCompletedAbandonedExpired;
			job.JobCompleted += OnJobCompletedAbandonedExpired;
			job.JobExpired += OnJobCompletedAbandonedExpired;
			job.JobTaken += OnJobTaken;
		}

		private void OnJobTaken(Job takenJob, bool jobLoadedFromSavegame)
		{
			if (!jobLoadedFromSavegame)
			{
				if (jobToExistingJobDebt.TryGetValue(takenJob, out var value))
				{
					value.jobDebtTracker.UpdateJobTakenSnapshot();
				}
				else
				{
					Debug.LogError("Job[" + takenJob.ID + "] wasn't registered in jobToExistingJobDebt. Couldn't take snapshot!");
				}
			}
		}

		private void StageJobDebt(ExistingJobDebt existingJobDebt)
		{
			if (!existingTrackedJobs.Remove(existingJobDebt))
			{
				Debug.LogError("Unexpected error: ExistingJobDebt:" + existingJobDebt.ID + " is not part of the existingTrackedJobs!");
				return;
			}
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(existingJobDebt);
			existingJobDebt.UpdateDebtState();
			JobDebtTracker jobDebtTracker = existingJobDebt.jobDebtTracker;
			JobDebtData jobDebtData = jobDebtTracker.GetJobDebtData(filterOutUnchanged: true);
			if (jobDebtData != null && jobDebtData.GetTotalPriceOfDebt() > 0f)
			{
				StagedJobDebt stagedJobDebt = new StagedJobDebt(jobDebtData, existingJobDebt.ActivationTime);
				stagedJobsDebts.Add(stagedJobDebt);
				SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(stagedJobDebt);
				LastStagedJobDebt = stagedJobDebt;
			}
			else
			{
				LastStagedJobDebt = null;
			}
			jobDebtTracker.UpdateStartValuesToEndValues();
			jobDebtTracker.ClearJobTakenSnapshot();
		}

		private void OnJobCompletedAbandonedExpired(Job job)
		{
			if (jobToExistingJobDebt.TryGetValue(job, out var value))
			{
				StageJobDebt(value);
				jobToExistingJobDebt.Remove(job);
			}
			else
			{
				Debug.LogError("Job[" + job.ID + "] wasn't present in jobToExistingJobDebt! Can't stage it!");
			}
		}

		public void PayExistingJobDebt(ExistingJobDebt jobDebt)
		{
			if (!existingTrackedJobs.Contains(jobDebt))
			{
				Debug.LogError("Trying to pay debt that is not part of existingTrackedJobs");
				return;
			}
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(jobDebt);
			JobDebtTracker jobDebtTracker = jobDebt.jobDebtTracker;
			jobDebtTracker.UpdateDebtValues();
			jobDebtTracker.UpdateStartValuesToEndValues();
			if (jobDebt.job.State == JobState.InProgress)
			{
				jobDebtTracker.UpdateJobTakenSnapshot();
			}
			SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(jobDebt);
		}

		public void PayStagedJobDebt(StagedJobDebt jobDebt)
		{
			if (!stagedJobsDebts.Remove(jobDebt))
			{
				Debug.LogError("Trying to pay debt that is not part of stagedJobsDebts");
			}
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(jobDebt);
		}

		public void ClearJobDebts()
		{
			foreach (StagedJobDebt stagedJobsDebt in stagedJobsDebts)
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(stagedJobsDebt);
			}
			stagedJobsDebts.Clear();
		}

		public ExistingJobDebt GetExistingJobDebtForJob(Job job)
		{
			if (!jobToExistingJobDebt.TryGetValue(job, out var value))
			{
				Debug.LogError("Job" + job.ID + " wasn't present in jobToExistingJobDebt!");
			}
			return value;
		}

		public StagedJobDebt GetLastStagedJobDebtWithId(string jobId)
		{
			for (int num = stagedJobsDebts.Count - 1; num >= 0; num--)
			{
				if (stagedJobsDebts[num].ID == jobId)
				{
					return stagedJobsDebts[num];
				}
			}
			return null;
		}

		public void RegisterJoblessCars(List<Car> cars)
		{
			foreach (Car car in cars)
			{
				if (car == null)
				{
					Debug.LogError("Train car entry is null when trying to register jobless car debt tracker!");
				}
				else if (car.playerSpawnedCar)
				{
					Debug.LogError("Train car is spawned by player, debts shouldn't be tracked! Skipping!");
				}
				else
				{
					AddJoblessCarDebtTracker(car);
				}
			}
		}

		private void AddJoblessCarDebtTracker(Car car)
		{
			CarDebtController component = SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar[car].GetComponent<CarDebtController>();
			if (component == null)
			{
				Debug.LogError("Couldn't find CarDebtController on jobless train car " + car.ID);
				return;
			}
			if (component.IsDummy)
			{
				Debug.LogError("CarDebtController is dummy, it shouldn't add any debts");
				return;
			}
			existingJoblessCarDebts.AddJoblessCarTracker(component.CarDebtTracker);
			if (existingJoblessCarDebts.NumberOfDebts == 1)
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(existingJoblessCarDebts);
			}
			component.SetupOnDestroyJoblessCarListener();
		}

		public void StageJoblessCarDebtOnCarDestroy(DebtTrackerCar debtTrackerCar)
		{
			if (!existingJoblessCarDebts.RemoveJoblessCarTracker(debtTrackerCar))
			{
				Debug.LogError("Unexpected error: DebtTrackerCar" + debtTrackerCar.GetDebtData().id + " is not part of the existingJoblessCarDebts!");
				return;
			}
			if (existingJoblessCarDebts.NumberOfDebts == 0)
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(existingJoblessCarDebts);
			}
			debtTrackerCar.UpdateDebtValues();
			CarDebtData debtData = debtTrackerCar.GetDebtData();
			if (!(debtData.GetTotalPriceOfDebt() > 0f))
			{
				return;
			}
			debtData = CarDebtData.FilterOutUnchangedComponents(debtData);
			if (debtData != null)
			{
				deletedJoblessCarDebts.AddJoblessCarDebt(debtData);
				if (deletedJoblessCarDebts.NumberOfDebts == 1)
				{
					SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(deletedJoblessCarDebts);
				}
			}
		}

		public void PayStagedJoblessCarsDebt()
		{
			deletedJoblessCarDebts.ClearDebts();
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(deletedJoblessCarDebts);
		}

		public void PayExistingJoblessCarsDebt()
		{
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(existingJoblessCarDebts);
			foreach (DebtTrackerCar joblessCarsTracker in existingJoblessCarDebts.joblessCarsTrackers)
			{
				joblessCarsTracker.UpdateDebtValues();
				joblessCarsTracker.UpdateStartValueToEndValue();
			}
			SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(existingJoblessCarDebts);
		}

		public JObject[] GetExistingJobsDebtsSaveData()
		{
			List<JObject> list = new List<JObject>();
			for (int i = 0; i < existingTrackedJobs.Count; i++)
			{
				ExistingJobDebt existingJobDebt = existingTrackedJobs[i];
				if (existingJobDebt.IsActivationTimeSet)
				{
					JObject jObject = new JObject();
					jObject.SetString("id", existingJobDebt.ID);
					jObject.SetDouble("t", existingJobDebt.ActivationTime.ToOADate());
					list.Add(jObject);
				}
			}
			return list.ToArray();
		}

		public void LoadExistingJobsDebtsSaveData(JObject[] data)
		{
			foreach (JObject dataObject in data)
			{
				string text = dataObject.GetString("id");
				double? num = dataObject.GetDouble("t");
				if (text != null && num.HasValue)
				{
					bool flag = false;
					foreach (ExistingJobDebt existingTrackedJob in existingTrackedJobs)
					{
						if (existingTrackedJob.ID == text)
						{
							DateTime savedActivationTime = DateTime.FromOADate(num.Value);
							existingTrackedJob.LoadActivationTime(savedActivationTime);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Debug.LogError("Unexpected state: Couldn't find job[" + text + "] to properly load activation time! Skipping");
					}
				}
				else
				{
					Debug.LogError("Unexpected state: Can't load activation time data for existing job debt! Skipping");
				}
			}
		}

		public JObject[] GetStagedJobsDebtsSaveData()
		{
			JObject[] array = new JObject[stagedJobsDebts.Count];
			for (int i = 0; i < stagedJobsDebts.Count; i++)
			{
				JObject jObject = new JObject();
				jObject.SetJObject("d", stagedJobsDebts[i].jobDebtData.GetJobDebtSaveData());
				jObject.SetDouble("t", stagedJobsDebts[i].ActivationTime.ToOADate());
				array[i] = jObject;
			}
			return array;
		}

		public void LoadStagedJobsDebtsSaveData(JObject[] data)
		{
			foreach (JObject dataObject in data)
			{
				JObject jObject = dataObject.GetJObject("d");
				double? num = dataObject.GetDouble("t");
				if (jObject != null && num.HasValue)
				{
					JobDebtData jobDebtData;
					DateTime activationTime;
					try
					{
						jobDebtData = JobDebtData.LoadJobDebtDataFromSaveData(jObject);
						activationTime = DateTime.FromOADate(num.Value);
					}
					catch (Exception message)
					{
						Debug.LogWarning("Loading of staged JobDebtData / DateTime entry failed due to invalid data. Skipping this entry");
						Debug.LogError(message);
						continue;
					}
					StagedJobDebt stagedJobDebt = new StagedJobDebt(jobDebtData, activationTime);
					stagedJobsDebts.Add(stagedJobDebt);
					SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(stagedJobDebt);
				}
			}
		}

		public JObject GetExistingJoblessCarsDebtsSaveData()
		{
			if (!existingJoblessCarDebts.IsActivationTimeSet)
			{
				return null;
			}
			JObject jObject = new JObject();
			jObject.SetDouble("t", existingJoblessCarDebts.ActivationTime.ToOADate());
			return jObject;
		}

		public void LoadExistingJoblessCarsDebtsSaveData(JObject data)
		{
			double? num = data.GetDouble("t");
			if (num.HasValue)
			{
				DateTime savedActivationTime = DateTime.FromOADate(num.Value);
				existingJoblessCarDebts.LoadActivationTime(savedActivationTime);
			}
		}

		public JObject GetDeletedJoblessCarDebtsSaveData()
		{
			List<CarDebtData> joblessCarsDebtData = deletedJoblessCarDebts.joblessCarsDebtData;
			JObject[] array = new JObject[joblessCarsDebtData.Count];
			int count = joblessCarsDebtData.Count;
			for (int i = 0; i < count; i++)
			{
				array[i] = joblessCarsDebtData[i].GetCarDebtSaveData();
			}
			JObject jObject = new JObject();
			jObject.SetJObjectArray("d", array);
			jObject.SetDouble("t", deletedJoblessCarDebts.ActivationTime.ToOADate());
			return jObject;
		}

		public void LoadDeletedJoblessCarDebtsSaveData(JObject data)
		{
			JObject[] jObjectArray = data.GetJObjectArray("d");
			if (jObjectArray == null)
			{
				return;
			}
			List<CarDebtData> list = new List<CarDebtData>();
			JObject[] array = jObjectArray;
			foreach (JObject data2 in array)
			{
				CarDebtData carDebtData;
				try
				{
					carDebtData = CarDebtData.LoadCarDebtFromSaveData(data2);
				}
				catch (Exception message)
				{
					Debug.LogWarning("Loading of CarDebtData entry failed due to invalid data. Skipping this entry");
					Debug.LogError(message);
					continue;
				}
				if (carDebtData != null)
				{
					list.Add(carDebtData);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			double? num = data.GetDouble("t");
			if (num.HasValue)
			{
				DateTime activationTime = DateTime.FromOADate(num.Value);
				deletedJoblessCarDebts.LoadJoblessCarDebtData(list, activationTime);
				if (deletedJoblessCarDebts.NumberOfDebts >= 1)
				{
					SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(deletedJoblessCarDebts);
				}
			}
			else
			{
				Debug.LogError("Unexpected state: Missing loadedActivationTimeData for deleted jobless cars. Something is wrong. Skipping");
			}
		}
	}
}
