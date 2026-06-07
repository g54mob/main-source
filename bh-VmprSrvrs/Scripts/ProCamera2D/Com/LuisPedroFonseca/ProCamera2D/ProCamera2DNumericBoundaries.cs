using System;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-numeric-boundaries/")]
	public class ProCamera2DNumericBoundaries : BasePC2D, IPositionDeltaChanger, ISizeOverrider
	{
		public static string ExtensionName;

		public Action OnBoundariesTransitionStarted;

		public Action OnBoundariesTransitionFinished;

		public bool UseNumericBoundaries;

		public bool UseTopBoundary;

		public float TopBoundary;

		public float TargetTopBoundary;

		public bool UseBottomBoundary;

		public float BottomBoundary;

		public float TargetBottomBoundary;

		public bool UseLeftBoundary;

		public float LeftBoundary;

		public float TargetLeftBoundary;

		public bool UseRightBoundary;

		public float RightBoundary;

		public float TargetRightBoundary;

		public bool IsCameraPositionHorizontallyBounded;

		public bool IsCameraPositionVerticallyBounded;

		public Coroutine TopBoundaryAnimRoutine;

		public Coroutine BottomBoundaryAnimRoutine;

		public Coroutine LeftBoundaryAnimRoutine;

		public Coroutine RightBoundaryAnimRoutine;

		public ProCamera2DTriggerBoundaries CurrentBoundariesTrigger;

		public Coroutine MoveCameraToTargetRoutine;

		public bool HasFiredTransitionStarted;

		public bool HasFiredTransitionFinished;

		public bool UseSoftBoundaries;

		[Range(0f, 4f)]
		public float Softness;

		[Range(0f, 0.5f)]
		public float SoftAreaSize;

		private float _smoothnessVelX;

		private float _smoothnessVelY;

		private int _pdcOrder;

		private int _soOrder;

		public NumericBoundariesSettings Settings
		{
			get
			{
				return default(NumericBoundariesSettings);
			}
			set
			{
			}
		}

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

		public Vector3 AdjustDelta(float deltaTime, Vector3 originalDelta)
		{
			return default(Vector3);
		}

		public float OverrideSize(float deltaTime, float originalSize)
		{
			return 0f;
		}
	}
}
