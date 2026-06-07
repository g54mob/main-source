using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-zoom-to-fit/")]
	public class ProCamera2DZoomToFitTargets : BasePC2D, ISizeOverrider
	{
		public static string ExtensionName;

		public float ZoomOutBorder;

		public float ZoomInBorder;

		public float ZoomInSmoothness;

		public float ZoomOutSmoothness;

		public float MaxZoomInAmount;

		public float MaxZoomOutAmount;

		public bool DisableWhenOneTarget;

		public bool CompensateForCameraPosition;

		private float _zoomVelocity;

		private float _previousCamSize;

		private float _targetCamSize;

		private float _targetCamSizeSmoothed;

		private float _minCameraSize;

		private float _maxCameraSize;

		private int _soOrder;

		public int SOOrder
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

		public float OverrideSize(float deltaTime, float originalSize)
		{
			return 0f;
		}

		public override void OnReset()
		{
		}

		private void UpdateTargetCamSize()
		{
		}
	}
}
