using System.Collections.Generic;
using DV.Booklets;

namespace DV.Logic.Job
{
	public class CarDataPerTrackID
	{
		public readonly TrackID track;

		public readonly List<Car_data> cars;

		public CarDataPerTrackID(TrackID track, List<Car_data> cars)
		{
			this.track = track;
			this.cars = cars;
		}
	}
}
