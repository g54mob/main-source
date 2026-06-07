using System;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Tilt Control")]
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

		[SerializeField]
		[Tooltip("The tilt directions in which movement is allowed. You can restrict movement to one or both directions.")]
		[CustomObfuscation(rename = false)]
		private TiltDirection _allowedTiltDirections;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		[SerializeField]
		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		private float _horizontalTiltLimit = 25f;

		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		[SerializeField]
		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		private float _horizontalRestAngle;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		[SerializeField]
		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		private float _forwardTiltLimit = 25f;

		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		[SerializeField]
		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
		private float _forwardRestAngle = 40f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The underlying 2D axis.")]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		private bool _useHAxis;

		private bool _useFAxis;

		private Func<Vector3> _getAccelerationValue;

		public TiltDirection axesToUse
		{
			get
			{
				return _allowedTiltDirections;
			}
			set
			{
				if (_allowedTiltDirections != value)
				{
					LoesNjgEUrYfdvEfknfJNxZeoYen(value);
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public CustomControllerElementTargetSetForFloat horizontalTiltCustomControllerElement => _horizontalTiltCustomControllerElement;

		public float horizontalTiltLimit
		{
			get
			{
				return _horizontalTiltLimit;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 180f);
				if (_horizontalTiltLimit != value)
				{
					_horizontalTiltLimit = value;
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public float horizontalRestAngle
		{
			get
			{
				return _horizontalRestAngle;
			}
			set
			{
				value = MathTools.Clamp(value, -90f, 90f);
				if (_horizontalRestAngle != value)
				{
					_horizontalRestAngle = value;
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public CustomControllerElementTargetSetForFloat forwardTiltCustomControllerElement => _forwardTiltCustomControllerElement;

		public float forwardTiltLimit
		{
			get
			{
				return _forwardTiltLimit;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 180f);
				if (_forwardTiltLimit != value)
				{
					_forwardTiltLimit = value;
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public float forwardRestAngle
		{
			get
			{
				return _forwardRestAngle;
			}
			set
			{
				value = MathTools.Clamp(value, -90f, 90f);
				if (_forwardRestAngle != value)
				{
					_forwardRestAngle = value;
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType => _axis2D.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D JeoDAFkVAltOVqQINZSuDxwGGvnT => _axis2D;

		private Vector3 hcGyxHpsZsmKeLajFqxSgCBnILNS
		{
			get
			{
				if (_getAccelerationValue == null)
				{
					return Input.acceleration;
				}
				return _getAccelerationValue();
			}
		}

		[CustomObfuscation(rename = false)]
		internal TiltControl()
		{
		}

		public void SetAccelerationSourceCallback(Func<Vector3> callback)
		{
			_getAccelerationValue = callback;
		}

		public void SetRestOrientation()
		{
			Vector3 vector = hcGyxHpsZsmKeLajFqxSgCBnILNS;
			horizontalRestAngle = Mathf.Atan2(vector.x, 0f - vector.y) * 57.29578f * -1f;
			forwardRestAngle = Mathf.Atan2(vector.z, 0f - vector.y) * 57.29578f * -1f;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				iWYRfiiURzkAkCfnyCOuFmghZKHC();
			}
		}

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			if (!base.qrhyEDreMhRqasASvGWwEiXwPpSPA())
			{
				return false;
			}
			iWYRfiiURzkAkCfnyCOuFmghZKHC();
			return true;
		}

		internal override void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
			base.IghfPvNUXsucbZILFgzLRWwwGmUeA();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				MaGXERvYSPERGOAfcEFdkGNuXzIr();
			}
		}

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
			{
				if (_useFAxis)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_forwardTiltCustomControllerElement, _axis2D.yAxis.value, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_useHAxis)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_horizontalTiltCustomControllerElement, _axis2D.xAxis.value, _axis2D.xAxis.buttonActivationThreshold);
				}
			}
		}

		public override void ClearValue()
		{
			_axis2D.xAxis.Clear();
			_axis2D.yAxis.Clear();
			if (lQbkmKnTRMhMmINePIJrIZrbBwDnA)
			{
				base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_horizontalTiltCustomControllerElement);
				base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_forwardTiltCustomControllerElement);
			}
		}

		private void MaGXERvYSPERGOAfcEFdkGNuXzIr()
		{
			if (_useHAxis)
			{
				float rawValue;
				if (hcGyxHpsZsmKeLajFqxSgCBnILNS == Vector3.zero)
				{
					rawValue = 0f;
				}
				else
				{
					float value = Mathf.Atan2(hcGyxHpsZsmKeLajFqxSgCBnILNS.x, 0f - hcGyxHpsZsmKeLajFqxSgCBnILNS.y) * 57.29578f + _horizontalRestAngle;
					rawValue = Mathf.InverseLerp(0f - _horizontalTiltLimit, _horizontalTiltLimit, value) * 2f - 1f;
				}
				_axis2D.xAxis.SetRawValue(rawValue);
			}
			if (_useFAxis)
			{
				float num;
				if (hcGyxHpsZsmKeLajFqxSgCBnILNS == Vector3.zero)
				{
					num = 0f;
				}
				else
				{
					float value2 = Mathf.Atan2(hcGyxHpsZsmKeLajFqxSgCBnILNS.z, 0f - hcGyxHpsZsmKeLajFqxSgCBnILNS.y) * 57.29578f + _forwardRestAngle;
					num = Mathf.InverseLerp(0f - _forwardTiltLimit, _forwardTiltLimit, value2) * 2f - 1f;
				}
				_axis2D.yAxis.SetRawValue(0f - num);
			}
		}

		private void iWYRfiiURzkAkCfnyCOuFmghZKHC()
		{
			LoesNjgEUrYfdvEfknfJNxZeoYen(_allowedTiltDirections);
			if (lQbkmKnTRMhMmINePIJrIZrbBwDnA)
			{
				if (_useHAxis)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ValidateElements(_horizontalTiltCustomControllerElement);
				}
				if (_useFAxis)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ValidateElements(_forwardTiltCustomControllerElement);
				}
			}
		}

		private void LoesNjgEUrYfdvEfknfJNxZeoYen(TiltDirection P_0)
		{
			bool flag = P_0 == TiltDirection.Both || P_0 == TiltDirection.Horizontal;
			if (_useHAxis != flag)
			{
				_useHAxis = flag;
				if (!flag && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_horizontalTiltCustomControllerElement);
				}
			}
			bool flag2 = P_0 == TiltDirection.Both || P_0 == TiltDirection.Forward;
			if (_useFAxis != flag2)
			{
				_useFAxis = flag2;
				if (!flag2 && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_forwardTiltCustomControllerElement);
				}
			}
			_allowedTiltDirections = P_0;
		}
	}
}
