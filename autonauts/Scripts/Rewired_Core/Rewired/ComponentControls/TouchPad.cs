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

		private class GTZMHPlukMMLwzchaFLJeONnZBt
		{
			private class ntEynTHLmegxrTSJZHPFoacqALv
			{
				public float ABfeqjpzvjRcvRvJfJKblIZhrhM;

				public float oUggHrhFoPXlKSaVAbqTbtQKHYOi;

				public uint NhyMsVEsWIZehrwQuSflSbIikKg;
			}

			private int DhPyddtNfRQXVcBwMhCFkOdEGGE;

			private ntEynTHLmegxrTSJZHPFoacqALv[] eijOwZbpeptWbZzpnQOEBtAEzoE;

			private int makeqSfOesOCmoTnKnppZmDJCnQg = -1;

			public GTZMHPlukMMLwzchaFLJeONnZBt(int maxSmoothFrames)
			{
				if (maxSmoothFrames < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				DhPyddtNfRQXVcBwMhCFkOdEGGE = maxSmoothFrames;
				eijOwZbpeptWbZzpnQOEBtAEzoE = new ntEynTHLmegxrTSJZHPFoacqALv[maxSmoothFrames];
				ArrayTools.Populate(eijOwZbpeptWbZzpnQOEBtAEzoE);
			}

			public void zxLhCcrlwKIIJANOaByFjYpjSot(float P_0, float P_1)
			{
				uint currentFrame = ReInput.currentFrame;
				if (makeqSfOesOCmoTnKnppZmDJCnQg >= 0 && eijOwZbpeptWbZzpnQOEBtAEzoE[makeqSfOesOCmoTnKnppZmDJCnQg].NhyMsVEsWIZehrwQuSflSbIikKg == currentFrame)
				{
					goto IL_0024;
				}
				goto IL_007f;
				IL_007f:
				vBIfqWdMVpvyhGWhRXUcUqbSBrh();
				int num = -384338770;
				goto IL_0029;
				IL_0024:
				num = -384338776;
				goto IL_0029;
				IL_0029:
				ntEynTHLmegxrTSJZHPFoacqALv ntEynTHLmegxrTSJZHPFoacqALv2 = default(ntEynTHLmegxrTSJZHPFoacqALv);
				while (true)
				{
					switch (num ^ -384338772)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						ntEynTHLmegxrTSJZHPFoacqALv2.oUggHrhFoPXlKSaVAbqTbtQKHYOi = P_1;
						ntEynTHLmegxrTSJZHPFoacqALv2.NhyMsVEsWIZehrwQuSflSbIikKg = currentFrame;
						num = -384338771;
						continue;
					case 2:
						ntEynTHLmegxrTSJZHPFoacqALv2 = eijOwZbpeptWbZzpnQOEBtAEzoE[makeqSfOesOCmoTnKnppZmDJCnQg];
						ntEynTHLmegxrTSJZHPFoacqALv2.ABfeqjpzvjRcvRvJfJKblIZhrhM = P_0;
						num = -384338769;
						continue;
					case 5:
						goto IL_007f;
					case 4:
						return;
					case 1:
						return;
					}
					break;
				}
				goto IL_0024;
			}

			public Vector2 fxoKLwzyPXXVGRqEUUSNKjzHEaG()
			{
				if (makeqSfOesOCmoTnKnppZmDJCnQg < 0)
				{
					return default(Vector2);
				}
				int num = makeqSfOesOCmoTnKnppZmDJCnQg;
				Vector2 result = default(Vector2);
				ntEynTHLmegxrTSJZHPFoacqALv ntEynTHLmegxrTSJZHPFoacqALv2 = default(ntEynTHLmegxrTSJZHPFoacqALv);
				uint nhyMsVEsWIZehrwQuSflSbIikKg = default(uint);
				int num3 = default(int);
				int num4 = default(int);
				while (true)
				{
					int num2 = -1943612989;
					while (true)
					{
						switch (num2 ^ -1943612982)
						{
						case 2:
							break;
						case 0:
							result.y += ntEynTHLmegxrTSJZHPFoacqALv2.oUggHrhFoPXlKSaVAbqTbtQKHYOi;
							nhyMsVEsWIZehrwQuSflSbIikKg = ntEynTHLmegxrTSJZHPFoacqALv2.NhyMsVEsWIZehrwQuSflSbIikKg;
							num2 = -1943612980;
							continue;
						case 5:
							num3 = num;
							num2 = -1943612983;
							continue;
						case 3:
							num4 = 1;
							num2 = -1943612990;
							continue;
						case 6:
							num4++;
							num2 = -1943612990;
							continue;
						case 8:
						{
							int num5;
							if ((num3 = yhSheElHOrrmvpQQfiznttbgCST(num3, DhPyddtNfRQXVcBwMhCFkOdEGGE)) != num)
							{
								num2 = -1943612981;
								num5 = num2;
							}
							else
							{
								num2 = -1943612978;
								num5 = num2;
							}
							continue;
						}
						case 9:
						{
							ntEynTHLmegxrTSJZHPFoacqALv ntEynTHLmegxrTSJZHPFoacqALv3 = eijOwZbpeptWbZzpnQOEBtAEzoE[num];
							result = new Vector2(ntEynTHLmegxrTSJZHPFoacqALv3.ABfeqjpzvjRcvRvJfJKblIZhrhM, ntEynTHLmegxrTSJZHPFoacqALv3.oUggHrhFoPXlKSaVAbqTbtQKHYOi);
							nhyMsVEsWIZehrwQuSflSbIikKg = ntEynTHLmegxrTSJZHPFoacqALv3.NhyMsVEsWIZehrwQuSflSbIikKg;
							num2 = -1943612977;
							continue;
						}
						case 4:
							if (num4 > 0)
							{
								result.x /= num4;
								result.y /= num4;
								num2 = -1943612979;
								continue;
							}
							goto default;
						case 1:
							ntEynTHLmegxrTSJZHPFoacqALv2 = eijOwZbpeptWbZzpnQOEBtAEzoE[num3];
							if (yEsIyeEyUVSeVKbJoHVZdViDZiM(ntEynTHLmegxrTSJZHPFoacqALv2.NhyMsVEsWIZehrwQuSflSbIikKg, nhyMsVEsWIZehrwQuSflSbIikKg))
							{
								result.x += ntEynTHLmegxrTSJZHPFoacqALv2.ABfeqjpzvjRcvRvJfJKblIZhrhM;
								num2 = -1943612982;
								continue;
							}
							goto case 4;
						default:
							return result;
						}
						break;
					}
				}
			}

			private void vBIfqWdMVpvyhGWhRXUcUqbSBrh()
			{
				makeqSfOesOCmoTnKnppZmDJCnQg = XmLorbBHxwHbnOBUAscPDYrxWsz(makeqSfOesOCmoTnKnppZmDJCnQg, DhPyddtNfRQXVcBwMhCFkOdEGGE);
			}

			private static int XmLorbBHxwHbnOBUAscPDYrxWsz(int P_0, int P_1)
			{
				if (P_0 >= P_1 - 1)
				{
					return 0;
				}
				return ++P_0;
			}

			private int yhSheElHOrrmvpQQfiznttbgCST(int P_0, int P_1)
			{
				if (P_0 > 0)
				{
					return --P_0;
				}
				return P_1 - 1;
			}

			private static bool yEsIyeEyUVSeVKbJoHVZdViDZiM(uint P_0, uint P_1)
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
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
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ValueFormat _valueFormat;

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		[SerializeField]
		private bool _useInertia;

		[FieldRange(0f, float.MaxValue)]
		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _inertiaFriction = 3f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Should taps on the touch pad be processed?")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _allowTap;

		[SerializeField]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		private float _tapTimeout = 0.25f;

		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[SerializeField]
		private int _tapDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		[SerializeField]
		private bool _allowPress;

		[SerializeField]
		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		[CustomObfuscation(rename = false)]
		private float _pressStartDelay = 0.1f;

		[SerializeField]
		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		[CustomObfuscation(rename = false)]
		private int _pressDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		[SerializeField]
		private bool _hideAtRuntime;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The underlying Axis 2D.")]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		[Tooltip("Event sent when the value changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[CustomObfuscation(rename = false)]
		private TapEventHandler _onTap = new TapEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		private PressDownEventHandler _onPressDown = new PressDownEventHandler();

		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private PressUpEventHandler _onPressUp = new PressUpEventHandler();

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool QlnYBBpzNpDLYXfPrVIqnYFRDKL;

		[NonSerialized]
		private bool tmlENZkWxfXAUYowkKtYqEQUwuh;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private GTZMHPlukMMLwzchaFLJeONnZBt _smoothDelta = new GTZMHPlukMMLwzchaFLJeONnZBt(3);

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
					while (true)
					{
						switch (-909807714 ^ -909807716)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				WltfmBeoAglkdNsEoHeUJFYHTwoK(value);
				OnSetProperty();
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
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -1035816865;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1035816866)
				{
				case 0:
					break;
				case 1:
					return;
				case 3:
					goto IL_0033;
				default:
					OnSetProperty();
					return;
				}
				goto IL_0009;
				IL_0033:
				_valueFormat = value;
				num = -1035816868;
				goto IL_000e;
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
					OnSetProperty();
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
				if (_inertiaFriction != value)
				{
					_inertiaFriction = value;
					OnSetProperty();
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
					int num = 469803931;
					while (true)
					{
						switch (num ^ 0x1C00A39B)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = 469803930;
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
						switch (-1891219019 ^ -1891219017)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_stayActiveOnSwipeOut = value;
				OnSetProperty();
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
					int num = 1924613578;
					while (true)
					{
						switch (num ^ 0x72B745CA)
						{
						case 2:
							num = 1924613577;
							continue;
						default:
							return;
						case 3:
							break;
						case 0:
							OnSetProperty();
							num = 1924613579;
							continue;
						case 1:
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
				if (_tapTimeout == value)
				{
					return;
				}
				while (true)
				{
					_tapTimeout = value;
					int num = -182261586;
					while (true)
					{
						switch (num ^ -182261588)
						{
						case 3:
							num = -182261587;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							OnSetProperty();
							num = -182261588;
							continue;
						case 0:
							return;
						}
						break;
					}
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
					while (true)
					{
						switch (-1313726551 ^ -1313726552)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_tapDistanceLimit = value;
				OnSetProperty();
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
					return;
				}
				while (true)
				{
					_allowPress = value;
					int num = -542716222;
					while (true)
					{
						switch (num ^ -542716221)
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
						num = -542716223;
					}
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
				if (_pressStartDelay == value)
				{
					return;
				}
				while (true)
				{
					_pressStartDelay = value;
					int num = -527260110;
					while (true)
					{
						switch (num ^ -527260110)
						{
						case 2:
							goto IL_001b;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_001b:
						num = -527260109;
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
				if (_pressDistanceLimit == value)
				{
					goto IL_0012;
				}
				goto IL_003c;
				IL_0012:
				int num = -1970725586;
				goto IL_0017;
				IL_0017:
				switch (num ^ -1970725585)
				{
				case 3:
					break;
				case 1:
					return;
				case 2:
					goto IL_003c;
				default:
					OnSetProperty();
					return;
				}
				goto IL_0012;
				IL_003c:
				_pressDistanceLimit = value;
				num = -1970725585;
				goto IL_0017;
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
					int num = 1470076228;
					while (true)
					{
						switch (num ^ 0x579F9546)
						{
						case 0:
							goto IL_000d;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000d:
						num = 1470076231;
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
				if (!TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
				{
					return Vector2.zero;
				}
				return TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(effectivePointerId);
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
			while (true)
			{
				int num = 1551765894;
				while (true)
				{
					switch (num ^ 0x5C7E1182)
					{
					case 2:
						break;
					default:
						return;
					case 4:
					{
						int num2;
						if (Application.isPlaying)
						{
							num = 1551765890;
							num2 = num;
						}
						else
						{
							num = 1551765889;
							num2 = num;
						}
						continue;
					}
					case 0:
						if (_hideAtRuntime)
						{
							base.visible = false;
							num = 1551765891;
							continue;
						}
						return;
					case 3:
						return;
					case 1:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				UtBolprlOWliIGJGYPhPmCxwKqH();
				cIMxKKikLZEqzDDbOdedgdvAfBZi();
			}
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			UtBolprlOWliIGJGYPhPmCxwKqH();
			return true;
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0041;
			IL_000e:
			int num = -349920711;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -349920710)
				{
				case 0:
					break;
				case 2:
					xvhEjvVFsFrafXEEWHZdWOefBUF();
					num = -349920706;
					continue;
				case 1:
					goto IL_0041;
				case 3:
					return;
				default:
					qDEKYbiYTTSxoNBsEQeFEknFCkp();
					dHMENUWUyUGqTWMrufnZgmzwpTXo();
					wSgfMijFKCCnjPHkXsMLWBlbbEQ();
					return;
				}
				break;
			}
			goto IL_000e;
			IL_0041:
			qJMamGLEEHdGsPSzzqthyOviLcp();
			num = -349920712;
			goto IL_0013;
		}

		internal override void OnCustomControllerUpdate()
		{
			if (!base.initialized)
			{
				return;
			}
			Vector2 vector2 = default(Vector2);
			while (true)
			{
				int num;
				int num2;
				if (!hasController)
				{
					num = -1005442179;
					num2 = num;
				}
				else
				{
					num = -1005442186;
					num2 = num;
				}
				while (true)
				{
					Vector2 vector;
					switch (num ^ -1005442178)
					{
					case 10:
						num = -1005442185;
						continue;
					default:
						return;
					case 11:
						if (_allowPress)
						{
							KyhNArefdFIxsvhHWTOXrRXnSZY(_pressCustomControllerElement, _pressValue);
							num = -1005442178;
							continue;
						}
						return;
					case 5:
					{
						int num3;
						if (!_useXAxis)
						{
							num = -1005442184;
							num3 = num;
						}
						else
						{
							num = -1005442182;
							num3 = num;
						}
						continue;
					}
					case 2:
					{
						int num4;
						if (_allowTap)
						{
							num = -1005442183;
							num4 = num;
						}
						else
						{
							num = -1005442187;
							num4 = num;
						}
						continue;
					}
					case 4:
						KyhNArefdFIxsvhHWTOXrRXnSZY(_horizontalAxisCustomControllerElement, vector2.x, _axis2D.xAxis.buttonActivationThreshold);
						num = -1005442184;
						continue;
					case 7:
						KyhNArefdFIxsvhHWTOXrRXnSZY(_tapCustomControllerElement, tapValue);
						num = -1005442187;
						continue;
					case 1:
						vector = _axis2D.value;
						goto IL_010b;
					case 3:
						return;
					case 9:
						break;
					case 6:
						if (_useYAxis)
						{
							KyhNArefdFIxsvhHWTOXrRXnSZY(_verticalAxisCustomControllerElement, vector2.y, _axis2D.xAxis.buttonActivationThreshold);
							num = -1005442180;
							continue;
						}
						goto case 2;
					case 8:
						if (_touchPadMode == TouchPadMode.ScreenPosition)
						{
							vector = _axis2D.rawValue;
							goto IL_010b;
						}
						num = -1005442177;
						continue;
					case 0:
						return;
						IL_010b:
						vector2 = vector;
						num = -1005442181;
						continue;
					}
					break;
				}
			}
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			if (base.initialized)
			{
				UtBolprlOWliIGJGYPhPmCxwKqH();
				cIMxKKikLZEqzDDbOdedgdvAfBZi();
			}
		}

		internal override void OnClear()
		{
			base.OnClear();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0072;
			IL_000e:
			int num = 283096700;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ 0x10DFB67D)
				{
				case 3:
					break;
				case 2:
					_previousTouchPosition = Vector2.zero;
					_axis2D.Clear();
					num = 283096697;
					continue;
				case 4:
					_lastTapFrame = -1;
					_pressValue = false;
					num = 283096696;
					continue;
				case 1:
					return;
				case 0:
					goto IL_0072;
				default:
					_isEligibleForTap = false;
					_isEligibleForPress = false;
					return;
				}
				break;
			}
			goto IL_000e;
			IL_0072:
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
			tmlENZkWxfXAUYowkKtYqEQUwuh = false;
			_pointerDownIsFake = false;
			_currentCenter = Vector2.zero;
			num = 283096703;
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
				_lastTapFrame = -1;
				_pressValue = false;
				if (!hasController)
				{
					break;
				}
				base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
				base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
				base.controller.ClearElementValue(_tapCustomControllerElement);
				int num = -1910586576;
				while (true)
				{
					switch (num ^ -1910586574)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = -1910586573;
				}
			}
		}

		private void cIMxKKikLZEqzDDbOdedgdvAfBZi()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			_pressCustomControllerElement.ClearElementCaches();
		}

		private void UtBolprlOWliIGJGYPhPmCxwKqH()
		{
			WltfmBeoAglkdNsEoHeUJFYHTwoK(_axesToUse);
			while (true)
			{
				int num = -941479663;
				while (true)
				{
					switch (num ^ -941479659)
					{
					case 5:
						break;
					default:
						return;
					case 6:
					{
						int num3;
						if (!_useYAxis)
						{
							num = -941479651;
							num3 = num;
						}
						else
						{
							num = -941479659;
							num3 = num;
						}
						continue;
					}
					case 8:
						if (_allowTap)
						{
							base.controller.ValidateElements(_tapCustomControllerElement);
							num = -941479652;
							continue;
						}
						goto case 9;
					case 0:
						base.controller.ValidateElements(_verticalAxisCustomControllerElement);
						num = -941479651;
						continue;
					case 9:
						if (_allowPress)
						{
							base.controller.ValidateElements(_pressCustomControllerElement);
							num = -941479662;
							continue;
						}
						return;
					case 2:
						if (_useXAxis)
						{
							base.controller.ValidateElements(_horizontalAxisCustomControllerElement);
							num = -941479661;
							continue;
						}
						goto case 6;
					case 1:
					{
						int num2;
						if (base.touchController.useCustomController)
						{
							num = -941479657;
							num2 = num;
						}
						else
						{
							num = -941479658;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					case 4:
						if (!hasController)
						{
							return;
						}
						goto case 1;
					case 7:
						return;
					}
					break;
				}
			}
		}

		private void WltfmBeoAglkdNsEoHeUJFYHTwoK(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag)
				{
					goto IL_001e;
				}
			}
			goto IL_0060;
			IL_009e:
			_axesToUse = P_0;
			return;
			IL_0023:
			int num;
			while (true)
			{
				switch (num ^ 0x28325054)
				{
				case 2:
					break;
				case 1:
					if (hasController)
					{
						base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
						num = 674386007;
						continue;
					}
					goto IL_0060;
				case 3:
					goto IL_0060;
				default:
					goto IL_009e;
				}
				break;
			}
			goto IL_001e;
			IL_001e:
			num = 674386005;
			goto IL_0023;
			IL_0060:
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && hasController)
				{
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
					num = 674386004;
					goto IL_0023;
				}
			}
			goto IL_009e;
		}

		private void xvhEjvVFsFrafXEEWHZdWOefBUF()
		{
			if (!hasPointer)
			{
				return;
			}
			while (!TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
			{
				PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(effectivePointerId);
				int num;
				if (pointerEventData != null)
				{
					int num2;
					if (pointerEventData.pointerPress != null)
					{
						num = -1850617929;
						num2 = num;
					}
					else
					{
						num = -1850617930;
						num2 = num;
					}
					goto IL_000e;
				}
				goto IL_002f;
				IL_002f:
				SHIErtNBGDqtOcJrfCqGmlXqnbj();
				num = -1850617935;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1850617931)
					{
					case 0:
						num = -1850617932;
						continue;
					default:
						return;
					case 3:
						break;
					case 2:
						VGdcUqdPAuBHPLgxHVatOVpAQUrD(pointerEventData);
						return;
					case 1:
						goto IL_004b;
					case 4:
						return;
					}
					break;
				}
				goto IL_002f;
				IL_004b:;
			}
		}

		private void qDEKYbiYTTSxoNBsEQeFEknFCkp()
		{
			if (_touchPadMode == TouchPadMode.VectorFromCenter)
			{
				Graphic graphic = base.targetGraphic;
				_currentCenter = ((graphic != null) ? graphic.transform.position : base.transform.position);
				_currentCenter = RectTransformUtility.WorldToScreenPoint(base.canvas.worldCamera, _currentCenter);
				goto IL_005b;
			}
			goto IL_010a;
			IL_005b:
			int num = -1166371603;
			goto IL_0060;
			IL_010a:
			if (hasPointer)
			{
				int num2;
				if (TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
				{
					num = -1166371602;
					num2 = num;
				}
				else
				{
					num = -1166371607;
					num2 = num;
				}
				goto IL_0060;
			}
			return;
			IL_0060:
			Vector3 vector2 = default(Vector3);
			Vector2 vector = default(Vector2);
			while (true)
			{
				switch (num ^ -1166371604)
				{
				case 7:
					break;
				case 2:
					vector2 = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(effectivePointerId);
					num = -1166371608;
					continue;
				case 4:
					goto IL_00ab;
				case 9:
					vector = vector2;
					num = -1166371606;
					continue;
				case 0:
					vector = new Vector2(vector2.x - _currentCenter.x, vector2.y - _currentCenter.y);
					num = -1166371606;
					continue;
				case 1:
					goto IL_010a;
				case 3:
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_currentCenter = _previousTouchPosition;
						num = -1166371604;
						continue;
					}
					goto case 0;
				case 5:
					return;
				case 6:
					vector = oMAirxICvIjDVAcimxXNbNmYLAh(vector);
					_axis2D.SetRawValue(vector.x, vector.y);
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_smoothDelta.zxLhCcrlwKIIJANOaByFjYpjSot(vector.x, vector.y);
						num = -1166371612;
						continue;
					}
					goto default;
				default:
					_previousTouchPosition = vector2;
					return;
				}
				break;
				IL_00ab:
				int num3;
				if (_touchPadMode == TouchPadMode.ScreenPosition)
				{
					num = -1166371611;
					num3 = num;
				}
				else
				{
					num = -1166371601;
					num3 = num;
				}
			}
			goto IL_005b;
		}

		private void dHMENUWUyUGqTWMrufnZgmzwpTXo()
		{
			if (_touchPadMode == TouchPadMode.Delta)
			{
				if (!_useInertia)
				{
					goto IL_0013;
				}
				goto IL_006a;
			}
			return;
			IL_006a:
			if (hasPointer)
			{
				return;
			}
			goto IL_007a;
			IL_0013:
			int num = 841311468;
			goto IL_0018;
			IL_0018:
			float num2 = default(float);
			float num3 = default(float);
			Vector2 rawValue = default(Vector2);
			float smoothDeltaTime = default(float);
			while (true)
			{
				switch (num ^ 0x322564E8)
				{
				case 6:
					break;
				case 0:
					goto IL_004c;
				case 3:
					goto IL_006a;
				case 1:
					goto IL_007a;
				case 4:
					return;
				case 2:
					if (MathTools.IsNearZero(num2, 0.0001f))
					{
						num2 = 0f;
						num = 841311469;
						continue;
					}
					goto default;
				case 8:
					num3 = 0f;
					num = 841311466;
					continue;
				case 7:
					num2 = Mathf.Lerp(rawValue.y, 0f, _inertiaFriction * smoothDeltaTime);
					num = 841311464;
					continue;
				default:
					_axis2D.SetRawValue(num3, num2);
					return;
				}
				break;
				IL_004c:
				int num4;
				if (!MathTools.IsNearZero(num3, 0.0001f))
				{
					num = 841311466;
					num4 = num;
				}
				else
				{
					num = 841311456;
					num4 = num;
				}
			}
			goto IL_0013;
			IL_007a:
			rawValue = _axis2D.rawValue;
			smoothDeltaTime = Time.smoothDeltaTime;
			num3 = Mathf.Lerp(rawValue.x, 0f, _inertiaFriction * smoothDeltaTime);
			num = 841311471;
			goto IL_0018;
		}

		private void qJMamGLEEHdGsPSzzqthyOviLcp()
		{
			if (!hasPointer)
			{
				return;
			}
			while (true)
			{
				Vector2 vector = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(effectivePointerId);
				int num = -1436529962;
				while (true)
				{
					switch (num ^ -1436529961)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					default:
						WKnqeaxtWIogwqZlNbMiyijCYhx(ref vector);
						zvkCIDezhlPVTGhcBsEQionFiid(ref vector);
						return;
					}
					break;
					IL_0009:
					num = -1436529963;
				}
			}
		}

		private void WKnqeaxtWIogwqZlNbMiyijCYhx(ref Vector2 P_0)
		{
			if (_allowTap)
			{
				if (!_isEligibleForTap)
				{
					goto IL_0016;
				}
				goto IL_00ae;
			}
			return;
			IL_00ae:
			int num;
			int num2;
			if (_tapTimeout > 0f)
			{
				num = -2024750148;
				num2 = num;
			}
			else
			{
				num = -2024750149;
				num2 = num;
			}
			goto IL_001b;
			IL_0016:
			num = -2024750146;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ -2024750145)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					goto IL_0047;
				case 4:
					goto IL_006c;
				case 1:
					return;
				case 6:
					goto IL_00ae;
				case 0:
					_isEligibleForTap = false;
					num = -2024750147;
					continue;
				case 2:
					return;
				}
				break;
				IL_006c:
				if (_tapDistanceLimit >= 0)
				{
					int num3;
					if (Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)
					{
						num = -2024750145;
						num3 = num;
					}
					else
					{
						num = -2024750147;
						num3 = num;
					}
					continue;
				}
				return;
				IL_0047:
				int num4;
				if (!(Time.realtimeSinceStartup - _touchStartTime > _tapTimeout))
				{
					num = -2024750149;
					num4 = num;
				}
				else
				{
					num = -2024750145;
					num4 = num;
				}
			}
			goto IL_0016;
		}

		private void zvkCIDezhlPVTGhcBsEQionFiid(ref Vector2 P_0)
		{
			if (!_allowPress)
			{
				return;
			}
			while (true)
			{
				int num = -990606791;
				while (true)
				{
					switch (num ^ -990606787)
					{
					case 0:
						break;
					case 1:
						if (_pressDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_pressDistanceLimit)
						{
							_isEligibleForPress = false;
							QHbiXrAgtGtNBqLKhFiwrziKWQe(false);
							return;
						}
						goto case 5;
					case 2:
						return;
					case 4:
					{
						int num2;
						if (_isEligibleForPress)
						{
							num = -990606788;
							num2 = num;
						}
						else
						{
							num = -990606785;
							num2 = num;
						}
						continue;
					}
					case 5:
						if (_pressStartDelay > 0f && Time.realtimeSinceStartup - _touchStartTime < _pressStartDelay)
						{
							return;
						}
						goto default;
					default:
						QHbiXrAgtGtNBqLKhFiwrziKWQe(true);
						return;
					}
					break;
				}
			}
		}

		private void wSgfMijFKCCnjPHkXsMLWBlbbEQ()
		{
			if (_touchPadMode != TouchPadMode.Delta)
			{
				goto IL_0062;
			}
			Vector2 value = _axis2D.value;
			Vector2 valuePrev = _axis2D.valuePrev;
			if (value.x == 0f)
			{
				goto IL_0031;
			}
			goto IL_00cc;
			IL_0062:
			Vector2 valueDelta = _axis2D.valueDelta;
			int num;
			int num2;
			if (valueDelta.x != 0f)
			{
				num = 1168506928;
				num2 = num;
			}
			else
			{
				num = 1168506932;
				num2 = num;
			}
			goto IL_0036;
			IL_0031:
			num = 1168506935;
			goto IL_0036;
			IL_0036:
			while (true)
			{
				switch (num ^ 0x45A60034)
				{
				case 6:
					break;
				default:
					return;
				case 1:
					goto IL_0062;
				case 0:
					goto IL_008d;
				case 4:
					_onValueChanged.Invoke(_axis2D.value);
					num = 1168506934;
					continue;
				case 5:
					goto IL_00cc;
				case 3:
					goto IL_00ed;
				case 2:
					return;
				}
				break;
				IL_00ed:
				if (value.y == 0f && valuePrev.x == 0f)
				{
					int num3;
					if (valuePrev.y == 0f)
					{
						num = 1168506934;
						num3 = num;
					}
					else
					{
						num = 1168506929;
						num3 = num;
					}
					continue;
				}
				goto IL_00cc;
				IL_008d:
				int num4;
				if (valueDelta.y != 0f)
				{
					num = 1168506928;
					num4 = num;
				}
				else
				{
					num = 1168506934;
					num4 = num;
				}
			}
			goto IL_0031;
			IL_00cc:
			_onValueChanged.Invoke(_axis2D.value);
		}

		private Vector2 oMAirxICvIjDVAcimxXNbNmYLAh(Vector2 P_0)
		{
			int num;
			float num2 = default(float);
			switch (_valueFormat)
			{
			case ValueFormat.Screen:
				P_0.x /= Screen.width;
				P_0.y /= Screen.height;
				num = -537288768;
				goto IL_0027;
			case ValueFormat.Physical:
				goto IL_0086;
			case ValueFormat.Direction:
				goto IL_00a1;
			default:
				goto IL_00cf;
			case ValueFormat.Pixels:
				break;
				IL_0027:
				while (true)
				{
					switch (num ^ -537288768)
					{
					case 5:
						num = -537288765;
						continue;
					case 3:
						break;
					case 1:
						goto IL_0086;
					case 4:
						goto IL_00a1;
					case 7:
						goto IL_00b2;
					case 2:
						goto IL_00cf;
					case 0:
						num = -537288762;
						continue;
					default:
						goto end_IL_0008;
					}
					break;
				}
				goto case ValueFormat.Screen;
				IL_00cf:
				throw new NotImplementedException();
				IL_00a1:
				P_0.Normalize();
				num = -537288762;
				goto IL_0027;
				IL_0086:
				num2 = Screen.dpi;
				if (num2 < 10f)
				{
					num2 = 96f;
					num = -537288761;
					goto IL_0027;
				}
				goto IL_00b2;
				IL_00b2:
				P_0 = P_0 / num2 * 100f;
				num = -537288762;
				goto IL_0027;
				end_IL_0008:
				break;
			}
			return P_0;
		}

		private void QHbiXrAgtGtNBqLKhFiwrziKWQe(bool P_0)
		{
			if (P_0 == _pressValue)
			{
				goto IL_0009;
			}
			goto IL_004d;
			IL_0009:
			int num = 2040544303;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x79A03C2D)
			{
			case 4:
				break;
			case 2:
				return;
			case 1:
				if (P_0)
				{
					_onPressDown.Invoke();
					return;
				}
				goto default;
			case 3:
				goto IL_004d;
			default:
				_onPressUp.Invoke();
				return;
			}
			goto IL_0009;
			IL_004d:
			_pressValue = P_0;
			num = 2040544300;
			goto IL_000e;
		}

		private void ykLlbzWaLuNEKGAQUYLFIUwTpBY(PointerEventData P_0)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0047;
			IL_0008:
			int num = -471735431;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -471735429)
				{
				case 3:
					break;
				case 4:
					PrhNrJNIlRPRCXgcxIuytulSRay(P_0.pointerId, P_0.pressPosition);
					num = -471735429;
					continue;
				case 1:
					goto IL_0047;
				case 2:
					if (!KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
					{
						return;
					}
					goto IL_0047;
				default:
					goto IL_007e;
				}
				break;
			}
			goto IL_0008;
			IL_007e:
			base.OnPointerDown(P_0);
			return;
			IL_0047:
			if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				int num2;
				if (IsInteractable())
				{
					num = -471735425;
					num2 = num;
				}
				else
				{
					num = -471735429;
					num2 = num;
				}
				goto IL_000d;
			}
			goto IL_007e;
		}

		private void PKDpapVpBsZIfGwBoVYoUivnEgl(PointerEventData P_0)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
				{
					num = 1613719660;
					num2 = num;
				}
				else
				{
					num = 1613719658;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x602F6868)
					{
					case 0:
						num = 1613719657;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						SHIErtNBGDqtOcJrfCqGmlXqnbj();
						base.OnPointerUp(P_0);
						num = 1613719659;
						continue;
					case 4:
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void LZkGGotiHtFpBawoWkiqWiNbAGgZ(PointerEventData P_0)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				return;
			}
			bool flag2 = default(bool);
			while (true)
			{
				bool flag = TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0.pointerId);
				int num = 571036668;
				while (true)
				{
					switch (num ^ 0x220953FB)
					{
					case 0:
						num = 571036659;
						continue;
					case 1:
						_pointerDownIsFake = true;
						num = 571036670;
						continue;
					case 7:
						flag2 = false;
						if (_activateOnSwipeIn)
						{
							int num2;
							if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
							{
								num = 571036671;
								num2 = num;
							}
							else
							{
								num = 571036669;
								num2 = num;
							}
							continue;
						}
						goto case 4;
					case 12:
					{
						int num4;
						if (flag2)
						{
							num = 571036658;
							num4 = num;
						}
						else
						{
							num = 571036670;
							num4 = num;
						}
						continue;
					}
					case 8:
						break;
					case 3:
						num = 571036657;
						continue;
					case 11:
						_realMousePointerId = P_0.pointerId;
						num = 571036657;
						continue;
					case 9:
					{
						GameObject gameObject = base.gameObject;
						PointerEventData pointerEventData = gxVyVSbhjrdJfymjdngkMthnlfz((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
						if (pointerEventData != null)
						{
							ykLlbzWaLuNEKGAQUYLFIUwTpBY(pointerEventData);
							int num3;
							if (!QlnYBBpzNpDLYXfPrVIqnYFRDKL)
							{
								num = 571036670;
								num3 = num;
							}
							else
							{
								num = 571036666;
								num3 = num;
							}
							continue;
						}
						goto default;
					}
					case 4:
						base.OnPointerEnter(P_0);
						num = 571036663;
						continue;
					case 2:
						if (QlnYBBpzNpDLYXfPrVIqnYFRDKL)
						{
							goto case 4;
						}
						if (flag)
						{
							int realMousePointerId;
							if (TouchInteractable.TrwaVKkqmuGmcHocRVPXaUPcSGp(base.allowedMouseButtons, out realMousePointerId))
							{
								_realMousePointerId = realMousePointerId;
								num = 571036664;
								continue;
							}
							goto case 11;
						}
						goto case 10;
					case 10:
						flag2 = true;
						num = 571036671;
						continue;
					case 6:
						if (IsInteractable())
						{
							if (!flag)
							{
								num = 571036665;
								continue;
							}
							if (TouchInteractable.FDenAmVtwBdAcjaFssMofuoOzsP(base.allowedMouseButtons))
							{
								goto case 2;
							}
						}
						goto case 4;
					default:
						tmlENZkWxfXAUYowkKtYqEQUwuh = true;
						return;
					}
					break;
				}
			}
		}

		private void jnQPXNUYsptUbWdLIawDCCMiSiQ(PointerEventData P_0)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			while (!stayActiveOnSwipeOut && QlnYBBpzNpDLYXfPrVIqnYFRDKL)
			{
				SHIErtNBGDqtOcJrfCqGmlXqnbj();
				int num = 779928593;
				while (true)
				{
					switch (num ^ 0x2E7CC413)
					{
					case 0:
						num = 779928594;
						continue;
					case 1:
						break;
					default:
						goto end_IL_003c;
					}
					break;
				}
				continue;
				end_IL_003c:
				break;
			}
			base.OnPointerExit(P_0);
			tmlENZkWxfXAUYowkKtYqEQUwuh = false;
		}

		private void PrhNrJNIlRPRCXgcxIuytulSRay(int P_0, Vector2 P_1)
		{
			_pointerId = P_0;
			while (true)
			{
				int num = 576148791;
				while (true)
				{
					switch (num ^ 0x22575533)
					{
					case 6:
						break;
					default:
						return;
					case 3:
						if (_touchPadMode == TouchPadMode.Delta)
						{
							_previousTouchPosition = P_1;
							num = 576148786;
							continue;
						}
						goto case 1;
					case 1:
						_touchStartTime = Time.realtimeSinceStartup;
						num = 576148790;
						continue;
					case 4:
						QlnYBBpzNpDLYXfPrVIqnYFRDKL = true;
						_isEligibleForTap = true;
						_isEligibleForPress = true;
						num = 576148787;
						continue;
					case 5:
						_touchStartPosition = P_1;
						num = 576148785;
						continue;
					case 0:
						if (_touchPadMode != TouchPadMode.VectorFromCenter)
						{
							_currentCenter = P_1;
							num = 576148784;
							continue;
						}
						goto case 3;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void SHIErtNBGDqtOcJrfCqGmlXqnbj()
		{
			bool flag = _allowTap && _isEligibleForTap;
			nnIbvzAiFmjEPCjsdxFWxHOPYIt();
			QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
			if (_useInertia)
			{
				goto IL_0027;
			}
			goto IL_005c;
			IL_005c:
			_axis2D.SetRawValue(0f, 0f);
			int num = 1622193821;
			goto IL_002c;
			IL_002c:
			while (true)
			{
				switch (num ^ 0x60B0B69F)
				{
				case 5:
					break;
				default:
					return;
				case 0:
					goto IL_005c;
				case 4:
					num = 1622193821;
					continue;
				case 3:
					if (flag)
					{
						_lastTapFrame = Time.frameCount + 1;
						num = 1622193822;
						continue;
					}
					return;
				case 7:
					if (_touchPadMode == TouchPadMode.Delta)
					{
						_axis2D.SetRawValue(_smoothDelta.fxoKLwzyPXXVGRqEUUSNKjzHEaG());
						num = 1622193819;
						continue;
					}
					goto IL_005c;
				case 2:
					QHbiXrAgtGtNBqLKhFiwrziKWQe(false);
					_isEligibleForTap = false;
					_isEligibleForPress = false;
					num = 1622193820;
					continue;
				case 1:
					_onTap.Invoke();
					num = 1622193817;
					continue;
				case 6:
					return;
				}
				break;
			}
			goto IL_0027;
			IL_0027:
			num = 1622193816;
			goto IL_002c;
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
				{
					num = 761752587;
					num2 = num;
				}
				else
				{
					num = 761752585;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x2D676C0A)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					case 3:
						return;
					default:
						PKDpapVpBsZIfGwBoVYoUivnEgl(eventData);
						return;
					}
					break;
					IL_0009:
					num = 761752584;
				}
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				ykLlbzWaLuNEKGAQUYLFIUwTpBY(eventData);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				while (true)
				{
					IL_0047:
					LZkGGotiHtFpBawoWkiqWiNbAGgZ(eventData);
					int num = 704396486;
					while (true)
					{
						switch (num ^ 0x29FC3CC4)
						{
						case 0:
							num = 704396487;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							goto IL_0047;
						case 2:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				jnQPXNUYsptUbWdLIawDCCMiSiQ(eventData);
			}
		}

		private void nnIbvzAiFmjEPCjsdxFWxHOPYIt()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
		}

		private bool KsFFXDTmNznRFMUIlONNipwkUlQ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (_pointerId == int.MinValue)
			{
				goto IL_0017;
			}
			if (_pointerId == P_0)
			{
				return true;
			}
			int num;
			if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0) && _realMousePointerId != int.MinValue)
			{
				num = 542931462;
				goto IL_001c;
			}
			goto IL_0074;
			IL_0074:
			return false;
			IL_0017:
			num = 542931461;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num ^ 0x205C7A04)
				{
				case 3:
					break;
				case 1:
					return false;
				case 2:
					goto IL_0062;
				default:
					return true;
				}
				break;
				IL_0062:
				if (P_0 == _realMousePointerId)
				{
					num = 542931460;
					continue;
				}
				goto IL_0074;
			}
			goto IL_0017;
		}

		private PointerEventData gxVyVSbhjrdJfymjdngkMthnlfz(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(P_0);
			if (TouchInteractable.dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
			{
				pointerEventData.eligibleForClick = true;
				goto IL_0032;
			}
			goto IL_0185;
			IL_0185:
			int num;
			int num2;
			if (!TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
			{
				num = -232951700;
				num2 = num;
			}
			else
			{
				num = -232951683;
				num2 = num;
			}
			goto IL_0037;
			IL_0037:
			float unscaledTime2 = default(float);
			float num3 = default(float);
			GameObject gameObject2 = default(GameObject);
			float unscaledTime = default(float);
			GameObject gameObject = default(GameObject);
			while (true)
			{
				switch (num ^ -232951684)
				{
				case 6:
					break;
				case 5:
					pointerEventData.clickTime = unscaledTime2;
					num = -232951698;
					continue;
				case 15:
					num3 = unscaledTime2 - pointerEventData.clickTime;
					num = -232951704;
					continue;
				case 3:
					pointerEventData.pointerPress = gameObject2;
					pointerEventData.rawPointerPress = P_1;
					pointerEventData.clickTime = unscaledTime;
					pointerEventData.pointerDrag = P_1;
					num = -232951695;
					continue;
				case 19:
					num = -232951681;
					continue;
				case 8:
					pointerEventData.clickCount = 1;
					num = -232951691;
					continue;
				case 1:
					pointerEventData.eligibleForClick = true;
					pointerEventData.delta = Vector2.zero;
					pointerEventData.dragging = false;
					pointerEventData.useDragThreshold = true;
					pointerEventData.pressPosition = pointerEventData.position;
					num = -232951689;
					continue;
				case 0:
					pointerEventData.clickCount = 1;
					num = -232951698;
					continue;
				case 4:
				{
					float num4 = unscaledTime - pointerEventData.clickTime;
					if (num4 < 0.3f)
					{
						pointerEventData.clickCount++;
						num = -232951691;
						continue;
					}
					goto case 8;
				}
				case 12:
					goto IL_0185;
				case 17:
					pointerEventData.clickTime = unscaledTime2;
					pointerEventData.pointerDrag = P_1;
					num = -232951682;
					continue;
				case 7:
					pointerEventData.clickCount = 1;
					num = -232951687;
					continue;
				case 21:
					goto IL_01cb;
				case 9:
					pointerEventData.clickTime = unscaledTime;
					num = -232951697;
					continue;
				case 11:
					goto IL_0215;
				case 14:
					pointerEventData.delta = Vector2.zero;
					pointerEventData.dragging = false;
					pointerEventData.useDragThreshold = true;
					pointerEventData.pressPosition = pointerEventData.position;
					pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
					if (pointerEventData.pointerEnter != P_1)
					{
						pointerEventData.pointerEnter = P_1;
						num = -232951703;
						continue;
					}
					goto IL_01cb;
				case 20:
					if (num3 < 0.3f)
					{
						pointerEventData.clickCount++;
						num = -232951687;
						continue;
					}
					goto case 7;
				case 10:
					pointerEventData.clickCount = 1;
					num = -232951681;
					continue;
				case 18:
					pointerEventData.pointerPress = gameObject;
					pointerEventData.rawPointerPress = P_1;
					num = -232951699;
					continue;
				default:
					Logger.LogWarning("Unsupported pointerId: " + P_0);
					return null;
				case 2:
				case 13:
					return pointerEventData;
				}
				break;
				IL_0215:
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				gameObject = P_1;
				unscaledTime2 = Time.unscaledTime;
				int num5;
				if (!(gameObject == pointerEventData.lastPress))
				{
					num = -232951684;
					num5 = num;
				}
				else
				{
					num = -232951693;
					num5 = num;
				}
				continue;
				IL_01cb:
				gameObject2 = P_1;
				unscaledTime = Time.unscaledTime;
				int num6;
				if (gameObject2 == pointerEventData.lastPress)
				{
					num = -232951688;
					num6 = num;
				}
				else
				{
					num = -232951690;
					num6 = num;
				}
			}
			goto IL_0032;
			IL_0032:
			num = -232951694;
			goto IL_0037;
		}

		private PointerEventData brhALqGXLcCaGnAtXlrPijwseztm(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(P_0);
			GameObject pointerDrag = default(GameObject);
			while (true)
			{
				int num = 128894498;
				while (true)
				{
					switch (num ^ 0x7AEC623)
					{
					case 3:
						break;
					case 1:
						if (pointerEventData == null)
						{
							return null;
						}
						pointerDrag = P_1;
						num = 128894499;
						continue;
					case 0:
					{
						Vector2 vector = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(P_0);
						pointerEventData.delta = vector - pointerEventData.position;
						pointerEventData.position = vector;
						pointerEventData.dragging = true;
						pointerEventData.pointerDrag = pointerDrag;
						pointerEventData.useDragThreshold = true;
						pointerEventData.pointerPress = null;
						num = 128894497;
						continue;
					}
					default:
						pointerEventData.rawPointerPress = null;
						return pointerEventData;
					}
					break;
				}
			}
		}

		private PointerEventData tzBbHeHAGAaQCwiFkPKWKUeCjYAn(int P_0)
		{
			PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
			{
				goto IL_0015;
			}
			goto IL_0078;
			IL_00e4:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			return null;
			IL_0015:
			int num = 1815636609;
			goto IL_001a;
			IL_001a:
			while (true)
			{
				switch (num ^ 0x6C386A86)
				{
				case 2:
					break;
				case 7:
					pointerEventData.eligibleForClick = false;
					pointerEventData.pointerPress = null;
					pointerEventData.rawPointerPress = null;
					num = 1815636613;
					continue;
				case 1:
					pointerEventData.pointerPress = null;
					num = 1815636622;
					continue;
				case 0:
					goto IL_0078;
				case 3:
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					num = 1815636610;
					continue;
				case 6:
					pointerEventData.pointerDrag = null;
					goto IL_00fb;
				case 4:
					pointerEventData.pointerEnter = null;
					goto IL_00fb;
				case 8:
					pointerEventData.rawPointerPress = null;
					pointerEventData.dragging = false;
					num = 1815636608;
					continue;
				default:
					goto IL_00e4;
					IL_00fb:
					return pointerEventData;
				}
				break;
			}
			goto IL_0015;
			IL_0078:
			if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
			{
				pointerEventData.eligibleForClick = false;
				num = 1815636615;
				goto IL_001a;
			}
			goto IL_00e4;
		}

		private void VGdcUqdPAuBHPLgxHVatOVpAQUrD(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				OnPointerUp(P_0);
				tzBbHeHAGAaQCwiFkPKWKUeCjYAn(effectivePointerId);
				int num = -1357603977;
				while (true)
				{
					switch (num ^ -1357603977)
					{
					case 2:
						goto IL_0004;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0004:
					num = -1357603978;
				}
			}
		}

		private PointerEventData ZratKwUfLghYErsNiaeupeoKzqF(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (__fakePointerEventData == null)
			{
				goto IL_0012;
			}
			goto IL_0091;
			IL_0091:
			PointerEventData value = default(PointerEventData);
			int num;
			if (!__fakePointerEventData.TryGetValue(P_0, out value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				__fakePointerEventData.Add(P_0, value);
				int num2;
				if (!TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
				{
					num = 1773372894;
					num2 = num;
				}
				else
				{
					num = 1773372880;
					num2 = num;
				}
				goto IL_0017;
			}
			goto IL_0125;
			IL_0012:
			num = 1773372884;
			goto IL_0017;
			IL_0017:
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x69B385D6)
				{
				case 4:
					break;
				case 10:
					throw new NotImplementedException();
				case 5:
					button = PointerEventData.InputButton.Left;
					num = 1773372881;
					continue;
				case 2:
					__fakePointerEventData = new Dictionary<int, PointerEventData>();
					num = 1773372895;
					continue;
				case 1:
					goto IL_007f;
				case 3:
					goto IL_0088;
				case 9:
					goto IL_0091;
				case 11:
					num = 1773372881;
					continue;
				case 0:
					switch (num3)
					{
					case -1:
						break;
					case -2:
						goto IL_007f;
					case -3:
						goto IL_0088;
					default:
						goto IL_00fe;
					}
					goto case 5;
				case 6:
					num3 = P_0;
					num = 1773372886;
					continue;
				case 7:
					value.button = button;
					num = 1773372894;
					continue;
				default:
					goto IL_0125;
					IL_00fe:
					num = 1773372892;
					continue;
					IL_0088:
					button = PointerEventData.InputButton.Middle;
					num = 1773372881;
					continue;
					IL_007f:
					button = PointerEventData.InputButton.Right;
					num = 1773372893;
					continue;
				}
				break;
			}
			goto IL_0012;
			IL_0125:
			return value;
		}
	}
}
