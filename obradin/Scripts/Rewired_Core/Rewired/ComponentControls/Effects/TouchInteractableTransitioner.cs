using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, IVisibilityChangedHandler, TouchInteractable.IInteractionStateTransitionHandler
	{
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		[SerializeField]
		private bool _visible = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(TouchInteractable.TransitionTypeFlags))]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Color Tint transitions.")]
		[SerializeField]
		private ColorBlock _transitionColorTint = new ColorBlock
		{
			colorMultiplier = 1f,
			disabledColor = new Color(25f / 32f, 25f / 32f, 25f / 32f, 0.5f),
			highlightedColor = Color.white,
			normalColor = Color.white,
			pressedColor = Color.white,
			fadeDuration = 0.1f
		};

		[Tooltip("Settings using for Sprite State transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SpriteState _transitionSpriteState;

		[Tooltip("Settings using for Animation Trigger transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[CustomObfuscation(rename = false)]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[SerializeField]
		private Graphic _targetGraphic;

		[SerializeField]
		[Tooltip("Toggles whether the fade duration is set by incoming transition events. If enabled, the duration of fades for visibility and Color Tint transitions will be synchronized with the event sender.")]
		[CustomObfuscation(rename = false)]
		private bool _syncFadeDurationWithTransitionEvent = true;

		[Tooltip("Toggles whether the color tint is set by incoming transition events. If enabled, the color tint transition of the event sender will override any color tint setting here. This setting overrides Sync Fade Duration With Transition Event.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _syncColorTintWithTransitionEvent;

		private TouchInteractable.InteractionState ehPgFVBdmCKlKrAFnEhGfpCHlUZG;

		public bool visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (visible != value)
				{
					SWnzUAEKhgDxxwxmMhpFBvKnnQNm(value, false);
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public TouchInteractable.TransitionTypeFlags transitionType
		{
			get
			{
				return _transitionType;
			}
			set
			{
				if (_transitionType != value)
				{
					_transitionType = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public ColorBlock transitionColorTint
		{
			get
			{
				return _transitionColorTint;
			}
			set
			{
				_transitionColorTint = value;
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
			}
		}

		public SpriteState transitionSpriteState
		{
			get
			{
				return _transitionSpriteState;
			}
			set
			{
				if (!_transitionSpriteState.Equals(value))
				{
					_transitionSpriteState = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public AnimationTriggers transitionAnimationTriggers
		{
			get
			{
				return _transitionAnimationTriggers;
			}
			set
			{
				if (_transitionAnimationTriggers == value)
				{
					return;
				}
				while (true)
				{
					_transitionAnimationTriggers = value;
					int num = 962901370;
					while (true)
					{
						switch (num ^ 0x3964B57B)
						{
						case 0:
							num = 962901368;
							continue;
						default:
							return;
						case 3:
							break;
						case 1:
							wQiEPKGVkSYAiCZoyTUamohUIKKd();
							num = 962901369;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public Graphic targetGraphic
		{
			get
			{
				return _targetGraphic;
			}
			set
			{
				if (!(_targetGraphic == value))
				{
					_targetGraphic = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public bool syncFadeDurationWithTransitionEvent
		{
			get
			{
				return _syncFadeDurationWithTransitionEvent;
			}
			set
			{
				if (_syncFadeDurationWithTransitionEvent != value)
				{
					_syncFadeDurationWithTransitionEvent = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public bool syncColorTintWithTransitionEvent
		{
			get
			{
				return _syncColorTintWithTransitionEvent;
			}
			set
			{
				if (_syncColorTintWithTransitionEvent == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 230157342;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0xDB7EC1F)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0033;
				case 2:
					return;
				}
				goto IL_0009;
				IL_0033:
				_syncColorTintWithTransitionEvent = value;
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
				num = 230157341;
				goto IL_000e;
			}
		}

		public Image image
		{
			get
			{
				return _targetGraphic as Image;
			}
			set
			{
				if (!(_targetGraphic == value))
				{
					_targetGraphic = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
				}
			}
		}

		public Animator animator
		{
			get
			{
				return base.gameObject.GetComponent<Animator>();
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchInteractableTransitioner()
		{
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (_targetGraphic == null)
				{
					num = -534893788;
					num2 = num;
				}
				else
				{
					num = -534893785;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -534893788)
					{
					case 2:
						num = -534893787;
						continue;
					case 1:
						break;
					case 0:
						_targetGraphic = base.gameObject.GetComponent<Graphic>();
						num = -534893785;
						continue;
					default:
						SWnzUAEKhgDxxwxmMhpFBvKnnQNm(_visible, true);
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				SWnzUAEKhgDxxwxmMhpFBvKnnQNm(_visible, true);
			}
			lPSCJgLLeQzAoKcuIadJZzmnIqP(true);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			jAQGAmQgKbqKrhUPStwqorlTNHK();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			while (true)
			{
				int num = 1119458117;
				while (true)
				{
					switch (num ^ 0x42B99344)
					{
					case 4:
						break;
					default:
						return;
					case 2:
						NVWqZPEZaDhGVdcEuqvABdsUKUL();
						num = 1119458119;
						continue;
					case 0:
						lPSCJgLLeQzAoKcuIadJZzmnIqP(true);
						num = 1119458118;
						continue;
					case 1:
						if (UnityTools.IsActiveAndEnabled(this))
						{
							XTdwPHoIYAeXdtxcHVtlnrtFtNI(null);
							GeMaoYWkSWdVuATkrycOOKBsivlD(Color.white, true);
							CnDPxkPDbLAJqkImsyyrmtwSUPMg(_transitionAnimationTriggers.normalTrigger);
							num = 1119458116;
							continue;
						}
						goto case 2;
					case 3:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
		}

		[CustomObfuscation(rename = false)]
		private void OnCanvasGroupWasChanged()
		{
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
		}

		[CustomObfuscation(rename = false)]
		private void OnAnimationPropertiesWereApplied()
		{
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
		}

		private void wQiEPKGVkSYAiCZoyTUamohUIKKd()
		{
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
		}

		private void NVWqZPEZaDhGVdcEuqvABdsUKUL()
		{
			if (!Application.isPlaying)
			{
				lPSCJgLLeQzAoKcuIadJZzmnIqP(true);
				return;
			}
			while (true)
			{
				lPSCJgLLeQzAoKcuIadJZzmnIqP(false);
				int num = -1137905279;
				while (true)
				{
					switch (num ^ -1137905277)
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
					num = -1137905278;
				}
			}
		}

		private void lPSCJgLLeQzAoKcuIadJZzmnIqP(bool P_0)
		{
			SuHWIDfTNsChRxehzCBEFxUUSSd(ehPgFVBdmCKlKrAFnEhGfpCHlUZG, P_0);
		}

		private void SWnzUAEKhgDxxwxmMhpFBvKnnQNm(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			while (true)
			{
				_visible = P_0;
				int num = -799491992;
				while (true)
				{
					switch (num ^ -799491990)
					{
					case 0:
						goto IL_000d;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_000d:
					num = -799491989;
				}
			}
		}

		private bool hisTrhNjyiXPMPtamRiivLoWhbo()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		private void jAQGAmQgKbqKrhUPStwqorlTNHK()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != TouchInteractable.TransitionTypeFlags.None)
			{
				GeMaoYWkSWdVuATkrycOOKBsivlD(Color.white, true);
				goto IL_0022;
			}
			goto IL_0044;
			IL_005c:
			int num;
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
			{
				CnDPxkPDbLAJqkImsyyrmtwSUPMg(normalTrigger);
				num = -766838773;
				goto IL_0027;
			}
			return;
			IL_0022:
			num = -766838776;
			goto IL_0027;
			IL_0027:
			switch (num ^ -766838774)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0044;
			case 3:
				goto IL_005c;
			case 1:
				return;
			}
			goto IL_0022;
			IL_0044:
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
			{
				XTdwPHoIYAeXdtxcHVtlnrtFtNI(null);
				num = -766838775;
				goto IL_0027;
			}
			goto IL_005c;
		}

		private void SuHWIDfTNsChRxehzCBEFxUUSSd(TouchInteractable.InteractionState P_0, bool P_1)
		{
			Sprite sprite = default(Sprite);
			string text = default(string);
			bool flag = default(bool);
			Color color = default(Color);
			while (true)
			{
				int num = 539072268;
				while (true)
				{
					switch (num ^ 0x2021970F)
					{
					case 13:
						break;
					default:
						return;
					case 19:
						num = 539072271;
						continue;
					case 14:
					{
						int num3;
						if (!_visible)
						{
							num = 539072286;
							num3 = num;
						}
						else
						{
							num = 539072267;
							num3 = num;
						}
						continue;
					}
					case 12:
						sprite = _transitionSpriteState.pressedSprite;
						num = 539072264;
						continue;
					case 15:
						if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
						{
							CnDPxkPDbLAJqkImsyyrmtwSUPMg(text);
							num = 539072285;
							continue;
						}
						return;
					case 4:
						if (base.gameObject.activeInHierarchy)
						{
							if (flag)
							{
								GeMaoYWkSWdVuATkrycOOKBsivlD(color * _transitionColorTint.colorMultiplier, P_1);
								num = 539072284;
								continue;
							}
							goto case 10;
						}
						return;
					case 17:
						color.a = 0f;
						num = 539072267;
						continue;
					case 9:
						color = _transitionColorTint.normalColor;
						sprite = null;
						text = _transitionAnimationTriggers.normalTrigger;
						num = 539072269;
						continue;
					case 3:
						switch (P_0)
						{
						case TouchInteractable.InteractionState.Normal:
							break;
						default:
							goto IL_0145;
						case TouchInteractable.InteractionState.Highlighted:
							goto IL_018d;
						case TouchInteractable.InteractionState.Pressed:
							goto IL_01bb;
						case TouchInteractable.InteractionState.Disabled:
							goto IL_020d;
						}
						goto case 9;
					case 16:
						color = Color.black;
						sprite = null;
						text = string.Empty;
						num = 539072269;
						continue;
					case 2:
					{
						flag = (_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != 0;
						int num2;
						if (flag)
						{
							num = 539072257;
							num2 = num;
						}
						else
						{
							num = 539072263;
							num2 = num;
						}
						continue;
					}
					case 6:
						goto IL_018d;
					case 1:
						goto IL_01bb;
					case 8:
						color = Color.white;
						num = 539072257;
						continue;
					case 11:
						text = _transitionAnimationTriggers.disabledTrigger;
						num = 539072269;
						continue;
					case 7:
						text = _transitionAnimationTriggers.pressedTrigger;
						num = 539072269;
						continue;
					case 5:
						goto IL_020d;
					case 10:
						GeMaoYWkSWdVuATkrycOOKBsivlD(color, P_1);
						num = 539072271;
						continue;
					case 0:
						if ((_transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
						{
							XTdwPHoIYAeXdtxcHVtlnrtFtNI(sprite);
							num = 539072256;
							continue;
						}
						goto case 15;
					case 18:
						return;
						IL_020d:
						color = _transitionColorTint.disabledColor;
						sprite = _transitionSpriteState.disabledSprite;
						num = 539072260;
						continue;
						IL_01bb:
						color = _transitionColorTint.pressedColor;
						num = 539072259;
						continue;
						IL_018d:
						color = _transitionColorTint.highlightedColor;
						sprite = _transitionSpriteState.highlightedSprite;
						text = _transitionAnimationTriggers.highlightedTrigger;
						num = 539072269;
						continue;
						IL_0145:
						num = 539072287;
						continue;
					}
					break;
				}
			}
		}

		private void GeMaoYWkSWdVuATkrycOOKBsivlD(Color P_0, bool P_1)
		{
			if (_targetGraphic == null)
			{
				while (true)
				{
					switch (0x9A5A9DA ^ 0x9A5A9DB)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, true, true);
		}

		private void XTdwPHoIYAeXdtxcHVtlnrtFtNI(Sprite P_0)
		{
			if (image == null)
			{
				return;
			}
			while (true)
			{
				image.overrideSprite = P_0;
				int num = 1493287108;
				while (true)
				{
					switch (num ^ 0x5901C0C4)
					{
					case 2:
						goto IL_000f;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000f:
					num = 1493287109;
				}
			}
		}

		private void CnDPxkPDbLAJqkImsyyrmtwSUPMg(string P_0)
		{
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None && !(animator == null) && UnityTools.IsActiveAndEnabled(animator) && !(animator.runtimeAnimatorController == null))
			{
				if (string.IsNullOrEmpty(P_0))
				{
					goto IL_0040;
				}
				goto IL_008f;
			}
			return;
			IL_008f:
			animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
			int num = -1705798079;
			goto IL_0045;
			IL_0040:
			num = -1705798078;
			goto IL_0045;
			IL_0045:
			while (true)
			{
				switch (num ^ -1705798077)
				{
				case 3:
					break;
				case 1:
					return;
				case 2:
					animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
					num = -1705798077;
					continue;
				case 5:
					goto IL_008f;
				case 0:
					animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
					num = -1705798073;
					continue;
				default:
					animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
					animator.SetTrigger(P_0);
					return;
				}
				break;
			}
			goto IL_0040;
		}

		public void OnInteractionStateTransition(TouchInteractable.InteractionStateTransitionArgs args)
		{
			ehPgFVBdmCKlKrAFnEhGfpCHlUZG = args.state;
			if (_syncFadeDurationWithTransitionEvent)
			{
				_transitionColorTint.fadeDuration = args.duration;
				goto IL_0025;
			}
			goto IL_004b;
			IL_0072:
			int num;
			if (args.sender != null)
			{
				_transitionColorTint = args.sender.transitionColorTint;
				num = 655811772;
				goto IL_002a;
			}
			goto IL_0098;
			IL_0025:
			num = 655811774;
			goto IL_002a;
			IL_002a:
			switch (num ^ 0x2716E4BF)
			{
			case 0:
				break;
			case 1:
				goto IL_004b;
			case 4:
				goto IL_0072;
			case 3:
				goto IL_0098;
			default:
				goto IL_00b1;
			}
			goto IL_0025;
			IL_004b:
			if (_syncColorTintWithTransitionEvent)
			{
				if ((_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) == 0)
				{
					_transitionType |= TouchInteractable.TransitionTypeFlags.ColorTint;
					num = 655811771;
					goto IL_002a;
				}
				goto IL_0072;
			}
			goto IL_0098;
			IL_0098:
			if (Application.isPlaying)
			{
				lPSCJgLLeQzAoKcuIadJZzmnIqP(false);
				return;
			}
			goto IL_00b1;
			IL_00b1:
			OnValidate();
		}

		public void OnVisibilityChanged(bool state)
		{
			visible = state;
		}
	}
}
