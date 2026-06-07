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
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TiltDirection _allowedTiltDirections;

		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		private float _horizontalTiltLimit = 25f;

		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _horizontalRestAngle;

		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		private float _forwardTiltLimit = 25f;

		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _forwardRestAngle = 40f;

		[Tooltip("The underlying 2D axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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
					ptwceihhPsfioSCYMgAHSvrzzgAi(value);
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType => _axis2D.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D zIFhWkFkyzgMONHcplKcWwmlNaJG => _axis2D;

		private Vector3 tZbaYaIPmGTEtMNEtPAILlQCBfEaA
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
			Vector3 vector = tZbaYaIPmGTEtMNEtPAILlQCBfEaA;
			horizontalRestAngle = Mathf.Atan2(vector.x, 0f - vector.y) * 57.29578f * -1f;
			forwardRestAngle = Mathf.Atan2(vector.z, 0f - vector.y) * 57.29578f * -1f;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				fYjajfigaJlkFAfIKMKOGOwEmSuZ();
			}
		}

		internal bool XvONvdkJRPqvZHlGHHGLtaOSumHO()
		{
			if (!base.kQSdBYbKoLxckNhngUuODXUumNm())
			{
				return false;
			}
			fYjajfigaJlkFAfIKMKOGOwEmSuZ();
			return true;
		}

		internal void fYxwiaUPZTgzUeBjZGaVGXbSFdcD()
		{
			base.XadwAoSmPfgqpkILfIkgfANXfddcb();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				IHstUqchnLAUHMEtyASbULkzDOWp();
			}
		}

		internal void NXBlyJaCnZKOSuLSdFqtGSbdZRRx()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && fWzcsqpjMiHugIFEsnxLnuyMnmGF)
			{
				if (_useFAxis)
				{
					BBGcGGKBcUWfsejCFzcKGieWiGAc(_forwardTiltCustomControllerElement, _axis2D.yAxis.value, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_useHAxis)
				{
					BBGcGGKBcUWfsejCFzcKGieWiGAc(_horizontalTiltCustomControllerElement, _axis2D.xAxis.value, _axis2D.xAxis.buttonActivationThreshold);
				}
			}
		}

		public override void ClearValue()
		{
			_axis2D.xAxis.Clear();
			_axis2D.yAxis.Clear();
			if (fWzcsqpjMiHugIFEsnxLnuyMnmGF)
			{
				base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_horizontalTiltCustomControllerElement);
				base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_forwardTiltCustomControllerElement);
			}
		}

		private void IHstUqchnLAUHMEtyASbULkzDOWp()
		{
			if (_useHAxis)
			{
				float rawValue;
				if (tZbaYaIPmGTEtMNEtPAILlQCBfEaA == Vector3.zero)
				{
					rawValue = 0f;
				}
				else
				{
					float value = Mathf.Atan2(tZbaYaIPmGTEtMNEtPAILlQCBfEaA.x, 0f - tZbaYaIPmGTEtMNEtPAILlQCBfEaA.y) * 57.29578f + _horizontalRestAngle;
					rawValue = Mathf.InverseLerp(0f - _horizontalTiltLimit, _horizontalTiltLimit, value) * 2f - 1f;
				}
				_axis2D.xAxis.SetRawValue(rawValue);
			}
			if (_useFAxis)
			{
				float num;
				if (tZbaYaIPmGTEtMNEtPAILlQCBfEaA == Vector3.zero)
				{
					num = 0f;
				}
				else
				{
					float value2 = Mathf.Atan2(tZbaYaIPmGTEtMNEtPAILlQCBfEaA.z, 0f - tZbaYaIPmGTEtMNEtPAILlQCBfEaA.y) * 57.29578f + _forwardRestAngle;
					num = Mathf.InverseLerp(0f - _forwardTiltLimit, _forwardTiltLimit, value2) * 2f - 1f;
				}
				_axis2D.yAxis.SetRawValue(0f - num);
			}
		}

		private void fYjajfigaJlkFAfIKMKOGOwEmSuZ()
		{
			ptwceihhPsfioSCYMgAHSvrzzgAi(_allowedTiltDirections);
			if (fWzcsqpjMiHugIFEsnxLnuyMnmGF)
			{
				if (_useHAxis)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ValidateElements(_horizontalTiltCustomControllerElement);
				}
				if (_useFAxis)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ValidateElements(_forwardTiltCustomControllerElement);
				}
			}
		}

		private void ptwceihhPsfioSCYMgAHSvrzzgAi(TiltDirection P_0)
		{
			bool flag = P_0 == TiltDirection.Both || P_0 == TiltDirection.Horizontal;
			if (_useHAxis != flag)
			{
				_useHAxis = flag;
				if (!flag && fWzcsqpjMiHugIFEsnxLnuyMnmGF)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_horizontalTiltCustomControllerElement);
				}
			}
			bool flag2 = P_0 == TiltDirection.Both || P_0 == TiltDirection.Forward;
			if (_useFAxis != flag2)
			{
				_useFAxis = flag2;
				if (!flag2 && fWzcsqpjMiHugIFEsnxLnuyMnmGF)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_forwardTiltCustomControllerElement);
				}
			}
			_allowedTiltDirections = P_0;
		}
	}
}
