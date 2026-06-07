using System;
using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class LocoDebtController : SingletonBehaviour<LocoDebtController>
	{
		private const string EXISTING_LOCO_DEBT_ID_KEY = "id";

		private const string EXISTING_LOCO_DEBT_ACTIVATION_TIME_KEY = "t";

		private const string DESTROYED_LOCO_DEBT_DATA_KEY = "d";

		private const string DESTROYED_LOCO_DEBT_ACTIVATION_TIME_KEY = "t";

		public List<ExistingLocoDebt> trackedLocosDebts = new List<ExistingLocoDebt>();

		public List<StagedLocoDebt> destroyedLocosDebts = new List<StagedLocoDebt>();

		public new static string AllowAutoCreate()
		{
			return "[LocoDebtController]";
		}

		public void RegisterLocoDebtTracker(TrainCar car, LocoDebtTrackerBase locoDebtTracker)
		{
			ExistingLocoDebt existingLocoDebt = new ExistingLocoDebt(car, locoDebtTracker);
			trackedLocosDebts.Add(existingLocoDebt);
			SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(existingLocoDebt);
		}

		public void StageLocoDebtOnLocoDestroy(LocoDebtTrackerBase locoDebtTrackerToStage)
		{
			int num = trackedLocosDebts.FindIndex((ExistingLocoDebt debt) => debt.locoDebtTracker == locoDebtTrackerToStage);
			if (num == -1)
			{
				throw new Exception("Unexpected error: LocoDebtTrackerBase is not part of the trackedLocosDebts!");
			}
			ExistingLocoDebt existingLocoDebt = trackedLocosDebts[num];
			trackedLocosDebts.RemoveAt(num);
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(existingLocoDebt);
			existingLocoDebt.UpdateDebtState();
			CarDebtData debtData = existingLocoDebt.locoDebtTracker.GetDebtData();
			if (debtData.GetTotalPriceOfDebt(includeTax: true) > 0f)
			{
				debtData = CarDebtData.FilterOutUnchangedComponents(debtData);
				if (debtData != null)
				{
					StagedLocoDebt stagedLocoDebt = new StagedLocoDebt(debtData, existingLocoDebt.ActivationTime);
					destroyedLocosDebts.Add(stagedLocoDebt);
					SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(stagedLocoDebt);
				}
			}
		}

		public StagedLocoDebt GetLastStagedLocoDebtWithId(string locoId)
		{
			for (int num = destroyedLocosDebts.Count - 1; num >= 0; num--)
			{
				if (destroyedLocosDebts[num].ID == locoId)
				{
					return destroyedLocosDebts[num];
				}
			}
			return null;
		}

		public void PayStagedLocoDebt(StagedLocoDebt locoDebtToPay)
		{
			if (!destroyedLocosDebts.Remove(locoDebtToPay))
			{
				Debug.LogError("Trying to pay debt that is not part of destroyedLocosDebts");
			}
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(locoDebtToPay);
		}

		public void PayExistingLocoDebt(ExistingLocoDebt locoDebtToPay)
		{
			if (!trackedLocosDebts.Contains(locoDebtToPay))
			{
				Debug.LogError("Trying to pay debt that is not part of trackedLocosDebts");
				return;
			}
			SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(locoDebtToPay);
			locoDebtToPay.locoDebtTracker.ResetState();
			SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(locoDebtToPay);
		}

		public void ClearLocoDebts()
		{
			foreach (StagedLocoDebt destroyedLocosDebt in destroyedLocosDebts)
			{
				SingletonBehaviour<CareerManagerDebtController>.Instance.UnregisterDebt(destroyedLocosDebt);
			}
			destroyedLocosDebts.Clear();
		}

		public JObject[] GetExistingLocosDebtsSaveData()
		{
			List<JObject> list = new List<JObject>();
			for (int i = 0; i < trackedLocosDebts.Count; i++)
			{
				ExistingLocoDebt existingLocoDebt = trackedLocosDebts[i];
				if (existingLocoDebt.IsActivationTimeSet)
				{
					JObject jObject = new JObject();
					jObject.SetString("id", existingLocoDebt.ID);
					jObject.SetDouble("t", existingLocoDebt.ActivationTime.ToOADate());
					list.Add(jObject);
				}
			}
			return list.ToArray();
		}

		public void LoadExistingLocosDebtsSaveData(JObject[] data)
		{
			foreach (JObject dataObject in data)
			{
				string text = dataObject.GetString("id");
				double? num = dataObject.GetDouble("t");
				if (text != null && num.HasValue)
				{
					bool flag = false;
					foreach (ExistingLocoDebt trackedLocosDebt in trackedLocosDebts)
					{
						if (trackedLocosDebt.ID == text)
						{
							DateTime savedActivationTime = DateTime.FromOADate(num.Value);
							trackedLocosDebt.LoadActivationTime(savedActivationTime);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Debug.LogError("Unexpected state: Couldn't find loco[" + text + "] to properly load activation time! Skipping");
					}
				}
				else
				{
					Debug.LogError("Unexpected state: Can't load activation time data for existing loco debt! Skipping");
				}
			}
		}

		public JObject[] GetDestroyedLocosDebtsSaveData()
		{
			JObject[] array = new JObject[destroyedLocosDebts.Count];
			for (int i = 0; i < destroyedLocosDebts.Count; i++)
			{
				JObject jObject = new JObject();
				jObject.SetJObject("d", destroyedLocosDebts[i].locoDebtData.GetCarDebtSaveData());
				jObject.SetDouble("t", destroyedLocosDebts[i].ActivationTime.ToOADate());
				array[i] = jObject;
			}
			return array;
		}

		public void LoadDestroyedLocosDebtsSaveData(JObject[] data)
		{
			foreach (JObject dataObject in data)
			{
				JObject jObject = dataObject.GetJObject("d");
				double? num = dataObject.GetDouble("t");
				if (jObject != null && num.HasValue)
				{
					CarDebtData locoDebtData;
					DateTime activationTime;
					try
					{
						locoDebtData = CarDebtData.LoadCarDebtFromSaveData(jObject);
						activationTime = DateTime.FromOADate(num.Value);
					}
					catch (Exception message)
					{
						Debug.LogWarning("Loading of CarDebtData / DateTime entry failed due to invalid data. Skipping this entry");
						Debug.LogError(message);
						continue;
					}
					StagedLocoDebt stagedLocoDebt = new StagedLocoDebt(locoDebtData, activationTime);
					destroyedLocosDebts.Add(stagedLocoDebt);
					SingletonBehaviour<CareerManagerDebtController>.Instance.RegisterDebt(stagedLocoDebt);
				}
			}
		}
	}
}
