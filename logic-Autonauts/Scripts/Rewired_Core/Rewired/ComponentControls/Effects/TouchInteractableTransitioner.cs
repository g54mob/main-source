using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, IVisibilityChangedHandler, TouchInteractable.IInteractionStateTransitionHandler
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible = true;

		[Bitmask(typeof(TouchInteractable.TransitionTypeFlags))]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Settings using for Sprite State transitions.")]
		private SpriteState _transitionSpriteState;

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		[SerializeField]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[SerializeField]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[CustomObfuscation(rename = false)]
		private Graphic _targetGraphic;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the fade duration is set by incoming transition events. If enabled, the duration of fades for visibility and Color Tint transitions will be synchronized with the event sender.")]
		private bool _syncFadeDurationWithTransitionEvent = true;

		[Tooltip("Toggles whether the color tint is set by incoming transition events. If enabled, the color tint transition of the event sender will override any color tint setting here. This setting overrides Sync Fade Duration With Transition Event.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _syncColorTintWithTransitionEvent;

		private TouchInteractable.InteractionState PcVzGUlUcYIFzLFEPJfMGMOZmDI;

		public bool visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (visible == value)
				{
					while (true)
					{
						switch (-920787067 ^ -920787068)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				fLfGNTIuzupCCAOzuPlZdWUzABYV(value, false);
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
				if (_transitionType == value)
				{
					goto IL_0009;
				}
				goto IL_003c;
				IL_0009:
				int num = 1593815783;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x5EFFB2E3)
					{
					case 3:
						break;
					default:
						return;
					case 0:
						TzavSRkIcUdUXyGrWDQoLGzUgZXD();
						num = 1593815778;
						continue;
					case 2:
						goto IL_003c;
					case 4:
						return;
					case 1:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_003c:
				_transitionType = value;
				num = 1593815779;
				goto IL_000e;
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
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					goto IL_000e;
				}
				goto IL_0038;
				IL_000e:
				int num = 86527843;
				goto IL_0013;
				IL_0013:
				switch (num ^ 0x5284F62)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					return;
				case 0:
					goto IL_0038;
				case 3:
					return;
				}
				goto IL_000e;
				IL_0038:
				_transitionSpriteState = value;
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
				num = 86527841;
				goto IL_0013;
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
				if (_transitionAnimationTriggers != value)
				{
					_transitionAnimationTriggers = value;
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
				if (_syncColorTintWithTransitionEvent != value)
				{
					_syncColorTintWithTransitionEvent = value;
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
				}
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
					goto IL_000e;
				}
				goto IL_0038;
				IL_000e:
				int num = 1489096060;
				goto IL_0013;
				IL_0013:
				switch (num ^ 0x58C1CD7D)
				{
				case 0:
					break;
				case 1:
					return;
				case 3:
					goto IL_0038;
				default:
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
					return;
				}
				goto IL_000e;
				IL_0038:
				_targetGraphic = value;
				num = 1489096063;
				goto IL_0013;
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
				goto IL_0007;
			}
			goto IL_004d;
			IL_0007:
			int num = 68472024;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ 0x414CCDA)
				{
				case 0:
					break;
				case 2:
					return;
				case 3:
					_targetGraphic = base.gameObject.GetComponent<Graphic>();
					num = 68472027;
					continue;
				case 4:
					goto IL_004d;
				default:
					fLfGNTIuzupCCAOzuPlZdWUzABYV(_visible, true);
					return;
				}
				break;
			}
			goto IL_0007;
			IL_004d:
			int num2;
			if (!(_targetGraphic == null))
			{
				num = 68472027;
				num2 = num;
			}
			else
			{
				num = 68472025;
				num2 = num;
			}
			goto IL_000c;
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				fLfGNTIuzupCCAOzuPlZdWUzABYV(_visible, true);
			}
			EDRFWYdBVAKrpijoqiItmhEhVql(true);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			CKGLVtyaWfsrMDiOesswTgtVNOH();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			if (UnityTools.IsActiveAndEnabled(this))
			{
				gfrprUAqGUNQMRdrbXPfAcvFcZF(null);
				zcAjFPuWKUaxDhSdZguQrbJsmpm(Color.white, true);
				while (true)
				{
					int num = -1960884505;
					while (true)
					{
						switch (num ^ -1960884506)
						{
						case 2:
							break;
						case 1:
							rqZFqnvavFbwNhorAwwbKxiMYWF(_transitionAnimationTriggers.normalTrigger);
							EDRFWYdBVAKrpijoqiItmhEhVql(true);
							num = -1960884506;
							continue;
						default:
							goto end_IL_003b;
						}
						break;
					}
					continue;
					end_IL_003b:
					break;
				}
			}
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
		}

		[CustomObfuscation(rename = false)]
		private void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
		}

		[CustomObfuscation(rename = false)]
		private void OnCanvasGroupWasChanged()
		{
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
		}

		[CustomObfuscation(rename = false)]
		private void OnAnimationPropertiesWereApplied()
		{
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
		}

		private void TzavSRkIcUdUXyGrWDQoLGzUgZXD()
		{
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
		}

		private void cIMxKKikLZEqzDDbOdedgdvAfBZi()
		{
			if (!Application.isPlaying)
			{
				EDRFWYdBVAKrpijoqiItmhEhVql(true);
			}
			else
			{
				EDRFWYdBVAKrpijoqiItmhEhVql(false);
			}
		}

		private void EDRFWYdBVAKrpijoqiItmhEhVql(bool P_0)
		{
			lMJPoRRdLqpsAHxtHOIHobpOFrX(PcVzGUlUcYIFzLFEPJfMGMOZmDI, P_0);
		}

		private void fLfGNTIuzupCCAOzuPlZdWUzABYV(bool P_0, bool P_1)
		{
			if (_visible != P_0 || P_1)
			{
				_visible = P_0;
			}
		}

		private bool SReWvifzbiimwfgOYBbsCDkCaEh()
		{
			return UnityTools.IsActiveAndEnabled(this);
		}

		private void CKGLVtyaWfsrMDiOesswTgtVNOH()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != TouchInteractable.TransitionTypeFlags.None)
			{
				zcAjFPuWKUaxDhSdZguQrbJsmpm(Color.white, true);
				goto IL_0022;
			}
			goto IL_0044;
			IL_005c:
			int num;
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
			{
				rqZFqnvavFbwNhorAwwbKxiMYWF(normalTrigger);
				num = 389970485;
				goto IL_0027;
			}
			return;
			IL_0022:
			num = 389970484;
			goto IL_0027;
			IL_0027:
			switch (num ^ 0x173E7A36)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0044;
			case 1:
				goto IL_005c;
			case 3:
				return;
			}
			goto IL_0022;
			IL_0044:
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
			{
				gfrprUAqGUNQMRdrbXPfAcvFcZF(null);
				num = 389970487;
				goto IL_0027;
			}
			goto IL_005c;
		}

		private void lMJPoRRdLqpsAHxtHOIHobpOFrX(TouchInteractable.InteractionState P_0, bool P_1)
		{
			Color color = default(Color);
			bool flag = default(bool);
			Sprite sprite = default(Sprite);
			string text = default(string);
			while (true)
			{
				int num = 19787064;
				while (true)
				{
					switch (num ^ 0x12DED3D)
					{
					case 19:
						break;
					default:
						return;
					case 9:
						num = 19787055;
						continue;
					case 2:
					{
						int num3;
						if (base.gameObject.activeInHierarchy)
						{
							num = 19787063;
							num3 = num;
						}
						else
						{
							num = 19787048;
							num3 = num;
						}
						continue;
					}
					case 4:
						color = Color.white;
						num = 19787059;
						continue;
					case 6:
					{
						int num2;
						if (!flag)
						{
							num = 19787065;
							num2 = num;
						}
						else
						{
							num = 19787059;
							num2 = num;
						}
						continue;
					}
					case 15:
						sprite = null;
						text = _transitionAnimationTriggers.normalTrigger;
						num = 19787055;
						continue;
					case 1:
						color = Color.black;
						sprite = null;
						text = string.Empty;
						num = 19787055;
						continue;
					case 10:
					{
						int num4;
						if (flag)
						{
							num = 19787070;
							num4 = num;
						}
						else
						{
							num = 19787066;
							num4 = num;
						}
						continue;
					}
					case 5:
						switch (P_0)
						{
						case TouchInteractable.InteractionState.Normal:
							goto IL_019b;
						case TouchInteractable.InteractionState.Highlighted:
							goto IL_01eb;
						case TouchInteractable.InteractionState.Disabled:
							goto IL_0201;
						case TouchInteractable.InteractionState.Pressed:
							goto IL_022f;
						}
						num = 19787068;
						continue;
					case 8:
						if ((_transitionType & TouchInteractable.TransitionTypeFlags.SpriteSwap) != TouchInteractable.TransitionTypeFlags.None)
						{
							gfrprUAqGUNQMRdrbXPfAcvFcZF(sprite);
							num = 19787049;
							continue;
						}
						goto case 20;
					case 12:
						sprite = _transitionSpriteState.pressedSprite;
						text = _transitionAnimationTriggers.pressedTrigger;
						num = 19787060;
						continue;
					case 7:
						zcAjFPuWKUaxDhSdZguQrbJsmpm(color, P_1);
						num = 19787061;
						continue;
					case 3:
						zcAjFPuWKUaxDhSdZguQrbJsmpm(color * _transitionColorTint.colorMultiplier, P_1);
						num = 19787061;
						continue;
					case 16:
						goto IL_019b;
					case 18:
						flag = (_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != 0;
						num = 19787067;
						continue;
					case 14:
						if (!_visible)
						{
							color.a = 0f;
							num = 19787071;
							continue;
						}
						goto case 2;
					case 11:
						goto IL_01eb;
					case 0:
						goto IL_0201;
					case 13:
						goto IL_022f;
					case 20:
						if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) != TouchInteractable.TransitionTypeFlags.None)
						{
							rqZFqnvavFbwNhorAwwbKxiMYWF(text);
							num = 19787048;
							continue;
						}
						return;
					case 17:
						sprite = _transitionSpriteState.highlightedSprite;
						text = _transitionAnimationTriggers.highlightedTrigger;
						num = 19787055;
						continue;
					case 21:
						return;
						IL_022f:
						color = _transitionColorTint.pressedColor;
						num = 19787057;
						continue;
						IL_0201:
						color = _transitionColorTint.disabledColor;
						sprite = _transitionSpriteState.disabledSprite;
						text = _transitionAnimationTriggers.disabledTrigger;
						num = 19787055;
						continue;
						IL_01eb:
						color = _transitionColorTint.highlightedColor;
						num = 19787052;
						continue;
						IL_019b:
						color = _transitionColorTint.normalColor;
						num = 19787058;
						continue;
					}
					break;
				}
			}
		}

		private void zcAjFPuWKUaxDhSdZguQrbJsmpm(Color P_0, bool P_1)
		{
			if (!(_targetGraphic == null))
			{
				_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, true, true);
			}
		}

		private void gfrprUAqGUNQMRdrbXPfAcvFcZF(Sprite P_0)
		{
			if (image == null)
			{
				return;
			}
			while (true)
			{
				image.overrideSprite = P_0;
				int num = 432170812;
				while (true)
				{
					switch (num ^ 0x19C2673C)
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
					num = 432170813;
				}
			}
		}

		private void rqZFqnvavFbwNhorAwwbKxiMYWF(string P_0)
		{
			if ((_transitionType & TouchInteractable.TransitionTypeFlags.Animation) == 0)
			{
				return;
			}
			while (true)
			{
				int num = -1380933468;
				while (true)
				{
					switch (num ^ -1380933472)
					{
					case 5:
						break;
					case 4:
						if (!(animator == null) && UnityTools.IsActiveAndEnabled(animator) && !(animator.runtimeAnimatorController == null))
						{
							int num2;
							if (string.IsNullOrEmpty(P_0))
							{
								num = -1380933471;
								num2 = num;
							}
							else
							{
								num = -1380933472;
								num2 = num;
							}
							continue;
						}
						return;
					case 0:
						animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
						animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
						num = -1380933470;
						continue;
					case 1:
						return;
					case 2:
						animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
						animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
						num = -1380933469;
						continue;
					default:
						animator.SetTrigger(P_0);
						return;
					}
					break;
				}
			}
		}

		public void OnInteractionStateTransition(TouchInteractable.InteractionStateTransitionArgs args)
		{
			PcVzGUlUcYIFzLFEPJfMGMOZmDI = args.state;
			if (_syncFadeDurationWithTransitionEvent)
			{
				_transitionColorTint.fadeDuration = args.duration;
				goto IL_0025;
			}
			goto IL_005a;
			IL_005a:
			int num;
			int num2;
			if (_syncColorTintWithTransitionEvent)
			{
				num = 896260105;
				num2 = num;
			}
			else
			{
				num = 896260108;
				num2 = num;
			}
			goto IL_002a;
			IL_0025:
			num = 896260109;
			goto IL_002a;
			IL_002a:
			while (true)
			{
				switch (num ^ 0x356BD80A)
				{
				case 0:
					break;
				case 7:
					goto IL_005a;
				case 6:
					goto IL_0073;
				case 4:
					_transitionType |= TouchInteractable.TransitionTypeFlags.ColorTint;
					num = 896260104;
					continue;
				case 5:
					EDRFWYdBVAKrpijoqiItmhEhVql(false);
					return;
				case 2:
					if (args.sender != null)
					{
						_transitionColorTint = args.sender.transitionColorTint;
						num = 896260108;
						continue;
					}
					goto IL_0073;
				case 3:
					goto IL_00db;
				default:
					OnValidate();
					return;
				}
				break;
				IL_00db:
				int num3;
				if ((_transitionType & TouchInteractable.TransitionTypeFlags.ColorTint) != TouchInteractable.TransitionTypeFlags.None)
				{
					num = 896260104;
					num3 = num;
				}
				else
				{
					num = 896260110;
					num3 = num;
				}
				continue;
				IL_0073:
				int num4;
				if (Application.isPlaying)
				{
					num = 896260111;
					num4 = num;
				}
				else
				{
					num = 896260107;
					num4 = num;
				}
			}
			goto IL_0025;
		}

		public void OnVisibilityChanged(bool state)
		{
			visible = state;
		}
	}
}
