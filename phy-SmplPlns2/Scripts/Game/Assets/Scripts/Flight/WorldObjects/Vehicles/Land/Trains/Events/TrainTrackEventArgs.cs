using System;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Events
{
	public class TrainTrackEventArgs : EventArgs
	{
		public TrainTrackScript Track { get; }

		public string TrackId { get; }

		public TrainTrackEventArgs(string trackId, TrainTrackScript track)
		{
			TrackId = trackId;
			Track = track;
		}
	}
}
