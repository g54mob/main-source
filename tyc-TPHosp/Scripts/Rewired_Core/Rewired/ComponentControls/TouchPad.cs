using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.ComponentControls
{
	[Serializable]
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("Rewired/Touch Pad")]
	[DisallowMultipleComponent]
	public sealed class TouchPad : TouchInteractable, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		public enum AxisDirection
		{
			Both = 0,
			Horizontal = 1,
			Vertical = 2
		}

		public enum TouchPadMode
		{
			Delta = 0,
			ScreenPosition = 1,
			VectorFromCenter = 2,
			VectorFromInitialTouch = 3
		}

		public enum ValueFormat
		{
			Pixels = 0,
			Screen = 1,
			Physical = 2,
			Direction = 3
		}

		private class nInpfXfuicnFdikGkVBsGfijdLk
		{
			private class hvZOqoXEoUAoiHsLRdhohmokSHlx
			{
				public float fmiyCZXvdFCBWTjMPhSrLknizZk;

				public float JSffCNviejhMhwjEgVmNZseKfks;

				public uint qSrCgnKuYeBgSGlFfKSvEicitujU;
			}

			private int usAbGZIHrlOpwjipcKlXgADBIkyy;

			private hvZOqoXEoUAoiHsLRdhohmokSHlx[] JBeGhlFgiFxdOJckDGTWreONSQo;

			private int FMfGoswTmMzBNBPokzjvUBjQbHe = -1;

			public nInpfXfuicnFdikGkVBsGfijdLk(int maxSmoothFrames)
			{
				if (maxSmoothFrames < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				usAbGZIHrlOpwjipcKlXgADBIkyy = maxSmoothFrames;
				JBeGhlFgiFxdOJckDGTWreONSQo = new hvZOqoXEoUAoiHsLRdhohmokSHlx[maxSmoothFrames];
				ArrayTools.Populate(JBeGhlFgiFxdOJckDGTWreONSQo);
			}

			public void GcIuKOHgXujXqCTdAuwBBVguUoX(float P_0, float P_1)
			{
				uint currentFrame = ReInput.currentFrame;
				if (FMfGoswTmMzBNBPokzjvUBjQbHe < 0 || JBeGhlFgiFxdOJckDGTWreONSQo[FMfGoswTmMzBNBPokzjvUBjQbHe].qSrCgnKuYeBgSGlFfKSvEicitujU != currentFrame)
				{
					QeGmLUTOGlBQHKmJXDFUAcGsMzLp();
					hvZOqoXEoUAoiHsLRdhohmokSHlx hvZOqoXEoUAoiHsLRdhohmokSHlx2 = JBeGhlFgiFxdOJckDGTWreONSQo[FMfGoswTmMzBNBPokzjvUBjQbHe];
					hvZOqoXEoUAoiHsLRdhohmokSHlx2.fmiyCZXvdFCBWTjMPhSrLknizZk = P_0;
					hvZOqoXEoUAoiHsLRdhohmokSHlx2.JSffCNviejhMhwjEgVmNZseKfks = P_1;
					hvZOqoXEoUAoiHsLRdhohmokSHlx2.qSrCgnKuYeBgSGlFfKSvEicitujU = currentFrame;
				}
			}

			public Vector2 EPfxuURiPnAypEJJumIXhgJMOsij()
			{
				if (FMfGoswTmMzBNBPokzjvUBjQbHe < 0)
				{
					return default(Vector2);
				}
				int fMfGoswTmMzBNBPokzjvUBjQbHe = FMfGoswTmMzBNBPokzjvUBjQbHe;
				hvZOqoXEoUAoiHsLRdhohmokSHlx hvZOqoXEoUAoiHsLRdhohmokSHlx2 = JBeGhlFgiFxdOJckDGTWreONSQo[fMfGoswTmMzBNBPokzjvUBjQbHe];
				Vector2 result = new Vector2(hvZOqoXEoUAoiHsLRdhohmokSHlx2.fmiyCZXvdFCBWTjMPhSrLknizZk, hvZOqoXEoUAoiHsLRdhohmokSHlx2.JSffCNviejhMhwjEgVmNZseKfks);
				uint qSrCgnKuYeBgSGlFfKSvEicitujU = hvZOqoXEoUAoiHsLRdhohmokSHlx2.qSrCgnKuYeBgSGlFfKSvEicitujU;
				int num = fMfGoswTmMzBNBPokzjvUBjQbHe;
				int num2 = 1;
				while ((num = PcVWgiTFKDFDYvRTHvIdTTJzidx(num, usAbGZIHrlOpwjipcKlXgADBIkyy)) != fMfGoswTmMzBNBPokzjvUBjQbHe)
				{
					hvZOqoXEoUAoiHsLRdhohmokSHlx hvZOqoXEoUAoiHsLRdhohmokSHlx3 = JBeGhlFgiFxdOJckDGTWreONSQo[num];
					if (!ZuxGaSyKthHYiIYAGRfJTjGAKDo(hvZOqoXEoUAoiHsLRdhohmokSHlx3.qSrCgnKuYeBgSGlFfKSvEicitujU, qSrCgnKuYeBgSGlFfKSvEicitujU))
					{
						break;
					}
					result.x += hvZOqoXEoUAoiHsLRdhohmokSHlx3.fmiyCZXvdFCBWTjMPhSrLknizZk;
					result.y += hvZOqoXEoUAoiHsLRdhohmokSHlx3.JSffCNviejhMhwjEgVmNZseKfks;
					qSrCgnKuYeBgSGlFfKSvEicitujU = hvZOqoXEoUAoiHsLRdhohmokSHlx3.qSrCgnKuYeBgSGlFfKSvEicitujU;
					num2++;
				}
				if (num2 > 0)
				{
					result.x /= num2;
					result.y /= num2;
				}
				return result;
			}

			private void QeGmLUTOGlBQHKmJXDFUAcGsMzLp()
			{
				FMfGoswTmMzBNBPokzjvUBjQbHe = sCCVMFbZbInYQUCTigeTjGXsbEBB(FMfGoswTmMzBNBPokzjvUBjQbHe, usAbGZIHrlOpwjipcKlXgADBIkyy);
			}

			private static int sCCVMFbZbInYQUCTigeTjGXsbEBB(int P_0, int P_1)
			{
				if (P_0 >= P_1 - 1)
				{
					return 0;
				}
				return ++P_0;
			}

			private int PcVWgiTFKDFDYvRTHvIdTTJzidx(int P_0, int P_1)
			{
				if (P_0 > 0)
				{
					return --P_0;
				}
				return P_1 - 1;
			}

			private static bool ZuxGaSyKthHYiIYAGRfJTjGAKDo(uint P_0, uint P_1)
			{
				if (P_1 == 0)
				{
					return P_0 == uint.MaxValue;
				}
				return P_0 == P_1 - 1;
			}
		}

		[Serializable]
		public class ValueChangedEventHandler : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class TapEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class PressDownEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class PressUpEventHandler : UnityEvent
		{
		}

		private const int SMOOTH_DELTA_FRAME_COUNT = 3;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's X axis.")]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's Y axis.")]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from touch pad taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from touch pad presses.")]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		private AxisDirection _axesToUse;

		[Tooltip("The mode of the touch pad.\n\nDelta - Returns the change in position of the touch from the previous to the current frame.\n\nScreen Position - Returns the absolute position of the touch  on the screen.\n\nVector From Center - Returns a vector from the center of the Touch Pad to the current touch position.\n\nVector From Initial Touch - Returns a vector from the intial touch position to the current touch position.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchPadMode _touchPadMode;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The format of the resulting data generated by the touch pad.\n\nPixels - Screen pixels.\n\nScreen - The proportion of the value to screen size in the corresponding dimension. 1 unit = 1 screen length (width for X, height for Y).\n\nPhysical - 1 unit = 1/100th of an inch. The resulting value will be consistent across different screen resolutions and sizes. IMPORTANT: This relies on the value returned by UnityEngine.Screen.dpi. If the device does not return a value, a reference resolution of 96 dpi will be used.\n\nDirection - A normalized direction vector.")]
		private ValueFormat _valueFormat;

		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useInertia;

		[FieldRange(0f, float.MaxValue)]
		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _inertiaFriction = 3f;

		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Should taps on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowTap;

		[FieldRange(0f, float.MaxValue)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		private float _tapTimeout = 0.25f;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[SerializeField]
		private int _tapDistanceLimit = 10;

		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _allowPress;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		private float _pressStartDelay = 0.1f;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[FieldRange(-1, int.MaxValue)]
		private int _pressDistanceLimit = 10;

		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime;

		[Tooltip("The underlying Axis 2D.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		[Tooltip("Event sent when the value changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		private TapEventHandler _onTap = new TapEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		private PressDownEventHandler _onPressDown = new PressDownEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		private PressUpEventHandler _onPressUp = new PressUpEventHandler();

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool traAtpHvLXNexVrCRTWuJipMjwd;

		[NonSerialized]
		private bool IqanMrGVhLvExACtCdEAMqyHqQT;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private nInpfXfuicnFdikGkVBsGfijdLk _smoothDelta = new nInpfXfuicnFdikGkVBsGfijdLk(3);

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement => _horizontalAxisCustomControllerElement;

		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement => _verticalAxisCustomControllerElement;

		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement => _tapCustomControllerElement;

		public CustomControllerElementTargetSetForBoolean pressCustomControllerElement => _pressCustomControllerElement;

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

		public TouchPadMode touchPadMode
		{
			get
			{
				return _touchPadMode;
			}
			set
			{
				if (_touchPadMode != value)
				{
					_touchPadMode = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public ValueFormat valueFormat
		{
			get
			{
				return _valueFormat;
			}
			set
			{
				if (_valueFormat != value)
				{
					_valueFormat = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public bool useInertia
		{
			get
			{
				return _useInertia;
			}
			set
			{
				if (_useInertia != value)
				{
					_useInertia = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public float inertiaFriction
		{
			get
			{
				return _inertiaFriction;
			}
			set
			{
				value = MathTools.Max(0f, value);
				if (_inertiaFriction != value)
				{
					_inertiaFriction = value;
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

		public bool allowPress
		{
			get
			{
				return _allowPress;
			}
			set
			{
				if (_allowPress != value)
				{
					_allowPress = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public float pressStartDelay
		{
			get
			{
				return _pressStartDelay;
			}
			set
			{
				value = Mathf.Max(0f, value);
				if (_pressStartDelay != value)
				{
					_pressStartDelay = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public int pressDistanceLimit
		{
			get
			{
				return _pressDistanceLimit;
			}
			set
			{
				value = MathTools.Max(-1, value);
				if (_pressDistanceLimit != value)
				{
					_pressDistanceLimit = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public bool hideAtRuntime
		{
			get
			{
				return _hideAtRuntime;
			}
			set
			{
				if (!(_hideAtRuntime = value))
				{
					_hideAtRuntime = true;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
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

		public bool hasPointer => _pointerId != int.MinValue;

		public Vector2 touchStartPosition
		{
			get
			{
				if (!hasPointer)
				{
					return Vector2.zero;
				}
				return _touchStartPosition;
			}
		}

		public Vector2 touchPosition
		{
			get
			{
				if (!TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
				{
					return Vector2.zero;
				}
				return TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(effectivePointerId);
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D axis2D => _axis2D;

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

		private bool tapValue => _lastTapFrame == Time.frameCount;

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

		public event UnityAction PressDownEvent
		{
			add
			{
				_onPressDown.AddListener(value);
			}
			remove
			{
				_onPressDown.RemoveListener(value);
			}
		}

		public event UnityAction PressUpEvent
		{
			add
			{
				_onPressUp.AddListener(value);
			}
			remove
			{
				_onPressUp.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchPad()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying && _hideAtRuntime)
			{
				base.visible = false;
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

		internal override bool USdTaHHNWIGWTOHgBLrxEkaEfPs()
		{
			if (!base.USdTaHHNWIGWTOHgBLrxEkaEfPs())
			{
				return false;
			}
			hjKEKTGDMqTIrdSXayZJBOZvNoba();
			return true;
		}

		internal override void yQdUgprBXDEoWjnetusIxRhMmAu()
		{
			base.yQdUgprBXDEoWjnetusIxRhMmAu();
			if (base.initialized)
			{
				JdZlUojfSleSDdJmJmihEAqvNxTi();
				AekkuDxviraQAPdPqvLzoeQytsn();
				RtHeETQCLbnJNRlSoUyJksTAoMX();
				GrNfMiykKeRRiOsAUdeNIdBdxEn();
				PdjeNUBTNepvCXcUzfiVkxfaLJc();
			}
		}

		internal override void OnoIpIJycGHhdFNrMapnMHSEpPu()
		{
			if (base.initialized && hasController)
			{
				Vector2 vector = ((_touchPadMode == TouchPadMode.ScreenPosition) ? _axis2D.rawValue : _axis2D.value);
				if (_useXAxis)
				{
					npeGbTfGrbHYJDvUuqKBwJdsXleT(_horizontalAxisCustomControllerElement, vector.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					npeGbTfGrbHYJDvUuqKBwJdsXleT(_verticalAxisCustomControllerElement, vector.y, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					npeGbTfGrbHYJDvUuqKBwJdsXleT(_tapCustomControllerElement, tapValue);
				}
				if (_allowPress)
				{
					npeGbTfGrbHYJDvUuqKBwJdsXleT(_pressCustomControllerElement, _pressValue);
				}
			}
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
			base.IEbkrYeiXOaqriLcwiYMyUdsreAF();
			if (base.initialized)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				traAtpHvLXNexVrCRTWuJipMjwd = false;
				IqanMrGVhLvExACtCdEAMqyHqQT = false;
				_pointerDownIsFake = false;
				_currentCenter = Vector2.zero;
				_previousTouchPosition = Vector2.zero;
				_axis2D.Clear();
				_lastTapFrame = -1;
				_pressValue = false;
				_isEligibleForTap = false;
				_isEligibleForPress = false;
			}
		}

		public override void ClearValue()
		{
			if (base.initialized)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				_pressValue = false;
				if (hasController)
				{
					base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
					base.controller.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		private void ZBDmBmYoVxMpOXnsuZypYbLJAdh()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			_pressCustomControllerElement.ClearElementCaches();
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
				if (_allowPress)
				{
					base.controller.ValidateElements(_pressCustomControllerElement);
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
					base.controller.ClearElementValue(_horizontalAxisCustomControllerElement);
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && hasController)
				{
					base.controller.ClearElementValue(_verticalAxisCustomControllerElement);
				}
			}
			_axesToUse = P_0;
		}

		private void AekkuDxviraQAPdPqvLzoeQytsn()
		{
			if (hasPointer && !TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
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
		}

		private void RtHeETQCLbnJNRlSoUyJksTAoMX()
		{
			if (_touchPadMode == TouchPadMode.VectorFromCenter)
			{
				Graphic graphic = base.targetGraphic;
				RectTransform rectTransform = ((graphic != null) ? (graphic.transform as RectTransform) : base.rectTransform);
				_currentCenter = rectTransform.TransformPoint(rectTransform.rect.center);
				_currentCenter = RectTransformUtility.WorldToScreenPoint(base.canvas.worldCamera, _currentCenter);
			}
			if (!hasPointer || !TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
			{
				return;
			}
			Vector3 vector = TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(effectivePointerId);
			Vector2 vector2;
			if (_touchPadMode == TouchPadMode.ScreenPosition)
			{
				vector2 = vector;
			}
			else
			{
				if (_touchPadMode == TouchPadMode.Delta)
				{
					_currentCenter = _previousTouchPosition;
				}
				vector2 = new Vector2(vector.x - _currentCenter.x, vector.y - _currentCenter.y);
			}
			vector2 = VLZDETkkYwOYmUtxEixZLmtJEfT(vector2);
			_axis2D.SetRawValue(vector2.x, vector2.y);
			if (_touchPadMode == TouchPadMode.Delta)
			{
				_smoothDelta.GcIuKOHgXujXqCTdAuwBBVguUoX(vector2.x, vector2.y);
			}
			_previousTouchPosition = vector;
		}

		private void GrNfMiykKeRRiOsAUdeNIdBdxEn()
		{
			if (_touchPadMode == TouchPadMode.Delta && _useInertia && !hasPointer)
			{
				Vector2 rawValue = _axis2D.rawValue;
				float smoothDeltaTime = Time.smoothDeltaTime;
				float num = Mathf.Lerp(rawValue.x, 0f, _inertiaFriction * smoothDeltaTime);
				float num2 = Mathf.Lerp(rawValue.y, 0f, _inertiaFriction * smoothDeltaTime);
				if (MathTools.IsNearZero(num, 0.0001f))
				{
					num = 0f;
				}
				if (MathTools.IsNearZero(num2, 0.0001f))
				{
					num2 = 0f;
				}
				_axis2D.SetRawValue(num, num2);
			}
		}

		private void JdZlUojfSleSDdJmJmihEAqvNxTi()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(effectivePointerId);
				xzaSEYZOOyFOHaePdKwmCThPLuB(ref vector);
				MOkNkaStdXoaoUWyhacOGSCYPGM(ref vector);
			}
		}

		private void xzaSEYZOOyFOHaePdKwmCThPLuB(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private void MOkNkaStdXoaoUWyhacOGSCYPGM(ref Vector2 P_0)
		{
			if (_allowPress && _isEligibleForPress)
			{
				if (_pressDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_pressDistanceLimit)
				{
					_isEligibleForPress = false;
					fuqaCRCodkNWkbgDVrLgVNKVowOT(false);
				}
				else if (!(_pressStartDelay > 0f) || !(Time.realtimeSinceStartup - _touchStartTime < _pressStartDelay))
				{
					fuqaCRCodkNWkbgDVrLgVNKVowOT(true);
				}
			}
		}

		private void PdjeNUBTNepvCXcUzfiVkxfaLJc()
		{
			if (_touchPadMode == TouchPadMode.Delta)
			{
				Vector2 value = _axis2D.value;
				Vector2 valuePrev = _axis2D.valuePrev;
				if (value.x != 0f || value.y != 0f || valuePrev.x != 0f || valuePrev.y != 0f)
				{
					_onValueChanged.Invoke(_axis2D.value);
				}
			}
			else
			{
				Vector2 valueDelta = _axis2D.valueDelta;
				if (valueDelta.x != 0f || valueDelta.y != 0f)
				{
					_onValueChanged.Invoke(_axis2D.value);
				}
			}
		}

		private Vector2 VLZDETkkYwOYmUtxEixZLmtJEfT(Vector2 P_0)
		{
			switch (_valueFormat)
			{
			case ValueFormat.Screen:
				P_0.x /= Screen.width;
				P_0.y /= Screen.height;
				break;
			case ValueFormat.Physical:
			{
				float num = Screen.dpi;
				if (num < 10f)
				{
					num = 96f;
				}
				P_0 = P_0 / num * 100f;
				break;
			}
			case ValueFormat.Direction:
				P_0.Normalize();
				break;
			default:
				throw new NotImplementedException();
			case ValueFormat.Pixels:
				break;
			}
			return P_0;
		}

		private void fuqaCRCodkNWkbgDVrLgVNKVowOT(bool P_0)
		{
			if (P_0 != _pressValue)
			{
				_pressValue = P_0;
				if (P_0)
				{
					_onPressDown.Invoke();
				}
				else
				{
					_onPressUp.Invoke();
				}
			}
		}

		private void VZWPPRkHaAzgbWCTqMIJiKiWgZm(PointerEventData P_0)
		{
			if (!hasPointer || beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				if (zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable())
				{
					cViKfhpmnxGslCDrJoQcTVUDatYE(P_0.pointerId, P_0.pressPosition);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void yQOZXNtLHWGaWIrWSOHsscHiLuT(PointerEventData P_0)
		{
			if ((!hasPointer || beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId)) && !TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
			{
				bCVmmRpfQdgPtiosLDGEOIttkFRM();
				base.OnPointerUp(P_0);
			}
		}

		private void mZbaXWFXpZQDscfQismiYpcuizW(PointerEventData P_0)
		{
			if (hasPointer && !beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0.pointerId);
			bool flag2 = false;
			if (_activateOnSwipeIn && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && (!flag || TouchInteractable.mjfqtOtDkxtBHvBGQKSoLmCVGJt(base.allowedMouseButtons)) && !traAtpHvLXNexVrCRTWuJipMjwd)
			{
				if (flag)
				{
					if (TouchInteractable.qlxzzsOdoUANRhJbnEPLSQzjWeJi(base.allowedMouseButtons, out var realMousePointerId))
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
				GameObject gameObject = base.gameObject;
				PointerEventData pointerEventData = LPSQCjDNxTWIUuTjTGvgkBFgTLH((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					VZWPPRkHaAzgbWCTqMIJiKiWgZm(pointerEventData);
					if (traAtpHvLXNexVrCRTWuJipMjwd)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			IqanMrGVhLvExACtCdEAMqyHqQT = true;
		}

		private void ETirtckwAXAWBWCQmcBygkjzMuX(PointerEventData P_0)
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

		private void cViKfhpmnxGslCDrJoQcTVUDatYE(int P_0, Vector2 P_1)
		{
			_pointerId = P_0;
			traAtpHvLXNexVrCRTWuJipMjwd = true;
			_isEligibleForTap = true;
			_isEligibleForPress = true;
			if (_touchPadMode != TouchPadMode.VectorFromCenter)
			{
				_currentCenter = P_1;
			}
			if (_touchPadMode == TouchPadMode.Delta)
			{
				_previousTouchPosition = P_1;
			}
			_touchStartTime = Time.realtimeSinceStartup;
			_touchStartPosition = P_1;
		}

		private void bCVmmRpfQdgPtiosLDGEOIttkFRM()
		{
			bool flag = _allowTap && _isEligibleForTap;
			ICZaXXGeTWWhejUbLxZSqRsMQuRB();
			traAtpHvLXNexVrCRTWuJipMjwd = false;
			if (_useInertia && _touchPadMode == TouchPadMode.Delta)
			{
				_axis2D.SetRawValue(_smoothDelta.EPfxuURiPnAypEJJumIXhgJMOsij());
			}
			else
			{
				_axis2D.SetRawValue(0f, 0f);
			}
			fuqaCRCodkNWkbgDVrLgVNKVowOT(false);
			_isEligibleForTap = false;
			_isEligibleForPress = false;
			if (flag)
			{
				_lastTapFrame = Time.frameCount + 1;
				_onTap.Invoke();
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				yQOZXNtLHWGaWIrWSOHsscHiLuT(eventData);
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				VZWPPRkHaAzgbWCTqMIJiKiWgZm(eventData);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				mZbaXWFXpZQDscfQismiYpcuizW(eventData);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				ETirtckwAXAWBWCQmcBygkjzMuX(eventData);
			}
		}

		private void ICZaXXGeTWWhejUbLxZSqRsMQuRB()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
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
	}
}
