using System.Collections.Generic;
using System.Linq;
using DV.ThingTypes;

namespace DV.ServicePenalty
{
	public class JobDebtTracker
	{
		public readonly string id;

		private readonly DebtTrackerCar[] carsDebtTrackers;

		public JobDebtTracker(string id, DebtTrackerCar[] carsDebtTrackers)
		{
			this.id = id;
			this.carsDebtTrackers = carsDebtTrackers;
		}

		public void UpdateDebtValues()
		{
			DebtTrackerCar[] array = carsDebtTrackers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].UpdateDebtValues();
			}
		}

		public void UpdateStartValuesToEndValues()
		{
			DebtTrackerCar[] array = carsDebtTrackers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].UpdateStartValueToEndValue();
			}
		}

		public void UpdateJobTakenSnapshot()
		{
			DebtTrackerCar[] array = carsDebtTrackers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].TakeSnapshot(new List<ResourceType> { ResourceType.EnvironmentDamageCargo });
			}
		}

		public void ClearJobTakenSnapshot()
		{
			DebtTrackerCar[] array = carsDebtTrackers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ClearSnapshot();
			}
		}

		public float GetCurrentTotalPriceOfDebt(bool includeTax = false)
		{
			float num = 0f;
			DebtTrackerCar[] array = carsDebtTrackers;
			foreach (DebtTrackerCar debtTrackerCar in array)
			{
				num += debtTrackerCar.GetCurrentTotalPriceOfDebt(includeTax);
			}
			return num;
		}

		public CarDebtData[] GetCarDebts()
		{
			return carsDebtTrackers.Select((DebtTrackerCar t) => t.GetDebtData()).ToArray();
		}

		public JobDebtData GetJobDebtData(bool filterOutUnchanged = false)
		{
			List<CarDebtData> list = new List<CarDebtData>();
			for (int i = 0; i < carsDebtTrackers.Length; i++)
			{
				CarDebtData carDebtData = carsDebtTrackers[i].GetDebtData();
				if (filterOutUnchanged)
				{
					carDebtData = CarDebtData.FilterOutUnchangedComponents(carDebtData);
					if (carDebtData == null)
					{
						continue;
					}
				}
				list.Add(new CarDebtData(carDebtData));
			}
			if (list.Count == 0)
			{
				return null;
			}
			return new JobDebtData(id, list.ToArray());
		}
	}
}
