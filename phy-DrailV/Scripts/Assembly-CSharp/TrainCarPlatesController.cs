using System;
using System.Collections.Generic;
using DV.Damage;
using DV.Localization;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

public class TrainCarPlatesController : MonoBehaviour
{
	private const string CAR_PLATES_PREFAB = "TrainCarPlate";

	private const string CAR_PLATE_ANCHOR_1 = "[car plate anchor1]";

	private const string CAR_PLATE_ANCHOR_2 = "[car plate anchor2]";

	private List<TrainCarPlate> trainCarPlates;

	private TrainCar trainCar;

	public string carIdText = string.Empty;

	public string carTypeText = string.Empty;

	public string carMassLengthText = string.Empty;

	public string cargoTypeText = string.Empty;

	private string cargoMassText = string.Empty;

	private string carHealthPercentageText = string.Empty;

	private string cargoHealthPercentageText = string.Empty;

	private string jobIdText = string.Empty;

	public string vehicleCargoText = string.Empty;

	public string healthPercentagesText = string.Empty;

	public string cargoMassJobIdText = string.Empty;

	private string VEHICLE => LocalizationAPI.L("car/plate_vehicle");

	private string CARGO => LocalizationAPI.L("car/plate_cargo");

	public event Action<TrainCarPlatesController> ValueChanged;

	public void CreateTrainCarPlates(TrainCar trainCar, CarDamageModel carDmg, CargoDamageModel cargoDmg, bool isLoco, float length, float mass)
	{
		this.trainCar = trainCar;
		trainCarPlates = new List<TrainCarPlate>();
		SpawnCarPlate("[car plate anchor1]");
		SpawnCarPlate("[car plate anchor2]");
		if (trainCarPlates.Count == 0)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		carIdText = string.Empty;
		carTypeText = LocalizationAPI.L(trainCar.carLivery.parentType.localizationKey);
		string text = Mathf.RoundToInt(mass) + "kg";
		string text2 = $"{length:0.#}m";
		carMassLengthText = text + text2.PadLeft(23 - text.Length);
		foreach (TrainCarPlate trainCarPlate in trainCarPlates)
		{
			trainCarPlate.carId.text = carIdText;
			trainCarPlate.carType.text = carTypeText;
			trainCarPlate.carMassLength.text = carMassLengthText;
		}
		jobIdText = string.Empty;
		UpdateCargoData();
		trainCar.CargoLoaded += UpdateCargoData;
		trainCar.CargoUnloaded += UpdateCargoData;
		if (carDmg != null)
		{
			UpdateCarHealthData(carDmg.EffectiveHealthPercentage100Notation);
			carDmg.CarEffectiveHealthStateUpdate += UpdateCarHealthData;
		}
		else
		{
			UpdateCarHealthData(100f);
		}
		if (cargoDmg != null)
		{
			UpdateCargoHealthData(cargoDmg.EffectiveHealthPercentage100Notation);
			cargoDmg.CargoEffectiveHealthStateUpdate += UpdateCargoHealthData;
		}
		else
		{
			UpdateCargoHealthData(100f);
		}
		void SpawnCarPlate(string carPlateAnchorString)
		{
			Transform transform = base.transform.Find(carPlateAnchorString);
			if (transform != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("TrainCarPlate", typeof(GameObject)) as GameObject, transform, worldPositionStays: false);
				TrainCarPlate component = gameObject.GetComponent<TrainCarPlate>();
				if (component == null)
				{
					Debug.LogError("Unexpected state: Missing TrainCarPlate on TrainCarPlate prefab. Ignoring setup for this plate", gameObject);
				}
				else
				{
					trainCarPlates.Add(component);
				}
			}
			else
			{
				Debug.LogWarning("Anchor " + carPlateAnchorString + " is missing from " + base.gameObject.name + ", train car plate will not be created for this anchor!", this);
			}
		}
	}

	public void OverrideId(string id)
	{
		carIdText = id;
		this.ValueChanged?.Invoke(this);
		foreach (TrainCarPlate trainCarPlate in trainCarPlates)
		{
			trainCarPlate.carId.text = id;
		}
	}

	public void UpdateJobIdData(string jobId)
	{
		jobIdText = jobId;
		RefreshDerivedCargoJobData();
	}

	private void UpdateCargoData(CargoType _)
	{
		UpdateCargoData();
	}

	private void UpdateCargoData()
	{
		CargoType cargoType = ((trainCar.logicCar != null) ? trainCar.LoadedCargo : CargoType.None);
		float cargoMass = trainCar.massController.CargoMass;
		if (cargoType != CargoType.None)
		{
			cargoTypeText = LocalizationAPI.L(cargoType.ToV2().localizationKeyShort);
			cargoMassText = Mathf.RoundToInt(cargoMass) + "kg";
		}
		else
		{
			cargoTypeText = string.Empty;
			cargoMassText = string.Empty;
		}
		RefreshDerivedCargoJobData();
	}

	private void RefreshDerivedCargoJobData()
	{
		cargoMassJobIdText = cargoMassText + jobIdText.PadLeft(25 - cargoMassText.Length);
		this.ValueChanged?.Invoke(this);
		foreach (TrainCarPlate trainCarPlate in trainCarPlates)
		{
			trainCarPlate.cargoType.text = cargoTypeText;
			trainCarPlate.cargoMassJobId.text = cargoMassJobIdText;
		}
	}

	private void UpdateCarHealthData(float carHealthPercentage)
	{
		carHealthPercentageText = FormatPercentage(carHealthPercentage);
		RefreshDerivedHealthData();
	}

	private void UpdateCargoHealthData(float cargoHealthPercentage)
	{
		bool flag = trainCar.logicCar != null && trainCar.LoadedCargo != CargoType.None;
		cargoHealthPercentageText = ((!flag) ? string.Empty : FormatPercentage(cargoHealthPercentage));
		RefreshDerivedHealthData();
	}

	private void RefreshDerivedHealthData()
	{
		vehicleCargoText = (string.IsNullOrEmpty(cargoHealthPercentageText) ? VEHICLE : (VEHICLE + "\n" + CARGO));
		healthPercentagesText = carHealthPercentageText + "\n" + cargoHealthPercentageText;
		this.ValueChanged?.Invoke(this);
		foreach (TrainCarPlate trainCarPlate in trainCarPlates)
		{
			trainCarPlate.vehicleCargo.text = vehicleCargoText;
			trainCarPlate.healthPercentages.text = healthPercentagesText;
		}
	}

	private static string FormatPercentage(float value)
	{
		if (!(Mathf.Abs(value) >= 10f))
		{
			return $"{value:0.##}%";
		}
		return $"{value:0.#}%";
	}
}
