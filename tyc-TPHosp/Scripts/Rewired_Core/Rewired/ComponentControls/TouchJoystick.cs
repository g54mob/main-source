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
	[AddComponentMenu("Rewired/Touch Joystick")]
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

		private enum oUPIrRZyCriMUPAcShdfFDradQDc
		{
			DVDMTdEnkAaktJFJqNakDhECjSAS = 0,
			gGCEEPKfpLJhbIEWxebhHfEPKFqR = 1,
			TwXdFBErLOFXUbbLkASzGEGrOQgJ = 2
		}

		private enum ntIRCNLNZzwbGhZlquZeBlORKoL
		{
			SaidbJQgZbwJIUhEOfXVjHpYIsz = 0,
			uVeuqRrVqCbFkUaeJPlhWwYcYgk = 1
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

		private sealed class CJxEcHwTVMzkIRJgaIWyEjtvwHz : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			public TouchJoystick kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public Vector2 aZvcttCYZyvpcbqSuEdfCWeofxD;

			public PositionType gKIedNefRQHDkodooGkfIArMTaNi;

			public float brHFgkYEWMuNyWyjPqgxFrGPZCw;

			public oUPIrRZyCriMUPAcShdfFDradQDc BbHMTdIqfNjQoQZLIgtdqXgYBym;

			public RectTransform SsyFcRqoyiRZmHUQnKptTLxoVUv;

			public Vector2 ebLYLqcupnCNmeUGKZVgxCeQduV;

			public float EjTbnPaoYwcSNcpZRdhqVVsZGecI;

			public float nsxQIzvtFfzbyzzAhAImepSiOXU;

			public float VcrZIZFFOTRalCfRNxzvYEcJGVx;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (!(brHFgkYEWMuNyWyjPqgxFrGPZCw <= 0f))
					{
						SsyFcRqoyiRZmHUQnKptTLxoVUv = kdBZqupjvsCsVkwJiOeEQzkEDVO.rectTransform;
						ebLYLqcupnCNmeUGKZVgxCeQduV = HIVfPxnnHQLxQzKCApRSVEGlhlG.VXVbSMdoMzOHvRIOaocImhqNoIls(SsyFcRqoyiRZmHUQnKptTLxoVUv, gKIedNefRQHDkodooGkfIArMTaNi);
						EjTbnPaoYwcSNcpZRdhqVVsZGecI = (aZvcttCYZyvpcbqSuEdfCWeofxD - ebLYLqcupnCNmeUGKZVgxCeQduV).magnitude;
						if (!(EjTbnPaoYwcSNcpZRdhqVVsZGecI < 0.01f))
						{
							kdBZqupjvsCsVkwJiOeEQzkEDVO._isMoving = true;
							nsxQIzvtFfzbyzzAhAImepSiOXU = EjTbnPaoYwcSNcpZRdhqVVsZGecI / brHFgkYEWMuNyWyjPqgxFrGPZCw;
							VcrZIZFFOTRalCfRNxzvYEcJGVx = 0f;
							goto IL_0125;
						}
					}
					goto IL_0132;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0125;
					}
					IL_0125:
					if (VcrZIZFFOTRalCfRNxzvYEcJGVx <= 1f)
					{
						VcrZIZFFOTRalCfRNxzvYEcJGVx += Time.unscaledDeltaTime / nsxQIzvtFfzbyzzAhAImepSiOXU;
						HIVfPxnnHQLxQzKCApRSVEGlhlG.OVadyLfTUUTuKfhAwqhiaCPfusM(SsyFcRqoyiRZmHUQnKptTLxoVUv, Vector2.Lerp(ebLYLqcupnCNmeUGKZVgxCeQduV, aZvcttCYZyvpcbqSuEdfCWeofxD, Mathf.SmoothStep(0f, 1f, VcrZIZFFOTRalCfRNxzvYEcJGVx)), gKIedNefRQHDkodooGkfIArMTaNi);
						ajbaQItphrIyqhowgmMTfPkCBvcN = null;
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0132;
					IL_0132:
					kdBZqupjvsCsVkwJiOeEQzkEDVO.cmBvOieMeiAlEJFxqjiAxiPCODUz(BbHMTdIqfNjQoQZLIgtdqXgYBym, aZvcttCYZyvpcbqSuEdfCWeofxD, gKIedNefRQHDkodooGkfIArMTaNi);
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
			public CJxEcHwTVMzkIRJgaIWyEjtvwHz(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
			}
		}

		private const float MAX_MOVE_SPEED = 20f;

		[SerializeField]
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[SerializeField]
		[Range(0.01f, 1000f)]
		private float _stickRange = 60f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		[SerializeField]
		private bool _scaleStickRange = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The shape of the range of movement of the joystick.")]
		private StickBounds _stickBounds;

		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisDirection _axesToUse;

		[SerializeField]
		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
		[CustomObfuscation(rename = false)]
		private SnapDirections _snapDirections;

		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _snapStickToTouch;

		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _centerStickOnRelease = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The underlying Axis 2D.")]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Should taps on the touch pad be processed?")]
		private bool _allowTap;

		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		[FieldRange(0f, float.MaxValue)]
		[CustomObfuscation(rename = false)]
		private float _tapTimeout = 0.25f;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[SerializeField]
		private int _tapDistanceLimit = 10;

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the joystick's RectTransform. This can be useful if you want a larger area of the screen to act as a joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local joystick will be ignored and only Touch Region touches will be used. Otherwise, both touches on the joystick and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useTouchRegionOnly = true;

		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[SerializeField]
		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnMoveToTouch = true;

		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		[SerializeField]
		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private float _moveToTouchSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		private bool _animateOnReturn = true;

		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		[SerializeField]
		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		private float _returnSpeed = 2f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		private bool _manageRaycasting = true;

		private bool _useXAxis;

		private bool _useYAxis;

		private AdtOIqFjosNYtDDJzoleKiXwEio.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private AdtOIqFjosNYtDDJzoleKiXwEio.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private oUPIrRZyCriMUPAcShdfFDradQDc _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool traAtpHvLXNexVrCRTWuJipMjwd;

		[NonSerialized]
		private bool IqanMrGVhLvExACtCdEAMqyHqQT;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private ntIRCNLNZzwbGhZlquZeBlORKoL _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private VRvPQHmdsvpeRqEMyCcOXcbSDWZ _imageRaycastHelper = new VRvPQHmdsvpeRqEMyCcOXcbSDWZ();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<oUPIrRZyCriMUPAcShdfFDradQDc> __moveStartedDelegate;

		private Action<oUPIrRZyCriMUPAcShdfFDradQDc> __moveEndedDelegate;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick value changes.")]
		[SerializeField]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick's stick position changes.")]
		[SerializeField]
		private ValueChangedEventHandler _onStickPositionChanged = new ValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the joystick is touched.")]
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

		private static AdtOIqFjosNYtDDJzoleKiXwEio.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static AdtOIqFjosNYtDDJzoleKiXwEio.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					pKeWVrSOISNzSBBNGegMrKsWCRO(value);
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (yAYwMKrQXZHXrNSqWOThanYtPym())
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
						PCPARCNgTWmorJBKnCnllnzHUlI();
					}
					else
					{
						_imageRaycastHelper.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
					}
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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

		private bool tapValue => _lastTapFrame == Time.frameCount;

		internal StandaloneAxis2D axis2D => _axis2D;

		private Action<oUPIrRZyCriMUPAcShdfFDradQDc> moveStartedDelegate
		{
			get
			{
				if (__moveStartedDelegate == null)
				{
					return __moveStartedDelegate = oTranSwyLPbQXnqMXiyRcliIkxw;
				}
				return __moveStartedDelegate;
			}
		}

		private Action<oUPIrRZyCriMUPAcShdfFDradQDc> moveEndedDelegate
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = lGOpDmQOzMduncmwRjrmDnVzawx;
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
				if (_lastClaimSource != ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk)
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
					return __calculatedStickRange_cachedValue;
				}
				RectTransform rectTransform = base.canvasTransform;
				RectTransform rectTransform2 = touchReferenceTransform;
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
					if (_lastClaimSource == ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk)
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

		internal static AdtOIqFjosNYtDDJzoleKiXwEio.EventFunction<IValueChangedHandler, Vector2> valueChangedHandlerDelegate
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					__valueChangedHandlerDelegate = delegate(IValueChangedHandler P_0, Vector2 P_1)
					{
						P_0.OnValueChanged(P_1);
					};
				}
				return __valueChangedHandlerDelegate;
			}
		}

		internal static AdtOIqFjosNYtDDJzoleKiXwEio.EventFunction<IStickPositionChangedHandler, Vector2> stickPositionChangedHandlerDelegate
		{
			get
			{
				if (__stickPositionChangedHandlerDelegate == null)
				{
					__stickPositionChangedHandlerDelegate = delegate(IStickPositionChangedHandler P_0, Vector2 P_1)
					{
						P_0.OnStickPositionChanged(P_1);
					};
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
			bVLtRgpzeeKoifEZUrauPucYriA(base.rectTransform.anchoredPosition);
		}

		private void bVLtRgpzeeKoifEZUrauPucYriA(Vector2 P_0)
		{
			if (base.initialized)
			{
				_origAnchoredPosition = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.initialized)
			{
				MqBlqPCfzHAXSELFPDuRHSHawkMF(_origAnchoredPosition, PositionType.SSYkzosXiTTPBCcOPEVRuAPZbiC, !instant && _animateOnReturn, _returnSpeed, oUPIrRZyCriMUPAcShdfFDradQDc.TwXdFBErLOFXUbbLkASzGEGrOQgJ);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.initialized)
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
				_origAnchoredPosition = base.rectTransform.anchoredPosition;
				if (_stickTransform != null)
				{
					_origStickAnchoredPosition = _stickTransform.anchoredPosition;
				}
				SetRawValue(axis2D.rawZero);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.initialized)
			{
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.initialized)
			{
				_axis2D.Deinitialize();
				IEbkrYeiXOaqriLcwiYMyUdsreAF();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				hjKEKTGDMqTIrdSXayZJBOZvNoba();
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		internal override void yQdUgprBXDEoWjnetusIxRhMmAu()
		{
			base.yQdUgprBXDEoWjnetusIxRhMmAu();
			if (base.initialized)
			{
				JdZlUojfSleSDdJmJmihEAqvNxTi();
				AekkuDxviraQAPdPqvLzoeQytsn();
				zvfOAwJekZgHSnaOvNHZzaMqNgQ();
			}
		}

		internal override bool USdTaHHNWIGWTOHgBLrxEkaEfPs()
		{
			if (!base.USdTaHHNWIGWTOHgBLrxEkaEfPs())
			{
				return false;
			}
			hjKEKTGDMqTIrdSXayZJBOZvNoba();
			_axis2D.Initialize();
			return true;
		}

		internal override void OnoIpIJycGHhdFNrMapnMHSEpPu()
		{
			if (base.initialized && hasController)
			{
				Vector2 value = _axis2D.value;
				if (_useXAxis)
				{
					npeGbTfGrbHYJDvUuqKBwJdsXleT(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					npeGbTfGrbHYJDvUuqKBwJdsXleT(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					npeGbTfGrbHYJDvUuqKBwJdsXleT(_tapCustomControllerElement, tapValue);
				}
			}
		}

		internal override void BxlLqiGbAIUodNYPXhhbDFpwdiA()
		{
			base.BxlLqiGbAIUodNYPXhhbDFpwdiA();
			_axis2D.ValueChangedEvent += BORFITtzDidAGHXDCfVAfBgNjyT;
		}

		internal override void eyUExPEfJOvDMpgTWfZhKmVaJVBB()
		{
			base.eyUExPEfJOvDMpgTWfZhKmVaJVBB();
			_axis2D.ValueChangedEvent -= BORFITtzDidAGHXDCfVAfBgNjyT;
		}

		internal override void qdlBanCKskFYgFyewDKidbPGRpbJ()
		{
			base.qdlBanCKskFYgFyewDKidbPGRpbJ();
			if (base.initialized)
			{
				hjKEKTGDMqTIrdSXayZJBOZvNoba();
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		internal override void IEbkrYeiXOaqriLcwiYMyUdsreAF()
		{
			if (base.initialized)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				traAtpHvLXNexVrCRTWuJipMjwd = false;
				IqanMrGVhLvExACtCdEAMqyHqQT = false;
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
				_moveDirection = oUPIrRZyCriMUPAcShdfFDradQDc.DVDMTdEnkAaktJFJqNakDhECjSAS;
				GgjjazLCAGjeIQBhjjlWbyFFMvX();
				_axis2D.Clear();
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		internal override void bAbhGMEVPDxqJQQfarYktRFMyZO()
		{
			base.bAbhGMEVPDxqJQQfarYktRFMyZO();
			if (_hierarchyValueChangedHandlers == null)
			{
				_hierarchyValueChangedHandlers = new AdtOIqFjosNYtDDJzoleKiXwEio.HierarchyEventHelper<IValueChangedHandler, Vector2>(valueChangedHandlerDelegate);
			}
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			if (_hierarchyStickPositionChangedHandlers == null)
			{
				_hierarchyStickPositionChangedHandlers = new AdtOIqFjosNYtDDJzoleKiXwEio.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(stickPositionChangedHandlerDelegate);
			}
			_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
		}

		public override void ClearValue()
		{
			if (base.initialized)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				if (hasController)
				{
					base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
					base.controller.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		internal override bool GVdTEbCGUhjDluCgHPTnyOZtsgt()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!zCDiilIuMmyrwiYynasIRcHvrxTh())
			{
				return false;
			}
			return traAtpHvLXNexVrCRTWuJipMjwd;
		}

		internal override bool DBZNemCCbEjBmnIHgXKlkdDPrhE(GameObject P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (base.DBZNemCCbEjBmnIHgXKlkdDPrhE(P_0))
			{
				return true;
			}
			if (_workingTouchRegion != null)
			{
				return _workingTouchRegion.gameObject == P_0;
			}
			return false;
		}

		private void ZBDmBmYoVxMpOXnsuZypYbLJAdh()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			zvfOAwJekZgHSnaOvNHZzaMqNgQ();
			PCPARCNgTWmorJBKnCnllnzHUlI();
		}

		private void PCPARCNgTWmorJBKnCnllnzHUlI()
		{
			if (_manageRaycasting)
			{
				_imageRaycastHelper.ZPsagkBaAfFubBAoNrUfTaaNrdjj(base.transform, leTvbaCbSfIpwpoFubGfcjgjTyMn());
			}
		}

		private bool leTvbaCbSfIpwpoFubGfcjgjTyMn()
		{
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void QSBgNgEKWYNEKAxGtTVSbnXflhSK(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				OiIVKSSVMGqSedqlicccboHpzwy(P_0);
				P_0.PointerDownEvent += EqbDkSeEiwoIINXSMrCbkUNSNXMp;
				P_0.PointerUpEvent += pXlEPBHOffgRPiBtYFzzNNDdUiS;
				P_0.PointerEnterEvent += xozFkdYIgNWtdAkJKmnWqXcJbOc;
				P_0.PointerExitEvent += iYqZdGDJeKOlcCXJHAeVAgJMotE;
				P_0.BeginDragEvent += tRohKNoZhaiwsyQSWpxHuVgYcgD;
				P_0.DragEvent += ZAUDYvqtOhFKprkXeJlUAuGTJYa;
				P_0.EndDragEvent += IuUcdZZTBwpkMARzmTQjFVSnbRh;
			}
		}

		private void OiIVKSSVMGqSedqlicccboHpzwy(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= EqbDkSeEiwoIINXSMrCbkUNSNXMp;
				P_0.PointerUpEvent -= pXlEPBHOffgRPiBtYFzzNNDdUiS;
				P_0.PointerEnterEvent -= xozFkdYIgNWtdAkJKmnWqXcJbOc;
				P_0.PointerExitEvent -= iYqZdGDJeKOlcCXJHAeVAgJMotE;
				P_0.BeginDragEvent -= tRohKNoZhaiwsyQSWpxHuVgYcgD;
				P_0.DragEvent -= ZAUDYvqtOhFKprkXeJlUAuGTJYa;
				P_0.EndDragEvent -= IuUcdZZTBwpkMARzmTQjFVSnbRh;
			}
		}

		private void zvfOAwJekZgHSnaOvNHZzaMqNgQ()
		{
			if (!(_workingTouchRegion == _touchRegion))
			{
				OiIVKSSVMGqSedqlicccboHpzwy(_workingTouchRegion);
				_workingTouchRegion = _touchRegion;
				QSBgNgEKWYNEKAxGtTVSbnXflhSK(_workingTouchRegion);
			}
		}

		private void AhzRJwCgBYyRxoCQAJKZjcgDAMzh(Vector2 P_0, bool P_1, float P_2, oUPIrRZyCriMUPAcShdfFDradQDc P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = HIVfPxnnHQLxQzKCApRSVEGlhlG.qsfJQxCcPETLDHWUUrzITRvJrGU(base.canvas, rectTransform, P_0);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 sizeDelta = base.rectTransform.sizeDelta;
			Vector3 localScale = base.rectTransform.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			MqBlqPCfzHAXSELFPDuRHSHawkMF(vector, PositionType.SaidbJQgZbwJIUhEOfXVjHpYIsz, P_1, P_2, P_3);
		}

		private void MqBlqPCfzHAXSELFPDuRHSHawkMF(Vector2 P_0, PositionType P_1, bool P_2, float P_3, oUPIrRZyCriMUPAcShdfFDradQDc P_4)
		{
			if (_isMoving && P_2 && _moveDirection == P_4)
			{
				return;
			}
			if (_isMoving && _coroutineMove != null)
			{
				GgjjazLCAGjeIQBhjjlWbyFFMvX();
				_isMoving = false;
				_moveDirection = oUPIrRZyCriMUPAcShdfFDradQDc.DVDMTdEnkAaktJFJqNakDhECjSAS;
			}
			if (base.canvas == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.canvas.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.canvasTransform;
				Vector2 one = Vector2.one;
				while ((parent = parent.parent) != rectTransform && !(parent == null))
				{
					one.x *= parent.localScale.x;
					one.y *= parent.localScale.y;
				}
				Vector2 sizeDelta = rectTransform.sizeDelta;
				bool flag = sizeDelta.x < sizeDelta.y;
				float num = MathTools.Max(sizeDelta.x, sizeDelta.y);
				float num2 = (flag ? one.y : one.x);
				if (num2 == 0f)
				{
					num2 = 0.0001f;
				}
				P_3 = P_3 / num2 * num;
				_coroutineMove = GDOMQOtmhmwMQQEzxFRHDoIbIARL(P_0, P_1, P_3, P_4);
				StartCoroutine(_coroutineMove);
				_moveDirection = P_4;
				_isMovedFromDefaultPosition = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				cmBvOieMeiAlEJFxqjiAxiPCODUz(P_4, P_0, P_1);
			}
		}

		private IEnumerator GDOMQOtmhmwMQQEzxFRHDoIbIARL(Vector2 P_0, PositionType P_1, float P_2, oUPIrRZyCriMUPAcShdfFDradQDc P_3)
		{
			CJxEcHwTVMzkIRJgaIWyEjtvwHz cJxEcHwTVMzkIRJgaIWyEjtvwHz = new CJxEcHwTVMzkIRJgaIWyEjtvwHz(0);
			cJxEcHwTVMzkIRJgaIWyEjtvwHz.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			cJxEcHwTVMzkIRJgaIWyEjtvwHz.aZvcttCYZyvpcbqSuEdfCWeofxD = P_0;
			cJxEcHwTVMzkIRJgaIWyEjtvwHz.gKIedNefRQHDkodooGkfIArMTaNi = P_1;
			cJxEcHwTVMzkIRJgaIWyEjtvwHz.brHFgkYEWMuNyWyjPqgxFrGPZCw = P_2;
			cJxEcHwTVMzkIRJgaIWyEjtvwHz.BbHMTdIqfNjQoQZLIgtdqXgYBym = P_3;
			return cJxEcHwTVMzkIRJgaIWyEjtvwHz;
		}

		private void cmBvOieMeiAlEJFxqjiAxiPCODUz(oUPIrRZyCriMUPAcShdfFDradQDc P_0, Vector2 P_1, PositionType P_2)
		{
			HIVfPxnnHQLxQzKCApRSVEGlhlG.OVadyLfTUUTuKfhAwqhiaCPfusM(base.rectTransform, P_1, P_2);
			_isMoving = false;
			_moveDirection = oUPIrRZyCriMUPAcShdfFDradQDc.DVDMTdEnkAaktJFJqNakDhECjSAS;
			switch (P_0)
			{
			case oUPIrRZyCriMUPAcShdfFDradQDc.TwXdFBErLOFXUbbLkASzGEGrOQgJ:
				_isMovedFromDefaultPosition = false;
				break;
			case oUPIrRZyCriMUPAcShdfFDradQDc.gGCEEPKfpLJhbIEWxebhHfEPKFqR:
				_isMovedFromDefaultPosition = true;
				break;
			}
			GgjjazLCAGjeIQBhjjlWbyFFMvX();
			moveEndedDelegate(P_0);
		}

		private void oTranSwyLPbQXnqMXiyRcliIkxw(oUPIrRZyCriMUPAcShdfFDradQDc P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == oUPIrRZyCriMUPAcShdfFDradQDc.gGCEEPKfpLJhbIEWxebhHfEPKFqR)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					_imageRaycastHelper.ZPsagkBaAfFubBAoNrUfTaaNrdjj(base.transform, flag2);
				}
			}
		}

		private void lGOpDmQOzMduncmwRjrmDnVzawx(oUPIrRZyCriMUPAcShdfFDradQDc P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == oUPIrRZyCriMUPAcShdfFDradQDc.TwXdFBErLOFXUbbLkASzGEGrOQgJ)
				{
					flag = true;
					flag2 = leTvbaCbSfIpwpoFubGfcjgjTyMn();
				}
				if (flag)
				{
					_imageRaycastHelper.ZPsagkBaAfFubBAoNrUfTaaNrdjj(base.transform, flag2);
				}
			}
		}

		private void GgjjazLCAGjeIQBhjjlWbyFFMvX()
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

		private void zRDaVDVWUXFSfLYFShHSEyrACKx(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(P_0))
			{
				MqBlqPCfzHAXSELFPDuRHSHawkMF((Vector2)HIVfPxnnHQLxQzKCApRSVEGlhlG.VXVbSMdoMzOHvRIOaocImhqNoIls(base.rectTransform, P_2) + P_1, P_2, false, 0f, oUPIrRZyCriMUPAcShdfFDradQDc.gGCEEPKfpLJhbIEWxebhHfEPKFqR);
				if (_lastClaimSource == ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk)
				{
					_lastPressAnchoredPosition += P_1;
				}
			}
		}

		private void AekkuDxviraQAPdPqvLzoeQytsn()
		{
			if (!hasPointer)
			{
				return;
			}
			if (!TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
			{
				PointerEventData pointerEventData = yHrsPUsBTKoffjSCQeywZyWFrOh(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					avwmcSzQSEgYouckhaptbkNDseT(pointerEventData);
				}
				else
				{
					bCVmmRpfQdgPtiosLDGEOIttkFRM();
				}
			}
			else if (_pointerDownIsFake)
			{
				PointerEventData pointerEventData2 = UKqbWOpPTQJChOIanzJLDqApVkX(effectivePointerId, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
				if (pointerEventData2 != null)
				{
					dmcWBTudHGINqJFpjaWcjOznbJn(pointerEventData2, _lastClaimSource);
				}
			}
		}

		private void JdZlUojfSleSDdJmJmihEAqvNxTi()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(effectivePointerId);
				xzaSEYZOOyFOHaePdKwmCThPLuB(ref vector);
			}
		}

		private void xzaSEYZOOyFOHaePdKwmCThPLuB(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private bool yAYwMKrQXZHXrNSqWOThanYtPym()
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

		private void ICZaXXGeTWWhejUbLxZSqRsMQuRB()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz;
		}

		private bool beMrQrnNPRabsSFJFZFTWEkfLfi(int P_0)
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
			if (TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
		}

		private PointerEventData LPSQCjDNxTWIUuTjTGvgkBFgTLH(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = yHrsPUsBTKoffjSCQeywZyWFrOh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(P_0);
			if (TouchInteractable.EUNPoxeUSzLzbtpjIDKKKWBaQYL(P_0))
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
					float num = unscaledTime - pointerEventData.clickTime;
					if (num < 0.3f)
					{
						pointerEventData.clickCount++;
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
				if (!TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0))
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
					float num2 = unscaledTime2 - pointerEventData.clickTime;
					if (num2 < 0.3f)
					{
						pointerEventData.clickCount++;
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

		private PointerEventData UKqbWOpPTQJChOIanzJLDqApVkX(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = yHrsPUsBTKoffjSCQeywZyWFrOh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(P_0);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = P_1;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		private PointerEventData YnMpqWcSMgzOjkQUUUqSqpETmui(int P_0)
		{
			PointerEventData pointerEventData = yHrsPUsBTKoffjSCQeywZyWFrOh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.EUNPoxeUSzLzbtpjIDKKKWBaQYL(P_0))
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
				if (!TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0))
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

		private void avwmcSzQSEgYouckhaptbkNDseT(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				YnMpqWcSMgzOjkQUUUqSqpETmui(effectivePointerId);
			}
		}

		private void dmcWBTudHGINqJFpjaWcjOznbJn(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if (P_0 != null)
			{
				switch (P_1)
				{
				case ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz:
					OnDrag(P_0);
					break;
				case ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk:
					ZAUDYvqtOhFKprkXeJlUAuGTJYa(P_0);
					break;
				default:
					throw new NotImplementedException();
				}
				YnMpqWcSMgzOjkQUUUqSqpETmui(effectivePointerId);
			}
		}

		private PointerEventData yHrsPUsBTKoffjSCQeywZyWFrOh(int P_0)
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
				if (TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0))
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

		private void hjKEKTGDMqTIrdSXayZJBOZvNoba()
		{
			pKeWVrSOISNzSBBNGegMrKsWCRO(_axesToUse);
			if (hasController && base.touchController.useCustomController)
			{
				if (_useXAxis)
				{
					base.controller.ValidateElements(_horizontalAxisCustomControllerElement);
				}
				if (_useYAxis)
				{
					base.controller.ValidateElements(_verticalAxisCustomControllerElement);
				}
				if (_allowTap)
				{
					base.controller.ValidateElements(_tapCustomControllerElement);
				}
			}
		}

		private void pKeWVrSOISNzSBBNGegMrKsWCRO(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag && hasController)
				{
					int targetCount = _horizontalAxisCustomControllerElement.targetCount;
					for (int i = 0; i < targetCount; i++)
					{
						base.controller.ClearElementValue(_horizontalAxisCustomControllerElement[i]);
					}
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && hasController)
				{
					int targetCount2 = _verticalAxisCustomControllerElement.targetCount;
					for (int j = 0; j < targetCount2; j++)
					{
						base.controller.ClearElementValue(_verticalAxisCustomControllerElement[j]);
					}
				}
			}
			_axesToUse = P_0;
		}

		private void VZWPPRkHaAzgbWCTqMIJiKiWgZm(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if (!hasPointer || beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				if (zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable())
				{
					cViKfhpmnxGslCDrJoQcTVUDatYE(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void yQOZXNtLHWGaWIrWSOHsscHiLuT(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if ((!hasPointer || beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId)) && !TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
			{
				bCVmmRpfQdgPtiosLDGEOIttkFRM();
				base.OnPointerUp(P_0);
			}
		}

		private void mZbaXWFXpZQDscfQismiYpcuizW(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if (hasPointer && !beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz => base.allowedMouseButtons, 
				ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && (!flag || TouchInteractable.mjfqtOtDkxtBHvBGQKSoLmCVGJt(mouseButtonFlags)) && !traAtpHvLXNexVrCRTWuJipMjwd)
			{
				if (flag)
				{
					if (TouchInteractable.qlxzzsOdoUANRhJbnEPLSQzjWeJi(mouseButtonFlags, out var realMousePointerId))
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
					ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz => base.gameObject, 
					ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk => _workingTouchRegion.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = LPSQCjDNxTWIUuTjTGvgkBFgTLH((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					VZWPPRkHaAzgbWCTqMIJiKiWgZm(pointerEventData, P_1);
					if (traAtpHvLXNexVrCRTWuJipMjwd)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			IqanMrGVhLvExACtCdEAMqyHqQT = true;
		}

		private void ETirtckwAXAWBWCQmcBygkjzMuX(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if (hasPointer && !beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && traAtpHvLXNexVrCRTWuJipMjwd)
			{
				bCVmmRpfQdgPtiosLDGEOIttkFRM();
			}
			base.OnPointerExit(P_0);
			IqanMrGVhLvExACtCdEAMqyHqQT = false;
		}

		private void VpmVcGyIfRihIpiBZtaaOEHNQMI(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if (hasPointer && beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				base.OnBeginDrag(P_0);
			}
		}

		private void wASIEJNFrIgVOFlVvoneqzlRMco(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if (!hasPointer || !beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				return;
			}
			RectTransform rectTransform = touchReferenceTransform;
			Vector2 vector = ((!_snapStickToTouch) ? _lastPressAnchoredPosition : HIVfPxnnHQLxQzKCApRSVEGlhlG.pCuifVMADflVGNprgaSSVaSIxIE(base.rectTransform, rectTransform, base.rectTransform.rect.center));
			if (!_centerStickOnRelease && !_snapStickToTouch)
			{
				vector -= _lastPressStartingValue * calculatedStickRange;
			}
			Vector2 vector2 = HIVfPxnnHQLxQzKCApRSVEGlhlG.QdatOZSQNHRKjecUoBuSQiqOqUZ(base.canvas, rectTransform, P_0.position);
			Vector2 vector3 = new Vector2(_useXAxis ? (vector2.x - vector.x) : 0f, _useYAxis ? (vector2.y - vector.y) : 0f);
			Vector2 vector4;
			if (_stickBounds == StickBounds.Circle)
			{
				vector4 = Vector2.ClampMagnitude(vector3, calculatedStickRange);
			}
			else
			{
				if (_stickBounds != StickBounds.Square)
				{
					throw new NotImplementedException();
				}
				vector4 = MathTools.Clamp(vector3, 0f - calculatedStickRange, calculatedStickRange);
			}
			Vector2 rawValue = vector4 / calculatedStickRange;
			SetRawValue(rawValue);
			if (_followTouchPosition)
			{
				if (_stickBounds == StickBounds.Circle)
				{
					if (vector3.sqrMagnitude > calculatedStickRange)
					{
						Vector2 vector5 = new Vector2(_useXAxis ? (vector3.x - vector4.x) : 0f, _useXAxis ? (vector3.y - vector4.y) : 0f);
						zRDaVDVWUXFSfLYFShHSEyrACKx(effectivePointerId, vector5, PositionType.SSYkzosXiTTPBCcOPEVRuAPZbiC);
					}
				}
				else
				{
					if (_stickBounds != StickBounds.Square)
					{
						throw new NotImplementedException();
					}
					bool flag = Mathf.Abs(vector3.x) > calculatedStickRange;
					bool flag2 = Mathf.Abs(vector3.y) > calculatedStickRange;
					if (flag || flag2)
					{
						Vector2 vector6 = new Vector2((_useXAxis && flag) ? (vector3.x - vector4.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector4.y) : 0f);
						zRDaVDVWUXFSfLYFShHSEyrACKx(effectivePointerId, vector6, PositionType.SSYkzosXiTTPBCcOPEVRuAPZbiC);
					}
				}
			}
			base.OnDrag(P_0);
		}

		private void kpYAUDLDLYtKoEIcJGDZnUQpQXS(PointerEventData P_0, ntIRCNLNZzwbGhZlquZeBlORKoL P_1)
		{
			if (hasPointer && beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				base.OnEndDrag(P_0);
			}
		}

		private void cViKfhpmnxGslCDrJoQcTVUDatYE(int P_0, Vector2 P_1, ntIRCNLNZzwbGhZlquZeBlORKoL P_2)
		{
			_pointerId = P_0;
			_lastClaimSource = P_2;
			_isEligibleForTap = true;
			_lastPressAnchoredPosition = HIVfPxnnHQLxQzKCApRSVEGlhlG.QdatOZSQNHRKjecUoBuSQiqOqUZ(base.canvas, touchReferenceTransform, P_1);
			traAtpHvLXNexVrCRTWuJipMjwd = true;
			_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
			_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
			_touchStartTime = Time.realtimeSinceStartup;
			_touchStartPosition = P_1;
			if (P_2 == ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk && (_moveToTouchPosition || _followTouchPosition))
			{
				if (_followTouchPosition)
				{
					AhzRJwCgBYyRxoCQAJKZjcgDAMzh(P_1, false, 0f, oUPIrRZyCriMUPAcShdfFDradQDc.gGCEEPKfpLJhbIEWxebhHfEPKFqR);
				}
				else
				{
					AhzRJwCgBYyRxoCQAJKZjcgDAMzh(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, oUPIrRZyCriMUPAcShdfFDradQDc.gGCEEPKfpLJhbIEWxebhHfEPKFqR);
				}
			}
			if (_onTouchStarted != null)
			{
				_onTouchStarted.Invoke();
			}
			PointerEventData pointerEventData = UKqbWOpPTQJChOIanzJLDqApVkX(_pointerId, (P_2 == ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
			if (pointerEventData != null)
			{
				dmcWBTudHGINqJFpjaWcjOznbJn(pointerEventData, P_2);
			}
		}

		private void bCVmmRpfQdgPtiosLDGEOIttkFRM()
		{
			ICZaXXGeTWWhejUbLxZSqRsMQuRB();
			bool flag = _allowTap && _isEligibleForTap;
			traAtpHvLXNexVrCRTWuJipMjwd = false;
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
			if (flag)
			{
				_lastTapFrame = Time.frameCount + 1;
				_onTap.Invoke();
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				yQOZXNtLHWGaWIrWSOHsscHiLuT(eventData, ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				VZWPPRkHaAzgbWCTqMIJiKiWgZm(eventData, ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				mZbaXWFXpZQDscfQismiYpcuizW(eventData, ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				ETirtckwAXAWBWCQmcBygkjzMuX(eventData, ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				VpmVcGyIfRihIpiBZtaaOEHNQMI(eventData, ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnDrag(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				wASIEJNFrIgVOFlVvoneqzlRMco(eventData, ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnEndDrag(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				kpYAUDLDLYtKoEIcJGDZnUQpQXS(eventData, ntIRCNLNZzwbGhZlquZeBlORKoL.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		private void EqbDkSeEiwoIINXSMrCbkUNSNXMp(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				VZWPPRkHaAzgbWCTqMIJiKiWgZm(P_0, ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void pXlEPBHOffgRPiBtYFzzNNDdUiS(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				yQOZXNtLHWGaWIrWSOHsscHiLuT(P_0, ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void xozFkdYIgNWtdAkJKmnWqXcJbOc(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				mZbaXWFXpZQDscfQismiYpcuizW(P_0, ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void iYqZdGDJeKOlcCXJHAeVAgJMotE(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				ETirtckwAXAWBWCQmcBygkjzMuX(P_0, ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void tRohKNoZhaiwsyQSWpxHuVgYcgD(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				VpmVcGyIfRihIpiBZtaaOEHNQMI(P_0, ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void ZAUDYvqtOhFKprkXeJlUAuGTJYa(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				wASIEJNFrIgVOFlVvoneqzlRMco(P_0, ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void IuUcdZZTBwpkMARzmTQjFVSnbRh(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				kpYAUDLDLYtKoEIcJGDZnUQpQXS(P_0, ntIRCNLNZzwbGhZlquZeBlORKoL.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void BORFITtzDidAGHXDCfVAfBgNjyT(Vector2 P_0)
		{
			bxcFuVigGCNQnErQwkHMGEIXJZoF(null);
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
				RectTransform rectTransform = touchReferenceTransform;
				Vector3 position = value * calculatedStickRange;
				position += rectTransform.InverseTransformPoint(base.transform.position);
				Vector3 position2 = rectTransform.TransformPoint(position);
				Vector3 vector = _stickTransform.parent.InverseTransformPoint(position2);
				Vector2 anchoredPosition = HIVfPxnnHQLxQzKCApRSVEGlhlG.oCSUyKYLzkgLGKEMxULrJTJpuOT(_stickTransform.parent as RectTransform, vector);
				anchoredPosition += _origStickAnchoredPosition;
				_stickTransform.anchoredPosition = anchoredPosition;
			}
			_hierarchyValueChangedHandlers.ExecuteOnAll(P_0);
			_hierarchyStickPositionChangedHandlers.ExecuteOnAll(value);
			_onValueChanged.Invoke(P_0);
			_onStickPositionChanged.Invoke(value);
		}

		[CompilerGenerated]
		private static void tRZEwsgoLQSpgDqaVKWgWHkeDJgG(IValueChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnValueChanged(P_1);
		}

		[CompilerGenerated]
		private static void ygUomfbrYjQVfyFBrkLIOSbwfeP(IStickPositionChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnStickPositionChanged(P_1);
		}
	}
}
