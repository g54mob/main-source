using System;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[AddComponentMenu("Rewired/Tilt Control")]
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
		[Tooltip("The tilt directions in which movement is allowed. You can restrict movement to one or both directions.")]
		[SerializeField]
		private TiltDirection _allowedTiltDirections;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from the X axis.")]
		private CustomControllerElementTargetSetForFloat _horizontalTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The maximum horizontal tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[Range(0f, 180f)]
		private float _horizontalTiltLimit = 25f;

		[Range(-90f, 90f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The offset angle from horizontal which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt.")]
		[SerializeField]
		private float _horizontalRestAngle;

		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from the Y axis.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _forwardTiltCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The maximum forward tilt angle in degrees. When the device is tilted to this angle or further in either direction, the axis will return a value of 1/-1.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 180f)]
		private float _forwardTiltLimit = 25f;

		[Range(-90f, 90f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The offset angle from vertical which will be considered the resting angle. This represents the angle at which the user holds the device without generating tilt. A typical value would be around 40 degrees.")]
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
					while (true)
					{
						switch (-1790578598 ^ -1790578600)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				hHbXGUYunkblaqblvHADFikMHzF(value);
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					int num = -1732351293;
					while (true)
					{
						switch (num ^ -1732351294)
						{
						case 4:
							break;
						default:
							return;
						case 3:
							_horizontalRestAngle = value;
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = -1732351294;
							continue;
						case 2:
							return;
						case 1:
						{
							int num2;
							if (_horizontalRestAngle == value)
							{
								num = -1732351296;
								num2 = num;
							}
							else
							{
								num = -1732351295;
								num2 = num;
							}
							continue;
						}
						case 0:
							return;
						}
						break;
					}
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType => _axis2D.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D axis2D => _axis2D;

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
				SSNbZVHYzyYyvTvbhmvcDWPTqqs();
				int num = 482276233;
				while (true)
				{
					switch (num ^ 0x1CBEF388)
					{
					case 0:
						goto IL_000f;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000f:
					num = 482276234;
				}
			}
		}

		internal override bool KeoQNyZvcuilfnGKgmHgqyJYGhr()
		{
			if (!base.KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				return false;
			}
			SSNbZVHYzyYyvTvbhmvcDWPTqqs();
			return true;
		}

		internal override void spiCZIbBixHwkYmPEBFXAXTGsXtO()
		{
			base.spiCZIbBixHwkYmPEBFXAXTGsXtO();
			while (true)
			{
				switch (-2136134979 ^ -2136134980)
				{
				case 2:
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
			eVPSloHveSYDZVHdjbizubeMkQp();
		}

		internal override void KhATpHHLaxfVykPnYPwsOWKYpr()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0041;
			IL_0008:
			int num = 794105796;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x2F5517C0)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					return;
				case 1:
					goto IL_0041;
				case 6:
					if (_useHAxis)
					{
						fcpMokSOSPSkfIoeTHjUJvvymMbi(_horizontalTiltCustomControllerElement, _axis2D.xAxis.value, _axis2D.xAxis.buttonActivationThreshold);
						num = 794105794;
						continue;
					}
					return;
				case 3:
					goto IL_0092;
				case 5:
					fcpMokSOSPSkfIoeTHjUJvvymMbi(_forwardTiltCustomControllerElement, _axis2D.yAxis.value, _axis2D.yAxis.buttonActivationThreshold);
					num = 794105798;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0041:
			if (!hasController)
			{
				return;
			}
			goto IL_0092;
			IL_0092:
			int num2;
			if (_useFAxis)
			{
				num = 794105797;
				num2 = num;
			}
			else
			{
				num = 794105798;
				num2 = num;
			}
			goto IL_000d;
		}

		public override void ClearValue()
		{
			_axis2D.xAxis.Clear();
			while (true)
			{
				int num = 377602670;
				while (true)
				{
					switch (num ^ 0x1681C26D)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						_axis2D.yAxis.Clear();
						num = 377602668;
						continue;
					case 1:
					{
						int num2;
						if (hasController)
						{
							num = 377602671;
							num2 = num;
						}
						else
						{
							num = 377602665;
							num2 = num;
						}
						continue;
					}
					case 2:
						base.controller.ClearElementValue(_horizontalTiltCustomControllerElement);
						base.controller.ClearElementValue(_forwardTiltCustomControllerElement);
						num = 377602665;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void eVPSloHveSYDZVHdjbizubeMkQp()
		{
			if (!_useHAxis)
			{
				goto IL_0099;
			}
			if (!(acceleration == Vector3.zero))
			{
				goto IL_0100;
			}
			float rawValue = 0f;
			goto IL_017e;
			IL_0099:
			int num;
			if (_useFAxis)
			{
				int num2;
				if (!(acceleration == Vector3.zero))
				{
					num = 682166322;
					num2 = num;
				}
				else
				{
					num = 682166332;
					num2 = num;
				}
				goto IL_0030;
			}
			return;
			IL_0100:
			float value = Mathf.Atan2(acceleration.x, 0f - acceleration.y) * 57.29578f + _horizontalRestAngle;
			rawValue = Mathf.InverseLerp(0f - _horizontalTiltLimit, _horizontalTiltLimit, value) * 2f - 1f;
			num = 682166329;
			goto IL_0030;
			IL_017e:
			_axis2D.xAxis.SetRawValue(rawValue);
			num = 682166333;
			goto IL_0030;
			IL_0030:
			float value2 = default(float);
			float num3 = default(float);
			while (true)
			{
				switch (num ^ 0x28A9083A)
				{
				case 0:
					num = 682166323;
					continue;
				default:
					return;
				case 8:
					value2 = Mathf.Atan2(acceleration.z, 0f - acceleration.y) * 57.29578f + _forwardRestAngle;
					num = 682166334;
					continue;
				case 7:
					break;
				case 6:
					num3 = 0f;
					num = 682166331;
					continue;
				case 1:
					num = 682166335;
					continue;
				case 5:
					_axis2D.yAxis.SetRawValue(0f - num3);
					num = 682166328;
					continue;
				case 9:
					goto IL_0100;
				case 4:
					num3 = Mathf.InverseLerp(0f - _forwardTiltLimit, _forwardTiltLimit, value2) * 2f - 1f;
					num = 682166335;
					continue;
				case 3:
					goto IL_017e;
				case 2:
					return;
				}
				break;
			}
			goto IL_0099;
		}

		private void SSNbZVHYzyYyvTvbhmvcDWPTqqs()
		{
			hHbXGUYunkblaqblvHADFikMHzF(_allowedTiltDirections);
			if (!hasController)
			{
				return;
			}
			while (true)
			{
				int num;
				if (_useHAxis)
				{
					base.controller.ValidateElements(_horizontalTiltCustomControllerElement);
					num = -1075610904;
					goto IL_001a;
				}
				goto IL_005c;
				IL_001a:
				while (true)
				{
					switch (num ^ -1075610904)
					{
					case 4:
						num = -1075610901;
						continue;
					default:
						return;
					case 3:
						break;
					case 0:
						goto IL_005c;
					case 1:
						base.controller.ValidateElements(_forwardTiltCustomControllerElement);
						num = -1075610902;
						continue;
					case 2:
						return;
					}
					break;
				}
				continue;
				IL_005c:
				int num2;
				if (!_useFAxis)
				{
					num = -1075610902;
					num2 = num;
				}
				else
				{
					num = -1075610903;
					num2 = num;
				}
				goto IL_001a;
			}
		}

		private void hHbXGUYunkblaqblvHADFikMHzF(TiltDirection P_0)
		{
			bool flag = P_0 == TiltDirection.Both || P_0 == TiltDirection.Horizontal;
			if (_useHAxis != flag)
			{
				_useHAxis = flag;
				if (!flag && hasController)
				{
					base.controller.ClearElementValue(_horizontalTiltCustomControllerElement);
					goto IL_003a;
				}
			}
			goto IL_0098;
			IL_0098:
			bool flag2 = P_0 == TiltDirection.Both || P_0 == TiltDirection.Forward;
			int num = -1871359714;
			goto IL_003f;
			IL_003f:
			while (true)
			{
				switch (num ^ -1871359717)
				{
				case 3:
					break;
				case 0:
					goto IL_0064;
				case 2:
					if (hasController)
					{
						base.controller.ClearElementValue(_forwardTiltCustomControllerElement);
						num = -1871359718;
						continue;
					}
					goto default;
				case 4:
					goto IL_0098;
				case 5:
					if (_useFAxis != flag2)
					{
						_useFAxis = flag2;
						num = -1871359717;
						continue;
					}
					goto default;
				default:
					_allowedTiltDirections = P_0;
					return;
				}
				break;
				IL_0064:
				int num2;
				if (flag2)
				{
					num = -1871359718;
					num2 = num;
				}
				else
				{
					num = -1871359719;
					num2 = num;
				}
			}
			goto IL_003a;
			IL_003a:
			num = -1871359713;
			goto IL_003f;
		}
	}
}
