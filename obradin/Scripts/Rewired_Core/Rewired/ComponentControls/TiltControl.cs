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

		[Tooltip("The tilt directions in which movement is allowed. You can restrict movement to one or both directions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TiltDirection _allowedTiltDirections;

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[SerializeField]
		[Range(0f, 180f)]
		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[CustomObfuscation(rename = false)]
		private float _horizontalTiltLimit = 25f;

		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(-90f, 90f)]
		private float _horizontalRestAngle;

		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Range(0f, 180f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		private float _forwardTiltLimit = 25f;

		[CustomObfuscation(rename = false)]
		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
		[Range(-90f, 90f)]
		[SerializeField]
		private float _forwardRestAngle = 40f;

		[Tooltip("The underlying 2D axis.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				if (_allowedTiltDirections == value)
				{
					return;
				}
				while (true)
				{
					nyzmpEWTMknZYhaJEGiQjqKBXpbI(value);
					int num = -54918710;
					while (true)
					{
						switch (num ^ -54918712)
						{
						case 0:
							goto IL_000a;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = -54918711;
					}
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
				if (_horizontalTiltLimit != value)
				{
					_horizontalTiltLimit = value;
					OnSetProperty();
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
				while (true)
				{
					switch (0x220F6DCF ^ 0x220F6DCD)
					{
					case 0:
						continue;
					case 2:
						if (_horizontalRestAngle == value)
						{
							return;
						}
						break;
					}
					break;
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
				if (_forwardTiltLimit == value)
				{
					return;
				}
				while (true)
				{
					_forwardTiltLimit = value;
					OnSetProperty();
					int num = -561208960;
					while (true)
					{
						switch (num ^ -561208960)
						{
						case 2:
							goto IL_001c;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_001c:
						num = -561208959;
					}
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
					OnSetProperty();
				}
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
			horizontalRestAngle = Mathf.Atan2(vector.x, 0f - vector.y) * 57.29578f * -1f;
			forwardRestAngle = Mathf.Atan2(vector.z, 0f - vector.y) * 57.29578f * -1f;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				GLLpRqMUycWVjUBpMRnWmbEUcQO();
				int num = 447090856;
				while (true)
				{
					switch (num ^ 0x1AA610A8)
					{
					case 2:
						goto IL_000f;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000f:
					num = 447090857;
				}
			}
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			GLLpRqMUycWVjUBpMRnWmbEUcQO();
			return true;
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (!base.initialized)
			{
				while (true)
				{
					switch (-1910179826 ^ -1910179825)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			kkNtqoBQUYwvhEbXKGKeVpYNbCJH();
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
				if (hasController)
				{
					num = -912548219;
					num2 = num;
				}
				else
				{
					num = -912548218;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -912548217)
					{
					case 0:
						num = -912548222;
						continue;
					default:
						return;
					case 5:
						break;
					case 1:
						return;
					case 3:
						if (_useHAxis)
						{
							jdvcKcWQnHxAXPvCkvKHWiFjvWV(_horizontalTiltCustomControllerElement, _axis2D.xAxis.value, _axis2D.xAxis.buttonActivationThreshold);
							num = -912548221;
							continue;
						}
						return;
					case 2:
						if (_useFAxis)
						{
							jdvcKcWQnHxAXPvCkvKHWiFjvWV(_forwardTiltCustomControllerElement, _axis2D.yAxis.value, _axis2D.yAxis.buttonActivationThreshold);
							num = -912548220;
							continue;
						}
						goto case 3;
					case 4:
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
				int num = 1652327500;
				while (true)
				{
					switch (num ^ 0x627C844E)
					{
					case 3:
						break;
					default:
						return;
					case 2:
						_axis2D.yAxis.Clear();
						num = 1652327503;
						continue;
					case 1:
						if (hasController)
						{
							base.controller.ClearElementValue(_horizontalTiltCustomControllerElement);
							base.controller.ClearElementValue(_forwardTiltCustomControllerElement);
							num = 1652327502;
							continue;
						}
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void kkNtqoBQUYwvhEbXKGKeVpYNbCJH()
		{
			if (_useHAxis)
			{
				if (acceleration == Vector3.zero)
				{
					goto IL_001d;
				}
				goto IL_0083;
			}
			goto IL_00f2;
			IL_0083:
			float value = Mathf.Atan2(acceleration.x, 0f - acceleration.y) * 57.29578f + _horizontalRestAngle;
			float rawValue = Mathf.InverseLerp(0f - _horizontalTiltLimit, _horizontalTiltLimit, value) * 2f - 1f;
			int num = -1747081828;
			goto IL_0022;
			IL_001d:
			num = -1747081831;
			goto IL_0022;
			IL_0022:
			float num2 = default(float);
			while (true)
			{
				switch (num ^ -1747081830)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					rawValue = 0f;
					num = -1747081826;
					continue;
				case 2:
					_axis2D.yAxis.SetRawValue(0f - num2);
					num = -1747081838;
					continue;
				case 4:
					num = -1747081828;
					continue;
				case 7:
					goto IL_0083;
				case 6:
					_axis2D.xAxis.SetRawValue(rawValue);
					num = -1747081829;
					continue;
				case 1:
					goto IL_00f2;
				case 5:
					goto IL_011c;
				case 8:
					return;
				}
				break;
			}
			goto IL_001d;
			IL_00f2:
			if (_useFAxis)
			{
				if (acceleration == Vector3.zero)
				{
					num2 = 0f;
					num = -1747081832;
					goto IL_0022;
				}
				goto IL_011c;
			}
			return;
			IL_011c:
			float value2 = Mathf.Atan2(acceleration.z, 0f - acceleration.y) * 57.29578f + _forwardRestAngle;
			num2 = Mathf.InverseLerp(0f - _forwardTiltLimit, _forwardTiltLimit, value2) * 2f - 1f;
			num = -1747081832;
			goto IL_0022;
		}

		private void GLLpRqMUycWVjUBpMRnWmbEUcQO()
		{
			nyzmpEWTMknZYhaJEGiQjqKBXpbI(_allowedTiltDirections);
			while (true)
			{
				int num = -278086057;
				while (true)
				{
					switch (num ^ -278086060)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						if (!hasController)
						{
							return;
						}
						goto case 1;
					case 4:
						if (_useFAxis)
						{
							base.controller.ValidateElements(_forwardTiltCustomControllerElement);
							num = -278086063;
							continue;
						}
						return;
					case 2:
						base.controller.ValidateElements(_horizontalTiltCustomControllerElement);
						num = -278086064;
						continue;
					case 1:
					{
						int num2;
						if (_useHAxis)
						{
							num = -278086058;
							num2 = num;
						}
						else
						{
							num = -278086064;
							num2 = num;
						}
						continue;
					}
					case 5:
						return;
					}
					break;
				}
			}
		}

		private void nyzmpEWTMknZYhaJEGiQjqKBXpbI(TiltDirection P_0)
		{
			bool flag = P_0 == TiltDirection.Both || P_0 == TiltDirection.Horizontal;
			if (_useHAxis != flag)
			{
				_useHAxis = flag;
				if (!flag && hasController)
				{
					base.controller.ClearElementValue(_horizontalTiltCustomControllerElement);
					goto IL_0040;
				}
			}
			goto IL_00cd;
			IL_00cd:
			bool flag2 = P_0 == TiltDirection.Both || P_0 == TiltDirection.Forward;
			int num = -1051796927;
			goto IL_0045;
			IL_0045:
			while (true)
			{
				switch (num ^ -1051796926)
				{
				case 0:
					break;
				case 5:
					if (hasController)
					{
						base.controller.ClearElementValue(_forwardTiltCustomControllerElement);
						num = -1051796924;
						continue;
					}
					goto default;
				case 1:
					_useFAxis = flag2;
					num = -1051796922;
					continue;
				case 4:
					goto IL_009c;
				case 3:
					goto IL_00b0;
				case 2:
					goto IL_00cd;
				default:
					_allowedTiltDirections = P_0;
					return;
				}
				break;
				IL_00b0:
				int num2;
				if (_useFAxis != flag2)
				{
					num = -1051796925;
					num2 = num;
				}
				else
				{
					num = -1051796924;
					num2 = num;
				}
				continue;
				IL_009c:
				int num3;
				if (flag2)
				{
					num = -1051796924;
					num3 = num;
				}
				else
				{
					num = -1051796921;
					num3 = num;
				}
			}
			goto IL_0040;
			IL_0040:
			num = -1051796928;
			goto IL_0045;
		}
	}
}
