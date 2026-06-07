using System;
using System.Collections.Generic;

[Serializable]
public class ListTrainCarWrapper
{
	public List<TrainCar> trainCars;

	public ListTrainCarWrapper(List<TrainCar> trainCars)
	{
		this.trainCars = trainCars;
	}
}
