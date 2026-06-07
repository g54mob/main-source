using UnityEngine;

namespace Assets.Scripts.Flight.Missions
{
	public interface IMissionUnit
	{
		double Altitude { get; }

		float Damage { get; set; }

		bool IsDead { get; }

		bool IsSpawned { get; set; }

		Vector3 Position { get; set; }

		double SpawnRadius { get; }

		Vector3 Velocity { get; set; }

		void Destroy();

		void Spawn();
	}
}
