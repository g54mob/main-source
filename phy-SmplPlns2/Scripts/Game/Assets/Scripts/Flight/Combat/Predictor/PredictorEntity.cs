using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Predictor
{
	public abstract class PredictorEntity
	{
		public float _unityDrag;

		public float Mass { get; set; }

		public Vector3 Position { get; set; }

		public float SimTime { get; set; }

		public Vector3 Velocity { get; set; }

		public void AddForce(Vector3 force, float deltaTime, ForceMode forceMode = ForceMode.Force)
		{
			switch (forceMode)
			{
			case ForceMode.Force:
				Velocity += force / Mass * deltaTime;
				break;
			case ForceMode.Impulse:
				Velocity += force / Mass;
				break;
			default:
				Debug.LogError("Force mode " + forceMode.ToString() + " not supported");
				break;
			}
		}

		public virtual void FixedUpdate(float deltaTime)
		{
			if (_unityDrag != 0f)
			{
				Velocity *= 1f - _unityDrag * deltaTime;
			}
			Velocity += Physics.gravity * deltaTime;
			Position += Velocity * deltaTime;
			SimTime += deltaTime;
		}

		public virtual void ResetSim(PartModifierScript weapon)
		{
			IRigidBody rigidBody = weapon.PartScript.Body.RigidBody;
			Position = weapon.transform.position;
			Velocity = rigidBody.velocity;
			Mass = rigidBody.mass;
			SimTime = 0f;
		}
	}
}
