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
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum vYIjyUMfsrLjixlJmTaeYJNvqmn
		{
			TCGihQKDgeeGtvEXifcuojmabzj = 0,
			euXYneYPthVhveBWhDzbgcsApkRZ = 1,
			HwWCoknLLuvDCNsHCSIjJkwLMtB = 2
		}

		private enum vwOsOGNXaoaruwxhzgqJCegchQrA
		{
			UMtjEaOogDDwQiplOLpTuwxTdbQ = 0,
			qBvlHFfTVaijZsMuBaXfTPCbahL = 1
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

		private sealed class rsyiMSQuFtxAGAoztUeTKDOkMKs : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			public TouchButton iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public Vector2 ofwHDGItTMAnajZEczGfQJAfkWi;

			public PositionType cEFYMcdcTaIHyHTckcmnNJNVUTy;

			public float lJAziHQEMyViiggdNdulCrmGjoLg;

			public vYIjyUMfsrLjixlJmTaeYJNvqmn DTQmUpQxxpEaloJNKuhapMsZmFf;

			public RectTransform KuzYKiimDsnBJZyCjKMMSnrGWZW;

			public Vector2 jImiyhrzbWqhsqSradCwLjfTnpD;

			public float mwFUmcbJChXveBDuBQahlGPGfsId;

			public float JHcHeogIHbciXiCKlfoLsUzCyrKK;

			public float TEWHNkXCXBuiRWFgJNKVNBRXZxU;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 1:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = -825561632;
					goto IL_001f;
				case 0:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						int num3;
						if (!(lJAziHQEMyViiggdNdulCrmGjoLg <= 0f))
						{
							num = -825561626;
							num3 = num;
						}
						else
						{
							num = -825561625;
							num3 = num;
						}
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -825561628)
						{
						case 5:
							num = -825561629;
							continue;
						case 0:
							PPQNIOlPnyDtERyUKpTWMMgiKJj.AwbDNgzQKwyuEBeAcQzspJfsFFt(KuzYKiimDsnBJZyCjKMMSnrGWZW, Vector2.Lerp(jImiyhrzbWqhsqSradCwLjfTnpD, ofwHDGItTMAnajZEczGfQJAfkWi, Mathf.SmoothStep(0f, 1f, TEWHNkXCXBuiRWFgJNKVNBRXZxU)), cEFYMcdcTaIHyHTckcmnNJNVUTy);
							aimBzjfQfPyaeQqysAQJISCBhELB = null;
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 6:
							num = -825561632;
							continue;
						case 2:
							KuzYKiimDsnBJZyCjKMMSnrGWZW = iKQXbXnVtIaMZEJNeigQJWAHqUx.rectTransform;
							jImiyhrzbWqhsqSradCwLjfTnpD = PPQNIOlPnyDtERyUKpTWMMgiKJj.BFYAtvgPUJNLjuOWcquIuXIEhUS(KuzYKiimDsnBJZyCjKMMSnrGWZW, cEFYMcdcTaIHyHTckcmnNJNVUTy);
							mwFUmcbJChXveBDuBQahlGPGfsId = (ofwHDGItTMAnajZEczGfQJAfkWi - jImiyhrzbWqhsqSradCwLjfTnpD).magnitude;
							if (!(mwFUmcbJChXveBDuBQahlGPGfsId < 0.01f))
							{
								iKQXbXnVtIaMZEJNeigQJWAHqUx.GmmtQmbFnqcHiBbFQapXEeqdMsIP = true;
								JHcHeogIHbciXiCKlfoLsUzCyrKK = mwFUmcbJChXveBDuBQahlGPGfsId / lJAziHQEMyViiggdNdulCrmGjoLg;
								TEWHNkXCXBuiRWFgJNKVNBRXZxU = 0f;
								num = -825561630;
								continue;
							}
							goto case 3;
						case 3:
							iKQXbXnVtIaMZEJNeigQJWAHqUx.yFIryXiFmAheSzYjuuUCpBvLoYn(DTQmUpQxxpEaloJNKuhapMsZmFf, ofwHDGItTMAnajZEczGfQJAfkWi, cEFYMcdcTaIHyHTckcmnNJNVUTy);
							num = -825561627;
							continue;
						case 8:
							TEWHNkXCXBuiRWFgJNKVNBRXZxU += Time.unscaledDeltaTime / JHcHeogIHbciXiCKlfoLsUzCyrKK;
							num = -825561628;
							continue;
						case 7:
							break;
						case 4:
							goto IL_01b9;
						default:
							goto end_IL_0008;
						}
						break;
						IL_01b9:
						int num2;
						if (!(TEWHNkXCXBuiRWFgJNKVNBRXZxU <= 1f))
						{
							num = -825561625;
							num2 = num;
						}
						else
						{
							num = -825561620;
							num2 = num;
						}
					}
					goto case 0;
					end_IL_0008:
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
			public rsyiMSQuFtxAGAoztUeTKDOkMKs(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
			}
		}

		private const float fruQAKvnXDBCklnsQHCaJkENDtS = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		private ButtonType _buttonType;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisSensitivity = 3f;

		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private StandaloneAxis _axis = new StandaloneAxis();

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[SerializeField]
		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _returnOnRelease = true;

		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _followTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private bool _animateOnMoveToTouch = true;

		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		private float _moveToTouchSpeed = 2f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		private bool _animateOnReturn = true;

		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		private bool _manageRaycasting = true;

		private float nNEEUtDnZNGztzylwYsGUXILDzX;

		private float epmELKqQkigMEBswrOLxBaKJgksu;

		private TouchRegion yOoaERsLfwRYibdXndHsenfOaVXe;

		private Vector2 AYIaFSyXLVsjxxyIKwNjduqJaEM;

		private bool GmmtQmbFnqcHiBbFQapXEeqdMsIP;

		private bool BfEabZhMOdfBmuBiTDzXflgDYlzq;

		private vYIjyUMfsrLjixlJmTaeYJNvqmn JUQAZmPbLZlOaQZfnawbuDZePwz;

		private int JMoqQTgkIefgMovyFXwlzczIaOU = int.MinValue;

		private int qkqJpryWPyBJRDHKnavLPnAoLsP = int.MinValue;

		[NonSerialized]
		private bool jYtFWKZUVrechfzATGCgCETBhJCg;

		[NonSerialized]
		private bool GXxxUMYvhnAdzwfrIpAYPjIWpue;

		private IEnumerator ujMkhdPMeAqacuGnPYMNkpmJFwqB;

		private RXykqpoobZXbeYNAmfMakWSBJalU cVCPUrwTVVqfwiajczZVENUMDXp = new RXykqpoobZXbeYNAmfMakWSBJalU();

		private Action<vYIjyUMfsrLjixlJmTaeYJNvqmn> QfeERTvvsihycVEwQaWsaWlttYqn;

		private Action<vYIjyUMfsrLjixlJmTaeYJNvqmn> nglBdOdoufkmXWvKgSGPncWSRcPa;

		[Tooltip("Event sent when the axis value changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[Tooltip("Event sent when the button value changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[Tooltip("Event sent when the button is pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[Tooltip("Event sent when the button is released.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> tTbkNLOsvXDQdRtrdKXoAuKlqSn;

		public CustomControllerElementTargetSetForFloat targetCustomControllerElement
		{
			get
			{
				return _targetCustomControllerElement;
			}
		}

		public ButtonType buttonType
		{
			get
			{
				return _buttonType;
			}
			set
			{
				if (_buttonType == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 515358529;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x1EB7BF42)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					return;
				case 1:
					goto IL_0033;
				case 2:
					return;
				}
				goto IL_0009;
				IL_0033:
				_buttonType = value;
				OnSetProperty();
				num = 515358528;
				goto IL_000e;
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
				if (_activateOnSwipeIn == value)
				{
					return;
				}
				while (true)
				{
					_activateOnSwipeIn = value;
					int num = -839495261;
					while (true)
					{
						switch (num ^ -839495262)
						{
						case 0:
							num = -839495263;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							OnSetProperty();
							num = -839495264;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (eOHzHpzQRbBLjxcuQVfnfVkaPND())
				{
					return true;
				}
				return _stayActiveOnSwipeOut;
			}
			set
			{
				if (_stayActiveOnSwipeOut == value)
				{
					return;
				}
				while (true)
				{
					_stayActiveOnSwipeOut = value;
					int num = 241210702;
					while (true)
					{
						switch (num ^ 0xE60954C)
						{
						case 0:
							goto IL_000a;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = 241210701;
					}
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
				if (_useDigitalAxisSimulation == value)
				{
					return;
				}
				while (true)
				{
					_useDigitalAxisSimulation = value;
					OnSetProperty();
					int num = 201096304;
					while (true)
					{
						switch (num ^ 0xBFC7C72)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = 201096307;
					}
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
				if (_digitalAxisGravity == value)
				{
					return;
				}
				while (true)
				{
					_digitalAxisGravity = value;
					int num = -1203582703;
					while (true)
					{
						switch (num ^ -1203582702)
						{
						case 2:
							num = -1203582701;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							OnSetProperty();
							num = -1203582702;
							continue;
						case 0:
							return;
						}
						break;
					}
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
				if (_digitalAxisSensitivity == value)
				{
					while (true)
					{
						switch (-256038740 ^ -256038739)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_digitalAxisSensitivity = value;
				OnSetProperty();
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
				if (_touchRegion == value)
				{
					return;
				}
				while (true)
				{
					_touchRegion = value;
					OnSetProperty();
					int num = -2135932973;
					while (true)
					{
						switch (num ^ -2135932974)
						{
						case 0:
							goto IL_000f;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000f:
						num = -2135932976;
					}
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
				if (_useTouchRegionOnly == value)
				{
					return;
				}
				while (true)
				{
					_useTouchRegionOnly = value;
					OnSetProperty();
					int num = -1108918255;
					while (true)
					{
						switch (num ^ -1108918256)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = -1108918254;
					}
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
					OnSetProperty();
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
					OnSetProperty();
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
				if (_followTouchPosition == value)
				{
					return;
				}
				while (true)
				{
					_followTouchPosition = value;
					OnSetProperty();
					int num = 36581604;
					while (true)
					{
						switch (num ^ 0x22E30E4)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 36581605;
					}
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
					OnSetProperty();
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
				if (_moveToTouchSpeed == value)
				{
					while (true)
					{
						switch (0xF41F910 ^ 0xF41F911)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_moveToTouchSpeed = value;
				OnSetProperty();
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
				if (_animateOnReturn == value)
				{
					return;
				}
				while (true)
				{
					_animateOnReturn = value;
					int num = -1033820225;
					while (true)
					{
						switch (num ^ -1033820227)
						{
						case 0:
							goto IL_000a;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = -1033820228;
					}
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
				while (true)
				{
					switch (-104539182 ^ -104539181)
					{
					case 2:
						continue;
					case 1:
						if (_returnSpeed == value)
						{
							return;
						}
						break;
					}
					break;
				}
				_returnSpeed = value;
				OnSetProperty();
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
				if (_manageRaycasting == value)
				{
					goto IL_0009;
				}
				goto IL_0041;
				IL_0009:
				int num = 2027550183;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x78D9F5E4)
				{
				case 4:
					break;
				case 1:
					goto IL_002f;
				case 2:
					goto IL_0041;
				case 3:
					return;
				default:
					OnSetProperty();
					return;
				}
				goto IL_0009;
				IL_0041:
				_manageRaycasting = value;
				if (value)
				{
					BpIrxrTAZovcjjJKjdrhqiRYbUtH();
					num = 2027550180;
					goto IL_000e;
				}
				goto IL_002f;
				IL_002f:
				cVCPUrwTVVqfwiajczZVENUMDXp.nympziBLtYDUiPlWNRoEGqbSPfa();
				num = 2027550180;
				goto IL_000e;
			}
		}

		public int pointerId
		{
			get
			{
				return JMoqQTgkIefgMovyFXwlzczIaOU;
			}
			set
			{
				JMoqQTgkIefgMovyFXwlzczIaOU = value;
			}
		}

		public bool hasPointer
		{
			get
			{
				return JMoqQTgkIefgMovyFXwlzczIaOU != int.MinValue;
			}
		}

		internal StandaloneAxis axis
		{
			get
			{
				return _axis;
			}
		}

		private Action<vYIjyUMfsrLjixlJmTaeYJNvqmn> moveStartedDelegate
		{
			get
			{
				if (QfeERTvvsihycVEwQaWsaWlttYqn == null)
				{
					return QfeERTvvsihycVEwQaWsaWlttYqn = ebwjYhEqRdpMXwLKPVkBqUQNcEDa;
				}
				return QfeERTvvsihycVEwQaWsaWlttYqn;
			}
		}

		private Action<vYIjyUMfsrLjixlJmTaeYJNvqmn> moveEndedDelegate
		{
			get
			{
				if (nglBdOdoufkmXWvKgSGPncWSRcPa == null)
				{
					return nglBdOdoufkmXWvKgSGPncWSRcPa = juHmsVQdOwsmtGcmTviVInzkJKk;
				}
				return nglBdOdoufkmXWvKgSGPncWSRcPa;
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
				return nNEEUtDnZNGztzylwYsGUXILDzX;
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
				return epmELKqQkigMEBswrOLxBaKJgksu;
			}
		}

		private bool buttonValue
		{
			get
			{
				return _axis.buttonValue;
			}
		}

		private bool buttonValuePrev
		{
			get
			{
				return _axis.buttonValuePrev;
			}
		}

		private int effectivePointerId
		{
			get
			{
				if (JMoqQTgkIefgMovyFXwlzczIaOU == int.MinValue)
				{
					return int.MinValue;
				}
				if (qkqJpryWPyBJRDHKnavLPnAoLsP != int.MinValue)
				{
					return qkqJpryWPyBJRDHKnavLPnAoLsP;
				}
				return JMoqQTgkIefgMovyFXwlzczIaOU;
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
			xbYqhNfPiSuHkPeDMsDiMfQJiRv(base.rectTransform.anchoredPosition);
		}

		private void xbYqhNfPiSuHkPeDMsDiMfQJiRv(Vector2 P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				AYIaFSyXLVsjxxyIKwNjduqJaEM = P_0;
				int num = 91173891;
				while (true)
				{
					switch (num ^ 0x56F3401)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = 91173888;
				}
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.initialized)
			{
				KXGXneOjslBgCoFxDokJHtUpHCr(AYIaFSyXLVsjxxyIKwNjduqJaEM, PositionType.GGTSFVietfXEJqUNBOrLtjJMCol, !instant && _animateOnReturn, _returnSpeed, vYIjyUMfsrLjixlJmTaeYJNvqmn.HwWCoknLLuvDCNsHCSIjJkwLMtB);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (base.initialized)
			{
				ReturnToDefaultPosition(false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying)
			{
				AYIaFSyXLVsjxxyIKwNjduqJaEM = base.rectTransform.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			while (true)
			{
				int num = -1415931140;
				while (true)
				{
					switch (num ^ -1415931139)
					{
					case 0:
						break;
					case 1:
					{
						int num2;
						if (!base.initialized)
						{
							num = -1415931138;
							num2 = num;
						}
						else
						{
							num = -1415931137;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					default:
						NVWqZPEZaDhGVdcEuqvABdsUKUL();
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				OnClear();
				int num = -842956612;
				while (true)
				{
					switch (num ^ -842956611)
					{
					case 0:
						goto IL_000f;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000f:
					num = -842956609;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0038;
			IL_000e:
			int num = -2107138266;
			goto IL_0013;
			IL_0013:
			switch (num ^ -2107138267)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 1:
				goto IL_0038;
			case 2:
				return;
			}
			goto IL_000e;
			IL_0038:
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
			num = -2107138265;
			goto IL_0013;
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			base.Reset();
			base.transitionType = TransitionTypeFlags.ColorTint;
		}

		internal override void OnUpdate()
		{
			base.OnUpdate();
			if (!base.initialized)
			{
				goto IL_000e;
			}
			goto IL_0044;
			IL_000e:
			int num = 394349972;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ 0x17814D91)
				{
				case 0:
					break;
				default:
					return;
				case 5:
					return;
				case 4:
					goto IL_0044;
				case 2:
					dyGGqqDNKdJMvZlREoTIYHXTftYS(effectivePointerId);
					num = 394349975;
					continue;
				case 3:
					dByKttBtodosJPFybBXLHsYfHmZw();
					TfNmSnGnpngwyaeoaJynHLedvQZ();
					num = 394349968;
					continue;
				case 1:
					goto IL_0077;
				case 6:
					return;
				}
				break;
				IL_0077:
				int num2;
				if (!_followTouchPosition)
				{
					num = 394349975;
					num2 = num;
				}
				else
				{
					num = 394349971;
					num2 = num;
				}
			}
			goto IL_000e;
			IL_0044:
			GLnFKkzcjTCAOtkTuThfdBcbeFU();
			num = 394349970;
			goto IL_0013;
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			return true;
		}

		internal override void OnCustomControllerUpdate()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = 1709242499;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x65E0F887)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				return;
			case 2:
				goto IL_0036;
			case 3:
				goto IL_0046;
			case 1:
				return;
			}
			goto IL_0008;
			IL_0036:
			if (!hasController)
			{
				return;
			}
			goto IL_0046;
			IL_0046:
			jdvcKcWQnHxAXPvCkvKHWiFjvWV(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			num = 1709242502;
			goto IL_000d;
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			_axis.AxisValueChangedEvent += HWFhkFlLkYUKyhTUFbGsyGCYFc;
			_axis.ButtonValueChangedEvent += HQgAhyJhrHYQKAXbJAataYJekULw;
			while (true)
			{
				int num = 62166509;
				while (true)
				{
					switch (num ^ 0x3B495EC)
					{
					case 2:
						break;
					case 1:
						goto IL_0052;
					default:
						_axis.ButtonUpEvent += vulYfrBZeVCgrYGRTBzfraHLDodh;
						return;
					}
					break;
					IL_0052:
					_axis.ButtonDownEvent += AwISkEnBouIcuKglDYyFpRHuHNVl;
					num = 62166508;
				}
			}
		}

		internal override void OnUnsubscribeEvents()
		{
			base.OnUnsubscribeEvents();
			while (true)
			{
				int num = 1483585804;
				while (true)
				{
					switch (num ^ 0x586DB90F)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						_axis.AxisValueChangedEvent -= HWFhkFlLkYUKyhTUFbGsyGCYFc;
						num = 1483585806;
						continue;
					case 1:
						_axis.ButtonValueChangedEvent -= HQgAhyJhrHYQKAXbJAataYJekULw;
						_axis.ButtonDownEvent -= AwISkEnBouIcuKglDYyFpRHuHNVl;
						_axis.ButtonUpEvent -= vulYfrBZeVCgrYGRTBzfraHLDodh;
						num = 1483585805;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x5475C13D ^ 0x5475C13F)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
		}

		internal override void OnClear()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				JMoqQTgkIefgMovyFXwlzczIaOU = int.MinValue;
				int num = -1676739344;
				while (true)
				{
					switch (num ^ -1676739340)
					{
					case 3:
						num = -1676739342;
						continue;
					case 5:
						JUQAZmPbLZlOaQZfnawbuDZePwz = vYIjyUMfsrLjixlJmTaeYJNvqmn.TCGihQKDgeeGtvEXifcuojmabzj;
						num = -1676739338;
						continue;
					case 4:
						qkqJpryWPyBJRDHKnavLPnAoLsP = int.MinValue;
						jYtFWKZUVrechfzATGCgCETBhJCg = false;
						GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
						if (_returnOnRelease && BfEabZhMOdfBmuBiTDzXflgDYlzq)
						{
							if (!_moveToTouchPosition)
							{
								int num2;
								if (!_followTouchPosition)
								{
									num = -1676739339;
									num2 = num;
								}
								else
								{
									num = -1676739340;
									num2 = num;
								}
								continue;
							}
							goto case 0;
						}
						goto case 1;
					case 8:
						_axis.Clear();
						num = -1676739341;
						continue;
					case 6:
						break;
					case 0:
						ReturnToDefaultPosition(true);
						num = -1676739339;
						continue;
					case 2:
						CgelQMRxKcNpSeEdjHrUgepUNWaw();
						num = -1676739332;
						continue;
					case 1:
						BfEabZhMOdfBmuBiTDzXflgDYlzq = false;
						GmmtQmbFnqcHiBbFQapXEeqdMsIP = false;
						num = -1676739343;
						continue;
					default:
						nNEEUtDnZNGztzylwYsGUXILDzX = 0f;
						epmELKqQkigMEBswrOLxBaKJgksu = 0f;
						NVWqZPEZaDhGVdcEuqvABdsUKUL();
						return;
					}
					break;
				}
			}
		}

		public override void ClearValue()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				_axis.Clear();
				nNEEUtDnZNGztzylwYsGUXILDzX = 0f;
				int num = -873783482;
				while (true)
				{
					switch (num ^ -873783483)
					{
					case 4:
						num = -873783484;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
					{
						int num2;
						if (!hasController)
						{
							num = -873783483;
							num2 = num;
						}
						else
						{
							num = -873783481;
							num2 = num;
						}
						continue;
					}
					case 2:
						base.controller.ClearElementValue(_targetCustomControllerElement);
						num = -873783483;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal override bool IsPressed()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				return false;
			}
			if (!_axis.buttonValue)
			{
				return _axis.value != 0f;
			}
			return true;
		}

		internal override bool IsThisOrTouchRegionGameObject(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			if (base.IsThisOrTouchRegionGameObject(gameObject))
			{
				return true;
			}
			if (yOoaERsLfwRYibdXndHsenfOaVXe != null)
			{
				return yOoaERsLfwRYibdXndHsenfOaVXe.gameObject == gameObject;
			}
			return false;
		}

		private void TfNmSnGnpngwyaeoaJynHLedvQZ()
		{
			if (!_useDigitalAxisSimulation)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (_axis.buttonValue)
				{
					num = 1608284382;
					num2 = num;
				}
				else
				{
					num = 1608284381;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5FDC78DC)
					{
					case 0:
						num = 1608284376;
						continue;
					case 3:
						return;
					case 2:
						zjMKBxqOgwPmpEClcPfpjHXaBkZ();
						num = 1608284383;
						continue;
					case 4:
						break;
					default:
						ZAIBJyFskuHqKsgCRyaGDwPriJl();
						return;
					}
					break;
				}
			}
		}

		private void zjMKBxqOgwPmpEClcPfpjHXaBkZ()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			float num2 = MathTools.Abs(_digitalAxisSensitivity);
			while (true)
			{
				int num3 = -1861969371;
				while (true)
				{
					switch (num3 ^ -1861969372)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						num *= num2 * Time.unscaledDeltaTime;
						num += nNEEUtDnZNGztzylwYsGUXILDzX;
						num = MathTools.Clamp(num, -1f, 1f);
						num3 = -1861969372;
						continue;
					case 0:
						hOqmqOAIOZLRmDMQVNtxmmyPjmN(num, true);
						num3 = -1861969369;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void ZAIBJyFskuHqKsgCRyaGDwPriJl()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				goto IL_0012;
			}
			goto IL_00a4;
			IL_0012:
			int num2 = -1260079350;
			goto IL_0017;
			IL_0017:
			float num4 = default(float);
			float num5 = default(float);
			float num3 = default(float);
			while (true)
			{
				switch (num2 ^ -1260079349)
				{
				case 2:
					break;
				case 1:
					return;
				case 3:
					if (MathTools.Abs(num4) >= MathTools.Abs(num5))
					{
						num3 = 0f;
						num2 = -1260079345;
						continue;
					}
					goto case 6;
				case 0:
					num4 = num * Time.unscaledDeltaTime;
					num2 = -1260079352;
					continue;
				case 6:
				{
					float num6 = ((num5 > 0f) ? (-1f) : 1f);
					num3 = num5 + num6 * num4;
					num2 = -1260079357;
					continue;
				}
				case 5:
					goto IL_00a4;
				case 4:
					num2 = -1260079357;
					continue;
				case 7:
					return;
				default:
					hOqmqOAIOZLRmDMQVNtxmmyPjmN(num3, true);
					return;
				}
				break;
			}
			goto IL_0012;
			IL_00a4:
			num5 = nNEEUtDnZNGztzylwYsGUXILDzX;
			int num7;
			if (num5 != 0f)
			{
				num2 = -1260079349;
				num7 = num2;
			}
			else
			{
				num2 = -1260079348;
				num7 = num2;
			}
			goto IL_0017;
		}

		private void hOqmqOAIOZLRmDMQVNtxmmyPjmN(float P_0, bool P_1)
		{
			epmELKqQkigMEBswrOLxBaKJgksu = nNEEUtDnZNGztzylwYsGUXILDzX;
			nNEEUtDnZNGztzylwYsGUXILDzX = P_0;
			if (P_0 != epmELKqQkigMEBswrOLxBaKJgksu)
			{
				goto IL_001c;
			}
			goto IL_0050;
			IL_001c:
			int num = 2124537616;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ 0x7EA1DF13)
				{
				case 4:
					break;
				default:
					return;
				case 3:
					tPzLrmyiYkESrTkUqlRUVdqEdkXD(null);
					num = 2124537619;
					continue;
				case 0:
					goto IL_0050;
				case 1:
					_onAxisValueChanged.Invoke(P_0);
					num = 2124537617;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_001c;
			IL_0050:
			if (P_1)
			{
				int num2;
				if (P_0 != epmELKqQkigMEBswrOLxBaKJgksu)
				{
					num = 2124537618;
					num2 = num;
				}
				else
				{
					num = 2124537617;
					num2 = num;
				}
				goto IL_0021;
			}
		}

		private void KeZsCUrjBWAXHpcDBjgHggzgjRn()
		{
			if (_buttonType != ButtonType.ToggleSwitch)
			{
				goto IL_004d;
			}
			if (buttonValue)
			{
				_axis.SetRawValue(_axis.rawZero);
				goto IL_0027;
			}
			goto IL_0072;
			IL_0072:
			_axis.SetRawValue(_axis.rawMax);
			return;
			IL_004d:
			int num;
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawMax);
				num = -1760700518;
				goto IL_002c;
			}
			return;
			IL_0027:
			num = -1760700517;
			goto IL_002c;
			IL_002c:
			switch (num ^ -1760700518)
			{
			case 4:
				break;
			default:
				return;
			case 3:
				goto IL_004d;
			case 2:
				goto IL_0072;
			case 1:
				return;
			case 0:
				return;
			}
			goto IL_0027;
		}

		private void MpKdXGgKmgAqQdDxmXYWSFTTKekf()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void NVWqZPEZaDhGVdcEuqvABdsUKUL()
		{
			_targetCustomControllerElement.ClearElementCaches();
			dByKttBtodosJPFybBXLHsYfHmZw();
			BpIrxrTAZovcjjJKjdrhqiRYbUtH();
		}

		private void BpIrxrTAZovcjjJKjdrhqiRYbUtH()
		{
			if (!_manageRaycasting)
			{
				return;
			}
			while (true)
			{
				cVCPUrwTVVqfwiajczZVENUMDXp.ZWxGRFCRCNYsxogmNDUfCfMeCIIr(base.transform, jRYzOZIJAJApqJNFeBYzaySiWHvl());
				int num = -68794029;
				while (true)
				{
					switch (num ^ -68794029)
					{
					case 2:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0009:
					num = -68794030;
				}
			}
		}

		private bool jRYzOZIJAJApqJNFeBYzaySiWHvl()
		{
			if (yOoaERsLfwRYibdXndHsenfOaVXe != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void WgGdgRGLGuNKILyWzVQUgvhaIKf(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				ScBbWfMbGgWRkVPrsqLkpPjeHhR(P_0);
				P_0.PointerDownEvent += WIePpjCcsUBMIhAWGtGpDSlJlip;
				P_0.PointerUpEvent += pEabpejZnFXyFYVtSEnxCGboYRd;
				P_0.PointerEnterEvent += dcgoqSOZQngElokwIQkKjPdIlML;
				P_0.PointerExitEvent += mErQunVxoylvoyoLVaOLThnRYfr;
				int num = -1226935595;
				while (true)
				{
					switch (num ^ -1226935596)
					{
					case 0:
						goto IL_000a;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000a:
					num = -1226935594;
				}
			}
		}

		private void ScBbWfMbGgWRkVPrsqLkpPjeHhR(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				P_0.PointerDownEvent -= WIePpjCcsUBMIhAWGtGpDSlJlip;
				int num = -89558544;
				while (true)
				{
					switch (num ^ -89558544)
					{
					case 2:
						num = -89558541;
						continue;
					default:
						return;
					case 3:
						break;
					case 0:
						P_0.PointerUpEvent -= pEabpejZnFXyFYVtSEnxCGboYRd;
						P_0.PointerEnterEvent -= dcgoqSOZQngElokwIQkKjPdIlML;
						P_0.PointerExitEvent -= mErQunVxoylvoyoLVaOLThnRYfr;
						num = -89558543;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void dByKttBtodosJPFybBXLHsYfHmZw()
		{
			if (yOoaERsLfwRYibdXndHsenfOaVXe == _touchRegion)
			{
				goto IL_0013;
			}
			goto IL_0060;
			IL_0013:
			int num = -209507842;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num ^ -209507844)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					yOoaERsLfwRYibdXndHsenfOaVXe = _touchRegion;
					WgGdgRGLGuNKILyWzVQUgvhaIKf(yOoaERsLfwRYibdXndHsenfOaVXe);
					num = -209507844;
					continue;
				case 1:
					goto IL_0060;
				case 0:
					return;
				}
				break;
			}
			goto IL_0013;
			IL_0060:
			ScBbWfMbGgWRkVPrsqLkpPjeHhR(yOoaERsLfwRYibdXndHsenfOaVXe);
			num = -209507841;
			goto IL_0018;
		}

		private void EngeuFiINqVonFKGMsOZSqAIstKQ(Vector2 P_0, bool P_1, float P_2, vYIjyUMfsrLjixlJmTaeYJNvqmn P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = default(Vector2);
			while (true)
			{
				int num = 1514228330;
				while (true)
				{
					switch (num ^ 0x5A414A6B)
					{
					case 0:
						break;
					case 1:
						goto IL_002f;
					default:
					{
						Vector2 pivot = base.rectTransform.pivot;
						Vector2 sizeDelta = base.rectTransform.sizeDelta;
						Vector3 localScale = base.rectTransform.localScale;
						vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
						KXGXneOjslBgCoFxDokJHtUpHCr(vector, PositionType.UMtjEaOogDDwQiplOLpTuwxTdbQ, P_1, P_2, P_3);
						return;
					}
					}
					break;
					IL_002f:
					vector = PPQNIOlPnyDtERyUKpTWMMgiKJj.yrmpiQKoHoELPfnQUspISjBYwMx(base.canvas, rectTransform, P_0);
					num = 1514228329;
				}
			}
		}

		private void KXGXneOjslBgCoFxDokJHtUpHCr(Vector2 P_0, PositionType P_1, bool P_2, float P_3, vYIjyUMfsrLjixlJmTaeYJNvqmn P_4)
		{
			if (GmmtQmbFnqcHiBbFQapXEeqdMsIP)
			{
				goto IL_000b;
			}
			goto IL_01ba;
			IL_000b:
			int num = -1876309631;
			goto IL_0010;
			IL_0010:
			Transform parent = default(Transform);
			Vector2 one = default(Vector2);
			Vector2 sizeDelta = default(Vector2);
			RectTransform rectTransform = default(RectTransform);
			bool flag = default(bool);
			float num3 = default(float);
			float num2 = default(float);
			while (true)
			{
				float num4;
				switch (num ^ -1876309613)
				{
				case 6:
					break;
				case 17:
					CgelQMRxKcNpSeEdjHrUgepUNWaw();
					GmmtQmbFnqcHiBbFQapXEeqdMsIP = false;
					JUQAZmPbLZlOaQZfnawbuDZePwz = vYIjyUMfsrLjixlJmTaeYJNvqmn.TCGihQKDgeeGtvEXifcuojmabzj;
					num = -1876309606;
					continue;
				case 9:
					if (base.canvas == null)
					{
						Logger.LogWarning("Animation cannot be used without a Canvas.");
						P_2 = false;
						num = -1876309615;
						continue;
					}
					goto case 11;
				case 12:
					StartCoroutine(ujMkhdPMeAqacuGnPYMNkpmJFwqB);
					num = -1876309609;
					continue;
				case 15:
					moveStartedDelegate(P_4);
					return;
				case 0:
					if (!(parent == null))
					{
						one.x *= parent.localScale.x;
						num = -1876309605;
						continue;
					}
					goto case 19;
				case 10:
					num4 = one.x;
					goto IL_012d;
				case 19:
					sizeDelta = rectTransform.sizeDelta;
					num = -1876309616;
					continue;
				case 3:
					flag = sizeDelta.x < sizeDelta.y;
					num = -1876309614;
					continue;
				case 8:
					one.y *= parent.localScale.y;
					num = -1876309625;
					continue;
				case 4:
					JUQAZmPbLZlOaQZfnawbuDZePwz = P_4;
					BfEabZhMOdfBmuBiTDzXflgDYlzq = true;
					num = -1876309604;
					continue;
				case 18:
					if (P_2 && JUQAZmPbLZlOaQZfnawbuDZePwz == P_4)
					{
						return;
					}
					goto IL_01ba;
				case 13:
					goto IL_01ba;
				case 16:
					goto IL_01d6;
				case 1:
					num3 = MathTools.Max(sizeDelta.x, sizeDelta.y);
					if (flag)
					{
						num4 = one.y;
						goto IL_012d;
					}
					num = -1876309607;
					continue;
				case 5:
					ujMkhdPMeAqacuGnPYMNkpmJFwqB = YwNxjLvllECYgmvWvRLPlgYahiJ(P_0, P_1, P_3, P_4);
					num = -1876309601;
					continue;
				case 20:
					goto IL_0234;
				case 11:
					if (base.canvas.renderMode == RenderMode.WorldSpace)
					{
						Logger.LogWarning("Animation can only be used with a screen space Canvas.");
						P_2 = false;
						num = -1876309615;
						continue;
					}
					goto case 2;
				case 7:
					P_3 = P_3 / num2 * num3;
					num = -1876309610;
					continue;
				case 22:
					moveStartedDelegate(P_4);
					num = -1876309626;
					continue;
				case 14:
					if (num2 == 0f)
					{
						num2 = 0.0001f;
						num = -1876309612;
						continue;
					}
					goto case 7;
				case 2:
					if (P_2)
					{
						parent = base.transform;
						rectTransform = base.canvasTransform;
						one = Vector2.one;
						num = -1876309625;
						continue;
					}
					goto case 22;
				default:
					{
						yFIryXiFmAheSzYjuuUCpBvLoYn(P_4, P_0, P_1);
						return;
					}
					IL_012d:
					num2 = num4;
					num = -1876309603;
					continue;
				}
				break;
				IL_0234:
				int num5;
				if (!((parent = parent.parent) != rectTransform))
				{
					num = -1876309632;
					num5 = num;
				}
				else
				{
					num = -1876309613;
					num5 = num;
				}
				continue;
				IL_01d6:
				int num6;
				if (ujMkhdPMeAqacuGnPYMNkpmJFwqB == null)
				{
					num = -1876309606;
					num6 = num;
				}
				else
				{
					num = -1876309630;
					num6 = num;
				}
			}
			goto IL_000b;
			IL_01ba:
			int num7;
			if (GmmtQmbFnqcHiBbFQapXEeqdMsIP)
			{
				num = -1876309629;
				num7 = num;
			}
			else
			{
				num = -1876309606;
				num7 = num;
			}
			goto IL_0010;
		}

		private IEnumerator YwNxjLvllECYgmvWvRLPlgYahiJ(Vector2 P_0, PositionType P_1, float P_2, vYIjyUMfsrLjixlJmTaeYJNvqmn P_3)
		{
			rsyiMSQuFtxAGAoztUeTKDOkMKs rsyiMSQuFtxAGAoztUeTKDOkMKs2 = new rsyiMSQuFtxAGAoztUeTKDOkMKs(0);
			rsyiMSQuFtxAGAoztUeTKDOkMKs2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
			rsyiMSQuFtxAGAoztUeTKDOkMKs2.ofwHDGItTMAnajZEczGfQJAfkWi = P_0;
			rsyiMSQuFtxAGAoztUeTKDOkMKs2.cEFYMcdcTaIHyHTckcmnNJNVUTy = P_1;
			rsyiMSQuFtxAGAoztUeTKDOkMKs2.lJAziHQEMyViiggdNdulCrmGjoLg = P_2;
			rsyiMSQuFtxAGAoztUeTKDOkMKs2.DTQmUpQxxpEaloJNKuhapMsZmFf = P_3;
			return rsyiMSQuFtxAGAoztUeTKDOkMKs2;
		}

		private void yFIryXiFmAheSzYjuuUCpBvLoYn(vYIjyUMfsrLjixlJmTaeYJNvqmn P_0, Vector2 P_1, PositionType P_2)
		{
			PPQNIOlPnyDtERyUKpTWMMgiKJj.AwbDNgzQKwyuEBeAcQzspJfsFFt(base.rectTransform, P_1, P_2);
			GmmtQmbFnqcHiBbFQapXEeqdMsIP = false;
			JUQAZmPbLZlOaQZfnawbuDZePwz = vYIjyUMfsrLjixlJmTaeYJNvqmn.TCGihQKDgeeGtvEXifcuojmabzj;
			while (true)
			{
				int num = -293758951;
				while (true)
				{
					switch (num ^ -293758952)
					{
					case 5:
						break;
					case 1:
						if (P_0 == vYIjyUMfsrLjixlJmTaeYJNvqmn.HwWCoknLLuvDCNsHCSIjJkwLMtB)
						{
							BfEabZhMOdfBmuBiTDzXflgDYlzq = false;
							num = -293758952;
							continue;
						}
						goto case 3;
					case 3:
						if (P_0 == vYIjyUMfsrLjixlJmTaeYJNvqmn.euXYneYPthVhveBWhDzbgcsApkRZ)
						{
							BfEabZhMOdfBmuBiTDzXflgDYlzq = true;
							num = -293758948;
							continue;
						}
						goto case 4;
					case 0:
						num = -293758948;
						continue;
					case 4:
						CgelQMRxKcNpSeEdjHrUgepUNWaw();
						num = -293758950;
						continue;
					default:
						moveEndedDelegate(P_0);
						return;
					}
					break;
				}
			}
		}

		private void ebwjYhEqRdpMXwLKPVkBqUQNcEDa(vYIjyUMfsrLjixlJmTaeYJNvqmn P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag2 = default(bool);
			bool flag = default(bool);
			while (true)
			{
				int num = -1546300417;
				while (true)
				{
					switch (num ^ -1546300425)
					{
					case 0:
						break;
					default:
						return;
					case 5:
					{
						int num3;
						if (!flag2)
						{
							num = -1546300427;
							num3 = num;
						}
						else
						{
							num = -1546300429;
							num3 = num;
						}
						continue;
					}
					case 7:
					{
						int num6;
						if (_moveToTouchPosition)
						{
							num = -1546300428;
							num6 = num;
						}
						else
						{
							num = -1546300430;
							num6 = num;
						}
						continue;
					}
					case 3:
						if (_returnOnRelease && P_0 == vYIjyUMfsrLjixlJmTaeYJNvqmn.euXYneYPthVhveBWhDzbgcsApkRZ)
						{
							flag2 = true;
							flag = false;
							num = -1546300430;
							continue;
						}
						goto case 5;
					case 6:
					{
						int num4;
						if (!_followTouchPosition)
						{
							num = -1546300426;
							num4 = num;
						}
						else
						{
							num = -1546300430;
							num4 = num;
						}
						continue;
					}
					case 1:
						if (yOoaERsLfwRYibdXndHsenfOaVXe != null)
						{
							int num5;
							if (_useTouchRegionOnly)
							{
								num = -1546300430;
								num5 = num;
							}
							else
							{
								num = -1546300432;
								num5 = num;
							}
							continue;
						}
						goto case 5;
					case 8:
						flag2 = false;
						flag = false;
						if (_followTouchPosition)
						{
							int num2;
							if (stayActiveOnSwipeOut)
							{
								num = -1546300428;
								num2 = num;
							}
							else
							{
								num = -1546300431;
								num2 = num;
							}
							continue;
						}
						goto case 6;
					case 4:
						cVCPUrwTVVqfwiajczZVENUMDXp.ZWxGRFCRCNYsxogmNDUfCfMeCIIr(base.transform, flag);
						num = -1546300427;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void juHmsVQdOwsmtGcmTviVInzkJKk(vYIjyUMfsrLjixlJmTaeYJNvqmn P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			while (true)
			{
				int num = 1606666609;
				while (true)
				{
					switch (num ^ 0x5FC3C977)
					{
					case 9:
						break;
					default:
						return;
					case 6:
						if (_followTouchPosition)
						{
							int num5;
							if (!stayActiveOnSwipeOut)
							{
								num = 1606666613;
								num5 = num;
							}
							else
							{
								num = 1606666623;
								num5 = num;
							}
							continue;
						}
						goto case 2;
					case 5:
						cVCPUrwTVVqfwiajczZVENUMDXp.ZWxGRFCRCNYsxogmNDUfCfMeCIIr(base.transform, flag2);
						num = 1606666608;
						continue;
					case 1:
						flag = true;
						flag2 = jRYzOZIJAJApqJNFeBYzaySiWHvl();
						num = 1606666612;
						continue;
					case 8:
					{
						int num6;
						if (!_returnOnRelease)
						{
							num = 1606666612;
							num6 = num;
						}
						else
						{
							num = 1606666611;
							num6 = num;
						}
						continue;
					}
					case 4:
					{
						int num4;
						if (P_0 != vYIjyUMfsrLjixlJmTaeYJNvqmn.HwWCoknLLuvDCNsHCSIjJkwLMtB)
						{
							num = 1606666612;
							num4 = num;
						}
						else
						{
							num = 1606666614;
							num4 = num;
						}
						continue;
					}
					case 3:
					{
						int num7;
						if (!flag)
						{
							num = 1606666608;
							num7 = num;
						}
						else
						{
							num = 1606666610;
							num7 = num;
						}
						continue;
					}
					case 2:
						if (!_followTouchPosition && yOoaERsLfwRYibdXndHsenfOaVXe != null)
						{
							int num3;
							if (_useTouchRegionOnly)
							{
								num = 1606666612;
								num3 = num;
							}
							else
							{
								num = 1606666615;
								num3 = num;
							}
							continue;
						}
						goto case 3;
					case 0:
					{
						int num2;
						if (_moveToTouchPosition)
						{
							num = 1606666623;
							num2 = num;
						}
						else
						{
							num = 1606666612;
							num2 = num;
						}
						continue;
					}
					case 7:
						return;
					}
					break;
				}
			}
		}

		private void dyGGqqDNKdJMvZlREoTIYHXTftYS(int P_0)
		{
			if (!TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(P_0))
			{
				while (true)
				{
					switch (-106613468 ^ -106613467)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			EngeuFiINqVonFKGMsOZSqAIstKQ(TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(P_0), false, 0f, vYIjyUMfsrLjixlJmTaeYJNvqmn.euXYneYPthVhveBWhDzbgcsApkRZ);
		}

		private void CgelQMRxKcNpSeEdjHrUgepUNWaw()
		{
			if (ujMkhdPMeAqacuGnPYMNkpmJFwqB != null)
			{
				try
				{
					StopCoroutine(ujMkhdPMeAqacuGnPYMNkpmJFwqB);
				}
				catch
				{
				}
				ujMkhdPMeAqacuGnPYMNkpmJFwqB = null;
			}
		}

		private void GLnFKkzcjTCAOtkTuThfdBcbeFU()
		{
			if (!hasPointer)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
				{
					num = 1793411794;
					num2 = num;
				}
				else
				{
					num = 1793411797;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x6AE54AD1)
					{
					case 0:
						num = 1793411792;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
					{
						PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(effectivePointerId);
						if (pointerEventData != null && pointerEventData.pointerPress != null)
						{
							uhbxZnhdAiTocMkidbifwylOKNg(pointerEventData);
							return;
						}
						goto case 2;
					}
					case 2:
						lvEXyedGHJXClGybBOaYBiVqimu();
						num = 1793411797;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private bool eOHzHpzQRbBLjxcuQVfnfVkaPND()
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

		private void IVWagqmpVqfBssUpPTaUIrMVFpo()
		{
			JMoqQTgkIefgMovyFXwlzczIaOU = int.MinValue;
			qkqJpryWPyBJRDHKnavLPnAoLsP = int.MinValue;
		}

		private bool xJRpUEtiZlPsigLVVURBBlekxkJ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (JMoqQTgkIefgMovyFXwlzczIaOU == int.MinValue)
			{
				return false;
			}
			if (JMoqQTgkIefgMovyFXwlzczIaOU == P_0)
			{
				return true;
			}
			if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0) && qkqJpryWPyBJRDHKnavLPnAoLsP != int.MinValue && P_0 == qkqJpryWPyBJRDHKnavLPnAoLsP)
			{
				return true;
			}
			return false;
		}

		private PointerEventData FcNxJWJevjAfECcjXghibLdzawa(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			GameObject gameObject = default(GameObject);
			float unscaledTime = default(float);
			GameObject gameObject2 = default(GameObject);
			float unscaledTime2 = default(float);
			while (true)
			{
				int num = -1872059350;
				while (true)
				{
					switch (num ^ -1872059353)
					{
					case 5:
						break;
					case 6:
						pointerEventData.pointerDrag = P_1;
						goto case 3;
					case 19:
						pointerEventData.eligibleForClick = true;
						pointerEventData.delta = Vector2.zero;
						pointerEventData.dragging = false;
						pointerEventData.useDragThreshold = true;
						num = -1872059354;
						continue;
					case 22:
						pointerEventData.clickCount = 1;
						num = -1872059341;
						continue;
					case 1:
						pointerEventData.pressPosition = pointerEventData.position;
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						if (pointerEventData.pointerEnter != P_1)
						{
							pointerEventData.pointerEnter = P_1;
							num = -1872059351;
							continue;
						}
						goto case 14;
					case 7:
						pointerEventData.clickCount = 1;
						num = -1872059337;
						continue;
					case 14:
						gameObject = P_1;
						num = -1872059355;
						continue;
					case 18:
					{
						int num3;
						if (!TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
						{
							num = -1872059347;
							num3 = num;
						}
						else
						{
							num = -1872059352;
							num3 = num;
						}
						continue;
					}
					case 16:
						pointerEventData.clickTime = unscaledTime;
						num = -1872059341;
						continue;
					case 23:
					{
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						gameObject2 = P_1;
						unscaledTime2 = Time.unscaledTime;
						int num8;
						if (!(gameObject2 == pointerEventData.lastPress))
						{
							num = -1872059346;
							num8 = num;
						}
						else
						{
							num = -1872059345;
							num8 = num;
						}
						continue;
					}
					case 13:
					{
						pointerEventData.position = TouchInteractable.eWcGendfQFVDlCeIgDmIKeADLJy(P_0);
						int num7;
						if (!TouchInteractable.KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
						{
							num = -1872059339;
							num7 = num;
						}
						else
						{
							num = -1872059340;
							num7 = num;
						}
						continue;
					}
					case 20:
						pointerEventData.pointerPress = gameObject;
						pointerEventData.rawPointerPress = P_1;
						pointerEventData.clickTime = unscaledTime;
						num = -1872059359;
						continue;
					case 8:
					{
						float num6 = unscaledTime2 - pointerEventData.clickTime;
						if (num6 < 0.3f)
						{
							pointerEventData.clickCount++;
							num = -1872059353;
							continue;
						}
						goto case 12;
					}
					case 11:
					{
						float num4 = unscaledTime - pointerEventData.clickTime;
						int num5;
						if (num4 < 0.3f)
						{
							num = -1872059342;
							num5 = num;
						}
						else
						{
							num = -1872059360;
							num5 = num;
						}
						continue;
					}
					case 21:
						pointerEventData.clickCount++;
						num = -1872059337;
						continue;
					case 4:
						pointerEventData.useDragThreshold = true;
						pointerEventData.pressPosition = pointerEventData.position;
						num = -1872059344;
						continue;
					case 0:
						pointerEventData.clickTime = unscaledTime2;
						num = -1872059338;
						continue;
					case 12:
						pointerEventData.clickCount = 1;
						num = -1872059353;
						continue;
					case 9:
						pointerEventData.clickCount = 1;
						num = -1872059338;
						continue;
					case 15:
						pointerEventData.eligibleForClick = true;
						pointerEventData.delta = Vector2.zero;
						pointerEventData.dragging = false;
						num = -1872059357;
						continue;
					case 17:
						pointerEventData.pointerPress = gameObject2;
						pointerEventData.rawPointerPress = P_1;
						pointerEventData.clickTime = unscaledTime2;
						pointerEventData.pointerDrag = P_1;
						num = -1872059356;
						continue;
					case 2:
					{
						unscaledTime = Time.unscaledTime;
						int num2;
						if (!(gameObject == pointerEventData.lastPress))
						{
							num = -1872059343;
							num2 = num;
						}
						else
						{
							num = -1872059348;
							num2 = num;
						}
						continue;
					}
					default:
						Logger.LogWarning("Unsupported pointerId: " + P_0);
						return null;
					case 3:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private PointerEventData YmNTOnqdWUarvHWIAOOUMxyMuVXg(int P_0)
		{
			PointerEventData pointerEventData = eHumJbgUTelnpVVEEkJoClmMzSA(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			if (TouchInteractable.KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
			{
				pointerEventData.eligibleForClick = false;
				pointerEventData.pointerPress = null;
				pointerEventData.rawPointerPress = null;
				goto IL_002d;
			}
			goto IL_00a1;
			IL_00ba:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			return null;
			IL_00a1:
			int num;
			if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
			{
				pointerEventData.eligibleForClick = false;
				num = 65709282;
				goto IL_0032;
			}
			goto IL_00ba;
			IL_002d:
			num = 65709283;
			goto IL_0032;
			IL_0032:
			while (true)
			{
				switch (num ^ 0x3EAA4E2)
				{
				case 3:
					break;
				case 1:
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					pointerEventData.pointerEnter = null;
					goto IL_00d1;
				case 0:
					pointerEventData.pointerPress = null;
					num = 65709286;
					continue;
				case 4:
					pointerEventData.rawPointerPress = null;
					pointerEventData.dragging = false;
					pointerEventData.pointerDrag = null;
					goto IL_00d1;
				case 2:
					goto IL_00a1;
				default:
					goto IL_00ba;
					IL_00d1:
					return pointerEventData;
				}
				break;
			}
			goto IL_002d;
		}

		private void uhbxZnhdAiTocMkidbifwylOKNg(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				OnPointerUp(P_0);
				int num = 120983109;
				while (true)
				{
					switch (num ^ 0x7360E44)
					{
					case 0:
						num = 120983111;
						continue;
					default:
						return;
					case 3:
						break;
					case 1:
						YmNTOnqdWUarvHWIAOOUMxyMuVXg(effectivePointerId);
						num = 120983110;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private PointerEventData eHumJbgUTelnpVVEEkJoClmMzSA(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				goto IL_0008;
			}
			int num;
			if (tTbkNLOsvXDQdRtrdKXoAuKlqSn == null)
			{
				tTbkNLOsvXDQdRtrdKXoAuKlqSn = new Dictionary<int, PointerEventData>();
				num = 65064102;
				goto IL_000d;
			}
			goto IL_00c4;
			IL_000d:
			PointerEventData value = default(PointerEventData);
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x3E0CCA6)
				{
				case 6:
					break;
				case 5:
					return null;
				case 2:
					value.button = button;
					num = 65064101;
					continue;
				case 1:
					button = PointerEventData.InputButton.Middle;
					num = 65064100;
					continue;
				case 12:
					num = 65064098;
					continue;
				case 7:
					num = 65064100;
					continue;
				case 11:
					value = new PointerEventData(EventSystem.current);
					value.pointerId = P_0;
					num = 65064111;
					continue;
				case 13:
					goto IL_00b8;
				case 0:
					goto IL_00c4;
				case 10:
					goto IL_00e8;
				case 8:
					switch (num2)
					{
					case -3:
						break;
					case -1:
						goto IL_00b8;
					case -2:
						goto IL_00e8;
					default:
						goto IL_0109;
					}
					goto case 1;
				case 4:
					throw new NotImplementedException();
				case 9:
					tTbkNLOsvXDQdRtrdKXoAuKlqSn.Add(P_0, value);
					if (TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
					{
						num2 = P_0;
						num = 65064110;
						continue;
					}
					goto default;
				default:
					{
						return value;
					}
					IL_0109:
					num = 65064106;
					continue;
					IL_00e8:
					button = PointerEventData.InputButton.Right;
					num = 65064097;
					continue;
					IL_00b8:
					button = PointerEventData.InputButton.Left;
					num = 65064100;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_00c4:
			int num3;
			if (tTbkNLOsvXDQdRtrdKXoAuKlqSn.TryGetValue(P_0, out value))
			{
				num = 65064101;
				num3 = num;
			}
			else
			{
				num = 65064109;
				num3 = num;
			}
			goto IL_000d;
			IL_0008:
			num = 65064099;
			goto IL_000d;
		}

		private void RTFkZgwwfqcoraXUeOtRrGPTipR(PointerEventData P_0, vwOsOGNXaoaruwxhzgqJCegchQrA P_1)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0052;
			IL_0008:
			int num = -1533283156;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1533283155)
			{
			case 4:
				break;
			default:
				return;
			case 1:
				if (!xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
				{
					return;
				}
				goto IL_0052;
			case 3:
				goto IL_0044;
			case 2:
				goto IL_0052;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0044:
			base.OnPointerDown(P_0);
			num = -1533283155;
			goto IL_000d;
			IL_0052:
			if (vWWTQEuzSAtwkwTidoREbMzaAEi() && IsInteractable())
			{
				oPbGWVlpSTmnotbhVEcMMsRAWvN(P_0.pointerId, P_0.pressPosition, P_1);
				num = -1533283154;
				goto IL_000d;
			}
			goto IL_0044;
		}

		private void oyVgIoryHcoeYsQAABSabldnFuw(PointerEventData P_0, vwOsOGNXaoaruwxhzgqJCegchQrA P_1)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_006d;
			IL_0008:
			int num = 90892518;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x56AE8E4)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_0032;
				case 4:
					goto IL_0051;
				case 5:
					return;
				case 1:
					goto IL_006d;
				case 3:
					return;
				}
				break;
				IL_0032:
				int num2;
				if (!xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
				{
					num = 90892513;
					num2 = num;
				}
				else
				{
					num = 90892517;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_006d:
			if (TouchInteractable.RoGStfwaKUBSohbxbjNXJoKcyhPq(effectivePointerId))
			{
				return;
			}
			goto IL_0051;
			IL_0051:
			lvEXyedGHJXClGybBOaYBiVqimu();
			base.OnPointerUp(P_0);
			num = 90892519;
			goto IL_000d;
		}

		private void kniQNhRGNrdKgAIpgLeavFJtBJvU(PointerEventData P_0, vwOsOGNXaoaruwxhzgqJCegchQrA P_1)
		{
			if (hasPointer && !xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				return;
			}
			MouseButtonFlags mouseButtonFlags = default(MouseButtonFlags);
			int num2 = default(int);
			bool flag2 = default(bool);
			vwOsOGNXaoaruwxhzgqJCegchQrA vwOsOGNXaoaruwxhzgqJCegchQrA2 = default(vwOsOGNXaoaruwxhzgqJCegchQrA);
			GameObject gameObject = default(GameObject);
			while (true)
			{
				bool flag = TouchInteractable.LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0.pointerId);
				int num = 1325346708;
				while (true)
				{
					switch (num ^ 0x4EFF2F9D)
					{
					case 20:
						num = 1325346713;
						continue;
					case 21:
						num = 1325346702;
						continue;
					case 14:
						if (IsInteractable() && (!flag || TouchInteractable.adosDjbqcDBzBFXIUEkqUggQerO(mouseButtonFlags)) && !jYtFWKZUVrechfzATGCgCETBhJCg)
						{
							if (flag)
							{
								int num3;
								if (!TouchInteractable.mrmKZDYUuqVORhTlxFDFBEPmIPc(mouseButtonFlags, out num2))
								{
									num = 1325346706;
									num3 = num;
								}
								else
								{
									num = 1325346717;
									num3 = num;
								}
								continue;
							}
							goto case 17;
						}
						goto case 8;
					case 18:
					{
						int num5;
						if (vWWTQEuzSAtwkwTidoREbMzaAEi())
						{
							num = 1325346707;
							num5 = num;
						}
						else
						{
							num = 1325346709;
							num5 = num;
						}
						continue;
					}
					case 0:
						qkqJpryWPyBJRDHKnavLPnAoLsP = num2;
						num = 1325346700;
						continue;
					case 17:
						flag2 = true;
						num = 1325346709;
						continue;
					case 10:
						vwOsOGNXaoaruwxhzgqJCegchQrA2 = P_1;
						num = 1325346712;
						continue;
					case 9:
						flag2 = false;
						num = 1325346711;
						continue;
					case 1:
						gameObject = base.gameObject;
						num = 1325346714;
						continue;
					case 8:
						base.OnPointerEnter(P_0);
						if (flag2)
						{
							switch (P_1)
							{
							case vwOsOGNXaoaruwxhzgqJCegchQrA.UMtjEaOogDDwQiplOLpTuwxTdbQ:
								break;
							default:
								goto IL_015c;
							case vwOsOGNXaoaruwxhzgqJCegchQrA.qBvlHFfTVaijZsMuBaXfTPCbahL:
								goto IL_0176;
							}
							goto case 1;
						}
						goto default;
					case 3:
						throw new NotImplementedException();
					case 11:
						goto IL_0176;
					case 19:
					{
						int num4;
						if (_activateOnSwipeIn)
						{
							num = 1325346703;
							num4 = num;
						}
						else
						{
							num = 1325346709;
							num4 = num;
						}
						continue;
					}
					case 5:
						switch (vwOsOGNXaoaruwxhzgqJCegchQrA2)
						{
						case vwOsOGNXaoaruwxhzgqJCegchQrA.qBvlHFfTVaijZsMuBaXfTPCbahL:
							goto IL_01c2;
						case vwOsOGNXaoaruwxhzgqJCegchQrA.UMtjEaOogDDwQiplOLpTuwxTdbQ:
							goto IL_021e;
						}
						num = 1325346704;
						continue;
					case 2:
						goto IL_01c2;
					case 7:
					{
						PointerEventData pointerEventData = FcNxJWJevjAfECcjXghibLdzawa((qkqJpryWPyBJRDHKnavLPnAoLsP != int.MinValue) ? qkqJpryWPyBJRDHKnavLPnAoLsP : P_0.pointerId, gameObject);
						if (pointerEventData != null)
						{
							RTFkZgwwfqcoraXUeOtRrGPTipR(pointerEventData, P_1);
							num = 1325346705;
							continue;
						}
						goto default;
					}
					case 16:
						num = 1325346702;
						continue;
					case 6:
						goto IL_021e;
					case 4:
						break;
					case 15:
						qkqJpryWPyBJRDHKnavLPnAoLsP = P_0.pointerId;
						num = 1325346700;
						continue;
					case 13:
						throw new NotImplementedException();
					default:
						{
							GXxxUMYvhnAdzwfrIpAYPjIWpue = true;
							return;
						}
						IL_0176:
						gameObject = yOoaERsLfwRYibdXndHsenfOaVXe.gameObject;
						num = 1325346714;
						continue;
						IL_021e:
						mouseButtonFlags = base.allowedMouseButtons;
						num = 1325346696;
						continue;
						IL_01c2:
						mouseButtonFlags = _touchRegion.allowedMouseButtons;
						num = 1325346701;
						continue;
						IL_015c:
						num = 1325346718;
						continue;
					}
					break;
				}
			}
		}

		private void AQKFYYuUyzWMUiyIguWHpBOybED(PointerEventData P_0, vwOsOGNXaoaruwxhzgqJCegchQrA P_1)
		{
			if (hasPointer && !xJRpUEtiZlPsigLVVURBBlekxkJ(P_0.pointerId))
			{
				base.OnPointerExit(P_0);
				goto IL_001d;
			}
			goto IL_0050;
			IL_0050:
			int num;
			if (!stayActiveOnSwipeOut)
			{
				int num2;
				if (jYtFWKZUVrechfzATGCgCETBhJCg)
				{
					num = 1408145458;
					num2 = num;
				}
				else
				{
					num = 1408145459;
					num2 = num;
				}
				goto IL_0022;
			}
			goto IL_0079;
			IL_0079:
			base.OnPointerExit(P_0);
			GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
			return;
			IL_001d:
			num = 1408145456;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ 0x53EE9831)
				{
				case 4:
					break;
				case 3:
					lvEXyedGHJXClGybBOaYBiVqimu();
					num = 1408145459;
					continue;
				case 0:
					goto IL_0050;
				case 1:
					return;
				default:
					goto IL_0079;
				}
				break;
			}
			goto IL_001d;
		}

		private void oPbGWVlpSTmnotbhVEcMMsRAWvN(int P_0, Vector2 P_1, vwOsOGNXaoaruwxhzgqJCegchQrA P_2)
		{
			JMoqQTgkIefgMovyFXwlzczIaOU = P_0;
			while (true)
			{
				int num = -1565074948;
				while (true)
				{
					switch (num ^ -1565074946)
					{
					case 4:
						break;
					case 2:
						jYtFWKZUVrechfzATGCgCETBhJCg = true;
						if (_followTouchPosition)
						{
							dyGGqqDNKdJMvZlREoTIYHXTftYS(P_0);
							num = -1565074946;
							continue;
						}
						goto case 3;
					case 3:
						if (P_2 == vwOsOGNXaoaruwxhzgqJCegchQrA.qBvlHFfTVaijZsMuBaXfTPCbahL)
						{
							int num2;
							if (!_moveToTouchPosition)
							{
								num = -1565074946;
								num2 = num;
							}
							else
							{
								num = -1565074945;
								num2 = num;
							}
							continue;
						}
						goto default;
					case 1:
						EngeuFiINqVonFKGMsOZSqAIstKQ(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, vYIjyUMfsrLjixlJmTaeYJNvqmn.euXYneYPthVhveBWhDzbgcsApkRZ);
						num = -1565074946;
						continue;
					default:
						KeZsCUrjBWAXHpcDBjgHggzgjRn();
						return;
					}
					break;
				}
			}
		}

		private void lvEXyedGHJXClGybBOaYBiVqimu()
		{
			IVWagqmpVqfBssUpPTaUIrMVFpo();
			jYtFWKZUVrechfzATGCgCETBhJCg = false;
			if (!_followTouchPosition)
			{
				if (_moveToTouchPosition)
				{
					goto IL_001d;
				}
				goto IL_0043;
			}
			goto IL_0065;
			IL_0043:
			MpKdXGgKmgAqQdDxmXYWSFTTKekf();
			int num = -1570559823;
			goto IL_0022;
			IL_001d:
			num = -1570559824;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ -1570559823)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					goto IL_0043;
				case 3:
					if (BfEabZhMOdfBmuBiTDzXflgDYlzq)
					{
						ReturnToDefaultPosition();
						num = -1570559821;
						continue;
					}
					goto IL_0043;
				case 1:
					goto IL_0065;
				case 0:
					return;
				}
				break;
			}
			goto IL_001d;
			IL_0065:
			int num2;
			if (!_returnOnRelease)
			{
				num = -1570559821;
				num2 = num;
			}
			else
			{
				num = -1570559822;
				num2 = num;
			}
			goto IL_0022;
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
				{
					num = 1979367761;
					num2 = num;
				}
				else
				{
					num = 1979367767;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x75FAC154)
					{
					case 0:
						num = 1979367766;
						continue;
					case 2:
						break;
					case 5:
						return;
					case 3:
					{
						int num3;
						if (!(yOoaERsLfwRYibdXndHsenfOaVXe != null))
						{
							num = 1979367760;
							num3 = num;
						}
						else
						{
							num = 1979367765;
							num3 = num;
						}
						continue;
					}
					case 1:
						if (_useTouchRegionOnly)
						{
							return;
						}
						goto default;
					default:
						RTFkZgwwfqcoraXUeOtRrGPTipR(eventData, vwOsOGNXaoaruwxhzgqJCegchQrA.UMtjEaOogDDwQiplOLpTuwxTdbQ);
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0049;
			IL_0008:
			int num = -277172874;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -277172880)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					oyVgIoryHcoeYsQAABSabldnFuw(eventData, vwOsOGNXaoaruwxhzgqJCegchQrA.UMtjEaOogDDwQiplOLpTuwxTdbQ);
					num = -277172873;
					continue;
				case 4:
					goto IL_0049;
				case 2:
					if (_useTouchRegionOnly)
					{
						return;
					}
					goto case 3;
				case 6:
					return;
				case 5:
					return;
				case 1:
					goto IL_0091;
				case 7:
					return;
				}
				break;
				IL_0091:
				int num2;
				if (yOoaERsLfwRYibdXndHsenfOaVXe != null)
				{
					num = -277172878;
					num2 = num;
				}
				else
				{
					num = -277172877;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0049:
			int num3;
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				num = -277172875;
				num3 = num;
			}
			else
			{
				num = -277172879;
				num3 = num;
			}
			goto IL_000d;
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				while (true)
				{
					IL_005a:
					if (yOoaERsLfwRYibdXndHsenfOaVXe != null && _useTouchRegionOnly)
					{
						return;
					}
					while (true)
					{
						IL_004b:
						kniQNhRGNrdKgAIpgLeavFJtBJvU(eventData, vwOsOGNXaoaruwxhzgqJCegchQrA.UMtjEaOogDDwQiplOLpTuwxTdbQ);
						int num = 997889054;
						while (true)
						{
							switch (num ^ 0x3B7A941D)
							{
							case 4:
								num = 997889052;
								continue;
							default:
								return;
							case 1:
								break;
							case 0:
								goto IL_004b;
							case 2:
								goto IL_005a;
							case 3:
								return;
							}
							break;
						}
						break;
					}
					break;
				}
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0075;
			IL_0008:
			int num = -895049454;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -895049456)
				{
				case 3:
					break;
				case 2:
					return;
				case 6:
					return;
				case 0:
					if (yOoaERsLfwRYibdXndHsenfOaVXe != null)
					{
						goto IL_0054;
					}
					goto default;
				case 4:
					return;
				case 1:
					goto IL_0075;
				default:
					AQKFYYuUyzWMUiyIguWHpBOybED(eventData, vwOsOGNXaoaruwxhzgqJCegchQrA.UMtjEaOogDDwQiplOLpTuwxTdbQ);
					return;
				}
				break;
				IL_0054:
				int num2;
				if (_useTouchRegionOnly)
				{
					num = -895049450;
					num2 = num;
				}
				else
				{
					num = -895049451;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0075:
			int num3;
			if (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				num = -895049456;
				num3 = num;
			}
			else
			{
				num = -895049452;
				num3 = num;
			}
			goto IL_000d;
		}

		private void WIePpjCcsUBMIhAWGtGpDSlJlip(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				while (true)
				{
					IL_004c:
					RTFkZgwwfqcoraXUeOtRrGPTipR(P_0, vwOsOGNXaoaruwxhzgqJCegchQrA.qBvlHFfTVaijZsMuBaXfTPCbahL);
					int num = -1662988507;
					while (true)
					{
						switch (num ^ -1662988505)
						{
						case 0:
							num = -1662988506;
							continue;
						default:
							return;
						case 1:
							break;
						case 3:
							goto IL_004c;
						case 2:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void pEabpejZnFXyFYVtSEnxCGboYRd(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0045;
			IL_0008:
			int num = 326072891;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x136F7A3A)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0036;
			case 0:
				goto IL_0045;
			case 4:
				return;
			}
			goto IL_0008;
			IL_0045:
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			goto IL_0036;
			IL_0036:
			oyVgIoryHcoeYsQAABSabldnFuw(P_0, vwOsOGNXaoaruwxhzgqJCegchQrA.qBvlHFfTVaijZsMuBaXfTPCbahL);
			num = 326072894;
			goto IL_000d;
		}

		private void dcgoqSOZQngElokwIQkKjPdIlML(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = 2126187626;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x7EBB0C68)
			{
			case 0:
				break;
			case 2:
				return;
			case 4:
				goto IL_0036;
			case 3:
				return;
			default:
				kniQNhRGNrdKgAIpgLeavFJtBJvU(P_0, vwOsOGNXaoaruwxhzgqJCegchQrA.qBvlHFfTVaijZsMuBaXfTPCbahL);
				return;
			}
			goto IL_0008;
			IL_0036:
			int num2;
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				num = 2126187627;
				num2 = num;
			}
			else
			{
				num = 2126187625;
				num2 = num;
			}
			goto IL_000d;
		}

		private void mErQunVxoylvoyoLVaOLThnRYfr(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x350709DD ^ 0x350709DF)
					{
					case 0:
						break;
					case 2:
						return;
					case 1:
						goto end_IL_0008;
					default:
						goto IL_0053;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			goto IL_0053;
			IL_0053:
			AQKFYYuUyzWMUiyIguWHpBOybED(P_0, vwOsOGNXaoaruwxhzgqJCegchQrA.qBvlHFfTVaijZsMuBaXfTPCbahL);
		}

		private void HWFhkFlLkYUKyhTUFbGsyGCYFc(float P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_005c;
			IL_0008:
			int num = -1948966300;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1948966297)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					return;
				case 2:
					return;
				case 0:
					tPzLrmyiYkESrTkUqlRUVdqEdkXD(null);
					_onAxisValueChanged.Invoke(P_0);
					num = -1948966301;
					continue;
				case 1:
					goto IL_005c;
				case 4:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_005c:
			int num2;
			if (_useDigitalAxisSimulation)
			{
				num = -1948966299;
				num2 = num;
			}
			else
			{
				num = -1948966297;
				num2 = num;
			}
			goto IL_000d;
		}

		private void HQgAhyJhrHYQKAXbJAataYJekULw(bool P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				tPzLrmyiYkESrTkUqlRUVdqEdkXD(null);
				_onButtonValueChanged.Invoke(P_0);
				int num = 1061944826;
				while (true)
				{
					switch (num ^ 0x3F4BFDFB)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 1061944825;
				}
			}
		}

		private void AwISkEnBouIcuKglDYyFpRHuHNVl()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				tPzLrmyiYkESrTkUqlRUVdqEdkXD(null);
				int num = -735014888;
				while (true)
				{
					switch (num ^ -735014888)
					{
					case 3:
						num = -735014887;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						_onButtonDown.Invoke();
						num = -735014886;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void vulYfrBZeVCgrYGRTBzfraHLDodh()
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (-9765546 ^ -9765548)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			tPzLrmyiYkESrTkUqlRUVdqEdkXD(null);
			_onButtonUp.Invoke();
		}
	}
}
