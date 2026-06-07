using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-limit-speed/")]
	public class ProCamera2DLimitSpeed : BasePC2D, IPositionDeltaChanger
	{
		public static string ExtensionName;

		public bool LimitHorizontalSpeed;

		public float MaxHorizontalSpeed;

		public bool LimitVerticalSpeed;

		public float MaxVerticalSpeed;

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
