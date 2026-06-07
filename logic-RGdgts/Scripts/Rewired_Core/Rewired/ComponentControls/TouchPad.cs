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
	public sealed class TouchPad : TouchInteractable, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
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

		private class TUKJsddbcTxMwHpEydWUABWUVbfp
		{
			private class afHGOCtXrFhYhcAPDpjjfDkQBcrG
			{
				public float VOqXZFpkfqxthtpirTSkjkUIXYWh;

				public float tHnucPZgaWBgGGxeQZvKhnVcDwSp;

				public uint WIrjufOYMVKYdFHdgPrcSgNBuLui;
			}

			private int AJScDFlQbIrXHSwVGeoAcPqdSqUT;

			private afHGOCtXrFhYhcAPDpjjfDkQBcrG[] vgykPhbigkeVbdfSvoLHgDXxKMQQA;

			private int hXbwTkGIglELkIvAOJmgZwYkqPGIA;

			public TUKJsddbcTxMwHpEydWUABWUVbfp(int P_0)
			{
			}

			public void oZQllQxQuNaPXytzirxUjNaKuQtr(float P_0, float P_1)
			{
			}

			public Vector2 yujbtInuPIYsMrSpSBKSIWawqnAJ()
			{
				return default(Vector2);
			}

			private void ovUSnKlBAKqCwqEnvAOZENnIGvhR()
			{
			}

			private static int OaETxTTojrgKxiFtMBnUDJmIcYrfA(int P_0, int P_1)
			{
				return 0;
			}

			private int bhXRTwznAuglvLevxyiopjiBoaNS(int P_0, int P_1)
			{
				return 0;
			}

			private static bool rQfONOQcCWixZwPycxGWxLhcNQQn(uint P_0, uint P_1)
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

		[CustomObfuscation]
		[SerializeField]
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

		[SerializeField]
		[CustomObfuscation]
		private TouchPadMode _touchPadMode;

		[SerializeField]
		[CustomObfuscation]
		private ValueFormat _valueFormat;

		[SerializeField]
		[CustomObfuscation]
		private bool _useInertia;

		[CustomObfuscation]
		[SerializeField]
		private float _inertiaFriction;

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
		private bool _allowPress;

		[SerializeField]
		[CustomObfuscation]
		private float _pressStartDelay;

		[CustomObfuscation]
		[SerializeField]
		private int _pressDistanceLimit;

		[SerializeField]
		[CustomObfuscation]
		private bool _hideAtRuntime;

		[SerializeField]
		[CustomObfuscation]
		private StandaloneAxis2D _axis2D;

		[SerializeField]
		[CustomObfuscation]
		private ValueChangedEventHandler _onValueChanged;

		[SerializeField]
		[CustomObfuscation]
		private TapEventHandler _onTap;

		[CustomObfuscation]
		[SerializeField]
		private PressDownEventHandler _onPressDown;

		[CustomObfuscation]
		[SerializeField]
		private PressUpEventHandler _onPressUp;

		private bool _useXAxis;

		private bool _useYAxis;

		private int _pointerId;

		private int _realMousePointerId;

		[NonSerialized]
		private bool HNeekbdvHcSGCkhkngTpwdUwueLRA;

		[NonSerialized]
		private bool aMiVitsTbcaHUuBPegFBByVtJKdtA;

		private bool _pointerDownIsFake;

		private Vector2 _touchStartPosition;

		private float _touchStartTime;

		private Vector3 _currentCenter;

		private Vector2 _previousTouchPosition;

		private int _lastTapFrame;

		private bool _isEligibleForTap;

		private bool _isEligibleForPress;

		private bool _pressValue;

		private TUKJsddbcTxMwHpEydWUABWUVbfp _smoothDelta;

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

		internal StandaloneAxis2D JeoDAFkVAltOVqQINZSuDxwGGvnT => null;

		private int QZxLXilNaypGgRZBuiQoBHottyGi => 0;

		private bool xmVZjoUJWiTDjMKZjjdBUzMMTwIM => false;

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

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			return false;
		}

		internal override void IghfPvNUXsucbZILFgzLRWwwGmUeA()
		{
		}

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
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

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
		}

		private void DFIDrBdFGXaeOuMhQIQKCqkLMkPfA()
		{
		}

		private void LoesNjgEUrYfdvEfknfJNxZeoYen(AxisDirection P_0)
		{
		}

		private void egDhVENqiOmptpvGuCmdKvgAwDfc()
		{
		}

		private void jPLOzLuCVMOZofmyWbFSQsyqPalO()
		{
		}

		private void yuNqaeAdcDxtFyGSonqAoowREnDdA()
		{
		}

		private void tZIZiJgAAQoalmOpfhkiyBVatjyA()
		{
		}

		private void ZimENQhoONdnkMiATgBvHaarzNpaA(ref Vector2 P_0)
		{
		}

		private void qxoxxkadvsEkFyCJRnTZidOwUrqd(ref Vector2 P_0)
		{
		}

		private void jujYCShJlVPdbjBwRlPIUkQCBMIK()
		{
		}

		private Vector2 tXNPALAQdRqYPaHVmsPMbOpxtGdF(Vector2 P_0)
		{
			return default(Vector2);
		}

		private void LlqBBPYhxZcqLjQzrUOzHnxjYumY(bool P_0)
		{
		}

		private void xIWWjJOuupYMQcrdMBCGCHPaXBWI(PointerEventData P_0)
		{
		}

		private void IoGbCPRdLbcSdkogaRArqCgIugjmA(PointerEventData P_0)
		{
		}

		private void QcjNpGrRNqqqNCrPAtddavSMTuin(PointerEventData P_0)
		{
		}

		private void qbFkezCsiyAgtoKeAIvWYmFVHAOW(PointerEventData P_0)
		{
		}

		private void IusOvBAtCSXEzhPnHLjnVptEdmr(int P_0, Vector2 P_1)
		{
		}

		private void VDahXJPMYKnASeYtoJZirWDQPxW()
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

		private PointerEventData KSrSTOGNRhDrOLwekzgdtyflCwNh(int P_0)
		{
			return null;
		}
	}
}
