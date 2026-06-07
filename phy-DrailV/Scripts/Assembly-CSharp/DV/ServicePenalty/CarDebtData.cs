using System;
using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using Newtonsoft.Json.Linq;

namespace DV.ServicePenalty
{
	[Serializable]
	public class CarDebtData
	{
		private const string ID_KEY = "id";

		private const string CAR_TYPE_KEY = "carType";

		private const string LOADED_CARGO_TYPE_KEY = "cargoType";

		private const string DEBTS_DATA_ARRAY_KEY = "debts";

		public string id;

		public TrainCarType carType;

		public CargoType loadedCargoType;

		public DebtComponent[] trackedDebts;

		public CarDebtData(string id, TrainCarType carType, DebtComponent[] trackedDebts, CargoType loadedCargoType = CargoType.None)
		{
			this.id = id;
			this.carType = carType;
			this.trackedDebts = trackedDebts;
			this.loadedCargoType = loadedCargoType;
		}

		public CarDebtData(CarDebtData carDebtData)
		{
			id = carDebtData.id;
			carType = carDebtData.carType;
			loadedCargoType = carDebtData.loadedCargoType;
			DebtComponent[] array = carDebtData.GetTrackedDebts();
			trackedDebts = new DebtComponent[array.Length];
			for (int i = 0; i < trackedDebts.Length; i++)
			{
				trackedDebts[i] = new DebtComponent(array[i]);
			}
		}

		public DebtComponent[] GetTrackedDebts()
		{
			return trackedDebts;
		}

		public float GetTotalPriceOfDebt(bool includeTax = false, bool ignoreEnvironmentDamage = false)
		{
			float num = 0f;
			DebtComponent[] array = trackedDebts;
			foreach (DebtComponent debtComponent in array)
			{
				if (!ignoreEnvironmentDamage || !debtComponent.Type.ToV2().canDamageEnvironment)
				{
					num += CalculatePriceOfComponent(debtComponent, includeTax);
				}
			}
			return num;
		}

		public float GetTotalPriceOfResources(ResourceType[] resources, bool includeTax = false)
		{
			float num = 0f;
			DebtComponent[] array = trackedDebts;
			foreach (DebtComponent debtComponent in array)
			{
				if (resources.Contains(debtComponent.Type))
				{
					num += CalculatePriceOfComponent(debtComponent, includeTax);
				}
			}
			return num;
		}

		public void UpdateLoadedCargoType(CargoType loadedCargoType)
		{
			this.loadedCargoType = loadedCargoType;
		}

		private float CalculatePriceOfComponent(DebtComponent component, bool includeTax = false)
		{
			float startToEndDiff = component.StartToEndDiff;
			if (startToEndDiff > 0f)
			{
				float num = startToEndDiff * GetUnitPriceOfComponent(component);
				if (includeTax && component.Type.ToV2().isTaxable)
				{
					num *= 2f;
				}
				return num.To2Decimals();
			}
			return 0f;
		}

		private float GetUnitPriceOfComponent(DebtComponent component)
		{
			TrainCarLivery carLivery = ((carType != TrainCarType.NotSet) ? carType.ToV2() : null);
			CargoType_v2 cargoType = ((loadedCargoType != CargoType.None) ? loadedCargoType.ToV2() : null);
			return ResourceTypes.GetFullUnitPriceOfResource(component.Type, carLivery, cargoType, Globals.G.GameParams.ResourcesParams);
		}

		public JObject GetCarDebtSaveData()
		{
			JObject jObject = new JObject();
			jObject.SetString("id", id);
			jObject.SetInt("carType", (int)carType);
			if (loadedCargoType != CargoType.None)
			{
				jObject.SetInt("cargoType", (int)loadedCargoType);
			}
			JObject[] array = new JObject[trackedDebts.Length];
			for (int i = 0; i < trackedDebts.Length; i++)
			{
				array[i] = trackedDebts[i].GetDebtComponentSaveData();
			}
			jObject.SetJObjectArray("debts", array);
			return jObject;
		}

		public static CarDebtData LoadCarDebtFromSaveData(JObject data)
		{
			string text = data.GetString("id");
			int? num = data.GetInt("carType");
			int? num2 = data.GetInt("cargoType");
			JObject[] jObjectArray = data.GetJObjectArray("debts");
			bool flag = !num2.HasValue || Enum.IsDefined(typeof(CargoType), num2);
			if (!(text != null && num.HasValue && Enum.IsDefined(typeof(TrainCarType), num) && jObjectArray != null && flag))
			{
				throw new Exception("Bad load data for CarDebtData!");
			}
			DebtComponent[] array = new DebtComponent[jObjectArray.Length];
			for (int i = 0; i < jObjectArray.Length; i++)
			{
				array[i] = DebtComponent.LoadDebtComponentFromSaveData(jObjectArray[i]);
			}
			return new CarDebtData(text, (TrainCarType)num.Value, array, num2.HasValue ? ((CargoType)num2.Value) : CargoType.None);
		}

		public List<PrintDebtComponentDetails> GetCarDebtPrintDetails(bool includeTax = false, bool filterOutUnchangedDebts = false, ResourceType[] typesToExcludeFromPrint = null)
		{
			List<PrintDebtComponentDetails> list = new List<PrintDebtComponentDetails>();
			CarDebtData carDebtData = (filterOutUnchangedDebts ? FilterOutUnchangedComponents(this) : this);
			if (carDebtData == null)
			{
				return null;
			}
			DebtComponent[] array = carDebtData.GetTrackedDebts();
			foreach (DebtComponent debtComponent in array)
			{
				if (typesToExcludeFromPrint == null || !typesToExcludeFromPrint.Contains(debtComponent.Type))
				{
					list.Add(new PrintDebtComponentDetails(debtComponent, GetUnitPriceOfComponent(debtComponent), CalculatePriceOfComponent(debtComponent, includeTax)));
				}
			}
			return list;
		}

		public int GetNumberOfDebtComponents(bool filterOutUnchangedDebts, ResourceType[] typesToExclude = null)
		{
			if (!filterOutUnchangedDebts)
			{
				return trackedDebts.Length;
			}
			int num = 0;
			DebtComponent[] array = trackedDebts;
			foreach (DebtComponent debtComponent in array)
			{
				if ((typesToExclude == null || !typesToExclude.Contains(debtComponent.Type)) && debtComponent.StartToEndDiff > 0f)
				{
					num++;
				}
			}
			return num;
		}

		public static CarDebtData FilterOutUnchangedComponents(CarDebtData debtData, bool returnEmptyDebtInsteadOfNull = false)
		{
			DebtComponent[] array = debtData.GetTrackedDebts();
			DebtComponent[] array2 = array.Where((DebtComponent debtComp) => debtComp.StartToEndDiff > 0f).ToArray();
			if (array2.Length == 0 && !returnEmptyDebtInsteadOfNull)
			{
				return null;
			}
			if (array2.Length != array.Length)
			{
				return new CarDebtData(debtData.id, debtData.carType, array2, debtData.loadedCargoType);
			}
			return debtData;
		}
	}
}
