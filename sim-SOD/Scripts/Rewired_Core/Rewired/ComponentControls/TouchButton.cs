using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[AddComponentMenu("Rewired/Touch Button")]
	[DisallowMultipleComponent]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum VbFGgwuAtEFvhtffNmqgjCzXIef
		{
			bANLksuTeREfmxvNVHxsLpYEtSv = 0,
			KqSQWMcOlEJLiuOGEQUnJyKavcL = 1,
			tRJXGTLVEZzBBPJirdFducUlxUF = 2
		}

		private enum LaDankEdwPQBrQufUNZJgnIHOMzC
		{
			mnuFxKgqikbGDTkpdhEJoVZzZrS = 0,
			IcqjulHBBVWXQLycuXudqviHAnV = 1
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

		private sealed class FOlPZskPmKXqZAlwGxdTtohSWAy : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			public TouchButton OLVemnFdjzUkQSlFFFIOsrknazt;

			public Vector2 IbjmykmYJzqFxHFANcxtDkoDUSwi;

			public PositionType CWrvEDLHLdKvNcuVHDpaDhvRhm;

			public float LhPQVnmnGLLUdiWnyOVphnKuJcD;

			public VbFGgwuAtEFvhtffNmqgjCzXIef dzDHtyuFrCketmFXvmZpIfivvaR;

			public RectTransform yTppLgIgoyLvCFBwvcdOpEPFLQP;

			public Vector2 TMhCDLRTrrcBvdyvVKxmNyRvIdTb;

			public float ETWlXQLIQAILnXbikTPfWAzmFwMe;

			public float lLrdXWWfJMGUGFWCWFNRrbJuZzQ;

			public float deRcoYfpRsxKABEomabXugppXtGO;

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
			public FOlPZskPmKXqZAlwGxdTtohSWAy(int _003C_003E1__state)
			{
			}
		}

		private const float DvzYdiJEHwcopvVgfihooVubAzGB = 20f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement;

		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ButtonType _buttonType;

		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		private bool _stayActiveOnSwipeOut;

		[CustomObfuscation(rename = false)]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		private bool _useDigitalAxisSimulation;

		[FieldRange(0f, float.PositiveInfinity)]
		[SerializeField]
		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisGravity;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useTouchRegionOnly;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		private bool _moveToTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		private bool _returnOnRelease;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		private bool _followTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private bool _animateOnMoveToTouch;

		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private float _moveToTouchSpeed;

		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnReturn;

		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[Range(0f, 20f)]
		[SerializeField]
		private float _returnSpeed;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _manageRaycasting;

		private float JtBdnsjLfkIyqHxcFWzsjflfZDh;

		private float ClbKqaYyqPmgVoGmIskpPWidJew;

		private TouchRegion SKftbNUrmRetSjZyCgyxCDwmLLn;

		private Vector2 uDWXsQSLyFIyxrInMFhdMQpOeEh;

		private bool oMbCGPFtIFnhpBRfpCDTVIWFmcE;

		private bool hbHUGhmRYQmnbVugqUQNEWIcmbt;

		private VbFGgwuAtEFvhtffNmqgjCzXIef tQHtTCtBOcJIvEpzGFInBjPSFdv;

		private int dQfZthCKUDbAJdyasJadPGJqkASS;

		private int QPxfMBEQXZavEXZQCxMVFkaEwyJe;

		[NonSerialized]
		private bool NyqjlerkFIBOqcrEsbpspnhzlBWn;

		[NonSerialized]
		private bool iYqRpkmMnUjFyaotbVhGmoqkshir;

		private IEnumerator YJDFAFgpitbOvUovaUnLkZQtrsiF;

		private jylERTQxpaiRjkKARAhcjpqGxaxX EUJkvBWqXeOfbgZvFWKXljeeFIr;

		private Action<VbFGgwuAtEFvhtffNmqgjCzXIef> wjxbkteXgJWSzkXenZrkAvXJHMqt;

		private Action<VbFGgwuAtEFvhtffNmqgjCzXIef> NFgDYaGqaAUCCdPKJYbPNpsqgoN;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the axis value changes.")]
		private AxisValueChangedEventHandler _onAxisValueChanged;

		[Tooltip("Event sent when the button value changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ButtonValueChangedEventHandler _onButtonValueChanged;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		private ButtonDownEventHandler _onButtonDown;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the button is released.")]
		private ButtonUpEventHandler _onButtonUp;

		private Dictionary<int, PointerEventData> PwmLbzkGhilqkRqjAxmyvecVewp;

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

		private Action<VbFGgwuAtEFvhtffNmqgjCzXIef> moveStartedDelegate => null;

		private Action<VbFGgwuAtEFvhtffNmqgjCzXIef> moveEndedDelegate => null;

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

		private void PDLNFzXijnUybVNtvXkyxauxXqf(Vector2 P_0)
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

		internal override void UvjCYqPOLWYwPPujGcXEXxRteLL()
		{
		}

		internal override bool kCtpTQnECPegKfokmmotHswhcCLu()
		{
			return false;
		}

		internal override void iagGGZhzoHvsifYztDyhsUjnGQZ()
		{
		}

		internal override void zZvUXvigSJSyudmZqKMfzEpXBSj()
		{
		}

		internal override void ARKxKpVNqBlBYALxhmjYIBkRyuM()
		{
		}

		internal override void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		internal override void uljBdNGgTHBIuJdsRFrEMcxJEVjD()
		{
		}

		public override void ClearValue()
		{
		}

		internal override bool oehOykmIxezsoQoHcgcpCBDSNgC()
		{
			return false;
		}

		internal override bool xlXQBhwolTgrrjPRJxnvItTggCjf(GameObject gameObject)
		{
			return false;
		}

		private void dHWRsFqenYYsjsQwZgmfcNKJxQF()
		{
		}

		private void FNXczHSrUBSbmUcQHdonCQbEMXVz()
		{
		}

		private void pBHukOjiCFIjNyAwwBCGqBbTXNj()
		{
		}

		private void TrbtNmkZQgGbxTVCcPQvBiIhlgP(float P_0, bool P_1)
		{
		}

		private void wBGBzqGTZrEcQwpJyHNTOFBKiZjj()
		{
		}

		private void gqNHekGhcTfABFVnXMnCfmbBvyaX()
		{
		}

		private void bvTAFhqERolFHfOeXbNxGuHwuYYG()
		{
		}

		private void vNByGJrTFLIQqvHCIDKdHLxecUv()
		{
		}

		private bool HSRqvvegCyjDpJVNPKnfMPaKmFrw()
		{
			return false;
		}

		private void sFDLavwYsJcJVBOEMyiYZTzEAbd(TouchRegion P_0)
		{
		}

		private void ydMOTLuUPJaKhFdYXPQaQFdWZpB(TouchRegion P_0)
		{
		}

		private void HcljITlvcGFYSgRyYvsXuVqPtyPI()
		{
		}

		private void cjlgHfaqFHAAcWDYfGbTIBcurrGB(Vector2 P_0, bool P_1, float P_2, VbFGgwuAtEFvhtffNmqgjCzXIef P_3)
		{
		}

		private void aVLsCIcObIbNHyLDoDTDyrRZFGh(Vector2 P_0, PositionType P_1, bool P_2, float P_3, VbFGgwuAtEFvhtffNmqgjCzXIef P_4)
		{
		}

		private IEnumerator cxAExRZyplelZsbrSIuHSpGECzgg(Vector2 P_0, PositionType P_1, float P_2, VbFGgwuAtEFvhtffNmqgjCzXIef P_3)
		{
			return null;
		}

		private void AcJYRrKmXpLRHfxuBLJUYLineAj(VbFGgwuAtEFvhtffNmqgjCzXIef P_0, Vector2 P_1, PositionType P_2)
		{
		}

		private void QVvIjJKIFCPcYTJYcfXRDjktCKBI(VbFGgwuAtEFvhtffNmqgjCzXIef P_0)
		{
		}

		private void ZRGJYtigfXYhaClokSUsncTCBzW(VbFGgwuAtEFvhtffNmqgjCzXIef P_0)
		{
		}

		private void TYDILUlWIIDcktJLpqsKiTpzJxS(int P_0)
		{
		}

		private void kInunodlKFGFHwhlSGAGjNDgrMwU()
		{
		}

		private void qKybyEPGwquHThgDXJohAlSJcPG()
		{
		}

		private bool GKQUlXDPDUvzyruDvuKxSQFYHjB()
		{
			return false;
		}

		private void sXRDhAKcRFVqpujuicGMzkcbLvk()
		{
		}

		private bool RIWUjwTZXIFAvqiJqzsRmjKEWiX(int P_0)
		{
			return false;
		}

		private PointerEventData zACIGkzGfCcuTSbrwFEaWnJTawo(int P_0, GameObject P_1)
		{
			return null;
		}

		private PointerEventData yJILvFKbUrQLqAqCnfxIaCOgTVXa(int P_0)
		{
			return null;
		}

		private void UEsNkFZcANbClMtwGXPrJWRikHg(PointerEventData P_0)
		{
		}

		private PointerEventData AftRdPGjJPVnaLvMfBHcloCgtOW(int P_0)
		{
			return null;
		}

		private void rwILpGMLcDAnggJJPjnFKJmjkkV(PointerEventData P_0, LaDankEdwPQBrQufUNZJgnIHOMzC P_1)
		{
		}

		private void KGnHQyTRRAYZywAdMqcQwDPfPo(PointerEventData P_0, LaDankEdwPQBrQufUNZJgnIHOMzC P_1)
		{
		}

		private void KPfYwTlNHSewjMThVCToyjhHCFha(PointerEventData P_0, LaDankEdwPQBrQufUNZJgnIHOMzC P_1)
		{
		}

		private void oPNajkGScOUePgaQHAZNNGaQujNJ(PointerEventData P_0, LaDankEdwPQBrQufUNZJgnIHOMzC P_1)
		{
		}

		private void UTotXmLEdaIKmhEhaohsrCOmSKj(int P_0, Vector2 P_1, LaDankEdwPQBrQufUNZJgnIHOMzC P_2)
		{
		}

		private void DVJysEZaYwGncINoyinUaozQRsmT()
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

		private void qxUePgSmbriVnmKbwjjsXVpLkf(PointerEventData P_0)
		{
		}

		private void DbftSEplregGQKuhvGOnxKVWWDb(PointerEventData P_0)
		{
		}

		private void PZnTNieIOWlqyiUkpEZOUNXqjGN(PointerEventData P_0)
		{
		}

		private void YashNLzgQJJpLoBLcZNHwLUnCrc(PointerEventData P_0)
		{
		}

		private void jaLAWOFyRlcwDvbTjWRIBekgFAk(float P_0)
		{
		}

		private void bRrfAGDFhyPaNRUfoGRjnynWdKD(bool P_0)
		{
		}

		private void aTTnZmTDcRmOnaQfuAZLdybIIBBk()
		{
		}

		private void ZaVbDhrmswuoFGTkySnUAjxCytn()
		{
		}
	}
}
