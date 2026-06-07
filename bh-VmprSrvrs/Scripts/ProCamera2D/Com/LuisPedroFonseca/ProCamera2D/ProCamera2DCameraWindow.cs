using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-camera-window/")]
	public class ProCamera2DCameraWindow : BasePC2D, IPositionDeltaChanger
	{
		public static string ExtensionName;

		public Rect CameraWindowRect;

		private Rect _cameraWindowRectInWorldCoords;

		public bool IsRelativeSizeAndPosition;

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

		private Rect GetRectAroundTransf(Rect rectNormalized, Vector2 rectSize, Transform transf, bool isRelative)
		{
			return default(Rect);
		}
	}
}
