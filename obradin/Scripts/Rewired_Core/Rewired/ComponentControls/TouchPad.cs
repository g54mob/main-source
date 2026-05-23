using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Image))]
	public sealed class TouchPad : TouchInteractable, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		public enum AxisDirection
		{
			Both = 0,
			Horizontal = 1,
			Vertical = 2
		}

		public enum TouchPadMode
		{
			Delta = 0,
			ScreenPosition = 1,
			VectorFromCenter = 2,
			VectorFromInitialTouch = 3
		}

		public enum ValueFormat
		{
			Pixels = 0,
			Screen = 1,
			Physical = 2,
			Direction = 3
		}

		private class nJXHASFXyGjqTJOiSWRFjOLpOSo
		{
			private class EKHjVEExXICPrxCGQroCXCPcuBp
			{
				public float tZfhkeNLltBUGrNOBGFtCGTpEgF;

				public float NSawOevekNbKdEGYiDwRoEKHtBBh;

				public uint guebJEeuIIBmQDaVIDUbCtSyEDzN;
			}

			private int gYHtosHYzHfFmYMxezlLLEvIBsB;

			private EKHjVEExXICPrxCGQroCXCPcuBp[] PvbfvGDQstrrExqmLGQWIcGWljDB;

			private int RMmuzLwPyyqjZzFkavzjXDLDVyZ = -1;

			public nJXHASFXyGjqTJOiSWRFjOLpOSo(int maxSmoothFrames)
			{
				if (maxSmoothFrames < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				gYHtosHYzHfFmYMxezlLLEvIBsB = maxSmoothFrames;
				PvbfvGDQstrrExqmLGQWIcGWljDB = new EKHjVEExXICPrxCGQroCXCPcuBp[maxSmoothFrames];
				ArrayTools.Populate(PvbfvGDQstrrExqmLGQWIcGWljDB);
			}

			public void MPPQJfVkqEnvckKDMacDSmlvhjwB(float P_0, float P_1)
			{
				uint currentFrame = ReInput.currentFrame;
				if (RMmuzLwPyyqjZzFkavzjXDLDVyZ >= 0 && PvbfvGDQstrrExqmLGQWIcGWljDB[RMmuzLwPyyqjZzFkavzjXDLDVyZ].guebJEeuIIBmQDaVIDUbCtSyEDzN == currentFrame)
				{
					while (true)
					{
						switch (-1336446742 ^ -1336446741)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				QfVyzdRKbRAEBqKPLZqCbPglAMc();
				EKHjVEExXICPrxCGQroCXCPcuBp eKHjVEExXICPrxCGQroCXCPcuBp = PvbfvGDQstrrExqmLGQWIcGWljDB[RMmuzLwPyyqjZzFkavzjXDLDVyZ];
				eKHjVEExXICPrxCGQroCXCPcuBp.tZfhkeNLltBUGrNOBGFtCGTpEgF = P_0;
				eKHjVEExXICPrxCGQroCXCPcuBp.NSawOevekNbKdEGYiDwRoEKHtBBh = P_1;
				eKHjVEExXICPrxCGQroCXCPcuBp.guebJEeuIIBmQDaVIDUbCtSyEDzN = currentFrame;
			}

			public Vector2 QJaTdhLNVZgOntuRiKaZnMxHFoN()
			{
				if (RMmuzLwPyyqjZzFkavzjXDLDVyZ < 0)
				{
					return default(Vector2);
				}
				int rMmuzLwPyyqjZzFkavzjXDLDVyZ = RMmuzLwPyyqjZzFkavzjXDLDVyZ;
				EKHjVEExXICPrxCGQroCXCPcuBp eKHjVEExXICPrxCGQroCXCPcuBp = PvbfvGDQstrrExqmLGQWIcGWljDB[rMmuzLwPyyqjZzFkavzjXDLDVyZ];
				Vector2 result = new Vector2(eKHjVEExXICPrxCGQroCXCPcuBp.tZfhkeNLltBUGrNOBGFtCGTpEgF, eKHjVEExXICPrxCGQroCXCPcuBp.NSawOevekNbKdEGYiDwRoEKHtBBh);
				uint guebJEeuIIBmQDaVIDUbCtSyEDzN = eKHjVEExXICPrxCGQroCXCPcuBp.guebJEeuIIBmQDaVIDUbCtSyEDzN;
				int num = rMmuzLwPyyqjZzFkavzjXDLDVyZ;
				int num3 = default(int);
				EKHjVEExXICPrxCGQroCXCPcuBp eKHjVEExXICPrxCGQroCXCPcuBp2 = default(EKHjVEExXICPrxCGQroCXCPcuBp);
				while (true)
				{
					int num2 = 1901410433;
					while (true)
					{
						switch (num2 ^ 0x71553887)
						{
						case 5:
							break;
						case 0:
							if (num3 > 0)
							{
								result.x /= num3;
								result.y /= num3;
								num2 = 1901410436;
								continue;
							}
							goto default;
						case 2:
						{
							int num4;
							if ((num = LwQmlBTBIntRAFTRXedrATdkaHG(num, gYHtosHYzHfFmYMxezlLLEvIBsB)) != rMmuzLwPyyqjZzFkavzjXDLDVyZ)
							{
								num2 = 1901410438;
								num4 = num2;
							}
							else
							{
								num2 = 1901410439;
								num4 = num2;
							}
							continue;
						}
						case 6:
							num3 = 1;
							num2 = 1901410437;
							continue;
						case 1:
							eKHjVEExXICPrxCGQroCXCPcuBp2 = PvbfvGDQstrrExqmLGQWIcGWljDB[num];
							if (HBqSffsIMZIRsFqSMCXDLOqJGdJH(eKHjVEExXICPrxCGQroCXCPcuBp2.guebJEeuIIBmQDaVIDUbCtSyEDzN, guebJEeuIIBmQDaVIDUbCtSyEDzN))
							{
								result.x += eKHjVEExXICPrxCGQroCXCPcuBp2.tZfhkeNLltBUGrNOBGFtCGTpEgF;
								result.y += eKHjVEExXICPrxCGQroCXCPcuBp2.NSawOevekNbKdEGYiDwRoEKHtBBh;
								num2 = 1901410435;
								continue;
							}
							goto case 0;
						case 4:
							guebJEeuIIBmQDaVIDUbCtSyEDzN = eKHjVEExXICPrxCGQroCXCPcuBp2.guebJEeuIIBmQDaVIDUbCtSyEDzN;
							num3++;
							num2 = 1901410437;
							continue;
						default:
							return result;
						}
						break;
					}
				}
			}

			private void QfVyzdRKbRAEBqKPLZqCbPglAMc()
			{
				RMmuzLwPyyqjZzFkavzjXDLDVyZ = epZfuqvEtgOGWyFTyGgBkCrrGtsd(RMmuzLwPyyqjZzFkavzjXDLDVyZ, gYHtosHYzHfFmYMxezlLLEvIBsB);
			}

			private static int epZfuqvEtgOGWyFTyGgBkCrrGtsd(int P_0, int P_1)
			{
				if (P_0 >= P_1 - 1)
				{
					return 0;
				}
				return ++P_0;
			}

			private int LwQmlBTBIntRAFTRXedrATdkaHG(int P_0, int P_1)
			{
				if (P_0 > 0)
				{
					return --P_0;
				}
				return P_1 - 1;
			}

			private static bool HBqSffsIMZIRsFqSMCXDLOqJGdJH(uint P_0, uint P_1)
			{
				if (P_1 == 0)
				{
					return P_0 == uint.MaxValue;
				}
				return P_0 == P_1 - 1;
			}
		}

		[Serializable]
		public class ValueChangedEventHandler : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class TapEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class PressDownEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class PressUpEventHandler : UnityEvent
		{
		}

		private const int SMOOTH_DELTA_FRAME_COUNT = 3;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's X axis.")]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from the touch pad's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from touch pad taps.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from touch pad presses.")]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisDirection _axesToUse;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The mode of the touch pad.\n\nDelta - Returns the change in position of the touch from the previous to the current frame.\n\nScreen Position - Returns the absolute position of the touch  on the screen.\n\nVector From Center - Returns a vector from the center of the Touch Pad to the current touch position.\n\nVector From Initial Touch - Returns a vector from the intial touch position to the current touch position.")]
		private TouchPadMode _touchPadMode;

		[Tooltip("The format of the resulting data generated by the touch pad.\n\nPixels - Screen pixels.\n\nScreen - The proportion of the value to screen size in the corresponding dimension. 1 unit = 1 screen length (width for X, height for Y).\n\nPhysical - 1 unit = 1/100th of an inch. The resulting value will be consistent across different screen resolutions and sizes. IMPORTANT: This relies on the value returned by UnityEngine.Screen.dpi. If the device does not return a value, a reference resolution of 96 dpi will be used.\n\nDirection - A normalized direction vector.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueFormat _valueFormat;

		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useInertia;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		[SerializeField]
		private float _inertiaFriction = 3f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Should taps on the touch pad be processed?")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _allowTap;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[FieldRange(0f, float.MaxValue)]
		private float _tapTimeout = 0.25f;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[FieldRange(-1, int.MaxValue)]
		private int _tapDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		[SerializeField]
		private bool _allowPress;

		[CustomObfuscation(rename = false)]
		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		[SerializeField]
		private float _pressStartDelay = 0.1f;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		[SerializeField]
		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		private int _pressDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		private bool _hideAtRuntime;

		[Tooltip("The underlying Axis 2D.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the value changes.")]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TapEventHandler _onTap = new TapEventHandler();

		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private PressDownEventHandler _onPressDown = new PressDownEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		private PressUpEventHandler _onPressUp = new PressUpEventHandler();

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool jYtFWKZUVrechfzATGCgCETBhJCg;

		[NonSerialized]
		private bool GXxxUMYvhnAdzwfrIpAYPjIWpue;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private nJXHASFXyGjqTJOiSWRFjOLpOSo _smoothDelta = new nJXHASFXyGjqTJOiSWRFjOLpOSo(3);

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement
		{
			get
			{
				return _horizontalAxisCustomControllerElement;
			}
		}

		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement
		{
			get
			{
				return _verticalAxisCustomControllerElement;
			}
		}

		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement
		{
			get
			{
				return _tapCustomControllerElement;
			}
		}

		public CustomControllerElementTargetSetForBoolean pressCustomControllerElement
		{
			get
			{
				return _pressCustomControllerElement;
			}
		}

		public AxisDirection axesToUse
		{
			get
			{
				return _axesToUse;
			}
			set
			{
				if (_axesToUse == value)
				{
					return;
				}
				while (true)
				{
					nyzmpEWTMknZYhaJEGiQjqKBXpbI(value);
					int num = 658643862;
					while (true)
					{
						switch (num ^ 0x27421B95)
						{
						case 0:
							num = 658643863;
							continue;
						default:
							return;
						case 2:
							break;
						case 3:
							OnSetProperty();
							num = 658643860;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		public TouchPadMode touchPadMode
		{
			get
			{
				return _touchPadMode;
			}
			set
			{
				if (_touchPadMode != value)
				{
					_touchPadMode = value;
					OnSetProperty();
				}
			}
		}

		public ValueFormat valueFormat
		{
			get
			{
				return _valueFormat;
			}
			set
			{
				if (_valueFormat == value)
				{
					while (true)
					{
						switch (-291197508 ^ -291197507)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_valueFormat = value;
				OnSetProperty();
			}
		}

		public bool useInertia
		{
			get
			{
				return _useInertia;
			}
			set
			{
				if (_useInertia == value)
				{
					while (true)
					{
						switch (-1770759459 ^ -1770759460)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_useInertia = value;
				OnSetProperty();
			}
		}

		public float inertiaFriction
		{
			get
			{
				return _inertiaFriction;
			}
			set
			{
				value = MathTools.Max(0f, value);
				while (true)
				{
					int num = -2058830801;
					while (true)
					{
						switch (num ^ -2058830804)
						{
						case 0:
							break;
						case 3:
						{
							int num2;
							if (_inertiaFriction != value)
							{
								num = -2058830803;
								num2 = num;
							}
							else
							{
								num = -2058830802;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
						default:
							_inertiaFriction = value;
							OnSetProperty();
							return;
						}
						break;
					}
				}
			}
		}

		public bool activateOnSwipeIn
		{
			get
			{
				return _activateOnSwipeIn;
			}
			set
			{
				if (_activateOnSwipeIn == value)
				{
					return;
				}
				while (true)
				{
					_activateOnSwipeIn = value;
					int num = 2053190865;
					while (true)
					{
						switch (num ^ 0x7A6134D0)
						{
						case 0:
							goto IL_000a;
						case 2:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = 2053190866;
					}
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				return _stayActiveOnSwipeOut;
			}
			set
			{
				if (_stayActiveOnSwipeOut == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -603259597;
				goto IL_000e;
				IL_000e:
				switch (num ^ -603259598)
				{
				case 0:
					break;
				case 1:
					return;
				case 2:
					goto IL_0033;
				default:
					OnSetProperty();
					return;
				}
				goto IL_0009;
				IL_0033:
				_stayActiveOnSwipeOut = value;
				num = -603259599;
				goto IL_000e;
			}
		}

		public bool allowTap
		{
			get
			{
				return _allowTap;
			}
			set
			{
				if (_allowTap == value)
				{
					return;
				}
				while (true)
				{
					_allowTap = value;
					OnSetProperty();
					int num = -1166349954;
					while (true)
					{
						switch (num ^ -1166349954)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = -1166349953;
					}
				}
			}
		}

		public float tapTimeout
		{
			get
			{
				return _tapTimeout;
			}
			set
			{
				value = MathTools.Max(0f, value);
				if (_tapTimeout == value)
				{
					goto IL_0016;
				}
				goto IL_0040;
				IL_0016:
				int num = -1932444750;
				goto IL_001b;
				IL_001b:
				switch (num ^ -1932444752)
				{
				case 0:
					break;
				case 2:
					return;
				case 3:
					goto IL_0040;
				default:
					OnSetProperty();
					return;
				}
				goto IL_0016;
				IL_0040:
				_tapTimeout = value;
				num = -1932444751;
				goto IL_001b;
			}
		}

		public int tapDistanceLimit
		{
			get
			{
				return _tapDistanceLimit;
			}
			set
			{
				value = MathTools.Max(-1, value);
				if (_tapDistanceLimit != value)
				{
					_tapDistanceLimit = value;
					OnSetProperty();
				}
			}
		}

		public bool allowPress
		{
			get
			{
				return _allowPress;
			}
			set
			{
				if (_allowPress != value)
				{
					_allowPress = value;
					OnSetProperty();
				}
			}
		}

		public float pressStartDelay
		{
			get
			{
				return _pressStartDelay;
			}
			set
			{
				value = Mathf.Max(0f, float.MaxValue);
				while (true)
				{
					switch (0x33BDE4DF ^ 0x33BDE4DE)
					{
					case 2:
						continue;
					case 1:
						if (_pressStartDelay == value)
						{
							return;
						}
						break;
					}
					break;
				}
				_pressStartDelay = value;
				OnSetProperty();
			}
		}

		public int pressDistanceLimit
		{
			get
			{
				return _pressDistanceLimit;
			}
			set
			{
				value = MathTools.Max(-1, value);
				if (_pressDistanceLimit == value)
				{
					return;
				}
				while (true)
				{
					_pressDistanceLimit = value;
					int num = -1813847491;
					while (true)
					{
						switch (num ^ -1813847492)
						{
						case 0:
							goto IL_0013;
						case 2:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_0013:
						num = -1813847490;
					}
				}
			}
		}

		public bool hideAtRuntime
		{
			get
			{
				return _hideAtRuntime;
			}
			set
			{
				bool flag = (_hideAtRuntime = value);
				while (true)
				{
					switch (-1244396680 ^ -1244396678)
					{
					case 0:
						continue;
					case 2:
						if (flag)
						{
							return;
						}
						break;
					}
					break;
				}
				_hideAtRuntime = true;
				OnSetProperty();
			}
		}

		public int pointerId
		{
			get
			{
				return _pointerId;
			}
			set
			{
				_pointerId = value;
			}
		}

		public bool hasPointer
		{
			get
			{
				return _pointerId != int.MinValue;
			}
		}

		public Vector2 touchStartPosition
		{
			get
			{
				if (!hasPointer)
				{
					return Vector2.zero;
				}
				return _touchStartPosition;
			}
		}

		public Vector2 touchPosition
		{
			get
			{
				if (!TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
				{
					return Vector2.zero;
				}
				return TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(effectivePointerId);
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

		private int effectivePointerId
		{
			get
			{
				if (_pointerId == int.MinValue)
				{
					return int.MinValue;
				}
				if (_realMousePointerId != int.MinValue)
				{
					return _realMousePointerId;
				}
				return _pointerId;
			}
		}

		private bool tapValue
		{
			get
			{
				return _lastTapFrame == Time.frameCount;
			}
		}

		public event UnityAction<Vector2> ValueChangedEvent
		{
			add
			{
				_onValueChanged.AddListener(value);
			}
			remove
			{
				_onValueChanged.RemoveListener(value);
			}
		}

		public event UnityAction TapEvent
		{
			add
			{
				_onTap.AddListener(value);
			}
			remove
			{
				_onTap.RemoveListener(value);
			}
		}

		public event UnityAction PressDownEvent
		{
			add
			{
				_onPressDown.AddListener(value);
			}
			remove
			{
				_onPressDown.RemoveListener(value);
			}
		}

		public event UnityAction PressUpEvent
		{
			add
			{
				_onPressUp.AddListener(value);
			}
			remove
			{
				_onPressUp.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchPad()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (!Application.isPlaying)
			{
				goto IL_000d;
			}
			goto IL_0037;
			IL_000d:
			int num = -429303271;
			goto IL_0012;
			IL_0012:
			switch (num ^ -429303269)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 3:
				goto IL_0037;
			case 1:
				return;
			}
			goto IL_000d;
			IL_0037:
			if (_hideAtRuntime)
			{
				base.visible = false;
				num = -429303270;
				goto IL_0012;
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
			int num = -1526719317;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1526719318)
			{
			case 2:
				break;
			case 1:
				return;
			case 3:
				goto IL_0038;
			default:
				NVWqZPEZaDhGVdcEuqvABdsUKUL();
				return;
			}
			goto IL_000e;
			IL_0038:
			nQRBjgHZAYAKvocDqONNTpxqTmA();
			num = -1526719318;
			goto IL_0013;
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			nQRBjgHZAYAKvocDqONNTpxqTmA();
			return true;
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = 110817746;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x69AF1D1)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				return;
			case 0:
				goto IL_0038;
			case 1:
				return;
			}
			goto IL_000e;
			IL_0038:
			XWItRFzQtFMTnzwGXepHBSuqEaS();
			GLnFKkzcjTCAOtkTuThfdBcbeFU();
			RaIuFmAMDXfdJjzOssKFhHpZxTs();
			UEQoSZqysCkXaofqKejXiFbupQQr();
			PeasfOPFFKtMOzEgnsHBtRnzgbX();
			num = 110817744;
			goto IL_0013;
		}

		internal override void OnCustomControllerUpdate()
		{
			if (!base.initialized)
			{
				goto IL_000b;
			}
			goto IL_00d9;
			IL_000b:
			int num = -172287289;
			goto IL_0010;
			IL_0010:
			Vector2 vector = default(Vector2);
			while (true)
			{
				switch (num ^ -172287292)
				{
				case 6:
					break;
				default:
					return;
				case 4:
					if (_allowPress)
					{
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(_pressCustomControllerElement, _pressValue);
						num = -172287291;
						continue;
					}
					return;
				case 5:
					jdvcKcWQnHxAXPvCkvKHWiFjvWV(_tapCustomControllerElement, tapValue);
					num = -172287296;
					continue;
				case 2:
					goto IL_0085;
				case 3:
					return;
				case 0:
					jdvcKcWQnHxAXPvCkvKHWiFjvWV(_verticalAxisCustomControllerElement, vector.y, _axis2D.xAxis.buttonActivationThreshold);
					num = -172287293;
					continue;
				case 8:
					goto IL_00d9;
				case 7:
					goto IL_00ec;
				case 9:
					goto IL_0108;
				case 1:
					return;
				}
				break;
				IL_00ec:
				int num2;
				if (_allowTap)
				{
					num = -172287295;
					num2 = num;
				}
				else
				{
					num = -172287296;
					num2 = num;
				}
			}
			goto IL_000b;
			IL_00d9:
			if (!hasController)
			{
				return;
			}
			goto IL_0108;
			IL_0108:
			vector = ((_touchPadMode == TouchPadMode.ScreenPosition) ? _axis2D.rawValue : _axis2D.value);
			if (_useXAxis)
			{
				jdvcKcWQnHxAXPvCkvKHWiFjvWV(_horizontalAxisCustomControllerElement, vector.x, _axis2D.xAxis.buttonActivationThreshold);
				num = -172287290;
				goto IL_0010;
			}
			goto IL_0085;
			IL_0085:
			int num3;
			if (_useYAxis)
			{
				num = -172287292;
				num3 = num;
			}
			else
			{
				num = -172287293;
				num3 = num;
			}
			goto IL_0010;
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			while (true)
			{
				int num = -2110029494;
				while (true)
				{
					switch (num ^ -2110029493)
					{
					case 2:
						break;
					default:
						return;
					case 1:
					{
						int num2;
						if (base.initialized)
						{
							num = -2110029489;
							num2 = num;
						}
						else
						{
							num = -2110029496;
							num2 = num;
						}
						continue;
					}
					case 4:
						nQRBjgHZAYAKvocDqONNTpxqTmA();
						NVWqZPEZaDhGVdcEuqvABdsUKUL();
						num = -2110029493;
						continue;
					case 3:
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal override void OnClear()
		{
			base.OnClear();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0089;
			IL_000e:
			int num = -728431459;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -728431463)
				{
				case 0:
					break;
				case 4:
					return;
				case 5:
					_realMousePointerId = int.MinValue;
					jYtFWKZUVrechfzATGCgCETBhJCg = false;
					num = -728431461;
					continue;
				case 2:
					GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
					_pointerDownIsFake = false;
					_currentCenter = Vector2.zero;
					_previousTouchPosition = Vector2.zero;
					num = -728431464;
					continue;
				case 3:
					goto IL_0089;
				default:
					_axis2D.Clear();
					_lastTapFrame = -1;
					_pressValue = false;
					_isEligibleForTap = false;
					_isEligibleForPress = false;
					return;
				}
				break;
			}
			goto IL_000e;
			IL_0089:
			_pointerId = int.MinValue;
			num = -728431460;
			goto IL_0013;
		}

		public override void ClearValue()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				_axis2D.Clear();
				int num = 1853696234;
				while (true)
				{
					switch (num ^ 0x6E7D28E8)
					{
					case 4:
						num = 1853696233;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						if (hasController)
						{
							base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
							base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
							base.controller.ClearElementValue(_tapCustomControllerElement);
							num = 1853696235;
							continue;
						}
						return;
					case 2:
						_lastTapFrame = -1;
						_pressValue = false;
						num = 1853696232;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void NVWqZPEZaDhGVdcEuqvABdsUKUL()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			_pressCustomControllerElement.ClearElementCaches();
		}

		private void nQRBjgHZAYAKvocDqONNTpxqTmA()
		{
			nyzmpEWTMknZYhaJEGiQjqKBXpbI(_axesToUse);
			if (!hasController)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!base.touchController.useCustomController)
				{
					num = 1597815905;
					num2 = num;
				}
				else
				{
					num = 1597815908;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5F3CBC67)
					{
					case 2:
						num = 1597815910;
						continue;
					default:
						return;
					case 7:
						if (_allowPress)
						{
							base.controller.ValidateElements(_pressCustomControllerElement);
							num = 1597815906;
							continue;
						}
						return;
					case 4:
						if (_allowTap)
						{
							base.controller.ValidateElements(_tapCustomControllerElement);
							num = 1597815904;
							continue;
						}
						goto case 7;
					case 1:
						break;
					case 6:
						return;
					case 0:
						if (_useYAxis)
						{
							base.controller.ValidateElements(_verticalAxisCustomControllerElement);
							num = 1597815907;
							continue;
						}
						goto case 4;
					case 3:
						if (_useXAxis)
						{
							base.controller.ValidateElements(_horizontalAxisCustomControllerElement);
							num = 1597815911;
							continue;
						}
						goto case 0;
					case 5:
						return;
					}
					break;
				}
			}
		}

		private void nyzmpEWTMknZYhaJEGiQjqKBXpbI(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				goto IL_001b;
			}
			goto IL_0080;
			IL_004c:
			int num;
			bool flag2 = (byte)num != 0;
			int num2;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && hasController)
				{
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
					num2 = 1809208584;
					goto IL_0020;
				}
			}
			goto IL_00c4;
			IL_0045:
			num = ((P_0 == AxisDirection.Vertical) ? 1 : 0);
			goto IL_004c;
			IL_00c4:
			_axesToUse = P_0;
			return;
			IL_0080:
			if (P_0 == AxisDirection.Both)
			{
				num = 1;
				goto IL_004c;
			}
			num2 = 1809208590;
			goto IL_0020;
			IL_001b:
			num2 = 1809208589;
			goto IL_0020;
			IL_0020:
			while (true)
			{
				switch (num2 ^ 0x6BD6550C)
				{
				case 5:
					break;
				case 2:
					goto IL_0045;
				case 3:
					goto IL_0080;
				case 0:
					if (hasController)
					{
						base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
						num2 = 1809208591;
						continue;
					}
					goto IL_0080;
				case 1:
					goto IL_00ad;
				default:
					goto IL_00c4;
				}
				break;
				IL_00ad:
				int num3;
				if (!flag)
				{
					num2 = 1809208588;
					num3 = num2;
				}
				else
				{
					num2 = 1809208591;
					num3 = num2;
				}
			}
			goto IL_001b;
		}

		private void GLnFKkzcjTCAOtkTuThfdBcbeFU()
		{
			if (!hasPointer)
			{
				return;
			}
			while (!TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
			{
				PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(effectivePointerId);
				int num = -435234964;
				while (true)
				{
					switch (num ^ -435234962)
					{
					case 0:
						num = -435234966;
						continue;
					default:
						return;
					case 4:
						break;
					case 3:
						lvEXyedGHJXClGybBOaYBiVqimu();
						num = -435234961;
						continue;
					case 2:
					{
						int num2;
						if (pointerEventData != null)
						{
							num = -435234965;
							num2 = num;
						}
						else
						{
							num = -435234963;
							num2 = num;
						}
						continue;
					}
					case 5:
						if (pointerEventData.pointerPress != null)
						{
							uhbxZnhdAiTocMkidbifwylOKNg(pointerEventData);
							return;
						}
						goto case 3;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void RaIuFmAMDXfdJjzOssKFhHpZxTs()
		{
			if (_touchPadMode == TouchPadMode.VectorFromCenter)
			{
				goto IL_000c;
			}
			goto IL_0174;
			IL_000c:
			int num = 2034435090;
			goto IL_0011;
			IL_0011:
			Vector3 vector2 = default(Vector3);
			Vector2 vector = default(Vector2);
			while (true)
			{
				switch (num ^ 0x79430415)
				{
				case 10:
					break;
				default:
					return;
				case 5:
					_previousTouchPosition = vector2;
					num = 2034435102;
					continue;
				case 0:
					vector2 = TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(effectivePointerId);
					num = 2034435089;
					continue;
				case 2:
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_currentCenter = _previousTouchPosition;
						num = 2034435092;
						continue;
					}
					goto case 1;
				case 8:
					vector = VMYdubkIOGMyJmruGrZwILSCIcw(vector);
					_axis2D.SetRawValue(vector.x, vector.y);
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_smoothDelta.MPPQJfVkqEnvckKDMacDSmlvhjwB(vector.x, vector.y);
						num = 2034435088;
						continue;
					}
					goto case 5;
				case 7:
				{
					Graphic graphic = base.targetGraphic;
					_currentCenter = ((graphic != null) ? graphic.transform.position : base.transform.position);
					_currentCenter = RectTransformUtility.WorldToScreenPoint(base.canvas.worldCamera, _currentCenter);
					num = 2034435100;
					continue;
				}
				case 4:
					if (_touchPadMode == TouchPadMode.ScreenPosition)
					{
						vector = vector2;
						num = 2034435094;
						continue;
					}
					goto case 2;
				case 3:
					num = 2034435101;
					continue;
				case 6:
					return;
				case 9:
					goto IL_0174;
				case 1:
					vector = new Vector2(vector2.x - _currentCenter.x, vector2.y - _currentCenter.y);
					num = 2034435101;
					continue;
				case 11:
					return;
				}
				break;
			}
			goto IL_000c;
			IL_0174:
			if (!hasPointer)
			{
				return;
			}
			int num2;
			if (!TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
			{
				num = 2034435091;
				num2 = num;
			}
			else
			{
				num = 2034435093;
				num2 = num;
			}
			goto IL_0011;
		}

		private void UEQoSZqysCkXaofqKejXiFbupQQr()
		{
			if (_touchPadMode == TouchPadMode.Delta)
			{
				if (!_useInertia)
				{
					goto IL_0010;
				}
				goto IL_0051;
			}
			return;
			IL_008f:
			Vector2 rawValue = _axis2D.rawValue;
			float smoothDeltaTime = Time.smoothDeltaTime;
			int num = -1152858795;
			goto IL_0015;
			IL_0010:
			num = -1152858794;
			goto IL_0015;
			IL_0015:
			float num2 = default(float);
			float num3 = default(float);
			while (true)
			{
				switch (num ^ -1152858800)
				{
				case 4:
					break;
				default:
					return;
				case 6:
					return;
				case 3:
					goto IL_0051;
				case 2:
					_axis2D.SetRawValue(num2, num3);
					num = -1152858792;
					continue;
				case 1:
					if (MathTools.IsNearZero(num3, 0.0001f))
					{
						num3 = 0f;
						num = -1152858798;
						continue;
					}
					goto case 2;
				case 0:
					goto IL_008f;
				case 5:
					num2 = Mathf.Lerp(rawValue.x, 0f, _inertiaFriction * smoothDeltaTime);
					num3 = Mathf.Lerp(rawValue.y, 0f, _inertiaFriction * smoothDeltaTime);
					num = -1152858793;
					continue;
				case 7:
					if (MathTools.IsNearZero(num2, 0.0001f))
					{
						num2 = 0f;
						num = -1152858799;
						continue;
					}
					goto case 1;
				case 8:
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0051:
			if (hasPointer)
			{
				return;
			}
			goto IL_008f;
		}

		private void XWItRFzQtFMTnzwGXepHBSuqEaS()
		{
			if (!hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 1618495086;
			goto IL_000d;
			IL_000d:
			Vector2 vector = default(Vector2);
			switch (num ^ 0x6078466D)
			{
			case 0:
				break;
			case 3:
				return;
			case 1:
				goto IL_0032;
			default:
				OhtZoNObgfifckfabmHWHssTvvb(ref vector);
				return;
			}
			goto IL_0008;
			IL_0032:
			vector = TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(effectivePointerId);
			pybGhnFNCApJPQjwvJIcNrbEYgc(ref vector);
			num = 1618495087;
			goto IL_000d;
		}

		private void pybGhnFNCApJPQjwvJIcNrbEYgc(ref Vector2 P_0)
		{
			if (!_allowTap)
			{
				return;
			}
			while (true)
			{
				int num = -1939806825;
				while (true)
				{
					switch (num ^ -1939806828)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						if (_tapDistanceLimit >= 0)
						{
							int num3;
							if (Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)
							{
								num = -1939806827;
								num3 = num;
							}
							else
							{
								num = -1939806830;
								num3 = num;
							}
							continue;
						}
						return;
					case 5:
						return;
					case 3:
					{
						int num4;
						if (_isEligibleForTap)
						{
							num = -1939806826;
							num4 = num;
						}
						else
						{
							num = -1939806831;
							num4 = num;
						}
						continue;
					}
					case 2:
						if (_tapTimeout > 0f)
						{
							int num2;
							if (!(Time.realtimeSinceStartup - _touchStartTime <= _tapTimeout))
							{
								num = -1939806827;
								num2 = num;
							}
							else
							{
								num = -1939806832;
								num2 = num;
							}
							continue;
						}
						goto case 4;
					case 1:
						_isEligibleForTap = false;
						num = -1939806830;
						continue;
					case 6:
						return;
					}
					break;
				}
			}
		}

		private void OhtZoNObgfifckfabmHWHssTvvb(ref Vector2 P_0)
		{
			if (!_allowPress)
			{
				return;
			}
			while (true)
			{
				int num = -1255748828;
				while (true)
				{
					switch (num ^ -1255748825)
					{
					case 0:
						break;
					default:
						return;
					case 3:
					{
						int num4;
						if (_isEligibleForPress)
						{
							num = -1255748830;
							num4 = num;
						}
						else
						{
							num = -1255748826;
							num4 = num;
						}
						continue;
					}
					case 2:
						bajrseiglAhYaEaLDuLcUsmOMPb(true);
						num = -1255748829;
						continue;
					case 5:
						if (_pressDistanceLimit >= 0)
						{
							int num2;
							if (Vector2.Distance(_touchStartPosition, P_0) > (float)_pressDistanceLimit)
							{
								num = -1255748831;
								num2 = num;
							}
							else
							{
								num = -1255748832;
								num2 = num;
							}
							continue;
						}
						goto case 7;
					case 6:
						_isEligibleForPress = false;
						bajrseiglAhYaEaLDuLcUsmOMPb(false);
						return;
					case 1:
						return;
					case 7:
						if (_pressStartDelay > 0f)
						{
							int num3;
							if (Time.realtimeSinceStartup - _touchStartTime < _pressStartDelay)
							{
								num = -1255748817;
								num3 = num;
							}
							else
							{
								num = -1255748827;
								num3 = num;
							}
							continue;
						}
						goto case 2;
					case 8:
						return;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void PeasfOPFFKtMOzEgnsHBtRnzgbX()
		{
			Vector2 value = default(Vector2);
			Vector2 valuePrev = default(Vector2);
			if (_touchPadMode == TouchPadMode.Delta)
			{
				value = _axis2D.value;
				valuePrev = _axis2D.valuePrev;
				goto IL_0023;
			}
			goto IL_00c4;
			IL_0077:
			_onValueChanged.Invoke(_axis2D.value);
			int num = -1257758417;
			goto IL_0028;
			IL_0023:
			num = -1257758422;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num ^ -1257758417)
				{
				case 7:
					break;
				default:
					return;
				case 5:
					goto IL_0058;
				case 4:
					goto IL_0077;
				case 6:
					if (value.y == 0f)
					{
						goto IL_00a2;
					}
					goto case 3;
				case 2:
					goto IL_00c4;
				case 3:
					_onValueChanged.Invoke(_axis2D.value);
					return;
				case 1:
					goto IL_0121;
				case 0:
					return;
				}
				break;
				IL_0121:
				int num2;
				if (valuePrev.y == 0f)
				{
					num = -1257758417;
					num2 = num;
				}
				else
				{
					num = -1257758420;
					num2 = num;
				}
				continue;
				IL_00a2:
				int num3;
				if (valuePrev.x == 0f)
				{
					num = -1257758418;
					num3 = num;
				}
				else
				{
					num = -1257758420;
					num3 = num;
				}
				continue;
				IL_0058:
				int num4;
				if (value.x != 0f)
				{
					num = -1257758420;
					num4 = num;
				}
				else
				{
					num = -1257758423;
					num4 = num;
				}
			}
			goto IL_0023;
			IL_00c4:
			Vector2 valueDelta = _axis2D.valueDelta;
			if (valueDelta.x == 0f)
			{
				int num5;
				if (valueDelta.y != 0f)
				{
					num = -1257758421;
					num5 = num;
				}
				else
				{
					num = -1257758417;
					num5 = num;
				}
				goto IL_0028;
			}
			goto IL_0077;
		}

		private Vector2 VMYdubkIOGMyJmruGrZwILSCIcw(Vector2 P_0)
		{
			int num;
			float num2 = default(float);
			switch (_valueFormat)
			{
			default:
				num = -1128684993;
				goto IL_0022;
			case ValueFormat.Direction:
				goto IL_0070;
			case ValueFormat.Screen:
				goto IL_007e;
			case ValueFormat.Physical:
				goto IL_00ce;
			case ValueFormat.Pixels:
				break;
				IL_0022:
				while (true)
				{
					switch (num ^ -1128684999)
					{
					case 3:
						break;
					case 8:
						goto IL_0056;
					case 1:
						goto IL_0070;
					case 0:
						goto IL_007e;
					case 6:
						num = -1128684996;
						continue;
					case 5:
						throw new NotImplementedException();
					case 2:
						P_0.y /= Screen.height;
						num = -1128684994;
						continue;
					case 4:
						goto IL_00ce;
					default:
						goto end_IL_0008;
					}
					break;
				}
				goto default;
				IL_00ce:
				num2 = Screen.dpi;
				if (num2 < 10f)
				{
					num2 = 96f;
					num = -1128685007;
					goto IL_0022;
				}
				goto IL_0056;
				IL_0056:
				P_0 = P_0 / num2 * 100f;
				num = -1128684994;
				goto IL_0022;
				IL_007e:
				P_0.x /= Screen.width;
				num = -1128684997;
				goto IL_0022;
				IL_0070:
				P_0.Normalize();
				num = -1128684994;
				goto IL_0022;
				end_IL_0008:
				break;
			}
			return P_0;
		}

		private void bajrseiglAhYaEaLDuLcUsmOMPb(bool P_0)
		{
			if (P_0 == _pressValue)
			{
				goto IL_0009;
			}
			goto IL_0054;
			IL_0009:
			int num = -264300815;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ -264300809)
				{
				case 5:
					break;
				default:
					return;
				case 0:
					return;
				case 3:
					if (P_0)
					{
						_onPressDown.Invoke();
						num = -264300809;
						continue;
					}
					goto case 4;
				case 2:
					goto IL_0054;
				case 4:
					_onPressUp.Invoke();
					num = -264300810;
					continue;
				case 6:
					return;
				case 1:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0054:
			_pressValue = P_0;
			num = -264300812;
			goto IL_000e;
		}

		private void RTFkZgwwfqcoraXUeOtRrGPTipR(PointerEventData P_0)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0040;
			IL_0008:
			int num = 1585914329;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x5E8721DB)
			{
			case 0:
				break;
			case 2:
				if (!xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
				{
					return;
				}
				goto IL_0040;
			case 3:
				goto IL_0040;
			default:
				goto IL_0069;
			}
			goto IL_0008;
			IL_0069:
			base.OnPointerDown(P_0);
			return;
			IL_0040:
			if (vWWTQEuzSAtwkwTidoREbMzaAEi() && IsInteractable())
			{
				oPbGWVlpSTmnotbhVEcMMsRAWvN(P_0.pointerId, P_0.pressPosition);
				num = 1585914330;
				goto IL_000d;
			}
			goto IL_0069;
		}

		private void oyVgIoryHcoeYsQAABSabldnFuw(PointerEventData P_0)
		{
			if (hasPointer && !xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				while (true)
				{
					switch (-26650022 ^ -26650023)
					{
					case 2:
						break;
					case 3:
						return;
					case 0:
						goto end_IL_0016;
					default:
						goto IL_0055;
					}
					continue;
					end_IL_0016:
					break;
				}
			}
			if (TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
			{
				return;
			}
			goto IL_0055;
			IL_0055:
			lvEXyedGHJXClGybBOaYBiVqimu();
			base.OnPointerUp(P_0);
		}

		private void kniQNhRGNrdKgAIpgLeavFJtBJvU(PointerEventData P_0)
		{
			if (hasPointer && !xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				goto IL_001c;
			}
			goto IL_0164;
			IL_0164:
			bool flag = TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0.pointerId);
			bool flag2 = false;
			int num;
			int num2;
			if (!_activateOnSwipeIn)
			{
				num = -418509780;
				num2 = num;
			}
			else
			{
				num = -418509782;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -418509778;
			goto IL_0021;
			IL_0021:
			int realMousePointerId = default(int);
			while (true)
			{
				switch (num ^ -418509782)
				{
				case 11:
					break;
				default:
					return;
				case 1:
					if ((flag && !TouchInteractable.adosDjbqcDBzBFXIUEkqUggQerO(base.allowedMouseButtons)) || jYtFWKZUVrechfzATGCgCETBhJCg)
					{
						goto IL_011f;
					}
					if (flag)
					{
						goto IL_0088;
					}
					goto case 9;
				case 10:
				{
					GameObject gameObject = base.gameObject;
					PointerEventData pointerEventData = FcNxJWJevjAfECcjXghibLdzawa((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
					if (pointerEventData != null)
					{
						RTFkZgwwfqcoraXUeOtRrGPTipR(pointerEventData);
						if (jYtFWKZUVrechfzATGCgCETBhJCg)
						{
							_pointerDownIsFake = true;
							num = -418509783;
							continue;
						}
					}
					goto case 3;
				}
				case 0:
					goto IL_00fb;
				case 6:
					goto IL_011f;
				case 3:
					GXxxUMYvhnAdzwfrIpAYPjIWpue = true;
					num = -418509784;
					continue;
				case 7:
					_realMousePointerId = P_0.pointerId;
					num = -418509789;
					continue;
				case 5:
					goto IL_0164;
				case 4:
					return;
				case 8:
					_realMousePointerId = realMousePointerId;
					num = -418509789;
					continue;
				case 9:
					flag2 = true;
					num = -418509780;
					continue;
				case 2:
					return;
				}
				break;
				IL_00fb:
				if (vWWTQEuzSAtwkwTidoREbMzaAEi())
				{
					int num3;
					if (IsInteractable())
					{
						num = -418509781;
						num3 = num;
					}
					else
					{
						num = -418509780;
						num3 = num;
					}
					continue;
				}
				goto IL_011f;
				IL_011f:
				base.OnPointerEnter(P_0);
				int num4;
				if (!flag2)
				{
					num = -418509783;
					num4 = num;
				}
				else
				{
					num = -418509792;
					num4 = num;
				}
				continue;
				IL_0088:
				int num5;
				if (TouchInteractable.mrmKZDYUuqVORhTlxFDFBEPmIPc(base.allowedMouseButtons, out realMousePointerId))
				{
					num = -418509790;
					num5 = num;
				}
				else
				{
					num = -418509779;
					num5 = num;
				}
			}
			goto IL_001c;
		}

		private void AQKFYYuUyzWMUiyIguWHpBOybED(PointerEventData P_0)
		{
			if (hasPointer && !xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				goto IL_0016;
			}
			goto IL_0060;
			IL_0060:
			int num;
			int num2;
			if (stayActiveOnSwipeOut)
			{
				num = -2024801031;
				num2 = num;
			}
			else
			{
				num = -2024801032;
				num2 = num;
			}
			goto IL_001b;
			IL_0016:
			num = -2024801030;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ -2024801032)
				{
				case 3:
					break;
				case 2:
					base.OnPointerExit(P_0);
					return;
				case 0:
					if (jYtFWKZUVrechfzATGCgCETBhJCg)
					{
						lvEXyedGHJXClGybBOaYBiVqimu();
						num = -2024801031;
						continue;
					}
					goto default;
				case 4:
					goto IL_0060;
				default:
					base.OnPointerExit(P_0);
					GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
					return;
				}
				break;
			}
			goto IL_0016;
		}

		private void oPbGWVlpSTmnotbhVEcMMsRAWvN(int P_0, Vector2 P_1)
		{
			_pointerId = P_0;
			jYtFWKZUVrechfzATGCgCETBhJCg = true;
			while (true)
			{
				int num = 764148582;
				while (true)
				{
					switch (num ^ 0x2D8BFB64)
					{
					case 0:
						break;
					case 2:
						_isEligibleForTap = true;
						_isEligibleForPress = true;
						if (_touchPadMode != TouchPadMode.VectorFromCenter)
						{
							_currentCenter = P_1;
							num = 764148581;
							continue;
						}
						goto case 1;
					case 1:
						if (_touchPadMode == TouchPadMode.Delta)
						{
							_previousTouchPosition = P_1;
							num = 764148583;
							continue;
						}
						goto default;
					default:
						_touchStartTime = Time.realtimeSinceStartup;
						_touchStartPosition = P_1;
						return;
					}
					break;
				}
			}
		}

		private void lvEXyedGHJXClGybBOaYBiVqimu()
		{
			if (_allowTap)
			{
				goto IL_000b;
			}
			int num = 0;
			goto IL_00c7;
			IL_00c7:
			bool flag = (byte)num != 0;
			int num2 = -64609220;
			goto IL_0010;
			IL_000b:
			num2 = -64609221;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ -64609222)
				{
				case 3:
					break;
				default:
					return;
				case 5:
					bajrseiglAhYaEaLDuLcUsmOMPb(false);
					_isEligibleForTap = false;
					_isEligibleForPress = false;
					if (flag)
					{
						_lastTapFrame = Time.frameCount + 1;
						_onTap.Invoke();
						num2 = -64609218;
						continue;
					}
					return;
				case 6:
					goto IL_0076;
				case 0:
					_axis2D.SetRawValue(0f, 0f);
					num2 = -64609217;
					continue;
				case 1:
					goto IL_00be;
				case 2:
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_axis2D.SetRawValue(_smoothDelta.QJaTdhLNVZgOntuRiKaZnMxHFoN());
						num2 = -64609217;
						continue;
					}
					goto case 0;
				case 4:
					return;
				}
				break;
				IL_0076:
				IVWagqmpVqfBssUpPTaUIrMVFpo();
				jYtFWKZUVrechfzATGCgCETBhJCg = false;
				int num3;
				if (!_useInertia)
				{
					num2 = -64609222;
					num3 = num2;
				}
				else
				{
					num2 = -64609224;
					num3 = num2;
				}
			}
			goto IL_000b;
			IL_00be:
			num = (_isEligibleForTap ? 1 : 0);
			goto IL_00c7;
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -927744608;
			goto IL_000d;
			IL_000d:
			switch (num ^ -927744604)
			{
			case 2:
				break;
			case 0:
				return;
			case 3:
				goto IL_0036;
			case 4:
				return;
			default:
				oyVgIoryHcoeYsQAABSabldnFuw(eventData);
				return;
			}
			goto IL_0008;
			IL_0036:
			int num2;
			if (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				num = -927744603;
				num2 = num;
			}
			else
			{
				num = -927744604;
				num2 = num;
			}
			goto IL_000d;
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				RTFkZgwwfqcoraXUeOtRrGPTipR(eventData);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
				{
					num = -431821559;
					num2 = num;
				}
				else
				{
					num = -431821558;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -431821560)
					{
					case 0:
						goto IL_0009;
					case 3:
						break;
					case 1:
						return;
					default:
						kniQNhRGNrdKgAIpgLeavFJtBJvU(eventData);
						return;
					}
					break;
					IL_0009:
					num = -431821557;
				}
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x1F449063 ^ 0x1F449062)
					{
					case 2:
						break;
					case 1:
						return;
					case 0:
						goto end_IL_0008;
					default:
						goto IL_004e;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			goto IL_004e;
			IL_004e:
			AQKFYYuUyzWMUiyIguWHpBOybED(eventData);
		}

		private void IVWagqmpVqfBssUpPTaUIrMVFpo()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
		}

		private bool xJRpUEtiZlPsigLVVURBBlekxkJ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				goto IL_0008;
			}
			if (_pointerId == int.MinValue)
			{
				return false;
			}
			int num;
			if (_pointerId == P_0)
			{
				num = -617275075;
				goto IL_000d;
			}
			if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
			IL_000d:
			switch (num ^ -617275075)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0008;
			IL_0008:
			num = -617275076;
			goto IL_000d;
		}

		private PointerEventData FcNxJWJevjAfECcjXghibLdzawa(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(P_0);
			if (TouchInteractable.KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				goto IL_0044;
			}
			goto IL_00d4;
			IL_0300:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			return null;
			IL_00d4:
			int num;
			if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
			{
				pointerEventData.eligibleForClick = true;
				num = 1131940829;
				goto IL_0049;
			}
			goto IL_0300;
			IL_0044:
			num = 1131940821;
			goto IL_0049;
			IL_0049:
			float unscaledTime2 = default(float);
			float unscaledTime = default(float);
			GameObject gameObject2 = default(GameObject);
			GameObject gameObject = default(GameObject);
			while (true)
			{
				switch (num ^ 0x43780BDE)
				{
				case 19:
					break;
				case 5:
					pointerEventData.clickCount = 1;
					num = 1131940823;
					continue;
				case 6:
					pointerEventData.clickCount = 1;
					num = 1131940822;
					continue;
				case 2:
					goto IL_00d4;
				case 8:
					pointerEventData.clickTime = unscaledTime2;
					num = 1131940820;
					continue;
				case 20:
				{
					float num3 = unscaledTime - pointerEventData.clickTime;
					if (num3 < 0.3f)
					{
						pointerEventData.clickCount++;
						num = 1131940817;
						continue;
					}
					goto case 17;
				}
				case 18:
					pointerEventData.clickCount = 1;
					num = 1131940826;
					continue;
				case 11:
					goto IL_0150;
				case 22:
					goto IL_0191;
				case 4:
					pointerEventData.pointerPress = gameObject2;
					pointerEventData.rawPointerPress = P_1;
					pointerEventData.clickTime = unscaledTime;
					pointerEventData.pointerDrag = P_1;
					num = 1131940819;
					continue;
				case 16:
				{
					float num2 = unscaledTime2 - pointerEventData.clickTime;
					if (num2 < 0.3f)
					{
						pointerEventData.clickCount++;
						num = 1131940822;
						continue;
					}
					goto case 6;
				}
				case 9:
					pointerEventData.pointerPress = gameObject;
					pointerEventData.rawPointerPress = P_1;
					pointerEventData.clickTime = unscaledTime2;
					pointerEventData.pointerDrag = P_1;
					num = 1131940818;
					continue;
				case 3:
					pointerEventData.delta = Vector2.zero;
					pointerEventData.dragging = false;
					pointerEventData.useDragThreshold = true;
					pointerEventData.pressPosition = pointerEventData.position;
					pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
					gameObject2 = P_1;
					num = 1131940825;
					continue;
				case 10:
					num = 1131940823;
					continue;
				case 15:
					pointerEventData.clickTime = unscaledTime;
					num = 1131940826;
					continue;
				case 21:
					pointerEventData.pointerEnter = P_1;
					num = 1131940816;
					continue;
				case 17:
					pointerEventData.clickCount = 1;
					num = 1131940817;
					continue;
				case 0:
					goto IL_02c0;
				case 7:
					unscaledTime = Time.unscaledTime;
					num = 1131940830;
					continue;
				case 14:
					gameObject = P_1;
					num = 1131940808;
					continue;
				default:
					goto IL_0300;
				case 12:
				case 13:
					return pointerEventData;
				}
				break;
				IL_02c0:
				int num4;
				if (!(gameObject2 == pointerEventData.lastPress))
				{
					num = 1131940812;
					num4 = num;
				}
				else
				{
					num = 1131940810;
					num4 = num;
				}
				continue;
				IL_0191:
				unscaledTime2 = Time.unscaledTime;
				int num5;
				if (gameObject == pointerEventData.lastPress)
				{
					num = 1131940814;
					num5 = num;
				}
				else
				{
					num = 1131940827;
					num5 = num;
				}
				continue;
				IL_0150:
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				int num6;
				if (!(pointerEventData.pointerEnter != P_1))
				{
					num = 1131940816;
					num6 = num;
				}
				else
				{
					num = 1131940811;
					num6 = num;
				}
			}
			goto IL_0044;
		}

		private PointerEventData YQzVKdtwLwSZvgQylBxBMwuutwg(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(P_0);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = P_1;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		private PointerEventData YmNTOnqdWUarvHWIAOOUMxyMuVXg(int P_0)
		{
			PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
			{
				pointerEventData.eligibleForClick = false;
				goto IL_001f;
			}
			goto IL_00c5;
			IL_00c5:
			int num;
			if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
			{
				pointerEventData.eligibleForClick = false;
				num = -419128284;
				goto IL_0024;
			}
			goto IL_00ea;
			IL_00ea:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			return null;
			IL_001f:
			num = -419128282;
			goto IL_0024;
			IL_0024:
			while (true)
			{
				switch (num ^ -419128283)
				{
				case 0:
					break;
				case 8:
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					goto case 4;
				case 5:
					pointerEventData.pointerEnter = null;
					num = -419128287;
					continue;
				case 1:
					pointerEventData.pointerPress = null;
					pointerEventData.rawPointerPress = null;
					num = -419128275;
					continue;
				case 3:
					pointerEventData.pointerPress = null;
					pointerEventData.rawPointerPress = null;
					num = -419128286;
					continue;
				case 7:
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					num = -419128288;
					continue;
				case 2:
					goto IL_00c5;
				default:
					goto IL_00ea;
				case 4:
					return pointerEventData;
				}
				break;
			}
			goto IL_001f;
		}

		private void uhbxZnhdAiTocMkidbifwylOKNg(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				YmNTOnqdWUarvHWIAOOUMxyMuVXg(effectivePointerId);
			}
		}

		private PointerEventData eHumJbgUTelnpVVEEkJoClmMzSA(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (__fakePointerEventData == null)
			{
				__fakePointerEventData = new Dictionary<int, PointerEventData>();
				goto IL_001d;
			}
			goto IL_007e;
			IL_00f1:
			PointerEventData value = default(PointerEventData);
			return value;
			IL_007e:
			int num;
			if (!__fakePointerEventData.TryGetValue(P_0, out value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				num = -1281782845;
				goto IL_0022;
			}
			goto IL_00f1;
			IL_001d:
			num = -1281782841;
			goto IL_0022;
			IL_0022:
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			while (true)
			{
				switch (num ^ -1281782846)
				{
				case 0:
					break;
				case 3:
					button = PointerEventData.InputButton.Right;
					num = -1281782838;
					continue;
				case 6:
					throw new NotImplementedException();
				case 4:
					goto IL_006c;
				case 2:
					goto IL_0075;
				case 5:
					goto IL_007e;
				case 8:
					value.button = button;
					num = -1281782843;
					continue;
				case 1:
					__fakePointerEventData.Add(P_0, value);
					if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
					{
						switch (P_0)
						{
						case -2:
							break;
						case -1:
							goto IL_006c;
						case -3:
							goto IL_0075;
						default:
							goto IL_00e7;
						}
						goto case 3;
					}
					goto IL_00f1;
				default:
					goto IL_00f1;
					IL_00e7:
					num = -1281782844;
					continue;
					IL_0075:
					button = PointerEventData.InputButton.Middle;
					num = -1281782838;
					continue;
					IL_006c:
					button = PointerEventData.InputButton.Left;
					num = -1281782838;
					continue;
				}
				break;
			}
			goto IL_001d;
		}
	}
}
