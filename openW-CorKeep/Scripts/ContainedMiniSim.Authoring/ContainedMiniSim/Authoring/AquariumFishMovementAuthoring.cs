using UnityEngine;

namespace ContainedMiniSim.Authoring
{
	[RequireComponent(typeof(ContainedMiniSimElementAuthoring))]
	public class AquariumFishMovementAuthoring : MonoBehaviour
	{
		public Vector2 swimSpeedMinMax;

		public Vector2 idleTimeMinMax;

		public float smoothingFactor;
	}
}
