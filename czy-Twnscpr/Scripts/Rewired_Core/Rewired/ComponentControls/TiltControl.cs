using System;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public sealed class TiltControl : CustomControllerControl
	{
		public enum TiltDirection
		{
			Both = 0,
			Horizontal = 1,
			Forward = 2
		}

		private const float maxFullTiltAngle = 180f;

		private const float maxAngleOffset = 90f;

		[CustomObfuscation]
		[SerializeField]
		private TiltDirection _allowedTiltDirections;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private float _horizontalTiltLimit;

		[CustomObfuscation]
		[SerializeField]
		private float _horizontalRestAngle;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private float _forwardTiltLimit;

		[CustomObfuscation]
		[SerializeField]
		private float _forwardRestAngle;

		[CustomObfuscation]
		[SerializeField]
		private StandaloneAxis2D _axis2D;

		private bool _useHAxis;

		private bool _useFAxis;

		private Func<Vector3> _getAccelerationValue;

		public TiltDirection axesToUse
		{
			get
			{
				return default(TiltDirection);
			}
			set
			{
			}
		}

		public CustomControllerElementTargetSetForFloat horizontalTiltCustomControllerElement => null;

		public float horizontalTiltLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float horizontalRestAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public CustomControllerElementTargetSetForFloat forwardTiltCustomControllerElement => null;

		public float forwardTiltLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float forwardRestAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AxisCalibration horizontalAxisCalibration => null;

		public AxisCalibration verticalAxisCalibration => null;

		[Obsolete]
		public Axis2DCalibration deadZoneType => null;

		public Axis2DCalibration axis2DCalibration => null;

		internal StandaloneAxis2D axis2D => null;

		private Vector3 acceleration => default(Vector3);

		[CustomObfuscation]
		internal TiltControl()
		{
		}

		public void SetAccelerationSourceCallback(Func<Vector3> callback)
		{
		}

		public void SetRestOrientation()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		internal override bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		internal override void PSFeJyfveNnRLRnWPckAdcFQFXH()
		{
		}

		internal override void ttJAqkHGCfTssfJpreeBeSfOQEJn()
		{
		}

		public override void ClearValue()
		{
		}

		private void LqhjWdLooFJhoSLVzWXKCIPECTH()
		{
		}

		private void zfdkmUIlklArKSUJvJtBjcuRaiO()
		{
		}

		private void SQHoHRQkTbaBPrHFpatgdFHUpqd(TiltDirection P_0)
		{
		}
	}
}
