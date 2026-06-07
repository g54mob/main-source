using System.Collections.Generic;
using DV.Booklets;

namespace DV.Logic.Job
{
	public class EmptyHaulJobData
	{
		public readonly Job_data job;

		public readonly TrackID startingTrack;

		public readonly TrackID destinationTrack;

		public readonly List<Car_data> transportingCars;

		public EmptyHaulJobData(Job_data job, TrackID startingTrack, TrackID destinationTrack, List<Car_data> transportingCars)
		{
			this.job = job;
			this.startingTrack = startingTrack;
			this.destinationTrack = destinationTrack;
			this.transportingCars = transportingCars;
		}
	}
}
