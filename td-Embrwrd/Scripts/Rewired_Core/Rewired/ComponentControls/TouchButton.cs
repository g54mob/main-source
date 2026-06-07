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
	[AddComponentMenu("Rewired/Touch Controls/Touch Button")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[DisallowMultipleComponent]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum jDZjrnAFKWfRKFFMSGXTbOTxNoLzA
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum bpFcCfANHFhdQwCSNVimvOwiGMTmA
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

		private sealed class fMJXivhhxVkRdesGNBIOMAuOinfu : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int zFqLNXnRhsxfHwEXLDEdsKtpzfus;

			private object TCTtSsDKScZZckTdGORTSHTTaHEeA;

			public float KMlFSNXOkaOqTbdBwrvSxMLbEzOq;

			public TouchButton PuCPAjtwYlSxhzBiPYmUrRuUDYeI;

			public PositionType PiVmSYkYkdBhQVfRngsajgmZxnBNA;

			public Vector2 XNgyViSPsiWKhXRDxSAgcpbTpDYQ;

			public jDZjrnAFKWfRKFFMSGXTbOTxNoLzA sEGCRyGHhkNEBeCfFDyXrxzRGDsS;

			private RectTransform XhZFJaHLEaYFNbghwLiQTgxcCKWmA;

			private Vector2 dLXqiCpxkjkHQAQsIVjOfGWndrkhA;

			private float LdwleTMiBYuIormoMxjIadcTheBT;

			private float CknAaAOTpbViXpLRPvnBDhwbxNfd;

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
			public fMJXivhhxVkRdesGNBIOMAuOinfu(int P_0)
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

		private const float gVseiDBIwcNHUzDXCudDsxhzcAcn = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		private ButtonType _buttonType;

		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _stayActiveOnSwipeOut;

		[CustomObfuscation(rename = false)]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity;

		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis;

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
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

		[SerializeField]
		[Range(0f, 20f)]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting;

		private float kUdFVrBsooYpwFbDVqxdfuHBYHZvb;

		private float xZgNyeKfshRDVaMpLdaFfRYfvmnn;

		private TouchRegion NNTkNEzvrojneWYMHgEjZpXtjPZg;

		private Vector2 RliocgbxOBHvYdWARHzaNlMMWhty;

		private bool ObwNJnleaFyDajTXYdGyndaeMTrv;

		private bool ooxvZCPjZeuEZWlsmsRyDhcdaiiAA;

		private jDZjrnAFKWfRKFFMSGXTbOTxNoLzA uycCQgdNLAYKFgsCVbmAgjSXwbIIb;

		private int pweRHAOCepSWUGEgIlxjYtVwfjCF;

		private int SPcQtMVtoEtFXuxcWthHixpUbWJu;

		[NonSerialized]
		private bool CAWSqEtdrhVPqcFJnJZPmDMJNxjv;

		[NonSerialized]
		private bool ofXGkcirvACqOlRYFcOKvkJyTzVPA;

		private IEnumerator BqdIXKtmDQGoQRYEkJVLCbXkZyST;

		private BLtugKwVIsVbSuMnMPEDELGPhaRhA vfqNMfsJXUUWerggnfASBVkmQFMu;

		private Action<jDZjrnAFKWfRKFFMSGXTbOTxNoLzA> OhrafBfBdbkxprOYKmIYFDIeDEITB;

		private Action<jDZjrnAFKWfRKFFMSGXTbOTxNoLzA> AeKccNfgYfHtDdJhhqwvvTKOHVsq;

		[SerializeField]
		[Tooltip("Event sent when the axis value changes.")]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedEventHandler _onAxisValueChanged;

		[SerializeField]
		[Tooltip("Event sent when the button value changes.")]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		private ButtonDownEventHandler _onButtonDown;

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp;

		private Dictionary<int, PointerEventData> bkJsHwRUkDxOSIiIdYFeYeMAIIRE;

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

		private Action<jDZjrnAFKWfRKFFMSGXTbOTxNoLzA> moveStartedDelegate => null;

		private Action<jDZjrnAFKWfRKFFMSGXTbOTxNoLzA> moveEndedDelegate => null;

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

		private void dWhVlwefrCbJDhoWxHhheDWJQgukb(Vector2 P_0)
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

		internal override void TaJJysfcXGOLIYrzfRlEkosEbnMcA()
		{
		}

		internal override bool qAgXOZxzQNKqPAuHppaSytuDgzcg()
		{
			return false;
		}

		internal override void UQizGkdUUglAlSKLFhpOGRJTqnpDb()
		{
		}

		internal override void PDJYvOSVfJDBKJNuJgaVVBNgWtxL()
		{
		}

		internal override void xroVZfvuVIfFNJbBpfsGuofJYYUm()
		{
		}

		internal override void MPxPpCPVtBLCgEKzdjWmMHtdnZGk()
		{
		}

		internal override void bFeVhzFgykusySbDzeNuCRErjfHH()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool LQDwBUFVjYdMXZIuYqvBOPLxVful()
		{
			return false;
		}

		internal override bool rFFOtJAlAcasBPbwsddQAooGmbaDb(GameObject gameObject)
		{
			return false;
		}

		private void oTmiDuYzjShPXfSGzrYYjAifFHOp()
		{
		}

		private void bIhKJpFbbYJCBZoQlfeDdPcqdkWL()
		{
		}

		private void ksusFzsAplDnoKpxKsstoPvfgTRiA()
		{
		}

		private void JkFxgzTDbihgEqGGcBRXCMilMNfY(float P_0, bool P_1)
		{
		}

		private void tiwpGCsDYwFlhSdhPtHEYAziaxdP()
		{
		}

		private void HPwrUgBgqqfAnaIyApzltlboBbLz()
		{
		}

		private void joguCSZdRCicrksmLvqAyoqSgeRU()
		{
		}

		private void DSOjLGCAcjYqAxrBteqkDiTZVwEtA()
		{
		}

		private bool RyqKXnukcfvvJWMlQIwEEsCJJxyKA()
		{
			return false;
		}

		private void qnsXVaIAAlyiCFsljWgtCPklCjMH(TouchRegion P_0)
		{
		}

		private void zOHAZhQSBHjTHVMfnJmvaZkmidDg(TouchRegion P_0)
		{
		}

		private void rYddHybPORPhDFBKBGIfWPtrkpdWb()
		{
		}

		private void vmAPhyhxrqtcGXLuKrQlyWKSibyn(Vector2 P_0, bool P_1, float P_2, jDZjrnAFKWfRKFFMSGXTbOTxNoLzA P_3)
		{
		}

		private void OKPdoTACyrZRpBdORoIWKmntJlGi(Vector2 P_0, PositionType P_1, bool P_2, float P_3, jDZjrnAFKWfRKFFMSGXTbOTxNoLzA P_4)
		{
		}

		[IteratorStateMachine(typeof(fMJXivhhxVkRdesGNBIOMAuOinfu))]
		private IEnumerator vvGvGARwxGItPyYkXSmcDUEIoRqc(Vector2 P_0, PositionType P_1, float P_2, jDZjrnAFKWfRKFFMSGXTbOTxNoLzA P_3)
		{
			return null;
		}

		private void bOyhHHBkLeBOxzxUUSTNmwzTeEmb(jDZjrnAFKWfRKFFMSGXTbOTxNoLzA P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void MEYMCxaBrCEFjBhSMQamLcCVjfdN(jDZjrnAFKWfRKFFMSGXTbOTxNoLzA P_0)
		{
		}

		private void CutQMfshrRAOTknxAAkSEBRnAULGA(jDZjrnAFKWfRKFFMSGXTbOTxNoLzA P_0)
		{
		}

		private void sUidyPsTnZazravZzKqdJPnLErxc(int P_0)
		{
		}

		private void cpanqOKSpSAKudNwdcYruQkSXnIF()
		{
		}

		private void VOUEoSoAihjksckfexBDnxtybUYDb()
		{
		}

		private bool XavsngEOhYTkPlZyaKBkhedcLRun()
		{
			return false;
		}

		private void LZDrAEvFQDSXncsRisWgDaLLIHaEA()
		{
		}

		private bool OlGyDqRXBcJIcWkqLbbrcPSUpwcBA(int P_0)
		{
			return false;
		}

		private PointerEventData PZHrxfNEPbltrUYRbdFkCWUjlSmE(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData MgndxkjTVpSEAdDSkuCENEXDRLHN(int P_0)
		{
			return null;
		}

		private void WwOjBmlSGMlbdNbJzFtMelmcXBliA(PointerEventData P_0)
		{
		}

		private PointerEventData hmOOcJUpVeCGqBMzOjVQIVDvxcTy(int P_0)
		{
			return null;
		}

		private void RwjrUosYcgYYERnIVdgDZGGFoxme(PointerEventData P_0, bpFcCfANHFhdQwCSNVimvOwiGMTmA P_1)
		{
		}

		private void UYByaEyEXQNUjprTCstMHbFhKRvL(PointerEventData P_0, bpFcCfANHFhdQwCSNVimvOwiGMTmA P_1)
		{
		}

		private void qfZhNXAVInEuTLlnOOYGSIMllKvGb(PointerEventData P_0, bpFcCfANHFhdQwCSNVimvOwiGMTmA P_1)
		{
		}

		private void zlIhOHTgvQHQlxGJdLaqbpyUfVvfA(PointerEventData P_0, bpFcCfANHFhdQwCSNVimvOwiGMTmA P_1)
		{
		}

		private void hrbDwyCtNMPVBCJBFWSxqujXFWqM(int P_0, Vector2 P_1, bpFcCfANHFhdQwCSNVimvOwiGMTmA P_2)
		{
		}

		private void UzWfVIgZYusckbfzPWWYDildLaCDA()
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

		private void XGWgWPkcLtZQirTbqGrbCJOBrJpD(PointerEventData P_0)
		{
		}

		private void bzvqLkfhVQITtDTmTwjQvihWqroy(PointerEventData P_0)
		{
		}

		private void GrjOpwseDcXnoHbEpbhwhpUnoyAjA(PointerEventData P_0)
		{
		}

		private void oHzretHnfHPcCLMMwDARmakGENXl(PointerEventData P_0)
		{
		}

		private void hfqdqcBGXwdTrbrxitNpadjGrifu(float P_0)
		{
		}

		private void rujoTrtGAkqkSLxQqwLpJGANtjgP(bool P_0)
		{
		}

		private void YoHNDbNNjkxZOGzgjoCwDymVFxjc()
		{
		}

		private void eFtNOHWNlOysDoFyoAwuVWpDwtHm()
		{
		}
	}
}
