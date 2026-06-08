using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Interactable Transitioner")]
	[RequireComponent(typeof(RectTransform))]
	[ExecuteInEditMode]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, IVisibilityChangedHandler, TouchInteractable.IInteractionStateTransitionHandler
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[Bitmask(typeof(TouchInteractable.TransitionTypeFlags))]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Color Tint transitions.")]
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
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private SpriteState _transitionSpriteState;

		[Tooltip("Settings using for Animation Trigger transitions.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		private Graphic _targetGraphic;

		[SerializeField]
		[Tooltip("Toggles whether the fade duration is set by incoming transition events. If enabled, the duration of fades for visibility and Color Tint transitions will be synchronized with the event sender.")]
		[CustomObfuscation(rename = false)]
		private bool _syncFadeDurationWithTransitionEvent = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the color tint is set by incoming transition events. If enabled, the color tint transition of the event sender will override any color tint setting here. This setting overrides Sync Fade Duration With Transition Event.")]
		private bool _syncColorTintWithTransitionEvent;

		private TouchInteractable.InteractionState agJGKBJoRESVuigjKFGTOQkYDIpK;

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
					KEpqQGGfOeHyBrmOlKJIMDckKQh(value, false);
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_transitionSpriteState.Equals(value))
				{
					return;
				}
				while (true)
				{
					_transitionSpriteState = value;
					int num = 1230071763;
					while (true)
					{
						switch (num ^ 0x495167D2)
						{
						case 3:
							num = 1230071760;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = 1230071762;
							continue;
						case 0:
							return;
						}
						break;
					}
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = -918707247;
					while (true)
					{
						switch (num ^ -918707247)
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
						num = -918707248;
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
				int num = -1985112869;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1985112870)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				_syncColorTintWithTransitionEvent = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
				num = -1985112870;
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
				if (_targetGraphic == value)
				{
					return;
				}
				while (true)
				{
					_targetGraphic = value;
					int num = 687310480;
					while (true)
					{
						switch (num ^ 0x28F78690)
						{
						case 2:
							goto IL_000f;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000f:
						num = 687310481;
					}
				}
			}
		}

		public Animator animator => base.gameObject.GetComponent<Animator>();

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
			while (_targetGraphic == null)
			{
				_targetGraphic = base.gameObject.GetComponent<Graphic>();
				int num = 1858880167;
				while (true)
				{
					switch (num ^ 0x6ECC42A5)
					{
					case 0:
						num = 1858880164;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0026;
					}
					break;
				}
				continue;
				end_IL_0026:
				break;
			}
			KEpqQGGfOeHyBrmOlKJIMDckKQh(_visible, true);
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				KEpqQGGfOeHyBrmOlKJIMDckKQh(_visible, true);
			}
			xFRbkPhHuGXRyWLYlLZgacHeUGUi(true);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			plWofkMyjnoeNofvjgPhBKLAfRiC();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			if (UnityTools.IsActiveAndEnabled(this))
			{
				while (true)
				{
					int num = -361569726;
					while (true)
					{
						switch (num ^ -361569728)
						{
						case 3:
							break;
						case 2:
							RjthIHqdtMwYHwNCgrsiQiVCbrog(null);
							MGKFSQAMxOCfCESIUMRTldtbNhJC(Color.white, true);
							num = -361569727;
							continue;
						case 1:
							EMVJCmXWIVhOCFPWBBGqYLMZRMm(_transitionAnimationTriggers.normalTrigger);
							xFRbkPhHuGXRyWLYlLZgacHeUGUi(true);
							num = -361569728;
							continue;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					end_IL_0028:
					break;
				}
			}
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		[CustomObfuscation(rename = false)]
		private void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
		}

		[CustomObfuscation(rename = false)]
		private void OnCanvasGroupWasChanged()
		{
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		[CustomObfuscation(rename = false)]
		private void OnAnimationPropertiesWereApplied()
		{
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		private void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		private void NPOFSRfAiJHJstoMPmTkHgTRYCc()
		{
			if (!Application.isPlaying)
			{
				xFRbkPhHuGXRyWLYlLZgacHeUGUi(true);
				return;
			}
			while (true)
			{
				xFRbkPhHuGXRyWLYlLZgacHeUGUi(false);
				int num = -636970277;
				while (true)
				{
					switch (num ^ -636970279)
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
					num = -636970280;
				}
			}
		}

		private void xFRbkPhHuGXRyWLYlLZgacHeUGUi(bool P_0)
		{
			IONEiCIvsiVsXkmUQKvSSaXNlMkE(agJGKBJoRESVuigjKFGTOQkYDIpK, P_0);
		}

		private void KEpqQGGfOeHyBrmOlKJIMDckKQh(bool P_0, bool P_1)
		{
			if (_visible != P_0 || P_1)
			{
				_visible = P_0;
			}
		}

		private bool vYubdtbZKaanrKYDTNuveCdLMdEG()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		private void plWofkMyjnoeNofvjgPhBKLAfRiC()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != TouchInteractable.TransitionTypeFlags.None)
			{
				MGKFSQAMxOCfCESIUMRTldtbNhJC(Color.white, true);
				goto IL_0022;
			}
			goto IL_0071;
			IL_0056:
			int num;
			int num2;
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
			{
				num = -1237798232;
				num2 = num;
			}
			else
			{
				num = -1237798229;
				num2 = num;
			}
			goto IL_0027;
			IL_0022:
			num = -1237798230;
			goto IL_0027;
			IL_0027:
			while (true)
			{
				switch (num ^ -1237798229)
				{
				case 4:
					break;
				default:
					return;
				case 3:
					EMVJCmXWIVhOCFPWBBGqYLMZRMm(normalTrigger);
					num = -1237798229;
					continue;
				case 2:
					goto IL_0056;
				case 1:
					goto IL_0071;
				case 0:
					return;
				}
				break;
			}
			goto IL_0022;
			IL_0071:
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
			{
				RjthIHqdtMwYHwNCgrsiQiVCbrog(null);
				num = -1237798231;
				goto IL_0027;
			}
			goto IL_0056;
		}

		private void IONEiCIvsiVsXkmUQKvSSaXNlMkE(TouchInteractable.InteractionState P_0, bool P_1)
		{
			Color color;
			int num;
			bool flag = default(bool);
			Sprite sprite = default(Sprite);
			string text = default(string);
			switch (P_0)
			{
			case TouchInteractable.InteractionState.Pressed:
				color = _transitionColorTint.pressedColor;
				num = -1676040722;
				goto IL_0024;
			case TouchInteractable.InteractionState.Highlighted:
				goto IL_0114;
			default:
				goto IL_01d3;
			case TouchInteractable.InteractionState.Disabled:
				goto IL_0246;
			case TouchInteractable.InteractionState.Normal:
				goto IL_025c;
				IL_0024:
				while (true)
				{
					switch (num ^ -1676040725)
					{
					case 23:
						num = -1676040709;
						continue;
					default:
						return;
					case 2:
						num = -1676040706;
						continue;
					case 14:
						if (!_visible)
						{
							color.a = 0f;
							num = -1676040721;
							continue;
						}
						goto case 4;
					case 21:
						break;
					case 18:
						goto end_IL_0024;
					case 6:
						num = -1676040706;
						continue;
					case 9:
						MGKFSQAMxOCfCESIUMRTldtbNhJC(color, P_1);
						num = -1676040729;
						continue;
					case 3:
						goto IL_0114;
					case 4:
						if (base.gameObject.activeInHierarchy)
						{
							if (flag)
							{
								MGKFSQAMxOCfCESIUMRTldtbNhJC(color * _transitionColorTint.colorMultiplier, P_1);
								num = -1676040729;
								continue;
							}
							goto case 9;
						}
						return;
					case 13:
						sprite = _transitionSpriteState.disabledSprite;
						text = _transitionAnimationTriggers.disabledTrigger;
						num = -1676040727;
						continue;
					case 0:
						num = -1676040706;
						continue;
					case 8:
						text = _transitionAnimationTriggers.highlightedTrigger;
						num = -1676040706;
						continue;
					case 10:
						color = Color.white;
						num = -1676040731;
						continue;
					case 15:
						text = _transitionAnimationTriggers.normalTrigger;
						num = -1676040723;
						continue;
					case 22:
						goto IL_01d3;
					case 17:
						text = _transitionAnimationTriggers.pressedTrigger;
						num = -1676040725;
						continue;
					case 5:
						sprite = _transitionSpriteState.pressedSprite;
						num = -1676040710;
						continue;
					case 19:
						EMVJCmXWIVhOCFPWBBGqYLMZRMm(text);
						num = -1676040736;
						continue;
					case 20:
						goto IL_0228;
					case 7:
						goto IL_0246;
					case 16:
						goto IL_025c;
					case 12:
						goto IL_0274;
					case 1:
						RjthIHqdtMwYHwNCgrsiQiVCbrog(sprite);
						num = -1676040705;
						continue;
					case 11:
						return;
					}
					flag = (_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != 0;
					int num2;
					if (flag)
					{
						num = -1676040731;
						num2 = num;
					}
					else
					{
						num = -1676040735;
						num2 = num;
					}
					continue;
					IL_0274:
					int num3;
					if ((_transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) == 0)
					{
						num = -1676040705;
						num3 = num;
					}
					else
					{
						num = -1676040726;
						num3 = num;
					}
					continue;
					IL_0228:
					int num4;
					if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
					{
						num = -1676040712;
						num4 = num;
					}
					else
					{
						num = -1676040736;
						num4 = num;
					}
					continue;
					end_IL_0024:
					break;
				}
				goto case TouchInteractable.InteractionState.Pressed;
				IL_025c:
				color = _transitionColorTint.normalColor;
				sprite = null;
				num = -1676040732;
				goto IL_0024;
				IL_0246:
				color = _transitionColorTint.disabledColor;
				num = -1676040730;
				goto IL_0024;
				IL_01d3:
				color = Color.black;
				sprite = null;
				text = string.Empty;
				num = -1676040706;
				goto IL_0024;
				IL_0114:
				color = _transitionColorTint.highlightedColor;
				sprite = _transitionSpriteState.highlightedSprite;
				num = -1676040733;
				goto IL_0024;
			}
		}

		private void MGKFSQAMxOCfCESIUMRTldtbNhJC(Color P_0, bool P_1)
		{
			if (_targetGraphic == null)
			{
				while (true)
				{
					switch (0x7B89109A ^ 0x7B89109B)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, ignoreTimeScale: true, useAlpha: true);
		}

		private void RjthIHqdtMwYHwNCgrsiQiVCbrog(Sprite P_0)
		{
			if (image == null)
			{
				return;
			}
			while (true)
			{
				image.overrideSprite = P_0;
				int num = -1632607912;
				while (true)
				{
					switch (num ^ -1632607912)
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
					num = -1632607911;
				}
			}
		}

		private void EMVJCmXWIVhOCFPWBBGqYLMZRMm(string P_0)
		{
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None && !(animator == null) && UnityTools.IsActiveAndEnabled(animator) && !(animator.runtimeAnimatorController == null))
			{
				if (string.IsNullOrEmpty(P_0))
				{
					goto IL_0040;
				}
				goto IL_006a;
			}
			return;
			IL_006a:
			animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
			animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
			int num = 172772409;
			goto IL_0045;
			IL_0040:
			num = 172772408;
			goto IL_0045;
			IL_0045:
			switch (num ^ 0xA4C4C3B)
			{
			case 0:
				break;
			case 3:
				return;
			case 1:
				goto IL_006a;
			default:
				animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
				animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
				animator.SetTrigger(P_0);
				return;
			}
			goto IL_0040;
		}

		public void OnInteractionStateTransition(TouchInteractable.InteractionStateTransitionArgs args)
		{
			agJGKBJoRESVuigjKFGTOQkYDIpK = args.state;
			if (_syncFadeDurationWithTransitionEvent)
			{
				_transitionColorTint.fadeDuration = args.duration;
				goto IL_0028;
			}
			goto IL_00d9;
			IL_00d9:
			int num;
			int num2;
			if (_syncColorTintWithTransitionEvent)
			{
				num = -1637393720;
				num2 = num;
			}
			else
			{
				num = -1637393716;
				num2 = num;
			}
			goto IL_002d;
			IL_0028:
			num = -1637393717;
			goto IL_002d;
			IL_002d:
			while (true)
			{
				switch (num ^ -1637393715)
				{
				case 4:
					break;
				case 0:
					if (args.sender != null)
					{
						_transitionColorTint = args.sender.transitionColorTint;
						num = -1637393716;
						continue;
					}
					goto case 1;
				case 5:
					goto IL_0083;
				case 1:
					if (Application.isPlaying)
					{
						xFRbkPhHuGXRyWLYlLZgacHeUGUi(false);
						num = -1637393714;
						continue;
					}
					goto default;
				case 2:
					_transitionType |= TouchInteractable.TransitionTypeFlags.ColorTint;
					num = -1637393715;
					continue;
				case 3:
					return;
				case 6:
					goto IL_00d9;
				default:
					OnValidate();
					return;
				}
				break;
				IL_0083:
				int num3;
				if ((_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) == 0)
				{
					num = -1637393713;
					num3 = num;
				}
				else
				{
					num = -1637393715;
					num3 = num;
				}
			}
			goto IL_0028;
		}

		public void OnVisibilityChanged(bool state)
		{
			visible = state;
		}
	}
}
