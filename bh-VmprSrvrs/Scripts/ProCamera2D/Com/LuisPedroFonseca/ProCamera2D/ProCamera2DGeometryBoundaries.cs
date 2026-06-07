using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-geometry-boundaries/")]
	public class ProCamera2DGeometryBoundaries : BasePC2D, IPositionDeltaChanger
	{
		public static string ExtensionName;

		[Tooltip("The layer that contains the (3d) colliders that define the boundaries for the camera")]
		public LayerMask BoundariesLayerMask;

		public MoveInColliderBoundaries MoveInColliderBoundaries;

		private int _pdcOrder;

		public int PDCOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public Vector3 AdjustDelta(float deltaTime, Vector3 originalDelta)
		{
			return default(Vector3);
		}
	}
}
