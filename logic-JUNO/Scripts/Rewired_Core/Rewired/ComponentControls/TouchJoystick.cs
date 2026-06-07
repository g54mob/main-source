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

		private enum iwxmNNaxsZtFmjboqqcjeogitBve
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum hzTFCMqWmbSNeDLABjxKuAmGijOn
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
		private sealed class UqoaHgXlEXeWjCOAJZASdgHRxznhA
		{
			public static readonly UqoaHgXlEXeWjCOAJZASdgHRxznhA _003C_003E9 = new UqoaHgXlEXeWjCOAJZASdgHRxznhA();

			public static QpJRFmwRLCvgydNYJyjjhpGiILCeA.EventFunction<IValueChangedHandler, Vector2> _003C_003E9__277_0;

			public static QpJRFmwRLCvgydNYJyjjhpGiILCeA.EventFunction<IStickPositionChangedHandler, Vector2> _003C_003E9__280_0;

			internal void GCVHBzTNvDixlaNczmfgsgPybpRU(IValueChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnValueChanged(P_1);
			}

			internal void cPUYUAqNALaGzhbtYErqkxrLskGkA(IStickPositionChangedHandler P_0, Vector2 P_1)
			{
				P_0.OnStickPositionChanged(P_1);
			}
		}

		private sealed class uqGXeWkTkMjWPdPMjUmKxkUFFoTC : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int RlFBtsEDgMJaaAmXMAOxwBJzxNDp;

			private object RhZGMOfXCFRACMIqkFzpMtRvYDFD;

			public float eFOJnSYahvyprLRIgmgfiRvEjlqQ;

			public TouchJoystick GKxSwYmZyriMArpDKGROepGFLFoL;

			public PositionType NbRyyQHuOPixsvhImIMRlfNPHOq;

			public Vector2 jrJMxjpHpTBqAditXHQztxwHhrcl;

			public iwxmNNaxsZtFmjboqqcjeogitBve tkfgojlmkRUpgDargFwJvqvlTOyP;

			private RectTransform RIsIPBTKzXzZpomLniprjmOUNbAE;

			private Vector2 ESTiCtCpARcyFupjZwTewmaxqQbY;

			private float aDfUEjkoiUEewJFWTnqLeUEHvZrCc;

			private float eDumJTyXdXOKZvotkRApNkkvNvUJ;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return RhZGMOfXCFRACMIqkFzpMtRvYDFD;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RhZGMOfXCFRACMIqkFzpMtRvYDFD;
				}
			}

			[DebuggerHidden]
			public uqGXeWkTkMjWPdPMjUmKxkUFFoTC(int P_0)
			{
				RlFBtsEDgMJaaAmXMAOxwBJzxNDp = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int rlFBtsEDgMJaaAmXMAOxwBJzxNDp = RlFBtsEDgMJaaAmXMAOxwBJzxNDp;
				TouchJoystick gKxSwYmZyriMArpDKGROepGFLFoL = GKxSwYmZyriMArpDKGROepGFLFoL;
				if (rlFBtsEDgMJaaAmXMAOxwBJzxNDp != 0)
				{
					if (rlFBtsEDgMJaaAmXMAOxwBJzxNDp != 1)
					{
						return false;
					}
					RlFBtsEDgMJaaAmXMAOxwBJzxNDp = -1;
					goto IL_010c;
				}
				RlFBtsEDgMJaaAmXMAOxwBJzxNDp = -1;
				if (!(eFOJnSYahvyprLRIgmgfiRvEjlqQ <= 0f))
				{
					RIsIPBTKzXzZpomLniprjmOUNbAE = gKxSwYmZyriMArpDKGROepGFLFoL.SeqvEgllFcYfioUgpBOnFeaUImqGA;
					ESTiCtCpARcyFupjZwTewmaxqQbY = LJvpobKSAwEwVFnZeCsPkLPxxOwo.KRLNtmRUhUuqiISMSeEuqNoiEgit(RIsIPBTKzXzZpomLniprjmOUNbAE, NbRyyQHuOPixsvhImIMRlfNPHOq);
					float magnitude = (jrJMxjpHpTBqAditXHQztxwHhrcl - ESTiCtCpARcyFupjZwTewmaxqQbY).magnitude;
					if (!(magnitude < 0.01f))
					{
						gKxSwYmZyriMArpDKGROepGFLFoL._isMoving = true;
						aDfUEjkoiUEewJFWTnqLeUEHvZrCc = magnitude / eFOJnSYahvyprLRIgmgfiRvEjlqQ;
						eDumJTyXdXOKZvotkRApNkkvNvUJ = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				gKxSwYmZyriMArpDKGROepGFLFoL.XPDEajEOHulpltsUAmMAuHHSlGZwA(tkfgojlmkRUpgDargFwJvqvlTOyP, jrJMxjpHpTBqAditXHQztxwHhrcl, NbRyyQHuOPixsvhImIMRlfNPHOq);
				return false;
				IL_010c:
				if (eDumJTyXdXOKZvotkRApNkkvNvUJ <= 1f)
				{
					eDumJTyXdXOKZvotkRApNkkvNvUJ += Time.unscaledDeltaTime / aDfUEjkoiUEewJFWTnqLeUEHvZrCc;
					LJvpobKSAwEwVFnZeCsPkLPxxOwo.BOaYZWscbxOwRlciicbcqDWEfYAx(RIsIPBTKzXzZpomLniprjmOUNbAE, Vector2.Lerp(ESTiCtCpARcyFupjZwTewmaxqQbY, jrJMxjpHpTBqAditXHQztxwHhrcl, Mathf.SmoothStep(0f, 1f, eDumJTyXdXOKZvotkRApNkkvNvUJ)), NbRyyQHuOPixsvhImIMRlfNPHOq);
					RhZGMOfXCFRACMIqkFzpMtRvYDFD = null;
					RlFBtsEDgMJaaAmXMAOxwBJzxNDp = 1;
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

		private QpJRFmwRLCvgydNYJyjjhpGiILCeA.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private QpJRFmwRLCvgydNYJyjjhpGiILCeA.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private iwxmNNaxsZtFmjboqqcjeogitBve _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool KGTaGPVExcfZIaELtiAuXulRnJGHb;

		[NonSerialized]
		private bool atfZsWroGBugEOiWgsJtrNrKvzKU;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private hzTFCMqWmbSNeDLABjxKuAmGijOn _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private HzVIQCREYHZKnIVBMAJjqUnIsmmT _imageRaycastHelper = new HzVIQCREYHZKnIVBMAJjqUnIsmmT();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<iwxmNNaxsZtFmjboqqcjeogitBve> __moveStartedDelegate;

		private Action<iwxmNNaxsZtFmjboqqcjeogitBve> __moveEndedDelegate;

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

		private static QpJRFmwRLCvgydNYJyjjhpGiILCeA.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static QpJRFmwRLCvgydNYJyjjhpGiILCeA.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		private StickBounds nlLjxfiOOYIpulBVQacNUGtILQlQ
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					cqinhMAVPFEvPZhfSfVmjDjxaRkaA(value);
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (HBMfNtzrBpFIKwIyQmtuLNBoBsNeA())
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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
						iQCHrHvMnuxPtaaufcUUtWgWMqft();
					}
					else
					{
						_imageRaycastHelper.BPLLZVQfnDZCnQzmgiGmwLcmmkgm();
					}
					GsBcXKiqrkqzLgoLvZRKojGmaLbaA();
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

		private bool eUlevMpFKllYGZwoQmzizivKpzaI => _lastTapFrame == Time.frameCount;

		internal StandaloneAxis2D RIudYkFAHqMVGCHGnkcahRnmokiV => _axis2D;

		private Action<iwxmNNaxsZtFmjboqqcjeogitBve> jriDppjJVtDVQnXFVkHkTMMZdaSBA
		{
			get
			{
				if (__moveStartedDelegate == null)
				{
					return __moveStartedDelegate = dVxeskLaOMsnZMhIuGXmDDYcqfppA;
				}
				return __moveStartedDelegate;
			}
		}

		private Action<iwxmNNaxsZtFmjboqqcjeogitBve> yGJBQiGgQLrSAiraPKjIGoZhyfUVB
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = lHzxkAXJIKJIpBTjzNCjTidgwoor;
				}
				return __moveEndedDelegate;
			}
		}

		private int kxdFBBhbuyaJrmPSfRCOWbtKRyCjA
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

		private RectTransform rSagGkVwZXGTvZDuHEgeblxGpgfNA
		{
			get
			{
				if (_lastClaimSource != hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion)
				{
					return base.transform as RectTransform;
				}
				return base.transform.parent as RectTransform;
			}
		}

		private float XprFJKfIBSBhBEezChYRrluhGDulA
		{
			get
			{
				if (Time.frameCount == _calculatedStickRange_lastUpdatedFrame)
				{
					return __calculatedStickRange_cachedValue;
				}
				RectTransform rectTransform = base.vCJGjqsSTOYxIOmvZHZOSVVpifrv;
				RectTransform rectTransform2 = rSagGkVwZXGTvZDuHEgeblxGpgfNA;
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
					if (_lastClaimSource == hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion)
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

		internal static QpJRFmwRLCvgydNYJyjjhpGiILCeA.EventFunction<IValueChangedHandler, Vector2> qWctegLwpvHuFjFNTufmeweOTNwP
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					__valueChangedHandlerDelegate = UqoaHgXlEXeWjCOAJZASdgHRxznhA._003C_003E9.GCVHBzTNvDixlaNczmfgsgPybpRU;
				}
				return __valueChangedHandlerDelegate;
			}
		}

		internal static QpJRFmwRLCvgydNYJyjjhpGiILCeA.EventFunction<IStickPositionChangedHandler, Vector2> zEPiyacoCxKmUiiMHDAxGzAzGDVxA
		{
			get
			{
				if (__stickPositionChangedHandlerDelegate == null)
				{
					__stickPositionChangedHandlerDelegate = UqoaHgXlEXeWjCOAJZASdgHRxznhA._003C_003E9.cPUYUAqNALaGzhbtYErqkxrLskGkA;
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
			if (!base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.value;
		}

		public Vector2 GetRawValue()
		{
			if (!base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				return _axis2D.rawZero;
			}
			return _axis2D.rawValue;
		}

		public void SetRawValue(Vector2 value)
		{
			if (!base.yISpryJPgsMScBhfNPMzRXpbpssc)
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
			HaujxJZfZUYQwDHHnyhRMajzvHXc(base.SeqvEgllFcYfioUgpBOnFeaUImqGA.anchoredPosition);
		}

		private void HaujxJZfZUYQwDHHnyhRMajzvHXc(Vector2 P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				_origAnchoredPosition = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				PHmkAAjIegPSMdCCkZLqOVlZUcpK(_origAnchoredPosition, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, iwxmNNaxsZtFmjboqqcjeogitBve.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
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
				_origAnchoredPosition = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.anchoredPosition;
				if (_stickTransform != null)
				{
					_origStickAnchoredPosition = _stickTransform.anchoredPosition;
				}
				SetRawValue(RIudYkFAHqMVGCHGnkcahRnmokiV.rawZero);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				GtpWSatTQvQqRawdbNnKVYqySNas();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				_axis2D.Deinitialize();
				prOtrdqYwZXkFcvprrpMujpofLsg();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				QMjyAWpCzybjdJWNPUtBJFNnRbzQ();
				GtpWSatTQvQqRawdbNnKVYqySNas();
			}
		}

		internal void UODasyuUmOBezNllMXBxyeDGMYOR()
		{
			base.XadwAoSmPfgqpkILfIkgfANXfddcb();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				FffZHimOfoZQczCmJZQVjlpjCRyn();
				WBiQHHkbXcFfmbljeNBMMvoxadFrA();
				lRZuDQivSvjbZLkfUBtIIpUDffEi();
			}
		}

		internal bool TKRDUZgrfvaZuQlyofKsGODDUnyUb()
		{
			if (!iedDOxkjfTrhublJdsoBBYzPiizQA())
			{
				return false;
			}
			QMjyAWpCzybjdJWNPUtBJFNnRbzQ();
			_axis2D.Initialize();
			return true;
		}

		internal void tlmctRNnXgGeFRCUaHEqBgZoAtXL()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && fWzcsqpjMiHugIFEsnxLnuyMnmGF)
			{
				Vector2 value = _axis2D.value;
				if (_useXAxis)
				{
					BBGcGGKBcUWfsejCFzcKGieWiGAc(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					BBGcGGKBcUWfsejCFzcKGieWiGAc(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					rlvXCcQLgbaIWkqoMoWXBPgIbtqRB(_tapCustomControllerElement, eUlevMpFKllYGZwoQmzizivKpzaI);
				}
			}
		}

		internal void fDioBOEYQghRsRCKoQWUKmEseVTD()
		{
			VoyGgLGiGTrtcFKALFAAsPOudnYcb();
			_axis2D.ValueChangedEvent += zjDtszxPaKOiADZJCnIHTHbhCukZ;
		}

		internal void tBwDOxWgxAzekdWBTxOoFPZwzzdD()
		{
			mKKrHnZUpVCHPdRTGsFNRlarfpEJ();
			_axis2D.ValueChangedEvent -= zjDtszxPaKOiADZJCnIHTHbhCukZ;
		}

		internal void ToNlVPEPAGtGznVTeBPZXlQNBcew()
		{
			MXkwbfQjWFfLiAPyzgGSCyXlFhQW();
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				QMjyAWpCzybjdJWNPUtBJFNnRbzQ();
				GtpWSatTQvQqRawdbNnKVYqySNas();
			}
		}

		internal void HHpgfxIVtYpJaRlQgUenWhobPFPCb()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				KGTaGPVExcfZIaELtiAuXulRnJGHb = false;
				atfZsWroGBugEOiWgsJtrNrKvzKU = false;
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
				_moveDirection = iwxmNNaxsZtFmjboqqcjeogitBve.None;
				zwnCDwUCxzQvdNwaalaMggbYGoqy();
				_axis2D.Clear();
				GtpWSatTQvQqRawdbNnKVYqySNas();
			}
		}

		internal void tYqIPzHGCbdmlaicVuOSCmhZuQJi()
		{
			VtgqxjDyMIHFNHvBgBmunIksXrlp();
			if (_hierarchyValueChangedHandlers == null)
			{
				_hierarchyValueChangedHandlers = new QpJRFmwRLCvgydNYJyjjhpGiILCeA.HierarchyEventHelper<IValueChangedHandler, Vector2>(qWctegLwpvHuFjFNTufmeweOTNwP);
			}
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			if (_hierarchyStickPositionChangedHandlers == null)
			{
				_hierarchyStickPositionChangedHandlers = new QpJRFmwRLCvgydNYJyjjhpGiILCeA.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(zEPiyacoCxKmUiiMHDAxGzAzGDVxA);
			}
			_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
		}

		public override void ClearValue()
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				if (fWzcsqpjMiHugIFEsnxLnuyMnmGF)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_verticalAxisCustomControllerElement);
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		internal bool suQDqeTtbCaycuxGvYRNjJSKnvqM()
		{
			if (!base.yISpryJPgsMScBhfNPMzRXpbpssc)
			{
				return false;
			}
			if (!PBRHZQINZfANWEOTugUlepRFdGfJ())
			{
				return false;
			}
			return KGTaGPVExcfZIaELtiAuXulRnJGHb;
		}

		internal bool LxclvFsAiCkwHCBPcIuUHGVtWFTOA(GameObject P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (base.plvFFPdzUNOHagtCgfoabMDAVjXWB(P_0))
			{
				return true;
			}
			if (_workingTouchRegion != null)
			{
				return _workingTouchRegion.gameObject == P_0;
			}
			return false;
		}

		private void GtpWSatTQvQqRawdbNnKVYqySNas()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			lRZuDQivSvjbZLkfUBtIIpUDffEi();
			iQCHrHvMnuxPtaaufcUUtWgWMqft();
		}

		private void iQCHrHvMnuxPtaaufcUUtWgWMqft()
		{
			if (_manageRaycasting)
			{
				_imageRaycastHelper.mCVECeXIEnTqWyaJNBwKcguewsyPA(base.transform, WRtfdkYKSXKfmuogXAnDKiNgMVIB());
			}
		}

		private bool WRtfdkYKSXKfmuogXAnDKiNgMVIB()
		{
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void iXoDMhOJZuBLFfjniTSoCtbkhHjHA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				VWouJxidcwPdNbfxMseRMjKnTUYF(P_0);
				P_0.PointerDownEvent += eYPkKyRVfPKNxeOWkmDXTXZgroHn;
				P_0.PointerUpEvent += CydKjcXEhStomLzYwQBgABsZNmxN;
				P_0.PointerEnterEvent += QuEemjkFTAPJtnIfGTQUJyIvjKuo;
				P_0.PointerExitEvent += NJzsqegGrLRKhHrxsxfLlhcelIWk;
				P_0.BeginDragEvent += AcaMCguoazrWpytkoYDdqpYrCcpb;
				P_0.DragEvent += PssfGVQlPPmarPRrPPDCCEyiGaEFA;
				P_0.EndDragEvent += BDAUaGFbaIrfMPkbnxOfLFpOmEje;
			}
		}

		private void VWouJxidcwPdNbfxMseRMjKnTUYF(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= eYPkKyRVfPKNxeOWkmDXTXZgroHn;
				P_0.PointerUpEvent -= CydKjcXEhStomLzYwQBgABsZNmxN;
				P_0.PointerEnterEvent -= QuEemjkFTAPJtnIfGTQUJyIvjKuo;
				P_0.PointerExitEvent -= NJzsqegGrLRKhHrxsxfLlhcelIWk;
				P_0.BeginDragEvent -= AcaMCguoazrWpytkoYDdqpYrCcpb;
				P_0.DragEvent -= PssfGVQlPPmarPRrPPDCCEyiGaEFA;
				P_0.EndDragEvent -= BDAUaGFbaIrfMPkbnxOfLFpOmEje;
			}
		}

		private void lRZuDQivSvjbZLkfUBtIIpUDffEi()
		{
			if (!(_workingTouchRegion == _touchRegion))
			{
				VWouJxidcwPdNbfxMseRMjKnTUYF(_workingTouchRegion);
				_workingTouchRegion = _touchRegion;
				iXoDMhOJZuBLFfjniTSoCtbkhHjHA(_workingTouchRegion);
			}
		}

		private void sYdEKWhicKoYpMaadNAWAbCKMSkI(Vector2 P_0, bool P_1, float P_2, iwxmNNaxsZtFmjboqqcjeogitBve P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = LJvpobKSAwEwVFnZeCsPkLPxxOwo.NmUvLnIKPPRNPnVYBPVVdtFTLjNy(base.uupfWdcRYmQCktvgNQvwZsMtFvqy, rectTransform, P_0);
			Vector2 pivot = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.pivot;
			Vector2 sizeDelta = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.sizeDelta;
			Vector3 localScale = base.SeqvEgllFcYfioUgpBOnFeaUImqGA.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			PHmkAAjIegPSMdCCkZLqOVlZUcpK(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void PHmkAAjIegPSMdCCkZLqOVlZUcpK(Vector2 P_0, PositionType P_1, bool P_2, float P_3, iwxmNNaxsZtFmjboqqcjeogitBve P_4)
		{
			if (_isMoving && P_2 && _moveDirection == P_4)
			{
				return;
			}
			if (_isMoving && _coroutineMove != null)
			{
				zwnCDwUCxzQvdNwaalaMggbYGoqy();
				_isMoving = false;
				_moveDirection = iwxmNNaxsZtFmjboqqcjeogitBve.None;
			}
			if (base.uupfWdcRYmQCktvgNQvwZsMtFvqy == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.uupfWdcRYmQCktvgNQvwZsMtFvqy.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.vCJGjqsSTOYxIOmvZHZOSVVpifrv;
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
				_coroutineMove = JtSlFSSLWsHEyvKaMDuTKkjbiWAaA(P_0, P_1, P_3, P_4);
				StartCoroutine(_coroutineMove);
				_moveDirection = P_4;
				_isMovedFromDefaultPosition = true;
				jriDppjJVtDVQnXFVkHkTMMZdaSBA(P_4);
			}
			else
			{
				jriDppjJVtDVQnXFVkHkTMMZdaSBA(P_4);
				XPDEajEOHulpltsUAmMAuHHSlGZwA(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(uqGXeWkTkMjWPdPMjUmKxkUFFoTC))]
		private IEnumerator JtSlFSSLWsHEyvKaMDuTKkjbiWAaA(Vector2 P_0, PositionType P_1, float P_2, iwxmNNaxsZtFmjboqqcjeogitBve P_3)
		{
			return new uqGXeWkTkMjWPdPMjUmKxkUFFoTC(0)
			{
				GKxSwYmZyriMArpDKGROepGFLFoL = this,
				jrJMxjpHpTBqAditXHQztxwHhrcl = P_0,
				NbRyyQHuOPixsvhImIMRlfNPHOq = P_1,
				eFOJnSYahvyprLRIgmgfiRvEjlqQ = P_2,
				tkfgojlmkRUpgDargFwJvqvlTOyP = P_3
			};
		}

		private void XPDEajEOHulpltsUAmMAuHHSlGZwA(iwxmNNaxsZtFmjboqqcjeogitBve P_0, Vector2 P_1, PositionType P_2)
		{
			LJvpobKSAwEwVFnZeCsPkLPxxOwo.BOaYZWscbxOwRlciicbcqDWEfYAx(base.SeqvEgllFcYfioUgpBOnFeaUImqGA, P_1, P_2);
			_isMoving = false;
			_moveDirection = iwxmNNaxsZtFmjboqqcjeogitBve.None;
			switch (P_0)
			{
			case iwxmNNaxsZtFmjboqqcjeogitBve.TowardHome:
				_isMovedFromDefaultPosition = false;
				break;
			case iwxmNNaxsZtFmjboqqcjeogitBve.TowardTouch:
				_isMovedFromDefaultPosition = true;
				break;
			}
			zwnCDwUCxzQvdNwaalaMggbYGoqy();
			yGJBQiGgQLrSAiraPKjIGoZhyfUVB(P_0);
		}

		private void dVxeskLaOMsnZMhIuGXmDDYcqfppA(iwxmNNaxsZtFmjboqqcjeogitBve P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == iwxmNNaxsZtFmjboqqcjeogitBve.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					_imageRaycastHelper.mCVECeXIEnTqWyaJNBwKcguewsyPA(base.transform, flag2);
				}
			}
		}

		private void lHzxkAXJIKJIpBTjzNCjTidgwoor(iwxmNNaxsZtFmjboqqcjeogitBve P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && _workingTouchRegion != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == iwxmNNaxsZtFmjboqqcjeogitBve.TowardHome)
				{
					flag = true;
					flag2 = WRtfdkYKSXKfmuogXAnDKiNgMVIB();
				}
				if (flag)
				{
					_imageRaycastHelper.mCVECeXIEnTqWyaJNBwKcguewsyPA(base.transform, flag2);
				}
			}
		}

		private void zwnCDwUCxzQvdNwaalaMggbYGoqy()
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

		private void jrxewPuedadWAcFoUWmnFvSFMlqi(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (TouchInteractable.HSdHFEwTqLmljSAXMrqWISAaJUgd(P_0))
			{
				PHmkAAjIegPSMdCCkZLqOVlZUcpK((Vector2)LJvpobKSAwEwVFnZeCsPkLPxxOwo.KRLNtmRUhUuqiISMSeEuqNoiEgit(base.SeqvEgllFcYfioUgpBOnFeaUImqGA, P_2) + P_1, P_2, false, 0f, iwxmNNaxsZtFmjboqqcjeogitBve.TowardTouch);
				if (_lastClaimSource == hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion)
				{
					_lastPressAnchoredPosition += P_1;
				}
			}
		}

		private void WBiQHHkbXcFfmbljeNBMMvoxadFrA()
		{
			if (!hasPointer)
			{
				return;
			}
			if (!TouchInteractable.HSdHFEwTqLmljSAXMrqWISAaJUgd(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA))
			{
				PointerEventData pointerEventData = GHMRqzizkaJzEmPwiuYRJWikVQnV(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					aBPDFDTZDAQMvHAjOZdMusCNHTfJ(pointerEventData);
				}
				else
				{
					puIJzqRIfvYQuFwrUwGgdOzJfyCd();
				}
			}
			else if (_pointerDownIsFake)
			{
				PointerEventData pointerEventData2 = VUHBjYPXGuXvyJjRDaCBzMmeiauZ(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
				if (pointerEventData2 != null)
				{
					gmPBbAeuQnCfURnwYAjdAJdcbTzU(pointerEventData2, _lastClaimSource);
				}
			}
		}

		private void FffZHimOfoZQczCmJZQVjlpjCRyn()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.GRqXcYGMGEOcqtDjGIZnCAiUOlaGA(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA);
				rkQFBlsNfJfdIfYYHkOfTViEvmPV(ref vector);
			}
		}

		private void rkQFBlsNfJfdIfYYHkOfTViEvmPV(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private bool HBMfNtzrBpFIKwIyQmtuLNBoBsNeA()
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

		private void zzegeWbkqvDnWsfVRiAEEuQdAelK()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = hzTFCMqWmbSNeDLABjxKuAmGijOn.Local;
		}

		private bool cFtWnTnjTMflndaaTVyMPSCbxhchA(int P_0)
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
			if (TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
		}

		private PointerEventData CtyfclrLrbncwRVjHbndyJJWTrpu(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = GHMRqzizkaJzEmPwiuYRJWikVQnV(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.GRqXcYGMGEOcqtDjGIZnCAiUOlaGA(P_0);
			if (TouchInteractable.GIygVOeNjVaVjWDNqzboLLzUBflBA(P_0))
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
				if (!TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0))
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

		private PointerEventData VUHBjYPXGuXvyJjRDaCBzMmeiauZ(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = GHMRqzizkaJzEmPwiuYRJWikVQnV(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.GRqXcYGMGEOcqtDjGIZnCAiUOlaGA(P_0);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = P_1;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		private PointerEventData AfvFoFurIMDyMFTIJQofaaEyDOaG(int P_0)
		{
			PointerEventData pointerEventData = GHMRqzizkaJzEmPwiuYRJWikVQnV(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.GIygVOeNjVaVjWDNqzboLLzUBflBA(P_0))
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
				if (!TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0))
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

		private void aBPDFDTZDAQMvHAjOZdMusCNHTfJ(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				AfvFoFurIMDyMFTIJQofaaEyDOaG(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA);
			}
		}

		private void gmPBbAeuQnCfURnwYAjdAJdcbTzU(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if (P_0 != null)
			{
				switch (P_1)
				{
				case hzTFCMqWmbSNeDLABjxKuAmGijOn.Local:
					OnDrag(P_0);
					break;
				case hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion:
					PssfGVQlPPmarPRrPPDCCEyiGaEFA(P_0);
					break;
				default:
					throw new NotImplementedException();
				}
				AfvFoFurIMDyMFTIJQofaaEyDOaG(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA);
			}
		}

		private PointerEventData GHMRqzizkaJzEmPwiuYRJWikVQnV(int P_0)
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
				if (TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0))
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

		private void QMjyAWpCzybjdJWNPUtBJFNnRbzQ()
		{
			cqinhMAVPFEvPZhfSfVmjDjxaRkaA(_axesToUse);
			if (fWzcsqpjMiHugIFEsnxLnuyMnmGF && base.sXDUEouJAqCiibpvIluvhcZgetzN.useCustomController)
			{
				if (_useXAxis)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ValidateElements(_horizontalAxisCustomControllerElement);
				}
				if (_useYAxis)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ValidateElements(_verticalAxisCustomControllerElement);
				}
				if (_allowTap)
				{
					base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ValidateElements(_tapCustomControllerElement);
				}
			}
		}

		private void cqinhMAVPFEvPZhfSfVmjDjxaRkaA(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag && fWzcsqpjMiHugIFEsnxLnuyMnmGF)
				{
					int targetCount = _horizontalAxisCustomControllerElement.targetCount;
					for (int i = 0; i < targetCount; i++)
					{
						base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_horizontalAxisCustomControllerElement[i]);
					}
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && fWzcsqpjMiHugIFEsnxLnuyMnmGF)
				{
					int targetCount2 = _verticalAxisCustomControllerElement.targetCount;
					for (int j = 0; j < targetCount2; j++)
					{
						base.HAJXbtYsLsLeqHUzHNVDqcdyIGMdA.ClearElementValue(_verticalAxisCustomControllerElement[j]);
					}
				}
			}
			_axesToUse = P_0;
		}

		private void hRkfJVmroZWXSVBqSUcirvigCIIB(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if (!hasPointer || cFtWnTnjTMflndaaTVyMPSCbxhchA(P_0.pointerId))
			{
				if (PBRHZQINZfANWEOTugUlepRFdGfJ() && IsInteractable())
				{
					BBIhTiCDubLPSjfweVWwTtnbgNXXA(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void GRRfYsDvapBpNLPuBdeqkTJOJErlA(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if ((!hasPointer || cFtWnTnjTMflndaaTVyMPSCbxhchA(P_0.pointerId)) && !TouchInteractable.HSdHFEwTqLmljSAXMrqWISAaJUgd(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA))
			{
				puIJzqRIfvYQuFwrUwGgdOzJfyCd();
				base.OnPointerUp(P_0);
			}
		}

		private void xAUWQfpgSDmzTOJpYlLcXoJMdCWe(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if (hasPointer && !cFtWnTnjTMflndaaTVyMPSCbxhchA(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.vYPGbuTavXEIDJeeAuBdpuxoOPlc(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				hzTFCMqWmbSNeDLABjxKuAmGijOn.Local => base.allowedMouseButtons, 
				hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && PBRHZQINZfANWEOTugUlepRFdGfJ() && IsInteractable() && (!flag || TouchInteractable.tblDrhtvhdTFJgWkleujTILlbVxu(mouseButtonFlags)) && !KGTaGPVExcfZIaELtiAuXulRnJGHb)
			{
				if (flag)
				{
					if (TouchInteractable.ilvBBLoOJPAulAFbbfMMVlRblJpFb(mouseButtonFlags, out var realMousePointerId))
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
					hzTFCMqWmbSNeDLABjxKuAmGijOn.Local => base.gameObject, 
					hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion => _workingTouchRegion.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = CtyfclrLrbncwRVjHbndyJJWTrpu((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					hRkfJVmroZWXSVBqSUcirvigCIIB(pointerEventData, P_1);
					if (KGTaGPVExcfZIaELtiAuXulRnJGHb)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			atfZsWroGBugEOiWgsJtrNrKvzKU = true;
		}

		private void GhFbSLOrUWkXVXHSesBvfJDyuKfl(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if (hasPointer && !cFtWnTnjTMflndaaTVyMPSCbxhchA(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && KGTaGPVExcfZIaELtiAuXulRnJGHb)
			{
				puIJzqRIfvYQuFwrUwGgdOzJfyCd();
			}
			base.OnPointerExit(P_0);
			atfZsWroGBugEOiWgsJtrNrKvzKU = false;
		}

		private void VzxeFJfbMVJmfBEeUGwnlBVvgJgE(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if (hasPointer && cFtWnTnjTMflndaaTVyMPSCbxhchA(P_0.pointerId))
			{
				base.OnBeginDrag(P_0);
			}
		}

		private void dJcfCzkxxbzcPneLieLFdhDubkSGb(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if (!hasPointer || !cFtWnTnjTMflndaaTVyMPSCbxhchA(P_0.pointerId))
			{
				return;
			}
			RectTransform rectTransform = rSagGkVwZXGTvZDuHEgeblxGpgfNA;
			Vector2 vector = ((!_snapStickToTouch) ? _lastPressAnchoredPosition : LJvpobKSAwEwVFnZeCsPkLPxxOwo.MUupjJBdFiQlcNnbWTlrKQbBfluB(base.SeqvEgllFcYfioUgpBOnFeaUImqGA, rectTransform, base.SeqvEgllFcYfioUgpBOnFeaUImqGA.rect.center));
			if (!_centerStickOnRelease && !_snapStickToTouch)
			{
				vector -= _lastPressStartingValue * XprFJKfIBSBhBEezChYRrluhGDulA;
			}
			Vector2 vector2 = LJvpobKSAwEwVFnZeCsPkLPxxOwo.kwCBEAOfqaCHxAXZEFtrwRphVnsi(base.uupfWdcRYmQCktvgNQvwZsMtFvqy, rectTransform, P_0.position);
			Vector2 vector3 = new Vector2(_useXAxis ? (vector2.x - vector.x) : 0f, _useYAxis ? (vector2.y - vector.y) : 0f);
			Vector2 vector4;
			if (_stickBounds == StickBounds.Circle)
			{
				vector4 = Vector2.ClampMagnitude(vector3, XprFJKfIBSBhBEezChYRrluhGDulA);
			}
			else
			{
				if (_stickBounds != StickBounds.Square)
				{
					throw new NotImplementedException();
				}
				vector4 = MathTools.Clamp(vector3, 0f - XprFJKfIBSBhBEezChYRrluhGDulA, XprFJKfIBSBhBEezChYRrluhGDulA);
			}
			Vector2 rawValue = vector4 / XprFJKfIBSBhBEezChYRrluhGDulA;
			SetRawValue(rawValue);
			if (_followTouchPosition)
			{
				if (_stickBounds == StickBounds.Circle)
				{
					if (vector3.sqrMagnitude > XprFJKfIBSBhBEezChYRrluhGDulA)
					{
						Vector2 vector5 = new Vector2(_useXAxis ? (vector3.x - vector4.x) : 0f, _useXAxis ? (vector3.y - vector4.y) : 0f);
						jrxewPuedadWAcFoUWmnFvSFMlqi(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA, vector5, PositionType.Anchored);
					}
				}
				else
				{
					if (_stickBounds != StickBounds.Square)
					{
						throw new NotImplementedException();
					}
					bool flag = Mathf.Abs(vector3.x) > XprFJKfIBSBhBEezChYRrluhGDulA;
					bool flag2 = Mathf.Abs(vector3.y) > XprFJKfIBSBhBEezChYRrluhGDulA;
					if (flag || flag2)
					{
						Vector2 vector6 = new Vector2((_useXAxis && flag) ? (vector3.x - vector4.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector4.y) : 0f);
						jrxewPuedadWAcFoUWmnFvSFMlqi(kxdFBBhbuyaJrmPSfRCOWbtKRyCjA, vector6, PositionType.Anchored);
					}
				}
			}
			base.OnDrag(P_0);
		}

		private void dDYHliefnSsIIESBwVaBgFAKMVaf(PointerEventData P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn P_1)
		{
			if (hasPointer && cFtWnTnjTMflndaaTVyMPSCbxhchA(P_0.pointerId))
			{
				base.OnEndDrag(P_0);
			}
		}

		private void BBIhTiCDubLPSjfweVWwTtnbgNXXA(int P_0, Vector2 P_1, hzTFCMqWmbSNeDLABjxKuAmGijOn P_2)
		{
			_pointerId = P_0;
			_lastClaimSource = P_2;
			_isEligibleForTap = true;
			_lastPressAnchoredPosition = LJvpobKSAwEwVFnZeCsPkLPxxOwo.kwCBEAOfqaCHxAXZEFtrwRphVnsi(base.uupfWdcRYmQCktvgNQvwZsMtFvqy, rSagGkVwZXGTvZDuHEgeblxGpgfNA, P_1);
			KGTaGPVExcfZIaELtiAuXulRnJGHb = true;
			_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
			_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
			_touchStartTime = Time.realtimeSinceStartup;
			_touchStartPosition = P_1;
			if (P_2 == hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion && (_moveToTouchPosition || _followTouchPosition))
			{
				if (_followTouchPosition)
				{
					sYdEKWhicKoYpMaadNAWAbCKMSkI(P_1, false, 0f, iwxmNNaxsZtFmjboqqcjeogitBve.TowardTouch);
				}
				else
				{
					sYdEKWhicKoYpMaadNAWAbCKMSkI(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, iwxmNNaxsZtFmjboqqcjeogitBve.TowardTouch);
				}
			}
			if (_onTouchStarted != null)
			{
				_onTouchStarted.Invoke();
			}
			PointerEventData pointerEventData = VUHBjYPXGuXvyJjRDaCBzMmeiauZ(_pointerId, (P_2 == hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
			if (pointerEventData != null)
			{
				gmPBbAeuQnCfURnwYAjdAJdcbTzU(pointerEventData, P_2);
			}
		}

		private void puIJzqRIfvYQuFwrUwGgdOzJfyCd()
		{
			zzegeWbkqvDnWsfVRiAEEuQdAelK();
			bool num = _allowTap && _isEligibleForTap;
			KGTaGPVExcfZIaELtiAuXulRnJGHb = false;
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

		internal void cSgHBxhCPCuqXYKqMFrUakCoLExGA(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				GRRfYsDvapBpNLPuBdeqkTJOJErlA(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.Local);
			}
		}

		internal void XxGhLMXjiHBkwMudhGkiHbDFvTLLA(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				hRkfJVmroZWXSVBqSUcirvigCIIB(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.Local);
			}
		}

		internal void jaVmWeUqDbeIsuoekvyXYIRbzyO(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				xAUWQfpgSDmzTOJpYlLcXoJMdCWe(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.Local);
			}
		}

		internal void NrYcveMceWQuHQXMGMDgKWEzgAFP(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				GhFbSLOrUWkXVXHSesBvfJDyuKfl(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.Local);
			}
		}

		internal void PHFVexcjSuhvzIbyybauXeeneVME(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				VzxeFJfbMVJmfBEeUGwnlBVvgJgE(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.Local);
			}
		}

		internal void XXBByyhHkmABsDXRBlsYtEvfkKzSA(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				dJcfCzkxxbzcPneLieLFdhDubkSGb(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.Local);
			}
		}

		internal void PbZFZqLPZGjeAuuIEMITYNzUqdgw(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				dDYHliefnSsIIESBwVaBgFAKMVaf(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.Local);
			}
		}

		private void eYPkKyRVfPKNxeOWkmDXTXZgroHn(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				hRkfJVmroZWXSVBqSUcirvigCIIB(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion);
			}
		}

		private void CydKjcXEhStomLzYwQBgABsZNmxN(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				GRRfYsDvapBpNLPuBdeqkTJOJErlA(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion);
			}
		}

		private void QuEemjkFTAPJtnIfGTQUJyIvjKuo(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				xAUWQfpgSDmzTOJpYlLcXoJMdCWe(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion);
			}
		}

		private void NJzsqegGrLRKhHrxsxfLlhcelIWk(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				GhFbSLOrUWkXVXHSesBvfJDyuKfl(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion);
			}
		}

		private void AcaMCguoazrWpytkoYDdqpYrCcpb(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				VzxeFJfbMVJmfBEeUGwnlBVvgJgE(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion);
			}
		}

		private void PssfGVQlPPmarPRrPPDCCEyiGaEFA(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				dJcfCzkxxbzcPneLieLFdhDubkSGb(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion);
			}
		}

		private void BDAUaGFbaIrfMPkbnxOfLFpOmEje(PointerEventData P_0)
		{
			if (base.yISpryJPgsMScBhfNPMzRXpbpssc && TouchInteractable.JkDrilijeoDrZkYsJxQuUPBCKtDZ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				dDYHliefnSsIIESBwVaBgFAKMVaf(P_0, hzTFCMqWmbSNeDLABjxKuAmGijOn.TouchRegion);
			}
		}

		private void zjDtszxPaKOiADZJCnIHTHbhCukZ(Vector2 P_0)
		{
			mqqgsskRuzXjTAiWvEdJawWAQYEob(null);
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
				RectTransform rectTransform = rSagGkVwZXGTvZDuHEgeblxGpgfNA;
				Vector3 position = value * XprFJKfIBSBhBEezChYRrluhGDulA;
				position += rectTransform.InverseTransformPoint(base.transform.position);
				Vector3 position2 = rectTransform.TransformPoint(position);
				Vector3 vector = _stickTransform.parent.InverseTransformPoint(position2);
				Vector2 anchoredPosition = LJvpobKSAwEwVFnZeCsPkLPxxOwo.XseuDraOJmBUMSgkyjPmLFtsNGnT(_stickTransform.parent as RectTransform, vector);
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
