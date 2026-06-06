using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

		private enum tflaNPFjSYbxNvHaLMQWmrdfeErmA
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum ngxiDBuIDRJNNQpwMHfvlZIyMmno
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

		private sealed class tthKdXKEfNUMckmcIDORdqMAFJJEA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int poSgnrJSnarNUEenGERoeXNnHFCab;

			private object LCjwWIsINmfhleLBHKHUppCLnHuF;

			public float YfHkThwgimKmOdqhfkMHAjpfFNgQ;

			public TouchButton TbcghTHIUrwsocbWMCHXcUWCWfKZB;

			public PositionType HanqFmJuerLlRJrpurfnNYSLPQnd;

			public Vector2 XFSrTOzHqkAicDsxamTzDiHPcbeo;

			public tflaNPFjSYbxNvHaLMQWmrdfeErmA uikfoCprpsExMGyZScpGzWXHthWdA;

			private RectTransform LeprAEsTIqzhMkmVzrBHBZDomsmj;

			private Vector2 ffvKsTEwfhzDuYUJBoXoCcprHGEc;

			private float XcIMXzpdDIoIzdtSBomTLVYHeKzq;

			private float ULTNokjKDrfbYtOdEEgEkxBriZHk;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return LCjwWIsINmfhleLBHKHUppCLnHuF;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return LCjwWIsINmfhleLBHKHUppCLnHuF;
				}
			}

			[DebuggerHidden]
			public tthKdXKEfNUMckmcIDORdqMAFJJEA(int P_0)
			{
				poSgnrJSnarNUEenGERoeXNnHFCab = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				LeprAEsTIqzhMkmVzrBHBZDomsmj = null;
				poSgnrJSnarNUEenGERoeXNnHFCab = -2;
			}

			private bool MoveNext()
			{
				int num = poSgnrJSnarNUEenGERoeXNnHFCab;
				TouchButton tbcghTHIUrwsocbWMCHXcUWCWfKZB = TbcghTHIUrwsocbWMCHXcUWCWfKZB;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					poSgnrJSnarNUEenGERoeXNnHFCab = -1;
					goto IL_010c;
				}
				poSgnrJSnarNUEenGERoeXNnHFCab = -1;
				if (!(YfHkThwgimKmOdqhfkMHAjpfFNgQ <= 0f))
				{
					LeprAEsTIqzhMkmVzrBHBZDomsmj = tbcghTHIUrwsocbWMCHXcUWCWfKZB.WguQsOfFOJkmIQiZkACAIfcHMwnD;
					ffvKsTEwfhzDuYUJBoXoCcprHGEc = RnroyRYdQLfgrzFDphyshVCaoaxm.KIHfcUFFvtnUCsCIRBQRtqhpISbp(LeprAEsTIqzhMkmVzrBHBZDomsmj, HanqFmJuerLlRJrpurfnNYSLPQnd);
					float magnitude = (XFSrTOzHqkAicDsxamTzDiHPcbeo - ffvKsTEwfhzDuYUJBoXoCcprHGEc).magnitude;
					if (!(magnitude < 0.01f))
					{
						tbcghTHIUrwsocbWMCHXcUWCWfKZB.SuQhBtEoXHhlHdlxVLzSASsmnNVb = true;
						XcIMXzpdDIoIzdtSBomTLVYHeKzq = magnitude / YfHkThwgimKmOdqhfkMHAjpfFNgQ;
						ULTNokjKDrfbYtOdEEgEkxBriZHk = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				tbcghTHIUrwsocbWMCHXcUWCWfKZB.zQOpLvwLsggbXnzJRRREZkGDIWuBA(uikfoCprpsExMGyZScpGzWXHthWdA, XFSrTOzHqkAicDsxamTzDiHPcbeo, HanqFmJuerLlRJrpurfnNYSLPQnd);
				return false;
				IL_010c:
				if (ULTNokjKDrfbYtOdEEgEkxBriZHk <= 1f)
				{
					ULTNokjKDrfbYtOdEEgEkxBriZHk += Time.unscaledDeltaTime / XcIMXzpdDIoIzdtSBomTLVYHeKzq;
					RnroyRYdQLfgrzFDphyshVCaoaxm.VQuRBguBrADknRnonxLRjMJJmxLI(LeprAEsTIqzhMkmVzrBHBZDomsmj, Vector2.Lerp(ffvKsTEwfhzDuYUJBoXoCcprHGEc, XFSrTOzHqkAicDsxamTzDiHPcbeo, Mathf.SmoothStep(0f, 1f, ULTNokjKDrfbYtOdEEgEkxBriZHk)), HanqFmJuerLlRJrpurfnNYSLPQnd);
					LCjwWIsINmfhleLBHKHUppCLnHuF = null;
					poSgnrJSnarNUEenGERoeXNnHFCab = 1;
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

		private const float cWAIBdcAgujvJjkfDwBUTqFfwwEf = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

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
		private bool _stayActiveOnSwipeOut = true;

		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnReturn = true;

		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private float moRjMRFpekXWvvgnSmEcPuxEvqlg;

		private float nKKYKTpabSpGjuJGenSdUcgtENIB;

		private TouchRegion RUvgMukCreDRhaIyCOliqwnafPbVc;

		private Vector2 LKCWcCMKQJDfJzcNMwRzwoeCNeLG;

		private bool SuQhBtEoXHhlHdlxVLzSASsmnNVb;

		private bool qPVBvwcINckoYKOAtMIneDYjYOGN;

		private tflaNPFjSYbxNvHaLMQWmrdfeErmA wRQgyQokJScuAgBkYjsFQaoBFuoJ;

		private int zVWFvqlfsfasLfQOZImwNzdowHcvA = int.MinValue;

		private int GKQVkYgqFKfCasSSHoYUNVYukhib = int.MinValue;

		[NonSerialized]
		private bool OHqfemGKbpWjjkhfeRUEBNkNCRDy;

		[NonSerialized]
		private bool sgxQdOAWlSEpDBMqENSFVgrsNKlK;

		private IEnumerator ZkFzycIPQEApRLsefITMtnigMikd;

		private VEZCMcJKQchTTqiTLuXSxqeTwYpt raYeMXPLrUgElzUkgDsTeEdgziuF = new VEZCMcJKQchTTqiTLuXSxqeTwYpt();

		private Action<tflaNPFjSYbxNvHaLMQWmrdfeErmA> GzBDMhcTdxRRyIDsTZjDmAiHkfkJ;

		private Action<tflaNPFjSYbxNvHaLMQWmrdfeErmA> ImcBAniEIpTXENbXgglomYwInnOPA;

		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> tLzOCAmkYDNFLOoQuXNdvbSMyuxN;

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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (PaLRSlbdfIUSVbOwjSxJKRhmnIUC())
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
					KgLXihurbPinOWJqLZtFhFebpoIB();
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
						BnanZmhyZlWPRrjBujGrPDlLGycf();
					}
					else
					{
						raYeMXPLrUgElzUkgDsTeEdgziuF.PlLOLvKAzmLUFcmoxeiBdhbprIjBA();
					}
					KgLXihurbPinOWJqLZtFhFebpoIB();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return zVWFvqlfsfasLfQOZImwNzdowHcvA;
			}
			set
			{
				zVWFvqlfsfasLfQOZImwNzdowHcvA = value;
			}
		}

		public bool hasPointer => zVWFvqlfsfasLfQOZImwNzdowHcvA != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<tflaNPFjSYbxNvHaLMQWmrdfeErmA> moveStartedDelegate
		{
			get
			{
				if (GzBDMhcTdxRRyIDsTZjDmAiHkfkJ == null)
				{
					return GzBDMhcTdxRRyIDsTZjDmAiHkfkJ = GmmkqJViVGkwyDmiPORzmIyBiZXo;
				}
				return GzBDMhcTdxRRyIDsTZjDmAiHkfkJ;
			}
		}

		private Action<tflaNPFjSYbxNvHaLMQWmrdfeErmA> moveEndedDelegate
		{
			get
			{
				if (ImcBAniEIpTXENbXgglomYwInnOPA == null)
				{
					return ImcBAniEIpTXENbXgglomYwInnOPA = WbPYsFJetJxeAykVBEnVIlrxamzUA;
				}
				return ImcBAniEIpTXENbXgglomYwInnOPA;
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
				return moRjMRFpekXWvvgnSmEcPuxEvqlg;
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
				return nKKYKTpabSpGjuJGenSdUcgtENIB;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (zVWFvqlfsfasLfQOZImwNzdowHcvA == int.MinValue)
				{
					return int.MinValue;
				}
				if (GKQVkYgqFKfCasSSHoYUNVYukhib != int.MinValue)
				{
					return GKQVkYgqFKfCasSSHoYUNVYukhib;
				}
				return zVWFvqlfsfasLfQOZImwNzdowHcvA;
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
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			jpTHHQDzlIzbMaNsuqwgaOsIQnWh(base.WguQsOfFOJkmIQiZkACAIfcHMwnD.anchoredPosition);
		}

		private void jpTHHQDzlIzbMaNsuqwgaOsIQnWh(Vector2 P_0)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				LKCWcCMKQJDfJzcNMwRzwoeCNeLG = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				ElhhXbzzkfAtoHliClbFtrPxfzak(LKCWcCMKQJDfJzcNMwRzwoeCNeLG, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, tflaNPFjSYbxNvHaLMQWmrdfeErmA.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
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
				LKCWcCMKQJDfJzcNMwRzwoeCNeLG = base.WguQsOfFOJkmIQiZkACAIfcHMwnD.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				vpMeCikwDGHMwNkEAJpHcDYHUGznB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				jLSKtHkuianWhYafcwdbvietoPrW();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				vpMeCikwDGHMwNkEAJpHcDYHUGznB();
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
			base.ZCxYpOKPlUdrVINhgqDHNCUEVWof();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				FOsOciNEcfQPdqfTrgIIOzBahwut();
				nRBlAWmIQTTmIDByBHFgilRosFBM();
				sOOhwQlpcOzqUjgruLeRGYprvAwF();
				if (_followTouchPosition)
				{
					kSAeJpDpHDdEwdePaORkOobTnmVBb(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!qpWVJdydcefUDsBsenoLiqICNaG())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && lgrxeUlsSPQSCicUhAbuoUnLaBDCA)
			{
				RhRZaqQiFdWPJAfrENbBHnpVmOZu(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			LPmsfNmGBmyCteMSKKhmQLHrVBoc();
			_axis.AxisValueChangedEvent += lgCZFMynBgPbazSBvoIeJkPCeOTs;
			_axis.ButtonValueChangedEvent += tFpnZCsMmaGRBHihKMuFucHZPYWB;
			_axis.ButtonDownEvent += YYArnlyLBkcNEbKTacdLqmQHalVab;
			_axis.ButtonUpEvent += uZNaahfjIAALMaMOvhSrePcTWchG;
		}

		internal void OnUnsubscribeEvents()
		{
			kgENzFDyfeJptTDUHgHsOGbgNVXf();
			_axis.AxisValueChangedEvent -= lgCZFMynBgPbazSBvoIeJkPCeOTs;
			_axis.ButtonValueChangedEvent -= tFpnZCsMmaGRBHihKMuFucHZPYWB;
			_axis.ButtonDownEvent -= YYArnlyLBkcNEbKTacdLqmQHalVab;
			_axis.ButtonUpEvent -= uZNaahfjIAALMaMOvhSrePcTWchG;
		}

		internal void OnSetProperty()
		{
			OgyQcTKIIgYuQgYgkEKxBHQuFNPl();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				vpMeCikwDGHMwNkEAJpHcDYHUGznB();
			}
		}

		internal void OnClear()
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				zVWFvqlfsfasLfQOZImwNzdowHcvA = int.MinValue;
				GKQVkYgqFKfCasSSHoYUNVYukhib = int.MinValue;
				OHqfemGKbpWjjkhfeRUEBNkNCRDy = false;
				sgxQdOAWlSEpDBMqENSFVgrsNKlK = false;
				if (_returnOnRelease && qPVBvwcINckoYKOAtMIneDYjYOGN && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				qPVBvwcINckoYKOAtMIneDYjYOGN = false;
				SuQhBtEoXHhlHdlxVLzSASsmnNVb = false;
				wRQgyQokJScuAgBkYjsFQaoBFuoJ = tflaNPFjSYbxNvHaLMQWmrdfeErmA.None;
				aRQbRkKtnOawjVnAmkhohRIgErsLc();
				_axis.Clear();
				moRjMRFpekXWvvgnSmEcPuxEvqlg = 0f;
				nKKYKTpabSpGjuJGenSdUcgtENIB = 0f;
				vpMeCikwDGHMwNkEAJpHcDYHUGznB();
			}
		}

		public override void ClearValue()
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				_axis.Clear();
				moRjMRFpekXWvvgnSmEcPuxEvqlg = 0f;
				if (lgrxeUlsSPQSCicUhAbuoUnLaBDCA)
				{
					base.BrLhsTCJDDhEOtjjAgHezhkdDyDBA.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				return false;
			}
			if (!NxZqTcOaFYxDkedTdVaCjfSAMJmR())
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
			if (base.haxTOdxQmmEeONWUheoXHSZWJeYe(gameObject))
			{
				return true;
			}
			if (RUvgMukCreDRhaIyCOliqwnafPbVc != null)
			{
				return RUvgMukCreDRhaIyCOliqwnafPbVc.gameObject == gameObject;
			}
			return false;
		}

		private void sOOhwQlpcOzqUjgruLeRGYprvAwF()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					liZgaRkzdEMbUJZuuimKGRWwHBaS();
				}
				else
				{
					sySUGJXnbhgHjUnVRMpiXWBjvprX();
				}
			}
		}

		private void liZgaRkzdEMbUJZuuimKGRWwHBaS()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += moRjMRFpekXWvvgnSmEcPuxEvqlg;
			num = MathTools.Clamp(num, -1f, 1f);
			RqdkFJwqtmIFBabapUUGnfCrxbLX(num, true);
		}

		private void sySUGJXnbhgHjUnVRMpiXWBjvprX()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num2 = moRjMRFpekXWvvgnSmEcPuxEvqlg;
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
				RqdkFJwqtmIFBabapUUGnfCrxbLX(num4, true);
			}
		}

		private void RqdkFJwqtmIFBabapUUGnfCrxbLX(float P_0, bool P_1)
		{
			nKKYKTpabSpGjuJGenSdUcgtENIB = moRjMRFpekXWvvgnSmEcPuxEvqlg;
			moRjMRFpekXWvvgnSmEcPuxEvqlg = P_0;
			if (P_0 != nKKYKTpabSpGjuJGenSdUcgtENIB)
			{
				cRqeMwJaAIifBGAnqngojDCDgLKB(null);
			}
			if (P_1 && P_0 != nKKYKTpabSpGjuJGenSdUcgtENIB)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void pnUkNgPaIqLtyYyDGEyPtrVoBRZJ()
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

		private void FgKsWYoePogkhGQvDwqLCPeyNpWb()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void vpMeCikwDGHMwNkEAJpHcDYHUGznB()
		{
			_targetCustomControllerElement.ClearElementCaches();
			nRBlAWmIQTTmIDByBHFgilRosFBM();
			BnanZmhyZlWPRrjBujGrPDlLGycf();
		}

		private void BnanZmhyZlWPRrjBujGrPDlLGycf()
		{
			if (_manageRaycasting)
			{
				raYeMXPLrUgElzUkgDsTeEdgziuF.uJXjGGBcSMxjsMURAFenrCltnOrV(base.transform, NxEjvLTajbFbEUTXJxRNLihPNxQd());
			}
		}

		private bool NxEjvLTajbFbEUTXJxRNLihPNxQd()
		{
			if (RUvgMukCreDRhaIyCOliqwnafPbVc != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void itEClSgbWpwCLjJVsSBqAjEbcscOA(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				jOjDsPdzOLCDQXKceNSuNzliqMjp(P_0);
				P_0.PointerDownEvent += XOkICrVoejOpxbLbvTRyrxjXLLNV;
				P_0.PointerUpEvent += bHJpEjGXDArkwRAcUoZJEHTQLOQB;
				P_0.PointerEnterEvent += IOTJeWDZTaNBtXmkqksjGgltYgwd;
				P_0.PointerExitEvent += ajPNTEeHtBAjRFTirgICMZAYhstKA;
			}
		}

		private void jOjDsPdzOLCDQXKceNSuNzliqMjp(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= XOkICrVoejOpxbLbvTRyrxjXLLNV;
				P_0.PointerUpEvent -= bHJpEjGXDArkwRAcUoZJEHTQLOQB;
				P_0.PointerEnterEvent -= IOTJeWDZTaNBtXmkqksjGgltYgwd;
				P_0.PointerExitEvent -= ajPNTEeHtBAjRFTirgICMZAYhstKA;
			}
		}

		private void nRBlAWmIQTTmIDByBHFgilRosFBM()
		{
			if (!(RUvgMukCreDRhaIyCOliqwnafPbVc == _touchRegion))
			{
				jOjDsPdzOLCDQXKceNSuNzliqMjp(RUvgMukCreDRhaIyCOliqwnafPbVc);
				RUvgMukCreDRhaIyCOliqwnafPbVc = _touchRegion;
				itEClSgbWpwCLjJVsSBqAjEbcscOA(RUvgMukCreDRhaIyCOliqwnafPbVc);
			}
		}

		private void nouPgEEzgyCbXLcCHLreHiiSDvMH(Vector2 P_0, bool P_1, float P_2, tflaNPFjSYbxNvHaLMQWmrdfeErmA P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = RnroyRYdQLfgrzFDphyshVCaoaxm.ZoALtNUTioSNlVSmOZussAFSFzCC(base.kNbKwHebMDAVGBqeMBbPGLFckDhW, rectTransform, P_0);
			Vector2 pivot = base.WguQsOfFOJkmIQiZkACAIfcHMwnD.pivot;
			Vector2 sizeDelta = base.WguQsOfFOJkmIQiZkACAIfcHMwnD.sizeDelta;
			Vector3 localScale = base.WguQsOfFOJkmIQiZkACAIfcHMwnD.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			ElhhXbzzkfAtoHliClbFtrPxfzak(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void ElhhXbzzkfAtoHliClbFtrPxfzak(Vector2 P_0, PositionType P_1, bool P_2, float P_3, tflaNPFjSYbxNvHaLMQWmrdfeErmA P_4)
		{
			if (SuQhBtEoXHhlHdlxVLzSASsmnNVb && P_2 && wRQgyQokJScuAgBkYjsFQaoBFuoJ == P_4)
			{
				return;
			}
			if (SuQhBtEoXHhlHdlxVLzSASsmnNVb && ZkFzycIPQEApRLsefITMtnigMikd != null)
			{
				aRQbRkKtnOawjVnAmkhohRIgErsLc();
				SuQhBtEoXHhlHdlxVLzSASsmnNVb = false;
				wRQgyQokJScuAgBkYjsFQaoBFuoJ = tflaNPFjSYbxNvHaLMQWmrdfeErmA.None;
			}
			if (base.kNbKwHebMDAVGBqeMBbPGLFckDhW == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.kNbKwHebMDAVGBqeMBbPGLFckDhW.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.prBzCSoVntaziqnoUNfbHJCyNAal;
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
				ZkFzycIPQEApRLsefITMtnigMikd = hWmMZamGaKbcqyOgxMDzslgYCGpkA(P_0, P_1, P_3, P_4);
				StartCoroutine(ZkFzycIPQEApRLsefITMtnigMikd);
				wRQgyQokJScuAgBkYjsFQaoBFuoJ = P_4;
				qPVBvwcINckoYKOAtMIneDYjYOGN = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				zQOpLvwLsggbXnzJRRREZkGDIWuBA(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(tthKdXKEfNUMckmcIDORdqMAFJJEA))]
		private IEnumerator hWmMZamGaKbcqyOgxMDzslgYCGpkA(Vector2 P_0, PositionType P_1, float P_2, tflaNPFjSYbxNvHaLMQWmrdfeErmA P_3)
		{
			return new tthKdXKEfNUMckmcIDORdqMAFJJEA(0)
			{
				TbcghTHIUrwsocbWMCHXcUWCWfKZB = this,
				XFSrTOzHqkAicDsxamTzDiHPcbeo = P_0,
				HanqFmJuerLlRJrpurfnNYSLPQnd = P_1,
				YfHkThwgimKmOdqhfkMHAjpfFNgQ = P_2,
				uikfoCprpsExMGyZScpGzWXHthWdA = P_3
			};
		}

		private void zQOpLvwLsggbXnzJRRREZkGDIWuBA(tflaNPFjSYbxNvHaLMQWmrdfeErmA P_0, Vector2 P_1, PositionType P_2)
		{
			RnroyRYdQLfgrzFDphyshVCaoaxm.VQuRBguBrADknRnonxLRjMJJmxLI(base.WguQsOfFOJkmIQiZkACAIfcHMwnD, P_1, P_2);
			SuQhBtEoXHhlHdlxVLzSASsmnNVb = false;
			wRQgyQokJScuAgBkYjsFQaoBFuoJ = tflaNPFjSYbxNvHaLMQWmrdfeErmA.None;
			switch (P_0)
			{
			case tflaNPFjSYbxNvHaLMQWmrdfeErmA.TowardHome:
				qPVBvwcINckoYKOAtMIneDYjYOGN = false;
				break;
			case tflaNPFjSYbxNvHaLMQWmrdfeErmA.TowardTouch:
				qPVBvwcINckoYKOAtMIneDYjYOGN = true;
				break;
			}
			aRQbRkKtnOawjVnAmkhohRIgErsLc();
			moveEndedDelegate(P_0);
		}

		private void GmmkqJViVGkwyDmiPORzmIyBiZXo(tflaNPFjSYbxNvHaLMQWmrdfeErmA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && RUvgMukCreDRhaIyCOliqwnafPbVc != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == tflaNPFjSYbxNvHaLMQWmrdfeErmA.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					raYeMXPLrUgElzUkgDsTeEdgziuF.uJXjGGBcSMxjsMURAFenrCltnOrV(base.transform, flag2);
				}
			}
		}

		private void WbPYsFJetJxeAykVBEnVIlrxamzUA(tflaNPFjSYbxNvHaLMQWmrdfeErmA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && RUvgMukCreDRhaIyCOliqwnafPbVc != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == tflaNPFjSYbxNvHaLMQWmrdfeErmA.TowardHome)
				{
					flag = true;
					flag2 = NxEjvLTajbFbEUTXJxRNLihPNxQd();
				}
				if (flag)
				{
					raYeMXPLrUgElzUkgDsTeEdgziuF.uJXjGGBcSMxjsMURAFenrCltnOrV(base.transform, flag2);
				}
			}
		}

		private void kSAeJpDpHDdEwdePaORkOobTnmVBb(int P_0)
		{
			if (TouchInteractable.XDhgZgonTsgdHgmGXthnmLFjLtdgb(P_0))
			{
				nouPgEEzgyCbXLcCHLreHiiSDvMH(TouchInteractable.STuogyYcUxpcOHaxVaHUDxhHJZxt(P_0), false, 0f, tflaNPFjSYbxNvHaLMQWmrdfeErmA.TowardTouch);
			}
		}

		private void aRQbRkKtnOawjVnAmkhohRIgErsLc()
		{
			if (ZkFzycIPQEApRLsefITMtnigMikd != null)
			{
				try
				{
					StopCoroutine(ZkFzycIPQEApRLsefITMtnigMikd);
				}
				catch
				{
				}
				ZkFzycIPQEApRLsefITMtnigMikd = null;
			}
		}

		private void FOsOciNEcfQPdqfTrgIIOzBahwut()
		{
			if (hasPointer && !TouchInteractable.XDhgZgonTsgdHgmGXthnmLFjLtdgb(effectivePointerId))
			{
				PointerEventData pointerEventData = jJiCEvlDKqyYhURQXWtVnzLvQelG(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					MUcdNSUWOAZBmPtUkquVUUcspwNe(pointerEventData);
				}
				else
				{
					MzwdxaidUyMYxnMFWTIBXgNdMwmK();
				}
			}
		}

		private bool PaLRSlbdfIUSVbOwjSxJKRhmnIUC()
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

		private void PAbckpOWWBpakqzirBfZilxLzEkb()
		{
			zVWFvqlfsfasLfQOZImwNzdowHcvA = int.MinValue;
			GKQVkYgqFKfCasSSHoYUNVYukhib = int.MinValue;
		}

		private bool KkuhiCcXPkyjtWAMGkgmahaQuMQP(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (zVWFvqlfsfasLfQOZImwNzdowHcvA == int.MinValue)
			{
				return false;
			}
			if (zVWFvqlfsfasLfQOZImwNzdowHcvA == P_0)
			{
				return true;
			}
			if (TouchInteractable.nXDGSPaBqYqZoIjiPTsmToxvZkGbA(P_0) && GKQVkYgqFKfCasSSHoYUNVYukhib != int.MinValue && P_0 == GKQVkYgqFKfCasSSHoYUNVYukhib)
			{
				return true;
			}
			return false;
		}

		private PointerEventData XDjDNDaXQjMBsSsouvunbJwblHAo(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = jJiCEvlDKqyYhURQXWtVnzLvQelG(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.STuogyYcUxpcOHaxVaHUDxhHJZxt(P_0);
			if (TouchInteractable.UomZqisexyDETiYLrkvRWHgXYViq(P_0))
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
				if (!TouchInteractable.nXDGSPaBqYqZoIjiPTsmToxvZkGbA(P_0))
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

		private PointerEventData UkHUJIOIPlvoXdzmnPHRiIbRspto(int P_0)
		{
			PointerEventData pointerEventData = jJiCEvlDKqyYhURQXWtVnzLvQelG(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.UomZqisexyDETiYLrkvRWHgXYViq(P_0))
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
				if (!TouchInteractable.nXDGSPaBqYqZoIjiPTsmToxvZkGbA(P_0))
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

		private void MUcdNSUWOAZBmPtUkquVUUcspwNe(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				UkHUJIOIPlvoXdzmnPHRiIbRspto(effectivePointerId);
			}
		}

		private PointerEventData jJiCEvlDKqyYhURQXWtVnzLvQelG(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (tLzOCAmkYDNFLOoQuXNdvbSMyuxN == null)
			{
				tLzOCAmkYDNFLOoQuXNdvbSMyuxN = new Dictionary<int, PointerEventData>();
			}
			if (!tLzOCAmkYDNFLOoQuXNdvbSMyuxN.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				tLzOCAmkYDNFLOoQuXNdvbSMyuxN.Add(P_0, value);
				if (TouchInteractable.nXDGSPaBqYqZoIjiPTsmToxvZkGbA(P_0))
				{
					PointerEventData.InputButton button = P_0 switch
					{
						-1 => PointerEventData.InputButton.Left, 
						-2 => PointerEventData.InputButton.Right, 
						-3 => PointerEventData.InputButton.Middle, 
						_ => throw new NotImplementedException(), 
					};
					value.button = button;
				}
			}
			return value;
		}

		private void RuVKLEBZUuniRPyZCbeGgZqFkCYQ(PointerEventData P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno P_1)
		{
			if (!hasPointer || KkuhiCcXPkyjtWAMGkgmahaQuMQP(P_0.pointerId))
			{
				if (NxZqTcOaFYxDkedTdVaCjfSAMJmR() && IsInteractable())
				{
					xrDxIKvjZGPzIUWhWcLkVqNNecQn(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void OanUumBdFCBycvghVEpLdcbdXgVcA(PointerEventData P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno P_1)
		{
			if ((!hasPointer || KkuhiCcXPkyjtWAMGkgmahaQuMQP(P_0.pointerId)) && !TouchInteractable.XDhgZgonTsgdHgmGXthnmLFjLtdgb(effectivePointerId))
			{
				MzwdxaidUyMYxnMFWTIBXgNdMwmK();
				base.OnPointerUp(P_0);
			}
		}

		private void qdpdJbgwMvIlIvABTDxVvCenEsTX(PointerEventData P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno P_1)
		{
			if (hasPointer && !KkuhiCcXPkyjtWAMGkgmahaQuMQP(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.nXDGSPaBqYqZoIjiPTsmToxvZkGbA(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				ngxiDBuIDRJNNQpwMHfvlZIyMmno.Local => base.allowedMouseButtons, 
				ngxiDBuIDRJNNQpwMHfvlZIyMmno.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && NxZqTcOaFYxDkedTdVaCjfSAMJmR() && IsInteractable() && (!flag || TouchInteractable.rItKnJlrvQCSpQDaqIeCKXYytvsl(mouseButtonFlags)) && !OHqfemGKbpWjjkhfeRUEBNkNCRDy)
			{
				if (flag)
				{
					if (TouchInteractable.kRrHDtcJXkinJnYzwOEzgKAaZxsS(mouseButtonFlags, out var gKQVkYgqFKfCasSSHoYUNVYukhib))
					{
						GKQVkYgqFKfCasSSHoYUNVYukhib = gKQVkYgqFKfCasSSHoYUNVYukhib;
					}
					else
					{
						GKQVkYgqFKfCasSSHoYUNVYukhib = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					ngxiDBuIDRJNNQpwMHfvlZIyMmno.Local => base.gameObject, 
					ngxiDBuIDRJNNQpwMHfvlZIyMmno.TouchRegion => RUvgMukCreDRhaIyCOliqwnafPbVc.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = XDjDNDaXQjMBsSsouvunbJwblHAo((GKQVkYgqFKfCasSSHoYUNVYukhib != int.MinValue) ? GKQVkYgqFKfCasSSHoYUNVYukhib : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					RuVKLEBZUuniRPyZCbeGgZqFkCYQ(pointerEventData, P_1);
				}
			}
			sgxQdOAWlSEpDBMqENSFVgrsNKlK = true;
		}

		private void fkezLjwNfQwcgddjmdrzeOKQqvJDb(PointerEventData P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno P_1)
		{
			if (hasPointer && !KkuhiCcXPkyjtWAMGkgmahaQuMQP(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && OHqfemGKbpWjjkhfeRUEBNkNCRDy)
			{
				MzwdxaidUyMYxnMFWTIBXgNdMwmK();
			}
			base.OnPointerExit(P_0);
			sgxQdOAWlSEpDBMqENSFVgrsNKlK = false;
		}

		private void xrDxIKvjZGPzIUWhWcLkVqNNecQn(int P_0, Vector2 P_1, ngxiDBuIDRJNNQpwMHfvlZIyMmno P_2)
		{
			zVWFvqlfsfasLfQOZImwNzdowHcvA = P_0;
			OHqfemGKbpWjjkhfeRUEBNkNCRDy = true;
			if (_followTouchPosition)
			{
				kSAeJpDpHDdEwdePaORkOobTnmVBb(P_0);
			}
			else if (P_2 == ngxiDBuIDRJNNQpwMHfvlZIyMmno.TouchRegion && _moveToTouchPosition)
			{
				nouPgEEzgyCbXLcCHLreHiiSDvMH(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, tflaNPFjSYbxNvHaLMQWmrdfeErmA.TowardTouch);
			}
			pnUkNgPaIqLtyYyDGEyPtrVoBRZJ();
		}

		private void MzwdxaidUyMYxnMFWTIBXgNdMwmK()
		{
			PAbckpOWWBpakqzirBfZilxLzEkb();
			OHqfemGKbpWjjkhfeRUEBNkNCRDy = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && qPVBvwcINckoYKOAtMIneDYjYOGN)
			{
				ReturnToDefaultPosition();
			}
			FgKsWYoePogkhGQvDwqLCPeyNpWb();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(RUvgMukCreDRhaIyCOliqwnafPbVc != null) || !_useTouchRegionOnly))
			{
				RuVKLEBZUuniRPyZCbeGgZqFkCYQ(eventData, ngxiDBuIDRJNNQpwMHfvlZIyMmno.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(RUvgMukCreDRhaIyCOliqwnafPbVc != null) || !_useTouchRegionOnly))
			{
				OanUumBdFCBycvghVEpLdcbdXgVcA(eventData, ngxiDBuIDRJNNQpwMHfvlZIyMmno.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(RUvgMukCreDRhaIyCOliqwnafPbVc != null) || !_useTouchRegionOnly))
			{
				qdpdJbgwMvIlIvABTDxVvCenEsTX(eventData, ngxiDBuIDRJNNQpwMHfvlZIyMmno.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(RUvgMukCreDRhaIyCOliqwnafPbVc != null) || !_useTouchRegionOnly))
			{
				fkezLjwNfQwcgddjmdrzeOKQqvJDb(eventData, ngxiDBuIDRJNNQpwMHfvlZIyMmno.Local);
			}
		}

		private void XOkICrVoejOpxbLbvTRyrxjXLLNV(PointerEventData P_0)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				RuVKLEBZUuniRPyZCbeGgZqFkCYQ(P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno.TouchRegion);
			}
		}

		private void bHJpEjGXDArkwRAcUoZJEHTQLOQB(PointerEventData P_0)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				OanUumBdFCBycvghVEpLdcbdXgVcA(P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno.TouchRegion);
			}
		}

		private void IOTJeWDZTaNBtXmkqksjGgltYgwd(PointerEventData P_0)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				qdpdJbgwMvIlIvABTDxVvCenEsTX(P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno.TouchRegion);
			}
		}

		private void ajPNTEeHtBAjRFTirgICMZAYhstKA(PointerEventData P_0)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && TouchInteractable.JbFmmVugyNsHvgamAgARApCNCBQaA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				fkezLjwNfQwcgddjmdrzeOKQqvJDb(P_0, ngxiDBuIDRJNNQpwMHfvlZIyMmno.TouchRegion);
			}
		}

		private void lgCZFMynBgPbazSBvoIeJkPCeOTs(float P_0)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn && !_useDigitalAxisSimulation)
			{
				cRqeMwJaAIifBGAnqngojDCDgLKB(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void tFpnZCsMmaGRBHihKMuFucHZPYWB(bool P_0)
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				cRqeMwJaAIifBGAnqngojDCDgLKB(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void YYArnlyLBkcNEbKTacdLqmQHalVab()
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				cRqeMwJaAIifBGAnqngojDCDgLKB(null);
				_onButtonDown.Invoke();
			}
		}

		private void uZNaahfjIAALMaMOvhSrePcTWchG()
		{
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				cRqeMwJaAIifBGAnqngojDCDgLKB(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
