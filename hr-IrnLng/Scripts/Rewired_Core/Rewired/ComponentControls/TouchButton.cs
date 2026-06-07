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
	[AddComponentMenu("Rewired/Touch Button")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[DisallowMultipleComponent]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum RBlhvBHjSWMmwaWNBnDzoHUMCDyp
		{
			xHdBaRgdNDZThJOvnpmpFtvdLIun = 0,
			WPytrjpOROGjrBgAebwWrfBpLYv = 1,
			ljhsqtORyJauKccpTHIeMXhgWUM = 2
		}

		private enum VgfdSFwNLJGGqdJJyfaMMVpFZnae
		{
			aXQImphWLsNyAXlPBncGlpmgAAN = 0,
			YBYRTOWNaXAOXNHGYPyoIIFUOoC = 1
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

		private sealed class DRHkgXdnkYRYCnIDkeQARUNNjfp : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			public TouchButton GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public Vector2 ScXDNLvDavIuowqstQHaYcTQvVj;

			public PositionType ODipSlYvwRswiyGWpaiwIwOmaWv;

			public float JutmFCdjNXRKeZDUAmUgTzndNtQ;

			public RBlhvBHjSWMmwaWNBnDzoHUMCDyp tNrzeLxiAExjaZcvROmiccNuyXY;

			public RectTransform iiJVGDJlVeIGDmpUBYMHTpgOidYg;

			public Vector2 DsJweuSuOtYueNqTzUIzSAsyKxM;

			public float KGqqnWSdnMSaYmKKYoyLeEqlHTd;

			public float xqHsBlDxwCJOLvpouuSIDswnWNZ;

			public float vezJFnuMmmZRZvFAIUeMUtKgYxP;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (!(JutmFCdjNXRKeZDUAmUgTzndNtQ <= 0f))
					{
						iiJVGDJlVeIGDmpUBYMHTpgOidYg = GxphHAMqMhNBLjnlhXuBQmXaALiE.rectTransform;
						DsJweuSuOtYueNqTzUIzSAsyKxM = lOjEgNUYKDaLCggmFifXLItFlte.hibndcJYzaEsrXIwpugDlXRbtYB(iiJVGDJlVeIGDmpUBYMHTpgOidYg, ODipSlYvwRswiyGWpaiwIwOmaWv);
						KGqqnWSdnMSaYmKKYoyLeEqlHTd = (ScXDNLvDavIuowqstQHaYcTQvVj - DsJweuSuOtYueNqTzUIzSAsyKxM).magnitude;
						if (!(KGqqnWSdnMSaYmKKYoyLeEqlHTd < 0.01f))
						{
							GxphHAMqMhNBLjnlhXuBQmXaALiE.yPNllrAyUNsoigvxVmfWdFxCRTN = true;
							xqHsBlDxwCJOLvpouuSIDswnWNZ = KGqqnWSdnMSaYmKKYoyLeEqlHTd / JutmFCdjNXRKeZDUAmUgTzndNtQ;
							vezJFnuMmmZRZvFAIUeMUtKgYxP = 0f;
							goto IL_0125;
						}
					}
					goto IL_0132;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_0125;
					}
					IL_0125:
					if (vezJFnuMmmZRZvFAIUeMUtKgYxP <= 1f)
					{
						vezJFnuMmmZRZvFAIUeMUtKgYxP += Time.unscaledDeltaTime / xqHsBlDxwCJOLvpouuSIDswnWNZ;
						lOjEgNUYKDaLCggmFifXLItFlte.kPSRPhEgnLVfCczyndEheCeBcby(iiJVGDJlVeIGDmpUBYMHTpgOidYg, Vector2.Lerp(DsJweuSuOtYueNqTzUIzSAsyKxM, ScXDNLvDavIuowqstQHaYcTQvVj, Mathf.SmoothStep(0f, 1f, vezJFnuMmmZRZvFAIUeMUtKgYxP)), ODipSlYvwRswiyGWpaiwIwOmaWv);
						WCNlIsEdYuVTqbNYvICUPcTebLU = null;
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_0132;
					IL_0132:
					GxphHAMqMhNBLjnlhXuBQmXaALiE.QFfhhGPWZppUICMXpzmNqXgmgTe(tNrzeLxiAExjaZcvROmiccNuyXY, ScXDNLvDavIuowqstQHaYcTQvVj, ODipSlYvwRswiyGWpaiwIwOmaWv);
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
			public DRHkgXdnkYRYCnIDkeQARUNNjfp(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
			}
		}

		private const float TRNKUHUIymeliOUMZGSjQYBstWB = 20f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[SerializeField]
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[CustomObfuscation(rename = false)]
		private ButtonType _buttonType;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[CustomObfuscation(rename = false)]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[SerializeField]
		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchRegion _touchRegion;

		[SerializeField]
		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[SerializeField]
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnMoveToTouch = true;

		[Range(0f, 20f)]
		[SerializeField]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		private float _moveToTouchSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		private bool _animateOnReturn = true;

		[SerializeField]
		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private float DutvYHcoSmUlhOIEraYfgNUaRocW;

		private float GWJXYNNDUZzSYHIRqPwshTrgTbz;

		private TouchRegion KsJmCARPEJgpyGUnirFjSculwwK;

		private Vector2 kmtlyZTXkqnNnSPaNaUoefpoPxB;

		private bool yPNllrAyUNsoigvxVmfWdFxCRTN;

		private bool zbznKEdvcQoHuaEaYhIQqjjjCBa;

		private RBlhvBHjSWMmwaWNBnDzoHUMCDyp jKhGYvucicYSedVXsAeitFGZfocF;

		private int jWHWRIRchJdZIFaIUCTieTgtWrT = int.MinValue;

		private int WUPzpkLQsFkiBwuysjzISJFZNGU = int.MinValue;

		[NonSerialized]
		private bool TeYWPPoFyMNBbKncGGitZfUyemX;

		[NonSerialized]
		private bool wDYSPwlKjAWglTFTTAdVKNarCnx;

		private IEnumerator WWhxbccjJbhTwFzPCOOWlQhqDSr;

		private xiHifuBaAyISozuypTCpBDPksDm QmbGBcCDwaDLkbJZCpfWFPFqjyms = new xiHifuBaAyISozuypTCpBDPksDm();

		private Action<RBlhvBHjSWMmwaWNBnDzoHUMCDyp> ybTBKIMUZTHWsoOdTMstVywMpwv;

		private Action<RBlhvBHjSWMmwaWNBnDzoHUMCDyp> XZQdxPTHcEBUJGyWvEFMfLnhFMG;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the axis value changes.")]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the button is released.")]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> FlEkmKpIMkbefDmZqoUfRZNMSVec;

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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (WoeifeKWkAJetEpCTxVeyqtZgkA())
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
						bzlavaeXqNGLjGQogjryfXKdvCc();
					}
					else
					{
						QmbGBcCDwaDLkbJZCpfWFPFqjyms.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
					}
					MxNDYRdNWvbuwnEvdAejdyZphUD();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return jWHWRIRchJdZIFaIUCTieTgtWrT;
			}
			set
			{
				jWHWRIRchJdZIFaIUCTieTgtWrT = value;
			}
		}

		public bool hasPointer => jWHWRIRchJdZIFaIUCTieTgtWrT != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<RBlhvBHjSWMmwaWNBnDzoHUMCDyp> moveStartedDelegate
		{
			get
			{
				if (ybTBKIMUZTHWsoOdTMstVywMpwv == null)
				{
					return ybTBKIMUZTHWsoOdTMstVywMpwv = OGVCroDHaYppXqKqCikMtNJsbaA;
				}
				return ybTBKIMUZTHWsoOdTMstVywMpwv;
			}
		}

		private Action<RBlhvBHjSWMmwaWNBnDzoHUMCDyp> moveEndedDelegate
		{
			get
			{
				if (XZQdxPTHcEBUJGyWvEFMfLnhFMG == null)
				{
					return XZQdxPTHcEBUJGyWvEFMfLnhFMG = HMqDmWbpANlJfrnOOzffODkXSiNr;
				}
				return XZQdxPTHcEBUJGyWvEFMfLnhFMG;
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
				return DutvYHcoSmUlhOIEraYfgNUaRocW;
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
				return GWJXYNNDUZzSYHIRqPwshTrgTbz;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (jWHWRIRchJdZIFaIUCTieTgtWrT == int.MinValue)
				{
					return int.MinValue;
				}
				if (WUPzpkLQsFkiBwuysjzISJFZNGU != int.MinValue)
				{
					return WUPzpkLQsFkiBwuysjzISJFZNGU;
				}
				return jWHWRIRchJdZIFaIUCTieTgtWrT;
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
			if (base.initialized)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			PfdeaCQvDjJHkuxxHgmpRSHeaum(base.rectTransform.anchoredPosition);
		}

		private void PfdeaCQvDjJHkuxxHgmpRSHeaum(Vector2 P_0)
		{
			if (base.initialized)
			{
				kmtlyZTXkqnNnSPaNaUoefpoPxB = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.initialized)
			{
				mnhADrHhSGIaIYDbIQwIACmeOquj(kmtlyZTXkqnNnSPaNaUoefpoPxB, PositionType.kZazSODdPWKkPNqkEMQEeHglNjy, !instant && _animateOnReturn, _returnSpeed, RBlhvBHjSWMmwaWNBnDzoHUMCDyp.ljhsqtORyJauKccpTHIeMXhgWUM);
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
			if (Application.isPlaying)
			{
				kmtlyZTXkqnNnSPaNaUoefpoPxB = base.rectTransform.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.initialized)
			{
				lobXwMhkakKXYKYMfyRgSFyhrnN();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.initialized)
			{
				qBJzEuLceLbZngSExWQZwAUKrscK();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				lobXwMhkakKXYKYMfyRgSFyhrnN();
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
			base.GoDzCZSWyCxHOoFNmmNBncoqcAY();
			if (base.initialized)
			{
				ibSzDfOLNeljIKYpzEPmwhxSCgBF();
				RcFzvwaQVQVkBwtYqZZQvXTKHtW();
				zVsIgehNSSCDkNSOzFJuBWrMeMKZ();
				if (_followTouchPosition)
				{
					ZEnyTfsHdCjXlSsdZLGDWIUkaAH(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!yTsKtkkrFvbLTmEALJcKJZadFG())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.initialized && hasController)
			{
				VcUTUxvIAwcjVgDobEIWBXMWIxQm(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			dJZdkEnsfJibdbIbYyjwTTIGMtqV();
			_axis.AxisValueChangedEvent += dlfTjjOSglEtOSsfBFnLjBJfdgnH;
			_axis.ButtonValueChangedEvent += dLFvatGGxknaAsDVCcKsFXSLpRQ;
			_axis.ButtonDownEvent += ehdcTJAZITJiCZBXCcUrAGvZaOp;
			_axis.ButtonUpEvent += VkONAuelDiydjjxpMmnygtMidVc;
		}

		internal void OnUnsubscribeEvents()
		{
			EryQQjAUaPnoItWfLGLmyUsSpHl();
			_axis.AxisValueChangedEvent -= dlfTjjOSglEtOSsfBFnLjBJfdgnH;
			_axis.ButtonValueChangedEvent -= dLFvatGGxknaAsDVCcKsFXSLpRQ;
			_axis.ButtonDownEvent -= ehdcTJAZITJiCZBXCcUrAGvZaOp;
			_axis.ButtonUpEvent -= VkONAuelDiydjjxpMmnygtMidVc;
		}

		internal void OnSetProperty()
		{
			MxNDYRdNWvbuwnEvdAejdyZphUD();
			if (base.initialized)
			{
				lobXwMhkakKXYKYMfyRgSFyhrnN();
			}
		}

		internal void OnClear()
		{
			if (base.initialized)
			{
				jWHWRIRchJdZIFaIUCTieTgtWrT = int.MinValue;
				WUPzpkLQsFkiBwuysjzISJFZNGU = int.MinValue;
				TeYWPPoFyMNBbKncGGitZfUyemX = false;
				wDYSPwlKjAWglTFTTAdVKNarCnx = false;
				if (_returnOnRelease && zbznKEdvcQoHuaEaYhIQqjjjCBa && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				zbznKEdvcQoHuaEaYhIQqjjjCBa = false;
				yPNllrAyUNsoigvxVmfWdFxCRTN = false;
				jKhGYvucicYSedVXsAeitFGZfocF = RBlhvBHjSWMmwaWNBnDzoHUMCDyp.xHdBaRgdNDZThJOvnpmpFtvdLIun;
				kcLGuZiExDEGYBoNsebZxTajDdrG();
				_axis.Clear();
				DutvYHcoSmUlhOIEraYfgNUaRocW = 0f;
				GWJXYNNDUZzSYHIRqPwshTrgTbz = 0f;
				lobXwMhkakKXYKYMfyRgSFyhrnN();
			}
		}

		public override void ClearValue()
		{
			if (base.initialized)
			{
				_axis.Clear();
				DutvYHcoSmUlhOIEraYfgNUaRocW = 0f;
				if (hasController)
				{
					base.controller.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!PmzPLRTbzhVAsZEWmVqPqmwBgpn())
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
			if (base.bvnqUnjCsHckqafilSFkqwdznqm(gameObject))
			{
				return true;
			}
			if (KsJmCARPEJgpyGUnirFjSculwwK != null)
			{
				return KsJmCARPEJgpyGUnirFjSculwwK.gameObject == gameObject;
			}
			return false;
		}

		private void zVsIgehNSSCDkNSOzFJuBWrMeMKZ()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					VyxVMcHhlLHwveridQLcRsAZMsIC();
				}
				else
				{
					dczsNzovZLpJQNmoQboPjSUAhgys();
				}
			}
		}

		private void VyxVMcHhlLHwveridQLcRsAZMsIC()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += DutvYHcoSmUlhOIEraYfgNUaRocW;
			num = MathTools.Clamp(num, -1f, 1f);
			PKXaoHdOfiIyeuPeKnturTbuIPU(num, true);
		}

		private void dczsNzovZLpJQNmoQboPjSUAhgys()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float dutvYHcoSmUlhOIEraYfgNUaRocW = DutvYHcoSmUlhOIEraYfgNUaRocW;
			if (dutvYHcoSmUlhOIEraYfgNUaRocW != 0f)
			{
				float num2 = num * Time.unscaledDeltaTime;
				float num3;
				if (MathTools.Abs(num2) >= MathTools.Abs(dutvYHcoSmUlhOIEraYfgNUaRocW))
				{
					num3 = 0f;
				}
				else
				{
					float num4 = ((dutvYHcoSmUlhOIEraYfgNUaRocW > 0f) ? (-1f) : 1f);
					num3 = dutvYHcoSmUlhOIEraYfgNUaRocW + num4 * num2;
				}
				PKXaoHdOfiIyeuPeKnturTbuIPU(num3, true);
			}
		}

		private void PKXaoHdOfiIyeuPeKnturTbuIPU(float P_0, bool P_1)
		{
			GWJXYNNDUZzSYHIRqPwshTrgTbz = DutvYHcoSmUlhOIEraYfgNUaRocW;
			DutvYHcoSmUlhOIEraYfgNUaRocW = P_0;
			if (P_0 != GWJXYNNDUZzSYHIRqPwshTrgTbz)
			{
				XQWPTxZJvVnljinalPFNQOhrbRM(null);
			}
			if (P_1 && P_0 != GWJXYNNDUZzSYHIRqPwshTrgTbz)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void mDiBCZObkxGdVIGpSNiWddeiDewy()
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

		private void wMbDpBZHnFZXEyLypMDXGKQmDKh()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void lobXwMhkakKXYKYMfyRgSFyhrnN()
		{
			_targetCustomControllerElement.ClearElementCaches();
			RcFzvwaQVQVkBwtYqZZQvXTKHtW();
			bzlavaeXqNGLjGQogjryfXKdvCc();
		}

		private void bzlavaeXqNGLjGQogjryfXKdvCc()
		{
			if (_manageRaycasting)
			{
				QmbGBcCDwaDLkbJZCpfWFPFqjyms.pdWNtSuAtgJQpXSAYCtoqPXrdLT(base.transform, BNtCMBjfzgSuBipXnIevnBCZamR());
			}
		}

		private bool BNtCMBjfzgSuBipXnIevnBCZamR()
		{
			if (KsJmCARPEJgpyGUnirFjSculwwK != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void wwnsaArOhVCrQckwyLXHhbqPZzsr(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				kcaGlalrdXgjoIkDpsczEgcePcYC(P_0);
				P_0.PointerDownEvent += cZHnDsnqZfCdWdMsRPSmcOamfFgj;
				P_0.PointerUpEvent += NbBtGpeWImTANlFHXfhuNAoFiue;
				P_0.PointerEnterEvent += XlFeLLtgdCbWrHCYThkFcEmntpC;
				P_0.PointerExitEvent += EIULUocpDXDSgLhxEOuGWBwmyds;
			}
		}

		private void kcaGlalrdXgjoIkDpsczEgcePcYC(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= cZHnDsnqZfCdWdMsRPSmcOamfFgj;
				P_0.PointerUpEvent -= NbBtGpeWImTANlFHXfhuNAoFiue;
				P_0.PointerEnterEvent -= XlFeLLtgdCbWrHCYThkFcEmntpC;
				P_0.PointerExitEvent -= EIULUocpDXDSgLhxEOuGWBwmyds;
			}
		}

		private void RcFzvwaQVQVkBwtYqZZQvXTKHtW()
		{
			if (!(KsJmCARPEJgpyGUnirFjSculwwK == _touchRegion))
			{
				kcaGlalrdXgjoIkDpsczEgcePcYC(KsJmCARPEJgpyGUnirFjSculwwK);
				KsJmCARPEJgpyGUnirFjSculwwK = _touchRegion;
				wwnsaArOhVCrQckwyLXHhbqPZzsr(KsJmCARPEJgpyGUnirFjSculwwK);
			}
		}

		private void auDkVYrswLDflriZPEgYvJHxGBR(Vector2 P_0, bool P_1, float P_2, RBlhvBHjSWMmwaWNBnDzoHUMCDyp P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = lOjEgNUYKDaLCggmFifXLItFlte.YpTdmPpDeBhqHDMyLNbFAREIvbkg(base.canvas, rectTransform, P_0);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 sizeDelta = base.rectTransform.sizeDelta;
			Vector3 localScale = base.rectTransform.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			mnhADrHhSGIaIYDbIQwIACmeOquj(vector, PositionType.aXQImphWLsNyAXlPBncGlpmgAAN, P_1, P_2, P_3);
		}

		private void mnhADrHhSGIaIYDbIQwIACmeOquj(Vector2 P_0, PositionType P_1, bool P_2, float P_3, RBlhvBHjSWMmwaWNBnDzoHUMCDyp P_4)
		{
			if (yPNllrAyUNsoigvxVmfWdFxCRTN && P_2 && jKhGYvucicYSedVXsAeitFGZfocF == P_4)
			{
				return;
			}
			if (yPNllrAyUNsoigvxVmfWdFxCRTN && WWhxbccjJbhTwFzPCOOWlQhqDSr != null)
			{
				kcLGuZiExDEGYBoNsebZxTajDdrG();
				yPNllrAyUNsoigvxVmfWdFxCRTN = false;
				jKhGYvucicYSedVXsAeitFGZfocF = RBlhvBHjSWMmwaWNBnDzoHUMCDyp.xHdBaRgdNDZThJOvnpmpFtvdLIun;
			}
			if (base.canvas == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.canvas.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.canvasTransform;
				Vector2 one = Vector2.one;
				while ((parent = parent.parent) != rectTransform && !(parent == null))
				{
					one.x *= parent.localScale.x;
					one.y *= parent.localScale.y;
				}
				Vector2 sizeDelta = rectTransform.sizeDelta;
				bool flag = sizeDelta.x < sizeDelta.y;
				float num = MathTools.Max(sizeDelta.x, sizeDelta.y);
				float num2 = (flag ? one.y : one.x);
				if (num2 == 0f)
				{
					num2 = 0.0001f;
				}
				P_3 = P_3 / num2 * num;
				WWhxbccjJbhTwFzPCOOWlQhqDSr = iqsYzqEcUjftSKLXqOTGAarJUKdQ(P_0, P_1, P_3, P_4);
				StartCoroutine(WWhxbccjJbhTwFzPCOOWlQhqDSr);
				jKhGYvucicYSedVXsAeitFGZfocF = P_4;
				zbznKEdvcQoHuaEaYhIQqjjjCBa = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				QFfhhGPWZppUICMXpzmNqXgmgTe(P_4, P_0, P_1);
			}
		}

		private IEnumerator iqsYzqEcUjftSKLXqOTGAarJUKdQ(Vector2 P_0, PositionType P_1, float P_2, RBlhvBHjSWMmwaWNBnDzoHUMCDyp P_3)
		{
			DRHkgXdnkYRYCnIDkeQARUNNjfp dRHkgXdnkYRYCnIDkeQARUNNjfp = new DRHkgXdnkYRYCnIDkeQARUNNjfp(0);
			dRHkgXdnkYRYCnIDkeQARUNNjfp.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			dRHkgXdnkYRYCnIDkeQARUNNjfp.ScXDNLvDavIuowqstQHaYcTQvVj = P_0;
			dRHkgXdnkYRYCnIDkeQARUNNjfp.ODipSlYvwRswiyGWpaiwIwOmaWv = P_1;
			dRHkgXdnkYRYCnIDkeQARUNNjfp.JutmFCdjNXRKeZDUAmUgTzndNtQ = P_2;
			dRHkgXdnkYRYCnIDkeQARUNNjfp.tNrzeLxiAExjaZcvROmiccNuyXY = P_3;
			return dRHkgXdnkYRYCnIDkeQARUNNjfp;
		}

		private void QFfhhGPWZppUICMXpzmNqXgmgTe(RBlhvBHjSWMmwaWNBnDzoHUMCDyp P_0, Vector2 P_1, PositionType P_2)
		{
			lOjEgNUYKDaLCggmFifXLItFlte.kPSRPhEgnLVfCczyndEheCeBcby(base.rectTransform, P_1, P_2);
			yPNllrAyUNsoigvxVmfWdFxCRTN = false;
			jKhGYvucicYSedVXsAeitFGZfocF = RBlhvBHjSWMmwaWNBnDzoHUMCDyp.xHdBaRgdNDZThJOvnpmpFtvdLIun;
			switch (P_0)
			{
			case RBlhvBHjSWMmwaWNBnDzoHUMCDyp.ljhsqtORyJauKccpTHIeMXhgWUM:
				zbznKEdvcQoHuaEaYhIQqjjjCBa = false;
				break;
			case RBlhvBHjSWMmwaWNBnDzoHUMCDyp.WPytrjpOROGjrBgAebwWrfBpLYv:
				zbznKEdvcQoHuaEaYhIQqjjjCBa = true;
				break;
			}
			kcLGuZiExDEGYBoNsebZxTajDdrG();
			moveEndedDelegate(P_0);
		}

		private void OGVCroDHaYppXqKqCikMtNJsbaA(RBlhvBHjSWMmwaWNBnDzoHUMCDyp P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && KsJmCARPEJgpyGUnirFjSculwwK != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == RBlhvBHjSWMmwaWNBnDzoHUMCDyp.WPytrjpOROGjrBgAebwWrfBpLYv)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					QmbGBcCDwaDLkbJZCpfWFPFqjyms.pdWNtSuAtgJQpXSAYCtoqPXrdLT(base.transform, flag2);
				}
			}
		}

		private void HMqDmWbpANlJfrnOOzffODkXSiNr(RBlhvBHjSWMmwaWNBnDzoHUMCDyp P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && KsJmCARPEJgpyGUnirFjSculwwK != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == RBlhvBHjSWMmwaWNBnDzoHUMCDyp.ljhsqtORyJauKccpTHIeMXhgWUM)
				{
					flag = true;
					flag2 = BNtCMBjfzgSuBipXnIevnBCZamR();
				}
				if (flag)
				{
					QmbGBcCDwaDLkbJZCpfWFPFqjyms.pdWNtSuAtgJQpXSAYCtoqPXrdLT(base.transform, flag2);
				}
			}
		}

		private void ZEnyTfsHdCjXlSsdZLGDWIUkaAH(int P_0)
		{
			if (TouchInteractable.drLtaaDzczryPGXVgVOLzVaFGWL(P_0))
			{
				auDkVYrswLDflriZPEgYvJHxGBR(TouchInteractable.CpVfSgBIpqTojStivvwPfHPkOalA(P_0), false, 0f, RBlhvBHjSWMmwaWNBnDzoHUMCDyp.WPytrjpOROGjrBgAebwWrfBpLYv);
			}
		}

		private void kcLGuZiExDEGYBoNsebZxTajDdrG()
		{
			if (WWhxbccjJbhTwFzPCOOWlQhqDSr != null)
			{
				try
				{
					StopCoroutine(WWhxbccjJbhTwFzPCOOWlQhqDSr);
				}
				catch
				{
				}
				WWhxbccjJbhTwFzPCOOWlQhqDSr = null;
			}
		}

		private void ibSzDfOLNeljIKYpzEPmwhxSCgBF()
		{
			if (hasPointer && !TouchInteractable.drLtaaDzczryPGXVgVOLzVaFGWL(effectivePointerId))
			{
				PointerEventData pointerEventData = OvDEccJLoXdMfynwFiRlBbvlHER(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					YENDmQzvHJgevTAewjmnmcfedn(pointerEventData);
				}
				else
				{
					VOdZJnQbjeHwpghUEOKTwOKVXRdF();
				}
			}
		}

		private bool WoeifeKWkAJetEpCTxVeyqtZgkA()
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

		private void ombjqnRRuZkQoVNJWYLFBTVgigb()
		{
			jWHWRIRchJdZIFaIUCTieTgtWrT = int.MinValue;
			WUPzpkLQsFkiBwuysjzISJFZNGU = int.MinValue;
		}

		private bool DUsKOPKCkQhLaToxMBDUbGlNVJIt(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (jWHWRIRchJdZIFaIUCTieTgtWrT == int.MinValue)
			{
				return false;
			}
			if (jWHWRIRchJdZIFaIUCTieTgtWrT == P_0)
			{
				return true;
			}
			if (TouchInteractable.bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0) && WUPzpkLQsFkiBwuysjzISJFZNGU != int.MinValue && P_0 == WUPzpkLQsFkiBwuysjzISJFZNGU)
			{
				return true;
			}
			return false;
		}

		private PointerEventData hFehlZDaMQjnEPlJOtdpjiuAfXnN(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = OvDEccJLoXdMfynwFiRlBbvlHER(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.CpVfSgBIpqTojStivvwPfHPkOalA(P_0);
			if (TouchInteractable.yKhgFVKBryTMtmcFDTYNKQwGtIrr(P_0))
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
				if (!TouchInteractable.bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0))
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

		private PointerEventData wcIAkyLztZWttfuPqEFWgdzouEc(int P_0)
		{
			PointerEventData pointerEventData = OvDEccJLoXdMfynwFiRlBbvlHER(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.yKhgFVKBryTMtmcFDTYNKQwGtIrr(P_0))
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
				if (!TouchInteractable.bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0))
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

		private void YENDmQzvHJgevTAewjmnmcfedn(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				wcIAkyLztZWttfuPqEFWgdzouEc(effectivePointerId);
			}
		}

		private PointerEventData OvDEccJLoXdMfynwFiRlBbvlHER(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (FlEkmKpIMkbefDmZqoUfRZNMSVec == null)
			{
				FlEkmKpIMkbefDmZqoUfRZNMSVec = new Dictionary<int, PointerEventData>();
			}
			if (!FlEkmKpIMkbefDmZqoUfRZNMSVec.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				FlEkmKpIMkbefDmZqoUfRZNMSVec.Add(P_0, value);
				if (TouchInteractable.bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0))
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

		private void vMcFetiXHLULvoXtzvAMUsTaDHMl(PointerEventData P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae P_1)
		{
			if (!hasPointer || DUsKOPKCkQhLaToxMBDUbGlNVJIt(P_0.pointerId))
			{
				if (PmzPLRTbzhVAsZEWmVqPqmwBgpn() && IsInteractable())
				{
					EsEYKHCJOcVDtAIJILUbHPvjIhc(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void GksLanYNmLRJSZGgXlTteKyUAedD(PointerEventData P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae P_1)
		{
			if ((!hasPointer || DUsKOPKCkQhLaToxMBDUbGlNVJIt(P_0.pointerId)) && !TouchInteractable.drLtaaDzczryPGXVgVOLzVaFGWL(effectivePointerId))
			{
				VOdZJnQbjeHwpghUEOKTwOKVXRdF();
				base.OnPointerUp(P_0);
			}
		}

		private void YVPJwecCoEbfyvnJrasrUNCIbks(PointerEventData P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae P_1)
		{
			if (hasPointer && !DUsKOPKCkQhLaToxMBDUbGlNVJIt(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				VgfdSFwNLJGGqdJJyfaMMVpFZnae.aXQImphWLsNyAXlPBncGlpmgAAN => base.allowedMouseButtons, 
				VgfdSFwNLJGGqdJJyfaMMVpFZnae.YBYRTOWNaXAOXNHGYPyoIIFUOoC => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && PmzPLRTbzhVAsZEWmVqPqmwBgpn() && IsInteractable() && (!flag || TouchInteractable.OZFdDoQVLcQGFsSqVeUdHqpttTZ(mouseButtonFlags)) && !TeYWPPoFyMNBbKncGGitZfUyemX)
			{
				if (flag)
				{
					if (TouchInteractable.EvThQAjlPBPgHUXNoSHCEtMVLsj(mouseButtonFlags, out var wUPzpkLQsFkiBwuysjzISJFZNGU))
					{
						WUPzpkLQsFkiBwuysjzISJFZNGU = wUPzpkLQsFkiBwuysjzISJFZNGU;
					}
					else
					{
						WUPzpkLQsFkiBwuysjzISJFZNGU = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					VgfdSFwNLJGGqdJJyfaMMVpFZnae.aXQImphWLsNyAXlPBncGlpmgAAN => base.gameObject, 
					VgfdSFwNLJGGqdJJyfaMMVpFZnae.YBYRTOWNaXAOXNHGYPyoIIFUOoC => KsJmCARPEJgpyGUnirFjSculwwK.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = hFehlZDaMQjnEPlJOtdpjiuAfXnN((WUPzpkLQsFkiBwuysjzISJFZNGU != int.MinValue) ? WUPzpkLQsFkiBwuysjzISJFZNGU : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					vMcFetiXHLULvoXtzvAMUsTaDHMl(pointerEventData, P_1);
				}
			}
			wDYSPwlKjAWglTFTTAdVKNarCnx = true;
		}

		private void iMlWrZDRXEndMBDabDaMwwLPLKC(PointerEventData P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae P_1)
		{
			if (hasPointer && !DUsKOPKCkQhLaToxMBDUbGlNVJIt(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && TeYWPPoFyMNBbKncGGitZfUyemX)
			{
				VOdZJnQbjeHwpghUEOKTwOKVXRdF();
			}
			base.OnPointerExit(P_0);
			wDYSPwlKjAWglTFTTAdVKNarCnx = false;
		}

		private void EsEYKHCJOcVDtAIJILUbHPvjIhc(int P_0, Vector2 P_1, VgfdSFwNLJGGqdJJyfaMMVpFZnae P_2)
		{
			jWHWRIRchJdZIFaIUCTieTgtWrT = P_0;
			TeYWPPoFyMNBbKncGGitZfUyemX = true;
			if (_followTouchPosition)
			{
				ZEnyTfsHdCjXlSsdZLGDWIUkaAH(P_0);
			}
			else if (P_2 == VgfdSFwNLJGGqdJJyfaMMVpFZnae.YBYRTOWNaXAOXNHGYPyoIIFUOoC && _moveToTouchPosition)
			{
				auDkVYrswLDflriZPEgYvJHxGBR(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, RBlhvBHjSWMmwaWNBnDzoHUMCDyp.WPytrjpOROGjrBgAebwWrfBpLYv);
			}
			mDiBCZObkxGdVIGpSNiWddeiDewy();
		}

		private void VOdZJnQbjeHwpghUEOKTwOKVXRdF()
		{
			ombjqnRRuZkQoVNJWYLFBTVgigb();
			TeYWPPoFyMNBbKncGGitZfUyemX = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && zbznKEdvcQoHuaEaYhIQqjjjCBa)
			{
				ReturnToDefaultPosition();
			}
			wMbDpBZHnFZXEyLypMDXGKQmDKh();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(KsJmCARPEJgpyGUnirFjSculwwK != null) || !_useTouchRegionOnly))
			{
				vMcFetiXHLULvoXtzvAMUsTaDHMl(eventData, VgfdSFwNLJGGqdJJyfaMMVpFZnae.aXQImphWLsNyAXlPBncGlpmgAAN);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(KsJmCARPEJgpyGUnirFjSculwwK != null) || !_useTouchRegionOnly))
			{
				GksLanYNmLRJSZGgXlTteKyUAedD(eventData, VgfdSFwNLJGGqdJJyfaMMVpFZnae.aXQImphWLsNyAXlPBncGlpmgAAN);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(KsJmCARPEJgpyGUnirFjSculwwK != null) || !_useTouchRegionOnly))
			{
				YVPJwecCoEbfyvnJrasrUNCIbks(eventData, VgfdSFwNLJGGqdJJyfaMMVpFZnae.aXQImphWLsNyAXlPBncGlpmgAAN);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(KsJmCARPEJgpyGUnirFjSculwwK != null) || !_useTouchRegionOnly))
			{
				iMlWrZDRXEndMBDabDaMwwLPLKC(eventData, VgfdSFwNLJGGqdJJyfaMMVpFZnae.aXQImphWLsNyAXlPBncGlpmgAAN);
			}
		}

		private void cZHnDsnqZfCdWdMsRPSmcOamfFgj(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				vMcFetiXHLULvoXtzvAMUsTaDHMl(P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae.YBYRTOWNaXAOXNHGYPyoIIFUOoC);
			}
		}

		private void NbBtGpeWImTANlFHXfhuNAoFiue(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				GksLanYNmLRJSZGgXlTteKyUAedD(P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae.YBYRTOWNaXAOXNHGYPyoIIFUOoC);
			}
		}

		private void XlFeLLtgdCbWrHCYThkFcEmntpC(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				YVPJwecCoEbfyvnJrasrUNCIbks(P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae.YBYRTOWNaXAOXNHGYPyoIIFUOoC);
			}
		}

		private void EIULUocpDXDSgLhxEOuGWBwmyds(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.HJbePsKtyjbsvZCFomIPfAKzIWp(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				iMlWrZDRXEndMBDabDaMwwLPLKC(P_0, VgfdSFwNLJGGqdJJyfaMMVpFZnae.YBYRTOWNaXAOXNHGYPyoIIFUOoC);
			}
		}

		private void dlfTjjOSglEtOSsfBFnLjBJfdgnH(float P_0)
		{
			if (base.initialized && !_useDigitalAxisSimulation)
			{
				XQWPTxZJvVnljinalPFNQOhrbRM(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void dLFvatGGxknaAsDVCcKsFXSLpRQ(bool P_0)
		{
			if (base.initialized)
			{
				XQWPTxZJvVnljinalPFNQOhrbRM(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void ehdcTJAZITJiCZBXCcUrAGvZaOp()
		{
			if (base.initialized)
			{
				XQWPTxZJvVnljinalPFNQOhrbRM(null);
				_onButtonDown.Invoke();
			}
		}

		private void VkONAuelDiydjjxpMmnygtMidVc()
		{
			if (base.initialized)
			{
				XQWPTxZJvVnljinalPFNQOhrbRM(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
