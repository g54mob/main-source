using System.Collections.Generic;

namespace DV.Logic.Job
{
	public class CarsPerTrack
	{
		public readonly Track track;

		public readonly List<Car> cars;

		public CarsPerTrack(Track track, List<Car> cars)
		{
			this.track = track;
			this.cars = cars;
		}
	}
}
