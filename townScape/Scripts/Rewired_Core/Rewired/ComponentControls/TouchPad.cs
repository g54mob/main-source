using System;
using System.Collections.Generic;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public sealed class TouchPad : TouchInteractable, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		public enum AxisDirection
		{
			Both = 0,
			Horizontal = 1,
			Vertical = 2
		}

		public enum TouchPadMode
		{
			Delta = 0,
			ScreenPosition = 1,
			VectorFromCenter = 2,
			VectorFromInitialTouch = 3
		}

		public enum ValueFormat
		{
			Pixels = 0,
			Screen = 1,
			Physical = 2,
			Direction = 3
		}

		private class WxnJLmPStNRIqJeAbPkfgYuaUvs
		{
			private class jLsoUYlrLFVCdAPSZODsVqOjawMH
			{
				public float WKPVenZSXoiyPzXCwAMDXEKeGcNH;

				public float yXMXennmCShVeSaOLmWfTcTSTnN;

				public uint RRWaYZgueVVXRuLTbTKFpaBfoPjj;
			}

			private int VtvdyniHXEiUxeQdNOrbkOaTPHLg;

			private jLsoUYlrLFVCdAPSZODsVqOjawMH[] swZqGLDQVwEaJzgtyMuidFPNvFB;

			private int eNYqXCcMQxAcOzBcRbrXEfYGqqP;

			public WxnJLmPStNRIqJeAbPkfgYuaUvs(int maxSmoothFrames)
			{
			}

			public void tcrMMsJWJDQatucPrgBfFGyeEry(float P_0, float P_1)
			{
			}

			public Vector2 nQGZWeXAjShVoHrDPuOlIyoMmTHc()
			{
				return default(Vector2);
			}

			private void fezQtyVmaWIxOgnXuMNkgzjoiMg()
			{
			}

			private static int DXfyozpiVrrbPooDRQylfpsyrdm(int P_0, int P_1)
			{
				return 0;
			}

			private int yWwosQVdeesOTTeNajVJBYqbVFQ(int P_0, int P_1)
			{
				return 0;
			}

			private static bool ytCgqoamKUgcnifIpBrvNchCheZ(uint P_0, uint P_1)
			{
				return false;
			}
		}

		[Serializable]
		public class ValueChangedEventHandler : UnityEvent<Vector2>
		{
		}

		[Serializable]
		public class TapEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class PressDownEventHandler : UnityEvent
		{
		}

		[Serializable]
		public class PressUpEventHandler : UnityEvent
		{
		}

		private const int SMOOTH_DELTA_FRAME_COUNT = 3;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _horizontalAxisCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForFloat _verticalAxisCustomControllerElement;

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementTargetSetForBoolean _tapCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private CustomControllerElementTargetSetForBoolean _pressCustomControllerElement;

		[SerializeField]
		[CustomObfuscation]
		private AxisDirection _axesToUse;

		[CustomObfuscation]
		[SerializeField]
		private TouchPadMode _touchPadMode;

		[CustomObfuscation]
		[SerializeField]
		private ValueFormat _valueFormat;

		[CustomObfuscation]
		[SerializeField]
		private bool _useInertia;

		[CustomObfuscation]
		[SerializeField]
		private float _inertiaFriction;

		[CustomObfuscation]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation]
		private bool _allowPress;

		[SerializeField]
		[CustomObfuscation]
		private float _pressStartDelay;

		[SerializeField]
		[CustomObfuscation]
		private int _pressDistanceLimit;

		[CustomObfuscation]
		[SerializeField]
		private bool _hideAtRuntime;

		[SerializeField]
		[CustomObfuscation]
		private StandaloneAxis2D _axis2D;

		[CustomObfuscation]
		[SerializeField]
		private ValueChangedEventHandler _onValueChanged;

		[SerializeField]
		[CustomObfuscation]
		private TapEventHandler _onTap;

		[CustomObfuscation]
		[SerializeField]
		private PressDownEventHandler _onPressDown;

		[SerializeField]
		[CustomObfuscation]
		private PressUpEventHandler _onPressUp;

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId;

		private int _realMousePointerId;

		[NonSerialized]
		private bool KqHBQBNHrkGLwntKsACAVNIMLBU;

		[NonSerialized]
		private bool jpHFALOLDsUlucqzzUZuYLLBnXs;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private WxnJLmPStNRIqJeAbPkfgYuaUvs _smoothDelta;

		private Dictionary<int, PointerEventData> __fakePointerEventData;

		public CustomControllerElementTargetSetForFloat horizontalAxisCustomControllerElement => null;

		public CustomControllerElementTargetSetForFloat verticalAxisCustomControllerElement => null;

		public CustomControllerElementTargetSetForBoolean tapCustomControllerElement => null;

		public CustomControllerElementTargetSetForBoolean pressCustomControllerElement => null;

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

		public TouchPadMode touchPadMode
		{
			get
			{
				return default(TouchPadMode);
			}
			set
			{
			}
		}

		public ValueFormat valueFormat
		{
			get
			{
				return default(ValueFormat);
			}
			set
			{
			}
		}

		public bool useInertia
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float inertiaFriction
		{
			get
			{
				return 0f;
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

		public bool allowPress
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float pressStartDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int pressDistanceLimit
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool hideAtRuntime
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

		public Vector2 touchStartPosition => default(Vector2);

		public Vector2 touchPosition => default(Vector2);

		public AxisCalibration horizontalAxisCalibration => null;

		public AxisCalibration verticalAxisCalibration => null;

		public Axis2DCalibration axis2DCalibration => null;

		internal StandaloneAxis2D axis2D => null;

		private int effectivePointerId => 0;

		private bool tapValue => false;

		public event UnityAction<Vector2> ValueChangedEvent
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

		public event UnityAction PressDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction PressUpEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation]
		private TouchPad()
		{
		}

		[CustomObfuscation]
		internal override void Awake()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		internal override bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		internal override void PSFeJyfveNnRLRnWPckAdcFQFXH()
		{
		}

		internal override void ttJAqkHGCfTssfJpreeBeSfOQEJn()
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

		private void kckhtUMxbCHYHtoyNtsHEKeNtSU()
		{
		}

		private void WolZobJnwPopqyRPVJVbYSmndVK()
		{
		}

		private void SQHoHRQkTbaBPrHFpatgdFHUpqd(AxisDirection P_0)
		{
		}

		private void veTfMrfLMUfzJzOHRBFRkMnqBWO()
		{
		}

		private void ismQRpWdZWQpMdIKZMnosoFMPci()
		{
		}

		private void lxoNYAwUyBympiynxfTdEgSjCfG()
		{
		}

		private void udygwKlCySwfInTwyGqHGEFbeIed()
		{
		}

		private void QLWgmfJqgZaSXOyAOWWuUsRwmiN(ref Vector2 P_0)
		{
		}

		private void jUNqIIQVXeSPvoumOFiwKknMcblK(ref Vector2 P_0)
		{
		}

		private void cdIjvoTdfXSOVfIOMMozkOOgHsRA()
		{
		}

		private Vector2 mGqIgpqCcPWrjkDrdpdfZsEXQSc(Vector2 P_0)
		{
			return default(Vector2);
		}

		private void EvTCadEoXPSzjYhZaWJMVdxDbHvC(bool P_0)
		{
		}

		private void kfvnrjqaEfeRuayXHYKbpmJKYwR(PointerEventData P_0)
		{
		}

		private void DxjcxzzqjvxZZegCnKBKoKmijVm(PointerEventData P_0)
		{
		}

		private void DfGSlmXfLslFdShfJolWIzSoPvh(PointerEventData P_0)
		{
		}

		private void preHHVyWSelnFiIdNqLbeHrxdpP(PointerEventData P_0)
		{
		}

		private void TAPiNRthJWADaabtiEUIPBfPOAra(int P_0, Vector2 P_1)
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

		private PointerEventData JCQxxuuzprIUaDcOjSsSZGfJObS(int P_0)
		{
			return null;
		}
	}
}
