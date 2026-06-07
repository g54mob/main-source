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
	public sealed class TouchJoystick : TouchInteractable
	{
		public enum AxisDirection
		{
			Both = 0,
			Horizontal = 1,
			Vertical = 2
		}

		public enum JoystickMode
		{
			Analog = 0,
			Digital = 1
		}

		public enum SnapDirections
		{
			None = 0,
			Four = 4,
			Eight = 8,
			Sixteen = 0x10,
			ThirtyTwo = 0x20,
			SixtyFour = 0x40
		}

		private enum INaLVlEEKkYnjkKyaWcjcCQYeri
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum JqhjQSbOLueCKcXtNjdSinGgvOOuA
		{
			Local = 0,
			TouchRegion = 1
		}

		public enum StickBounds
		{
			Circle = 0,
			Square = 1
		}

		[Serializable]
		public class ValueChangedEventHandler : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class StickPositionChangedEventHandler : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class TapEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class TouchStartedEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class TouchEndedEventHandler : UnityEvent
		{
		}

		public interface IValueChangedHandler
		{
			void OnValueChanged(Vector2 value);
		}

		public interface IStickPositionChangedHandler
		{
			void OnStickPositionChanged(Vector2 value);
		}

		[Serializable]
		private sealed class kjUBggGfvIgZPISdDBCUfxjbgAlM
		{
			public static readonly kjUBggGfvIgZPISdDBCUfxjbgAlM _003C_003E9;

			public static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IValueChangedHandler, Vector2> _003C_003E9__277_0;

			public static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IStickPositionChangedHandler, Vector2> _003C_003E9__280_0;

			internal void rojQLwoGojpsMalgZBwPiBWLaNVj(IValueChangedHandler P_0, Vector2 P_1)
			{
			}

			internal void SbwCeYuvwefMYWNKphPoMnHDCHOHA(IStickPositionChangedHandler P_0, Vector2 P_1)
			{
			}
		}

		private sealed class UkIZWvhoPLqrejoibIGZkIrziHAc : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private object USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			public float RTHUUqokIzIENeGXftdmzIzrqZYk;

			public TouchJoystick GZXxEqHwrHYIyUJtInpLwgTukJaY;

			public PositionType AUMAgZZLBrHzLgTUYOnkEcEkkkfGc;

			public Vector2 GPrcxxCgPFJPNaVyAUBmpuVaCrKbd;

			public INaLVlEEKkYnjkKyaWcjcCQYeri vJROrazzqkuFowhstzcKQBkiBOn;

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
			public UkIZWvhoPLqrejoibIGZkIrziHAc(int P_0)
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

		private const float MAX_MOVE_SPEED = 20f;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private RectTransform _stickTransform;

		[SerializeField]
		[CustomObfuscation]
		private JoystickMode _joystickMode;

		[CustomObfuscation]
		[SerializeField]
		private float _digitalModeDeadZone;

		[SerializeField]
		[CustomObfuscation]
		private float _stickRange;

		[SerializeField]
		[CustomObfuscation]
		private bool _scaleStickRange;

		[SerializeField]
		[CustomObfuscation]
		private StickBounds _stickBounds;

		[CustomObfuscation]
		[SerializeField]
		private AxisDirection _axesToUse;

		[SerializeField]
		[CustomObfuscation]
		private SnapDirections _snapDirections;

		[CustomObfuscation]
		[SerializeField]
		private bool _snapStickToTouch;

		[SerializeField]
		[CustomObfuscation]
		private bool _centerStickOnRelease;

		[CustomObfuscation]
		[SerializeField]
		private StandaloneAxis2D _axis2D;

		[CustomObfuscation]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation]
		private bool _stayActiveOnSwipeOut;

		[CustomObfuscation]
		[SerializeField]
		private bool _allowTap;

		[CustomObfuscation]
		[SerializeField]
		private float _tapTimeout;

		[CustomObfuscation]
		[SerializeField]
		private int _tapDistanceLimit;

		[SerializeField]
		[CustomObfuscation]
		private TouchRegion _touchRegion;

		[CustomObfuscation]
		[SerializeField]
		private bool _useTouchRegionOnly;

		[CustomObfuscation]
		[SerializeField]
		private bool _moveToTouchPosition;

		[CustomObfuscation]
		[SerializeField]
		private bool _returnOnRelease;

		[SerializeField]
		[CustomObfuscation]
		private bool _followTouchPosition;

		[CustomObfuscation]
		[SerializeField]
		private bool _animateOnMoveToTouch;

		[CustomObfuscation]
		[SerializeField]
		private float _moveToTouchSpeed;

		[CustomObfuscation]
		[SerializeField]
		private bool _animateOnReturn;

		[CustomObfuscation]
		[SerializeField]
		private float _returnSpeed;

		[CustomObfuscation]
		[SerializeField]
		private bool _manageRaycasting;

		private bool _useXAxis;

		private bool _useYAxis;

		private iFznRwzhmJipMjcfRBhjJauAXkUOA.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private iFznRwzhmJipMjcfRBhjJauAXkUOA.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private INaLVlEEKkYnjkKyaWcjcCQYeri _moveDirection;

		private int _pointerId;

		private int _realMousePointerId;

		[NonSerialized]
		private bool HNeekbdvHcSGCkhkngTpwdUwueLRA;

		[NonSerialized]
		private bool aMiVitsTbcaHUuBPegFBByVtJKdtA;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private JqhjQSbOLueCKcXtNjdSinGgvOOuA _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private bizhSGSkbYKHLUAwUjJldBHmyZwq _imageRaycastHelper;

		private int _calculatedStickRange_lastUpdatedFrame;

		private int _lastTapFrame;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> __moveStartedDelegate;

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> __moveEndedDelegate;

		[CustomObfuscation]
		[SerializeField]
		private ValueChangedEventHandler _onValueChanged;

		[CustomObfuscation]
		[SerializeField]
		private ValueChangedEventHandler _onStickPositionChanged;

		[CustomObfuscation]
		[SerializeField]
		private TouchStartedEventHandler _onTouchStarted;

		[CustomObfuscation]
		[SerializeField]
		private TouchEndedEventHandler _onTouchEnded;

		[SerializeField]
		[CustomObfuscation]
		private TapEventHandler _onTap;

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement => null;

		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement => null;

		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement => null;

		public RectTransform stickTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public JoystickMode joystickMode
		{
			get
			{
				return default(JoystickMode);
			}
			set
			{
			}
		}

		public float digitalModeDeadZone
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float stickRange
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool scaleStickRange
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private StickBounds bJwZTusLjGcEamLgzowGnTtVOpOt
		{
			get
			{
				return default(StickBounds);
			}
			set
			{
			}
		}

		public AxisDirection axesToUse
		{
			get
			{
				return default(AxisDirection);
			}
			set
			{
			}
		}

		public SnapDirections snapDirections
		{
			get
			{
				return default(SnapDirections);
			}
			set
			{
			}
		}

		public bool snapStickToTouch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool centerStickOnRelease
		{
			get
			{
				return false;
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

		public bool allowTap
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float tapTimeout
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int tapDistanceLimit
		{
			get
			{
				return 0;
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

		public AxisCalibration horizontalAxisCalibration => null;

		public AxisCalibration verticalAxisCalibration => null;

		[Obsolete]
		public Axis2DCalibration deadZoneType => null;

		public Axis2DCalibration axis2DCalibration => null;

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

		private bool xmVZjoUJWiTDjMKZjjdBUzMMTwIM => false;

		internal StandaloneAxis2D JeoDAFkVAltOVqQINZSuDxwGGvnT => null;

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> hyflsGakWYPyLOtmggGdIrukDZdP => null;

		private Action<INaLVlEEKkYnjkKyaWcjcCQYeri> uyVPZaTPIjGJKKabCgQTRIXqAPLc => null;

		private int QZxLXilNaypGgRZBuiQoBHottyGi => 0;

		private RectTransform PERVNvTritjAxOJkevDzqabLFppY => null;

		private float PRZyCPNeNSAVBodpDSRtCbkaIvbB => 0f;

		internal static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IValueChangedHandler, Vector2> lmZgyJnIarviZfOvZzxbtpiJCcDU => null;

		internal static iFznRwzhmJipMjcfRBhjJauAXkUOA.EventFunction<IStickPositionChangedHandler, Vector2> DHBgoNgozsYOKsUzifGfZijMsFVQA => null;

		public event UnityAction<Vector2> ValueChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<Vector2> StickPositionChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction TouchDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction TouchUpEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction TapEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		private TouchJoystick()
		{
		}

		public Vector2 GetValue()
		{
			return default(Vector2);
		}

		public Vector2 GetRawValue()
		{
			return default(Vector2);
		}

		public void SetRawValue(Vector2 value)
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

		internal override void LLzALYpKRiDYsyFTIBJvkresqDwWA()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool iRdXbhkXKKrPUChGpkAoIswDMaDN()
		{
			return false;
		}

		internal override bool pzZuAkmltxMhZFAhATJmEgsvqjqP(GameObject P_0)
		{
			return false;
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

		private void yXvFCwguRvPGWzUcsYLKERTdoKRZA(Vector2 P_0, bool P_1, float P_2, INaLVlEEKkYnjkKyaWcjcCQYeri P_3)
		{
		}

		private void eITbiRqIzcvtzyMtnrVQwwxIcFag(Vector2 P_0, PositionType P_1, bool P_2, float P_3, INaLVlEEKkYnjkKyaWcjcCQYeri P_4)
		{
		}

		private IEnumerator eYHLOFQxNaFhuZFTErUMQxBGBpL(Vector2 P_0, PositionType P_1, float P_2, INaLVlEEKkYnjkKyaWcjcCQYeri P_3)
		{
			return null;
		}

		private void WQXJGuUNcDBFtdyHEvIDGCascPox(INaLVlEEKkYnjkKyaWcjcCQYeri P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void KlzDqOhWDaEscpTwtInUZXFgetYgb(INaLVlEEKkYnjkKyaWcjcCQYeri P_0)
		{
		}

		private void TfMWssqBnrIKOIMGruTtpLqJkuDH(INaLVlEEKkYnjkKyaWcjcCQYeri P_0)
		{
		}

		private void ewnocjnbCdATpbuVDhgTcBsizpjGb()
		{
		}

		private void BnHDOLKbUanuKgdtijCJfcEoDAFlA(int P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void egDhVENqiOmptpvGuCmdKvgAwDfc()
		{
		}

		private void tZIZiJgAAQoalmOpfhkiyBVatjyA()
		{
		}

		private void ZimENQhoONdnkMiATgBvHaarzNpaA(ref Vector2 P_0)
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

		private PointerEventData oBkawAiVTdObEHyMDFoQDrdRAZpvA(int P_0, GameObject P_1)
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

		private void TVygNHETfhPqszujRArTXpvRlvpq(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private PointerEventData KSrSTOGNRhDrOLwekzgdtyflCwNh(int P_0)
		{
			return null;
		}

		private void DFIDrBdFGXaeOuMhQIQKCqkLMkPfA()
		{
		}

		private void LoesNjgEUrYfdvEfknfJNxZeoYen(AxisDirection P_0)
		{
		}

		private void xIWWjJOuupYMQcrdMBCGCHPaXBWI(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private void IoGbCPRdLbcSdkogaRArqCgIugjmA(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private void QcjNpGrRNqqqNCrPAtddavSMTuin(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private void qbFkezCsiyAgtoKeAIvWYmFVHAOW(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private void hCxIEsOXCccCWDXSxomhaunnmOiM(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private void CkCSJVnUrjmbnlJpFGojYPMrtmYy(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private void GNYxHVvkJhjJTauMtPJSZthFgQgY(PointerEventData P_0, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_1)
		{
		}

		private void IusOvBAtCSXEzhPnHLjnVptEdmr(int P_0, Vector2 P_1, JqhjQSbOLueCKcXtNjdSinGgvOOuA P_2)
		{
		}

		private void VDahXJPMYKnASeYtoJZirWDQPxW()
		{
		}

		internal override void OnPointerUp(PointerEventData P_0)
		{
		}

		internal override void OnPointerDown(PointerEventData P_0)
		{
		}

		internal override void OnPointerEnter(PointerEventData P_0)
		{
		}

		internal override void OnPointerExit(PointerEventData P_0)
		{
		}

		internal override void OnBeginDrag(PointerEventData P_0)
		{
		}

		internal override void OnDrag(PointerEventData P_0)
		{
		}

		internal override void OnEndDrag(PointerEventData P_0)
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

		private void DioRXQKhVFSVUIyHkcQmUXTcypWb(PointerEventData P_0)
		{
		}

		private void vjSkIKYzzYorlBwUUeSyguFmTJeV(PointerEventData P_0)
		{
		}

		private void kiYAuTAdRDaAhYmNElDiyxdPqPHZ(PointerEventData P_0)
		{
		}

		private void lLFFKNPRhFapxntcuwlZTDsroWzC(Vector2 P_0)
		{
		}
	}
}
