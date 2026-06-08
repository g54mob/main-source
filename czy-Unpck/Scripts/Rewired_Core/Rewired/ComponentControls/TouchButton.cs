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
	[DisallowMultipleComponent]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public sealed class TouchButton : TouchInteractable
	{
		public enum ButtonType
		{
			Standard = 0,
			ToggleSwitch = 1
		}

		private enum bBKAXIbGOthvKVyNPUqrLhbuauJv
		{
			XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
			yrNPjkUJApZCVhMgUIDiTGAJeil = 1,
			ZHOJKsdjqeTbuCznzGjkgQECHhx = 2
		}

		private enum jfWoaSDxXqJmQriNWFwYxpUbATB
		{
			AXriQuEBFZCYarVPplCATARGxpw = 0,
			ocnclNbRoiITlrFWknqquxusEpr = 1
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

		private sealed class ftoREUCQafdPadJVMjjWDpcvrOEb : IEnumerator<object>, IDisposable, IEnumerator
		{
			private object ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			public TouchButton syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public Vector2 gbejOQIayEZKbGyCZpFoaaiiUxS;

			public PositionType oDHiqonMoiufKKpGJbNyiKpUZHE;

			public float juGAuHQJxyCbGveDiDRabDWTpiv;

			public bBKAXIbGOthvKVyNPUqrLhbuauJv JoWgWEHKMpkeOadbbkLgIsuWZgn;

			public RectTransform KJkCcQkcFVhJdUUSpUfVnvRiZQbm;

			public Vector2 ptkONblBIYdRClZNRCljouJMFxz;

			public float ahXSeedevfPTYQAUuJzeKheReLk;

			public float ZRuKqqwBwfBUrNkkQgRIjnVJFbyV;

			public float XFUfkcDGkFJYjLpEacfOkgjEhnoh;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 0:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					num = 385387251;
					goto IL_001f;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 385387261;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x16F88AF8)
						{
						case 4:
							num = 385387257;
							continue;
						case 5:
							break;
						case 11:
							goto IL_007d;
						case 9:
							goto IL_009b;
						case 10:
							KJkCcQkcFVhJdUUSpUfVnvRiZQbm = syCPfFbHYMDOvEPjTnPLBqiOhsPv.rectTransform;
							num = 385387249;
							continue;
						case 0:
							XFUfkcDGkFJYjLpEacfOkgjEhnoh += Time.unscaledDeltaTime / ZRuKqqwBwfBUrNkkQgRIjnVJFbyV;
							LOMeYMhHKyjSwUDqvWYJlrErQKH.UprvgqxthkUgaQeUXArWMBZlDPh(KJkCcQkcFVhJdUUSpUfVnvRiZQbm, Vector2.Lerp(ptkONblBIYdRClZNRCljouJMFxz, gbejOQIayEZKbGyCZpFoaaiiUxS, Mathf.SmoothStep(0f, 1f, XFUfkcDGkFJYjLpEacfOkgjEhnoh)), oDHiqonMoiufKKpGJbNyiKpUZHE);
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = null;
							num = 385387248;
							continue;
						case 2:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.shENDFotJKEDucBZRyRFORLMigTa(JoWgWEHKMpkeOadbbkLgIsuWZgn, gbejOQIayEZKbGyCZpFoaaiiUxS, oDHiqonMoiufKKpGJbNyiKpUZHE);
							num = 385387259;
							continue;
						case 1:
							goto end_IL_001f;
						case 6:
							return true;
						case 7:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.MOkeHydsYmBjWMGbpaGUIHYmfacO = true;
							ZRuKqqwBwfBUrNkkQgRIjnVJFbyV = ahXSeedevfPTYQAUuJzeKheReLk / juGAuHQJxyCbGveDiDRabDWTpiv;
							XFUfkcDGkFJYjLpEacfOkgjEhnoh = 0f;
							num = 385387261;
							continue;
						case 8:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = 385387262;
							continue;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (!(XFUfkcDGkFJYjLpEacfOkgjEhnoh > 1f))
						{
							num = 385387256;
							num2 = num;
						}
						else
						{
							num = 385387258;
							num2 = num;
						}
						continue;
						IL_009b:
						ptkONblBIYdRClZNRCljouJMFxz = LOMeYMhHKyjSwUDqvWYJlrErQKH.RHSfXhsPjZpvTnuaRtDNJQoXDno(KJkCcQkcFVhJdUUSpUfVnvRiZQbm, oDHiqonMoiufKKpGJbNyiKpUZHE);
						ahXSeedevfPTYQAUuJzeKheReLk = (gbejOQIayEZKbGyCZpFoaaiiUxS - ptkONblBIYdRClZNRCljouJMFxz).magnitude;
						int num3;
						if (!(ahXSeedevfPTYQAUuJzeKheReLk >= 0.01f))
						{
							num = 385387258;
							num3 = num;
						}
						else
						{
							num = 385387263;
							num3 = num;
						}
						continue;
						IL_007d:
						int num4;
						if (!(juGAuHQJxyCbGveDiDRabDWTpiv > 0f))
						{
							num = 385387258;
							num4 = num;
						}
						else
						{
							num = 385387250;
							num4 = num;
						}
						continue;
						end_IL_001f:
						break;
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
			public ftoREUCQafdPadJVMjjWDpcvrOEb(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
			}
		}

		private const float hQeoiChRmHqgYkSQdpCzmdkEIlo = 20f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element that will receive input values from this control.")]
		private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Button
		}));

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
		private ButtonType _buttonType;

		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
		[SerializeField]
		private bool _activateOnSwipeIn;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
		private bool _stayActiveOnSwipeOut = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
		private bool _useDigitalAxisSimulation;

		[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[SerializeField]
		[FieldRange(0f, float.PositiveInfinity)]
		[CustomObfuscation(rename = false)]
		private float _digitalAxisGravity = 3f;

		[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
		[CustomObfuscation(rename = false)]
		[FieldRange(0f, float.PositiveInfinity)]
		[SerializeField]
		private float _digitalAxisSensitivity = 3f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
		private StandaloneAxis _axis = new StandaloneAxis();

		[CustomObfuscation(rename = false)]
		[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
		[SerializeField]
		private TouchRegion _touchRegion;

		[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useTouchRegionOnly = true;

		[SerializeField]
		[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
		[CustomObfuscation(rename = false)]
		private bool _moveToTouchPosition;

		[CustomObfuscation(rename = false)]
		[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
		[SerializeField]
		private bool _returnOnRelease = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
		private bool _followTouchPosition;

		[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _animateOnMoveToTouch = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
		[Range(0f, 20f)]
		private float _moveToTouchSpeed = 2f;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
		[SerializeField]
		private bool _animateOnReturn = true;

		[Range(0f, 20f)]
		[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private float _returnSpeed = 2f;

		[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _manageRaycasting = true;

		private float duAdyIDRWTXiZatSHndhbqzARJH;

		private float evgzQTaZdwccXhEfQqcyBgWVqOC;

		private TouchRegion iQmFiDmmCiNwWeIdWsidKUZRDib;

		private Vector2 YKMeEUiGuZSGDgDadsXsSiSQbws;

		private bool MOkeHydsYmBjWMGbpaGUIHYmfacO;

		private bool LCMJNNIhlrvlECcQiHKWEDSFCjJG;

		private bBKAXIbGOthvKVyNPUqrLhbuauJv LmMNeqLluRSDEVqFGoHkNPrrvDL;

		private int HvkclJglniOXcnrWcckuOPsHKFa = int.MinValue;

		private int wUaATdmWscCtdMBeYMUAghqpCele = int.MinValue;

		[NonSerialized]
		private bool deteGKFsUpKVtiobsxDnfbVWHkL;

		[NonSerialized]
		private bool IflsmAOKUdJKTpCZjpeDsuqZbjM;

		private IEnumerator wWUdDrDMDWpYUxNLcnnKBLIAOkS;

		private NIcCUdyQMDYZUZhyXqxbpJwMTqP oKOYxtmhgFlYCzGLRiOQfDoBOXL = new NIcCUdyQMDYZUZhyXqxbpJwMTqP();

		private Action<bBKAXIbGOthvKVyNPUqrLhbuauJv> AdyvrPhZPyInWKAEhettrVTyEKS;

		private Action<bBKAXIbGOthvKVyNPUqrLhbuauJv> hbxDCByNEfGvRwgDDtAzZqNumpX;

		[Tooltip("Event sent when the axis value changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

		[SerializeField]
		[Tooltip("Event sent when the button value changes.")]
		[CustomObfuscation(rename = false)]
		private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the button is pressed.")]
		private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the button is released.")]
		private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

		private Dictionary<int, PointerEventData> vlrRIXQCCHSpLGkTSgbxdZoiFgD;

		public CustomControllerElementTargetSetForFloat targetCustomControllerElement => _targetCustomControllerElement;

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
					int num = 930253535;
					while (true)
					{
						switch (num ^ 0x37728ADF)
						{
						case 2:
							num = 930253534;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = 930253532;
							continue;
						case 3:
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
					while (true)
					{
						switch (0xB2234D ^ 0xB2234C)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_activateOnSwipeIn = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
			}
		}

		public bool stayActiveOnSwipeOut
		{
			get
			{
				if (yPLpJvfMgnznJgRUbpowGjMhQZr())
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 1654742175;
					while (true)
					{
						switch (num ^ 0x62A15C9D)
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
						num = 1654742172;
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
				if (_useDigitalAxisSimulation != value)
				{
					_useDigitalAxisSimulation = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					return;
				}
				while (true)
				{
					_digitalAxisSensitivity = value;
					int num = 297115423;
					while (true)
					{
						switch (num ^ 0x11B59F1E)
						{
						case 0:
							goto IL_000a;
						case 2:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000a:
						num = 297115420;
					}
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
				if (_touchRegion == value)
				{
					return;
				}
				while (true)
				{
					_touchRegion = value;
					int num = 644439810;
					while (true)
					{
						switch (num ^ 0x26695F00)
						{
						case 0:
							goto IL_000f;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000f:
						num = 644439809;
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 1174607549;
					while (true)
					{
						switch (num ^ 0x460316BF)
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
						num = 1174607550;
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
					goto IL_0009;
				}
				goto IL_0044;
				IL_0009:
				int num = 976049000;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x3A2D5369)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						return;
					case 0:
						wWklIWMVIReShFCdZhfAVVyDQgX();
						num = 976049003;
						continue;
					case 4:
						goto IL_0044;
					case 2:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0044:
				_moveToTouchPosition = value;
				num = 976049001;
				goto IL_000e;
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
					return;
				}
				while (true)
				{
					_returnOnRelease = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = -1197495451;
					while (true)
					{
						switch (num ^ -1197495451)
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
						num = -1197495452;
					}
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_animateOnMoveToTouch == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -982361989;
				goto IL_000e;
				IL_000e:
				switch (num ^ -982361990)
				{
				case 3:
					break;
				case 1:
					return;
				case 0:
					goto IL_0033;
				default:
					wWklIWMVIReShFCdZhfAVVyDQgX();
					return;
				}
				goto IL_0009;
				IL_0033:
				_animateOnMoveToTouch = value;
				num = -982361992;
				goto IL_000e;
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
					return;
				}
				while (true)
				{
					_moveToTouchSpeed = value;
					int num = 2126015553;
					while (true)
					{
						switch (num ^ 0x7EB86C40)
						{
						case 3:
							num = 2126015554;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = 2126015552;
							continue;
						case 0:
							return;
						}
						break;
					}
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
					while (true)
					{
						switch (-210287518 ^ -210287517)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_animateOnReturn = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					goto IL_0009;
				}
				goto IL_005a;
				IL_0009:
				int num = 1250967196;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x4A903E99)
					{
					case 0:
						break;
					case 5:
						return;
					case 2:
						PXEXrnDRygAuZueqSOcmNrpLWNJ();
						num = 1250967194;
						continue;
					case 1:
						oKOYxtmhgFlYCzGLRiOQfDoBOXL.tAgADqjTsMUxSqYXeDyJIdETYRAp();
						num = 1250967194;
						continue;
					case 4:
						goto IL_005a;
					default:
						wWklIWMVIReShFCdZhfAVVyDQgX();
						return;
					}
					break;
				}
				goto IL_0009;
				IL_005a:
				_manageRaycasting = value;
				int num2;
				if (value)
				{
					num = 1250967195;
					num2 = num;
				}
				else
				{
					num = 1250967192;
					num2 = num;
				}
				goto IL_000e;
			}
		}

		public int pointerId
		{
			get
			{
				return HvkclJglniOXcnrWcckuOPsHKFa;
			}
			set
			{
				HvkclJglniOXcnrWcckuOPsHKFa = value;
			}
		}

		public bool hasPointer => HvkclJglniOXcnrWcckuOPsHKFa != int.MinValue;

		internal StandaloneAxis axis => _axis;

		private Action<bBKAXIbGOthvKVyNPUqrLhbuauJv> moveStartedDelegate
		{
			get
			{
				if (AdyvrPhZPyInWKAEhettrVTyEKS == null)
				{
					return AdyvrPhZPyInWKAEhettrVTyEKS = ygmgHpsoczoktCqokJEUBknCWlz;
				}
				return AdyvrPhZPyInWKAEhettrVTyEKS;
			}
		}

		private Action<bBKAXIbGOthvKVyNPUqrLhbuauJv> moveEndedDelegate
		{
			get
			{
				if (hbxDCByNEfGvRwgDDtAzZqNumpX == null)
				{
					return hbxDCByNEfGvRwgDDtAzZqNumpX = hMLWOTCnUeECHkZYcVMttLBlZZs;
				}
				return hbxDCByNEfGvRwgDDtAzZqNumpX;
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
				return duAdyIDRWTXiZatSHndhbqzARJH;
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
				return evgzQTaZdwccXhEfQqcyBgWVqOC;
			}
		}

		private bool buttonValue => _axis.buttonValue;

		private bool buttonValuePrev => _axis.buttonValuePrev;

		private int effectivePointerId
		{
			get
			{
				if (HvkclJglniOXcnrWcckuOPsHKFa == int.MinValue)
				{
					return int.MinValue;
				}
				if (wUaATdmWscCtdMBeYMUAghqpCele != int.MinValue)
				{
					return wUaATdmWscCtdMBeYMUAghqpCele;
				}
				return HvkclJglniOXcnrWcckuOPsHKFa;
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
			if (!base.initialized)
			{
				while (true)
				{
					switch (0x2CA27119 ^ 0x2CA2711B)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			_axis.SetRawValue(value);
		}

		public void SetDefaultPosition()
		{
			fFKLAVvYROMMQQhfhHNlftiOPJN(base.rectTransform.anchoredPosition);
		}

		private void fFKLAVvYROMMQQhfhHNlftiOPJN(Vector2 P_0)
		{
			if (base.initialized)
			{
				YKMeEUiGuZSGDgDadsXsSiSQbws = P_0;
			}
		}

		public void ReturnToDefaultPosition(bool instant)
		{
			if (base.initialized)
			{
				WMSsfkMLKlhjcjelurBOcNZuvNX(YKMeEUiGuZSGDgDadsXsSiSQbws, PositionType.WALjqDIkNzPxbhnsjcnYTAHDFKBY, !instant && _animateOnReturn, _returnSpeed, bBKAXIbGOthvKVyNPUqrLhbuauJv.ZHOJKsdjqeTbuCznzGjkgQECHhx);
			}
		}

		public void ReturnToDefaultPosition()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 1009863778;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x3C314C63)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_0032;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0032:
			ReturnToDefaultPosition(instant: false);
			num = 1009863779;
			goto IL_000d;
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying)
			{
				YKMeEUiGuZSGDgDadsXsSiSQbws = base.rectTransform.anchoredPosition;
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			while (true)
			{
				switch (0x6EB04CC0 ^ 0x6EB04CC2)
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
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			base.OnDisable();
			while (true)
			{
				switch (0x6E3E9207 ^ 0x6E3E9205)
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
			QBogclsViwEODeiCNJnFOileABHD();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			while (true)
			{
				int num = 453784887;
				while (true)
				{
					switch (num ^ 0x1B0C3534)
					{
					case 2:
						break;
					case 3:
					{
						int num2;
						if (base.initialized)
						{
							num = 453784885;
							num2 = num;
						}
						else
						{
							num = 453784884;
							num2 = num;
						}
						continue;
					}
					case 0:
						return;
					default:
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
						return;
					}
					break;
				}
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
			base.spiCZIbBixHwkYmPEBFXAXTGsXtO();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				UcvgzyHjPLrcamsdZskkPOQcONwi();
				rcqBXlFvThOIzUYEKRmQDTmyRyd();
				int num = -780049662;
				while (true)
				{
					switch (num ^ -780049661)
					{
					case 4:
						num = -780049663;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
					{
						PwFQGpSvYxdOGrWIVgkgsMQgDbfj();
						int num2;
						if (_followTouchPosition)
						{
							num = -780049661;
							num2 = num;
						}
						else
						{
							num = -780049664;
							num2 = num;
						}
						continue;
					}
					case 0:
						xdUAfaJdefyUTchrjmQTwhnQniy(effectivePointerId);
						num = -780049664;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal bool OnInitialize()
		{
			if (!KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				return false;
			}
			return true;
		}

		internal void OnCustomControllerUpdate()
		{
			if (base.initialized && hasController)
			{
				fcpMokSOSPSkfIoeTHjUJvvymMbi(_targetCustomControllerElement, axisValue, _axis.buttonActivationThreshold);
			}
		}

		internal void OnSubscribeEvents()
		{
			NjkGaTSbjeAmPqdpyKMonMbyiMJ();
			while (true)
			{
				int num = -413357653;
				while (true)
				{
					switch (num ^ -413357655)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						_axis.ButtonValueChangedEvent += BksFivzUBJegkQVdqVIsdnNbIFn;
						_axis.ButtonDownEvent += EhUABIhiTsSyCnsVqZdAwLvlLFz;
						_axis.ButtonUpEvent += fknGcxFHFVWuTRijgaKwgMxIvgTK;
						return;
					}
					break;
					IL_0024:
					_axis.AxisValueChangedEvent += PmSBHqGtcObwsBsjhRGByRmNdVOn;
					num = -413357656;
				}
			}
		}

		internal void OnUnsubscribeEvents()
		{
			erHIwspAqyvfsFjxpigiGUNoawW();
			while (true)
			{
				int num = -804381542;
				while (true)
				{
					switch (num ^ -804381541)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						_axis.ButtonUpEvent -= fknGcxFHFVWuTRijgaKwgMxIvgTK;
						return;
					}
					break;
					IL_0024:
					_axis.AxisValueChangedEvent -= PmSBHqGtcObwsBsjhRGByRmNdVOn;
					_axis.ButtonValueChangedEvent -= BksFivzUBJegkQVdqVIsdnNbIFn;
					_axis.ButtonDownEvent -= EhUABIhiTsSyCnsVqZdAwLvlLFz;
					num = -804381541;
				}
			}
		}

		internal void OnSetProperty()
		{
			wWklIWMVIReShFCdZhfAVVyDQgX();
			while (true)
			{
				int num = 1293658392;
				while (true)
				{
					switch (num ^ 0x4D1BA91A)
					{
					case 3:
						break;
					case 2:
					{
						int num2;
						if (base.initialized)
						{
							num = 1293658394;
							num2 = num;
						}
						else
						{
							num = 1293658395;
							num2 = num;
						}
						continue;
					}
					case 1:
						return;
					default:
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
						return;
					}
					break;
				}
			}
		}

		internal void OnClear()
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				HvkclJglniOXcnrWcckuOPsHKFa = int.MinValue;
				int num = 409143475;
				while (true)
				{
					switch (num ^ 0x186308BB)
					{
					case 4:
						num = 409143480;
						continue;
					case 5:
					{
						int num3;
						if (_moveToTouchPosition)
						{
							num = 409143482;
							num3 = num;
						}
						else
						{
							num = 409143484;
							num3 = num;
						}
						continue;
					}
					case 2:
						LCMJNNIhlrvlECcQiHKWEDSFCjJG = false;
						MOkeHydsYmBjWMGbpaGUIHYmfacO = false;
						num = 409143485;
						continue;
					case 7:
					{
						int num4;
						if (!_followTouchPosition)
						{
							num = 409143481;
							num4 = num;
						}
						else
						{
							num = 409143482;
							num4 = num;
						}
						continue;
					}
					case 1:
						ReturnToDefaultPosition(instant: true);
						num = 409143481;
						continue;
					case 3:
						break;
					case 6:
						LmMNeqLluRSDEVqFGoHkNPrrvDL = bBKAXIbGOthvKVyNPUqrLhbuauJv.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
						KcecMEVnboRrodQNOWiPXeBBDUA();
						num = 409143483;
						continue;
					case 0:
						_axis.Clear();
						duAdyIDRWTXiZatSHndhbqzARJH = 0f;
						evgzQTaZdwccXhEfQqcyBgWVqOC = 0f;
						num = 409143474;
						continue;
					case 8:
						wUaATdmWscCtdMBeYMUAghqpCele = int.MinValue;
						deteGKFsUpKVtiobsxDnfbVWHkL = false;
						IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
						if (_returnOnRelease)
						{
							int num2;
							if (!LCMJNNIhlrvlECcQiHKWEDSFCjJG)
							{
								num = 409143481;
								num2 = num;
							}
							else
							{
								num = 409143486;
								num2 = num;
							}
							continue;
						}
						goto case 2;
					default:
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
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
				goto IL_0008;
			}
			goto IL_004a;
			IL_0008:
			int num = -420384160;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -420384156)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					base.controller.ClearElementValue(_targetCustomControllerElement);
					num = -420384156;
					continue;
				case 5:
					goto IL_004a;
				case 2:
					goto IL_0067;
				case 4:
					return;
				case 0:
					return;
				}
				break;
				IL_0067:
				int num2;
				if (!hasController)
				{
					num = -420384156;
					num2 = num;
				}
				else
				{
					num = -420384155;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_004a:
			_axis.Clear();
			duAdyIDRWTXiZatSHndhbqzARJH = 0f;
			num = -420384154;
			goto IL_000d;
		}

		internal bool IsPressed()
		{
			if (!base.initialized)
			{
				return false;
			}
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
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
			if (base.NwAEhJMhIkbNQQjjHtkiYeNJUED(gameObject))
			{
				return true;
			}
			if (iQmFiDmmCiNwWeIdWsidKUZRDib != null)
			{
				return iQmFiDmmCiNwWeIdWsidKUZRDib.gameObject == gameObject;
			}
			return false;
		}

		private void PwFQGpSvYxdOGrWIVgkgsMQgDbfj()
		{
			if (!_useDigitalAxisSimulation)
			{
				while (true)
				{
					switch (-1391543321 ^ -1391543322)
					{
					case 0:
						break;
					case 1:
						return;
					case 3:
						goto end_IL_0008;
					default:
						goto IL_004f;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (_axis.buttonValue)
			{
				hZWcgvCotaJrHhZcVSsqCxzrUJt();
				return;
			}
			goto IL_004f;
			IL_004f:
			BACmnkLRJcDOwjyiclNNgblgPXF();
		}

		private void hZWcgvCotaJrHhZcVSsqCxzrUJt()
		{
			if (!(_axis.value >= 0f))
			{
				goto IL_0012;
			}
			float num = 1f;
			goto IL_003c;
			IL_003c:
			float num2 = num;
			float num3 = MathTools.Abs(_digitalAxisSensitivity);
			num2 *= num3 * Time.unscaledDeltaTime;
			num2 += duAdyIDRWTXiZatSHndhbqzARJH;
			num2 = MathTools.Clamp(num2, -1f, 1f);
			pKqQQIClhXtqKYJyyMyoZhYYojb(num2, true);
			int num4 = -1551018185;
			goto IL_0017;
			IL_0012:
			num4 = -1551018186;
			goto IL_0017;
			IL_0017:
			switch (num4 ^ -1551018185)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0030;
			case 0:
				return;
			}
			goto IL_0012;
			IL_0030:
			num = -1f;
			goto IL_003c;
		}

		private void BACmnkLRJcDOwjyiclNNgblgPXF()
		{
			float num = _digitalAxisGravity;
			if (num == 0f)
			{
				return;
			}
			float num6 = default(float);
			float num8 = default(float);
			float num4 = default(float);
			while (true)
			{
				float num2 = duAdyIDRWTXiZatSHndhbqzARJH;
				int num3 = 2033796106;
				while (true)
				{
					switch (num3 ^ 0x79394409)
					{
					case 7:
						num3 = 2033796108;
						continue;
					case 5:
						break;
					case 4:
						return;
					case 8:
					{
						num6 = num * Time.unscaledDeltaTime;
						int num7;
						if (MathTools.Abs(num6) >= MathTools.Abs(num2))
						{
							num3 = 2033796104;
							num7 = num3;
						}
						else
						{
							num3 = 2033796107;
							num7 = num3;
						}
						continue;
					}
					case 2:
						num8 = ((num2 > 0f) ? (-1f) : 1f);
						num3 = 2033796111;
						continue;
					case 6:
						num4 = num2 + num8 * num6;
						num3 = 2033796105;
						continue;
					case 1:
						num4 = 0f;
						num3 = 2033796105;
						continue;
					case 3:
					{
						int num5;
						if (num2 == 0f)
						{
							num3 = 2033796109;
							num5 = num3;
						}
						else
						{
							num3 = 2033796097;
							num5 = num3;
						}
						continue;
					}
					default:
						pKqQQIClhXtqKYJyyMyoZhYYojb(num4, true);
						return;
					}
					break;
				}
			}
		}

		private void pKqQQIClhXtqKYJyyMyoZhYYojb(float P_0, bool P_1)
		{
			evgzQTaZdwccXhEfQqcyBgWVqOC = duAdyIDRWTXiZatSHndhbqzARJH;
			duAdyIDRWTXiZatSHndhbqzARJH = P_0;
			while (true)
			{
				int num = -197704444;
				while (true)
				{
					switch (num ^ -197704441)
					{
					case 2:
						break;
					default:
						return;
					case 3:
					{
						int num3;
						if (P_0 == evgzQTaZdwccXhEfQqcyBgWVqOC)
						{
							num = -197704445;
							num3 = num;
						}
						else
						{
							num = -197704441;
							num3 = num;
						}
						continue;
					}
					case 0:
						vpbJzwkSvsfcXUnwDyeDqyAFmab(null);
						num = -197704445;
						continue;
					case 1:
						_onAxisValueChanged.Invoke(P_0);
						num = -197704446;
						continue;
					case 4:
						if (P_1)
						{
							int num2;
							if (P_0 == evgzQTaZdwccXhEfQqcyBgWVqOC)
							{
								num = -197704446;
								num2 = num;
							}
							else
							{
								num = -197704442;
								num2 = num;
							}
							continue;
						}
						return;
					case 5:
						return;
					}
					break;
				}
			}
		}

		private void WdDwWQpMwConxaplaHaGTbZhHMH()
		{
			if (_buttonType != ButtonType.ToggleSwitch)
			{
				goto IL_0059;
			}
			if (buttonValue)
			{
				goto IL_0011;
			}
			goto IL_0086;
			IL_0086:
			_axis.SetRawValue(_axis.rawMax);
			int num = 655744964;
			goto IL_0016;
			IL_0011:
			num = 655744967;
			goto IL_0016;
			IL_0016:
			switch (num ^ 0x2715DFC6)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				_axis.SetRawValue(_axis.rawZero);
				return;
			case 4:
				goto IL_0059;
			case 2:
				return;
			case 3:
				goto IL_0086;
			case 5:
				return;
			}
			goto IL_0011;
			IL_0059:
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawMax);
				num = 655744963;
				goto IL_0016;
			}
		}

		private void UACbMsURobGiSXJDChXicxIcoWN()
		{
			if (_buttonType == ButtonType.Standard)
			{
				_axis.SetRawValue(_axis.rawZero);
			}
		}

		private void NPOFSRfAiJHJstoMPmTkHgTRYCc()
		{
			_targetCustomControllerElement.ClearElementCaches();
			rcqBXlFvThOIzUYEKRmQDTmyRyd();
			PXEXrnDRygAuZueqSOcmNrpLWNJ();
		}

		private void PXEXrnDRygAuZueqSOcmNrpLWNJ()
		{
			if (!_manageRaycasting)
			{
				while (true)
				{
					switch (0x3E6CD4E5 ^ 0x3E6CD4E4)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			oKOYxtmhgFlYCzGLRiOQfDoBOXL.PdlrGNXpCBECJtKEwhNmSCcHIIa(base.transform, dpUcCTWbxZTIQEahDbeeBsyhVEX());
		}

		private bool dpUcCTWbxZTIQEahDbeeBsyhVEX()
		{
			if (iQmFiDmmCiNwWeIdWsidKUZRDib != null && _useTouchRegionOnly)
			{
				return false;
			}
			return true;
		}

		private void WwYJCDMlbisayAqaWBeBNPJzvOX(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				WdJoLlSYdebiQOSJXPJdQvBdeZx(P_0);
				int num = 535842379;
				while (true)
				{
					switch (num ^ 0x1FF04E49)
					{
					case 0:
						num = 535842381;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						P_0.PointerDownEvent += AyoEjrMMNOOkuaSctItwyzHQsaJ;
						P_0.PointerUpEvent += pCiTtuZbGZMrbTGZfOtwxRNbNRF;
						num = 535842378;
						continue;
					case 3:
						P_0.PointerEnterEvent += hlqIuMOCvpmOFxFCvgLNQJHJcCdE;
						P_0.PointerExitEvent += shdDotNgJorBUprfkABOaHDWPST;
						num = 535842376;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void WdJoLlSYdebiQOSJXPJdQvBdeZx(TouchRegion P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				P_0.PointerDownEvent -= AyoEjrMMNOOkuaSctItwyzHQsaJ;
				P_0.PointerUpEvent -= pCiTtuZbGZMrbTGZfOtwxRNbNRF;
				int num = -1252488622;
				while (true)
				{
					switch (num ^ -1252488624)
					{
					case 0:
						goto IL_000a;
					case 1:
						break;
					default:
						P_0.PointerEnterEvent -= hlqIuMOCvpmOFxFCvgLNQJHJcCdE;
						P_0.PointerExitEvent -= shdDotNgJorBUprfkABOaHDWPST;
						return;
					}
					break;
					IL_000a:
					num = -1252488623;
				}
			}
		}

		private void rcqBXlFvThOIzUYEKRmQDTmyRyd()
		{
			if (!(iQmFiDmmCiNwWeIdWsidKUZRDib == _touchRegion))
			{
				WdJoLlSYdebiQOSJXPJdQvBdeZx(iQmFiDmmCiNwWeIdWsidKUZRDib);
				iQmFiDmmCiNwWeIdWsidKUZRDib = _touchRegion;
				WwYJCDMlbisayAqaWBeBNPJzvOX(iQmFiDmmCiNwWeIdWsidKUZRDib);
			}
		}

		private void YuLONUCioDONtByhpbAhNihDhuS(Vector2 P_0, bool P_1, float P_2, bBKAXIbGOthvKVyNPUqrLhbuauJv P_3)
		{
			RectTransform rectTransform = base.transform.parent as RectTransform;
			while (true)
			{
				int num = 1704364189;
				while (true)
				{
					Vector2 vector;
					switch (num ^ 0x6596889C)
					{
					case 2:
						break;
					default:
						return;
					case 1:
					{
						vector = LOMeYMhHKyjSwUDqvWYJlrErQKH.wNaIZGSpgwpXpwwUzSBRpejVUBJ(base.canvas, rectTransform, P_0);
						Vector2 pivot = base.rectTransform.pivot;
						Vector2 sizeDelta = base.rectTransform.sizeDelta;
						Vector3 localScale = base.rectTransform.localScale;
						vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
						num = 1704364188;
						continue;
					}
					case 0:
						WMSsfkMLKlhjcjelurBOcNZuvNX(vector, PositionType.AXriQuEBFZCYarVPplCATARGxpw, P_1, P_2, P_3);
						num = 1704364191;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void WMSsfkMLKlhjcjelurBOcNZuvNX(Vector2 P_0, PositionType P_1, bool P_2, float P_3, bBKAXIbGOthvKVyNPUqrLhbuauJv P_4)
		{
			if (MOkeHydsYmBjWMGbpaGUIHYmfacO && P_2 && LmMNeqLluRSDEVqFGoHkNPrrvDL == P_4)
			{
				return;
			}
			Vector2 one = default(Vector2);
			Transform parent = default(Transform);
			RectTransform rectTransform = default(RectTransform);
			float num4 = default(float);
			float num5 = default(float);
			while (true)
			{
				int num;
				if (MOkeHydsYmBjWMGbpaGUIHYmfacO)
				{
					int num2;
					if (wWUdDrDMDWpYUxNLcnnKBLIAOkS != null)
					{
						num = -1622690030;
						num2 = num;
					}
					else
					{
						num = -1622690037;
						num2 = num;
					}
					goto IL_0024;
				}
				goto IL_02e9;
				IL_0024:
				while (true)
				{
					float num3;
					switch (num ^ -1622690020)
					{
					case 0:
						num = -1622690035;
						continue;
					case 21:
						one.y *= parent.localScale.y;
						num = -1622690021;
						continue;
					case 15:
					{
						Vector2 sizeDelta = rectTransform.sizeDelta;
						bool flag = sizeDelta.x < sizeDelta.y;
						num4 = MathTools.Max(sizeDelta.x, sizeDelta.y);
						if (!flag)
						{
							num = -1622690019;
							continue;
						}
						num3 = one.y;
						goto IL_0290;
					}
					case 7:
						break;
					case 3:
						P_2 = false;
						num = -1622690032;
						continue;
					case 17:
						goto end_IL_0024;
					case 14:
						KcecMEVnboRrodQNOWiPXeBBDUA();
						MOkeHydsYmBjWMGbpaGUIHYmfacO = false;
						LmMNeqLluRSDEVqFGoHkNPrrvDL = bBKAXIbGOthvKVyNPUqrLhbuauJv.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
						num = -1622690037;
						continue;
					case 16:
						P_2 = false;
						num = -1622690038;
						continue;
					case 6:
						num = -1622690021;
						continue;
					case 4:
						LmMNeqLluRSDEVqFGoHkNPrrvDL = P_4;
						num = -1622690026;
						continue;
					case 10:
						LCMJNNIhlrvlECcQiHKWEDSFCjJG = true;
						moveStartedDelegate(P_4);
						return;
					case 2:
						P_3 = P_3 / num5 * num4;
						wWUdDrDMDWpYUxNLcnnKBLIAOkS = IqFGDnenIQKacibNEdiWcGInRzSU(P_0, P_1, P_3, P_4);
						num = -1622690040;
						continue;
					case 11:
						parent = base.transform;
						rectTransform = base.canvasTransform;
						one = Vector2.one;
						num = -1622690022;
						continue;
					case 19:
						goto IL_01f8;
					case 22:
						num = -1622690032;
						continue;
					case 13:
						Logger.LogWarning("Animation can only be used with a screen space Canvas.");
						num = -1622690017;
						continue;
					case 5:
						goto IL_0238;
					case 8:
						Logger.LogWarning("Animation cannot be used without a Canvas.");
						num = -1622690036;
						continue;
					case 20:
						StartCoroutine(wWUdDrDMDWpYUxNLcnnKBLIAOkS);
						num = -1622690024;
						continue;
					case 1:
						num3 = one.x;
						goto IL_0290;
					case 12:
						goto IL_02af;
					case 18:
						one.x *= parent.localScale.x;
						num = -1622690039;
						continue;
					case 23:
						goto IL_02e9;
					default:
						{
							moveStartedDelegate(P_4);
							shENDFotJKEDucBZRyRFORLMigTa(P_4, P_0, P_1);
							return;
						}
						IL_0290:
						num5 = num3;
						if (num5 == 0f)
						{
							num5 = 0.0001f;
							num = -1622690018;
							continue;
						}
						goto case 2;
					}
					int num6;
					if (!((parent = parent.parent) != rectTransform))
					{
						num = -1622690029;
						num6 = num;
					}
					else
					{
						num = -1622690023;
						num6 = num;
					}
					continue;
					IL_02af:
					int num7;
					if (!P_2)
					{
						num = -1622690027;
						num7 = num;
					}
					else
					{
						num = -1622690025;
						num7 = num;
					}
					continue;
					IL_01f8:
					int num8;
					if (base.canvas.renderMode != RenderMode.WorldSpace)
					{
						num = -1622690032;
						num8 = num;
					}
					else
					{
						num = -1622690031;
						num8 = num;
					}
					continue;
					IL_0238:
					int num9;
					if (!(parent == null))
					{
						num = -1622690034;
						num9 = num;
					}
					else
					{
						num = -1622690029;
						num9 = num;
					}
					continue;
					end_IL_0024:
					break;
				}
				continue;
				IL_02e9:
				int num10;
				if (!(base.canvas == null))
				{
					num = -1622690033;
					num10 = num;
				}
				else
				{
					num = -1622690028;
					num10 = num;
				}
				goto IL_0024;
			}
		}

		private IEnumerator IqFGDnenIQKacibNEdiWcGInRzSU(Vector2 P_0, PositionType P_1, float P_2, bBKAXIbGOthvKVyNPUqrLhbuauJv P_3)
		{
			ftoREUCQafdPadJVMjjWDpcvrOEb ftoREUCQafdPadJVMjjWDpcvrOEb2 = new ftoREUCQafdPadJVMjjWDpcvrOEb(0);
			while (true)
			{
				int num = -427467149;
				while (true)
				{
					switch (num ^ -427467152)
					{
					case 0:
						break;
					case 1:
						ftoREUCQafdPadJVMjjWDpcvrOEb2.juGAuHQJxyCbGveDiDRabDWTpiv = P_2;
						num = -427467148;
						continue;
					case 4:
						ftoREUCQafdPadJVMjjWDpcvrOEb2.JoWgWEHKMpkeOadbbkLgIsuWZgn = P_3;
						num = -427467147;
						continue;
					case 3:
						ftoREUCQafdPadJVMjjWDpcvrOEb2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
						num = -427467150;
						continue;
					case 2:
						ftoREUCQafdPadJVMjjWDpcvrOEb2.gbejOQIayEZKbGyCZpFoaaiiUxS = P_0;
						ftoREUCQafdPadJVMjjWDpcvrOEb2.oDHiqonMoiufKKpGJbNyiKpUZHE = P_1;
						num = -427467151;
						continue;
					default:
						return ftoREUCQafdPadJVMjjWDpcvrOEb2;
					}
					break;
				}
			}
		}

		private void shENDFotJKEDucBZRyRFORLMigTa(bBKAXIbGOthvKVyNPUqrLhbuauJv P_0, Vector2 P_1, PositionType P_2)
		{
			LOMeYMhHKyjSwUDqvWYJlrErQKH.UprvgqxthkUgaQeUXArWMBZlDPh(base.rectTransform, P_1, P_2);
			MOkeHydsYmBjWMGbpaGUIHYmfacO = false;
			while (true)
			{
				int num = 1928635280;
				while (true)
				{
					switch (num ^ 0x72F4A391)
					{
					case 3:
						break;
					case 4:
					{
						int num3;
						if (P_0 != bBKAXIbGOthvKVyNPUqrLhbuauJv.yrNPjkUJApZCVhMgUIDiTGAJeil)
						{
							num = 1928635283;
							num3 = num;
						}
						else
						{
							num = 1928635284;
							num3 = num;
						}
						continue;
					}
					case 0:
						LCMJNNIhlrvlECcQiHKWEDSFCjJG = false;
						num = 1928635283;
						continue;
					case 1:
					{
						LmMNeqLluRSDEVqFGoHkNPrrvDL = bBKAXIbGOthvKVyNPUqrLhbuauJv.XHUTYEIfTgeCBgXrVRVbPfGzuhN;
						int num2;
						if (P_0 == bBKAXIbGOthvKVyNPUqrLhbuauJv.ZHOJKsdjqeTbuCznzGjkgQECHhx)
						{
							num = 1928635281;
							num2 = num;
						}
						else
						{
							num = 1928635285;
							num2 = num;
						}
						continue;
					}
					case 5:
						LCMJNNIhlrvlECcQiHKWEDSFCjJG = true;
						num = 1928635283;
						continue;
					default:
						KcecMEVnboRrodQNOWiPXeBBDUA();
						moveEndedDelegate(P_0);
						return;
					}
					break;
				}
			}
		}

		private void ygmgHpsoczoktCqokJEUBknCWlz(bBKAXIbGOthvKVyNPUqrLhbuauJv P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag2 = default(bool);
			bool flag = default(bool);
			while (true)
			{
				int num = -1573952253;
				while (true)
				{
					switch (num ^ -1573952249)
					{
					case 3:
						break;
					default:
						return;
					case 5:
						if (_returnOnRelease && P_0 == bBKAXIbGOthvKVyNPUqrLhbuauJv.yrNPjkUJApZCVhMgUIDiTGAJeil)
						{
							flag2 = true;
							flag = false;
							num = -1573952256;
							continue;
						}
						goto case 7;
					case 0:
					{
						int num3;
						if (!stayActiveOnSwipeOut)
						{
							num = -1573952251;
							num3 = num;
						}
						else
						{
							num = -1573952254;
							num3 = num;
						}
						continue;
					}
					case 7:
						if (flag2)
						{
							oKOYxtmhgFlYCzGLRiOQfDoBOXL.PdlrGNXpCBECJtKEwhNmSCcHIIa(base.transform, flag);
							num = -1573952250;
							continue;
						}
						return;
					case 4:
						flag2 = false;
						num = -1573952255;
						continue;
					case 2:
						if (!_followTouchPosition && iQmFiDmmCiNwWeIdWsidKUZRDib != null && !_useTouchRegionOnly)
						{
							int num4;
							if (!_moveToTouchPosition)
							{
								num = -1573952256;
								num4 = num;
							}
							else
							{
								num = -1573952254;
								num4 = num;
							}
							continue;
						}
						goto case 7;
					case 6:
					{
						flag = false;
						int num2;
						if (!_followTouchPosition)
						{
							num = -1573952251;
							num2 = num;
						}
						else
						{
							num = -1573952249;
							num2 = num;
						}
						continue;
					}
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void hMLWOTCnUeECHkZYcVMttLBlZZs(bBKAXIbGOthvKVyNPUqrLhbuauJv P_0)
		{
			if (!_manageRaycasting)
			{
				return;
			}
			bool flag2 = default(bool);
			bool flag = default(bool);
			while (true)
			{
				int num = -987134698;
				while (true)
				{
					switch (num ^ -987134690)
					{
					case 4:
						break;
					default:
						return;
					case 1:
					{
						int num3;
						if (!(iQmFiDmmCiNwWeIdWsidKUZRDib != null))
						{
							num = -987134695;
							num3 = num;
						}
						else
						{
							num = -987134693;
							num3 = num;
						}
						continue;
					}
					case 3:
						flag2 = true;
						num = -987134696;
						continue;
					case 8:
						flag2 = false;
						flag = false;
						if (_followTouchPosition)
						{
							int num5;
							if (!stayActiveOnSwipeOut)
							{
								num = -987134697;
								num5 = num;
							}
							else
							{
								num = -987134690;
								num5 = num;
							}
							continue;
						}
						goto case 9;
					case 7:
						if (flag2)
						{
							oKOYxtmhgFlYCzGLRiOQfDoBOXL.PdlrGNXpCBECJtKEwhNmSCcHIIa(base.transform, flag);
							num = -987134692;
							continue;
						}
						return;
					case 6:
						flag = dpUcCTWbxZTIQEahDbeeBsyhVEX();
						num = -987134695;
						continue;
					case 9:
					{
						int num6;
						if (_followTouchPosition)
						{
							num = -987134695;
							num6 = num;
						}
						else
						{
							num = -987134689;
							num6 = num;
						}
						continue;
					}
					case 0:
						if (_returnOnRelease)
						{
							int num4;
							if (P_0 != bBKAXIbGOthvKVyNPUqrLhbuauJv.ZHOJKsdjqeTbuCznzGjkgQECHhx)
							{
								num = -987134695;
								num4 = num;
							}
							else
							{
								num = -987134691;
								num4 = num;
							}
							continue;
						}
						goto case 7;
					case 5:
						if (!_useTouchRegionOnly)
						{
							int num2;
							if (_moveToTouchPosition)
							{
								num = -987134690;
								num2 = num;
							}
							else
							{
								num = -987134695;
								num2 = num;
							}
							continue;
						}
						goto case 7;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void xdUAfaJdefyUTchrjmQTwhnQniy(int P_0)
		{
			if (!TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(P_0))
			{
				return;
			}
			while (true)
			{
				YuLONUCioDONtByhpbAhNihDhuS(TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(P_0), false, 0f, bBKAXIbGOthvKVyNPUqrLhbuauJv.yrNPjkUJApZCVhMgUIDiTGAJeil);
				int num = 1860604521;
				while (true)
				{
					switch (num ^ 0x6EE6926B)
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
					num = 1860604522;
				}
			}
		}

		private void KcecMEVnboRrodQNOWiPXeBBDUA()
		{
			if (wWUdDrDMDWpYUxNLcnnKBLIAOkS != null)
			{
				try
				{
					StopCoroutine(wWUdDrDMDWpYUxNLcnnKBLIAOkS);
				}
				catch
				{
				}
				wWUdDrDMDWpYUxNLcnnKBLIAOkS = null;
			}
		}

		private void UcvgzyHjPLrcamsdZskkPOQcONwi()
		{
			if (!hasPointer)
			{
				return;
			}
			while (!TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
			{
				PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(effectivePointerId);
				int num;
				if (pointerEventData != null)
				{
					int num2;
					if (pointerEventData.pointerPress != null)
					{
						num = 692543562;
						num2 = num;
					}
					else
					{
						num = 692543564;
						num2 = num;
					}
					goto IL_000e;
				}
				goto IL_006b;
				IL_006b:
				lpCghgdvtFwpLBkUsSpPyavhpiK();
				num = 692543566;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x2947604E)
					{
					case 3:
						num = 692543567;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						goto IL_006b;
					case 4:
						yexpQprndcKAWRDGCPOiDjHZJQS(pointerEventData);
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private bool yPLpJvfMgnznJgRUbpowGjMhQZr()
		{
			if (!_followTouchPosition)
			{
				goto IL_0008;
			}
			int num;
			if (_touchRegion != null && _useTouchRegionOnly)
			{
				num = 1121394611;
				goto IL_000d;
			}
			return true;
			IL_000d:
			switch (num ^ 0x42D71FB3)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0008;
			IL_0008:
			num = 1121394610;
			goto IL_000d;
		}

		private void OmMQSyoLmaJHYrXPeNoBnwkIRXA()
		{
			HvkclJglniOXcnrWcckuOPsHKFa = int.MinValue;
			wUaATdmWscCtdMBeYMUAghqpCele = int.MinValue;
		}

		private bool rtBocUdjipCXKhkfukoKkICxgqh(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (HvkclJglniOXcnrWcckuOPsHKFa == int.MinValue)
			{
				return false;
			}
			if (HvkclJglniOXcnrWcckuOPsHKFa == P_0)
			{
				return true;
			}
			if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0) && wUaATdmWscCtdMBeYMUAghqpCele != int.MinValue && P_0 == wUaATdmWscCtdMBeYMUAghqpCele)
			{
				return true;
			}
			return false;
		}

		private PointerEventData VeJANUaZIhfuukBBgCAhDSXJcuGp(int P_0, GameObject P_1)
		{
			PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(P_0);
			if (pointerEventData == null)
			{
				return null;
			}
			pointerEventData.position = TouchInteractable.cpmXsthbnFhxHDTcLoXFmpmGBNKS(P_0);
			if (TouchInteractable.MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
			{
				pointerEventData.eligibleForClick = true;
				goto IL_0032;
			}
			goto IL_0102;
			IL_0300:
			Logger.LogWarning("Unsupported pointerId: " + P_0);
			return null;
			IL_0102:
			int num;
			if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
			{
				pointerEventData.eligibleForClick = true;
				pointerEventData.delta = Vector2.zero;
				num = -1495907083;
				goto IL_0037;
			}
			goto IL_0300;
			IL_0032:
			num = -1495907084;
			goto IL_0037;
			IL_0037:
			float unscaledTime2 = default(float);
			GameObject gameObject = default(GameObject);
			float num2 = default(float);
			GameObject gameObject2 = default(GameObject);
			float unscaledTime = default(float);
			float num3 = default(float);
			while (true)
			{
				switch (num ^ -1495907086)
				{
				case 9:
					break;
				case 20:
					unscaledTime2 = Time.unscaledTime;
					if (gameObject == pointerEventData.lastPress)
					{
						num2 = unscaledTime2 - pointerEventData.clickTime;
						num = -1495907088;
						continue;
					}
					goto case 8;
				case 21:
					gameObject2 = P_1;
					unscaledTime = Time.unscaledTime;
					if (gameObject2 == pointerEventData.lastPress)
					{
						num3 = unscaledTime - pointerEventData.clickTime;
						num = -1495907080;
						continue;
					}
					goto case 22;
				case 18:
					goto IL_0102;
				case 7:
					pointerEventData.dragging = false;
					pointerEventData.useDragThreshold = true;
					num = -1495907099;
					continue;
				case 13:
					pointerEventData.pointerPress = gameObject2;
					num = -1495907101;
					continue;
				case 3:
					gameObject = P_1;
					num = -1495907098;
					continue;
				case 11:
					pointerEventData.clickTime = unscaledTime2;
					num = -1495907074;
					continue;
				case 5:
					pointerEventData.clickCount++;
					num = -1495907076;
					continue;
				case 10:
					goto IL_0189;
				case 12:
					pointerEventData.pointerPress = gameObject;
					pointerEventData.rawPointerPress = P_1;
					pointerEventData.clickTime = unscaledTime2;
					pointerEventData.pointerDrag = P_1;
					goto IL_0317;
				case 6:
					pointerEventData.delta = Vector2.zero;
					pointerEventData.dragging = false;
					num = -1495907103;
					continue;
				case 17:
					pointerEventData.rawPointerPress = P_1;
					pointerEventData.clickTime = unscaledTime;
					pointerEventData.pointerDrag = P_1;
					goto IL_0317;
				case 8:
					pointerEventData.clickCount = 1;
					num = -1495907074;
					continue;
				case 22:
					pointerEventData.clickCount = 1;
					num = -1495907073;
					continue;
				case 1:
					pointerEventData.clickCount = 1;
					num = -1495907076;
					continue;
				case 0:
					pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
					if (pointerEventData.pointerEnter != P_1)
					{
						pointerEventData.pointerEnter = P_1;
						num = -1495907097;
						continue;
					}
					goto case 21;
				case 4:
					num = -1495907079;
					continue;
				case 2:
					if (num2 < 0.3f)
					{
						pointerEventData.clickCount++;
						num = -1495907082;
						continue;
					}
					goto case 15;
				case 15:
					pointerEventData.clickCount = 1;
					num = -1495907079;
					continue;
				case 23:
					pointerEventData.pressPosition = pointerEventData.position;
					pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
					num = -1495907087;
					continue;
				case 14:
					pointerEventData.clickTime = unscaledTime;
					num = -1495907073;
					continue;
				case 19:
					pointerEventData.useDragThreshold = true;
					pointerEventData.pressPosition = pointerEventData.position;
					num = -1495907086;
					continue;
				default:
					goto IL_0300;
					IL_0317:
					return pointerEventData;
				}
				break;
				IL_0189:
				int num4;
				if (num3 >= 0.3f)
				{
					num = -1495907085;
					num4 = num;
				}
				else
				{
					num = -1495907081;
					num4 = num;
				}
			}
			goto IL_0032;
		}

		private PointerEventData WWBaWpsvmKBDDDdyzjqZKoKTVkj(int P_0)
		{
			PointerEventData pointerEventData = eVclGdybysCFPcOarpTxhdEPClmv(P_0);
			while (true)
			{
				int num = 1411292708;
				while (true)
				{
					switch (num ^ 0x541E9E22)
					{
					case 0:
						break;
					case 7:
					{
						int num3;
						if (!TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
						{
							num = 1411292705;
							num3 = num;
						}
						else
						{
							num = 1411292707;
							num3 = num;
						}
						continue;
					}
					case 1:
						pointerEventData.eligibleForClick = false;
						num = 1411292714;
						continue;
					case 8:
						pointerEventData.pointerPress = null;
						pointerEventData.rawPointerPress = null;
						num = 1411292711;
						continue;
					case 6:
					{
						if (pointerEventData == null)
						{
							return null;
						}
						int num2;
						if (!TouchInteractable.MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
						{
							num = 1411292709;
							num2 = num;
						}
						else
						{
							num = 1411292710;
							num2 = num;
						}
						continue;
					}
					case 5:
						pointerEventData.dragging = false;
						pointerEventData.pointerDrag = null;
						goto IL_010f;
					case 4:
						pointerEventData.eligibleForClick = false;
						pointerEventData.pointerPress = null;
						pointerEventData.rawPointerPress = null;
						pointerEventData.dragging = false;
						pointerEventData.pointerDrag = null;
						num = 1411292704;
						continue;
					case 2:
						pointerEventData.pointerEnter = null;
						goto IL_010f;
					default:
						{
							Logger.LogWarning("Unsupported pointerId: " + P_0);
							return null;
						}
						IL_010f:
						return pointerEventData;
					}
					break;
				}
			}
		}

		private void yexpQprndcKAWRDGCPOiDjHZJQS(PointerEventData P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = 2045489982;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x79EBB33F)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_002d;
			case 3:
				return;
			}
			goto IL_0003;
			IL_002d:
			OnPointerUp(P_0);
			WWBaWpsvmKBDDDdyzjqZKoKTVkj(effectivePointerId);
			num = 2045489980;
			goto IL_0008;
		}

		private PointerEventData eVclGdybysCFPcOarpTxhdEPClmv(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				goto IL_0008;
			}
			int num;
			if (vlrRIXQCCHSpLGkTSgbxdZoiFgD == null)
			{
				vlrRIXQCCHSpLGkTSgbxdZoiFgD = new Dictionary<int, PointerEventData>();
				num = 187665085;
				goto IL_000d;
			}
			goto IL_0070;
			IL_0124:
			PointerEventData value = default(PointerEventData);
			return value;
			IL_0070:
			if (!vlrRIXQCCHSpLGkTSgbxdZoiFgD.TryGetValue(P_0, out value))
			{
				value = new PointerEventData(EventSystem.current);
				num = 187665081;
				goto IL_000d;
			}
			goto IL_0124;
			IL_0008:
			num = 187665080;
			goto IL_000d;
			IL_000d:
			PointerEventData.InputButton button = default(PointerEventData.InputButton);
			while (true)
			{
				switch (num ^ 0xB2F8AB9)
				{
				case 9:
					break;
				case 1:
					return null;
				case 2:
					num = 187665086;
					continue;
				case 4:
					goto IL_0070;
				case 5:
					button = PointerEventData.InputButton.Left;
					num = 187665083;
					continue;
				case 6:
					throw new NotImplementedException();
				case 8:
					goto IL_00b4;
				case 0:
					value.pointerId = P_0;
					vlrRIXQCCHSpLGkTSgbxdZoiFgD.Add(P_0, value);
					if (TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
					{
						switch (P_0)
						{
						case -1:
							break;
						case -2:
							goto IL_00b4;
						default:
							goto IL_00f3;
						case -3:
							goto IL_00fd;
						}
						goto case 5;
					}
					goto IL_0124;
				case 11:
					goto IL_00fd;
				case 7:
					value.button = button;
					num = 187665082;
					continue;
				case 10:
					num = 187665086;
					continue;
				default:
					goto IL_0124;
					IL_00fd:
					button = PointerEventData.InputButton.Middle;
					num = 187665086;
					continue;
					IL_00f3:
					num = 187665087;
					continue;
					IL_00b4:
					button = PointerEventData.InputButton.Right;
					num = 187665075;
					continue;
				}
				break;
			}
			goto IL_0008;
		}

		private void VMPxCmwNDckEZjKzFAfOOLwMEyj(PointerEventData P_0, jfWoaSDxXqJmQriNWFwYxpUbATB P_1)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0040;
			IL_0008:
			int num = -665335715;
			goto IL_000d;
			IL_000d:
			switch (num ^ -665335714)
			{
			case 2:
				break;
			case 3:
				if (!rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
				{
					return;
				}
				goto IL_0040;
			case 0:
				goto IL_0040;
			default:
				goto IL_006a;
			}
			goto IL_0008;
			IL_006a:
			base.OnPointerDown(P_0);
			return;
			IL_0040:
			if (pmYjhUyltIKROfKAKRLTAORpQYO() && IsInteractable())
			{
				qttGoWavQZHOZLyJsMtdmpSFVQLR(P_0.pointerId, P_0.pressPosition, P_1);
				num = -665335713;
				goto IL_000d;
			}
			goto IL_006a;
		}

		private void gkFDUotSecrQghkuzcszQbTklVO(PointerEventData P_0, jfWoaSDxXqJmQriNWFwYxpUbATB P_1)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (TouchInteractable.PYUTplsvvKimYgNZKiMZNosbrtO(effectivePointerId))
				{
					num = -1747046215;
					num2 = num;
				}
				else
				{
					num = -1747046213;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1747046216)
					{
					case 0:
						goto IL_0017;
					case 2:
						break;
					case 1:
						return;
					default:
						lpCghgdvtFwpLBkUsSpPyavhpiK();
						base.OnPointerUp(P_0);
						return;
					}
					break;
					IL_0017:
					num = -1747046214;
				}
			}
		}

		private void yVatkfTlebiCIFaVPbRrioxyjVJ(PointerEventData P_0, jfWoaSDxXqJmQriNWFwYxpUbATB P_1)
		{
			if (hasPointer && !rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
			{
				goto IL_001c;
			}
			goto IL_0145;
			IL_0145:
			bool flag = TouchInteractable.LVbAAmZsiNVWVEZvWStcjqdZghy(P_0.pointerId);
			int num = -806071997;
			goto IL_0021;
			IL_001c:
			num = -806071993;
			goto IL_0021;
			IL_0021:
			int num2 = default(int);
			MouseButtonFlags mouseButtonFlags = default(MouseButtonFlags);
			GameObject gameObject = default(GameObject);
			PointerEventData pointerEventData = default(PointerEventData);
			jfWoaSDxXqJmQriNWFwYxpUbATB jfWoaSDxXqJmQriNWFwYxpUbATB3 = default(jfWoaSDxXqJmQriNWFwYxpUbATB);
			jfWoaSDxXqJmQriNWFwYxpUbATB jfWoaSDxXqJmQriNWFwYxpUbATB2 = default(jfWoaSDxXqJmQriNWFwYxpUbATB);
			bool flag2 = default(bool);
			while (true)
			{
				switch (num ^ -806071984)
				{
				case 2:
					break;
				case 5:
					wUaATdmWscCtdMBeYMUAghqpCele = num2;
					num = -806071970;
					continue;
				case 17:
					mouseButtonFlags = base.allowedMouseButtons;
					num = -806071998;
					continue;
				case 13:
					gameObject = base.gameObject;
					num = -806071980;
					continue;
				case 4:
					pointerEventData = VeJANUaZIhfuukBBgCAhDSXJcuGp((wUaATdmWscCtdMBeYMUAghqpCele != int.MinValue) ? wUaATdmWscCtdMBeYMUAghqpCele : P_0.pointerId, gameObject);
					num = -806071995;
					continue;
				case 24:
					wUaATdmWscCtdMBeYMUAghqpCele = P_0.pointerId;
					num = -806071970;
					continue;
				case 16:
					switch (jfWoaSDxXqJmQriNWFwYxpUbATB3)
					{
					case jfWoaSDxXqJmQriNWFwYxpUbATB.AXriQuEBFZCYarVPplCATARGxpw:
						break;
					default:
						goto IL_011d;
					case jfWoaSDxXqJmQriNWFwYxpUbATB.ocnclNbRoiITlrFWknqquxusEpr:
						goto IL_0243;
					}
					goto case 13;
				case 1:
					goto IL_0127;
				case 12:
					goto IL_0145;
				case 3:
					throw new NotImplementedException();
				case 0:
					if ((flag && !TouchInteractable.oZwvzbhTHFLSrWQmffrxbbIJDii(mouseButtonFlags)) || deteGKFsUpKVtiobsxDnfbVWHkL)
					{
						goto IL_0127;
					}
					if (flag)
					{
						goto IL_0187;
					}
					goto case 14;
				case 10:
					goto IL_01a5;
				case 8:
					switch (jfWoaSDxXqJmQriNWFwYxpUbATB2)
					{
					case jfWoaSDxXqJmQriNWFwYxpUbATB.AXriQuEBFZCYarVPplCATARGxpw:
						break;
					case jfWoaSDxXqJmQriNWFwYxpUbATB.ocnclNbRoiITlrFWknqquxusEpr:
						goto IL_01a5;
					default:
						goto IL_01ca;
					}
					goto case 17;
				case 9:
					throw new NotImplementedException();
				case 6:
					jfWoaSDxXqJmQriNWFwYxpUbATB3 = P_1;
					num = -806072000;
					continue;
				case 21:
					if (pointerEventData != null)
					{
						VMPxCmwNDckEZjKzFAfOOLwMEyj(pointerEventData, P_1);
						num = -806071996;
						continue;
					}
					goto default;
				case 7:
					num = -806071981;
					continue;
				case 22:
					jfWoaSDxXqJmQriNWFwYxpUbATB2 = P_1;
					num = -806071976;
					continue;
				case 11:
					num = -806071998;
					continue;
				case 19:
					flag2 = false;
					num = -806071994;
					continue;
				case 23:
					return;
				case 15:
					goto IL_0243;
				case 14:
					flag2 = true;
					num = -806071983;
					continue;
				case 18:
					goto IL_0266;
				default:
					{
						IflsmAOKUdJKTpCZjpeDsuqZbjM = true;
						return;
					}
					IL_01ca:
					num = -806071975;
					continue;
					IL_01a5:
					mouseButtonFlags = _touchRegion.allowedMouseButtons;
					num = -806071973;
					continue;
					IL_0243:
					gameObject = iQmFiDmmCiNwWeIdWsidKUZRDib.gameObject;
					num = -806071980;
					continue;
					IL_011d:
					num = -806071977;
					continue;
				}
				break;
				IL_0266:
				if (_activateOnSwipeIn && pmYjhUyltIKROfKAKRLTAORpQYO())
				{
					int num3;
					if (!IsInteractable())
					{
						num = -806071983;
						num3 = num;
					}
					else
					{
						num = -806071984;
						num3 = num;
					}
					continue;
				}
				goto IL_0127;
				IL_0187:
				int num4;
				if (TouchInteractable.uvgPsLARFwGrvuIJCgcCjshzWDCu(mouseButtonFlags, out num2))
				{
					num = -806071979;
					num4 = num;
				}
				else
				{
					num = -806071992;
					num4 = num;
				}
				continue;
				IL_0127:
				base.OnPointerEnter(P_0);
				int num5;
				if (!flag2)
				{
					num = -806071996;
					num5 = num;
				}
				else
				{
					num = -806071978;
					num5 = num;
				}
			}
			goto IL_001c;
		}

		private void UNMauMeXBncuatcyFyBICUuhBxd(PointerEventData P_0, jfWoaSDxXqJmQriNWFwYxpUbATB P_1)
		{
			if (hasPointer)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -1656658804;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1656658807)
				{
				case 0:
					break;
				case 3:
					goto IL_0036;
				case 1:
					lpCghgdvtFwpLBkUsSpPyavhpiK();
					num = -1656658803;
					continue;
				case 6:
					goto IL_005c;
				case 5:
					if (!rtBocUdjipCXKhkfukoKkICxgqh(P_0.pointerId))
					{
						base.OnPointerExit(P_0);
						num = -1656658805;
						continue;
					}
					goto IL_0036;
				case 2:
					return;
				default:
					base.OnPointerExit(P_0);
					IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
					return;
				}
				break;
				IL_005c:
				int num2;
				if (!deteGKFsUpKVtiobsxDnfbVWHkL)
				{
					num = -1656658803;
					num2 = num;
				}
				else
				{
					num = -1656658808;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0036:
			int num3;
			if (!stayActiveOnSwipeOut)
			{
				num = -1656658801;
				num3 = num;
			}
			else
			{
				num = -1656658803;
				num3 = num;
			}
			goto IL_000d;
		}

		private void qttGoWavQZHOZLyJsMtdmpSFVQLR(int P_0, Vector2 P_1, jfWoaSDxXqJmQriNWFwYxpUbATB P_2)
		{
			HvkclJglniOXcnrWcckuOPsHKFa = P_0;
			deteGKFsUpKVtiobsxDnfbVWHkL = true;
			if (_followTouchPosition)
			{
				goto IL_0016;
			}
			goto IL_0057;
			IL_0016:
			int num = -1287021306;
			goto IL_001b;
			IL_001b:
			while (true)
			{
				switch (num ^ -1287021305)
				{
				case 3:
					break;
				case 4:
					YuLONUCioDONtByhpbAhNihDhuS(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, bBKAXIbGOthvKVyNPUqrLhbuauJv.yrNPjkUJApZCVhMgUIDiTGAJeil);
					num = -1287021307;
					continue;
				case 0:
					goto IL_0057;
				case 1:
					xdUAfaJdefyUTchrjmQTwhnQniy(P_0);
					num = -1287021307;
					continue;
				default:
					goto IL_0082;
				}
				break;
			}
			goto IL_0016;
			IL_0057:
			if (P_2 == jfWoaSDxXqJmQriNWFwYxpUbATB.ocnclNbRoiITlrFWknqquxusEpr)
			{
				int num2;
				if (_moveToTouchPosition)
				{
					num = -1287021309;
					num2 = num;
				}
				else
				{
					num = -1287021307;
					num2 = num;
				}
				goto IL_001b;
			}
			goto IL_0082;
			IL_0082:
			WdDwWQpMwConxaplaHaGTbZhHMH();
		}

		private void lpCghgdvtFwpLBkUsSpPyavhpiK()
		{
			OmMQSyoLmaJHYrXPeNoBnwkIRXA();
			while (true)
			{
				int num = 1594411660;
				while (true)
				{
					switch (num ^ 0x5F08CA88)
					{
					case 2:
						break;
					case 3:
						if (_returnOnRelease)
						{
							int num3;
							if (LCMJNNIhlrvlECcQiHKWEDSFCjJG)
							{
								num = 1594411661;
								num3 = num;
							}
							else
							{
								num = 1594411657;
								num3 = num;
							}
							continue;
						}
						goto default;
					case 0:
						if (!_followTouchPosition)
						{
							int num2;
							if (_moveToTouchPosition)
							{
								num = 1594411659;
								num2 = num;
							}
							else
							{
								num = 1594411657;
								num2 = num;
							}
							continue;
						}
						goto case 3;
					case 5:
						ReturnToDefaultPosition();
						num = 1594411657;
						continue;
					case 4:
						deteGKFsUpKVtiobsxDnfbVWHkL = false;
						num = 1594411656;
						continue;
					default:
						UACbMsURobGiSXJDChXicxIcoWN();
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
			{
				while (true)
				{
					IL_0083:
					int num;
					int num2;
					if (iQmFiDmmCiNwWeIdWsidKUZRDib != null)
					{
						num = 330070232;
						num2 = num;
					}
					else
					{
						num = 330070234;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x13AC78DA)
						{
						case 3:
							num = 330070236;
							continue;
						default:
							return;
						case 6:
							break;
						case 4:
							return;
						case 0:
							VMPxCmwNDckEZjKzFAfOOLwMEyj(eventData, jfWoaSDxXqJmQriNWFwYxpUbATB.AXriQuEBFZCYarVPplCATARGxpw);
							num = 330070235;
							continue;
						case 2:
							goto IL_006a;
						case 5:
							goto IL_0083;
						case 1:
							return;
						}
						break;
						IL_006a:
						int num3;
						if (!_useTouchRegionOnly)
						{
							num = 330070234;
							num3 = num;
						}
						else
						{
							num = 330070238;
							num3 = num;
						}
					}
					break;
				}
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			if (base.initialized && TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(iQmFiDmmCiNwWeIdWsidKUZRDib != null) || !_useTouchRegionOnly))
			{
				gkFDUotSecrQghkuzcszQbTklVO(eventData, jfWoaSDxXqJmQriNWFwYxpUbATB.AXriQuEBFZCYarVPplCATARGxpw);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0042;
			IL_0008:
			int num = 1905378706;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x7191C593)
			{
			case 5:
				break;
			case 0:
				if (_useTouchRegionOnly)
				{
					return;
				}
				goto default;
			case 2:
				goto IL_0042;
			case 3:
				goto IL_005e;
			case 1:
				return;
			default:
				yVatkfTlebiCIFaVPbRrioxyjVJ(eventData, jfWoaSDxXqJmQriNWFwYxpUbATB.AXriQuEBFZCYarVPplCATARGxpw);
				return;
			}
			goto IL_0008;
			IL_005e:
			int num2;
			if (iQmFiDmmCiNwWeIdWsidKUZRDib != null)
			{
				num = 1905378707;
				num2 = num;
			}
			else
			{
				num = 1905378711;
				num2 = num;
			}
			goto IL_000d;
			IL_0042:
			if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			goto IL_005e;
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
			{
				while (true)
				{
					IL_004b:
					int num;
					int num2;
					if (!(iQmFiDmmCiNwWeIdWsidKUZRDib != null))
					{
						num = 56080084;
						num2 = num;
					}
					else
					{
						num = 56080082;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x357B6D0)
						{
						case 0:
							num = 56080083;
							continue;
						case 3:
							break;
						case 1:
							goto IL_004b;
						case 2:
							if (_useTouchRegionOnly)
							{
								return;
							}
							goto default;
						default:
							UNMauMeXBncuatcyFyBICUuhBxd(eventData, jfWoaSDxXqJmQriNWFwYxpUbATB.AXriQuEBFZCYarVPplCATARGxpw);
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void AyoEjrMMNOOkuaSctItwyzHQsaJ(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
				{
					num = 155424218;
					num2 = num;
				}
				else
				{
					num = 155424219;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x94395D8)
					{
					case 4:
						num = 155424217;
						continue;
					default:
						return;
					case 3:
						VMPxCmwNDckEZjKzFAfOOLwMEyj(P_0, jfWoaSDxXqJmQriNWFwYxpUbATB.ocnclNbRoiITlrFWknqquxusEpr);
						num = 155424216;
						continue;
					case 2:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void pCiTtuZbGZMrbTGZfOtwxRNbNRF(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
			{
				while (true)
				{
					IL_004c:
					gkFDUotSecrQghkuzcszQbTklVO(P_0, jfWoaSDxXqJmQriNWFwYxpUbATB.ocnclNbRoiITlrFWknqquxusEpr);
					int num = 1243796487;
					while (true)
					{
						switch (num ^ 0x4A22D404)
						{
						case 0:
							num = 1243796485;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							goto IL_004c;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void hlqIuMOCvpmOFxFCvgLNQJHJcCdE(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = 144611399;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x89E9843)
			{
			case 2:
				break;
			default:
				return;
			case 4:
				return;
			case 0:
				goto IL_0036;
			case 1:
				goto IL_0057;
			case 3:
				return;
			}
			goto IL_0008;
			IL_0036:
			if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			goto IL_0057;
			IL_0057:
			yVatkfTlebiCIFaVPbRrioxyjVJ(P_0, jfWoaSDxXqJmQriNWFwYxpUbATB.ocnclNbRoiITlrFWknqquxusEpr);
			num = 144611392;
			goto IL_000d;
		}

		private void shdDotNgJorBUprfkABOaHDWPST(PointerEventData P_0)
		{
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
				{
					num = -2015005762;
					num2 = num;
				}
				else
				{
					num = -2015005761;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2015005762)
					{
					case 2:
						goto IL_0009;
					case 3:
						break;
					case 0:
						return;
					default:
						UNMauMeXBncuatcyFyBICUuhBxd(P_0, jfWoaSDxXqJmQriNWFwYxpUbATB.ocnclNbRoiITlrFWknqquxusEpr);
						return;
					}
					break;
					IL_0009:
					num = -2015005763;
				}
			}
		}

		private void PmSBHqGtcObwsBsjhRGByRmNdVOn(float P_0)
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0045;
			IL_0008:
			int num = 1204105469;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x47C530FC)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					_onAxisValueChanged.Invoke(P_0);
					num = 1204105464;
					continue;
				case 0:
					goto IL_0045;
				case 1:
					return;
				case 5:
					goto IL_005d;
				case 4:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0045:
			if (_useDigitalAxisSimulation)
			{
				return;
			}
			goto IL_005d;
			IL_005d:
			vpbJzwkSvsfcXUnwDyeDqyAFmab(null);
			num = 1204105470;
			goto IL_000d;
		}

		private void BksFivzUBJegkQVdqVIsdnNbIFn(bool P_0)
		{
			if (base.initialized)
			{
				vpbJzwkSvsfcXUnwDyeDqyAFmab(null);
				_onButtonValueChanged.Invoke(P_0);
			}
		}

		private void EhUABIhiTsSyCnsVqZdAwLvlLFz()
		{
			if (base.initialized)
			{
				vpbJzwkSvsfcXUnwDyeDqyAFmab(null);
				_onButtonDown.Invoke();
			}
		}

		private void fknGcxFHFVWuTRijgaKwgMxIvgTK()
		{
			if (!base.initialized)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -429161065;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -429161066)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0036;
				case 4:
					_onButtonUp.Invoke();
					num = -429161066;
					continue;
				case 0:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0036:
			vpbJzwkSvsfcXUnwDyeDqyAFmab(null);
			num = -429161070;
			goto IL_000d;
		}
	}
}
