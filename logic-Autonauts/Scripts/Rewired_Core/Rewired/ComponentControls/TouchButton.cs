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
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum UzAgcTofzxoRKPiAALjutXmddFi
		{
			iOlZgcuFwLCPNAjSgaSDuxucio = 0,
			XtRDenkmlflSSFYJThdxkTsQRdUi = 1,
			kDQhddPzDwumddhEyJEvsPyPkgY = 2
		}

		private enum YIGKRFpzmwAuTUviVgNTzUogFuc
		{
			hWboZvyXoJNhfSvesxqLLWrBcgF = 0,
			FbpqMQLqHsIUsSlvpbBzoWAbCsO = 1
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

		private sealed class CpeCdZoMTfAQnksiXZGBvlAiXRj : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			public TouchButton ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public Vector2 JduXYBqbDACUTxxZQjOzqMMbLTj;

			public PositionType BEDVoxNLBeqRJhchWAqhqSPVsYd;

			public float EWKgfOCaWksDFjQilyybAfeIqrUz;

			public UzAgcTofzxoRKPiAALjutXmddFi yLCxvNsJdtnzXSCIkwezQoUNbSO;

			public RectTransform bHuPBTOfgBGNovyluQrAhDfrZjE;

			public Vector2 YxonfqJfnEBQDaOuQHEqEyfDKgCO;

			public float ZIZefvIPOzwMRPtfbqyhCABbWlVO;

			public float kVmMzjUvDxPRcgRVDQwPdJdAscF;

			public float qEYMSztDRZvHyoyjfaOVyWLJNyZ;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = -1034847029;
					while (true)
					{
						switch (num ^ -1034847032)
						{
						case 8:
							break;
						case 9:
							qEYMSztDRZvHyoyjfaOVyWLJNyZ = 0f;
							num = -1034847025;
							continue;
						case 5:
							eNAeLDLTbmAsdtyVgrjCdfsiFPci.rRhYUvPnCuVwprINEAdgWHfmPUy(bHuPBTOfgBGNovyluQrAhDfrZjE, Vector2.Lerp(YxonfqJfnEBQDaOuQHEqEyfDKgCO, JduXYBqbDACUTxxZQjOzqMMbLTj, Mathf.SmoothStep(0f, 1f, qEYMSztDRZvHyoyjfaOVyWLJNyZ)), BEDVoxNLBeqRJhchWAqhqSPVsYd);
							RDkWcsTpvDaNZojjIZONnoEBXPC = null;
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 4:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							if (!(EWKgfOCaWksDFjQilyybAfeIqrUz <= 0f))
							{
								bHuPBTOfgBGNovyluQrAhDfrZjE = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.rectTransform;
								num = -1034847030;
								continue;
							}
							goto case 0;
						case 0:
							ZzSaCQHlhEgTijsOQGwUlyKTOzqG.FdMktGOiqKeApBkgCYuESOjTorm(yLCxvNsJdtnzXSCIkwezQoUNbSO, JduXYBqbDACUTxxZQjOzqMMbLTj, BEDVoxNLBeqRJhchWAqhqSPVsYd);
							num = -1034847026;
							continue;
						case 3:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								num = -1034847025;
								continue;
							case 0:
								break;
							default:
								num = -1034847026;
								continue;
							}
							goto case 4;
						case 2:
							YxonfqJfnEBQDaOuQHEqEyfDKgCO = eNAeLDLTbmAsdtyVgrjCdfsiFPci.sDAkhoYrEZafWItRCkMCXhQGsTL(bHuPBTOfgBGNovyluQrAhDfrZjE, BEDVoxNLBeqRJhchWAqhqSPVsYd);
							ZIZefvIPOzwMRPtfbqyhCABbWlVO = (JduXYBqbDACUTxxZQjOzqMMbLTj - YxonfqJfnEBQDaOuQHEqEyfDKgCO).magnitude;
							if (!(ZIZefvIPOzwMRPtfbqyhCABbWlVO < 0.01f))
							{
								ZzSaCQHlhEgTijsOQGwUlyKTOzqG.vpweTjXijucmZdtKklsRTcenjEH = true;
								kVmMzjUvDxPRcgRVDQwPdJdAscF = ZIZefvIPOzwMRPtfbqyhCABbWlVO / EWKgfOCaWksDFjQilyybAfeIqrUz;
								num = -1034847039;
								continue;
							}
							goto case 0;
						case 1:
							qEYMSztDRZvHyoyjfaOVyWLJNyZ += Time.unscaledDeltaTime / kVmMzjUvDxPRcgRVDQwPdJdAscF;
							num = -1034847027;
							continue;
						case 7:
						{
							int num2;
							if (!(qEYMSztDRZvHyoyjfaOVyWLJNyZ > 1f))
							{
								num = -1034847031;
								num2 = num;
							}
							else
							{
								num = -1034847032;
								num2 = num;
							}
							continue;
						}
						default:
							return false;
						}
						break;
					}
				}
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
			public CpeCdZoMTfAQnksiXZGBvlAiXRj(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
			}
		}

		private const float EUehDNBkDBdxFBlxeeYwqgGNbuJ = 20f;

		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ButtonType _buttonType;

		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		private bool _useDigitalAxisSimulation;

		[SerializeField]
		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		private float _digitalAxisGravity = 3f;

		[FieldRange(0f, float.PositiveInfinity)]
		[SerializeField]
		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisSensitivity = 3f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		private StandaloneAxis _axis = new StandaloneAxis();

		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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
		[CustomObfuscation(rename = false)]
		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		private bool _returnOnRelease = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		[SerializeField]
		private bool _followTouchPosition;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		private bool _animateOnMoveToTouch = true;

		[SerializeField]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[Range(0f, 20f)]
		[CustomObfuscation(rename = false)]
		private float _moveToTouchSpeed = 2f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		private bool _animateOnReturn = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[SerializeField]
		[Range(0f, 20f)]
		private float _returnSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[SerializeField]
		private bool _manageRaycasting = true;

		private float EsYTvNbhgFlRCNlpGUxkbReDMgu;

		private float BXwUGZMNiqjbtEMrRwRlLCSRSlf;

		private TouchRegion TMyXBUOIpefyPDfOBNRqSCzUeMA;

		private Vector2 tGCxWFSdRTXxERrTeqkdKesNluT;

		private bool vpweTjXijucmZdtKklsRTcenjEH;

		private bool yEGfcMioCprmZdfdCprLEAuqWmsm;

		private UzAgcTofzxoRKPiAALjutXmddFi eiKHWlzYRPAsXkKiDirnDiRgYXm;

		private int qzygTAANCsGThMrzndPvSXbKaDF = int.MinValue;

		private int LzoOqyUXBgfuwfLHBBzDqMYqLhC = int.MinValue;

		[NonSerialized]
		private bool QlnYBBpzNpDLYXfPrVIqnYFRDKL;

		[NonSerialized]
		private bool tmlENZkWxfXAUYowkKtYqEQUwuh;

		private IEnumerator PwWreepIkGPNJYlcbCGJIZeBtthR;

		private cHqRtqSnvZYMLmoNYIQaJzSHZpkb ZDOYJqIXVTLJWAuBAhJUdYjWOCe = new cHqRtqSnvZYMLmoNYIQaJzSHZpkb();

		private Action<UzAgcTofzxoRKPiAALjutXmddFi> rGyoOWVzekJLVpNlgzCwvYvxBXz;

		private Action<UzAgcTofzxoRKPiAALjutXmddFi> QGnWkLIbwtNXmRZLOpGTXLKWjvA;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the axis value changes.")]
		[SerializeField]
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
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> OmdClIeGlFSmCdhqZRQsbuQzaza;

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
					return;
				}
				while (true)
				{
					_buttonType = value;
					int num = -1421621337;
					while (true)
					{
						switch (num ^ -1421621339)
						{
						case 3:
							num = -1421621340;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							OnSetProperty();
							num = -1421621339;
							continue;
						case 0:
							return;
						}
						break;
					}
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
				if (_activateOnSwipeIn == value)
				{
					return;
				}
				while (true)
				{
					_activateOnSwipeIn = value;
					int num = 1829231320;
					while (true)
					{
						switch (num ^ 0x6D07DAD9)
						{
						case 0:
							goto IL_000a;
						case 2:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = 1829231323;
					}
				}
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (LLTAgqLqZdxqORftayLlSimyXII())
				{
					return true;
				}
				return _stayActiveOnSwipeOut;
			}
			set
			{
				if (_stayActiveOnSwipeOut == value)
				{
					while (true)
					{
						switch (0x51412A07 ^ 0x51412A06)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_stayActiveOnSwipeOut = value;
				OnSetProperty();
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
					OnSetProperty();
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
					OnSetProperty();
					int num = 110135534;
					while (true)
					{
						switch (num ^ 0x69088EC)
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
						num = 110135533;
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
						switch (-1236317079 ^ -1236317080)
						{
						case 0:
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
					int num = 897286173;
					while (true)
					{
						switch (num ^ 0x357B801F)
						{
						case 0:
							goto IL_000f;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000f:
						num = 897286174;
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
					int num = 1727135927;
					while (true)
					{
						switch (num ^ 0x66F200B5)
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
						num = 1727135924;
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
				if (_moveToTouchPosition == value)
				{
					while (true)
					{
						switch (-1405661947 ^ -1405661948)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_moveToTouchPosition = value;
				OnSetProperty();
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
				if (_returnOnRelease == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -1991936246;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1991936248)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					goto IL_0033;
				case 1:
					return;
				}
				goto IL_0009;
				IL_0033:
				_returnOnRelease = value;
				OnSetProperty();
				num = -1991936247;
				goto IL_000e;
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
					while (true)
					{
						switch (0x44AA0417 ^ 0x44AA0416)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_followTouchPosition = value;
				OnSetProperty();
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
				if (_animateOnMoveToTouch == value)
				{
					return;
				}
				while (true)
				{
					_animateOnMoveToTouch = value;
					int num = -1798203575;
					while (true)
					{
						switch (num ^ -1798203573)
						{
						case 0:
							num = -1798203574;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							OnSetProperty();
							num = -1798203576;
							continue;
						case 3:
							return;
						}
						break;
					}
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
					OnSetProperty();
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
				if (_animateOnReturn == value)
				{
					goto IL_0009;
				}
				goto IL_0037;
				IL_0009:
				int num = -1810000351;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1810000350)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						return;
					case 0:
						goto IL_0037;
					case 1:
						OnSetProperty();
						num = -1810000346;
						continue;
					case 4:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0037:
				_animateOnReturn = value;
				num = -1810000349;
				goto IL_000e;
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
					OnSetProperty();
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
				if (_manageRaycasting == value)
				{
					return;
				}
				while (true)
				{
					_manageRaycasting = value;
					int num;
					if (value)
					{
						iWWhqovcLkzXONoZDjLpTHNUCDo();
						num = -547314683;
						goto IL_000f;
					}
					goto IL_004e;
					IL_000f:
					while (true)
					{
						switch (num ^ -547314681)
						{
						case 4:
							num = -547314682;
							continue;
						case 1:
							break;
						case 2:
							num = -547314681;
							continue;
						case 3:
							goto IL_004e;
						default:
							OnSetProperty();
							return;
						}
						break;
					}
					continue;
					IL_004e:
					ZDOYJqIXVTLJWAuBAhJUdYjWOCe.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
					num = -547314681;
					goto IL_000f;
				}
			}
		}

		public int pointerId
		{
			get
			{
				return qzygTAANCsGThMrzndPvSXbKaDF;
			}
			set
			{
				qzygTAANCsGThMrzndPvSXbKaDF = value;
			}
		}

		public bool hasPointer
		{
			get
			{
				return qzygTAANCsGThMrzndPvSXbKaDF != int.MinValue;
			}
		}

		internal StandaloneAxis axis
		{
			get
			{
				return _axis;
			}
		}

		private Action<UzAgcTofzxoRKPiAALjutXmddFi> moveStartedDelegate
		{
			get
			{
				if (rGyoOWVzekJLVpNlgzCwvYvxBXz == null)
				{
					return rGyoOWVzekJLVpNlgzCwvYvxBXz = VIyzHkWsNtqxypeBrFgRAHUVADKV;
				}
				return rGyoOWVzekJLVpNlgzCwvYvxBXz;
			}
		}

		private Action<UzAgcTofzxoRKPiAALjutXmddFi> moveEndedDelegate
		{
			get
			{
				if (QGnWkLIbwtNXmRZLOpGTXLKWjvA == null)
				{
					return QGnWkLIbwtNXmRZLOpGTXLKWjvA = AFZfKuwjkqTUacvfdthqlbegOzJ;
				}
				return QGnWkLIbwtNXmRZLOpGTXLKWjvA;
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
				return EsYTvNbhgFlRCNlpGUxkbReDMgu;
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
				return BXwUGZMNiqjbtEMrRwRlLCSRSlf;
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
				if (qzygTAANCsGThMrzndPvSXbKaDF == int.MinValue)
				{
					return int.MinValue;
				}
				if (LzoOqyUXBgfuwfLHBBzDqMYqLhC != int.MinValue)
				{
					return LzoOqyUXBgfuwfLHBBzDqMYqLhC;
				}
				return qzygTAANCsGThMrzndPvSXbKaDF;
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
			UgKvFMVXcKNGPxTOwsIwvbOJKWy(base.rectTransform.anchoredPosition);
		}

		private void UgKvFMVXcKNGPxTOwsIwvbOJKWy(Vector2 P_0)
		{
			if (base.initialized)
			{
				tGCxWFSdRTXxERrTeqkdKesNluT = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.initialized)
			{
				hQeCbaPdhGazQaWjtkPsBzddKed(tGCxWFSdRTXxERrTeqkdKesNluT, PositionType.huHVQQAcuxcYyCLZjEIJOChEJYa, !instant && _animateOnReturn, _returnSpeed, UzAgcTofzxoRKPiAALjutXmddFi.kDQhddPzDwumddhEyJEvsPyPkgY);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				ReturnToDefaultPosition(false);
				int num = -306141349;
				while (true)
				{
					switch (num ^ -306141349)
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
					num = -306141350;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			while (true)
			{
				switch (0x5DDAC691 ^ 0x5DDAC690)
				{
				case 0:
					continue;
				case 1:
					if (!Application.isPlaying)
					{
						return;
					}
					break;
				}
				break;
			}
			tGCxWFSdRTXxERrTeqkdKesNluT = base.rectTransform.anchoredPosition;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!base.initialized)
			{
				while (true)
				{
					switch (-349577002 ^ -349577001)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			while (true)
			{
				switch (-1298665874 ^ -1298665876)
				{
				case 0:
					continue;
				case 2:
					if (!base.initialized)
					{
						return;
					}
					break;
				}
				break;
			}
			OnClear();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (!base.initialized)
			{
				while (true)
				{
					switch (-998750037 ^ -998750038)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
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
				return;
			}
			while (true)
			{
				xvhEjvVFsFrafXEEWHZdWOefBUF();
				int num = 2129562808;
				while (true)
				{
					switch (num ^ 0x7EEE8CBA)
					{
					case 0:
						num = 2129562811;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						IBequgtYajRRqjVlZlDTJkMfzbY();
						wWRbfeyYhzfRZYSjYkPzqrylmeG();
						num = 2129562814;
						continue;
					case 4:
						if (_followTouchPosition)
						{
							KKKzzptlCzpxEXyQiJDGcaVVucZ(effectivePointerId);
							num = 2129562809;
							continue;
						}
						return;
					case 3:
						return;
					}
					break;
				}
			}
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
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!hasController)
				{
					num = -1037684609;
					num2 = num;
				}
				else
				{
					num = -1037684612;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1037684612)
					{
					case 2:
						goto IL_0009;
					case 1:
						break;
					case 3:
						return;
					default:
						KyhNArefdFIxsvhHWTOXrRXnSZY(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
						return;
					}
					break;
					IL_0009:
					num = -1037684611;
				}
			}
		}

		internal override void OnSubscribeEvents()
		{
			base.OnSubscribeEvents();
			while (true)
			{
				int num = -765982127;
				while (true)
				{
					switch (num ^ -765982125)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						_axis.ButtonDownEvent += bJKClJiPquDFFWIspweNEeFaeUAG;
						_axis.ButtonUpEvent += KgzRGahoqRbPKqcAjAddGKFLgvea;
						return;
					}
					break;
					IL_0024:
					_axis.AxisValueChangedEvent += ikGcuzFLbQzirRQpqnEOPYpKOAv;
					_axis.ButtonValueChangedEvent += sryVkxTqbPBffatwxQivcnTaaJWS;
					num = -765982126;
				}
			}
		}

		internal override void OnUnsubscribeEvents()
		{
			base.OnUnsubscribeEvents();
			_axis.AxisValueChangedEvent -= ikGcuzFLbQzirRQpqnEOPYpKOAv;
			_axis.ButtonValueChangedEvent -= sryVkxTqbPBffatwxQivcnTaaJWS;
			_axis.ButtonDownEvent -= bJKClJiPquDFFWIspweNEeFaeUAG;
			_axis.ButtonUpEvent -= KgzRGahoqRbPKqcAjAddGKFLgvea;
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			while (true)
			{
				int num = 1622884502;
				while (true)
				{
					switch (num ^ 0x60BB4097)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (base.initialized)
						{
							goto IL_0038;
						}
						return;
					case 3:
						goto IL_0038;
					case 2:
						return;
					}
					break;
					IL_0038:
					cIMxKKikLZEqzDDbOdedgdvAfBZi();
					num = 1622884501;
				}
			}
		}

		internal override void OnClear()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0078;
			IL_0008:
			int num = 928340212;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x375558F2)
				{
				case 5:
					break;
				case 3:
					QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
					tmlENZkWxfXAUYowkKtYqEQUwuh = false;
					if (!_returnOnRelease || !yEGfcMioCprmZdfdCprLEAuqWmsm)
					{
						goto case 4;
					}
					if (!_moveToTouchPosition)
					{
						goto IL_005f;
					}
					goto case 0;
				case 1:
					goto IL_0078;
				case 4:
					yEGfcMioCprmZdfdCprLEAuqWmsm = false;
					vpweTjXijucmZdtKklsRTcenjEH = false;
					eiKHWlzYRPAsXkKiDirnDiRgYXm = UzAgcTofzxoRKPiAALjutXmddFi.iOlZgcuFwLCPNAjSgaSDuxucio;
					num = 928340208;
					continue;
				case 0:
					ReturnToDefaultPosition(true);
					num = 928340214;
					continue;
				case 6:
					return;
				default:
					fgggXZrtEesUbQzeFuxUPcrQeRfJ();
					_axis.Clear();
					EsYTvNbhgFlRCNlpGUxkbReDMgu = 0f;
					BXwUGZMNiqjbtEMrRwRlLCSRSlf = 0f;
					cIMxKKikLZEqzDDbOdedgdvAfBZi();
					return;
				}
				break;
				IL_005f:
				int num2;
				if (!_followTouchPosition)
				{
					num = 928340214;
					num2 = num;
				}
				else
				{
					num = 928340210;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0078:
			qzygTAANCsGThMrzndPvSXbKaDF = int.MinValue;
			LzoOqyUXBgfuwfLHBBzDqMYqLhC = int.MinValue;
			num = 928340209;
			goto IL_000d;
		}

		public override void ClearValue()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -22600435;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -22600434)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					return;
				case 4:
					goto IL_0036;
				case 1:
					base.controller.ClearElementValue(_targetCustomControllerElement);
					num = -22600436;
					continue;
				case 2:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0036:
			_axis.Clear();
			EsYTvNbhgFlRCNlpGUxkbReDMgu = 0f;
			int num2;
			if (hasController)
			{
				num = -22600433;
				num2 = num;
			}
			else
			{
				num = -22600436;
				num2 = num;
			}
			goto IL_000d;
		}

		internal override bool IsPressed()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				goto IL_0012;
			}
			int num;
			if (!_axis.buttonValue)
			{
				num = 831812523;
				goto IL_0017;
			}
			return true;
			IL_0017:
			switch (num ^ 0x319473AB)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return _axis.value != 0f;
			}
			goto IL_0012;
			IL_0012:
			num = 831812522;
			goto IL_0017;
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
			if (TMyXBUOIpefyPDfOBNRqSCzUeMA != null)
			{
				return TMyXBUOIpefyPDfOBNRqSCzUeMA.gameObject == gameObject;
			}
			return false;
		}

		private void wWRbfeyYhzfRZYSjYkPzqrylmeG()
		{
			if (!_useDigitalAxisSimulation)
			{
				return;
			}
			while (true)
			{
				bool flag = _axis.buttonValue;
				int num = -1695634999;
				while (true)
				{
					switch (num ^ -1695635000)
					{
					case 5:
						num = -1695634996;
						continue;
					case 2:
						return;
					case 1:
					{
						int num2;
						if (flag)
						{
							num = -1695635000;
							num2 = num;
						}
						else
						{
							num = -1695634997;
							num2 = num;
						}
						continue;
					}
					case 4:
						break;
					case 0:
						EXCXaiEkIiiSGohLIBHzIVFwYsI();
						num = -1695634998;
						continue;
					default:
						gBYCEnneqgeXtWUBnPwCeVNrKIg();
						return;
					}
					break;
				}
			}
		}

		private void EXCXaiEkIiiSGohLIBHzIVFwYsI()
		{
			float num = ((_axis.value >= 0f) ? 1f : (-1f));
			while (true)
			{
				int num2 = 456455667;
				while (true)
				{
					switch (num2 ^ 0x1B34F5F2)
					{
					case 0:
						break;
					case 1:
						goto IL_003d;
					default:
						num += EsYTvNbhgFlRCNlpGUxkbReDMgu;
						num = MathTools.Clamp(num, -1f, 1f);
						MOshlXwjUVJkFvUVhMxxXNwLLbM(num, true);
						return;
					}
					break;
					IL_003d:
					float num3 = MathTools.Abs(_digitalAxisSensitivity);
					num *= num3 * Time.unscaledDeltaTime;
					num2 = 456455664;
				}
			}
		}

		private void gBYCEnneqgeXtWUBnPwCeVNrKIg()
		{
			float num = _digitalAxisGravity;
			float num4 = default(float);
			float esYTvNbhgFlRCNlpGUxkbReDMgu = default(float);
			float num5 = default(float);
			float num6 = default(float);
			while (true)
			{
				int num2 = -1206698127;
				while (true)
				{
					switch (num2 ^ -1206698123)
					{
					case 9:
						break;
					default:
						return;
					case 3:
						num4 = num * Time.unscaledDeltaTime;
						if (MathTools.Abs(num4) >= MathTools.Abs(esYTvNbhgFlRCNlpGUxkbReDMgu))
						{
							num5 = 0f;
							num2 = -1206698123;
							continue;
						}
						goto case 2;
					case 6:
						esYTvNbhgFlRCNlpGUxkbReDMgu = EsYTvNbhgFlRCNlpGUxkbReDMgu;
						num2 = -1206698126;
						continue;
					case 0:
						MOshlXwjUVJkFvUVhMxxXNwLLbM(num5, true);
						num2 = -1206698128;
						continue;
					case 2:
						num6 = ((esYTvNbhgFlRCNlpGUxkbReDMgu > 0f) ? (-1f) : 1f);
						num2 = -1206698115;
						continue;
					case 4:
						if (num == 0f)
						{
							return;
						}
						goto case 6;
					case 8:
						num5 = esYTvNbhgFlRCNlpGUxkbReDMgu + num6 * num4;
						num2 = -1206698123;
						continue;
					case 1:
						return;
					case 7:
					{
						int num3;
						if (esYTvNbhgFlRCNlpGUxkbReDMgu == 0f)
						{
							num2 = -1206698124;
							num3 = num2;
						}
						else
						{
							num2 = -1206698122;
							num3 = num2;
						}
						continue;
					}
					case 5:
						return;
					}
					break;
				}
			}
		}

		private void MOshlXwjUVJkFvUVhMxxXNwLLbM(float P_0, bool P_1)
		{
			BXwUGZMNiqjbtEMrRwRlLCSRSlf = EsYTvNbhgFlRCNlpGUxkbReDMgu;
			EsYTvNbhgFlRCNlpGUxkbReDMgu = P_0;
			if (P_0 != BXwUGZMNiqjbtEMrRwRlLCSRSlf)
			{
				EQnWUlQqOynmEtPVWLCOkLeIdyA(null);
				goto IL_0023;
			}
			goto IL_0049;
			IL_0049:
			int num;
			int num2;
			if (!P_1)
			{
				num = -85889046;
				num2 = num;
			}
			else
			{
				num = -85889045;
				num2 = num;
			}
			goto IL_0028;
			IL_0023:
			num = -85889048;
			goto IL_0028;
			IL_0028:
			while (true)
			{
				switch (num ^ -85889046)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					goto IL_0049;
				case 3:
					_onAxisValueChanged.Invoke(P_0);
					num = -85889046;
					continue;
				case 1:
					goto IL_0070;
				case 0:
					return;
				}
				break;
				IL_0070:
				int num3;
				if (P_0 == BXwUGZMNiqjbtEMrRwRlLCSRSlf)
				{
					num = -85889046;
					num3 = num;
				}
				else
				{
					num = -85889047;
					num3 = num;
				}
			}
			goto IL_0023;
		}

		private void lCFIBZLMNKvXmTGMtfkRZXzmGto()
		{
			if (_buttonType != ButtonType.ToggleSwitch)
			{
				goto IL_003b;
			}
			if (buttonValue)
			{
				goto IL_0011;
			}
			goto IL_0060;
			IL_003b:
			int num;
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawMax);
				num = -1050688495;
				goto IL_0016;
			}
			return;
			IL_0011:
			num = -1050688496;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num ^ -1050688495)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					goto IL_003b;
				case 3:
					goto IL_0060;
				case 5:
					return;
				case 1:
					_axis.SetRawValue(_axis.rawZero);
					num = -1050688492;
					continue;
				case 0:
					return;
				}
				break;
			}
			goto IL_0011;
			IL_0060:
			_axis.SetRawValue(_axis.rawMax);
		}

		private void nSUtEBAkcafXvvbwQuYCqBXHwpf()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void cIMxKKikLZEqzDDbOdedgdvAfBZi()
		{
			_targetCustomControllerElement.ClearElementCaches();
			IBequgtYajRRqjVlZlDTJkMfzbY();
			iWWhqovcLkzXONoZDjLpTHNUCDo();
		}

		private void iWWhqovcLkzXONoZDjLpTHNUCDo()
		{
			if (_manageRaycasting)
			{
				ZDOYJqIXVTLJWAuBAhJUdYjWOCe.mkbZMChGYDoTKCWjjeEtIdAOcVVA(base.transform, SVAETGmUIJXUZncESXWxVhCkFKc());
			}
		}

		private bool SVAETGmUIJXUZncESXWxVhCkFKc()
		{
			if (TMyXBUOIpefyPDfOBNRqSCzUeMA != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void fxGzCSkWWmtevdNVRZAQTujeJAk(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				goto IL_0009;
			}
			goto IL_0037;
			IL_0009:
			int num = -1434747100;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ -1434747099)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0037;
				case 4:
					P_0.PointerDownEvent += lzqUemmLiWpBjHlLmGrpmuhFrlo;
					P_0.PointerUpEvent += UEcgqxIblHuJqokaoodfjjxksQmz;
					P_0.PointerEnterEvent += UkqepPwTKhKlSSYpykoMGilKlBO;
					P_0.PointerExitEvent += FdfJZopCusKoJSmKfyVDmEfTHFm;
					num = -1434747099;
					continue;
				case 0:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0037:
			dEJqrswYMslXTjicYopqMczugAC(P_0);
			num = -1434747103;
			goto IL_000e;
		}

		private void dEJqrswYMslXTjicYopqMczugAC(TouchRegion P_0)
		{
			if (!(P_0 == null))
			{
				P_0.PointerDownEvent -= lzqUemmLiWpBjHlLmGrpmuhFrlo;
				P_0.PointerUpEvent -= UEcgqxIblHuJqokaoodfjjxksQmz;
				P_0.PointerEnterEvent -= UkqepPwTKhKlSSYpykoMGilKlBO;
				P_0.PointerExitEvent -= FdfJZopCusKoJSmKfyVDmEfTHFm;
			}
		}

		private void IBequgtYajRRqjVlZlDTJkMfzbY()
		{
			if (!(TMyXBUOIpefyPDfOBNRqSCzUeMA == _touchRegion))
			{
				dEJqrswYMslXTjicYopqMczugAC(TMyXBUOIpefyPDfOBNRqSCzUeMA);
				TMyXBUOIpefyPDfOBNRqSCzUeMA = _touchRegion;
				fxGzCSkWWmtevdNVRZAQTujeJAk(TMyXBUOIpefyPDfOBNRqSCzUeMA);
			}
		}

		private void vUqurQgbViEJEHwXocSHTJSMPuDp(Vector2 P_0, bool P_1, float P_2, UzAgcTofzxoRKPiAALjutXmddFi P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			Vector2 vector = default(Vector2);
			Vector2 pivot = default(Vector2);
			Vector2 sizeDelta = default(Vector2);
			while (true)
			{
				int num = -829608852;
				while (true)
				{
					switch (num ^ -829608849)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						vector = eNAeLDLTbmAsdtyVgrjCdfsiFPci.DseKlDkkNmcmsDeTaDjKFrBMTXcs(base.canvas, rectTransform, P_0);
						num = -829608849;
						continue;
					case 1:
					{
						Vector3 localScale = base.rectTransform.localScale;
						vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
						hQeCbaPdhGazQaWjtkPsBzddKed(vector, PositionType.hWboZvyXoJNhfSvesxqLLWrBcgF, P_1, P_2, P_3);
						num = -829608853;
						continue;
					}
					case 0:
						pivot = base.rectTransform.pivot;
						sizeDelta = base.rectTransform.sizeDelta;
						num = -829608850;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void hQeCbaPdhGazQaWjtkPsBzddKed(Vector2 P_0, PositionType P_1, bool P_2, float P_3, UzAgcTofzxoRKPiAALjutXmddFi P_4)
		{
			if (vpweTjXijucmZdtKklsRTcenjEH && P_2)
			{
				goto IL_0011;
			}
			goto IL_0213;
			IL_0213:
			int num;
			if (vpweTjXijucmZdtKklsRTcenjEH && PwWreepIkGPNJYlcbCGJIZeBtthR != null)
			{
				fgggXZrtEesUbQzeFuxUPcrQeRfJ();
				vpweTjXijucmZdtKklsRTcenjEH = false;
				eiKHWlzYRPAsXkKiDirnDiRgYXm = UzAgcTofzxoRKPiAALjutXmddFi.iOlZgcuFwLCPNAjSgaSDuxucio;
				num = 1934747505;
				goto IL_0016;
			}
			goto IL_0072;
			IL_0011:
			num = 1934747512;
			goto IL_0016;
			IL_0016:
			Vector2 one = default(Vector2);
			Transform parent = default(Transform);
			RectTransform rectTransform = default(RectTransform);
			Vector2 sizeDelta = default(Vector2);
			bool flag = default(bool);
			float num3 = default(float);
			float num2 = default(float);
			while (true)
			{
				switch (num ^ 0x7351E77B)
				{
				case 4:
					break;
				case 10:
					goto IL_0072;
				case 12:
					goto IL_009a;
				case 5:
					P_2 = false;
					num = 1934747517;
					continue;
				case 3:
					goto IL_00cb;
				case 2:
					goto IL_00e9;
				case 0:
					return;
				case 11:
					one.y *= parent.localScale.y;
					num = 1934747511;
					continue;
				case 13:
					StartCoroutine(PwWreepIkGPNJYlcbCGJIZeBtthR);
					eiKHWlzYRPAsXkKiDirnDiRgYXm = P_4;
					yEGfcMioCprmZdfdCprLEAuqWmsm = true;
					moveStartedDelegate(P_4);
					return;
				case 17:
					rectTransform = base.canvasTransform;
					one = Vector2.one;
					num = 1934747511;
					continue;
				case 1:
					sizeDelta = rectTransform.sizeDelta;
					flag = sizeDelta.x < sizeDelta.y;
					num = 1934747497;
					continue;
				case 8:
					P_3 = P_3 / num3 * num2;
					PwWreepIkGPNJYlcbCGJIZeBtthR = tjPcPkDazEzSfOwRBVeZGdakazv(P_0, P_1, P_3, P_4);
					num = 1934747510;
					continue;
				case 9:
					if (!(parent == null))
					{
						one.x *= parent.localScale.x;
						num = 1934747504;
						continue;
					}
					goto case 1;
				case 7:
					goto IL_01ee;
				case 14:
					goto IL_0213;
				case 16:
					num = 1934747517;
					continue;
				case 18:
					num2 = MathTools.Max(sizeDelta.x, sizeDelta.y);
					num3 = (flag ? one.y : one.x);
					if (num3 == 0f)
					{
						num3 = 0.0001f;
						num = 1934747507;
						continue;
					}
					goto case 8;
				case 6:
					goto IL_0299;
				default:
					FdMktGOiqKeApBkgCYuESOjTorm(P_4, P_0, P_1);
					return;
				}
				break;
				IL_00cb:
				int num4;
				if (eiKHWlzYRPAsXkKiDirnDiRgYXm == P_4)
				{
					num = 1934747515;
					num4 = num;
				}
				else
				{
					num = 1934747509;
					num4 = num;
				}
				continue;
				IL_009a:
				int num5;
				if ((parent = parent.parent) != rectTransform)
				{
					num = 1934747506;
					num5 = num;
				}
				else
				{
					num = 1934747514;
					num5 = num;
				}
			}
			goto IL_0011;
			IL_01ee:
			if (base.canvas.renderMode == RenderMode.WorldSpace)
			{
				Logger.LogWarning("Animation can only be used with a screen space Canvas.");
				num = 1934747518;
				goto IL_0016;
			}
			goto IL_0299;
			IL_00e9:
			moveStartedDelegate(P_4);
			num = 1934747508;
			goto IL_0016;
			IL_0072:
			if (base.canvas == null)
			{
				Logger.LogWarning("Animation cannot be used without a Canvas.");
				P_2 = false;
				num = 1934747499;
				goto IL_0016;
			}
			goto IL_01ee;
			IL_0299:
			if (P_2)
			{
				parent = base.transform;
				num = 1934747498;
				goto IL_0016;
			}
			goto IL_00e9;
		}

		private IEnumerator tjPcPkDazEzSfOwRBVeZGdakazv(Vector2 P_0, PositionType P_1, float P_2, UzAgcTofzxoRKPiAALjutXmddFi P_3)
		{
			CpeCdZoMTfAQnksiXZGBvlAiXRj cpeCdZoMTfAQnksiXZGBvlAiXRj = new CpeCdZoMTfAQnksiXZGBvlAiXRj(0);
			cpeCdZoMTfAQnksiXZGBvlAiXRj.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			cpeCdZoMTfAQnksiXZGBvlAiXRj.JduXYBqbDACUTxxZQjOzqMMbLTj = P_0;
			cpeCdZoMTfAQnksiXZGBvlAiXRj.BEDVoxNLBeqRJhchWAqhqSPVsYd = P_1;
			cpeCdZoMTfAQnksiXZGBvlAiXRj.EWKgfOCaWksDFjQilyybAfeIqrUz = P_2;
			cpeCdZoMTfAQnksiXZGBvlAiXRj.yLCxvNsJdtnzXSCIkwezQoUNbSO = P_3;
			return cpeCdZoMTfAQnksiXZGBvlAiXRj;
		}

		private void FdMktGOiqKeApBkgCYuESOjTorm(UzAgcTofzxoRKPiAALjutXmddFi P_0, Vector2 P_1, PositionType P_2)
		{
			eNAeLDLTbmAsdtyVgrjCdfsiFPci.rRhYUvPnCuVwprINEAdgWHfmPUy(base.rectTransform, P_1, P_2);
			vpweTjXijucmZdtKklsRTcenjEH = false;
			while (true)
			{
				int num = 117348449;
				while (true)
				{
					switch (num ^ 0x6FE9862)
					{
					case 2:
						break;
					case 3:
						eiKHWlzYRPAsXkKiDirnDiRgYXm = UzAgcTofzxoRKPiAALjutXmddFi.iOlZgcuFwLCPNAjSgaSDuxucio;
						if (P_0 == UzAgcTofzxoRKPiAALjutXmddFi.kDQhddPzDwumddhEyJEvsPyPkgY)
						{
							yEGfcMioCprmZdfdCprLEAuqWmsm = false;
							num = 117348451;
							continue;
						}
						goto case 0;
					case 0:
						if (P_0 == UzAgcTofzxoRKPiAALjutXmddFi.XtRDenkmlflSSFYJThdxkTsQRdUi)
						{
							yEGfcMioCprmZdfdCprLEAuqWmsm = true;
							num = 117348451;
							continue;
						}
						goto default;
					default:
						fgggXZrtEesUbQzeFuxUPcrQeRfJ();
						moveEndedDelegate(P_0);
						return;
					}
					break;
				}
			}
		}

		private void VIyzHkWsNtqxypeBrFgRAHUVADKV(UzAgcTofzxoRKPiAALjutXmddFi P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag = false;
			bool flag2 = default(bool);
			while (true)
			{
				int num = 1872636902;
				while (true)
				{
					switch (num ^ 0x6F9E2BE3)
					{
					case 3:
						break;
					default:
						return;
					case 5:
						flag2 = false;
						if (_followTouchPosition)
						{
							int num4;
							if (!stayActiveOnSwipeOut)
							{
								num = 1872636897;
								num4 = num;
							}
							else
							{
								num = 1872636898;
								num4 = num;
							}
							continue;
						}
						goto case 2;
					case 2:
						if (!_followTouchPosition)
						{
							int num3;
							if (TMyXBUOIpefyPDfOBNRqSCzUeMA != null)
							{
								num = 1872636899;
								num3 = num;
							}
							else
							{
								num = 1872636901;
								num3 = num;
							}
							continue;
						}
						goto case 6;
					case 1:
						if (_returnOnRelease && P_0 == UzAgcTofzxoRKPiAALjutXmddFi.XtRDenkmlflSSFYJThdxkTsQRdUi)
						{
							flag = true;
							flag2 = false;
							num = 1872636901;
							continue;
						}
						goto case 6;
					case 6:
						if (flag)
						{
							ZDOYJqIXVTLJWAuBAhJUdYjWOCe.mkbZMChGYDoTKCWjjeEtIdAOcVVA(base.transform, flag2);
							num = 1872636903;
							continue;
						}
						return;
					case 0:
						if (!_useTouchRegionOnly)
						{
							int num2;
							if (!_moveToTouchPosition)
							{
								num = 1872636901;
								num2 = num;
							}
							else
							{
								num = 1872636898;
								num2 = num;
							}
							continue;
						}
						goto case 6;
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void AFZfKuwjkqTUacvfdthqlbegOzJ(UzAgcTofzxoRKPiAALjutXmddFi P_0)
		{
			bool flag;
			bool flag2;
			if (_manageRaycasting)
			{
				flag = false;
				flag2 = false;
				if (_followTouchPosition)
				{
					goto IL_0017;
				}
				goto IL_0096;
			}
			return;
			IL_00d0:
			int num;
			int num2;
			if (flag)
			{
				num = 1532551086;
				num2 = num;
			}
			else
			{
				num = 1532551081;
				num2 = num;
			}
			goto IL_001c;
			IL_0017:
			num = 1532551084;
			goto IL_001c;
			IL_001c:
			while (true)
			{
				switch (num ^ 0x5B58DFAD)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					goto IL_0048;
				case 5:
					if (_returnOnRelease && P_0 == UzAgcTofzxoRKPiAALjutXmddFi.kDQhddPzDwumddhEyJEvsPyPkgY)
					{
						flag = true;
						flag2 = SVAETGmUIJXUZncESXWxVhCkFKc();
						num = 1532551083;
						continue;
					}
					goto IL_00d0;
				case 3:
					ZDOYJqIXVTLJWAuBAhJUdYjWOCe.mkbZMChGYDoTKCWjjeEtIdAOcVVA(base.transform, flag2);
					num = 1532551081;
					continue;
				case 0:
					goto IL_0096;
				case 6:
					goto IL_00d0;
				case 4:
					return;
				}
				break;
				IL_0048:
				int num3;
				if (stayActiveOnSwipeOut)
				{
					num = 1532551080;
					num3 = num;
				}
				else
				{
					num = 1532551085;
					num3 = num;
				}
			}
			goto IL_0017;
			IL_0096:
			if (!_followTouchPosition && TMyXBUOIpefyPDfOBNRqSCzUeMA != null && !_useTouchRegionOnly)
			{
				int num4;
				if (!_moveToTouchPosition)
				{
					num = 1532551083;
					num4 = num;
				}
				else
				{
					num = 1532551080;
					num4 = num;
				}
				goto IL_001c;
			}
			goto IL_00d0;
		}

		private void KKKzzptlCzpxEXyQiJDGcaVVucZ(int P_0)
		{
			if (!TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(P_0))
			{
				return;
			}
			while (true)
			{
				vUqurQgbViEJEHwXocSHTJSMPuDp(TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(P_0), false, 0f, UzAgcTofzxoRKPiAALjutXmddFi.XtRDenkmlflSSFYJThdxkTsQRdUi);
				int num = -473278276;
				while (true)
				{
					switch (num ^ -473278274)
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
					num = -473278273;
				}
			}
		}

		private void fgggXZrtEesUbQzeFuxUPcrQeRfJ()
		{
			if (PwWreepIkGPNJYlcbCGJIZeBtthR != null)
			{
				try
				{
					StopCoroutine(PwWreepIkGPNJYlcbCGJIZeBtthR);
				}
				catch
				{
				}
				PwWreepIkGPNJYlcbCGJIZeBtthR = null;
			}
		}

		private void xvhEjvVFsFrafXEEWHZdWOefBUF()
		{
			if (!hasPointer)
			{
				return;
			}
			while (!TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
			{
				PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(effectivePointerId);
				int num;
				if (pointerEventData != null && pointerEventData.pointerPress != null)
				{
					VGdcUqdPAuBHPLgxHVatOVpAQUrD(pointerEventData);
					num = -735064311;
					goto IL_000e;
				}
				goto IL_002f;
				IL_000e:
				while (true)
				{
					switch (num ^ -735064307)
					{
					case 0:
						num = -735064308;
						continue;
					default:
						return;
					case 3:
						break;
					case 4:
						return;
					case 1:
						goto IL_0044;
					case 2:
						return;
					}
					break;
				}
				goto IL_002f;
				IL_002f:
				SHIErtNBGDqtOcJrfCqGmlXqnbj();
				num = -735064305;
				goto IL_000e;
				IL_0044:;
			}
		}

		private bool LLTAgqLqZdxqORftayLlSimyXII()
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

		private void nnIbvzAiFmjEPCjsdxFWxHOPYIt()
		{
			qzygTAANCsGThMrzndPvSXbKaDF = int.MinValue;
			LzoOqyUXBgfuwfLHBBzDqMYqLhC = int.MinValue;
		}

		private bool KsFFXDTmNznRFMUIlONNipwkUlQ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (qzygTAANCsGThMrzndPvSXbKaDF == int.MinValue)
			{
				goto IL_0017;
			}
			if (qzygTAANCsGThMrzndPvSXbKaDF == P_0)
			{
				return true;
			}
			int num;
			if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
			{
				num = 1335381942;
				goto IL_001c;
			}
			goto IL_007f;
			IL_001c:
			while (true)
			{
				switch (num ^ 0x4F984FB6)
				{
				case 4:
					break;
				case 2:
					goto IL_003d;
				case 0:
					goto IL_004d;
				case 1:
					return false;
				default:
					return true;
				}
				break;
				IL_004d:
				if (LzoOqyUXBgfuwfLHBBzDqMYqLhC != int.MinValue)
				{
					num = 1335381940;
					continue;
				}
				goto IL_007f;
				IL_003d:
				if (P_0 == LzoOqyUXBgfuwfLHBBzDqMYqLhC)
				{
					num = 1335381941;
					continue;
				}
				goto IL_007f;
			}
			goto IL_0017;
			IL_0017:
			num = 1335381943;
			goto IL_001c;
			IL_007f:
			return false;
		}

		private PointerEventData gxVyVSbhjrdJfymjdngkMthnlfz(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(P_0);
			GameObject gameObject2 = default(GameObject);
			GameObject gameObject = default(GameObject);
			float unscaledTime = default(float);
			float num2 = default(float);
			float num3 = default(float);
			GameObject gameObject3 = default(GameObject);
			float unscaledTime2 = default(float);
			while (true)
			{
				int num = 1217494250;
				while (true)
				{
					switch (num ^ 0x48917CEC)
					{
					case 3:
						break;
					case 17:
						pointerEventData.clickCount = 1;
						num = 1217494241;
						continue;
					case 2:
						if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
						{
							pointerEventData.eligibleForClick = true;
							pointerEventData.delta = Vector2.zero;
							pointerEventData.dragging = false;
							num = 1217494271;
							continue;
						}
						goto default;
					case 0:
						pointerEventData.pointerPress = gameObject2;
						pointerEventData.rawPointerPress = gameObject;
						pointerEventData.clickTime = unscaledTime;
						pointerEventData.pointerDrag = gameObject;
						goto IL_02f8;
					case 9:
						if (num2 < 0.3f)
						{
							pointerEventData.clickCount++;
							num = 1217494244;
							continue;
						}
						goto case 4;
					case 21:
						if (num3 < 0.3f)
						{
							pointerEventData.clickCount++;
							num = 1217494251;
							continue;
						}
						goto case 17;
					case 5:
						num = 1217494240;
						continue;
					case 7:
						num = 1217494241;
						continue;
					case 18:
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						if (pointerEventData.pointerEnter != gameObject)
						{
							pointerEventData.pointerEnter = gameObject;
							num = 1217494242;
							continue;
						}
						goto case 14;
					case 19:
					{
						pointerEventData.useDragThreshold = true;
						pointerEventData.pressPosition = pointerEventData.position;
						pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
						gameObject3 = P_1;
						unscaledTime2 = Time.unscaledTime;
						int num4;
						if (gameObject3 == pointerEventData.lastPress)
						{
							num = 1217494268;
							num4 = num;
						}
						else
						{
							num = 1217494264;
							num4 = num;
						}
						continue;
					}
					case 11:
						pointerEventData.rawPointerPress = gameObject;
						pointerEventData.clickTime = unscaledTime2;
						pointerEventData.pointerDrag = gameObject;
						goto IL_02f8;
					case 12:
						pointerEventData.pointerPress = gameObject3;
						num = 1217494247;
						continue;
					case 14:
						gameObject2 = P_1;
						unscaledTime = Time.unscaledTime;
						num = 1217494243;
						continue;
					case 10:
						pointerEventData.clickCount = 1;
						num = 1217494252;
						continue;
					case 16:
						num2 = unscaledTime2 - pointerEventData.clickTime;
						num = 1217494245;
						continue;
					case 8:
						pointerEventData.clickTime = unscaledTime2;
						num = 1217494249;
						continue;
					case 15:
						if (gameObject2 == pointerEventData.lastPress)
						{
							num3 = unscaledTime - pointerEventData.clickTime;
							num = 1217494265;
							continue;
						}
						goto case 10;
					case 6:
						if (pointerEventData == null)
						{
							return null;
						}
						gameObject = P_1;
						pointerEventData.position = TouchInteractable.LHsXCsNAjXaZWaBWMkQCnCpFObj(P_0);
						if (TouchInteractable.dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
						{
							pointerEventData.eligibleForClick = true;
							pointerEventData.delta = Vector2.zero;
							pointerEventData.dragging = false;
							pointerEventData.useDragThreshold = true;
							pointerEventData.pressPosition = pointerEventData.position;
							num = 1217494270;
							continue;
						}
						goto case 2;
					case 13:
						pointerEventData.clickTime = unscaledTime;
						num = 1217494252;
						continue;
					case 20:
						pointerEventData.clickCount = 1;
						num = 1217494240;
						continue;
					case 4:
						pointerEventData.clickCount = 1;
						num = 1217494244;
						continue;
					default:
						{
							Logger.LogWarning("Unsupported pointerId: " + P_0);
							return null;
						}
						IL_02f8:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private PointerEventData tzBbHeHAGAaQCwiFkPKWKUeCjYAn(int P_0)
		{
			PointerEventData pointerEventData = ZratKwUfLghYErsNiaeupeoKzqF(P_0);
			while (true)
			{
				int num = -337423900;
				while (true)
				{
					switch (num ^ -337423897)
					{
					case 4:
						break;
					case 7:
						pointerEventData.pointerPress = null;
						num = -337423892;
						continue;
					case 2:
						pointerEventData.pointerDrag = null;
						num = -337423891;
						continue;
					case 3:
					{
						if (pointerEventData == null)
						{
							return null;
						}
						int num2;
						if (!TouchInteractable.dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
						{
							num = -337423890;
							num2 = num;
						}
						else
						{
							num = -337423889;
							num2 = num;
						}
						continue;
					}
					case 10:
						pointerEventData.pointerEnter = null;
						goto IL_0140;
					case 8:
						pointerEventData.eligibleForClick = false;
						num = -337423898;
						continue;
					case 9:
						if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
						{
							pointerEventData.eligibleForClick = false;
							num = -337423904;
							continue;
						}
						goto case 12;
					case 12:
						Logger.LogWarning("Unsupported pointerId: " + P_0);
						num = -337423903;
						continue;
					case 1:
						pointerEventData.pointerPress = null;
						pointerEventData.rawPointerPress = null;
						num = -337423897;
						continue;
					case 5:
						pointerEventData.pointerDrag = null;
						goto IL_0140;
					case 11:
						pointerEventData.rawPointerPress = null;
						pointerEventData.dragging = false;
						num = -337423902;
						continue;
					case 0:
						pointerEventData.dragging = false;
						num = -337423899;
						continue;
					default:
						{
							return null;
						}
						IL_0140:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private void VGdcUqdPAuBHPLgxHVatOVpAQUrD(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				OnPointerUp(P_0);
				int num = 1007451314;
				while (true)
				{
					switch (num ^ 0x3C0C7CB2)
					{
					case 2:
						goto IL_0004;
					case 1:
						break;
					default:
						tzBbHeHAGAaQCwiFkPKWKUeCjYAn(effectivePointerId);
						return;
					}
					break;
					IL_0004:
					num = 1007451315;
				}
			}
		}

		private PointerEventData ZratKwUfLghYErsNiaeupeoKzqF(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return null;
			}
			if (OmdClIeGlFSmCdhqZRQsbuQzaza == null)
			{
				OmdClIeGlFSmCdhqZRQsbuQzaza = new Dictionary<int, PointerEventData>();
				goto IL_0020;
			}
			goto IL_00be;
			IL_011d:
			PointerEventData value = default(PointerEventData);
			return value;
			IL_00be:
			int num;
			if (!OmdClIeGlFSmCdhqZRQsbuQzaza.TryGetValue(P_0, out value))
			{
				value = new PointerEventData(EventSystem.current);
				value.pointerId = P_0;
				num = 754171656;
				goto IL_0025;
			}
			goto IL_011d;
			IL_0020:
			num = 754171654;
			goto IL_0025;
			IL_0025:
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			while (true)
			{
				switch (num ^ 0x2CF3BF0E)
				{
				case 0:
					break;
				case 4:
					throw new NotImplementedException();
				case 5:
					button = PointerEventData.InputButton.Middle;
					num = 754171652;
					continue;
				case 6:
					goto IL_0077;
				case 3:
					switch (P_0)
					{
					case -3:
						break;
					default:
						goto IL_00b4;
					case -1:
						goto IL_00ea;
					case -2:
						goto IL_00f6;
					}
					goto case 5;
				case 8:
					goto IL_00be;
				case 1:
					goto IL_00ea;
				case 9:
					goto IL_00f6;
				case 10:
					num = 754171660;
					continue;
				case 2:
					value.button = button;
					num = 754171657;
					continue;
				default:
					goto IL_011d;
					IL_00f6:
					button = PointerEventData.InputButton.Right;
					num = 754171660;
					continue;
					IL_00ea:
					button = PointerEventData.InputButton.Left;
					num = 754171660;
					continue;
					IL_00b4:
					num = 754171658;
					continue;
				}
				break;
				IL_0077:
				OmdClIeGlFSmCdhqZRQsbuQzaza.Add(P_0, value);
				int num2;
				if (TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
				{
					num = 754171661;
					num2 = num;
				}
				else
				{
					num = 754171657;
					num2 = num;
				}
			}
			goto IL_0020;
		}

		private void ykLlbzWaLuNEKGAQUYLFIUwTpBY(PointerEventData P_0, YIGKRFpzmwAuTUviVgNTzUogFuc P_1)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				return;
			}
			while (WMOIUVAoMMEQPQHrJmvWWfvqFVh() && IsInteractable())
			{
				PrhNrJNIlRPRCXgcxIuytulSRay(P_0.pointerId, P_0.pressPosition, P_1);
				int num = 1501941366;
				while (true)
				{
					switch (num ^ 0x5985CE76)
					{
					case 2:
						num = 1501941367;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0035;
					}
					break;
				}
				continue;
				end_IL_0035:
				break;
			}
			base.OnPointerDown(P_0);
		}

		private void PKDpapVpBsZIfGwBoVYoUivnEgl(PointerEventData P_0, YIGKRFpzmwAuTUviVgNTzUogFuc P_1)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				goto IL_0016;
			}
			goto IL_0044;
			IL_0059:
			SHIErtNBGDqtOcJrfCqGmlXqnbj();
			base.OnPointerUp(P_0);
			int num = -326284810;
			goto IL_001b;
			IL_0016:
			num = -326284809;
			goto IL_001b;
			IL_001b:
			switch (num ^ -326284810)
			{
			case 4:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0044;
			case 2:
				goto IL_0059;
			case 0:
				return;
			}
			goto IL_0016;
			IL_0044:
			if (TouchInteractable.kbMCsiiWOKxlJWHaZJNVHJWBcqKM(effectivePointerId))
			{
				return;
			}
			goto IL_0059;
		}

		private void LZkGGotiHtFpBawoWkiqWiNbAGgZ(PointerEventData P_0, YIGKRFpzmwAuTUviVgNTzUogFuc P_1)
		{
			if (hasPointer && !KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
			{
				return;
			}
			MouseButtonFlags mouseButtonFlags = default(MouseButtonFlags);
			GameObject gameObject = default(GameObject);
			YIGKRFpzmwAuTUviVgNTzUogFuc yIGKRFpzmwAuTUviVgNTzUogFuc = default(YIGKRFpzmwAuTUviVgNTzUogFuc);
			while (true)
			{
				bool flag = TouchInteractable.gydVlFlzHNJAJhzgHruavaCUkbP(P_0.pointerId);
				bool flag2 = false;
				int num = 885068274;
				while (true)
				{
					switch (num ^ 0x34C111F7)
					{
					case 17:
						num = 885068277;
						continue;
					case 11:
						num = 885068280;
						continue;
					case 1:
						mouseButtonFlags = base.allowedMouseButtons;
						num = 885068282;
						continue;
					case 15:
					{
						PointerEventData pointerEventData = gxVyVSbhjrdJfymjdngkMthnlfz((LzoOqyUXBgfuwfLHBBzDqMYqLhC != int.MinValue) ? LzoOqyUXBgfuwfLHBBzDqMYqLhC : P_0.pointerId, gameObject);
						if (pointerEventData != null)
						{
							ykLlbzWaLuNEKGAQUYLFIUwTpBY(pointerEventData, P_1);
							num = 885068281;
							continue;
						}
						goto default;
					}
					case 0:
						if (flag)
						{
							int lzoOqyUXBgfuwfLHBBzDqMYqLhC;
							if (TouchInteractable.TrwaVKkqmuGmcHocRVPXaUPcSGp(mouseButtonFlags, out lzoOqyUXBgfuwfLHBBzDqMYqLhC))
							{
								LzoOqyUXBgfuwfLHBBzDqMYqLhC = lzoOqyUXBgfuwfLHBBzDqMYqLhC;
								num = 885068283;
								continue;
							}
							goto case 19;
						}
						goto case 12;
					case 8:
						gameObject = base.gameObject;
						num = 885068280;
						continue;
					case 5:
						yIGKRFpzmwAuTUviVgNTzUogFuc = P_1;
						num = 885068261;
						continue;
					case 3:
						if (_activateOnSwipeIn && WMOIUVAoMMEQPQHrJmvWWfvqFVh() && IsInteractable() && (!flag || TouchInteractable.FDenAmVtwBdAcjaFssMofuoOzsP(mouseButtonFlags)))
						{
							int num2;
							if (!QlnYBBpzNpDLYXfPrVIqnYFRDKL)
							{
								num = 885068279;
								num2 = num;
							}
							else
							{
								num = 885068286;
								num2 = num;
							}
							continue;
						}
						goto case 9;
					case 19:
						LzoOqyUXBgfuwfLHBBzDqMYqLhC = P_0.pointerId;
						num = 885068283;
						continue;
					case 2:
						break;
					case 10:
						throw new NotImplementedException();
					case 12:
						flag2 = true;
						num = 885068286;
						continue;
					case 7:
						throw new NotImplementedException();
					case 6:
						goto IL_01be;
					case 13:
						num = 885068276;
						continue;
					case 16:
						num = 885068272;
						continue;
					case 18:
						switch (yIGKRFpzmwAuTUviVgNTzUogFuc)
						{
						case YIGKRFpzmwAuTUviVgNTzUogFuc.hWboZvyXoJNhfSvesxqLLWrBcgF:
							break;
						case YIGKRFpzmwAuTUviVgNTzUogFuc.FbpqMQLqHsIUsSlvpbBzoWAbCsO:
							goto IL_01be;
						default:
							goto IL_01f7;
						}
						goto case 1;
					case 4:
						goto IL_0201;
					case 9:
						base.OnPointerEnter(P_0);
						if (flag2)
						{
							switch (P_1)
							{
							case YIGKRFpzmwAuTUviVgNTzUogFuc.hWboZvyXoJNhfSvesxqLLWrBcgF:
								break;
							case YIGKRFpzmwAuTUviVgNTzUogFuc.FbpqMQLqHsIUsSlvpbBzoWAbCsO:
								goto IL_0201;
							default:
								goto IL_0234;
							}
							goto case 8;
						}
						goto default;
					default:
						{
							tmlENZkWxfXAUYowkKtYqEQUwuh = true;
							return;
						}
						IL_01f7:
						num = 885068263;
						continue;
						IL_01be:
						mouseButtonFlags = _touchRegion.allowedMouseButtons;
						num = 885068276;
						continue;
						IL_0234:
						num = 885068285;
						continue;
						IL_0201:
						gameObject = TMyXBUOIpefyPDfOBNRqSCzUeMA.gameObject;
						num = 885068284;
						continue;
					}
					break;
				}
			}
		}

		private void jnQPXNUYsptUbWdLIawDCCMiSiQ(PointerEventData P_0, YIGKRFpzmwAuTUviVgNTzUogFuc P_1)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0048;
			IL_0008:
			int num = -312839271;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -312839268)
				{
				case 4:
					break;
				case 0:
					goto IL_0032;
				case 1:
					return;
				case 2:
					goto IL_0048;
				case 5:
					if (!KsFFXDTmNznRFMUIlONNipwkUlQ(P_0.pointerId))
					{
						base.OnPointerExit(P_0);
						num = -312839267;
						continue;
					}
					goto IL_0048;
				default:
					tmlENZkWxfXAUYowkKtYqEQUwuh = false;
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0032:
			base.OnPointerExit(P_0);
			num = -312839265;
			goto IL_000d;
			IL_0048:
			if (!stayActiveOnSwipeOut && QlnYBBpzNpDLYXfPrVIqnYFRDKL)
			{
				SHIErtNBGDqtOcJrfCqGmlXqnbj();
				num = -312839268;
				goto IL_000d;
			}
			goto IL_0032;
		}

		private void PrhNrJNIlRPRCXgcxIuytulSRay(int P_0, Vector2 P_1, YIGKRFpzmwAuTUviVgNTzUogFuc P_2)
		{
			qzygTAANCsGThMrzndPvSXbKaDF = P_0;
			QlnYBBpzNpDLYXfPrVIqnYFRDKL = true;
			if (_followTouchPosition)
			{
				KKKzzptlCzpxEXyQiJDGcaVVucZ(P_0);
			}
			else
			{
				while (P_2 == YIGKRFpzmwAuTUviVgNTzUogFuc.FbpqMQLqHsIUsSlvpbBzoWAbCsO && _moveToTouchPosition)
				{
					vUqurQgbViEJEHwXocSHTJSMPuDp(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, UzAgcTofzxoRKPiAALjutXmddFi.XtRDenkmlflSSFYJThdxkTsQRdUi);
					int num = -1618237765;
					while (true)
					{
						switch (num ^ -1618237767)
						{
						case 0:
							num = -1618237768;
							continue;
						case 1:
							break;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			lCFIBZLMNKvXmTGMtfkRZXzmGto();
		}

		private void SHIErtNBGDqtOcJrfCqGmlXqnbj()
		{
			nnIbvzAiFmjEPCjsdxFWxHOPYIt();
			QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
			if (!_followTouchPosition)
			{
				goto IL_0015;
			}
			goto IL_0061;
			IL_0015:
			int num = -174672161;
			goto IL_001a;
			IL_001a:
			while (true)
			{
				switch (num ^ -174672163)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					nSUtEBAkcafXvvbwQuYCqBXHwpf();
					num = -174672167;
					continue;
				case 5:
					if (yEGfcMioCprmZdfdCprLEAuqWmsm)
					{
						ReturnToDefaultPosition();
						num = -174672162;
						continue;
					}
					goto case 3;
				case 1:
					goto IL_0061;
				case 2:
					goto IL_007a;
				case 4:
					return;
				}
				break;
				IL_007a:
				int num2;
				if (!_moveToTouchPosition)
				{
					num = -174672162;
					num2 = num;
				}
				else
				{
					num = -174672164;
					num2 = num;
				}
			}
			goto IL_0015;
			IL_0061:
			int num3;
			if (!_returnOnRelease)
			{
				num = -174672162;
				num3 = num;
			}
			else
			{
				num = -174672168;
				num3 = num;
			}
			goto IL_001a;
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(TMyXBUOIpefyPDfOBNRqSCzUeMA != null) || !_useTouchRegionOnly))
			{
				ykLlbzWaLuNEKGAQUYLFIUwTpBY(eventData, YIGKRFpzmwAuTUviVgNTzUogFuc.hWboZvyXoJNhfSvesxqLLWrBcgF);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(TMyXBUOIpefyPDfOBNRqSCzUeMA != null) || !_useTouchRegionOnly))
			{
				PKDpapVpBsZIfGwBoVYoUivnEgl(eventData, YIGKRFpzmwAuTUviVgNTzUogFuc.hWboZvyXoJNhfSvesxqLLWrBcgF);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(TMyXBUOIpefyPDfOBNRqSCzUeMA != null) || !_useTouchRegionOnly))
			{
				LZkGGotiHtFpBawoWkiqWiNbAGgZ(eventData, YIGKRFpzmwAuTUviVgNTzUogFuc.hWboZvyXoJNhfSvesxqLLWrBcgF);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
				{
					num = -941795768;
					num2 = num;
				}
				else
				{
					num = -941795765;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -941795768)
					{
					case 4:
						goto IL_0009;
					case 3:
						if (TMyXBUOIpefyPDfOBNRqSCzUeMA != null && _useTouchRegionOnly)
						{
							return;
						}
						goto default;
					case 0:
						return;
					case 1:
						break;
					default:
						jnQPXNUYsptUbWdLIawDCCMiSiQ(eventData, YIGKRFpzmwAuTUviVgNTzUogFuc.hWboZvyXoJNhfSvesxqLLWrBcgF);
						return;
					}
					break;
					IL_0009:
					num = -941795767;
				}
			}
		}

		private void lzqUemmLiWpBjHlLmGrpmuhFrlo(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				ykLlbzWaLuNEKGAQUYLFIUwTpBY(P_0, YIGKRFpzmwAuTUviVgNTzUogFuc.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
			}
		}

		private void UEcgqxIblHuJqokaoodfjjxksQmz(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_003d;
			IL_0008:
			int num = -1982148797;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1982148798)
			{
			case 4:
				break;
			default:
				return;
			case 3:
				goto IL_002e;
			case 0:
				goto IL_003d;
			case 1:
				return;
			case 2:
				return;
			}
			goto IL_0008;
			IL_003d:
			if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			goto IL_002e;
			IL_002e:
			PKDpapVpBsZIfGwBoVYoUivnEgl(P_0, YIGKRFpzmwAuTUviVgNTzUogFuc.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
			num = -1982148800;
			goto IL_000d;
		}

		private void UkqepPwTKhKlSSYpykoMGilKlBO(PointerEventData P_0)
		{
			if (base.initialized && TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				LZkGGotiHtFpBawoWkiqWiNbAGgZ(P_0, YIGKRFpzmwAuTUviVgNTzUogFuc.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
			}
		}

		private void FdfJZopCusKoJSmKfyVDmEfTHFm(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				while (true)
				{
					switch (-1976012370 ^ -1976012369)
					{
					case 0:
						break;
					case 1:
						return;
					case 2:
						goto end_IL_0008;
					default:
						goto IL_0053;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			goto IL_0053;
			IL_0053:
			jnQPXNUYsptUbWdLIawDCCMiSiQ(P_0, YIGKRFpzmwAuTUviVgNTzUogFuc.FbpqMQLqHsIUsSlvpbBzoWAbCsO);
		}

		private void ikGcuzFLbQzirRQpqnEOPYpKOAv(float P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!_useDigitalAxisSimulation)
				{
					num = -2080768265;
					num2 = num;
				}
				else
				{
					num = -2080768268;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2080768267)
					{
					case 0:
						goto IL_0009;
					case 3:
						break;
					case 1:
						return;
					default:
						EQnWUlQqOynmEtPVWLCOkLeIdyA(null);
						_onAxisValueChanged.Invoke(P_0);
						return;
					}
					break;
					IL_0009:
					num = -2080768266;
				}
			}
		}

		private void sryVkxTqbPBffatwxQivcnTaaJWS(bool P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				EQnWUlQqOynmEtPVWLCOkLeIdyA(null);
				_onButtonValueChanged.Invoke(P_0);
				int num = 438431478;
				while (true)
				{
					switch (num ^ 0x1A21EEF7)
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
					num = 438431477;
				}
			}
		}

		private void bJKClJiPquDFFWIspweNEeFaeUAG()
		{
			if (base.initialized)
			{
				EQnWUlQqOynmEtPVWLCOkLeIdyA(null);
				_onButtonDown.Invoke();
			}
		}

		private void KgzRGahoqRbPKqcAjAddGKFLgvea()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				EQnWUlQqOynmEtPVWLCOkLeIdyA(null);
				int num = -916719256;
				while (true)
				{
					switch (num ^ -916719255)
					{
					case 0:
						goto IL_0009;
					case 2:
						break;
					default:
						_onButtonUp.Invoke();
						return;
					}
					break;
					IL_0009:
					num = -916719253;
				}
			}
		}
	}
}
