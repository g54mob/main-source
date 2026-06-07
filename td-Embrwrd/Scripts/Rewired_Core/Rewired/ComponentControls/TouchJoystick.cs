using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils.Attributes;
using Rewired.Utils.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[AddComponentMenu("Rewired/Touch Controls/Touch Joystick")]
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

		private enum inJWMJVPbuAscLLHwrrIAEXrhaAK
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum pcrxuEJfuKbwBCzcDyoqSGRVcxbxA
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
		private sealed class KFIdbakGUopmSwstXXCiYEgYnaAH
		{
			public static readonly KFIdbakGUopmSwstXXCiYEgYnaAH _003C_003E9;

			public static SRtajoXrNhbTDeRsLSkJRLdbaRxDb.EventFunction<IValueChangedHandler, Vector2> _003C_003E9__277_0;

			public static SRtajoXrNhbTDeRsLSkJRLdbaRxDb.EventFunction<IStickPositionChangedHandler, Vector2> _003C_003E9__280_0;

			internal void CSlfBjktasJFCEIOrrFWOtanpEoJ(IValueChangedHandler P_0, Vector2 P_1)
			{
			}

			internal void eqseeEXAYoqdGBIFOcsKfHSGMivhb(IStickPositionChangedHandler P_0, Vector2 P_1)
			{
			}
		}

		private sealed class wScnbMVOJzAauPjjlRWyRTHUVNyI : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int JarrUqhBivZuPagxGLHJWRekXgoI;

			private object NnlmhQKvVgenhoBiiDGXkUUiJWkO;

			public float iFsVBKtldWGSMjhueHdVYEMFNlXBA;

			public TouchJoystick ArXmaIHHwKXUtXHpAHvuCbXGFYHd;

			public PositionType JAZEjwlFqfhTEMCDQbFifsMUxRxO;

			public Vector2 nnxwifWfGwgpzNPZFZIRDRMGtIPE;

			public inJWMJVPbuAscLLHwrrIAEXrhaAK nUFMrHOeLyhPHnPMoblsJSDcMePE;

			private RectTransform ZNAujFcyheQfSQVQvdoHZBJZNKni;

			private Vector2 KivUwllZQgDLkGGJFgSYIAXoHGWVA;

			private float eNVZitHTctmVVrHgDwrxyLncfNKKA;

			private float eMMtfXDNfyhpcjPJoRVPoxXsmRfwA;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public wScnbMVOJzAauPjjlRWyRTHUVNyI(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
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
			}
		}

		private const float MAX_MOVE_SPEED = 20f;

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement;

		[Tooltip("The Custom Controller element(s) that will receive input values from the joystick's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement;

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Rect Transform of the stick disc. This is moved around by the user when manipulating the joystick.")]
		private RectTransform _stickTransform;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The joystick's mode of operation. Set this to Digital to simulate a D-Pad which has only On/Off states. If you want mimic a real D-Pad, you should also set Snap Directions to 8.")]
		private JoystickMode _joystickMode;

		[Tooltip("A dead zone which is applied when Stick Mode is set to Digital. This is used to filter out tiny stick movements near 0, 0.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 1f)]
		private float _digitalModeDeadZone;

		[Tooltip("The range of movement of the stick in Canvas pixels. The larger the number, the further the stick must be moved from center to register movement.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0.01f, 1000f)]
		private float _stickRange;

		[Tooltip("If enabled, the stick range will scale with parent controls. Otherwise, the stick range will remain constant.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _scaleStickRange;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The shape of the range of movement of the joystick.")]
		private StickBounds _stickBounds;

		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisDirection _axesToUse;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Snaps joystick movement to a fixed number of directions. This can be used to create a D-Pad, for example, setting it to 4 or 8 directions. If you want a true D-Pad, Stick Mode should be set to digital.")]
		private SnapDirections _snapDirections;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the stick disc will snap immediately to the touch position when initially touched. This results in the stick disc being centered to the touch position. This will cause the stick to generate input immediately when touched if not touched perfectly centered.If false, the stick disc will remain in its current position on touch, and when dragged will retain the same offset. The stick's center point will be set to the position of the touch. The initial touch will not cause the stick to pop in any direction.")]
		private bool _snapStickToTouch;

		[Tooltip("If true, the stick will return to the center after it is released. Otherwise, the stick will remain in the last position and continue to return input.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _centerStickOnRelease;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The underlying Axis 2D.")]
		private StandaloneAxis2D _axis2D;

		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut;

		[Tooltip("Should taps on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		private float _tapTimeout;

		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _tapDistanceLimit;

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the joystick's RectTransform. This can be useful if you want a larger area of the screen to act as a joystick.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local joystick will be ignored and only Touch Region touches will be used. Otherwise, both touches on the joystick and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly;

		[Tooltip("If True, the joystick will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a joystick and have the joystick graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[SerializeField]
		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		private bool _followTouchPosition;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private bool _animateOnMoveToTouch;

		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private float _moveToTouchSpeed;

		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnReturn;

		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[Range(0f, 20f)]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _returnSpeed;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		private bool _manageRaycasting;

		private bool _useXAxis;

		private bool _useYAxis;

		private SRtajoXrNhbTDeRsLSkJRLdbaRxDb.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private SRtajoXrNhbTDeRsLSkJRLdbaRxDb.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private inJWMJVPbuAscLLHwrrIAEXrhaAK _moveDirection;

		private int _pointerId;

		private int _realMousePointerId;

		[NonSerialized]
		private bool UpfcbVuhfRqNpcnzhZBOSlQWNWhj;

		[NonSerialized]
		private bool isJDUMIJEoXFzeOmskGLXsWZfxvV;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private pcrxuEJfuKbwBCzcDyoqSGRVcxbxA _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private BLtugKwVIsVbSuMnMPEDELGPhaRhA _imageRaycastHelper;

		private int _calculatedStickRange_lastUpdatedFrame;

		private int _lastTapFrame;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<inJWMJVPbuAscLLHwrrIAEXrhaAK> __moveStartedDelegate;

		private Action<inJWMJVPbuAscLLHwrrIAEXrhaAK> __moveEndedDelegate;

		[Tooltip("Event sent when the joystick value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onValueChanged;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick's stick position changes.")]
		[SerializeField]
		private ValueChangedEventHandler _onStickPositionChanged;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the joystick is touched.")]
		[SerializeField]
		private TouchStartedEventHandler _onTouchStarted;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchEndedEventHandler _onTouchEnded;

		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TapEventHandler _onTap;

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static SRtajoXrNhbTDeRsLSkJRLdbaRxDb.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static SRtajoXrNhbTDeRsLSkJRLdbaRxDb.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement => null;

		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement => null;

		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement => null;

		public RectTransform stickTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JoystickMode joystickMode
		{
			get
			{
				return default(JoystickMode);
			}
			set
			{
			}
		}

		public float digitalModeDeadZone
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float stickRange
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool scaleStickRange
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private StickBounds nrsDtETKjnlRAZhUyjzLgYFwCCoA
		{
			get
			{
				return default(StickBounds);
			}
			set
			{
			}
		}

		public AxisDirection axesToUse
		{
			get
			{
				return default(AxisDirection);
			}
			set
			{
			}
		}

		public SnapDirections snapDirections
		{
			get
			{
				return default(SnapDirections);
			}
			set
			{
			}
		}

		public bool snapStickToTouch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool centerStickOnRelease
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool activateOnSwipeIn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool allowTap
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float tapTimeout
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int tapDistanceLimit
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public TouchRegion touchRegion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool useTouchRegionOnly
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool moveToTouchPosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool returnOnRelease
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool followTouchPosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool animateOnMoveToTouch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float moveToTouchSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool animateOnReturn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float returnSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool manageRaycasting
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public AxisCalibration horizontalAxisCalibration => null;

		public AxisCalibration verticalAxisCalibration => null;

		[Obsolete("Use axis2DCalibration instead.", false)]
		public Axis2DCalibration deadZoneType => null;

		public Axis2DCalibration axis2DCalibration => null;

		public int pointerId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool hasPointer => false;

		private bool ghJWgCSaIOAWhhYWGjfEZqCThlDY => false;

		internal StandaloneAxis2D HcWqVwcPTNlVxmeXrrDANSEjmgDF => null;

		private Action<inJWMJVPbuAscLLHwrrIAEXrhaAK> fpEZLfMhVCMibRShJiQKjrlQVoxo => null;

		private Action<inJWMJVPbuAscLLHwrrIAEXrhaAK> yVtqeyNYEorpdPzYPJyyCZopvzdM => null;

		private int gfVmvRQAwHFwQbpebPNiRPAVBcxYA => 0;

		private RectTransform fIIxseqUFoFiMdzINqrSPMWZgmMq => null;

		private float PqXxpGIsHpVCeAUHICVdFfXyADXaA => 0f;

		internal static SRtajoXrNhbTDeRsLSkJRLdbaRxDb.EventFunction<IValueChangedHandler, Vector2> stKkUakUzQBJqZLrZFsAEyVBTLHr => null;

		internal static SRtajoXrNhbTDeRsLSkJRLdbaRxDb.EventFunction<IStickPositionChangedHandler, Vector2> hmlmYuBDIMgVpGYiNrRLXbbacBgaA => null;

		public event UnityAction<Vector2> ValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<Vector2> StickPositionChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction TouchDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction TouchUpEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction TapEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchJoystick()
		{
		}

		public Vector2 GetValue()
		{
			return default(Vector2);
		}

		public Vector2 GetRawValue()
		{
			return default(Vector2);
		}

		public void SetRawValue(Vector2 value)
		{
		}

		public void SetDefaultPosition()
		{
		}

		private void VFADVDepplMtntqtpZjRoTDgixcs(Vector2 P_0)
		{
		}

		public void ReturnToDefaultPosition(bool instant)
		{
		}

		public void ReturnToDefaultPosition()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
		}

		internal override void TaJJysfcXGOLIYrzfRlEkosEbnMcA()
		{
		}

		internal override bool qAgXOZxzQNKqPAuHppaSytuDgzcg()
		{
			return false;
		}

		internal override void UQizGkdUUglAlSKLFhpOGRJTqnpDb()
		{
		}

		internal override void PDJYvOSVfJDBKJNuJgaVVBNgWtxL()
		{
		}

		internal override void xroVZfvuVIfFNJbBpfsGuofJYYUm()
		{
		}

		internal override void MPxPpCPVtBLCgEKzdjWmMHtdnZGk()
		{
		}

		internal override void bFeVhzFgykusySbDzeNuCRErjfHH()
		{
		}

		internal override void nGKIeWxqdnUtNJvRqnXhmJyYsngc()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool LQDwBUFVjYdMXZIuYqvBOPLxVful()
		{
			return false;
		}

		internal override bool rFFOtJAlAcasBPbwsddQAooGmbaDb(GameObject P_0)
		{
			return false;
		}

		private void OiVgueQHUWzLgUdDfXakfEZlDVJFA()
		{
		}

		private void eEglRfQboVMUfKWlfTgbPFmZkKpb()
		{
		}

		private bool CHNRlxfJMaxPGQRKBVaNiOJnYnmj()
		{
			return false;
		}

		private void gdUzkrbOZTtocZGBgfDOcuClQFQgA(TouchRegion P_0)
		{
		}

		private void LiUOVdDrxPmxeFNzIhTvypLgLmhE(TouchRegion P_0)
		{
		}

		private void lMlAITHYeMAoWfBhAGbcoryQldte()
		{
		}

		private void elHcXCEuWbJGWiaGnAmoybtVGCVJ(Vector2 P_0, bool P_1, float P_2, inJWMJVPbuAscLLHwrrIAEXrhaAK P_3)
		{
		}

		private void TTKaACQlyDekrRdiyXGCynUKEOUAA(Vector2 P_0, PositionType P_1, bool P_2, float P_3, inJWMJVPbuAscLLHwrrIAEXrhaAK P_4)
		{
		}

		[IteratorStateMachine(typeof(wScnbMVOJzAauPjjlRWyRTHUVNyI))]
		private IEnumerator DTiGtYdtYBzfBFRCMIpbqkEiAMbXA(Vector2 P_0, PositionType P_1, float P_2, inJWMJVPbuAscLLHwrrIAEXrhaAK P_3)
		{
			return null;
		}

		private void JwvnMdprNDKIMMdmAzHqzdwTYQmW(inJWMJVPbuAscLLHwrrIAEXrhaAK P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void xTRYWsypAjcWsaqiiWOQpKjjenOBA(inJWMJVPbuAscLLHwrrIAEXrhaAK P_0)
		{
		}

		private void zdJiEOqQCzntWxyVjINXxlIdEuDS(inJWMJVPbuAscLLHwrrIAEXrhaAK P_0)
		{
		}

		private void bpHyXyrctIdvQznMakauABODTmLx()
		{
		}

		private void nnNGhLHfhPWqtIMqGLBVtFpYEMHm(int P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void QaQDpRGHXNoUFaLHqPQupJPcStaNA()
		{
		}

		private void DAHgruFhdBwlVFVCVRJdZzYmHTLm()
		{
		}

		private void tAuZzpRBxgSYzBDkZAXJGfHJCyiQA(ref Vector2 P_0)
		{
		}

		private bool TJezojMFQSjbnYAVImTCjiExcYse()
		{
			return false;
		}

		private void hAECBSQqtOavjGvrFdCeipKkIZAE()
		{
		}

		private bool gFPILDKrFpRQQCNARfnoqPhcfhTV(int P_0)
		{
			return false;
		}

		private PointerEventData KsKXMvYqjQeJNldJTlkVQHwTfdIkA(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData PrrqFYqIEPuQNtCdJRLtJCRbDgLY(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData WENhbPROsfoUjdwbZVOJSljfFNTC(int P_0)
		{
			return null;
		}

		private void alsnZclXbenUazXUuAaRCdQqFGFb(PointerEventData P_0)
		{
		}

		private void yOfRtQBKVOOxXjWCGREPiKjhBnCC(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private PointerEventData EfmCWxaRoZIEpHGUoXJdfxZrWYYfb(int P_0)
		{
			return null;
		}

		private void SXMSYGMbLPMOghdkTohLtuAojCKb()
		{
		}

		private void uMOEHGedDsOzyQtLYKAOHBMoJVRlA(AxisDirection P_0)
		{
		}

		private void ziYRILJUxczXgpwfOTuAREstMClG(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private void GOtXamwQqUfMajmKTVrUlNgHoCUN(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private void lAwiRtWggcfDwcTlCqcMlZFNfntR(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private void ANfJLMzEAxXcapmEyrDBRsOxepEC(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private void DKNEaLIUzeeFKnMmGHWXBUeasuZF(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private void dCWpubRyrAeZyTWbixCfXeipvehx(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private void fyyChoZRbvVTrmXkwBQfGJvTbKXx(PointerEventData P_0, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_1)
		{
		}

		private void JKmnfoeNqKekpJrIqLNENcSaAXaAA(int P_0, Vector2 P_1, pcrxuEJfuKbwBCzcDyoqSGRVcxbxA P_2)
		{
		}

		private void bGeTRgydlMTnHfcBQvnYXFOEBfpCA()
		{
		}

		internal override void OnPointerUp(PointerEventData P_0)
		{
		}

		internal override void OnPointerDown(PointerEventData P_0)
		{
		}

		internal override void OnPointerEnter(PointerEventData P_0)
		{
		}

		internal override void OnPointerExit(PointerEventData P_0)
		{
		}

		internal override void OnBeginDrag(PointerEventData P_0)
		{
		}

		internal override void OnDrag(PointerEventData P_0)
		{
		}

		internal override void OnEndDrag(PointerEventData P_0)
		{
		}

		private void ghzSoskRjmcoKOissbSpijepCwqzA(PointerEventData P_0)
		{
		}

		private void OiHSRyomjrAVVhekwHMMdyPOHuQIA(PointerEventData P_0)
		{
		}

		private void IvezCrBXTrGcMBRFAkZmtJnqEAHn(PointerEventData P_0)
		{
		}

		private void XmZUiuZBnefoIlMFyjyjAHZrbvrgb(PointerEventData P_0)
		{
		}

		private void CZCirKVOyCMzjQHhqFrhYOSoAHJe(PointerEventData P_0)
		{
		}

		private void ZSUXiFhtLeDLEnoVHAUiqbJffyxBA(PointerEventData P_0)
		{
		}

		private void BGgeVmenrrIHzrTIreMRbooRwMAF(PointerEventData P_0)
		{
		}

		private void pWlkUdCigfhRbghdSoNxebWcuqTnA(Vector2 P_0)
		{
		}
	}
}
