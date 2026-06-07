using System.Collections.Generic;
using DV.Booklets;
using DV.ThingTypes;

namespace DV.Logic.Job
{
	public class TransportJobData
	{
		public readonly Job_data job;

		public readonly TrackID startingTrack;

		public readonly TrackID destinationTrack;

		public readonly List<Car_data> transportingCars;

		public readonly List<CargoType> transportedCargoPerCar;

		public TransportJobData(Job_data job, TrackID startingTrack, TrackID destinationTrack, List<Car_data> transportingCars, List<CargoType> transportedCargoPerCar)
		{
			this.job = job;
			this.startingTrack = startingTrack;
			this.destinationTrack = destinationTrack;
			this.transportingCars = transportingCars;
			this.transportedCargoPerCar = transportedCargoPerCar;
		}
	}
}
