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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Touch Button")]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum beybCbmzNPVQsbcvobtcSqOzXSMr
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum hzyGbphuGSabeAyvbdCVeWtEqiMac
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

		private sealed class bsouifPBcOwVHGafhfDjYtnYVVgh : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int nvTmNPRnghnExGtcdwgIiRepTYhj;

			private object FHsLvatsNbCDCfSUcdrebUWdHbBQc;

			public float QWMKvXhilrwihTduYfNnHfYdHXFtA;

			public TouchButton TLbwztTOXeWfLHXFdymbpBnIdjbo;

			public PositionType JcmTrGUFnyWdabOyVBAVqrlPwJAy;

			public Vector2 NTFtsaeKxrcWLCrsBHqZvcoJpfDCb;

			public beybCbmzNPVQsbcvobtcSqOzXSMr aUfzSskwbvLujIEorSKyfoNLnWxd;

			private RectTransform BhudgkgdDtTDbTEMAUQpsTqaXyBs;

			private Vector2 zTulLKVcfsoDikPZefFpxRXzMHxS;

			private float FbXYqDgdUJyAAVBLwcNbslvRlUAu;

			private float GWsrKrcEufBfZBqbwParXonLLuEA;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return FHsLvatsNbCDCfSUcdrebUWdHbBQc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FHsLvatsNbCDCfSUcdrebUWdHbBQc;
				}
			}

			[DebuggerHidden]
			public bsouifPBcOwVHGafhfDjYtnYVVgh(int P_0)
			{
				nvTmNPRnghnExGtcdwgIiRepTYhj = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = nvTmNPRnghnExGtcdwgIiRepTYhj;
				TouchButton tLbwztTOXeWfLHXFdymbpBnIdjbo = TLbwztTOXeWfLHXFdymbpBnIdjbo;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					nvTmNPRnghnExGtcdwgIiRepTYhj = -1;
					goto IL_010c;
				}
				nvTmNPRnghnExGtcdwgIiRepTYhj = -1;
				if (!(QWMKvXhilrwihTduYfNnHfYdHXFtA <= 0f))
				{
					BhudgkgdDtTDbTEMAUQpsTqaXyBs = tLbwztTOXeWfLHXFdymbpBnIdjbo.KXbFLgsvCYMSvuHjRTfknYKDbMAM;
					zTulLKVcfsoDikPZefFpxRXzMHxS = DqaChzdTZYNFWhBQIpZWKgtwfiCfA.CyKeeehKagdHzEOJhkdvTCWQzUMsb(BhudgkgdDtTDbTEMAUQpsTqaXyBs, JcmTrGUFnyWdabOyVBAVqrlPwJAy);
					float magnitude = (NTFtsaeKxrcWLCrsBHqZvcoJpfDCb - zTulLKVcfsoDikPZefFpxRXzMHxS).magnitude;
					if (!(magnitude < 0.01f))
					{
						tLbwztTOXeWfLHXFdymbpBnIdjbo.IjTqkfTYhITHYNkoiEyFGjlcOfaEA = true;
						FbXYqDgdUJyAAVBLwcNbslvRlUAu = magnitude / QWMKvXhilrwihTduYfNnHfYdHXFtA;
						GWsrKrcEufBfZBqbwParXonLLuEA = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				tLbwztTOXeWfLHXFdymbpBnIdjbo.nBtEZhtzxlJeiHWenkylcxJZKTkA(aUfzSskwbvLujIEorSKyfoNLnWxd, NTFtsaeKxrcWLCrsBHqZvcoJpfDCb, JcmTrGUFnyWdabOyVBAVqrlPwJAy);
				return false;
				IL_010c:
				if (GWsrKrcEufBfZBqbwParXonLLuEA <= 1f)
				{
					GWsrKrcEufBfZBqbwParXonLLuEA += Time.unscaledDeltaTime / FbXYqDgdUJyAAVBLwcNbslvRlUAu;
					DqaChzdTZYNFWhBQIpZWKgtwfiCfA.BsdJYCzGuBKzUbylUTSvUyoLgxek(BhudgkgdDtTDbTEMAUQpsTqaXyBs, Vector2.Lerp(zTulLKVcfsoDikPZefFpxRXzMHxS, NTFtsaeKxrcWLCrsBHqZvcoJpfDCb, Mathf.SmoothStep(0f, 1f, GWsrKrcEufBfZBqbwParXonLLuEA)), JcmTrGUFnyWdabOyVBAVqrlPwJAy);
					FHsLvatsNbCDCfSUcdrebUWdHbBQc = null;
					nvTmNPRnghnExGtcdwgIiRepTYhj = 1;
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

		private const float onRjHTrnrluHuXZacQHeiduhfknhA = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonType _buttonType;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		private bool _useDigitalAxisSimulation;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		private float _digitalAxisGravity = 3f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		private float _digitalAxisSensitivity = 3f;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private StandaloneAxis _axis = new StandaloneAxis();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		private TouchRegion _touchRegion;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		private bool _useTouchRegionOnly = true;

		[SerializeField]
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _moveToTouchSpeed = 2f;

		[SerializeField]
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private float gtMAszCUnxftQOBihxFMPcQYohENA;

		private float bKFNBmykzyLHxWEMvhEwbdHtoWaRA;

		private TouchRegion FsqNNWBOmzvzCwfpnOGIHeEdgRMU;

		private Vector2 XzPoBwXbTEopeNIxfjFHPpXEcTip;

		private bool IjTqkfTYhITHYNkoiEyFGjlcOfaEA;

		private bool kTYvwSpNEvQYbqsXYKxHTAxdTCxT;

		private beybCbmzNPVQsbcvobtcSqOzXSMr kkBCpyBbGVrItoIhvUKfofFXLRFcA;

		private int biDoHIshjqUpkghDeaRIILEwTBFS = int.MinValue;

		private int IPFLQCdbpZADtdGVkUZwiygQQyQPA = int.MinValue;

		[NonSerialized]
		private bool MDxbeUBimaNWYMDiXlAyoITZZaiK;

		[NonSerialized]
		private bool cIeENuGXuRuqkGvzliwxduIgLHSMA;

		private IEnumerator FOEDySJrCTsxsvvfYjzeSCMmMMZL;

		private DVQzFAWdDpbloDWGesgiOGNXKEUXA zFJqlnMOQReWSHfBBVwrHPhabjJO = new DVQzFAWdDpbloDWGesgiOGNXKEUXA();

		private Action<beybCbmzNPVQsbcvobtcSqOzXSMr> QbQHGLDncyAfPPmbekqnLVVPfeRoA;

		private Action<beybCbmzNPVQsbcvobtcSqOzXSMr> AXvVdHZODqpLhFPOZOtYrgREjLxF;

		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the button value changes.")]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the button is pressed.")]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> joTPeudNYvtshmPBhwXpApOoaSSA;

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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (FfYKKymhcFmslDeBKSfTlSmcsxdt())
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
						ZQveiYiSfwSmoPOaLIYPkgABjYPq();
					}
					else
					{
						zFJqlnMOQReWSHfBBVwrHPhabjJO.BYQOPWTaxsiwkGnKZTnrGCxUQYTA();
					}
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return biDoHIshjqUpkghDeaRIILEwTBFS;
			}
			set
			{
				biDoHIshjqUpkghDeaRIILEwTBFS = value;
			}
		}

		public bool hasPointer => biDoHIshjqUpkghDeaRIILEwTBFS != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<beybCbmzNPVQsbcvobtcSqOzXSMr> moveStartedDelegate
		{
			get
			{
				if (QbQHGLDncyAfPPmbekqnLVVPfeRoA == null)
				{
					return QbQHGLDncyAfPPmbekqnLVVPfeRoA = MvxlCnYfQLYLZfSxigAFDNFJXEgi;
				}
				return QbQHGLDncyAfPPmbekqnLVVPfeRoA;
			}
		}

		private Action<beybCbmzNPVQsbcvobtcSqOzXSMr> moveEndedDelegate
		{
			get
			{
				if (AXvVdHZODqpLhFPOZOtYrgREjLxF == null)
				{
					return AXvVdHZODqpLhFPOZOtYrgREjLxF = MoUCdjWKmQqUlEsQuqQxQoQvkcAS;
				}
				return AXvVdHZODqpLhFPOZOtYrgREjLxF;
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
				return gtMAszCUnxftQOBihxFMPcQYohENA;
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
				return bKFNBmykzyLHxWEMvhEwbdHtoWaRA;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (biDoHIshjqUpkghDeaRIILEwTBFS == int.MinValue)
				{
					return int.MinValue;
				}
				if (IPFLQCdbpZADtdGVkUZwiygQQyQPA != int.MinValue)
				{
					return IPFLQCdbpZADtdGVkUZwiygQQyQPA;
				}
				return biDoHIshjqUpkghDeaRIILEwTBFS;
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
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			nPEVMeMMkZfRfbMdPtFGlVNMtUprA(base.KXbFLgsvCYMSvuHjRTfknYKDbMAM.anchoredPosition);
		}

		private void nPEVMeMMkZfRfbMdPtFGlVNMtUprA(Vector2 P_0)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				XzPoBwXbTEopeNIxfjFHPpXEcTip = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				WuuUpLofnuDwZhrrpAihCwLtvFJg(XzPoBwXbTEopeNIxfjFHPpXEcTip, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, beybCbmzNPVQsbcvobtcSqOzXSMr.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
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
				XzPoBwXbTEopeNIxfjFHPpXEcTip = base.KXbFLgsvCYMSvuHjRTfknYKDbMAM.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				nMJNeEjMUPguTAcPpYEzcqrAYAIj();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				pUDwhrfBtvoGUyjyVCwDYOFnTkUL();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				nMJNeEjMUPguTAcPpYEzcqrAYAIj();
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
			base.HDehBiVJQHtZseCWJjHvsFnOvLVX();
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				FplJNCGwlunmWKDOSjxeDdgyHgRyA();
				lKWCigCxTEyjbNjxaewUPNmwHLgrA();
				wpLiaksgcPLPvBznXyublFllxXNm();
				if (_followTouchPosition)
				{
					wfPAyHEInQgQHGMFLwbWNGKFatcg(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!eXuLZbsoevtAdlpQPYDImaDSfOHz())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && tCmDnaqSHMayjAbLSbCCIFMNrLegA)
			{
				TcUpHSLRYsxYwaeotAfbcWODWZmj(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			ZRtPdJfFFlFAhGTFpzpDpLmfnXmn();
			_axis.AxisValueChangedEvent += tCRFQmtWShSHZTpAWrrSuWgMlEaO;
			_axis.ButtonValueChangedEvent += hqOouzPlVhUsyvurYBhWBsXBARfX;
			_axis.ButtonDownEvent += EgVwBBpOtvhGriGEHCpjPpgNbPcE;
			_axis.ButtonUpEvent += sEWqrXotkVHsxCrVQDQHTMgXFUSDA;
		}

		internal void OnUnsubscribeEvents()
		{
			ePmTlETkzdjAnRGaNWOhsSwHQyI();
			_axis.AxisValueChangedEvent -= tCRFQmtWShSHZTpAWrrSuWgMlEaO;
			_axis.ButtonValueChangedEvent -= hqOouzPlVhUsyvurYBhWBsXBARfX;
			_axis.ButtonDownEvent -= EgVwBBpOtvhGriGEHCpjPpgNbPcE;
			_axis.ButtonUpEvent -= sEWqrXotkVHsxCrVQDQHTMgXFUSDA;
		}

		internal void OnSetProperty()
		{
			UrxvCbTTyrcwzAlwHnkPcfjwZqaC();
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				nMJNeEjMUPguTAcPpYEzcqrAYAIj();
			}
		}

		internal void OnClear()
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				biDoHIshjqUpkghDeaRIILEwTBFS = int.MinValue;
				IPFLQCdbpZADtdGVkUZwiygQQyQPA = int.MinValue;
				MDxbeUBimaNWYMDiXlAyoITZZaiK = false;
				cIeENuGXuRuqkGvzliwxduIgLHSMA = false;
				if (_returnOnRelease && kTYvwSpNEvQYbqsXYKxHTAxdTCxT && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				kTYvwSpNEvQYbqsXYKxHTAxdTCxT = false;
				IjTqkfTYhITHYNkoiEyFGjlcOfaEA = false;
				kkBCpyBbGVrItoIhvUKfofFXLRFcA = beybCbmzNPVQsbcvobtcSqOzXSMr.None;
				sLZQNGeNuNMOYHPkXKCImcnIxPHI();
				_axis.Clear();
				gtMAszCUnxftQOBihxFMPcQYohENA = 0f;
				bKFNBmykzyLHxWEMvhEwbdHtoWaRA = 0f;
				nMJNeEjMUPguTAcPpYEzcqrAYAIj();
			}
		}

		public override void ClearValue()
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				_axis.Clear();
				gtMAszCUnxftQOBihxFMPcQYohENA = 0f;
				if (tCmDnaqSHMayjAbLSbCCIFMNrLegA)
				{
					base.TuEiudZyOALZvXpibFyWSoJvoXul.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				return false;
			}
			if (!DfQIcSJUPXlHPQKgUHsgOrKCBhBG())
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
			if (base.xEwQUZcqFhGubfvZUNKxwzzGTqdF(gameObject))
			{
				return true;
			}
			if (FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null)
			{
				return FsqNNWBOmzvzCwfpnOGIHeEdgRMU.gameObject == gameObject;
			}
			return false;
		}

		private void wpLiaksgcPLPvBznXyublFllxXNm()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					tQQhlzpyVTRNvtzjXDAyfjSaBxJC();
				}
				else
				{
					ilPbDhYEmgzbKirUcIYSiXgjBfQR();
				}
			}
		}

		private void tQQhlzpyVTRNvtzjXDAyfjSaBxJC()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += gtMAszCUnxftQOBihxFMPcQYohENA;
			num = MathTools.Clamp(num, -1f, 1f);
			RPgUgrvkRvxfaSJlGxowOejrDnmp(num, true);
		}

		private void ilPbDhYEmgzbKirUcIYSiXgjBfQR()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num2 = gtMAszCUnxftQOBihxFMPcQYohENA;
			if (num2 != 0f)
			{
				float num3 = num * Time.unscaledDeltaTime;
				float num4;
				if (MathTools.Abs(num3) >= MathTools.Abs(num2))
				{
					num4 = 0f;
				}
				else
				{
					float num5 = ((num2 > 0f) ? (-1f) : 1f);
					num4 = num2 + num5 * num3;
				}
				RPgUgrvkRvxfaSJlGxowOejrDnmp(num4, true);
			}
		}

		private void RPgUgrvkRvxfaSJlGxowOejrDnmp(float P_0, bool P_1)
		{
			bKFNBmykzyLHxWEMvhEwbdHtoWaRA = gtMAszCUnxftQOBihxFMPcQYohENA;
			gtMAszCUnxftQOBihxFMPcQYohENA = P_0;
			if (P_0 != bKFNBmykzyLHxWEMvhEwbdHtoWaRA)
			{
				qTbQveApfHOMSehJBxKYMzaVLcgX(null);
			}
			if (P_1 && P_0 != bKFNBmykzyLHxWEMvhEwbdHtoWaRA)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void dWVQGSMITjPNNumEfVfrMrcmFuuI()
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

		private void XvDMxqpyvvOGDepZiWVYbpyaTLAw()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void nMJNeEjMUPguTAcPpYEzcqrAYAIj()
		{
			_targetCustomControllerElement.ClearElementCaches();
			lKWCigCxTEyjbNjxaewUPNmwHLgrA();
			ZQveiYiSfwSmoPOaLIYPkgABjYPq();
		}

		private void ZQveiYiSfwSmoPOaLIYPkgABjYPq()
		{
			if (_manageRaycasting)
			{
				zFJqlnMOQReWSHfBBVwrHPhabjJO.ewYNmyWCNHNCHmZClXtNQtKxUcEK(base.transform, FKXFydERdmPjhmVMoBEdksNDGNjt());
			}
		}

		private bool FKXFydERdmPjhmVMoBEdksNDGNjt()
		{
			if (FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void eNJeUgesVuoDcnYMLwgIYGldagVy(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				lKazzxkXbOjArnadRlPMiLMqELKG(P_0);
				P_0.PointerDownEvent += JXvJWZKfBiFCQTwsWobEEAnDHCeF;
				P_0.PointerUpEvent += tmWliuZZARiVBbQNxBNtpogKYJxO;
				P_0.PointerEnterEvent += MuKOQeMmCzGlAdrzLCJZXzLpkGJUA;
				P_0.PointerExitEvent += cObGkOnwCrReRbhAPpwGmhhCwQzb;
			}
		}

		private void lKazzxkXbOjArnadRlPMiLMqELKG(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= JXvJWZKfBiFCQTwsWobEEAnDHCeF;
				P_0.PointerUpEvent -= tmWliuZZARiVBbQNxBNtpogKYJxO;
				P_0.PointerEnterEvent -= MuKOQeMmCzGlAdrzLCJZXzLpkGJUA;
				P_0.PointerExitEvent -= cObGkOnwCrReRbhAPpwGmhhCwQzb;
			}
		}

		private void lKWCigCxTEyjbNjxaewUPNmwHLgrA()
		{
			if (!(FsqNNWBOmzvzCwfpnOGIHeEdgRMU == _touchRegion))
			{
				lKazzxkXbOjArnadRlPMiLMqELKG(FsqNNWBOmzvzCwfpnOGIHeEdgRMU);
				FsqNNWBOmzvzCwfpnOGIHeEdgRMU = _touchRegion;
				eNJeUgesVuoDcnYMLwgIYGldagVy(FsqNNWBOmzvzCwfpnOGIHeEdgRMU);
			}
		}

		private void htvpEqVswlpwkfKZamuCmfLAyNxv(Vector2 P_0, bool P_1, float P_2, beybCbmzNPVQsbcvobtcSqOzXSMr P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = DqaChzdTZYNFWhBQIpZWKgtwfiCfA.RPNHKzNFQfDoKApVrjsOYFxIcBjbb(base.krwSPbnrBGEzhAtvrnWbhxuaaPWOA, rectTransform, P_0);
			Vector2 pivot = base.KXbFLgsvCYMSvuHjRTfknYKDbMAM.pivot;
			Vector2 sizeDelta = base.KXbFLgsvCYMSvuHjRTfknYKDbMAM.sizeDelta;
			Vector3 localScale = base.KXbFLgsvCYMSvuHjRTfknYKDbMAM.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			WuuUpLofnuDwZhrrpAihCwLtvFJg(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void WuuUpLofnuDwZhrrpAihCwLtvFJg(Vector2 P_0, PositionType P_1, bool P_2, float P_3, beybCbmzNPVQsbcvobtcSqOzXSMr P_4)
		{
			if (IjTqkfTYhITHYNkoiEyFGjlcOfaEA && P_2 && kkBCpyBbGVrItoIhvUKfofFXLRFcA == P_4)
			{
				return;
			}
			if (IjTqkfTYhITHYNkoiEyFGjlcOfaEA && FOEDySJrCTsxsvvfYjzeSCMmMMZL != null)
			{
				sLZQNGeNuNMOYHPkXKCImcnIxPHI();
				IjTqkfTYhITHYNkoiEyFGjlcOfaEA = false;
				kkBCpyBbGVrItoIhvUKfofFXLRFcA = beybCbmzNPVQsbcvobtcSqOzXSMr.None;
			}
			if (base.krwSPbnrBGEzhAtvrnWbhxuaaPWOA == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.krwSPbnrBGEzhAtvrnWbhxuaaPWOA.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.fgIqcgpLYsnGBSCwzxuZaMteMDDO;
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
				FOEDySJrCTsxsvvfYjzeSCMmMMZL = thbWYzbhMTITzGrNMwFjTNbEKMYb(P_0, P_1, P_3, P_4);
				StartCoroutine(FOEDySJrCTsxsvvfYjzeSCMmMMZL);
				kkBCpyBbGVrItoIhvUKfofFXLRFcA = P_4;
				kTYvwSpNEvQYbqsXYKxHTAxdTCxT = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				nBtEZhtzxlJeiHWenkylcxJZKTkA(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(bsouifPBcOwVHGafhfDjYtnYVVgh))]
		private IEnumerator thbWYzbhMTITzGrNMwFjTNbEKMYb(Vector2 P_0, PositionType P_1, float P_2, beybCbmzNPVQsbcvobtcSqOzXSMr P_3)
		{
			return new bsouifPBcOwVHGafhfDjYtnYVVgh(0)
			{
				TLbwztTOXeWfLHXFdymbpBnIdjbo = this,
				NTFtsaeKxrcWLCrsBHqZvcoJpfDCb = P_0,
				JcmTrGUFnyWdabOyVBAVqrlPwJAy = P_1,
				QWMKvXhilrwihTduYfNnHfYdHXFtA = P_2,
				aUfzSskwbvLujIEorSKyfoNLnWxd = P_3
			};
		}

		private void nBtEZhtzxlJeiHWenkylcxJZKTkA(beybCbmzNPVQsbcvobtcSqOzXSMr P_0, Vector2 P_1, PositionType P_2)
		{
			DqaChzdTZYNFWhBQIpZWKgtwfiCfA.BsdJYCzGuBKzUbylUTSvUyoLgxek(base.KXbFLgsvCYMSvuHjRTfknYKDbMAM, P_1, P_2);
			IjTqkfTYhITHYNkoiEyFGjlcOfaEA = false;
			kkBCpyBbGVrItoIhvUKfofFXLRFcA = beybCbmzNPVQsbcvobtcSqOzXSMr.None;
			switch (P_0)
			{
			case beybCbmzNPVQsbcvobtcSqOzXSMr.TowardHome:
				kTYvwSpNEvQYbqsXYKxHTAxdTCxT = false;
				break;
			case beybCbmzNPVQsbcvobtcSqOzXSMr.TowardTouch:
				kTYvwSpNEvQYbqsXYKxHTAxdTCxT = true;
				break;
			}
			sLZQNGeNuNMOYHPkXKCImcnIxPHI();
			moveEndedDelegate(P_0);
		}

		private void MvxlCnYfQLYLZfSxigAFDNFJXEgi(beybCbmzNPVQsbcvobtcSqOzXSMr P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == beybCbmzNPVQsbcvobtcSqOzXSMr.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					zFJqlnMOQReWSHfBBVwrHPhabjJO.ewYNmyWCNHNCHmZClXtNQtKxUcEK(base.transform, flag2);
				}
			}
		}

		private void MoUCdjWKmQqUlEsQuqQxQoQvkcAS(beybCbmzNPVQsbcvobtcSqOzXSMr P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == beybCbmzNPVQsbcvobtcSqOzXSMr.TowardHome)
				{
					flag = true;
					flag2 = FKXFydERdmPjhmVMoBEdksNDGNjt();
				}
				if (flag)
				{
					zFJqlnMOQReWSHfBBVwrHPhabjJO.ewYNmyWCNHNCHmZClXtNQtKxUcEK(base.transform, flag2);
				}
			}
		}

		private void wfPAyHEInQgQHGMFLwbWNGKFatcg(int P_0)
		{
			if (TouchInteractable.ZYwGYYdmSzHakANXcUYVgtqvzOUJ(P_0))
			{
				htvpEqVswlpwkfKZamuCmfLAyNxv(TouchInteractable.SlvklMDRFubBrxxwogKeezCPTKAI(P_0), false, 0f, beybCbmzNPVQsbcvobtcSqOzXSMr.TowardTouch);
			}
		}

		private void sLZQNGeNuNMOYHPkXKCImcnIxPHI()
		{
			if (FOEDySJrCTsxsvvfYjzeSCMmMMZL != null)
			{
				try
				{
					StopCoroutine(FOEDySJrCTsxsvvfYjzeSCMmMMZL);
				}
				catch
				{
				}
				FOEDySJrCTsxsvvfYjzeSCMmMMZL = null;
			}
		}

		private void FplJNCGwlunmWKDOSjxeDdgyHgRyA()
		{
			if (hasPointer && !TouchInteractable.ZYwGYYdmSzHakANXcUYVgtqvzOUJ(effectivePointerId))
			{
				PointerEventData pointerEventData = xYvOFBclUjxAAyvEcSbpGZKfRWIp(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					YiveccBAJZGhNdlyFtXtJrxyAhqlA(pointerEventData);
				}
				else
				{
					GodAsYhdZpkcWGZCvUczAyenFUZHA();
				}
			}
		}

		private bool FfYKKymhcFmslDeBKSfTlSmcsxdt()
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

		private void RFamdWLYZCdRREnwMaRFZaWLbrrv()
		{
			biDoHIshjqUpkghDeaRIILEwTBFS = int.MinValue;
			IPFLQCdbpZADtdGVkUZwiygQQyQPA = int.MinValue;
		}

		private bool AbdVayfdExrEOgJRxGHCXxZQMAfY(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (biDoHIshjqUpkghDeaRIILEwTBFS == int.MinValue)
			{
				return false;
			}
			if (biDoHIshjqUpkghDeaRIILEwTBFS == P_0)
			{
				return true;
			}
			if (TouchInteractable.zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0) && IPFLQCdbpZADtdGVkUZwiygQQyQPA != int.MinValue && P_0 == IPFLQCdbpZADtdGVkUZwiygQQyQPA)
			{
				return true;
			}
			return false;
		}

		private PointerEventData BAaSxvxLPcvDHmCxDBaVIaFpgVdR(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = xYvOFBclUjxAAyvEcSbpGZKfRWIp(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.SlvklMDRFubBrxxwogKeezCPTKAI(P_0);
			if (TouchInteractable.YOjWGKtwerAoiAXAEISfxlNHfJJw(P_0))
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
				if (!TouchInteractable.zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0))
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

		private PointerEventData GxWEqiDDCmFEoJCvMaezGPQTizAQA(int P_0)
		{
			PointerEventData pointerEventData = xYvOFBclUjxAAyvEcSbpGZKfRWIp(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.YOjWGKtwerAoiAXAEISfxlNHfJJw(P_0))
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
				if (!TouchInteractable.zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0))
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

		private void YiveccBAJZGhNdlyFtXtJrxyAhqlA(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				GxWEqiDDCmFEoJCvMaezGPQTizAQA(effectivePointerId);
			}
		}

		private PointerEventData xYvOFBclUjxAAyvEcSbpGZKfRWIp(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (joTPeudNYvtshmPBhwXpApOoaSSA == null)
			{
				joTPeudNYvtshmPBhwXpApOoaSSA = new Dictionary<int, PointerEventData>();
			}
			if (!joTPeudNYvtshmPBhwXpApOoaSSA.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				joTPeudNYvtshmPBhwXpApOoaSSA.Add(P_0, value);
				if (TouchInteractable.zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0))
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

		private void DdYWQwMAJfCporACfBUsPvBDQrbI(PointerEventData P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac P_1)
		{
			if (!hasPointer || AbdVayfdExrEOgJRxGHCXxZQMAfY(P_0.pointerId))
			{
				if (DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable())
				{
					tQYFqowCSPIJrqMezqwGyCgHyqhT(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void UnktDOIxSViSTJakieOrELEjOscSA(PointerEventData P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac P_1)
		{
			if ((!hasPointer || AbdVayfdExrEOgJRxGHCXxZQMAfY(P_0.pointerId)) && !TouchInteractable.ZYwGYYdmSzHakANXcUYVgtqvzOUJ(effectivePointerId))
			{
				GodAsYhdZpkcWGZCvUczAyenFUZHA();
				base.OnPointerUp(P_0);
			}
		}

		private void qIcaoPxwPuacfIRMaHcfcMNKzygYb(PointerEventData P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac P_1)
		{
			if (hasPointer && !AbdVayfdExrEOgJRxGHCXxZQMAfY(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				hzyGbphuGSabeAyvbdCVeWtEqiMac.Local => base.allowedMouseButtons, 
				hzyGbphuGSabeAyvbdCVeWtEqiMac.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && (!flag || TouchInteractable.bvaavvcdoRyDQyElLKVutjdctzVO(mouseButtonFlags)) && !MDxbeUBimaNWYMDiXlAyoITZZaiK)
			{
				if (flag)
				{
					if (TouchInteractable.wosOqXdFSlBXaFBgRvyXXgngpsXH(mouseButtonFlags, out var iPFLQCdbpZADtdGVkUZwiygQQyQPA))
					{
						IPFLQCdbpZADtdGVkUZwiygQQyQPA = iPFLQCdbpZADtdGVkUZwiygQQyQPA;
					}
					else
					{
						IPFLQCdbpZADtdGVkUZwiygQQyQPA = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					hzyGbphuGSabeAyvbdCVeWtEqiMac.Local => base.gameObject, 
					hzyGbphuGSabeAyvbdCVeWtEqiMac.TouchRegion => FsqNNWBOmzvzCwfpnOGIHeEdgRMU.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = BAaSxvxLPcvDHmCxDBaVIaFpgVdR((IPFLQCdbpZADtdGVkUZwiygQQyQPA != int.MinValue) ? IPFLQCdbpZADtdGVkUZwiygQQyQPA : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					DdYWQwMAJfCporACfBUsPvBDQrbI(pointerEventData, P_1);
				}
			}
			cIeENuGXuRuqkGvzliwxduIgLHSMA = true;
		}

		private void rWldYPtKwFcIFNBiXgEHBlvKypmY(PointerEventData P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac P_1)
		{
			if (hasPointer && !AbdVayfdExrEOgJRxGHCXxZQMAfY(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && MDxbeUBimaNWYMDiXlAyoITZZaiK)
			{
				GodAsYhdZpkcWGZCvUczAyenFUZHA();
			}
			base.OnPointerExit(P_0);
			cIeENuGXuRuqkGvzliwxduIgLHSMA = false;
		}

		private void tQYFqowCSPIJrqMezqwGyCgHyqhT(int P_0, Vector2 P_1, hzyGbphuGSabeAyvbdCVeWtEqiMac P_2)
		{
			biDoHIshjqUpkghDeaRIILEwTBFS = P_0;
			MDxbeUBimaNWYMDiXlAyoITZZaiK = true;
			if (_followTouchPosition)
			{
				wfPAyHEInQgQHGMFLwbWNGKFatcg(P_0);
			}
			else if (P_2 == hzyGbphuGSabeAyvbdCVeWtEqiMac.TouchRegion && _moveToTouchPosition)
			{
				htvpEqVswlpwkfKZamuCmfLAyNxv(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, beybCbmzNPVQsbcvobtcSqOzXSMr.TowardTouch);
			}
			dWVQGSMITjPNNumEfVfrMrcmFuuI();
		}

		private void GodAsYhdZpkcWGZCvUczAyenFUZHA()
		{
			RFamdWLYZCdRREnwMaRFZaWLbrrv();
			MDxbeUBimaNWYMDiXlAyoITZZaiK = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && kTYvwSpNEvQYbqsXYKxHTAxdTCxT)
			{
				ReturnToDefaultPosition();
			}
			XvDMxqpyvvOGDepZiWVYbpyaTLAw();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null) || !_useTouchRegionOnly))
			{
				DdYWQwMAJfCporACfBUsPvBDQrbI(eventData, hzyGbphuGSabeAyvbdCVeWtEqiMac.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null) || !_useTouchRegionOnly))
			{
				UnktDOIxSViSTJakieOrELEjOscSA(eventData, hzyGbphuGSabeAyvbdCVeWtEqiMac.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null) || !_useTouchRegionOnly))
			{
				qIcaoPxwPuacfIRMaHcfcMNKzygYb(eventData, hzyGbphuGSabeAyvbdCVeWtEqiMac.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(FsqNNWBOmzvzCwfpnOGIHeEdgRMU != null) || !_useTouchRegionOnly))
			{
				rWldYPtKwFcIFNBiXgEHBlvKypmY(eventData, hzyGbphuGSabeAyvbdCVeWtEqiMac.Local);
			}
		}

		private void JXvJWZKfBiFCQTwsWobEEAnDHCeF(PointerEventData P_0)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				DdYWQwMAJfCporACfBUsPvBDQrbI(P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac.TouchRegion);
			}
		}

		private void tmWliuZZARiVBbQNxBNtpogKYJxO(PointerEventData P_0)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				UnktDOIxSViSTJakieOrELEjOscSA(P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac.TouchRegion);
			}
		}

		private void MuKOQeMmCzGlAdrzLCJZXzLpkGJUA(PointerEventData P_0)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				qIcaoPxwPuacfIRMaHcfcMNKzygYb(P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac.TouchRegion);
			}
		}

		private void cObGkOnwCrReRbhAPpwGmhhCwQzb(PointerEventData P_0)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				rWldYPtKwFcIFNBiXgEHBlvKypmY(P_0, hzyGbphuGSabeAyvbdCVeWtEqiMac.TouchRegion);
			}
		}

		private void tCRFQmtWShSHZTpAWrrSuWgMlEaO(float P_0)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && !_useDigitalAxisSimulation)
			{
				qTbQveApfHOMSehJBxKYMzaVLcgX(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void hqOouzPlVhUsyvurYBhWBsXBARfX(bool P_0)
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				qTbQveApfHOMSehJBxKYMzaVLcgX(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void EgVwBBpOtvhGriGEHCpjPpgNbPcE()
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				qTbQveApfHOMSehJBxKYMzaVLcgX(null);
				_onButtonDown.Invoke();
			}
		}

		private void sEWqrXotkVHsxCrVQDQHTMgXFUSDA()
		{
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ)
			{
				qTbQveApfHOMSehJBxKYMzaVLcgX(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
