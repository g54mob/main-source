using System;

namespace Assets.Scripts.Flight.Events
{
	public class MapLocationChangedEventArgs : EventArgs
	{
		public string LocationDisplayName { get; }

		public string LocationId { get; }

		public MapLocationChangedEventArgs(string locationId, string locationDisplayName)
		{
			LocationId = locationId;
			LocationDisplayName = locationDisplayName;
		}
	}
}
