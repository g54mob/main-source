using UnityEngine;

namespace Assets.Scripts.Flight.Missions
{
	public class MissionUnit : IMissionUnit
	{
		public virtual double Altitude => Position.y;

		public virtual float Damage { get; set; }

		public virtual bool IsDead { get; }

		public virtual bool IsSpawned { get; set; }

		public virtual Vector3 Position { get; set; }

		public double SpawnRadius { get; set; }

		public virtual Vector3 Velocity { get; set; }

		public virtual void Destroy()
		{
		}

		public virtual void Spawn()
		{
			IsSpawned = true;
		}
	}
}
