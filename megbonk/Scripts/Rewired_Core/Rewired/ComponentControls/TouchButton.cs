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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Touch Controls/Touch Button")]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum uwIHpvVmsDEaEfdVpMdhPIDRSeAz
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum aNAWfpSnWCOtAeVooUfSMexEGNCD
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

		private sealed class ihUyHfieHYRXvADPuNxiUoqiunkt : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int wDpqPNcRPjvOXSgIyxoPwmrHZjpq;

			private object UQYKDaWmupirmMBszrljCgZfcFVQ;

			public float RPecQDMHGfoFJFEOPgXgzMFTCnNcA;

			public TouchButton WBXsVlebwsZlfBvpyGmihJqufTbfA;

			public PositionType UkSWtAbLIuSuIphCOEpSatyztuIh;

			public Vector2 MExRSaPGZprUvvCTGkBWibWfZiZc;

			public uwIHpvVmsDEaEfdVpMdhPIDRSeAz trPvOqVOPrveRWDmmEEpCjnlQHhoA;

			private RectTransform OEABmQOqBtiJSOkFLIeowzrUARjB;

			private Vector2 aEAyeWgOQaiMAkZpbTYotUAFrztI;

			private float QzlvnFTtdHEVcTaftAZqsxajggIbA;

			private float BgqbOKcRvgJeXqPKqMTxXUzLdzmX;

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
			public ihUyHfieHYRXvADPuNxiUoqiunkt(int P_0)
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

		private const float fAjFkZWUApqqSLYUlpHdcUjVCAvq = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement;

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
		private bool _stayActiveOnSwipeOut;

		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, 1f / 0f)]
		private float _digitalAxisGravity;

		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, 1f / 0f)]
		private float _digitalAxisSensitivity;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis;

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly;

		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch;

		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed;

		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn;

		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting;

		private float tsAHpjvYbNCkRmEkFRNupXyxXOu;

		private float eChgOsVuKawoXIuikCQxbwCXuhkg;

		private TouchRegion QiIqoIyNJlwMgeRLukOPZZVPmfWp;

		private Vector2 CbpkeimAaAkIWZPFyYJOZAImjdyiA;

		private bool NrxNozasCOsncRdAzipAxzcCTQiF;

		private bool zfoNRKAcrznzNymrHzvYXFkTmTvf;

		private uwIHpvVmsDEaEfdVpMdhPIDRSeAz jBbGyAAtARlNUQLXcUgppSibjFFd;

		private int oDlVNYNJMynnMcibpyXDANRWvSXl;

		private int DkhtdAGrELiJLGzhbZpxchtuKVYG;

		[NonSerialized]
		private bool TjFvEQwLLoKwqWnMWchhsXQdBpsx;

		[NonSerialized]
		private bool zeGqkmgFpPTQodXskogRsPPGhSNc;

		private IEnumerator UJuHLOkXjLXYQjuTFzCvEoFIwkNJ;

		private ArkyMExcqvAjSSEgvKopSLEhHuEEA aUrGpxvNvFbrePxUGyFgRhqQDmBJ;

		private Action<uwIHpvVmsDEaEfdVpMdhPIDRSeAz> NlslHLQPJoWhviHQxgYgHMNpQpJd;

		private Action<uwIHpvVmsDEaEfdVpMdhPIDRSeAz> FPNoeVcnqegGVBWwWxIJlHKmTTvp;

		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedEventHandler _onAxisValueChanged;

		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged;

		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonDownEventHandler _onButtonDown;

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp;

		private Dictionary<int, PointerEventData> cgOaamUtyKXCSaUhGmyEQFueZSYm;

		public CustomControllerElementTargetSetForFloat targetCustomControllerElement => null;

		public ButtonType buttonType
		{
			get
			{
				return default(ButtonType);
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

		public bool useDigitalAxisSimulation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float digitalAxisGravity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float digitalAxisSensitivity
		{
			get
			{
				return 0f;
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

		internal StandaloneAxis axis => null;

		private Action<uwIHpvVmsDEaEfdVpMdhPIDRSeAz> moveStartedDelegate => null;

		private Action<uwIHpvVmsDEaEfdVpMdhPIDRSeAz> moveEndedDelegate => null;

		private float axisValue => 0f;

		private float axisValuePrev => 0f;

		private bool buttonValue => false;

		private bool buttonValuePrev => false;

		private int effectivePointerId => 0;

		public event UnityAction<float> AxisValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<bool> ButtonValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction ButtonDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction ButtonUpEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchButton()
		{
		}

		public void SetRawValue(float value)
		{
		}

		public void SetDefaultPosition()
		{
		}

		private void gwuhSavTjFoSVMPuYBpBRSxauxsc(Vector2 P_0)
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

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
		}

		internal override void UjYAamsdzBByKqJeCzTogWwkpzPq()
		{
		}

		internal override bool pSfLXLykqGsrHeXOKVHkoiqvAwzcA()
		{
			return false;
		}

		internal override void JjbSogcowrvbvmUaaVAcTDurzTkd()
		{
		}

		internal override void YPIpAATaLSbyQilpgKOjbXBAhEqXA()
		{
		}

		internal override void wKtlVbgqdJHWDjRQWgYcGuxfgWDxA()
		{
		}

		internal override void PCavBKUOTQxjogDkKkwMMvzHZTRh()
		{
		}

		internal override void uejyLnYLOhZNmitUQHKQQMEZdrEY()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool SjGLqQCXTLpKRhCblQEzSnJNvLxp()
		{
			return false;
		}

		internal override bool muEjuLNOgxFpTfrtZBaeqossxvzd(GameObject gameObject)
		{
			return false;
		}

		private void xwfFLuRVHVwZLNuDQkbgfrmHJtVj()
		{
		}

		private void cHwTCdYGJFYeZbEFGWFxhnaEVzTp()
		{
		}

		private void vbrmyrxuTyDYuivmnWvFsfvFZGGf()
		{
		}

		private void WjQXfnCqTvSAWCTPBjbbQZgTmZwT(float P_0, bool P_1)
		{
		}

		private void sDbytSfHsruVhqhqoBTcIezOmraQ()
		{
		}

		private void CdlSVoGfApfKzwWhpXJVfefGlgYj()
		{
		}

		private void mLdLcYSdzTGNnaGtghWewiamooCDb()
		{
		}

		private void AHPTpCHiCmaDAJmOEUOUiCZxYkVX()
		{
		}

		private bool UNtBkbhcQmIGPojelpIiaAKxYbzo()
		{
			return false;
		}

		private void dzfRRsPYayPDQhciUjsZcAeNOSXCA(TouchRegion P_0)
		{
		}

		private void ebKwQrPlwUcCZrrZABhPqTJIRoIq(TouchRegion P_0)
		{
		}

		private void ebaVekCyIQGeThPexwcRNbxOpZge()
		{
		}

		private void shBvXmoUZbPzOzVpfePBsJOovctl(Vector2 P_0, bool P_1, float P_2, uwIHpvVmsDEaEfdVpMdhPIDRSeAz P_3)
		{
		}

		private void PfEUnZRiSuAkflrTmXAkYqhLQBXN(Vector2 P_0, PositionType P_1, bool P_2, float P_3, uwIHpvVmsDEaEfdVpMdhPIDRSeAz P_4)
		{
		}

		[IteratorStateMachine(typeof(ihUyHfieHYRXvADPuNxiUoqiunkt))]
		private IEnumerator aEBCfSFQWBHbhCvRZziGLFIeeeAIA(Vector2 P_0, PositionType P_1, float P_2, uwIHpvVmsDEaEfdVpMdhPIDRSeAz P_3)
		{
			return null;
		}

		private void ulfAtBcYMbHaGITqdostcuiibsPob(uwIHpvVmsDEaEfdVpMdhPIDRSeAz P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void JfDXQnvlrFYhrrFBpDiCcHMvOrkyA(uwIHpvVmsDEaEfdVpMdhPIDRSeAz P_0)
		{
		}

		private void DZajOjzzTAndHIdiheUueYPRaMGkA(uwIHpvVmsDEaEfdVpMdhPIDRSeAz P_0)
		{
		}

		private void jHvwzZlmhATDnAZmKfcNLvJbeQiP(int P_0)
		{
		}

		private void jbtNlYJNPDrdkNRzIoMJwLicLFRv()
		{
		}

		private void YxHbeSrQGaxByWEaRhnbztzAEWVeA()
		{
		}

		private bool QtabBcFwHFTZVBKlRdcWbzjSNmtg()
		{
			return false;
		}

		private void UTGAiGsPyCivxIsSLcVSHCPxTJfl()
		{
		}

		private bool PKVZGgIdrxvvoewdeTLZFBAmGorQ(int P_0)
		{
			return false;
		}

		private PointerEventData EMKwrnUTismCviJTOFTEjQKVVfblA(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData ZPahbuoNtggtSDuZTpgaJnBbHRSn(int P_0)
		{
			return null;
		}

		private void XPPJpyeAwXIEnnXYGXDmhHyQXPwE(PointerEventData P_0)
		{
		}

		private PointerEventData maXisXPrntzTgaxgzhciUeFLovSJ(int P_0)
		{
			return null;
		}

		private void KwmVxilekbavMarqkgNjXTCrEuhyA(PointerEventData P_0, aNAWfpSnWCOtAeVooUfSMexEGNCD P_1)
		{
		}

		private void BlYgUWnbABtYxPGEnUlePHxRILwC(PointerEventData P_0, aNAWfpSnWCOtAeVooUfSMexEGNCD P_1)
		{
		}

		private void vOEHBwEserFLuFcxJmqWYYTBScIA(PointerEventData P_0, aNAWfpSnWCOtAeVooUfSMexEGNCD P_1)
		{
		}

		private void crRjtFKPVTFdrjFOONOYUpocdXaCb(PointerEventData P_0, aNAWfpSnWCOtAeVooUfSMexEGNCD P_1)
		{
		}

		private void oIiEasJndBdgFuRSqCcXqQjvREro(int P_0, Vector2 P_1, aNAWfpSnWCOtAeVooUfSMexEGNCD P_2)
		{
		}

		private void TTzBMQmqdkTqHbkeigeiofLjeVBb()
		{
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
		}

		private void QCZycLzuEgfowZOEJDcRiWXnVhchA(PointerEventData P_0)
		{
		}

		private void snyDcmgrlDikjrGjwDBqnUnuhHxH(PointerEventData P_0)
		{
		}

		private void XEqdSwdNffGkwpFjAHgShcEBwxBJ(PointerEventData P_0)
		{
		}

		private void xiubjgEGDCyoYVpPVebzRkcwhOUvA(PointerEventData P_0)
		{
		}

		private void wKzjfiWSbzfibBPwTBjNmKhyrqkt(float P_0)
		{
		}

		private void mVsFeduQazJgAbxFVxcLBwGxfVlj(bool P_0)
		{
		}

		private void FtreTZFIthhOHYggCCCkLRmlNNacb()
		{
		}

		private void ruaORNDnBNLkHYrWFOHIRhprqhAf()
		{
		}
	}
}
