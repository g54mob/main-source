using Rewired.UI;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Interactable Transitioner")]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, IVisibilityChangedHandler, TouchInteractable.IInteractionStateTransitionHandler
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[Bitmask(typeof(TouchInteractable.TransitionTypeFlags))]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Color Tint transitions.")]
		private ColorBlock _transitionColorTint;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Sprite State transitions.")]
		private SpriteState _transitionSpriteState;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		private AnimationTriggers _transitionAnimationTriggers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		private Graphic _targetGraphic;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the fade duration is set by incoming transition events. If enabled, the duration of fades for visibility and Color Tint transitions will be synchronized with the event sender.")]
		private bool _syncFadeDurationWithTransitionEvent;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the color tint is set by incoming transition events. If enabled, the color tint transition of the event sender will override any color tint setting here. This setting overrides Sync Fade Duration With Transition Event.")]
		private bool _syncColorTintWithTransitionEvent;

		private TouchInteractable.InteractionState GzHRouXpIFArqKxwYIIchGcdOmMBb;

		public bool visible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public TouchInteractable.TransitionTypeFlags transitionType
		{
			get
			{
				return default(TouchInteractable.TransitionTypeFlags);
			}
			set
			{
			}
		}

		public ColorBlock transitionColorTint
		{
			get
			{
				return default(ColorBlock);
			}
			set
			{
			}
		}

		public SpriteState transitionSpriteState
		{
			get
			{
				return default(SpriteState);
			}
			set
			{
			}
		}

		public AnimationTriggers transitionAnimationTriggers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Graphic targetGraphic
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool syncFadeDurationWithTransitionEvent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool syncColorTintWithTransitionEvent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Image image
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Animator animator => null;

		[CustomObfuscation(rename = false)]
		private TouchInteractableTransitioner()
		{
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		private void Reset()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnCanvasGroupWasChanged()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnAnimationPropertiesWereApplied()
		{
		}

		private void fxlcRbcHzysTyAwVDkIrJbcXUobM()
		{
		}

		private void VsVNwqdNrNNTKuCqfggdodivEvIw()
		{
		}

		private void GuSOMMfMhbznarMelzJChWdvNZDm(bool P_0)
		{
		}

		private void tZabwkQysWrOacJacbbWCDepeVMaA(bool P_0, bool P_1)
		{
		}

		private bool hOmYAkDaXzesNxxvrZryHoGQekvk()
		{
			return false;
		}

		private void gYGvMGvDlASBlSCIcKhVXSrXmXll()
		{
		}

		private void FuseZuldbMHOVtxwSzaawtOhmkDK(TouchInteractable.InteractionState P_0, bool P_1)
		{
		}

		private void zQEmBZkLzXufdzvwYhTlzpNacTqFA(Color P_0, bool P_1)
		{
		}

		private void EJAIlwVdnnrMXfnGZakXdvnmQOPR(Sprite P_0)
		{
		}

		private void vRWEflipjcfiuBRNvAFANuhzyHGvA(string P_0)
		{
		}

		public void OnInteractionStateTransition(TouchInteractable.InteractionStateTransitionArgs args)
		{
		}

		public void OnVisibilityChanged(bool state)
		{
		}
	}
}
