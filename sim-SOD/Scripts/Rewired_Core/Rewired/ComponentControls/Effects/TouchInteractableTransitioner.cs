using Rewired.UI;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[AddComponentMenu("Rewired/Touch Interactable Transitioner")]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, IVisibilityChangedHandler, TouchInteractable.IInteractionStateTransitionHandler
	{
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _visible;

		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[SerializeField]
		[Bitmask(typeof(TouchInteractable.TransitionTypeFlags))]
		[CustomObfuscation(rename = false)]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		[Tooltip("Settings using for Color Tint transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ColorBlock _transitionColorTint;

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Sprite State transitions.")]
		[SerializeField]
		private SpriteState _transitionSpriteState;

		[Tooltip("Settings using for Animation Trigger transitions.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AnimationTriggers _transitionAnimationTriggers;

		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Graphic _targetGraphic;

		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the fade duration is set by incoming transition events. If enabled, the duration of fades for visibility and Color Tint transitions will be synchronized with the event sender.")]
		[SerializeField]
		private bool _syncFadeDurationWithTransitionEvent;

		[SerializeField]
		[Tooltip("Toggles whether the color tint is set by incoming transition events. If enabled, the color tint transition of the event sender will override any color tint setting here. This setting overrides Sync Fade Duration With Transition Event.")]
		[CustomObfuscation(rename = false)]
		private bool _syncColorTintWithTransitionEvent;

		private TouchInteractable.InteractionState QWHtvxwolDILzHTQYqQYtebSTP;

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

		private void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		private void bvTAFhqERolFHfOeXbNxGuHwuYYG()
		{
		}

		private void DeIhupdHDdHXVSkozrZpciJVHYi(bool P_0)
		{
		}

		private void gzwPpsgHxRCLyyPctkGHOamHQYX(bool P_0, bool P_1)
		{
		}

		private bool NhxcsRlbpZfvCJlrVomyWKbkXzk()
		{
			return false;
		}

		private void JbBDhUGqGQJqgdhNdnZiYJVvdBGO()
		{
		}

		private void cYGadsNABRUwoxLkKpdXiDVewMW(TouchInteractable.InteractionState P_0, bool P_1)
		{
		}

		private void gLRPozuOdYjtMZyQINQPjjIWptN(Color P_0, bool P_1)
		{
		}

		private void neYVpCASbsQwIpemYonFUZvDhYx(Sprite P_0)
		{
		}

		private void cPQvGIjPdiGtvEecRaNdbASijBUc(string P_0)
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
