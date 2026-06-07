using System;
using System.Collections.Generic;
using DV.ThingTypes;

[Serializable]
public class TrainCarsPerCargoType
{
	public List<TrainCar> trainCars;

	public CargoType cargoType;

	public float totalCargoAmount;

	public TrainCarsPerCargoType(List<TrainCar> trainCars, CargoType cargoType, float totalCargoAmount)
	{
		this.trainCars = trainCars;
		this.cargoType = cargoType;
		this.totalCargoAmount = totalCargoAmount;
	}
}
