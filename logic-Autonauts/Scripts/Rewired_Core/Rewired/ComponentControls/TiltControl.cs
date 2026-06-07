using System;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The tilt directions in which movement is allowed. You can restrict movement to one or both directions.")]
		private TiltDirection _allowedTiltDirections;

		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Range(0f, 180f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		private float _horizontalTiltLimit = 25f;

		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _horizontalRestAngle;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Range(0f, 180f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		private float _forwardTiltLimit = 25f;

		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
		[SerializeField]
		[Range(-90f, 90f)]
		[CustomObfuscation(rename = false)]
		private float _forwardRestAngle = 40f;

		[SerializeField]
		[Tooltip("The underlying 2D axis.")]
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
					WltfmBeoAglkdNsEoHeUJFYHTwoK(value);
					OnSetProperty();
				}
			}
		}

		public CustomControllerElementTargetSetForFloat horizontalTiltCustomControllerElement
		{
			get
			{
				return _horizontalTiltCustomControllerElement;
			}
		}

		public float horizontalTiltLimit
		{
			get
			{
				return _horizontalTiltLimit;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 180f);
				if (_horizontalTiltLimit == value)
				{
					goto IL_001b;
				}
				goto IL_004e;
				IL_001b:
				int num = -419872328;
				goto IL_0020;
				IL_0020:
				while (true)
				{
					switch (num ^ -419872327)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						OnSetProperty();
						num = -419872323;
						continue;
					case 0:
						goto IL_004e;
					case 1:
						return;
					case 4:
						return;
					}
					break;
				}
				goto IL_001b;
				IL_004e:
				_horizontalTiltLimit = value;
				num = -419872326;
				goto IL_0020;
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
				if (_horizontalRestAngle == value)
				{
					while (true)
					{
						switch (-1624302040 ^ -1624302039)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_horizontalRestAngle = value;
				OnSetProperty();
			}
		}

		public CustomControllerElementTargetSetForFloat forwardTiltCustomControllerElement
		{
			get
			{
				return _forwardTiltCustomControllerElement;
			}
		}

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
					OnSetProperty();
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
				if (_forwardRestAngle == value)
				{
					while (true)
					{
						switch (0x34B977C0 ^ 0x34B977C2)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_forwardRestAngle = value;
				OnSetProperty();
			}
		}

		public AxisCalibration horizontalAxisCalibration
		{
			get
			{
				return _axis2D.xAxis.calibration;
			}
		}

		public AxisCalibration verticalAxisCalibration
		{
			get
			{
				return _axis2D.yAxis.calibration;
			}
		}

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType
		{
			get
			{
				return _axis2D.calibration;
			}
		}

		public Axis2DCalibration axis2DCalibration
		{
			get
			{
				return _axis2D.calibration;
			}
		}

		internal StandaloneAxis2D axis2D
		{
			get
			{
				return _axis2D;
			}
		}

		private Vector3 acceleration
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
			Vector3 vector = acceleration;
			while (true)
			{
				int num = 900925601;
				while (true)
				{
					switch (num ^ 0x35B308A3)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						forwardRestAngle = Mathf.Atan2(vector.z, 0f - vector.y) * 57.29578f * -1f;
						return;
					}
					break;
					IL_0025:
					horizontalRestAngle = Mathf.Atan2(vector.x, 0f - vector.y) * 57.29578f * -1f;
					num = 900925602;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = 893647733;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x3543FB77)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 3:
				goto IL_0038;
			case 1:
				return;
			}
			goto IL_000e;
			IL_0038:
			fLNoWScSNkxQqcQBuFfrLEpIlgF();
			num = 893647734;
			goto IL_0013;
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			fLNoWScSNkxQqcQBuFfrLEpIlgF();
			return true;
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			while (true)
			{
				switch (0x76C9327D ^ 0x76C9327C)
				{
				case 0:
					continue;
				case 1:
					if (!base.initialized)
					{
						return;
					}
					break;
				}
				break;
			}
			DCTdrtAfYMhTYseAcpCqUcUNJNMo();
		}

		internal override void OnCustomControllerUpdate()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!hasController)
				{
					num = 1743381465;
					num2 = num;
				}
				else
				{
					num = 1743381467;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x67E9E3DD)
					{
					case 5:
						num = 1743381468;
						continue;
					default:
						return;
					case 0:
						KyhNArefdFIxsvhHWTOXrRXnSZY(_horizontalTiltCustomControllerElement, _axis2D.xAxis.value, _axis2D.xAxis.buttonActivationThreshold);
						num = 1743381470;
						continue;
					case 4:
						return;
					case 1:
						break;
					case 2:
					{
						int num3;
						if (_useHAxis)
						{
							num = 1743381469;
							num3 = num;
						}
						else
						{
							num = 1743381470;
							num3 = num;
						}
						continue;
					}
					case 6:
						if (_useFAxis)
						{
							KyhNArefdFIxsvhHWTOXrRXnSZY(_forwardTiltCustomControllerElement, _axis2D.yAxis.value, _axis2D.yAxis.buttonActivationThreshold);
							num = 1743381471;
							continue;
						}
						goto case 2;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public override void ClearValue()
		{
			_axis2D.xAxis.Clear();
			while (true)
			{
				int num = 1411427009;
				while (true)
				{
					switch (num ^ 0x5420AAC0)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						base.controller.ClearElementValue(_horizontalTiltCustomControllerElement);
						base.controller.ClearElementValue(_forwardTiltCustomControllerElement);
						num = 1411427010;
						continue;
					case 4:
					{
						int num2;
						if (hasController)
						{
							num = 1411427011;
							num2 = num;
						}
						else
						{
							num = 1411427010;
							num2 = num;
						}
						continue;
					}
					case 1:
						_axis2D.yAxis.Clear();
						num = 1411427012;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void DCTdrtAfYMhTYseAcpCqUcUNJNMo()
		{
			if (!_useHAxis)
			{
				goto IL_0065;
			}
			if (!(acceleration == Vector3.zero))
			{
				goto IL_00e0;
			}
			float rawValue = 0f;
			goto IL_0168;
			IL_0065:
			int num;
			if (_useFAxis)
			{
				int num2;
				if (acceleration == Vector3.zero)
				{
					num = 1710700466;
					num2 = num;
				}
				else
				{
					num = 1710700474;
					num2 = num;
				}
				goto IL_002d;
			}
			return;
			IL_00e0:
			float value = Mathf.Atan2(acceleration.x, 0f - acceleration.y) * 57.29578f + _horizontalRestAngle;
			num = 1710700473;
			goto IL_002d;
			IL_0168:
			_axis2D.xAxis.SetRawValue(rawValue);
			num = 1710700475;
			goto IL_002d;
			IL_002d:
			float num3 = default(float);
			float value2 = default(float);
			while (true)
			{
				switch (num ^ 0x65F737BB)
				{
				case 7:
					num = 1710700472;
					continue;
				default:
					return;
				case 0:
					break;
				case 8:
					_axis2D.yAxis.SetRawValue(0f - num3);
					num = 1710700479;
					continue;
				case 1:
					value2 = Mathf.Atan2(acceleration.z, 0f - acceleration.y) * 57.29578f + _forwardRestAngle;
					num = 1710700478;
					continue;
				case 3:
					goto IL_00e0;
				case 5:
					num3 = Mathf.InverseLerp(0f - _forwardTiltLimit, _forwardTiltLimit, value2) * 2f - 1f;
					num = 1710700467;
					continue;
				case 2:
					rawValue = Mathf.InverseLerp(0f - _horizontalTiltLimit, _horizontalTiltLimit, value) * 2f - 1f;
					num = 1710700477;
					continue;
				case 6:
					goto IL_0168;
				case 9:
					num3 = 0f;
					num = 1710700467;
					continue;
				case 4:
					return;
				}
				break;
			}
			goto IL_0065;
		}

		private void fLNoWScSNkxQqcQBuFfrLEpIlgF()
		{
			WltfmBeoAglkdNsEoHeUJFYHTwoK(_allowedTiltDirections);
			if (!hasController)
			{
				goto IL_0014;
			}
			goto IL_005b;
			IL_0014:
			int num = -251255696;
			goto IL_0019;
			IL_0019:
			switch (num ^ -251255693)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_003a;
			case 0:
				goto IL_005b;
			case 3:
				return;
			case 4:
				return;
			}
			goto IL_0014;
			IL_005b:
			if (_useHAxis)
			{
				base.controller.ValidateElements(_horizontalTiltCustomControllerElement);
				num = -251255694;
				goto IL_0019;
			}
			goto IL_003a;
			IL_003a:
			if (_useFAxis)
			{
				base.controller.ValidateElements(_forwardTiltCustomControllerElement);
				num = -251255689;
				goto IL_0019;
			}
		}

		private void WltfmBeoAglkdNsEoHeUJFYHTwoK(TiltDirection P_0)
		{
			bool flag = P_0 == TiltDirection.Both || P_0 == TiltDirection.Horizontal;
			bool flag2 = default(bool);
			while (true)
			{
				int num = 2128674953;
				while (true)
				{
					int num4;
					switch (num ^ 0x7EE10081)
					{
					case 0:
						break;
					default:
						return;
					case 7:
						if (P_0 != TiltDirection.Both)
						{
							num = 2128674948;
							continue;
						}
						num4 = 1;
						goto IL_0074;
					case 2:
					{
						_useFAxis = flag2;
						int num3;
						if (flag2)
						{
							num = 2128674952;
							num3 = num;
						}
						else
						{
							num = 2128674944;
							num3 = num;
						}
						continue;
					}
					case 5:
						num4 = ((P_0 == TiltDirection.Forward) ? 1 : 0);
						goto IL_0074;
					case 8:
						if (_useHAxis != flag)
						{
							_useHAxis = flag;
							int num5;
							if (flag)
							{
								num = 2128674950;
								num5 = num;
							}
							else
							{
								num = 2128674949;
								num5 = num;
							}
							continue;
						}
						goto case 7;
					case 4:
						if (hasController)
						{
							base.controller.ClearElementValue(_horizontalTiltCustomControllerElement);
							num = 2128674950;
							continue;
						}
						goto case 7;
					case 9:
						_allowedTiltDirections = P_0;
						num = 2128674951;
						continue;
					case 1:
						if (hasController)
						{
							base.controller.ClearElementValue(_forwardTiltCustomControllerElement);
							num = 2128674952;
							continue;
						}
						goto case 9;
					case 3:
					{
						int num2;
						if (_useFAxis != flag2)
						{
							num = 2128674947;
							num2 = num;
						}
						else
						{
							num = 2128674952;
							num2 = num;
						}
						continue;
					}
					case 6:
						return;
						IL_0074:
						flag2 = (byte)num4 != 0;
						num = 2128674946;
						continue;
					}
					break;
				}
			}
		}
	}
}
