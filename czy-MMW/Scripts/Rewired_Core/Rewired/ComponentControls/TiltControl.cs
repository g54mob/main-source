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

		[Tooltip("The tilt directions in which movement is allowed. You can restrict movement to one or both directions.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TiltDirection _allowedTiltDirections;

		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[Range(0f, 180f)]
		[SerializeField]
		private float _horizontalTiltLimit = 25f;

		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _horizontalRestAngle;

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Range(0f, 180f)]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		private float _forwardTiltLimit = 25f;

		[Range(-90f, 90f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
		private float _forwardRestAngle = 40f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
					lPvnUoojQYWvjEGVmfFKuoBuePiw(value);
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType => _axis2D.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D vfQwFuYwvBBkXBfCXQQvuAGmgxfT => _axis2D;

		private Vector3 xdoTomZJvmfeeIaPFFtXbruPEJoV
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
			Vector3 vector = xdoTomZJvmfeeIaPFFtXbruPEJoV;
			horizontalRestAngle = Mathf.Atan2(vector.x, 0f - vector.y) * 57.29578f * -1f;
			forwardRestAngle = Mathf.Atan2(vector.z, 0f - vector.y) * 57.29578f * -1f;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				nsqMedxMhfZLGrjBqThZwfKDQqGt();
			}
		}

		internal bool LBNGszjxQdPGCHZRjVjSuHsZKMlHA()
		{
			if (!base.gFHceRVuTSMIduHiFFMdoyvBSShL())
			{
				return false;
			}
			nsqMedxMhfZLGrjBqThZwfKDQqGt();
			return true;
		}

		internal void bvcvVyFPSrNmkwmAdhHfqOjFxWUf()
		{
			base.HDehBiVJQHtZseCWJjHvsFnOvLVX();
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				SKhgGkfEsnfmQMceYtgugCEeEqkw();
			}
		}

		internal void BeEExNbOofybDcLLJMBquLHoInhBA()
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && tCmDnaqSHMayjAbLSbCCIFMNrLegA)
			{
				if (_useFAxis)
				{
					TcUpHSLRYsxYwaeotAfbcWODWZmj(_forwardTiltCustomControllerElement, _axis2D.yAxis.value, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_useHAxis)
				{
					TcUpHSLRYsxYwaeotAfbcWODWZmj(_horizontalTiltCustomControllerElement, _axis2D.xAxis.value, _axis2D.xAxis.buttonActivationThreshold);
				}
			}
		}

		public override void ClearValue()
		{
			_axis2D.xAxis.Clear();
			_axis2D.yAxis.Clear();
			if (tCmDnaqSHMayjAbLSbCCIFMNrLegA)
			{
				base.TuEiudZyOALZvXpibFyWSoJvoXul.ClearElementValue(_horizontalTiltCustomControllerElement);
				base.TuEiudZyOALZvXpibFyWSoJvoXul.ClearElementValue(_forwardTiltCustomControllerElement);
			}
		}

		private void SKhgGkfEsnfmQMceYtgugCEeEqkw()
		{
			if (_useHAxis)
			{
				float rawValue;
				if (xdoTomZJvmfeeIaPFFtXbruPEJoV == Vector3.zero)
				{
					rawValue = 0f;
				}
				else
				{
					float value = Mathf.Atan2(xdoTomZJvmfeeIaPFFtXbruPEJoV.x, 0f - xdoTomZJvmfeeIaPFFtXbruPEJoV.y) * 57.29578f + _horizontalRestAngle;
					rawValue = Mathf.InverseLerp(0f - _horizontalTiltLimit, _horizontalTiltLimit, value) * 2f - 1f;
				}
				_axis2D.xAxis.SetRawValue(rawValue);
			}
			if (_useFAxis)
			{
				float num;
				if (xdoTomZJvmfeeIaPFFtXbruPEJoV == Vector3.zero)
				{
					num = 0f;
				}
				else
				{
					float value2 = Mathf.Atan2(xdoTomZJvmfeeIaPFFtXbruPEJoV.z, 0f - xdoTomZJvmfeeIaPFFtXbruPEJoV.y) * 57.29578f + _forwardRestAngle;
					num = Mathf.InverseLerp(0f - _forwardTiltLimit, _forwardTiltLimit, value2) * 2f - 1f;
				}
				_axis2D.yAxis.SetRawValue(0f - num);
			}
		}

		private void nsqMedxMhfZLGrjBqThZwfKDQqGt()
		{
			lPvnUoojQYWvjEGVmfFKuoBuePiw(_allowedTiltDirections);
			if (tCmDnaqSHMayjAbLSbCCIFMNrLegA)
			{
				if (_useHAxis)
				{
					base.TuEiudZyOALZvXpibFyWSoJvoXul.ValidateElements(_horizontalTiltCustomControllerElement);
				}
				if (_useFAxis)
				{
					base.TuEiudZyOALZvXpibFyWSoJvoXul.ValidateElements(_forwardTiltCustomControllerElement);
				}
			}
		}

		private void lPvnUoojQYWvjEGVmfFKuoBuePiw(TiltDirection P_0)
		{
			bool flag = P_0 == TiltDirection.Both || P_0 == TiltDirection.Horizontal;
			if (_useHAxis != flag)
			{
				_useHAxis = flag;
				if (!flag && tCmDnaqSHMayjAbLSbCCIFMNrLegA)
				{
					base.TuEiudZyOALZvXpibFyWSoJvoXul.ClearElementValue(_horizontalTiltCustomControllerElement);
				}
			}
			bool flag2 = P_0 == TiltDirection.Both || P_0 == TiltDirection.Forward;
			if (_useFAxis != flag2)
			{
				_useFAxis = flag2;
				if (!flag2 && tCmDnaqSHMayjAbLSbCCIFMNrLegA)
				{
					base.TuEiudZyOALZvXpibFyWSoJvoXul.ClearElementValue(_forwardTiltCustomControllerElement);
				}
			}
			_allowedTiltDirections = P_0;
		}
	}
}
