using Rewired.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, TouchInteractable.IInteractionStateTransitionHandler, IVisibilityChangedHandler
	{
		[CustomObfuscation]
		[SerializeField]
		private bool _visible;

		[CustomObfuscation]
		[SerializeField]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		[CustomObfuscation]
		[SerializeField]
		private ColorBlock _transitionColorTint;

		[SerializeField]
		[CustomObfuscation]
		private SpriteState _transitionSpriteState;

		[CustomObfuscation]
		[SerializeField]
		private AnimationTriggers _transitionAnimationTriggers;

		[CustomObfuscation]
		[SerializeField]
		private Graphic _targetGraphic;

		[CustomObfuscation]
		[SerializeField]
		private bool _syncFadeDurationWithTransitionEvent;

		[CustomObfuscation]
		[SerializeField]
		private bool _syncColorTintWithTransitionEvent;

		private TouchInteractable.InteractionState YROSvivbkTJRrfPlDiTRAdFkBfOM;

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

		[CustomObfuscation]
		private TouchInteractableTransitioner()
		{
		}

		[CustomObfuscation]
		private void Awake()
		{
		}

		[CustomObfuscation]
		private void OnEnable()
		{
		}

		[CustomObfuscation]
		private void OnDisable()
		{
		}

		[CustomObfuscation]
		private void OnValidate()
		{
		}

		[CustomObfuscation]
		private void Reset()
		{
		}

		[CustomObfuscation]
		private void OnCanvasGroupWasChanged()
		{
		}

		[CustomObfuscation]
		private void OnAnimationPropertiesWereApplied()
		{
		}

		private void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
		}

		private void fLESigLZMfTrdvEIqdmveetSjBkA()
		{
		}

		private void JOCciorJzRTgvIEYqzBgsuWQznjd(bool P_0)
		{
		}

		private void cmmwwvcottRDAmZIsNkUSjRSinOy(bool P_0, bool P_1)
		{
		}

		private bool PShxgWdddbbfaPENIUnxAgObCOvO()
		{
			return false;
		}

		private void ZlNIcJavSueqWtLzqBdtHqwqWmJU()
		{
		}

		private void qWsmrFrRtLqAzmAJjTWknehanDAA(TouchInteractable.InteractionState P_0, bool P_1)
		{
		}

		private void epNdUxcmGRRbZLcKRgzRfnAPCSwdA(Color P_0, bool P_1)
		{
		}

		private void zEwcEuIfKXxGYjVAdKYwGBwmdMNAA(Sprite P_0)
		{
		}

		private void wCWTFDpUnKNhFQqOCujuWnhfOyFK(string P_0)
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
