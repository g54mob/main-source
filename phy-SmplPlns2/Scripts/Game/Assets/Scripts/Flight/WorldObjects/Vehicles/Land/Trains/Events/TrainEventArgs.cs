using System;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Events
{
	public class TrainEventArgs : EventArgs
	{
		public TrainScript Train { get; }

		public TrainEventArgs(TrainScript train)
		{
			Train = train;
		}
	}
}
