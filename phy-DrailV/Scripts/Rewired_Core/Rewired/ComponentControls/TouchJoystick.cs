using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

		private enum zzFfxUNlqIUVPGlqLEMEIkpRFAfyA
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum aTvNXzJzKijupcJOaZoTkllfGSob
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
		private sealed class TFEDGrjeZQKejjrDwCiociUmwOrcb
		{
			public static readonly TFEDGrjeZQKejjrDwCiociUmwOrcb _003C_003E9 = new TFEDGrjeZQKejjrDwCiociUmwOrcb();

			public static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IValueChangedHandler, Vector2> _003C_003E9__277_0;

			public static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IStickPositionChangedHandler, Vector2> _003C_003E9__280_0;

			internal void QXbpNjYvUzjUmFAMkEblgdrUbiTGb(IValueChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnValueChanged(P_1);
			}

			internal void bysfhZAKSqEpchncGStIWXiMUFExb(IStickPositionChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnStickPositionChanged(P_1);
			}
		}

		private sealed class jgkeQTTCKXmLNIaWCPugjmlyhcFo : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private object vjnbYLtrPMftzpjohNfommerCnGo;

			public float qkXPLxWturrcjNqpWPvEaFUuBmCI;

			public TouchJoystick zITtixdgVFWlEnpDnrTdnZsdTFkt;

			public PositionType rrUfjUGrrfoWdcnsvZDUrItvrupt;

			public Vector2 rSjomiQzvTwnjofCtffQbKcPrxpO;

			public zzFfxUNlqIUVPGlqLEMEIkpRFAfyA CFZgLeSNFyCLpaVLVUHQRDinORMQA;

			private RectTransform ZcjMjycqMQbiMicoFMzzHkFHNpUcA;

			private Vector2 eBtPAFhRkDeVnDxzdphBhXBjIPGE;

			private float sThSegvLXYoytahwkbwZBvrRMGmd;

			private float WGhwOCFTkqWtePPHGlMSlGcurPTu;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public jgkeQTTCKXmLNIaWCPugjmlyhcFo(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				TouchJoystick touchJoystick = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_010c;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (!(qkXPLxWturrcjNqpWPvEaFUuBmCI <= 0f))
				{
					ZcjMjycqMQbiMicoFMzzHkFHNpUcA = touchJoystick.DSmDnIVkfzvBzeFgEbidCWTOTVMO;
					eBtPAFhRkDeVnDxzdphBhXBjIPGE = EeDnToreLfEgTseEVjKzmWOWfvaP.IZHCYVFceYsMoERWjWPbdWmcxIXHb(ZcjMjycqMQbiMicoFMzzHkFHNpUcA, rrUfjUGrrfoWdcnsvZDUrItvrupt);
					float magnitude = (rSjomiQzvTwnjofCtffQbKcPrxpO - eBtPAFhRkDeVnDxzdphBhXBjIPGE).magnitude;
					if (!(magnitude < 0.01f))
					{
						touchJoystick._isMoving = true;
						sThSegvLXYoytahwkbwZBvrRMGmd = magnitude / qkXPLxWturrcjNqpWPvEaFUuBmCI;
						WGhwOCFTkqWtePPHGlMSlGcurPTu = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				touchJoystick.rNLYWheOSDixDWEthcZnZxDfAVaP(CFZgLeSNFyCLpaVLVUHQRDinORMQA, rSjomiQzvTwnjofCtffQbKcPrxpO, rrUfjUGrrfoWdcnsvZDUrItvrupt);
				return false;
				IL_010c:
				if (WGhwOCFTkqWtePPHGlMSlGcurPTu <= 1f)
				{
					WGhwOCFTkqWtePPHGlMSlGcurPTu += Time.unscaledDeltaTime / sThSegvLXYoytahwkbwZBvrRMGmd;
					EeDnToreLfEgTseEVjKzmWOWfvaP.HWswGCfZinnZXqMSjKXHZdJKuMuG(ZcjMjycqMQbiMicoFMzzHkFHNpUcA, Vector2.Lerp(eBtPAFhRkDeVnDxzdphBhXBjIPGE, rSjomiQzvTwnjofCtffQbKcPrxpO, Mathf.SmoothStep(0f, 1f, WGhwOCFTkqWtePPHGlMSlGcurPTu)), rrUfjUGrrfoWdcnsvZDUrItvrupt);
					vjnbYLtrPMftzpjohNfommerCnGo = null;
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		[SerializeField]
		private RectTransform _stickTransform;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The joystick's mode of operation. Set this to Digital to simulate a D-Pad which has only On/Off states. If you want mimic a real D-Pad, you should also set Snap Directions to 8.")]
		private JoystickMode _joystickMode;

		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		[Tooltip("A dead zone which is applied when Stick Mode is set to Digital. This is used to filter out tiny stick movements near 0, 0.")]
		[SerializeField]
		private float _digitalModeDeadZone = 0.3f;

		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[Range(0.01f, 1000f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _stickRange = 60f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		private bool _scaleStickRange = true;

		[Tooltip("The shape of the range of movement of the joystick.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private StickBounds _stickBounds;

		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisDirection _axesToUse;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
		private SnapDirections _snapDirections;

		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _snapStickToTouch;

		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _centerStickOnRelease = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
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
		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _tapDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the joystick's RectTransform. This can be useful if you want a larger area of the screen to act as a joystick.")]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local joystick will be ignored and only Touch Region touches will be used. Otherwise, both touches on the joystick and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		private bool _moveToTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		private bool _manageRaycasting = true;

		private bool _useXAxis;

		private bool _useYAxis;

		private PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private zzFfxUNlqIUVPGlqLEMEIkpRFAfyA _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool qQqrGmXxzubkmCaMCrOVuSrdktRh;

		[NonSerialized]
		private bool PPobDgSULmsGqZojTdFrxnegWsbI;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private aTvNXzJzKijupcJOaZoTkllfGSob _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private StcRXHeXGKmrcfQEptFjeyDpLqUb _imageRaycastHelper = new StcRXHeXGKmrcfQEptFjeyDpLqUb();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<zzFfxUNlqIUVPGlqLEMEIkpRFAfyA> __moveStartedDelegate;

		private Action<zzFfxUNlqIUVPGlqLEMEIkpRFAfyA> __moveEndedDelegate;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick value changes.")]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		private TapEventHandler _onTap = new TapEventHandler();

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		private StickBounds AacaItYrPKUbMTBQEfSsauGCojUAA
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					yrqYbeKIijUVZAnVVTnpKMepYUwF(value);
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (xwKXEXrKdcGMyfKaNNgUPxYUBiSkA())
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
						CCHQPPVxVhbVaICAgGECKBdadleG();
					}
					else
					{
						_imageRaycastHelper.wJjPIIRJfHhEbGedUconecGfiwzgB();
					}
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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

		private bool WCFasvosqqbcVbdjMcFbAXdHuwGqA => _lastTapFrame == Time.frameCount;

		internal StandaloneAxis2D aHaHiCvZaxhAtPQaqajYYWHNjfxk => _axis2D;

		private Action<zzFfxUNlqIUVPGlqLEMEIkpRFAfyA> MbvnRVEkEQRedrcCBuZRLJFdRzvi
		{
			get
			{
				if (__moveStartedDelegate == null)
				{
					return __moveStartedDelegate = rohjiReAvoRsMeYYIHBkAAodkfIr;
				}
				return __moveStartedDelegate;
			}
		}

		private Action<zzFfxUNlqIUVPGlqLEMEIkpRFAfyA> RjefYArSdfhjtxsYljKmQhjnMMPM
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = acYSVxCyBhnzsnboYXCXymLCueHR;
				}
				return __moveEndedDelegate;
			}
		}

		private int fjtxAbJrQwCAKqphTeKWcAJwOzOx
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

		private RectTransform giXWDwhlUlbfTxuCJpKNjxYOvJpH
		{
			get
			{
				if (_lastClaimSource != aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion)
				{
					return base.transform as RectTransform;
				}
				return base.transform.parent as RectTransform;
			}
		}

		private float aOHIpTpCSEenvdTNmksrCHItBUhJA
		{
			get
			{
				if (Time.frameCount == _calculatedStickRange_lastUpdatedFrame)
				{
					return __calculatedStickRange_cachedValue;
				}
				RectTransform rectTransform = base.MEOaKmSNIwHUYDtxqlUIUZwwqRaO;
				RectTransform rectTransform2 = giXWDwhlUlbfTxuCJpKNjxYOvJpH;
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
					if (_lastClaimSource == aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion)
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

		internal static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IValueChangedHandler, Vector2> YJXtYHBGjNVnUwHmgLBesVKzuTLA
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					__valueChangedHandlerDelegate = TFEDGrjeZQKejjrDwCiociUmwOrcb._003C_003E9.QXbpNjYvUzjUmFAMkEblgdrUbiTGb;
				}
				return __valueChangedHandlerDelegate;
			}
		}

		internal static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IStickPositionChangedHandler, Vector2> oyTbvGOtBqLhshZZPDeZfBQVfLPjA
		{
			get
			{
				if (__stickPositionChangedHandlerDelegate == null)
				{
					__stickPositionChangedHandlerDelegate = TFEDGrjeZQKejjrDwCiociUmwOrcb._003C_003E9.bysfhZAKSqEpchncGStIWXiMUFExb;
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
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.value;
		}

		public Vector2 GetRawValue()
		{
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.rawValue;
		}

		public void SetRawValue(Vector2 value)
		{
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
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
			qATzXzjIGXRhrijPPfRPyscnGscS(base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.anchoredPosition);
		}

		private void qATzXzjIGXRhrijPPfRPyscnGscS(Vector2 P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_origAnchoredPosition = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				TRLOyCQJHeKwHJgDQHJmzyPRKosW(_origAnchoredPosition, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
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
				_origAnchoredPosition = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.anchoredPosition;
				if (_stickTransform != null)
				{
					_origStickAnchoredPosition = _stickTransform.anchoredPosition;
				}
				SetRawValue(aHaHiCvZaxhAtPQaqajYYWHNjfxk.rawZero);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_axis2D.Deinitialize();
				XetDzXgLfjrusCzyhbGhxGxLsdqi();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				cpAbEOeRoJbZuIDTtoiiKpNWWePmA();
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		internal override void vjhEkIpbiwZRwstmkNxqMDjviCZ()
		{
			base.vjhEkIpbiwZRwstmkNxqMDjviCZ();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				AePHCbxVsYkRUKHgGbBWjpkQgddU();
				BfcemEvRAUDLLQwTdfsEGPCDloJEA();
				onvOBINGqdjUFcaiXkezCsHLZYRA();
			}
		}

		internal override bool BUnNPMFoanNJCVAmWibAzWafnjUk()
		{
			if (!base.BUnNPMFoanNJCVAmWibAzWafnjUk())
			{
				return false;
			}
			cpAbEOeRoJbZuIDTtoiiKpNWWePmA();
			_axis2D.Initialize();
			return true;
		}

		internal override void NSaIxTLXSfKHgYqfDPqUzdSfjLOK()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
			{
				Vector2 value = _axis2D.value;
				if (_useXAxis)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(_tapCustomControllerElement, WCFasvosqqbcVbdjMcFbAXdHuwGqA);
				}
			}
		}

		internal override void OCbTyrEcaxLtyGXBEYyEklZHhUaE()
		{
			base.OCbTyrEcaxLtyGXBEYyEklZHhUaE();
			_axis2D.ValueChangedEvent += KvDhOKlllDnJVQRNDmKnUouiMevO;
		}

		internal override void tDIDrACtxdHSRUhHLVoEeNTZdDjmA()
		{
			base.tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			_axis2D.ValueChangedEvent -= KvDhOKlllDnJVQRNDmKnUouiMevO;
		}

		internal override void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
			base.jebsoqOBGHhJxfFgdjbRaKVujtZwA();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				cpAbEOeRoJbZuIDTtoiiKpNWWePmA();
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		internal override void XetDzXgLfjrusCzyhbGhxGxLsdqi()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
				PPobDgSULmsGqZojTdFrxnegWsbI = false;
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
				_moveDirection = zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.None;
				JMtnteXFqjeDNZdvuGWjEMRkGrdr();
				_axis2D.Clear();
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		internal override void kvtAMBhXvoFvKTDvbPnZAgXAnVeob()
		{
			base.kvtAMBhXvoFvKTDvbPnZAgXAnVeob();
			if (_hierarchyValueChangedHandlers == null)
			{
				_hierarchyValueChangedHandlers = new PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IValueChangedHandler, Vector2>(YJXtYHBGjNVnUwHmgLBesVKzuTLA);
			}
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			if (_hierarchyStickPositionChangedHandlers == null)
			{
				_hierarchyStickPositionChangedHandlers = new PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(oyTbvGOtBqLhshZZPDeZfBQVfLPjA);
			}
			_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
		}

		public override void ClearValue()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				if (UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_verticalAxisCustomControllerElement);
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		internal override bool XAnxKiEsqAoGaxLsQPiYTKBOAuBt()
		{
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return false;
			}
			if (!uITeqmergHcifeDewaJvLHRSazjqA())
			{
				return false;
			}
			return qQqrGmXxzubkmCaMCrOVuSrdktRh;
		}

		internal override bool CCRTYlKENtSVpmwZvzlIPCFobzki(GameObject P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (base.CCRTYlKENtSVpmwZvzlIPCFobzki(P_0))
			{
				return true;
			}
			if (_workingTouchRegion != null)
			{
				return _workingTouchRegion.gameObject == P_0;
			}
			return false;
		}

		private void QCTiHbMbjMBiDhGopGJUAtTEkvFmB()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			onvOBINGqdjUFcaiXkezCsHLZYRA();
			CCHQPPVxVhbVaICAgGECKBdadleG();
		}

		private void CCHQPPVxVhbVaICAgGECKBdadleG()
		{
			if (_manageRaycasting)
			{
				_imageRaycastHelper.WpiqHjRcuWGpcXTsCkpIPZokatTs(base.transform, gkLbwlKdyQwhpoLXtnCEOSsAkMqF());
			}
		}

		private bool gkLbwlKdyQwhpoLXtnCEOSsAkMqF()
		{
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void XsRcHdcMofeXXwuCaWifJSVWulmNA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				ROSzEBYmibvPrutzdqPFViLEreGs(P_0);
				P_0.PointerDownEvent += VvnEeLBQILUHLAWKLgnCOdVbIFoyA;
				P_0.PointerUpEvent += qsbKaKVpPEnEWhDnNiKSemHIDswR;
				P_0.PointerEnterEvent += cqjJduOBmiLDgBtoNPjlFUJyfnOI;
				P_0.PointerExitEvent += lzaDhFGRErVydKJHIIJajzRcpfsvB;
				P_0.BeginDragEvent += yreDQQcMVTufvjgEDBEuKJmvByjtA;
				P_0.DragEvent += GaEFPJkDKEGwFiixhamMxexdPIuE;
				P_0.EndDragEvent += TYMpfWPwpRrSHFapvpKOsYICDgHK;
			}
		}

		private void ROSzEBYmibvPrutzdqPFViLEreGs(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= VvnEeLBQILUHLAWKLgnCOdVbIFoyA;
				P_0.PointerUpEvent -= qsbKaKVpPEnEWhDnNiKSemHIDswR;
				P_0.PointerEnterEvent -= cqjJduOBmiLDgBtoNPjlFUJyfnOI;
				P_0.PointerExitEvent -= lzaDhFGRErVydKJHIIJajzRcpfsvB;
				P_0.BeginDragEvent -= yreDQQcMVTufvjgEDBEuKJmvByjtA;
				P_0.DragEvent -= GaEFPJkDKEGwFiixhamMxexdPIuE;
				P_0.EndDragEvent -= TYMpfWPwpRrSHFapvpKOsYICDgHK;
			}
		}

		private void onvOBINGqdjUFcaiXkezCsHLZYRA()
		{
			if (!(_workingTouchRegion == _touchRegion))
			{
				ROSzEBYmibvPrutzdqPFViLEreGs(_workingTouchRegion);
				_workingTouchRegion = _touchRegion;
				XsRcHdcMofeXXwuCaWifJSVWulmNA(_workingTouchRegion);
			}
		}

		private void FbjbVhCqtbatwGjQFsvgGueyDSBGA(Vector2 P_0, bool P_1, float P_2, zzFfxUNlqIUVPGlqLEMEIkpRFAfyA P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = EeDnToreLfEgTseEVjKzmWOWfvaP.bxxRIiMvkpOpQMGQXOctozcixKiD(base.HtGlhojWyGbbBWmlieYRaIFDtOyfA, rectTransform, P_0);
			Vector2 pivot = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.pivot;
			Vector2 sizeDelta = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.sizeDelta;
			Vector3 localScale = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			TRLOyCQJHeKwHJgDQHJmzyPRKosW(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void TRLOyCQJHeKwHJgDQHJmzyPRKosW(Vector2 P_0, PositionType P_1, bool P_2, float P_3, zzFfxUNlqIUVPGlqLEMEIkpRFAfyA P_4)
		{
			if (_isMoving && P_2 && _moveDirection == P_4)
			{
				return;
			}
			if (_isMoving && _coroutineMove != null)
			{
				JMtnteXFqjeDNZdvuGWjEMRkGrdr();
				_isMoving = false;
				_moveDirection = zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.None;
			}
			if (base.HtGlhojWyGbbBWmlieYRaIFDtOyfA == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.HtGlhojWyGbbBWmlieYRaIFDtOyfA.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.MEOaKmSNIwHUYDtxqlUIUZwwqRaO;
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
				_coroutineMove = NdGGKXbALTrFNPCleIggATGIgAzeb(P_0, P_1, P_3, P_4);
				StartCoroutine(_coroutineMove);
				_moveDirection = P_4;
				_isMovedFromDefaultPosition = true;
				MbvnRVEkEQRedrcCBuZRLJFdRzvi(P_4);
			}
			else
			{
				MbvnRVEkEQRedrcCBuZRLJFdRzvi(P_4);
				rNLYWheOSDixDWEthcZnZxDfAVaP(P_4, P_0, P_1);
			}
		}

		private IEnumerator NdGGKXbALTrFNPCleIggATGIgAzeb(Vector2 P_0, PositionType P_1, float P_2, zzFfxUNlqIUVPGlqLEMEIkpRFAfyA P_3)
		{
			return new jgkeQTTCKXmLNIaWCPugjmlyhcFo(0)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				rSjomiQzvTwnjofCtffQbKcPrxpO = P_0,
				rrUfjUGrrfoWdcnsvZDUrItvrupt = P_1,
				qkXPLxWturrcjNqpWPvEaFUuBmCI = P_2,
				CFZgLeSNFyCLpaVLVUHQRDinORMQA = P_3
			};
		}

		private void rNLYWheOSDixDWEthcZnZxDfAVaP(zzFfxUNlqIUVPGlqLEMEIkpRFAfyA P_0, Vector2 P_1, PositionType P_2)
		{
			EeDnToreLfEgTseEVjKzmWOWfvaP.HWswGCfZinnZXqMSjKXHZdJKuMuG(base.DSmDnIVkfzvBzeFgEbidCWTOTVMO, P_1, P_2);
			_isMoving = false;
			_moveDirection = zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.None;
			switch (P_0)
			{
			case zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardHome:
				_isMovedFromDefaultPosition = false;
				break;
			case zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardTouch:
				_isMovedFromDefaultPosition = true;
				break;
			}
			JMtnteXFqjeDNZdvuGWjEMRkGrdr();
			RjefYArSdfhjtxsYljKmQhjnMMPM(P_0);
		}

		private void rohjiReAvoRsMeYYIHBkAAodkfIr(zzFfxUNlqIUVPGlqLEMEIkpRFAfyA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					_imageRaycastHelper.WpiqHjRcuWGpcXTsCkpIPZokatTs(base.transform, flag2);
				}
			}
		}

		private void acYSVxCyBhnzsnboYXCXymLCueHR(zzFfxUNlqIUVPGlqLEMEIkpRFAfyA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardHome)
				{
					flag = true;
					flag2 = gkLbwlKdyQwhpoLXtnCEOSsAkMqF();
				}
				if (flag)
				{
					_imageRaycastHelper.WpiqHjRcuWGpcXTsCkpIPZokatTs(base.transform, flag2);
				}
			}
		}

		private void JMtnteXFqjeDNZdvuGWjEMRkGrdr()
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

		private void kqTTFWTvseTQmSdLBfqvxdlndWXDA(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(P_0))
			{
				TRLOyCQJHeKwHJgDQHJmzyPRKosW((Vector2)EeDnToreLfEgTseEVjKzmWOWfvaP.IZHCYVFceYsMoERWjWPbdWmcxIXHb(base.DSmDnIVkfzvBzeFgEbidCWTOTVMO, P_2) + P_1, P_2, false, 0f, zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardTouch);
				if (_lastClaimSource == aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion)
				{
					_lastPressAnchoredPosition += P_1;
				}
			}
		}

		private void BfcemEvRAUDLLQwTdfsEGPCDloJEA()
		{
			if (!hasPointer)
			{
				return;
			}
			if (!TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(fjtxAbJrQwCAKqphTeKWcAJwOzOx))
			{
				PointerEventData pointerEventData = dczyVDsPxnjiyyaODoPHeAYsoMJt(fjtxAbJrQwCAKqphTeKWcAJwOzOx);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					vviajNlqcdpzxjFwqPqOUALggKvH(pointerEventData);
				}
				else
				{
					ocNguSfHeUhMkjikGvvptZpSPVpP();
				}
			}
			else if (_pointerDownIsFake)
			{
				PointerEventData pointerEventData2 = ZEyjARxxtrCPmNkwiOXmgGaAPwfC(fjtxAbJrQwCAKqphTeKWcAJwOzOx, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
				if (pointerEventData2 != null)
				{
					eMmAiKqRqhVEQOJhyVqjKOjObcbG(pointerEventData2, _lastClaimSource);
				}
			}
		}

		private void AePHCbxVsYkRUKHgGbBWjpkQgddU()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(fjtxAbJrQwCAKqphTeKWcAJwOzOx);
				kuvCBbHykFOYJjkvqrHFvTdmRavD(ref vector);
			}
		}

		private void kuvCBbHykFOYJjkvqrHFvTdmRavD(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private bool xwKXEXrKdcGMyfKaNNgUPxYUBiSkA()
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

		private void ThPWHWimrlcazXyfWPofuuahDgzo()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = aTvNXzJzKijupcJOaZoTkllfGSob.Local;
		}

		private bool myYtwwlhtsxanLJJUsAmdAOARlCJ(int P_0)
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
			if (TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
		}

		private PointerEventData IjGPKgTPXkdFNtRxOeIZLhPNAXdfA(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = dczyVDsPxnjiyyaODoPHeAYsoMJt(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(P_0);
			if (TouchInteractable.VNDmieaLiUocagPbDSxfzUBDHEdR(P_0))
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
				if (!TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0))
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

		private PointerEventData ZEyjARxxtrCPmNkwiOXmgGaAPwfC(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = dczyVDsPxnjiyyaODoPHeAYsoMJt(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(P_0);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = P_1;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		private PointerEventData TNYrVNatiFwMytxODxgjVFEuFySR(int P_0)
		{
			PointerEventData pointerEventData = dczyVDsPxnjiyyaODoPHeAYsoMJt(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.VNDmieaLiUocagPbDSxfzUBDHEdR(P_0))
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
				if (!TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0))
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

		private void vviajNlqcdpzxjFwqPqOUALggKvH(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				TNYrVNatiFwMytxODxgjVFEuFySR(fjtxAbJrQwCAKqphTeKWcAJwOzOx);
			}
		}

		private void eMmAiKqRqhVEQOJhyVqjKOjObcbG(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if (P_0 != null)
			{
				switch (P_1)
				{
				case aTvNXzJzKijupcJOaZoTkllfGSob.Local:
					OnDrag(P_0);
					break;
				case aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion:
					GaEFPJkDKEGwFiixhamMxexdPIuE(P_0);
					break;
				default:
					throw new NotImplementedException();
				}
				TNYrVNatiFwMytxODxgjVFEuFySR(fjtxAbJrQwCAKqphTeKWcAJwOzOx);
			}
		}

		private PointerEventData dczyVDsPxnjiyyaODoPHeAYsoMJt(int P_0)
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
				if (TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0))
				{
					PointerEventData.InputButton button;
					switch (P_0)
					{
					case -1:
						button = PointerEventData.InputButton.Left;
						break;
					case -2:
						button = PointerEventData.InputButton.Right;
						break;
					case -3:
						button = PointerEventData.InputButton.Middle;
						break;
					default:
						throw new NotImplementedException();
					}
					value.button = button;
				}
			}
			return value;
		}

		private void cpAbEOeRoJbZuIDTtoiiKpNWWePmA()
		{
			yrqYbeKIijUVZAnVVTnpKMepYUwF(_axesToUse);
			if (UTvbNmLtOtvCXnKmzpVoOCmLyTeb && base.AdPalGJekNRQUVTGUZipitWwnClw.useCustomController)
			{
				if (_useXAxis)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ValidateElements(_horizontalAxisCustomControllerElement);
				}
				if (_useYAxis)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ValidateElements(_verticalAxisCustomControllerElement);
				}
				if (_allowTap)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ValidateElements(_tapCustomControllerElement);
				}
			}
		}

		private void yrqYbeKIijUVZAnVVTnpKMepYUwF(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag && UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
				{
					int targetCount = _horizontalAxisCustomControllerElement.targetCount;
					for (int i = 0; i < targetCount; i++)
					{
						base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_horizontalAxisCustomControllerElement[i]);
					}
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
				{
					int targetCount2 = _verticalAxisCustomControllerElement.targetCount;
					for (int j = 0; j < targetCount2; j++)
					{
						base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_verticalAxisCustomControllerElement[j]);
					}
				}
			}
			_axesToUse = P_0;
		}

		private void QFKOXEymAtfzaXbJhAtiDSsrpLGX(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if (!hasPointer || myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				if (uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable())
				{
					zbyGnibPBSirsUMdWdhZwaIygfajA(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void jXYdNAjblrCnDXVQHikRFJVkFajbc(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if ((!hasPointer || myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId)) && !TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(fjtxAbJrQwCAKqphTeKWcAJwOzOx))
			{
				ocNguSfHeUhMkjikGvvptZpSPVpP();
				base.OnPointerUp(P_0);
			}
		}

		private void jFpyRRTzQaTGpbtgzHIZrldBeWud(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if (hasPointer && !myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags;
			switch (P_1)
			{
			case aTvNXzJzKijupcJOaZoTkllfGSob.Local:
				mouseButtonFlags = base.allowedMouseButtons;
				break;
			case aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion:
				mouseButtonFlags = _touchRegion.allowedMouseButtons;
				break;
			default:
				throw new NotImplementedException();
			}
			if (_activateOnSwipeIn && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && (!flag || TouchInteractable.tIvoXXrIMIwvUwCpDxwPcEyiNtFC(mouseButtonFlags)) && !qQqrGmXxzubkmCaMCrOVuSrdktRh)
			{
				if (flag)
				{
					if (TouchInteractable.xKpthjOvWrGLEYZzckNkzUxWiphi(mouseButtonFlags, out var realMousePointerId))
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
				GameObject gameObject;
				switch (P_1)
				{
				case aTvNXzJzKijupcJOaZoTkllfGSob.Local:
					gameObject = base.gameObject;
					break;
				case aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion:
					gameObject = _workingTouchRegion.gameObject;
					break;
				default:
					throw new NotImplementedException();
				}
				PointerEventData pointerEventData = IjGPKgTPXkdFNtRxOeIZLhPNAXdfA((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					QFKOXEymAtfzaXbJhAtiDSsrpLGX(pointerEventData, P_1);
					if (qQqrGmXxzubkmCaMCrOVuSrdktRh)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			PPobDgSULmsGqZojTdFrxnegWsbI = true;
		}

		private void VRPzeteEbsZCPDMfbJbyNayEMNCI(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if (hasPointer && !myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && qQqrGmXxzubkmCaMCrOVuSrdktRh)
			{
				ocNguSfHeUhMkjikGvvptZpSPVpP();
			}
			base.OnPointerExit(P_0);
			PPobDgSULmsGqZojTdFrxnegWsbI = false;
		}

		private void StnLgfyeqijiyiyIOKXLvIUmAumC(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if (hasPointer && myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				base.OnBeginDrag(P_0);
			}
		}

		private void lAIOpAJSDvAuBOtFyUYLPfpyaFOL(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if (!hasPointer || !myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				return;
			}
			RectTransform rectTransform = giXWDwhlUlbfTxuCJpKNjxYOvJpH;
			Vector2 vector = ((!_snapStickToTouch) ? _lastPressAnchoredPosition : EeDnToreLfEgTseEVjKzmWOWfvaP.wBemlIOmzENYBSyxztJzcaWpgSks(base.DSmDnIVkfzvBzeFgEbidCWTOTVMO, rectTransform, base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.rect.center));
			if (!_centerStickOnRelease && !_snapStickToTouch)
			{
				vector -= _lastPressStartingValue * aOHIpTpCSEenvdTNmksrCHItBUhJA;
			}
			Vector2 vector2 = EeDnToreLfEgTseEVjKzmWOWfvaP.HYkzfMKkvaOIcnEorwrhbCsbmjtH(base.HtGlhojWyGbbBWmlieYRaIFDtOyfA, rectTransform, P_0.position);
			Vector2 vector3 = new Vector2(_useXAxis ? (vector2.x - vector.x) : 0f, _useYAxis ? (vector2.y - vector.y) : 0f);
			Vector2 vector4;
			if (_stickBounds == StickBounds.Circle)
			{
				vector4 = Vector2.ClampMagnitude(vector3, aOHIpTpCSEenvdTNmksrCHItBUhJA);
			}
			else
			{
				if (_stickBounds != StickBounds.Square)
				{
					throw new NotImplementedException();
				}
				vector4 = MathTools.Clamp(vector3, 0f - aOHIpTpCSEenvdTNmksrCHItBUhJA, aOHIpTpCSEenvdTNmksrCHItBUhJA);
			}
			Vector2 rawValue = vector4 / aOHIpTpCSEenvdTNmksrCHItBUhJA;
			SetRawValue(rawValue);
			if (_followTouchPosition)
			{
				if (_stickBounds == StickBounds.Circle)
				{
					if (vector3.sqrMagnitude > aOHIpTpCSEenvdTNmksrCHItBUhJA)
					{
						Vector2 vector5 = new Vector2(_useXAxis ? (vector3.x - vector4.x) : 0f, _useXAxis ? (vector3.y - vector4.y) : 0f);
						kqTTFWTvseTQmSdLBfqvxdlndWXDA(fjtxAbJrQwCAKqphTeKWcAJwOzOx, vector5, PositionType.Anchored);
					}
				}
				else
				{
					if (_stickBounds != StickBounds.Square)
					{
						throw new NotImplementedException();
					}
					bool flag = Mathf.Abs(vector3.x) > aOHIpTpCSEenvdTNmksrCHItBUhJA;
					bool flag2 = Mathf.Abs(vector3.y) > aOHIpTpCSEenvdTNmksrCHItBUhJA;
					if (flag || flag2)
					{
						Vector2 vector6 = new Vector2((_useXAxis && flag) ? (vector3.x - vector4.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector4.y) : 0f);
						kqTTFWTvseTQmSdLBfqvxdlndWXDA(fjtxAbJrQwCAKqphTeKWcAJwOzOx, vector6, PositionType.Anchored);
					}
				}
			}
			base.OnDrag(P_0);
		}

		private void rQIQOQBohtgktPLiQfSwSAnSUgyf(PointerEventData P_0, aTvNXzJzKijupcJOaZoTkllfGSob P_1)
		{
			if (hasPointer && myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				base.OnEndDrag(P_0);
			}
		}

		private void zbyGnibPBSirsUMdWdhZwaIygfajA(int P_0, Vector2 P_1, aTvNXzJzKijupcJOaZoTkllfGSob P_2)
		{
			_pointerId = P_0;
			_lastClaimSource = P_2;
			_isEligibleForTap = true;
			_lastPressAnchoredPosition = EeDnToreLfEgTseEVjKzmWOWfvaP.HYkzfMKkvaOIcnEorwrhbCsbmjtH(base.HtGlhojWyGbbBWmlieYRaIFDtOyfA, giXWDwhlUlbfTxuCJpKNjxYOvJpH, P_1);
			qQqrGmXxzubkmCaMCrOVuSrdktRh = true;
			_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
			_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
			_touchStartTime = Time.realtimeSinceStartup;
			_touchStartPosition = P_1;
			if (P_2 == aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion && (_moveToTouchPosition || _followTouchPosition))
			{
				if (_followTouchPosition)
				{
					FbjbVhCqtbatwGjQFsvgGueyDSBGA(P_1, false, 0f, zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardTouch);
				}
				else
				{
					FbjbVhCqtbatwGjQFsvgGueyDSBGA(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, zzFfxUNlqIUVPGlqLEMEIkpRFAfyA.TowardTouch);
				}
			}
			if (_onTouchStarted != null)
			{
				_onTouchStarted.Invoke();
			}
			PointerEventData pointerEventData = ZEyjARxxtrCPmNkwiOXmgGaAPwfC(_pointerId, (P_2 == aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
			if (pointerEventData != null)
			{
				eMmAiKqRqhVEQOJhyVqjKOjObcbG(pointerEventData, P_2);
			}
		}

		private void ocNguSfHeUhMkjikGvvptZpSPVpP()
		{
			ThPWHWimrlcazXyfWPofuuahDgzo();
			bool num = _allowTap && _isEligibleForTap;
			qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
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

		internal void kIuurkBaeVQXEvKeoUpHwDFvanke(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				jXYdNAjblrCnDXVQHikRFJVkFajbc(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.Local);
			}
		}

		internal void PGwFOvjzBABNClsiikWqPSHmkSaE(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				QFKOXEymAtfzaXbJhAtiDSsrpLGX(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.Local);
			}
		}

		internal void JnpzKJYnsyfOfPwsOaQsJaDHZrbTA(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				jFpyRRTzQaTGpbtgzHIZrldBeWud(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.Local);
			}
		}

		internal void oZNXKPzrkOQGHJcuOrJBZbPcRSZn(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				VRPzeteEbsZCPDMfbJbyNayEMNCI(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.Local);
			}
		}

		internal void ipdaaERukGdhLuzwhGwIglbtwlT(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				StnLgfyeqijiyiyIOKXLvIUmAumC(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.Local);
			}
		}

		internal void xRSxtmDlpdoibPBivduBkZSMLJfO(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				lAIOpAJSDvAuBOtFyUYLPfpyaFOL(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.Local);
			}
		}

		internal void rDkVJzgnLccmpdPbaUZYcnygmWQcA(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				rQIQOQBohtgktPLiQfSwSAnSUgyf(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.Local);
			}
		}

		private void VvnEeLBQILUHLAWKLgnCOdVbIFoyA(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				QFKOXEymAtfzaXbJhAtiDSsrpLGX(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion);
			}
		}

		private void qsbKaKVpPEnEWhDnNiKSemHIDswR(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				jXYdNAjblrCnDXVQHikRFJVkFajbc(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion);
			}
		}

		private void cqjJduOBmiLDgBtoNPjlFUJyfnOI(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				jFpyRRTzQaTGpbtgzHIZrldBeWud(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion);
			}
		}

		private void lzaDhFGRErVydKJHIIJajzRcpfsvB(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				VRPzeteEbsZCPDMfbJbyNayEMNCI(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion);
			}
		}

		private void yreDQQcMVTufvjgEDBEuKJmvByjtA(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				StnLgfyeqijiyiyIOKXLvIUmAumC(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion);
			}
		}

		private void GaEFPJkDKEGwFiixhamMxexdPIuE(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				lAIOpAJSDvAuBOtFyUYLPfpyaFOL(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion);
			}
		}

		private void TYMpfWPwpRrSHFapvpKOsYICDgHK(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				rQIQOQBohtgktPLiQfSwSAnSUgyf(P_0, aTvNXzJzKijupcJOaZoTkllfGSob.TouchRegion);
			}
		}

		private void KvDhOKlllDnJVQRNDmKnUouiMevO(Vector2 P_0)
		{
			cBqecUAeoxxZoHcAtIutmfGiHXYSA(null);
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
				RectTransform rectTransform = giXWDwhlUlbfTxuCJpKNjxYOvJpH;
				Vector3 position = value * aOHIpTpCSEenvdTNmksrCHItBUhJA;
				position += rectTransform.InverseTransformPoint(base.transform.position);
				Vector3 position2 = rectTransform.TransformPoint(position);
				Vector3 vector = _stickTransform.parent.InverseTransformPoint(position2);
				Vector2 anchoredPosition = EeDnToreLfEgTseEVjKzmWOWfvaP.pDICGVALPLtxLXgGkxWCoMTUoXhI(_stickTransform.parent as RectTransform, vector);
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
