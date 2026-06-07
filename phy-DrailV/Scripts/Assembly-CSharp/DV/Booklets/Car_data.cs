using System;
using DV.Logic.Job;
using DV.ThingTypes;
using DV.Utils;

namespace DV.Booklets
{
	[Serializable]
	public class Car_data
	{
		public string ID;

		public TrainCarLivery type;

		public bool derailed;

		public bool isOnDestinationTrack;

		public float length;

		public float carOnlyMass;

		public float capacity;

		public Car_data(string ID, TrainCarLivery type, bool derailed, bool isOnDestinationTrack, float length, float carOnlyMass, float capacity)
		{
			this.ID = ID;
			this.type = type;
			this.derailed = derailed;
			this.isOnDestinationTrack = isOnDestinationTrack;
			this.length = length;
			this.carOnlyMass = carOnlyMass;
			this.capacity = capacity;
		}

		public Car_data(Car car, bool isOnDestinationTrack)
		{
			this.isOnDestinationTrack = isOnDestinationTrack;
			ID = car.ID;
			type = car.carType;
			length = car.length;
			carOnlyMass = car.carType.parentType.mass;
			capacity = car.capacity;
			derailed = SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.TryGetValue(car, out var value) && value.derailed;
		}
	}
}
