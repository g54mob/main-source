using Assets.Scripts.Craft;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public abstract class ExplosionBaseScript : MonoBehaviour, IExplosionScript
	{
		public abstract ExplosiveForceScript ExplosiveForce { get; }

		public abstract void Explode(float scale, Vector3? blastDirection, AircraftScript owner, Rigidbody ownerBody, Vector3? impactDirection, ExplosiveWeaponImpactType impactType);
	}
}
