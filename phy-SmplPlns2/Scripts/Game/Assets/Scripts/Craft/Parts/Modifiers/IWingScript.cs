using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IWingScript
	{
		float LiftScale { get; }

		bool PhysicsEnabled { get; }

		float GetArea();

		Vector3 GetCentreOfLift(out float lift);

		float GetProjectedAreaMoment(Vector3 axis, out Vector3 centre);
	}
}
