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
	[AddComponentMenu("Rewired/Touch Controls/Touch Pad")]
	[RequireComponent(typeof(Image))]
	[DisallowMultipleComponent]
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

		private class cyElaPTCfXjYPsqMNsszDxNDvbbB
		{
			private class NBTsHDBgbHwGLHdiowHPeoqHaTbDA
			{
				public float cLwWUIFFJkYELAfQMrjOynpLvFSp;

				public float EYxlxKdKWUPYipWWxXVcknevqWWh;

				public uint xsfBoabwqLRrLvyBRBnSeNmHKaqkb;
			}

			private int pSMcOWNrPShgdHfbdxAwdxHoSiQNA;

			private NBTsHDBgbHwGLHdiowHPeoqHaTbDA[] YWqICyZAZaepLWeAIxsfAwguINSd;

			private int KorITzkUWrapWSEcrMKEngxzFXIp = -1;

			public cyElaPTCfXjYPsqMNsszDxNDvbbB(int P_0)
			{
				if (P_0 < 2)
				{
					throw new ArgumentOutOfRangeException("maxSmoothFrames must be >= 2");
				}
				pSMcOWNrPShgdHfbdxAwdxHoSiQNA = P_0;
				YWqICyZAZaepLWeAIxsfAwguINSd = new NBTsHDBgbHwGLHdiowHPeoqHaTbDA[P_0];
				ArrayTools.Populate(YWqICyZAZaepLWeAIxsfAwguINSd);
			}

			public void ZCYeQXTQlBeczBTsRNSgmJnLWcxf(float P_0, float P_1)
			{
				uint currentFrame = ReInput.currentFrame;
				if (KorITzkUWrapWSEcrMKEngxzFXIp < 0 || YWqICyZAZaepLWeAIxsfAwguINSd[KorITzkUWrapWSEcrMKEngxzFXIp].xsfBoabwqLRrLvyBRBnSeNmHKaqkb != currentFrame)
				{
					LEOsDTTMmUXJETXXARunNIMZPbzm();
					NBTsHDBgbHwGLHdiowHPeoqHaTbDA obj = YWqICyZAZaepLWeAIxsfAwguINSd[KorITzkUWrapWSEcrMKEngxzFXIp];
					obj.cLwWUIFFJkYELAfQMrjOynpLvFSp = P_0;
					obj.EYxlxKdKWUPYipWWxXVcknevqWWh = P_1;
					obj.xsfBoabwqLRrLvyBRBnSeNmHKaqkb = currentFrame;
				}
			}

			public Vector2 TrrycHHAvYjjqUhXpavsZTNfcmMFA()
			{
				if (KorITzkUWrapWSEcrMKEngxzFXIp < 0)
				{
					return default(Vector2);
				}
				int korITzkUWrapWSEcrMKEngxzFXIp = KorITzkUWrapWSEcrMKEngxzFXIp;
				NBTsHDBgbHwGLHdiowHPeoqHaTbDA nBTsHDBgbHwGLHdiowHPeoqHaTbDA = YWqICyZAZaepLWeAIxsfAwguINSd[korITzkUWrapWSEcrMKEngxzFXIp];
				Vector2 result = new Vector2(nBTsHDBgbHwGLHdiowHPeoqHaTbDA.cLwWUIFFJkYELAfQMrjOynpLvFSp, nBTsHDBgbHwGLHdiowHPeoqHaTbDA.EYxlxKdKWUPYipWWxXVcknevqWWh);
				uint xsfBoabwqLRrLvyBRBnSeNmHKaqkb = nBTsHDBgbHwGLHdiowHPeoqHaTbDA.xsfBoabwqLRrLvyBRBnSeNmHKaqkb;
				int num = korITzkUWrapWSEcrMKEngxzFXIp;
				int num2 = 1;
				while ((num = EXHKntFfugSRTqcNOUwAgsVSqVBG(num, pSMcOWNrPShgdHfbdxAwdxHoSiQNA)) != korITzkUWrapWSEcrMKEngxzFXIp)
				{
					NBTsHDBgbHwGLHdiowHPeoqHaTbDA nBTsHDBgbHwGLHdiowHPeoqHaTbDA2 = YWqICyZAZaepLWeAIxsfAwguINSd[num];
					if (!EulCxBswuIIAfLUQDouwyOipQCMd(nBTsHDBgbHwGLHdiowHPeoqHaTbDA2.xsfBoabwqLRrLvyBRBnSeNmHKaqkb, xsfBoabwqLRrLvyBRBnSeNmHKaqkb))
					{
						break;
					}
					result.x += nBTsHDBgbHwGLHdiowHPeoqHaTbDA2.cLwWUIFFJkYELAfQMrjOynpLvFSp;
					result.y += nBTsHDBgbHwGLHdiowHPeoqHaTbDA2.EYxlxKdKWUPYipWWxXVcknevqWWh;
					xsfBoabwqLRrLvyBRBnSeNmHKaqkb = nBTsHDBgbHwGLHdiowHPeoqHaTbDA2.xsfBoabwqLRrLvyBRBnSeNmHKaqkb;
					num2++;
				}
				if (num2 > 0)
				{
					result.x /= num2;
					result.y /= num2;
				}
				return result;
			}

			private void LEOsDTTMmUXJETXXARunNIMZPbzm()
			{
				KorITzkUWrapWSEcrMKEngxzFXIp = xWMzGAzNXjPHJDYFbIRmAfXDQWdN(KorITzkUWrapWSEcrMKEngxzFXIp, pSMcOWNrPShgdHfbdxAwdxHoSiQNA);
			}

			private static int xWMzGAzNXjPHJDYFbIRmAfXDQWdN(int P_0, int P_1)
			{
				if (P_0 >= P_1 - 1)
				{
					return 0;
				}
				return ++P_0;
			}

			private int EXHKntFfugSRTqcNOUwAgsVSqVBG(int P_0, int P_1)
			{
				if (P_0 > 0)
				{
					return --P_0;
				}
				return P_1 - 1;
			}

			private static bool EulCxBswuIIAfLUQDouwyOipQCMd(uint P_0, uint P_1)
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's X axis.")]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from the touch pad's Y axis.")]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement = new CustomControllerElementTargetSetForFloat();

		[Tooltip("The Custom Controller element that will receive input values from touch pad taps.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from touch pad presses.")]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement = new CustomControllerElementTargetSetForBoolean();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The axis directions in which movement is allowed. You can restrict movement to one or both axes.")]
		private AxisDirection _axesToUse;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The mode of the touch pad.\n\nDelta - Returns the change in position of the touch from the previous to the current frame.\n\nScreen Position - Returns the absolute position of the touch  on the screen.\n\nVector From Center - Returns a vector from the center of the Touch Pad to the current touch position.\n\nVector From Initial Touch - Returns a vector from the intial touch position to the current touch position.")]
		private TouchPadMode _touchPadMode;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The format of the resulting data generated by the touch pad.\n\nPixels - Screen pixels.\n\nScreen - The proportion of the value to screen size in the corresponding dimension. 1 unit = 1 screen length (width for X, height for Y).\n\nPhysical - 1 unit = 1/100th of an inch. The resulting value will be consistent across different screen resolutions and sizes. IMPORTANT: This relies on the value returned by UnityEngine.Screen.dpi. If the device does not return a value, a reference resolution of 96 dpi will be used.\n\nDirection - A normalized direction vector.")]
		private ValueFormat _valueFormat;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, when swiped and released, the value will slowly fall toward zero based on the Friction value. This only has an effect if Touch Pad Mode is set to Position Delta.")]
		private bool _useInertia;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		[Tooltip("Determines how quickly a swipe value will fall toward zero when Use Inertia is enabled.")]
		[SerializeField]
		private float _inertiaFriction = 3f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the touch pad can be activated by a touch swipe that began in an area outside the touch pad region. If false, the touch pad can only be activated by a direct touch.")]
		private bool _activateOnSwipeIn;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the touch pad will stay engaged even if the touch that activated it moves outside the touch pad region. If false, the touch pad will be released once the touch that activated it moves outside the touch pad region.")]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should taps on the touch pad be processed?")]
		private bool _allowTap;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.MaxValue)]
		[Tooltip("The maximum touch duration allowed for the touch to be considered a tap. A touch that lasts longer than this value will not trigger a tap when released.")]
		[SerializeField]
		private float _tapTimeout = 0.25f;

		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a tap. [-1 = no limit]")]
		[SerializeField]
		private int _tapDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should presses (continual press like a button) on the touch pad be processed?")]
		private bool _allowPress;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Time the touch pad must be touched before it will be considered a press.")]
		private float _pressStartDelay = 0.1f;

		[CustomObfuscation(rename = false)]
		[FieldRange(-1, int.MaxValue)]
		[Tooltip("The maximum movement distance allowed in pixels since the touch began for the touch to be considered a press. Any movement beyond this value will cancel the press. [-1 = no limit]")]
		[SerializeField]
		private int _pressDistanceLimit = 10;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the control will be hidden when gameplay starts.")]
		private bool _hideAtRuntime;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The underlying Axis 2D.")]
		private StandaloneAxis2D _axis2D = StandaloneAxis2D.CreateRelative();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the value changes.")]
		private ValueChangedEventHandler _onValueChanged = new ValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the touch pad is tapped. This event will only be sent if allowTap is True.")]
		private TapEventHandler _onTap = new TapEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the touch pad is initally pressed. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		[SerializeField]
		private PressDownEventHandler _onPressDown = new PressDownEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the touch pad is released after a press. This event is for the Press button simulation which must be enabled by setting Press Allowed to True. This event will only be sent if allowPress is True.")]
		private PressUpEventHandler _onPressUp = new PressUpEventHandler();

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId = int.MinValue;

		private int _realMousePointerId = int.MinValue;

		[NonSerialized]
		private bool qQqrGmXxzubkmCaMCrOVuSrdktRh;

		[NonSerialized]
		private bool PPobDgSULmsGqZojTdFrxnegWsbI;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame = -1;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private cyElaPTCfXjYPsqMNsszDxNDvbbB _smoothDelta = new cyElaPTCfXjYPsqMNsszDxNDvbbB(3);

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
					yrqYbeKIijUVZAnVVTnpKMepYUwF(value);
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
				if (!TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(fjtxAbJrQwCAKqphTeKWcAJwOzOx))
				{
					return Vector2.zero;
				}
				return TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(fjtxAbJrQwCAKqphTeKWcAJwOzOx);
			}
		}

		public AxisCalibration horizontalAxisCalibration => _axis2D.xAxis.calibration;

		public AxisCalibration verticalAxisCalibration => _axis2D.yAxis.calibration;

		public Axis2DCalibration axis2DCalibration => _axis2D.calibration;

		internal StandaloneAxis2D aHaHiCvZaxhAtPQaqajYYWHNjfxk => _axis2D;

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

		private bool WCFasvosqqbcVbdjMcFbAXdHuwGqA => _lastTapFrame == Time.frameCount;

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
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				cpAbEOeRoJbZuIDTtoiiKpNWWePmA();
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		internal override bool BUnNPMFoanNJCVAmWibAzWafnjUk()
		{
			if (!base.BUnNPMFoanNJCVAmWibAzWafnjUk())
			{
				return false;
			}
			cpAbEOeRoJbZuIDTtoiiKpNWWePmA();
			return true;
		}

		internal override void vjhEkIpbiwZRwstmkNxqMDjviCZ()
		{
			base.vjhEkIpbiwZRwstmkNxqMDjviCZ();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				AePHCbxVsYkRUKHgGbBWjpkQgddU();
				BfcemEvRAUDLLQwTdfsEGPCDloJEA();
				OSXcjEWlRGenGSALrzZsDTDhmTre();
				RXXldxedYXGZdTFiXAakfDJSjtDw();
				IDrkTZFGbVNaZEaCmGXkaNjRfPStA();
			}
		}

		internal override void NSaIxTLXSfKHgYqfDPqUzdSfjLOK()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
			{
				Vector2 vector = ((_touchPadMode == TouchPadMode.ScreenPosition) ? _axis2D.rawValue : _axis2D.value);
				if (_useXAxis)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(_horizontalAxisCustomControllerElement, vector.x, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_useYAxis)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(_verticalAxisCustomControllerElement, vector.y, _axis2D.xAxis.buttonActivationThreshold);
				}
				if (_allowTap)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(_tapCustomControllerElement, WCFasvosqqbcVbdjMcFbAXdHuwGqA);
				}
				if (_allowPress)
				{
					wJuChGHELKYHUkqGfCzcAspJNjWPB(_pressCustomControllerElement, _pressValue);
				}
			}
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
			base.XetDzXgLfjrusCzyhbGhxGxLsdqi();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_pointerId = int.MinValue;
				_realMousePointerId = int.MinValue;
				qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
				PPobDgSULmsGqZojTdFrxnegWsbI = false;
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
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_axis2D.Clear();
				_lastTapFrame = -1;
				_pressValue = false;
				if (UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_horizontalAxisCustomControllerElement);
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_verticalAxisCustomControllerElement);
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_tapCustomControllerElement);
				}
			}
		}

		private void QCTiHbMbjMBiDhGopGJUAtTEkvFmB()
		{
			_horizontalAxisCustomControllerElement.ClearElementCaches();
			_verticalAxisCustomControllerElement.ClearElementCaches();
			_tapCustomControllerElement.ClearElementCaches();
			_pressCustomControllerElement.ClearElementCaches();
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
				if (_allowPress)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ValidateElements(_pressCustomControllerElement);
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
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_horizontalAxisCustomControllerElement);
				}
			}
			bool flag2 = P_0 == AxisDirection.Both || P_0 == AxisDirection.Vertical;
			if (_useYAxis != flag2)
			{
				_useYAxis = flag2;
				if (!flag2 && UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_verticalAxisCustomControllerElement);
				}
			}
			_axesToUse = P_0;
		}

		private void BfcemEvRAUDLLQwTdfsEGPCDloJEA()
		{
			if (hasPointer && !TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(fjtxAbJrQwCAKqphTeKWcAJwOzOx))
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
		}

		private void OSXcjEWlRGenGSALrzZsDTDhmTre()
		{
			if (_touchPadMode == TouchPadMode.VectorFromCenter)
			{
				Graphic graphic = base.targetGraphic;
				RectTransform rectTransform = ((graphic != null) ? (graphic.transform as RectTransform) : base.DSmDnIVkfzvBzeFgEbidCWTOTVMO);
				_currentCenter = rectTransform.TransformPoint(rectTransform.rect.center);
				_currentCenter = RectTransformUtility.WorldToScreenPoint(base.HtGlhojWyGbbBWmlieYRaIFDtOyfA.worldCamera, _currentCenter);
			}
			if (!hasPointer || !TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(fjtxAbJrQwCAKqphTeKWcAJwOzOx))
			{
				return;
			}
			Vector3 vector = TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(fjtxAbJrQwCAKqphTeKWcAJwOzOx);
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
			vector2 = ShHkKAkycBMDpZIpNWKmmabebflEA(vector2);
			_axis2D.SetRawValue(vector2.x, vector2.y);
			if (_touchPadMode == TouchPadMode.Delta)
			{
				_smoothDelta.ZCYeQXTQlBeczBTsRNSgmJnLWcxf(vector2.x, vector2.y);
			}
			_previousTouchPosition = vector;
		}

		private void RXXldxedYXGZdTFiXAakfDJSjtDw()
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

		private void AePHCbxVsYkRUKHgGbBWjpkQgddU()
		{
			if (hasPointer)
			{
				Vector2 vector = TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(fjtxAbJrQwCAKqphTeKWcAJwOzOx);
				kuvCBbHykFOYJjkvqrHFvTdmRavD(ref vector);
				DuurejQHNwLjdDScmmPrdrCniWmn(ref vector);
			}
		}

		private void kuvCBbHykFOYJjkvqrHFvTdmRavD(ref Vector2 P_0)
		{
			if (_allowTap && _isEligibleForTap && ((_tapTimeout > 0f && Time.realtimeSinceStartup - _touchStartTime > _tapTimeout) || (_tapDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_tapDistanceLimit)))
			{
				_isEligibleForTap = false;
			}
		}

		private void DuurejQHNwLjdDScmmPrdrCniWmn(ref Vector2 P_0)
		{
			if (_allowPress && _isEligibleForPress)
			{
				if (_pressDistanceLimit >= 0 && Vector2.Distance(_touchStartPosition, P_0) > (float)_pressDistanceLimit)
				{
					_isEligibleForPress = false;
					yuaeIEfcJVJRtMvNAQcPEuUaVwsqA(false);
				}
				else if (!(_pressStartDelay > 0f) || !(Time.realtimeSinceStartup - _touchStartTime < _pressStartDelay))
				{
					yuaeIEfcJVJRtMvNAQcPEuUaVwsqA(true);
				}
			}
		}

		private void IDrkTZFGbVNaZEaCmGXkaNjRfPStA()
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

		private Vector2 ShHkKAkycBMDpZIpNWKmmabebflEA(Vector2 P_0)
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

		private void yuaeIEfcJVJRtMvNAQcPEuUaVwsqA(bool P_0)
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

		private void QFKOXEymAtfzaXbJhAtiDSsrpLGX(PointerEventData P_0)
		{
			if (!hasPointer || myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				if (uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable())
				{
					zbyGnibPBSirsUMdWdhZwaIygfajA(P_0.pointerId, P_0.pressPosition);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void jXYdNAjblrCnDXVQHikRFJVkFajbc(PointerEventData P_0)
		{
			if ((!hasPointer || myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId)) && !TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(fjtxAbJrQwCAKqphTeKWcAJwOzOx))
			{
				ocNguSfHeUhMkjikGvvptZpSPVpP();
				base.OnPointerUp(P_0);
			}
		}

		private void jFpyRRTzQaTGpbtgzHIZrldBeWud(PointerEventData P_0)
		{
			if (hasPointer && !myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0.pointerId);
			bool flag2 = false;
			if (_activateOnSwipeIn && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && (!flag || TouchInteractable.tIvoXXrIMIwvUwCpDxwPcEyiNtFC(base.allowedMouseButtons)) && !qQqrGmXxzubkmCaMCrOVuSrdktRh)
			{
				if (flag)
				{
					if (TouchInteractable.xKpthjOvWrGLEYZzckNkzUxWiphi(base.allowedMouseButtons, out var realMousePointerId))
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
				PointerEventData pointerEventData = IjGPKgTPXkdFNtRxOeIZLhPNAXdfA((_realMousePointerId != int.MinValue) ? _realMousePointerId : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					QFKOXEymAtfzaXbJhAtiDSsrpLGX(pointerEventData);
					if (qQqrGmXxzubkmCaMCrOVuSrdktRh)
					{
						_pointerDownIsFake = true;
					}
				}
			}
			PPobDgSULmsGqZojTdFrxnegWsbI = true;
		}

		private void VRPzeteEbsZCPDMfbJbyNayEMNCI(PointerEventData P_0)
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

		private void zbyGnibPBSirsUMdWdhZwaIygfajA(int P_0, Vector2 P_1)
		{
			_pointerId = P_0;
			qQqrGmXxzubkmCaMCrOVuSrdktRh = true;
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

		private void ocNguSfHeUhMkjikGvvptZpSPVpP()
		{
			bool num = _allowTap && _isEligibleForTap;
			ThPWHWimrlcazXyfWPofuuahDgzo();
			qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
			if (_useInertia && _touchPadMode == TouchPadMode.Delta)
			{
				_axis2D.SetRawValue(_smoothDelta.TrrycHHAvYjjqUhXpavsZTNfcmMFA());
			}
			else
			{
				_axis2D.SetRawValue(0f, 0f);
			}
			yuaeIEfcJVJRtMvNAQcPEuUaVwsqA(false);
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
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				jXYdNAjblrCnDXVQHikRFJVkFajbc(eventData);
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				QFKOXEymAtfzaXbJhAtiDSsrpLGX(eventData);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				jFpyRRTzQaTGpbtgzHIZrldBeWud(eventData);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				VRPzeteEbsZCPDMfbJbyNayEMNCI(eventData);
			}
		}

		private void ThPWHWimrlcazXyfWPofuuahDgzo()
		{
			_pointerId = int.MinValue;
			_realMousePointerId = int.MinValue;
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
	}
}
