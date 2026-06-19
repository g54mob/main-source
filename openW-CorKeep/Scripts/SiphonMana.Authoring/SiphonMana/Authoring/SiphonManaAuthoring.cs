using UnityEngine;

namespace SiphonMana.Authoring
{
	[RequireComponent(typeof(NearbyEntitiesTrackerAuthoring))]
	public class SiphonManaAuthoring : MonoBehaviour
	{
		[Range(0f, 1f)]
		public float maxManaSiphonedPerSecond;

		public float manaSiphonCooldownSeconds;

		public float maxTransferDistance;

		public float siphonRadius;
	}
}
