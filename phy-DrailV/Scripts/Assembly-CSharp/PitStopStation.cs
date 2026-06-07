using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

public class PitStopStation : MonoBehaviour
{
	public PitStop pitstop;

	public PitStopIndicators locoResourceModules;

	private Dictionary<ResourceType, LocoParameterData> latestCarParamsReport;

	private void OnEnable()
	{
		SetupListeners(set: true);
	}

	private void OnDisable()
	{
		SetupListeners(set: false);
	}

	private void SetupListeners(bool set)
	{
		if (set)
		{
			LocoResourceModule[] resourceModules = locoResourceModules.resourceModules;
			foreach (LocoResourceModule obj in resourceModules)
			{
				obj.OnResourceBought += UpdateParameter;
				obj.ConnectTo(this);
			}
			pitstop.CarExited += OnCarPitStopExit;
			pitstop.CarEntered += OnCarPitStopEnter;
			pitstop.CarSelected += OnCarPitStopSelected;
		}
		else
		{
			LocoResourceModule[] resourceModules = locoResourceModules.resourceModules;
			foreach (LocoResourceModule obj2 in resourceModules)
			{
				obj2.OnResourceBought -= UpdateParameter;
				obj2.ConnectTo(null);
			}
			pitstop.CarExited -= OnCarPitStopExit;
			pitstop.CarEntered -= OnCarPitStopEnter;
			pitstop.CarSelected -= OnCarPitStopSelected;
		}
	}

	private void Update()
	{
		if (pitstop.IsCarInPitStop())
		{
			DisplayLatestCarParamsReport(initialize: false);
		}
	}

	public void DisplayLatestCarParamsReport(bool initialize)
	{
		latestCarParamsReport = pitstop.GetCarParameters().GetCarPitStopParameters();
		if (latestCarParamsReport == null)
		{
			Debug.LogWarning("latestCarParamsReport not generated, can't display its values.", base.gameObject);
		}
		else
		{
			locoResourceModules.UpdateResourceModules(latestCarParamsReport, initialize);
		}
	}

	public void UpdateParameter(CarPitStopParametersBase car, ResourceType param, float changeAmount)
	{
		if (!pitstop.IsCarInPitStop())
		{
			Debug.LogWarning("No car in pit stop, can't update car parameter", pitstop.gameObject);
			return;
		}
		Dictionary<ResourceType, LocoParameterData> carPitStopParameters = car.GetCarPitStopParameters();
		if (carPitStopParameters == null || !carPitStopParameters.ContainsKey(param))
		{
			Debug.LogWarning("carPitStopParams are null or you are trying to update parameter that does not exist in this car " + car.gameObject.name + ".", car.gameObject);
			return;
		}
		car.UpdateCarPitStopParameter(param, changeAmount);
		DisplayLatestCarParamsReport(initialize: false);
	}

	public void RefillAll()
	{
		if (!pitstop.IsCarInPitStop() || latestCarParamsReport == null)
		{
			Debug.LogWarning("No car in pit stop or no latestCarParamsReport generated, car was not refilled.", pitstop);
			return;
		}
		ResourceType[] consumableResources = ResourceTypes.ConsumableResources;
		for (int i = 0; i < consumableResources.Length; i++)
		{
			ResourceType resourceType = consumableResources[i];
			if (latestCarParamsReport.ContainsKey(resourceType))
			{
				float num = latestCarParamsReport[resourceType].maxValue - latestCarParamsReport[resourceType].value;
				UpdateParameter(pitstop.GetCarParameters(), resourceType, num);
				Debug.Log("Refilled param: " + resourceType.ToString() + " for " + num);
			}
		}
	}

	public void RepairAll()
	{
		if (!pitstop.IsCarInPitStop() || latestCarParamsReport == null)
		{
			Debug.LogWarning("No car in pit stop or no latestCarParamsReport generated, car was not repaired.", pitstop);
			return;
		}
		ResourceType[] damageableResources = ResourceTypes.DamageableResources;
		for (int i = 0; i < damageableResources.Length; i++)
		{
			ResourceType resourceType = damageableResources[i];
			if (latestCarParamsReport.ContainsKey(resourceType))
			{
				float num = latestCarParamsReport[resourceType].maxValue - latestCarParamsReport[resourceType].value;
				UpdateParameter(pitstop.GetCarParameters(), resourceType, num);
				Debug.Log("Repaired param: " + resourceType.ToString() + " for " + num);
			}
		}
	}

	private void OnCarPitStopExit()
	{
		latestCarParamsReport = null;
		locoResourceModules.ResetResourceModuleState();
		locoResourceModules.ClearPricesThatDependOnLocoType(null);
	}

	private void OnCarPitStopEnter()
	{
		if (!pitstop.IsCarInPitStop())
		{
			Debug.LogWarning("No car in pit stop.", pitstop);
		}
		else
		{
			OnCarPitStopSelected();
		}
	}

	private void OnCarPitStopSelected()
	{
		locoResourceModules.UpdatePricesDependingOnLocoType(pitstop.SelectedCar, pitstop.SelectedCar.carLivery);
		locoResourceModules.UpdateIndependentPrices(pitstop.SelectedCar);
		DisplayLatestCarParamsReport(initialize: false);
	}
}
