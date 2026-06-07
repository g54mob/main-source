using UnityEngine;

namespace PlacementSystem
{
	[AddComponentMenu("Placement/Placement Anchor")]
	public class PlacementAnchor : MonoBehaviour
	{
		[Tooltip("Optional transform that marks the exact anchor position. If left empty the component's transform is used.")]
		[SerializeField]
		private Transform anchorTransform;

		private Transform AnchorTransform => null;

		public Vector3 GetLocalOffset(Transform root)
		{
			return default(Vector3);
		}

		public static bool TryGetAnchorLocalOffset(GameObject rootObject, out Vector3 localOffset)
		{
			localOffset = default(Vector3);
			return false;
		}
	}
}
