using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Button")]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum eKFPMqEwLqICnImjloUNsdbJFDmt
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum sOXvLwBClbqDtJxViVNomCuIdOoD
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

		private sealed class iBHCgwIxgvtlUrRxyzaAiuAanIIW : IDisposable, IEnumerator, IEnumerator<object>
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private object vjnbYLtrPMftzpjohNfommerCnGo;

			public float qkXPLxWturrcjNqpWPvEaFUuBmCI;

			public TouchButton zITtixdgVFWlEnpDnrTdnZsdTFkt;

			public PositionType rrUfjUGrrfoWdcnsvZDUrItvrupt;

			public Vector2 rSjomiQzvTwnjofCtffQbKcPrxpO;

			public eKFPMqEwLqICnImjloUNsdbJFDmt CFZgLeSNFyCLpaVLVUHQRDinORMQA;

			private RectTransform ZcjMjycqMQbiMicoFMzzHkFHNpUcA;

			private Vector2 eBtPAFhRkDeVnDxzdphBhXBjIPGE;

			private float sThSegvLXYoytahwkbwZBvrRMGmd;

			private float WGhwOCFTkqWtePPHGlMSlGcurPTu;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public iBHCgwIxgvtlUrRxyzaAiuAanIIW(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				TouchButton touchButton = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_010c;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (!(qkXPLxWturrcjNqpWPvEaFUuBmCI <= 0f))
				{
					ZcjMjycqMQbiMicoFMzzHkFHNpUcA = touchButton.DSmDnIVkfzvBzeFgEbidCWTOTVMO;
					eBtPAFhRkDeVnDxzdphBhXBjIPGE = EeDnToreLfEgTseEVjKzmWOWfvaP.IZHCYVFceYsMoERWjWPbdWmcxIXHb(ZcjMjycqMQbiMicoFMzzHkFHNpUcA, rrUfjUGrrfoWdcnsvZDUrItvrupt);
					float magnitude = (rSjomiQzvTwnjofCtffQbKcPrxpO - eBtPAFhRkDeVnDxzdphBhXBjIPGE).magnitude;
					if (!(magnitude < 0.01f))
					{
						touchButton.BLdGQGArFxqGdvcNHYEkFUAHjVJmA = true;
						sThSegvLXYoytahwkbwZBvrRMGmd = magnitude / qkXPLxWturrcjNqpWPvEaFUuBmCI;
						WGhwOCFTkqWtePPHGlMSlGcurPTu = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				touchButton.rNLYWheOSDixDWEthcZnZxDfAVaP(CFZgLeSNFyCLpaVLVUHQRDinORMQA, rSjomiQzvTwnjofCtffQbKcPrxpO, rrUfjUGrrfoWdcnsvZDUrItvrupt);
				return false;
				IL_010c:
				if (WGhwOCFTkqWtePPHGlMSlGcurPTu <= 1f)
				{
					WGhwOCFTkqWtePPHGlMSlGcurPTu += Time.unscaledDeltaTime / sThSegvLXYoytahwkbwZBvrRMGmd;
					EeDnToreLfEgTseEVjKzmWOWfvaP.HWswGCfZinnZXqMSjKXHZdJKuMuG(ZcjMjycqMQbiMicoFMzzHkFHNpUcA, Vector2.Lerp(eBtPAFhRkDeVnDxzdphBhXBjIPGE, rSjomiQzvTwnjofCtffQbKcPrxpO, Mathf.SmoothStep(0f, 1f, WGhwOCFTkqWtePPHGlMSlGcurPTu)), rrUfjUGrrfoWdcnsvZDUrItvrupt);
					vjnbYLtrPMftzpjohNfommerCnGo = null;
					hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
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

		private const float cJbrSivpyKLjdUqqZdhVhCifOSRG = 20f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		private ButtonType _buttonType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		private bool _stayActiveOnSwipeOut = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		private bool _useDigitalAxisSimulation;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		[SerializeField]
		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		private float _digitalAxisGravity = 3f;

		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		[SerializeField]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		private float _digitalAxisSensitivity = 3f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		private StandaloneAxis _axis = new StandaloneAxis();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		private TouchRegion _touchRegion;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		private bool _useTouchRegionOnly = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		private bool _moveToTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		private bool _returnOnRelease = true;

		[SerializeField]
		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private bool _animateOnMoveToTouch = true;

		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		private float _moveToTouchSpeed = 2f;

		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnReturn = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		private float _returnSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		private bool _manageRaycasting = true;

		private float cmFFzsLYTEXmiCMgljVBoAtbwVwE;

		private float rcfeOggzOzZyHRHkumJOAnsnTpjj;

		private TouchRegion hjhFfdcmBnFRdQMBsLiBCPBDoyUpc;

		private Vector2 ZSDeJubyxALfipKYJjBCGNCChTVWB;

		private bool BLdGQGArFxqGdvcNHYEkFUAHjVJmA;

		private bool MsDGhnErgkEAhuNiSEmkLyWmGCkj;

		private eKFPMqEwLqICnImjloUNsdbJFDmt ACRbjKBTvSxelRxnulFOUSnStesQA;

		private int QEhzUveeThteHBoKWekUBZOyrUTe = int.MinValue;

		private int zdIATkaxxKXIwrYmSRirKuGRFKj = int.MinValue;

		[NonSerialized]
		private bool qQqrGmXxzubkmCaMCrOVuSrdktRh;

		[NonSerialized]
		private bool PPobDgSULmsGqZojTdFrxnegWsbI;

		private IEnumerator bkJWPITInXfdbRjcOngeCAblJfnf;

		private StcRXHeXGKmrcfQEptFjeyDpLqUb xOTlaPqvhUsfbXrvrFUwsuykRgoM = new StcRXHeXGKmrcfQEptFjeyDpLqUb();

		private Action<eKFPMqEwLqICnImjloUNsdbJFDmt> XLdahnrYHbxhdswNLpMTgBVLzLvD;

		private Action<eKFPMqEwLqICnImjloUNsdbJFDmt> cMobCcsSUaSjIQXOnlnwYlceGRWCA;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the axis value changes.")]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button value changes.")]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is pressed.")]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is released.")]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> sFuvDnANVAjUkyLjajdXiayLATcFA;

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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (xwKXEXrKdcGMyfKaNNgUPxYUBiSkA())
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
						CCHQPPVxVhbVaICAgGECKBdadleG();
					}
					else
					{
						xOTlaPqvhUsfbXrvrFUwsuykRgoM.wJjPIIRJfHhEbGedUconecGfiwzgB();
					}
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return QEhzUveeThteHBoKWekUBZOyrUTe;
			}
			set
			{
				QEhzUveeThteHBoKWekUBZOyrUTe = value;
			}
		}

		public bool hasPointer => QEhzUveeThteHBoKWekUBZOyrUTe != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<eKFPMqEwLqICnImjloUNsdbJFDmt> moveStartedDelegate
		{
			get
			{
				if (XLdahnrYHbxhdswNLpMTgBVLzLvD == null)
				{
					return XLdahnrYHbxhdswNLpMTgBVLzLvD = rohjiReAvoRsMeYYIHBkAAodkfIr;
				}
				return XLdahnrYHbxhdswNLpMTgBVLzLvD;
			}
		}

		private Action<eKFPMqEwLqICnImjloUNsdbJFDmt> moveEndedDelegate
		{
			get
			{
				if (cMobCcsSUaSjIQXOnlnwYlceGRWCA == null)
				{
					return cMobCcsSUaSjIQXOnlnwYlceGRWCA = acYSVxCyBhnzsnboYXCXymLCueHR;
				}
				return cMobCcsSUaSjIQXOnlnwYlceGRWCA;
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
				return cmFFzsLYTEXmiCMgljVBoAtbwVwE;
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
				return rcfeOggzOzZyHRHkumJOAnsnTpjj;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (QEhzUveeThteHBoKWekUBZOyrUTe == int.MinValue)
				{
					return int.MinValue;
				}
				if (zdIATkaxxKXIwrYmSRirKuGRFKj != int.MinValue)
				{
					return zdIATkaxxKXIwrYmSRirKuGRFKj;
				}
				return QEhzUveeThteHBoKWekUBZOyrUTe;
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
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			qATzXzjIGXRhrijPPfRPyscnGscS(base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.anchoredPosition);
		}

		private void qATzXzjIGXRhrijPPfRPyscnGscS(Vector2 P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				ZSDeJubyxALfipKYJjBCGNCChTVWB = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				TRLOyCQJHeKwHJgDQHJmzyPRKosW(ZSDeJubyxALfipKYJjBCGNCChTVWB, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, eKFPMqEwLqICnImjloUNsdbJFDmt.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
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
				ZSDeJubyxALfipKYJjBCGNCChTVWB = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				XetDzXgLfjrusCzyhbGhxGxLsdqi();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
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
			base.vjhEkIpbiwZRwstmkNxqMDjviCZ();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				BfcemEvRAUDLLQwTdfsEGPCDloJEA();
				onvOBINGqdjUFcaiXkezCsHLZYRA();
				SrGWJLIINeUrhXxsdeeCnmQRNGYv();
				if (_followTouchPosition)
				{
					kqTTFWTvseTQmSdLBfqvxdlndWXDA(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!BUnNPMFoanNJCVAmWibAzWafnjUk())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
			{
				wJuChGHELKYHUkqGfCzcAspJNjWPB(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			OCbTyrEcaxLtyGXBEYyEklZHhUaE();
			_axis.AxisValueChangedEvent += KvDhOKlllDnJVQRNDmKnUouiMevO;
			_axis.ButtonValueChangedEvent += WWjCAYjKNAJZZBqrYCFQSelEwjKAA;
			_axis.ButtonDownEvent += VxTHdgbCWbcxvJlbQpNerrtCQeGs;
			_axis.ButtonUpEvent += wBwIhXbDYMXNijvVOYOOALzjPPsPA;
		}

		internal void OnUnsubscribeEvents()
		{
			tDIDrACtxdHSRUhHLVoEeNTZdDjmA();
			_axis.AxisValueChangedEvent -= KvDhOKlllDnJVQRNDmKnUouiMevO;
			_axis.ButtonValueChangedEvent -= WWjCAYjKNAJZZBqrYCFQSelEwjKAA;
			_axis.ButtonDownEvent -= VxTHdgbCWbcxvJlbQpNerrtCQeGs;
			_axis.ButtonUpEvent -= wBwIhXbDYMXNijvVOYOOALzjPPsPA;
		}

		internal void OnSetProperty()
		{
			jebsoqOBGHhJxfFgdjbRaKVujtZwA();
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		internal void OnClear()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				QEhzUveeThteHBoKWekUBZOyrUTe = int.MinValue;
				zdIATkaxxKXIwrYmSRirKuGRFKj = int.MinValue;
				qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
				PPobDgSULmsGqZojTdFrxnegWsbI = false;
				if (_returnOnRelease && MsDGhnErgkEAhuNiSEmkLyWmGCkj && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				MsDGhnErgkEAhuNiSEmkLyWmGCkj = false;
				BLdGQGArFxqGdvcNHYEkFUAHjVJmA = false;
				ACRbjKBTvSxelRxnulFOUSnStesQA = eKFPMqEwLqICnImjloUNsdbJFDmt.None;
				JMtnteXFqjeDNZdvuGWjEMRkGrdr();
				_axis.Clear();
				cmFFzsLYTEXmiCMgljVBoAtbwVwE = 0f;
				rcfeOggzOzZyHRHkumJOAnsnTpjj = 0f;
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		public override void ClearValue()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				_axis.Clear();
				cmFFzsLYTEXmiCMgljVBoAtbwVwE = 0f;
				if (UTvbNmLtOtvCXnKmzpVoOCmLyTeb)
				{
					base.yBVYaZymnHfILCjQopwadWNgxbeH.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				return false;
			}
			if (!uITeqmergHcifeDewaJvLHRSazjqA())
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
			if (base.CCRTYlKENtSVpmwZvzlIPCFobzki(gameObject))
			{
				return true;
			}
			if (hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null)
			{
				return hjhFfdcmBnFRdQMBsLiBCPBDoyUpc.gameObject == gameObject;
			}
			return false;
		}

		private void SrGWJLIINeUrhXxsdeeCnmQRNGYv()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					oHXEdFipabUUqpzQtRiUHalOIqQDA();
				}
				else
				{
					IMDEoYAFGlUfDTFSAwVrGrrFMaqbb();
				}
			}
		}

		private void oHXEdFipabUUqpzQtRiUHalOIqQDA()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += cmFFzsLYTEXmiCMgljVBoAtbwVwE;
			num = MathTools.Clamp(num, -1f, 1f);
			mvhRNsYAoUQbhyHGUBWUEuUzdZKm(num, true);
		}

		private void IMDEoYAFGlUfDTFSAwVrGrrFMaqbb()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num2 = cmFFzsLYTEXmiCMgljVBoAtbwVwE;
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
				mvhRNsYAoUQbhyHGUBWUEuUzdZKm(num4, true);
			}
		}

		private void mvhRNsYAoUQbhyHGUBWUEuUzdZKm(float P_0, bool P_1)
		{
			rcfeOggzOzZyHRHkumJOAnsnTpjj = cmFFzsLYTEXmiCMgljVBoAtbwVwE;
			cmFFzsLYTEXmiCMgljVBoAtbwVwE = P_0;
			if (P_0 != rcfeOggzOzZyHRHkumJOAnsnTpjj)
			{
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(null);
			}
			if (P_1 && P_0 != rcfeOggzOzZyHRHkumJOAnsnTpjj)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void XrWtSmtdlNVcYQBEOPCmKBQGswke()
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

		private void JiLCwugMSrHlTymdbGvprLnxbTjo()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void QCTiHbMbjMBiDhGopGJUAtTEkvFmB()
		{
			_targetCustomControllerElement.ClearElementCaches();
			onvOBINGqdjUFcaiXkezCsHLZYRA();
			CCHQPPVxVhbVaICAgGECKBdadleG();
		}

		private void CCHQPPVxVhbVaICAgGECKBdadleG()
		{
			if (_manageRaycasting)
			{
				xOTlaPqvhUsfbXrvrFUwsuykRgoM.WpiqHjRcuWGpcXTsCkpIPZokatTs(base.transform, gkLbwlKdyQwhpoLXtnCEOSsAkMqF());
			}
		}

		private bool gkLbwlKdyQwhpoLXtnCEOSsAkMqF()
		{
			if (hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void XsRcHdcMofeXXwuCaWifJSVWulmNA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				ROSzEBYmibvPrutzdqPFViLEreGs(P_0);
				P_0.PointerDownEvent += VvnEeLBQILUHLAWKLgnCOdVbIFoyA;
				P_0.PointerUpEvent += qsbKaKVpPEnEWhDnNiKSemHIDswR;
				P_0.PointerEnterEvent += cqjJduOBmiLDgBtoNPjlFUJyfnOI;
				P_0.PointerExitEvent += lzaDhFGRErVydKJHIIJajzRcpfsvB;
			}
		}

		private void ROSzEBYmibvPrutzdqPFViLEreGs(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= VvnEeLBQILUHLAWKLgnCOdVbIFoyA;
				P_0.PointerUpEvent -= qsbKaKVpPEnEWhDnNiKSemHIDswR;
				P_0.PointerEnterEvent -= cqjJduOBmiLDgBtoNPjlFUJyfnOI;
				P_0.PointerExitEvent -= lzaDhFGRErVydKJHIIJajzRcpfsvB;
			}
		}

		private void onvOBINGqdjUFcaiXkezCsHLZYRA()
		{
			if (!(hjhFfdcmBnFRdQMBsLiBCPBDoyUpc == _touchRegion))
			{
				ROSzEBYmibvPrutzdqPFViLEreGs(hjhFfdcmBnFRdQMBsLiBCPBDoyUpc);
				hjhFfdcmBnFRdQMBsLiBCPBDoyUpc = _touchRegion;
				XsRcHdcMofeXXwuCaWifJSVWulmNA(hjhFfdcmBnFRdQMBsLiBCPBDoyUpc);
			}
		}

		private void FbjbVhCqtbatwGjQFsvgGueyDSBGA(Vector2 P_0, bool P_1, float P_2, eKFPMqEwLqICnImjloUNsdbJFDmt P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = EeDnToreLfEgTseEVjKzmWOWfvaP.bxxRIiMvkpOpQMGQXOctozcixKiD(base.HtGlhojWyGbbBWmlieYRaIFDtOyfA, rectTransform, P_0);
			Vector2 pivot = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.pivot;
			Vector2 sizeDelta = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.sizeDelta;
			Vector3 localScale = base.DSmDnIVkfzvBzeFgEbidCWTOTVMO.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			TRLOyCQJHeKwHJgDQHJmzyPRKosW(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void TRLOyCQJHeKwHJgDQHJmzyPRKosW(Vector2 P_0, PositionType P_1, bool P_2, float P_3, eKFPMqEwLqICnImjloUNsdbJFDmt P_4)
		{
			if (BLdGQGArFxqGdvcNHYEkFUAHjVJmA && P_2 && ACRbjKBTvSxelRxnulFOUSnStesQA == P_4)
			{
				return;
			}
			if (BLdGQGArFxqGdvcNHYEkFUAHjVJmA && bkJWPITInXfdbRjcOngeCAblJfnf != null)
			{
				JMtnteXFqjeDNZdvuGWjEMRkGrdr();
				BLdGQGArFxqGdvcNHYEkFUAHjVJmA = false;
				ACRbjKBTvSxelRxnulFOUSnStesQA = eKFPMqEwLqICnImjloUNsdbJFDmt.None;
			}
			if (base.HtGlhojWyGbbBWmlieYRaIFDtOyfA == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.HtGlhojWyGbbBWmlieYRaIFDtOyfA.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.MEOaKmSNIwHUYDtxqlUIUZwwqRaO;
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
				bkJWPITInXfdbRjcOngeCAblJfnf = NdGGKXbALTrFNPCleIggATGIgAzeb(P_0, P_1, P_3, P_4);
				StartCoroutine(bkJWPITInXfdbRjcOngeCAblJfnf);
				ACRbjKBTvSxelRxnulFOUSnStesQA = P_4;
				MsDGhnErgkEAhuNiSEmkLyWmGCkj = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				rNLYWheOSDixDWEthcZnZxDfAVaP(P_4, P_0, P_1);
			}
		}

		private IEnumerator NdGGKXbALTrFNPCleIggATGIgAzeb(Vector2 P_0, PositionType P_1, float P_2, eKFPMqEwLqICnImjloUNsdbJFDmt P_3)
		{
			return new iBHCgwIxgvtlUrRxyzaAiuAanIIW(0)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this,
				rSjomiQzvTwnjofCtffQbKcPrxpO = P_0,
				rrUfjUGrrfoWdcnsvZDUrItvrupt = P_1,
				qkXPLxWturrcjNqpWPvEaFUuBmCI = P_2,
				CFZgLeSNFyCLpaVLVUHQRDinORMQA = P_3
			};
		}

		private void rNLYWheOSDixDWEthcZnZxDfAVaP(eKFPMqEwLqICnImjloUNsdbJFDmt P_0, Vector2 P_1, PositionType P_2)
		{
			EeDnToreLfEgTseEVjKzmWOWfvaP.HWswGCfZinnZXqMSjKXHZdJKuMuG(base.DSmDnIVkfzvBzeFgEbidCWTOTVMO, P_1, P_2);
			BLdGQGArFxqGdvcNHYEkFUAHjVJmA = false;
			ACRbjKBTvSxelRxnulFOUSnStesQA = eKFPMqEwLqICnImjloUNsdbJFDmt.None;
			switch (P_0)
			{
			case eKFPMqEwLqICnImjloUNsdbJFDmt.TowardHome:
				MsDGhnErgkEAhuNiSEmkLyWmGCkj = false;
				break;
			case eKFPMqEwLqICnImjloUNsdbJFDmt.TowardTouch:
				MsDGhnErgkEAhuNiSEmkLyWmGCkj = true;
				break;
			}
			JMtnteXFqjeDNZdvuGWjEMRkGrdr();
			moveEndedDelegate(P_0);
		}

		private void rohjiReAvoRsMeYYIHBkAAodkfIr(eKFPMqEwLqICnImjloUNsdbJFDmt P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == eKFPMqEwLqICnImjloUNsdbJFDmt.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					xOTlaPqvhUsfbXrvrFUwsuykRgoM.WpiqHjRcuWGpcXTsCkpIPZokatTs(base.transform, flag2);
				}
			}
		}

		private void acYSVxCyBhnzsnboYXCXymLCueHR(eKFPMqEwLqICnImjloUNsdbJFDmt P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == eKFPMqEwLqICnImjloUNsdbJFDmt.TowardHome)
				{
					flag = true;
					flag2 = gkLbwlKdyQwhpoLXtnCEOSsAkMqF();
				}
				if (flag)
				{
					xOTlaPqvhUsfbXrvrFUwsuykRgoM.WpiqHjRcuWGpcXTsCkpIPZokatTs(base.transform, flag2);
				}
			}
		}

		private void kqTTFWTvseTQmSdLBfqvxdlndWXDA(int P_0)
		{
			if (TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(P_0))
			{
				FbjbVhCqtbatwGjQFsvgGueyDSBGA(TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(P_0), false, 0f, eKFPMqEwLqICnImjloUNsdbJFDmt.TowardTouch);
			}
		}

		private void JMtnteXFqjeDNZdvuGWjEMRkGrdr()
		{
			if (bkJWPITInXfdbRjcOngeCAblJfnf != null)
			{
				try
				{
					StopCoroutine(bkJWPITInXfdbRjcOngeCAblJfnf);
				}
				catch
				{
				}
				bkJWPITInXfdbRjcOngeCAblJfnf = null;
			}
		}

		private void BfcemEvRAUDLLQwTdfsEGPCDloJEA()
		{
			if (hasPointer && !TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(effectivePointerId))
			{
				PointerEventData pointerEventData = dczyVDsPxnjiyyaODoPHeAYsoMJt(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					vviajNlqcdpzxjFwqPqOUALggKvH(pointerEventData);
				}
				else
				{
					ocNguSfHeUhMkjikGvvptZpSPVpP();
				}
			}
		}

		private bool xwKXEXrKdcGMyfKaNNgUPxYUBiSkA()
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

		private void ThPWHWimrlcazXyfWPofuuahDgzo()
		{
			QEhzUveeThteHBoKWekUBZOyrUTe = int.MinValue;
			zdIATkaxxKXIwrYmSRirKuGRFKj = int.MinValue;
		}

		private bool myYtwwlhtsxanLJJUsAmdAOARlCJ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (QEhzUveeThteHBoKWekUBZOyrUTe == int.MinValue)
			{
				return false;
			}
			if (QEhzUveeThteHBoKWekUBZOyrUTe == P_0)
			{
				return true;
			}
			if (TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0) && zdIATkaxxKXIwrYmSRirKuGRFKj != int.MinValue && P_0 == zdIATkaxxKXIwrYmSRirKuGRFKj)
			{
				return true;
			}
			return false;
		}

		private PointerEventData IjGPKgTPXkdFNtRxOeIZLhPNAXdfA(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = dczyVDsPxnjiyyaODoPHeAYsoMJt(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.jDjpvJxmiWZSqzgArtDxiAozBibiA(P_0);
			if (TouchInteractable.VNDmieaLiUocagPbDSxfzUBDHEdR(P_0))
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
				if (!TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0))
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

		private PointerEventData TNYrVNatiFwMytxODxgjVFEuFySR(int P_0)
		{
			PointerEventData pointerEventData = dczyVDsPxnjiyyaODoPHeAYsoMJt(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.VNDmieaLiUocagPbDSxfzUBDHEdR(P_0))
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
				if (!TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0))
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

		private void vviajNlqcdpzxjFwqPqOUALggKvH(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				TNYrVNatiFwMytxODxgjVFEuFySR(effectivePointerId);
			}
		}

		private PointerEventData dczyVDsPxnjiyyaODoPHeAYsoMJt(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (sFuvDnANVAjUkyLjajdXiayLATcFA == null)
			{
				sFuvDnANVAjUkyLjajdXiayLATcFA = new Dictionary<int, PointerEventData>();
			}
			if (!sFuvDnANVAjUkyLjajdXiayLATcFA.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				sFuvDnANVAjUkyLjajdXiayLATcFA.Add(P_0, value);
				if (TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0))
				{
					PointerEventData.InputButton button;
					switch (P_0)
					{
					case -1:
						button = PointerEventData.InputButton.Left;
						break;
					case -2:
						button = PointerEventData.InputButton.Right;
						break;
					case -3:
						button = PointerEventData.InputButton.Middle;
						break;
					default:
						throw new NotImplementedException();
					}
					value.button = button;
				}
			}
			return value;
		}

		private void QFKOXEymAtfzaXbJhAtiDSsrpLGX(PointerEventData P_0, sOXvLwBClbqDtJxViVNomCuIdOoD P_1)
		{
			if (!hasPointer || myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				if (uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable())
				{
					zbyGnibPBSirsUMdWdhZwaIygfajA(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void jXYdNAjblrCnDXVQHikRFJVkFajbc(PointerEventData P_0, sOXvLwBClbqDtJxViVNomCuIdOoD P_1)
		{
			if ((!hasPointer || myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId)) && !TouchInteractable.KPVKeHyDuDGRnEhncMacOuyMIqYk(effectivePointerId))
			{
				ocNguSfHeUhMkjikGvvptZpSPVpP();
				base.OnPointerUp(P_0);
			}
		}

		private void jFpyRRTzQaTGpbtgzHIZrldBeWud(PointerEventData P_0, sOXvLwBClbqDtJxViVNomCuIdOoD P_1)
		{
			if (hasPointer && !myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags;
			switch (P_1)
			{
			case sOXvLwBClbqDtJxViVNomCuIdOoD.Local:
				mouseButtonFlags = base.allowedMouseButtons;
				break;
			case sOXvLwBClbqDtJxViVNomCuIdOoD.TouchRegion:
				mouseButtonFlags = _touchRegion.allowedMouseButtons;
				break;
			default:
				throw new NotImplementedException();
			}
			if (_activateOnSwipeIn && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && (!flag || TouchInteractable.tIvoXXrIMIwvUwCpDxwPcEyiNtFC(mouseButtonFlags)) && !qQqrGmXxzubkmCaMCrOVuSrdktRh)
			{
				if (flag)
				{
					if (TouchInteractable.xKpthjOvWrGLEYZzckNkzUxWiphi(mouseButtonFlags, out var num))
					{
						zdIATkaxxKXIwrYmSRirKuGRFKj = num;
					}
					else
					{
						zdIATkaxxKXIwrYmSRirKuGRFKj = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject;
				switch (P_1)
				{
				case sOXvLwBClbqDtJxViVNomCuIdOoD.Local:
					gameObject = base.gameObject;
					break;
				case sOXvLwBClbqDtJxViVNomCuIdOoD.TouchRegion:
					gameObject = hjhFfdcmBnFRdQMBsLiBCPBDoyUpc.gameObject;
					break;
				default:
					throw new NotImplementedException();
				}
				PointerEventData pointerEventData = IjGPKgTPXkdFNtRxOeIZLhPNAXdfA((zdIATkaxxKXIwrYmSRirKuGRFKj != int.MinValue) ? zdIATkaxxKXIwrYmSRirKuGRFKj : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					QFKOXEymAtfzaXbJhAtiDSsrpLGX(pointerEventData, P_1);
				}
			}
			PPobDgSULmsGqZojTdFrxnegWsbI = true;
		}

		private void VRPzeteEbsZCPDMfbJbyNayEMNCI(PointerEventData P_0, sOXvLwBClbqDtJxViVNomCuIdOoD P_1)
		{
			if (hasPointer && !myYtwwlhtsxanLJJUsAmdAOARlCJ(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && qQqrGmXxzubkmCaMCrOVuSrdktRh)
			{
				ocNguSfHeUhMkjikGvvptZpSPVpP();
			}
			base.OnPointerExit(P_0);
			PPobDgSULmsGqZojTdFrxnegWsbI = false;
		}

		private void zbyGnibPBSirsUMdWdhZwaIygfajA(int P_0, Vector2 P_1, sOXvLwBClbqDtJxViVNomCuIdOoD P_2)
		{
			QEhzUveeThteHBoKWekUBZOyrUTe = P_0;
			qQqrGmXxzubkmCaMCrOVuSrdktRh = true;
			if (_followTouchPosition)
			{
				kqTTFWTvseTQmSdLBfqvxdlndWXDA(P_0);
			}
			else if (P_2 == sOXvLwBClbqDtJxViVNomCuIdOoD.TouchRegion && _moveToTouchPosition)
			{
				FbjbVhCqtbatwGjQFsvgGueyDSBGA(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, eKFPMqEwLqICnImjloUNsdbJFDmt.TowardTouch);
			}
			XrWtSmtdlNVcYQBEOPCmKBQGswke();
		}

		private void ocNguSfHeUhMkjikGvvptZpSPVpP()
		{
			ThPWHWimrlcazXyfWPofuuahDgzo();
			qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && MsDGhnErgkEAhuNiSEmkLyWmGCkj)
			{
				ReturnToDefaultPosition();
			}
			JiLCwugMSrHlTymdbGvprLnxbTjo();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null) || !_useTouchRegionOnly))
			{
				QFKOXEymAtfzaXbJhAtiDSsrpLGX(eventData, sOXvLwBClbqDtJxViVNomCuIdOoD.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null) || !_useTouchRegionOnly))
			{
				jXYdNAjblrCnDXVQHikRFJVkFajbc(eventData, sOXvLwBClbqDtJxViVNomCuIdOoD.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null) || !_useTouchRegionOnly))
			{
				jFpyRRTzQaTGpbtgzHIZrldBeWud(eventData, sOXvLwBClbqDtJxViVNomCuIdOoD.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(hjhFfdcmBnFRdQMBsLiBCPBDoyUpc != null) || !_useTouchRegionOnly))
			{
				VRPzeteEbsZCPDMfbJbyNayEMNCI(eventData, sOXvLwBClbqDtJxViVNomCuIdOoD.Local);
			}
		}

		private void VvnEeLBQILUHLAWKLgnCOdVbIFoyA(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				QFKOXEymAtfzaXbJhAtiDSsrpLGX(P_0, sOXvLwBClbqDtJxViVNomCuIdOoD.TouchRegion);
			}
		}

		private void qsbKaKVpPEnEWhDnNiKSemHIDswR(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				jXYdNAjblrCnDXVQHikRFJVkFajbc(P_0, sOXvLwBClbqDtJxViVNomCuIdOoD.TouchRegion);
			}
		}

		private void cqjJduOBmiLDgBtoNPjlFUJyfnOI(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				jFpyRRTzQaTGpbtgzHIZrldBeWud(P_0, sOXvLwBClbqDtJxViVNomCuIdOoD.TouchRegion);
			}
		}

		private void lzaDhFGRErVydKJHIIJajzRcpfsvB(PointerEventData P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				VRPzeteEbsZCPDMfbJbyNayEMNCI(P_0, sOXvLwBClbqDtJxViVNomCuIdOoD.TouchRegion);
			}
		}

		private void KvDhOKlllDnJVQRNDmKnUouiMevO(float P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && !_useDigitalAxisSimulation)
			{
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void WWjCAYjKNAJZZBqrYCFQSelEwjKAA(bool P_0)
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void VxTHdgbCWbcxvJlbQpNerrtCQeGs()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(null);
				_onButtonDown.Invoke();
			}
		}

		private void wBwIhXbDYMXNijvVOYOOALzjPPsPA()
		{
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU)
			{
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
