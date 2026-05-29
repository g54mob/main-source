using Rewired.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public sealed class TouchInteractableTransitioner : MonoBehaviour, IVisibilityChangedHandler, TouchInteractable.IInteractionStateTransitionHandler
	{
		[CustomObfuscation]
		[SerializeField]
		private bool _visible;

		[CustomObfuscation]
		[SerializeField]
		private TouchInteractable.TransitionTypeFlags _transitionType;

		[SerializeField]
		[CustomObfuscation]
		private ColorBlock _transitionColorTint;

		[CustomObfuscation]
		[SerializeField]
		private SpriteState _transitionSpriteState;

		[SerializeField]
		[CustomObfuscation]
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

		private TouchInteractable.InteractionState BonfhOcDEPMWRGvHbEdmncNGKOZk;

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

		private void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		private void kckhtUMxbCHYHtoyNtsHEKeNtSU()
		{
		}

		private void KYjHDWJKlPlCVCfuzVuDISoukCg(bool P_0)
		{
		}

		private void xPPTbJYPHhGHieHgnbzxiTVuGUP(bool P_0, bool P_1)
		{
		}

		private bool IBKkOwJrXljaMLFlVIPSHuCVYtwa()
		{
			return false;
		}

		private void OpkZfQOoimpucbLizkCUnoGCBeY()
		{
		}

		private void xffgPHrvnrcdgfhkGFMffAuXjMCO(TouchInteractable.InteractionState P_0, bool P_1)
		{
		}

		private void zXsevXAVmBHqbCZuQscofVSdAhfL(Color P_0, bool P_1)
		{
		}

		private void ucVifAewkToLchvacQVRDioaCbOk(Sprite P_0)
		{
		}

		private void jFzeOdRVtKuFlGGeFqLFiGfHdHI(string P_0)
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
