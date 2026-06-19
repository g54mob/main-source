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
	[AddComponentMenu("Rewired/Touch Button")]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[DisallowMultipleComponent]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum zKRQSjSInJqLsXbtqlZaZmzeeBA
		{
			DVDMTdEnkAaktJFJqNakDhECjSAS = 0,
			gGCEEPKfpLJhbIEWxebhHfEPKFqR = 1,
			TwXdFBErLOFXUbbLkASzGEGrOQgJ = 2
		}

		private enum zqHlgpPaVYdAwGxKbubVPBAddrO
		{
			SaidbJQgZbwJIUhEOfXVjHpYIsz = 0,
			uVeuqRrVqCbFkUaeJPlhWwYcYgk = 1
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

		private sealed class dYhzRpKRJLhhWqixvGPXDzyjzlL : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			public TouchButton kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public Vector2 aZvcttCYZyvpcbqSuEdfCWeofxD;

			public PositionType gKIedNefRQHDkodooGkfIArMTaNi;

			public float brHFgkYEWMuNyWyjPqgxFrGPZCw;

			public zKRQSjSInJqLsXbtqlZaZmzeeBA BbHMTdIqfNjQoQZLIgtdqXgYBym;

			public RectTransform McbGrbqUanCpFjHeEaKObPBaBrol;

			public Vector2 tfRgUxdZghIuOfGkQsgAPPEEgi;

			public float kDSTnPvOGZfpoljwBeybmXbDrHb;

			public float BjFVhyRYTcNSsUknsNCRZGFGit;

			public float VDhwPrVFtWgNecuPHMTEOjdMEnf;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (!(brHFgkYEWMuNyWyjPqgxFrGPZCw <= 0f))
					{
						McbGrbqUanCpFjHeEaKObPBaBrol = kdBZqupjvsCsVkwJiOeEQzkEDVO.rectTransform;
						tfRgUxdZghIuOfGkQsgAPPEEgi = HIVfPxnnHQLxQzKCApRSVEGlhlG.VXVbSMdoMzOHvRIOaocImhqNoIls(McbGrbqUanCpFjHeEaKObPBaBrol, gKIedNefRQHDkodooGkfIArMTaNi);
						kDSTnPvOGZfpoljwBeybmXbDrHb = (aZvcttCYZyvpcbqSuEdfCWeofxD - tfRgUxdZghIuOfGkQsgAPPEEgi).magnitude;
						if (!(kDSTnPvOGZfpoljwBeybmXbDrHb < 0.01f))
						{
							kdBZqupjvsCsVkwJiOeEQzkEDVO.SmvaITkflCMBkGxRBYnXTbWkkTfI = true;
							BjFVhyRYTcNSsUknsNCRZGFGit = kDSTnPvOGZfpoljwBeybmXbDrHb / brHFgkYEWMuNyWyjPqgxFrGPZCw;
							VDhwPrVFtWgNecuPHMTEOjdMEnf = 0f;
							goto IL_0125;
						}
					}
					goto IL_0132;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_0125;
					}
					IL_0125:
					if (VDhwPrVFtWgNecuPHMTEOjdMEnf <= 1f)
					{
						VDhwPrVFtWgNecuPHMTEOjdMEnf += Time.unscaledDeltaTime / BjFVhyRYTcNSsUknsNCRZGFGit;
						HIVfPxnnHQLxQzKCApRSVEGlhlG.OVadyLfTUUTuKfhAwqhiaCPfusM(McbGrbqUanCpFjHeEaKObPBaBrol, Vector2.Lerp(tfRgUxdZghIuOfGkQsgAPPEEgi, aZvcttCYZyvpcbqSuEdfCWeofxD, Mathf.SmoothStep(0f, 1f, VDhwPrVFtWgNecuPHMTEOjdMEnf)), gKIedNefRQHDkodooGkfIArMTaNi);
						ajbaQItphrIyqhowgmMTfPkCBvcN = null;
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_0132;
					IL_0132:
					kdBZqupjvsCsVkwJiOeEQzkEDVO.cmBvOieMeiAlEJFxqjiAxiPCODUz(BbHMTdIqfNjQoQZLIgtdqXgYBym, aZvcttCYZyvpcbqSuEdfCWeofxD, gKIedNefRQHDkodooGkfIArMTaNi);
					break;
				}
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
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public dYhzRpKRJLhhWqixvGPXDzyjzlL(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
			}
		}

		private const float bflvLrnbZzGPiNMuGAdiUGqUGKl = 20f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[SerializeField]
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[CustomObfuscation(rename = false)]
		private ButtonType _buttonType;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		[SerializeField]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[CustomObfuscation(rename = false)]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[SerializeField]
		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[CustomObfuscation(rename = false)]
		private StandaloneAxis _axis = new StandaloneAxis();

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private TouchRegion _touchRegion;

		[SerializeField]
		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _useTouchRegionOnly = true;

		[SerializeField]
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _animateOnMoveToTouch = true;

		[Range(0f, 20f)]
		[SerializeField]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[CustomObfuscation(rename = false)]
		private float _moveToTouchSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		private bool _animateOnReturn = true;

		[SerializeField]
		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _manageRaycasting = true;

		private float bHPjrbVwljVSnFQuaZYoVEnOsiU;

		private float kCpBmnmFsUyOUCAaftPhrUcMcXX;

		private TouchRegion cpxBlgEyjIcWshNPxzBsniNNJkyD;

		private Vector2 ESTaPdewZtSahmPUKzoflkAKMVv;

		private bool SmvaITkflCMBkGxRBYnXTbWkkTfI;

		private bool DXPWlsSRQPHNmzewPdbPyhILhKS;

		private zKRQSjSInJqLsXbtqlZaZmzeeBA LhJvrDDmJrlbqsvdnButdExrtcK;

		private int PardoywaEUoKKSsaXRTpyRWFjix = int.MinValue;

		private int wXvOWZmXwMXRglCvftHOGqgfPkV = int.MinValue;

		[NonSerialized]
		private bool traAtpHvLXNexVrCRTWuJipMjwd;

		[NonSerialized]
		private bool IqanMrGVhLvExACtCdEAMqyHqQT;

		private IEnumerator kQTOJOLgZsciyMhDXQTDfKQMJLR;

		private VRvPQHmdsvpeRqEMyCcOXcbSDWZ gVDpuIwVZhgiuMzhuilHBfaLqwO = new VRvPQHmdsvpeRqEMyCcOXcbSDWZ();

		private Action<zKRQSjSInJqLsXbtqlZaZmzeeBA> MftwcOliBAkeDpiiWOstPBBqngB;

		private Action<zKRQSjSInJqLsXbtqlZaZmzeeBA> tFcaIvwBcPEoBkDQeHWZBdgRxPyL;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the axis value changes.")]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button value changes.")]
		[SerializeField]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the button is released.")]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> rbcBHqhIjllVjPfdpcIoyNuqPFIJ;

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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (yAYwMKrQXZHXrNSqWOThanYtPym())
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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
						PCPARCNgTWmorJBKnCnllnzHUlI();
					}
					else
					{
						gVDpuIwVZhgiuMzhuilHBfaLqwO.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
					}
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public int pointerId
		{
			get
			{
				return PardoywaEUoKKSsaXRTpyRWFjix;
			}
			set
			{
				PardoywaEUoKKSsaXRTpyRWFjix = value;
			}
		}

		public bool hasPointer => PardoywaEUoKKSsaXRTpyRWFjix != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<zKRQSjSInJqLsXbtqlZaZmzeeBA> moveStartedDelegate
		{
			get
			{
				if (MftwcOliBAkeDpiiWOstPBBqngB == null)
				{
					return MftwcOliBAkeDpiiWOstPBBqngB = oTranSwyLPbQXnqMXiyRcliIkxw;
				}
				return MftwcOliBAkeDpiiWOstPBBqngB;
			}
		}

		private Action<zKRQSjSInJqLsXbtqlZaZmzeeBA> moveEndedDelegate
		{
			get
			{
				if (tFcaIvwBcPEoBkDQeHWZBdgRxPyL == null)
				{
					return tFcaIvwBcPEoBkDQeHWZBdgRxPyL = lGOpDmQOzMduncmwRjrmDnVzawx;
				}
				return tFcaIvwBcPEoBkDQeHWZBdgRxPyL;
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
				return bHPjrbVwljVSnFQuaZYoVEnOsiU;
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
				return kCpBmnmFsUyOUCAaftPhrUcMcXX;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (PardoywaEUoKKSsaXRTpyRWFjix == int.MinValue)
				{
					return int.MinValue;
				}
				if (wXvOWZmXwMXRglCvftHOGqgfPkV != int.MinValue)
				{
					return wXvOWZmXwMXRglCvftHOGqgfPkV;
				}
				return PardoywaEUoKKSsaXRTpyRWFjix;
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
			if (base.initialized)
			{
				_axis.SetRawValue(value);
			}
		}

		public void SetDefaultPosition()
		{
			bVLtRgpzeeKoifEZUrauPucYriA(base.rectTransform.anchoredPosition);
		}

		private void bVLtRgpzeeKoifEZUrauPucYriA(Vector2 P_0)
		{
			if (base.initialized)
			{
				ESTaPdewZtSahmPUKzoflkAKMVv = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.initialized)
			{
				MqBlqPCfzHAXSELFPDuRHSHawkMF(ESTaPdewZtSahmPUKzoflkAKMVv, PositionType.SSYkzosXiTTPBCcOPEVRuAPZbiC, !instant && _animateOnReturn, _returnSpeed, zKRQSjSInJqLsXbtqlZaZmzeeBA.TwXdFBErLOFXUbbLkASzGEGrOQgJ);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.initialized)
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
				ESTaPdewZtSahmPUKzoflkAKMVv = base.rectTransform.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (base.initialized)
			{
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (base.initialized)
			{
				IEbkrYeiXOaqriLcwiYMyUdsreAF();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
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
			base.yQdUgprBXDEoWjnetusIxRhMmAu();
			if (base.initialized)
			{
				AekkuDxviraQAPdPqvLzoeQytsn();
				zvfOAwJekZgHSnaOvNHZzaMqNgQ();
				ZSSXPCWvxFsmyMtmqgPbUNCcGAiI();
				if (_followTouchPosition)
				{
					zRDaVDVWUXFSfLYFShHSEyrACKx(effectivePointerId);
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!USdTaHHNWIGWTOHgBLrxEkaEfPs())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.initialized && hasController)
			{
				npeGbTfGrbHYJDvUuqKBwJdsXleT(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			BxlLqiGbAIUodNYPXhhbDFpwdiA();
			_axis.AxisValueChangedEvent += BORFITtzDidAGHXDCfVAfBgNjyT;
			_axis.ButtonValueChangedEvent += XXbYGTdevxFSOfOnTFyfBTtvKbs;
			_axis.ButtonDownEvent += QdJPlpzQcOgomChzVmdHOnjxoAk;
			_axis.ButtonUpEvent += zgoCnAeBgbkGjTyLTmzfewnKWFWw;
		}

		internal void OnUnsubscribeEvents()
		{
			eyUExPEfJOvDMpgTWfZhKmVaJVBB();
			_axis.AxisValueChangedEvent -= BORFITtzDidAGHXDCfVAfBgNjyT;
			_axis.ButtonValueChangedEvent -= XXbYGTdevxFSOfOnTFyfBTtvKbs;
			_axis.ButtonDownEvent -= QdJPlpzQcOgomChzVmdHOnjxoAk;
			_axis.ButtonUpEvent -= zgoCnAeBgbkGjTyLTmzfewnKWFWw;
		}

		internal void OnSetProperty()
		{
			qdlBanCKskFYgFyewDKidbPGRpbJ();
			if (base.initialized)
			{
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		internal void OnClear()
		{
			if (base.initialized)
			{
				PardoywaEUoKKSsaXRTpyRWFjix = int.MinValue;
				wXvOWZmXwMXRglCvftHOGqgfPkV = int.MinValue;
				traAtpHvLXNexVrCRTWuJipMjwd = false;
				IqanMrGVhLvExACtCdEAMqyHqQT = false;
				if (_returnOnRelease && DXPWlsSRQPHNmzewPdbPyhILhKS && (_moveToTouchPosition || _followTouchPosition))
				{
					ReturnToDefaultPosition(instant: true);
				}
				DXPWlsSRQPHNmzewPdbPyhILhKS = false;
				SmvaITkflCMBkGxRBYnXTbWkkTfI = false;
				LhJvrDDmJrlbqsvdnButdExrtcK = zKRQSjSInJqLsXbtqlZaZmzeeBA.DVDMTdEnkAaktJFJqNakDhECjSAS;
				GgjjazLCAGjeIQBhjjlWbyFFMvX();
				_axis.Clear();
				bHPjrbVwljVSnFQuaZYoVEnOsiU = 0f;
				kCpBmnmFsUyOUCAaftPhrUcMcXX = 0f;
				ZBDmBmYoVxMpOXnsuZypYbLJAdh();
			}
		}

		public override void ClearValue()
		{
			if (base.initialized)
			{
				_axis.Clear();
				bHPjrbVwljVSnFQuaZYoVEnOsiU = 0f;
				if (hasController)
				{
					base.controller.ClearElementValue(_targetCustomControllerElement);
				}
			}
		}

		internal bool IsPressed()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!zCDiilIuMmyrwiYynasIRcHvrxTh())
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
			if (base.DBZNemCCbEjBmnIHgXKlkdDPrhE(gameObject))
			{
				return true;
			}
			if (cpxBlgEyjIcWshNPxzBsniNNJkyD != null)
			{
				return cpxBlgEyjIcWshNPxzBsniNNJkyD.gameObject == gameObject;
			}
			return false;
		}

		private void ZSSXPCWvxFsmyMtmqgPbUNCcGAiI()
		{
			if (_useDigitalAxisSimulation)
			{
				if (_axis.buttonValue)
				{
					tBHIjIkAOOGPnfaAmDTnyyldyis();
				}
				else
				{
					XoPFgHKTuChkMHGQJQcCbKlhmiAU();
				}
			}
		}

		private void tBHIjIkAOOGPnfaAmDTnyyldyis()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			num *= num2 * Time.unscaledDeltaTime;
			num += bHPjrbVwljVSnFQuaZYoVEnOsiU;
			num = MathTools.Clamp(num, -1f, 1f);
			bvxBTbSUChJTsvAiDndblCgGTyq(num, true);
		}

		private void XoPFgHKTuChkMHGQJQcCbKlhmiAU()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num2 = bHPjrbVwljVSnFQuaZYoVEnOsiU;
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
				bvxBTbSUChJTsvAiDndblCgGTyq(num4, true);
			}
		}

		private void bvxBTbSUChJTsvAiDndblCgGTyq(float P_0, bool P_1)
		{
			kCpBmnmFsUyOUCAaftPhrUcMcXX = bHPjrbVwljVSnFQuaZYoVEnOsiU;
			bHPjrbVwljVSnFQuaZYoVEnOsiU = P_0;
			if (P_0 != kCpBmnmFsUyOUCAaftPhrUcMcXX)
			{
				bxcFuVigGCNQnErQwkHMGEIXJZoF(null);
			}
			if (P_1 && P_0 != kCpBmnmFsUyOUCAaftPhrUcMcXX)
			{
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void UWIfcbhZXgIBRZHFVohNxAJhgyW()
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

		private void IjDejrsZeYoaYhdjsDEWUdhAeRHc()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void ZBDmBmYoVxMpOXnsuZypYbLJAdh()
		{
			_targetCustomControllerElement.ClearElementCaches();
			zvfOAwJekZgHSnaOvNHZzaMqNgQ();
			PCPARCNgTWmorJBKnCnllnzHUlI();
		}

		private void PCPARCNgTWmorJBKnCnllnzHUlI()
		{
			if (_manageRaycasting)
			{
				gVDpuIwVZhgiuMzhuilHBfaLqwO.ZPsagkBaAfFubBAoNrUfTaaNrdjj(base.transform, leTvbaCbSfIpwpoFubGfcjgjTyMn());
			}
		}

		private bool leTvbaCbSfIpwpoFubGfcjgjTyMn()
		{
			if (cpxBlgEyjIcWshNPxzBsniNNJkyD != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void QSBgNgEKWYNEKAxGtTVSbnXflhSK(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				OiIVKSSVMGqSedqlicccboHpzwy(P_0);
				P_0.PointerDownEvent += EqbDkSeEiwoIINXSMrCbkUNSNXMp;
				P_0.PointerUpEvent += pXlEPBHOffgRPiBtYFzzNNDdUiS;
				P_0.PointerEnterEvent += xozFkdYIgNWtdAkJKmnWqXcJbOc;
				P_0.PointerExitEvent += iYqZdGDJeKOlcCXJHAeVAgJMotE;
			}
		}

		private void OiIVKSSVMGqSedqlicccboHpzwy(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= EqbDkSeEiwoIINXSMrCbkUNSNXMp;
				P_0.PointerUpEvent -= pXlEPBHOffgRPiBtYFzzNNDdUiS;
				P_0.PointerEnterEvent -= xozFkdYIgNWtdAkJKmnWqXcJbOc;
				P_0.PointerExitEvent -= iYqZdGDJeKOlcCXJHAeVAgJMotE;
			}
		}

		private void zvfOAwJekZgHSnaOvNHZzaMqNgQ()
		{
			if (!(cpxBlgEyjIcWshNPxzBsniNNJkyD == _touchRegion))
			{
				OiIVKSSVMGqSedqlicccboHpzwy(cpxBlgEyjIcWshNPxzBsniNNJkyD);
				cpxBlgEyjIcWshNPxzBsniNNJkyD = _touchRegion;
				QSBgNgEKWYNEKAxGtTVSbnXflhSK(cpxBlgEyjIcWshNPxzBsniNNJkyD);
			}
		}

		private void AhzRJwCgBYyRxoCQAJKZjcgDAMzh(Vector2 P_0, bool P_1, float P_2, zKRQSjSInJqLsXbtqlZaZmzeeBA P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = HIVfPxnnHQLxQzKCApRSVEGlhlG.qsfJQxCcPETLDHWUUrzITRvJrGU(base.canvas, rectTransform, P_0);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 sizeDelta = base.rectTransform.sizeDelta;
			Vector3 localScale = base.rectTransform.localScale;
			vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
			MqBlqPCfzHAXSELFPDuRHSHawkMF(vector, PositionType.SaidbJQgZbwJIUhEOfXVjHpYIsz, P_1, P_2, P_3);
		}

		private void MqBlqPCfzHAXSELFPDuRHSHawkMF(Vector2 P_0, PositionType P_1, bool P_2, float P_3, zKRQSjSInJqLsXbtqlZaZmzeeBA P_4)
		{
			if (SmvaITkflCMBkGxRBYnXTbWkkTfI && P_2 && LhJvrDDmJrlbqsvdnButdExrtcK == P_4)
			{
				return;
			}
			if (SmvaITkflCMBkGxRBYnXTbWkkTfI && kQTOJOLgZsciyMhDXQTDfKQMJLR != null)
			{
				GgjjazLCAGjeIQBhjjlWbyFFMvX();
				SmvaITkflCMBkGxRBYnXTbWkkTfI = false;
				LhJvrDDmJrlbqsvdnButdExrtcK = zKRQSjSInJqLsXbtqlZaZmzeeBA.DVDMTdEnkAaktJFJqNakDhECjSAS;
			}
			if (base.canvas == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
			}
			else if (base.canvas.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				P_2 = false;
			}
			if (P_2)
			{
				Transform parent = base.transform;
				RectTransform rectTransform = base.canvasTransform;
				Vector2 one = Vector2.one;
				while ((parent = parent.parent) != rectTransform && !(parent == null))
				{
					one.x *= parent.localScale.x;
					one.y *= parent.localScale.y;
				}
				Vector2 sizeDelta = rectTransform.sizeDelta;
				bool flag = sizeDelta.x < sizeDelta.y;
				float num = MathTools.Max(sizeDelta.x, sizeDelta.y);
				float num2 = (flag ? one.y : one.x);
				if (num2 == 0f)
				{
					num2 = 0.0001f;
				}
				P_3 = P_3 / num2 * num;
				kQTOJOLgZsciyMhDXQTDfKQMJLR = GDOMQOtmhmwMQQEzxFRHDoIbIARL(P_0, P_1, P_3, P_4);
				StartCoroutine(kQTOJOLgZsciyMhDXQTDfKQMJLR);
				LhJvrDDmJrlbqsvdnButdExrtcK = P_4;
				DXPWlsSRQPHNmzewPdbPyhILhKS = true;
				moveStartedDelegate(P_4);
			}
			else
			{
				moveStartedDelegate(P_4);
				cmBvOieMeiAlEJFxqjiAxiPCODUz(P_4, P_0, P_1);
			}
		}

		private IEnumerator GDOMQOtmhmwMQQEzxFRHDoIbIARL(Vector2 P_0, PositionType P_1, float P_2, zKRQSjSInJqLsXbtqlZaZmzeeBA P_3)
		{
			dYhzRpKRJLhhWqixvGPXDzyjzlL dYhzRpKRJLhhWqixvGPXDzyjzlL2 = new dYhzRpKRJLhhWqixvGPXDzyjzlL(0);
			dYhzRpKRJLhhWqixvGPXDzyjzlL2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			dYhzRpKRJLhhWqixvGPXDzyjzlL2.aZvcttCYZyvpcbqSuEdfCWeofxD = P_0;
			dYhzRpKRJLhhWqixvGPXDzyjzlL2.gKIedNefRQHDkodooGkfIArMTaNi = P_1;
			dYhzRpKRJLhhWqixvGPXDzyjzlL2.brHFgkYEWMuNyWyjPqgxFrGPZCw = P_2;
			dYhzRpKRJLhhWqixvGPXDzyjzlL2.BbHMTdIqfNjQoQZLIgtdqXgYBym = P_3;
			return dYhzRpKRJLhhWqixvGPXDzyjzlL2;
		}

		private void cmBvOieMeiAlEJFxqjiAxiPCODUz(zKRQSjSInJqLsXbtqlZaZmzeeBA P_0, Vector2 P_1, PositionType P_2)
		{
			HIVfPxnnHQLxQzKCApRSVEGlhlG.OVadyLfTUUTuKfhAwqhiaCPfusM(base.rectTransform, P_1, P_2);
			SmvaITkflCMBkGxRBYnXTbWkkTfI = false;
			LhJvrDDmJrlbqsvdnButdExrtcK = zKRQSjSInJqLsXbtqlZaZmzeeBA.DVDMTdEnkAaktJFJqNakDhECjSAS;
			switch (P_0)
			{
			case zKRQSjSInJqLsXbtqlZaZmzeeBA.TwXdFBErLOFXUbbLkASzGEGrOQgJ:
				DXPWlsSRQPHNmzewPdbPyhILhKS = false;
				break;
			case zKRQSjSInJqLsXbtqlZaZmzeeBA.gGCEEPKfpLJhbIEWxebhHfEPKFqR:
				DXPWlsSRQPHNmzewPdbPyhILhKS = true;
				break;
			}
			GgjjazLCAGjeIQBhjjlWbyFFMvX();
			moveEndedDelegate(P_0);
		}

		private void oTranSwyLPbQXnqMXiyRcliIkxw(zKRQSjSInJqLsXbtqlZaZmzeeBA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && cpxBlgEyjIcWshNPxzBsniNNJkyD != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == zKRQSjSInJqLsXbtqlZaZmzeeBA.gGCEEPKfpLJhbIEWxebhHfEPKFqR)
				{
					flag = true;
					flag2 = false;
				}
				if (flag)
				{
					gVDpuIwVZhgiuMzhuilHBfaLqwO.ZPsagkBaAfFubBAoNrUfTaaNrdjj(base.transform, flag2);
				}
			}
		}

		private void lGOpDmQOzMduncmwRjrmDnVzawx(zKRQSjSInJqLsXbtqlZaZmzeeBA P_0)
		{
			if (_manageRaycasting)
			{
				bool flag = false;
				bool flag2 = false;
				if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && cpxBlgEyjIcWshNPxzBsniNNJkyD != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == zKRQSjSInJqLsXbtqlZaZmzeeBA.TwXdFBErLOFXUbbLkASzGEGrOQgJ)
				{
					flag = true;
					flag2 = leTvbaCbSfIpwpoFubGfcjgjTyMn();
				}
				if (flag)
				{
					gVDpuIwVZhgiuMzhuilHBfaLqwO.ZPsagkBaAfFubBAoNrUfTaaNrdjj(base.transform, flag2);
				}
			}
		}

		private void zRDaVDVWUXFSfLYFShHSEyrACKx(int P_0)
		{
			if (TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(P_0))
			{
				AhzRJwCgBYyRxoCQAJKZjcgDAMzh(TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(P_0), false, 0f, zKRQSjSInJqLsXbtqlZaZmzeeBA.gGCEEPKfpLJhbIEWxebhHfEPKFqR);
			}
		}

		private void GgjjazLCAGjeIQBhjjlWbyFFMvX()
		{
			if (kQTOJOLgZsciyMhDXQTDfKQMJLR != null)
			{
				try
				{
					StopCoroutine(kQTOJOLgZsciyMhDXQTDfKQMJLR);
				}
				catch
				{
				}
				kQTOJOLgZsciyMhDXQTDfKQMJLR = null;
			}
		}

		private void AekkuDxviraQAPdPqvLzoeQytsn()
		{
			if (hasPointer && !TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
			{
				PointerEventData pointerEventData = yHrsPUsBTKoffjSCQeywZyWFrOh(effectivePointerId);
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					avwmcSzQSEgYouckhaptbkNDseT(pointerEventData);
				}
				else
				{
					bCVmmRpfQdgPtiosLDGEOIttkFRM();
				}
			}
		}

		private bool yAYwMKrQXZHXrNSqWOThanYtPym()
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

		private void ICZaXXGeTWWhejUbLxZSqRsMQuRB()
		{
			PardoywaEUoKKSsaXRTpyRWFjix = int.MinValue;
			wXvOWZmXwMXRglCvftHOGqgfPkV = int.MinValue;
		}

		private bool beMrQrnNPRabsSFJFZFTWEkfLfi(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (PardoywaEUoKKSsaXRTpyRWFjix == int.MinValue)
			{
				return false;
			}
			if (PardoywaEUoKKSsaXRTpyRWFjix == P_0)
			{
				return true;
			}
			if (TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0) && wXvOWZmXwMXRglCvftHOGqgfPkV != int.MinValue && P_0 == wXvOWZmXwMXRglCvftHOGqgfPkV)
			{
				return true;
			}
			return false;
		}

		private PointerEventData LPSQCjDNxTWIUuTjTGvgkBFgTLH(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = yHrsPUsBTKoffjSCQeywZyWFrOh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.iCtSdEdbUllBhkoEsdmIZxcKEoLh(P_0);
			if (TouchInteractable.EUNPoxeUSzLzbtpjIDKKKWBaQYL(P_0))
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
					float num = unscaledTime - pointerEventData.clickTime;
					if (num < 0.3f)
					{
						pointerEventData.clickCount++;
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
				if (!TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0))
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
					float num2 = unscaledTime2 - pointerEventData.clickTime;
					if (num2 < 0.3f)
					{
						pointerEventData.clickCount++;
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

		private PointerEventData YnMpqWcSMgzOjkQUUUqSqpETmui(int P_0)
		{
			PointerEventData pointerEventData = yHrsPUsBTKoffjSCQeywZyWFrOh(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.EUNPoxeUSzLzbtpjIDKKKWBaQYL(P_0))
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
				if (!TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0))
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

		private void avwmcSzQSEgYouckhaptbkNDseT(PointerEventData P_0)
		{
			if (P_0 != null)
			{
				OnPointerUp(P_0);
				YnMpqWcSMgzOjkQUUUqSqpETmui(effectivePointerId);
			}
		}

		private PointerEventData yHrsPUsBTKoffjSCQeywZyWFrOh(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (rbcBHqhIjllVjPfdpcIoyNuqPFIJ == null)
			{
				rbcBHqhIjllVjPfdpcIoyNuqPFIJ = new Dictionary<int, PointerEventData>();
			}
			if (!rbcBHqhIjllVjPfdpcIoyNuqPFIJ.TryGetValue(P_0, out var value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				rbcBHqhIjllVjPfdpcIoyNuqPFIJ.Add(P_0, value);
				if (TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0))
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

		private void VZWPPRkHaAzgbWCTqMIJiKiWgZm(PointerEventData P_0, zqHlgpPaVYdAwGxKbubVPBAddrO P_1)
		{
			if (!hasPointer || beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				if (zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable())
				{
					cViKfhpmnxGslCDrJoQcTVUDatYE(P_0.pointerId, P_0.pressPosition, P_1);
				}
				base.OnPointerDown(P_0);
			}
		}

		private void yQOZXNtLHWGaWIrWSOHsscHiLuT(PointerEventData P_0, zqHlgpPaVYdAwGxKbubVPBAddrO P_1)
		{
			if ((!hasPointer || beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId)) && !TouchInteractable.FoLGlOgsGoUwoLufhJsVpiSxQYm(effectivePointerId))
			{
				bCVmmRpfQdgPtiosLDGEOIttkFRM();
				base.OnPointerUp(P_0);
			}
		}

		private void mZbaXWFXpZQDscfQismiYpcuizW(PointerEventData P_0, zqHlgpPaVYdAwGxKbubVPBAddrO P_1)
		{
			if (hasPointer && !beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				return;
			}
			bool flag = TouchInteractable.FcibJdJVXbMzmpAdzCtyBEgZADhe(P_0.pointerId);
			bool flag2 = false;
			MouseButtonFlags mouseButtonFlags = P_1 switch
			{
				zqHlgpPaVYdAwGxKbubVPBAddrO.SaidbJQgZbwJIUhEOfXVjHpYIsz => base.allowedMouseButtons, 
				zqHlgpPaVYdAwGxKbubVPBAddrO.uVeuqRrVqCbFkUaeJPlhWwYcYgk => _touchRegion.allowedMouseButtons, 
				_ => throw new NotImplementedException(), 
			};
			if (_activateOnSwipeIn && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && (!flag || TouchInteractable.mjfqtOtDkxtBHvBGQKSoLmCVGJt(mouseButtonFlags)) && !traAtpHvLXNexVrCRTWuJipMjwd)
			{
				if (flag)
				{
					if (TouchInteractable.qlxzzsOdoUANRhJbnEPLSQzjWeJi(mouseButtonFlags, out var num))
					{
						wXvOWZmXwMXRglCvftHOGqgfPkV = num;
					}
					else
					{
						wXvOWZmXwMXRglCvftHOGqgfPkV = P_0.pointerId;
					}
				}
				flag2 = true;
			}
			base.OnPointerEnter(P_0);
			if (flag2)
			{
				GameObject gameObject = P_1 switch
				{
					zqHlgpPaVYdAwGxKbubVPBAddrO.SaidbJQgZbwJIUhEOfXVjHpYIsz => base.gameObject, 
					zqHlgpPaVYdAwGxKbubVPBAddrO.uVeuqRrVqCbFkUaeJPlhWwYcYgk => cpxBlgEyjIcWshNPxzBsniNNJkyD.gameObject, 
					_ => throw new NotImplementedException(), 
				};
				PointerEventData pointerEventData = LPSQCjDNxTWIUuTjTGvgkBFgTLH((wXvOWZmXwMXRglCvftHOGqgfPkV != int.MinValue) ? wXvOWZmXwMXRglCvftHOGqgfPkV : P_0.pointerId, gameObject);
				if (pointerEventData != null)
				{
					VZWPPRkHaAzgbWCTqMIJiKiWgZm(pointerEventData, P_1);
				}
			}
			IqanMrGVhLvExACtCdEAMqyHqQT = true;
		}

		private void ETirtckwAXAWBWCQmcBygkjzMuX(PointerEventData P_0, zqHlgpPaVYdAwGxKbubVPBAddrO P_1)
		{
			if (hasPointer && !beMrQrnNPRabsSFJFZFTWEkfLfi(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				return;
			}
			if (!stayActiveOnSwipeOut && traAtpHvLXNexVrCRTWuJipMjwd)
			{
				bCVmmRpfQdgPtiosLDGEOIttkFRM();
			}
			base.OnPointerExit(P_0);
			IqanMrGVhLvExACtCdEAMqyHqQT = false;
		}

		private void cViKfhpmnxGslCDrJoQcTVUDatYE(int P_0, Vector2 P_1, zqHlgpPaVYdAwGxKbubVPBAddrO P_2)
		{
			PardoywaEUoKKSsaXRTpyRWFjix = P_0;
			traAtpHvLXNexVrCRTWuJipMjwd = true;
			if (_followTouchPosition)
			{
				zRDaVDVWUXFSfLYFShHSEyrACKx(P_0);
			}
			else if (P_2 == zqHlgpPaVYdAwGxKbubVPBAddrO.uVeuqRrVqCbFkUaeJPlhWwYcYgk && _moveToTouchPosition)
			{
				AhzRJwCgBYyRxoCQAJKZjcgDAMzh(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, zKRQSjSInJqLsXbtqlZaZmzeeBA.gGCEEPKfpLJhbIEWxebhHfEPKFqR);
			}
			UWIfcbhZXgIBRZHFVohNxAJhgyW();
		}

		private void bCVmmRpfQdgPtiosLDGEOIttkFRM()
		{
			ICZaXXGeTWWhejUbLxZSqRsMQuRB();
			traAtpHvLXNexVrCRTWuJipMjwd = false;
			if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && DXPWlsSRQPHNmzewPdbPyhILhKS)
			{
				ReturnToDefaultPosition();
			}
			IjDejrsZeYoaYhdjsDEWUdhAeRHc();
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(cpxBlgEyjIcWshNPxzBsniNNJkyD != null) || !_useTouchRegionOnly))
			{
				VZWPPRkHaAzgbWCTqMIJiKiWgZm(eventData, zqHlgpPaVYdAwGxKbubVPBAddrO.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(cpxBlgEyjIcWshNPxzBsniNNJkyD != null) || !_useTouchRegionOnly))
			{
				yQOZXNtLHWGaWIrWSOHsscHiLuT(eventData, zqHlgpPaVYdAwGxKbubVPBAddrO.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(cpxBlgEyjIcWshNPxzBsniNNJkyD != null) || !_useTouchRegionOnly))
			{
				mZbaXWFXpZQDscfQismiYpcuizW(eventData, zqHlgpPaVYdAwGxKbubVPBAddrO.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(cpxBlgEyjIcWshNPxzBsniNNJkyD != null) || !_useTouchRegionOnly))
			{
				ETirtckwAXAWBWCQmcBygkjzMuX(eventData, zqHlgpPaVYdAwGxKbubVPBAddrO.SaidbJQgZbwJIUhEOfXVjHpYIsz);
			}
		}

		private void EqbDkSeEiwoIINXSMrCbkUNSNXMp(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				VZWPPRkHaAzgbWCTqMIJiKiWgZm(P_0, zqHlgpPaVYdAwGxKbubVPBAddrO.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void pXlEPBHOffgRPiBtYFzzNNDdUiS(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				yQOZXNtLHWGaWIrWSOHsscHiLuT(P_0, zqHlgpPaVYdAwGxKbubVPBAddrO.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void xozFkdYIgNWtdAkJKmnWqXcJbOc(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				mZbaXWFXpZQDscfQismiYpcuizW(P_0, zqHlgpPaVYdAwGxKbubVPBAddrO.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void iYqZdGDJeKOlcCXJHAeVAgJMotE(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				ETirtckwAXAWBWCQmcBygkjzMuX(P_0, zqHlgpPaVYdAwGxKbubVPBAddrO.uVeuqRrVqCbFkUaeJPlhWwYcYgk);
			}
		}

		private void BORFITtzDidAGHXDCfVAfBgNjyT(float P_0)
		{
			if (base.initialized && !_useDigitalAxisSimulation)
			{
				bxcFuVigGCNQnErQwkHMGEIXJZoF(null);
				_onAxisValueChanged.Invoke(P_0);
			}
		}

		private void XXbYGTdevxFSOfOnTFyfBTtvKbs(bool P_0)
		{
			if (base.initialized)
			{
				bxcFuVigGCNQnErQwkHMGEIXJZoF(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void QdJPlpzQcOgomChzVmdHOnjxoAk()
		{
			if (base.initialized)
			{
				bxcFuVigGCNQnErQwkHMGEIXJZoF(null);
				_onButtonDown.Invoke();
			}
		}

		private void zgoCnAeBgbkGjTyLTmzfewnKWFWw()
		{
			if (base.initialized)
			{
				bxcFuVigGCNQnErQwkHMGEIXJZoF(null);
				_onButtonUp.Invoke();
			}
		}
	}
}
