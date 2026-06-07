using Assets.Scripts.Craft;
using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public interface IExplosionScript
	{
		void Explode(float scale, Vector3? blastDirection, AircraftScript owner, Rigidbody ownerBody, Vector3? impactDirection, ExplosiveWeaponImpactType impactType);
	}
}
