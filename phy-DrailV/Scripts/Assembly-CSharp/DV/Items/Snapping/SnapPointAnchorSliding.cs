using UnityEngine;

namespace DV.Items.Snapping
{
	public class SnapPointAnchorSliding : SnapPointAnchor
	{
		[SerializeField]
		private Vector2 slidingOffsetRange;

		public Vector2 SlidingOffsetRange => slidingOffsetRange;

		public Vector3 InitialLocalPosition { get; private set; }

		private void Awake()
		{
			InitialLocalPosition = base.transform.localPosition;
		}

		public void Reset()
		{
			base.transform.localPosition = InitialLocalPosition;
		}
	}
}
