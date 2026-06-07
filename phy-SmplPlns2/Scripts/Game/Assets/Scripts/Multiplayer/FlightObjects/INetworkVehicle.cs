using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public interface INetworkVehicle
	{
		bool IsOwner { get; }

		bool IsReversePath { get; }

		Transform Transform { get; }

		void Despawn();
	}
}
