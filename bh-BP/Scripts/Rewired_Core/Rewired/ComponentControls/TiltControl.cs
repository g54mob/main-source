using System;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Component Controls/Tilt Control")]
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

		[Tooltip("The tilt directions in which movement is allowed. You can restrict movement to one or both directions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TiltDirection _allowedTiltDirections;

		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement;

		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		private float _horizontalTiltLimit;

		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _horizontalRestAngle;

		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement;

		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		private float _forwardTiltLimit;

		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _forwardRestAngle;

		[Tooltip("The underlying 2D axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType => null;

		public Axis2DCalibration axis2DCalibration => null;

		internal StandaloneAxis2D lCNTxVzBAKpbQKYbzcywArdTlkIo => null;

		private Vector3 rZtBYBqwYjaJxFXgvRZSeNLaIQBZA => default(Vector3);

		[CustomObfuscation(rename = false)]
		internal TiltControl()
		{
		}

		public void SetAccelerationSourceCallback(Func<Vector3> callback)
		{
		}

		public void SetRestOrientation()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
		}

		internal override bool udELxkqKqBssyvTXjSbiAnMcBXWcA()
		{
			return false;
		}

		internal override void ZadSFFqddMfzbdzzllVuUFOpUuig()
		{
		}

		internal override void GNCccHkqTowQUzFFJjdyvdxeUTNB()
		{
		}

		public override void ClearValue()
		{
		}

		private void OUmClBGUPwdTRdHButPpNAnBpzJab()
		{
		}

		private void rslBhUOkYkDlJsMqECVChYnwyfhO()
		{
		}

		private void znwpuDLYtTfyqJHaQsnPQPuTtCNR(TiltDirection P_0)
		{
		}
	}
}
