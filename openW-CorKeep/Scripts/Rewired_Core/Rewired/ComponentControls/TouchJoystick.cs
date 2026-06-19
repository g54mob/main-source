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
	[AddComponentMenu("Rewired/Touch Controls/Touch Joystick")]
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

		private enum wqniaqGdJiSkJuPHmrxqssnAjCct
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum lYLMrHAWtGWeCWeeZmAWizaaQSHC
		{
			Local = 0,
			TouchRegion = 1
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

		[Serializable]
		private sealed class OjoeFRcnkovVlsPiLQHEdwWfAMgxA
		{
			public static readonly OjoeFRcnkovVlsPiLQHEdwWfAMgxA _003C_003E9 = new OjoeFRcnkovVlsPiLQHEdwWfAMgxA();

			public static IOTRuZUhpblgmuwMViwnrZiSkgDF.EventFunction<IValueChangedHandler, Vector2> _003C_003E9__277_0;

			public static IOTRuZUhpblgmuwMViwnrZiSkgDF.EventFunction<IStickPositionChangedHandler, Vector2> _003C_003E9__280_0;

			internal void QVRzVEnMDqelbIhYtgfkmuOEGUSPA(IValueChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnValueChanged(P_1);
			}

			internal void oqUCEdYuoyTShgWHWuKshIqdZTZj(IStickPositionChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnStickPositionChanged(P_1);
			}
		}

		private sealed class uVIDTtOkhxauLAohlKLOJbvnIuOoA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int FFXiRNcuYdvlavFfOTRtusABPaCEA;

			private object DoJEYtTffuwGGHqemQUhYzcDrFUh;

			public float qYvhxXuXQqgtEUsoPbtnucmJUnbb;

			public TouchJoystick MWdEMtJQIOXnOwsdMgFWGsDttehuA;

			public PositionType DDdnaLwGAvvhdnwBIKDGBngtaWFm;

			public Vector2 hrFyYELoFyBYAerBPaVxrNxlcIvm;

			public wqniaqGdJiSkJuPHmrxqssnAjCct hXlxuEVgMcADcDMDgajHxhePpbxPA;

			private RectTransform PNwMCmtiFcGidKlCbRvnghrgUsZmA;

			private Vector2 MfNUMNqkOapXajPqBSgpsdCHhdkD;

			private float qkvArYIEmblguQcAPvGJMKTZiNak;

			private float kesJqWONkIFXyRNyODtLGbNNqPU;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return DoJEYtTffuwGGHqemQUhYzcDrFUh;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DoJEYtTffuwGGHqemQUhYzcDrFUh;
				}
			}

			[DebuggerHidden]
			public uVIDTtOkhxauLAohlKLOJbvnIuOoA(int P_0)
			{
				FFXiRNcuYdvlavFfOTRtusABPaCEA = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				PNwMCmtiFcGidKlCbRvnghrgUsZmA = null;
				FFXiRNcuYdvlavFfOTRtusABPaCEA = -2;
			}

			private bool MoveNext()
			{
				int fFXiRNcuYdvlavFfOTRtusABPaCEA = FFXiRNcuYdvlavFfOTRtusABPaCEA;
				TouchJoystick mWdEMtJQIOXnOwsdMgFWGsDttehuA = MWdEMtJQIOXnOwsdMgFWGsDttehuA;
				if (fFXiRNcuYdvlavFfOTRtusABPaCEA != 0)
				{
					if (fFXiRNcuYdvlavFfOTRtusABPaCEA != 1)
					{
						return false;
					}
					FFXiRNcuYdvlavFfOTRtusABPaCEA = -1;
					goto IL_010c;
				}
				FFXiRNcuYdvlavFfOTRtusABPaCEA = -1;
				if (!(qYvhxXuXQqgtEUsoPbtnucmJUnbb <= 0f))
				{
					PNwMCmtiFcGidKlCbRvnghrgUsZmA = mWdEMtJQIOXnOwsdMgFWGsDttehuA.WDuGVHNrhJsWydsOjFkhLWpgTdjk;
					MfNUMNqkOapXajPqBSgpsdCHhdkD = JPvwdModsFtwLYKhejFPycAZezzl.KfHhADhJZplBqVfiMBxieCzKTSlj(PNwMCmtiFcGidKlCbRvnghrgUsZmA, DDdnaLwGAvvhdnwBIKDGBngtaWFm);
					float magnitude = (hrFyYELoFyBYAerBPaVxrNxlcIvm - MfNUMNqkOapXajPqBSgpsdCHhdkD).magnitude;
					if (!(magnitude < 0.01f))
					{
						mWdEMtJQIOXnOwsdMgFWGsDttehuA._isMoving = true;
						qkvArYIEmblguQcAPvGJMKTZiNak = magnitude / qYvhxXuXQqgtEUsoPbtnucmJUnbb;
						kesJqWONkIFXyRNyODtLGbNNqPU = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				mWdEMtJQIOXnOwsdMgFWGsDttehuA.TwXeXMkejLKwxpjkSiLCNaSqvvEV(hXlxuEVgMcADcDMDgajHxhePpbxPA, hrFyYELoFyBYAerBPaVxrNxlcIvm, DDdnaLwGAvvhdnwBIKDGBngtaWFm);
				return false;
				IL_010c:
				if (kesJqWONkIFXyRNyODtLGbNNqPU <= 1f)
				{
					kesJqWONkIFXyRNyODtLGbNNqPU += Time.unscaledDeltaTime / qkvArYIEmblguQcAPvGJMKTZiNak;
					JPvwdModsFtwLYKhejFPycAZezzl.DOgPhbEoPINwRutQwmHqcxNubIRH(PNwMCmtiFcGidKlCbRvnghrgUsZmA, Vector2.Lerp(MfNUMNqkOapXajPqBSgpsdCHhdkD, hrFyYELoFyBYAerBPaVxrNxlcIvm, Mathf.SmoothStep(0f, 1f, kesJqWONkIFXyRNyODtLGbNNqPU)), DDdnaLwGAvvhdnwBIKDGBngtaWFm);
					DoJEYtTffuwGGHqemQUhYzcDrFUh = null;
					FFXiRNcuYdvlavFfOTRtusABPaCEA = 1;
					return true;
				}
				goto IL_0119;
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
		}

		private const float MAX_MOVE_SPEED = 20f;

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private RectTransform _stickTransform;

		[Tooltip("The joystick's mode of operation. Set this to Digital to simulate a D-Pad which has only On/Off states. If you want mimic a real D-Pad, you should also set Snap Directions to 8.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private JoystickMode _joystickMode;

		[Tooltip("A dead zone which is applied when Stick Mode is set to Digital. This is used to filter out tiny stick movements near 0, 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		private float _digitalModeDeadZone = 0.3f;

		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0.01f, 1000f)]
		private float _stickRange = 60f;

		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _scaleStickRange = true;

		[Tooltip("The shape of the range of movement of the joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StickBounds _stickBounds;

		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisDirection _axesToUse;

		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SnapDirections _snapDirections;

		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _snapStickToTouch;

		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _centerStickOnRelease = true;

		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Should taps on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		private float _tapTimeout = 0.25f;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		private int _tapDistanceLimit = 10;

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the joystick's RectTransform. This can be useful if you want a larger area of the screen to act as a joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local joystick will be ignored and only Touch Region touches will be used. Otherwise, both touches on the joystick and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
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

		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private bool _useXAxis;

		private bool _useYAxis;

		private IOTRuZUhpblgmuwMViwnrZiSkgDF.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private IOTRuZUhpblgmuwMViwnrZiSkgDF.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private wqniaqGdJiSkJuPHmrxqssnAjCct _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool OtDeEqdvRNZUQiFfjgRsAcuKfiVOc;

		[NonSerialized]
		private bool mRdoblBPywhwEVcLkWPvpimmKPNC;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private lYLMrHAWtGWeCWeeZmAWizaaQSHC _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private FXeWxvuoejNrJnpUgQhgaqksVhEA _imageRaycastHelper = new FXeWxvuoejNrJnpUgQhgaqksVhEA();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<wqniaqGdJiSkJuPHmrxqssnAjCct> __moveStartedDelegate;

		private Action<wqniaqGdJiSkJuPHmrxqssnAjCct> __moveEndedDelegate;

		[Tooltip("Event sent when the joystick value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[Tooltip("Event sent when the joystick's stick position changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onStickPositionChanged = new ValueChangedEventHandler();

		[Tooltip("Event sent when the joystick is touched.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchStartedEventHandler _onTouchStarted = new TouchStartedEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchEndedEventHandler _onTouchEnded = new TouchEndedEventHandler();

		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TapEventHandler _onTap = new TapEventHandler();

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static IOTRuZUhpblgmuwMViwnrZiSkgDF.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static IOTRuZUhpblgmuwMViwnrZiSkgDF.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement => _horizontalAxisCustomControllerElement;

		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement => _verticalAxisCustomControllerElement;

		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement => _tapCustomControllerElement;

		public RectTransform stickTransform
		{
			get
			{
				return _stickTransform;
			}
			set
			{
				if (!(_stickTransform == value))
				{
					_stickTransform = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_digitalModeDeadZone != value)
				{
					_digitalModeDeadZone = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
			}
		}

		private StickBounds hsDSpSYbavaXgecbSgvTvSqsYfsfA
		{
			get
			{
				return _stickBounds;
			}
			set
			{
				if (_stickBounds != stickBounds)
				{
					_stickBounds = stickBounds;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_axesToUse != value)
				{
					qjolqjsxWiBCFUGNOIDefIaJittL(value);
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
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
				if (_snapDirections != value)
				{
					_snapDirections = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
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
				if (_snapStickToTouch != value)
				{
					_snapStickToTouch = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_activateOnSwipeIn != value)
				{
					_activateOnSwipeIn = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (RMCBLYgXjAeLOQrMMVosEPUYFFKfb())
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_tapDistanceLimit != value)
				{
					_tapDistanceLimit = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (!(_touchRegion == value))
				{
					_touchRegion = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_useTouchRegionOnly != value)
				{
					_useTouchRegionOnly = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_returnOnRelease != value)
				{
					_returnOnRelease = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_animateOnMoveToTouch != value)
				{
					_animateOnMoveToTouch = value;
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
				if (_manageRaycasting != value)
				{
					_manageRaycasting = value;
					if (value)
					{
						mkMWZoZiPTBkrjWAhgPQbzdyOHwv();
					}
					else
					{
						_imageRaycastHelper.BqVxZaiQDoOWbRDQwEhcmklEDJnq();
					}
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType => _axis2D.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

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

		private bool wGnmitNNwIuOGAGSGDjsnrsqDAjw => _lastTapFrame == Time.frameCount;

		internal StandaloneAxis2D FiudARHzvDeFOkHgzXzwhLuKvVbt => _axis2D;

		private Action<wqniaqGdJiSkJuPHmrxqssnAjCct> fLgrEAXlhQEDWoCpZUPwVeXhFELk
		{
			get
			{
				if (__moveStartedDelegate == null)
				{
					return __moveStartedDelegate = nQtabNlwnbgNBZmKmOFsFNNCEcie;
				}
				return __moveStartedDelegate;
			}
		}

		private Action<wqniaqGdJiSkJuPHmrxqssnAjCct> ivVCURABsyODAacSNRuWaeMKgAPAA
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = panwmlvVsrBWpQdTfJKdXloEXFxK;
				}
				return __moveEndedDelegate;
			}
		}

		private int oCrRekHdOTGKbEQgxYVAnSgorTBn
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

		private RectTransform bfcUZrtrocGbIYScVjBcrcdwVQud
		{
			get
			{
				if (_lastClaimSource != lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion)
				{
					return base.transform as RectTransform;
				}
				return base.transform.parent as RectTransform;
			}
		}

		private float DKxJefRzqlabXhLSEFjBdHlZsTfF
		{
			get
			{
				if (Time.frameCount == _calculatedStickRange_lastUpdatedFrame)
				{
					return __calculatedStickRange_cachedValue;
				}
				RectTransform rectTransform = base.fxNbNJQIjpDsOBtBDMMUUhQBfOst;
				RectTransform rectTransform2 = bfcUZrtrocGbIYScVjBcrcdwVQud;
				Vector3 position = new Vector3(0f, _stickRange, 0f);
				Vector3 vector = rectTransform.TransformPoint(position) - rectTransform.position;
				Vector3 a = rectTransform2.InverseTransformPoint(vector + rectTransform2.position);
				float magnitude;
				if (_scaleStickRange)
				{
					Vector3 lossyScale = rectTransform.lossyScale;
					Vector3 lossyScale2 = rectTransform2.lossyScale;
					if (lossyScale.x != 0f)
					{
						lossyScale2.x /= lossyScale.x;
					}
					if (lossyScale.y != 0f)
					{
						lossyScale2.y /= lossyScale.y;
					}
					if (lossyScale.z != 0f)
					{
						lossyScale2.z /= lossyScale.z;
					}
					if (_lastClaimSource == lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion)
					{
						lossyScale2.Scale(base.transform.localScale);
					}
					magnitude = Vector3.Scale(a, lossyScale2).magnitude;
				}
				else
				{
					magnitude = a.magnitude;
				}
				__calculatedStickRange_cachedValue = magnitude;
				_calculatedStickRange_lastUpdatedFrame = Time.frameCount;
				return magnitude;
			}
		}

		internal static IOTRuZUhpblgmuwMViwnrZiSkgDF.EventFunction<IValueChangedHandler, Vector2> eqoiWNztFWdmJewzDmGyybLgiidf
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					__valueChangedHandlerDelegate = OjoeFRcnkovVlsPiLQHEdwWfAMgxA._003C_003E9.QVRzVEnMDqelbIhYtgfkmuOEGUSPA;
				}
				return __valueChangedHandlerDelegate;
			}
		}

		internal static IOTRuZUhpblgmuwMViwnrZiSkgDF.EventFunction<IStickPositionChangedHandler, Vector2> xLPmgHSdeUgjUjCeDnDhbOBFdwEZ
		{
			get
			{
				if (__stickPositionChangedHandlerDelegate == null)
				{
					__stickPositionChangedHandlerDelegate = OjoeFRcnkovVlsPiLQHEdwWfAMgxA._003C_003E9.oqUCEdYuoyTShgWHWuKshIqdZTZj;
				}
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
			if (!base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.value;
		}

		public Vector2 GetRawValue()
		{
			if (!base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.rawValue;
		}

		public void SetRawValue(Vector2 value)
		{
			if (!base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				return;
			}
			if (_joystickMode == JoystickMode.Digital)
			{
				if (value.sqrMagnitude <= _digitalModeDeadZone * _digitalModeDeadZone)
				{
					value.x = 0f;
					value.y = 0f;
				}
				else
				{
					value.Normalize();
				}
			}
			if (_snapDirections != SnapDirections.None)
			{
				value = MathTools.SnapVectorToNearestAngle(value, 360f / (float)_snapDirections);
				if (value.x != 0f)
				{
					if (MathTools.IsNearZero(value.x, 0.0001f))
					{
						value.x = 0f;
					}
					else if (MathTools.IsNear(value.x, 1f, 0.0001f))
					{
						value.x = 1f;
					}
					else if (MathTools.IsNear(value.x, -1f, 0.0001f))
					{
						value.x = -1f;
					}
				}
				if (value.y != 0f)
				{
					if (MathTools.IsNearZero(value.y, 0.0001f))
					{
						value.y = 0f;
					}
					else if (MathTools.IsNear(value.y, 1f, 0.0001f))
					{
						value.y = 1f;
					}
					else if (MathTools.IsNear(value.y, -1f, 0.0001f))
					{
						value.y = -1f;
					}
				}
			}
			if (_useXAxis || _useYAxis)
			{
				_axis2D.SetRawValue(_useXAxis ? value.x : 0f, _useYAxis ? value.y : 0f);
			}
		}

		public void SetDefaultPosition()
		{
			RgyQtwfbTnmHMEhpxvnfUarFQCSv(base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.anchoredPosition);
		}

		private void RgyQtwfbTnmHMEhpxvnfUarFQCSv(Vector2 P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				_origAnchoredPosition = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				NTqNwpJvITsYSsjgagSaSOedIjqY(_origAnchoredPosition, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, wqniaqGdJiSkJuPHmrxqssnAjCct.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				ReturnToDefaultPosition(instant: false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying)
			{
				_origAnchoredPosition = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.anchoredPosition;
				if (_stickTransform != null)
				{
					_origStickAnchoredPosition = _stickTransform.anchoredPosition;
				}
				SetRawValue(FiudARHzvDeFOkHgzXzwhLuKvVbt.rawZero);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				QfpENZZJoSxrFjANneMKJPvKmJnH();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				_axis2D.Deinitialize();
				tKEdjOKSEgjEZYzXhFqUMeyYYOhKA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				AtdUyzBXDDsmzEbxFwVJPeWLHKkN();
				QfpENZZJoSxrFjANneMKJPvKmJnH();
			}
		}

		internal void AcRGqPKQSjenrzCVGCErByOesbFCc()
		{
			base.ZadSFFqddMfzbdzzllVuUFOpUuig();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				PydXbVSLTTLmmicIXJNPlUyJkozJ();
				YUmBlcUfQZauegBGiCOKtjIBItQE();
				dtJYgvWfeMhcRjQLAyIYLWRhkCTvA();
			}
		}

		internal bool PrNAYqPdDKVMssxEyiLmADMcACzkA()
		{
			if (!iFndMIDWDcaooyXvhIvZUIepHxsJ())
			{
				return false;
			}
			AtdUyzBXDDsmzEbxFwVJPeWLHKkN();
			_axis2D.Initialize();
			return true;
		}

		internal void jqkMgkxPJZNBZMvacaOeVhSSodQX()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && lHrmyZFsaDtMgFwuiNoBbdveNATp)
			{
				Vector2 value = _axis2D.value;
				if (_useXAxis)
				{
					RBVJiriJzxhTlbkVFcwgUMluaNDw(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					RBVJiriJzxhTlbkVFcwgUMluaNDw(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					tenSjBgQIGZLSvdKIFVVJGjRbUhX(_tapCustomControllerElement, wGnmitNNwIuOGAGSGDjsnrsqDAjw);
				}
			}
		}

		internal void feeGmlmKiPXkgWDwwmBCKcxQADMFA()
		{
			NNwwjaQfacauaRboVLZYHgLEFIBU();
			_axis2D.ValueChangedEvent += twPyUADmQhxhWEFdMkTTZgmFLHtm;
		}

		internal void xcypHKcVVxseocpdPukgRYOEoUmT()
		{
			wECbfKDjTyxXZaslOArXZDpDLMTJA();
			_axis2D.ValueChangedEvent -= twPyUADmQhxhWEFdMkTTZgmFLHtm;
		}

		internal void NiFZmuysthPIfqcbyOvDDsZrBYrD()
		{
			MkeUcSwhoilMoVoCdyXQYIOXhQJu();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				AtdUyzBXDDsmzEbxFwVJPeWLHKkN();
				QfpENZZJoSxrFjANneMKJPvKmJnH();
			}
		}

		internal void VBnAhQjfJdLCisTgyQtdtThNsaKu()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				OtDeEqdvRNZUQiFfjgRsAcuKfiVOc = false;
				mRdoblBPywhwEVcLkWPvpimmKPNC = false;
				_pointerDownIsFake = false;
				_lastPressAnchoredPosition = Vector2.zero;
				_lastPressStartingValue = Vector2.zero;
				_calculatedStickRange_lastUpdatedFrame = -1;
				_lastTapFrame = -1;
				_isEligibleForTap = false;
				if (_returnOnRelease && _isMovedFromDefaultPosition && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				_isMovedFromDefaultPosition = false;
				_isMoving = false;
				_moveDirection = wqniaqGdJiSkJuPHmrxqssnAjCct.None;
				vOdPYJgQFOFHvIBOyBmAboeyeTdgb();
				_axis2D.Clear();
				QfpENZZJoSxrFjANneMKJPvKmJnH();
			}
		}

		internal void dkknCGdhiWGmlKdURbpMEMwbzVWnB()
		{
			PswnpWzyzfQnHCpemjbarFhMQjmi();
			if (_hierarchyValueChangedHandlers == null)
			{
				_hierarchyValueChangedHandlers = new IOTRuZUhpblgmuwMViwnrZiSkgDF.HierarchyEventHelper<IValueChangedHandler, Vector2>(eqoiWNztFWdmJewzDmGyybLgiidf);
			}
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			if (_hierarchyStickPositionChangedHandlers == null)
			{
				_hierarchyStickPositionChangedHandlers = new IOTRuZUhpblgmuwMViwnrZiSkgDF.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(xLPmgHSdeUgjUjCeDnDhbOBFdwEZ);
			}
			_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
		}

		public override void ClearValue()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				if (lHrmyZFsaDtMgFwuiNoBbdveNATp)
				{
					base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ClearElementValue(_verticalAxisCustomControllerElement);
					base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		internal bool oHMAqPjqLpwxilwalWSNhgVibCnz()
		{
			if (!base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				return false;
			}
			if (!FBTWPzcXpWlDMTGvkvxpkZYxUkml())
			{
				return false;
			}
			return OtDeEqdvRNZUQiFfjgRsAcuKfiVOc;
		}

		internal bool NrcdfifQKpmzBAVreKjKUQWDhuIPA(GameObject P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (base.hFzAHiRfaqYGcaauuljcWQStfGUP(P_0))
			{
				return true;
			}
			if (_workingTouchRegion != null)
			{
				return _workingTouchRegion.gameObject == P_0;
			}
			return false;
		}

		private void QfpENZZJoSxrFjANneMKJPvKmJnH()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			dtJYgvWfeMhcRjQLAyIYLWRhkCTvA();
			mkMWZoZiPTBkrjWAhgPQbzdyOHwv();
		}

		private void mkMWZoZiPTBkrjWAhgPQbzdyOHwv()
		{
			if (_manageRaycasting)
			{
				_imageRaycastHelper.yoHcYTHfsAHxQAbnJqlQwudSzNtU(base.transform, QKjilCwjuirFdlYAPURpGtbANjSM());
			}
		}

		private bool QKjilCwjuirFdlYAPURpGtbANjSM()
		{
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void kXyYExuxCTSHAqZNgFclAeWGgipB(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				BiqEwKWKZRDKRalRMPtHGQDLOmXT(P_0);
				P_0.PointerDownEvent += iJEeJhINoBCvpRowWYBZcMUjXYw;
				P_0.PointerUpEvent += UrjBNzBXltOwKYwyGugChbzXwch;
				P_0.PointerEnterEvent += APGwdMKbovUchaFnKVIINPrFzlhe;
				P_0.PointerExitEvent += RpdnuZGwRwECvWiDeRoFtplUeKTW;
				P_0.BeginDragEvent += ACyIUtSzIYurWtdZmHPZuxuXridK;
				P_0.DragEvent += HMuGiywlhuvmpMHOVSRUMlVWHQBe;
				P_0.EndDragEvent += FjCkOLjsRvqkOGVKdjahZiGgZTiQ;
			}
		}

		private void BiqEwKWKZRDKRalRMPtHGQDLOmXT(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= iJEeJhINoBCvpRowWYBZcMUjXYw;
				P_0.PointerUpEvent -= UrjBNzBXltOwKYwyGugChbzXwch;
				P_0.PointerEnterEvent -= APGwdMKbovUchaFnKVIINPrFzlhe;
				P_0.PointerExitEvent -= RpdnuZGwRwECvWiDeRoFtplUeKTW;
				P_0.BeginDragEvent -= ACyIUtSzIYurWtdZmHPZuxuXridK;
				P_0.DragEvent -= HMuGiywlhuvmpMHOVSRUMlVWHQBe;
				P_0.EndDragEvent -= FjCkOLjsRvqkOGVKdjahZiGgZTiQ;
			}
		}

		private void dtJYgvWfeMhcRjQLAyIYLWRhkCTvA()
		{
			if (!(_workingTouchRegion == _touchRegion))
			{
				BiqEwKWKZRDKRalRMPtHGQDLOmXT(_workingTouchRegion);
				_workingTouchRegion = _touchRegion;
				kXyYExuxCTSHAqZNgFclAeWGgipB(_workingTouchRegion);
			}
		}

		private void ollfGhFJQtrpdNHGpqKUIjReJbjT(Vector2 P_0, bool P_1, float P_2, wqniaqGdJiSkJuPHmrxqssnAjCct P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = JPvwdModsFtwLYKhejFPycAZezzl.PtKBIMkQruMMZudiZKbNzXIzOvEG(base.wprEGQGwAFDVwiYwZymvFLeLIFvD, rectTransform, P_0);
			Vector2 pivot = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.pivot;
			Vector2 sizeDelta = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.sizeDelta;
			Vector3 localScale = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			NTqNwpJvITsYSsjgagSaSOedIjqY(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void NTqNwpJvITsYSsjgagSaSOedIjqY(Vector2 P_0, PositionType P_1, bool P_2, float P_3, wqniaqGdJiSkJuPHmrxqssnAjCct P_4)
		{
			if (_isMoving && P_2 && _moveDirection == P_4)
			{
				return;
			}
			if (_isMoving && _coroutineMove != null)
			{
				vOdPYJgQFOFHvIBOyBmAboeyeTdgb();
				_isMoving = false;
				_moveDirection = wqniaqGdJiSkJuPHmrxqssnAjCct.None;
			}
			if (base.wprEGQGwAFDVwiYwZymvFLeLIFvD == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.wprEGQGwAFDVwiYwZymvFLeLIFvD.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.fxNbNJQIjpDsOBtBDMMUUhQBfOst;
				Vector2 one = Vector2.one;
				while ((parent = parent.parent) != rectTransform && !(parent == null))
				{
					one.x *= parent.localScale.x;
					one.y *= parent.localScale.y;
				}
				Vector2 sizeDelta = rectTransform.sizeDelta;
				bool num = sizeDelta.x < sizeDelta.y;
				float num2 = MathTools.Max(sizeDelta.x, sizeDelta.y);
				float num3 = (num ? one.y : one.x);
				if (num3 == 0f)
				{
					num3 = 0.0001f;
				}
				P_3 = P_3 / num3 * num2;
				_coroutineMove = FNKHNdgkwXLAeqnIOnyBCogVlsFJ(P_0, P_1, P_3, P_4);
				StartCoroutine(_coroutineMove);
				_moveDirection = P_4;
				_isMovedFromDefaultPosition = true;
				fLgrEAXlhQEDWoCpZUPwVeXhFELk(P_4);
			}
			else
			{
				fLgrEAXlhQEDWoCpZUPwVeXhFELk(P_4);
				TwXeXMkejLKwxpjkSiLCNaSqvvEV(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(uVIDTtOkhxauLAohlKLOJbvnIuOoA))]
		private IEnumerator FNKHNdgkwXLAeqnIOnyBCogVlsFJ(Vector2 P_0, PositionType P_1, float P_2, wqniaqGdJiSkJuPHmrxqssnAjCct P_3)
		{
			return new uVIDTtOkhxauLAohlKLOJbvnIuOoA(0)
			{
				MWdEMtJQIOXnOwsdMgFWGsDttehuA = this,
				hrFyYELoFyBYAerBPaVxrNxlcIvm = P_0,
				DDdnaLwGAvvhdnwBIKDGBngtaWFm = P_1,
				qYvhxXuXQqgtEUsoPbtnucmJUnbb = P_2,
				hXlxuEVgMcADcDMDgajHxhePpbxPA = P_3
			};
		}

		private void TwXeXMkejLKwxpjkSiLCNaSqvvEV(wqniaqGdJiSkJuPHmrxqssnAjCct P_0, Vector2 P_1, PositionType P_2)
		{
			JPvwdModsFtwLYKhejFPycAZezzl.DOgPhbEoPINwRutQwmHqcxNubIRH(base.WDuGVHNrhJsWydsOjFkhLWpgTdjk, P_1, P_2);
			_isMoving = false;
			_moveDirection = wqniaqGdJiSkJuPHmrxqssnAjCct.None;
			switch (P_0)
			{
			case wqniaqGdJiSkJuPHmrxqssnAjCct.TowardHome:
				_isMovedFromDefaultPosition = false;
				break;
			case wqniaqGdJiSkJuPHmrxqssnAjCct.TowardTouch:
				_isMovedFromDefaultPosition = true;
				break;
			}
			vOdPYJgQFOFHvIBOyBmAboeyeTdgb();
			ivVCURABsyODAacSNRuWaeMKgAPAA(P_0);
		}

		private void nQtabNlwnbgNBZmKmOFsFNNCEcie(wqniaqGdJiSkJuPHmrxqssnAjCct P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == wqniaqGdJiSkJuPHmrxqssnAjCct.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					_imageRaycastHelper.yoHcYTHfsAHxQAbnJqlQwudSzNtU(base.transform, flag2);
				}
			}
		}

		private void panwmlvVsrBWpQdTfJKdXloEXFxK(wqniaqGdJiSkJuPHmrxqssnAjCct P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == wqniaqGdJiSkJuPHmrxqssnAjCct.TowardHome)
				{
					flag = true;
					flag2 = QKjilCwjuirFdlYAPURpGtbANjSM();
				}
				if (flag)
				{
					_imageRaycastHelper.yoHcYTHfsAHxQAbnJqlQwudSzNtU(base.transform, flag2);
				}
			}
		}

		private void vOdPYJgQFOFHvIBOyBmAboeyeTdgb()
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

		private void hrnXokYWLVroAdwEINVhTBRdftpbA(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (TouchInteractable.LffDJhSOdmwbrPooQjeWBIBCzwpSA(P_0))
			{
				NTqNwpJvITsYSsjgagSaSOedIjqY((Vector2)JPvwdModsFtwLYKhejFPycAZezzl.KfHhADhJZplBqVfiMBxieCzKTSlj(base.WDuGVHNrhJsWydsOjFkhLWpgTdjk, P_2) + P_1, P_2, false, 0f, wqniaqGdJiSkJuPHmrxqssnAjCct.TowardTouch);
				if (_lastClaimSource == lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion)
				{
					_lastPressAnchoredPosition += P_1;
				}
			}
		}

		private void YUmBlcUfQZauegBGiCOKtjIBItQE()
		{
			if (!hasPointer)
			{
				return;
			}
			if (!TouchInteractable.LffDJhSOdmwbrPooQjeWBIBCzwpSA(oCrRekHdOTGKbEQgxYVAnSgorTBn))
			{
				PointerEventData pointerEventData = ObEchUEDQRmeOpQIuDqHXfjUjuwI(oCrRekHdOTGKbEQgxYVAnSgorTBn);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					sNBTRylpnriBhAYLERAIusPtVogS(pointerEventData);
				}
				else
				{
					fCbaJvNPWJemADLUjAynosfYzHF();
				}
			}
			else if (_pointerDownIsFake)
			{
				PointerEventData pointerEventData2 = HOTCpljYaNUcoWifVjFLHdpIZPnnA(oCrRekHdOTGKbEQgxYVAnSgorTBn, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
				if (pointerEventData2 != null)
				{
					oSNazdDIcETqOIUAGOTneCmjOwsRB(pointerEventData2, _lastClaimSource);
				}
			}
		}

		private void PydXbVSLTTLmmicIXJNPlUyJkozJ()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.SqasatmOsdxOkmDVAAKlQOxsGWtR(oCrRekHdOTGKbEQgxYVAnSgorTBn);
				txWFfMKTbaayYusSTXHjBhSmDCGe(ref vector);
			}
		}

		private void txWFfMKTbaayYusSTXHjBhSmDCGe(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private bool RMCBLYgXjAeLOQrMMVosEPUYFFKfb()
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

		private void tgkzsrFQMEeUAFvnZzhKrWNROnmSA()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local;
		}

		private bool kfrfaqDdvzdcvxbAXjzESpZTxSzr(int P_0)
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
			if (TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
		}

		private PointerEventData ImkciKDHJQrpeEHcRkPnqIQcGKid(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = ObEchUEDQRmeOpQIuDqHXfjUjuwI(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.SqasatmOsdxOkmDVAAKlQOxsGWtR(P_0);
			if (TouchInteractable.KpeFbcOXwyWnYHxiDueDNayuQkab(P_0))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				if (pointerEventData.pointerEnter != P_1)
				{
					pointerEventData.pointerEnter = P_1;
				}
				float unscaledTime = Time.unscaledTime;
				if (P_1 == pointerEventData.lastPress)
				{
					if (unscaledTime - pointerEventData.clickTime < 0.3f)
					{
						int clickCount = pointerEventData.clickCount + 1;
						pointerEventData.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = P_1;
				pointerEventData.rawPointerPress = P_1;
				pointerEventData.clickTime = unscaledTime;
				pointerEventData.pointerDrag = P_1;
			}
			else
			{
				if (!TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0))
				{
					Logger.LogWarning("Unsupported pointerId: " + P_0);
					return null;
				}
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				pointerEventData.useDragThreshold = true;
				pointerEventData.pressPosition = pointerEventData.position;
				pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
				float unscaledTime2 = Time.unscaledTime;
				if (P_1 == pointerEventData.lastPress)
				{
					if (unscaledTime2 - pointerEventData.clickTime < 0.3f)
					{
						int clickCount = pointerEventData.clickCount + 1;
						pointerEventData.clickCount = clickCount;
					}
					else
					{
						pointerEventData.clickCount = 1;
					}
					pointerEventData.clickTime = unscaledTime2;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.pointerPress = P_1;
				pointerEventData.rawPointerPress = P_1;
				pointerEventData.clickTime = unscaledTime2;
				pointerEventData.pointerDrag = P_1;
			}
			return pointerEventData;
		}

		private PointerEventData HOTCpljYaNUcoWifVjFLHdpIZPnnA(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = ObEchUEDQRmeOpQIuDqHXfjUjuwI(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.SqasatmOsdxOkmDVAAKlQOxsGWtR(P_0);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = P_1;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		private PointerEventData IKtzXiQBurWKGUpwVSNjsJJYpsro(int P_0)
		{
			PointerEventData pointerEventData = ObEchUEDQRmeOpQIuDqHXfjUjuwI(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.KpeFbcOXwyWnYHxiDueDNayuQkab(P_0))
			{
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
				pointerEventData.pointerEnter = null;
			}
			else
			{
				if (!TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0))
				{
					Logger.LogWarning("Unsupported pointerId: " + P_0);
					return null;
				}
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				pointerEventData.dragging = false;
				pointerEventData.pointerDrag = null;
			}
			return pointerEventData;
		}

		private void sNBTRylpnriBhAYLERAIusPtVogS(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				IKtzXiQBurWKGUpwVSNjsJJYpsro(oCrRekHdOTGKbEQgxYVAnSgorTBn);
			}
		}

		private void oSNazdDIcETqOIUAGOTneCmjOwsRB(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if (P_0 != null)
			{
				switch (P_1)
				{
				case lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local:
					OnDrag(P_0);
					break;
				case lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion:
					HMuGiywlhuvmpMHOVSRUMlVWHQBe(P_0);
					break;
				default:
					throw new NotImplementedException();
				}
				IKtzXiQBurWKGUpwVSNjsJJYpsro(oCrRekHdOTGKbEQgxYVAnSgorTBn);
			}
		}

		private PointerEventData ObEchUEDQRmeOpQIuDqHXfjUjuwI(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (__fakePointerEventData == null)
			{
				__fakePointerEventData = new Dictionary<int, PointerEventData>();
			}
			if (!__fakePointerEventData.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				__fakePointerEventData.Add(P_0, value);
				if (TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0))
				{
					PointerEventData.InputButton button = P_0 switch
					{
						-1 => PointerEventData.InputButton.Left, 
						-2 => PointerEventData.InputButton.Right, 
						-3 => PointerEventData.InputButton.Middle, 
						_ => throw new NotImplementedException(), 
					};
					value.button = button;
				}
			}
			return value;
		}

		private void AtdUyzBXDDsmzEbxFwVJPeWLHKkN()
		{
			qjolqjsxWiBCFUGNOIDefIaJittL(_axesToUse);
			if (lHrmyZFsaDtMgFwuiNoBbdveNATp && base.qRJAbVOFmJDhouOJYHwxvIOOHAkAA.useCustomController)
			{
				if (_useXAxis)
				{
					base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ValidateElements(_horizontalAxisCustomControllerElement);
				}
				if (_useYAxis)
				{
					base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ValidateElements(_verticalAxisCustomControllerElement);
				}
				if (_allowTap)
				{
					base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ValidateElements(_tapCustomControllerElement);
				}
			}
		}

		private void qjolqjsxWiBCFUGNOIDefIaJittL(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag && lHrmyZFsaDtMgFwuiNoBbdveNATp)
				{
					int targetCount = _horizontalAxisCustomControllerElement.targetCount;
					for (int i = 0; i < targetCount; i++)
					{
						base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ClearElementValue(_horizontalAxisCustomControllerElement[i]);
					}
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && lHrmyZFsaDtMgFwuiNoBbdveNATp)
				{
					int targetCount2 = _verticalAxisCustomControllerElement.targetCount;
					for (int j = 0; j < targetCount2; j++)
					{
						base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ClearElementValue(_verticalAxisCustomControllerElement[j]);
					}
				}
			}
			_axesToUse = P_0;
		}

		private void hluHrkGnXqtNHAjtSfHuejmQLtVvA(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if (!hasPointer || kfrfaqDdvzdcvxbAXjzESpZTxSzr(P_0.pointerId))
			{
				if (FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable())
				{
					RiQHlZdyOSGKAcnQuNhqxRoJqdYH(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void QKTYHNzYpIghNEFUTpxsJkCsdqoi(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if ((!hasPointer || kfrfaqDdvzdcvxbAXjzESpZTxSzr(P_0.pointerId)) && !TouchInteractable.LffDJhSOdmwbrPooQjeWBIBCzwpSA(oCrRekHdOTGKbEQgxYVAnSgorTBn))
			{
				fCbaJvNPWJemADLUjAynosfYzHF();
				base.OnPointerUp(P_0);
			}
		}

		private void vAApCCDfQsbpZaBvIfkmXVxiwKPHA(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if (hasPointer && !kfrfaqDdvzdcvxbAXjzESpZTxSzr(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local => base.allowedMouseButtons, 
				lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && (!flag || TouchInteractable.fnhAvAdZTQvKTpxAhVnpVsCPoXuk(mouseButtonFlags)) && !OtDeEqdvRNZUQiFfjgRsAcuKfiVOc)
			{
				if (flag)
				{
					if (TouchInteractable.ordaBaeMzsSrrhYXhoJUevCXwuyPA(mouseButtonFlags, out var realMousePointerId))
					{
						_realMousePointerId = realMousePointerId;
					}
					else
					{
						_realMousePointerId = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local => base.gameObject, 
					lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion => _workingTouchRegion.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = ImkciKDHJQrpeEHcRkPnqIQcGKid((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					hluHrkGnXqtNHAjtSfHuejmQLtVvA(pointerEventData, P_1);
					if (OtDeEqdvRNZUQiFfjgRsAcuKfiVOc)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			mRdoblBPywhwEVcLkWPvpimmKPNC = true;
		}

		private void OTDwtocMwnUzROqwqFbvtkKYFReT(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if (hasPointer && !kfrfaqDdvzdcvxbAXjzESpZTxSzr(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && OtDeEqdvRNZUQiFfjgRsAcuKfiVOc)
			{
				fCbaJvNPWJemADLUjAynosfYzHF();
			}
			base.OnPointerExit(P_0);
			mRdoblBPywhwEVcLkWPvpimmKPNC = false;
		}

		private void NKrFckHnZmOEhWToSLTxxjQTyRlq(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if (hasPointer && kfrfaqDdvzdcvxbAXjzESpZTxSzr(P_0.pointerId))
			{
				base.OnBeginDrag(P_0);
			}
		}

		private void nCaIxSAcNCDnFgchgpQFnUWEHHJX(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if (!hasPointer || !kfrfaqDdvzdcvxbAXjzESpZTxSzr(P_0.pointerId))
			{
				return;
			}
			RectTransform rectTransform = bfcUZrtrocGbIYScVjBcrcdwVQud;
			Vector2 vector = ((!_snapStickToTouch) ? _lastPressAnchoredPosition : JPvwdModsFtwLYKhejFPycAZezzl.AoKInMfcVqqBdWKVGtAbCVDhNAcX(base.WDuGVHNrhJsWydsOjFkhLWpgTdjk, rectTransform, base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.rect.center));
			if (!_centerStickOnRelease && !_snapStickToTouch)
			{
				vector -= _lastPressStartingValue * DKxJefRzqlabXhLSEFjBdHlZsTfF;
			}
			Vector2 vector2 = JPvwdModsFtwLYKhejFPycAZezzl.ipANNladAVODnXXpOOAxsQyLiybk(base.wprEGQGwAFDVwiYwZymvFLeLIFvD, rectTransform, P_0.position);
			Vector2 vector3 = new Vector2(_useXAxis ? (vector2.x - vector.x) : 0f, _useYAxis ? (vector2.y - vector.y) : 0f);
			Vector2 vector4;
			if (_stickBounds == StickBounds.Circle)
			{
				vector4 = Vector2.ClampMagnitude(vector3, DKxJefRzqlabXhLSEFjBdHlZsTfF);
			}
			else
			{
				if (_stickBounds != StickBounds.Square)
				{
					throw new NotImplementedException();
				}
				vector4 = MathTools.Clamp(vector3, 0f - DKxJefRzqlabXhLSEFjBdHlZsTfF, DKxJefRzqlabXhLSEFjBdHlZsTfF);
			}
			Vector2 rawValue = vector4 / DKxJefRzqlabXhLSEFjBdHlZsTfF;
			SetRawValue(rawValue);
			if (_followTouchPosition)
			{
				if (_stickBounds == StickBounds.Circle)
				{
					if (vector3.sqrMagnitude > DKxJefRzqlabXhLSEFjBdHlZsTfF)
					{
						Vector2 vector5 = new Vector2(_useXAxis ? (vector3.x - vector4.x) : 0f, _useXAxis ? (vector3.y - vector4.y) : 0f);
						hrnXokYWLVroAdwEINVhTBRdftpbA(oCrRekHdOTGKbEQgxYVAnSgorTBn, vector5, PositionType.Anchored);
					}
				}
				else
				{
					if (_stickBounds != StickBounds.Square)
					{
						throw new NotImplementedException();
					}
					bool flag = Mathf.Abs(vector3.x) > DKxJefRzqlabXhLSEFjBdHlZsTfF;
					bool flag2 = Mathf.Abs(vector3.y) > DKxJefRzqlabXhLSEFjBdHlZsTfF;
					if (flag || flag2)
					{
						Vector2 vector6 = new Vector2((_useXAxis && flag) ? (vector3.x - vector4.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector4.y) : 0f);
						hrnXokYWLVroAdwEINVhTBRdftpbA(oCrRekHdOTGKbEQgxYVAnSgorTBn, vector6, PositionType.Anchored);
					}
				}
			}
			base.OnDrag(P_0);
		}

		private void zXEQJBWeNpfdGKJcccWZXsBeKvrFb(PointerEventData P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_1)
		{
			if (hasPointer && kfrfaqDdvzdcvxbAXjzESpZTxSzr(P_0.pointerId))
			{
				base.OnEndDrag(P_0);
			}
		}

		private void RiQHlZdyOSGKAcnQuNhqxRoJqdYH(int P_0, Vector2 P_1, lYLMrHAWtGWeCWeeZmAWizaaQSHC P_2)
		{
			_pointerId = P_0;
			_lastClaimSource = P_2;
			_isEligibleForTap = true;
			_lastPressAnchoredPosition = JPvwdModsFtwLYKhejFPycAZezzl.ipANNladAVODnXXpOOAxsQyLiybk(base.wprEGQGwAFDVwiYwZymvFLeLIFvD, bfcUZrtrocGbIYScVjBcrcdwVQud, P_1);
			OtDeEqdvRNZUQiFfjgRsAcuKfiVOc = true;
			_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
			_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
			_touchStartTime = Time.realtimeSinceStartup;
			_touchStartPosition = P_1;
			if (P_2 == lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion && (_moveToTouchPosition || _followTouchPosition))
			{
				if (_followTouchPosition)
				{
					ollfGhFJQtrpdNHGpqKUIjReJbjT(P_1, false, 0f, wqniaqGdJiSkJuPHmrxqssnAjCct.TowardTouch);
				}
				else
				{
					ollfGhFJQtrpdNHGpqKUIjReJbjT(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, wqniaqGdJiSkJuPHmrxqssnAjCct.TowardTouch);
				}
			}
			if (_onTouchStarted != null)
			{
				_onTouchStarted.Invoke();
			}
			PointerEventData pointerEventData = HOTCpljYaNUcoWifVjFLHdpIZPnnA(_pointerId, (P_2 == lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
			if (pointerEventData != null)
			{
				oSNazdDIcETqOIUAGOTneCmjOwsRB(pointerEventData, P_2);
			}
		}

		private void fCbaJvNPWJemADLUjAynosfYzHF()
		{
			tgkzsrFQMEeUAFvnZzhKrWNROnmSA();
			bool num = _allowTap && _isEligibleForTap;
			OtDeEqdvRNZUQiFfjgRsAcuKfiVOc = false;
			_pointerDownIsFake = false;
			_lastPressAnchoredPosition = Vector2.zero;
			_lastPressStartingValue = Vector2.zero;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && _isMovedFromDefaultPosition)
			{
				ReturnToDefaultPosition();
			}
			if (_centerStickOnRelease)
			{
				SetRawValue(_axis2D.rawZero);
			}
			if (_onTouchEnded != null)
			{
				_onTouchEnded.Invoke();
			}
			_isEligibleForTap = false;
			if (num)
			{
				_lastTapFrame = Time.frameCount + 1;
				_onTap.Invoke();
			}
		}

		internal void ofcJUmTnddhJSLMEEaQWuVXYfonB(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				QKTYHNzYpIghNEFUTpxsJkCsdqoi(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local);
			}
		}

		internal void NkADxnhMdczePBBmljmdfQdxoYQc(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				hluHrkGnXqtNHAjtSfHuejmQLtVvA(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local);
			}
		}

		internal void hCaLqbWQSqCrCkhQaLgmBuBpyIlP(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				vAApCCDfQsbpZaBvIfkmXVxiwKPHA(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local);
			}
		}

		internal void BXSBrDhsGpDxLXTaWvGqbGDJShMlA(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				OTDwtocMwnUzROqwqFbvtkKYFReT(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local);
			}
		}

		internal void NTLPLYQERLpynTvLqLicFlvBwFLS(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				NKrFckHnZmOEhWToSLTxxjQTyRlq(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local);
			}
		}

		internal void ZSDdaVXzIRWMqUMfDtnSOvgNMzkR(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				nCaIxSAcNCDnFgchgpQFnUWEHHJX(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local);
			}
		}

		internal void JnDbZLrTjdhjSfrsYrZVJIgmSIjrA(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				zXEQJBWeNpfdGKJcccWZXsBeKvrFb(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.Local);
			}
		}

		private void iJEeJhINoBCvpRowWYBZcMUjXYw(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				hluHrkGnXqtNHAjtSfHuejmQLtVvA(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion);
			}
		}

		private void UrjBNzBXltOwKYwyGugChbzXwch(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				QKTYHNzYpIghNEFUTpxsJkCsdqoi(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion);
			}
		}

		private void APGwdMKbovUchaFnKVIINPrFzlhe(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				vAApCCDfQsbpZaBvIfkmXVxiwKPHA(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion);
			}
		}

		private void RpdnuZGwRwECvWiDeRoFtplUeKTW(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				OTDwtocMwnUzROqwqFbvtkKYFReT(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion);
			}
		}

		private void ACyIUtSzIYurWtdZmHPZuxuXridK(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				NKrFckHnZmOEhWToSLTxxjQTyRlq(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion);
			}
		}

		private void HMuGiywlhuvmpMHOVSRUMlVWHQBe(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				nCaIxSAcNCDnFgchgpQFnUWEHHJX(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion);
			}
		}

		private void FjCkOLjsRvqkOGVKdjahZiGgZTiQ(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				zXEQJBWeNpfdGKJcccWZXsBeKvrFb(P_0, lYLMrHAWtGWeCWeeZmAWizaaQSHC.TouchRegion);
			}
		}

		private void twPyUADmQhxhWEFdMkTTZgmFLHtm(Vector2 P_0)
		{
			qQaapJpxQGaLHbgcrjcVeTFoGrXq(null);
			Vector2 value = P_0;
			if (_axis2D.xAxis.calibration.invert)
			{
				value.x *= -1f;
			}
			if (_axis2D.yAxis.calibration.invert)
			{
				value.y *= -1f;
			}
			value = MathTools.Clamp(value, -1f, 1f);
			if (_stickTransform != null)
			{
				RectTransform rectTransform = bfcUZrtrocGbIYScVjBcrcdwVQud;
				Vector3 position = value * DKxJefRzqlabXhLSEFjBdHlZsTfF;
				position += rectTransform.InverseTransformPoint(base.transform.position);
				Vector3 position2 = rectTransform.TransformPoint(position);
				Vector3 vector = _stickTransform.parent.InverseTransformPoint(position2);
				Vector2 anchoredPosition = JPvwdModsFtwLYKhejFPycAZezzl.VngBDAAdfViUKHCQclUmFhuUXrqs(_stickTransform.parent as RectTransform, vector);
				anchoredPosition += _origStickAnchoredPosition;
				_stickTransform.anchoredPosition = anchoredPosition;
			}
			_hierarchyValueChangedHandlers.ExecuteOnAll(P_0);
			_hierarchyStickPositionChangedHandlers.ExecuteOnAll(value);
			_onValueChanged.Invoke(P_0);
			_onStickPositionChanged.Invoke(value);
		}
	}
}
