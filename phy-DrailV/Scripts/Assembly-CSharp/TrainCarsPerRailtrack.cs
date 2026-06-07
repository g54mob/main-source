using System;
using System.Collections.Generic;

[Serializable]
public class TrainCarsPerRailtrack
{
	public List<TrainCar> trainCars;

	public RailTrack railTrack;

	public TrainCarsPerRailtrack(List<TrainCar> trainCars, RailTrack railTrack)
	{
		this.trainCars = trainCars;
		this.railTrack = railTrack;
	}
}
