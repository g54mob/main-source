using System;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;

namespace DV.ServicePenalty
{
	public class JobDebtData
	{
		private const string ID_KEY = "id";

		private const string CAR_DEBTS_DATA_ARRAY_KEY = "carDebts";

		public readonly string id;

		private readonly CarDebtData[] carsDebts;

		public JobDebtData(string id, CarDebtData[] carsDebts)
		{
			this.id = id;
			this.carsDebts = carsDebts;
		}

		public CarDebtData[] GetCarsDebts()
		{
			return carsDebts;
		}

		public float GetTotalPriceOfDebt(bool includeTax = false)
		{
			float num = 0f;
			CarDebtData[] array = carsDebts;
			foreach (CarDebtData carDebtData in array)
			{
				num += carDebtData.GetTotalPriceOfDebt(includeTax);
			}
			return num;
		}

		public JObject GetJobDebtSaveData()
		{
			JObject jObject = new JObject();
			jObject.SetString("id", id);
			JObject[] array = new JObject[carsDebts.Length];
			for (int i = 0; i < carsDebts.Length; i++)
			{
				array[i] = carsDebts[i].GetCarDebtSaveData();
			}
			jObject.SetJObjectArray("carDebts", array);
			return jObject;
		}

		public static JobDebtData LoadJobDebtDataFromSaveData(JObject data)
		{
			string text = data.GetString("id");
			JObject[] jObjectArray = data.GetJObjectArray("carDebts");
			if (text == null || jObjectArray == null)
			{
				throw new Exception("Bad load data for CarDebtData!");
			}
			CarDebtData[] array = new CarDebtData[jObjectArray.Length];
			for (int i = 0; i < jObjectArray.Length; i++)
			{
				array[i] = CarDebtData.LoadCarDebtFromSaveData(jObjectArray[i]);
			}
			return new JobDebtData(text, array);
		}
	}
}
