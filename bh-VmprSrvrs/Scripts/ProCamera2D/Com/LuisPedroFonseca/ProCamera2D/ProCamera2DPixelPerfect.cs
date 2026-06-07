using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-pixel-perfect/")]
	public class ProCamera2DPixelPerfect : BasePC2D, IPositionOverrider
	{
		public static string ExtensionName;

		public float PixelsPerUnit;

		public AutoScaleMode ViewportAutoScale;

		public Vector2 TargetViewportSizeInPixels;

		[Range(1f, 32f)]
		[SerializeField]
		private int _zoom;

		public bool SnapMovementToGrid;

		public bool SnapCameraToGrid;

		public bool DrawGrid;

		public Color GridColor;

		public float GridDensity;

		private float _pixelStep;

		private Transform _parent;

		private int _poOrder;

		public int Zoom
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float ViewportScale { get; private set; }

		public float PixelStep => 0f;

		public int POOrder
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

		public Vector3 OverridePosition(float deltaTime, Vector3 originalPosition)
		{
			return default(Vector3);
		}

		public void ResizeCameraToPixelPerfect()
		{
		}

		public float CalculateViewportScale()
		{
			return 0f;
		}

		private float CalculatePixelStep(float viewportScale)
		{
			return 0f;
		}
	}
}
