using System.Collections.Generic;
using DV.Logic.Job;
using DV.Utils;

public class TrainCarRegistry : SingletonBehaviour<TrainCarRegistry>
{
	public Dictionary<Car, TrainCar> logicCarToTrainCar = new Dictionary<Car, TrainCar>();

	public new static string AllowAutoCreate()
	{
		return "[TrainCarRegistry]";
	}

	public TrainCar GetTrainCarByCarGuid(string carGuid)
	{
		if (SingletonBehaviour<IdGenerator>.Instance.carGuidToCar.TryGetValue(carGuid, out var value) && logicCarToTrainCar.TryGetValue(value, out var value2))
		{
			return value2;
		}
		return null;
	}
}
