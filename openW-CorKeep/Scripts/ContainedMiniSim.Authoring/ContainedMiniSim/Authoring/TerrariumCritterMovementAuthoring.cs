using UnityEngine;

namespace ContainedMiniSim.Authoring
{
	[RequireComponent(typeof(ContainedMiniSimElementAuthoring))]
	public class TerrariumCritterMovementAuthoring : MonoBehaviour
	{
		public float speed;

		public Vector2 minMaxIdleTime;
	}
}
