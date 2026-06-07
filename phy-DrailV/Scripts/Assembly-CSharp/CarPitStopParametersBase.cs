using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

public abstract class CarPitStopParametersBase : MonoBehaviour
{
	protected Dictionary<ResourceType, LocoParameterData> carPitStopParameters;

	protected abstract void InitPitStopParameters();

	public Dictionary<ResourceType, LocoParameterData> GetCarPitStopParameters()
	{
		RefreshParameters();
		return carPitStopParameters;
	}

	public abstract void UpdateCarPitStopParameter(ResourceType parameter, float changeAmount);

	protected abstract void RefreshParameters();
}
