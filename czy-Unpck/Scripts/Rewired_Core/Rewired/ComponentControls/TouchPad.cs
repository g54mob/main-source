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
	[AddComponentMenu("Rewired/Touch Pad")]
	[RequireComponent(typeof(Image))]
	[DisallowMultipleComponent]
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

		private class jUVsKMNAVSWxpCZInuNQIYraABA
		{
			private class OGpnugPIDxpreYPuCakcHErzGykG
			{
				public float rattTiJVMfrlkuegiThkhLtmwyl;

				public float ZNmiScpIVNoaJXUmXRGYlfkADLj;

				public uint ogijnMsRdWFOeWGzredaGuetbTLC;
			}

			private int oKRENyTIKHbPMHAVJyAMivVJKRt;

			private OGpnugPIDxpreYPuCakcHErzGykG[] HjhAZUJqXlQPwmwSuTtFHNgXuzt;

			private int VXgPrLiRFgJCxmeSHMjaqdvOBgr = -1;

			public jUVsKMNAVSWxpCZInuNQIYraABA(int maxSmoothFrames)
			{
				if (maxSmoothFrames < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				oKRENyTIKHbPMHAVJyAMivVJKRt = maxSmoothFrames;
				HjhAZUJqXlQPwmwSuTtFHNgXuzt = new OGpnugPIDxpreYPuCakcHErzGykG[maxSmoothFrames];
				ArrayTools.Populate(HjhAZUJqXlQPwmwSuTtFHNgXuzt);
			}

			public void KyHpjvRkJIBKWzDbtHSSnZwunyW(float P_0, float P_1)
			{
				uint currentFrame = ReInput.currentFrame;
				if (VXgPrLiRFgJCxmeSHMjaqdvOBgr >= 0 && HjhAZUJqXlQPwmwSuTtFHNgXuzt[VXgPrLiRFgJCxmeSHMjaqdvOBgr].ogijnMsRdWFOeWGzredaGuetbTLC == currentFrame)
				{
					return;
				}
				while (true)
				{
					MuVtGvZkhDdmvGbxgYyTKMOalWWB();
					OGpnugPIDxpreYPuCakcHErzGykG oGpnugPIDxpreYPuCakcHErzGykG = HjhAZUJqXlQPwmwSuTtFHNgXuzt[VXgPrLiRFgJCxmeSHMjaqdvOBgr];
					oGpnugPIDxpreYPuCakcHErzGykG.rattTiJVMfrlkuegiThkhLtmwyl = P_0;
					oGpnugPIDxpreYPuCakcHErzGykG.ZNmiScpIVNoaJXUmXRGYlfkADLj = P_1;
					oGpnugPIDxpreYPuCakcHErzGykG.ogijnMsRdWFOeWGzredaGuetbTLC = currentFrame;
					int num = 30968994;
					while (true)
					{
						switch (num ^ 0x1D88CA3)
						{
						case 0:
							goto IL_0025;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0025:
						num = 30968993;
					}
				}
			}

			public Vector2 CbqPbrFmeFhKRaihBafMhQRQNRdv()
			{
				if (VXgPrLiRFgJCxmeSHMjaqdvOBgr < 0)
				{
					return default(Vector2);
				}
				int vXgPrLiRFgJCxmeSHMjaqdvOBgr = VXgPrLiRFgJCxmeSHMjaqdvOBgr;
				OGpnugPIDxpreYPuCakcHErzGykG oGpnugPIDxpreYPuCakcHErzGykG = HjhAZUJqXlQPwmwSuTtFHNgXuzt[vXgPrLiRFgJCxmeSHMjaqdvOBgr];
				Vector2 result = new Vector2(oGpnugPIDxpreYPuCakcHErzGykG.rattTiJVMfrlkuegiThkhLtmwyl, oGpnugPIDxpreYPuCakcHErzGykG.ZNmiScpIVNoaJXUmXRGYlfkADLj);
				uint ogijnMsRdWFOeWGzredaGuetbTLC = oGpnugPIDxpreYPuCakcHErzGykG.ogijnMsRdWFOeWGzredaGuetbTLC;
				int num = vXgPrLiRFgJCxmeSHMjaqdvOBgr;
				OGpnugPIDxpreYPuCakcHErzGykG oGpnugPIDxpreYPuCakcHErzGykG2 = default(OGpnugPIDxpreYPuCakcHErzGykG);
				int num3 = default(int);
				while (true)
				{
					int num2 = 1078867481;
					while (true)
					{
						switch (num2 ^ 0x404E361A)
						{
						case 2:
							break;
						case 1:
							result.y += oGpnugPIDxpreYPuCakcHErzGykG2.ZNmiScpIVNoaJXUmXRGYlfkADLj;
							ogijnMsRdWFOeWGzredaGuetbTLC = oGpnugPIDxpreYPuCakcHErzGykG2.ogijnMsRdWFOeWGzredaGuetbTLC;
							num2 = 1078867486;
							continue;
						case 5:
							oGpnugPIDxpreYPuCakcHErzGykG2 = HjhAZUJqXlQPwmwSuTtFHNgXuzt[num];
							if (JbuZYzoKrLfuAzPgviaOxIKQFrr(oGpnugPIDxpreYPuCakcHErzGykG2.ogijnMsRdWFOeWGzredaGuetbTLC, ogijnMsRdWFOeWGzredaGuetbTLC))
							{
								result.x += oGpnugPIDxpreYPuCakcHErzGykG2.rattTiJVMfrlkuegiThkhLtmwyl;
								num2 = 1078867483;
								continue;
							}
							goto case 7;
						case 0:
						{
							int num4;
							if ((num = LiQLqZLQlrhoqAoxcYIivSXdTQo(num, oKRENyTIKHbPMHAVJyAMivVJKRt)) == vXgPrLiRFgJCxmeSHMjaqdvOBgr)
							{
								num2 = 1078867485;
								num4 = num2;
							}
							else
							{
								num2 = 1078867487;
								num4 = num2;
							}
							continue;
						}
						case 4:
							num3++;
							num2 = 1078867482;
							continue;
						case 7:
							if (num3 > 0)
							{
								result.x /= num3;
								result.y /= num3;
								num2 = 1078867484;
								continue;
							}
							goto default;
						case 3:
							num3 = 1;
							num2 = 1078867482;
							continue;
						default:
							return result;
						}
						break;
					}
				}
			}

			private void MuVtGvZkhDdmvGbxgYyTKMOalWWB()
			{
				VXgPrLiRFgJCxmeSHMjaqdvOBgr = yqPoFarEMiUiivanDSTKBtNqPhW(VXgPrLiRFgJCxmeSHMjaqdvOBgr, oKRENyTIKHbPMHAVJyAMivVJKRt);
			}

			private static int yqPoFarEMiUiivanDSTKBtNqPhW(int P_0, int P_1)
			{
				if (P_0 >= P_1 - 1)
				{
					return 0;
				}
				return ++P_0;
			}

			private int LiQLqZLQlrhoqAoxcYIivSXdTQo(int P_0, int P_1)
			{
				if (P_0 > 0)
				{
					return --P_0;
				}
				return P_1 - 1;
			}

			private static bool JbuZYzoKrLfuAzPgviaOxIKQFrr(uint P_0, uint P_1)
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
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's X axis.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's Y axis.")]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from touch pad taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from touch pad presses.")]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		private AxisDirection _axesToUse;

		[SerializeField]
		[Tooltip("The mode of the touch pad.\n\nDelta - Returns the change in position of the touch from the previous to the current frame.\n\nScreen Position - Returns the absolute position of the touch  on the screen.\n\nVector From Center - Returns a vector from the center of the Touch Pad to the current touch position.\n\nVector From Initial Touch - Returns a vector from the intial touch position to the current touch position.")]
		[CustomObfuscation(rename = false)]
		private TouchPadMode _touchPadMode;

		[CustomObfuscation(rename = false)]
		[Tooltip("The format of the resulting data generated by the touch pad.\n\nPixels - Screen pixels.\n\nScreen - The proportion of the value to screen size in the corresponding dimension. 1 unit = 1 screen length (width for X, height for Y).\n\nPhysical - 1 unit = 1/100th of an inch. The resulting value will be consistent across different screen resolutions and sizes. IMPORTANT: This relies on the value returned by UnityEngine.Screen.dpi. If the device does not return a value, a reference resolution of 96 dpi will be used.\n\nDirection - A normalized direction vector.")]
		[SerializeField]
		private ValueFormat _valueFormat;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		private bool _useInertia;

		[FieldRange(0f, float.MaxValue)]
		[SerializeField]
		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		[CustomObfuscation(rename = false)]
		private float _inertiaFriction = 3f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Should taps on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		private float _tapTimeout = 0.25f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		private int _tapDistanceLimit = 10;

		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _allowPress;

		[SerializeField]
		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		[CustomObfuscation(rename = false)]
		private float _pressStartDelay = 0.1f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		[FieldRange(-1, int.MaxValue)]
		private int _pressDistanceLimit = 10;

		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _hideAtRuntime;

		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the value changes.")]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		private TapEventHandler _onTap = new TapEventHandler();

		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PressDownEventHandler _onPressDown = new PressDownEventHandler();

		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PressUpEventHandler _onPressUp = new PressUpEventHandler();

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool deteGKFsUpKVtiobsxDnfbVWHkL;

		[NonSerialized]
		private bool IflsmAOKUdJKTpCZjpeDsuqZbjM;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private jUVsKMNAVSWxpCZInuNQIYraABA _smoothDelta = new jUVsKMNAVSWxpCZInuNQIYraABA(3);

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement => _horizontalAxisCustomControllerElement;

		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement => _verticalAxisCustomControllerElement;

		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement => _tapCustomControllerElement;

		public CustomControllerElementTargetSetForBoolean pressCustomControllerElement => _pressCustomControllerElement;

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
					while (true)
					{
						switch (0x4ED7AF00 ^ 0x4ED7AF02)
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					return;
				}
				while (true)
				{
					_valueFormat = value;
					int num = 549607091;
					while (true)
					{
						switch (num ^ 0x20C256B3)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000a:
						num = 549607090;
					}
				}
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
				if (_useInertia != value)
				{
					_useInertia = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
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
				if (_inertiaFriction == value)
				{
					while (true)
					{
						switch (-1822690552 ^ -1822690550)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_inertiaFriction = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					int num = -832631650;
					while (true)
					{
						switch (num ^ -832631650)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000a:
						num = -832631649;
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
					while (true)
					{
						switch (-89748100 ^ -89748099)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_stayActiveOnSwipeOut = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					int num = 1060530130;
					while (true)
					{
						switch (num ^ 0x3F3667D0)
						{
						case 0:
							num = 1060530129;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = 1060530131;
							continue;
						case 3:
							return;
						}
						break;
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
				if (_tapTimeout != value)
				{
					_tapTimeout = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
				}
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
				if (_tapDistanceLimit == value)
				{
					goto IL_0012;
				}
				goto IL_003c;
				IL_0012:
				int num = 594801359;
				goto IL_0017;
				IL_0017:
				switch (num ^ 0x2373F2CC)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					return;
				case 0:
					goto IL_003c;
				case 1:
					return;
				}
				goto IL_0012;
				IL_003c:
				_tapDistanceLimit = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
				num = 594801357;
				goto IL_0017;
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
				if (_allowPress == value)
				{
					while (true)
					{
						switch (-1287727027 ^ -1287727028)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_allowPress = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
				value = Mathf.Max(0f, value);
				if (_pressStartDelay == value)
				{
					return;
				}
				while (true)
				{
					_pressStartDelay = value;
					int num = 388779307;
					while (true)
					{
						switch (num ^ 0x172C4D29)
						{
						case 0:
							goto IL_0017;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_0017:
						num = 388779304;
					}
				}
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
				while (true)
				{
					switch (-1323511760 ^ -1323511758)
					{
					case 0:
						continue;
					case 2:
						if (_pressDistanceLimit == value)
						{
							return;
						}
						break;
					}
					break;
				}
				_pressDistanceLimit = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_hideAtRuntime = value)
				{
					return;
				}
				while (true)
				{
					_hideAtRuntime = true;
					int num = 1490985583;
					while (true)
					{
						switch (num ^ 0x58DEA26D)
						{
						case 0:
							goto IL_000d;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000d:
						num = 1490985580;
					}
				}
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

		public bool hasPointer => _pointerId != int.MinValue;

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
				if (!TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
				{
					return Vector2.zero;
				}
				return TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(effectivePointerId);
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D axis2D => _axis2D;

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

		private bool tapValue => _lastTapFrame == Time.frameCount;

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
			while (true)
			{
				int num = -196880684;
				while (true)
				{
					switch (num ^ -196880683)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						if (!Application.isPlaying)
						{
							return;
						}
						goto case 0;
					case 0:
						if (_hideAtRuntime)
						{
							goto IL_003f;
						}
						return;
					case 2:
						return;
					}
					break;
					IL_003f:
					base.visible = false;
					num = -196880681;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				xsDgFyTZvEgtPjzlBqGOyLVzBoa();
				NPOFSRfAiJHJstoMPmTkHgTRYCc();
			}
		}

		internal override bool KeoQNyZvcuilfnGKgmHgqyJYGhr()
		{
			if (!base.KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				return false;
			}
			xsDgFyTZvEgtPjzlBqGOyLVzBoa();
			return true;
		}

		internal override void spiCZIbBixHwkYmPEBFXAXTGsXtO()
		{
			base.spiCZIbBixHwkYmPEBFXAXTGsXtO();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				XQGfZDfjhHBqlsRSwZXkemarOYM();
				int num = -904104752;
				while (true)
				{
					switch (num ^ -904104751)
					{
					case 0:
						num = -904104749;
						continue;
					case 2:
						break;
					case 1:
						UcvgzyHjPLrcamsdZskkPOQcONwi();
						TZChncINkPJVfokwTjyOSQNKJuW();
						ADIiWPybTGlyArqStKpAcoHdEvc();
						num = -904104750;
						continue;
					default:
						TvwaCvgDyOcBugmwEQRUaEnCyoCv();
						return;
					}
					break;
				}
			}
		}

		internal override void KhATpHHLaxfVykPnYPwsOWKYpr()
		{
			if (!base.initialized)
			{
				goto IL_000b;
			}
			goto IL_0123;
			IL_000b:
			int num = 348038385;
			goto IL_0010;
			IL_0010:
			Vector2 vector = default(Vector2);
			while (true)
			{
				switch (num ^ 0x14BEA4F0)
				{
				case 2:
					break;
				default:
					return;
				case 6:
					if (_useYAxis)
					{
						fcpMokSOSPSkfIoeTHjUJvvymMbi(_verticalAxisCustomControllerElement, vector.y, _axis2D.xAxis.buttonActivationThreshold);
						num = 348038393;
						continue;
					}
					goto case 9;
				case 9:
					if (_allowTap)
					{
						fcpMokSOSPSkfIoeTHjUJvvymMbi(_tapCustomControllerElement, tapValue);
						num = 348038388;
						continue;
					}
					goto IL_00c9;
				case 10:
					return;
				case 8:
					fcpMokSOSPSkfIoeTHjUJvvymMbi(_pressCustomControllerElement, _pressValue);
					num = 348038387;
					continue;
				case 4:
					goto IL_00c9;
				case 5:
					goto IL_00e5;
				case 0:
					goto IL_0123;
				case 7:
					fcpMokSOSPSkfIoeTHjUJvvymMbi(_horizontalAxisCustomControllerElement, vector.x, _axis2D.xAxis.buttonActivationThreshold);
					num = 348038390;
					continue;
				case 1:
					return;
				case 3:
					return;
				}
				break;
				IL_00e5:
				vector = ((_touchPadMode == TouchPadMode.ScreenPosition) ? _axis2D.rawValue : _axis2D.value);
				int num2;
				if (_useXAxis)
				{
					num = 348038391;
					num2 = num;
				}
				else
				{
					num = 348038390;
					num2 = num;
				}
				continue;
				IL_00c9:
				int num3;
				if (!_allowPress)
				{
					num = 348038387;
					num3 = num;
				}
				else
				{
					num = 348038392;
					num3 = num;
				}
			}
			goto IL_000b;
			IL_0123:
			int num4;
			if (hasController)
			{
				num = 348038389;
				num4 = num;
			}
			else
			{
				num = 348038394;
				num4 = num;
			}
			goto IL_0010;
		}

		internal override void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			base.wWklIWMVIReShFCdZhfAVVyDQgX();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				xsDgFyTZvEgtPjzlBqGOyLVzBoa();
				int num = -724810275;
				while (true)
				{
					switch (num ^ -724810274)
					{
					case 2:
						num = -724810273;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
						num = -724810274;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal override void QBogclsViwEODeiCNJnFOileABHD()
		{
			base.QBogclsViwEODeiCNJnFOileABHD();
			if (base.initialized)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				deteGKFsUpKVtiobsxDnfbVWHkL = false;
				IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
				_pointerDownIsFake = false;
				_currentCenter = Vector2.zero;
				_previousTouchPosition = Vector2.zero;
				_axis2D.Clear();
				_lastTapFrame = -1;
				_pressValue = false;
				_isEligibleForTap = false;
				_isEligibleForPress = false;
			}
		}

		public override void ClearValue()
		{
			if (!base.initialized)
			{
				goto IL_000b;
			}
			goto IL_00b6;
			IL_000b:
			int num = -1606178156;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ -1606178153)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					_pressValue = false;
					num = -1606178155;
					continue;
				case 4:
					base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
					num = -1606178159;
					continue;
				case 3:
					return;
				case 6:
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
					base.controller.ClearElementValue(_tapCustomControllerElement);
					num = -1606178160;
					continue;
				case 2:
					goto IL_009a;
				case 5:
					goto IL_00b6;
				case 7:
					return;
				}
				break;
				IL_009a:
				int num2;
				if (!hasController)
				{
					num = -1606178160;
					num2 = num;
				}
				else
				{
					num = -1606178157;
					num2 = num;
				}
			}
			goto IL_000b;
			IL_00b6:
			_axis2D.Clear();
			_lastTapFrame = -1;
			num = -1606178154;
			goto IL_0010;
		}

		private void NPOFSRfAiJHJstoMPmTkHgTRYCc()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			_pressCustomControllerElement.ClearElementCaches();
		}

		private void xsDgFyTZvEgtPjzlBqGOyLVzBoa()
		{
			hHbXGUYunkblaqblvHADFikMHzF(_axesToUse);
			if (!hasController)
			{
				return;
			}
			while (base.touchController.useCustomController)
			{
				while (true)
				{
					IL_0066:
					int num;
					if (_useXAxis)
					{
						base.controller.ValidateElements(_horizontalAxisCustomControllerElement);
						num = -1204490013;
						goto IL_001d;
					}
					goto IL_004d;
					IL_001d:
					while (true)
					{
						switch (num ^ -1204490010)
						{
						case 3:
							num = -1204490009;
							continue;
						default:
							return;
						case 5:
							break;
						case 6:
							goto IL_0066;
						case 7:
							if (_allowPress)
							{
								base.controller.ValidateElements(_pressCustomControllerElement);
								num = -1204490014;
								continue;
							}
							return;
						case 2:
							base.controller.ValidateElements(_verticalAxisCustomControllerElement);
							num = -1204490010;
							continue;
						case 0:
							if (_allowTap)
							{
								base.controller.ValidateElements(_tapCustomControllerElement);
								num = -1204490015;
								continue;
							}
							goto case 7;
						case 1:
							goto end_IL_0066;
						case 4:
							return;
						}
						break;
					}
					goto IL_004d;
					IL_004d:
					int num2;
					if (_useYAxis)
					{
						num = -1204490012;
						num2 = num;
					}
					else
					{
						num = -1204490010;
						num2 = num;
					}
					goto IL_001d;
					continue;
					end_IL_0066:
					break;
				}
			}
		}

		private void hHbXGUYunkblaqblvHADFikMHzF(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			bool flag2 = default(bool);
			while (true)
			{
				int num = 1988364830;
				while (true)
				{
					switch (num ^ 0x76840A1D)
					{
					case 5:
						break;
					case 3:
						if (_useXAxis != flag)
						{
							_useXAxis = flag;
							if (!flag)
							{
								int num2;
								if (hasController)
								{
									num = 1988364825;
									num2 = num;
								}
								else
								{
									num = 1988364828;
									num2 = num;
								}
								continue;
							}
						}
						goto case 1;
					case 0:
						if (!flag2 && hasController)
						{
							base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
							num = 1988364831;
							continue;
						}
						goto default;
					case 1:
						flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
						if (_useYAxis != flag2)
						{
							_useYAxis = flag2;
							num = 1988364829;
							continue;
						}
						goto default;
					case 4:
						base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
						num = 1988364828;
						continue;
					default:
						_axesToUse = P_0;
						return;
					}
					break;
				}
			}
		}

		private void UcvgzyHjPLrcamsdZskkPOQcONwi()
		{
			if (!hasPointer)
			{
				return;
			}
			while (!TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
			{
				PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(effectivePointerId);
				int num = -1284226114;
				while (true)
				{
					switch (num ^ -1284226113)
					{
					case 0:
						num = -1284226117;
						continue;
					default:
						return;
					case 2:
						lpCghgdvtFwpLBkUsSpPyavhpiK();
						num = -1284226116;
						continue;
					case 1:
						if (pointerEventData != null && pointerEventData.pointerPress != null)
						{
							yexpQprndcKAWRDGCPOiDjHZJQS(pointerEventData);
							return;
						}
						goto case 2;
					case 4:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void TZChncINkPJVfokwTjyOSQNKJuW()
		{
			object obj;
			if (_touchPadMode == TouchPadMode.VectorFromCenter)
			{
				Graphic graphic = base.targetGraphic;
				if (!(graphic != null))
				{
					goto IL_001f;
				}
				obj = graphic.transform as RectTransform;
				goto IL_0102;
			}
			goto IL_013e;
			IL_00ef:
			obj = base.rectTransform;
			goto IL_0102;
			IL_013e:
			if (!hasPointer)
			{
				return;
			}
			int num;
			int num2;
			if (!TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
			{
				num = -577184166;
				num2 = num;
			}
			else
			{
				num = -577184167;
				num2 = num;
			}
			goto IL_0024;
			IL_001f:
			num = -577184162;
			goto IL_0024;
			IL_0024:
			Vector2 vector2 = default(Vector2);
			Vector3 vector = default(Vector3);
			while (true)
			{
				switch (num ^ -577184168)
				{
				case 8:
					break;
				case 2:
					return;
				case 11:
					vector2 = new Vector2(vector.x - _currentCenter.x, vector.y - _currentCenter.y);
					num = -577184168;
					continue;
				case 0:
					vector2 = HuAaPaEidSreUqvRdROYLpdVPAIm(vector2);
					_axis2D.SetRawValue(vector2.x, vector2.y);
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_smoothDelta.KyHpjvRkJIBKWzDbtHSSnZwunyW(vector2.x, vector2.y);
						num = -577184174;
						continue;
					}
					goto default;
				case 6:
					goto IL_00ef;
				case 4:
					vector2 = vector;
					num = -577184161;
					continue;
				case 5:
					goto IL_013e;
				case 9:
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_currentCenter = _previousTouchPosition;
						num = -577184173;
						continue;
					}
					goto case 11;
				case 3:
					_currentCenter = RectTransformUtility.WorldToScreenPoint(base.canvas.worldCamera, _currentCenter);
					num = -577184163;
					continue;
				case 7:
					num = -577184168;
					continue;
				case 1:
					goto IL_01c5;
				default:
					_previousTouchPosition = vector;
					return;
				}
				break;
				IL_01c5:
				vector = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(effectivePointerId);
				int num3;
				if (_touchPadMode == TouchPadMode.ScreenPosition)
				{
					num = -577184164;
					num3 = num;
				}
				else
				{
					num = -577184175;
					num3 = num;
				}
			}
			goto IL_001f;
			IL_0102:
			RectTransform rectTransform = (RectTransform)obj;
			_currentCenter = rectTransform.TransformPoint(rectTransform.rect.center);
			num = -577184165;
			goto IL_0024;
		}

		private void ADIiWPybTGlyArqStKpAcoHdEvc()
		{
			if (_touchPadMode == TouchPadMode.Delta)
			{
				if (!_useInertia)
				{
					goto IL_0013;
				}
				goto IL_0080;
			}
			return;
			IL_0080:
			int num;
			int num2;
			if (hasPointer)
			{
				num = -184833452;
				num2 = num;
			}
			else
			{
				num = -184833454;
				num2 = num;
			}
			goto IL_0018;
			IL_0013:
			num = -184833456;
			goto IL_0018;
			IL_0018:
			float num4 = default(float);
			Vector2 rawValue = default(Vector2);
			float smoothDeltaTime = default(float);
			float num3 = default(float);
			while (true)
			{
				switch (num ^ -184833449)
				{
				case 8:
					break;
				case 1:
					num4 = Mathf.Lerp(rawValue.y, 0f, _inertiaFriction * smoothDeltaTime);
					if (MathTools.IsNearZero(num3, 0.0001f))
					{
						num3 = 0f;
						num = -184833453;
						continue;
					}
					goto IL_00b2;
				case 0:
					goto IL_0080;
				case 7:
					return;
				case 3:
					return;
				case 4:
					goto IL_00b2;
				case 5:
					rawValue = _axis2D.rawValue;
					smoothDeltaTime = Time.smoothDeltaTime;
					num3 = Mathf.Lerp(rawValue.x, 0f, _inertiaFriction * smoothDeltaTime);
					num = -184833450;
					continue;
				case 6:
					num4 = 0f;
					num = -184833451;
					continue;
				default:
					_axis2D.SetRawValue(num3, num4);
					return;
				}
				break;
				IL_00b2:
				int num5;
				if (!MathTools.IsNearZero(num4, 0.0001f))
				{
					num = -184833451;
					num5 = num;
				}
				else
				{
					num = -184833455;
					num5 = num;
				}
			}
			goto IL_0013;
		}

		private void XQGfZDfjhHBqlsRSwZXkemarOYM()
		{
			if (!hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = 1503121847;
			goto IL_000d;
			IL_000d:
			Vector2 vector = default(Vector2);
			while (true)
			{
				switch (num ^ 0x5997D1B6)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 0:
					goto IL_0036;
				case 2:
					MZnShJUPKxQCCvuSSmPZguIOohN(ref vector);
					num = 1503121842;
					continue;
				case 4:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0036:
			vector = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(effectivePointerId);
			hmpcDbRPfUQzhTrCSArvmjJPrsM(ref vector);
			num = 1503121844;
			goto IL_000d;
		}

		private void hmpcDbRPfUQzhTrCSArvmjJPrsM(ref Vector2 P_0)
		{
			if (_allowTap)
			{
				if (!_isEligibleForTap)
				{
					goto IL_0010;
				}
				goto IL_0084;
			}
			return;
			IL_003a:
			int num;
			if (_tapDistanceLimit >= 0)
			{
				int num2;
				if (Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)
				{
					num = -290972111;
					num2 = num;
				}
				else
				{
					num = -290972108;
					num2 = num;
				}
				goto IL_0015;
			}
			return;
			IL_0010:
			num = -290972112;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -290972107)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					goto IL_003a;
				case 4:
					_isEligibleForTap = false;
					num = -290972108;
					continue;
				case 5:
					return;
				case 2:
					goto IL_0084;
				case 1:
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0084:
			if (_tapTimeout > 0f)
			{
				int num3;
				if (!(Time.realtimeSinceStartup - _touchStartTime > _tapTimeout))
				{
					num = -290972106;
					num3 = num;
				}
				else
				{
					num = -290972111;
					num3 = num;
				}
				goto IL_0015;
			}
			goto IL_003a;
		}

		private void MZnShJUPKxQCCvuSSmPZguIOohN(ref Vector2 P_0)
		{
			if (_allowPress)
			{
				if (!_isEligibleForPress)
				{
					goto IL_0010;
				}
				goto IL_007a;
			}
			return;
			IL_0042:
			if (_pressStartDelay > 0f && Time.realtimeSinceStartup - _touchStartTime < _pressStartDelay)
			{
				return;
			}
			goto IL_00ae;
			IL_0010:
			int num = -1058461888;
			goto IL_0015;
			IL_0015:
			switch (num ^ -1058461887)
			{
			case 5:
				break;
			case 1:
				return;
			case 4:
				goto IL_0042;
			case 3:
				tLpeNekAEQDmCANvgNerHjQaDLHq(false);
				return;
			case 2:
				goto IL_007a;
			default:
				goto IL_00ae;
			}
			goto IL_0010;
			IL_007a:
			if (_pressDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_pressDistanceLimit)
			{
				_isEligibleForPress = false;
				num = -1058461886;
				goto IL_0015;
			}
			goto IL_0042;
			IL_00ae:
			tLpeNekAEQDmCANvgNerHjQaDLHq(true);
		}

		private void TvwaCvgDyOcBugmwEQRUaEnCyoCv()
		{
			if (_touchPadMode == TouchPadMode.Delta)
			{
				goto IL_000b;
			}
			goto IL_00c1;
			IL_000b:
			int num = -307104310;
			goto IL_0010;
			IL_0010:
			Vector2 valueDelta = default(Vector2);
			while (true)
			{
				Vector2 valuePrev;
				switch (num ^ -307104305)
				{
				case 0:
					break;
				default:
					return;
				case 5:
				{
					Vector2 value = _axis2D.value;
					valuePrev = _axis2D.valuePrev;
					if (value.x == 0f && value.y == 0f && valuePrev.x == 0f)
					{
						goto IL_007e;
					}
					goto case 6;
				}
				case 6:
					_onValueChanged.Invoke(_axis2D.value);
					return;
				case 4:
					goto IL_00c1;
				case 3:
					goto IL_00ef;
				case 2:
					_onValueChanged.Invoke(_axis2D.value);
					num = -307104306;
					continue;
				case 1:
					return;
				}
				break;
				IL_00ef:
				int num2;
				if (valueDelta.y == 0f)
				{
					num = -307104306;
					num2 = num;
				}
				else
				{
					num = -307104307;
					num2 = num;
				}
				continue;
				IL_007e:
				int num3;
				if (valuePrev.y == 0f)
				{
					num = -307104306;
					num3 = num;
				}
				else
				{
					num = -307104311;
					num3 = num;
				}
			}
			goto IL_000b;
			IL_00c1:
			valueDelta = _axis2D.valueDelta;
			int num4;
			if (valueDelta.x != 0f)
			{
				num = -307104307;
				num4 = num;
			}
			else
			{
				num = -307104308;
				num4 = num;
			}
			goto IL_0010;
		}

		private Vector2 HuAaPaEidSreUqvRdROYLpdVPAIm(Vector2 P_0)
		{
			int num;
			float num2 = default(float);
			switch (_valueFormat)
			{
			case ValueFormat.Direction:
				P_0.Normalize();
				num = 440670007;
				goto IL_0024;
			default:
				goto IL_009a;
			case ValueFormat.Physical:
				goto IL_00c7;
			case ValueFormat.Screen:
				goto IL_00d7;
			case ValueFormat.Pixels:
				break;
				IL_0024:
				while (true)
				{
					switch (num ^ 0x1A441732)
					{
					case 7:
						num = 440670000;
						continue;
					case 4:
						if (num2 < 10f)
						{
							num2 = 96f;
							num = 440670011;
							continue;
						}
						goto case 9;
					case 6:
						break;
					case 1:
						P_0.y /= Screen.height;
						num = 440670010;
						continue;
					case 0:
						goto IL_009a;
					case 9:
						P_0 = P_0 / num2 * 100f;
						num = 440670010;
						continue;
					case 3:
						goto IL_00c7;
					case 2:
						goto IL_00d7;
					case 5:
						num = 440670010;
						continue;
					default:
						goto end_IL_0008;
					}
					break;
				}
				goto case ValueFormat.Direction;
				IL_00d7:
				P_0.x /= Screen.width;
				num = 440670003;
				goto IL_0024;
				IL_00c7:
				num2 = Screen.dpi;
				num = 440670006;
				goto IL_0024;
				IL_009a:
				throw new NotImplementedException();
				end_IL_0008:
				break;
			}
			return P_0;
		}

		private void tLpeNekAEQDmCANvgNerHjQaDLHq(bool P_0)
		{
			if (P_0 == _pressValue)
			{
				return;
			}
			while (true)
			{
				_pressValue = P_0;
				if (!P_0)
				{
					break;
				}
				_onPressDown.Invoke();
				int num = -826535552;
				while (true)
				{
					switch (num ^ -826535549)
					{
					case 0:
						num = -826535550;
						continue;
					case 1:
						break;
					case 3:
						return;
					default:
						goto end_IL_002c;
					}
					break;
				}
				continue;
				end_IL_002c:
				break;
			}
			_onPressUp.Invoke();
		}

		private void VMPxCmwNDckEZjKzFAfOOLwMEyj(PointerEventData P_0)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				goto IL_0016;
			}
			goto IL_0061;
			IL_0061:
			int num;
			int num2;
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				num = 632203376;
				num2 = num;
			}
			else
			{
				num = 632203379;
				num2 = num;
			}
			goto IL_001b;
			IL_0016:
			num = 632203378;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ 0x25AEA870)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					if (IsInteractable())
					{
						qttGoWavQZHOZLyJsMtdmpSFVQLR(P_0.pointerId, P_0.pressPosition);
						num = 632203376;
						continue;
					}
					goto case 0;
				case 1:
					goto IL_0061;
				case 0:
					base.OnPointerDown(P_0);
					num = 632203380;
					continue;
				case 2:
					return;
				case 4:
					return;
				}
				break;
			}
			goto IL_0016;
		}

		private void gkFDUotSecrQghkuzcszQbTklVO(PointerEventData P_0)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				while (true)
				{
					switch (0x1FCE4123 ^ 0x1FCE4121)
					{
					case 0:
						break;
					case 2:
						return;
					case 3:
						goto end_IL_0016;
					default:
						goto IL_0055;
					}
					continue;
					end_IL_0016:
					break;
				}
			}
			if (TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
			{
				return;
			}
			goto IL_0055;
			IL_0055:
			lpCghgdvtFwpLBkUsSpPyavhpiK();
			base.OnPointerUp(P_0);
		}

		private void yVatkfTlebiCIFaVPbRrioxyjVJ(PointerEventData P_0)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				return;
			}
			bool flag2 = default(bool);
			PointerEventData pointerEventData = default(PointerEventData);
			while (true)
			{
				bool flag = TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0.pointerId);
				int num = -609057469;
				while (true)
				{
					switch (num ^ -609057466)
					{
					case 0:
						num = -609057468;
						continue;
					case 2:
						break;
					case 9:
					{
						int num2;
						if (pmYjhUyltIKROfKAKRLTAORpQYO())
						{
							num = -609057471;
							num2 = num;
						}
						else
						{
							num = -609057465;
							num2 = num;
						}
						continue;
					}
					case 3:
					{
						int num5;
						if (!flag2)
						{
							num = -609057458;
							num5 = num;
						}
						else
						{
							num = -609057460;
							num5 = num;
						}
						continue;
					}
					case 10:
					{
						GameObject gameObject = base.gameObject;
						pointerEventData = VeJANUaZIhfuukBBgCAhDSXJcuGp((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
						int num3;
						if (pointerEventData == null)
						{
							num = -609057458;
							num3 = num;
						}
						else
						{
							num = -609057459;
							num3 = num;
						}
						continue;
					}
					case 11:
						VMPxCmwNDckEZjKzFAfOOLwMEyj(pointerEventData);
						if (deteGKFsUpKVtiobsxDnfbVWHkL)
						{
							_pointerDownIsFake = true;
							num = -609057458;
							continue;
						}
						goto default;
					case 4:
						flag2 = true;
						num = -609057465;
						continue;
					case 12:
						_realMousePointerId = P_0.pointerId;
						num = -609057470;
						continue;
					case 1:
						base.OnPointerEnter(P_0);
						num = -609057467;
						continue;
					case 5:
					{
						flag2 = false;
						int num4;
						if (_activateOnSwipeIn)
						{
							num = -609057457;
							num4 = num;
						}
						else
						{
							num = -609057465;
							num4 = num;
						}
						continue;
					}
					case 6:
						if (!deteGKFsUpKVtiobsxDnfbVWHkL)
						{
							if (!flag)
							{
								goto case 4;
							}
							if (TouchInteractable.uvgPsLARFwGrvuIJCgcCjshzWDCu(base.allowedMouseButtons, out var realMousePointerId))
							{
								_realMousePointerId = realMousePointerId;
								num = -609057470;
								continue;
							}
							goto case 12;
						}
						goto case 1;
					case 7:
						if (IsInteractable())
						{
							if (!flag)
							{
								num = -609057472;
								continue;
							}
							if (TouchInteractable.oZwvzbhTHFLSrWQmffrxbbIJDii(base.allowedMouseButtons))
							{
								goto case 6;
							}
						}
						goto case 1;
					default:
						IflsmAOKUdJKTpCZjpeDsuqZbjM = true;
						return;
					}
					break;
				}
			}
		}

		private void UNMauMeXBncuatcyFyBICUuhBxd(PointerEventData P_0)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				goto IL_001d;
			}
			goto IL_0050;
			IL_0079:
			base.OnPointerExit(P_0);
			IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
			return;
			IL_0050:
			int num;
			if (!stayActiveOnSwipeOut)
			{
				int num2;
				if (deteGKFsUpKVtiobsxDnfbVWHkL)
				{
					num = 1330295178;
					num2 = num;
				}
				else
				{
					num = 1330295177;
					num2 = num;
				}
				goto IL_0022;
			}
			goto IL_0079;
			IL_001d:
			num = 1330295176;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ 0x4F4AB18B)
				{
				case 0:
					break;
				case 1:
					lpCghgdvtFwpLBkUsSpPyavhpiK();
					num = 1330295177;
					continue;
				case 4:
					goto IL_0050;
				case 3:
					return;
				default:
					goto IL_0079;
				}
				break;
			}
			goto IL_001d;
		}

		private void qttGoWavQZHOZLyJsMtdmpSFVQLR(int P_0, Vector2 P_1)
		{
			_pointerId = P_0;
			while (true)
			{
				int num = 350005796;
				while (true)
				{
					switch (num ^ 0x14DCAA25)
					{
					case 2:
						break;
					case 1:
						deteGKFsUpKVtiobsxDnfbVWHkL = true;
						_isEligibleForTap = true;
						_isEligibleForPress = true;
						if (_touchPadMode != TouchPadMode.VectorFromCenter)
						{
							_currentCenter = P_1;
							num = 350005798;
							continue;
						}
						goto case 3;
					case 3:
					{
						int num2;
						if (_touchPadMode == TouchPadMode.Delta)
						{
							num = 350005793;
							num2 = num;
						}
						else
						{
							num = 350005797;
							num2 = num;
						}
						continue;
					}
					case 4:
						_previousTouchPosition = P_1;
						num = 350005797;
						continue;
					default:
						_touchStartTime = Time.realtimeSinceStartup;
						_touchStartPosition = P_1;
						return;
					}
					break;
				}
			}
		}

		private void lpCghgdvtFwpLBkUsSpPyavhpiK()
		{
			bool flag = _allowTap && _isEligibleForTap;
			OmMQSyoLmaJHYrXPeNoBnwkIRXA();
			while (true)
			{
				int num = -1437315789;
				while (true)
				{
					switch (num ^ -1437315790)
					{
					case 3:
						break;
					default:
						return;
					case 1:
					{
						deteGKFsUpKVtiobsxDnfbVWHkL = false;
						int num2;
						if (_useInertia)
						{
							num = -1437315785;
							num2 = num;
						}
						else
						{
							num = -1437315792;
							num2 = num;
						}
						continue;
					}
					case 2:
						_axis2D.SetRawValue(0f, 0f);
						num = -1437315788;
						continue;
					case 6:
						tLpeNekAEQDmCANvgNerHjQaDLHq(false);
						_isEligibleForTap = false;
						_isEligibleForPress = false;
						if (flag)
						{
							_lastTapFrame = Time.frameCount + 1;
							num = -1437315786;
							continue;
						}
						return;
					case 5:
						if (_touchPadMode == TouchPadMode.Delta)
						{
							_axis2D.SetRawValue(_smoothDelta.CbqPbrFmeFhKRaihBafMhQRQNRdv());
							num = -1437315788;
							continue;
						}
						goto case 2;
					case 4:
						_onTap.Invoke();
						num = -1437315790;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				gkFDUotSecrQghkuzcszQbTklVO(eventData);
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
				{
					num = -780832329;
					num2 = num;
				}
				else
				{
					num = -780832331;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -780832329)
					{
					case 3:
						goto IL_0009;
					case 1:
						break;
					case 2:
						return;
					default:
						VMPxCmwNDckEZjKzFAfOOLwMEyj(eventData);
						return;
					}
					break;
					IL_0009:
					num = -780832330;
				}
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				yVatkfTlebiCIFaVPbRrioxyjVJ(eventData);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				UNMauMeXBncuatcyFyBICUuhBxd(eventData);
			}
		}

		private void OmMQSyoLmaJHYrXPeNoBnwkIRXA()
		{
			_pointerId = int.MinValue;
			while (true)
			{
				int num = -1141024605;
				while (true)
				{
					switch (num ^ -1141024606)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0029;
					case 0:
						return;
					}
					break;
					IL_0029:
					_realMousePointerId = int.MinValue;
					num = -1141024606;
				}
			}
		}

		private bool rtBocUdjipCXKhkfukoKkICxgqh(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (_pointerId == int.MinValue)
			{
				return false;
			}
			if (_pointerId == P_0)
			{
				return true;
			}
			if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
		}

		private PointerEventData VeJANUaZIhfuukBBgCAhDSXJcuGp(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(P_0);
			GameObject gameObject2 = default(GameObject);
			float unscaledTime = default(float);
			GameObject gameObject = default(GameObject);
			float unscaledTime2 = default(float);
			float num2 = default(float);
			while (true)
			{
				int num = 2079727685;
				while (true)
				{
					switch (num ^ 0x7BF62056)
					{
					case 20:
						break;
					case 5:
						pointerEventData.clickCount = 1;
						num = 2079727687;
						continue;
					case 15:
						pointerEventData.pointerPress = gameObject2;
						pointerEventData.rawPointerPress = P_1;
						num = 2079727702;
						continue;
					case 2:
						num = 2079727701;
						continue;
					case 8:
						if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
						{
							pointerEventData.eligibleForClick = true;
							pointerEventData.delta = Vector2.zero;
							pointerEventData.dragging = false;
							pointerEventData.useDragThreshold = true;
							pointerEventData.pressPosition = pointerEventData.position;
							num = 2079727697;
							continue;
						}
						goto default;
					case 18:
						num = 2079727687;
						continue;
					case 1:
						unscaledTime = Time.unscaledTime;
						if (gameObject2 == pointerEventData.lastPress)
						{
							float num5 = unscaledTime - pointerEventData.clickTime;
							if (num5 < 0.3f)
							{
								pointerEventData.clickCount++;
								num = 2079727700;
								continue;
							}
							goto case 4;
						}
						goto case 13;
					case 19:
						if (!TouchInteractable.MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
						{
							goto case 8;
						}
						pointerEventData.eligibleForClick = true;
						pointerEventData.delta = Vector2.zero;
						pointerEventData.dragging = false;
						pointerEventData.useDragThreshold = true;
						pointerEventData.pressPosition = pointerEventData.position;
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						if (pointerEventData.pointerEnter != P_1)
						{
							pointerEventData.pointerEnter = P_1;
							num = 2079727696;
							continue;
						}
						goto case 6;
					case 7:
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						gameObject = P_1;
						unscaledTime2 = Time.unscaledTime;
						num = 2079727708;
						continue;
					case 17:
						pointerEventData.clickTime = unscaledTime2;
						num = 2079727706;
						continue;
					case 3:
						pointerEventData.clickTime = unscaledTime;
						num = 2079727709;
						continue;
					case 6:
						gameObject2 = P_1;
						num = 2079727703;
						continue;
					case 10:
					{
						int num4;
						if (!(gameObject == pointerEventData.lastPress))
						{
							num = 2079727704;
							num4 = num;
						}
						else
						{
							num = 2079727683;
							num4 = num;
						}
						continue;
					}
					case 21:
						num2 = unscaledTime2 - pointerEventData.clickTime;
						num = 2079727686;
						continue;
					case 12:
						pointerEventData.pointerPress = gameObject;
						pointerEventData.rawPointerPress = P_1;
						pointerEventData.clickTime = unscaledTime2;
						pointerEventData.pointerDrag = P_1;
						goto IL_030a;
					case 14:
						pointerEventData.clickCount = 1;
						num = 2079727706;
						continue;
					case 9:
						pointerEventData.clickCount++;
						num = 2079727684;
						continue;
					case 4:
						pointerEventData.clickCount = 1;
						num = 2079727701;
						continue;
					case 13:
						pointerEventData.clickCount = 1;
						num = 2079727705;
						continue;
					case 0:
						pointerEventData.clickTime = unscaledTime;
						pointerEventData.pointerDrag = P_1;
						goto IL_030a;
					case 11:
						num = 2079727705;
						continue;
					case 16:
					{
						int num3;
						if (num2 < 0.3f)
						{
							num = 2079727711;
							num3 = num;
						}
						else
						{
							num = 2079727699;
							num3 = num;
						}
						continue;
					}
					default:
						{
							Logger.LogWarning("Unsupported pointerId: " + P_0);
							return null;
						}
						IL_030a:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private PointerEventData IOvmMzhsiknEPdURAICYdMNvgPQ(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(P_0);
			Vector2 vector = default(Vector2);
			GameObject pointerDrag = default(GameObject);
			while (true)
			{
				int num = -1725573170;
				while (true)
				{
					switch (num ^ -1725573169)
					{
					case 4:
						break;
					case 5:
						pointerEventData.position = vector;
						pointerEventData.dragging = true;
						pointerEventData.pointerDrag = pointerDrag;
						pointerEventData.useDragThreshold = true;
						num = -1725573169;
						continue;
					case 2:
						return null;
					case 3:
						pointerEventData.delta = vector - pointerEventData.position;
						num = -1725573174;
						continue;
					case 1:
						if (pointerEventData != null)
						{
							pointerDrag = P_1;
							vector = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(P_0);
							num = -1725573172;
						}
						else
						{
							num = -1725573171;
						}
						continue;
					default:
						pointerEventData.pointerPress = null;
						pointerEventData.rawPointerPress = null;
						return pointerEventData;
					}
					break;
				}
			}
		}

		private PointerEventData WWBaWpsvmKBDDDdyzjqZKoKTVkj(int P_0)
		{
			PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
			{
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				goto IL_0031;
			}
			goto IL_008a;
			IL_008a:
			int num;
			if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
			{
				pointerEventData.eligibleForClick = false;
				num = 136733504;
				goto IL_0036;
			}
			goto IL_00cd;
			IL_00cd:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			num = 136733505;
			goto IL_0036;
			IL_0031:
			num = 136733511;
			goto IL_0036;
			IL_0036:
			while (true)
			{
				switch (num ^ 0x8266341)
				{
				case 9:
					break;
				case 1:
					pointerEventData.pointerPress = null;
					num = 136733513;
					continue;
				case 8:
					pointerEventData.rawPointerPress = null;
					num = 136733508;
					continue;
				case 4:
					goto IL_008a;
				case 5:
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					num = 136733510;
					continue;
				case 2:
					goto IL_00cd;
				case 6:
					pointerEventData.pointerDrag = null;
					pointerEventData.pointerEnter = null;
					num = 136733506;
					continue;
				default:
					return null;
				case 3:
				case 7:
					return pointerEventData;
				}
				break;
			}
			goto IL_0031;
		}

		private void yexpQprndcKAWRDGCPOiDjHZJQS(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				OnPointerUp(P_0);
				WWBaWpsvmKBDDDdyzjqZKoKTVkj(effectivePointerId);
				int num = 2143115638;
				while (true)
				{
					switch (num ^ 0x7FBD5977)
					{
					case 0:
						goto IL_0004;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0004:
					num = 2143115637;
				}
			}
		}

		private PointerEventData eVclGdybysCFPcOarpTxhdEPClmv(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (__fakePointerEventData == null)
			{
				__fakePointerEventData = new Dictionary<int, PointerEventData>();
				goto IL_0020;
			}
			goto IL_00e3;
			IL_00e3:
			PointerEventData value = default(PointerEventData);
			int num;
			if (!__fakePointerEventData.TryGetValue(P_0, out value))
			{
				value = new PointerEventData(EventSystem.current);
				num = 678827024;
				goto IL_0025;
			}
			goto IL_0147;
			IL_0147:
			return value;
			IL_0020:
			num = 678827038;
			goto IL_0025;
			IL_0025:
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			while (true)
			{
				switch (num ^ 0x2876141A)
				{
				case 5:
					break;
				case 8:
					num = 678827030;
					continue;
				case 10:
					value.pointerId = P_0;
					num = 678827037;
					continue;
				case 2:
					switch (P_0)
					{
					case -1:
						goto IL_0119;
					case -2:
						goto IL_0125;
					case -3:
						goto IL_0131;
					}
					num = 678827034;
					continue;
				case 11:
					throw new NotImplementedException();
				case 7:
					goto IL_00b0;
				case 0:
					num = 678827025;
					continue;
				case 4:
					goto IL_00e3;
				case 12:
					value.button = button;
					num = 678827033;
					continue;
				case 13:
					goto IL_0119;
				case 9:
					goto IL_0125;
				case 6:
					goto IL_0131;
				case 1:
					num = 678827030;
					continue;
				default:
					goto IL_0147;
					IL_0131:
					button = PointerEventData.InputButton.Middle;
					num = 678827030;
					continue;
					IL_0125:
					button = PointerEventData.InputButton.Right;
					num = 678827026;
					continue;
					IL_0119:
					button = PointerEventData.InputButton.Left;
					num = 678827035;
					continue;
				}
				break;
				IL_00b0:
				__fakePointerEventData.Add(P_0, value);
				int num2;
				if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
				{
					num = 678827032;
					num2 = num;
				}
				else
				{
					num = 678827033;
					num2 = num;
				}
			}
			goto IL_0020;
		}
	}
}
