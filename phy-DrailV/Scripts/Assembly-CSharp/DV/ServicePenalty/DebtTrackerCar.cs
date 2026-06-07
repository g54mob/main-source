using System;
using DV.Damage;
using DV.JObjectExtstensions;
using DV.ThingTypes;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class DebtTrackerCar : DebtTrackerBase
	{
		private const string CAR_DAMAGE_DEBT_START_VALUE_KEY = "carStartV";

		private const string CARGO_DAMAGE_DEBT_START_VALUE_KEY = "cargoStartV";

		private const string CAR_DAMAGE_DEBT_SNAPSHOT_VALUE_KEY = "carSnap";

		private const string CARGO_DAMAGE_DEBT_SNAPSHOT_VALUE_KEY = "cargoSnap";

		private const string CARGO_DAMAGE_DEBT_END_VALUE_KEY = "cargoEndV";

		private const string WAS_CARGO_UNLOADED_KEY = "cargoUnloaded";

		private const string LOADED_CARGO_TYPE_KEY = "loadedCargo";

		private CarDamageModel carDmg;

		private CargoDamageModel cargoDmg;

		private bool unloadedCargo;

		private int carDamageIndex;

		private int cargoDamageIndex;

		private int environmentDamageCargoIndex;

		public DebtTrackerCar(CarDamageModel carDmg, CargoDamageModel cargoDmg, string id, TrainCarType carType)
		{
			this.carDmg = carDmg;
			this.cargoDmg = cargoDmg;
			debtData = new CarDebtData(id, carType, InitializeDebtComponents());
			if (cargoDmg != null)
			{
				cargoDmg.CargoDamageLoadedCargo += OnCargoLoaded;
			}
		}

		private void OnCargoLoaded()
		{
			if (cargoDmg == null)
			{
				Debug.LogError("Unexpected state: OnCargoLoaded event handler called, but cargoDmg is null! Ignoring.");
				return;
			}
			cargoDmg.CargoDamageLoadedCargo -= OnCargoLoaded;
			cargoDmg.CargoDamageUnloadedCargo += OnCargoUnloaded;
			debtData.UpdateLoadedCargoType(cargoDmg.cargoType);
			DebtComponent debtComponent = debtData.GetTrackedDebts()[cargoDamageIndex];
			debtComponent.UpdateStartValue(cargoDmg.EffectiveHealthPercentage100Notation);
			debtComponent.UpdateEndValue(cargoDmg.EffectiveHealthPercentage100Notation);
			if (debtComponent.HasSnapshot)
			{
				debtComponent.SetSnapshot(debtComponent.EndValue);
			}
			unloadedCargo = false;
		}

		private void OnCargoUnloaded()
		{
			if (cargoDmg == null)
			{
				Debug.LogError("Unexpected state: OnCargoUnloaded event handler called, but cargoDmg is null! Ignoring.");
				return;
			}
			cargoDmg.CargoDamageUnloadedCargo -= OnCargoUnloaded;
			cargoDmg.CargoDamageLoadedCargo += OnCargoLoaded;
			debtData.GetTrackedDebts()[cargoDamageIndex].UpdateEndValue(cargoDmg.EffectiveHealthPercentage100Notation);
			UpdateEnvironmentDamageCargo();
			unloadedCargo = true;
		}

		public override DebtComponent[] InitializeDebtComponents()
		{
			int num = 0;
			if (carDmg != null)
			{
				carDamageIndex = num;
				num++;
			}
			if (cargoDmg != null)
			{
				cargoDamageIndex = num;
				num = (environmentDamageCargoIndex = num + 1) + 1;
			}
			DebtComponent[] array = new DebtComponent[num];
			if (carDmg != null)
			{
				array[carDamageIndex] = new DebtComponent(carDmg.EffectiveHealthPercentage100Notation, ResourceType.Car_DMG);
			}
			if (cargoDmg != null)
			{
				array[cargoDamageIndex] = new DebtComponent(cargoDmg.EffectiveHealthPercentage100Notation, ResourceType.Cargo_DMG);
				array[environmentDamageCargoIndex] = new DebtComponent(0f, ResourceType.EnvironmentDamageCargo);
			}
			return array;
		}

		public override void UpdateDebtValues()
		{
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			if (carDmg != null)
			{
				trackedDebts[carDamageIndex].UpdateEndValue(carDmg.EffectiveHealthPercentage100Notation);
			}
			if (cargoDmg != null && !unloadedCargo)
			{
				trackedDebts[cargoDamageIndex].UpdateEndValue(cargoDmg.EffectiveHealthPercentage100Notation);
				UpdateEnvironmentDamageCargo();
			}
		}

		private void UpdateEnvironmentDamageCargo()
		{
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			if (cargoDmg.currentDamageState == DamageState.Damaged || cargoDmg.currentDamageState == DamageState.Destroyed)
			{
				trackedDebts[environmentDamageCargoIndex].UpdateStartValue(trackedDebts[cargoDamageIndex].StartToEndDiff);
			}
		}

		public JObject GetDebtTrackerCarSaveData()
		{
			JObject jObject = new JObject();
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			if (carDmg != null)
			{
				DebtComponent debtComponent = trackedDebts[carDamageIndex];
				jObject.SetFloat("carStartV", debtComponent.StartValue);
				if (debtComponent.HasSnapshot)
				{
					jObject.SetFloat("carSnap", debtComponent.SnapshotValue);
				}
			}
			if (cargoDmg != null)
			{
				DebtComponent debtComponent2 = trackedDebts[cargoDamageIndex];
				jObject.SetFloat("cargoStartV", debtComponent2.StartValue);
				if (debtComponent2.HasSnapshot)
				{
					jObject.SetFloat("cargoSnap", debtComponent2.SnapshotValue);
				}
				if (unloadedCargo)
				{
					jObject.SetBool("cargoUnloaded", unloadedCargo);
					jObject.SetFloat("cargoEndV", debtComponent2.EndValue);
					jObject.SetInt("loadedCargo", (int)debtData.loadedCargoType);
				}
			}
			return jObject;
		}

		public void LoadDebtTrackerCarStateFromSaveData(JObject data)
		{
			DebtComponent[] trackedDebts = debtData.GetTrackedDebts();
			if (carDmg != null)
			{
				DebtComponent debtComponent = trackedDebts[carDamageIndex];
				float? num = data.GetFloat("carStartV");
				if (num.HasValue)
				{
					debtComponent.UpdateStartValue(num.Value);
				}
				else
				{
					Debug.LogError("Couldn't find carStartV to load!", carDmg);
				}
				float? num2 = data.GetFloat("carSnap");
				if (num2.HasValue)
				{
					debtComponent.SetSnapshot(num2.Value);
				}
			}
			if (!(cargoDmg != null))
			{
				return;
			}
			DebtComponent debtComponent2 = trackedDebts[cargoDamageIndex];
			float? num3 = data.GetFloat("cargoStartV");
			if (num3.HasValue)
			{
				debtComponent2.UpdateStartValue(num3.Value);
			}
			else
			{
				Debug.LogError("Couldn't find cargoStartV to load!", cargoDmg);
			}
			float? num4 = data.GetFloat("cargoSnap");
			if (num4.HasValue)
			{
				debtComponent2.SetSnapshot(num4.Value);
			}
			bool? flag = data.GetBool("cargoUnloaded");
			if (flag.HasValue && flag.Value)
			{
				unloadedCargo = flag.Value;
				float? num5 = data.GetFloat("cargoEndV");
				if (num5.HasValue)
				{
					debtComponent2.UpdateEndValue(num5.Value);
				}
				else
				{
					Debug.LogError("Couldn't find cargoEndV to load!", cargoDmg);
				}
				int? num6 = data.GetInt("loadedCargo");
				if (num6.HasValue && Enum.IsDefined(typeof(CargoType), num6))
				{
					debtData.UpdateLoadedCargoType((CargoType)num6.Value);
				}
			}
			UpdateEnvironmentDamageCargo();
		}
	}
}
