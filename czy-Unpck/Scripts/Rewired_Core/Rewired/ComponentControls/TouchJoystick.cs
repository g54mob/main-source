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

		private enum wRCfymeNjLzkuVaEfTYwCbhegtWO
		{
			XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
			yrNPjkUJApZCVhMgUIDiTGAJeil = 1,
			ZHOJKsdjqeTbuCznzGjkgQECHhx = 2
		}

		private enum jFqMitXzejUyLCwdAFdYbchMkpx
		{
			AXriQuEBFZCYarVPplCATARGxpw = 0,
			ocnclNbRoiITlrFWknqquxusEpr = 1
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

		private sealed class MswgrqgGkcjYkfeUTdftXahdKceq : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			public TouchJoystick syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public Vector2 gbejOQIayEZKbGyCZpFoaaiiUxS;

			public PositionType oDHiqonMoiufKKpGJbNyiKpUZHE;

			public float juGAuHQJxyCbGveDiDRabDWTpiv;

			public wRCfymeNjLzkuVaEfTYwCbhegtWO JoWgWEHKMpkeOadbbkLgIsuWZgn;

			public RectTransform EClUtgkBDIrQAoonSxfqnhukeCw;

			public Vector2 gFOrKBmWQDRpQFykpcwnHeySCVK;

			public float IrGauKodcYmdzQzsBInitacHBjH;

			public float ffsBVOrOwLHAQIiRApspKVvozxB;

			public float ZmsPJcNCnjBWVfdlsGEezmwHxqgu;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			private bool MoveNext()
			{
				int num;
				int num4;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				default:
					num = 1036473917;
					goto IL_001a;
				case 0:
					goto IL_0074;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1036473908;
						goto IL_001a;
					}
					IL_001a:
					while (true)
					{
						switch (num ^ 0x3DC75635)
						{
						case 6:
							break;
						case 3:
							goto IL_0056;
						case 7:
							goto IL_0074;
						case 1:
							goto IL_0099;
						case 4:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.shENDFotJKEDucBZRyRFORLMigTa(JoWgWEHKMpkeOadbbkLgIsuWZgn, gbejOQIayEZKbGyCZpFoaaiiUxS, oDHiqonMoiufKKpGJbNyiKpUZHE);
							num = 1036473916;
							continue;
						case 5:
							LOMeYMhHKyjSwUDqvWYJlrErQKH.UprvgqxthkUgaQeUXArWMBZlDPh(EClUtgkBDIrQAoonSxfqnhukeCw, Vector2.Lerp(gFOrKBmWQDRpQFykpcwnHeySCVK, gbejOQIayEZKbGyCZpFoaaiiUxS, Mathf.SmoothStep(0f, 1f, ZmsPJcNCnjBWVfdlsGEezmwHxqgu)), oDHiqonMoiufKKpGJbNyiKpUZHE);
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = null;
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 0:
							ZmsPJcNCnjBWVfdlsGEezmwHxqgu += Time.unscaledDeltaTime / ffsBVOrOwLHAQIiRApspKVvozxB;
							num = 1036473904;
							continue;
						case 2:
							EClUtgkBDIrQAoonSxfqnhukeCw = syCPfFbHYMDOvEPjTnPLBqiOhsPv.rectTransform;
							gFOrKBmWQDRpQFykpcwnHeySCVK = LOMeYMhHKyjSwUDqvWYJlrErQKH.RHSfXhsPjZpvTnuaRtDNJQoXDno(EClUtgkBDIrQAoonSxfqnhukeCw, oDHiqonMoiufKKpGJbNyiKpUZHE);
							IrGauKodcYmdzQzsBInitacHBjH = (gbejOQIayEZKbGyCZpFoaaiiUxS - gFOrKBmWQDRpQFykpcwnHeySCVK).magnitude;
							num = 1036473910;
							continue;
						case 8:
							num = 1036473916;
							continue;
						case 10:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv._isMoving = true;
							ffsBVOrOwLHAQIiRApspKVvozxB = IrGauKodcYmdzQzsBInitacHBjH / juGAuHQJxyCbGveDiDRabDWTpiv;
							ZmsPJcNCnjBWVfdlsGEezmwHxqgu = 0f;
							num = 1036473908;
							continue;
						default:
							return false;
						}
						break;
						IL_0099:
						int num2;
						if (!(ZmsPJcNCnjBWVfdlsGEezmwHxqgu <= 1f))
						{
							num = 1036473905;
							num2 = num;
						}
						else
						{
							num = 1036473909;
							num2 = num;
						}
						continue;
						IL_0056:
						int num3;
						if (!(IrGauKodcYmdzQzsBInitacHBjH >= 0.01f))
						{
							num = 1036473905;
							num3 = num;
						}
						else
						{
							num = 1036473919;
							num3 = num;
						}
					}
					goto default;
					IL_0074:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (!(juGAuHQJxyCbGveDiDRabDWTpiv <= 0f))
					{
						num = 1036473911;
						num4 = num;
					}
					else
					{
						num = 1036473905;
						num4 = num;
					}
					goto IL_001a;
				}
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
			public MswgrqgGkcjYkfeUTdftXahdKceq(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
			}
		}

		private const float MAX_MOVE_SPEED = 20f;

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		private RectTransform _stickTransform;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The joystick's mode of operation. Set this to Digital to simulate a D-Pad which has only On/Off states. If you want mimic a real D-Pad, you should also set Snap Directions to 8.")]
		private JoystickMode _joystickMode;

		[CustomObfuscation(rename = false)]
		[Tooltip("A dead zone which is applied when Stick Mode is set to Digital. This is used to filter out tiny stick movements near 0, 0.")]
		[SerializeField]
		[Range(0f, 1f)]
		private float _digitalModeDeadZone = 0.3f;

		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[Range(0.01f, 1000f)]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _stickRange = 60f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		[SerializeField]
		private bool _scaleStickRange = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The shape of the range of movement of the joystick.")]
		private StickBounds _stickBounds;

		[SerializeField]
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[CustomObfuscation(rename = false)]
		private AxisDirection _axesToUse;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
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
		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		private StandaloneAxis2D _axis2D = new StandaloneAxis2D();

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[SerializeField]
		[Tooltip("Should taps on the touch pad be processed?")]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		[FieldRange(0f, float.MaxValue)]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _tapTimeout = 0.25f;

		[FieldRange(-1, int.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		private int _tapDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the joystick's RectTransform. This can be useful if you want a larger area of the screen to act as a joystick.")]
		private TouchRegion _touchRegion;

		[SerializeField]
		[Tooltip("If True, hovers/clicks/touches on the local joystick will be ignored and only Touch Region touches will be used. Otherwise, both touches on the joystick and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[CustomObfuscation(rename = false)]
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

		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		private float _moveToTouchSpeed = 2f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		private bool _animateOnReturn = true;

		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private bool _useXAxis;

		private bool _useYAxis;

		private SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private wRCfymeNjLzkuVaEfTYwCbhegtWO _moveDirection;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool deteGKFsUpKVtiobsxDnfbVWHkL;

		[NonSerialized]
		private bool IflsmAOKUdJKTpCZjpeDsuqZbjM;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private jFqMitXzejUyLCwdAFdYbchMkpx _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private NIcCUdyQMDYZUZhyXqxbpJwMTqP _imageRaycastHelper = new NIcCUdyQMDYZUZhyXqxbpJwMTqP();

		private int _calculatedStickRange_lastUpdatedFrame = -1;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<wRCfymeNjLzkuVaEfTYwCbhegtWO> __moveStartedDelegate;

		private Action<wRCfymeNjLzkuVaEfTYwCbhegtWO> __moveEndedDelegate;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the joystick value changes.")]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[Tooltip("Event sent when the joystick's stick position changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ValueChangedEventHandler _onStickPositionChanged = new ValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the joystick is touched.")]
		[CustomObfuscation(rename = false)]
		private TouchStartedEventHandler _onTouchStarted = new TouchStartedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchEndedEventHandler _onTouchEnded = new TouchEndedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[CustomObfuscation(rename = false)]
		private TapEventHandler _onTap = new TapEventHandler();

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

		[CompilerGenerated]
		private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IValueChangedHandler, Vector2> CS_0024_003C_003E9__CachedAnonymousMethodDelegate8;

		[CompilerGenerated]
		private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IStickPositionChangedHandler, Vector2> CS_0024_003C_003E9__CachedAnonymousMethodDelegatea;

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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_joystickMode == value)
				{
					return;
				}
				while (true)
				{
					_joystickMode = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 1354460709;
					while (true)
					{
						switch (num ^ 0x50BB6E24)
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
						num = 1354460710;
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
				while (true)
				{
					int num = 998256229;
					while (true)
					{
						switch (num ^ 0x3B802E66)
						{
						case 2:
							break;
						case 3:
						{
							int num2;
							if (_digitalModeDeadZone != value)
							{
								num = 998256231;
								num2 = num;
							}
							else
							{
								num = 998256230;
								num2 = num;
							}
							continue;
						}
						case 0:
							return;
						default:
							_digitalModeDeadZone = value;
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_scaleStickRange == value)
				{
					return;
				}
				while (true)
				{
					_scaleStickRange = value;
					int num = 1112157912;
					while (true)
					{
						switch (num ^ 0x424A2ED8)
						{
						case 3:
							num = 1112157913;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = 1112157914;
							continue;
						case 2:
							return;
						}
						break;
					}
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
				if (_stickBounds == value)
				{
					return;
				}
				while (true)
				{
					_stickBounds = value;
					int num = 580590992;
					while (true)
					{
						switch (num ^ 0x229B1D90)
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
						num = 580590993;
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
					return;
				}
				while (true)
				{
					hHbXGUYunkblaqblvHADFikMHzF(value);
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 1897103530;
					while (true)
					{
						switch (num ^ 0x711380AA)
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
						num = 1897103531;
					}
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
				if (_snapDirections == value)
				{
					while (true)
					{
						switch (0x682B008A ^ 0x682B008B)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_snapDirections = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					goto IL_0009;
				}
				goto IL_0044;
				IL_0009:
				int num = -2065162352;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -2065162349)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						return;
					case 4:
						wWklIWMVIReShFCdZhfAVVyDQgX();
						num = -2065162350;
						continue;
					case 0:
						goto IL_0044;
					case 1:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0044:
				_activateOnSwipeIn = value;
				num = -2065162345;
				goto IL_000e;
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (yPLpJvfMgnznJgRUbpowGjMhQZr())
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
				int num = -28730973;
				goto IL_000e;
				IL_000e:
				switch (num ^ -28730975)
				{
				case 0:
					break;
				case 2:
					return;
				case 3:
					goto IL_0033;
				default:
					wWklIWMVIReShFCdZhfAVVyDQgX();
					return;
				}
				goto IL_0009;
				IL_0033:
				_stayActiveOnSwipeOut = value;
				num = -28730976;
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
				if (_allowTap != value)
				{
					_allowTap = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					int num = 778894862;
					while (true)
					{
						switch (num ^ 0x2E6CFE0C)
						{
						case 0:
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
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_0040:
						_tapTimeout = value;
						num = 778894863;
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					goto IL_000e;
				}
				goto IL_0041;
				IL_000e:
				int num = 845767780;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ 0x32696465)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						wWklIWMVIReShFCdZhfAVVyDQgX();
						num = 845767781;
						continue;
					case 4:
						goto IL_0041;
					case 1:
						return;
					case 0:
						return;
					}
					break;
				}
				goto IL_000e;
				IL_0041:
				_touchRegion = value;
				num = 845767782;
				goto IL_0013;
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_moveToTouchPosition == value)
				{
					return;
				}
				while (true)
				{
					_moveToTouchPosition = value;
					int num = 234366505;
					while (true)
					{
						switch (num ^ 0xDF82628)
						{
						case 0:
							goto IL_000a;
						case 2:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000a:
						num = 234366506;
					}
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 1271273596;
					while (true)
					{
						switch (num ^ 0x4BC6187C)
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
						num = 1271273597;
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
				if (_followTouchPosition != value)
				{
					_followTouchPosition = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					return;
				}
				while (true)
				{
					_moveToTouchSpeed = value;
					int num = -1057663533;
					while (true)
					{
						switch (num ^ -1057663534)
						{
						case 3:
							num = -1057663536;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = -1057663534;
							continue;
						case 0:
							return;
						}
						break;
					}
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					int num = 1005697538;
					while (true)
					{
						switch (num ^ 0x3BF1BA03)
						{
						case 0:
							num = 1005697536;
							continue;
						case 3:
							break;
						case 2:
							_imageRaycastHelper.tAgADqjTsMUxSqYXeDyJIdETYRAp();
							num = 1005697543;
							continue;
						case 1:
							if (value)
							{
								PXEXrnDRygAuZueqSOcmNrpLWNJ();
								num = 1005697543;
								continue;
							}
							goto case 2;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
					}
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

		private Action<wRCfymeNjLzkuVaEfTYwCbhegtWO> moveStartedDelegate
		{
			get
			{
				if (__moveStartedDelegate == null)
				{
					return __moveStartedDelegate = ygmgHpsoczoktCqokJEUBknCWlz;
				}
				return __moveStartedDelegate;
			}
		}

		private Action<wRCfymeNjLzkuVaEfTYwCbhegtWO> moveEndedDelegate
		{
			get
			{
				if (__moveEndedDelegate == null)
				{
					return __moveEndedDelegate = hMLWOTCnUeECHkZYcVMttLBlZZs;
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
				if (_lastClaimSource != jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr)
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
				RectTransform rectTransform2 = default(RectTransform);
				Vector3 lossyScale2 = default(Vector3);
				Vector3 lossyScale = default(Vector3);
				Vector3 a = default(Vector3);
				Vector3 vector = default(Vector3);
				float magnitude = default(float);
				while (true)
				{
					int num = -772842975;
					while (true)
					{
						switch (num ^ -772842968)
						{
						case 12:
							break;
						case 9:
							rectTransform2 = touchReferenceTransform;
							num = -772842976;
							continue;
						case 1:
							lossyScale2 = rectTransform2.lossyScale;
							if (lossyScale.x != 0f)
							{
								lossyScale2.x /= lossyScale.x;
								num = -772842973;
								continue;
							}
							goto case 11;
						case 5:
							num = -772842966;
							continue;
						case 6:
							if (_lastClaimSource == jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr)
							{
								lossyScale2.Scale(base.transform.localScale);
								num = -772842974;
								continue;
							}
							goto case 10;
						case 0:
						{
							a = rectTransform2.InverseTransformPoint(vector + rectTransform2.position);
							int num2;
							if (_scaleStickRange)
							{
								num = -772842961;
								num2 = num;
							}
							else
							{
								num = -772842964;
								num2 = num;
							}
							continue;
						}
						case 8:
						{
							Vector3 position = new Vector3(0f, _stickRange, 0f);
							vector = rectTransform.TransformPoint(position) - rectTransform.position;
							num = -772842968;
							continue;
						}
						case 4:
							magnitude = a.magnitude;
							num = -772842966;
							continue;
						case 3:
							if (lossyScale.z != 0f)
							{
								lossyScale2.z /= lossyScale.z;
								num = -772842962;
								continue;
							}
							goto case 6;
						case 7:
							lossyScale = rectTransform.lossyScale;
							num = -772842967;
							continue;
						case 10:
							magnitude = Vector3.Scale(a, lossyScale2).magnitude;
							num = -772842963;
							continue;
						case 11:
							if (lossyScale.y != 0f)
							{
								lossyScale2.y /= lossyScale.y;
								num = -772842965;
								continue;
							}
							goto case 3;
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

		internal static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IValueChangedHandler, Vector2> valueChangedHandlerDelegate
		{
			get
			{
				if (__valueChangedHandlerDelegate == null)
				{
					if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate8 == null)
					{
						goto IL_000e;
					}
					goto IL_0048;
				}
				goto IL_0059;
				IL_0059:
				return __valueChangedHandlerDelegate;
				IL_000e:
				int num = -878347115;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ -878347113)
					{
					case 0:
						break;
					case 2:
						CS_0024_003C_003E9__CachedAnonymousMethodDelegate8 = delegate(IValueChangedHandler P_0, Vector2 P_1)
						{
							P_0.OnValueChanged(P_1);
						};
						num = -878347114;
						continue;
					case 1:
						goto IL_0048;
					default:
						goto IL_0059;
					}
					break;
				}
				goto IL_000e;
				IL_0048:
				__valueChangedHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate8;
				num = -878347116;
				goto IL_0013;
			}
		}

		internal static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IStickPositionChangedHandler, Vector2> stickPositionChangedHandlerDelegate
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
				int num = 800077423;
				goto IL_0024;
				IL_004e:
				return __stickPositionChangedHandlerDelegate;
				IL_001f:
				num = 800077422;
				goto IL_0024;
				IL_0024:
				switch (num ^ 0x2FB0366F)
				{
				case 2:
					break;
				case 1:
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
				goto IL_0008;
			}
			goto IL_0081;
			IL_0008:
			int num = -1762087622;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1762087630)
				{
				case 11:
					break;
				default:
					return;
				case 6:
					goto IL_005d;
				case 14:
					goto IL_0081;
				case 2:
					goto IL_00c5;
				case 12:
					goto IL_011f;
				case 13:
					if (MathTools.IsNear(value.y, -1f, 0.0001f))
					{
						value.y = -1f;
						num = -1762087628;
						continue;
					}
					goto IL_005d;
				case 10:
					value.x = 1f;
					num = -1762087626;
					continue;
				case 4:
					goto IL_01a7;
				case 1:
					goto IL_01e1;
				case 7:
					value.x = -1f;
					num = -1762087626;
					continue;
				case 0:
					goto IL_0223;
				case 8:
					return;
				case 3:
					goto IL_023f;
				case 5:
					goto IL_026b;
				case 15:
					value.y = 1f;
					num = -1762087628;
					continue;
				case 9:
					return;
				}
				break;
				IL_026b:
				int num2;
				if (!MathTools.IsNear(value.x, -1f, 0.0001f))
				{
					num = -1762087626;
					num2 = num;
				}
				else
				{
					num = -1762087627;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_005d:
			if (!_useXAxis)
			{
				int num3;
				if (!_useYAxis)
				{
					num = -1762087621;
					num3 = num;
				}
				else
				{
					num = -1762087618;
					num3 = num;
				}
				goto IL_000d;
			}
			goto IL_011f;
			IL_01e1:
			int num4;
			if (!MathTools.IsNear(value.x, 1f, 0.0001f))
			{
				num = -1762087625;
				num4 = num;
			}
			else
			{
				num = -1762087624;
				num4 = num;
			}
			goto IL_000d;
			IL_023f:
			int num5;
			if (MathTools.IsNear(value.y, 1f, 0.0001f))
			{
				num = -1762087619;
				num5 = num;
			}
			else
			{
				num = -1762087617;
				num5 = num;
			}
			goto IL_000d;
			IL_01a7:
			if (value.y == 0f)
			{
				goto IL_005d;
			}
			if (MathTools.IsNearZero(value.y, 0.0001f))
			{
				value.y = 0f;
				num = -1762087628;
				goto IL_000d;
			}
			goto IL_023f;
			IL_0223:
			value.Normalize();
			num = -1762087632;
			goto IL_000d;
			IL_00c5:
			if (_snapDirections == SnapDirections.None)
			{
				goto IL_005d;
			}
			value = MathTools.SnapVectorToNearestAngle(value, 360f / (float)_snapDirections);
			if (value.x == 0f)
			{
				goto IL_01a7;
			}
			if (MathTools.IsNearZero(value.x, 0.0001f))
			{
				value.x = 0f;
				num = -1762087626;
				goto IL_000d;
			}
			goto IL_01e1;
			IL_011f:
			_axis2D.SetRawValue(_useXAxis ? value.x : 0f, _useYAxis ? value.y : 0f);
			num = -1762087621;
			goto IL_000d;
			IL_0081:
			if (_joystickMode != JoystickMode.Digital)
			{
				goto IL_00c5;
			}
			if (value.sqrMagnitude <= _digitalModeDeadZone * _digitalModeDeadZone)
			{
				value.x = 0f;
				value.y = 0f;
				num = -1762087632;
				goto IL_000d;
			}
			goto IL_0223;
		}

		public void SetDefaultPosition()
		{
			fFKLAVvYROMMQQhfhHNlftiOPJN(base.rectTransform.anchoredPosition);
		}

		private void fFKLAVvYROMMQQhfhHNlftiOPJN(Vector2 P_0)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x1EF89918 ^ 0x1EF8991A)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			_origAnchoredPosition = P_0;
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				WMSsfkMLKlhjcjelurBOcNZuvNX(_origAnchoredPosition, PositionType.WALjqDIkNzPxbhnsjcnYTAHDFKBY, !instant && _animateOnReturn, _returnSpeed, wRCfymeNjLzkuVaEfTYwCbhegtWO.ZHOJKsdjqeTbuCznzGjkgQECHhx);
				int num = 440824486;
				while (true)
				{
					switch (num ^ 0x1A4672A7)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 440824485;
				}
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
			if (!Application.isPlaying)
			{
				return;
			}
			while (true)
			{
				_origAnchoredPosition = base.rectTransform.anchoredPosition;
				int num = -1502537344;
				while (true)
				{
					switch (num ^ -1502537342)
					{
					case 0:
						num = -1502537343;
						continue;
					case 3:
						break;
					case 2:
						if (_stickTransform != null)
						{
							_origStickAnchoredPosition = _stickTransform.anchoredPosition;
							num = -1502537341;
							continue;
						}
						goto default;
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
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = 1805841233;
			goto IL_0013;
			IL_0013:
			switch (num ^ 0x6BA2F350)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0038;
			case 2:
				return;
			}
			goto IL_000e;
			IL_0038:
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
			num = 1805841234;
			goto IL_0013;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.initialized)
			{
				_axis2D.Deinitialize();
				QBogclsViwEODeiCNJnFOileABHD();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				xsDgFyTZvEgtPjzlBqGOyLVzBoa();
				int num = 1712154850;
				while (true)
				{
					switch (num ^ 0x660D68E3)
					{
					case 0:
						goto IL_000f;
					case 2:
						break;
					default:
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
						return;
					}
					break;
					IL_000f:
					num = 1712154849;
				}
			}
		}

		internal override void spiCZIbBixHwkYmPEBFXAXTGsXtO()
		{
			base.spiCZIbBixHwkYmPEBFXAXTGsXtO();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = -1179396998;
			goto IL_0013;
			IL_0013:
			switch (num ^ -1179397000)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 3:
				goto IL_0038;
			case 1:
				return;
			}
			goto IL_000e;
			IL_0038:
			XQGfZDfjhHBqlsRSwZXkemarOYM();
			UcvgzyHjPLrcamsdZskkPOQcONwi();
			rcqBXlFvThOIzUYEKRmQDTmyRyd();
			num = -1179396999;
			goto IL_0013;
		}

		internal override bool KeoQNyZvcuilfnGKgmHgqyJYGhr()
		{
			if (!base.KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				goto IL_0008;
			}
			xsDgFyTZvEgtPjzlBqGOyLVzBoa();
			_axis2D.Initialize();
			int num = 1738123734;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x6799A9D4)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_0008;
			IL_0008:
			num = 1738123733;
			goto IL_000d;
		}

		internal override void KhATpHHLaxfVykPnYPwsOWKYpr()
		{
			if (!base.initialized)
			{
				return;
			}
			while (hasController)
			{
				while (true)
				{
					IL_004a:
					Vector2 value = _axis2D.value;
					int num = -2037708943;
					while (true)
					{
						switch (num ^ -2037708937)
						{
						case 0:
							num = -2037708939;
							continue;
						default:
							return;
						case 2:
							break;
						case 5:
							goto IL_004a;
						case 4:
							if (_useYAxis)
							{
								fcpMokSOSPSkfIoeTHjUJvvymMbi(_verticalAxisCustomControllerElement, value.y, _axis2D.yAxis.buttonActivationThreshold);
								num = -2037708938;
								continue;
							}
							goto case 1;
						case 6:
							if (_useXAxis)
							{
								fcpMokSOSPSkfIoeTHjUJvvymMbi(_horizontalAxisCustomControllerElement, value.x, _axis2D.xAxis.buttonActivationThreshold);
								num = -2037708941;
								continue;
							}
							goto case 4;
						case 1:
							if (_allowTap)
							{
								fcpMokSOSPSkfIoeTHjUJvvymMbi(_tapCustomControllerElement, tapValue);
								num = -2037708940;
								continue;
							}
							return;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal override void NjkGaTSbjeAmPqdpyKMonMbyiMJ()
		{
			base.NjkGaTSbjeAmPqdpyKMonMbyiMJ();
			_axis2D.ValueChangedEvent += PmSBHqGtcObwsBsjhRGByRmNdVOn;
		}

		internal override void erHIwspAqyvfsFjxpigiGUNoawW()
		{
			base.erHIwspAqyvfsFjxpigiGUNoawW();
			_axis2D.ValueChangedEvent -= PmSBHqGtcObwsBsjhRGByRmNdVOn;
		}

		internal override void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			base.wWklIWMVIReShFCdZhfAVVyDQgX();
			while (true)
			{
				int num = -397436723;
				while (true)
				{
					switch (num ^ -397436724)
					{
					case 2:
						break;
					case 1:
					{
						int num2;
						if (base.initialized)
						{
							num = -397436724;
							num2 = num;
						}
						else
						{
							num = -397436721;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					default:
						xsDgFyTZvEgtPjzlBqGOyLVzBoa();
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
						return;
					}
					break;
				}
			}
		}

		internal override void QBogclsViwEODeiCNJnFOileABHD()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				int num = -1570720280;
				while (true)
				{
					switch (num ^ -1570720273)
					{
					case 8:
						num = -1570720275;
						continue;
					case 6:
						_isMovedFromDefaultPosition = false;
						_isMoving = false;
						_moveDirection = wRCfymeNjLzkuVaEfTYwCbhegtWO.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
						num = -1570720274;
						continue;
					case 10:
						_calculatedStickRange_lastUpdatedFrame = -1;
						_lastTapFrame = -1;
						_isEligibleForTap = false;
						num = -1570720277;
						continue;
					case 3:
						_lastPressStartingValue = Vector2.zero;
						num = -1570720283;
						continue;
					case 5:
						ReturnToDefaultPosition(instant: true);
						num = -1570720279;
						continue;
					case 0:
						IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
						_pointerDownIsFake = false;
						_lastPressAnchoredPosition = Vector2.zero;
						num = -1570720276;
						continue;
					case 4:
						if (!_returnOnRelease || !_isMovedFromDefaultPosition)
						{
							goto case 6;
						}
						if (!_moveToTouchPosition)
						{
							int num2;
							if (!_followTouchPosition)
							{
								num = -1570720279;
								num2 = num;
							}
							else
							{
								num = -1570720278;
								num2 = num;
							}
							continue;
						}
						goto case 5;
					case 7:
						deteGKFsUpKVtiobsxDnfbVWHkL = false;
						num = -1570720273;
						continue;
					case 2:
						break;
					case 1:
						KcecMEVnboRrodQNOWiPXeBBDUA();
						_axis2D.Clear();
						num = -1570720282;
						continue;
					default:
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
						return;
					}
					break;
				}
			}
		}

		internal override void bDqKNfDLkzsEdxLPBgplGtPGTwPI()
		{
			base.bDqKNfDLkzsEdxLPBgplGtPGTwPI();
			if (_hierarchyValueChangedHandlers == null)
			{
				_hierarchyValueChangedHandlers = new SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IValueChangedHandler, Vector2>(valueChangedHandlerDelegate);
				goto IL_001e;
			}
			goto IL_0044;
			IL_0044:
			_hierarchyValueChangedHandlers.GetHandlers(base.transform);
			int num;
			int num2;
			if (_hierarchyStickPositionChangedHandlers == null)
			{
				num = -1733279909;
				num2 = num;
			}
			else
			{
				num = -1733279908;
				num2 = num;
			}
			goto IL_0023;
			IL_001e:
			num = -1733279910;
			goto IL_0023;
			IL_0023:
			while (true)
			{
				switch (num ^ -1733279912)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_0044;
				case 3:
					_hierarchyStickPositionChangedHandlers = new SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IStickPositionChangedHandler, Vector2>(stickPositionChangedHandlerDelegate);
					num = -1733279908;
					continue;
				case 4:
					_hierarchyStickPositionChangedHandlers.GetHandlers(base.transform);
					num = -1733279911;
					continue;
				case 1:
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
				return;
			}
			while (true)
			{
				_axis2D.Clear();
				int num = -2038954943;
				while (true)
				{
					switch (num ^ -2038954941)
					{
					case 0:
						num = -2038954937;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						_lastTapFrame = -1;
						num = -2038954942;
						continue;
					case 1:
						if (hasController)
						{
							base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
							base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
							base.controller.ClearElementValue(_tapCustomControllerElement);
							num = -2038954944;
							continue;
						}
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal override bool EfomNIIerZfdReJWaymsEQFbGDuv()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				return false;
			}
			return deteGKFsUpKVtiobsxDnfbVWHkL;
		}

		internal override bool NwAEhJMhIkbNQQjjHtkiYeNJUED(GameObject P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (base.NwAEhJMhIkbNQQjjHtkiYeNJUED(P_0))
			{
				return true;
			}
			if (_workingTouchRegion != null)
			{
				return _workingTouchRegion.gameObject == P_0;
			}
			return false;
		}

		private void NPOFSRfAiJHJstoMPmTkHgTRYCc()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			while (true)
			{
				int num = 781483201;
				while (true)
				{
					switch (num ^ 0x2E947CC0)
					{
					case 0:
						break;
					case 1:
						goto IL_0029;
					default:
						rcqBXlFvThOIzUYEKRmQDTmyRyd();
						PXEXrnDRygAuZueqSOcmNrpLWNJ();
						return;
					}
					break;
					IL_0029:
					_verticalAxisCustomControllerElement.ClearElementCaches();
					_tapCustomControllerElement.ClearElementCaches();
					num = 781483202;
				}
			}
		}

		private void PXEXrnDRygAuZueqSOcmNrpLWNJ()
		{
			if (!_manageRaycasting)
			{
				while (true)
				{
					switch (-1933298870 ^ -1933298869)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			_imageRaycastHelper.PdlrGNXpCBECJtKEwhNmSCcHIIa(base.transform, dpUcCTWbxZTIQEahDbeeBsyhVEX());
		}

		private bool dpUcCTWbxZTIQEahDbeeBsyhVEX()
		{
			if (_workingTouchRegion != null)
			{
				while (true)
				{
					int num = -1744584069;
					while (true)
					{
						switch (num ^ -1744584070)
						{
						case 0:
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
						num = -1744584072;
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			return true;
		}

		private void WwYJCDMlbisayAqaWBeBNPJzvOX(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				WdJoLlSYdebiQOSJXPJdQvBdeZx(P_0);
				int num = 1936843785;
				while (true)
				{
					switch (num ^ 0x7371E40C)
					{
					case 0:
						num = 1936843784;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						P_0.PointerExitEvent += shdDotNgJorBUprfkABOaHDWPST;
						P_0.BeginDragEvent += xJxFJgGwAWqWMgZurBGAeWiYmDST;
						P_0.DragEvent += ThBAEvkIIHcjifCMBUiowuuGLkXn;
						num = 1936843789;
						continue;
					case 1:
						P_0.EndDragEvent += EmLweaNiZSWHijBoXhegrWJzeze;
						num = 1936843791;
						continue;
					case 5:
						P_0.PointerDownEvent += AyoEjrMMNOOkuaSctItwyzHQsaJ;
						P_0.PointerUpEvent += pCiTtuZbGZMrbTGZfOtwxRNbNRF;
						P_0.PointerEnterEvent += hlqIuMOCvpmOFxFCvgLNQJHJcCdE;
						num = 1936843790;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void WdJoLlSYdebiQOSJXPJdQvBdeZx(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				P_0.PointerDownEvent -= AyoEjrMMNOOkuaSctItwyzHQsaJ;
				int num = -281430552;
				while (true)
				{
					switch (num ^ -281430549)
					{
					case 0:
						num = -281430545;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						P_0.DragEvent -= ThBAEvkIIHcjifCMBUiowuuGLkXn;
						P_0.EndDragEvent -= EmLweaNiZSWHijBoXhegrWJzeze;
						num = -281430546;
						continue;
					case 1:
						P_0.PointerEnterEvent -= hlqIuMOCvpmOFxFCvgLNQJHJcCdE;
						P_0.PointerExitEvent -= shdDotNgJorBUprfkABOaHDWPST;
						P_0.BeginDragEvent -= xJxFJgGwAWqWMgZurBGAeWiYmDST;
						num = -281430551;
						continue;
					case 3:
						P_0.PointerUpEvent -= pCiTtuZbGZMrbTGZfOtwxRNbNRF;
						num = -281430550;
						continue;
					case 5:
						return;
					}
					break;
				}
			}
		}

		private void rcqBXlFvThOIzUYEKRmQDTmyRyd()
		{
			if (_workingTouchRegion == _touchRegion)
			{
				return;
			}
			while (true)
			{
				WdJoLlSYdebiQOSJXPJdQvBdeZx(_workingTouchRegion);
				int num = -198011262;
				while (true)
				{
					switch (num ^ -198011263)
					{
					case 2:
						num = -198011264;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						_workingTouchRegion = _touchRegion;
						WwYJCDMlbisayAqaWBeBNPJzvOX(_workingTouchRegion);
						num = -198011263;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void YuLONUCioDONtByhpbAhNihDhuS(Vector2 P_0, bool P_1, float P_2, wRCfymeNjLzkuVaEfTYwCbhegtWO P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = default(Vector2);
			Vector2 pivot = default(Vector2);
			Vector2 sizeDelta = default(Vector2);
			while (true)
			{
				int num = -410342248;
				while (true)
				{
					switch (num ^ -410342247)
					{
					case 0:
						break;
					case 1:
						goto IL_002f;
					default:
					{
						Vector3 localScale = base.rectTransform.localScale;
						vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
						WMSsfkMLKlhjcjelurBOcNZuvNX(vector, PositionType.AXriQuEBFZCYarVPplCATARGxpw, P_1, P_2, P_3);
						return;
					}
					}
					break;
					IL_002f:
					vector = LOMeYMhHKyjSwUDqvWYJlrErQKH.wNaIZGSpgwpXpwwUzSBRpejVUBJ(base.canvas, rectTransform, P_0);
					pivot = base.rectTransform.pivot;
					sizeDelta = base.rectTransform.sizeDelta;
					num = -410342245;
				}
			}
		}

		private void WMSsfkMLKlhjcjelurBOcNZuvNX(Vector2 P_0, PositionType P_1, bool P_2, float P_3, wRCfymeNjLzkuVaEfTYwCbhegtWO P_4)
		{
			if (_isMoving && P_2)
			{
				goto IL_0011;
			}
			goto IL_00c8;
			IL_0239:
			int num;
			int num2;
			if (!(base.canvas == null))
			{
				num = -2071262241;
				num2 = num;
			}
			else
			{
				num = -2071262255;
				num2 = num;
			}
			goto IL_0016;
			IL_0011:
			num = -2071262271;
			goto IL_0016;
			IL_0016:
			Transform parent = default(Transform);
			RectTransform rectTransform = default(RectTransform);
			Vector2 one = default(Vector2);
			bool flag = default(bool);
			Vector2 sizeDelta = default(Vector2);
			float num3 = default(float);
			float num4 = default(float);
			while (true)
			{
				switch (num ^ -2071262251)
				{
				case 12:
					break;
				default:
					return;
				case 11:
					_isMovedFromDefaultPosition = true;
					num = -2071262251;
					continue;
				case 2:
					if (P_2)
					{
						parent = base.transform;
						rectTransform = base.canvasTransform;
						one = Vector2.one;
						num = -2071262246;
						continue;
					}
					goto case 16;
				case 13:
					flag = sizeDelta.x < sizeDelta.y;
					num = -2071262268;
					continue;
				case 7:
					goto IL_00c8;
				case 17:
					goto IL_00fc;
				case 6:
					P_3 = P_3 / num3 * num4;
					_coroutineMove = IqFGDnenIQKacibNEdiWcGInRzSU(P_0, P_1, P_3, P_4);
					StartCoroutine(_coroutineMove);
					_moveDirection = P_4;
					num = -2071262242;
					continue;
				case 1:
					P_2 = false;
					num = -2071262249;
					continue;
				case 9:
					if (!(parent == null))
					{
						one.x *= parent.localScale.x;
						one.y *= parent.localScale.y;
						num = -2071262246;
						continue;
					}
					goto case 3;
				case 19:
					shENDFotJKEDucBZRyRFORLMigTa(P_4, P_0, P_1);
					num = -2071262256;
					continue;
				case 20:
					if (_moveDirection == P_4)
					{
						return;
					}
					goto IL_00c8;
				case 8:
					num3 = 0.0001f;
					num = -2071262253;
					continue;
				case 16:
					moveStartedDelegate(P_4);
					num = -2071262266;
					continue;
				case 3:
					sizeDelta = rectTransform.sizeDelta;
					num = -2071262248;
					continue;
				case 14:
					goto IL_0239;
				case 10:
					if (base.canvas.renderMode == RenderMode.WorldSpace)
					{
						Logger.LogWarning("Animation can only be used with a screen space Canvas.");
						num = -2071262265;
						continue;
					}
					goto case 2;
				case 15:
					goto IL_0280;
				case 4:
					Logger.LogWarning("Animation cannot be used without a Canvas.");
					num = -2071262252;
					continue;
				case 18:
					P_2 = false;
					num = -2071262249;
					continue;
				case 0:
					moveStartedDelegate(P_4);
					return;
				case 5:
					return;
				}
				break;
				IL_0280:
				int num5;
				if (!((parent = parent.parent) != rectTransform))
				{
					num = -2071262250;
					num5 = num;
				}
				else
				{
					num = -2071262244;
					num5 = num;
				}
				continue;
				IL_00fc:
				num4 = MathTools.Max(sizeDelta.x, sizeDelta.y);
				num3 = (flag ? one.y : one.x);
				int num6;
				if (num3 == 0f)
				{
					num = -2071262243;
					num6 = num;
				}
				else
				{
					num = -2071262253;
					num6 = num;
				}
			}
			goto IL_0011;
			IL_00c8:
			if (_isMoving && _coroutineMove != null)
			{
				KcecMEVnboRrodQNOWiPXeBBDUA();
				_isMoving = false;
				_moveDirection = wRCfymeNjLzkuVaEfTYwCbhegtWO.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
				num = -2071262245;
				goto IL_0016;
			}
			goto IL_0239;
		}

		private IEnumerator IqFGDnenIQKacibNEdiWcGInRzSU(Vector2 P_0, PositionType P_1, float P_2, wRCfymeNjLzkuVaEfTYwCbhegtWO P_3)
		{
			MswgrqgGkcjYkfeUTdftXahdKceq mswgrqgGkcjYkfeUTdftXahdKceq = new MswgrqgGkcjYkfeUTdftXahdKceq(0);
			mswgrqgGkcjYkfeUTdftXahdKceq.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			while (true)
			{
				int num = -1836802666;
				while (true)
				{
					switch (num ^ -1836802665)
					{
					case 2:
						break;
					case 1:
						goto IL_002c;
					default:
						return mswgrqgGkcjYkfeUTdftXahdKceq;
					}
					break;
					IL_002c:
					mswgrqgGkcjYkfeUTdftXahdKceq.gbejOQIayEZKbGyCZpFoaaiiUxS = P_0;
					mswgrqgGkcjYkfeUTdftXahdKceq.oDHiqonMoiufKKpGJbNyiKpUZHE = P_1;
					mswgrqgGkcjYkfeUTdftXahdKceq.juGAuHQJxyCbGveDiDRabDWTpiv = P_2;
					mswgrqgGkcjYkfeUTdftXahdKceq.JoWgWEHKMpkeOadbbkLgIsuWZgn = P_3;
					num = -1836802665;
				}
			}
		}

		private void shENDFotJKEDucBZRyRFORLMigTa(wRCfymeNjLzkuVaEfTYwCbhegtWO P_0, Vector2 P_1, PositionType P_2)
		{
			LOMeYMhHKyjSwUDqvWYJlrErQKH.UprvgqxthkUgaQeUXArWMBZlDPh(base.rectTransform, P_1, P_2);
			_isMoving = false;
			_moveDirection = wRCfymeNjLzkuVaEfTYwCbhegtWO.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
			while (true)
			{
				int num = -1543257864;
				while (true)
				{
					switch (num ^ -1543257863)
					{
					case 2:
						break;
					case 1:
						if (P_0 == wRCfymeNjLzkuVaEfTYwCbhegtWO.ZHOJKsdjqeTbuCznzGjkgQECHhx)
						{
							_isMovedFromDefaultPosition = false;
							num = -1543257863;
							continue;
						}
						goto case 3;
					case 3:
						if (P_0 == wRCfymeNjLzkuVaEfTYwCbhegtWO.yrNPjkUJApZCVhMgUIDiTGAJeil)
						{
							_isMovedFromDefaultPosition = true;
							num = -1543257863;
							continue;
						}
						goto default;
					default:
						KcecMEVnboRrodQNOWiPXeBBDUA();
						moveEndedDelegate(P_0);
						return;
					}
					break;
				}
			}
		}

		private void ygmgHpsoczoktCqokJEUBknCWlz(wRCfymeNjLzkuVaEfTYwCbhegtWO P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag = default(bool);
			bool flag2 = default(bool);
			while (true)
			{
				int num = 743133502;
				while (true)
				{
					switch (num ^ 0x2C4B513F)
					{
					case 3:
						break;
					default:
						return;
					case 5:
						flag = true;
						flag2 = false;
						num = 743133496;
						continue;
					case 7:
						if (flag)
						{
							_imageRaycastHelper.PdlrGNXpCBECJtKEwhNmSCcHIIa(base.transform, flag2);
							num = 743133497;
							continue;
						}
						return;
					case 2:
						if (!_followTouchPosition)
						{
							int num3;
							if (!(_workingTouchRegion != null))
							{
								num = 743133496;
								num3 = num;
							}
							else
							{
								num = 743133499;
								num3 = num;
							}
							continue;
						}
						goto case 7;
					case 1:
						flag = false;
						flag2 = false;
						if (_followTouchPosition)
						{
							int num5;
							if (!stayActiveOnSwipeOut)
							{
								num = 743133501;
								num5 = num;
							}
							else
							{
								num = 743133503;
								num5 = num;
							}
							continue;
						}
						goto case 2;
					case 0:
						if (_returnOnRelease)
						{
							int num6;
							if (P_0 != wRCfymeNjLzkuVaEfTYwCbhegtWO.yrNPjkUJApZCVhMgUIDiTGAJeil)
							{
								num = 743133496;
								num6 = num;
							}
							else
							{
								num = 743133498;
								num6 = num;
							}
							continue;
						}
						goto case 7;
					case 8:
					{
						int num4;
						if (!_moveToTouchPosition)
						{
							num = 743133496;
							num4 = num;
						}
						else
						{
							num = 743133503;
							num4 = num;
						}
						continue;
					}
					case 4:
					{
						int num2;
						if (_useTouchRegionOnly)
						{
							num = 743133496;
							num2 = num;
						}
						else
						{
							num = 743133495;
							num2 = num;
						}
						continue;
					}
					case 6:
						return;
					}
					break;
				}
			}
		}

		private void hMLWOTCnUeECHkZYcVMttLBlZZs(wRCfymeNjLzkuVaEfTYwCbhegtWO P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag = false;
			bool flag2 = default(bool);
			while (true)
			{
				int num = -1540719784;
				while (true)
				{
					switch (num ^ -1540719780)
					{
					case 7:
						break;
					default:
						return;
					case 2:
					{
						int num3;
						if (!_returnOnRelease)
						{
							num = -1540719783;
							num3 = num;
						}
						else
						{
							num = -1540719780;
							num3 = num;
						}
						continue;
					}
					case 0:
						if (P_0 == wRCfymeNjLzkuVaEfTYwCbhegtWO.ZHOJKsdjqeTbuCznzGjkgQECHhx)
						{
							flag = true;
							flag2 = dpUcCTWbxZTIQEahDbeeBsyhVEX();
							num = -1540719783;
							continue;
						}
						goto case 5;
					case 6:
					{
						int num5;
						if (!_moveToTouchPosition)
						{
							num = -1540719783;
							num5 = num;
						}
						else
						{
							num = -1540719778;
							num5 = num;
						}
						continue;
					}
					case 5:
						if (flag)
						{
							_imageRaycastHelper.PdlrGNXpCBECJtKEwhNmSCcHIIa(base.transform, flag2);
							num = -1540719777;
							continue;
						}
						return;
					case 1:
						if (!_followTouchPosition && _workingTouchRegion != null)
						{
							int num4;
							if (!_useTouchRegionOnly)
							{
								num = -1540719782;
								num4 = num;
							}
							else
							{
								num = -1540719783;
								num4 = num;
							}
							continue;
						}
						goto case 5;
					case 4:
						flag2 = false;
						if (_followTouchPosition)
						{
							int num2;
							if (!stayActiveOnSwipeOut)
							{
								num = -1540719779;
								num2 = num;
							}
							else
							{
								num = -1540719778;
								num2 = num;
							}
							continue;
						}
						goto case 1;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void KcecMEVnboRrodQNOWiPXeBBDUA()
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

		private void xdUAfaJdefyUTchrjmQTwhnQniy(int P_0, Vector2 P_1, PositionType P_2)
		{
			if (!TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(P_0))
			{
				return;
			}
			while (true)
			{
				WMSsfkMLKlhjcjelurBOcNZuvNX((Vector2)LOMeYMhHKyjSwUDqvWYJlrErQKH.RHSfXhsPjZpvTnuaRtDNJQoXDno(base.rectTransform, P_2) + P_1, P_2, false, 0f, wRCfymeNjLzkuVaEfTYwCbhegtWO.yrNPjkUJApZCVhMgUIDiTGAJeil);
				int num;
				int num2;
				if (_lastClaimSource == jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr)
				{
					num = -630321999;
					num2 = num;
				}
				else
				{
					num = -630322000;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -630321998)
					{
					case 0:
						num = -630321997;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						_lastPressAnchoredPosition += P_1;
						num = -630322000;
						continue;
					case 2:
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
			PointerEventData pointerEventData = default(PointerEventData);
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
				{
					num = -131672336;
					num2 = num;
				}
				else
				{
					num = -131672332;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -131672330)
					{
					case 3:
						num = -131672334;
						continue;
					default:
						return;
					case 5:
						yexpQprndcKAWRDGCPOiDjHZJQS(pointerEventData);
						num = -131672335;
						continue;
					case 2:
						if (_pointerDownIsFake)
						{
							PointerEventData pointerEventData2 = IOvmMzhsiknEPdURAICYdMNvgPQ(effectivePointerId, (_workingTouchRegion != null && _useTouchRegionOnly) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
							if (pointerEventData2 != null)
							{
								nYhBjmkyAksLnmRnYZANDzUlWpM(pointerEventData2, _lastClaimSource);
								num = -131672330;
								continue;
							}
						}
						return;
					case 1:
						lpCghgdvtFwpLBkUsSpPyavhpiK();
						return;
					case 4:
						break;
					case 8:
						if (pointerEventData != null)
						{
							int num3;
							if (!(pointerEventData.pointerPress != null))
							{
								num = -131672329;
								num3 = num;
							}
							else
							{
								num = -131672333;
								num3 = num;
							}
							continue;
						}
						goto case 1;
					case 6:
						pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(effectivePointerId);
						num = -131672322;
						continue;
					case 7:
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void XQGfZDfjhHBqlsRSwZXkemarOYM()
		{
			if (!hasPointer)
			{
				while (true)
				{
					switch (-1586850448 ^ -1586850446)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			Vector2 vector = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(effectivePointerId);
			hmpcDbRPfUQzhTrCSArvmjJPrsM(ref vector);
		}

		private void hmpcDbRPfUQzhTrCSArvmjJPrsM(ref Vector2 P_0)
		{
			if (!_allowTap)
			{
				return;
			}
			while (true)
			{
				int num = 317219058;
				while (true)
				{
					switch (num ^ 0x12E860F6)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						_isEligibleForTap = false;
						num = 317219060;
						continue;
					case 1:
						if (_tapTimeout > 0f)
						{
							int num4;
							if (!(Time.realtimeSinceStartup - _touchStartTime <= _tapTimeout))
							{
								num = 317219061;
								num4 = num;
							}
							else
							{
								num = 317219056;
								num4 = num;
							}
							continue;
						}
						goto case 6;
					case 5:
						return;
					case 6:
						if (_tapDistanceLimit >= 0)
						{
							int num3;
							if (Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)
							{
								num = 317219061;
								num3 = num;
							}
							else
							{
								num = 317219060;
								num3 = num;
							}
							continue;
						}
						return;
					case 4:
					{
						int num2;
						if (_isEligibleForTap)
						{
							num = 317219063;
							num2 = num;
						}
						else
						{
							num = 317219059;
							num2 = num;
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

		private bool yPLpJvfMgnznJgRUbpowGjMhQZr()
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

		private void OmMQSyoLmaJHYrXPeNoBnwkIRXA()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
			_lastClaimSource = jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw;
		}

		private bool rtBocUdjipCXKhkfukoKkICxgqh(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (_pointerId == int.MinValue)
			{
				goto IL_0017;
			}
			int num;
			if (_pointerId == P_0)
			{
				num = -1297360847;
				goto IL_001c;
			}
			if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
			IL_0017:
			num = -1297360846;
			goto IL_001c;
			IL_001c:
			switch (num ^ -1297360848)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return true;
			}
			goto IL_0017;
		}

		private PointerEventData VeJANUaZIhfuukBBgCAhDSXJcuGp(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(P_0);
			if (pointerEventData == null)
			{
				goto IL_000e;
			}
			GameObject gameObject = P_1;
			pointerEventData.position = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(P_0);
			int num;
			if (TouchInteractable.MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				num = -1567306443;
				goto IL_0013;
			}
			goto IL_00eb;
			IL_02c4:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			return null;
			IL_00eb:
			if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				pointerEventData.dragging = false;
				num = -1567306435;
				goto IL_0013;
			}
			goto IL_02c4;
			IL_000e:
			num = -1567306433;
			goto IL_0013;
			IL_0013:
			GameObject gameObject3 = default(GameObject);
			float unscaledTime2 = default(float);
			GameObject gameObject2 = default(GameObject);
			float unscaledTime = default(float);
			while (true)
			{
				switch (num ^ -1567306446)
				{
				case 10:
					break;
				case 1:
					pointerEventData.clickCount = 1;
					num = -1567306442;
					continue;
				case 15:
					pointerEventData.useDragThreshold = true;
					pointerEventData.pressPosition = pointerEventData.position;
					pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
					gameObject3 = P_1;
					unscaledTime2 = Time.unscaledTime;
					if (gameObject3 == pointerEventData.lastPress)
					{
						float num3 = unscaledTime2 - pointerEventData.clickTime;
						if (num3 < 0.3f)
						{
							pointerEventData.clickCount++;
							num = -1567306444;
							continue;
						}
						goto case 12;
					}
					goto case 14;
				case 8:
					goto IL_00eb;
				case 18:
					pointerEventData.clickCount = 1;
					num = -1567306437;
					continue;
				case 4:
					pointerEventData.pointerPress = gameObject2;
					num = -1567306463;
					continue;
				case 19:
					pointerEventData.rawPointerPress = gameObject;
					num = -1567306441;
					continue;
				case 3:
					pointerEventData.pointerPress = gameObject3;
					pointerEventData.rawPointerPress = gameObject;
					pointerEventData.clickTime = unscaledTime2;
					num = -1567306462;
					continue;
				case 7:
					pointerEventData.dragging = false;
					pointerEventData.useDragThreshold = true;
					pointerEventData.pressPosition = pointerEventData.position;
					pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
					if (pointerEventData.pointerEnter != gameObject)
					{
						pointerEventData.pointerEnter = gameObject;
						num = -1567306439;
						continue;
					}
					goto case 11;
				case 12:
					pointerEventData.clickCount = 1;
					num = -1567306444;
					continue;
				case 9:
					pointerEventData.clickTime = unscaledTime;
					num = -1567306442;
					continue;
				case 14:
					pointerEventData.clickCount = 1;
					num = -1567306447;
					continue;
				case 6:
					pointerEventData.clickTime = unscaledTime2;
					num = -1567306447;
					continue;
				case 13:
					return null;
				case 11:
				{
					gameObject2 = P_1;
					unscaledTime = Time.unscaledTime;
					if (!(gameObject2 == pointerEventData.lastPress))
					{
						goto case 1;
					}
					float num2 = unscaledTime - pointerEventData.clickTime;
					if (num2 < 0.3f)
					{
						pointerEventData.clickCount++;
						num = -1567306437;
						continue;
					}
					goto case 18;
				}
				case 16:
					pointerEventData.pointerDrag = gameObject;
					num = -1567306448;
					continue;
				case 5:
					pointerEventData.clickTime = unscaledTime;
					pointerEventData.pointerDrag = gameObject;
					num = -1567306446;
					continue;
				default:
					goto IL_02c4;
				case 0:
				case 2:
					return pointerEventData;
				}
				break;
			}
			goto IL_000e;
		}

		private PointerEventData IOvmMzhsiknEPdURAICYdMNvgPQ(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(P_0);
			GameObject pointerDrag = default(GameObject);
			Vector2 vector = default(Vector2);
			while (true)
			{
				int num = -1822094925;
				while (true)
				{
					switch (num ^ -1822094927)
					{
					case 0:
						break;
					case 2:
						if (pointerEventData == null)
						{
							return null;
						}
						pointerDrag = P_1;
						vector = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(P_0);
						pointerEventData.delta = vector - pointerEventData.position;
						num = -1822094928;
						continue;
					case 4:
						pointerEventData.pointerDrag = pointerDrag;
						pointerEventData.useDragThreshold = true;
						num = -1822094926;
						continue;
					case 1:
						pointerEventData.position = vector;
						pointerEventData.dragging = true;
						num = -1822094923;
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
			while (true)
			{
				int num = 1748873095;
				while (true)
				{
					switch (num ^ 0x683DAF81)
					{
					case 4:
						break;
					case 6:
						if (pointerEventData == null)
						{
							return null;
						}
						if (TouchInteractable.MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
						{
							pointerEventData.eligibleForClick = false;
							num = 1748873097;
							continue;
						}
						goto case 1;
					case 0:
						Logger.LogWarning("Unsupported pointerId: " + P_0);
						num = 1748873090;
						continue;
					case 1:
						if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
						{
							pointerEventData.eligibleForClick = false;
							pointerEventData.pointerPress = null;
							num = 1748873091;
							continue;
						}
						goto case 0;
					case 8:
						pointerEventData.pointerPress = null;
						pointerEventData.rawPointerPress = null;
						num = 1748873092;
						continue;
					case 2:
						pointerEventData.rawPointerPress = null;
						pointerEventData.dragging = false;
						pointerEventData.pointerDrag = null;
						goto IL_00fe;
					case 5:
						pointerEventData.dragging = false;
						num = 1748873094;
						continue;
					case 7:
						pointerEventData.pointerDrag = null;
						pointerEventData.pointerEnter = null;
						goto IL_00fe;
					default:
						{
							return null;
						}
						IL_00fe:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private void yexpQprndcKAWRDGCPOiDjHZJQS(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = 2098000786;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x7D0CF393)
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
			WWBaWpsvmKBDDDdyzjqZKoKTVkj(effectivePointerId);
			num = 2098000787;
			goto IL_0008;
		}

		private void nYhBjmkyAksLnmRnYZANDzUlWpM(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				int num;
				if (P_1 == jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw)
				{
					OnDrag(P_0);
					num = 485700576;
					goto IL_0009;
				}
				goto IL_004c;
				IL_0009:
				while (true)
				{
					switch (num ^ 0x1CF333E1)
					{
					case 3:
						num = 485700579;
						continue;
					case 2:
						break;
					case 5:
						goto end_IL_002e;
					case 4:
						goto IL_004c;
					case 1:
						num = 485700577;
						continue;
					default:
						WWBaWpsvmKBDDDdyzjqZKoKTVkj(effectivePointerId);
						return;
					}
					break;
				}
				continue;
				IL_004c:
				if (P_1 != jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr)
				{
					break;
				}
				ThBAEvkIIHcjifCMBUiowuuGLkXn(P_0);
				num = 485700577;
				goto IL_0009;
				continue;
				end_IL_002e:
				break;
			}
			throw new NotImplementedException();
		}

		private PointerEventData eVclGdybysCFPcOarpTxhdEPClmv(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (__fakePointerEventData == null)
			{
				goto IL_0015;
			}
			goto IL_00a4;
			IL_011c:
			PointerEventData value = default(PointerEventData);
			return value;
			IL_0015:
			int num = 1849838565;
			goto IL_001a;
			IL_001a:
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			while (true)
			{
				switch (num ^ 0x6E424BEC)
				{
				case 0:
					break;
				case 3:
					value.button = button;
					num = 1849838569;
					continue;
				case 1:
					value.pointerId = P_0;
					__fakePointerEventData.Add(P_0, value);
					if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
					{
						switch (P_0)
						{
						case -2:
							goto IL_00c9;
						case -1:
							goto IL_00ef;
						case -3:
							goto IL_0110;
						}
						num = 1849838570;
						continue;
					}
					goto IL_011c;
				case 10:
					goto IL_00a4;
				case 8:
					goto IL_00c9;
				case 4:
					num = 1849838575;
					continue;
				case 6:
					throw new NotImplementedException();
				case 7:
					goto IL_00ef;
				case 9:
					__fakePointerEventData = new Dictionary<int, PointerEventData>();
					num = 1849838566;
					continue;
				case 2:
					goto IL_0110;
				default:
					goto IL_011c;
					IL_0110:
					button = PointerEventData.InputButton.Middle;
					num = 1849838575;
					continue;
					IL_00ef:
					button = PointerEventData.InputButton.Left;
					num = 1849838575;
					continue;
					IL_00c9:
					button = PointerEventData.InputButton.Right;
					num = 1849838568;
					continue;
				}
				break;
			}
			goto IL_0015;
			IL_00a4:
			if (!__fakePointerEventData.TryGetValue(P_0, out value))
			{
				value = new PointerEventData(EventSystem.current);
				num = 1849838573;
				goto IL_001a;
			}
			goto IL_011c;
		}

		private void xsDgFyTZvEgtPjzlBqGOyLVzBoa()
		{
			hHbXGUYunkblaqblvHADFikMHzF(_axesToUse);
			while (true)
			{
				int num = -332783092;
				while (true)
				{
					switch (num ^ -332783094)
					{
					case 5:
						break;
					default:
						return;
					case 7:
					{
						int num2;
						if (_useXAxis)
						{
							num = -332783090;
							num2 = num;
						}
						else
						{
							num = -332783095;
							num2 = num;
						}
						continue;
					}
					case 2:
						if (!base.touchController.useCustomController)
						{
							return;
						}
						goto case 7;
					case 3:
						if (_useYAxis)
						{
							base.controller.ValidateElements(_verticalAxisCustomControllerElement);
							num = -332783102;
							continue;
						}
						goto case 8;
					case 4:
						base.controller.ValidateElements(_horizontalAxisCustomControllerElement);
						num = -332783095;
						continue;
					case 0:
						base.controller.ValidateElements(_tapCustomControllerElement);
						num = -332783093;
						continue;
					case 6:
						if (!hasController)
						{
							return;
						}
						goto case 2;
					case 8:
					{
						int num3;
						if (_allowTap)
						{
							num = -332783094;
							num3 = num;
						}
						else
						{
							num = -332783093;
							num3 = num;
						}
						continue;
					}
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void hHbXGUYunkblaqblvHADFikMHzF(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag && hasController)
				{
					goto IL_002f;
				}
			}
			goto IL_0114;
			IL_002f:
			int num = 916660808;
			goto IL_0034;
			IL_0114:
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			int num2;
			if (_useYAxis == flag2)
			{
				num = 916660801;
				num2 = num;
			}
			else
			{
				num = 916660806;
				num2 = num;
			}
			goto IL_0034;
			IL_0034:
			int num3 = default(int);
			int targetCount2 = default(int);
			int num4 = default(int);
			int targetCount = default(int);
			while (true)
			{
				switch (num ^ 0x36A32240)
				{
				case 13:
					break;
				default:
					return;
				case 3:
					num3++;
					num = 916660804;
					continue;
				case 6:
					_useYAxis = flag2;
					num = 916660810;
					continue;
				case 12:
					goto IL_009d;
				case 8:
					targetCount2 = _horizontalAxisCustomControllerElement.targetCount;
					num = 916660807;
					continue;
				case 11:
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement[num4]);
					num = 916660815;
					continue;
				case 10:
					goto IL_00ec;
				case 1:
					_axesToUse = P_0;
					num = 916660800;
					continue;
				case 14:
					goto IL_0114;
				case 7:
					num3 = 0;
					num = 916660804;
					continue;
				case 15:
					num4++;
					num = 916660812;
					continue;
				case 9:
					if (hasController)
					{
						targetCount = _verticalAxisCustomControllerElement.targetCount;
						num4 = 0;
						num = 916660802;
						continue;
					}
					goto case 1;
				case 2:
					num = 916660812;
					continue;
				case 5:
					base.controller.ClearElementValue(_horizontalAxisCustomControllerElement[num3]);
					num = 916660803;
					continue;
				case 4:
					goto IL_01a5;
				case 0:
					return;
				}
				break;
				IL_01a5:
				int num5;
				if (num3 < targetCount2)
				{
					num = 916660805;
					num5 = num;
				}
				else
				{
					num = 916660814;
					num5 = num;
				}
				continue;
				IL_00ec:
				int num6;
				if (flag2)
				{
					num = 916660801;
					num6 = num;
				}
				else
				{
					num = 916660809;
					num6 = num;
				}
				continue;
				IL_009d:
				int num7;
				if (num4 >= targetCount)
				{
					num = 916660801;
					num7 = num;
				}
				else
				{
					num = 916660811;
					num7 = num;
				}
			}
			goto IL_002f;
		}

		private void VMPxCmwNDckEZjKzFAfOOLwMEyj(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0067;
			IL_0008:
			int num = 1883369414;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x7041EFC7)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					goto IL_0032;
				case 3:
					goto IL_0051;
				case 5:
					return;
				case 2:
					goto IL_0067;
				case 0:
					return;
				}
				break;
				IL_0032:
				int num2;
				if (!rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
				{
					num = 1883369410;
					num2 = num;
				}
				else
				{
					num = 1883369413;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0051:
			base.OnPointerDown(P_0);
			num = 1883369415;
			goto IL_000d;
			IL_0067:
			if (pmYjhUyltIKROfKAKRLTAORpQYO() && IsInteractable())
			{
				qttGoWavQZHOZLyJsMtdmpSFVQLR(P_0.pointerId, P_0.pressPosition, P_1);
				num = 1883369412;
				goto IL_000d;
			}
			goto IL_0051;
		}

		private void gkFDUotSecrQghkuzcszQbTklVO(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				goto IL_0016;
			}
			goto IL_004c;
			IL_004c:
			int num;
			int num2;
			if (TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
			{
				num = -1149089312;
				num2 = num;
			}
			else
			{
				num = -1149089307;
				num2 = num;
			}
			goto IL_001b;
			IL_0016:
			num = -1149089305;
			goto IL_001b;
			IL_001b:
			switch (num ^ -1149089308)
			{
			case 0:
				break;
			case 3:
				return;
			case 4:
				return;
			case 2:
				goto IL_004c;
			default:
				lpCghgdvtFwpLBkUsSpPyavhpiK();
				base.OnPointerUp(P_0);
				return;
			}
			goto IL_0016;
		}

		private void yVatkfTlebiCIFaVPbRrioxyjVJ(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				return;
			}
			MouseButtonFlags mouseButtonFlags = default(MouseButtonFlags);
			jFqMitXzejUyLCwdAFdYbchMkpx jFqMitXzejUyLCwdAFdYbchMkpx2 = default(jFqMitXzejUyLCwdAFdYbchMkpx);
			GameObject gameObject = default(GameObject);
			while (true)
			{
				bool flag = TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0.pointerId);
				bool flag2 = false;
				int num = 478737664;
				while (true)
				{
					switch (num ^ 0x1C88F502)
					{
					case 11:
						num = 478737676;
						continue;
					case 0:
						flag2 = true;
						num = 478737679;
						continue;
					case 5:
						throw new NotImplementedException();
					case 4:
						if (_activateOnSwipeIn && pmYjhUyltIKROfKAKRLTAORpQYO() && IsInteractable() && (!flag || TouchInteractable.oZwvzbhTHFLSrWQmffrxbbIJDii(mouseButtonFlags)) && !deteGKFsUpKVtiobsxDnfbVWHkL)
						{
							if (!flag)
							{
								goto case 0;
							}
							if (TouchInteractable.uvgPsLARFwGrvuIJCgcCjshzWDCu(mouseButtonFlags, out var realMousePointerId))
							{
								_realMousePointerId = realMousePointerId;
								num = 478737672;
								continue;
							}
							goto case 15;
						}
						goto case 13;
					case 15:
						_realMousePointerId = P_0.pointerId;
						num = 478737666;
						continue;
					case 17:
						num = 478737670;
						continue;
					case 6:
						switch (jFqMitXzejUyLCwdAFdYbchMkpx2)
						{
						case jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw:
							goto IL_0128;
						case jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr:
							goto IL_013a;
						}
						num = 478737682;
						continue;
					case 8:
						goto IL_0128;
					case 3:
						goto IL_013a;
					case 16:
						throw new NotImplementedException();
					case 9:
						num = 478737671;
						continue;
					case 14:
						break;
					case 10:
						num = 478737666;
						continue;
					case 1:
					{
						PointerEventData pointerEventData = VeJANUaZIhfuukBBgCAhDSXJcuGp((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
						if (pointerEventData != null)
						{
							VMPxCmwNDckEZjKzFAfOOLwMEyj(pointerEventData, P_1);
							if (deteGKFsUpKVtiobsxDnfbVWHkL)
							{
								_pointerDownIsFake = true;
								num = 478737669;
								continue;
							}
						}
						goto default;
					}
					case 12:
						mouseButtonFlags = _touchRegion.allowedMouseButtons;
						num = 478737670;
						continue;
					case 18:
						goto IL_01ee;
					case 13:
						base.OnPointerEnter(P_0);
						if (flag2)
						{
							jFqMitXzejUyLCwdAFdYbchMkpx2 = P_1;
							num = 478737668;
							continue;
						}
						goto default;
					case 2:
						switch (P_1)
						{
						case jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr:
							break;
						case jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw:
							goto IL_01ee;
						default:
							goto IL_0228;
						}
						goto case 12;
					default:
						{
							IflsmAOKUdJKTpCZjpeDsuqZbjM = true;
							return;
						}
						IL_0228:
						num = 478737675;
						continue;
						IL_01ee:
						mouseButtonFlags = base.allowedMouseButtons;
						num = 478737683;
						continue;
						IL_013a:
						gameObject = _workingTouchRegion.gameObject;
						num = 478737667;
						continue;
						IL_0128:
						gameObject = base.gameObject;
						num = 478737667;
						continue;
					}
					break;
				}
			}
		}

		private void UNMauMeXBncuatcyFyBICUuhBxd(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			while (true)
			{
				int num;
				if (!stayActiveOnSwipeOut)
				{
					int num2;
					if (!deteGKFsUpKVtiobsxDnfbVWHkL)
					{
						num = 956501822;
						num2 = num;
					}
					else
					{
						num = 956501823;
						num2 = num;
					}
					goto IL_0023;
				}
				goto IL_0065;
				IL_0023:
				while (true)
				{
					switch (num ^ 0x39030F3C)
					{
					case 0:
						num = 956501816;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						goto IL_0065;
					case 3:
						lpCghgdvtFwpLBkUsSpPyavhpiK();
						num = 956501822;
						continue;
					case 1:
						return;
					}
					break;
				}
				continue;
				IL_0065:
				base.OnPointerExit(P_0);
				IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
				num = 956501821;
				goto IL_0023;
			}
		}

		private void TpeATHihvrdIPCiOoSGtuyIVVtV(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (!hasPointer)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
				{
					num = -1367762236;
					num2 = num;
				}
				else
				{
					num = -1367762234;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1367762236)
					{
					case 3:
						num = -1367762240;
						continue;
					default:
						return;
					case 4:
						break;
					case 0:
						base.OnBeginDrag(P_0);
						num = -1367762235;
						continue;
					case 2:
						return;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void cKDJLuJFCwljceHvKSZhCcdNDOv(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (!hasPointer)
			{
				goto IL_000b;
			}
			goto IL_01c4;
			IL_000b:
			int num = 139925076;
			goto IL_0010;
			IL_0010:
			bool flag = default(bool);
			Vector2 vector3 = default(Vector2);
			Vector2 vector2 = default(Vector2);
			bool flag2 = default(bool);
			Vector2 vector4 = default(Vector2);
			Vector2 vector = default(Vector2);
			RectTransform rectTransform = default(RectTransform);
			while (true)
			{
				switch (num ^ 0x8571650)
				{
				case 6:
					break;
				default:
					return;
				case 12:
					goto IL_0080;
				case 11:
					base.OnDrag(P_0);
					num = 139925063;
					continue;
				case 0:
					if (_stickBounds == StickBounds.Square)
					{
						goto IL_00b5;
					}
					goto case 18;
				case 5:
					return;
				case 3:
				{
					Vector2 vector5 = new Vector2((_useXAxis && flag) ? (vector3.x - vector2.x) : 0f, (_useXAxis && flag2) ? (vector3.y - vector2.y) : 0f);
					xdUAfaJdefyUTchrjmQTwhnQniy(effectivePointerId, vector5, PositionType.WALjqDIkNzPxbhnsjcnYTAHDFKBY);
					num = 139925057;
					continue;
				}
				case 15:
					xdUAfaJdefyUTchrjmQTwhnQniy(effectivePointerId, vector4, PositionType.WALjqDIkNzPxbhnsjcnYTAHDFKBY);
					num = 139925083;
					continue;
				case 13:
					goto IL_0181;
				case 8:
					throw new NotImplementedException();
				case 18:
					throw new NotImplementedException();
				case 19:
					goto IL_01c4;
				case 22:
					vector = _lastPressAnchoredPosition;
					num = 139925074;
					continue;
				case 4:
					return;
				case 2:
					goto IL_0202;
				case 14:
					if (_followTouchPosition)
					{
						if (_stickBounds != StickBounds.Circle)
						{
							goto case 0;
						}
						if (vector3.sqrMagnitude > calculatedStickRange)
						{
							vector4 = new Vector2(_useXAxis ? (vector3.x - vector2.x) : 0f, _useXAxis ? (vector3.y - vector2.y) : 0f);
							num = 139925087;
							continue;
						}
					}
					goto case 11;
				case 10:
					vector2 = MathTools.Clamp(vector3, 0f - calculatedStickRange, calculatedStickRange);
					num = 139925060;
					continue;
				case 21:
					goto IL_02bd;
				case 20:
				{
					Vector2 rawValue = vector2 / calculatedStickRange;
					SetRawValue(rawValue);
					num = 139925086;
					continue;
				}
				case 16:
					goto IL_0350;
				case 9:
					vector = LOMeYMhHKyjSwUDqvWYJlrErQKH.jjbEkoGOuTdtgosBVVbDWrCUidFI(base.rectTransform, rectTransform, base.rectTransform.rect.center);
					num = 139925074;
					continue;
				case 7:
					vector2 = Vector2.ClampMagnitude(vector3, calculatedStickRange);
					num = 139925060;
					continue;
				case 1:
					vector -= _lastPressStartingValue * calculatedStickRange;
					num = 139925061;
					continue;
				case 17:
					num = 139925083;
					continue;
				case 23:
					return;
				}
				break;
				IL_0350:
				int num2;
				if (_stickBounds == StickBounds.Square)
				{
					num = 139925082;
					num2 = num;
				}
				else
				{
					num = 139925080;
					num2 = num;
				}
				continue;
				IL_00b5:
				flag = Mathf.Abs(vector3.x) > calculatedStickRange;
				flag2 = Mathf.Abs(vector3.y) > calculatedStickRange;
				int num3;
				if (flag)
				{
					num = 139925075;
					num3 = num;
				}
				else
				{
					num = 139925084;
					num3 = num;
				}
				continue;
				IL_0080:
				int num4;
				if (flag2)
				{
					num = 139925075;
					num4 = num;
				}
				else
				{
					num = 139925083;
					num4 = num;
				}
				continue;
				IL_0202:
				if (!_centerStickOnRelease)
				{
					int num5;
					if (!_snapStickToTouch)
					{
						num = 139925073;
						num5 = num;
					}
					else
					{
						num = 139925061;
						num5 = num;
					}
					continue;
				}
				goto IL_02bd;
				IL_0181:
				rectTransform = touchReferenceTransform;
				int num6;
				if (!_snapStickToTouch)
				{
					num = 139925062;
					num6 = num;
				}
				else
				{
					num = 139925081;
					num6 = num;
				}
				continue;
				IL_02bd:
				Vector2 vector6 = LOMeYMhHKyjSwUDqvWYJlrErQKH.KTbmzeAAdhrTBJRYRmgLkeyURAQ(base.canvas, rectTransform, P_0.position);
				vector3 = new Vector2(_useXAxis ? (vector6.x - vector.x) : 0f, _useYAxis ? (vector6.y - vector.y) : 0f);
				int num7;
				if (_stickBounds == StickBounds.Circle)
				{
					num = 139925079;
					num7 = num;
				}
				else
				{
					num = 139925056;
					num7 = num;
				}
			}
			goto IL_000b;
			IL_01c4:
			int num8;
			if (rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				num = 139925085;
				num8 = num;
			}
			else
			{
				num = 139925077;
				num8 = num;
			}
			goto IL_0010;
		}

		private void skHPmmDofmNpWpYOuzgWHAyttpR(PointerEventData P_0, jFqMitXzejUyLCwdAFdYbchMkpx P_1)
		{
			if (!hasPointer)
			{
				while (true)
				{
					switch (0x4D300791 ^ 0x4D300790)
					{
					case 0:
						break;
					case 1:
						return;
					case 2:
						goto end_IL_0008;
					default:
						goto IL_0048;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				return;
			}
			goto IL_0048;
			IL_0048:
			base.OnEndDrag(P_0);
		}

		private void qttGoWavQZHOZLyJsMtdmpSFVQLR(int P_0, Vector2 P_1, jFqMitXzejUyLCwdAFdYbchMkpx P_2)
		{
			_pointerId = P_0;
			_lastClaimSource = P_2;
			_isEligibleForTap = true;
			PointerEventData pointerEventData = default(PointerEventData);
			while (true)
			{
				int num = -239945442;
				while (true)
				{
					switch (num ^ -239945445)
					{
					case 10:
						break;
					default:
						return;
					case 5:
					{
						_lastPressAnchoredPosition = LOMeYMhHKyjSwUDqvWYJlrErQKH.KTbmzeAAdhrTBJRYRmgLkeyURAQ(base.canvas, touchReferenceTransform, P_1);
						deteGKFsUpKVtiobsxDnfbVWHkL = true;
						_lastPressStartingValue.x = MathTools.Clamp(_axis2D.value.x, -1f, 1f);
						_lastPressStartingValue.y = MathTools.Clamp(_axis2D.value.y, -1f, 1f);
						_touchStartTime = Time.realtimeSinceStartup;
						_touchStartPosition = P_1;
						int num5;
						if (P_2 != jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr)
						{
							num = -239945443;
							num5 = num;
						}
						else
						{
							num = -239945441;
							num5 = num;
						}
						continue;
					}
					case 1:
						YuLONUCioDONtByhpbAhNihDhuS(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, wRCfymeNjLzkuVaEfTYwCbhegtWO.yrNPjkUJApZCVhMgUIDiTGAJeil);
						num = -239945443;
						continue;
					case 6:
					{
						int num4;
						if (_onTouchStarted == null)
						{
							num = -239945454;
							num4 = num;
						}
						else
						{
							num = -239945447;
							num4 = num;
						}
						continue;
					}
					case 2:
						_onTouchStarted.Invoke();
						num = -239945454;
						continue;
					case 8:
						YuLONUCioDONtByhpbAhNihDhuS(P_1, false, 0f, wRCfymeNjLzkuVaEfTYwCbhegtWO.yrNPjkUJApZCVhMgUIDiTGAJeil);
						num = -239945443;
						continue;
					case 0:
						if (pointerEventData != null)
						{
							nYhBjmkyAksLnmRnYZANDzUlWpM(pointerEventData, P_2);
							num = -239945444;
							continue;
						}
						return;
					case 3:
					{
						int num3;
						if (_followTouchPosition)
						{
							num = -239945453;
							num3 = num;
						}
						else
						{
							num = -239945446;
							num3 = num;
						}
						continue;
					}
					case 9:
						pointerEventData = IOvmMzhsiknEPdURAICYdMNvgPQ(_pointerId, (P_2 == jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr) ? _workingTouchRegion.gameObject : ((_stickTransform != null) ? _stickTransform.gameObject : base.gameObject));
						num = -239945445;
						continue;
					case 4:
						if (!_moveToTouchPosition)
						{
							int num2;
							if (_followTouchPosition)
							{
								num = -239945448;
								num2 = num;
							}
							else
							{
								num = -239945443;
								num2 = num;
							}
							continue;
						}
						goto case 3;
					case 7:
						return;
					}
					break;
				}
			}
		}

		private void lpCghgdvtFwpLBkUsSpPyavhpiK()
		{
			OmMQSyoLmaJHYrXPeNoBnwkIRXA();
			if (_allowTap)
			{
				goto IL_0011;
			}
			int num = 0;
			goto IL_009c;
			IL_009c:
			bool flag = (byte)num != 0;
			int num2 = 1262274918;
			goto IL_0016;
			IL_0011:
			num2 = 1262274922;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num2 ^ 0x4B3CC96E)
				{
				case 5:
					break;
				default:
					return;
				case 0:
					goto IL_004e;
				case 2:
					_isEligibleForTap = false;
					if (flag)
					{
						_lastTapFrame = Time.frameCount + 1;
						_onTap.Invoke();
						num2 = 1262274919;
						continue;
					}
					return;
				case 4:
					goto IL_0093;
				case 3:
					ReturnToDefaultPosition();
					num2 = 1262274920;
					continue;
				case 1:
					goto IL_00b7;
				case 8:
					goto IL_00d3;
				case 7:
					if (_onTouchEnded != null)
					{
						_onTouchEnded.Invoke();
						num2 = 1262274924;
						continue;
					}
					goto case 2;
				case 6:
					if (_centerStickOnRelease)
					{
						SetRawValue(_axis2D.rawZero);
						num2 = 1262274921;
						continue;
					}
					goto case 7;
				case 9:
					return;
				}
				break;
				IL_00d3:
				deteGKFsUpKVtiobsxDnfbVWHkL = false;
				_pointerDownIsFake = false;
				_lastPressAnchoredPosition = Vector2.zero;
				_lastPressStartingValue = Vector2.zero;
				if (!_followTouchPosition)
				{
					int num3;
					if (_moveToTouchPosition)
					{
						num2 = 1262274926;
						num3 = num2;
					}
					else
					{
						num2 = 1262274920;
						num3 = num2;
					}
					continue;
				}
				goto IL_004e;
				IL_004e:
				int num4;
				if (!_returnOnRelease)
				{
					num2 = 1262274920;
					num4 = num2;
				}
				else
				{
					num2 = 1262274927;
					num4 = num2;
				}
				continue;
				IL_00b7:
				int num5;
				if (!_isMovedFromDefaultPosition)
				{
					num2 = 1262274920;
					num5 = num2;
				}
				else
				{
					num2 = 1262274925;
					num5 = num2;
				}
			}
			goto IL_0011;
			IL_0093:
			num = (_isEligibleForTap ? 1 : 0);
			goto IL_009c;
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0069;
			IL_0008:
			int num = 1390298023;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x52DE43A2)
			{
			case 0:
				break;
			case 2:
				goto IL_0032;
			case 3:
				return;
			case 5:
				return;
			case 4:
				goto IL_0069;
			default:
				goto IL_0085;
			}
			goto IL_0008;
			IL_0069:
			if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			goto IL_0032;
			IL_0032:
			if (_workingTouchRegion != null)
			{
				int num2;
				if (!_useTouchRegionOnly)
				{
					num = 1390298019;
					num2 = num;
				}
				else
				{
					num = 1390298017;
					num2 = num;
				}
				goto IL_000d;
			}
			goto IL_0085;
			IL_0085:
			gkFDUotSecrQghkuzcszQbTklVO(eventData, jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw);
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0042;
			IL_0008:
			int num = -547082619;
			goto IL_000d;
			IL_000d:
			switch (num ^ -547082623)
			{
			case 0:
				break;
			case 2:
				if (_useTouchRegionOnly)
				{
					return;
				}
				goto default;
			case 3:
				goto IL_0042;
			case 1:
				goto IL_005e;
			case 4:
				return;
			default:
				VMPxCmwNDckEZjKzFAfOOLwMEyj(eventData, jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw);
				return;
			}
			goto IL_0008;
			IL_005e:
			int num2;
			if (_workingTouchRegion != null)
			{
				num = -547082621;
				num2 = num;
			}
			else
			{
				num = -547082620;
				num2 = num;
			}
			goto IL_000d;
			IL_0042:
			if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				return;
			}
			goto IL_005e;
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(_workingTouchRegion != null) || !_useTouchRegionOnly))
			{
				yVatkfTlebiCIFaVPbRrioxyjVJ(eventData, jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
				{
					num = -1938138880;
					num2 = num;
				}
				else
				{
					num = -1938138879;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1938138877)
					{
					case 0:
						goto IL_0009;
					case 2:
						if (_workingTouchRegion != null && _useTouchRegionOnly)
						{
							return;
						}
						goto default;
					case 3:
						return;
					case 4:
						break;
					default:
						UNMauMeXBncuatcyFyBICUuhBxd(eventData, jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw);
						return;
					}
					break;
					IL_0009:
					num = -1938138873;
				}
			}
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (-1023689470 ^ -1023689472)
					{
					case 4:
						break;
					case 1:
						goto end_IL_0008;
					case 3:
						goto IL_004c;
					case 2:
						return;
					default:
						goto IL_0071;
					}
					continue;
					end_IL_0008:
					break;
				}
				goto IL_002e;
			}
			goto IL_004c;
			IL_0071:
			TpeATHihvrdIPCiOoSGtuyIVVtV(eventData, jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw);
			return;
			IL_004c:
			if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				return;
			}
			goto IL_002e;
			IL_002e:
			if (_workingTouchRegion != null && _useTouchRegionOnly)
			{
				return;
			}
			goto IL_0071;
		}

		internal override void OnDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
			{
				while (true)
				{
					IL_004b:
					if (_workingTouchRegion != null && _useTouchRegionOnly)
					{
						return;
					}
					while (true)
					{
						IL_0069:
						cKDJLuJFCwljceHvKSZhCcdNDOv(eventData, jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw);
						int num = -1289933662;
						while (true)
						{
							switch (num ^ -1289933663)
							{
							case 0:
								num = -1289933664;
								continue;
							default:
								return;
							case 1:
								break;
							case 2:
								goto IL_004b;
							case 4:
								goto IL_0069;
							case 3:
								return;
							}
							break;
						}
						break;
					}
					break;
				}
			}
		}

		internal override void OnEndDrag(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				while (true)
				{
					if (_workingTouchRegion != null)
					{
						int num;
						int num2;
						if (!_useTouchRegionOnly)
						{
							num = -1351781796;
							num2 = num;
						}
						else
						{
							num = -1351781795;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1351781795)
							{
							case 3:
								num = -1351781799;
								continue;
							case 0:
								return;
							case 2:
								break;
							case 4:
								goto end_IL_0037;
							default:
								goto IL_007b;
							}
							break;
						}
						continue;
					}
					goto IL_007b;
					IL_007b:
					skHPmmDofmNpWpYOuzgWHAyttpR(eventData, jFqMitXzejUyLCwdAFdYbchMkpx.AXriQuEBFZCYarVPplCATARGxpw);
					return;
					continue;
					end_IL_0037:
					break;
				}
			}
		}

		private void AyoEjrMMNOOkuaSctItwyzHQsaJ(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
				{
					num = -1789085059;
					num2 = num;
				}
				else
				{
					num = -1789085057;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1789085058)
					{
					case 0:
						num = -1789085062;
						continue;
					default:
						return;
					case 4:
						break;
					case 1:
						return;
					case 3:
						VMPxCmwNDckEZjKzFAfOOLwMEyj(P_0, jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr);
						num = -1789085060;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void pCiTtuZbGZMrbTGZfOtwxRNbNRF(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
				{
					num = 38276656;
					num2 = num;
				}
				else
				{
					num = 38276658;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x2480E33)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					case 1:
						return;
					default:
						gkFDUotSecrQghkuzcszQbTklVO(P_0, jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr);
						return;
					}
					break;
					IL_0009:
					num = 38276657;
				}
			}
		}

		private void hlqIuMOCvpmOFxFCvgLNQJHJcCdE(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x6E3B4477 ^ 0x6E3B4474)
					{
					case 0:
						break;
					case 3:
						return;
					case 1:
						goto end_IL_0008;
					default:
						goto IL_0053;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			goto IL_0053;
			IL_0053:
			yVatkfTlebiCIFaVPbRrioxyjVJ(P_0, jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr);
		}

		private void shdDotNgJorBUprfkABOaHDWPST(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				UNMauMeXBncuatcyFyBICUuhBxd(P_0, jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr);
			}
		}

		private void xJxFJgGwAWqWMgZurBGAeWiYmDST(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (-9507586 ^ -9507587)
					{
					case 0:
						break;
					case 3:
						return;
					case 2:
						goto end_IL_0008;
					default:
						goto IL_0054;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.BeginDrag))
			{
				return;
			}
			goto IL_0054;
			IL_0054:
			TpeATHihvrdIPCiOoSGtuyIVVtV(P_0, jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr);
		}

		private void ThBAEvkIIHcjifCMBUiowuuGLkXn(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.Drag))
			{
				while (true)
				{
					IL_004c:
					cKDJLuJFCwljceHvKSZhCcdNDOv(P_0, jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr);
					int num = -1058233607;
					while (true)
					{
						switch (num ^ -1058233606)
						{
						case 0:
							num = -1058233605;
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

		private void EmLweaNiZSWHijBoXhegrWJzeze(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.EndDrag))
			{
				skHPmmDofmNpWpYOuzgWHAyttpR(P_0, jFqMitXzejUyLCwdAFdYbchMkpx.ocnclNbRoiITlrFWknqquxusEpr);
			}
		}

		private void PmSBHqGtcObwsBsjhRGByRmNdVOn(Vector2 P_0)
		{
			vpbJzwkSvsfcXUnwDyeDqyAFmab(null);
			Vector2 vector = P_0;
			if (_axis2D.xAxis.calibration.invert)
			{
				vector.x *= -1f;
				goto IL_0033;
			}
			goto IL_0068;
			IL_0068:
			int num;
			int num2;
			if (_axis2D.yAxis.calibration.invert)
			{
				num = -64146755;
				num2 = num;
			}
			else
			{
				num = -64146758;
				num2 = num;
			}
			goto IL_0038;
			IL_0033:
			num = -64146760;
			goto IL_0038;
			IL_0038:
			RectTransform rectTransform = default(RectTransform);
			Vector3 position = default(Vector3);
			while (true)
			{
				switch (num ^ -64146753)
				{
				case 0:
					break;
				default:
					return;
				case 7:
					goto IL_0068;
				case 3:
					rectTransform = touchReferenceTransform;
					position = vector * calculatedStickRange;
					num = -64146759;
					continue;
				case 1:
					_hierarchyValueChangedHandlers.ExecuteOnAll(P_0);
					_hierarchyStickPositionChangedHandlers.ExecuteOnAll(vector);
					_onValueChanged.Invoke(P_0);
					_onStickPositionChanged.Invoke(vector);
					num = -64146757;
					continue;
				case 6:
				{
					position += rectTransform.InverseTransformPoint(base.transform.position);
					Vector3 position2 = rectTransform.TransformPoint(position);
					Vector3 vector2 = _stickTransform.parent.InverseTransformPoint(position2);
					Vector2 anchoredPosition = LOMeYMhHKyjSwUDqvWYJlrErQKH.yxZHAzCCQSGYmzkdYlbchIDlJDC(_stickTransform.parent as RectTransform, vector2);
					anchoredPosition += _origStickAnchoredPosition;
					_stickTransform.anchoredPosition = anchoredPosition;
					num = -64146754;
					continue;
				}
				case 5:
					goto IL_015c;
				case 2:
					vector.y *= -1f;
					num = -64146758;
					continue;
				case 4:
					return;
				}
				break;
				IL_015c:
				vector = MathTools.Clamp(vector, -1f, 1f);
				int num3;
				if (!(_stickTransform != null))
				{
					num = -64146754;
					num3 = num;
				}
				else
				{
					num = -64146756;
					num3 = num;
				}
			}
			goto IL_0033;
		}

		[CompilerGenerated]
		private static void tUSItRuiakATIDDGaYljmLauHkv(IValueChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnValueChanged(P_1);
		}

		[CompilerGenerated]
		private static void aDbrMPtdIcgmjZpzSnPWstKaFAO(IStickPositionChangedHandler P_0, Vector2 P_1)
		{
			P_0.OnStickPositionChanged(P_1);
		}
	}
}
