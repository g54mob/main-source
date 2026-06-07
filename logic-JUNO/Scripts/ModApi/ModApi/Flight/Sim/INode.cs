using ModApi.Flight.GameView;
using UnityEngine;

namespace ModApi.Flight.Sim
{
	public interface INode
	{
		float GameViewLoadDistance { get; }

		IGameViewObject GameViewObject { get; }

		bool IsDestroyed { get; }

		IPlanetNode Parent { get; set; }

		Vector3d Position { get; }

		Vector3d SolarPosition { get; }

		event NodeDelegate Destroyed;

		void FlightEnd();

		void FlightLateUpdate(double elapsedTime);

		void FlightStart();

		void FlightUpdate(double elapsedTime, double currentTime);

		void Initialize();

		void SynchronizeData();
	}
}
