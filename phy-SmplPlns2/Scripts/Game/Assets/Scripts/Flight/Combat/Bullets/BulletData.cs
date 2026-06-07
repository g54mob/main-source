using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Bullets
{
	public class BulletData
	{
		public Color Color { get; set; }

		public float Damage { get; set; }

		public bool DisableOwnerCollisions { get; set; }

		public float ImpactForce { get; set; }

		public float Lifetime { get; set; }

		public AircraftScript Owner { get; private set; }

		public bool RemoteBullet { get; }

		public Vector3 Scale { get; set; }

		public BulletData()
		{
			Color = GunData.DefaultTracerColor;
			Damage = 30f;
			DisableOwnerCollisions = false;
			ImpactForce = 10f;
			Lifetime = 3f;
			Owner = null;
			Scale = Vector3.one;
		}

		public BulletData(AircraftScript owner, bool disableOwnerCollisions, float lifetime, Color color, Vector3 scale, float damage, float impactForce)
		{
			Color = color;
			Damage = damage;
			DisableOwnerCollisions = disableOwnerCollisions;
			ImpactForce = impactForce;
			Lifetime = lifetime;
			Owner = owner;
			Scale = scale;
			RemoteBullet = Owner?.RemoteAircraft ?? false;
		}
	}
}
