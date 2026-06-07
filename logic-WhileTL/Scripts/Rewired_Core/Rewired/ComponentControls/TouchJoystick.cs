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
	[AddComponentMenu("Rewired/Touch Joystick")]
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

		private enum INaLVlEEKkYnjkKyaWcjcCQYeri
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum JqhjQSbOLueCKcXtNjdSinGgvOOuA
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
		private sealed class kjUBggGfvIgZPISdDBCUfxjbgAlM
		{
			public static readonly kjUBggGfvIgZPISdDBCUfxjbgAlM _003C_003E9 = new kjUBggGfvIgZPISdDBCUfxjbgAlM();

			public static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IValueChangedHandler, Vector2> _003C_003E9__277_0;

			public static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IStickPositionChangedHandler, Vector2> _003C_003E9__280_0;

			internal void rojQLwoGojpsMalgZBwPiBWLaNVj(IValueChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnValueChanged(P_1);
			}

			internal void SbwCeYuvwefMYWNKphPoMnHDCHOHA(IStickPositionChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnStickPositionChanged(P_1);
			}
		}

		private sealed class UkIZWvhoPLqrejoibIGZkIrziHAc : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private object USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			public float RTHUUqokIzIENeGXftdmzIzrqZYk;

			public TouchJoystick GZXxEqHwrHYIyUJtInpLwgTukJaY;

			public PositionType AUMAgZZLBrHzLgTUYOnkEcEkkkfGc;

			public Vector2 GPrcxxCgPFJPNaVyAUBmpuVaCrKbd;

			public INaLVlEEKkYnjkKyaWcjcCQYeri vJROrazzqkuFowhstzcKQBkiBOn;

			private RectTransform qFzqahMwvABcaXQMePQLzcLClWIe;

			private Vector2 VybkKGDZvBOLPuPNAxXxkmgqbIQt;

			private float NQxPJdHgtMBLHGPLDXXpWVSGwEix;

			private float pkpBVFhaGsQICwoxdelakPJbHgFI;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
				}
			}

			[DebuggerHidden]
			public UkIZWvhoPLqrejoibIGZkIrziHAc(int P_0)
			{
				GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
				TouchJoystick gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
				{
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
					{
						return false;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					goto IL_010c;
				}
				GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
				if (!(RTHUUqokIzIENeGXftdmzIzrqZYk <= 0f))
				{
					qFzqahMwvABcaXQMePQLzcLClWIe = gZXxEqHwrHYIyUJtInpLwgTukJaY.uBgsATlVNpCXLTZUrAUVBouJZPML;
					VybkKGDZvBOLPuPNAxXxkmgqbIQt = rAPtcpHLzzLbzFhqkNsLlgjZFneJA.jqVCRSYgYAAfCassUTnRPsBnBSBcA(qFzqahMwvABcaXQMePQLzcLClWIe, AUMAgZZLBrHzLgTUYOnkEcEkkkfGc);
					float magnitude = (GPrcxxCgPFJPNaVyAUBmpuVaCrKbd - VybkKGDZvBOLPuPNAxXxkmgqbIQt).magnitude;
					if (!(magnitude < 0.01f))
					{
						gZXxEqHwrHYIyUJtInpLwgTukJaY._isMoving = true;
						NQxPJdHgtMBLHGPLDXXpWVSGwEix = magnitude / RTHUUqokIzIENeGXftdmzIzrqZYk;
						pkpBVFhaGsQICwoxdelakPJbHgFI = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				gZXxEqHwrHYIyUJtInpLwgTukJaY.WQXJGuUNcDBFtdyHEvIDGCascPox(vJROrazzqkuFowhstzcKQBkiBOn, GPrcxxCgPFJPNaVyAUBmpuVaCrKbd, AUMAgZZLBrHzLgTUYOnkEcEkkkfGc);
				return false;
				IL_010c:
				if (pkpBVFhaGsQICwoxdelakPJbHgFI <= 1f)
				{
					pkpBVFhaGsQICwoxdelakPJbHgFI += Time.unscaledDeltaTime / NQxPJdHgtMBLHGPLDXXpWVSGwEix;
					rAPtcpHLzzLbzFhqkNsLlgjZFneJA.ggeBfXdXMzUKfWJqSCynZUgDwusiA(qFzqahMwvABcaXQMePQLzcLClWIe, Vector2.Lerp(VybkKGDZvBOLPuPNAxXxkmgqbIQt, GPrcxxCgPFJPNaVyAUBmpuVaCrKbd, Mathf.SmoothStep(0f, 1f, pkpBVFhaGsQICwoxdelakPJbHgFI)), AUMAgZZLBrHzLgTUYOnkEcEkkkfGc);
					USjDTWbJtWhEBdYYYfLUglTcnnGrA = null;
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
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
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		private RectTransform _stickTransform;

		[Tooltip("The joystick's mode of operation. Set this to Digital to simulate a D-Pad which has only On/Off states. If you want mimic a real D-Pad, you should also set Snap Directions to 8.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private JoystickMode _joystickMode;

		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		[Tooltip("A dead zone which is applied when Stick Mode is set to Digital. This is used to filter out tiny stick movements near 0, 0.")]
		[SerializeField]
		private float _digitalModeDeadZone = 0.3f;

		[Range(0.01f, 1000f)]
		[SerializeField]
		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[CustomObfuscation(rename = false)]
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

		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _snapStickToTouch;

		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _centerStickOnRelease = true;

		[Tooltip("The underlying Axis 2D.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
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

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		private bool _moveToTouchPosition;

		[CustomObfuscation(rename = false)]
		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		private bool _returnOnRelease = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		private bool _followTouchPosition;

		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnMoveToTouch = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Range(0f, 20f)]
		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private float _moveToTouchSpeed = 2f;

		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnReturn = true;

		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		[SerializeField]
		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _manageRaycasting = true;

		private bool _useXAxis;

		private bool _useYAxis;

		private iFznRwzhmJipMjcfRBhjJauAXkUOA.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private iFznRwzhmJipMjcfRBhjJauAXkUOA.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private INaLVlEEKkYnjkKyaWcjcCQYeri _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool HNeekbdvHcSGCkhkngTpwdUwueLRA;

		[NonSerialized]
		private bool aMiVitsTbcaHUuBPegFBByVtJKdtA;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private JqhjQSbOLueCKcXtNjdSinGgvOOuA _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private bizhSGSkbYKHLUAwUjJldBHmyZwq _imageRaycastHelper = new bizhSGSkbYKHLUAwUjJldBHmyZwq();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> __moveStartedDelegate;

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> __moveEndedDelegate;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick value changes.")]
		[SerializeField]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick's stick position changes.")]
		[SerializeField]
		private ValueChangedEventHandler _onStickPositionChanged = new ValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the joystick is touched.")]
		private TouchStartedEventHandler _onTouchStarted = new TouchStartedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchEndedEventHandler _onTouchEnded = new TouchEndedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[CustomObfuscation(rename = false)]
		private TapEventHandler _onTap = new TapEventHandler();

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		private StickBounds bJwZTusLjGcEamLgzowGnTtVOpOt
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					LoesNjgEUrYfdvEfknfJNxZeoYen(value);
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (CZCTQSVOBilzIhcUcSFoCffNCgIT())
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
						pzPMFEbyDhmWExkoJxkqFuWrLfmN();
					}
					else
					{
						_imageRaycastHelper.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
					}
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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

		private bool xmVZjoUJWiTDjMKZjjdBUzMMTwIM => _lastTapFrame == Time.frameCount;

		internal StandaloneAxis2D JeoDAFkVAltOVqQINZSuDxwGGvnT => _axis2D;

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> hyflsGakWYPyLOtmggGdIrukDZdP
		{
			get
			{
				if (__moveStartedDelegate == null)
				{
					return __moveStartedDelegate = KlzDqOhWDaEscpTwtInUZXFgetYgb;
				}
				return __moveStartedDelegate;
			}
		}

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> uyVPZaTPIjGJKKabCgQTRIXqAPLc
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = TfMWssqBnrIKOIMGruTtpLqJkuDH;
				}
				return __moveEndedDelegate;
			}
		}

		private int QZxLXilNaypGgRZBuiQoBHottyGi
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

		private RectTransform PERVNvTritjAxOJkevDzqabLFppY
		{
			get
			{
				if (_lastClaimSource != JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion)
				{
					return base.transform as RectTransform;
				}
				return base.transform.parent as RectTransform;
			}
		}

		private float PRZyCPNeNSAVBodpDSRtCbkaIvbB
		{
			get
			{
				if (Time.frameCount == _calculatedStickRange_lastUpdatedFrame)
				{
					return __calculatedStickRange_cachedValue;
				}
				RectTransform rectTransform = base.boAaJrcsmiHhkYkFXRgeFHFbAFmGb;
				RectTransform rectTransform2 = PERVNvTritjAxOJkevDzqabLFppY;
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
					if (_lastClaimSource == JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion)
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

		internal static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IValueChangedHandler, Vector2> lmZgyJnIarviZfOvZzxbtpiJCcDU
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					__valueChangedHandlerDelegate = kjUBggGfvIgZPISdDBCUfxjbgAlM._003C_003E9.rojQLwoGojpsMalgZBwPiBWLaNVj;
				}
				return __valueChangedHandlerDelegate;
			}
		}

		internal static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IStickPositionChangedHandler, Vector2> DHBgoNgozsYOKsUzifGfZijMsFVQA
		{
			get
			{
				if (__stickPositionChangedHandlerDelegate == null)
				{
					__stickPositionChangedHandlerDelegate = kjUBggGfvIgZPISdDBCUfxjbgAlM._003C_003E9.SbwCeYuvwefMYWNKphPoMnHDCHOHA;
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
			if (!base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.value;
		}

		public Vector2 GetRawValue()
		{
			if (!base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.rawValue;
		}

		public void SetRawValue(Vector2 value)
		{
			if (!base.qumTafanxrjKbDduWdypwIzXqmiP)
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
			ZrZWwcXscDUNLLffipUjfeXokFej(base.uBgsATlVNpCXLTZUrAUVBouJZPML.anchoredPosition);
		}

		private void ZrZWwcXscDUNLLffipUjfeXokFej(Vector2 P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_origAnchoredPosition = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				eITbiRqIzcvtzyMtnrVQwwxIcFag(_origAnchoredPosition, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, INaLVlEEKkYnjkKyaWcjcCQYeri.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
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
				_origAnchoredPosition = base.uBgsATlVNpCXLTZUrAUVBouJZPML.anchoredPosition;
				if (_stickTransform != null)
				{
					_origStickAnchoredPosition = _stickTransform.anchoredPosition;
				}
				SetRawValue(JeoDAFkVAltOVqQINZSuDxwGGvnT.rawZero);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_axis2D.Deinitialize();
				wfYqWOGHtnIUbtMhSNJLmUHIcfqd();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				DFIDrBdFGXaeOuMhQIQKCqkLMkPfA();
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		internal override void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
			base.IghfPvNUXsucbZILFgzLRWwwGmUeA();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				tZIZiJgAAQoalmOpfhkiyBVatjyA();
				egDhVENqiOmptpvGuCmdKvgAwDfc();
				JLnGBUfdysxYoDUCZJSERpDKNZAO();
			}
		}

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			if (!base.qrhyEDreMhRqasASvGWwEiXwPpSPA())
			{
				return false;
			}
			DFIDrBdFGXaeOuMhQIQKCqkLMkPfA();
			_axis2D.Initialize();
			return true;
		}

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
			{
				Vector2 value = _axis2D.value;
				if (_useXAxis)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_tapCustomControllerElement, xmVZjoUJWiTDjMKZjjdBUzMMTwIM);
				}
			}
		}

		internal override void pmxmOeyRAlBoCxmllQyaxtECbvcr()
		{
			base.pmxmOeyRAlBoCxmllQyaxtECbvcr();
			_axis2D.ValueChangedEvent += lLFFKNPRhFapxntcuwlZTDsroWzC;
		}

		internal override void KhQueZDBBtkbvKkxubYmYxeSHJrfA()
		{
			base.KhQueZDBBtkbvKkxubYmYxeSHJrfA();
			_axis2D.ValueChangedEvent -= lLFFKNPRhFapxntcuwlZTDsroWzC;
		}

		internal override void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
			base.CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				DFIDrBdFGXaeOuMhQIQKCqkLMkPfA();
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		internal override void wfYqWOGHtnIUbtMhSNJLmUHIcfqd()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				HNeekbdvHcSGCkhkngTpwdUwueLRA = false;
				aMiVitsTbcaHUuBPegFBByVtJKdtA = false;
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
				_moveDirection = INaLVlEEKkYnjkKyaWcjcCQYeri.None;
				ewnocjnbCdATpbuVDhgTcBsizpjGb();
				_axis2D.Clear();
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		internal override void LLzALYpKRiDYsyFTIBJvkresqDwWA()
		{
			base.LLzALYpKRiDYsyFTIBJvkresqDwWA();
			if (_hierarchyValueChangedHandlers == null)
			{
				_hierarchyValueChangedHandlers = new iFznRwzhmJipMjcfRBhjJauAXkUOA.HierarchyEventHelper<IValueChangedHandler, Vector2>(lmZgyJnIarviZfOvZzxbtpiJCcDU);
			}
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			if (_hierarchyStickPositionChangedHandlers == null)
			{
				_hierarchyStickPositionChangedHandlers = new iFznRwzhmJipMjcfRBhjJauAXkUOA.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(DHBgoNgozsYOKsUzifGfZijMsFVQA);
			}
			_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
		}

		public override void ClearValue()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				if (lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_verticalAxisCustomControllerElement);
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		internal override bool iRdXbhkXKKrPUChGpkAoIswDMaDN()
		{
			if (!base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				return false;
			}
			if (!BmJxkhIhAZjPFwDWRTfFEWoVOzdM())
			{
				return false;
			}
			return HNeekbdvHcSGCkhkngTpwdUwueLRA;
		}

		internal override bool pzZuAkmltxMhZFAhATJmEgsvqjqP(GameObject P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (base.pzZuAkmltxMhZFAhATJmEgsvqjqP(P_0))
			{
				return true;
			}
			if (_workingTouchRegion != null)
			{
				return _workingTouchRegion.gameObject == P_0;
			}
			return false;
		}

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			JLnGBUfdysxYoDUCZJSERpDKNZAO();
			pzPMFEbyDhmWExkoJxkqFuWrLfmN();
		}

		private void pzPMFEbyDhmWExkoJxkqFuWrLfmN()
		{
			if (_manageRaycasting)
			{
				_imageRaycastHelper.nmwDzgxVACcOAJkYbADwUYDbZzFK(base.transform, PGRwgyyCEWmVXLbfYWHiHTHXKcgx());
			}
		}

		private bool PGRwgyyCEWmVXLbfYWHiHTHXKcgx()
		{
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void cVJYLgudKpcedZGsLcQHBTgFXrogA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				esAXKEkUWhoBLDsRGfMxQcmHceQK(P_0);
				P_0.PointerDownEvent += mYtlVUwcgRDqffxeyQNiuhceENseA;
				P_0.PointerUpEvent += LphWTZrpvYLSyEGXsYgatVgDoywK;
				P_0.PointerEnterEvent += TMvPCdsBYetiGshWuVrBWfehcrIfA;
				P_0.PointerExitEvent += KPebiOdQuvcDTjsxtodIOqscoheFb;
				P_0.BeginDragEvent += DioRXQKhVFSVUIyHkcQmUXTcypWb;
				P_0.DragEvent += vjSkIKYzzYorlBwUUeSyguFmTJeV;
				P_0.EndDragEvent += kiYAuTAdRDaAhYmNElDiyxdPqPHZ;
			}
		}

		private void esAXKEkUWhoBLDsRGfMxQcmHceQK(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= mYtlVUwcgRDqffxeyQNiuhceENseA;
				P_0.PointerUpEvent -= LphWTZrpvYLSyEGXsYgatVgDoywK;
				P_0.PointerEnterEvent -= TMvPCdsBYetiGshWuVrBWfehcrIfA;
				P_0.PointerExitEvent -= KPebiOdQuvcDTjsxtodIOqscoheFb;
				P_0.BeginDragEvent -= DioRXQKhVFSVUIyHkcQmUXTcypWb;
				P_0.DragEvent -= vjSkIKYzzYorlBwUUeSyguFmTJeV;
				P_0.EndDragEvent -= kiYAuTAdRDaAhYmNElDiyxdPqPHZ;
			}
		}

		private void JLnGBUfdysxYoDUCZJSERpDKNZAO()
		{
			if (!(_workingTouchRegion == _touchRegion))
			{
				esAXKEkUWhoBLDsRGfMxQcmHceQK(_workingTouchRegion);
				_workingTouchRegion = _touchRegion;
				cVJYLgudKpcedZGsLcQHBTgFXrogA(_workingTouchRegion);
			}
		}

		private void yXvFCwguRvPGWzUcsYLKERTdoKRZA(Vector2 P_0, bool P_1, float P_2, INaLVlEEKkYnjkKyaWcjcCQYeri P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = rAPtcpHLzzLbzFhqkNsLlgjZFneJA.SgnmCnknRrphshQsybuTdsGjQtuR(base.oJQqczDhICKLxrvFLqPtRJoISnkJ, rectTransform, P_0);
			Vector2 pivot = base.uBgsATlVNpCXLTZUrAUVBouJZPML.pivot;
			Vector2 sizeDelta = base.uBgsATlVNpCXLTZUrAUVBouJZPML.sizeDelta;
			Vector3 localScale = base.uBgsATlVNpCXLTZUrAUVBouJZPML.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			eITbiRqIzcvtzyMtnrVQwwxIcFag(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void eITbiRqIzcvtzyMtnrVQwwxIcFag(Vector2 P_0, PositionType P_1, bool P_2, float P_3, INaLVlEEKkYnjkKyaWcjcCQYeri P_4)
		{
			if (_isMoving && P_2 && _moveDirection == P_4)
			{
				return;
			}
			if (_isMoving && _coroutineMove != null)
			{
				ewnocjnbCdATpbuVDhgTcBsizpjGb();
				_isMoving = false;
				_moveDirection = INaLVlEEKkYnjkKyaWcjcCQYeri.None;
			}
			if (base.oJQqczDhICKLxrvFLqPtRJoISnkJ == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.oJQqczDhICKLxrvFLqPtRJoISnkJ.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.boAaJrcsmiHhkYkFXRgeFHFbAFmGb;
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
				_coroutineMove = eYHLOFQxNaFhuZFTErUMQxBGBpL(P_0, P_1, P_3, P_4);
				StartCoroutine(_coroutineMove);
				_moveDirection = P_4;
				_isMovedFromDefaultPosition = true;
				hyflsGakWYPyLOtmggGdIrukDZdP(P_4);
			}
			else
			{
				hyflsGakWYPyLOtmggGdIrukDZdP(P_4);
				WQXJGuUNcDBFtdyHEvIDGCascPox(P_4, P_0, P_1);
			}
		}

		private IEnumerator eYHLOFQxNaFhuZFTErUMQxBGBpL(Vector2 P_0, PositionType P_1, float P_2, INaLVlEEKkYnjkKyaWcjcCQYeri P_3)
		{
			return new UkIZWvhoPLqrejoibIGZkIrziHAc(0)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				GPrcxxCgPFJPNaVyAUBmpuVaCrKbd = P_0,
				AUMAgZZLBrHzLgTUYOnkEcEkkkfGc = P_1,
				RTHUUqokIzIENeGXftdmzIzrqZYk = P_2,
				vJROrazzqkuFowhstzcKQBkiBOn = P_3
			};
		}

		private void WQXJGuUNcDBFtdyHEvIDGCascPox(INaLVlEEKkYnjkKyaWcjcCQYeri P_0, Vector2 P_1, PositionType P_2)
		{
			rAPtcpHLzzLbzFhqkNsLlgjZFneJA.ggeBfXdXMzUKfWJqSCynZUgDwusiA(base.uBgsATlVNpCXLTZUrAUVBouJZPML, P_1, P_2);
			_isMoving = false;
			_moveDirection = INaLVlEEKkYnjkKyaWcjcCQYeri.None;
			switch (P_0)
			{
			case INaLVlEEKkYnjkKyaWcjcCQYeri.TowardHome:
				_isMovedFromDefaultPosition = false;
				break;
			case INaLVlEEKkYnjkKyaWcjcCQYeri.TowardTouch:
				_isMovedFromDefaultPosition = true;
				break;
			}
			ewnocjnbCdATpbuVDhgTcBsizpjGb();
			uyVPZaTPIjGJKKabCgQTRIXqAPLc(P_0);
		}

		private void KlzDqOhWDaEscpTwtInUZXFgetYgb(INaLVlEEKkYnjkKyaWcjcCQYeri P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == INaLVlEEKkYnjkKyaWcjcCQYeri.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					_imageRaycastHelper.nmwDzgxVACcOAJkYbADwUYDbZzFK(base.transform, flag2);
				}
			}
		}

		private void TfMWssqBnrIKOIMGruTtpLqJkuDH(INaLVlEEKkYnjkKyaWcjcCQYeri P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == INaLVlEEKkYnjkKyaWcjcCQYeri.TowardHome)
				{
					flag = true;
					flag2 = PGRwgyyCEWmVXLbfYWHiHTHXKcgx();
				}
				if (flag)
				{
					_imageRaycastHelper.nmwDzgxVACcOAJkYbADwUYDbZzFK(base.transform, flag2);
				}
			}
		}

		private void ewnocjnbCdATpbuVDhgTcBsizpjGb()
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

		private void BnHDOLKbUanuKgdtijCJfcEoDAFlA(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(P_0))
			{
				eITbiRqIzcvtzyMtnrVQwwxIcFag((Vector2)rAPtcpHLzzLbzFhqkNsLlgjZFneJA.jqVCRSYgYAAfCassUTnRPsBnBSBcA(base.uBgsATlVNpCXLTZUrAUVBouJZPML, P_2) + P_1, P_2, false, 0f, INaLVlEEKkYnjkKyaWcjcCQYeri.TowardTouch);
				if (_lastClaimSource == JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion)
				{
					_lastPressAnchoredPosition += P_1;
				}
			}
		}

		private void egDhVENqiOmptpvGuCmdKvgAwDfc()
		{
			if (!hasPointer)
			{
				return;
			}
			if (!TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(QZxLXilNaypGgRZBuiQoBHottyGi))
			{
				PointerEventData pointerEventData = KSrSTOGNRhDrOLwekzgdtyflCwNh(QZxLXilNaypGgRZBuiQoBHottyGi);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					OsoYfSPmIvHIXGTEXudqHnglgstr(pointerEventData);
				}
				else
				{
					VDahXJPMYKnASeYtoJZirWDQPxW();
				}
			}
			else if (_pointerDownIsFake)
			{
				PointerEventData pointerEventData2 = oBkawAiVTdObEHyMDFoQDrdRAZpvA(QZxLXilNaypGgRZBuiQoBHottyGi, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
				if (pointerEventData2 != null)
				{
					TVygNHETfhPqszujRArTXpvRlvpq(pointerEventData2, _lastClaimSource);
				}
			}
		}

		private void tZIZiJgAAQoalmOpfhkiyBVatjyA()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.OGvcMITMMMbQQEcIOflTxFfwaCjh(QZxLXilNaypGgRZBuiQoBHottyGi);
				ZimENQhoONdnkMiATgBvHaarzNpaA(ref vector);
			}
		}

		private void ZimENQhoONdnkMiATgBvHaarzNpaA(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private bool CZCTQSVOBilzIhcUcSFoCffNCgIT()
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

		private void ykJYYTWDBrPpTaxVtKiVzeDkBkrt()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local;
		}

		private bool ZUErojFQVybWFckzvOUChmdZdZUuA(int P_0)
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
			if (TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
		}

		private PointerEventData tmSHozvxCeyplYJTdurtEufONlsc(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = KSrSTOGNRhDrOLwekzgdtyflCwNh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.OGvcMITMMMbQQEcIOflTxFfwaCjh(P_0);
			if (TouchInteractable.cENzhlYGCELsWXyTiPnZgeuYMRhH(P_0))
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
				if (!TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0))
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

		private PointerEventData oBkawAiVTdObEHyMDFoQDrdRAZpvA(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = KSrSTOGNRhDrOLwekzgdtyflCwNh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.OGvcMITMMMbQQEcIOflTxFfwaCjh(P_0);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = P_1;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		private PointerEventData sxUWcYUfULZPIUeyiMZFYFflpeYn(int P_0)
		{
			PointerEventData pointerEventData = KSrSTOGNRhDrOLwekzgdtyflCwNh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.cENzhlYGCELsWXyTiPnZgeuYMRhH(P_0))
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
				if (!TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0))
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

		private void OsoYfSPmIvHIXGTEXudqHnglgstr(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				sxUWcYUfULZPIUeyiMZFYFflpeYn(QZxLXilNaypGgRZBuiQoBHottyGi);
			}
		}

		private void TVygNHETfhPqszujRArTXpvRlvpq(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if (P_0 != null)
			{
				switch (P_1)
				{
				case JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local:
					OnDrag(P_0);
					break;
				case JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion:
					vjSkIKYzzYorlBwUUeSyguFmTJeV(P_0);
					break;
				default:
					throw new NotImplementedException();
				}
				sxUWcYUfULZPIUeyiMZFYFflpeYn(QZxLXilNaypGgRZBuiQoBHottyGi);
			}
		}

		private PointerEventData KSrSTOGNRhDrOLwekzgdtyflCwNh(int P_0)
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
				if (TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0))
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

		private void DFIDrBdFGXaeOuMhQIQKCqkLMkPfA()
		{
			LoesNjgEUrYfdvEfknfJNxZeoYen(_axesToUse);
			if (lQbkmKnTRMhMmINePIJrIZrbBwDnA && base.lgVibRICIXCvkyosxfYRxInxaGjBA.useCustomController)
			{
				if (_useXAxis)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ValidateElements(_horizontalAxisCustomControllerElement);
				}
				if (_useYAxis)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ValidateElements(_verticalAxisCustomControllerElement);
				}
				if (_allowTap)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ValidateElements(_tapCustomControllerElement);
				}
			}
		}

		private void LoesNjgEUrYfdvEfknfJNxZeoYen(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					int targetCount = _horizontalAxisCustomControllerElement.targetCount;
					for (int i = 0; i < targetCount; i++)
					{
						base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_horizontalAxisCustomControllerElement[i]);
					}
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					int targetCount2 = _verticalAxisCustomControllerElement.targetCount;
					for (int j = 0; j < targetCount2; j++)
					{
						base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_verticalAxisCustomControllerElement[j]);
					}
				}
			}
			_axesToUse = P_0;
		}

		private void xIWWjJOuupYMQcrdMBCGCHPaXBWI(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if (!hasPointer || ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				if (BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable())
				{
					IusOvBAtCSXEzhPnHLjnVptEdmr(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void IoGbCPRdLbcSdkogaRArqCgIugjmA(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if ((!hasPointer || ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId)) && !TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(QZxLXilNaypGgRZBuiQoBHottyGi))
			{
				VDahXJPMYKnASeYtoJZirWDQPxW();
				base.OnPointerUp(P_0);
			}
		}

		private void QcjNpGrRNqqqNCrPAtddavSMTuin(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if (hasPointer && !ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local => base.allowedMouseButtons, 
				JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && (!flag || TouchInteractable.KsjMbURloCOTuFHgwOLhnvhvdPJW(mouseButtonFlags)) && !HNeekbdvHcSGCkhkngTpwdUwueLRA)
			{
				if (flag)
				{
					if (TouchInteractable.IBzkqesnobxsqrtNNOtMshEFafzK(mouseButtonFlags, out var realMousePointerId))
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
					JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local => base.gameObject, 
					JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion => _workingTouchRegion.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = tmSHozvxCeyplYJTdurtEufONlsc((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					xIWWjJOuupYMQcrdMBCGCHPaXBWI(pointerEventData, P_1);
					if (HNeekbdvHcSGCkhkngTpwdUwueLRA)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			aMiVitsTbcaHUuBPegFBByVtJKdtA = true;
		}

		private void qbFkezCsiyAgtoKeAIvWYmFVHAOW(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if (hasPointer && !ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && HNeekbdvHcSGCkhkngTpwdUwueLRA)
			{
				VDahXJPMYKnASeYtoJZirWDQPxW();
			}
			base.OnPointerExit(P_0);
			aMiVitsTbcaHUuBPegFBByVtJKdtA = false;
		}

		private void hCxIEsOXCccCWDXSxomhaunnmOiM(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if (hasPointer && ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				base.OnBeginDrag(P_0);
			}
		}

		private void CkCSJVnUrjmbnlJpFGojYPMrtmYy(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if (!hasPointer || !ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				return;
			}
			RectTransform rectTransform = PERVNvTritjAxOJkevDzqabLFppY;
			Vector2 vector = ((!_snapStickToTouch) ? _lastPressAnchoredPosition : rAPtcpHLzzLbzFhqkNsLlgjZFneJA.HfoaKLiZpGjRvpJyQJUBfvfkUnsd(base.uBgsATlVNpCXLTZUrAUVBouJZPML, rectTransform, base.uBgsATlVNpCXLTZUrAUVBouJZPML.rect.center));
			if (!_centerStickOnRelease && !_snapStickToTouch)
			{
				vector -= _lastPressStartingValue * PRZyCPNeNSAVBodpDSRtCbkaIvbB;
			}
			Vector2 vector2 = rAPtcpHLzzLbzFhqkNsLlgjZFneJA.aVeQeJyQMkcxEOFWMrKPqFXiQgnw(base.oJQqczDhICKLxrvFLqPtRJoISnkJ, rectTransform, P_0.position);
			Vector2 vector3 = new Vector2(_useXAxis ? (vector2.x - vector.x) : 0f, _useYAxis ? (vector2.y - vector.y) : 0f);
			Vector2 vector4;
			if (_stickBounds == StickBounds.Circle)
			{
				vector4 = Vector2.ClampMagnitude(vector3, PRZyCPNeNSAVBodpDSRtCbkaIvbB);
			}
			else
			{
				if (_stickBounds != StickBounds.Square)
				{
					throw new NotImplementedException();
				}
				vector4 = MathTools.Clamp(vector3, 0f - PRZyCPNeNSAVBodpDSRtCbkaIvbB, PRZyCPNeNSAVBodpDSRtCbkaIvbB);
			}
			Vector2 rawValue = vector4 / PRZyCPNeNSAVBodpDSRtCbkaIvbB;
			SetRawValue(rawValue);
			if (_followTouchPosition)
			{
				if (_stickBounds == StickBounds.Circle)
				{
					if (vector3.sqrMagnitude > PRZyCPNeNSAVBodpDSRtCbkaIvbB)
					{
						Vector2 vector5 = new Vector2(_useXAxis ? (vector3.x - vector4.x) : 0f, _useXAxis ? (vector3.y - vector4.y) : 0f);
						BnHDOLKbUanuKgdtijCJfcEoDAFlA(QZxLXilNaypGgRZBuiQoBHottyGi, vector5, PositionType.Anchored);
					}
				}
				else
				{
					if (_stickBounds != StickBounds.Square)
					{
						throw new NotImplementedException();
					}
					bool flag = Mathf.Abs(vector3.x) > PRZyCPNeNSAVBodpDSRtCbkaIvbB;
					bool flag2 = Mathf.Abs(vector3.y) > PRZyCPNeNSAVBodpDSRtCbkaIvbB;
					if (flag || flag2)
					{
						Vector2 vector6 = new Vector2((_useXAxis && flag) ? (vector3.x - vector4.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector4.y) : 0f);
						BnHDOLKbUanuKgdtijCJfcEoDAFlA(QZxLXilNaypGgRZBuiQoBHottyGi, vector6, PositionType.Anchored);
					}
				}
			}
			base.OnDrag(P_0);
		}

		private void GNYxHVvkJhjJTauMtPJSZthFgQgY(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
			if (hasPointer && ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				base.OnEndDrag(P_0);
			}
		}

		private void IusOvBAtCSXEzhPnHLjnVptEdmr(int P_0, Vector2 P_1, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_2)
		{
			_pointerId = P_0;
			_lastClaimSource = P_2;
			_isEligibleForTap = true;
			_lastPressAnchoredPosition = rAPtcpHLzzLbzFhqkNsLlgjZFneJA.aVeQeJyQMkcxEOFWMrKPqFXiQgnw(base.oJQqczDhICKLxrvFLqPtRJoISnkJ, PERVNvTritjAxOJkevDzqabLFppY, P_1);
			HNeekbdvHcSGCkhkngTpwdUwueLRA = true;
			_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
			_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
			_touchStartTime = Time.realtimeSinceStartup;
			_touchStartPosition = P_1;
			if (P_2 == JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion && (_moveToTouchPosition || _followTouchPosition))
			{
				if (_followTouchPosition)
				{
					yXvFCwguRvPGWzUcsYLKERTdoKRZA(P_1, false, 0f, INaLVlEEKkYnjkKyaWcjcCQYeri.TowardTouch);
				}
				else
				{
					yXvFCwguRvPGWzUcsYLKERTdoKRZA(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, INaLVlEEKkYnjkKyaWcjcCQYeri.TowardTouch);
				}
			}
			if (_onTouchStarted != null)
			{
				_onTouchStarted.Invoke();
			}
			PointerEventData pointerEventData = oBkawAiVTdObEHyMDFoQDrdRAZpvA(_pointerId, (P_2 == JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
			if (pointerEventData != null)
			{
				TVygNHETfhPqszujRArTXpvRlvpq(pointerEventData, P_2);
			}
		}

		private void VDahXJPMYKnASeYtoJZirWDQPxW()
		{
			ykJYYTWDBrPpTaxVtKiVzeDkBkrt();
			bool num = _allowTap && _isEligibleForTap;
			HNeekbdvHcSGCkhkngTpwdUwueLRA = false;
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

		internal void XfcNrzdiSTbjskEuHcqpZhemQemOA(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				IoGbCPRdLbcSdkogaRArqCgIugjmA(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local);
			}
		}

		internal void iDcPScFqPAKcaOrORDGUfYntQieUA(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				xIWWjJOuupYMQcrdMBCGCHPaXBWI(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local);
			}
		}

		internal void sqfXmEerQmdFDqvKtyJYjfmOGrxp(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				QcjNpGrRNqqqNCrPAtddavSMTuin(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local);
			}
		}

		internal void ZCZXbSDZYKzibqAMtttvAiafEgZk(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				qbFkezCsiyAgtoKeAIvWYmFVHAOW(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local);
			}
		}

		internal void RcbhndaZEkdEPcJJNBuSGFCuzoxNA(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				hCxIEsOXCccCWDXSxomhaunnmOiM(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local);
			}
		}

		internal void ObMYqftcBzDHXCgICDCdelbgNFbQb(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				CkCSJVnUrjmbnlJpFGojYPMrtmYy(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local);
			}
		}

		internal void WGcUhoCpzgJyRkoXPxXcmJJxMyKG(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				GNYxHVvkJhjJTauMtPJSZthFgQgY(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.Local);
			}
		}

		private void mYtlVUwcgRDqffxeyQNiuhceENseA(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				xIWWjJOuupYMQcrdMBCGCHPaXBWI(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion);
			}
		}

		private void LphWTZrpvYLSyEGXsYgatVgDoywK(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				IoGbCPRdLbcSdkogaRArqCgIugjmA(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion);
			}
		}

		private void TMvPCdsBYetiGshWuVrBWfehcrIfA(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				QcjNpGrRNqqqNCrPAtddavSMTuin(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion);
			}
		}

		private void KPebiOdQuvcDTjsxtodIOqscoheFb(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				qbFkezCsiyAgtoKeAIvWYmFVHAOW(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion);
			}
		}

		private void DioRXQKhVFSVUIyHkcQmUXTcypWb(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				hCxIEsOXCccCWDXSxomhaunnmOiM(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion);
			}
		}

		private void vjSkIKYzzYorlBwUUeSyguFmTJeV(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				CkCSJVnUrjmbnlJpFGojYPMrtmYy(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion);
			}
		}

		private void kiYAuTAdRDaAhYmNElDiyxdPqPHZ(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				GNYxHVvkJhjJTauMtPJSZthFgQgY(P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA.TouchRegion);
			}
		}

		private void lLFFKNPRhFapxntcuwlZTDsroWzC(Vector2 P_0)
		{
			VEkfkZWVOjyuYZKyQWGZuutzFXEI(null);
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
				RectTransform rectTransform = PERVNvTritjAxOJkevDzqabLFppY;
				Vector3 position = value * PRZyCPNeNSAVBodpDSRtCbkaIvbB;
				position += rectTransform.InverseTransformPoint(base.transform.position);
				Vector3 position2 = rectTransform.TransformPoint(position);
				Vector3 vector = _stickTransform.parent.InverseTransformPoint(position2);
				Vector2 anchoredPosition = rAPtcpHLzzLbzFhqkNsLlgjZFneJA.AAUVFSyQdNkItkWsBRUmdAoZIuzv(_stickTransform.parent as RectTransform, vector);
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
