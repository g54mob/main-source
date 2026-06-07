using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

		private enum FaugZzXAwImbZpKilAxZRuSwyti
		{
			kWwOvXSVQftLstpRDMaKvWdpfrv = 0,
			BhlggfALXeCHqaSIOjQPvpUDuzL = 1,
			wqcbhtCrfxNgDYLLdEEPZQrIAfVU = 2
		}

		private enum USEdoaHnPcHcrNVYswvGHWbMzVM
		{
			nHPtsYQbEDXgmhYrndYheGAnOz = 0,
			ZBZWYgvtnoCSPewqyVBkKJgohP = 1
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

		private sealed class tOEaArdqvrcJHQfkJoCIdAUrPcEi : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			public TouchJoystick TiaUIShtPVkFOKyDFxywSfPUjyv;

			public Vector2 XtSOgFUidBAYtZiIVWILWyBaOQc;

			public PositionType LQlGFbCflnOozLLyPpePESIaEZkz;

			public float WKertIOlspTQdeQxowWRBMhJcAJ;

			public FaugZzXAwImbZpKilAxZRuSwyti igoHlLKNBsDzfiNFnGgNabDCtiP;

			public RectTransform xyBrrlmtEBqgphWCAKhLZSQokFE;

			public Vector2 JvkTjQkqRWuchOqYvPBQrGDEUJg;

			public float zjsXgzacyJjVYLyPyxZEDKBTHtL;

			public float MtYyUFlRoSUXbXtwQKeUsQdmbMd;

			public float cHQUgpBKuakNoiVHyQfHQyDLBoM;

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
			public tOEaArdqvrcJHQfkJoCIdAUrPcEi(int _003C_003E1__state)
			{
			}
		}

		private const float MAX_MOVE_SPEED = 20f;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private RectTransform _stickTransform;

		[CustomObfuscation]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation]
		private bool _snapStickToTouch;

		[SerializeField]
		[CustomObfuscation]
		private bool _centerStickOnRelease;

		[CustomObfuscation]
		[SerializeField]
		private StandaloneAxis2D _axis2D;

		[SerializeField]
		[CustomObfuscation]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation]
		private bool _stayActiveOnSwipeOut;

		[SerializeField]
		[CustomObfuscation]
		private bool _allowTap;

		[CustomObfuscation]
		[SerializeField]
		private float _tapTimeout;

		[CustomObfuscation]
		[SerializeField]
		private int _tapDistanceLimit;

		[CustomObfuscation]
		[SerializeField]
		private TouchRegion _touchRegion;

		[SerializeField]
		[CustomObfuscation]
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

		[CustomObfuscation]
		[SerializeField]
		private bool _animateOnMoveToTouch;

		[CustomObfuscation]
		[SerializeField]
		private float _moveToTouchSpeed;

		[SerializeField]
		[CustomObfuscation]
		private bool _animateOnReturn;

		[CustomObfuscation]
		[SerializeField]
		private float _returnSpeed;

		[SerializeField]
		[CustomObfuscation]
		private bool _manageRaycasting;

		private bool _useXAxis;

		private bool _useYAxis;

		private jiAimQXWlXowirDyUeIMGqAsZDV.HierarchyEventHelper<IValueChangedHandler, Vector2> _hierarchyValueChangedHandlers;

		private jiAimQXWlXowirDyUeIMGqAsZDV.HierarchyEventHelper<IStickPositionChangedHandler, Vector2> _hierarchyStickPositionChangedHandlers;

		private TouchRegion _workingTouchRegion;

		private Vector2 _origAnchoredPosition;

		private Vector2 _origStickAnchoredPosition;

		private Vector2 _lastPressAnchoredPosition;

		private bool _isMoving;

		private bool _isMovedFromDefaultPosition;

		private FaugZzXAwImbZpKilAxZRuSwyti _moveDirection;

		private int _pointerId;

		private int _realMousePointerId;

		[NonSerialized]
		private bool KqHBQBNHrkGLwntKsACAVNIMLBU;

		[NonSerialized]
		private bool jpHFALOLDsUlucqzzUZuYLLBnXs;

		private bool _pointerDownIsFake;

		private Vector2 _lastPressStartingValue;

		private USEdoaHnPcHcrNVYswvGHWbMzVM _lastClaimSource;

		private float _touchStartTime;

		private Vector2 _touchStartPosition;

		private IEnumerator _coroutineMove;

		private yGgxgyRZUBKpiMEJkOOhHBUlev _imageRaycastHelper;

		private int _calculatedStickRange_lastUpdatedFrame;

		private int _lastTapFrame;

		private bool _isEligibleForTap;

		private float __calculatedStickRange_cachedValue;

		private Action<FaugZzXAwImbZpKilAxZRuSwyti> __moveStartedDelegate;

		private Action<FaugZzXAwImbZpKilAxZRuSwyti> __moveEndedDelegate;

		[SerializeField]
		[CustomObfuscation]
		private ValueChangedEventHandler _onValueChanged;

		[SerializeField]
		[CustomObfuscation]
		private ValueChangedEventHandler _onStickPositionChanged;

		[SerializeField]
		[CustomObfuscation]
		private TouchStartedEventHandler _onTouchStarted;

		[SerializeField]
		[CustomObfuscation]
		private TouchEndedEventHandler _onTouchEnded;

		[SerializeField]
		[CustomObfuscation]
		private TapEventHandler _onTap;

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		private static jiAimQXWlXowirDyUeIMGqAsZDV.EventFunction<IValueChangedHandler, Vector2> __valueChangedHandlerDelegate;

		private static jiAimQXWlXowirDyUeIMGqAsZDV.EventFunction<IStickPositionChangedHandler, Vector2> __stickPositionChangedHandlerDelegate;

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

		private StickBounds stickBounds
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

		private bool tapValue => false;

		internal StandaloneAxis2D axis2D => null;

		private Action<FaugZzXAwImbZpKilAxZRuSwyti> moveStartedDelegate => null;

		private Action<FaugZzXAwImbZpKilAxZRuSwyti> moveEndedDelegate => null;

		private int effectivePointerId => 0;

		private RectTransform touchReferenceTransform => null;

		private float calculatedStickRange => 0f;

		internal static jiAimQXWlXowirDyUeIMGqAsZDV.EventFunction<IValueChangedHandler, Vector2> valueChangedHandlerDelegate => null;

		internal static jiAimQXWlXowirDyUeIMGqAsZDV.EventFunction<IStickPositionChangedHandler, Vector2> stickPositionChangedHandlerDelegate => null;

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

		internal override void EUAcigCVtcdNGimfhNGKNDeeSwJn()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool dBCYcNAjoSqmwCdqowZTiusxKJK()
		{
			return false;
		}

		internal override bool wByjfGONJngXzFPsNQZLuqsRAef(GameObject P_0)
		{
			return false;
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

		private void lBQcfSAIvteHiOMCxZQfpjHBFnWa(Vector2 P_0, bool P_1, float P_2, FaugZzXAwImbZpKilAxZRuSwyti P_3)
		{
		}

		private void nrunSlECDmhyNBsJeWmrqGkmPHpM(Vector2 P_0, PositionType P_1, bool P_2, float P_3, FaugZzXAwImbZpKilAxZRuSwyti P_4)
		{
		}

		private IEnumerator tDxHouhbBVejXDatWoXphgfjcnqd(Vector2 P_0, PositionType P_1, float P_2, FaugZzXAwImbZpKilAxZRuSwyti P_3)
		{
			return null;
		}

		private void LnuxqQsvAZUKZrIpVUgioYuSloh(FaugZzXAwImbZpKilAxZRuSwyti P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void LNWHMamEpyGxOPREoPuxjHVIGEP(FaugZzXAwImbZpKilAxZRuSwyti P_0)
		{
		}

		private void UbpubYKwTtJTwSiecfjUgFynXVUr(FaugZzXAwImbZpKilAxZRuSwyti P_0)
		{
		}

		private void dmKBmHHHwfWsZsdpSlycxaVZSDu()
		{
		}

		private void QQizmlJFawbwuxZNlXtgYHKEbAU(int P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void veTfMrfLMUfzJzOHRBFRkMnqBWO()
		{
		}

		private void udygwKlCySwfInTwyGqHGEFbeIed()
		{
		}

		private void QLWgmfJqgZaSXOyAOWWuUsRwmiN(ref Vector2 P_0)
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

		private PointerEventData fFJFVoxvdvapyoEcEjvlPEhnCcqE(int P_0, GameObject P_1)
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

		private void KnXwhSqFfblaCjHKOmUinfShEqu(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private PointerEventData JCQxxuuzprIUaDcOjSsSZGfJObS(int P_0)
		{
			return null;
		}

		private void WolZobJnwPopqyRPVJVbYSmndVK()
		{
		}

		private void SQHoHRQkTbaBPrHFpatgdFHUpqd(AxisDirection P_0)
		{
		}

		private void kfvnrjqaEfeRuayXHYKbpmJKYwR(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private void DxjcxzzqjvxZZegCnKBKoKmijVm(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private void DfGSlmXfLslFdShfJolWIzSoPvh(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private void preHHVyWSelnFiIdNqLbeHrxdpP(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private void mSWrAIsapkVesXyHedcEOIvHvkt(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private void RbbsirBOPlkALvnDWlGSmGSTHVT(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private void LqbqIbZspnSktuSqwEolzpjjnvf(PointerEventData P_0, USEdoaHnPcHcrNVYswvGHWbMzVM P_1)
		{
		}

		private void TAPiNRthJWADaabtiEUIPBfPOAra(int P_0, Vector2 P_1, USEdoaHnPcHcrNVYswvGHWbMzVM P_2)
		{
		}

		private void UCuhEhhpmUBeyHWoyYCwAQUxCkas()
		{
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
		}

		internal override void OnDrag(PointerEventData eventData)
		{
		}

		internal override void OnEndDrag(PointerEventData eventData)
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

		private void SQVEibarLZmRtMPUjgpnaoTUPVgA(PointerEventData P_0)
		{
		}

		private void mAnbSkgBxOwrPPgUFPfBMRlAadf(PointerEventData P_0)
		{
		}

		private void zzvJKlFGxFHNVeQtTBUNcRbfZoYp(PointerEventData P_0)
		{
		}

		private void eUkigvhovXTpDjxNlghkvfBNLFy(Vector2 P_0)
		{
		}

		[CompilerGenerated]
		private static void SQeCESKohnNExIIusQCUCSNkZqF(IValueChangedHandler P_0, Vector2 P_1)
		{
		}

		[CompilerGenerated]
		private static void DvPCEQxDUzrOBOJOKuplCdowQio(IStickPositionChangedHandler P_0, Vector2 P_1)
		{
		}
	}
}
