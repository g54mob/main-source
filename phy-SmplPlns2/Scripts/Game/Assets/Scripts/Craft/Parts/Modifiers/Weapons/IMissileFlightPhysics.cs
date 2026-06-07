using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public interface IMissileFlightPhysics
	{
		void OnFire(Vector3 toTarget);

		void UpdatePhysics(bool locked, Rigidbody body, MissileScript.FrameStats stats, MissileScript.FrameStats previousStats, float deltaTime);
	}
}
