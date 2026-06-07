using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[CustomClassObfuscation]
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
			public PEZvntLEEzEUiYzLXTCktMxhYESr(int P_0)
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

		private const float XgnNuvXBBArwHhmQuOJjuwPwAMLr = 20f;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private ButtonType _buttonType;

		[CustomObfuscation]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[CustomObfuscation]
		[SerializeField]
		private bool _stayActiveOnSwipeOut;

		[CustomObfuscation]
		[SerializeField]
		private bool _useDigitalAxisSimulation;

		[CustomObfuscation]
		[SerializeField]
		private float _digitalAxisGravity;

		[CustomObfuscation]
		[SerializeField]
		private float _digitalAxisSensitivity;

		[SerializeField]
		[CustomObfuscation]
		private StandaloneAxis _axis;

		[CustomObfuscation]
		[SerializeField]
		private TouchRegion _touchRegion;

		[CustomObfuscation]
		[SerializeField]
		private bool _useTouchRegionOnly;

		[CustomObfuscation]
		[SerializeField]
		private bool _moveToTouchPosition;

		[SerializeField]
		[CustomObfuscation]
		private bool _returnOnRelease;

		[SerializeField]
		[CustomObfuscation]
		private bool _followTouchPosition;

		[SerializeField]
		[CustomObfuscation]
		private bool _animateOnMoveToTouch;

		[SerializeField]
		[CustomObfuscation]
		private float _moveToTouchSpeed;

		[SerializeField]
		[CustomObfuscation]
		private bool _animateOnReturn;

		[SerializeField]
		[CustomObfuscation]
		private float _returnSpeed;

		[CustomObfuscation]
		[SerializeField]
		private bool _manageRaycasting;

		private float LCRetaxfqWkUybIwMDfXdUQmmqbB;

		private float KztafzFUovqmhfsAgBYciDHCaTzkc;

		private TouchRegion OZpdgeYptzceNlEbLLCpIasfuuCQ;

		private Vector2 gJPBKjASPUkYQjJweuleWqdkiBDy;

		private bool acleJLVJfrpdNZbfkVwSBZrSlDZv;

		private bool zOLVRmkYSiUbLTDSlPyMCnlvpMcq;

		private LNVXndypfcnGHxjXWIKbzWEKXCgJ pFDkUXpsRWRnBYBJHInaLzWBAmwW;

		private int hBtoemOfUfsKjssObQMaORunBvJT;

		private int SzxfXOWsFpbnmLHgHTaMmMHBBXQEA;

		[NonSerialized]
		private bool HNeekbdvHcSGCkhkngTpwdUwueLRA;

		[NonSerialized]
		private bool aMiVitsTbcaHUuBPegFBByVtJKdtA;

		private IEnumerator ATTFNSdOsXBGJgyJpEHUDcrydDngA;

		private bizhSGSkbYKHLUAwUjJldBHmyZwq IFVbECUjDOSCVcLLYiPMhcVdqoyh;

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> ovtgdkNgwpSEHRHYmtFdrOoUovrX;

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> VVgDPpCRkwAUmdtwUpPAdDZvLTKUA;

		[CustomObfuscation]
		[SerializeField]
		private AxisValueChangedEventHandler _onAxisValueChanged;

		[SerializeField]
		[CustomObfuscation]
		private ButtonValueChangedEventHandler _onButtonValueChanged;

		[CustomObfuscation]
		[SerializeField]
		private ButtonDownEventHandler _onButtonDown;

		[SerializeField]
		[CustomObfuscation]
		private ButtonUpEventHandler _onButtonUp;

		private Dictionary<int, PointerEventData> LjmEDecqpUzpCHTZXZyrvkHEVVih;

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

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> moveStartedDelegate => null;

		private Action<LNVXndypfcnGHxjXWIKbzWEKXCgJ> moveEndedDelegate => null;

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

		[CustomObfuscation]
		private TouchButton()
		{
		}

		public void SetRawValue(float value)
		{
		}

		public void SetDefaultPosition()
		{
		}

		private void ZrZWwcXscDUNLLffipUjfeXokFej(Vector2 P_0)
		{
		}

		public void ReturnToDefaultPosition(bool instant)
		{
		}

		public void ReturnToDefaultPosition()
		{
		}

		[CustomObfuscation]
		internal override void Awake()
		{
		}

		[CustomObfuscation]
		internal override void OnEnable()
		{
		}

		[CustomObfuscation]
		internal override void OnDisable()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation]
		internal override void Reset()
		{
		}

		internal override void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
		}

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			return false;
		}

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
		{
		}

		internal override void pmxmOeyRAlBoCxmllQyaxtECbvcr()
		{
		}

		internal override void KhQueZDBBtkbvKkxubYmYxeSHJrfA()
		{
		}

		internal override void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
		}

		internal override void wfYqWOGHtnIUbtMhSNJLmUHIcfqd()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool iRdXbhkXKKrPUChGpkAoIswDMaDN()
		{
			return false;
		}

		internal override bool pzZuAkmltxMhZFAhATJmEgsvqjqP(GameObject gameObject)
		{
			return false;
		}

		private void zuAKYWggjwIZZcFIWSNietTQOaIg()
		{
		}

		private void TXokOyGYvfhCZKwEhWuKACDQsGvA()
		{
		}

		private void xPPrkDhYcdSavovozhVHyLYWmHoI()
		{
		}

		private void NExRKhgqSEXnRVmslgyqZwlepTKt(float P_0, bool P_1)
		{
		}

		private void moMoajBsFPMscddbfqbMNRmHCyiN()
		{
		}

		private void cfXhvzcGsdISdUHJYWVNEeKiLJlUA()
		{
		}

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
		}

		private void pzPMFEbyDhmWExkoJxkqFuWrLfmN()
		{
		}

		private bool PGRwgyyCEWmVXLbfYWHiHTHXKcgx()
		{
			return false;
		}

		private void cVJYLgudKpcedZGsLcQHBTgFXrogA(TouchRegion P_0)
		{
		}

		private void esAXKEkUWhoBLDsRGfMxQcmHceQK(TouchRegion P_0)
		{
		}

		private void JLnGBUfdysxYoDUCZJSERpDKNZAO()
		{
		}

		private void yXvFCwguRvPGWzUcsYLKERTdoKRZA(Vector2 P_0, bool P_1, float P_2, LNVXndypfcnGHxjXWIKbzWEKXCgJ P_3)
		{
		}

		private void eITbiRqIzcvtzyMtnrVQwwxIcFag(Vector2 P_0, PositionType P_1, bool P_2, float P_3, LNVXndypfcnGHxjXWIKbzWEKXCgJ P_4)
		{
		}

		private IEnumerator eYHLOFQxNaFhuZFTErUMQxBGBpL(Vector2 P_0, PositionType P_1, float P_2, LNVXndypfcnGHxjXWIKbzWEKXCgJ P_3)
		{
			return null;
		}

		private void WQXJGuUNcDBFtdyHEvIDGCascPox(LNVXndypfcnGHxjXWIKbzWEKXCgJ P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void KlzDqOhWDaEscpTwtInUZXFgetYgb(LNVXndypfcnGHxjXWIKbzWEKXCgJ P_0)
		{
		}

		private void TfMWssqBnrIKOIMGruTtpLqJkuDH(LNVXndypfcnGHxjXWIKbzWEKXCgJ P_0)
		{
		}

		private void BnHDOLKbUanuKgdtijCJfcEoDAFlA(int P_0)
		{
		}

		private void ewnocjnbCdATpbuVDhgTcBsizpjGb()
		{
		}

		private void egDhVENqiOmptpvGuCmdKvgAwDfc()
		{
		}

		private bool CZCTQSVOBilzIhcUcSFoCffNCgIT()
		{
			return false;
		}

		private void ykJYYTWDBrPpTaxVtKiVzeDkBkrt()
		{
		}

		private bool ZUErojFQVybWFckzvOUChmdZdZUuA(int P_0)
		{
			return false;
		}

		private PointerEventData tmSHozvxCeyplYJTdurtEufONlsc(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData sxUWcYUfULZPIUeyiMZFYFflpeYn(int P_0)
		{
			return null;
		}

		private void OsoYfSPmIvHIXGTEXudqHnglgstr(PointerEventData P_0)
		{
		}

		private PointerEventData KSrSTOGNRhDrOLwekzgdtyflCwNh(int P_0)
		{
			return null;
		}

		private void xIWWjJOuupYMQcrdMBCGCHPaXBWI(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
		{
		}

		private void IoGbCPRdLbcSdkogaRArqCgIugjmA(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
		{
		}

		private void QcjNpGrRNqqqNCrPAtddavSMTuin(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
		{
		}

		private void qbFkezCsiyAgtoKeAIvWYmFVHAOW(PointerEventData P_0, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_1)
		{
		}

		private void IusOvBAtCSXEzhPnHLjnVptEdmr(int P_0, Vector2 P_1, FLHpwrtrgrAVRgvHFllCbTfBvlsX P_2)
		{
		}

		private void VDahXJPMYKnASeYtoJZirWDQPxW()
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

		private void mYtlVUwcgRDqffxeyQNiuhceENseA(PointerEventData P_0)
		{
		}

		private void LphWTZrpvYLSyEGXsYgatVgDoywK(PointerEventData P_0)
		{
		}

		private void TMvPCdsBYetiGshWuVrBWfehcrIfA(PointerEventData P_0)
		{
		}

		private void KPebiOdQuvcDTjsxtodIOqscoheFb(PointerEventData P_0)
		{
		}

		private void lLFFKNPRhFapxntcuwlZTDsroWzC(float P_0)
		{
		}

		private void xgbfJDEHpWXivuVHhlzqrlGBypUt(bool P_0)
		{
		}

		private void uGPyYjLxchxKLwgNhTxIoOCBgiGx()
		{
		}

		private void HfqBmKzQoOGqOGrpdJsuQnYySZuk()
		{
		}
	}
}
