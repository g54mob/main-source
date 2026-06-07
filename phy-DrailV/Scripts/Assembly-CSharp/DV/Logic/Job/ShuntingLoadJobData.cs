using System.Collections.Generic;
using DV.Booklets;
using DV.ThingTypes;

namespace DV.Logic.Job
{
	public class ShuntingLoadJobData
	{
		public readonly Job_data job;

		public readonly List<CarDataPerTrackID> startingTracksData;

		public readonly TrackID loadMachineTrack;

		public readonly TrackID destinationTrack;

		public readonly List<Car_data> allCarsToLoad;

		public readonly List<CargoType> loadingCargoTypePerCar;

		public ShuntingLoadJobData(Job_data job, List<CarDataPerTrackID> startingTracksData, TrackID loadMachineTrack, TrackID destinationTrack, List<Car_data> allCarsToLoad, List<CargoType> loadingCargoTypePerCar)
		{
			this.job = job;
			this.startingTracksData = startingTracksData;
			this.loadMachineTrack = loadMachineTrack;
			this.destinationTrack = destinationTrack;
			this.allCarsToLoad = allCarsToLoad;
			this.loadingCargoTypePerCar = loadingCargoTypePerCar;
		}
	}
}
