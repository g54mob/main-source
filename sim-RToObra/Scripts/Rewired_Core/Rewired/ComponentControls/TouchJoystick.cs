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

		private enum ynWUqBPMQTEMtlodYrfUADbwzmX
		{
			TCGihQKDgeeGtvEXifcuojmabzj = 0,
			euXYneYPthVhveBWhDzbgcsApkRZ = 1,
			HwWCoknLLuvDCNsHCSIjJkwLMtB = 2
		}

		private enum lfggsvJHPvryrXYDjukFAqXNbzH
		{
			UMtjEaOogDDwQiplOLpTuwxTdbQ = 0,
			qBvlHFfTVaijZsMuBaXfTPCbahL = 1
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

		private sealed class GPccVisIRkEiSIvwqqWgcRVCgcEK : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			public TouchJoystick iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public Vector2 ofwHDGItTMAnajZEczGfQJAfkWi;

			public PositionType cEFYMcdcTaIHyHTckcmnNJNVUTy;

			public float lJAziHQEMyViiggdNdulCrmGjoLg;

			public ynWUqBPMQTEMtlodYrfUADbwzmX DTQmUpQxxpEaloJNKuhapMsZmFf;

			public RectTransform EEhxgioMmCLVcxOOpFGjSbXrfkQi;

			public Vector2 ecOyPViWhRLxkGuISZHscbSLPLo;

			public float GVYfKmacGAMQXNVXNQtmRMGEGTJt;

			public float dFaobIhfzLbrmRUhdDCkenJrzll;

			public float NvwxJeVVWtwvfwcXXfnhTEIWsjQ;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = -202350986;
					goto IL_001f;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -202350978;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -202350988)
						{
						case 3:
							num = -202350980;
							continue;
						case 8:
							break;
						case 10:
							goto IL_0069;
						case 1:
							NvwxJeVVWtwvfwcXXfnhTEIWsjQ += Time.unscaledDeltaTime / dFaobIhfzLbrmRUhdDCkenJrzll;
							PPQNIOlPnyDtERyUKpTWMMgiKJj.AwbDNgzQKwyuEBeAcQzspJfsFFt(EEhxgioMmCLVcxOOpFGjSbXrfkQi, Vector2.Lerp(ecOyPViWhRLxkGuISZHscbSLPLo, ofwHDGItTMAnajZEczGfQJAfkWi, Mathf.SmoothStep(0f, 1f, NvwxJeVVWtwvfwcXXfnhTEIWsjQ)), cEFYMcdcTaIHyHTckcmnNJNVUTy);
							aimBzjfQfPyaeQqysAQJISCBhELB = null;
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							num = -202350992;
							continue;
						case 7:
							num = -202350978;
							continue;
						case 5:
							iKQXbXnVtIaMZEJNeigQJWAHqUx._isMoving = true;
							dFaobIhfzLbrmRUhdDCkenJrzll = GVYfKmacGAMQXNVXNQtmRMGEGTJt / lJAziHQEMyViiggdNdulCrmGjoLg;
							NvwxJeVVWtwvfwcXXfnhTEIWsjQ = 0f;
							num = -202350989;
							continue;
						case 0:
							goto IL_0132;
						case 2:
							if (!(lJAziHQEMyViiggdNdulCrmGjoLg <= 0f))
							{
								EEhxgioMmCLVcxOOpFGjSbXrfkQi = iKQXbXnVtIaMZEJNeigQJWAHqUx.rectTransform;
								ecOyPViWhRLxkGuISZHscbSLPLo = PPQNIOlPnyDtERyUKpTWMMgiKJj.BFYAtvgPUJNLjuOWcquIuXIEhUS(EEhxgioMmCLVcxOOpFGjSbXrfkQi, cEFYMcdcTaIHyHTckcmnNJNVUTy);
								num = -202350988;
								continue;
							}
							goto case 9;
						case 9:
							iKQXbXnVtIaMZEJNeigQJWAHqUx.yFIryXiFmAheSzYjuuUCpBvLoYn(DTQmUpQxxpEaloJNKuhapMsZmFf, ofwHDGItTMAnajZEczGfQJAfkWi, cEFYMcdcTaIHyHTckcmnNJNVUTy);
							num = -202350990;
							continue;
						case 4:
							return true;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0132:
						GVYfKmacGAMQXNVXNQtmRMGEGTJt = (ofwHDGItTMAnajZEczGfQJAfkWi - ecOyPViWhRLxkGuISZHscbSLPLo).magnitude;
						int num2;
						if (!(GVYfKmacGAMQXNVXNQtmRMGEGTJt < 0.01f))
						{
							num = -202350991;
							num2 = num;
						}
						else
						{
							num = -202350979;
							num2 = num;
						}
						continue;
						IL_0069:
						int num3;
						if (!(NvwxJeVVWtwvfwcXXfnhTEIWsjQ <= 1f))
						{
							num = -202350979;
							num3 = num;
						}
						else
						{
							num = -202350987;
							num3 = num;
						}
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
			public GPccVisIRkEiSIvwqqWgcRVCgcEK(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
			}
		}

		private const float MAX_MOVE_SPEED = 20f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[CustomObfuscation(rename = false)]
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
		[SerializeField]
		[Range(0f, 1f)]
		private float _digitalModeDeadZone = 0.3f;

		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Range(0.01f, 1000f)]
		private float _stickRange = 60f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		[SerializeField]
		private bool _scaleStickRange = true;

		[Tooltip("The shape of the range of movement of the joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StickBounds _stickBounds;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		private AxisDirection _axesToUse;

		[CustomObfuscation(rename = false)]
		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
		[SerializeField]
		private SnapDirections _snapDirections;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		[SerializeField]
		private bool _snapStickToTouch;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
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
		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[SerializeField]
		[Tooltip("Should taps on the touch pad be processed?")]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		[SerializeField]
		[FieldRange(0f, float.MaxValue)]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[CustomObfuscation(rename = false)]
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
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _returnOnRelease = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		private bool _followTouchPosition;

		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnMoveToTouch = true;

		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _moveToTouchSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		private bool _animateOnReturn = true;

		[SerializeField]
		[Range(0f, 20f)]
		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[CustomObfuscation(rename = false)]
		private float _returnSpeed = 2f;

		[SerializeField]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private bool _useXAxis;

		private bool _useYAxis;

		private GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private ynWUqBPMQTEMtlodYrfUADbwzmX _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool jYtFWKZUVrechfzATGCgCETBhJCg;

		[NonSerialized]
		private bool GXxxUMYvhnAdzwfrIpAYPjIWpue;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private lfggsvJHPvryrXYDjukFAqXNbzH _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private RXykqpoobZXbeYNAmfMakWSBJalU _imageRaycastHelper = new RXykqpoobZXbeYNAmfMakWSBJalU();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<ynWUqBPMQTEMtlodYrfUADbwzmX> __moveStartedDelegate;

		private Action<ynWUqBPMQTEMtlodYrfUADbwzmX> __moveEndedDelegate;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick value changes.")]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the joystick's stick position changes.")]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onStickPositionChanged = new ValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the joystick is touched.")]
		[CustomObfuscation(rename = false)]
		private TouchStartedEventHandler _onTouchStarted = new TouchStartedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchEndedEventHandler _onTouchEnded = new TouchEndedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		private TapEventHandler _onTap = new TapEventHandler();

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

		[CompilerGenerated]
		private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IValueChangedHandler, Vector2> CS_0024_003C_003E9__CachedAnonymousMethodDelegate8;

		[CompilerGenerated]
		private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IStickPositionChangedHandler, Vector2> CS_0024_003C_003E9__CachedAnonymousMethodDelegatea;

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
					while (true)
					{
						switch (0x7CECEFE9 ^ 0x7CECEFE8)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_stickTransform = value;
				OnSetProperty();
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
				if (_joystickMode == value)
				{
					return;
				}
				while (true)
				{
					_joystickMode = value;
					int num = -782143952;
					while (true)
					{
						switch (num ^ -782143950)
						{
						case 0:
							num = -782143951;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							OnSetProperty();
							num = -782143949;
							continue;
						case 1:
							return;
						}
						break;
					}
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
					OnSetProperty();
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
				if (_stickRange == value)
				{
					goto IL_001b;
				}
				goto IL_0056;
				IL_001b:
				int num = -93718919;
				goto IL_0020;
				IL_0020:
				while (true)
				{
					switch (num ^ -93718920)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						return;
					case 4:
						OnSetProperty();
						num = -93718917;
						continue;
					case 2:
						goto IL_0056;
					case 3:
						return;
					}
					break;
				}
				goto IL_001b;
				IL_0056:
				_stickRange = value;
				num = -93718916;
				goto IL_0020;
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
				if (_scaleStickRange == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -330978179;
				goto IL_000e;
				IL_000e:
				switch (num ^ -330978180)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0033;
				case 2:
					return;
				}
				goto IL_0009;
				IL_0033:
				_scaleStickRange = value;
				OnSetProperty();
				num = -330978178;
				goto IL_000e;
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
				if (_stickBounds == value)
				{
					return;
				}
				while (true)
				{
					_stickBounds = value;
					int num = 686427186;
					while (true)
					{
						switch (num ^ 0x28EA0C30)
						{
						case 0:
							num = 686427187;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							OnSetProperty();
							num = 686427185;
							continue;
						case 1:
							return;
						}
						break;
					}
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
						switch (-769933431 ^ -769933432)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				nyzmpEWTMknZYhaJEGiQjqKBXpbI(value);
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
				if (_snapDirections != value)
				{
					_snapDirections = value;
					OnSetProperty();
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
				if (_snapStickToTouch == value)
				{
					while (true)
					{
						switch (-2008734900 ^ -2008734899)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_snapStickToTouch = value;
				OnSetProperty();
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
				if (_centerStickOnRelease == value)
				{
					return;
				}
				while (true)
				{
					_centerStickOnRelease = value;
					int num = 136243253;
					while (true)
					{
						switch (num ^ 0x81EE837)
						{
						case 0:
							goto IL_000a;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = 136243254;
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
					int num = -1855978471;
					while (true)
					{
						switch (num ^ -1855978469)
						{
						case 3:
							num = -1855978470;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							OnSetProperty();
							num = -1855978469;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (eOHzHpzQRbBLjxcuQVfnfVkaPND())
				{
					return true;
				}
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
				int num = 2048220555;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x7A155D89)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				_stayActiveOnSwipeOut = value;
				OnSetProperty();
				num = 2048220553;
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
					int num = -652944413;
					while (true)
					{
						switch (num ^ -652944414)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = -652944416;
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
				while (true)
				{
					int num = -225565146;
					while (true)
					{
						switch (num ^ -225565148)
						{
						case 3:
							break;
						case 2:
							if (_tapTimeout != value)
							{
								goto IL_0040;
							}
							return;
						case 1:
							goto IL_0040;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_0040:
						_tapTimeout = value;
						num = -225565148;
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
				if (_tapDistanceLimit != value)
				{
					_tapDistanceLimit = value;
					OnSetProperty();
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
					OnSetProperty();
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
					return;
				}
				while (true)
				{
					_useTouchRegionOnly = value;
					OnSetProperty();
					int num = -1989165679;
					while (true)
					{
						switch (num ^ -1989165680)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = -1989165678;
					}
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
					return;
				}
				while (true)
				{
					_returnOnRelease = value;
					int num = 1586697018;
					while (true)
					{
						switch (num ^ 0x5E93133A)
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
						num = 1586697019;
					}
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
				if (_followTouchPosition == value)
				{
					goto IL_0009;
				}
				goto IL_0044;
				IL_0009:
				int num = 1683035659;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x6451160A)
					{
					case 4:
						break;
					default:
						return;
					case 1:
						return;
					case 2:
						OnSetProperty();
						num = 1683035658;
						continue;
					case 3:
						goto IL_0044;
					case 0:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0044:
				_followTouchPosition = value;
				num = 1683035656;
				goto IL_000e;
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
					int num = -560800470;
					while (true)
					{
						switch (num ^ -560800472)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = -560800471;
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
				if (_moveToTouchSpeed == value)
				{
					while (true)
					{
						switch (0x2E17D629 ^ 0x2E17D62B)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_moveToTouchSpeed = value;
				OnSetProperty();
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
				if (_animateOnReturn == value)
				{
					return;
				}
				while (true)
				{
					_animateOnReturn = value;
					int num = -745100438;
					while (true)
					{
						switch (num ^ -745100439)
						{
						case 2:
							num = -745100440;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							OnSetProperty();
							num = -745100439;
							continue;
						case 0:
							return;
						}
						break;
					}
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
				while (true)
				{
					switch (-1489844277 ^ -1489844278)
					{
					case 2:
						continue;
					case 1:
						if (_returnSpeed == value)
						{
							return;
						}
						break;
					}
					break;
				}
				_returnSpeed = value;
				OnSetProperty();
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
					if (value)
					{
						num = -1679863135;
						num2 = num;
					}
					else
					{
						num = -1679863134;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1679863134)
						{
						case 2:
							num = -1679863133;
							continue;
						case 1:
							break;
						case 0:
							_imageRaycastHelper.nympziBLtYDUiPlWNRoEGqbSPfa();
							num = -1679863130;
							continue;
						case 3:
							BpIrxrTAZovcjjJKjdrhqiRYbUtH();
							num = -1679863130;
							continue;
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

		private Action<ynWUqBPMQTEMtlodYrfUADbwzmX> moveStartedDelegate
		{
			get
			{
				Action<ynWUqBPMQTEMtlodYrfUADbwzmX> result = default(Action<ynWUqBPMQTEMtlodYrfUADbwzmX>);
				if (__moveStartedDelegate == null)
				{
					while (true)
					{
						int num = 1737376896;
						while (true)
						{
							switch (num ^ 0x678E4481)
							{
							case 2:
								break;
							case 1:
								goto IL_0026;
							default:
								return result;
							}
							break;
							IL_0026:
							result = (__moveStartedDelegate = ebwjYhEqRdpMXwLKPVkBqUQNcEDa);
							num = 1737376897;
						}
					}
				}
				return __moveStartedDelegate;
			}
		}

		private Action<ynWUqBPMQTEMtlodYrfUADbwzmX> moveEndedDelegate
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = juHmsVQdOwsmtGcmTviVInzkJKk;
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
				if (_lastClaimSource != lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL)
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
				Vector3 lossyScale = default(Vector3);
				Vector3 lossyScale2 = default(Vector3);
				RectTransform rectTransform2 = default(RectTransform);
				float magnitude = default(float);
				Vector3 a = default(Vector3);
				Vector3 vector = default(Vector3);
				while (true)
				{
					int num = 1190222958;
					while (true)
					{
						switch (num ^ 0x46F15C6F)
						{
						case 4:
							break;
						case 3:
							if (_scaleStickRange)
							{
								lossyScale = rectTransform.lossyScale;
								lossyScale2 = rectTransform2.lossyScale;
								num = 1190222947;
								continue;
							}
							goto case 9;
						case 8:
							magnitude = Vector3.Scale(a, lossyScale2).magnitude;
							num = 1190222948;
							continue;
						case 11:
							num = 1190222949;
							continue;
						case 2:
							lossyScale2.y /= lossyScale.y;
							num = 1190222959;
							continue;
						case 6:
							if (_lastClaimSource == lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL)
							{
								lossyScale2.Scale(base.transform.localScale);
								num = 1190222951;
								continue;
							}
							goto case 8;
						case 9:
							magnitude = a.magnitude;
							num = 1190222949;
							continue;
						case 7:
						{
							int num3;
							if (lossyScale.y == 0f)
							{
								num = 1190222959;
								num3 = num;
							}
							else
							{
								num = 1190222957;
								num3 = num;
							}
							continue;
						}
						case 13:
							lossyScale2.x /= lossyScale.x;
							num = 1190222952;
							continue;
						case 5:
							a = rectTransform2.InverseTransformPoint(vector + rectTransform2.position);
							num = 1190222956;
							continue;
						case 0:
							if (lossyScale.z != 0f)
							{
								lossyScale2.z /= lossyScale.z;
								num = 1190222953;
								continue;
							}
							goto case 6;
						case 1:
						{
							rectTransform2 = touchReferenceTransform;
							Vector3 position = new Vector3(0f, _stickRange, 0f);
							vector = rectTransform.TransformPoint(position) - rectTransform.position;
							num = 1190222954;
							continue;
						}
						case 12:
						{
							int num2;
							if (lossyScale.x != 0f)
							{
								num = 1190222946;
								num2 = num;
							}
							else
							{
								num = 1190222952;
								num2 = num;
							}
							continue;
						}
						default:
							__calculatedStickRange_cachedValue = magnitude;
							_calculatedStickRange_lastUpdatedFrame = Time.frameCount;
							return magnitude;
						}
						break;
					}
				}
			}
		}

		internal static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IValueChangedHandler, Vector2> valueChangedHandlerDelegate
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					while (true)
					{
						int num = 547350104;
						while (true)
						{
							switch (num ^ 0x209FE659)
							{
							case 0:
								break;
							case 1:
								if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate8 == null)
								{
									CS_0024_003C_003E9__CachedAnonymousMethodDelegate8 = delegate(IValueChangedHandler P_0, Vector2 P_1)
									{
										P_0.OnValueChanged(P_1);
									};
									num = 547350107;
									continue;
								}
								goto case 2;
							case 2:
								__valueChangedHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate8;
								num = 547350106;
								continue;
							default:
								goto end_IL_0007;
							}
							break;
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				return __valueChangedHandlerDelegate;
			}
		}

		internal static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IStickPositionChangedHandler, Vector2> stickPositionChangedHandlerDelegate
		{
			get
			{
				if (__stickPositionChangedHandlerDelegate == null)
				{
					if (CS_0024_003C_003E9__CachedAnonymousMethodDelegatea == null)
					{
						CS_0024_003C_003E9__CachedAnonymousMethodDelegatea = delegate(IStickPositionChangedHandler P_0, Vector2 P_1)
						{
							P_0.OnStickPositionChanged(P_1);
						};
						goto IL_001f;
					}
					goto IL_003d;
				}
				goto IL_004e;
				IL_003d:
				__stickPositionChangedHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegatea;
				int num = 425500552;
				goto IL_0024;
				IL_004e:
				return __stickPositionChangedHandlerDelegate;
				IL_001f:
				num = 425500555;
				goto IL_0024;
				IL_0024:
				switch (num ^ 0x195C9F89)
				{
				case 0:
					break;
				case 2:
					goto IL_003d;
				default:
					goto IL_004e;
				}
				goto IL_001f;
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
				IL_00df:
				int num;
				if (_joystickMode == JoystickMode.Digital)
				{
					int num2;
					if (value.sqrMagnitude > _digitalModeDeadZone * _digitalModeDeadZone)
					{
						num = -1004204549;
						num2 = num;
					}
					else
					{
						num = -1004204553;
						num2 = num;
					}
					goto IL_0011;
				}
				goto IL_01af;
				IL_0287:
				int num3;
				if (MathTools.IsNear(value.y, -1f, 0.0001f))
				{
					num = -1004204560;
					num3 = num;
				}
				else
				{
					num = -1004204559;
					num3 = num;
				}
				goto IL_0011;
				IL_0115:
				int num4;
				if (MathTools.IsNear(value.x, -1f, 0.0001f))
				{
					num = -1004204545;
					num4 = num;
				}
				else
				{
					num = -1004204556;
					num4 = num;
				}
				goto IL_0011;
				IL_009e:
				_axis2D.SetRawValue(_useXAxis ? value.x : 0f, _useYAxis ? value.y : 0f);
				num = -1004204557;
				goto IL_0011;
				IL_01af:
				if (_snapDirections == SnapDirections.None)
				{
					goto IL_0188;
				}
				value = MathTools.SnapVectorToNearestAngle(value, 360f / (float)_snapDirections);
				if (value.x == 0f)
				{
					goto IL_0061;
				}
				if (MathTools.IsNearZero(value.x, 0.0001f))
				{
					value.x = 0f;
					num = -1004204556;
					goto IL_0011;
				}
				goto IL_0256;
				IL_0256:
				if (MathTools.IsNear(value.x, 1f, 0.0001f))
				{
					value.x = 1f;
					num = -1004204556;
					goto IL_0011;
				}
				goto IL_0115;
				IL_0061:
				if (value.y == 0f)
				{
					goto IL_0188;
				}
				if (MathTools.IsNearZero(value.y, 0.0001f))
				{
					value.y = 0f;
					num = -1004204552;
					goto IL_0011;
				}
				goto IL_0206;
				IL_0011:
				while (true)
				{
					switch (num ^ -1004204558)
					{
					case 14:
						num = -1004204551;
						continue;
					default:
						return;
					case 6:
						break;
					case 12:
						goto IL_009e;
					case 11:
						goto IL_00df;
					case 4:
						goto IL_0115;
					case 13:
						value.x = -1f;
						num = -1004204556;
						continue;
					case 2:
						value.y = -1f;
						num = -1004204559;
						continue;
					case 9:
						value.Normalize();
						num = -1004204550;
						continue;
					case 10:
						num = -1004204559;
						continue;
					case 3:
						goto IL_0188;
					case 8:
						goto IL_01af;
					case 7:
						goto IL_0206;
					case 5:
						value.x = 0f;
						value.y = 0f;
						num = -1004204550;
						continue;
					case 0:
						goto IL_0256;
					case 15:
						goto IL_0287;
					case 1:
						return;
					}
					break;
				}
				goto IL_0061;
				IL_0188:
				if (!_useXAxis)
				{
					int num5;
					if (!_useYAxis)
					{
						num = -1004204557;
						num5 = num;
					}
					else
					{
						num = -1004204546;
						num5 = num;
					}
					goto IL_0011;
				}
				goto IL_009e;
				IL_0206:
				if (MathTools.IsNear(value.y, 1f, 0.0001f))
				{
					value.y = 1f;
					num = -1004204559;
					goto IL_0011;
				}
				goto IL_0287;
			}
		}

		public void SetDefaultPosition()
		{
			xbYqhNfPiSuHkPeDMsDiMfQJiRv(base.rectTransform.anchoredPosition);
		}

		private void xbYqhNfPiSuHkPeDMsDiMfQJiRv(Vector2 P_0)
		{
			if (base.initialized)
			{
				_origAnchoredPosition = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1313588399;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1313588400)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0032;
			case 2:
				return;
			}
			goto IL_0008;
			IL_0032:
			KXGXneOjslBgCoFxDokJHtUpHCr(_origAnchoredPosition, PositionType.GGTSFVietfXEJqUNBOrLtjJMCol, !instant && _animateOnReturn, _returnSpeed, ynWUqBPMQTEMtlodYrfUADbwzmX.HwWCoknLLuvDCNsHCSIjJkwLMtB);
			num = -1313588398;
			goto IL_000d;
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
			while (true)
			{
				int num = 1911915990;
				while (true)
				{
					switch (num ^ 0x71F585D5)
					{
					case 0:
						break;
					case 1:
						_origStickAnchoredPosition = _stickTransform.anchoredPosition;
						num = 1911915991;
						continue;
					case 4:
					{
						_origAnchoredPosition = base.rectTransform.anchoredPosition;
						int num2;
						if (!(_stickTransform != null))
						{
							num = 1911915991;
							num2 = num;
						}
						else
						{
							num = 1911915988;
							num2 = num;
						}
						continue;
					}
					case 3:
						if (!Application.isPlaying)
						{
							return;
						}
						goto case 4;
					default:
						SetRawValue(axis2D.rawZero);
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.initialized)
			{
				NVWqZPEZaDhGVdcEuqvABdsUKUL();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.initialized)
			{
				_axis2D.Deinitialize();
				OnClear();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			while (true)
			{
				int num = 952113866;
				while (true)
				{
					switch (num ^ 0x38C01ACB)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (base.initialized)
						{
							goto IL_0038;
						}
						return;
					case 3:
						goto IL_0038;
					case 2:
						return;
					}
					break;
					IL_0038:
					nQRBjgHZAYAKvocDqONNTpxqTmA();
					NVWqZPEZaDhGVdcEuqvABdsUKUL();
					num = 952113865;
				}
			}
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x544F2716 ^ 0x544F2714)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			XWItRFzQtFMTnzwGXepHBSuqEaS();
			GLnFKkzcjTCAOtkTuThfdBcbeFU();
			dByKttBtodosJPFybBXLHsYfHmZw();
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			nQRBjgHZAYAKvocDqONNTpxqTmA();
			_axis2D.Initialize();
			return true;
		}

		internal override void OnCustomControllerUpdate()
		{
			if (!base.initialized)
			{
				return;
			}
			while (hasController)
			{
				while (true)
				{
					IL_009c:
					Vector2 value = _axis2D.value;
					int num;
					if (_useXAxis)
					{
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
						num = 148817274;
						goto IL_000e;
					}
					goto IL_0046;
					IL_0078:
					if (_allowTap)
					{
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(_tapCustomControllerElement, tapValue);
						num = 148817276;
						goto IL_000e;
					}
					return;
					IL_0046:
					if (_useYAxis)
					{
						jdvcKcWQnHxAXPvCkvKHWiFjvWV(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
						num = 148817273;
						goto IL_000e;
					}
					goto IL_0078;
					IL_000e:
					while (true)
					{
						switch (num ^ 0x8DEC578)
						{
						case 0:
							num = 148817275;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							goto IL_0046;
						case 1:
							goto IL_0078;
						case 5:
							goto IL_009c;
						case 4:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			while (true)
			{
				int num = 1910565193;
				while (true)
				{
					switch (num ^ 0x71E0E948)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					_axis2D.ValueChangedEvent += HWFhkFlLkYUKyhTUFbGsyGCYFc;
					num = 1910565194;
				}
			}
		}

		internal override void OnUnsubscribeEvents()
		{
			base.OnUnsubscribeEvents();
			_axis2D.ValueChangedEvent -= HWFhkFlLkYUKyhTUFbGsyGCYFc;
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			if (!base.initialized)
			{
				while (true)
				{
					switch (0xFCF82B1 ^ 0xFCF82B3)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			nQRBjgHZAYAKvocDqONNTpxqTmA();
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
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
				int num = -1193174042;
				while (true)
				{
					switch (num ^ -1193174042)
					{
					case 4:
						num = -1193174045;
						continue;
					case 5:
						break;
					case 2:
						CgelQMRxKcNpSeEdjHrUgepUNWaw();
						_axis2D.Clear();
						num = -1193174043;
						continue;
					case 7:
						ReturnToDefaultPosition(true);
						num = -1193174041;
						continue;
					case 0:
					{
						jYtFWKZUVrechfzATGCgCETBhJCg = false;
						GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
						_pointerDownIsFake = false;
						_lastPressAnchoredPosition = Vector2.zero;
						_lastPressStartingValue = Vector2.zero;
						_calculatedStickRange_lastUpdatedFrame = -1;
						_lastTapFrame = -1;
						_isEligibleForTap = false;
						int num3;
						if (!_returnOnRelease)
						{
							num = -1193174041;
							num3 = num;
						}
						else
						{
							num = -1193174048;
							num3 = num;
						}
						continue;
					}
					case 6:
						if (_isMovedFromDefaultPosition)
						{
							if (!_moveToTouchPosition)
							{
								int num2;
								if (_followTouchPosition)
								{
									num = -1193174047;
									num2 = num;
								}
								else
								{
									num = -1193174041;
									num2 = num;
								}
								continue;
							}
							goto case 7;
						}
						goto case 1;
					case 1:
						_isMovedFromDefaultPosition = false;
						_isMoving = false;
						_moveDirection = ynWUqBPMQTEMtlodYrfUADbwzmX.TCGihQKDgeeGtvEXifcuojmabzj;
						num = -1193174044;
						continue;
					default:
						NVWqZPEZaDhGVdcEuqvABdsUKUL();
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
				_hierarchyValueChangedHandlers = new GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IValueChangedHandler, Vector2>(valueChangedHandlerDelegate);
				goto IL_001e;
			}
			goto IL_0073;
			IL_0073:
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			int num;
			int num2;
			if (_hierarchyStickPositionChangedHandlers != null)
			{
				num = 1556128450;
				num2 = num;
			}
			else
			{
				num = 1556128448;
				num2 = num;
			}
			goto IL_0023;
			IL_001e:
			num = 1556128453;
			goto IL_0023;
			IL_0023:
			while (true)
			{
				switch (num ^ 0x5CC0A2C1)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
					num = 1556128451;
					continue;
				case 1:
					_hierarchyStickPositionChangedHandlers = new GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(stickPositionChangedHandlerDelegate);
					num = 1556128450;
					continue;
				case 4:
					goto IL_0073;
				case 2:
					return;
				}
				break;
			}
			goto IL_001e;
		}

		public override void ClearValue()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0040;
			IL_0008:
			int num = -534369781;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -534369782)
				{
				case 5:
					break;
				default:
					return;
				case 2:
					_lastTapFrame = -1;
					num = -534369783;
					continue;
				case 0:
					goto IL_0040;
				case 1:
					return;
				case 3:
					if (hasController)
					{
						base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
						base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
						base.controller.ClearElementValue(_tapCustomControllerElement);
						num = -534369778;
						continue;
					}
					return;
				case 4:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0040:
			_axis2D.Clear();
			num = -534369784;
			goto IL_000d;
		}

		internal override bool IsPressed()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				return false;
			}
			return jYtFWKZUVrechfzATGCgCETBhJCg;
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

		private void NVWqZPEZaDhGVdcEuqvABdsUKUL()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			dByKttBtodosJPFybBXLHsYfHmZw();
			BpIrxrTAZovcjjJKjdrhqiRYbUtH();
		}

		private void BpIrxrTAZovcjjJKjdrhqiRYbUtH()
		{
			if (_manageRaycasting)
			{
				_imageRaycastHelper.ZWxGRFCRCNYsxogmNDUfCfMeCIIr(base.transform, jRYzOZIJAJApqJNFeBYzaySiWHvl());
			}
		}

		private bool jRYzOZIJAJApqJNFeBYzaySiWHvl()
		{
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void WgGdgRGLGuNKILyWzVQUgvhaIKf(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				goto IL_0009;
			}
			goto IL_0065;
			IL_0009:
			int num = 1316326870;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x4E758DD4)
				{
				case 4:
					break;
				case 3:
					P_0.PointerEnterEvent += dcgoqSOZQngElokwIQkKjPdIlML;
					num = 1316326868;
					continue;
				case 5:
					P_0.PointerUpEvent += pEabpejZnFXyFYVtSEnxCGboYRd;
					num = 1316326871;
					continue;
				case 1:
					goto IL_0065;
				case 2:
					return;
				default:
					P_0.PointerExitEvent += mErQunVxoylvoyoLVaOLThnRYfr;
					P_0.BeginDragEvent += tSprHwabWAeayCELWdqRtWpZHTy;
					P_0.DragEvent += BTVEajulvNaTWgPgwHHzcBOiDqbm;
					P_0.EndDragEvent += QtHeMsbLBSdgMrevetMzBIueeeSv;
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0065:
			ScBbWfMbGgWRkVPrsqLkpPjeHhR(P_0);
			P_0.PointerDownEvent += WIePpjCcsUBMIhAWGtGpDSlJlip;
			num = 1316326865;
			goto IL_000e;
		}

		private void ScBbWfMbGgWRkVPrsqLkpPjeHhR(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				goto IL_0009;
			}
			goto IL_0042;
			IL_0009:
			int num = -1321719324;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ -1321719322)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 6:
					goto IL_0042;
				case 3:
					P_0.DragEvent -= BTVEajulvNaTWgPgwHHzcBOiDqbm;
					P_0.EndDragEvent -= QtHeMsbLBSdgMrevetMzBIueeeSv;
					num = -1321719325;
					continue;
				case 1:
					P_0.BeginDragEvent -= tSprHwabWAeayCELWdqRtWpZHTy;
					num = -1321719323;
					continue;
				case 4:
					P_0.PointerUpEvent -= pEabpejZnFXyFYVtSEnxCGboYRd;
					P_0.PointerEnterEvent -= dcgoqSOZQngElokwIQkKjPdIlML;
					P_0.PointerExitEvent -= mErQunVxoylvoyoLVaOLThnRYfr;
					num = -1321719321;
					continue;
				case 5:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0042:
			P_0.PointerDownEvent -= WIePpjCcsUBMIhAWGtGpDSlJlip;
			num = -1321719326;
			goto IL_000e;
		}

		private void dByKttBtodosJPFybBXLHsYfHmZw()
		{
			if (_workingTouchRegion == _touchRegion)
			{
				return;
			}
			while (true)
			{
				ScBbWfMbGgWRkVPrsqLkpPjeHhR(_workingTouchRegion);
				_workingTouchRegion = _touchRegion;
				WgGdgRGLGuNKILyWzVQUgvhaIKf(_workingTouchRegion);
				int num = -1900809753;
				while (true)
				{
					switch (num ^ -1900809753)
					{
					case 2:
						goto IL_0014;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0014:
					num = -1900809754;
				}
			}
		}

		private void EngeuFiINqVonFKGMsOZSqAIstKQ(Vector2 P_0, bool P_1, float P_2, ynWUqBPMQTEMtlodYrfUADbwzmX P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = PPQNIOlPnyDtERyUKpTWMMgiKJj.yrmpiQKoHoELPfnQUspISjBYwMx(base.canvas, rectTransform, P_0);
			Vector2 pivot = default(Vector2);
			Vector2 sizeDelta = default(Vector2);
			while (true)
			{
				int num = -4483873;
				while (true)
				{
					switch (num ^ -4483875)
					{
					case 0:
						break;
					case 2:
						goto IL_003d;
					default:
					{
						Vector3 localScale = base.rectTransform.localScale;
						vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
						KXGXneOjslBgCoFxDokJHtUpHCr(vector, PositionType.UMtjEaOogDDwQiplOLpTuwxTdbQ, P_1, P_2, P_3);
						return;
					}
					}
					break;
					IL_003d:
					pivot = base.rectTransform.pivot;
					sizeDelta = base.rectTransform.sizeDelta;
					num = -4483876;
				}
			}
		}

		private void KXGXneOjslBgCoFxDokJHtUpHCr(Vector2 P_0, PositionType P_1, bool P_2, float P_3, ynWUqBPMQTEMtlodYrfUADbwzmX P_4)
		{
			if (_isMoving && P_2)
			{
				goto IL_0011;
			}
			goto IL_0209;
			IL_00dd:
			int num;
			int num2;
			if (!(base.canvas == null))
			{
				num = -609864926;
				num2 = num;
			}
			else
			{
				num = -609864908;
				num2 = num;
			}
			goto IL_0016;
			IL_0011:
			num = -609864902;
			goto IL_0016;
			IL_0016:
			float num4 = default(float);
			float num3 = default(float);
			Transform parent = default(Transform);
			Vector2 one = default(Vector2);
			Vector2 sizeDelta = default(Vector2);
			RectTransform rectTransform = default(RectTransform);
			bool flag = default(bool);
			while (true)
			{
				switch (num ^ -609864906)
				{
				case 9:
					break;
				default:
					return;
				case 1:
					P_3 = P_3 / num4 * num3;
					_coroutineMove = YwNxjLvllECYgmvWvRLPlgYahiJ(P_0, P_1, P_3, P_4);
					StartCoroutine(_coroutineMove);
					_moveDirection = P_4;
					_isMovedFromDefaultPosition = true;
					num = -609864900;
					continue;
				case 7:
					P_2 = false;
					num = -609864904;
					continue;
				case 17:
					goto IL_00dd;
				case 4:
					if (P_2)
					{
						parent = base.transform;
						num = -609864922;
						continue;
					}
					goto case 25;
				case 21:
					one = Vector2.one;
					num = -609864923;
					continue;
				case 11:
					if (!(parent == null))
					{
						one.x *= parent.localScale.x;
						num = -609864924;
						continue;
					}
					goto case 15;
				case 6:
					num4 = 0.0001f;
					num = -609864905;
					continue;
				case 5:
					goto IL_0163;
				case 15:
					sizeDelta = rectTransform.sizeDelta;
					num = -609864907;
					continue;
				case 25:
					moveStartedDelegate(P_4);
					yFIryXiFmAheSzYjuuUCpBvLoYn(P_4, P_0, P_1);
					num = -609864928;
					continue;
				case 3:
					flag = sizeDelta.x < sizeDelta.y;
					num = -609864914;
					continue;
				case 19:
					goto IL_01ce;
				case 10:
					moveStartedDelegate(P_4);
					num = -609864927;
					continue;
				case 13:
					goto IL_0209;
				case 18:
					one.y *= parent.localScale.y;
					num = -609864923;
					continue;
				case 20:
					if (base.canvas.renderMode == RenderMode.WorldSpace)
					{
						Logger.LogWarning("Animation can only be used with a screen space Canvas.");
						P_2 = false;
						num = -609864910;
						continue;
					}
					goto case 4;
				case 8:
					_moveDirection = ynWUqBPMQTEMtlodYrfUADbwzmX.TCGihQKDgeeGtvEXifcuojmabzj;
					num = -609864921;
					continue;
				case 0:
					CgelQMRxKcNpSeEdjHrUgepUNWaw();
					_isMoving = false;
					num = -609864898;
					continue;
				case 16:
					rectTransform = base.canvasTransform;
					num = -609864925;
					continue;
				case 14:
					num = -609864910;
					continue;
				case 2:
					Logger.LogWarning("Animation cannot be used without a Canvas.");
					num = -609864911;
					continue;
				case 23:
					return;
				case 12:
					if (_moveDirection == P_4)
					{
						return;
					}
					goto IL_0209;
				case 24:
					num3 = MathTools.Max(sizeDelta.x, sizeDelta.y);
					num4 = (flag ? one.y : one.x);
					num = -609864909;
					continue;
				case 22:
					return;
				}
				break;
				IL_01ce:
				int num5;
				if (!((parent = parent.parent) != rectTransform))
				{
					num = -609864903;
					num5 = num;
				}
				else
				{
					num = -609864899;
					num5 = num;
				}
				continue;
				IL_0163:
				int num6;
				if (num4 == 0f)
				{
					num = -609864912;
					num6 = num;
				}
				else
				{
					num = -609864905;
					num6 = num;
				}
			}
			goto IL_0011;
			IL_0209:
			if (_isMoving)
			{
				int num7;
				if (_coroutineMove == null)
				{
					num = -609864921;
					num7 = num;
				}
				else
				{
					num = -609864906;
					num7 = num;
				}
				goto IL_0016;
			}
			goto IL_00dd;
		}

		private IEnumerator YwNxjLvllECYgmvWvRLPlgYahiJ(Vector2 P_0, PositionType P_1, float P_2, ynWUqBPMQTEMtlodYrfUADbwzmX P_3)
		{
			GPccVisIRkEiSIvwqqWgcRVCgcEK gPccVisIRkEiSIvwqqWgcRVCgcEK = new GPccVisIRkEiSIvwqqWgcRVCgcEK(0);
			gPccVisIRkEiSIvwqqWgcRVCgcEK.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			while (true)
			{
				int num = 1919460608;
				while (true)
				{
					switch (num ^ 0x7268A501)
					{
					case 0:
						break;
					case 1:
						goto IL_002c;
					default:
						gPccVisIRkEiSIvwqqWgcRVCgcEK.DTQmUpQxxpEaloJNKuhapMsZmFf = P_3;
						return gPccVisIRkEiSIvwqqWgcRVCgcEK;
					}
					break;
					IL_002c:
					gPccVisIRkEiSIvwqqWgcRVCgcEK.ofwHDGItTMAnajZEczGfQJAfkWi = P_0;
					gPccVisIRkEiSIvwqqWgcRVCgcEK.cEFYMcdcTaIHyHTckcmnNJNVUTy = P_1;
					gPccVisIRkEiSIvwqqWgcRVCgcEK.lJAziHQEMyViiggdNdulCrmGjoLg = P_2;
					num = 1919460611;
				}
			}
		}

		private void yFIryXiFmAheSzYjuuUCpBvLoYn(ynWUqBPMQTEMtlodYrfUADbwzmX P_0, Vector2 P_1, PositionType P_2)
		{
			PPQNIOlPnyDtERyUKpTWMMgiKJj.AwbDNgzQKwyuEBeAcQzspJfsFFt(base.rectTransform, P_1, P_2);
			while (true)
			{
				int num = 1255576146;
				while (true)
				{
					switch (num ^ 0x4AD69253)
					{
					case 4:
						break;
					default:
						return;
					case 1:
						_isMoving = false;
						_moveDirection = ynWUqBPMQTEMtlodYrfUADbwzmX.TCGihQKDgeeGtvEXifcuojmabzj;
						if (P_0 == ynWUqBPMQTEMtlodYrfUADbwzmX.HwWCoknLLuvDCNsHCSIjJkwLMtB)
						{
							_isMovedFromDefaultPosition = false;
							num = 1255576147;
							continue;
						}
						goto case 3;
					case 0:
						CgelQMRxKcNpSeEdjHrUgepUNWaw();
						moveEndedDelegate(P_0);
						num = 1255576145;
						continue;
					case 3:
						if (P_0 == ynWUqBPMQTEMtlodYrfUADbwzmX.euXYneYPthVhveBWhDzbgcsApkRZ)
						{
							_isMovedFromDefaultPosition = true;
							num = 1255576147;
							continue;
						}
						goto case 0;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void ebwjYhEqRdpMXwLKPVkBqUQNcEDa(ynWUqBPMQTEMtlodYrfUADbwzmX P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag = default(bool);
			bool flag2 = default(bool);
			while (true)
			{
				int num = 354418948;
				while (true)
				{
					switch (num ^ 0x15200107)
					{
					case 6:
						break;
					default:
						return;
					case 8:
						flag = true;
						flag2 = false;
						num = 354418951;
						continue;
					case 5:
						if (!_useTouchRegionOnly)
						{
							int num3;
							if (_moveToTouchPosition)
							{
								num = 354418947;
								num3 = num;
							}
							else
							{
								num = 354418951;
								num3 = num;
							}
							continue;
						}
						goto case 0;
					case 3:
						flag = false;
						num = 354418944;
						continue;
					case 9:
						_imageRaycastHelper.ZWxGRFCRCNYsxogmNDUfCfMeCIIr(base.transform, flag2);
						num = 354418950;
						continue;
					case 7:
					{
						flag2 = false;
						int num4;
						if (!_followTouchPosition)
						{
							num = 354418949;
							num4 = num;
						}
						else
						{
							num = 354418957;
							num4 = num;
						}
						continue;
					}
					case 10:
					{
						int num7;
						if (stayActiveOnSwipeOut)
						{
							num = 354418947;
							num7 = num;
						}
						else
						{
							num = 354418949;
							num7 = num;
						}
						continue;
					}
					case 0:
					{
						int num6;
						if (!flag)
						{
							num = 354418950;
							num6 = num;
						}
						else
						{
							num = 354418958;
							num6 = num;
						}
						continue;
					}
					case 2:
						if (!_followTouchPosition)
						{
							int num5;
							if (_workingTouchRegion != null)
							{
								num = 354418946;
								num5 = num;
							}
							else
							{
								num = 354418951;
								num5 = num;
							}
							continue;
						}
						goto case 0;
					case 4:
						if (_returnOnRelease)
						{
							int num2;
							if (P_0 == ynWUqBPMQTEMtlodYrfUADbwzmX.euXYneYPthVhveBWhDzbgcsApkRZ)
							{
								num = 354418959;
								num2 = num;
							}
							else
							{
								num = 354418951;
								num2 = num;
							}
							continue;
						}
						goto case 0;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void juHmsVQdOwsmtGcmTviVInzkJKk(ynWUqBPMQTEMtlodYrfUADbwzmX P_0)
		{
			bool flag;
			bool flag2;
			if (_manageRaycasting)
			{
				flag = false;
				flag2 = false;
				if (_followTouchPosition)
				{
					goto IL_001a;
				}
				goto IL_00eb;
			}
			return;
			IL_00a5:
			int num;
			int num2;
			if (!flag)
			{
				num = 32838832;
				num2 = num;
			}
			else
			{
				num = 32838842;
				num2 = num;
			}
			goto IL_001f;
			IL_001a:
			num = 32838833;
			goto IL_001f;
			IL_001f:
			while (true)
			{
				switch (num ^ 0x1F514B8)
				{
				case 6:
					break;
				default:
					return;
				case 2:
					_imageRaycastHelper.ZWxGRFCRCNYsxogmNDUfCfMeCIIr(base.transform, flag2);
					num = 32838832;
					continue;
				case 5:
					goto IL_0070;
				case 3:
					goto IL_0089;
				case 1:
					goto IL_00a5;
				case 0:
					flag = true;
					flag2 = jRYzOZIJAJApqJNFeBYzaySiWHvl();
					num = 32838841;
					continue;
				case 9:
					goto IL_00cf;
				case 4:
					goto IL_00eb;
				case 7:
					goto IL_011d;
				case 8:
					return;
				}
				break;
				IL_011d:
				int num3;
				if (P_0 == ynWUqBPMQTEMtlodYrfUADbwzmX.HwWCoknLLuvDCNsHCSIjJkwLMtB)
				{
					num = 32838840;
					num3 = num;
				}
				else
				{
					num = 32838841;
					num3 = num;
				}
				continue;
				IL_0089:
				int num4;
				if (_returnOnRelease)
				{
					num = 32838847;
					num4 = num;
				}
				else
				{
					num = 32838841;
					num4 = num;
				}
				continue;
				IL_0070:
				int num5;
				if (!_moveToTouchPosition)
				{
					num = 32838841;
					num5 = num;
				}
				else
				{
					num = 32838843;
					num5 = num;
				}
				continue;
				IL_00cf:
				int num6;
				if (!stayActiveOnSwipeOut)
				{
					num = 32838844;
					num6 = num;
				}
				else
				{
					num = 32838843;
					num6 = num;
				}
			}
			goto IL_001a;
			IL_00eb:
			if (!_followTouchPosition && _workingTouchRegion != null)
			{
				int num7;
				if (_useTouchRegionOnly)
				{
					num = 32838841;
					num7 = num;
				}
				else
				{
					num = 32838845;
					num7 = num;
				}
				goto IL_001f;
			}
			goto IL_00a5;
		}

		private void CgelQMRxKcNpSeEdjHrUgepUNWaw()
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

		private void dyGGqqDNKdJMvZlREoTIYHXTftYS(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (!TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(P_0))
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -2146546265;
			goto IL_000d;
			IL_000d:
			switch (num ^ -2146546267)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 1:
				goto IL_0032;
			case 3:
				return;
			}
			goto IL_0008;
			IL_0032:
			KXGXneOjslBgCoFxDokJHtUpHCr((Vector2)PPQNIOlPnyDtERyUKpTWMMgiKJj.BFYAtvgPUJNLjuOWcquIuXIEhUS(base.rectTransform, P_2) + P_1, P_2, false, 0f, ynWUqBPMQTEMtlodYrfUADbwzmX.euXYneYPthVhveBWhDzbgcsApkRZ);
			if (_lastClaimSource == lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL)
			{
				_lastPressAnchoredPosition += P_1;
				num = -2146546266;
				goto IL_000d;
			}
		}

		private void GLnFKkzcjTCAOtkTuThfdBcbeFU()
		{
			if (!hasPointer)
			{
				return;
			}
			PointerEventData pointerEventData = default(PointerEventData);
			while (true)
			{
				IL_00c2:
				int num;
				if (!TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
				{
					pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(effectivePointerId);
					num = -1037029978;
					goto IL_0011;
				}
				goto IL_0049;
				IL_0011:
				while (true)
				{
					switch (num ^ -1037029978)
					{
					case 5:
						num = -1037029977;
						continue;
					default:
						return;
					case 3:
						return;
					case 4:
						break;
					case 1:
						goto IL_00c2;
					case 6:
						lvEXyedGHJXClGybBOaYBiVqimu();
						num = -1037029979;
						continue;
					case 2:
						uhbxZnhdAiTocMkidbifwylOKNg(pointerEventData);
						return;
					case 0:
						if (pointerEventData == null)
						{
							goto case 6;
						}
						goto IL_010e;
					case 7:
						return;
					}
					break;
					IL_010e:
					int num2;
					if (!(pointerEventData.pointerPress != null))
					{
						num = -1037029984;
						num2 = num;
					}
					else
					{
						num = -1037029980;
						num2 = num;
					}
				}
				goto IL_0049;
				IL_0049:
				if (_pointerDownIsFake)
				{
					PointerEventData pointerEventData2 = YQzVKdtwLwSZvgQylBxBMwuutwg(effectivePointerId, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
					if (pointerEventData2 != null)
					{
						vKlEhocfjmbSFgtXzOsMTqmeMWoR(pointerEventData2, _lastClaimSource);
						num = -1037029983;
						goto IL_0011;
					}
					break;
				}
				break;
			}
		}

		private void XWItRFzQtFMTnzwGXepHBSuqEaS()
		{
			if (!hasPointer)
			{
				goto IL_0008;
			}
			goto IL_003d;
			IL_0008:
			int num = 2018998790;
			goto IL_000d;
			IL_000d:
			Vector2 vector = default(Vector2);
			while (true)
			{
				switch (num ^ 0x78577A07)
				{
				case 2:
					break;
				default:
					return;
				case 0:
					pybGhnFNCApJPQjwvJIcNrbEYgc(ref vector);
					num = 2018998788;
					continue;
				case 4:
					goto IL_003d;
				case 1:
					return;
				case 3:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_003d:
			vector = TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(effectivePointerId);
			num = 2018998791;
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
				int num = 279248184;
				while (true)
				{
					switch (num ^ 0x10A4FD39)
					{
					case 2:
						break;
					default:
						return;
					case 4:
						if (_tapDistanceLimit >= 0)
						{
							int num4;
							if (Vector2.Distance(_touchStartPosition, P_0) <= (float)_tapDistanceLimit)
							{
								num = 279248185;
								num4 = num;
							}
							else
							{
								num = 279248186;
								num4 = num;
							}
							continue;
						}
						return;
					case 3:
						_isEligibleForTap = false;
						num = 279248185;
						continue;
					case 1:
					{
						int num3;
						if (_isEligibleForTap)
						{
							num = 279248191;
							num3 = num;
						}
						else
						{
							num = 279248188;
							num3 = num;
						}
						continue;
					}
					case 6:
						if (_tapTimeout > 0f)
						{
							int num2;
							if (!(Time.realtimeSinceStartup - _touchStartTime > _tapTimeout))
							{
								num = 279248189;
								num2 = num;
							}
							else
							{
								num = 279248186;
								num2 = num;
							}
							continue;
						}
						goto case 4;
					case 5:
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private bool eOHzHpzQRbBLjxcuQVfnfVkaPND()
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

		private void IVWagqmpVqfBssUpPTaUIrMVFpo()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ;
		}

		private bool xJRpUEtiZlPsigLVVURBBlekxkJ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				goto IL_0008;
			}
			int num;
			if (_pointerId == int.MinValue)
			{
				num = 421907302;
			}
			else if (_pointerId != P_0)
			{
				if (!TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
				{
					goto IL_007f;
				}
				num = 421907303;
			}
			else
			{
				num = 421907300;
			}
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x1925CB67)
			{
			case 4:
				break;
			case 2:
				return false;
			case 3:
				return true;
			case 1:
				return false;
			default:
				goto IL_0067;
			}
			goto IL_0008;
			IL_0008:
			num = 421907301;
			goto IL_000d;
			IL_0067:
			if (_realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			goto IL_007f;
			IL_007f:
			return false;
		}

		private PointerEventData FcNxJWJevjAfECcjXghibLdzawa(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			GameObject gameObject = default(GameObject);
			float unscaledTime = default(float);
			GameObject gameObject2 = default(GameObject);
			float unscaledTime2 = default(float);
			float num3 = default(float);
			while (true)
			{
				int num = 374104940;
				while (true)
				{
					switch (num ^ 0x164C637E)
					{
					case 4:
						break;
					case 16:
						pointerEventData.clickCount = 1;
						num = 374104949;
						continue;
					case 19:
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						gameObject = P_1;
						num = 374104956;
						continue;
					case 18:
						pointerEventData.position = TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(P_0);
						num = 374104955;
						continue;
					case 2:
						unscaledTime = Time.unscaledTime;
						num = 374104947;
						continue;
					case 3:
						pointerEventData.clickTime = unscaledTime;
						num = 374104951;
						continue;
					case 6:
						pointerEventData.pointerDrag = P_1;
						goto case 7;
					case 17:
						pointerEventData.dragging = false;
						pointerEventData.useDragThreshold = true;
						pointerEventData.pressPosition = pointerEventData.position;
						num = 374104941;
						continue;
					case 5:
						if (!TouchInteractable.KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
						{
							goto case 14;
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
							num = 374104948;
							continue;
						}
						goto case 10;
					case 0:
						pointerEventData.clickCount = 1;
						num = 374104959;
						continue;
					case 14:
						if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
						{
							pointerEventData.eligibleForClick = true;
							pointerEventData.delta = Vector2.zero;
							num = 374104943;
							continue;
						}
						goto case 20;
					case 20:
						Logger.LogWarning("Unsupported pointerId: " + P_0);
						num = 374104939;
						continue;
					case 15:
						num = 374104936;
						continue;
					case 11:
						pointerEventData.pointerPress = gameObject;
						pointerEventData.rawPointerPress = P_1;
						pointerEventData.clickTime = unscaledTime;
						pointerEventData.pointerDrag = P_1;
						num = 374104953;
						continue;
					case 10:
						gameObject2 = P_1;
						unscaledTime2 = Time.unscaledTime;
						if (gameObject2 == pointerEventData.lastPress)
						{
							num3 = unscaledTime2 - pointerEventData.clickTime;
							num = 374104950;
							continue;
						}
						goto case 23;
					case 9:
						num = 374104949;
						continue;
					case 1:
						pointerEventData.clickTime = unscaledTime2;
						num = 374104945;
						continue;
					case 24:
						num = 374104959;
						continue;
					case 22:
						pointerEventData.pointerPress = gameObject2;
						pointerEventData.rawPointerPress = P_1;
						pointerEventData.clickTime = unscaledTime2;
						num = 374104952;
						continue;
					case 8:
						if (num3 < 0.3f)
						{
							pointerEventData.clickCount++;
							num = 374104934;
							continue;
						}
						goto case 0;
					case 13:
					{
						if (!(gameObject == pointerEventData.lastPress))
						{
							goto case 16;
						}
						float num2 = unscaledTime - pointerEventData.clickTime;
						if (num2 < 0.3f)
						{
							pointerEventData.clickCount++;
							num = 374104957;
							continue;
						}
						goto case 12;
					}
					case 12:
						pointerEventData.clickCount = 1;
						num = 374104957;
						continue;
					case 23:
						pointerEventData.clickCount = 1;
						num = 374104936;
						continue;
					default:
						return null;
					case 7:
						return pointerEventData;
					}
					break;
				}
			}
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
			while (true)
			{
				int num = -1121989261;
				while (true)
				{
					switch (num ^ -1121989262)
					{
					case 3:
						break;
					case 1:
						pointerEventData.dragging = true;
						pointerEventData.pointerDrag = P_1;
						pointerEventData.useDragThreshold = true;
						pointerEventData.pointerPress = null;
						num = -1121989264;
						continue;
					case 2:
						pointerEventData.rawPointerPress = null;
						num = -1121989262;
						continue;
					default:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private PointerEventData YmNTOnqdWUarvHWIAOOUMxyMuVXg(int P_0)
		{
			PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(P_0);
			while (true)
			{
				int num = -1674970522;
				while (true)
				{
					switch (num ^ -1674970521)
					{
					case 4:
						break;
					case 3:
						pointerEventData.pointerDrag = null;
						pointerEventData.pointerEnter = null;
						goto IL_00d7;
					case 5:
						if (!TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
						{
							goto default;
						}
						pointerEventData.eligibleForClick = false;
						pointerEventData.pointerPress = null;
						pointerEventData.rawPointerPress = null;
						pointerEventData.dragging = false;
						pointerEventData.pointerDrag = null;
						goto IL_00d7;
					case 1:
						if (pointerEventData == null)
						{
							return null;
						}
						if (TouchInteractable.KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
						{
							pointerEventData.eligibleForClick = false;
							pointerEventData.pointerPress = null;
							pointerEventData.rawPointerPress = null;
							num = -1674970521;
							continue;
						}
						goto case 5;
					case 0:
						pointerEventData.dragging = false;
						num = -1674970524;
						continue;
					default:
						{
							Logger.LogWarning("Unsupported pointerId: " + P_0);
							return null;
						}
						IL_00d7:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private void uhbxZnhdAiTocMkidbifwylOKNg(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = 1490214050;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x58D2DCA3)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_002d;
			case 3:
				return;
			}
			goto IL_0003;
			IL_002d:
			OnPointerUp(P_0);
			YmNTOnqdWUarvHWIAOOUMxyMuVXg(effectivePointerId);
			num = 1490214048;
			goto IL_0008;
		}

		private void vKlEhocfjmbSFgtXzOsMTqmeMWoR(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0056;
			IL_0003:
			int num = 1776747982;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x69E705CF)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0041;
				case 6:
					goto IL_0056;
				case 7:
					YmNTOnqdWUarvHWIAOOUMxyMuVXg(effectivePointerId);
					num = 1776747975;
					continue;
				case 4:
					OnDrag(P_0);
					num = 1776747976;
					continue;
				case 5:
					BTVEajulvNaTWgPgwHHzcBOiDqbm(P_0);
					num = 1776747976;
					continue;
				case 2:
					throw new NotImplementedException();
				case 8:
					return;
				}
				break;
				IL_0041:
				int num2;
				if (P_1 != lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL)
				{
					num = 1776747981;
					num2 = num;
				}
				else
				{
					num = 1776747978;
					num2 = num;
				}
			}
			goto IL_0003;
			IL_0056:
			int num3;
			if (P_1 == lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ)
			{
				num = 1776747979;
				num3 = num;
			}
			else
			{
				num = 1776747980;
				num3 = num;
			}
			goto IL_0008;
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
			goto IL_0083;
			IL_0022:
			int num;
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			PointerEventData value = default(PointerEventData);
			while (true)
			{
				switch (num ^ -255272380)
				{
				case 7:
					break;
				case 5:
					button = PointerEventData.InputButton.Right;
					num = -255272378;
					continue;
				case 2:
					value.button = button;
					num = -255272384;
					continue;
				case 0:
					throw new NotImplementedException();
				case 1:
					goto IL_007a;
				case 8:
					goto IL_0083;
				case 3:
					value = new PointerEventData(EventSystem.current);
					value.pointerId = P_0;
					__fakePointerEventData.Add(P_0, value);
					if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
					{
						switch (P_0)
						{
						case -2:
							break;
						case -3:
							goto IL_007a;
						default:
							goto IL_00e5;
						case -1:
							goto IL_00ef;
						}
						goto case 5;
					}
					goto default;
				case 6:
					goto IL_00ef;
				default:
					{
						return value;
					}
					IL_00ef:
					button = PointerEventData.InputButton.Left;
					num = -255272378;
					continue;
					IL_00e5:
					num = -255272380;
					continue;
					IL_007a:
					button = PointerEventData.InputButton.Middle;
					num = -255272378;
					continue;
				}
				break;
			}
			goto IL_001d;
			IL_0083:
			int num2;
			if (__fakePointerEventData.TryGetValue(P_0, out value))
			{
				num = -255272384;
				num2 = num;
			}
			else
			{
				num = -255272377;
				num2 = num;
			}
			goto IL_0022;
			IL_001d:
			num = -255272372;
			goto IL_0022;
		}

		private void nQRBjgHZAYAKvocDqONNTpxqTmA()
		{
			nyzmpEWTMknZYhaJEGiQjqKBXpbI(_axesToUse);
			if (!hasController)
			{
				return;
			}
			while (base.touchController.useCustomController)
			{
				while (true)
				{
					IL_0096:
					int num;
					if (_useXAxis)
					{
						base.controller.ValidateElements(_horizontalAxisCustomControllerElement);
						num = 36568821;
						goto IL_001a;
					}
					goto IL_0075;
					IL_0054:
					if (_allowTap)
					{
						base.controller.ValidateElements(_tapCustomControllerElement);
						num = 36568823;
						goto IL_001a;
					}
					return;
					IL_0075:
					if (_useYAxis)
					{
						base.controller.ValidateElements(_verticalAxisCustomControllerElement);
						num = 36568817;
						goto IL_001a;
					}
					goto IL_0054;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x22DFEF5)
						{
						case 5:
							num = 36568820;
							continue;
						default:
							return;
						case 1:
							break;
						case 4:
							goto IL_0054;
						case 0:
							goto IL_0075;
						case 3:
							goto IL_0096;
						case 2:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void nyzmpEWTMknZYhaJEGiQjqKBXpbI(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			int num3 = default(int);
			int num2 = default(int);
			int targetCount = default(int);
			int targetCount2 = default(int);
			while (true)
			{
				int num = -1488087715;
				while (true)
				{
					switch (num ^ -1488087718)
					{
					case 4:
						break;
					case 10:
						num = -1488087720;
						continue;
					case 6:
						num3 = 0;
						num = -1488087728;
						continue;
					case 8:
						num3++;
						num = -1488087720;
						continue;
					case 3:
					{
						int num5;
						if (num2 < targetCount)
						{
							num = -1488087725;
							num5 = num;
						}
						else
						{
							num = -1488087713;
							num5 = num;
						}
						continue;
					}
					case 9:
						base.controller.ClearElementValue(_horizontalAxisCustomControllerElement[num2]);
						num2++;
						num = -1488087719;
						continue;
					case 1:
						base.controller.ClearElementValue(_verticalAxisCustomControllerElement[num3]);
						num = -1488087726;
						continue;
					case 5:
					{
						bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
						if (_useYAxis != flag2)
						{
							_useYAxis = flag2;
							if (!flag2 && hasController)
							{
								targetCount2 = _verticalAxisCustomControllerElement.targetCount;
								num = -1488087716;
								continue;
							}
						}
						goto default;
					}
					case 2:
					{
						int num4;
						if (num3 >= targetCount2)
						{
							num = -1488087718;
							num4 = num;
						}
						else
						{
							num = -1488087717;
							num4 = num;
						}
						continue;
					}
					case 7:
						if (_useXAxis != flag)
						{
							_useXAxis = flag;
							if (!flag && hasController)
							{
								targetCount = _horizontalAxisCustomControllerElement.targetCount;
								num2 = 0;
								num = -1488087719;
								continue;
							}
						}
						goto case 5;
					default:
						_axesToUse = P_0;
						return;
					}
					break;
				}
			}
		}

		private void RTFkZgwwfqcoraXUeOtRrGPTipR(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if (hasPointer && !xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (vWWTQEuzSAtwkwTidoREbMzaAEi())
				{
					num = -1029688512;
					num2 = num;
				}
				else
				{
					num = -1029688510;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1029688512)
					{
					case 3:
						num = -1029688511;
						continue;
					case 1:
						break;
					case 0:
						if (IsInteractable())
						{
							oPbGWVlpSTmnotbhVEcMMsRAWvN(P_0.pointerId, P_0.pressPosition, P_1);
							num = -1029688510;
							continue;
						}
						goto default;
					default:
						base.OnPointerDown(P_0);
						return;
					}
					break;
				}
			}
		}

		private void oyVgIoryHcoeYsQAABSabldnFuw(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if ((!hasPointer || xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId)) && !TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
			{
				lvEXyedGHJXClGybBOaYBiVqimu();
				base.OnPointerUp(P_0);
			}
		}

		private void kniQNhRGNrdKgAIpgLeavFJtBJvU(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if (hasPointer)
			{
				goto IL_000b;
			}
			goto IL_02c3;
			IL_000b:
			int num = -1415188198;
			goto IL_0010;
			IL_0010:
			bool flag2 = default(bool);
			MouseButtonFlags mouseButtonFlags = default(MouseButtonFlags);
			PointerEventData pointerEventData = default(PointerEventData);
			int realMousePointerId = default(int);
			bool flag = default(bool);
			GameObject gameObject = default(GameObject);
			while (true)
			{
				switch (num ^ -1415188208)
				{
				case 20:
					break;
				case 27:
					goto IL_0090;
				case 0:
					num = -1415188202;
					continue;
				case 18:
					if ((!flag2 || TouchInteractable.adosDjbqcDBzBFXIUEkqUggQerO(mouseButtonFlags)) && !jYtFWKZUVrechfzATGCgCETBhJCg)
					{
						goto IL_00c1;
					}
					goto case 25;
				case 25:
					base.OnPointerEnter(P_0);
					num = -1415188201;
					continue;
				case 5:
					if (jYtFWKZUVrechfzATGCgCETBhJCg)
					{
						_pointerDownIsFake = true;
						num = -1415188204;
						continue;
					}
					goto default;
				case 24:
					goto IL_0105;
				case 10:
					goto IL_0123;
				case 3:
					if (!_activateOnSwipeIn)
					{
						goto case 25;
					}
					goto IL_014d;
				case 11:
					switch (P_1)
					{
					case lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL:
						goto IL_0185;
					case lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ:
						goto IL_01af;
					}
					num = -1415188208;
					continue;
				case 23:
					goto IL_0185;
				case 12:
					RTFkZgwwfqcoraXUeOtRrGPTipR(pointerEventData, P_1);
					num = -1415188203;
					continue;
				case 8:
					goto IL_01af;
				case 26:
					num = -1415188224;
					continue;
				case 17:
					num = -1415188218;
					continue;
				case 14:
					_realMousePointerId = realMousePointerId;
					num = -1415188223;
					continue;
				case 2:
					goto IL_01e6;
				case 13:
					goto IL_0202;
				case 16:
					goto IL_0218;
				case 1:
					return;
				case 9:
					_realMousePointerId = P_0.pointerId;
					num = -1415188218;
					continue;
				case 19:
					throw new NotImplementedException();
				case 15:
					num = -1415188221;
					continue;
				case 7:
					goto IL_0290;
				case 22:
					flag = true;
					num = -1415188215;
					continue;
				case 6:
					throw new NotImplementedException();
				case 21:
					goto IL_02c3;
				default:
					{
						GXxxUMYvhnAdzwfrIpAYPjIWpue = true;
						return;
					}
					IL_01af:
					gameObject = base.gameObject;
					num = -1415188214;
					continue;
					IL_0185:
					gameObject = _workingTouchRegion.gameObject;
					num = -1415188224;
					continue;
				}
				break;
				IL_0290:
				int num2;
				if (!flag)
				{
					num = -1415188204;
					num2 = num;
				}
				else
				{
					num = -1415188197;
					num2 = num;
				}
				continue;
				IL_00c1:
				int num3;
				if (flag2)
				{
					num = -1415188216;
					num3 = num;
				}
				else
				{
					num = -1415188218;
					num3 = num;
				}
				continue;
				IL_014d:
				int num4;
				if (vWWTQEuzSAtwkwTidoREbMzaAEi())
				{
					num = -1415188206;
					num4 = num;
				}
				else
				{
					num = -1415188215;
					num4 = num;
				}
				continue;
				IL_0218:
				pointerEventData = FcNxJWJevjAfECcjXghibLdzawa((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				int num5;
				if (pointerEventData != null)
				{
					num = -1415188196;
					num5 = num;
				}
				else
				{
					num = -1415188204;
					num5 = num;
				}
				continue;
				IL_0105:
				int num6;
				if (!TouchInteractable.mrmKZDYUuqVORhTlxFDFBEPmIPc(mouseButtonFlags, out realMousePointerId))
				{
					num = -1415188199;
					num6 = num;
				}
				else
				{
					num = -1415188194;
					num6 = num;
				}
				continue;
				IL_0123:
				int num7;
				if (!xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
				{
					num = -1415188207;
					num7 = num;
				}
				else
				{
					num = -1415188219;
					num7 = num;
				}
				continue;
				IL_01e6:
				int num8;
				if (!IsInteractable())
				{
					num = -1415188215;
					num8 = num;
				}
				else
				{
					num = -1415188222;
					num8 = num;
				}
			}
			goto IL_000b;
			IL_02c3:
			flag2 = TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0.pointerId);
			flag = false;
			switch (P_1)
			{
			case lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ:
				break;
			case lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL:
				goto IL_0202;
			default:
				goto IL_02e3;
			}
			goto IL_0090;
			IL_0090:
			mouseButtonFlags = base.allowedMouseButtons;
			num = -1415188205;
			goto IL_0010;
			IL_0202:
			mouseButtonFlags = _touchRegion.allowedMouseButtons;
			num = -1415188205;
			goto IL_0010;
			IL_02e3:
			num = -1415188193;
			goto IL_0010;
		}

		private void AQKFYYuUyzWMUiyIguWHpBOybED(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_007c;
			IL_0008:
			int num = -1784052520;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1784052516)
				{
				case 2:
					break;
				default:
					return;
				case 4:
					if (!xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
					{
						base.OnPointerExit(P_0);
						return;
					}
					goto IL_007c;
				case 5:
					goto IL_0053;
				case 0:
					lvEXyedGHJXClGybBOaYBiVqimu();
					num = -1784052519;
					continue;
				case 6:
					GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
					num = -1784052515;
					continue;
				case 3:
					goto IL_007c;
				case 1:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0053:
			base.OnPointerExit(P_0);
			num = -1784052518;
			goto IL_000d;
			IL_007c:
			if (!stayActiveOnSwipeOut)
			{
				int num2;
				if (!jYtFWKZUVrechfzATGCgCETBhJCg)
				{
					num = -1784052519;
					num2 = num;
				}
				else
				{
					num = -1784052516;
					num2 = num;
				}
				goto IL_000d;
			}
			goto IL_0053;
		}

		private void JRkEqNmrQbBydBquNGteZdaKdfdJ(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if (!hasPointer)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = -952984007;
			goto IL_000d;
			IL_000d:
			switch (num ^ -952984005)
			{
			case 3:
				break;
			default:
				return;
			case 0:
				goto IL_002e;
			case 4:
				goto IL_003c;
			case 2:
				return;
			case 1:
				return;
			}
			goto IL_0008;
			IL_003c:
			if (!xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				return;
			}
			goto IL_002e;
			IL_002e:
			base.OnBeginDrag(P_0);
			num = -952984006;
			goto IL_000d;
		}

		private void oZDVbyDorizVIzkVjNvchfTADTLa(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if (!hasPointer)
			{
				return;
			}
			Vector2 vector4 = default(Vector2);
			Vector2 vector3 = default(Vector2);
			Vector2 rawValue = default(Vector2);
			bool flag = default(bool);
			Vector2 vector5 = default(Vector2);
			bool flag2 = default(bool);
			while (xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				while (true)
				{
					IL_01e9:
					RectTransform rectTransform = touchReferenceTransform;
					Vector2 vector;
					int num;
					if (_snapStickToTouch)
					{
						vector = PPQNIOlPnyDtERyUKpTWMMgiKJj.jjXGghIXZrRSMthukGSsSaDDllE(base.rectTransform, rectTransform, base.rectTransform.rect.center);
						num = 443148830;
						goto IL_0011;
					}
					goto IL_02d5;
					IL_0011:
					while (true)
					{
						switch (num ^ 0x1A69EA0F)
						{
						case 19:
							num = 443148810;
							continue;
						case 13:
							if (_stickBounds == StickBounds.Square)
							{
								vector4 = MathTools.Clamp(vector3, 0f - calculatedStickRange, calculatedStickRange);
								num = 443148809;
								continue;
							}
							goto case 14;
						case 0:
							rawValue = vector4 / calculatedStickRange;
							num = 443148812;
							continue;
						case 4:
							break;
						case 11:
							if (_stickBounds == StickBounds.Square)
							{
								flag = Mathf.Abs(vector3.x) > calculatedStickRange;
								num = 443148811;
								continue;
							}
							goto case 8;
						case 16:
							vector4 = Vector2.ClampMagnitude(vector3, calculatedStickRange);
							num = 443148815;
							continue;
						case 14:
							throw new NotImplementedException();
						case 6:
							num = 443148815;
							continue;
						case 15:
							goto IL_0145;
						case 5:
							goto end_IL_0011;
						case 20:
							dyGGqqDNKdJMvZlREoTIYHXTftYS(effectivePointerId, vector5, PositionType.GGTSFVietfXEJqUNBOrLtjJMCol);
							num = 443148806;
							continue;
						case 10:
							goto IL_01e9;
						case 18:
							goto IL_0226;
						case 7:
							if (_followTouchPosition)
							{
								if (_stickBounds != StickBounds.Circle)
								{
									goto case 11;
								}
								if (vector3.sqrMagnitude > calculatedStickRange)
								{
									vector5 = new Vector2(_useXAxis ? (vector3.x - vector4.x) : 0f, _useXAxis ? (vector3.y - vector4.y) : 0f);
									num = 443148827;
									continue;
								}
							}
							goto default;
						case 3:
							SetRawValue(rawValue);
							num = 443148808;
							continue;
						case 8:
							throw new NotImplementedException();
						case 1:
							goto IL_02d5;
						case 17:
							goto IL_02e6;
						case 12:
							vector -= _lastPressStartingValue * calculatedStickRange;
							num = 443148800;
							continue;
						case 2:
						{
							Vector2 vector2 = new Vector2((_useXAxis && flag) ? (vector3.x - vector4.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector4.y) : 0f);
							dyGGqqDNKdJMvZlREoTIYHXTftYS(effectivePointerId, vector2, PositionType.GGTSFVietfXEJqUNBOrLtjJMCol);
							num = 443148806;
							continue;
						}
						default:
							base.OnDrag(P_0);
							return;
						}
						flag2 = Mathf.Abs(vector3.y) > calculatedStickRange;
						int num2;
						if (!flag)
						{
							num = 443148829;
							num2 = num;
						}
						else
						{
							num = 443148813;
							num2 = num;
						}
						continue;
						IL_02e6:
						if (!_centerStickOnRelease)
						{
							int num3;
							if (_snapStickToTouch)
							{
								num = 443148800;
								num3 = num;
							}
							else
							{
								num = 443148803;
								num3 = num;
							}
							continue;
						}
						goto IL_0145;
						IL_0226:
						int num4;
						if (flag2)
						{
							num = 443148813;
							num4 = num;
						}
						else
						{
							num = 443148806;
							num4 = num;
						}
						continue;
						IL_0145:
						Vector2 vector6 = PPQNIOlPnyDtERyUKpTWMMgiKJj.GKxnYoGyGjBRzUqwywRMFVQZwPk(base.canvas, rectTransform, P_0.position);
						vector3 = new Vector2(_useXAxis ? (vector6.x - vector.x) : 0f, _useYAxis ? (vector6.y - vector.y) : 0f);
						int num5;
						if (_stickBounds == StickBounds.Circle)
						{
							num = 443148831;
							num5 = num;
						}
						else
						{
							num = 443148802;
							num5 = num;
						}
						continue;
						end_IL_0011:
						break;
					}
					break;
					IL_02d5:
					vector = _lastPressAnchoredPosition;
					num = 443148830;
					goto IL_0011;
				}
			}
		}

		private void qCDVnsBmJowpycpyHMQTezgiJlz(PointerEventData P_0, lfggsvJHPvryrXYDjukFAqXNbzH P_1)
		{
			if (!hasPointer)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
				{
					num = -1882490951;
					num2 = num;
				}
				else
				{
					num = -1882490950;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1882490952)
					{
					case 4:
						num = -1882490949;
						continue;
					default:
						return;
					case 2:
						base.OnEndDrag(P_0);
						num = -1882490952;
						continue;
					case 1:
						return;
					case 3:
						break;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void oPbGWVlpSTmnotbhVEcMMsRAWvN(int P_0, Vector2 P_1, lfggsvJHPvryrXYDjukFAqXNbzH P_2)
		{
			_pointerId = P_0;
			_lastClaimSource = P_2;
			_isEligibleForTap = true;
			_lastPressAnchoredPosition = PPQNIOlPnyDtERyUKpTWMMgiKJj.GKxnYoGyGjBRzUqwywRMFVQZwPk(base.canvas, touchReferenceTransform, P_1);
			jYtFWKZUVrechfzATGCgCETBhJCg = true;
			while (true)
			{
				int num = 1524963698;
				while (true)
				{
					switch (num ^ 0x5AE51973)
					{
					case 3:
						break;
					default:
						return;
					case 6:
						if (_onTouchStarted != null)
						{
							_onTouchStarted.Invoke();
							num = 1524963697;
							continue;
						}
						goto case 2;
					case 2:
					{
						PointerEventData pointerEventData = YQzVKdtwLwSZvgQylBxBMwuutwg(_pointerId, (P_2 == lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
						if (pointerEventData != null)
						{
							vKlEhocfjmbSFgtXzOsMTqmeMWoR(pointerEventData, P_2);
							num = 1524963700;
							continue;
						}
						return;
					}
					case 8:
						num = 1524963701;
						continue;
					case 4:
						if (P_2 != lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL)
						{
							goto case 6;
						}
						if (!_moveToTouchPosition)
						{
							int num2;
							if (_followTouchPosition)
							{
								num = 1524963699;
								num2 = num;
							}
							else
							{
								num = 1524963701;
								num2 = num;
							}
							continue;
						}
						goto case 0;
					case 0:
						if (_followTouchPosition)
						{
							EngeuFiINqVonFKGMsOZSqAIstKQ(P_1, false, 0f, ynWUqBPMQTEMtlodYrfUADbwzmX.euXYneYPthVhveBWhDzbgcsApkRZ);
							num = 1524963707;
							continue;
						}
						goto case 5;
					case 1:
						_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
						_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
						_touchStartTime = Time.realtimeSinceStartup;
						_touchStartPosition = P_1;
						num = 1524963703;
						continue;
					case 5:
						EngeuFiINqVonFKGMsOZSqAIstKQ(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, ynWUqBPMQTEMtlodYrfUADbwzmX.euXYneYPthVhveBWhDzbgcsApkRZ);
						num = 1524963701;
						continue;
					case 7:
						return;
					}
					break;
				}
			}
		}

		private void lvEXyedGHJXClGybBOaYBiVqimu()
		{
			IVWagqmpVqfBssUpPTaUIrMVFpo();
			bool flag = default(bool);
			while (true)
			{
				int num = 1263124399;
				while (true)
				{
					int num2;
					switch (num ^ 0x4B49BFA1)
					{
					case 4:
						break;
					default:
						return;
					case 13:
						_isEligibleForTap = false;
						if (flag)
						{
							_lastTapFrame = Time.frameCount + 1;
							num = 1263124387;
							continue;
						}
						return;
					case 5:
						if (_onTouchEnded != null)
						{
							_onTouchEnded.Invoke();
							num = 1263124396;
							continue;
						}
						goto case 13;
					case 8:
						_lastPressAnchoredPosition = Vector2.zero;
						num = 1263124384;
						continue;
					case 9:
						if (_returnOnRelease)
						{
							int num3;
							if (!_isMovedFromDefaultPosition)
							{
								num = 1263124394;
								num3 = num;
							}
							else
							{
								num = 1263124397;
								num3 = num;
							}
							continue;
						}
						goto case 11;
					case 10:
						if (!_followTouchPosition)
						{
							int num4;
							if (!_moveToTouchPosition)
							{
								num = 1263124394;
								num4 = num;
							}
							else
							{
								num = 1263124392;
								num4 = num;
							}
							continue;
						}
						goto case 9;
					case 0:
						jYtFWKZUVrechfzATGCgCETBhJCg = false;
						_pointerDownIsFake = false;
						num = 1263124393;
						continue;
					case 2:
						_onTap.Invoke();
						num = 1263124390;
						continue;
					case 3:
						SetRawValue(_axis2D.rawZero);
						num = 1263124388;
						continue;
					case 14:
						if (_allowTap)
						{
							num = 1263124391;
							continue;
						}
						num2 = 0;
						goto IL_016d;
					case 1:
						_lastPressStartingValue = Vector2.zero;
						num = 1263124395;
						continue;
					case 6:
						num2 = (_isEligibleForTap ? 1 : 0);
						goto IL_016d;
					case 11:
					{
						int num5;
						if (_centerStickOnRelease)
						{
							num = 1263124386;
							num5 = num;
						}
						else
						{
							num = 1263124388;
							num5 = num;
						}
						continue;
					}
					case 12:
						ReturnToDefaultPosition();
						num = 1263124394;
						continue;
					case 7:
						return;
						IL_016d:
						flag = (byte)num2 != 0;
						num = 1263124385;
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
				while (true)
				{
					switch (0x264691DA ^ 0x264691DE)
					{
					case 0:
						break;
					case 4:
						return;
					case 2:
						goto end_IL_0008;
					case 1:
						goto IL_0054;
					default:
						goto IL_0070;
					}
					continue;
					end_IL_0008:
					break;
				}
				goto IL_0036;
			}
			goto IL_0054;
			IL_0070:
			oyVgIoryHcoeYsQAABSabldnFuw(eventData, lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ);
			return;
			IL_0054:
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			goto IL_0036;
			IL_0036:
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return;
			}
			goto IL_0070;
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				while (true)
				{
					int num;
					int num2;
					if (_workingTouchRegion != null)
					{
						num = -395613274;
						num2 = num;
					}
					else
					{
						num = -395613277;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -395613278)
						{
						case 2:
							num = -395613279;
							continue;
						case 4:
							if (_useTouchRegionOnly)
							{
								return;
							}
							goto default;
						case 0:
							break;
						case 3:
							goto end_IL_003f;
						default:
							RTFkZgwwfqcoraXUeOtRrGPTipR(eventData, lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ);
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

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x3B5B327D ^ 0x3B5B327F)
					{
					case 0:
						break;
					case 2:
						return;
					case 4:
						goto end_IL_0008;
					case 1:
						goto IL_0054;
					default:
						goto IL_0070;
					}
					continue;
					end_IL_0008:
					break;
				}
				goto IL_0036;
			}
			goto IL_0054;
			IL_0070:
			kniQNhRGNrdKgAIpgLeavFJtBJvU(eventData, lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ);
			return;
			IL_0054:
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			goto IL_0036;
			IL_0036:
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return;
			}
			goto IL_0070;
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
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
							num = 629570401;
							num2 = num;
						}
						else
						{
							num = 629570407;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ 0x25867B65)
							{
							case 0:
								num = 629570404;
								continue;
							case 1:
								break;
							case 2:
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
					AQKFYYuUyzWMUiyIguWHpBOybED(eventData, lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ);
					return;
				}
			}
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				while (true)
				{
					IL_005c:
					int num;
					int num2;
					if (!(_workingTouchRegion != null))
					{
						num = -894927514;
						num2 = num;
					}
					else
					{
						num = -894927513;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -894927515)
						{
						case 0:
							num = -894927519;
							continue;
						case 4:
							break;
						case 2:
							if (_useTouchRegionOnly)
							{
								return;
							}
							goto default;
						case 1:
							goto IL_005c;
						default:
							JRkEqNmrQbBydBquNGteZdaKdfdJ(eventData, lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ);
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal override void OnDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
				{
					num = -590961025;
					num2 = num;
				}
				else
				{
					num = -590961027;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -590961027)
					{
					case 4:
						num = -590961028;
						continue;
					default:
						return;
					case 5:
						if (_useTouchRegionOnly)
						{
							return;
						}
						goto case 6;
					case 0:
						return;
					case 2:
					{
						int num3;
						if (_workingTouchRegion != null)
						{
							num = -590961032;
							num3 = num;
						}
						else
						{
							num = -590961029;
							num3 = num;
						}
						continue;
					}
					case 1:
						break;
					case 6:
						oZDVbyDorizVIzkVjNvchfTADTLa(eventData, lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ);
						num = -590961026;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal override void OnEndDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0051;
			IL_0008:
			int num = 1739758824;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x67B29CEB)
			{
			case 5:
				break;
			case 4:
				goto IL_0032;
			case 2:
				goto IL_0051;
			case 3:
				return;
			case 1:
				if (_useTouchRegionOnly)
				{
					return;
				}
				goto default;
			default:
				qCDVnsBmJowpycpyHMQTezgiJlz(eventData, lfggsvJHPvryrXYDjukFAqXNbzH.UMtjEaOogDDwQiplOLpTuwxTdbQ);
				return;
			}
			goto IL_0008;
			IL_0032:
			int num2;
			if (!(_workingTouchRegion != null))
			{
				num = 1739758827;
				num2 = num;
			}
			else
			{
				num = 1739758826;
				num2 = num;
			}
			goto IL_000d;
			IL_0051:
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				return;
			}
			goto IL_0032;
		}

		private void WIePpjCcsUBMIhAWGtGpDSlJlip(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				while (true)
				{
					IL_004c:
					RTFkZgwwfqcoraXUeOtRrGPTipR(P_0, lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL);
					int num = -1690300885;
					while (true)
					{
						switch (num ^ -1690300888)
						{
						case 0:
							num = -1690300887;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							goto IL_004c;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void pEabpejZnFXyFYVtSEnxCGboYRd(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
				{
					num = 2077723556;
					num2 = num;
				}
				else
				{
					num = 2077723557;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7BD78BA7)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					case 2:
						return;
					default:
						oyVgIoryHcoeYsQAABSabldnFuw(P_0, lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL);
						return;
					}
					break;
					IL_0009:
					num = 2077723558;
				}
			}
		}

		private void dcgoqSOZQngElokwIQkKjPdIlML(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				kniQNhRGNrdKgAIpgLeavFJtBJvU(P_0, lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL);
			}
		}

		private void mErQunVxoylvoyoLVaOLThnRYfr(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (-1380977518 ^ -1380977517)
					{
					case 2:
						break;
					case 1:
						return;
					case 3:
						goto end_IL_0008;
					default:
						goto IL_0053;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			goto IL_0053;
			IL_0053:
			AQKFYYuUyzWMUiyIguWHpBOybED(P_0, lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL);
		}

		private void tSprHwabWAeayCELWdqRtWpZHTy(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
				{
					num = 101228817;
					num2 = num;
				}
				else
				{
					num = 101228819;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x608A111)
					{
					case 3:
						num = 101228821;
						continue;
					default:
						return;
					case 2:
						JRkEqNmrQbBydBquNGteZdaKdfdJ(P_0, lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL);
						num = 101228816;
						continue;
					case 0:
						return;
					case 4:
						break;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void BTVEajulvNaTWgPgwHHzcBOiDqbm(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -1382306237;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1382306233)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				return;
			case 1:
				goto IL_0036;
			case 3:
				goto IL_0057;
			case 2:
				return;
			}
			goto IL_0008;
			IL_0036:
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				return;
			}
			goto IL_0057;
			IL_0057:
			oZDVbyDorizVIzkVjNvchfTADTLa(P_0, lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL);
			num = -1382306235;
			goto IL_000d;
		}

		private void QtHeMsbLBSdgMrevetMzBIueeeSv(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				qCDVnsBmJowpycpyHMQTezgiJlz(P_0, lfggsvJHPvryrXYDjukFAqXNbzH.qBvlHFfTVaijZsMuBaXfTPCbahL);
			}
		}

		private void HWFhkFlLkYUKyhTUFbGsyGCYFc(Vector2 P_0)
		{
			tPzLrmyiYkESrTkUqlRUVdqEdkXD(null);
			Vector2 vector = P_0;
			if (_axis2D.xAxis.calibration.invert)
			{
				vector.x *= -1f;
				goto IL_0033;
			}
			goto IL_0060;
			IL_0101:
			vector = MathTools.Clamp(vector, -1f, 1f);
			RectTransform rectTransform = default(RectTransform);
			Vector3 position;
			int num;
			if (_stickTransform != null)
			{
				rectTransform = touchReferenceTransform;
				position = vector * calculatedStickRange;
				position += rectTransform.InverseTransformPoint(base.transform.position);
				num = 244178192;
				goto IL_0038;
			}
			goto IL_0094;
			IL_0033:
			num = 244178198;
			goto IL_0038;
			IL_0038:
			while (true)
			{
				switch (num ^ 0xE8DDD15)
				{
				case 0:
					break;
				case 3:
					goto IL_0060;
				case 2:
					goto IL_0094;
				case 5:
				{
					Vector3 position2 = rectTransform.TransformPoint(position);
					Vector3 vector2 = _stickTransform.parent.InverseTransformPoint(position2);
					Vector2 anchoredPosition = PPQNIOlPnyDtERyUKpTWMMgiKJj.cQRXzfGypQicMcIGncOvjOxyqBuA(_stickTransform.parent as RectTransform, vector2);
					anchoredPosition += _origStickAnchoredPosition;
					_stickTransform.anchoredPosition = anchoredPosition;
					num = 244178199;
					continue;
				}
				case 4:
					goto IL_0101;
				default:
					_hierarchyStickPositionChangedHandlers.ExecuteOnAll(vector);
					_onValueChanged.Invoke(P_0);
					_onStickPositionChanged.Invoke(vector);
					return;
				}
				break;
			}
			goto IL_0033;
			IL_0060:
			if (_axis2D.yAxis.calibration.invert)
			{
				vector.y *= -1f;
				num = 244178193;
				goto IL_0038;
			}
			goto IL_0101;
			IL_0094:
			_hierarchyValueChangedHandlers.ExecuteOnAll(P_0);
			num = 244178196;
			goto IL_0038;
		}

		[CompilerGenerated]
		private static void zfAcPJelVuzRcUBgBbCkHpSdnsZ(IValueChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnValueChanged(P_1);
		}

		[CompilerGenerated]
		private static void wcvHJXvNnkRWTITVjmiLPaczMMm(IStickPositionChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnStickPositionChanged(P_1);
		}
	}
}
