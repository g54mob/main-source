using System;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public interface INetworkedArea
	{
		bool IsFlightObjectLoaded { get; }

		bool IsOwner { get; }

		event Action<NetworkFlightObject> FlightObjectLoaded;

		event Action<NetworkFlightObject> FlightObjectUnloaded;

		event Action<bool> OwnershipChanged;
	}
}
