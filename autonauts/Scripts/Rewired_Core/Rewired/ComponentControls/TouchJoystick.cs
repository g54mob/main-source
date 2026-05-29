using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public sealed class TouchJoystick : TouchInteractable
	{
		public enum AxisDirection
		{
			Both = 0,
			Horizontal = 1,
			Vertical = 2
		}

		public enum JoystickMode
		{
			Analog = 0,
			Digital = 1
		}

		public enum SnapDirections
		{
			None = 0,
			Four = 4,
			Eight = 8,
			Sixteen = 0x10,
			ThirtyTwo = 0x20,
			SixtyFour = 0x40
		}

		private enum FPYFNlfKuTtFhNHjyzBdbhLfBid
		{
			iOlZgcuFwLCPNAjSgaSDuxucio = 0,
			XtRDenkmlflSSFYJThdxkTsQRdUi = 1,
			kDQhddPzDwumddhEyJEvsPyPkgY = 2
		}

		private enum YeelzijLJjtLIphMNHeBIxXHloAJ
		{
			hWboZvyXoJNhfSvesxqLLWrBcgF = 0,
			FbpqMQLqHsIUsSlvpbBzoWAbCsO = 1
		}

		public enum StickBounds
		{
			Circle = 0,
			Square = 1
		}

		[Serializable]
		public class ValueChangedEventHandler : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class StickPositionChangedEventHandler : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class TapEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class TouchStartedEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class TouchEndedEventHandler : UnityEvent
		{
		}

		public interface IValueChangedHandler
		{
			void OnValueChanged(Vector2 value);
		}

		public interface IStickPositionChangedHandler
		{
			void OnStickPositionChanged(Vector2 value);
		}

		private sealed class zSuWMdCOJyJqtXZnIEyseMRwlrD : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			public TouchJoystick ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public Vector2 JduXYBqbDACUTxxZQjOzqMMbLTj;

			public PositionType BEDVoxNLBeqRJhchWAqhqSPVsYd;

			public float EWKgfOCaWksDFjQilyybAfeIqrUz;

			public FPYFNlfKuTtFhNHjyzBdbhLfBid yLCxvNsJdtnzXSCIkwezQoUNbSO;

			public RectTransform vjxBdlDEuIvgZaBNLpWzCbRdlzVV;

			public Vector2 XbWCjQUXjLrqNmuDqcPwTdQVTSn;

			public float xtWvHvWSCGerwvzGvitqnhOItCW;

			public float GewecNFLnJAEHvrsREGsEANzXikW;

			public float iNuBkhxbEbcLAIYMhAddRgEMijDn;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					int num2;
					if (!(EWKgfOCaWksDFjQilyybAfeIqrUz > 0f))
					{
						num = 748080302;
						num2 = num;
					}
					else
					{
						num = 748080301;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 748080296;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x2C96CCA8)
						{
						case 7:
							num = 748080297;
							continue;
						case 6:
							ZzSaCQHlhEgTijsOQGwUlyKTOzqG.FdMktGOiqKeApBkgCYuESOjTorm(yLCxvNsJdtnzXSCIkwezQoUNbSO, JduXYBqbDACUTxxZQjOzqMMbLTj, BEDVoxNLBeqRJhchWAqhqSPVsYd);
							num = 748080300;
							continue;
						case 0:
							break;
						case 1:
							goto end_IL_001f;
						case 3:
							iNuBkhxbEbcLAIYMhAddRgEMijDn += Time.unscaledDeltaTime / GewecNFLnJAEHvrsREGsEANzXikW;
							num = 748080298;
							continue;
						case 5:
							vjxBdlDEuIvgZaBNLpWzCbRdlzVV = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.rectTransform;
							XbWCjQUXjLrqNmuDqcPwTdQVTSn = eNAeLDLTbmAsdtyVgrjCdfsiFPci.sDAkhoYrEZafWItRCkMCXhQGsTL(vjxBdlDEuIvgZaBNLpWzCbRdlzVV, BEDVoxNLBeqRJhchWAqhqSPVsYd);
							xtWvHvWSCGerwvzGvitqnhOItCW = (JduXYBqbDACUTxxZQjOzqMMbLTj - XbWCjQUXjLrqNmuDqcPwTdQVTSn).magnitude;
							if (!(xtWvHvWSCGerwvzGvitqnhOItCW < 0.01f))
							{
								ZzSaCQHlhEgTijsOQGwUlyKTOzqG._isMoving = true;
								GewecNFLnJAEHvrsREGsEANzXikW = xtWvHvWSCGerwvzGvitqnhOItCW / EWKgfOCaWksDFjQilyybAfeIqrUz;
								iNuBkhxbEbcLAIYMhAddRgEMijDn = 0f;
								num = 748080288;
								continue;
							}
							goto case 6;
						case 2:
							eNAeLDLTbmAsdtyVgrjCdfsiFPci.rRhYUvPnCuVwprINEAdgWHfmPUy(vjxBdlDEuIvgZaBNLpWzCbRdlzVV, Vector2.Lerp(XbWCjQUXjLrqNmuDqcPwTdQVTSn, JduXYBqbDACUTxxZQjOzqMMbLTj, Mathf.SmoothStep(0f, 1f, iNuBkhxbEbcLAIYMhAddRgEMijDn)), BEDVoxNLBeqRJhchWAqhqSPVsYd);
							RDkWcsTpvDaNZojjIZONnoEBXPC = null;
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 8:
							num = 748080296;
							continue;
						default:
							goto end_IL_0008;
						}
						int num3;
						if (!(iNuBkhxbEbcLAIYMhAddRgEMijDn <= 1f))
						{
							num = 748080302;
							num3 = num;
						}
						else
						{
							num = 748080299;
							num3 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public zSuWMdCOJyJqtXZnIEyseMRwlrD(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -1992455354;
					while (true)
					{
						switch (num ^ -1992455353)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 0:
							return;
						}
						break;
						IL_0024:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
						num = -1992455353;
					}
				}
			}
		}

		private const float MAX_MOVE_SPEED = 20f;

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		[SerializeField]
		private RectTransform _stickTransform;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The joystick's mode of operation. Set this to Digital to simulate a D-Pad which has only On/Off states. If you want mimic a real D-Pad, you should also set Snap Directions to 8.")]
		private JoystickMode _joystickMode;

		[Tooltip("A dead zone which is applied when Stick Mode is set to Digital. This is used to filter out tiny stick movements near 0, 0.")]
		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		[SerializeField]
		private float _digitalModeDeadZone = 0.3f;

		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[CustomObfuscation(rename = false)]
		[Range(0.01f, 1000f)]
		[SerializeField]
		private float _stickRange = 60f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		private bool _scaleStickRange = true;

		[SerializeField]
		[Tooltip("The shape of the range of movement of the joystick.")]
		[CustomObfuscation(rename = false)]
		private StickBounds _stickBounds;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		private AxisDirection _axesToUse;

		[SerializeField]
		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
		[CustomObfuscation(rename = false)]
		private SnapDirections _snapDirections;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		[SerializeField]
		private bool _snapStickToTouch;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
		private bool _centerStickOnRelease = true;

		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[SerializeField]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should taps on the touch pad be processed?")]
		private bool _allowTap;

		[FieldRange(0f, float.MaxValue)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		private float _tapTimeout = 0.25f;

		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		private int _tapDistanceLimit = 10;

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the joystick's RectTransform. This can be useful if you want a larger area of the screen to act as a joystick.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchRegion _touchRegion;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, hovers/clicks/touches on the local joystick will be ignored and only Touch Region touches will be used. Otherwise, both touches on the joystick and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		private bool _useTouchRegionOnly = true;

		[SerializeField]
		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		private bool _animateOnMoveToTouch = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		[SerializeField]
		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		private float _returnSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		private bool _manageRaycasting = true;

		private bool _useXAxis;

		private bool _useYAxis;

		private huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private FPYFNlfKuTtFhNHjyzBdbhLfBid _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool QlnYBBpzNpDLYXfPrVIqnYFRDKL;

		[NonSerialized]
		private bool tmlENZkWxfXAUYowkKtYqEQUwuh;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private YeelzijLJjtLIphMNHeBIxXHloAJ _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private cHqRtqSnvZYMLmoNYIQaJzSHZpkb _imageRaycastHelper = new cHqRtqSnvZYMLmoNYIQaJzSHZpkb();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<FPYFNlfKuTtFhNHjyzBdbhLfBid> __moveStartedDelegate;

		private Action<FPYFNlfKuTtFhNHjyzBdbhLfBid> __moveEndedDelegate;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the joystick value changes.")]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the joystick's stick position changes.")]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onStickPositionChanged = new ValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the joystick is touched.")]
		private TouchStartedEventHandler _onTouchStarted = new TouchStartedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchEndedEventHandler _onTouchEnded = new TouchEndedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		private TapEventHandler _onTap = new TapEventHandler();

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

		[CompilerGenerated]
		private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IValueChangedHandler, Vector2> CS_0024_003C_003E9__CachedAnonymousMethodDelegate8;

		[CompilerGenerated]
		private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IStickPositionChangedHandler, Vector2> CS_0024_003C_003E9__CachedAnonymousMethodDelegatea;

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

		public RectTransform stickTransform
		{
			get
			{
				return _stickTransform;
			}
			set
			{
				if (_stickTransform == value)
				{
					goto IL_000e;
				}
				goto IL_0049;
				IL_000e:
				int num = -1869135541;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ -1869135543)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						return;
					case 1:
						OnSetProperty();
						num = -1869135539;
						continue;
					case 3:
						goto IL_0049;
					case 4:
						return;
					}
					break;
				}
				goto IL_000e;
				IL_0049:
				_stickTransform = value;
				num = -1869135544;
				goto IL_0013;
			}
		}

		public JoystickMode joystickMode
		{
			get
			{
				return _joystickMode;
			}
			set
			{
				if (_joystickMode != value)
				{
					_joystickMode = value;
					OnSetProperty();
				}
			}
		}

		public float digitalModeDeadZone
		{
			get
			{
				return _digitalModeDeadZone;
			}
			set
			{
				value = MathTools.Clamp01(value);
				if (_digitalModeDeadZone == value)
				{
					return;
				}
				while (true)
				{
					_digitalModeDeadZone = value;
					OnSetProperty();
					int num = 1853416416;
					while (true)
					{
						switch (num ^ 0x6E78E3E1)
						{
						case 0:
							goto IL_0012;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0012:
						num = 1853416419;
					}
				}
			}
		}

		public float stickRange
		{
			get
			{
				return _stickRange;
			}
			set
			{
				value = MathTools.Clamp(value, 1f, 1000f);
				if (_stickRange != value)
				{
					_stickRange = value;
					OnSetProperty();
				}
			}
		}

		public bool scaleStickRange
		{
			get
			{
				return _scaleStickRange;
			}
			set
			{
				if (_scaleStickRange != value)
				{
					_scaleStickRange = value;
					OnSetProperty();
				}
			}
		}

		private StickBounds stickBounds
		{
			get
			{
				return _stickBounds;
			}
			set
			{
				if (_stickBounds != value)
				{
					_stickBounds = value;
					OnSetProperty();
				}
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
						switch (0x2E131ADC ^ 0x2E131ADD)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				WltfmBeoAglkdNsEoHeUJFYHTwoK(value);
				OnSetProperty();
			}
		}

		public SnapDirections snapDirections
		{
			get
			{
				return _snapDirections;
			}
			set
			{
				if (_snapDirections == value)
				{
					while (true)
					{
						switch (0x21209024 ^ 0x21209025)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_snapDirections = value;
				OnSetProperty();
			}
		}

		public bool snapStickToTouch
		{
			get
			{
				return _snapStickToTouch;
			}
			set
			{
				if (_snapStickToTouch == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -1865262712;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1865262711)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				_snapStickToTouch = value;
				OnSetProperty();
				num = -1865262711;
				goto IL_000e;
			}
		}

		public bool centerStickOnRelease
		{
			get
			{
				return _centerStickOnRelease;
			}
			set
			{
				if (_centerStickOnRelease != value)
				{
					_centerStickOnRelease = value;
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
					while (true)
					{
						switch (-236584431 ^ -236584429)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_activateOnSwipeIn = value;
				OnSetProperty();
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (LLTAgqLqZdxqORftayLlSimyXII())
				{
					return true;
				}
				return _stayActiveOnSwipeOut;
			}
			set
			{
				if (_stayActiveOnSwipeOut != value)
				{
					_stayActiveOnSwipeOut = value;
					OnSetProperty();
				}
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
				if (_allowTap != value)
				{
					_allowTap = value;
					OnSetProperty();
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
					OnSetProperty();
					int num = -532793479;
					while (true)
					{
						switch (num ^ -532793480)
						{
						case 0:
							goto IL_0017;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0017:
						num = -532793478;
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
				while (true)
				{
					int num = 1948813107;
					while (true)
					{
						switch (num ^ 0x74288731)
						{
						case 0:
							break;
						case 2:
						{
							int num2;
							if (_tapDistanceLimit != value)
							{
								num = 1948813104;
								num2 = num;
							}
							else
							{
								num = 1948813106;
								num2 = num;
							}
							continue;
						}
						case 3:
							return;
						default:
							_tapDistanceLimit = value;
							OnSetProperty();
							return;
						}
						break;
					}
				}
			}
		}

		public TouchRegion touchRegion
		{
			get
			{
				return _touchRegion;
			}
			set
			{
				if (_touchRegion == value)
				{
					return;
				}
				while (true)
				{
					_touchRegion = value;
					int num = -1501055301;
					while (true)
					{
						switch (num ^ -1501055303)
						{
						case 0:
							goto IL_000f;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000f:
						num = -1501055304;
					}
				}
			}
		}

		public bool useTouchRegionOnly
		{
			get
			{
				return _useTouchRegionOnly;
			}
			set
			{
				if (_useTouchRegionOnly == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 1046348159;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x3E5E017E)
				{
				case 2:
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
				_useTouchRegionOnly = value;
				num = 1046348158;
				goto IL_000e;
			}
		}

		public bool moveToTouchPosition
		{
			get
			{
				return _moveToTouchPosition;
			}
			set
			{
				if (_moveToTouchPosition != value)
				{
					_moveToTouchPosition = value;
					OnSetProperty();
				}
			}
		}

		public bool returnOnRelease
		{
			get
			{
				return _returnOnRelease;
			}
			set
			{
				if (_returnOnRelease == value)
				{
					while (true)
					{
						switch (0xE985B8D ^ 0xE985B8C)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_returnOnRelease = value;
				OnSetProperty();
			}
		}

		public bool followTouchPosition
		{
			get
			{
				return _followTouchPosition;
			}
			set
			{
				if (_followTouchPosition != value)
				{
					_followTouchPosition = value;
					OnSetProperty();
				}
			}
		}

		public bool animateOnMoveToTouch
		{
			get
			{
				return _animateOnMoveToTouch;
			}
			set
			{
				if (_animateOnMoveToTouch == value)
				{
					return;
				}
				while (true)
				{
					_animateOnMoveToTouch = value;
					OnSetProperty();
					int num = 1999145394;
					while (true)
					{
						switch (num ^ 0x772889B2)
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
						num = 1999145395;
					}
				}
			}
		}

		public float moveToTouchSpeed
		{
			get
			{
				return _moveToTouchSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (_moveToTouchSpeed != value)
				{
					_moveToTouchSpeed = value;
					OnSetProperty();
				}
			}
		}

		public bool animateOnReturn
		{
			get
			{
				return _animateOnReturn;
			}
			set
			{
				if (_animateOnReturn != value)
				{
					_animateOnReturn = value;
					OnSetProperty();
				}
			}
		}

		public float returnSpeed
		{
			get
			{
				return _returnSpeed;
			}
			set
			{
				value = MathTools.Clamp(value, 0f, 20f);
				if (_returnSpeed != value)
				{
					_returnSpeed = value;
					OnSetProperty();
				}
			}
		}

		public bool manageRaycasting
		{
			get
			{
				return _manageRaycasting;
			}
			set
			{
				if (_manageRaycasting == value)
				{
					return;
				}
				while (true)
				{
					_manageRaycasting = value;
					int num;
					int num2;
					if (!value)
					{
						num = 412945085;
						num2 = num;
					}
					else
					{
						num = 412945084;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x189D0ABC)
						{
						case 4:
							num = 412945087;
							continue;
						case 1:
							_imageRaycastHelper.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
							num = 412945086;
							continue;
						case 0:
							iWWhqovcLkzXONoZDjLpTHNUCDo();
							num = 412945086;
							continue;
						case 3:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
					}
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

		private bool tapValue
		{
			get
			{
				return _lastTapFrame == Time.frameCount;
			}
		}

		internal StandaloneAxis2D axis2D
		{
			get
			{
				return _axis2D;
			}
		}

		private Action<FPYFNlfKuTtFhNHjyzBdbhLfBid> moveStartedDelegate
		{
			get
			{
				if (__moveStartedDelegate == null)
				{
					return __moveStartedDelegate = VIyzHkWsNtqxypeBrFgRAHUVADKV;
				}
				return __moveStartedDelegate;
			}
		}

		private Action<FPYFNlfKuTtFhNHjyzBdbhLfBid> moveEndedDelegate
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = AFZfKuwjkqTUacvfdthqlbegOzJ;
				}
				return __moveEndedDelegate;
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

		private RectTransform touchReferenceTransform
		{
			get
			{
				if (_lastClaimSource != YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO)
				{
					return base.transform as RectTransform;
				}
				return base.transform.parent as RectTransform;
			}
		}

		private float calculatedStickRange
		{
			get
			{
				if (Time.frameCount == _calculatedStickRange_lastUpdatedFrame)
				{
					goto IL_0010;
				}
				RectTransform rectTransform = base.canvasTransform;
				int num = 2111604427;
				goto IL_0015;
				IL_0015:
				Vector3 lossyScale = default(Vector3);
				Vector3 lossyScale2 = default(Vector3);
				RectTransform rectTransform2 = default(RectTransform);
				float magnitude = default(float);
				Vector3 a = default(Vector3);
				while (true)
				{
					switch (num ^ 0x7DDC86C1)
					{
					case 3:
						break;
					case 6:
						if (lossyScale.x != 0f)
						{
							lossyScale2.x /= lossyScale.x;
							num = 2111604426;
							continue;
						}
						goto case 11;
					case 10:
						rectTransform2 = touchReferenceTransform;
						num = 2111604420;
						continue;
					case 8:
						lossyScale2 = rectTransform2.lossyScale;
						num = 2111604423;
						continue;
					case 11:
						if (lossyScale.y != 0f)
						{
							lossyScale2.y /= lossyScale.y;
							num = 2111604416;
							continue;
						}
						goto case 1;
					case 4:
						magnitude = a.magnitude;
						num = 2111604417;
						continue;
					case 7:
						return __calculatedStickRange_cachedValue;
					case 2:
						magnitude = Vector3.Scale(a, lossyScale2).magnitude;
						num = 2111604417;
						continue;
					case 9:
						if (_lastClaimSource == YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO)
						{
							lossyScale2.Scale(base.transform.localScale);
							num = 2111604419;
							continue;
						}
						goto case 2;
					case 5:
					{
						Vector3 position = new Vector3(0f, _stickRange, 0f);
						Vector3 vector = rectTransform.TransformPoint(position) - rectTransform.position;
						a = rectTransform2.InverseTransformPoint(vector + rectTransform2.position);
						if (_scaleStickRange)
						{
							lossyScale = rectTransform.lossyScale;
							num = 2111604425;
							continue;
						}
						goto case 4;
					}
					case 1:
						if (lossyScale.z != 0f)
						{
							lossyScale2.z /= lossyScale.z;
							num = 2111604424;
							continue;
						}
						goto case 9;
					default:
						__calculatedStickRange_cachedValue = magnitude;
						_calculatedStickRange_lastUpdatedFrame = Time.frameCount;
						return magnitude;
					}
					break;
				}
				goto IL_0010;
				IL_0010:
				num = 2111604422;
				goto IL_0015;
			}
		}

		internal static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IValueChangedHandler, Vector2> valueChangedHandlerDelegate
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate8 == null)
					{
						CS_0024_003C_003E9__CachedAnonymousMethodDelegate8 = delegate(IValueChangedHandler P_0, Vector2 P_1)
						{
							P_0.OnValueChanged(P_1);
						};
						goto IL_001f;
					}
					goto IL_003d;
				}
				goto IL_004e;
				IL_003d:
				__valueChangedHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate8;
				int num = -1611897024;
				goto IL_0024;
				IL_004e:
				return __valueChangedHandlerDelegate;
				IL_001f:
				num = -1611897021;
				goto IL_0024;
				IL_0024:
				switch (num ^ -1611897022)
				{
				case 0:
					break;
				case 1:
					goto IL_003d;
				default:
					goto IL_004e;
				}
				goto IL_001f;
			}
		}

		internal static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IStickPositionChangedHandler, Vector2> stickPositionChangedHandlerDelegate
		{
			get
			{
				if (__stickPositionChangedHandlerDelegate == null)
				{
					if (CS_0024_003C_003E9__CachedAnonymousMethodDelegatea == null)
					{
						goto IL_000e;
					}
					goto IL_0048;
				}
				goto IL_0059;
				IL_0048:
				__stickPositionChangedHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegatea;
				int num = 1850969464;
				goto IL_0013;
				IL_000e:
				num = 1850969467;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ 0x6E538D79)
					{
					case 0:
						break;
					case 2:
						CS_0024_003C_003E9__CachedAnonymousMethodDelegatea = delegate(IStickPositionChangedHandler P_0, Vector2 P_1)
						{
							P_0.OnStickPositionChanged(P_1);
						};
						num = 1850969466;
						continue;
					case 3:
						goto IL_0048;
					default:
						goto IL_0059;
					}
					break;
				}
				goto IL_000e;
				IL_0059:
				return __stickPositionChangedHandlerDelegate;
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

		public event UnityAction<Vector2> StickPositionChangedEvent
		{
			add
			{
				_onStickPositionChanged.AddListener(value);
			}
			remove
			{
				_onStickPositionChanged.RemoveListener(value);
			}
		}

		public event UnityAction TouchDownEvent
		{
			add
			{
				_onTouchStarted.AddListener(value);
			}
			remove
			{
				_onTouchStarted.RemoveListener(value);
			}
		}

		public event UnityAction TouchUpEvent
		{
			add
			{
				_onTouchEnded.AddListener(value);
			}
			remove
			{
				_onTouchEnded.RemoveListener(value);
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

		[CustomObfuscation(rename = false)]
		private TouchJoystick()
		{
		}

		public Vector2 GetValue()
		{
			if (!base.initialized)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.value;
		}

		public Vector2 GetRawValue()
		{
			if (!base.initialized)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.rawValue;
		}

		public void SetRawValue(Vector2 value)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				IL_016b:
				if (_joystickMode != JoystickMode.Digital)
				{
					goto IL_009a;
				}
				int num;
				if (value.sqrMagnitude <= _digitalModeDeadZone * _digitalModeDeadZone)
				{
					value.x = 0f;
					value.y = 0f;
					num = -787635496;
					goto IL_0011;
				}
				goto IL_0286;
				IL_0011:
				while (true)
				{
					switch (num ^ -787635501)
					{
					case 15:
						num = -787635502;
						continue;
					default:
						return;
					case 13:
						if (MathTools.IsNear(value.x, -1f, 0.0001f))
						{
							value.x = -1f;
							num = -787635500;
							continue;
						}
						goto case 7;
					case 11:
						num = -787635499;
						continue;
					case 6:
						break;
					case 12:
						if (MathTools.IsNear(value.y, -1f, 0.0001f))
						{
							value.y = -1f;
							num = -787635495;
							continue;
						}
						goto case 10;
					case 7:
						if (value.y != 0f)
						{
							goto IL_00f8;
						}
						goto case 10;
					case 4:
						value = MathTools.SnapVectorToNearestAngle(value, 360f / (float)_snapDirections);
						if (value.x == 0f)
						{
							goto case 7;
						}
						if (MathTools.IsNearZero(value.x, 0.0001f))
						{
							value.x = 0f;
							num = -787635500;
							continue;
						}
						goto IL_01bc;
					case 1:
						goto IL_016b;
					case 3:
						num = -787635500;
						continue;
					case 9:
						goto IL_01bc;
					case 8:
						value.x = 1f;
						num = -787635504;
						continue;
					case 2:
						if (MathTools.IsNear(value.y, 1f, 0.0001f))
						{
							value.y = 1f;
							num = -787635495;
							continue;
						}
						goto case 12;
					case 5:
						_axis2D.SetRawValue(_useXAxis ? value.x : 0f, _useYAxis ? value.y : 0f);
						num = -787635501;
						continue;
					case 14:
						value.y = 0f;
						num = -787635495;
						continue;
					case 16:
						goto IL_0286;
					case 10:
						if (_useXAxis)
						{
							goto case 5;
						}
						goto IL_029f;
					case 0:
						return;
					}
					break;
					IL_01bc:
					int num2;
					if (!MathTools.IsNear(value.x, 1f, 0.0001f))
					{
						num = -787635490;
						num2 = num;
					}
					else
					{
						num = -787635493;
						num2 = num;
					}
					continue;
					IL_00f8:
					int num3;
					if (!MathTools.IsNearZero(value.y, 0.0001f))
					{
						num = -787635503;
						num3 = num;
					}
					else
					{
						num = -787635491;
						num3 = num;
					}
					continue;
					IL_029f:
					int num4;
					if (!_useYAxis)
					{
						num = -787635501;
						num4 = num;
					}
					else
					{
						num = -787635498;
						num4 = num;
					}
				}
				goto IL_009a;
				IL_0286:
				value.Normalize();
				num = -787635499;
				goto IL_0011;
				IL_009a:
				int num5;
				if (_snapDirections != SnapDirections.None)
				{
					num = -787635497;
					num5 = num;
				}
				else
				{
					num = -787635495;
					num5 = num;
				}
				goto IL_0011;
			}
		}

		public void SetDefaultPosition()
		{
			UgKvFMVXcKNGPxTOwsIwvbOJKWy(base.rectTransform.anchoredPosition);
		}

		private void UgKvFMVXcKNGPxTOwsIwvbOJKWy(Vector2 P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 47004813;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x2CD3C8E)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				return;
			case 0:
				goto IL_0032;
			case 1:
				return;
			}
			goto IL_0008;
			IL_0032:
			_origAnchoredPosition = P_0;
			num = 47004815;
			goto IL_000d;
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (-723338563 ^ -723338561)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			hQeCbaPdhGazQaWjtkPsBzddKed(_origAnchoredPosition, PositionType.huHVQQAcuxcYyCLZjEIJOChEJYa, !instant && _animateOnReturn, _returnSpeed, FPYFNlfKuTtFhNHjyzBdbhLfBid.kDQhddPzDwumddhEyJEvsPyPkgY);
		}

		public void ReturnToDefaultPosition()
		{
			if (base.initialized)
			{
				ReturnToDefaultPosition(false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (!Application.isPlaying)
			{
				goto IL_000d;
			}
			goto IL_003f;
			IL_000d:
			int num = -1501911218;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1501911222)
				{
				case 3:
					break;
				default:
					return;
				case 4:
					return;
				case 0:
					goto IL_003f;
				case 1:
					SetRawValue(axis2D.rawZero);
					num = -1501911224;
					continue;
				case 5:
					if (_stickTransform != null)
					{
						_origStickAnchoredPosition = _stickTransform.anchoredPosition;
						num = -1501911221;
						continue;
					}
					goto case 1;
				case 2:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_003f:
			_origAnchoredPosition = base.rectTransform.anchoredPosition;
			num = -1501911217;
			goto IL_0012;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.initialized)
			{
				cIMxKKikLZEqzDDbOdedgdvAfBZi();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				_axis2D.Deinitialize();
				int num = -1421400362;
				while (true)
				{
					switch (num ^ -1421400364)
					{
					case 0:
						goto IL_000f;
					case 1:
						break;
					default:
						OnClear();
						return;
					}
					break;
					IL_000f:
					num = -1421400363;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			while (true)
			{
				switch (-669189612 ^ -669189611)
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
			UtBolprlOWliIGJGYPhPmCxwKqH();
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (base.initialized)
			{
				qJMamGLEEHdGsPSzzqthyOviLcp();
				xvhEjvVFsFrafXEEWHZdWOefBUF();
				IBequgtYajRRqjVlZlDTJkMfzbY();
			}
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			UtBolprlOWliIGJGYPhPmCxwKqH();
			_axis2D.Initialize();
			return true;
		}

		internal override void OnCustomControllerUpdate()
		{
			if (!base.initialized)
			{
				goto IL_000b;
			}
			goto IL_009a;
			IL_000b:
			int num = -1816447450;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num ^ -1816447453)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					goto IL_0040;
				case 6:
					goto IL_0059;
				case 2:
					goto IL_009a;
				case 1:
					goto IL_00ad;
				case 4:
					KyhNArefdFIxsvhHWTOXrRXnSZY(_tapCustomControllerElement, tapValue);
					num = -1816447452;
					continue;
				case 5:
					return;
				case 7:
					return;
				}
				break;
			}
			goto IL_000b;
			IL_009a:
			if (!hasController)
			{
				return;
			}
			goto IL_0059;
			IL_0040:
			int num2;
			if (_allowTap)
			{
				num = -1816447449;
				num2 = num;
			}
			else
			{
				num = -1816447452;
				num2 = num;
			}
			goto IL_0010;
			IL_0059:
			Vector2 value = _axis2D.value;
			if (_useXAxis)
			{
				KyhNArefdFIxsvhHWTOXrRXnSZY(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
				num = -1816447454;
				goto IL_0010;
			}
			goto IL_00ad;
			IL_00ad:
			if (_useYAxis)
			{
				KyhNArefdFIxsvhHWTOXrRXnSZY(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
				num = -1816447456;
				goto IL_0010;
			}
			goto IL_0040;
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			_axis2D.ValueChangedEvent += ikGcuzFLbQzirRQpqnEOPYpKOAv;
		}

		internal override void OnUnsubscribeEvents()
		{
			base.OnUnsubscribeEvents();
			_axis2D.ValueChangedEvent -= ikGcuzFLbQzirRQpqnEOPYpKOAv;
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = -231538727;
			goto IL_0013;
			IL_0013:
			switch (num ^ -231538726)
			{
			case 2:
				break;
			case 3:
				return;
			case 0:
				goto IL_0038;
			default:
				cIMxKKikLZEqzDDbOdedgdvAfBZi();
				return;
			}
			goto IL_000e;
			IL_0038:
			UtBolprlOWliIGJGYPhPmCxwKqH();
			num = -231538725;
			goto IL_0013;
		}

		internal override void OnClear()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
				tmlENZkWxfXAUYowkKtYqEQUwuh = false;
				_pointerDownIsFake = false;
				int num = -2036863382;
				while (true)
				{
					switch (num ^ -2036863379)
					{
					case 0:
						num = -2036863380;
						continue;
					default:
						return;
					case 3:
						_lastPressStartingValue = Vector2.zero;
						_calculatedStickRange_lastUpdatedFrame = -1;
						num = -2036863383;
						continue;
					case 7:
						_lastPressAnchoredPosition = Vector2.zero;
						num = -2036863378;
						continue;
					case 4:
						_lastTapFrame = -1;
						_isEligibleForTap = false;
						if (_returnOnRelease && _isMovedFromDefaultPosition)
						{
							if (!_moveToTouchPosition)
							{
								int num2;
								if (_followTouchPosition)
								{
									num = -2036863381;
									num2 = num;
								}
								else
								{
									num = -2036863384;
									num2 = num;
								}
								continue;
							}
							goto case 6;
						}
						goto case 5;
					case 6:
						ReturnToDefaultPosition(true);
						num = -2036863384;
						continue;
					case 1:
						break;
					case 5:
						_isMovedFromDefaultPosition = false;
						_isMoving = false;
						_moveDirection = FPYFNlfKuTtFhNHjyzBdbhLfBid.iOlZgcuFwLCPNAjSgaSDuxucio;
						fgggXZrtEesUbQzeFuxUPcrQeRfJ();
						_axis2D.Clear();
						cIMxKKikLZEqzDDbOdedgdvAfBZi();
						num = -2036863377;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		internal override void FindEventHandlers()
		{
			base.FindEventHandlers();
			if (_hierarchyValueChangedHandlers == null)
			{
				goto IL_000e;
			}
			goto IL_004b;
			IL_000e:
			int num = -420806677;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -420806678)
				{
				case 0:
					break;
				case 1:
					_hierarchyValueChangedHandlers = new huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IValueChangedHandler, Vector2>(valueChangedHandlerDelegate);
					num = -420806680;
					continue;
				case 2:
					goto IL_004b;
				case 4:
					_hierarchyStickPositionChangedHandlers = new huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(stickPositionChangedHandlerDelegate);
					num = -420806679;
					continue;
				default:
					_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
					return;
				}
				break;
			}
			goto IL_000e;
			IL_004b:
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			int num2;
			if (_hierarchyStickPositionChangedHandlers != null)
			{
				num = -420806679;
				num2 = num;
			}
			else
			{
				num = -420806674;
				num2 = num;
			}
			goto IL_0013;
		}

		public override void ClearValue()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_005f;
			IL_0008:
			int num = -1680802205;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1680802207)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					return;
				case 4:
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
					base.controller.ClearElementValue(_tapCustomControllerElement);
					num = -1680802207;
					continue;
				case 1:
					goto IL_005f;
				case 0:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_005f:
			_axis2D.Clear();
			_lastTapFrame = -1;
			if (hasController)
			{
				base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
				num = -1680802203;
				goto IL_000d;
			}
		}

		internal override bool IsPressed()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				return false;
			}
			return QlnYBBpzNpDLYXfPrVIqnYFRDKL;
		}

		internal override bool IsThisOrTouchRegionGameObject(GameObject P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (base.IsThisOrTouchRegionGameObject(P_0))
			{
				return true;
			}
			if (_workingTouchRegion != null)
			{
				return _workingTouchRegion.gameObject == P_0;
			}
			return false;
		}

		private void cIMxKKikLZEqzDDbOdedgdvAfBZi()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			while (true)
			{
				int num = 81002068;
				while (true)
				{
					switch (num ^ 0x4D3FE55)
					{
					case 2:
						break;
					case 1:
						goto IL_0034;
					default:
						IBequgtYajRRqjVlZlDTJkMfzbY();
						iWWhqovcLkzXONoZDjLpTHNUCDo();
						return;
					}
					break;
					IL_0034:
					_tapCustomControllerElement.ClearElementCaches();
					num = 81002069;
				}
			}
		}

		private void iWWhqovcLkzXONoZDjLpTHNUCDo()
		{
			if (_manageRaycasting)
			{
				_imageRaycastHelper.mkbZMChGYDoTKCWjjeEtIdAOcVVA(base.transform, SVAETGmUIJXUZncESXWxVhCkFKc());
			}
		}

		private bool SVAETGmUIJXUZncESXWxVhCkFKc()
		{
			if (_workingTouchRegion != null)
			{
				while (true)
				{
					int num = -320577043;
					while (true)
					{
						switch (num ^ -320577044)
						{
						case 2:
							break;
						case 1:
							goto IL_002c;
						default:
							return false;
						}
						break;
						IL_002c:
						if (!_useTouchRegionOnly)
						{
							goto end_IL_000e;
						}
						num = -320577044;
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			return true;
		}

		private void fxGzCSkWWmtevdNVRZAQTujeJAk(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				goto IL_000c;
			}
			goto IL_00e1;
			IL_000c:
			int num = -2035164227;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ -2035164225)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					P_0.PointerDownEvent += lzqUemmLiWpBjHlLmGrpmuhFrlo;
					P_0.PointerUpEvent += UEcgqxIblHuJqokaoodfjjxksQmz;
					P_0.PointerEnterEvent += UkqepPwTKhKlSSYpykoMGilKlBO;
					P_0.PointerExitEvent += FdfJZopCusKoJSmKfyVDmEfTHFm;
					num = -2035164230;
					continue;
				case 0:
					P_0.DragEvent += elPOduWEbDBmbJjpWoPrFoUTehqQ;
					P_0.EndDragEvent += ptNzRrfAVKsNlEekGdQzcnymCdJz;
					num = -2035164228;
					continue;
				case 5:
					P_0.BeginDragEvent += EHxgShUabCDTBywXirJDWBSRAdl;
					num = -2035164225;
					continue;
				case 2:
					return;
				case 6:
					goto IL_00e1;
				case 3:
					return;
				}
				break;
			}
			goto IL_000c;
			IL_00e1:
			dEJqrswYMslXTjicYopqMczugAC(P_0);
			num = -2035164226;
			goto IL_0011;
		}

		private void dEJqrswYMslXTjicYopqMczugAC(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				goto IL_0009;
			}
			goto IL_0036;
			IL_0009:
			int num = 717243522;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x2AC04483)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_0036;
			case 3:
				return;
			}
			goto IL_0009;
			IL_0036:
			P_0.PointerDownEvent -= lzqUemmLiWpBjHlLmGrpmuhFrlo;
			P_0.PointerUpEvent -= UEcgqxIblHuJqokaoodfjjxksQmz;
			P_0.PointerEnterEvent -= UkqepPwTKhKlSSYpykoMGilKlBO;
			P_0.PointerExitEvent -= FdfJZopCusKoJSmKfyVDmEfTHFm;
			P_0.BeginDragEvent -= EHxgShUabCDTBywXirJDWBSRAdl;
			P_0.DragEvent -= elPOduWEbDBmbJjpWoPrFoUTehqQ;
			P_0.EndDragEvent -= ptNzRrfAVKsNlEekGdQzcnymCdJz;
			num = 717243520;
			goto IL_000e;
		}

		private void IBequgtYajRRqjVlZlDTJkMfzbY()
		{
			if (!(_workingTouchRegion == _touchRegion))
			{
				dEJqrswYMslXTjicYopqMczugAC(_workingTouchRegion);
				_workingTouchRegion = _touchRegion;
				fxGzCSkWWmtevdNVRZAQTujeJAk(_workingTouchRegion);
			}
		}

		private void vUqurQgbViEJEHwXocSHTJSMPuDp(Vector2 P_0, bool P_1, float P_2, FPYFNlfKuTtFhNHjyzBdbhLfBid P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = eNAeLDLTbmAsdtyVgrjCdfsiFPci.DseKlDkkNmcmsDeTaDjKFrBMTXcs(base.canvas, rectTransform, P_0);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 sizeDelta = base.rectTransform.sizeDelta;
			Vector3 localScale = base.rectTransform.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			hQeCbaPdhGazQaWjtkPsBzddKed(vector, PositionType.hWboZvyXoJNhfSvesxqLLWrBcgF, P_1, P_2, P_3);
		}

		private void hQeCbaPdhGazQaWjtkPsBzddKed(Vector2 P_0, PositionType P_1, bool P_2, float P_3, FPYFNlfKuTtFhNHjyzBdbhLfBid P_4)
		{
			if (_isMoving)
			{
				goto IL_000b;
			}
			goto IL_00b5;
			IL_000b:
			int num = 17907565;
			goto IL_0010;
			IL_0010:
			float num3 = default(float);
			float num2 = default(float);
			Transform parent = default(Transform);
			RectTransform rectTransform = default(RectTransform);
			Vector2 one = default(Vector2);
			while (true)
			{
				switch (num ^ 0x1113F66)
				{
				case 5:
					break;
				default:
					return;
				case 11:
					if (P_2 && _moveDirection == P_4)
					{
						return;
					}
					goto IL_00b5;
				case 13:
					goto IL_0081;
				case 4:
					_isMoving = false;
					_moveDirection = FPYFNlfKuTtFhNHjyzBdbhLfBid.iOlZgcuFwLCPNAjSgaSDuxucio;
					num = 17907558;
					continue;
				case 6:
					goto IL_00b5;
				case 8:
					FdMktGOiqKeApBkgCYuESOjTorm(P_4, P_0, P_1);
					num = 17907575;
					continue;
				case 14:
					P_3 = P_3 / num3 * num2;
					_coroutineMove = tjPcPkDazEzSfOwRBVeZGdakazv(P_0, P_1, P_3, P_4);
					num = 17907572;
					continue;
				case 3:
					Logger.LogWarning("Animation cannot be used without a Canvas.");
					P_2 = false;
					num = 17907553;
					continue;
				case 1:
					goto IL_0122;
				case 15:
					if (base.canvas.renderMode == RenderMode.WorldSpace)
					{
						Logger.LogWarning("Animation can only be used with a screen space Canvas.");
						num = 17907574;
						continue;
					}
					goto case 7;
				case 2:
					fgggXZrtEesUbQzeFuxUPcrQeRfJ();
					num = 17907554;
					continue;
				case 7:
					if (P_2)
					{
						parent = base.transform;
						rectTransform = base.canvasTransform;
						one = Vector2.one;
						num = 17907559;
						continue;
					}
					goto case 9;
				case 0:
					goto IL_019c;
				case 12:
					if (!(parent == null))
					{
						one.x *= parent.localScale.x;
						one.y *= parent.localScale.y;
						num = 17907559;
						continue;
					}
					goto case 10;
				case 18:
					StartCoroutine(_coroutineMove);
					_moveDirection = P_4;
					_isMovedFromDefaultPosition = true;
					moveStartedDelegate(P_4);
					return;
				case 16:
					P_2 = false;
					num = 17907553;
					continue;
				case 9:
					moveStartedDelegate(P_4);
					num = 17907566;
					continue;
				case 10:
				{
					Vector2 sizeDelta = rectTransform.sizeDelta;
					bool flag = sizeDelta.x < sizeDelta.y;
					num2 = MathTools.Max(sizeDelta.x, sizeDelta.y);
					num3 = (flag ? one.y : one.x);
					if (num3 == 0f)
					{
						num3 = 0.0001f;
						num = 17907560;
						continue;
					}
					goto case 14;
				}
				case 17:
					return;
				}
				break;
				IL_019c:
				int num4;
				if (!(base.canvas == null))
				{
					num = 17907561;
					num4 = num;
				}
				else
				{
					num = 17907557;
					num4 = num;
				}
				continue;
				IL_0122:
				int num5;
				if ((parent = parent.parent) != rectTransform)
				{
					num = 17907562;
					num5 = num;
				}
				else
				{
					num = 17907564;
					num5 = num;
				}
				continue;
				IL_0081:
				int num6;
				if (_coroutineMove == null)
				{
					num = 17907558;
					num6 = num;
				}
				else
				{
					num = 17907556;
					num6 = num;
				}
			}
			goto IL_000b;
			IL_00b5:
			int num7;
			if (_isMoving)
			{
				num = 17907563;
				num7 = num;
			}
			else
			{
				num = 17907558;
				num7 = num;
			}
			goto IL_0010;
		}

		private IEnumerator tjPcPkDazEzSfOwRBVeZGdakazv(Vector2 P_0, PositionType P_1, float P_2, FPYFNlfKuTtFhNHjyzBdbhLfBid P_3)
		{
			zSuWMdCOJyJqtXZnIEyseMRwlrD zSuWMdCOJyJqtXZnIEyseMRwlrD2 = new zSuWMdCOJyJqtXZnIEyseMRwlrD(0);
			zSuWMdCOJyJqtXZnIEyseMRwlrD2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			zSuWMdCOJyJqtXZnIEyseMRwlrD2.JduXYBqbDACUTxxZQjOzqMMbLTj = P_0;
			zSuWMdCOJyJqtXZnIEyseMRwlrD2.BEDVoxNLBeqRJhchWAqhqSPVsYd = P_1;
			zSuWMdCOJyJqtXZnIEyseMRwlrD2.EWKgfOCaWksDFjQilyybAfeIqrUz = P_2;
			zSuWMdCOJyJqtXZnIEyseMRwlrD2.yLCxvNsJdtnzXSCIkwezQoUNbSO = P_3;
			return zSuWMdCOJyJqtXZnIEyseMRwlrD2;
		}

		private void FdMktGOiqKeApBkgCYuESOjTorm(FPYFNlfKuTtFhNHjyzBdbhLfBid P_0, Vector2 P_1, PositionType P_2)
		{
			eNAeLDLTbmAsdtyVgrjCdfsiFPci.rRhYUvPnCuVwprINEAdgWHfmPUy(base.rectTransform, P_1, P_2);
			_isMoving = false;
			while (true)
			{
				int num = 176395978;
				while (true)
				{
					switch (num ^ 0xA8396CB)
					{
					case 5:
						break;
					case 3:
						num = 176395977;
						continue;
					case 4:
						if (P_0 == FPYFNlfKuTtFhNHjyzBdbhLfBid.XtRDenkmlflSSFYJThdxkTsQRdUi)
						{
							_isMovedFromDefaultPosition = true;
							num = 176395977;
							continue;
						}
						goto default;
					case 1:
					{
						_moveDirection = FPYFNlfKuTtFhNHjyzBdbhLfBid.iOlZgcuFwLCPNAjSgaSDuxucio;
						int num2;
						if (P_0 == FPYFNlfKuTtFhNHjyzBdbhLfBid.kDQhddPzDwumddhEyJEvsPyPkgY)
						{
							num = 176395979;
							num2 = num;
						}
						else
						{
							num = 176395983;
							num2 = num;
						}
						continue;
					}
					case 0:
						_isMovedFromDefaultPosition = false;
						num = 176395976;
						continue;
					default:
						fgggXZrtEesUbQzeFuxUPcrQeRfJ();
						moveEndedDelegate(P_0);
						return;
					}
					break;
				}
			}
		}

		private void VIyzHkWsNtqxypeBrFgRAHUVADKV(FPYFNlfKuTtFhNHjyzBdbhLfBid P_0)
		{
			bool flag;
			bool flag2;
			if (_manageRaycasting)
			{
				flag = false;
				flag2 = false;
				if (!_followTouchPosition)
				{
					goto IL_0053;
				}
				if (!stayActiveOnSwipeOut)
				{
					goto IL_0022;
				}
				goto IL_00c9;
			}
			return;
			IL_0053:
			int num;
			if (!_followTouchPosition)
			{
				int num2;
				if (!(_workingTouchRegion != null))
				{
					num = -836099082;
					num2 = num;
				}
				else
				{
					num = -836099081;
					num2 = num;
				}
				goto IL_0027;
			}
			goto IL_0089;
			IL_0089:
			if (flag)
			{
				_imageRaycastHelper.mkbZMChGYDoTKCWjjeEtIdAOcVVA(base.transform, flag2);
				num = -836099084;
				goto IL_0027;
			}
			return;
			IL_0022:
			num = -836099083;
			goto IL_0027;
			IL_0027:
			while (true)
			{
				switch (num ^ -836099082)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					goto IL_0053;
				case 4:
					if (P_0 == FPYFNlfKuTtFhNHjyzBdbhLfBid.XtRDenkmlflSSFYJThdxkTsQRdUi)
					{
						flag = true;
						flag2 = false;
						num = -836099082;
						continue;
					}
					goto IL_0089;
				case 0:
					goto IL_0089;
				case 1:
					goto IL_00a5;
				case 6:
					goto IL_00c9;
				case 2:
					return;
				}
				break;
				IL_00a5:
				if (!_useTouchRegionOnly)
				{
					int num3;
					if (!_moveToTouchPosition)
					{
						num = -836099082;
						num3 = num;
					}
					else
					{
						num = -836099088;
						num3 = num;
					}
					continue;
				}
				goto IL_0089;
			}
			goto IL_0022;
			IL_00c9:
			int num4;
			if (!_returnOnRelease)
			{
				num = -836099082;
				num4 = num;
			}
			else
			{
				num = -836099086;
				num4 = num;
			}
			goto IL_0027;
		}

		private void AFZfKuwjkqTUacvfdthqlbegOzJ(FPYFNlfKuTtFhNHjyzBdbhLfBid P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag = false;
			bool flag2 = default(bool);
			while (true)
			{
				int num = 373303193;
				while (true)
				{
					switch (num ^ 0x1640279A)
					{
					case 6:
						break;
					default:
						return;
					case 3:
						flag2 = false;
						if (_followTouchPosition)
						{
							int num3;
							if (!stayActiveOnSwipeOut)
							{
								num = 373303198;
								num3 = num;
							}
							else
							{
								num = 373303197;
								num3 = num;
							}
							continue;
						}
						goto case 4;
					case 1:
						flag = true;
						flag2 = SVAETGmUIJXUZncESXWxVhCkFKc();
						num = 373303192;
						continue;
					case 7:
					{
						int num4;
						if (!_returnOnRelease)
						{
							num = 373303192;
							num4 = num;
						}
						else
						{
							num = 373303194;
							num4 = num;
						}
						continue;
					}
					case 2:
						if (flag)
						{
							_imageRaycastHelper.mkbZMChGYDoTKCWjjeEtIdAOcVVA(base.transform, flag2);
							num = 373303199;
							continue;
						}
						return;
					case 0:
					{
						int num2;
						if (P_0 != FPYFNlfKuTtFhNHjyzBdbhLfBid.kDQhddPzDwumddhEyJEvsPyPkgY)
						{
							num = 373303192;
							num2 = num;
						}
						else
						{
							num = 373303195;
							num2 = num;
						}
						continue;
					}
					case 4:
						if (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly)
						{
							int num5;
							if (!_moveToTouchPosition)
							{
								num = 373303192;
								num5 = num;
							}
							else
							{
								num = 373303197;
								num5 = num;
							}
							continue;
						}
						goto case 2;
					case 5:
						return;
					}
					break;
				}
			}
		}

		private void fgggXZrtEesUbQzeFuxUPcrQeRfJ()
		{
			if (_coroutineMove != null)
			{
				try
				{
					StopCoroutine(_coroutineMove);
				}
				catch
				{
				}
				_coroutineMove = null;
			}
		}

		private void KKKzzptlCzpxEXyQiJDGcaVVucZ(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (!TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(P_0))
			{
				return;
			}
			while (true)
			{
				hQeCbaPdhGazQaWjtkPsBzddKed((Vector2)eNAeLDLTbmAsdtyVgrjCdfsiFPci.sDAkhoYrEZafWItRCkMCXhQGsTL(base.rectTransform, P_2) + P_1, P_2, false, 0f, FPYFNlfKuTtFhNHjyzBdbhLfBid.XtRDenkmlflSSFYJThdxkTsQRdUi);
				int num;
				int num2;
				if (_lastClaimSource != YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO)
				{
					num = 1620854921;
					num2 = num;
				}
				else
				{
					num = 1620854923;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x609C488B)
					{
					case 3:
						num = 1620854922;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						_lastPressAnchoredPosition += P_1;
						num = 1620854921;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void xvhEjvVFsFrafXEEWHZdWOefBUF()
		{
			if (!hasPointer)
			{
				return;
			}
			PointerEventData pointerEventData = default(PointerEventData);
			PointerEventData pointerEventData2 = default(PointerEventData);
			while (true)
			{
				IL_0126:
				int num;
				if (!TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
				{
					pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(effectivePointerId);
					int num2;
					if (pointerEventData != null)
					{
						num = -1095030526;
						num2 = num;
					}
					else
					{
						num = -1095030527;
						num2 = num;
					}
					goto IL_0011;
				}
				goto IL_0049;
				IL_0011:
				while (true)
				{
					switch (num ^ -1095030522)
					{
					case 0:
						num = -1095030528;
						continue;
					default:
						return;
					case 2:
						break;
					case 4:
						if (pointerEventData.pointerPress != null)
						{
							VGdcUqdPAuBHPLgxHVatOVpAQUrD(pointerEventData);
							num = -1095030523;
							continue;
						}
						goto case 7;
					case 5:
						goto IL_0081;
					case 3:
						return;
					case 7:
						SHIErtNBGDqtOcJrfCqGmlXqnbj();
						num = -1095030514;
						continue;
					case 8:
						return;
					case 9:
						CXvLmtALdadnijFWJqoItJecMJzN(pointerEventData2, _lastClaimSource);
						num = -1095030521;
						continue;
					case 6:
						goto IL_0126;
					case 1:
						return;
					}
					break;
					IL_0081:
					pointerEventData2 = brhALqGXLcCaGnAtXlrPijwseztm(effectivePointerId, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
					int num3;
					if (pointerEventData2 == null)
					{
						num = -1095030521;
						num3 = num;
					}
					else
					{
						num = -1095030513;
						num3 = num;
					}
				}
				goto IL_0049;
				IL_0049:
				int num4;
				if (!_pointerDownIsFake)
				{
					num = -1095030521;
					num4 = num;
				}
				else
				{
					num = -1095030525;
					num4 = num;
				}
				goto IL_0011;
			}
		}

		private void qJMamGLEEHdGsPSzzqthyOviLcp()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(effectivePointerId);
				WKnqeaxtWIogwqZlNbMiyijCYhx(ref vector);
			}
		}

		private void WKnqeaxtWIogwqZlNbMiyijCYhx(ref Vector2 P_0)
		{
			if (_allowTap)
			{
				if (!_isEligibleForTap)
				{
					goto IL_0010;
				}
				goto IL_0048;
			}
			return;
			IL_0082:
			int num;
			if (_tapDistanceLimit >= 0)
			{
				int num2;
				if (Vector2.Distance(_touchStartPosition, P_0) <= (float)_tapDistanceLimit)
				{
					num = -1351697966;
					num2 = num;
				}
				else
				{
					num = -1351697965;
					num2 = num;
				}
				goto IL_0015;
			}
			return;
			IL_0010:
			num = -1351697962;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1351697961)
				{
				case 2:
					break;
				default:
					return;
				case 4:
					_isEligibleForTap = false;
					num = -1351697966;
					continue;
				case 0:
					goto IL_0048;
				case 1:
					return;
				case 3:
					goto IL_0082;
				case 5:
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0048:
			if (_tapTimeout > 0f)
			{
				int num3;
				if (!(Time.realtimeSinceStartup - _touchStartTime > _tapTimeout))
				{
					num = -1351697964;
					num3 = num;
				}
				else
				{
					num = -1351697965;
					num3 = num;
				}
				goto IL_0015;
			}
			goto IL_0082;
		}

		private bool LLTAgqLqZdxqORftayLlSimyXII()
		{
			if (!_followTouchPosition)
			{
				return false;
			}
			if (_touchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void nnIbvzAiFmjEPCjsdxFWxHOPYIt()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF;
		}

		private bool KsFFXDTmNznRFMUIlONNipwkUlQ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				goto IL_0008;
			}
			if (_pointerId == int.MinValue)
			{
				return false;
			}
			if (_pointerId == P_0)
			{
				return true;
			}
			int num;
			if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0) && _realMousePointerId != int.MinValue)
			{
				num = 2086303119;
				goto IL_000d;
			}
			goto IL_0069;
			IL_005e:
			if (P_0 == _realMousePointerId)
			{
				return true;
			}
			goto IL_0069;
			IL_0008:
			num = 2086303116;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x7C5A758D)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				goto IL_005e;
			}
			goto IL_0008;
			IL_0069:
			return false;
		}

		private PointerEventData gxVyVSbhjrdJfymjdngkMthnlfz(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(P_0);
			GameObject gameObject3 = default(GameObject);
			float unscaledTime2 = default(float);
			GameObject gameObject2 = default(GameObject);
			float unscaledTime = default(float);
			GameObject gameObject = default(GameObject);
			while (true)
			{
				int num = -2002201161;
				while (true)
				{
					switch (num ^ -2002201163)
					{
					case 8:
						break;
					case 22:
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						num = -2002201160;
						continue;
					case 17:
						pointerEventData.clickCount = 1;
						num = -2002201158;
						continue;
					case 12:
					{
						int num6;
						if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
						{
							num = -2002201183;
							num6 = num;
						}
						else
						{
							num = -2002201157;
							num6 = num;
						}
						continue;
					}
					case 13:
					{
						gameObject3 = P_1;
						unscaledTime2 = Time.unscaledTime;
						if (!(gameObject3 == pointerEventData.lastPress))
						{
							goto case 17;
						}
						float num3 = unscaledTime2 - pointerEventData.clickTime;
						if (num3 < 0.3f)
						{
							pointerEventData.clickCount++;
							num = -2002201167;
							continue;
						}
						goto case 10;
					}
					case 11:
						pointerEventData.clickCount++;
						num = -2002201172;
						continue;
					case 0:
						pointerEventData.clickTime = unscaledTime2;
						num = -2002201158;
						continue;
					case 23:
						pointerEventData.rawPointerPress = gameObject2;
						num = -2002201164;
						continue;
					case 25:
						pointerEventData.clickTime = unscaledTime;
						num = -2002201166;
						continue;
					case 6:
						gameObject = P_1;
						unscaledTime = Time.unscaledTime;
						if (gameObject == pointerEventData.lastPress)
						{
							float num4 = unscaledTime - pointerEventData.clickTime;
							int num5;
							if (num4 >= 0.3f)
							{
								num = -2002201168;
								num5 = num;
							}
							else
							{
								num = -2002201154;
								num5 = num;
							}
							continue;
						}
						goto case 24;
					case 15:
						pointerEventData.pointerPress = gameObject3;
						num = -2002201182;
						continue;
					case 20:
						pointerEventData.eligibleForClick = true;
						pointerEventData.delta = Vector2.zero;
						pointerEventData.dragging = false;
						pointerEventData.useDragThreshold = true;
						pointerEventData.pressPosition = pointerEventData.position;
						num = -2002201181;
						continue;
					case 5:
						pointerEventData.clickCount = 1;
						num = -2002201172;
						continue;
					case 3:
					{
						int num2;
						if (!TouchInteractable.dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
						{
							num = -2002201159;
							num2 = num;
						}
						else
						{
							num = -2002201184;
							num2 = num;
						}
						continue;
					}
					case 7:
						num = -2002201178;
						continue;
					case 1:
						pointerEventData.clickTime = unscaledTime2;
						pointerEventData.pointerDrag = gameObject2;
						num = -2002201156;
						continue;
					case 4:
						num = -2002201163;
						continue;
					case 18:
						pointerEventData.delta = Vector2.zero;
						pointerEventData.dragging = false;
						pointerEventData.useDragThreshold = true;
						num = -2002201179;
						continue;
					case 16:
						pointerEventData.pressPosition = pointerEventData.position;
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						if (pointerEventData.pointerEnter != gameObject2)
						{
							pointerEventData.pointerEnter = gameObject2;
							num = -2002201165;
							continue;
						}
						goto case 6;
					case 24:
						pointerEventData.clickCount = 1;
						num = -2002201178;
						continue;
					case 2:
						if (pointerEventData == null)
						{
							return null;
						}
						gameObject2 = P_1;
						pointerEventData.position = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(P_0);
						num = -2002201162;
						continue;
					case 10:
						pointerEventData.clickCount = 1;
						num = -2002201163;
						continue;
					case 21:
						pointerEventData.eligibleForClick = true;
						num = -2002201177;
						continue;
					case 19:
						pointerEventData.pointerPress = gameObject;
						pointerEventData.rawPointerPress = gameObject2;
						pointerEventData.clickTime = unscaledTime;
						pointerEventData.pointerDrag = gameObject2;
						goto case 9;
					default:
						Logger.LogWarning("Unsupported pointerId: " + P_0);
						return null;
					case 9:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private PointerEventData brhALqGXLcCaGnAtXlrPijwseztm(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(P_0);
			while (true)
			{
				int num = -1795790372;
				while (true)
				{
					switch (num ^ -1795790376)
					{
					case 0:
						break;
					case 4:
						pointerEventData.delta = vector - pointerEventData.position;
						num = -1795790374;
						continue;
					case 3:
						pointerEventData.pointerPress = null;
						pointerEventData.rawPointerPress = null;
						num = -1795790375;
						continue;
					case 2:
						pointerEventData.position = vector;
						pointerEventData.dragging = true;
						pointerEventData.pointerDrag = P_1;
						pointerEventData.useDragThreshold = true;
						num = -1795790373;
						continue;
					default:
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
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				goto IL_0023;
			}
			goto IL_005b;
			IL_005b:
			int num;
			if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
			{
				pointerEventData.eligibleForClick = false;
				num = -1893997877;
				goto IL_0028;
			}
			goto IL_00b7;
			IL_00b7:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			return null;
			IL_0023:
			num = -1893997878;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num ^ -1893997874)
				{
				case 0:
					break;
				case 4:
					pointerEventData.rawPointerPress = null;
					num = -1893997873;
					continue;
				case 2:
					goto IL_005b;
				case 1:
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					pointerEventData.pointerEnter = null;
					goto IL_00ce;
				case 5:
					pointerEventData.pointerPress = null;
					pointerEventData.rawPointerPress = null;
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					goto IL_00ce;
				default:
					goto IL_00b7;
					IL_00ce:
					return pointerEventData;
				}
				break;
			}
			goto IL_0023;
		}

		private void VGdcUqdPAuBHPLgxHVatOVpAQUrD(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = 550536028;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x20D0835D)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_002d;
			case 0:
				return;
			}
			goto IL_0003;
			IL_002d:
			OnPointerUp(P_0);
			tzBbHeHAGAaQCwiFkPKWKUeCjYAn(effectivePointerId);
			num = 550536029;
			goto IL_0008;
		}

		private void CXvLmtALdadnijFWJqoItJecMJzN(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_006d;
			IL_0003:
			int num = -956900813;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -956900812)
				{
				case 0:
					break;
				case 7:
					return;
				case 1:
					elPOduWEbDBmbJjpWoPrFoUTehqQ(P_0);
					num = -956900815;
					continue;
				case 6:
					throw new NotImplementedException();
				case 4:
					goto IL_0058;
				case 2:
					goto IL_006d;
				case 3:
					OnDrag(P_0);
					num = -956900815;
					continue;
				default:
					tzBbHeHAGAaQCwiFkPKWKUeCjYAn(effectivePointerId);
					return;
				}
				break;
				IL_0058:
				int num2;
				if (P_1 != YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO)
				{
					num = -956900814;
					num2 = num;
				}
				else
				{
					num = -956900811;
					num2 = num;
				}
			}
			goto IL_0003;
			IL_006d:
			int num3;
			if (P_1 == YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF)
			{
				num = -956900809;
				num3 = num;
			}
			else
			{
				num = -956900816;
				num3 = num;
			}
			goto IL_0008;
		}

		private PointerEventData ZratKwUfLghYErsNiaeupeoKzqF(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				goto IL_000b;
			}
			int num;
			if (__fakePointerEventData == null)
			{
				__fakePointerEventData = new Dictionary<int, PointerEventData>();
				num = 2070644623;
				goto IL_0010;
			}
			goto IL_0096;
			IL_0096:
			PointerEventData value = default(PointerEventData);
			if (!__fakePointerEventData.TryGetValue(P_0, out value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				__fakePointerEventData.Add(P_0, value);
				int num2;
				if (!TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
				{
					num = 2070644618;
					num2 = num;
				}
				else
				{
					num = 2070644609;
					num2 = num;
				}
				goto IL_0010;
			}
			goto IL_010c;
			IL_010c:
			return value;
			IL_000b:
			num = 2070644622;
			goto IL_0010;
			IL_0010:
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			while (true)
			{
				switch (num ^ 0x7B6B8788)
				{
				case 4:
					break;
				case 0:
					button = PointerEventData.InputButton.Left;
					num = 2070644619;
					continue;
				case 9:
					switch (P_0)
					{
					case -1:
						break;
					default:
						goto IL_0068;
					case -2:
						goto IL_008a;
					case -3:
						goto IL_0100;
					}
					goto case 0;
				case 3:
					value.button = button;
					num = 2070644618;
					continue;
				case 1:
					throw new NotImplementedException();
				case 5:
					goto IL_008a;
				case 7:
					goto IL_0096;
				case 6:
					return null;
				case 8:
					goto IL_0100;
				default:
					goto IL_010c;
					IL_0100:
					button = PointerEventData.InputButton.Middle;
					num = 2070644619;
					continue;
					IL_008a:
					button = PointerEventData.InputButton.Right;
					num = 2070644619;
					continue;
					IL_0068:
					num = 2070644617;
					continue;
				}
				break;
			}
			goto IL_000b;
		}

		private void UtBolprlOWliIGJGYPhPmCxwKqH()
		{
			WltfmBeoAglkdNsEoHeUJFYHTwoK(_axesToUse);
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
					num = 924930092;
					num2 = num;
				}
				else
				{
					num = 924930088;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x37215029)
					{
					case 6:
						num = 924930093;
						continue;
					default:
						return;
					case 7:
						base.controller.ValidateElements(_tapCustomControllerElement);
						num = 924930091;
						continue;
					case 5:
						return;
					case 1:
						if (_useXAxis)
						{
							base.controller.ValidateElements(_horizontalAxisCustomControllerElement);
							num = 924930090;
							continue;
						}
						goto case 3;
					case 4:
						break;
					case 3:
						if (_useYAxis)
						{
							base.controller.ValidateElements(_verticalAxisCustomControllerElement);
							num = 924930089;
							continue;
						}
						goto case 0;
					case 0:
					{
						int num3;
						if (_allowTap)
						{
							num = 924930094;
							num3 = num;
						}
						else
						{
							num = 924930091;
							num3 = num;
						}
						continue;
					}
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void WltfmBeoAglkdNsEoHeUJFYHTwoK(AxisDirection P_0)
		{
			if (P_0 != AxisDirection.Both)
			{
				goto IL_0006;
			}
			int num = 1;
			goto IL_016f;
			IL_016f:
			bool flag = (byte)num != 0;
			int num2 = -1208672832;
			goto IL_000b;
			IL_0006:
			num2 = -1208672827;
			goto IL_000b;
			IL_000b:
			bool flag2 = default(bool);
			int targetCount2 = default(int);
			int targetCount = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1208672832)
				{
				case 6:
					break;
				case 11:
					if (!flag2 && hasController)
					{
						targetCount2 = _verticalAxisCustomControllerElement.targetCount;
						num2 = -1208672823;
						continue;
					}
					goto default;
				case 8:
					goto IL_0080;
				case 10:
					goto IL_009c;
				case 14:
					targetCount = _horizontalAxisCustomControllerElement.targetCount;
					num4 = 0;
					num2 = -1208672822;
					continue;
				case 15:
					num4++;
					num2 = -1208672822;
					continue;
				case 9:
					num3 = 0;
					num2 = -1208672820;
					continue;
				case 7:
					base.controller.ClearElementValue(_horizontalAxisCustomControllerElement[num4]);
					num2 = -1208672817;
					continue;
				case 4:
					goto IL_0108;
				case 13:
					goto IL_0126;
				case 12:
					goto IL_014e;
				case 5:
					goto IL_0168;
				case 0:
					goto IL_017a;
				case 2:
					_useYAxis = flag2;
					num2 = -1208672821;
					continue;
				case 1:
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement[num3]);
					num3++;
					num2 = -1208672820;
					continue;
				default:
					_axesToUse = P_0;
					return;
				}
				break;
				IL_017a:
				int num5;
				if (_useXAxis != flag)
				{
					num2 = -1208672828;
					num5 = num2;
				}
				else
				{
					num2 = -1208672819;
					num5 = num2;
				}
				continue;
				IL_0126:
				flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
				int num6;
				if (_useYAxis != flag2)
				{
					num2 = -1208672830;
					num6 = num2;
				}
				else
				{
					num2 = -1208672829;
					num6 = num2;
				}
				continue;
				IL_0080:
				int num7;
				if (hasController)
				{
					num2 = -1208672818;
					num7 = num2;
				}
				else
				{
					num2 = -1208672819;
					num7 = num2;
				}
				continue;
				IL_014e:
				int num8;
				if (num3 >= targetCount2)
				{
					num2 = -1208672829;
					num8 = num2;
				}
				else
				{
					num2 = -1208672831;
					num8 = num2;
				}
				continue;
				IL_0108:
				_useXAxis = flag;
				int num9;
				if (flag)
				{
					num2 = -1208672819;
					num9 = num2;
				}
				else
				{
					num2 = -1208672824;
					num9 = num2;
				}
				continue;
				IL_009c:
				int num10;
				if (num4 >= targetCount)
				{
					num2 = -1208672819;
					num10 = num2;
				}
				else
				{
					num2 = -1208672825;
					num10 = num2;
				}
			}
			goto IL_0006;
			IL_0168:
			num = ((P_0 == AxisDirection.Horizontal) ? 1 : 0);
			goto IL_016f;
		}

		private void ykLlbzWaLuNEKGAQUYLFIUwTpBY(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				return;
			}
			while (true)
			{
				IL_0065:
				int num;
				if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
				{
					int num2;
					if (IsInteractable())
					{
						num = 1557324226;
						num2 = num;
					}
					else
					{
						num = 1557324228;
						num2 = num;
					}
					goto IL_001c;
				}
				goto IL_003d;
				IL_001c:
				while (true)
				{
					switch (num ^ 0x5CD2E1C0)
					{
					case 3:
						num = 1557324225;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						PrhNrJNIlRPRCXgcxIuytulSRay(P_0.pointerId, P_0.pressPosition, P_1);
						num = 1557324228;
						continue;
					case 1:
						goto IL_0065;
					case 0:
						return;
					}
					break;
				}
				goto IL_003d;
				IL_003d:
				base.OnPointerDown(P_0);
				num = 1557324224;
				goto IL_001c;
			}
		}

		private void PKDpapVpBsZIfGwBoVYoUivnEgl(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (hasPointer)
			{
				while (true)
				{
					int num = -1569167935;
					while (true)
					{
						switch (num ^ -1569167934)
						{
						case 0:
							break;
						case 3:
							goto IL_002e;
						case 2:
							goto end_IL_0008;
						case 1:
							return;
						default:
							goto IL_006a;
						}
						break;
						IL_002e:
						int num2;
						if (!KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
						{
							num = -1569167933;
							num2 = num;
						}
						else
						{
							num = -1569167936;
							num2 = num;
						}
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
			{
				return;
			}
			goto IL_006a;
			IL_006a:
			SHIErtNBGDqtOcJrfCqGmlXqnbj();
			base.OnPointerUp(P_0);
		}

		private void LZkGGotiHtFpBawoWkiqWiNbAGgZ(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				return;
			}
			GameObject gameObject = default(GameObject);
			MouseButtonFlags mouseButtonFlags = default(MouseButtonFlags);
			YeelzijLJjtLIphMNHeBIxXHloAJ yeelzijLJjtLIphMNHeBIxXHloAJ = default(YeelzijLJjtLIphMNHeBIxXHloAJ);
			PointerEventData pointerEventData = default(PointerEventData);
			while (true)
			{
				bool flag = TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0.pointerId);
				bool flag2 = false;
				int num = 709841162;
				while (true)
				{
					switch (num ^ 0x2A4F511B)
					{
					case 2:
						num = 709841169;
						continue;
					case 10:
						break;
					case 6:
						flag2 = true;
						num = 709841183;
						continue;
					case 8:
						gameObject = base.gameObject;
						num = 709841179;
						continue;
					case 3:
					{
						if (!flag)
						{
							goto case 6;
						}
						int realMousePointerId;
						if (TouchInteractable.TrwaVKkqmuGmcHocRVPXaUPcSGp(mouseButtonFlags, out realMousePointerId))
						{
							_realMousePointerId = realMousePointerId;
							num = 709841181;
							continue;
						}
						goto case 18;
					}
					case 13:
						mouseButtonFlags = _touchRegion.allowedMouseButtons;
						num = 709841180;
						continue;
					case 9:
						goto IL_00ea;
					case 17:
						yeelzijLJjtLIphMNHeBIxXHloAJ = P_1;
						num = 709841172;
						continue;
					case 20:
					{
						int num3;
						if (QlnYBBpzNpDLYXfPrVIqnYFRDKL)
						{
							num = 709841183;
							num3 = num;
						}
						else
						{
							num = 709841176;
							num3 = num;
						}
						continue;
					}
					case 4:
						base.OnPointerEnter(P_0);
						if (flag2)
						{
							switch (P_1)
							{
							case YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF:
								break;
							case YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO:
								goto IL_00ea;
							default:
								goto IL_0154;
							}
							goto case 8;
						}
						goto default;
					case 0:
						num = 709841173;
						continue;
					case 19:
						throw new NotImplementedException();
					case 7:
						if (_activateOnSwipeIn && WMOIUVAoMMEQPQHrJmvWWfvqFVh() && IsInteractable())
						{
							if (!flag)
							{
								num = 709841167;
								continue;
							}
							if (TouchInteractable.FDenAmVtwBdAcjaFssMofuoOzsP(mouseButtonFlags))
							{
								goto case 20;
							}
						}
						goto case 4;
					case 5:
						goto IL_01a0;
					case 1:
						_pointerDownIsFake = true;
						num = 709841168;
						continue;
					case 12:
						throw new NotImplementedException();
					case 16:
						if (pointerEventData != null)
						{
							ykLlbzWaLuNEKGAQUYLFIUwTpBY(pointerEventData, P_1);
							int num2;
							if (!QlnYBBpzNpDLYXfPrVIqnYFRDKL)
							{
								num = 709841168;
								num2 = num;
							}
							else
							{
								num = 709841178;
								num2 = num;
							}
							continue;
						}
						goto default;
					case 18:
						_realMousePointerId = P_0.pointerId;
						num = 709841181;
						continue;
					case 15:
						switch (yeelzijLJjtLIphMNHeBIxXHloAJ)
						{
						case YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO:
							break;
						case YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF:
							goto IL_01a0;
						default:
							goto IL_0223;
						}
						goto case 13;
					case 14:
						pointerEventData = gxVyVSbhjrdJfymjdngkMthnlfz((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
						num = 709841163;
						continue;
					default:
						{
							tmlENZkWxfXAUYowkKtYqEQUwuh = true;
							return;
						}
						IL_0154:
						num = 709841175;
						continue;
						IL_0223:
						num = 709841160;
						continue;
						IL_01a0:
						mouseButtonFlags = base.allowedMouseButtons;
						num = 709841180;
						continue;
						IL_00ea:
						gameObject = _workingTouchRegion.gameObject;
						num = 709841173;
						continue;
					}
					break;
				}
			}
		}

		private void jnQPXNUYsptUbWdLIawDCCMiSiQ(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				goto IL_0016;
			}
			goto IL_007a;
			IL_007a:
			int num;
			int num2;
			if (!stayActiveOnSwipeOut)
			{
				num = -787373566;
				num2 = num;
			}
			else
			{
				num = -787373561;
				num2 = num;
			}
			goto IL_001b;
			IL_0016:
			num = -787373568;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ -787373564)
				{
				case 2:
					break;
				case 4:
					base.OnPointerExit(P_0);
					return;
				case 6:
					goto IL_0053;
				case 3:
					base.OnPointerExit(P_0);
					num = -787373564;
					continue;
				case 5:
					goto IL_007a;
				case 1:
					SHIErtNBGDqtOcJrfCqGmlXqnbj();
					num = -787373561;
					continue;
				default:
					tmlENZkWxfXAUYowkKtYqEQUwuh = false;
					return;
				}
				break;
				IL_0053:
				int num3;
				if (!QlnYBBpzNpDLYXfPrVIqnYFRDKL)
				{
					num = -787373561;
					num3 = num;
				}
				else
				{
					num = -787373563;
					num3 = num;
				}
			}
			goto IL_0016;
		}

		private void iosotEIsCfFFIfRvzfxosSeUoge(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (hasPointer && KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				base.OnBeginDrag(P_0);
			}
		}

		private void BMTfaxkpbqwedhJUBlpcGCTKAYUf(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (!hasPointer)
			{
				return;
			}
			Vector2 vector2 = default(Vector2);
			Vector2 vector3 = default(Vector2);
			bool flag = default(bool);
			bool flag2 = default(bool);
			Vector2 vector = default(Vector2);
			Vector2 vector5 = default(Vector2);
			while (KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				while (true)
				{
					IL_0087:
					RectTransform rectTransform = touchReferenceTransform;
					int num;
					int num2;
					if (!_snapStickToTouch)
					{
						num = 1617660717;
						num2 = num;
					}
					else
					{
						num = 1617660710;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x606B8B29)
						{
						case 13:
							num = 1617660719;
							continue;
						default:
							return;
						case 6:
							break;
						case 1:
							num = 1617660729;
							continue;
						case 18:
							goto IL_0087;
						case 3:
							if (_stickBounds == StickBounds.Square)
							{
								vector2 = MathTools.Clamp(vector3, 0f - calculatedStickRange, calculatedStickRange);
								num = 1617660729;
								continue;
							}
							goto case 12;
						case 7:
							if (_stickBounds == StickBounds.Square)
							{
								flag = Mathf.Abs(vector3.x) > calculatedStickRange;
								flag2 = Mathf.Abs(vector3.y) > calculatedStickRange;
								num = 1617660706;
								continue;
							}
							goto case 0;
						case 4:
							vector = _lastPressAnchoredPosition;
							num = 1617660704;
							continue;
						case 15:
							vector = eNAeLDLTbmAsdtyVgrjCdfsiFPci.QGvZDzoHqRwxpTqLWKpUlqVHoSu(base.rectTransform, rectTransform, base.rectTransform.rect.center);
							num = 1617660704;
							continue;
						case 17:
							base.OnDrag(P_0);
							num = 1617660705;
							continue;
						case 5:
							goto IL_0164;
						case 2:
						{
							Vector2 vector4 = new Vector2((_useXAxis && flag) ? (vector3.x - vector2.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector2.y) : 0f);
							KKKzzptlCzpxEXyQiJDGcaVVucZ(effectivePointerId, vector4, PositionType.huHVQQAcuxcYyCLZjEIJOChEJYa);
							num = 1617660728;
							continue;
						}
						case 16:
						{
							Vector2 rawValue = vector2 / calculatedStickRange;
							SetRawValue(rawValue);
							if (_followTouchPosition)
							{
								if (_stickBounds != StickBounds.Circle)
								{
									goto case 7;
								}
								if (vector3.sqrMagnitude > calculatedStickRange)
								{
									vector5 = new Vector2(_useXAxis ? (vector3.x - vector2.x) : 0f, _useXAxis ? (vector3.y - vector2.y) : 0f);
									num = 1617660707;
									continue;
								}
							}
							goto case 17;
						}
						case 10:
							KKKzzptlCzpxEXyQiJDGcaVVucZ(effectivePointerId, vector5, PositionType.huHVQQAcuxcYyCLZjEIJOChEJYa);
							num = 1617660728;
							continue;
						case 14:
							vector2 = Vector2.ClampMagnitude(vector3, calculatedStickRange);
							num = 1617660712;
							continue;
						case 0:
							throw new NotImplementedException();
						case 9:
							if (!_centerStickOnRelease && !_snapStickToTouch)
							{
								vector -= _lastPressStartingValue * calculatedStickRange;
								num = 1617660716;
								continue;
							}
							goto IL_0164;
						case 11:
							if (flag)
							{
								goto case 2;
							}
							goto IL_0346;
						case 12:
							throw new NotImplementedException();
						case 8:
							return;
						}
						break;
						IL_0346:
						int num3;
						if (!flag2)
						{
							num = 1617660728;
							num3 = num;
						}
						else
						{
							num = 1617660715;
							num3 = num;
						}
						continue;
						IL_0164:
						Vector2 vector6 = eNAeLDLTbmAsdtyVgrjCdfsiFPci.dtpDXxeWSzCwUaZpUNVCeFQTgWhH(base.canvas, rectTransform, P_0.position);
						vector3 = new Vector2(_useXAxis ? (vector6.x - vector.x) : 0f, _useYAxis ? (vector6.y - vector.y) : 0f);
						int num4;
						if (_stickBounds == StickBounds.Circle)
						{
							num = 1617660711;
							num4 = num;
						}
						else
						{
							num = 1617660714;
							num4 = num;
						}
					}
					break;
				}
			}
		}

		private void LMXamfDxLuRGTiSrbMKVCBmadeoY(PointerEventData P_0, YeelzijLJjtLIphMNHeBIxXHloAJ P_1)
		{
			if (!hasPointer)
			{
				return;
			}
			while (KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				while (true)
				{
					IL_0041:
					base.OnEndDrag(P_0);
					int num = -1186041842;
					while (true)
					{
						switch (num ^ -1186041842)
						{
						case 3:
							num = -1186041844;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_0041;
						case 0:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void PrhNrJNIlRPRCXgcxIuytulSRay(int P_0, Vector2 P_1, YeelzijLJjtLIphMNHeBIxXHloAJ P_2)
		{
			_pointerId = P_0;
			while (true)
			{
				int num = -1077816451;
				while (true)
				{
					switch (num ^ -1077816458)
					{
					case 7:
						break;
					default:
						return;
					case 8:
						vUqurQgbViEJEHwXocSHTJSMPuDp(P_1, false, 0f, FPYFNlfKuTtFhNHjyzBdbhLfBid.XtRDenkmlflSSFYJThdxkTsQRdUi);
						num = -1077816458;
						continue;
					case 6:
						_lastPressAnchoredPosition = eNAeLDLTbmAsdtyVgrjCdfsiFPci.dtpDXxeWSzCwUaZpUNVCeFQTgWhH(base.canvas, touchReferenceTransform, P_1);
						num = -1077816462;
						continue;
					case 9:
						vUqurQgbViEJEHwXocSHTJSMPuDp(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, FPYFNlfKuTtFhNHjyzBdbhLfBid.XtRDenkmlflSSFYJThdxkTsQRdUi);
						num = -1077816457;
						continue;
					case 10:
						_touchStartTime = Time.realtimeSinceStartup;
						_touchStartPosition = P_1;
						if (P_2 != YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO)
						{
							goto case 1;
						}
						if (!_moveToTouchPosition)
						{
							int num2;
							if (_followTouchPosition)
							{
								num = -1077816460;
								num2 = num;
							}
							else
							{
								num = -1077816457;
								num2 = num;
							}
							continue;
						}
						goto case 2;
					case 4:
						QlnYBBpzNpDLYXfPrVIqnYFRDKL = true;
						_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
						_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
						num = -1077816452;
						continue;
					case 5:
					{
						PointerEventData pointerEventData = brhALqGXLcCaGnAtXlrPijwseztm(_pointerId, (P_2 == YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
						if (pointerEventData != null)
						{
							CXvLmtALdadnijFWJqoItJecMJzN(pointerEventData, P_2);
							num = -1077816459;
							continue;
						}
						return;
					}
					case 11:
						_lastClaimSource = P_2;
						_isEligibleForTap = true;
						num = -1077816464;
						continue;
					case 1:
						if (_onTouchStarted != null)
						{
							_onTouchStarted.Invoke();
							num = -1077816461;
							continue;
						}
						goto case 5;
					case 0:
						num = -1077816457;
						continue;
					case 2:
					{
						int num3;
						if (_followTouchPosition)
						{
							num = -1077816450;
							num3 = num;
						}
						else
						{
							num = -1077816449;
							num3 = num;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void SHIErtNBGDqtOcJrfCqGmlXqnbj()
		{
			nnIbvzAiFmjEPCjsdxFWxHOPYIt();
			bool flag = default(bool);
			while (true)
			{
				int num = -1917997859;
				while (true)
				{
					int num2;
					switch (num ^ -1917997861)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						if (_isMovedFromDefaultPosition)
						{
							ReturnToDefaultPosition();
							num = -1917997857;
							continue;
						}
						goto case 4;
					case 7:
						_onTap.Invoke();
						num = -1917997870;
						continue;
					case 2:
						if (_onTouchEnded != null)
						{
							_onTouchEnded.Invoke();
							num = -1917997862;
							continue;
						}
						goto case 1;
					case 1:
						_isEligibleForTap = false;
						if (flag)
						{
							_lastTapFrame = Time.frameCount + 1;
							num = -1917997860;
							continue;
						}
						return;
					case 11:
						if (!_followTouchPosition)
						{
							int num3;
							if (!_moveToTouchPosition)
							{
								num = -1917997857;
								num3 = num;
							}
							else
							{
								num = -1917997858;
								num3 = num;
							}
							continue;
						}
						goto case 5;
					case 5:
					{
						int num4;
						if (_returnOnRelease)
						{
							num = -1917997864;
							num4 = num;
						}
						else
						{
							num = -1917997857;
							num4 = num;
						}
						continue;
					}
					case 10:
						_pointerDownIsFake = false;
						_lastPressAnchoredPosition = Vector2.zero;
						_lastPressStartingValue = Vector2.zero;
						num = -1917997872;
						continue;
					case 6:
						if (_allowTap)
						{
							num = -1917997869;
							continue;
						}
						num2 = 0;
						goto IL_015e;
					case 4:
						if (_centerStickOnRelease)
						{
							SetRawValue(_axis2D.rawZero);
							num = -1917997863;
							continue;
						}
						goto case 2;
					case 8:
						num2 = (_isEligibleForTap ? 1 : 0);
						goto IL_015e;
					case 9:
						return;
						IL_015e:
						flag = (byte)num2 != 0;
						QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
						num = -1917997871;
						continue;
					}
					break;
				}
			}
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
					num = -177048838;
					num2 = num;
				}
				else
				{
					num = -177048833;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -177048833)
					{
					case 6:
						num = -177048837;
						continue;
					default:
						return;
					case 5:
					{
						int num3;
						if (_workingTouchRegion != null)
						{
							num = -177048834;
							num3 = num;
						}
						else
						{
							num = -177048835;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					case 1:
						if (_useTouchRegionOnly)
						{
							return;
						}
						goto case 2;
					case 4:
						break;
					case 2:
						PKDpapVpBsZIfGwBoVYoUivnEgl(eventData, YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF);
						num = -177048836;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0069;
			IL_0008:
			int num = 766851143;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x2DB53846)
			{
			case 5:
				break;
			case 1:
				return;
			case 3:
				if (_useTouchRegionOnly)
				{
					return;
				}
				goto default;
			case 4:
				goto IL_004a;
			case 2:
				goto IL_0069;
			default:
				ykLlbzWaLuNEKGAQUYLFIUwTpBY(eventData, YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF);
				return;
			}
			goto IL_0008;
			IL_0069:
			if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			goto IL_004a;
			IL_004a:
			int num2;
			if (_workingTouchRegion != null)
			{
				num = 766851141;
				num2 = num;
			}
			else
			{
				num = 766851142;
				num2 = num;
			}
			goto IL_000d;
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
				if (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
				{
					num = 2008854506;
					num2 = num;
				}
				else
				{
					num = 2008854507;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x77BCAFEE)
					{
					case 2:
						num = 2008854509;
						continue;
					default:
						return;
					case 4:
						if (_workingTouchRegion != null && _useTouchRegionOnly)
						{
							return;
						}
						goto case 1;
					case 5:
						return;
					case 1:
						LZkGGotiHtFpBawoWkiqWiNbAGgZ(eventData, YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF);
						num = 2008854510;
						continue;
					case 3:
						break;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				while (true)
				{
					int num;
					int num2;
					if (!(_workingTouchRegion != null))
					{
						num = 530431405;
						num2 = num;
					}
					else
					{
						num = 530431403;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x1F9DBDAF)
						{
						case 3:
							num = 530431406;
							continue;
						case 4:
							if (_useTouchRegionOnly)
							{
								return;
							}
							goto default;
						case 0:
							break;
						case 1:
							goto end_IL_003f;
						default:
							jnQPXNUYsptUbWdLIawDCCMiSiQ(eventData, YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF);
							return;
						}
						break;
					}
					continue;
					end_IL_003f:
					break;
				}
			}
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
				{
					num = 2124189189;
					num2 = num;
				}
				else
				{
					num = 2124189184;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7E9C8E04)
					{
					case 3:
						goto IL_0009;
					case 2:
						break;
					case 1:
						return;
					case 4:
						if (_workingTouchRegion != null && _useTouchRegionOnly)
						{
							return;
						}
						goto default;
					default:
						iosotEIsCfFFIfRvzfxosSeUoge(eventData, YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF);
						return;
					}
					break;
					IL_0009:
					num = 2124189190;
				}
			}
		}

		internal override void OnDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
			{
				while (true)
				{
					IL_0053:
					if (_workingTouchRegion != null)
					{
						int num;
						int num2;
						if (!_useTouchRegionOnly)
						{
							num = 1470689241;
							num2 = num;
						}
						else
						{
							num = 1470689244;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x57A8EFDD)
							{
							case 0:
								num = 1470689247;
								continue;
							case 2:
								break;
							case 1:
								return;
							case 3:
								goto IL_0053;
							default:
								goto IL_007a;
							}
							break;
						}
						break;
					}
					goto IL_007a;
					IL_007a:
					BMTfaxkpbqwedhJUBlpcGCTKAYUf(eventData, YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF);
					return;
				}
			}
		}

		internal override void OnEndDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
				{
					num = -1059245194;
					num2 = num;
				}
				else
				{
					num = -1059245193;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1059245197)
					{
					case 0:
						num = -1059245198;
						continue;
					case 3:
						return;
					case 4:
						return;
					case 5:
						if (_workingTouchRegion != null)
						{
							int num3;
							if (!_useTouchRegionOnly)
							{
								num = -1059245199;
								num3 = num;
							}
							else
							{
								num = -1059245200;
								num3 = num;
							}
							continue;
						}
						goto default;
					case 1:
						break;
					default:
						LMXamfDxLuRGTiSrbMKVCBmadeoY(eventData, YeelzijLJjtLIphMNHeBIxXHloAJ.hWboZvyXoJNhfSvesxqLLWrBcgF);
						return;
					}
					break;
				}
			}
		}

		private void lzqUemmLiWpBjHlLmGrpmuhFrlo(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
				{
					num = -146949410;
					num2 = num;
				}
				else
				{
					num = -146949409;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -146949410)
					{
					case 4:
						num = -146949411;
						continue;
					default:
						return;
					case 3:
						break;
					case 0:
						return;
					case 1:
						ykLlbzWaLuNEKGAQUYLFIUwTpBY(P_0, YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
						num = -146949412;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void UEcgqxIblHuJqokaoodfjjxksQmz(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
				{
					num = -398954539;
					num2 = num;
				}
				else
				{
					num = -398954538;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -398954538)
					{
					case 2:
						goto IL_0009;
					case 1:
						break;
					case 0:
						return;
					default:
						PKDpapVpBsZIfGwBoVYoUivnEgl(P_0, YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
						return;
					}
					break;
					IL_0009:
					num = -398954537;
				}
			}
		}

		private void UkqepPwTKhKlSSYpykoMGilKlBO(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0045;
			IL_0008:
			int num = 469598392;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x1BFD80BA)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				return;
			case 4:
				goto IL_0036;
			case 1:
				goto IL_0045;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0045:
			if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			goto IL_0036;
			IL_0036:
			LZkGGotiHtFpBawoWkiqWiNbAGgZ(P_0, YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
			num = 469598394;
			goto IL_000d;
		}

		private void FdfJZopCusKoJSmKfyVDmEfTHFm(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x3496F04B ^ 0x3496F048)
					{
					case 2:
						break;
					case 3:
						return;
					case 0:
						goto end_IL_0008;
					default:
						goto IL_0053;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			goto IL_0053;
			IL_0053:
			jnQPXNUYsptUbWdLIawDCCMiSiQ(P_0, YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
		}

		private void EHxgShUabCDTBywXirJDWBSRAdl(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				while (true)
				{
					IL_004d:
					iosotEIsCfFFIfRvzfxosSeUoge(P_0, YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
					int num = 632514609;
					while (true)
					{
						switch (num ^ 0x25B36831)
						{
						case 3:
							num = 632514608;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							goto IL_004d;
						case 0:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void elPOduWEbDBmbJjpWoPrFoUTehqQ(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				while (true)
				{
					IL_004c:
					BMTfaxkpbqwedhJUBlpcGCTKAYUf(P_0, YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
					int num = 842886983;
					while (true)
					{
						switch (num ^ 0x323D6F45)
						{
						case 0:
							num = 842886980;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							goto IL_004c;
						case 2:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void ptNzRrfAVKsNlEekGdQzcnymCdJz(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -993630747;
			goto IL_000d;
			IL_000d:
			switch (num ^ -993630745)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 3:
				goto IL_0036;
			case 1:
				goto IL_0058;
			case 4:
				return;
			}
			goto IL_0008;
			IL_0036:
			if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				return;
			}
			goto IL_0058;
			IL_0058:
			LMXamfDxLuRGTiSrbMKVCBmadeoY(P_0, YeelzijLJjtLIphMNHeBIxXHloAJ.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
			num = -993630749;
			goto IL_000d;
		}

		private void ikGcuzFLbQzirRQpqnEOPYpKOAv(Vector2 P_0)
		{
			EQnWUlQqOynmEtPVWLCOkLeIdyA(null);
			Vector2 vector = P_0;
			RectTransform rectTransform = default(RectTransform);
			Vector3 position = default(Vector3);
			while (true)
			{
				int num = 462245637;
				while (true)
				{
					Vector2 anchoredPosition;
					switch (num ^ 0x1B8D4F07)
					{
					case 9:
						break;
					case 1:
					{
						int num2;
						if (!(_stickTransform != null))
						{
							num = 462245639;
							num2 = num;
						}
						else
						{
							num = 462245634;
							num2 = num;
						}
						continue;
					}
					case 7:
						if (_axis2D.yAxis.calibration.invert)
						{
							vector.y *= -1f;
							num = 462245635;
							continue;
						}
						goto case 4;
					case 0:
						_hierarchyValueChangedHandlers.ExecuteOnAll(P_0);
						_hierarchyStickPositionChangedHandlers.ExecuteOnAll(vector);
						_onValueChanged.Invoke(P_0);
						num = 462245647;
						continue;
					case 4:
						vector = MathTools.Clamp(vector, -1f, 1f);
						num = 462245638;
						continue;
					case 5:
						rectTransform = touchReferenceTransform;
						position = vector * calculatedStickRange;
						num = 462245636;
						continue;
					case 2:
						if (_axis2D.xAxis.calibration.invert)
						{
							vector.x *= -1f;
							num = 462245632;
							continue;
						}
						goto case 7;
					case 3:
					{
						position += rectTransform.InverseTransformPoint(base.transform.position);
						Vector3 position2 = rectTransform.TransformPoint(position);
						Vector3 vector2 = _stickTransform.parent.InverseTransformPoint(position2);
						anchoredPosition = eNAeLDLTbmAsdtyVgrjCdfsiFPci.NZZcusBkbOFDzVSPFEQxwzjwbMrh(_stickTransform.parent as RectTransform, vector2);
						anchoredPosition += _origStickAnchoredPosition;
						num = 462245633;
						continue;
					}
					case 6:
						_stickTransform.anchoredPosition = anchoredPosition;
						num = 462245639;
						continue;
					default:
						_onStickPositionChanged.Invoke(vector);
						return;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private static void EVUSxKUnLaGvBgnrdQdmwbYxdFC(IValueChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnValueChanged(P_1);
		}

		[CompilerGenerated]
		private static void NhbnCEVRzuqrwyhONZeXsbkxMNf(IStickPositionChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnStickPositionChanged(P_1);
		}
	}
}
