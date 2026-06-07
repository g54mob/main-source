using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-limit-distance/")]
	public class ProCamera2DLimitDistance : BasePC2D, IPositionDeltaChanger
	{
		public static string ExtensionName;

		public bool UseTargetsPosition;

		public bool LimitTopCameraDistance;

		[Range(0.1f, 1f)]
		public float MaxTopTargetDistance;

		public bool LimitBottomCameraDistance;

		[Range(0.1f, 1f)]
		public float MaxBottomTargetDistance;

		public bool LimitLeftCameraDistance;

		[Range(0.1f, 1f)]
		public float MaxLeftTargetDistance;

		public bool LimitRightCameraDistance;

		[Range(0.1f, 1f)]
		public float MaxRightTargetDistance;

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
