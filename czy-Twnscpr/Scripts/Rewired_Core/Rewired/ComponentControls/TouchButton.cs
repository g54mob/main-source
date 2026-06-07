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
	[CustomClassObfuscation]
	[DisallowMultipleComponent]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum YJwoaBAfHayorfPjXeFGNPEyNwf
		{
			kWwOvXSVQftLstpRDMaKvWdpfrv = 0,
			BhlggfALXeCHqaSIOjQPvpUDuzL = 1,
			wqcbhtCrfxNgDYLLdEEPZQrIAfVU = 2
		}

		private enum YpeNTTRQHvOvberyUwAlLbLdAgx
		{
			nHPtsYQbEDXgmhYrndYheGAnOz = 0,
			ZBZWYgvtnoCSPewqyVBkKJgohP = 1
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

		private sealed class OYOujZSHpmQRTWYjKYbdFgDbESo : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			public TouchButton TiaUIShtPVkFOKyDFxywSfPUjyv;

			public Vector2 XtSOgFUidBAYtZiIVWILWyBaOQc;

			public PositionType LQlGFbCflnOozLLyPpePESIaEZkz;

			public float WKertIOlspTQdeQxowWRBMhJcAJ;

			public YJwoaBAfHayorfPjXeFGNPEyNwf igoHlLKNBsDzfiNFnGgNabDCtiP;

			public RectTransform tBALJTyKEGiYWNGqjVGoDPwoBIL;

			public Vector2 YAAjgotFxRCrhknWRWSAWiqEtsZ;

			public float DYnrZhtrcyMKpFUuywKBcJYVkMY;

			public float oaKnIzsjImZpMKKQSsTzXgcZpCC;

			public float cSmGpNRfpKZIiIuKmEvPGAeOfKy;

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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public OYOujZSHpmQRTWYjKYbdFgDbESo(int _003C_003E1__state)
			{
			}
		}

		private const float IkKRMLvrFSrQrjgPnCGWMTrOzbK = 20f;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private ButtonType _buttonType;

		[SerializeField]
		[CustomObfuscation]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation]
		private bool _stayActiveOnSwipeOut;

		[SerializeField]
		[CustomObfuscation]
		private bool _useDigitalAxisSimulation;

		[CustomObfuscation]
		[SerializeField]
		private float _digitalAxisGravity;

		[SerializeField]
		[CustomObfuscation]
		private float _digitalAxisSensitivity;

		[SerializeField]
		[CustomObfuscation]
		private StandaloneAxis _axis;

		[SerializeField]
		[CustomObfuscation]
		private TouchRegion _touchRegion;

		[SerializeField]
		[CustomObfuscation]
		private bool _useTouchRegionOnly;

		[SerializeField]
		[CustomObfuscation]
		private bool _moveToTouchPosition;

		[SerializeField]
		[CustomObfuscation]
		private bool _returnOnRelease;

		[SerializeField]
		[CustomObfuscation]
		private bool _followTouchPosition;

		[CustomObfuscation]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation]
		private bool _manageRaycasting;

		private float IMwePFDSPGatkFxaTAMGyPKAnDfw;

		private float XCOUIVcgAfgbBuagOlVZbaBATao;

		private TouchRegion NJOGJIHyFrypxlADQyLSoYqJgLV;

		private Vector2 fTuCnNiwdOZRcorKbruVOcrABcWt;

		private bool hmMfalIfHjhkpGPBDffzErhvmsGP;

		private bool gRmozEEdkuuTfFtimrRzaNtXlYx;

		private YJwoaBAfHayorfPjXeFGNPEyNwf uBaaNrhVfWNKzNUzGOiDyhObVRbs;

		private int wfQFPIyuNxZVNmyjsXoFqwaHSjI;

		private int FGiEegxdhsGCLRGQzAjGgPpbiJ;

		[NonSerialized]
		private bool KqHBQBNHrkGLwntKsACAVNIMLBU;

		[NonSerialized]
		private bool jpHFALOLDsUlucqzzUZuYLLBnXs;

		private IEnumerator HKqwanPWZNZjaodIyIFvtdPImze;

		private yGgxgyRZUBKpiMEJkOOhHBUlev DPaMMgoFdEORdoMxBrLfLbXTDTx;

		private Action<YJwoaBAfHayorfPjXeFGNPEyNwf> rlMEaAxWitXgpBFqrAUOBQogAEi;

		private Action<YJwoaBAfHayorfPjXeFGNPEyNwf> WLFCkPmiKsLXKhNEXSSrjsNZDkV;

		[SerializeField]
		[CustomObfuscation]
		private AxisValueChangedEventHandler _onAxisValueChanged;

		[SerializeField]
		[CustomObfuscation]
		private ButtonValueChangedEventHandler _onButtonValueChanged;

		[SerializeField]
		[CustomObfuscation]
		private ButtonDownEventHandler _onButtonDown;

		[SerializeField]
		[CustomObfuscation]
		private ButtonUpEventHandler _onButtonUp;

		private Dictionary<int, PointerEventData> YgLWlCQLLAVasVsbUeUWPDHkOif;

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

		private Action<YJwoaBAfHayorfPjXeFGNPEyNwf> moveStartedDelegate => null;

		private Action<YJwoaBAfHayorfPjXeFGNPEyNwf> moveEndedDelegate => null;

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

		private void WbcyzCnBYDpBlBHFzMgGHNNQDFdD(Vector2 P_0)
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

		internal override void PSFeJyfveNnRLRnWPckAdcFQFXH()
		{
		}

		internal override bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		internal override void ttJAqkHGCfTssfJpreeBeSfOQEJn()
		{
		}

		internal override void icQxdQEDgrvBqfMTuplRHxKgMmr()
		{
		}

		internal override void NdtcFvGfnnZoRnENbmFXoawgFosU()
		{
		}

		internal override void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		internal override void dfIfTakAbrHDwHdgPNSyWCKumHlK()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool dBCYcNAjoSqmwCdqowZTiusxKJK()
		{
			return false;
		}

		internal override bool wByjfGONJngXzFPsNQZLuqsRAef(GameObject gameObject)
		{
			return false;
		}

		private void yRzvrgYSTumDruraNLJLSTnsphN()
		{
		}

		private void IhoDLuyjmpOgyGKYZwFXuPSftHJ()
		{
		}

		private void onmdYfGTOlpRTdoKacqkFUOroTlZ()
		{
		}

		private void GUWjRHCkkIufdZlYkbwNlNtAeyH(float P_0, bool P_1)
		{
		}

		private void rQpRpBjpkJpYUfJRusyzpoaxBVd()
		{
		}

		private void pIubQZcZWtMXLPpvXQvqYAYYCqu()
		{
		}

		private void kckhtUMxbCHYHtoyNtsHEKeNtSU()
		{
		}

		private void idowseZlGvRQslSHYluJlAkPEJr()
		{
		}

		private bool AJsXCSKraWGmxVSVDMoDxHFnaBn()
		{
			return false;
		}

		private void rRgDlIHKcpijByBEQOTwpsobXOt(TouchRegion P_0)
		{
		}

		private void lodymkYoizLvdTuzDmkSuzgxGZP(TouchRegion P_0)
		{
		}

		private void UCWygVqUaZVUHLoGuHfxLFabiVB()
		{
		}

		private void lBQcfSAIvteHiOMCxZQfpjHBFnWa(Vector2 P_0, bool P_1, float P_2, YJwoaBAfHayorfPjXeFGNPEyNwf P_3)
		{
		}

		private void nrunSlECDmhyNBsJeWmrqGkmPHpM(Vector2 P_0, PositionType P_1, bool P_2, float P_3, YJwoaBAfHayorfPjXeFGNPEyNwf P_4)
		{
		}

		private IEnumerator tDxHouhbBVejXDatWoXphgfjcnqd(Vector2 P_0, PositionType P_1, float P_2, YJwoaBAfHayorfPjXeFGNPEyNwf P_3)
		{
			return null;
		}

		private void LnuxqQsvAZUKZrIpVUgioYuSloh(YJwoaBAfHayorfPjXeFGNPEyNwf P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void LNWHMamEpyGxOPREoPuxjHVIGEP(YJwoaBAfHayorfPjXeFGNPEyNwf P_0)
		{
		}

		private void UbpubYKwTtJTwSiecfjUgFynXVUr(YJwoaBAfHayorfPjXeFGNPEyNwf P_0)
		{
		}

		private void QQizmlJFawbwuxZNlXtgYHKEbAU(int P_0)
		{
		}

		private void dmKBmHHHwfWsZsdpSlycxaVZSDu()
		{
		}

		private void veTfMrfLMUfzJzOHRBFRkMnqBWO()
		{
		}

		private bool RVbzuctoduCakjVutuZLyDfnZZF()
		{
			return false;
		}

		private void zHgVhzqmbhEMlEstipDsIXTAjNei()
		{
		}

		private bool SYhZCRvJjiXnfkTsyFWfOpOfsTZ(int P_0)
		{
			return false;
		}

		private PointerEventData oJrokPHIRoDpHGtvkvpQmHowcew(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData zopDdwaviZCSmAhQnKOimKfZBUT(int P_0)
		{
			return null;
		}

		private void BwRKOcbOwdLvrIpeGyfXzAkRHLy(PointerEventData P_0)
		{
		}

		private PointerEventData JCQxxuuzprIUaDcOjSsSZGfJObS(int P_0)
		{
			return null;
		}

		private void kfvnrjqaEfeRuayXHYKbpmJKYwR(PointerEventData P_0, YpeNTTRQHvOvberyUwAlLbLdAgx P_1)
		{
		}

		private void DxjcxzzqjvxZZegCnKBKoKmijVm(PointerEventData P_0, YpeNTTRQHvOvberyUwAlLbLdAgx P_1)
		{
		}

		private void DfGSlmXfLslFdShfJolWIzSoPvh(PointerEventData P_0, YpeNTTRQHvOvberyUwAlLbLdAgx P_1)
		{
		}

		private void preHHVyWSelnFiIdNqLbeHrxdpP(PointerEventData P_0, YpeNTTRQHvOvberyUwAlLbLdAgx P_1)
		{
		}

		private void TAPiNRthJWADaabtiEUIPBfPOAra(int P_0, Vector2 P_1, YpeNTTRQHvOvberyUwAlLbLdAgx P_2)
		{
		}

		private void UCuhEhhpmUBeyHWoyYCwAQUxCkas()
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

		private void bwUFIqhEOHizPlzQbAWZDIqMXkzW(PointerEventData P_0)
		{
		}

		private void KRImDvFrLGRAMQPrhfQZDkwhNip(PointerEventData P_0)
		{
		}

		private void WpSnwHWcTedSikawnoCkwuJJWBJ(PointerEventData P_0)
		{
		}

		private void RZLcDwdTQxRKplkTiOuxmAeQROdi(PointerEventData P_0)
		{
		}

		private void eUkigvhovXTpDjxNlghkvfBNLFy(float P_0)
		{
		}

		private void cXABqxxlBWlwVNCzuiWPFaGbbOX(bool P_0)
		{
		}

		private void bykdyHbOWxVhjmQdoqmpIeYjfZP()
		{
		}

		private void QbPHLoiBAMrzcuAFiufLkkIWqazd()
		{
		}
	}
}
