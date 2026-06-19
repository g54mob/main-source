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
	[AddComponentMenu("Rewired/Touch Controls/Touch Button")]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum dGdpPQRPsAEdjFoYSiXxawbSMBnXA
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum djzopKKzNVFdfdFAFaQOsAQZAltn
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

		private sealed class dSrdfQdmZHMQWOZQLLDoSyCltITRA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int tIWgpaeNPgvReDkZJVSRSSZGjIAq;

			private object DdnFwJInsyanLXlzYHNvcFjmBcwCA;

			public float QJPizkYgKwWXgCfJujOwHYnCGfqK;

			public TouchButton LUiDvGiCwzZmKSOkPICgNOKtjsQEA;

			public PositionType XFrmFlpBGfbVlodPfPiIGkGqbUxdA;

			public Vector2 ZHYbGRPAhkehKyHwzUVQOJVounmC;

			public dGdpPQRPsAEdjFoYSiXxawbSMBnXA mIgfmTFRJkgdsTRbVgyfNZBeHgIoA;

			private RectTransform FbtpiLQHkgnXsHgxeudqSgRXDnon;

			private Vector2 nLrCKpgjMbwvrfxqKDvcBJqQeQMJA;

			private float BhECLuALxKnURiIeQJzsWEGiZFfNA;

			private float UpTYqfTWfbChsKJZDNlhxvRCFAFo;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return DdnFwJInsyanLXlzYHNvcFjmBcwCA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DdnFwJInsyanLXlzYHNvcFjmBcwCA;
				}
			}

			[DebuggerHidden]
			public dSrdfQdmZHMQWOZQLLDoSyCltITRA(int P_0)
			{
				tIWgpaeNPgvReDkZJVSRSSZGjIAq = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				FbtpiLQHkgnXsHgxeudqSgRXDnon = null;
				tIWgpaeNPgvReDkZJVSRSSZGjIAq = -2;
			}

			private bool MoveNext()
			{
				int num = tIWgpaeNPgvReDkZJVSRSSZGjIAq;
				TouchButton lUiDvGiCwzZmKSOkPICgNOKtjsQEA = LUiDvGiCwzZmKSOkPICgNOKtjsQEA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					tIWgpaeNPgvReDkZJVSRSSZGjIAq = -1;
					goto IL_010c;
				}
				tIWgpaeNPgvReDkZJVSRSSZGjIAq = -1;
				if (!(QJPizkYgKwWXgCfJujOwHYnCGfqK <= 0f))
				{
					FbtpiLQHkgnXsHgxeudqSgRXDnon = lUiDvGiCwzZmKSOkPICgNOKtjsQEA.WDuGVHNrhJsWydsOjFkhLWpgTdjk;
					nLrCKpgjMbwvrfxqKDvcBJqQeQMJA = JPvwdModsFtwLYKhejFPycAZezzl.KfHhADhJZplBqVfiMBxieCzKTSlj(FbtpiLQHkgnXsHgxeudqSgRXDnon, XFrmFlpBGfbVlodPfPiIGkGqbUxdA);
					float magnitude = (ZHYbGRPAhkehKyHwzUVQOJVounmC - nLrCKpgjMbwvrfxqKDvcBJqQeQMJA).magnitude;
					if (!(magnitude < 0.01f))
					{
						lUiDvGiCwzZmKSOkPICgNOKtjsQEA.WYStMIghAHtWXMyTUEMEXGULyvHK = true;
						BhECLuALxKnURiIeQJzsWEGiZFfNA = magnitude / QJPizkYgKwWXgCfJujOwHYnCGfqK;
						UpTYqfTWfbChsKJZDNlhxvRCFAFo = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				lUiDvGiCwzZmKSOkPICgNOKtjsQEA.pUGyVoCyQoIflUkfSDClHCMwPVacb(mIgfmTFRJkgdsTRbVgyfNZBeHgIoA, ZHYbGRPAhkehKyHwzUVQOJVounmC, XFrmFlpBGfbVlodPfPiIGkGqbUxdA);
				return false;
				IL_010c:
				if (UpTYqfTWfbChsKJZDNlhxvRCFAFo <= 1f)
				{
					UpTYqfTWfbChsKJZDNlhxvRCFAFo += Time.unscaledDeltaTime / BhECLuALxKnURiIeQJzsWEGiZFfNA;
					JPvwdModsFtwLYKhejFPycAZezzl.DOgPhbEoPINwRutQwmHqcxNubIRH(FbtpiLQHkgnXsHgxeudqSgRXDnon, Vector2.Lerp(nLrCKpgjMbwvrfxqKDvcBJqQeQMJA, ZHYbGRPAhkehKyHwzUVQOJVounmC, Mathf.SmoothStep(0f, 1f, UpTYqfTWfbChsKJZDNlhxvRCFAFo)), XFrmFlpBGfbVlodPfPiIGkGqbUxdA);
					DdnFwJInsyanLXlzYHNvcFjmBcwCA = null;
					tIWgpaeNPgvReDkZJVSRSSZGjIAq = 1;
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

		private const float stUYEwAKEcdkxAjHIdghWoFMngGj = 20f;

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

		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
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

		private float aRDdvWnCCmRFLYmPThCFOrbvwqnf;

		private float jXAaAJZZGjrpsLNrLTwtRAqWYPPN;

		private TouchRegion ZorgOfqrJmwLJrSOThoNfgbUlEhP;

		private Vector2 NIKAQJgFwPgFtJCOJylCDjgnCYVEb;

		private bool WYStMIghAHtWXMyTUEMEXGULyvHK;

		private bool ukXbzWIlRoesSlalkZUBhKiITgUC;

		private dGdpPQRPsAEdjFoYSiXxawbSMBnXA aVUeDNAkhEkIuBuMReQoNioiYDmK;

		private int dCCFlpDFGtyifjbuWJzVypbNYMwX = int.MinValue;

		private int CqWCFhYkCUjtiJMaGBtvYzVpCpfy = int.MinValue;

		[NonSerialized]
		private bool UGwEcdqVHbJxRRQBfeBpESioyKLVA;

		[NonSerialized]
		private bool aczEnNekJYEYrkvOLEtgGErFUyrJ;

		private IEnumerator FPXrzduRjIYYhwSCkDRtktlJDdgJ;

		private FXeWxvuoejNrJnpUgQhgaqksVhEA jEKaaKpIpYYeTUNkvKMubTGPuuet = new FXeWxvuoejNrJnpUgQhgaqksVhEA();

		private Action<dGdpPQRPsAEdjFoYSiXxawbSMBnXA> SBRBuoKXZlFvKdKbCWrexwkabjmF;

		private Action<dGdpPQRPsAEdjFoYSiXxawbSMBnXA> IGqjEqipqdgFabIrffcDdRohtkUMb;

		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> xprXCBWlcJBBnnVuzlICcKSzvtxm;

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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (DAPELBPeDQTYaOpuafPOHqTHAkGN())
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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
						HsqdddXFClaEjYiHvwoSOIdyPLoX();
					}
					else
					{
						jEKaaKpIpYYeTUNkvKMubTGPuuet.BqVxZaiQDoOWbRDQwEhcmklEDJnq();
					}
					YmRcFnSGPDloZzprndIQeqXQHaodA();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return dCCFlpDFGtyifjbuWJzVypbNYMwX;
			}
			set
			{
				dCCFlpDFGtyifjbuWJzVypbNYMwX = value;
			}
		}

		public bool hasPointer => dCCFlpDFGtyifjbuWJzVypbNYMwX != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<dGdpPQRPsAEdjFoYSiXxawbSMBnXA> moveStartedDelegate
		{
			get
			{
				if (SBRBuoKXZlFvKdKbCWrexwkabjmF == null)
				{
					return SBRBuoKXZlFvKdKbCWrexwkabjmF = UkycoQIbpOKgAJmGOoEUfrqyqQVyA;
				}
				return SBRBuoKXZlFvKdKbCWrexwkabjmF;
			}
		}

		private Action<dGdpPQRPsAEdjFoYSiXxawbSMBnXA> moveEndedDelegate
		{
			get
			{
				if (IGqjEqipqdgFabIrffcDdRohtkUMb == null)
				{
					return IGqjEqipqdgFabIrffcDdRohtkUMb = QwZloIheRPzawZzzIrggaElGcnjkA;
				}
				return IGqjEqipqdgFabIrffcDdRohtkUMb;
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
				return aRDdvWnCCmRFLYmPThCFOrbvwqnf;
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
				return jXAaAJZZGjrpsLNrLTwtRAqWYPPN;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (dCCFlpDFGtyifjbuWJzVypbNYMwX == int.MinValue)
				{
					return int.MinValue;
				}
				if (CqWCFhYkCUjtiJMaGBtvYzVpCpfy != int.MinValue)
				{
					return CqWCFhYkCUjtiJMaGBtvYzVpCpfy;
				}
				return dCCFlpDFGtyifjbuWJzVypbNYMwX;
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
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			vQZBBvxDrOlkwJKRzrZPtkalZCTB(base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.anchoredPosition);
		}

		private void vQZBBvxDrOlkwJKRzrZPtkalZCTB(Vector2 P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				NIKAQJgFwPgFtJCOJylCDjgnCYVEb = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				KqvGLoDuOvznUclERyqowzLKiaco(NIKAQJgFwPgFtJCOJylCDjgnCYVEb, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, dGdpPQRPsAEdjFoYSiXxawbSMBnXA.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
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
				NIKAQJgFwPgFtJCOJylCDjgnCYVEb = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				xrEjCzCAzQGOIAVmNzaaBOCtsPbDb();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				tKEdjOKSEgjEZYzXhFqUMeyYYOhKA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				xrEjCzCAzQGOIAVmNzaaBOCtsPbDb();
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
			base.ZadSFFqddMfzbdzzllVuUFOpUuig();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				DMqAUnzeKtIqNDBvuGJjDpRNezuR();
				xUVtFDGaSTLCkkGYSMcLfdZJFCBo();
				iTIzMJLOHAxckQfErAKiZKMIGgkt();
				if (_followTouchPosition)
				{
					qXODXeFfbReWIlVnxNWFyfzmAlRab(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!iFndMIDWDcaooyXvhIvZUIepHxsJ())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && lHrmyZFsaDtMgFwuiNoBbdveNATp)
			{
				RBVJiriJzxhTlbkVFcwgUMluaNDw(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			NNwwjaQfacauaRboVLZYHgLEFIBU();
			_axis.AxisValueChangedEvent += lHWLFNYObwfhQSjfobJNYdJbSRNt;
			_axis.ButtonValueChangedEvent += bULArKixyobYtypYsdXDdmqisEOS;
			_axis.ButtonDownEvent += WCWWvsEnfoNTepvzzFqidVWeEsDr;
			_axis.ButtonUpEvent += kFVakmPJVEvEoXyciHiUlhHmMLbM;
		}

		internal void OnUnsubscribeEvents()
		{
			wECbfKDjTyxXZaslOArXZDpDLMTJA();
			_axis.AxisValueChangedEvent -= lHWLFNYObwfhQSjfobJNYdJbSRNt;
			_axis.ButtonValueChangedEvent -= bULArKixyobYtypYsdXDdmqisEOS;
			_axis.ButtonDownEvent -= WCWWvsEnfoNTepvzzFqidVWeEsDr;
			_axis.ButtonUpEvent -= kFVakmPJVEvEoXyciHiUlhHmMLbM;
		}

		internal void OnSetProperty()
		{
			MkeUcSwhoilMoVoCdyXQYIOXhQJu();
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				xrEjCzCAzQGOIAVmNzaaBOCtsPbDb();
			}
		}

		internal void OnClear()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				dCCFlpDFGtyifjbuWJzVypbNYMwX = int.MinValue;
				CqWCFhYkCUjtiJMaGBtvYzVpCpfy = int.MinValue;
				UGwEcdqVHbJxRRQBfeBpESioyKLVA = false;
				aczEnNekJYEYrkvOLEtgGErFUyrJ = false;
				if (_returnOnRelease && ukXbzWIlRoesSlalkZUBhKiITgUC && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				ukXbzWIlRoesSlalkZUBhKiITgUC = false;
				WYStMIghAHtWXMyTUEMEXGULyvHK = false;
				aVUeDNAkhEkIuBuMReQoNioiYDmK = dGdpPQRPsAEdjFoYSiXxawbSMBnXA.None;
				msYgLvHRPWQeXCoofNiFSdKjZewv();
				_axis.Clear();
				aRDdvWnCCmRFLYmPThCFOrbvwqnf = 0f;
				jXAaAJZZGjrpsLNrLTwtRAqWYPPN = 0f;
				xrEjCzCAzQGOIAVmNzaaBOCtsPbDb();
			}
		}

		public override void ClearValue()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				_axis.Clear();
				aRDdvWnCCmRFLYmPThCFOrbvwqnf = 0f;
				if (lHrmyZFsaDtMgFwuiNoBbdveNATp)
				{
					base.NOHjKMqVvRxqcULJVMYRwUmUvaPl.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				return false;
			}
			if (!FBTWPzcXpWlDMTGvkvxpkZYxUkml())
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
			if (base.hFzAHiRfaqYGcaauuljcWQStfGUP(gameObject))
			{
				return true;
			}
			if (ZorgOfqrJmwLJrSOThoNfgbUlEhP != null)
			{
				return ZorgOfqrJmwLJrSOThoNfgbUlEhP.gameObject == gameObject;
			}
			return false;
		}

		private void iTIzMJLOHAxckQfErAKiZKMIGgkt()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					pONgaIJOZCFbibyExpzxxHAHVWubA();
				}
				else
				{
					yuQmYChZTtDBZhNvUagVCMFIhodIA();
				}
			}
		}

		private void pONgaIJOZCFbibyExpzxxHAHVWubA()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += aRDdvWnCCmRFLYmPThCFOrbvwqnf;
			num = MathTools.Clamp(num, -1f, 1f);
			VPnCDQEYJqcXpyTQmQRpqaEMwwDgA(num, true);
		}

		private void yuQmYChZTtDBZhNvUagVCMFIhodIA()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num2 = aRDdvWnCCmRFLYmPThCFOrbvwqnf;
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
				VPnCDQEYJqcXpyTQmQRpqaEMwwDgA(num4, true);
			}
		}

		private void VPnCDQEYJqcXpyTQmQRpqaEMwwDgA(float P_0, bool P_1)
		{
			jXAaAJZZGjrpsLNrLTwtRAqWYPPN = aRDdvWnCCmRFLYmPThCFOrbvwqnf;
			aRDdvWnCCmRFLYmPThCFOrbvwqnf = P_0;
			if (P_0 != jXAaAJZZGjrpsLNrLTwtRAqWYPPN)
			{
				qQaapJpxQGaLHbgcrjcVeTFoGrXq(null);
			}
			if (P_1 && P_0 != jXAaAJZZGjrpsLNrLTwtRAqWYPPN)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void dLWCRvfvoqypKxPbJDzcyWZHGHZl()
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

		private void NMAByXMfYihoQdLyCmnVZJFNeYlo()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void xrEjCzCAzQGOIAVmNzaaBOCtsPbDb()
		{
			_targetCustomControllerElement.ClearElementCaches();
			xUVtFDGaSTLCkkGYSMcLfdZJFCBo();
			HsqdddXFClaEjYiHvwoSOIdyPLoX();
		}

		private void HsqdddXFClaEjYiHvwoSOIdyPLoX()
		{
			if (_manageRaycasting)
			{
				jEKaaKpIpYYeTUNkvKMubTGPuuet.yoHcYTHfsAHxQAbnJqlQwudSzNtU(base.transform, DwUlXCjlSrBFadcvYdmqEjiclAMO());
			}
		}

		private bool DwUlXCjlSrBFadcvYdmqEjiclAMO()
		{
			if (ZorgOfqrJmwLJrSOThoNfgbUlEhP != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void goOfrHRUatPAnuAztgMFBgGYstkdA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				xUfDoCRwsZADgaeQzvTBREbTBJdbb(P_0);
				P_0.PointerDownEvent += ZMudAoavUnmnJwARoNSZCaxDiYTBB;
				P_0.PointerUpEvent += rVPCnRyqhGlhKofsHPxqDALzTUCu;
				P_0.PointerEnterEvent += SNNJrVfZfyHHHufEvpPMPFqOFZio;
				P_0.PointerExitEvent += goXYLFSINDOvjsgOiHDncQQrdpjVA;
			}
		}

		private void xUfDoCRwsZADgaeQzvTBREbTBJdbb(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= ZMudAoavUnmnJwARoNSZCaxDiYTBB;
				P_0.PointerUpEvent -= rVPCnRyqhGlhKofsHPxqDALzTUCu;
				P_0.PointerEnterEvent -= SNNJrVfZfyHHHufEvpPMPFqOFZio;
				P_0.PointerExitEvent -= goXYLFSINDOvjsgOiHDncQQrdpjVA;
			}
		}

		private void xUVtFDGaSTLCkkGYSMcLfdZJFCBo()
		{
			if (!(ZorgOfqrJmwLJrSOThoNfgbUlEhP == _touchRegion))
			{
				xUfDoCRwsZADgaeQzvTBREbTBJdbb(ZorgOfqrJmwLJrSOThoNfgbUlEhP);
				ZorgOfqrJmwLJrSOThoNfgbUlEhP = _touchRegion;
				goOfrHRUatPAnuAztgMFBgGYstkdA(ZorgOfqrJmwLJrSOThoNfgbUlEhP);
			}
		}

		private void fMwDuVseXsGOxiLyGWEZEZkbEAAq(Vector2 P_0, bool P_1, float P_2, dGdpPQRPsAEdjFoYSiXxawbSMBnXA P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = JPvwdModsFtwLYKhejFPycAZezzl.PtKBIMkQruMMZudiZKbNzXIzOvEG(base.wprEGQGwAFDVwiYwZymvFLeLIFvD, rectTransform, P_0);
			Vector2 pivot = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.pivot;
			Vector2 sizeDelta = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.sizeDelta;
			Vector3 localScale = base.WDuGVHNrhJsWydsOjFkhLWpgTdjk.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			KqvGLoDuOvznUclERyqowzLKiaco(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void KqvGLoDuOvznUclERyqowzLKiaco(Vector2 P_0, PositionType P_1, bool P_2, float P_3, dGdpPQRPsAEdjFoYSiXxawbSMBnXA P_4)
		{
			if (WYStMIghAHtWXMyTUEMEXGULyvHK && P_2 && aVUeDNAkhEkIuBuMReQoNioiYDmK == P_4)
			{
				return;
			}
			if (WYStMIghAHtWXMyTUEMEXGULyvHK && FPXrzduRjIYYhwSCkDRtktlJDdgJ != null)
			{
				msYgLvHRPWQeXCoofNiFSdKjZewv();
				WYStMIghAHtWXMyTUEMEXGULyvHK = false;
				aVUeDNAkhEkIuBuMReQoNioiYDmK = dGdpPQRPsAEdjFoYSiXxawbSMBnXA.None;
			}
			if (base.wprEGQGwAFDVwiYwZymvFLeLIFvD == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.wprEGQGwAFDVwiYwZymvFLeLIFvD.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.fxNbNJQIjpDsOBtBDMMUUhQBfOst;
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
				FPXrzduRjIYYhwSCkDRtktlJDdgJ = nBeXHrWOAMleANMKoaMEvLextHvw(P_0, P_1, P_3, P_4);
				StartCoroutine(FPXrzduRjIYYhwSCkDRtktlJDdgJ);
				aVUeDNAkhEkIuBuMReQoNioiYDmK = P_4;
				ukXbzWIlRoesSlalkZUBhKiITgUC = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				pUGyVoCyQoIflUkfSDClHCMwPVacb(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(dSrdfQdmZHMQWOZQLLDoSyCltITRA))]
		private IEnumerator nBeXHrWOAMleANMKoaMEvLextHvw(Vector2 P_0, PositionType P_1, float P_2, dGdpPQRPsAEdjFoYSiXxawbSMBnXA P_3)
		{
			return new dSrdfQdmZHMQWOZQLLDoSyCltITRA(0)
			{
				LUiDvGiCwzZmKSOkPICgNOKtjsQEA = this,
				ZHYbGRPAhkehKyHwzUVQOJVounmC = P_0,
				XFrmFlpBGfbVlodPfPiIGkGqbUxdA = P_1,
				QJPizkYgKwWXgCfJujOwHYnCGfqK = P_2,
				mIgfmTFRJkgdsTRbVgyfNZBeHgIoA = P_3
			};
		}

		private void pUGyVoCyQoIflUkfSDClHCMwPVacb(dGdpPQRPsAEdjFoYSiXxawbSMBnXA P_0, Vector2 P_1, PositionType P_2)
		{
			JPvwdModsFtwLYKhejFPycAZezzl.DOgPhbEoPINwRutQwmHqcxNubIRH(base.WDuGVHNrhJsWydsOjFkhLWpgTdjk, P_1, P_2);
			WYStMIghAHtWXMyTUEMEXGULyvHK = false;
			aVUeDNAkhEkIuBuMReQoNioiYDmK = dGdpPQRPsAEdjFoYSiXxawbSMBnXA.None;
			switch (P_0)
			{
			case dGdpPQRPsAEdjFoYSiXxawbSMBnXA.TowardHome:
				ukXbzWIlRoesSlalkZUBhKiITgUC = false;
				break;
			case dGdpPQRPsAEdjFoYSiXxawbSMBnXA.TowardTouch:
				ukXbzWIlRoesSlalkZUBhKiITgUC = true;
				break;
			}
			msYgLvHRPWQeXCoofNiFSdKjZewv();
			moveEndedDelegate(P_0);
		}

		private void UkycoQIbpOKgAJmGOoEUfrqyqQVyA(dGdpPQRPsAEdjFoYSiXxawbSMBnXA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && ZorgOfqrJmwLJrSOThoNfgbUlEhP != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == dGdpPQRPsAEdjFoYSiXxawbSMBnXA.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					jEKaaKpIpYYeTUNkvKMubTGPuuet.yoHcYTHfsAHxQAbnJqlQwudSzNtU(base.transform, flag2);
				}
			}
		}

		private void QwZloIheRPzawZzzIrggaElGcnjkA(dGdpPQRPsAEdjFoYSiXxawbSMBnXA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && ZorgOfqrJmwLJrSOThoNfgbUlEhP != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == dGdpPQRPsAEdjFoYSiXxawbSMBnXA.TowardHome)
				{
					flag = true;
					flag2 = DwUlXCjlSrBFadcvYdmqEjiclAMO();
				}
				if (flag)
				{
					jEKaaKpIpYYeTUNkvKMubTGPuuet.yoHcYTHfsAHxQAbnJqlQwudSzNtU(base.transform, flag2);
				}
			}
		}

		private void qXODXeFfbReWIlVnxNWFyfzmAlRab(int P_0)
		{
			if (TouchInteractable.LffDJhSOdmwbrPooQjeWBIBCzwpSA(P_0))
			{
				fMwDuVseXsGOxiLyGWEZEZkbEAAq(TouchInteractable.SqasatmOsdxOkmDVAAKlQOxsGWtR(P_0), false, 0f, dGdpPQRPsAEdjFoYSiXxawbSMBnXA.TowardTouch);
			}
		}

		private void msYgLvHRPWQeXCoofNiFSdKjZewv()
		{
			if (FPXrzduRjIYYhwSCkDRtktlJDdgJ != null)
			{
				try
				{
					StopCoroutine(FPXrzduRjIYYhwSCkDRtktlJDdgJ);
				}
				catch
				{
				}
				FPXrzduRjIYYhwSCkDRtktlJDdgJ = null;
			}
		}

		private void DMqAUnzeKtIqNDBvuGJjDpRNezuR()
		{
			if (hasPointer && !TouchInteractable.LffDJhSOdmwbrPooQjeWBIBCzwpSA(effectivePointerId))
			{
				PointerEventData pointerEventData = jjsOQkJiloguHvafODRcaVnYyJxw(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					ItqtCJazyADXOaJDnjTkHCrNeaNC(pointerEventData);
				}
				else
				{
					AWwzQxAAsoCNVGfbVIMwQMFCLLir();
				}
			}
		}

		private bool DAPELBPeDQTYaOpuafPOHqTHAkGN()
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

		private void VZxdolsqsBfjKdDPaHWKulhucyMYA()
		{
			dCCFlpDFGtyifjbuWJzVypbNYMwX = int.MinValue;
			CqWCFhYkCUjtiJMaGBtvYzVpCpfy = int.MinValue;
		}

		private bool CFytiNUvlcccNrciVjSZlsdjVHSG(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (dCCFlpDFGtyifjbuWJzVypbNYMwX == int.MinValue)
			{
				return false;
			}
			if (dCCFlpDFGtyifjbuWJzVypbNYMwX == P_0)
			{
				return true;
			}
			if (TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0) && CqWCFhYkCUjtiJMaGBtvYzVpCpfy != int.MinValue && P_0 == CqWCFhYkCUjtiJMaGBtvYzVpCpfy)
			{
				return true;
			}
			return false;
		}

		private PointerEventData NCdgPOGOeblDUKhGvEpQGyggSAMJb(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = jjsOQkJiloguHvafODRcaVnYyJxw(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.SqasatmOsdxOkmDVAAKlQOxsGWtR(P_0);
			if (TouchInteractable.KpeFbcOXwyWnYHxiDueDNayuQkab(P_0))
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
				if (!TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0))
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

		private PointerEventData GgTQBJwktbgqnMXOkOQexuxsDqvn(int P_0)
		{
			PointerEventData pointerEventData = jjsOQkJiloguHvafODRcaVnYyJxw(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.KpeFbcOXwyWnYHxiDueDNayuQkab(P_0))
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
				if (!TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0))
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

		private void ItqtCJazyADXOaJDnjTkHCrNeaNC(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				GgTQBJwktbgqnMXOkOQexuxsDqvn(effectivePointerId);
			}
		}

		private PointerEventData jjsOQkJiloguHvafODRcaVnYyJxw(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (xprXCBWlcJBBnnVuzlICcKSzvtxm == null)
			{
				xprXCBWlcJBBnnVuzlICcKSzvtxm = new Dictionary<int, PointerEventData>();
			}
			if (!xprXCBWlcJBBnnVuzlICcKSzvtxm.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				xprXCBWlcJBBnnVuzlICcKSzvtxm.Add(P_0, value);
				if (TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0))
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

		private void LaHdVZhhiwmwjAerVjjnmziidVSXA(PointerEventData P_0, djzopKKzNVFdfdFAFaQOsAQZAltn P_1)
		{
			if (!hasPointer || CFytiNUvlcccNrciVjSZlsdjVHSG(P_0.pointerId))
			{
				if (FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable())
				{
					lTZQATDldYCjkhtJVdGVMxNahfOo(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void GVbOKxvpjIeMKERNSgbepxmQpeVC(PointerEventData P_0, djzopKKzNVFdfdFAFaQOsAQZAltn P_1)
		{
			if ((!hasPointer || CFytiNUvlcccNrciVjSZlsdjVHSG(P_0.pointerId)) && !TouchInteractable.LffDJhSOdmwbrPooQjeWBIBCzwpSA(effectivePointerId))
			{
				AWwzQxAAsoCNVGfbVIMwQMFCLLir();
				base.OnPointerUp(P_0);
			}
		}

		private void sztlQyUherWngYGdCbQogxgOovTw(PointerEventData P_0, djzopKKzNVFdfdFAFaQOsAQZAltn P_1)
		{
			if (hasPointer && !CFytiNUvlcccNrciVjSZlsdjVHSG(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.hYReOStBGAVFKUROIWtVpihIOpQq(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				djzopKKzNVFdfdFAFaQOsAQZAltn.Local => base.allowedMouseButtons, 
				djzopKKzNVFdfdFAFaQOsAQZAltn.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && (!flag || TouchInteractable.fnhAvAdZTQvKTpxAhVnpVsCPoXuk(mouseButtonFlags)) && !UGwEcdqVHbJxRRQBfeBpESioyKLVA)
			{
				if (flag)
				{
					if (TouchInteractable.ordaBaeMzsSrrhYXhoJUevCXwuyPA(mouseButtonFlags, out var cqWCFhYkCUjtiJMaGBtvYzVpCpfy))
					{
						CqWCFhYkCUjtiJMaGBtvYzVpCpfy = cqWCFhYkCUjtiJMaGBtvYzVpCpfy;
					}
					else
					{
						CqWCFhYkCUjtiJMaGBtvYzVpCpfy = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					djzopKKzNVFdfdFAFaQOsAQZAltn.Local => base.gameObject, 
					djzopKKzNVFdfdFAFaQOsAQZAltn.TouchRegion => ZorgOfqrJmwLJrSOThoNfgbUlEhP.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = NCdgPOGOeblDUKhGvEpQGyggSAMJb((CqWCFhYkCUjtiJMaGBtvYzVpCpfy != int.MinValue) ? CqWCFhYkCUjtiJMaGBtvYzVpCpfy : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					LaHdVZhhiwmwjAerVjjnmziidVSXA(pointerEventData, P_1);
				}
			}
			aczEnNekJYEYrkvOLEtgGErFUyrJ = true;
		}

		private void tloLTiSmVYFaQIQBrLqQgDIiroXZB(PointerEventData P_0, djzopKKzNVFdfdFAFaQOsAQZAltn P_1)
		{
			if (hasPointer && !CFytiNUvlcccNrciVjSZlsdjVHSG(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && UGwEcdqVHbJxRRQBfeBpESioyKLVA)
			{
				AWwzQxAAsoCNVGfbVIMwQMFCLLir();
			}
			base.OnPointerExit(P_0);
			aczEnNekJYEYrkvOLEtgGErFUyrJ = false;
		}

		private void lTZQATDldYCjkhtJVdGVMxNahfOo(int P_0, Vector2 P_1, djzopKKzNVFdfdFAFaQOsAQZAltn P_2)
		{
			dCCFlpDFGtyifjbuWJzVypbNYMwX = P_0;
			UGwEcdqVHbJxRRQBfeBpESioyKLVA = true;
			if (_followTouchPosition)
			{
				qXODXeFfbReWIlVnxNWFyfzmAlRab(P_0);
			}
			else if (P_2 == djzopKKzNVFdfdFAFaQOsAQZAltn.TouchRegion && _moveToTouchPosition)
			{
				fMwDuVseXsGOxiLyGWEZEZkbEAAq(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, dGdpPQRPsAEdjFoYSiXxawbSMBnXA.TowardTouch);
			}
			dLWCRvfvoqypKxPbJDzcyWZHGHZl();
		}

		private void AWwzQxAAsoCNVGfbVIMwQMFCLLir()
		{
			VZxdolsqsBfjKdDPaHWKulhucyMYA();
			UGwEcdqVHbJxRRQBfeBpESioyKLVA = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && ukXbzWIlRoesSlalkZUBhKiITgUC)
			{
				ReturnToDefaultPosition();
			}
			NMAByXMfYihoQdLyCmnVZJFNeYlo();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(ZorgOfqrJmwLJrSOThoNfgbUlEhP != null) || !_useTouchRegionOnly))
			{
				LaHdVZhhiwmwjAerVjjnmziidVSXA(eventData, djzopKKzNVFdfdFAFaQOsAQZAltn.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(ZorgOfqrJmwLJrSOThoNfgbUlEhP != null) || !_useTouchRegionOnly))
			{
				GVbOKxvpjIeMKERNSgbepxmQpeVC(eventData, djzopKKzNVFdfdFAFaQOsAQZAltn.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(ZorgOfqrJmwLJrSOThoNfgbUlEhP != null) || !_useTouchRegionOnly))
			{
				sztlQyUherWngYGdCbQogxgOovTw(eventData, djzopKKzNVFdfdFAFaQOsAQZAltn.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(ZorgOfqrJmwLJrSOThoNfgbUlEhP != null) || !_useTouchRegionOnly))
			{
				tloLTiSmVYFaQIQBrLqQgDIiroXZB(eventData, djzopKKzNVFdfdFAFaQOsAQZAltn.Local);
			}
		}

		private void ZMudAoavUnmnJwARoNSZCaxDiYTBB(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				LaHdVZhhiwmwjAerVjjnmziidVSXA(P_0, djzopKKzNVFdfdFAFaQOsAQZAltn.TouchRegion);
			}
		}

		private void rVPCnRyqhGlhKofsHPxqDALzTUCu(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				GVbOKxvpjIeMKERNSgbepxmQpeVC(P_0, djzopKKzNVFdfdFAFaQOsAQZAltn.TouchRegion);
			}
		}

		private void SNNJrVfZfyHHHufEvpPMPFqOFZio(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				sztlQyUherWngYGdCbQogxgOovTw(P_0, djzopKKzNVFdfdFAFaQOsAQZAltn.TouchRegion);
			}
		}

		private void goXYLFSINDOvjsgOiHDncQQrdpjVA(PointerEventData P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				tloLTiSmVYFaQIQBrLqQgDIiroXZB(P_0, djzopKKzNVFdfdFAFaQOsAQZAltn.TouchRegion);
			}
		}

		private void lHWLFNYObwfhQSjfobJNYdJbSRNt(float P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && !_useDigitalAxisSimulation)
			{
				qQaapJpxQGaLHbgcrjcVeTFoGrXq(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void bULArKixyobYtypYsdXDdmqisEOS(bool P_0)
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				qQaapJpxQGaLHbgcrjcVeTFoGrXq(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void WCWWvsEnfoNTepvzzFqidVWeEsDr()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				qQaapJpxQGaLHbgcrjcVeTFoGrXq(null);
				_onButtonDown.Invoke();
			}
		}

		private void kFVakmPJVEvEoXyciHiUlhHmMLbM()
		{
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo)
			{
				qQaapJpxQGaLHbgcrjcVeTFoGrXq(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
