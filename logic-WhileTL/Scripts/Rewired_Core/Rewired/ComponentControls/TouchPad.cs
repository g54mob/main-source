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
	[AddComponentMenu("Rewired/Touch Pad")]
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

		private class TUKJsddbcTxMwHpEydWUABWUVbfp
		{
			private class afHGOCtXrFhYhcAPDpjjfDkQBcrG
			{
				public float VOqXZFpkfqxthtpirTSkjkUIXYWh;

				public float tHnucPZgaWBgGGxeQZvKhnVcDwSp;

				public uint WIrjufOYMVKYdFHdgPrcSgNBuLui;
			}

			private int AJScDFlQbIrXHSwVGeoAcPqdSqUT;

			private afHGOCtXrFhYhcAPDpjjfDkQBcrG[] vgykPhbigkeVbdfSvoLHgDXxKMQQA;

			private int hXbwTkGIglELkIvAOJmgZwYkqPGIA = -1;

			public TUKJsddbcTxMwHpEydWUABWUVbfp(int P_0)
			{
				if (P_0 < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				AJScDFlQbIrXHSwVGeoAcPqdSqUT = P_0;
				vgykPhbigkeVbdfSvoLHgDXxKMQQA = new afHGOCtXrFhYhcAPDpjjfDkQBcrG[P_0];
				ArrayTools.Populate(vgykPhbigkeVbdfSvoLHgDXxKMQQA);
			}

			public void oZQllQxQuNaPXytzirxUjNaKuQtr(float P_0, float P_1)
			{
				uint currentFrame = ReInput.currentFrame;
				if (hXbwTkGIglELkIvAOJmgZwYkqPGIA < 0 || vgykPhbigkeVbdfSvoLHgDXxKMQQA[hXbwTkGIglELkIvAOJmgZwYkqPGIA].WIrjufOYMVKYdFHdgPrcSgNBuLui != currentFrame)
				{
					ovUSnKlBAKqCwqEnvAOZENnIGvhR();
					afHGOCtXrFhYhcAPDpjjfDkQBcrG obj = vgykPhbigkeVbdfSvoLHgDXxKMQQA[hXbwTkGIglELkIvAOJmgZwYkqPGIA];
					obj.VOqXZFpkfqxthtpirTSkjkUIXYWh = P_0;
					obj.tHnucPZgaWBgGGxeQZvKhnVcDwSp = P_1;
					obj.WIrjufOYMVKYdFHdgPrcSgNBuLui = currentFrame;
				}
			}

			public Vector2 yujbtInuPIYsMrSpSBKSIWawqnAJ()
			{
				if (hXbwTkGIglELkIvAOJmgZwYkqPGIA < 0)
				{
					return default(Vector2);
				}
				int num = hXbwTkGIglELkIvAOJmgZwYkqPGIA;
				afHGOCtXrFhYhcAPDpjjfDkQBcrG afHGOCtXrFhYhcAPDpjjfDkQBcrG2 = vgykPhbigkeVbdfSvoLHgDXxKMQQA[num];
				Vector2 result = new Vector2(afHGOCtXrFhYhcAPDpjjfDkQBcrG2.VOqXZFpkfqxthtpirTSkjkUIXYWh, afHGOCtXrFhYhcAPDpjjfDkQBcrG2.tHnucPZgaWBgGGxeQZvKhnVcDwSp);
				uint wIrjufOYMVKYdFHdgPrcSgNBuLui = afHGOCtXrFhYhcAPDpjjfDkQBcrG2.WIrjufOYMVKYdFHdgPrcSgNBuLui;
				int num2 = num;
				int num3 = 1;
				while ((num2 = bhXRTwznAuglvLevxyiopjiBoaNS(num2, AJScDFlQbIrXHSwVGeoAcPqdSqUT)) != num)
				{
					afHGOCtXrFhYhcAPDpjjfDkQBcrG afHGOCtXrFhYhcAPDpjjfDkQBcrG3 = vgykPhbigkeVbdfSvoLHgDXxKMQQA[num2];
					if (!rQfONOQcCWixZwPycxGWxLhcNQQn(afHGOCtXrFhYhcAPDpjjfDkQBcrG3.WIrjufOYMVKYdFHdgPrcSgNBuLui, wIrjufOYMVKYdFHdgPrcSgNBuLui))
					{
						break;
					}
					result.x += afHGOCtXrFhYhcAPDpjjfDkQBcrG3.VOqXZFpkfqxthtpirTSkjkUIXYWh;
					result.y += afHGOCtXrFhYhcAPDpjjfDkQBcrG3.tHnucPZgaWBgGGxeQZvKhnVcDwSp;
					wIrjufOYMVKYdFHdgPrcSgNBuLui = afHGOCtXrFhYhcAPDpjjfDkQBcrG3.WIrjufOYMVKYdFHdgPrcSgNBuLui;
					num3++;
				}
				if (num3 > 0)
				{
					result.x /= num3;
					result.y /= num3;
				}
				return result;
			}

			private void ovUSnKlBAKqCwqEnvAOZENnIGvhR()
			{
				hXbwTkGIglELkIvAOJmgZwYkqPGIA = OaETxTTojrgKxiFtMBnUDJmIcYrfA(hXbwTkGIglELkIvAOJmgZwYkqPGIA, AJScDFlQbIrXHSwVGeoAcPqdSqUT);
			}

			private static int OaETxTTojrgKxiFtMBnUDJmIcYrfA(int P_0, int P_1)
			{
				if (P_0 >= P_1 - 1)
				{
					return 0;
				}
				return ++P_0;
			}

			private int bhXRTwznAuglvLevxyiopjiBoaNS(int P_0, int P_1)
			{
				if (P_0 > 0)
				{
					return --P_0;
				}
				return P_1 - 1;
			}

			private static bool rQfONOQcCWixZwPycxGWxLhcNQQn(uint P_0, uint P_1)
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

		[Tooltip("The Custom Controller element that will receive input values from the touch pad's Y axis.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from touch pad taps.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[Tooltip("The Custom Controller element that will receive input values from touch pad presses.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[SerializeField]
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		[CustomObfuscation(rename = false)]
		private AxisDirection _axesToUse;

		[Tooltip("The mode of the touch pad.\n\nDelta - Returns the change in position of the touch from the previous to the current frame.\n\nScreen Position - Returns the absolute position of the touch  on the screen.\n\nVector From Center - Returns a vector from the center of the Touch Pad to the current touch position.\n\nVector From Initial Touch - Returns a vector from the intial touch position to the current touch position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchPadMode _touchPadMode;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The format of the resulting data generated by the touch pad.\n\nPixels - Screen pixels.\n\nScreen - The proportion of the value to screen size in the corresponding dimension. 1 unit = 1 screen length (width for X, height for Y).\n\nPhysical - 1 unit = 1/100th of an inch. The resulting value will be consistent across different screen resolutions and sizes. IMPORTANT: This relies on the value returned by UnityEngine.Screen.dpi. If the device does not return a value, a reference resolution of 96 dpi will be used.\n\nDirection - A normalized direction vector.")]
		private ValueFormat _valueFormat;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		private bool _useInertia;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		[SerializeField]
		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		private float _inertiaFriction = 3f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
		private bool _stayActiveOnSwipeOut = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Should taps on the touch pad be processed?")]
		private bool _allowTap;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		[SerializeField]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		private float _tapTimeout = 0.25f;

		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[SerializeField]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		private int _tapDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		[SerializeField]
		private bool _allowPress;

		[SerializeField]
		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		[CustomObfuscation(rename = false)]
		private float _pressStartDelay = 0.1f;

		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[SerializeField]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		private int _pressDistanceLimit = 10;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		private bool _hideAtRuntime;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The underlying Axis 2D.")]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the value changes.")]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TapEventHandler _onTap = new TapEventHandler();

		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private PressDownEventHandler _onPressDown = new PressDownEventHandler();

		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private PressUpEventHandler _onPressUp = new PressUpEventHandler();

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool HNeekbdvHcSGCkhkngTpwdUwueLRA;

		[NonSerialized]
		private bool aMiVitsTbcaHUuBPegFBByVtJKdtA;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private TUKJsddbcTxMwHpEydWUABWUVbfp _smoothDelta = new TUKJsddbcTxMwHpEydWUABWUVbfp(3);

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
					LoesNjgEUrYfdvEfknfJNxZeoYen(value);
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
				if (!TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(QZxLXilNaypGgRZBuiQoBHottyGi))
				{
					return Vector2.zero;
				}
				return TouchInteractable.OGvcMITMMMbQQEcIOflTxFfwaCjh(QZxLXilNaypGgRZBuiQoBHottyGi);
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D JeoDAFkVAltOVqQINZSuDxwGGvnT => _axis2D;

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

		private bool xmVZjoUJWiTDjMKZjjdBUzMMTwIM => _lastTapFrame == Time.frameCount;

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
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				DFIDrBdFGXaeOuMhQIQKCqkLMkPfA();
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			if (!base.qrhyEDreMhRqasASvGWwEiXwPpSPA())
			{
				return false;
			}
			DFIDrBdFGXaeOuMhQIQKCqkLMkPfA();
			return true;
		}

		internal override void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
			base.IghfPvNUXsucbZILFgzLRWwwGmUeA();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				tZIZiJgAAQoalmOpfhkiyBVatjyA();
				egDhVENqiOmptpvGuCmdKvgAwDfc();
				jPLOzLuCVMOZofmyWbFSQsyqPalO();
				yuNqaeAdcDxtFyGSonqAoowREnDdA();
				jujYCShJlVPdbjBwRlPIUkQCBMIK();
			}
		}

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
			{
				Vector2 vector = ((_touchPadMode == TouchPadMode.ScreenPosition) ? _axis2D.rawValue : _axis2D.value);
				if (_useXAxis)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_horizontalAxisCustomControllerElement, vector.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_verticalAxisCustomControllerElement, vector.y, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_tapCustomControllerElement, xmVZjoUJWiTDjMKZjjdBUzMMTwIM);
				}
				if (_allowPress)
				{
					HnasqDsAjOkwcNNgKbRUzSIOurWO(_pressCustomControllerElement, _pressValue);
				}
			}
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
			base.wfYqWOGHtnIUbtMhSNJLmUHIcfqd();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				HNeekbdvHcSGCkhkngTpwdUwueLRA = false;
				aMiVitsTbcaHUuBPegFBByVtJKdtA = false;
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
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				_pressValue = false;
				if (lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_verticalAxisCustomControllerElement);
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			_pressCustomControllerElement.ClearElementCaches();
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
				if (_allowPress)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ValidateElements(_pressCustomControllerElement);
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
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_horizontalAxisCustomControllerElement);
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_verticalAxisCustomControllerElement);
				}
			}
			_axesToUse = P_0;
		}

		private void egDhVENqiOmptpvGuCmdKvgAwDfc()
		{
			if (hasPointer && !TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(QZxLXilNaypGgRZBuiQoBHottyGi))
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
		}

		private void jPLOzLuCVMOZofmyWbFSQsyqPalO()
		{
			if (_touchPadMode == TouchPadMode.VectorFromCenter)
			{
				Graphic graphic = base.targetGraphic;
				RectTransform rectTransform = ((graphic != null) ? (graphic.transform as RectTransform) : base.uBgsATlVNpCXLTZUrAUVBouJZPML);
				_currentCenter = rectTransform.TransformPoint(rectTransform.rect.center);
				_currentCenter = RectTransformUtility.WorldToScreenPoint(base.oJQqczDhICKLxrvFLqPtRJoISnkJ.worldCamera, _currentCenter);
			}
			if (!hasPointer || !TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(QZxLXilNaypGgRZBuiQoBHottyGi))
			{
				return;
			}
			Vector3 vector = TouchInteractable.OGvcMITMMMbQQEcIOflTxFfwaCjh(QZxLXilNaypGgRZBuiQoBHottyGi);
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
			vector2 = tXNPALAQdRqYPaHVmsPMbOpxtGdF(vector2);
			_axis2D.SetRawValue(vector2.x, vector2.y);
			if (_touchPadMode == TouchPadMode.Delta)
			{
				_smoothDelta.oZQllQxQuNaPXytzirxUjNaKuQtr(vector2.x, vector2.y);
			}
			_previousTouchPosition = vector;
		}

		private void yuNqaeAdcDxtFyGSonqAoowREnDdA()
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

		private void tZIZiJgAAQoalmOpfhkiyBVatjyA()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.OGvcMITMMMbQQEcIOflTxFfwaCjh(QZxLXilNaypGgRZBuiQoBHottyGi);
				ZimENQhoONdnkMiATgBvHaarzNpaA(ref vector);
				qxoxxkadvsEkFyCJRnTZidOwUrqd(ref vector);
			}
		}

		private void ZimENQhoONdnkMiATgBvHaarzNpaA(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private void qxoxxkadvsEkFyCJRnTZidOwUrqd(ref Vector2 P_0)
		{
			if (_allowPress && _isEligibleForPress)
			{
				if (_pressDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_pressDistanceLimit)
				{
					_isEligibleForPress = false;
					LlqBBPYhxZcqLjQzrUOzHnxjYumY(false);
				}
				else if (!(_pressStartDelay > 0f) || !(Time.realtimeSinceStartup - _touchStartTime < _pressStartDelay))
				{
					LlqBBPYhxZcqLjQzrUOzHnxjYumY(true);
				}
			}
		}

		private void jujYCShJlVPdbjBwRlPIUkQCBMIK()
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

		private Vector2 tXNPALAQdRqYPaHVmsPMbOpxtGdF(Vector2 P_0)
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

		private void LlqBBPYhxZcqLjQzrUOzHnxjYumY(bool P_0)
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

		private void xIWWjJOuupYMQcrdMBCGCHPaXBWI(PointerEventData P_0)
		{
			if (!hasPointer || ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				if (BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable())
				{
					IusOvBAtCSXEzhPnHLjnVptEdmr(P_0.pointerId, P_0.pressPosition);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void IoGbCPRdLbcSdkogaRArqCgIugjmA(PointerEventData P_0)
		{
			if ((!hasPointer || ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId)) && !TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(QZxLXilNaypGgRZBuiQoBHottyGi))
			{
				VDahXJPMYKnASeYtoJZirWDQPxW();
				base.OnPointerUp(P_0);
			}
		}

		private void QcjNpGrRNqqqNCrPAtddavSMTuin(PointerEventData P_0)
		{
			if (hasPointer && !ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0.pointerId);
			bool flag2 = false;
			if (_activateOnSwipeIn && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && (!flag || TouchInteractable.KsjMbURloCOTuFHgwOLhnvhvdPJW(base.allowedMouseButtons)) && !HNeekbdvHcSGCkhkngTpwdUwueLRA)
			{
				if (flag)
				{
					if (TouchInteractable.IBzkqesnobxsqrtNNOtMshEFafzK(base.allowedMouseButtons, out var realMousePointerId))
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
				PointerEventData pointerEventData = tmSHozvxCeyplYJTdurtEufONlsc((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					xIWWjJOuupYMQcrdMBCGCHPaXBWI(pointerEventData);
					if (HNeekbdvHcSGCkhkngTpwdUwueLRA)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			aMiVitsTbcaHUuBPegFBByVtJKdtA = true;
		}

		private void qbFkezCsiyAgtoKeAIvWYmFVHAOW(PointerEventData P_0)
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

		private void IusOvBAtCSXEzhPnHLjnVptEdmr(int P_0, Vector2 P_1)
		{
			_pointerId = P_0;
			HNeekbdvHcSGCkhkngTpwdUwueLRA = true;
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

		private void VDahXJPMYKnASeYtoJZirWDQPxW()
		{
			bool num = _allowTap && _isEligibleForTap;
			ykJYYTWDBrPpTaxVtKiVzeDkBkrt();
			HNeekbdvHcSGCkhkngTpwdUwueLRA = false;
			if (_useInertia && _touchPadMode == TouchPadMode.Delta)
			{
				_axis2D.SetRawValue(_smoothDelta.yujbtInuPIYsMrSpSBKSIWawqnAJ());
			}
			else
			{
				_axis2D.SetRawValue(0f, 0f);
			}
			LlqBBPYhxZcqLjQzrUOzHnxjYumY(false);
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
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				IoGbCPRdLbcSdkogaRArqCgIugjmA(eventData);
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				xIWWjJOuupYMQcrdMBCGCHPaXBWI(eventData);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				QcjNpGrRNqqqNCrPAtddavSMTuin(eventData);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				qbFkezCsiyAgtoKeAIvWYmFVHAOW(eventData);
			}
		}

		private void ykJYYTWDBrPpTaxVtKiVzeDkBkrt()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
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
	}
}
