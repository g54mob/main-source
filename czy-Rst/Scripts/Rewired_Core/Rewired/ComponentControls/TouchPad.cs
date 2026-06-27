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
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Pad")]
	public sealed class TouchPad : TouchInteractable, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
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

		private class amBqeIpKGbgmXHhpMDzhDxiIsYHcA
		{
			private class HUKUbSxxAjNMoepklOCjMtrSqVoB
			{
				public float zWFhBRaLnUxdvUZKEaPRDfScsjqm;

				public float nesCbQMutuKQuIjvNPUAkWlmCofF;

				public uint wzeUQJuLkprpNDFhMiJKxnjbxaFM;
			}

			private int EoqkjSWhkUZpwCUjTcPsnMkltCre;

			private HUKUbSxxAjNMoepklOCjMtrSqVoB[] pEvshXFUpihewhXQIgMsamQxadrAA;

			private int pmJADUuRbiUIousKwAuNcjmHRWRd = -1;

			public amBqeIpKGbgmXHhpMDzhDxiIsYHcA(int P_0)
			{
				if (P_0 < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				EoqkjSWhkUZpwCUjTcPsnMkltCre = P_0;
				pEvshXFUpihewhXQIgMsamQxadrAA = new HUKUbSxxAjNMoepklOCjMtrSqVoB[P_0];
				ArrayTools.Populate(pEvshXFUpihewhXQIgMsamQxadrAA);
			}

			public void PuMynjeldQAxGbbyiCmYBRuqWcvf(float P_0, float P_1)
			{
				uint currentFrame = ReInput.currentFrame;
				if (pmJADUuRbiUIousKwAuNcjmHRWRd < 0 || pEvshXFUpihewhXQIgMsamQxadrAA[pmJADUuRbiUIousKwAuNcjmHRWRd].wzeUQJuLkprpNDFhMiJKxnjbxaFM != currentFrame)
				{
					yGokJRVmSodJjcNqLHjtEBbYNjAaA();
					HUKUbSxxAjNMoepklOCjMtrSqVoB obj = pEvshXFUpihewhXQIgMsamQxadrAA[pmJADUuRbiUIousKwAuNcjmHRWRd];
					obj.zWFhBRaLnUxdvUZKEaPRDfScsjqm = P_0;
					obj.nesCbQMutuKQuIjvNPUAkWlmCofF = P_1;
					obj.wzeUQJuLkprpNDFhMiJKxnjbxaFM = currentFrame;
				}
			}

			public Vector2 AvCcTSjBTcJZQKiYIFNqDKnyYNLLA()
			{
				if (pmJADUuRbiUIousKwAuNcjmHRWRd < 0)
				{
					return default(Vector2);
				}
				int num = pmJADUuRbiUIousKwAuNcjmHRWRd;
				HUKUbSxxAjNMoepklOCjMtrSqVoB hUKUbSxxAjNMoepklOCjMtrSqVoB = pEvshXFUpihewhXQIgMsamQxadrAA[num];
				Vector2 result = new Vector2(hUKUbSxxAjNMoepklOCjMtrSqVoB.zWFhBRaLnUxdvUZKEaPRDfScsjqm, hUKUbSxxAjNMoepklOCjMtrSqVoB.nesCbQMutuKQuIjvNPUAkWlmCofF);
				uint wzeUQJuLkprpNDFhMiJKxnjbxaFM = hUKUbSxxAjNMoepklOCjMtrSqVoB.wzeUQJuLkprpNDFhMiJKxnjbxaFM;
				int num2 = num;
				int num3 = 1;
				while ((num2 = XujxXRSMFZVgEDozKHdwseFfqpyk(num2, EoqkjSWhkUZpwCUjTcPsnMkltCre)) != num)
				{
					HUKUbSxxAjNMoepklOCjMtrSqVoB hUKUbSxxAjNMoepklOCjMtrSqVoB2 = pEvshXFUpihewhXQIgMsamQxadrAA[num2];
					if (!eTfncsdUbhqDCBGjjiSaffwaHZUQ(hUKUbSxxAjNMoepklOCjMtrSqVoB2.wzeUQJuLkprpNDFhMiJKxnjbxaFM, wzeUQJuLkprpNDFhMiJKxnjbxaFM))
					{
						break;
					}
					result.x += hUKUbSxxAjNMoepklOCjMtrSqVoB2.zWFhBRaLnUxdvUZKEaPRDfScsjqm;
					result.y += hUKUbSxxAjNMoepklOCjMtrSqVoB2.nesCbQMutuKQuIjvNPUAkWlmCofF;
					wzeUQJuLkprpNDFhMiJKxnjbxaFM = hUKUbSxxAjNMoepklOCjMtrSqVoB2.wzeUQJuLkprpNDFhMiJKxnjbxaFM;
					num3++;
				}
				if (num3 > 0)
				{
					result.x /= num3;
					result.y /= num3;
				}
				return result;
			}

			private void yGokJRVmSodJjcNqLHjtEBbYNjAaA()
			{
				pmJADUuRbiUIousKwAuNcjmHRWRd = OuTDTrkPWQEQCDSjCplAUvlWnypcA(pmJADUuRbiUIousKwAuNcjmHRWRd, EoqkjSWhkUZpwCUjTcPsnMkltCre);
			}

			private static int OuTDTrkPWQEQCDSjCplAUvlWnypcA(int P_0, int P_1)
			{
				if (P_0 >= P_1 - 1)
				{
					return 0;
				}
				return ++P_0;
			}

			private int XujxXRSMFZVgEDozKHdwseFfqpyk(int P_0, int P_1)
			{
				if (P_0 > 0)
				{
					return --P_0;
				}
				return P_1 - 1;
			}

			private static bool eTfncsdUbhqDCBGjjiSaffwaHZUQ(uint P_0, uint P_1)
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

		[Tooltip("The Custom Controller element that will receive input values from the touch pad's X axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from the touch pad's Y axis.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from touch pad taps.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[Tooltip("The Custom Controller element that will receive input values from touch pad presses.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisDirection _axesToUse;

		[Tooltip("The mode of the touch pad.\n\nDelta - Returns the change in position of the touch from the previous to the current frame.\n\nScreen Position - Returns the absolute position of the touch  on the screen.\n\nVector From Center - Returns a vector from the center of the Touch Pad to the current touch position.\n\nVector From Initial Touch - Returns a vector from the intial touch position to the current touch position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPadMode _touchPadMode;

		[Tooltip("The format of the resulting data generated by the touch pad.\n\nPixels - Screen pixels.\n\nScreen - The proportion of the value to screen size in the corresponding dimension. 1 unit = 1 screen length (width for X, height for Y).\n\nPhysical - 1 unit = 1/100th of an inch. The resulting value will be consistent across different screen resolutions and sizes. IMPORTANT: This relies on the value returned by UnityEngine.Screen.dpi. If the device does not return a value, a reference resolution of 96 dpi will be used.\n\nDirection - A normalized direction vector.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueFormat _valueFormat;

		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useInertia;

		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		private float _inertiaFriction = 3f;

		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
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

		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _allowPress;

		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _pressStartDelay = 0.1f;

		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		private int _pressDistanceLimit = 10;

		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime;

		[Tooltip("The underlying Axis 2D.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		[Tooltip("Event sent when the value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TapEventHandler _onTap = new TapEventHandler();

		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PressDownEventHandler _onPressDown = new PressDownEventHandler();

		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private PressUpEventHandler _onPressUp = new PressUpEventHandler();

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool xsWAbrEZoqPcocgNHscoUnFwmpItA;

		[NonSerialized]
		private bool RTSilXksnfupFudohifUTNwNvCWL;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private amBqeIpKGbgmXHhpMDzhDxiIsYHcA _smoothDelta = new amBqeIpKGbgmXHhpMDzhDxiIsYHcA(3);

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
					oabUkzZMEOILXTsGClubquThwjal(value);
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
				if (!TouchInteractable.IZIBozfCzyDkZOWWaGlLiEtSPYyB(kOHAXSoxWGxdvPCIDQnjjFtNcoAK))
				{
					return Vector2.zero;
				}
				return TouchInteractable.RKVcirKVVrPBttTpsXyGcfygGdOQ(kOHAXSoxWGxdvPCIDQnjjFtNcoAK);
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D WUbUREBKDLayWCYcEvDzfAsPNnABb => _axis2D;

		private int kOHAXSoxWGxdvPCIDQnjjFtNcoAK
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

		private bool rIGFquSwmFDgJVEyfgtzQlTzDIzJA => _lastTapFrame == Time.frameCount;

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
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				wTUxTfmXXXgXusiKkwDDbfKLuaNp();
				cHHfSLeIXoapINfMppQUCbwonFtlA();
			}
		}

		internal bool yAlFuKdUUhucsEcAzGOeRXNHXoDUA()
		{
			if (!txYYAAoRiaPItjnHJYZsolhdcVNl())
			{
				return false;
			}
			wTUxTfmXXXgXusiKkwDDbfKLuaNp();
			return true;
		}

		internal void fiPqVnsAdwRxstSyKkPNQiXSdURt()
		{
			base.QcGIWLDDCIjLkBgZbJZNrqDVlpFrb();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				GtGBpTSzBckVhZilsopvWihOdElE();
				XymbLWfJNwwaQhGBnvluaTxQctrhA();
				axksndjiYMthJsxEzLrtAFjpEPjP();
				zSzacdGRRdeqDqFPmCNNfXTEYvRfA();
				OQrKcPWTWaPRViKZIALyzquKWNSW();
			}
		}

		internal void qncaOBKwogrkEPCRTBgWbQaGbrEHA()
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && sBSyLdyBEZqxqMQAUOeeTuCypwge)
			{
				Vector2 vector = ((_touchPadMode == TouchPadMode.ScreenPosition) ? _axis2D.rawValue : _axis2D.value);
				if (_useXAxis)
				{
					AXiqrbJHOthQgiWhbUsFiQksmOuF(_horizontalAxisCustomControllerElement, vector.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					AXiqrbJHOthQgiWhbUsFiQksmOuF(_verticalAxisCustomControllerElement, vector.y, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					yIGACPdPxKNbFAccDkxmGzqfXbQjc(_tapCustomControllerElement, rIGFquSwmFDgJVEyfgtzQlTzDIzJA);
				}
				if (_allowPress)
				{
					yIGACPdPxKNbFAccDkxmGzqfXbQjc(_pressCustomControllerElement, _pressValue);
				}
			}
		}

		internal void skWypXgQTcKIuZdSOzUptfRGcSyhA()
		{
			RxXwmSTcDqekzOuyZktlaLRThxqq();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				wTUxTfmXXXgXusiKkwDDbfKLuaNp();
				cHHfSLeIXoapINfMppQUCbwonFtlA();
			}
		}

		internal void gHWgiPdgPtjDXhIBEnUFptlfRuapA()
		{
			base.uqpvXSxBdciqAsrvTMJdOHfWenSP();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				xsWAbrEZoqPcocgNHscoUnFwmpItA = false;
				RTSilXksnfupFudohifUTNwNvCWL = false;
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
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				_pressValue = false;
				if (sBSyLdyBEZqxqMQAUOeeTuCypwge)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ClearElementValue(_verticalAxisCustomControllerElement);
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		private void cHHfSLeIXoapINfMppQUCbwonFtlA()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			_pressCustomControllerElement.ClearElementCaches();
		}

		private void wTUxTfmXXXgXusiKkwDDbfKLuaNp()
		{
			oabUkzZMEOILXTsGClubquThwjal(_axesToUse);
			if (sBSyLdyBEZqxqMQAUOeeTuCypwge && base.xwgeSLedLROHvElpicUYfVBhKnCJd.useCustomController)
			{
				if (_useXAxis)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ValidateElements(_horizontalAxisCustomControllerElement);
				}
				if (_useYAxis)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ValidateElements(_verticalAxisCustomControllerElement);
				}
				if (_allowTap)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ValidateElements(_tapCustomControllerElement);
				}
				if (_allowPress)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ValidateElements(_pressCustomControllerElement);
				}
			}
		}

		private void oabUkzZMEOILXTsGClubquThwjal(AxisDirection P_0)
		{
			bool flag = P_0 == AxisDirection.Both || P_0 == AxisDirection.Horizontal;
			if (_useXAxis != flag)
			{
				_useXAxis = flag;
				if (!flag && sBSyLdyBEZqxqMQAUOeeTuCypwge)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ClearElementValue(_horizontalAxisCustomControllerElement);
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && sBSyLdyBEZqxqMQAUOeeTuCypwge)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ClearElementValue(_verticalAxisCustomControllerElement);
				}
			}
			_axesToUse = P_0;
		}

		private void XymbLWfJNwwaQhGBnvluaTxQctrhA()
		{
			if (hasPointer && !TouchInteractable.IZIBozfCzyDkZOWWaGlLiEtSPYyB(kOHAXSoxWGxdvPCIDQnjjFtNcoAK))
			{
				PointerEventData pointerEventData = rBHDixUPGohuOAOcWPXjOZdFcXvYA(kOHAXSoxWGxdvPCIDQnjjFtNcoAK);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					WlmYeKvZnTShNVZlVDsAWHuTQbMq(pointerEventData);
				}
				else
				{
					xRCmKdTYJgGpHBGnRJlKQZQDZkrh();
				}
			}
		}

		private void axksndjiYMthJsxEzLrtAFjpEPjP()
		{
			if (_touchPadMode == TouchPadMode.VectorFromCenter)
			{
				Graphic graphic = base.targetGraphic;
				RectTransform rectTransform = ((graphic != null) ? (graphic.transform as RectTransform) : base.VyVEENbwGDUYbEgmFqxSHryubuWYA);
				_currentCenter = rectTransform.TransformPoint(rectTransform.rect.center);
				_currentCenter = RectTransformUtility.WorldToScreenPoint(base.pvOOYOdfJNCdvfQqvCELdEURThOr.worldCamera, _currentCenter);
			}
			if (!hasPointer || !TouchInteractable.IZIBozfCzyDkZOWWaGlLiEtSPYyB(kOHAXSoxWGxdvPCIDQnjjFtNcoAK))
			{
				return;
			}
			Vector3 vector = TouchInteractable.RKVcirKVVrPBttTpsXyGcfygGdOQ(kOHAXSoxWGxdvPCIDQnjjFtNcoAK);
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
			vector2 = QIxNUWGVDndJuedmXyfAvwSYHanL(vector2);
			_axis2D.SetRawValue(vector2.x, vector2.y);
			if (_touchPadMode == TouchPadMode.Delta)
			{
				_smoothDelta.PuMynjeldQAxGbbyiCmYBRuqWcvf(vector2.x, vector2.y);
			}
			_previousTouchPosition = vector;
		}

		private void zSzacdGRRdeqDqFPmCNNfXTEYvRfA()
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

		private void GtGBpTSzBckVhZilsopvWihOdElE()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.RKVcirKVVrPBttTpsXyGcfygGdOQ(kOHAXSoxWGxdvPCIDQnjjFtNcoAK);
				dRxtFnQepOpRXfYYWnDCnvaXvAzM(ref vector);
				YQEpTipTIZbGTBeXlfOTGLlAERTcA(ref vector);
			}
		}

		private void dRxtFnQepOpRXfYYWnDCnvaXvAzM(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private void YQEpTipTIZbGTBeXlfOTGLlAERTcA(ref Vector2 P_0)
		{
			if (_allowPress && _isEligibleForPress)
			{
				if (_pressDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_pressDistanceLimit)
				{
					_isEligibleForPress = false;
					jAPvUdywSzzxiiQandoJchoxdTxt(false);
				}
				else if (!(_pressStartDelay > 0f) || !(Time.realtimeSinceStartup - _touchStartTime < _pressStartDelay))
				{
					jAPvUdywSzzxiiQandoJchoxdTxt(true);
				}
			}
		}

		private void OQrKcPWTWaPRViKZIALyzquKWNSW()
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

		private Vector2 QIxNUWGVDndJuedmXyfAvwSYHanL(Vector2 P_0)
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

		private void jAPvUdywSzzxiiQandoJchoxdTxt(bool P_0)
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

		private void ddKdLlgdRpdxFpLWdAhexCDxhAYtA(PointerEventData P_0)
		{
			if (!hasPointer || cVyytefdIeFxYDDPrUbEMbvbwFAU(P_0.pointerId))
			{
				if (GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable())
				{
					ZYFgbHaUWvpMZooSpPegFmMJufSWb(P_0.pointerId, P_0.pressPosition);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void KGBMuIYlcLYcZlMqVxHnDIEkIsjl(PointerEventData P_0)
		{
			if ((!hasPointer || cVyytefdIeFxYDDPrUbEMbvbwFAU(P_0.pointerId)) && !TouchInteractable.IZIBozfCzyDkZOWWaGlLiEtSPYyB(kOHAXSoxWGxdvPCIDQnjjFtNcoAK))
			{
				xRCmKdTYJgGpHBGnRJlKQZQDZkrh();
				base.OnPointerUp(P_0);
			}
		}

		private void gVLDApFUnGsbgczvGtLXtqwoFGdGb(PointerEventData P_0)
		{
			if (hasPointer && !cVyytefdIeFxYDDPrUbEMbvbwFAU(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0.pointerId);
			bool flag2 = false;
			if (_activateOnSwipeIn && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && (!flag || TouchInteractable.sZOlWOgCsSeAIquqRVBCziBDPwZl(base.allowedMouseButtons)) && !xsWAbrEZoqPcocgNHscoUnFwmpItA)
			{
				if (flag)
				{
					if (TouchInteractable.lkQTlwjROwXyeNpzHpZbVfPTZrXg(base.allowedMouseButtons, out var realMousePointerId))
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
				PointerEventData pointerEventData = xuVgyWDtTtPPJdeBhQoyzkcSpvseB((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					ddKdLlgdRpdxFpLWdAhexCDxhAYtA(pointerEventData);
					if (xsWAbrEZoqPcocgNHscoUnFwmpItA)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			RTSilXksnfupFudohifUTNwNvCWL = true;
		}

		private void XlIXGoxbjeosUPJGGRtNiCabxvIW(PointerEventData P_0)
		{
			if (hasPointer && !cVyytefdIeFxYDDPrUbEMbvbwFAU(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && xsWAbrEZoqPcocgNHscoUnFwmpItA)
			{
				xRCmKdTYJgGpHBGnRJlKQZQDZkrh();
			}
			base.OnPointerExit(P_0);
			RTSilXksnfupFudohifUTNwNvCWL = false;
		}

		private void ZYFgbHaUWvpMZooSpPegFmMJufSWb(int P_0, Vector2 P_1)
		{
			_pointerId = P_0;
			xsWAbrEZoqPcocgNHscoUnFwmpItA = true;
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

		private void xRCmKdTYJgGpHBGnRJlKQZQDZkrh()
		{
			bool num = _allowTap && _isEligibleForTap;
			QvARxSmPBgQaxHddpVfUCpmFfTAGA();
			xsWAbrEZoqPcocgNHscoUnFwmpItA = false;
			if (_useInertia && _touchPadMode == TouchPadMode.Delta)
			{
				_axis2D.SetRawValue(_smoothDelta.AvCcTSjBTcJZQKiYIFNqDKnyYNLLA());
			}
			else
			{
				_axis2D.SetRawValue(0f, 0f);
			}
			jAPvUdywSzzxiiQandoJchoxdTxt(false);
			_isEligibleForTap = false;
			_isEligibleForPress = false;
			if (num)
			{
				_lastTapFrame = Time.frameCount + 1;
				_onTap.Invoke();
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				KGBMuIYlcLYcZlMqVxHnDIEkIsjl(eventData);
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				ddKdLlgdRpdxFpLWdAhexCDxhAYtA(eventData);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				gVLDApFUnGsbgczvGtLXtqwoFGdGb(eventData);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				XlIXGoxbjeosUPJGGRtNiCabxvIW(eventData);
			}
		}

		private void QvARxSmPBgQaxHddpVfUCpmFfTAGA()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
		}

		private bool cVyytefdIeFxYDDPrUbEMbvbwFAU(int P_0)
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
			if (TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0) && _realMousePointerId != int.MinValue && P_0 == _realMousePointerId)
			{
				return true;
			}
			return false;
		}

		private PointerEventData xuVgyWDtTtPPJdeBhQoyzkcSpvseB(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = rBHDixUPGohuOAOcWPXjOZdFcXvYA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.RKVcirKVVrPBttTpsXyGcfygGdOQ(P_0);
			if (TouchInteractable.DrDqLttSkyvwiIzPAjMBncpcYrPv(P_0))
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
				if (!TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0))
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

		private PointerEventData jvHRFXxTgqwgHCpYmuqIJNxBnCbj(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = rBHDixUPGohuOAOcWPXjOZdFcXvYA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			Vector2 vector = TouchInteractable.RKVcirKVVrPBttTpsXyGcfygGdOQ(P_0);
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.dragging = true;
			pointerEventData.pointerDrag = P_1;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			return pointerEventData;
		}

		private PointerEventData dCkZPdEMBrOmzxzxbCtMizTnIsPu(int P_0)
		{
			PointerEventData pointerEventData = rBHDixUPGohuOAOcWPXjOZdFcXvYA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.DrDqLttSkyvwiIzPAjMBncpcYrPv(P_0))
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
				if (!TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0))
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

		private void WlmYeKvZnTShNVZlVDsAWHuTQbMq(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				dCkZPdEMBrOmzxzxbCtMizTnIsPu(kOHAXSoxWGxdvPCIDQnjjFtNcoAK);
			}
		}

		private PointerEventData rBHDixUPGohuOAOcWPXjOZdFcXvYA(int P_0)
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
				if (TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0))
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
