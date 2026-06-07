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
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Touch Button")]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum LNVXndypfcnGHxjXWIKbzWEKXCgJ
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum FLHpwrtrgrAVRgvHFllCbTfBvlsX
		{
			Local = 0,
			TouchRegion = 1
		}

		[Serializable]
		public class AxisValueChangedEventHandler : UnityEvent<float>
		{
		}

		[Serializable]
		public class ButtonValueChangedEventHandler : UnityEvent<bool>
		{
		}

		[Serializable]
		public class ButtonDownEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class ButtonUpEventHandler : UnityEvent
		{
		}

		private sealed class PEZvntLEEzEUiYzLXTCktMxhYESr : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private object USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			public float RTHUUqokIzIENeGXftdmzIzrqZYk;

			public TouchButton GZXxEqHwrHYIyUJtInpLwgTukJaY;

			public PositionType AUMAgZZLBrHzLgTUYOnkEcEkkkfGc;

			public Vector2 GPrcxxCgPFJPNaVyAUBmpuVaCrKbd;

			public LNVXndypfcnGHxjXWIKbzWEKXCgJ vJROrazzqkuFowhstzcKQBkiBOn;

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
			public PEZvntLEEzEUiYzLXTCktMxhYESr(int P_0)
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
				TouchButton gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
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
						gZXxEqHwrHYIyUJtInpLwgTukJaY.acleJLVJfrpdNZbfkVwSBZrSlDZv = true;
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

		private const float XgnNuvXBBArwHhmQuOJjuwPwAMLr = 20f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		private ButtonType _buttonType;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		private bool _activateOnSwipeIn;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		private bool _useDigitalAxisSimulation;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		[SerializeField]
		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		private float _digitalAxisGravity = 3f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		private TouchRegion _touchRegion;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		private bool _useTouchRegionOnly = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		private bool _moveToTouchPosition;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		private bool _returnOnRelease = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		private bool _followTouchPosition;

		[SerializeField]
		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private float _moveToTouchSpeed = 2f;

		[SerializeField]
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[Range(0f, 20f)]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _manageRaycasting = true;

		private float LCRetaxfqWkUybIwMDfXdUQmmqbB;

		private float KztafzFUovqmhfsAgBYciDHCaTzkc;

		private TouchRegion OZpdgeYptzceNlEbLLCpIasfuuCQ;

		private Vector2 gJPBKjASPUkYQjJweuleWqdkiBDy;

		private bool acleJLVJfrpdNZbfkVwSBZrSlDZv;

		private bool zOLVRmkYSiUbLTDSlPyMCnlvpMcq;

		private LNVXndypfcnGHxjXWIKbzWEKXCgJ pFDkUXpsRWRnBYBJHInaLzWBAmwW;

		private int hBtoemOfUfsKjssObQMaORunBvJT = int.MinValue;

		private int SzxfXOWsFpbnmLHgHTaMmMHBBXQEA = int.MinValue;

		[NonSerialized]
		private bool HNeekbdvHcSGCkhkngTpwdUwueLRA;

		[NonSerialized]
		private bool aMiVitsTbcaHUuBPegFBByVtJKdtA;

		private IEnumerator ATTFNSdOsXBGJgyJpEHUDcrydDngA;

		private bizhSGSkbYKHLUAwUjJldBHmyZwq IFVbECUjDOSCVcLLYiPMhcVdqoyh = new bizhSGSkbYKHLUAwUjJldBHmyZwq();

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> ovtgdkNgwpSEHRHYmtFdrOoUovrX;

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> VVgDPpCRkwAUmdtwUpPAdDZvLTKUA;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the button is pressed.")]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is released.")]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> LjmEDecqpUzpCHTZXZyrvkHEVVih;

		public CustomControllerElementTargetSetForFloat targetCustomControllerElement => _targetCustomControllerElement;

		public ButtonType buttonType
		{
			get
			{
				return _buttonType;
			}
			set
			{
				if (_buttonType != value)
				{
					_buttonType = value;
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

		public bool useDigitalAxisSimulation
		{
			get
			{
				return _useDigitalAxisSimulation;
			}
			set
			{
				if (_useDigitalAxisSimulation != value)
				{
					_useDigitalAxisSimulation = value;
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public float digitalAxisGravity
		{
			get
			{
				return _digitalAxisGravity;
			}
			set
			{
				if (_digitalAxisGravity != value)
				{
					_digitalAxisGravity = value;
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public float digitalAxisSensitivity
		{
			get
			{
				return _digitalAxisSensitivity;
			}
			set
			{
				if (_digitalAxisSensitivity != value)
				{
					_digitalAxisSensitivity = value;
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
						IFVbECUjDOSCVcLLYiPMhcVdqoyh.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
					}
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return hBtoemOfUfsKjssObQMaORunBvJT;
			}
			set
			{
				hBtoemOfUfsKjssObQMaORunBvJT = value;
			}
		}

		public bool hasPointer => hBtoemOfUfsKjssObQMaORunBvJT != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> moveStartedDelegate
		{
			get
			{
				if (ovtgdkNgwpSEHRHYmtFdrOoUovrX == null)
				{
					return ovtgdkNgwpSEHRHYmtFdrOoUovrX = KlzDqOhWDaEscpTwtInUZXFgetYgb;
				}
				return ovtgdkNgwpSEHRHYmtFdrOoUovrX;
			}
		}

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> moveEndedDelegate
		{
			get
			{
				if (VVgDPpCRkwAUmdtwUpPAdDZvLTKUA == null)
				{
					return VVgDPpCRkwAUmdtwUpPAdDZvLTKUA = TfMWssqBnrIKOIMGruTtpLqJkuDH;
				}
				return VVgDPpCRkwAUmdtwUpPAdDZvLTKUA;
			}
		}

		private float axisValue
		{
			get
			{
				if (!_useDigitalAxisSimulation)
				{
					return _axis.value;
				}
				return LCRetaxfqWkUybIwMDfXdUQmmqbB;
			}
		}

		private float axisValuePrev
		{
			get
			{
				if (!_useDigitalAxisSimulation)
				{
					return _axis.valuePrev;
				}
				return KztafzFUovqmhfsAgBYciDHCaTzkc;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (hBtoemOfUfsKjssObQMaORunBvJT == int.MinValue)
				{
					return int.MinValue;
				}
				if (SzxfXOWsFpbnmLHgHTaMmMHBBXQEA != int.MinValue)
				{
					return SzxfXOWsFpbnmLHgHTaMmMHBBXQEA;
				}
				return hBtoemOfUfsKjssObQMaORunBvJT;
			}
		}

		public event UnityAction<float> AxisValueChangedEvent
		{
			add
			{
				_onAxisValueChanged.AddListener(value);
			}
			remove
			{
				_onAxisValueChanged.RemoveListener(value);
			}
		}

		public event UnityAction<bool> ButtonValueChangedEvent
		{
			add
			{
				_onButtonValueChanged.AddListener(value);
			}
			remove
			{
				_onButtonValueChanged.RemoveListener(value);
			}
		}

		public event UnityAction ButtonDownEvent
		{
			add
			{
				_onButtonDown.AddListener(value);
			}
			remove
			{
				_onButtonDown.RemoveListener(value);
			}
		}

		public event UnityAction ButtonUpEvent
		{
			add
			{
				_onButtonUp.AddListener(value);
			}
			remove
			{
				_onButtonUp.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchButton()
		{
		}

		public void SetRawValue(float value)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_axis.SetRawValue(value);
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
				gJPBKjASPUkYQjJweuleWqdkiBDy = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				eITbiRqIzcvtzyMtnrVQwwxIcFag(gJPBKjASPUkYQjJweuleWqdkiBDy, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, LNVXndypfcnGHxjXWIKbzWEKXCgJ.TowardHome);
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
				gJPBKjASPUkYQjJweuleWqdkiBDy = base.uBgsATlVNpCXLTZUrAUVBouJZPML.anchoredPosition;
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
				wfYqWOGHtnIUbtMhSNJLmUHIcfqd();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			base.Reset();
			base.transitionType = TransitionTypeFlags.ColorTint;
		}

		internal void OnUpdate()
		{
			base.IghfPvNUXsucbZILFgzLRWwwGmUeA();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				egDhVENqiOmptpvGuCmdKvgAwDfc();
				JLnGBUfdysxYoDUCZJSERpDKNZAO();
				zuAKYWggjwIZZcFIWSNietTQOaIg();
				if (_followTouchPosition)
				{
					BnHDOLKbUanuKgdtijCJfcEoDAFlA(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!qrhyEDreMhRqasASvGWwEiXwPpSPA())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && lQbkmKnTRMhMmINePIJrIZrbBwDnA)
			{
				HnasqDsAjOkwcNNgKbRUzSIOurWO(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			pmxmOeyRAlBoCxmllQyaxtECbvcr();
			_axis.AxisValueChangedEvent += lLFFKNPRhFapxntcuwlZTDsroWzC;
			_axis.ButtonValueChangedEvent += xgbfJDEHpWXivuVHhlzqrlGBypUt;
			_axis.ButtonDownEvent += uGPyYjLxchxKLwgNhTxIoOCBgiGx;
			_axis.ButtonUpEvent += HfqBmKzQoOGqOGrpdJsuQnYySZuk;
		}

		internal void OnUnsubscribeEvents()
		{
			KhQueZDBBtkbvKkxubYmYxeSHJrfA();
			_axis.AxisValueChangedEvent -= lLFFKNPRhFapxntcuwlZTDsroWzC;
			_axis.ButtonValueChangedEvent -= xgbfJDEHpWXivuVHhlzqrlGBypUt;
			_axis.ButtonDownEvent -= uGPyYjLxchxKLwgNhTxIoOCBgiGx;
			_axis.ButtonUpEvent -= HfqBmKzQoOGqOGrpdJsuQnYySZuk;
		}

		internal void OnSetProperty()
		{
			CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		internal void OnClear()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				hBtoemOfUfsKjssObQMaORunBvJT = int.MinValue;
				SzxfXOWsFpbnmLHgHTaMmMHBBXQEA = int.MinValue;
				HNeekbdvHcSGCkhkngTpwdUwueLRA = false;
				aMiVitsTbcaHUuBPegFBByVtJKdtA = false;
				if (_returnOnRelease && zOLVRmkYSiUbLTDSlPyMCnlvpMcq && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				zOLVRmkYSiUbLTDSlPyMCnlvpMcq = false;
				acleJLVJfrpdNZbfkVwSBZrSlDZv = false;
				pFDkUXpsRWRnBYBJHInaLzWBAmwW = LNVXndypfcnGHxjXWIKbzWEKXCgJ.None;
				ewnocjnbCdATpbuVDhgTcBsizpjGb();
				_axis.Clear();
				LCRetaxfqWkUybIwMDfXdUQmmqbB = 0f;
				KztafzFUovqmhfsAgBYciDHCaTzkc = 0f;
				fLESigLZMfTrdvEIqdmveetSjBkA();
			}
		}

		public override void ClearValue()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				_axis.Clear();
				LCRetaxfqWkUybIwMDfXdUQmmqbB = 0f;
				if (lQbkmKnTRMhMmINePIJrIZrbBwDnA)
				{
					base.NlFnBAIUQPMwtvacPcDKoOszCbeW.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				return false;
			}
			if (!BmJxkhIhAZjPFwDWRTfFEWoVOzdM())
			{
				return false;
			}
			if (!_axis.buttonValue)
			{
				return _axis.value != 0f;
			}
			return true;
		}

		internal bool IsThisOrTouchRegionGameObject(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			if (base.pzZuAkmltxMhZFAhATJmEgsvqjqP(gameObject))
			{
				return true;
			}
			if (OZpdgeYptzceNlEbLLCpIasfuuCQ != null)
			{
				return OZpdgeYptzceNlEbLLCpIasfuuCQ.gameObject == gameObject;
			}
			return false;
		}

		private void zuAKYWggjwIZZcFIWSNietTQOaIg()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					TXokOyGYvfhCZKwEhWuKACDQsGvA();
				}
				else
				{
					xPPrkDhYcdSavovozhVHyLYWmHoI();
				}
			}
		}

		private void TXokOyGYvfhCZKwEhWuKACDQsGvA()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += LCRetaxfqWkUybIwMDfXdUQmmqbB;
			num = MathTools.Clamp(num, -1f, 1f);
			NExRKhgqSEXnRVmslgyqZwlepTKt(num, true);
		}

		private void xPPrkDhYcdSavovozhVHyLYWmHoI()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float lCRetaxfqWkUybIwMDfXdUQmmqbB = LCRetaxfqWkUybIwMDfXdUQmmqbB;
			if (lCRetaxfqWkUybIwMDfXdUQmmqbB != 0f)
			{
				float num2 = num * Time.unscaledDeltaTime;
				float num3;
				if (MathTools.Abs(num2) >= MathTools.Abs(lCRetaxfqWkUybIwMDfXdUQmmqbB))
				{
					num3 = 0f;
				}
				else
				{
					float num4 = ((lCRetaxfqWkUybIwMDfXdUQmmqbB > 0f) ? (-1f) : 1f);
					num3 = lCRetaxfqWkUybIwMDfXdUQmmqbB + num4 * num2;
				}
				NExRKhgqSEXnRVmslgyqZwlepTKt(num3, true);
			}
		}

		private void NExRKhgqSEXnRVmslgyqZwlepTKt(float P_0, bool P_1)
		{
			KztafzFUovqmhfsAgBYciDHCaTzkc = LCRetaxfqWkUybIwMDfXdUQmmqbB;
			LCRetaxfqWkUybIwMDfXdUQmmqbB = P_0;
			if (P_0 != KztafzFUovqmhfsAgBYciDHCaTzkc)
			{
				VEkfkZWVOjyuYZKyQWGZuutzFXEI(null);
			}
			if (P_1 && P_0 != KztafzFUovqmhfsAgBYciDHCaTzkc)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void moMoajBsFPMscddbfqbMNRmHCyiN()
		{
			if (_buttonType == ButtonType.ToggleSwitch)
			{
				if (buttonValue)
				{
					_axis.SetRawValue(_axis.rawZero);
				}
				else
				{
					_axis.SetRawValue(_axis.rawMax);
				}
			}
			else if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawMax);
			}
		}

		private void cfXhvzcGsdISdUHJYWVNEeKiLJlUA()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
			_targetCustomControllerElement.ClearElementCaches();
			JLnGBUfdysxYoDUCZJSERpDKNZAO();
			pzPMFEbyDhmWExkoJxkqFuWrLfmN();
		}

		private void pzPMFEbyDhmWExkoJxkqFuWrLfmN()
		{
			if (_manageRaycasting)
			{
				IFVbECUjDOSCVcLLYiPMhcVdqoyh.nmwDzgxVACcOAJkYbADwUYDbZzFK(base.transform, PGRwgyyCEWmVXLbfYWHiHTHXKcgx());
			}
		}

		private bool PGRwgyyCEWmVXLbfYWHiHTHXKcgx()
		{
			if (OZpdgeYptzceNlEbLLCpIasfuuCQ != null && _useTouchRegionOnly)
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
			}
		}

		private void JLnGBUfdysxYoDUCZJSERpDKNZAO()
		{
			if (!(OZpdgeYptzceNlEbLLCpIasfuuCQ == _touchRegion))
			{
				esAXKEkUWhoBLDsRGfMxQcmHceQK(OZpdgeYptzceNlEbLLCpIasfuuCQ);
				OZpdgeYptzceNlEbLLCpIasfuuCQ = _touchRegion;
				cVJYLgudKpcedZGsLcQHBTgFXrogA(OZpdgeYptzceNlEbLLCpIasfuuCQ);
			}
		}

		private void yXvFCwguRvPGWzUcsYLKERTdoKRZA(Vector2 P_0, bool P_1, float P_2, LNVXndypfcnGHxjXWIKbzWEKXCgJ P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = rAPtcpHLzzLbzFhqkNsLlgjZFneJA.SgnmCnknRrphshQsybuTdsGjQtuR(base.oJQqczDhICKLxrvFLqPtRJoISnkJ, rectTransform, P_0);
			Vector2 pivot = base.uBgsATlVNpCXLTZUrAUVBouJZPML.pivot;
			Vector2 sizeDelta = base.uBgsATlVNpCXLTZUrAUVBouJZPML.sizeDelta;
			Vector3 localScale = base.uBgsATlVNpCXLTZUrAUVBouJZPML.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			eITbiRqIzcvtzyMtnrVQwwxIcFag(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void eITbiRqIzcvtzyMtnrVQwwxIcFag(Vector2 P_0, PositionType P_1, bool P_2, float P_3, LNVXndypfcnGHxjXWIKbzWEKXCgJ P_4)
		{
			if (acleJLVJfrpdNZbfkVwSBZrSlDZv && P_2 && pFDkUXpsRWRnBYBJHInaLzWBAmwW == P_4)
			{
				return;
			}
			if (acleJLVJfrpdNZbfkVwSBZrSlDZv && ATTFNSdOsXBGJgyJpEHUDcrydDngA != null)
			{
				ewnocjnbCdATpbuVDhgTcBsizpjGb();
				acleJLVJfrpdNZbfkVwSBZrSlDZv = false;
				pFDkUXpsRWRnBYBJHInaLzWBAmwW = LNVXndypfcnGHxjXWIKbzWEKXCgJ.None;
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
				ATTFNSdOsXBGJgyJpEHUDcrydDngA = eYHLOFQxNaFhuZFTErUMQxBGBpL(P_0, P_1, P_3, P_4);
				StartCoroutine(ATTFNSdOsXBGJgyJpEHUDcrydDngA);
				pFDkUXpsRWRnBYBJHInaLzWBAmwW = P_4;
				zOLVRmkYSiUbLTDSlPyMCnlvpMcq = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				WQXJGuUNcDBFtdyHEvIDGCascPox(P_4, P_0, P_1);
			}
		}

		private IEnumerator eYHLOFQxNaFhuZFTErUMQxBGBpL(Vector2 P_0, PositionType P_1, float P_2, LNVXndypfcnGHxjXWIKbzWEKXCgJ P_3)
		{
			return new PEZvntLEEzEUiYzLXTCktMxhYESr(0)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				GPrcxxCgPFJPNaVyAUBmpuVaCrKbd = P_0,
				AUMAgZZLBrHzLgTUYOnkEcEkkkfGc = P_1,
				RTHUUqokIzIENeGXftdmzIzrqZYk = P_2,
				vJROrazzqkuFowhstzcKQBkiBOn = P_3
			};
		}

		private void WQXJGuUNcDBFtdyHEvIDGCascPox(LNVXndypfcnGHxjXWIKbzWEKXCgJ P_0, Vector2 P_1, PositionType P_2)
		{
			rAPtcpHLzzLbzFhqkNsLlgjZFneJA.ggeBfXdXMzUKfWJqSCynZUgDwusiA(base.uBgsATlVNpCXLTZUrAUVBouJZPML, P_1, P_2);
			acleJLVJfrpdNZbfkVwSBZrSlDZv = false;
			pFDkUXpsRWRnBYBJHInaLzWBAmwW = LNVXndypfcnGHxjXWIKbzWEKXCgJ.None;
			switch (P_0)
			{
			case LNVXndypfcnGHxjXWIKbzWEKXCgJ.TowardHome:
				zOLVRmkYSiUbLTDSlPyMCnlvpMcq = false;
				break;
			case LNVXndypfcnGHxjXWIKbzWEKXCgJ.TowardTouch:
				zOLVRmkYSiUbLTDSlPyMCnlvpMcq = true;
				break;
			}
			ewnocjnbCdATpbuVDhgTcBsizpjGb();
			moveEndedDelegate(P_0);
		}

		private void KlzDqOhWDaEscpTwtInUZXFgetYgb(LNVXndypfcnGHxjXWIKbzWEKXCgJ P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && OZpdgeYptzceNlEbLLCpIasfuuCQ != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == LNVXndypfcnGHxjXWIKbzWEKXCgJ.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					IFVbECUjDOSCVcLLYiPMhcVdqoyh.nmwDzgxVACcOAJkYbADwUYDbZzFK(base.transform, flag2);
				}
			}
		}

		private void TfMWssqBnrIKOIMGruTtpLqJkuDH(LNVXndypfcnGHxjXWIKbzWEKXCgJ P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && OZpdgeYptzceNlEbLLCpIasfuuCQ != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == LNVXndypfcnGHxjXWIKbzWEKXCgJ.TowardHome)
				{
					flag = true;
					flag2 = PGRwgyyCEWmVXLbfYWHiHTHXKcgx();
				}
				if (flag)
				{
					IFVbECUjDOSCVcLLYiPMhcVdqoyh.nmwDzgxVACcOAJkYbADwUYDbZzFK(base.transform, flag2);
				}
			}
		}

		private void BnHDOLKbUanuKgdtijCJfcEoDAFlA(int P_0)
		{
			if (TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(P_0))
			{
				yXvFCwguRvPGWzUcsYLKERTdoKRZA(TouchInteractable.OGvcMITMMMbQQEcIOflTxFfwaCjh(P_0), false, 0f, LNVXndypfcnGHxjXWIKbzWEKXCgJ.TowardTouch);
			}
		}

		private void ewnocjnbCdATpbuVDhgTcBsizpjGb()
		{
			if (ATTFNSdOsXBGJgyJpEHUDcrydDngA != null)
			{
				try
				{
					StopCoroutine(ATTFNSdOsXBGJgyJpEHUDcrydDngA);
				}
				catch
				{
				}
				ATTFNSdOsXBGJgyJpEHUDcrydDngA = null;
			}
		}

		private void egDhVENqiOmptpvGuCmdKvgAwDfc()
		{
			if (hasPointer && !TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(effectivePointerId))
			{
				PointerEventData pointerEventData = KSrSTOGNRhDrOLwekzgdtyflCwNh(effectivePointerId);
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
			hBtoemOfUfsKjssObQMaORunBvJT = int.MinValue;
			SzxfXOWsFpbnmLHgHTaMmMHBBXQEA = int.MinValue;
		}

		private bool ZUErojFQVybWFckzvOUChmdZdZUuA(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (hBtoemOfUfsKjssObQMaORunBvJT == int.MinValue)
			{
				return false;
			}
			if (hBtoemOfUfsKjssObQMaORunBvJT == P_0)
			{
				return true;
			}
			if (TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0) && SzxfXOWsFpbnmLHgHTaMmMHBBXQEA != int.MinValue && P_0 == SzxfXOWsFpbnmLHgHTaMmMHBBXQEA)
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
				sxUWcYUfULZPIUeyiMZFYFflpeYn(effectivePointerId);
			}
		}

		private PointerEventData KSrSTOGNRhDrOLwekzgdtyflCwNh(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (LjmEDecqpUzpCHTZXZyrvkHEVVih == null)
			{
				LjmEDecqpUzpCHTZXZyrvkHEVVih = new Dictionary<int, PointerEventData>();
			}
			if (!LjmEDecqpUzpCHTZXZyrvkHEVVih.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				LjmEDecqpUzpCHTZXZyrvkHEVVih.Add(P_0, value);
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

		private void xIWWjJOuupYMQcrdMBCGCHPaXBWI(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
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

		private void IoGbCPRdLbcSdkogaRArqCgIugjmA(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
		{
			if ((!hasPointer || ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId)) && !TouchInteractable.lzPVBIKyCDpqDzCZFsIOPbTHYEWP(effectivePointerId))
			{
				VDahXJPMYKnASeYtoJZirWDQPxW();
				base.OnPointerUp(P_0);
			}
		}

		private void QcjNpGrRNqqqNCrPAtddavSMTuin(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
		{
			if (hasPointer && !ZUErojFQVybWFckzvOUChmdZdZUuA(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.rZmZQrhrXAGTBXIHJwuxnbDbfRJfA(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				FLHpwrtrgrAVRgvHFllCbTfBvlsX.Local => base.allowedMouseButtons, 
				FLHpwrtrgrAVRgvHFllCbTfBvlsX.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && (!flag || TouchInteractable.KsjMbURloCOTuFHgwOLhnvhvdPJW(mouseButtonFlags)) && !HNeekbdvHcSGCkhkngTpwdUwueLRA)
			{
				if (flag)
				{
					if (TouchInteractable.IBzkqesnobxsqrtNNOtMshEFafzK(mouseButtonFlags, out var szxfXOWsFpbnmLHgHTaMmMHBBXQEA))
					{
						SzxfXOWsFpbnmLHgHTaMmMHBBXQEA = szxfXOWsFpbnmLHgHTaMmMHBBXQEA;
					}
					else
					{
						SzxfXOWsFpbnmLHgHTaMmMHBBXQEA = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					FLHpwrtrgrAVRgvHFllCbTfBvlsX.Local => base.gameObject, 
					FLHpwrtrgrAVRgvHFllCbTfBvlsX.TouchRegion => OZpdgeYptzceNlEbLLCpIasfuuCQ.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = tmSHozvxCeyplYJTdurtEufONlsc((SzxfXOWsFpbnmLHgHTaMmMHBBXQEA != int.MinValue) ? SzxfXOWsFpbnmLHgHTaMmMHBBXQEA : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					xIWWjJOuupYMQcrdMBCGCHPaXBWI(pointerEventData, P_1);
				}
			}
			aMiVitsTbcaHUuBPegFBByVtJKdtA = true;
		}

		private void qbFkezCsiyAgtoKeAIvWYmFVHAOW(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
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

		private void IusOvBAtCSXEzhPnHLjnVptEdmr(int P_0, Vector2 P_1, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_2)
		{
			hBtoemOfUfsKjssObQMaORunBvJT = P_0;
			HNeekbdvHcSGCkhkngTpwdUwueLRA = true;
			if (_followTouchPosition)
			{
				BnHDOLKbUanuKgdtijCJfcEoDAFlA(P_0);
			}
			else if (P_2 == FLHpwrtrgrAVRgvHFllCbTfBvlsX.TouchRegion && _moveToTouchPosition)
			{
				yXvFCwguRvPGWzUcsYLKERTdoKRZA(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, LNVXndypfcnGHxjXWIKbzWEKXCgJ.TowardTouch);
			}
			moMoajBsFPMscddbfqbMNRmHCyiN();
		}

		private void VDahXJPMYKnASeYtoJZirWDQPxW()
		{
			ykJYYTWDBrPpTaxVtKiVzeDkBkrt();
			HNeekbdvHcSGCkhkngTpwdUwueLRA = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && zOLVRmkYSiUbLTDSlPyMCnlvpMcq)
			{
				ReturnToDefaultPosition();
			}
			cfXhvzcGsdISdUHJYWVNEeKiLJlUA();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(OZpdgeYptzceNlEbLLCpIasfuuCQ != null) || !_useTouchRegionOnly))
			{
				xIWWjJOuupYMQcrdMBCGCHPaXBWI(eventData, FLHpwrtrgrAVRgvHFllCbTfBvlsX.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(OZpdgeYptzceNlEbLLCpIasfuuCQ != null) || !_useTouchRegionOnly))
			{
				IoGbCPRdLbcSdkogaRArqCgIugjmA(eventData, FLHpwrtrgrAVRgvHFllCbTfBvlsX.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(OZpdgeYptzceNlEbLLCpIasfuuCQ != null) || !_useTouchRegionOnly))
			{
				QcjNpGrRNqqqNCrPAtddavSMTuin(eventData, FLHpwrtrgrAVRgvHFllCbTfBvlsX.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(OZpdgeYptzceNlEbLLCpIasfuuCQ != null) || !_useTouchRegionOnly))
			{
				qbFkezCsiyAgtoKeAIvWYmFVHAOW(eventData, FLHpwrtrgrAVRgvHFllCbTfBvlsX.Local);
			}
		}

		private void mYtlVUwcgRDqffxeyQNiuhceENseA(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				xIWWjJOuupYMQcrdMBCGCHPaXBWI(P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX.TouchRegion);
			}
		}

		private void LphWTZrpvYLSyEGXsYgatVgDoywK(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				IoGbCPRdLbcSdkogaRArqCgIugjmA(P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX.TouchRegion);
			}
		}

		private void TMvPCdsBYetiGshWuVrBWfehcrIfA(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				QcjNpGrRNqqqNCrPAtddavSMTuin(P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX.TouchRegion);
			}
		}

		private void KPebiOdQuvcDTjsxtodIOqscoheFb(PointerEventData P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				qbFkezCsiyAgtoKeAIvWYmFVHAOW(P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX.TouchRegion);
			}
		}

		private void lLFFKNPRhFapxntcuwlZTDsroWzC(float P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && !_useDigitalAxisSimulation)
			{
				VEkfkZWVOjyuYZKyQWGZuutzFXEI(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void xgbfJDEHpWXivuVHhlzqrlGBypUt(bool P_0)
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				VEkfkZWVOjyuYZKyQWGZuutzFXEI(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void uGPyYjLxchxKLwgNhTxIoOCBgiGx()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				VEkfkZWVOjyuYZKyQWGZuutzFXEI(null);
				_onButtonDown.Invoke();
			}
		}

		private void HfqBmKzQoOGqOGrpdJsuQnYySZuk()
		{
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				VEkfkZWVOjyuYZKyQWGZuutzFXEI(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
