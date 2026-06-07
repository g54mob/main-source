using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-speed-based-zoom/")]
	public class ProCamera2DSpeedBasedZoom : BasePC2D, ISizeDeltaChanger
	{
		public static string ExtensionName;

		[Tooltip("The speed at which the camera will reach it's max zoom out.")]
		public float CamVelocityForZoomOut;

		[Tooltip("Below this speed the camera zooms in. Above this speed the camera will start zooming out.")]
		public float CamVelocityForZoomIn;

		[Tooltip("Represents how smooth the zoom in of the camera should be. The lower the number the quickest the zoom is.")]
		[Range(0f, 3f)]
		public float ZoomInSmoothness;

		[Tooltip("Represents how smooth the zoom out of the camera should be. The lower the number the quickest the zoom is.")]
		[Range(0f, 3f)]
		public float ZoomOutSmoothness;

		[Tooltip("Represents the maximum amount the camera should zoom in when the camera speed is below SpeedForZoomIn")]
		public float MaxZoomInAmount;

		[Tooltip("Represents the maximum amount the camera should zoom out when the camera speed is equal to SpeedForZoomOut")]
		public float MaxZoomOutAmount;

		private float _zoomVelocity;

		private float _initialCamSize;

		private float _previousCamSize;

		private Vector3 _previousCameraPosition;

		[HideInInspector]
		public float CurrentVelocity;

		private int _sdcOrder;

		public int SDCOrder
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

		public float AdjustSize(float deltaTime, float originalDelta)
		{
			return 0f;
		}

		public override void OnReset()
		{
		}
	}
}
