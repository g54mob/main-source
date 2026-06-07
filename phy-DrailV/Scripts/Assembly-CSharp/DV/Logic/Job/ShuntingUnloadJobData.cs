using System.Collections.Generic;
using DV.Booklets;
using DV.ThingTypes;

namespace DV.Logic.Job
{
	public class ShuntingUnloadJobData
	{
		public readonly Job_data job;

		public readonly TrackID startingTrack;

		public readonly TrackID unloadMachineTrack;

		public readonly List<CarDataPerTrackID> destinationTracksData;

		public readonly List<Car_data> allCarsToUnload;

		public readonly List<CargoType> unloadingCargoTypePerCar;

		public ShuntingUnloadJobData(Job_data job, TrackID startingTrack, TrackID unloadMachineTrack, List<CarDataPerTrackID> destinationTracksData, List<Car_data> allCarsToUnload, List<CargoType> unloadingCargoTypePerCar)
		{
			this.job = job;
			this.startingTrack = startingTrack;
			this.unloadMachineTrack = unloadMachineTrack;
			this.destinationTracksData = destinationTracksData;
			this.allCarsToUnload = allCarsToUnload;
			this.unloadingCargoTypePerCar = unloadingCargoTypePerCar;
		}
	}
}
