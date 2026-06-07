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

		private enum mPnLWnwIAPiJikJEqbtjdSJuxhGQ
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum vhXcdscyNfLnHsInBsmBuzRYyzvK
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
		private sealed class UWeqYvPxDZgQSVdLZBZWxcMTdIdc
		{
			public static readonly UWeqYvPxDZgQSVdLZBZWxcMTdIdc _003C_003E9;

			public static ARBysOammWoCZkJhZNqouiroPTrR.EventFunction<IValueChangedHandler, Vector2> _003C_003E9__277_0;

			public static ARBysOammWoCZkJhZNqouiroPTrR.EventFunction<IStickPositionChangedHandler, Vector2> _003C_003E9__280_0;

			internal void SkDkpXDSXPMmCnZYfxPnlofazriD(IValueChangedHandler P_0, Vector2 P_1)
			{
			}

			internal void uPYqvcsgvLeaOBaOQpmdCiYBDclsc(IStickPositionChangedHandler P_0, Vector2 P_1)
			{
			}
		}

		private sealed class okYcmcqvgIOPwqYkfjPDkJPTcRubA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int FHeSJSLjQEZnPmaIFFyzsbfNBiC;

			private object HsRdtclQqVjfhXJbwVEgFDGzIYqZ;

			public float oGEFQmbKCbrJAQubcXhkflOQDrVQ;

			public TouchJoystick WjxzkCwVNzAvbckhSXROthSDZPYB;

			public PositionType DCpXHWUDPQhOGbRGMAJDYOQHHNlq;

			public Vector2 dpPxtDrORTrehsYITBeasHDNbaDg;

			public mPnLWnwIAPiJikJEqbtjdSJuxhGQ zipBbZrFFJwAXAQYavpKolSnSDBI;

			private RectTransform RswxVtPOELTtCzPHplHsgUTOLibJ;

			private Vector2 SATElNIOlFdAgmtURROzwrFnfAAJb;

			private float oVnxbRszHIGWTABjRipMZinjYTKx;

			private float uxmFmzCaEVveoqvOiDZidYLfOPfIA;

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
			public okYcmcqvgIOPwqYkfjPDkJPTcRubA(int P_0)
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

		[Tooltip("The Custom Controller element that will receive input values from taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement;

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
		private bool _centerStickOnRelease;

		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D;

		[Tooltip("If true, the joystick can be activated by a touch swipe that began in an area outside the joystick region. If false, the joystick can only be activated by a direct touch.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the joystick will stay engaged even if the touch that activated it moves outside the joystick region. If false, the joystick will be released once the touch that activated it moves outside the joystick region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut;

		[Tooltip("Should taps on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, 3.4028235E+38f)]
		private float _tapTimeout;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, 2147483647)]
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

		[Tooltip("If Move To Touch Position is enabled, this will make the joystick return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease;

		[Tooltip("If True, the joystick will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[Tooltip("Should the joystick animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch;

		[Tooltip("The speed at which the joystick will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed;

		[Tooltip("Should the joystick animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn;

		[Tooltip("The speed at which the joystick will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting;

		private bool _useXAxis;

		private bool _useYAxis;

		private ARBysOammWoCZkJhZNqouiroPTrR.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private ARBysOammWoCZkJhZNqouiroPTrR.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private mPnLWnwIAPiJikJEqbtjdSJuxhGQ _moveDirection;

		private int _pointerId;

		private int _realMousePointerId;

		[NonSerialized]
		private bool UMRrfvNIcsvdBLqStRvKfECPJKxC;

		[NonSerialized]
		private bool wofqFsxHjPMKlLpbqgGmcTWOArxGA;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private vhXcdscyNfLnHsInBsmBuzRYyzvK _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private BaXIpqZTfVimIDRoWGYuurOCveHgA _imageRaycastHelper;

		private int _calculatedStickRange_lastUpdatedFrame;

		private int _lastTapFrame;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<mPnLWnwIAPiJikJEqbtjdSJuxhGQ> __moveStartedDelegate;

		private Action<mPnLWnwIAPiJikJEqbtjdSJuxhGQ> __moveEndedDelegate;

		[Tooltip("Event sent when the joystick value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onValueChanged;

		[Tooltip("Event sent when the joystick's stick position changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onStickPositionChanged;

		[Tooltip("Event sent when the joystick is touched.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchStartedEventHandler _onTouchStarted;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchEndedEventHandler _onTouchEnded;

		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TapEventHandler _onTap;

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static ARBysOammWoCZkJhZNqouiroPTrR.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static ARBysOammWoCZkJhZNqouiroPTrR.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

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

		private StickBounds doFUQPmKrAidVcRcCxFGPUOSMSMj
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

		private bool izvRSujmndXJjGARMxVxsUJSvzJD => false;

		internal StandaloneAxis2D BymbEVXwaeenOLrdjvffwKeykFNc => null;

		private Action<mPnLWnwIAPiJikJEqbtjdSJuxhGQ> fUsBQThxmhWnvkcyPdItCYxTgmfyA => null;

		private Action<mPnLWnwIAPiJikJEqbtjdSJuxhGQ> wKTDpKcUfFEqfoxNBDaNfIceYdpq => null;

		private int qdpmerbeBiwrISMvhTPPqiIKpmrM => 0;

		private RectTransform fbuGzWENyZynObOPNCjzzuMEikYZA => null;

		private float DVlZyglekSJNevLCMzXOszVxqBTM => 0f;

		internal static ARBysOammWoCZkJhZNqouiroPTrR.EventFunction<IValueChangedHandler, Vector2> aqymDIHaSxbMkjykTQmrubNIIBPAb => null;

		internal static ARBysOammWoCZkJhZNqouiroPTrR.EventFunction<IStickPositionChangedHandler, Vector2> juTJPSmqfzuUvfjbJKTwitbbtZek => null;

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

		private void PZaYFnZUUWqJzQEyblpiREHnlZwG(Vector2 P_0)
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

		internal override void HFvohMUOstAUOCfejghrHDohTlWob()
		{
		}

		internal override bool kCMMqxCXpgLJLruKfzlhHdqYwqkJ()
		{
			return false;
		}

		internal override void YsQBPQCvrBZXbzlCHhtnkCXGyxjR()
		{
		}

		internal override void HzbXIgvDEecKGiVrHsiaugTjTUln()
		{
		}

		internal override void noSANRUEqtKuHmySzautBIlAHAWcA()
		{
		}

		internal override void GTRDyimMWaAVahmkfoYBnobmVDON()
		{
		}

		internal override void nvUORnqFfBpcibUOpygLfKlyxCZD()
		{
		}

		internal override void zwkdLoCQYQUJBkkwofvYaZBZJijLA()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool LmlvpacDElEuBoptUDsideXckHeR()
		{
			return false;
		}

		internal override bool zazjadrXbZLpHyUrcIdnVMeBCdqr(GameObject P_0)
		{
			return false;
		}

		private void OAxqfAnmzllMyhCEjoyXGYDgNTFs()
		{
		}

		private void sVGqabfHGmJbSzqZpVxZqEVEcOQj()
		{
		}

		private bool SvrUxBSDjJewEzFBPXFoDONaCMoz()
		{
			return false;
		}

		private void uiaEbLAMuiEfkLeCgSDpPLOulZWrA(TouchRegion P_0)
		{
		}

		private void FyqbDRkmKsujimOAEGpKDVnbqPbEA(TouchRegion P_0)
		{
		}

		private void hnZBkeulybNksKMPCKZNFheDhjdF()
		{
		}

		private void uUdBbstZNSeWCTNJpbAXLsrAUwFl(Vector2 P_0, bool P_1, float P_2, mPnLWnwIAPiJikJEqbtjdSJuxhGQ P_3)
		{
		}

		private void XmwXosfODihCxcEheeItBEUXYUQn(Vector2 P_0, PositionType P_1, bool P_2, float P_3, mPnLWnwIAPiJikJEqbtjdSJuxhGQ P_4)
		{
		}

		[IteratorStateMachine(typeof(okYcmcqvgIOPwqYkfjPDkJPTcRubA))]
		private IEnumerator FSIukwKKbsDwPfmTWJpEDJQhwIlYA(Vector2 P_0, PositionType P_1, float P_2, mPnLWnwIAPiJikJEqbtjdSJuxhGQ P_3)
		{
			return null;
		}

		private void RJLgVJKRmevPWfdbQRFDYWuYsUwX(mPnLWnwIAPiJikJEqbtjdSJuxhGQ P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void xpvbLGiHnOVFwrNzycMlxEpanrCdA(mPnLWnwIAPiJikJEqbtjdSJuxhGQ P_0)
		{
		}

		private void vFlsVoRmzCZoKQVQbcLkWRYedyTr(mPnLWnwIAPiJikJEqbtjdSJuxhGQ P_0)
		{
		}

		private void prxnLWSuWfoXEAbHmwcPvzSSmLJh()
		{
		}

		private void dpbNUxoYKwJdlxToMZMmKpmZYPHc(int P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void KlazijuXakDBRqqQidUVBmBhUzucA()
		{
		}

		private void VHfqaSqMGgJmNcwPJaLQofWlUXVn()
		{
		}

		private void rIKZgRoPSLGXdawnRuXiuMFWkagGb(ref Vector2 P_0)
		{
		}

		private bool TtQydZduatgsrjXUSkTtWkCiered()
		{
			return false;
		}

		private void rZiJpmhLdtlxbteQTxmRJzDvKsMd()
		{
		}

		private bool yAvNCjxReAeRStTRVMlFTJrvDdJU(int P_0)
		{
			return false;
		}

		private PointerEventData WTcaTHFjEfqEJiYSBjikWrkQWxQSA(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData ZrVDUgBifgfNJiMcVwFOtsPmJgFYA(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData AVbmOrgfcGxzxAhTZHeohrimNIHe(int P_0)
		{
			return null;
		}

		private void msZuRpHJaMswMAuGGSBPdmtJRNKh(PointerEventData P_0)
		{
		}

		private void qnBIiqelydZJlYJPYLJeDKPyDFQD(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private PointerEventData UEGXPDqcByZFpjKByJNQSAPoaYGiA(int P_0)
		{
			return null;
		}

		private void EnxHMibYUkBaYOhsDmJMWAwhhmGm()
		{
		}

		private void oWssQoAIkPCckbIUYaWxqqObcXVYA(AxisDirection P_0)
		{
		}

		private void dvyCvlefSDHogAPiCmVhcCAkqYvM(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private void SvBApOfTHxZRoNQTXzlnqMkCoSEvA(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private void pfKjWDztHLMlqNpaEoJbIHTGDrht(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private void QmFMzzMrvWUiTYxCyngkmgfuugMg(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private void XvjcXjvrYNBhIGohQjJwyhazHyRdA(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private void xdqklHiIOfeWacUeaDYIevsgwary(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private void liOcFAsSCAYnzRYfmSJUhfpQMpVh(PointerEventData P_0, vhXcdscyNfLnHsInBsmBuzRYyzvK P_1)
		{
		}

		private void PXIKmYHGRjRxxkCBoNPrmVIhsDup(int P_0, Vector2 P_1, vhXcdscyNfLnHsInBsmBuzRYyzvK P_2)
		{
		}

		private void bfYiWQHFWnMeZGIKJKbphwQJJzjIB()
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

		private void wBTHdGHVWVjfCLvjsIQGFKaivsgyA(PointerEventData P_0)
		{
		}

		private void KBfHECgDWEEONYQtaNItoXDRuaIaA(PointerEventData P_0)
		{
		}

		private void IQMBJJGymUEjYwsEOfTDMQlllAXMA(PointerEventData P_0)
		{
		}

		private void PQrPUCqlQFrKESUKcyZIunPsxavH(PointerEventData P_0)
		{
		}

		private void IDmapkukZxJOvpVUsHdOvCSpYWTk(PointerEventData P_0)
		{
		}

		private void ZtyaxxfOcVQSSIOOLmSFSXDgZuldA(PointerEventData P_0)
		{
		}

		private void BxKljKDaMSFTtUQNjcScSjuAiyCQ(PointerEventData P_0)
		{
		}

		private void rJZmFDnlHIxOzEneSVWWMEObJqZn(Vector2 P_0)
		{
		}
	}
}
