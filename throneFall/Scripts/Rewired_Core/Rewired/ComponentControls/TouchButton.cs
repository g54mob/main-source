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

		private enum MrVtqtjDFSQmYoRzxIwllBSDnMsu
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum EJVHovgSEVWKIbdpgPMIdSvAqmiH
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

		private sealed class YgHfMjKooXaRzENjskicUvvsIPOYA : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int MlacMXaKwoTWPjLcmavTuBaVfDFxA;

			private object yQBNkBoNWscyFBEwridHdAxdznrB;

			public float rIfXGJmfhoNcDYAkLhOaKVYXLjdk;

			public TouchButton edIeSvdADxMhjIURakjccMvagjBRE;

			public PositionType mnXPUvNbpzGAPiwKCDKTZlnfPksb;

			public Vector2 aGibYkvrpoVpdkioIbtQbTghFbttA;

			public MrVtqtjDFSQmYoRzxIwllBSDnMsu BMKKPmbtimasLVbGwuXnQdkrojZw;

			private RectTransform wRPUDemCFoHyNFTQReLuDuqOmkvT;

			private Vector2 SdXzbYCphlaaEpXqlOFmWZKDJoRE;

			private float ersFkNrdOQeByCUNviEmxVfnwCmVA;

			private float dIzQPUdGWncmJEMgmVArlkgFVDMuA;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return yQBNkBoNWscyFBEwridHdAxdznrB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yQBNkBoNWscyFBEwridHdAxdznrB;
				}
			}

			[DebuggerHidden]
			public YgHfMjKooXaRzENjskicUvvsIPOYA(int P_0)
			{
				MlacMXaKwoTWPjLcmavTuBaVfDFxA = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int mlacMXaKwoTWPjLcmavTuBaVfDFxA = MlacMXaKwoTWPjLcmavTuBaVfDFxA;
				TouchButton touchButton = edIeSvdADxMhjIURakjccMvagjBRE;
				if (mlacMXaKwoTWPjLcmavTuBaVfDFxA != 0)
				{
					if (mlacMXaKwoTWPjLcmavTuBaVfDFxA != 1)
					{
						return false;
					}
					MlacMXaKwoTWPjLcmavTuBaVfDFxA = -1;
					goto IL_010c;
				}
				MlacMXaKwoTWPjLcmavTuBaVfDFxA = -1;
				if (!(rIfXGJmfhoNcDYAkLhOaKVYXLjdk <= 0f))
				{
					wRPUDemCFoHyNFTQReLuDuqOmkvT = touchButton.njMzqkjgKXtAPpsbWqNrSYYvKakF;
					SdXzbYCphlaaEpXqlOFmWZKDJoRE = eXVTxxSoRDwrgUWSVIbJlBxEydwL.bIhKCeJxgfwQXNeHlaaibPWZOOgy(wRPUDemCFoHyNFTQReLuDuqOmkvT, mnXPUvNbpzGAPiwKCDKTZlnfPksb);
					float magnitude = (aGibYkvrpoVpdkioIbtQbTghFbttA - SdXzbYCphlaaEpXqlOFmWZKDJoRE).magnitude;
					if (!(magnitude < 0.01f))
					{
						touchButton.beQUnuMzVRcwPCqvnfWoSfCOjKNA = true;
						ersFkNrdOQeByCUNviEmxVfnwCmVA = magnitude / rIfXGJmfhoNcDYAkLhOaKVYXLjdk;
						dIzQPUdGWncmJEMgmVArlkgFVDMuA = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				touchButton.EeeruRyShmMuIWMCrIplLYtjNSxU(BMKKPmbtimasLVbGwuXnQdkrojZw, aGibYkvrpoVpdkioIbtQbTghFbttA, mnXPUvNbpzGAPiwKCDKTZlnfPksb);
				return false;
				IL_010c:
				if (dIzQPUdGWncmJEMgmVArlkgFVDMuA <= 1f)
				{
					dIzQPUdGWncmJEMgmVArlkgFVDMuA += Time.unscaledDeltaTime / ersFkNrdOQeByCUNviEmxVfnwCmVA;
					eXVTxxSoRDwrgUWSVIbJlBxEydwL.kDMsxGiwqCAtuinlFBeozewbwiQF(wRPUDemCFoHyNFTQReLuDuqOmkvT, Vector2.Lerp(SdXzbYCphlaaEpXqlOFmWZKDJoRE, aGibYkvrpoVpdkioIbtQbTghFbttA, Mathf.SmoothStep(0f, 1f, dIzQPUdGWncmJEMgmVArlkgFVDMuA)), mnXPUvNbpzGAPiwKCDKTZlnfPksb);
					yQBNkBoNWscyFBEwridHdAxdznrB = null;
					MlacMXaKwoTWPjLcmavTuBaVfDFxA = 1;
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

		private const float JYunIDenZmaGWGoJzCBvTgHZmrTe = 20f;

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

		private float LclAUjRNtmAPeKMcoELBTiMkzSii;

		private float GvijbabpCduyZFCmwDKfETtFMmKE;

		private TouchRegion gJHcnAbAuwtIqKfjwLTNegOCVZwPB;

		private Vector2 yuPtqWVZFMtWACxccSQcRBmsFOs;

		private bool beQUnuMzVRcwPCqvnfWoSfCOjKNA;

		private bool XCrMGWoxOafJZhBPFmyCqJvTStPi;

		private MrVtqtjDFSQmYoRzxIwllBSDnMsu FTuBXqgSWAzrFVwfsRviWDVtRAtf;

		private int CXokUGvllzhlWpmTvCGPpLECGHlQ = int.MinValue;

		private int rXmuKOedjUmLpNHAfKGhXeueoLme = int.MinValue;

		[NonSerialized]
		private bool dsUKDCWyatLsaFUmQLwhVZBtIRWO;

		[NonSerialized]
		private bool VqPzboAfkQbTKmDfgQrmTLCCEVyZ;

		private IEnumerator uYnYaCUBMIDgGkQvJuNhlUvSUXxD;

		private iitbXMZzJwKrUPEUjjkxptBdGIuh WmiHdDNMGDrgVETKMbeGsdIYtdXb = new iitbXMZzJwKrUPEUjjkxptBdGIuh();

		private Action<MrVtqtjDFSQmYoRzxIwllBSDnMsu> vmxwFJgqclMlbjDbrFjmkuNzSuhp;

		private Action<MrVtqtjDFSQmYoRzxIwllBSDnMsu> nMUFdHFKFtGADjSKjSLLyYVqqfXsB;

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

		private Dictionary<int, PointerEventData> EIBsbggvXVrMUvUXMCpWzljuGimEA;

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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (yotyeEjaVYNRfIZCFqIkUuhExZpB())
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
						obQGjMhDnlDiEOXkOZVSJqSrAaxL();
					}
					else
					{
						WmiHdDNMGDrgVETKMbeGsdIYtdXb.ijrRyVGjiyWDYVJtTsAirrYJaGuy();
					}
					dGrkdAigHPtPsfObCbIMleiXpdpl();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return CXokUGvllzhlWpmTvCGPpLECGHlQ;
			}
			set
			{
				CXokUGvllzhlWpmTvCGPpLECGHlQ = value;
			}
		}

		public bool hasPointer => CXokUGvllzhlWpmTvCGPpLECGHlQ != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<MrVtqtjDFSQmYoRzxIwllBSDnMsu> moveStartedDelegate
		{
			get
			{
				if (vmxwFJgqclMlbjDbrFjmkuNzSuhp == null)
				{
					return vmxwFJgqclMlbjDbrFjmkuNzSuhp = jiYFTdHxWOgjjcmbpfWEiYTfPZAf;
				}
				return vmxwFJgqclMlbjDbrFjmkuNzSuhp;
			}
		}

		private Action<MrVtqtjDFSQmYoRzxIwllBSDnMsu> moveEndedDelegate
		{
			get
			{
				if (nMUFdHFKFtGADjSKjSLLyYVqqfXsB == null)
				{
					return nMUFdHFKFtGADjSKjSLLyYVqqfXsB = tAzWJjXuwLGnBXAOdvNcfVEHVqgQ;
				}
				return nMUFdHFKFtGADjSKjSLLyYVqqfXsB;
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
				return LclAUjRNtmAPeKMcoELBTiMkzSii;
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
				return GvijbabpCduyZFCmwDKfETtFMmKE;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (CXokUGvllzhlWpmTvCGPpLECGHlQ == int.MinValue)
				{
					return int.MinValue;
				}
				if (rXmuKOedjUmLpNHAfKGhXeueoLme != int.MinValue)
				{
					return rXmuKOedjUmLpNHAfKGhXeueoLme;
				}
				return CXokUGvllzhlWpmTvCGPpLECGHlQ;
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
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			QCjDomBguIqsXXyvUrOVuIHelKLV(base.njMzqkjgKXtAPpsbWqNrSYYvKakF.anchoredPosition);
		}

		private void QCjDomBguIqsXXyvUrOVuIHelKLV(Vector2 P_0)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				yuPtqWVZFMtWACxccSQcRBmsFOs = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				rHXIkVhztbTmdaSfodLyzAwFjhfV(yuPtqWVZFMtWACxccSQcRBmsFOs, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, MrVtqtjDFSQmYoRzxIwllBSDnMsu.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
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
				yuPtqWVZFMtWACxccSQcRBmsFOs = base.njMzqkjgKXtAPpsbWqNrSYYvKakF.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				QDggdSwXWUyBrRpVeZTiPUfmbCkr();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				GIsfEluetqtLurkiIFZQxQLPGRycA();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				QDggdSwXWUyBrRpVeZTiPUfmbCkr();
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
			base.qnLhJkUiUIykMbMYQAAaROlmDNjm();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				kBWnGGJidzRmwJdSJcPlOouEuTxf();
				ItpUsuimRRAjPqertllLunmYDNOG();
				DaeGeuznkEqXPMjlSxysQKzBfjnG();
				if (_followTouchPosition)
				{
					PveJyFNvMTdVhJWOYVtDuqYdejQk(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!XjBzdhnktatNTyEAKEeVRBDyMEbg())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && OPBVHezjFVpJBDXXXJwLabYlHTYR)
			{
				eRrfNGgQMniYEStsyLPyHwUxcEUZ(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			cWTJDgsNiclLqNNsXcOxUkTHFEXA();
			_axis.AxisValueChangedEvent += OPaWcsgbMadezIQUDFmVZHouhMYmA;
			_axis.ButtonValueChangedEvent += AZzYtoWHwoHYQytNHeXomJvpVNfB;
			_axis.ButtonDownEvent += fwaLCJacAcuCNpqOEiVcqujjzrIX;
			_axis.ButtonUpEvent += ZzMDPBnuIDDBFHZABPMaqswlAuRb;
		}

		internal void OnUnsubscribeEvents()
		{
			DUioYfVwaovScwgKjEAVfYGUBNCPA();
			_axis.AxisValueChangedEvent -= OPaWcsgbMadezIQUDFmVZHouhMYmA;
			_axis.ButtonValueChangedEvent -= AZzYtoWHwoHYQytNHeXomJvpVNfB;
			_axis.ButtonDownEvent -= fwaLCJacAcuCNpqOEiVcqujjzrIX;
			_axis.ButtonUpEvent -= ZzMDPBnuIDDBFHZABPMaqswlAuRb;
		}

		internal void OnSetProperty()
		{
			njSNDjOhPuFLTAZdCBoKADvUxVAoA();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				QDggdSwXWUyBrRpVeZTiPUfmbCkr();
			}
		}

		internal void OnClear()
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				CXokUGvllzhlWpmTvCGPpLECGHlQ = int.MinValue;
				rXmuKOedjUmLpNHAfKGhXeueoLme = int.MinValue;
				dsUKDCWyatLsaFUmQLwhVZBtIRWO = false;
				VqPzboAfkQbTKmDfgQrmTLCCEVyZ = false;
				if (_returnOnRelease && XCrMGWoxOafJZhBPFmyCqJvTStPi && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				XCrMGWoxOafJZhBPFmyCqJvTStPi = false;
				beQUnuMzVRcwPCqvnfWoSfCOjKNA = false;
				FTuBXqgSWAzrFVwfsRviWDVtRAtf = MrVtqtjDFSQmYoRzxIwllBSDnMsu.None;
				LBsjqKArsEAjgrINWGZHqVhcMtjWA();
				_axis.Clear();
				LclAUjRNtmAPeKMcoELBTiMkzSii = 0f;
				GvijbabpCduyZFCmwDKfETtFMmKE = 0f;
				QDggdSwXWUyBrRpVeZTiPUfmbCkr();
			}
		}

		public override void ClearValue()
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				_axis.Clear();
				LclAUjRNtmAPeKMcoELBTiMkzSii = 0f;
				if (OPBVHezjFVpJBDXXXJwLabYlHTYR)
				{
					base.kehARxYYCBsbPQqXelIPlFVDezIE.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				return false;
			}
			if (!kxzKiGOSSGHSvNhOTCCxvpjgSZtV())
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
			if (base.MVmgHBlZkOFFFcBhDKctRpNkFXtb(gameObject))
			{
				return true;
			}
			if (gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null)
			{
				return gJHcnAbAuwtIqKfjwLTNegOCVZwPB.gameObject == gameObject;
			}
			return false;
		}

		private void DaeGeuznkEqXPMjlSxysQKzBfjnG()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					UgfJDvmjmESkTiZrAqOnQenGoRzu();
				}
				else
				{
					BzctrlBxajRQuziUhaPBJBeZZrmcA();
				}
			}
		}

		private void UgfJDvmjmESkTiZrAqOnQenGoRzu()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += LclAUjRNtmAPeKMcoELBTiMkzSii;
			num = MathTools.Clamp(num, -1f, 1f);
			yDLFezymouYWCNyjFskftSvLrhSs(num, true);
		}

		private void BzctrlBxajRQuziUhaPBJBeZZrmcA()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float lclAUjRNtmAPeKMcoELBTiMkzSii = LclAUjRNtmAPeKMcoELBTiMkzSii;
			if (lclAUjRNtmAPeKMcoELBTiMkzSii != 0f)
			{
				float num2 = num * Time.unscaledDeltaTime;
				float num3;
				if (MathTools.Abs(num2) >= MathTools.Abs(lclAUjRNtmAPeKMcoELBTiMkzSii))
				{
					num3 = 0f;
				}
				else
				{
					float num4 = ((lclAUjRNtmAPeKMcoELBTiMkzSii > 0f) ? (-1f) : 1f);
					num3 = lclAUjRNtmAPeKMcoELBTiMkzSii + num4 * num2;
				}
				yDLFezymouYWCNyjFskftSvLrhSs(num3, true);
			}
		}

		private void yDLFezymouYWCNyjFskftSvLrhSs(float P_0, bool P_1)
		{
			GvijbabpCduyZFCmwDKfETtFMmKE = LclAUjRNtmAPeKMcoELBTiMkzSii;
			LclAUjRNtmAPeKMcoELBTiMkzSii = P_0;
			if (P_0 != GvijbabpCduyZFCmwDKfETtFMmKE)
			{
				HcMHgTLnDSxiFjVdUVgBpujlujCh(null);
			}
			if (P_1 && P_0 != GvijbabpCduyZFCmwDKfETtFMmKE)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void WLuEkMVlTeUyphAOkYIgnPiMTPMy()
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

		private void iGmFkgajOcnifncVxQdFAVsYTdeL()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void QDggdSwXWUyBrRpVeZTiPUfmbCkr()
		{
			_targetCustomControllerElement.ClearElementCaches();
			ItpUsuimRRAjPqertllLunmYDNOG();
			obQGjMhDnlDiEOXkOZVSJqSrAaxL();
		}

		private void obQGjMhDnlDiEOXkOZVSJqSrAaxL()
		{
			if (_manageRaycasting)
			{
				WmiHdDNMGDrgVETKMbeGsdIYtdXb.HJrgjgTtFYwslhcOyEAAanOTMAqxA(base.transform, yXuCErFaljQPBrFArLZgZiBrDbLl());
			}
		}

		private bool yXuCErFaljQPBrFArLZgZiBrDbLl()
		{
			if (gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void TgidWobdHvAHGbkOEOxRLbdDBmfSb(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				WZJjRfhMLFqUPunhIZqTDMUCkUeY(P_0);
				P_0.PointerDownEvent += uKWebHFZttqauWqmLjpFnnQhsLQm;
				P_0.PointerUpEvent += CwbIqkCIxOybPsTSiQsmKsPcNRMb;
				P_0.PointerEnterEvent += vlmdsVVMaGNcoBjMEOYMsRJLYxS;
				P_0.PointerExitEvent += HhvQseylkLieQaLzJforRbvcpmkp;
			}
		}

		private void WZJjRfhMLFqUPunhIZqTDMUCkUeY(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= uKWebHFZttqauWqmLjpFnnQhsLQm;
				P_0.PointerUpEvent -= CwbIqkCIxOybPsTSiQsmKsPcNRMb;
				P_0.PointerEnterEvent -= vlmdsVVMaGNcoBjMEOYMsRJLYxS;
				P_0.PointerExitEvent -= HhvQseylkLieQaLzJforRbvcpmkp;
			}
		}

		private void ItpUsuimRRAjPqertllLunmYDNOG()
		{
			if (!(gJHcnAbAuwtIqKfjwLTNegOCVZwPB == _touchRegion))
			{
				WZJjRfhMLFqUPunhIZqTDMUCkUeY(gJHcnAbAuwtIqKfjwLTNegOCVZwPB);
				gJHcnAbAuwtIqKfjwLTNegOCVZwPB = _touchRegion;
				TgidWobdHvAHGbkOEOxRLbdDBmfSb(gJHcnAbAuwtIqKfjwLTNegOCVZwPB);
			}
		}

		private void AOkarSsNsLKTeDVpfVZHBjqFLBc(Vector2 P_0, bool P_1, float P_2, MrVtqtjDFSQmYoRzxIwllBSDnMsu P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = eXVTxxSoRDwrgUWSVIbJlBxEydwL.qZemUjEiSyJDkwBLuIfBmEloIZLdA(base.PeRbvjmKLXVAZwUjeMLqAywUbFwt, rectTransform, P_0);
			Vector2 pivot = base.njMzqkjgKXtAPpsbWqNrSYYvKakF.pivot;
			Vector2 sizeDelta = base.njMzqkjgKXtAPpsbWqNrSYYvKakF.sizeDelta;
			Vector3 localScale = base.njMzqkjgKXtAPpsbWqNrSYYvKakF.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			rHXIkVhztbTmdaSfodLyzAwFjhfV(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void rHXIkVhztbTmdaSfodLyzAwFjhfV(Vector2 P_0, PositionType P_1, bool P_2, float P_3, MrVtqtjDFSQmYoRzxIwllBSDnMsu P_4)
		{
			if (beQUnuMzVRcwPCqvnfWoSfCOjKNA && P_2 && FTuBXqgSWAzrFVwfsRviWDVtRAtf == P_4)
			{
				return;
			}
			if (beQUnuMzVRcwPCqvnfWoSfCOjKNA && uYnYaCUBMIDgGkQvJuNhlUvSUXxD != null)
			{
				LBsjqKArsEAjgrINWGZHqVhcMtjWA();
				beQUnuMzVRcwPCqvnfWoSfCOjKNA = false;
				FTuBXqgSWAzrFVwfsRviWDVtRAtf = MrVtqtjDFSQmYoRzxIwllBSDnMsu.None;
			}
			if (base.PeRbvjmKLXVAZwUjeMLqAywUbFwt == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.PeRbvjmKLXVAZwUjeMLqAywUbFwt.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.ItGEsMyMpnxlJugoabGAFlWwNpaA;
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
				uYnYaCUBMIDgGkQvJuNhlUvSUXxD = WyMsyKaahUItjJPvVwrOEiPqgCkAb(P_0, P_1, P_3, P_4);
				StartCoroutine(uYnYaCUBMIDgGkQvJuNhlUvSUXxD);
				FTuBXqgSWAzrFVwfsRviWDVtRAtf = P_4;
				XCrMGWoxOafJZhBPFmyCqJvTStPi = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				EeeruRyShmMuIWMCrIplLYtjNSxU(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(YgHfMjKooXaRzENjskicUvvsIPOYA))]
		private IEnumerator WyMsyKaahUItjJPvVwrOEiPqgCkAb(Vector2 P_0, PositionType P_1, float P_2, MrVtqtjDFSQmYoRzxIwllBSDnMsu P_3)
		{
			return new YgHfMjKooXaRzENjskicUvvsIPOYA(0)
			{
				edIeSvdADxMhjIURakjccMvagjBRE = this,
				aGibYkvrpoVpdkioIbtQbTghFbttA = P_0,
				mnXPUvNbpzGAPiwKCDKTZlnfPksb = P_1,
				rIfXGJmfhoNcDYAkLhOaKVYXLjdk = P_2,
				BMKKPmbtimasLVbGwuXnQdkrojZw = P_3
			};
		}

		private void EeeruRyShmMuIWMCrIplLYtjNSxU(MrVtqtjDFSQmYoRzxIwllBSDnMsu P_0, Vector2 P_1, PositionType P_2)
		{
			eXVTxxSoRDwrgUWSVIbJlBxEydwL.kDMsxGiwqCAtuinlFBeozewbwiQF(base.njMzqkjgKXtAPpsbWqNrSYYvKakF, P_1, P_2);
			beQUnuMzVRcwPCqvnfWoSfCOjKNA = false;
			FTuBXqgSWAzrFVwfsRviWDVtRAtf = MrVtqtjDFSQmYoRzxIwllBSDnMsu.None;
			switch (P_0)
			{
			case MrVtqtjDFSQmYoRzxIwllBSDnMsu.TowardHome:
				XCrMGWoxOafJZhBPFmyCqJvTStPi = false;
				break;
			case MrVtqtjDFSQmYoRzxIwllBSDnMsu.TowardTouch:
				XCrMGWoxOafJZhBPFmyCqJvTStPi = true;
				break;
			}
			LBsjqKArsEAjgrINWGZHqVhcMtjWA();
			moveEndedDelegate(P_0);
		}

		private void jiYFTdHxWOgjjcmbpfWEiYTfPZAf(MrVtqtjDFSQmYoRzxIwllBSDnMsu P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == MrVtqtjDFSQmYoRzxIwllBSDnMsu.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					WmiHdDNMGDrgVETKMbeGsdIYtdXb.HJrgjgTtFYwslhcOyEAAanOTMAqxA(base.transform, flag2);
				}
			}
		}

		private void tAzWJjXuwLGnBXAOdvNcfVEHVqgQ(MrVtqtjDFSQmYoRzxIwllBSDnMsu P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == MrVtqtjDFSQmYoRzxIwllBSDnMsu.TowardHome)
				{
					flag = true;
					flag2 = yXuCErFaljQPBrFArLZgZiBrDbLl();
				}
				if (flag)
				{
					WmiHdDNMGDrgVETKMbeGsdIYtdXb.HJrgjgTtFYwslhcOyEAAanOTMAqxA(base.transform, flag2);
				}
			}
		}

		private void PveJyFNvMTdVhJWOYVtDuqYdejQk(int P_0)
		{
			if (TouchInteractable.iONeyGHaOwtoIAJTjPLQcZwBddoCb(P_0))
			{
				AOkarSsNsLKTeDVpfVZHBjqFLBc(TouchInteractable.rVODrSUHTpgCNauChrZjXUWtXIwC(P_0), false, 0f, MrVtqtjDFSQmYoRzxIwllBSDnMsu.TowardTouch);
			}
		}

		private void LBsjqKArsEAjgrINWGZHqVhcMtjWA()
		{
			if (uYnYaCUBMIDgGkQvJuNhlUvSUXxD != null)
			{
				try
				{
					StopCoroutine(uYnYaCUBMIDgGkQvJuNhlUvSUXxD);
				}
				catch
				{
				}
				uYnYaCUBMIDgGkQvJuNhlUvSUXxD = null;
			}
		}

		private void kBWnGGJidzRmwJdSJcPlOouEuTxf()
		{
			if (hasPointer && !TouchInteractable.iONeyGHaOwtoIAJTjPLQcZwBddoCb(effectivePointerId))
			{
				PointerEventData pointerEventData = UKunJjeKwAziadShqyonzIXnGwoA(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					xUSGWkSLLOCFvwsBKSOqQdDGhCYF(pointerEventData);
				}
				else
				{
					bXMShAeLLqBkeUIMaxQyHreVCejl();
				}
			}
		}

		private bool yotyeEjaVYNRfIZCFqIkUuhExZpB()
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

		private void yNTJOoUDBLafeTcARzaMsCsxpFNE()
		{
			CXokUGvllzhlWpmTvCGPpLECGHlQ = int.MinValue;
			rXmuKOedjUmLpNHAfKGhXeueoLme = int.MinValue;
		}

		private bool foIbSgiXMmAvwnnBySWVoINwAVHL(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (CXokUGvllzhlWpmTvCGPpLECGHlQ == int.MinValue)
			{
				return false;
			}
			if (CXokUGvllzhlWpmTvCGPpLECGHlQ == P_0)
			{
				return true;
			}
			if (TouchInteractable.SUdbtzJPnQgGdEKdknCPcwKPPmVvb(P_0) && rXmuKOedjUmLpNHAfKGhXeueoLme != int.MinValue && P_0 == rXmuKOedjUmLpNHAfKGhXeueoLme)
			{
				return true;
			}
			return false;
		}

		private PointerEventData sqJjypsZTbIUnjSzIfEMbIDZFNZGA(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = UKunJjeKwAziadShqyonzIXnGwoA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.rVODrSUHTpgCNauChrZjXUWtXIwC(P_0);
			if (TouchInteractable.jYECoEesieCXQHbEBfJmGELpbTzSA(P_0))
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
				if (!TouchInteractable.SUdbtzJPnQgGdEKdknCPcwKPPmVvb(P_0))
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

		private PointerEventData zMzYgyGuOxmxIMMxXpEssxOfrPwE(int P_0)
		{
			PointerEventData pointerEventData = UKunJjeKwAziadShqyonzIXnGwoA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.jYECoEesieCXQHbEBfJmGELpbTzSA(P_0))
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
				if (!TouchInteractable.SUdbtzJPnQgGdEKdknCPcwKPPmVvb(P_0))
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

		private void xUSGWkSLLOCFvwsBKSOqQdDGhCYF(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				zMzYgyGuOxmxIMMxXpEssxOfrPwE(effectivePointerId);
			}
		}

		private PointerEventData UKunJjeKwAziadShqyonzIXnGwoA(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (EIBsbggvXVrMUvUXMCpWzljuGimEA == null)
			{
				EIBsbggvXVrMUvUXMCpWzljuGimEA = new Dictionary<int, PointerEventData>();
			}
			if (!EIBsbggvXVrMUvUXMCpWzljuGimEA.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				EIBsbggvXVrMUvUXMCpWzljuGimEA.Add(P_0, value);
				if (TouchInteractable.SUdbtzJPnQgGdEKdknCPcwKPPmVvb(P_0))
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

		private void ourfwqJcJautSuCOuZCfkNBzDSLR(PointerEventData P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH P_1)
		{
			if (!hasPointer || foIbSgiXMmAvwnnBySWVoINwAVHL(P_0.pointerId))
			{
				if (kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable())
				{
					CEtYhkpsWKQiZfQakynNFduxkcBV(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void byJzrUDeSOEtlCWerKHsyQQDeiCx(PointerEventData P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH P_1)
		{
			if ((!hasPointer || foIbSgiXMmAvwnnBySWVoINwAVHL(P_0.pointerId)) && !TouchInteractable.iONeyGHaOwtoIAJTjPLQcZwBddoCb(effectivePointerId))
			{
				bXMShAeLLqBkeUIMaxQyHreVCejl();
				base.OnPointerUp(P_0);
			}
		}

		private void RSXMlJwUDnBWPQFMptaaxtPDwrQK(PointerEventData P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH P_1)
		{
			if (hasPointer && !foIbSgiXMmAvwnnBySWVoINwAVHL(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.SUdbtzJPnQgGdEKdknCPcwKPPmVvb(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				EJVHovgSEVWKIbdpgPMIdSvAqmiH.Local => base.allowedMouseButtons, 
				EJVHovgSEVWKIbdpgPMIdSvAqmiH.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && (!flag || TouchInteractable.KKRHWbdFaIIFqBdbMCYjIStQNzxXA(mouseButtonFlags)) && !dsUKDCWyatLsaFUmQLwhVZBtIRWO)
			{
				if (flag)
				{
					if (TouchInteractable.FCVicNqFSeVyGSrqQaUEoDvCEzbN(mouseButtonFlags, out var num))
					{
						rXmuKOedjUmLpNHAfKGhXeueoLme = num;
					}
					else
					{
						rXmuKOedjUmLpNHAfKGhXeueoLme = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					EJVHovgSEVWKIbdpgPMIdSvAqmiH.Local => base.gameObject, 
					EJVHovgSEVWKIbdpgPMIdSvAqmiH.TouchRegion => gJHcnAbAuwtIqKfjwLTNegOCVZwPB.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = sqJjypsZTbIUnjSzIfEMbIDZFNZGA((rXmuKOedjUmLpNHAfKGhXeueoLme != int.MinValue) ? rXmuKOedjUmLpNHAfKGhXeueoLme : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					ourfwqJcJautSuCOuZCfkNBzDSLR(pointerEventData, P_1);
				}
			}
			VqPzboAfkQbTKmDfgQrmTLCCEVyZ = true;
		}

		private void ULCwmTiCuEltzSjwYhDIIlniAdQz(PointerEventData P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH P_1)
		{
			if (hasPointer && !foIbSgiXMmAvwnnBySWVoINwAVHL(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && dsUKDCWyatLsaFUmQLwhVZBtIRWO)
			{
				bXMShAeLLqBkeUIMaxQyHreVCejl();
			}
			base.OnPointerExit(P_0);
			VqPzboAfkQbTKmDfgQrmTLCCEVyZ = false;
		}

		private void CEtYhkpsWKQiZfQakynNFduxkcBV(int P_0, Vector2 P_1, EJVHovgSEVWKIbdpgPMIdSvAqmiH P_2)
		{
			CXokUGvllzhlWpmTvCGPpLECGHlQ = P_0;
			dsUKDCWyatLsaFUmQLwhVZBtIRWO = true;
			if (_followTouchPosition)
			{
				PveJyFNvMTdVhJWOYVtDuqYdejQk(P_0);
			}
			else if (P_2 == EJVHovgSEVWKIbdpgPMIdSvAqmiH.TouchRegion && _moveToTouchPosition)
			{
				AOkarSsNsLKTeDVpfVZHBjqFLBc(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, MrVtqtjDFSQmYoRzxIwllBSDnMsu.TowardTouch);
			}
			WLuEkMVlTeUyphAOkYIgnPiMTPMy();
		}

		private void bXMShAeLLqBkeUIMaxQyHreVCejl()
		{
			yNTJOoUDBLafeTcARzaMsCsxpFNE();
			dsUKDCWyatLsaFUmQLwhVZBtIRWO = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && XCrMGWoxOafJZhBPFmyCqJvTStPi)
			{
				ReturnToDefaultPosition();
			}
			iGmFkgajOcnifncVxQdFAVsYTdeL();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null) || !_useTouchRegionOnly))
			{
				ourfwqJcJautSuCOuZCfkNBzDSLR(eventData, EJVHovgSEVWKIbdpgPMIdSvAqmiH.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null) || !_useTouchRegionOnly))
			{
				byJzrUDeSOEtlCWerKHsyQQDeiCx(eventData, EJVHovgSEVWKIbdpgPMIdSvAqmiH.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null) || !_useTouchRegionOnly))
			{
				RSXMlJwUDnBWPQFMptaaxtPDwrQK(eventData, EJVHovgSEVWKIbdpgPMIdSvAqmiH.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(gJHcnAbAuwtIqKfjwLTNegOCVZwPB != null) || !_useTouchRegionOnly))
			{
				ULCwmTiCuEltzSjwYhDIIlniAdQz(eventData, EJVHovgSEVWKIbdpgPMIdSvAqmiH.Local);
			}
		}

		private void uKWebHFZttqauWqmLjpFnnQhsLQm(PointerEventData P_0)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				ourfwqJcJautSuCOuZCfkNBzDSLR(P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH.TouchRegion);
			}
		}

		private void CwbIqkCIxOybPsTSiQsmKsPcNRMb(PointerEventData P_0)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				byJzrUDeSOEtlCWerKHsyQQDeiCx(P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH.TouchRegion);
			}
		}

		private void vlmdsVVMaGNcoBjMEOYMsRJLYxS(PointerEventData P_0)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				RSXMlJwUDnBWPQFMptaaxtPDwrQK(P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH.TouchRegion);
			}
		}

		private void HhvQseylkLieQaLzJforRbvcpmkp(PointerEventData P_0)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				ULCwmTiCuEltzSjwYhDIIlniAdQz(P_0, EJVHovgSEVWKIbdpgPMIdSvAqmiH.TouchRegion);
			}
		}

		private void OPaWcsgbMadezIQUDFmVZHouhMYmA(float P_0)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && !_useDigitalAxisSimulation)
			{
				HcMHgTLnDSxiFjVdUVgBpujlujCh(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void AZzYtoWHwoHYQytNHeXomJvpVNfB(bool P_0)
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				HcMHgTLnDSxiFjVdUVgBpujlujCh(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void fwaLCJacAcuCNpqOEiVcqujjzrIX()
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				HcMHgTLnDSxiFjVdUVgBpujlujCh(null);
				_onButtonDown.Invoke();
			}
		}

		private void ZzMDPBnuIDDBFHZABPMaqswlAuRb()
		{
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				HcMHgTLnDSxiFjVdUVgBpujlujCh(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
