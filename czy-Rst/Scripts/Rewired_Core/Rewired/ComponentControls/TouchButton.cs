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

		private enum yIJHYaNRAPcgpxietWUIboIsmYI
		{
			None = 0,
			TowardTouch = 1,
			TowardHome = 2
		}

		private enum mASgsQnjCTGzuaqmjRKjjCJXkKMUA
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

		private sealed class moKbxEVDeHmmPKAyxdlXWtNnVpwM : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int wPdfRiNcqynCbMdZzwuqeGmQtdhC;

			private object UEWYeNbtBsEHAIgRatrGEigiBHNjA;

			public float DdmCuybtvqFgjRZjMGRHlxcQRlHxA;

			public TouchButton AjLdcOXdVhIMLLdOncNDfHNrKXbM;

			public PositionType YhWvehAddxXbslVdBcUpeHJubpYGA;

			public Vector2 IXhOdPiofuCQVvelNmazcqCaQDDv;

			public yIJHYaNRAPcgpxietWUIboIsmYI puHiYRoPcuPzrCpRhIpWjyMoVqlL;

			private RectTransform GCKLfJhwFiDxxIxZQMwFeWULWJNJ;

			private Vector2 wxWWOrPbzfeZabeEaOFVVjrSQrpbA;

			private float UgxHYgqfSQyKUPQRgRENakToyHII;

			private float LXcbwzkCGdnPdPpzbCZWNGSYfbeu;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return UEWYeNbtBsEHAIgRatrGEigiBHNjA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UEWYeNbtBsEHAIgRatrGEigiBHNjA;
				}
			}

			[DebuggerHidden]
			public moKbxEVDeHmmPKAyxdlXWtNnVpwM(int P_0)
			{
				wPdfRiNcqynCbMdZzwuqeGmQtdhC = P_0;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = wPdfRiNcqynCbMdZzwuqeGmQtdhC;
				TouchButton ajLdcOXdVhIMLLdOncNDfHNrKXbM = AjLdcOXdVhIMLLdOncNDfHNrKXbM;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					wPdfRiNcqynCbMdZzwuqeGmQtdhC = -1;
					goto IL_010c;
				}
				wPdfRiNcqynCbMdZzwuqeGmQtdhC = -1;
				if (!(DdmCuybtvqFgjRZjMGRHlxcQRlHxA <= 0f))
				{
					GCKLfJhwFiDxxIxZQMwFeWULWJNJ = ajLdcOXdVhIMLLdOncNDfHNrKXbM.VyVEENbwGDUYbEgmFqxSHryubuWYA;
					wxWWOrPbzfeZabeEaOFVVjrSQrpbA = YPQKmEBCRFdXKFPTUMPyDQNLWWKCb.TteDtBUaopNPbGlKgpvNMZyMguEW(GCKLfJhwFiDxxIxZQMwFeWULWJNJ, YhWvehAddxXbslVdBcUpeHJubpYGA);
					float magnitude = (IXhOdPiofuCQVvelNmazcqCaQDDv - wxWWOrPbzfeZabeEaOFVVjrSQrpbA).magnitude;
					if (!(magnitude < 0.01f))
					{
						ajLdcOXdVhIMLLdOncNDfHNrKXbM.RobUhKVZnVbZGRFdcHefCtJHhNcBb = true;
						UgxHYgqfSQyKUPQRgRENakToyHII = magnitude / DdmCuybtvqFgjRZjMGRHlxcQRlHxA;
						LXcbwzkCGdnPdPpzbCZWNGSYfbeu = 0f;
						goto IL_010c;
					}
				}
				goto IL_0119;
				IL_0119:
				ajLdcOXdVhIMLLdOncNDfHNrKXbM.mtlBRwrCbahNuXoVsqiIubZigsXGA(puHiYRoPcuPzrCpRhIpWjyMoVqlL, IXhOdPiofuCQVvelNmazcqCaQDDv, YhWvehAddxXbslVdBcUpeHJubpYGA);
				return false;
				IL_010c:
				if (LXcbwzkCGdnPdPpzbCZWNGSYfbeu <= 1f)
				{
					LXcbwzkCGdnPdPpzbCZWNGSYfbeu += Time.unscaledDeltaTime / UgxHYgqfSQyKUPQRgRENakToyHII;
					YPQKmEBCRFdXKFPTUMPyDQNLWWKCb.GRLDVdFlqQpbIhlwESKFREAwsAeCB(GCKLfJhwFiDxxIxZQMwFeWULWJNJ, Vector2.Lerp(wxWWOrPbzfeZabeEaOFVVjrSQrpbA, IXhOdPiofuCQVvelNmazcqCaQDDv, Mathf.SmoothStep(0f, 1f, LXcbwzkCGdnPdPpzbCZWNGSYfbeu)), YhWvehAddxXbslVdBcUpeHJubpYGA);
					UEWYeNbtBsEHAIgRatrGEigiBHNjA = null;
					wPdfRiNcqynCbMdZzwuqeGmQtdhC = 1;
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

		private const float rNzdMyEfhijVmRXdgyZULwSCYWvDA = 20f;

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

		private float ttqHtGGsrgLpWDeflNDyoisfWZYq;

		private float eQhzYRkhbhWZlIYXbSAWnKtSYmqr;

		private TouchRegion UpAERnBcXwhGYqszdKsONkArdAjb;

		private Vector2 GyjTUFPZJDsnyVwodmZhXJtzSheS;

		private bool RobUhKVZnVbZGRFdcHefCtJHhNcBb;

		private bool pNumzlhbUkRGjwbCKXrfZIXSbitfA;

		private yIJHYaNRAPcgpxietWUIboIsmYI nKrKeHxWMYLUxCuwvKgFnjlcihLt;

		private int gLlnwlasbdKNisFOyNOoMhiFjpRf = int.MinValue;

		private int HtlwXbpSjWDDlOOKmMHIuzSlCOGP = int.MinValue;

		[NonSerialized]
		private bool DbPkJjVIgnHBOKRtHozUmCrqOper;

		[NonSerialized]
		private bool rcSlKLVykWkqmtIwtXsZwHmPfbGcA;

		private IEnumerator YSkerniFAWsmyQlmGXrAUOyJxgNcA;

		private QzalQbKCBuslmYXXuSeAUGvggaMdA mHhUkOOMWGcMMCXGDUyHeVXHpTLLA = new QzalQbKCBuslmYXXuSeAUGvggaMdA();

		private Action<yIJHYaNRAPcgpxietWUIboIsmYI> VdaHRinIsjphFiossnoDJFbcEYZCA;

		private Action<yIJHYaNRAPcgpxietWUIboIsmYI> BSXMjaZfTtnqxFlFTURcbFllDKtj;

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

		private Dictionary<int, PointerEventData> mXGCwHhdLNxXmiiQXaupYkVdVQMS;

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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (UcozDFgkkQWadFrIGqbztcOTMPxT())
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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
						AVZddvbsfposuABbDrMjdgocicDMb();
					}
					else
					{
						mHhUkOOMWGcMMCXGDUyHeVXHpTLLA.ExoJtgNHkcBcwCMkScBFKTeWckCIA();
					}
					HAozJjtCaBQEIiVJLswvClYOjXTs();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return gLlnwlasbdKNisFOyNOoMhiFjpRf;
			}
			set
			{
				gLlnwlasbdKNisFOyNOoMhiFjpRf = value;
			}
		}

		public bool hasPointer => gLlnwlasbdKNisFOyNOoMhiFjpRf != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<yIJHYaNRAPcgpxietWUIboIsmYI> moveStartedDelegate
		{
			get
			{
				if (VdaHRinIsjphFiossnoDJFbcEYZCA == null)
				{
					return VdaHRinIsjphFiossnoDJFbcEYZCA = JrVmaGUTAISrDdUiomzjVKjufPem;
				}
				return VdaHRinIsjphFiossnoDJFbcEYZCA;
			}
		}

		private Action<yIJHYaNRAPcgpxietWUIboIsmYI> moveEndedDelegate
		{
			get
			{
				if (BSXMjaZfTtnqxFlFTURcbFllDKtj == null)
				{
					return BSXMjaZfTtnqxFlFTURcbFllDKtj = HGayALGwoZGhtQDWeCZSKaMXIAab;
				}
				return BSXMjaZfTtnqxFlFTURcbFllDKtj;
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
				return ttqHtGGsrgLpWDeflNDyoisfWZYq;
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
				return eQhzYRkhbhWZlIYXbSAWnKtSYmqr;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (gLlnwlasbdKNisFOyNOoMhiFjpRf == int.MinValue)
				{
					return int.MinValue;
				}
				if (HtlwXbpSjWDDlOOKmMHIuzSlCOGP != int.MinValue)
				{
					return HtlwXbpSjWDDlOOKmMHIuzSlCOGP;
				}
				return gLlnwlasbdKNisFOyNOoMhiFjpRf;
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
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			yTgrNXYomYABtKLaZwNyXnxbRmju(base.VyVEENbwGDUYbEgmFqxSHryubuWYA.anchoredPosition);
		}

		private void yTgrNXYomYABtKLaZwNyXnxbRmju(Vector2 P_0)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				GyjTUFPZJDsnyVwodmZhXJtzSheS = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				ZWATPwkudtROBfoajAuDOcOGTFLk(GyjTUFPZJDsnyVwodmZhXJtzSheS, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, yIJHYaNRAPcgpxietWUIboIsmYI.TowardHome);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
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
				GyjTUFPZJDsnyVwodmZhXJtzSheS = base.VyVEENbwGDUYbEgmFqxSHryubuWYA.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				iOdKYtvIsEkhJMGPhQIBkRVfygMC();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				uqpvXSxBdciqAsrvTMJdOHfWenSP();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				iOdKYtvIsEkhJMGPhQIBkRVfygMC();
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
			base.QcGIWLDDCIjLkBgZbJZNrqDVlpFrb();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				GPXCGrbQxdbiIDWHACpUFtIYNQVXb();
				ikkJpLxARLetncpiqCqqYZSJCdgSA();
				puhftTHsgMVVfbPqXSuFIzBWqBJVA();
				if (_followTouchPosition)
				{
					fKhTFaSBIBjuTQdJTtquDNmwhUiy(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!txYYAAoRiaPItjnHJYZsolhdcVNl())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && sBSyLdyBEZqxqMQAUOeeTuCypwge)
			{
				AXiqrbJHOthQgiWhbUsFiQksmOuF(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			CoPWsupLNkdAvQXWpAljrUIAFjko();
			_axis.AxisValueChangedEvent += sBdNVVtYDqXBkHPLSbqMcMMfkikb;
			_axis.ButtonValueChangedEvent += eTeYxEHDTqLaihmyUolwHmpeszju;
			_axis.ButtonDownEvent += BkvrnupYImfnteVUBMCDLKXsBneI;
			_axis.ButtonUpEvent += dHeUaqgPkKAinaSUEmQnaTQDcaGdc;
		}

		internal void OnUnsubscribeEvents()
		{
			jcjdhAAdqcPbMjgHcqJkjiuTMpoO();
			_axis.AxisValueChangedEvent -= sBdNVVtYDqXBkHPLSbqMcMMfkikb;
			_axis.ButtonValueChangedEvent -= eTeYxEHDTqLaihmyUolwHmpeszju;
			_axis.ButtonDownEvent -= BkvrnupYImfnteVUBMCDLKXsBneI;
			_axis.ButtonUpEvent -= dHeUaqgPkKAinaSUEmQnaTQDcaGdc;
		}

		internal void OnSetProperty()
		{
			RxXwmSTcDqekzOuyZktlaLRThxqq();
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				iOdKYtvIsEkhJMGPhQIBkRVfygMC();
			}
		}

		internal void OnClear()
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				gLlnwlasbdKNisFOyNOoMhiFjpRf = int.MinValue;
				HtlwXbpSjWDDlOOKmMHIuzSlCOGP = int.MinValue;
				DbPkJjVIgnHBOKRtHozUmCrqOper = false;
				rcSlKLVykWkqmtIwtXsZwHmPfbGcA = false;
				if (_returnOnRelease && pNumzlhbUkRGjwbCKXrfZIXSbitfA && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				pNumzlhbUkRGjwbCKXrfZIXSbitfA = false;
				RobUhKVZnVbZGRFdcHefCtJHhNcBb = false;
				nKrKeHxWMYLUxCuwvKgFnjlcihLt = yIJHYaNRAPcgpxietWUIboIsmYI.None;
				xNpRNbkEwMUUYPOEJUcikwPbBTPf();
				_axis.Clear();
				ttqHtGGsrgLpWDeflNDyoisfWZYq = 0f;
				eQhzYRkhbhWZlIYXbSAWnKtSYmqr = 0f;
				iOdKYtvIsEkhJMGPhQIBkRVfygMC();
			}
		}

		public override void ClearValue()
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				_axis.Clear();
				ttqHtGGsrgLpWDeflNDyoisfWZYq = 0f;
				if (sBSyLdyBEZqxqMQAUOeeTuCypwge)
				{
					base.GsoZbMPaQLTBrRsfvicmEcjMgUcgA.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				return false;
			}
			if (!GlaXMdVzEWtLRKxLWJPCCCZtpeXE())
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
			if (base.yhSTFcgNFyBkbahIEXDHacLdqfjKA(gameObject))
			{
				return true;
			}
			if (UpAERnBcXwhGYqszdKsONkArdAjb != null)
			{
				return UpAERnBcXwhGYqszdKsONkArdAjb.gameObject == gameObject;
			}
			return false;
		}

		private void puhftTHsgMVVfbPqXSuFIzBWqBJVA()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					quikuIdViIRPnlPaJJfWzxHZhqDL();
				}
				else
				{
					dDtAOYOsMzjEaoRNcIkhiIPGFYnb();
				}
			}
		}

		private void quikuIdViIRPnlPaJJfWzxHZhqDL()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += ttqHtGGsrgLpWDeflNDyoisfWZYq;
			num = MathTools.Clamp(num, -1f, 1f);
			ELOBzGlwWahdeYGsEjFUMvROJKsg(num, true);
		}

		private void dDtAOYOsMzjEaoRNcIkhiIPGFYnb()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num2 = ttqHtGGsrgLpWDeflNDyoisfWZYq;
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
				ELOBzGlwWahdeYGsEjFUMvROJKsg(num4, true);
			}
		}

		private void ELOBzGlwWahdeYGsEjFUMvROJKsg(float P_0, bool P_1)
		{
			eQhzYRkhbhWZlIYXbSAWnKtSYmqr = ttqHtGGsrgLpWDeflNDyoisfWZYq;
			ttqHtGGsrgLpWDeflNDyoisfWZYq = P_0;
			if (P_0 != eQhzYRkhbhWZlIYXbSAWnKtSYmqr)
			{
				vPLwwZScbMSKSuXMXuQiQJCkGUmW(null);
			}
			if (P_1 && P_0 != eQhzYRkhbhWZlIYXbSAWnKtSYmqr)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void oUrFTpEhDoRjJwoBdJoVGmYNjZad()
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

		private void UAvycZbynaeYVqAIcZBavJGRetCs()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void iOdKYtvIsEkhJMGPhQIBkRVfygMC()
		{
			_targetCustomControllerElement.ClearElementCaches();
			ikkJpLxARLetncpiqCqqYZSJCdgSA();
			AVZddvbsfposuABbDrMjdgocicDMb();
		}

		private void AVZddvbsfposuABbDrMjdgocicDMb()
		{
			if (_manageRaycasting)
			{
				mHhUkOOMWGcMMCXGDUyHeVXHpTLLA.pYuAdJCpRMTzPwAPnLirIOgKkrIh(base.transform, MLbfzQcMpnalbYyBsdWNDybcwzfEA());
			}
		}

		private bool MLbfzQcMpnalbYyBsdWNDybcwzfEA()
		{
			if (UpAERnBcXwhGYqszdKsONkArdAjb != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void dlbbJNohTbuosfcRJkviIlNYObFK(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				sNCecIujXFApjlzqTdlagOiDSoWw(P_0);
				P_0.PointerDownEvent += MTRMDyWlrzFSKVbjEkyeAruelmeh;
				P_0.PointerUpEvent += klwznVRwCOoNVvhEfEJVrkIdubzS;
				P_0.PointerEnterEvent += JsitBXOpKwBvEnDmTtJzxCpYeqReA;
				P_0.PointerExitEvent += lvqAPXhBuNvDcjcaSIpSBmPvdOSpA;
			}
		}

		private void sNCecIujXFApjlzqTdlagOiDSoWw(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= MTRMDyWlrzFSKVbjEkyeAruelmeh;
				P_0.PointerUpEvent -= klwznVRwCOoNVvhEfEJVrkIdubzS;
				P_0.PointerEnterEvent -= JsitBXOpKwBvEnDmTtJzxCpYeqReA;
				P_0.PointerExitEvent -= lvqAPXhBuNvDcjcaSIpSBmPvdOSpA;
			}
		}

		private void ikkJpLxARLetncpiqCqqYZSJCdgSA()
		{
			if (!(UpAERnBcXwhGYqszdKsONkArdAjb == _touchRegion))
			{
				sNCecIujXFApjlzqTdlagOiDSoWw(UpAERnBcXwhGYqszdKsONkArdAjb);
				UpAERnBcXwhGYqszdKsONkArdAjb = _touchRegion;
				dlbbJNohTbuosfcRJkviIlNYObFK(UpAERnBcXwhGYqszdKsONkArdAjb);
			}
		}

		private void iPRsRNBWokDesdUCeLqeiZjnEzvr(Vector2 P_0, bool P_1, float P_2, yIJHYaNRAPcgpxietWUIboIsmYI P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = YPQKmEBCRFdXKFPTUMPyDQNLWWKCb.UTfFJUBtAkCgOabYdpaagHBxytjBA(base.pvOOYOdfJNCdvfQqvCELdEURThOr, rectTransform, P_0);
			Vector2 pivot = base.VyVEENbwGDUYbEgmFqxSHryubuWYA.pivot;
			Vector2 sizeDelta = base.VyVEENbwGDUYbEgmFqxSHryubuWYA.sizeDelta;
			Vector3 localScale = base.VyVEENbwGDUYbEgmFqxSHryubuWYA.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			ZWATPwkudtROBfoajAuDOcOGTFLk(vector, PositionType.Local, P_1, P_2, P_3);
		}

		private void ZWATPwkudtROBfoajAuDOcOGTFLk(Vector2 P_0, PositionType P_1, bool P_2, float P_3, yIJHYaNRAPcgpxietWUIboIsmYI P_4)
		{
			if (RobUhKVZnVbZGRFdcHefCtJHhNcBb && P_2 && nKrKeHxWMYLUxCuwvKgFnjlcihLt == P_4)
			{
				return;
			}
			if (RobUhKVZnVbZGRFdcHefCtJHhNcBb && YSkerniFAWsmyQlmGXrAUOyJxgNcA != null)
			{
				xNpRNbkEwMUUYPOEJUcikwPbBTPf();
				RobUhKVZnVbZGRFdcHefCtJHhNcBb = false;
				nKrKeHxWMYLUxCuwvKgFnjlcihLt = yIJHYaNRAPcgpxietWUIboIsmYI.None;
			}
			if (base.pvOOYOdfJNCdvfQqvCELdEURThOr == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.pvOOYOdfJNCdvfQqvCELdEURThOr.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.mlgUlJrKAdVYJCrdtlahwJTPEvDn;
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
				YSkerniFAWsmyQlmGXrAUOyJxgNcA = smJcHppWlEcOFCCuSIyrZLhttgEq(P_0, P_1, P_3, P_4);
				StartCoroutine(YSkerniFAWsmyQlmGXrAUOyJxgNcA);
				nKrKeHxWMYLUxCuwvKgFnjlcihLt = P_4;
				pNumzlhbUkRGjwbCKXrfZIXSbitfA = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				mtlBRwrCbahNuXoVsqiIubZigsXGA(P_4, P_0, P_1);
			}
		}

		[IteratorStateMachine(typeof(moKbxEVDeHmmPKAyxdlXWtNnVpwM))]
		private IEnumerator smJcHppWlEcOFCCuSIyrZLhttgEq(Vector2 P_0, PositionType P_1, float P_2, yIJHYaNRAPcgpxietWUIboIsmYI P_3)
		{
			return new moKbxEVDeHmmPKAyxdlXWtNnVpwM(0)
			{
				AjLdcOXdVhIMLLdOncNDfHNrKXbM = this,
				IXhOdPiofuCQVvelNmazcqCaQDDv = P_0,
				YhWvehAddxXbslVdBcUpeHJubpYGA = P_1,
				DdmCuybtvqFgjRZjMGRHlxcQRlHxA = P_2,
				puHiYRoPcuPzrCpRhIpWjyMoVqlL = P_3
			};
		}

		private void mtlBRwrCbahNuXoVsqiIubZigsXGA(yIJHYaNRAPcgpxietWUIboIsmYI P_0, Vector2 P_1, PositionType P_2)
		{
			YPQKmEBCRFdXKFPTUMPyDQNLWWKCb.GRLDVdFlqQpbIhlwESKFREAwsAeCB(base.VyVEENbwGDUYbEgmFqxSHryubuWYA, P_1, P_2);
			RobUhKVZnVbZGRFdcHefCtJHhNcBb = false;
			nKrKeHxWMYLUxCuwvKgFnjlcihLt = yIJHYaNRAPcgpxietWUIboIsmYI.None;
			switch (P_0)
			{
			case yIJHYaNRAPcgpxietWUIboIsmYI.TowardHome:
				pNumzlhbUkRGjwbCKXrfZIXSbitfA = false;
				break;
			case yIJHYaNRAPcgpxietWUIboIsmYI.TowardTouch:
				pNumzlhbUkRGjwbCKXrfZIXSbitfA = true;
				break;
			}
			xNpRNbkEwMUUYPOEJUcikwPbBTPf();
			moveEndedDelegate(P_0);
		}

		private void JrVmaGUTAISrDdUiomzjVKjufPem(yIJHYaNRAPcgpxietWUIboIsmYI P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && UpAERnBcXwhGYqszdKsONkArdAjb != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == yIJHYaNRAPcgpxietWUIboIsmYI.TowardTouch)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					mHhUkOOMWGcMMCXGDUyHeVXHpTLLA.pYuAdJCpRMTzPwAPnLirIOgKkrIh(base.transform, flag2);
				}
			}
		}

		private void HGayALGwoZGhtQDWeCZSKaMXIAab(yIJHYaNRAPcgpxietWUIboIsmYI P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && UpAERnBcXwhGYqszdKsONkArdAjb != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == yIJHYaNRAPcgpxietWUIboIsmYI.TowardHome)
				{
					flag = true;
					flag2 = MLbfzQcMpnalbYyBsdWNDybcwzfEA();
				}
				if (flag)
				{
					mHhUkOOMWGcMMCXGDUyHeVXHpTLLA.pYuAdJCpRMTzPwAPnLirIOgKkrIh(base.transform, flag2);
				}
			}
		}

		private void fKhTFaSBIBjuTQdJTtquDNmwhUiy(int P_0)
		{
			if (TouchInteractable.IZIBozfCzyDkZOWWaGlLiEtSPYyB(P_0))
			{
				iPRsRNBWokDesdUCeLqeiZjnEzvr(TouchInteractable.RKVcirKVVrPBttTpsXyGcfygGdOQ(P_0), false, 0f, yIJHYaNRAPcgpxietWUIboIsmYI.TowardTouch);
			}
		}

		private void xNpRNbkEwMUUYPOEJUcikwPbBTPf()
		{
			if (YSkerniFAWsmyQlmGXrAUOyJxgNcA != null)
			{
				try
				{
					StopCoroutine(YSkerniFAWsmyQlmGXrAUOyJxgNcA);
				}
				catch
				{
				}
				YSkerniFAWsmyQlmGXrAUOyJxgNcA = null;
			}
		}

		private void GPXCGrbQxdbiIDWHACpUFtIYNQVXb()
		{
			if (hasPointer && !TouchInteractable.IZIBozfCzyDkZOWWaGlLiEtSPYyB(effectivePointerId))
			{
				PointerEventData pointerEventData = qxDtUoaoGojSCgmVoqxTWjsEaeGq(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					TIXFnPCLLSMfZEfnBWTBelPDSZomA(pointerEventData);
				}
				else
				{
					LiPJbtnBZaswWDHPxTyDuMCOLkJx();
				}
			}
		}

		private bool UcozDFgkkQWadFrIGqbztcOTMPxT()
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

		private void YCOYwtHvNPQJFQKjIcvhVIuqgJpw()
		{
			gLlnwlasbdKNisFOyNOoMhiFjpRf = int.MinValue;
			HtlwXbpSjWDDlOOKmMHIuzSlCOGP = int.MinValue;
		}

		private bool PYFrvDvASmcAMBuUzOXgZDhxNixHb(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (gLlnwlasbdKNisFOyNOoMhiFjpRf == int.MinValue)
			{
				return false;
			}
			if (gLlnwlasbdKNisFOyNOoMhiFjpRf == P_0)
			{
				return true;
			}
			if (TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0) && HtlwXbpSjWDDlOOKmMHIuzSlCOGP != int.MinValue && P_0 == HtlwXbpSjWDDlOOKmMHIuzSlCOGP)
			{
				return true;
			}
			return false;
		}

		private PointerEventData SzCPeKtFDfdnRajcDWZjYDxMvjzU(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = qxDtUoaoGojSCgmVoqxTWjsEaeGq(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.RKVcirKVVrPBttTpsXyGcfygGdOQ(P_0);
			if (TouchInteractable.DrDqLttSkyvwiIzPAjMBncpcYrPv(P_0))
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
				if (!TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0))
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

		private PointerEventData VSaHBLHMFdIbeDHeUyTRZGwoVjCJ(int P_0)
		{
			PointerEventData pointerEventData = qxDtUoaoGojSCgmVoqxTWjsEaeGq(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.DrDqLttSkyvwiIzPAjMBncpcYrPv(P_0))
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
				if (!TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0))
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

		private void TIXFnPCLLSMfZEfnBWTBelPDSZomA(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				VSaHBLHMFdIbeDHeUyTRZGwoVjCJ(effectivePointerId);
			}
		}

		private PointerEventData qxDtUoaoGojSCgmVoqxTWjsEaeGq(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (mXGCwHhdLNxXmiiQXaupYkVdVQMS == null)
			{
				mXGCwHhdLNxXmiiQXaupYkVdVQMS = new Dictionary<int, PointerEventData>();
			}
			if (!mXGCwHhdLNxXmiiQXaupYkVdVQMS.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				mXGCwHhdLNxXmiiQXaupYkVdVQMS.Add(P_0, value);
				if (TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0))
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

		private void KimJyBQaBoCngtTVvRUAPpDmiDxG(PointerEventData P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA P_1)
		{
			if (!hasPointer || PYFrvDvASmcAMBuUzOXgZDhxNixHb(P_0.pointerId))
			{
				if (GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable())
				{
					gQoSJlaSbQZliclLfggLsGRcSzNB(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void TIKrWpKuOMLQNNPvseKZJRmCYKyX(PointerEventData P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA P_1)
		{
			if ((!hasPointer || PYFrvDvASmcAMBuUzOXgZDhxNixHb(P_0.pointerId)) && !TouchInteractable.IZIBozfCzyDkZOWWaGlLiEtSPYyB(effectivePointerId))
			{
				LiPJbtnBZaswWDHPxTyDuMCOLkJx();
				base.OnPointerUp(P_0);
			}
		}

		private void vEQKbqnhFtekhJZBuycBAJdSaOscA(PointerEventData P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA P_1)
		{
			if (hasPointer && !PYFrvDvASmcAMBuUzOXgZDhxNixHb(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.kFwYjYQjSYfVGTyWeFqBXijYCzsB(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				mASgsQnjCTGzuaqmjRKjjCJXkKMUA.Local => base.allowedMouseButtons, 
				mASgsQnjCTGzuaqmjRKjjCJXkKMUA.TouchRegion => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && (!flag || TouchInteractable.sZOlWOgCsSeAIquqRVBCziBDPwZl(mouseButtonFlags)) && !DbPkJjVIgnHBOKRtHozUmCrqOper)
			{
				if (flag)
				{
					if (TouchInteractable.lkQTlwjROwXyeNpzHpZbVfPTZrXg(mouseButtonFlags, out var htlwXbpSjWDDlOOKmMHIuzSlCOGP))
					{
						HtlwXbpSjWDDlOOKmMHIuzSlCOGP = htlwXbpSjWDDlOOKmMHIuzSlCOGP;
					}
					else
					{
						HtlwXbpSjWDDlOOKmMHIuzSlCOGP = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					mASgsQnjCTGzuaqmjRKjjCJXkKMUA.Local => base.gameObject, 
					mASgsQnjCTGzuaqmjRKjjCJXkKMUA.TouchRegion => UpAERnBcXwhGYqszdKsONkArdAjb.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = SzCPeKtFDfdnRajcDWZjYDxMvjzU((HtlwXbpSjWDDlOOKmMHIuzSlCOGP != int.MinValue) ? HtlwXbpSjWDDlOOKmMHIuzSlCOGP : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					KimJyBQaBoCngtTVvRUAPpDmiDxG(pointerEventData, P_1);
				}
			}
			rcSlKLVykWkqmtIwtXsZwHmPfbGcA = true;
		}

		private void gPoNmEhoJSWHzVtJPObrxDsdJwFc(PointerEventData P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA P_1)
		{
			if (hasPointer && !PYFrvDvASmcAMBuUzOXgZDhxNixHb(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && DbPkJjVIgnHBOKRtHozUmCrqOper)
			{
				LiPJbtnBZaswWDHPxTyDuMCOLkJx();
			}
			base.OnPointerExit(P_0);
			rcSlKLVykWkqmtIwtXsZwHmPfbGcA = false;
		}

		private void gQoSJlaSbQZliclLfggLsGRcSzNB(int P_0, Vector2 P_1, mASgsQnjCTGzuaqmjRKjjCJXkKMUA P_2)
		{
			gLlnwlasbdKNisFOyNOoMhiFjpRf = P_0;
			DbPkJjVIgnHBOKRtHozUmCrqOper = true;
			if (_followTouchPosition)
			{
				fKhTFaSBIBjuTQdJTtquDNmwhUiy(P_0);
			}
			else if (P_2 == mASgsQnjCTGzuaqmjRKjjCJXkKMUA.TouchRegion && _moveToTouchPosition)
			{
				iPRsRNBWokDesdUCeLqeiZjnEzvr(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, yIJHYaNRAPcgpxietWUIboIsmYI.TowardTouch);
			}
			oUrFTpEhDoRjJwoBdJoVGmYNjZad();
		}

		private void LiPJbtnBZaswWDHPxTyDuMCOLkJx()
		{
			YCOYwtHvNPQJFQKjIcvhVIuqgJpw();
			DbPkJjVIgnHBOKRtHozUmCrqOper = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && pNumzlhbUkRGjwbCKXrfZIXSbitfA)
			{
				ReturnToDefaultPosition();
			}
			UAvycZbynaeYVqAIcZBavJGRetCs();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(UpAERnBcXwhGYqszdKsONkArdAjb != null) || !_useTouchRegionOnly))
			{
				KimJyBQaBoCngtTVvRUAPpDmiDxG(eventData, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.Local);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(UpAERnBcXwhGYqszdKsONkArdAjb != null) || !_useTouchRegionOnly))
			{
				TIKrWpKuOMLQNNPvseKZJRmCYKyX(eventData, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.Local);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(UpAERnBcXwhGYqszdKsONkArdAjb != null) || !_useTouchRegionOnly))
			{
				vEQKbqnhFtekhJZBuycBAJdSaOscA(eventData, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.Local);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(UpAERnBcXwhGYqszdKsONkArdAjb != null) || !_useTouchRegionOnly))
			{
				gPoNmEhoJSWHzVtJPObrxDsdJwFc(eventData, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.Local);
			}
		}

		private void MTRMDyWlrzFSKVbjEkyeAruelmeh(PointerEventData P_0)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				KimJyBQaBoCngtTVvRUAPpDmiDxG(P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.TouchRegion);
			}
		}

		private void klwznVRwCOoNVvhEfEJVrkIdubzS(PointerEventData P_0)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				TIKrWpKuOMLQNNPvseKZJRmCYKyX(P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.TouchRegion);
			}
		}

		private void JsitBXOpKwBvEnDmTtJzxCpYeqReA(PointerEventData P_0)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				vEQKbqnhFtekhJZBuycBAJdSaOscA(P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.TouchRegion);
			}
		}

		private void lvqAPXhBuNvDcjcaSIpSBmPvdOSpA(PointerEventData P_0)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				gPoNmEhoJSWHzVtJPObrxDsdJwFc(P_0, mASgsQnjCTGzuaqmjRKjjCJXkKMUA.TouchRegion);
			}
		}

		private void sBdNVVtYDqXBkHPLSbqMcMMfkikb(float P_0)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && !_useDigitalAxisSimulation)
			{
				vPLwwZScbMSKSuXMXuQiQJCkGUmW(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void eTeYxEHDTqLaihmyUolwHmpeszju(bool P_0)
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				vPLwwZScbMSKSuXMXuQiQJCkGUmW(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void BkvrnupYImfnteVUBMCDLKXsBneI()
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				vPLwwZScbMSKSuXMXuQiQJCkGUmW(null);
				_onButtonDown.Invoke();
			}
		}

		private void dHeUaqgPkKAinaSUEmQnaTQDcaGdc()
		{
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd)
			{
				vPLwwZScbMSKSuXMXuQiQJCkGUmW(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
