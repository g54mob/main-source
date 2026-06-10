using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.UI;
using Rewired.Utils.Attributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public abstract class TouchInteractable : TouchControl, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
	{
		public enum InteractionState
		{
			Normal = 0,
			Highlighted = 1,
			Pressed = 2,
			Disabled = 3
		}

		[Flags]
		public enum TransitionTypeFlags
		{
			None = 0,
			ColorTint = 1,
			SpriteSwap = 2,
			Animation = 4
		}

		[Flags]
		public enum MouseButtonFlags
		{
			None = 0,
			LeftButton = 1,
			RightButton = 2,
			MiddleButton = 4,
			AnyButton = -1
		}

		[Serializable]
		public class InteractionStateTransitionEventHandler : UnityEvent<InteractionStateTransitionArgs>
		{
		}

		[Serializable]
		public class VisibilityChangedEventHandler : UnityEvent<bool>
		{
		}

		public class InteractionStateTransitionArgs
		{
			private TouchInteractable xrujpVXsSnkjHEMlUvgbvpMlYXT;

			private InteractionState XpygcDfKCDmefnvGhqkVqgmLKcT;

			private float ksYBclMuUBYfGGvcpbtnUWOivw;

			public TouchInteractable sender => null;

			public InteractionState state => default(InteractionState);

			public float duration => 0f;

			internal InteractionStateTransitionArgs()
			{
			}

			internal void XCtmPOrxAdFOcqUsoCVXUexNCxb(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
			}
		}

		public interface IInteractionStateTransitionHandler
		{
			void OnInteractionStateTransition(InteractionStateTransitionArgs data);
		}

		public const int POINTER_ID_NULL = int.MinValue;

		public const int POINTER_ID_MOUSE_LEFT_BUTTON = -1;

		public const int POINTER_ID_MOUSE_RIGHT_BUTTON = -2;

		public const int POINTER_ID_MOUSE_MIDDLE_BUTTON = -3;

		internal const int MAX_MOUSE_BUTTONS = 3;

		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the control can be interacted with by the user.")]
		[SerializeField]
		private bool _interactable;

		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		[SerializeField]
		private bool _visible;

		[CustomObfuscation(rename = false)]
		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		[SerializeField]
		private bool _hideWhenIdle;

		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(MouseButtonFlags))]
		[SerializeField]
		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		private MouseButtonFlags _allowedMouseButtons;

		[CustomObfuscation(rename = false)]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[Bitmask(typeof(TransitionTypeFlags))]
		[SerializeField]
		private TransitionTypeFlags _transitionType;

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Color Tint transitions.")]
		[SerializeField]
		private ColorBlock _transitionColorTint;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Sprite State transitions.")]
		private SpriteState _transitionSpriteState;

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		[SerializeField]
		private AnimationTriggers _transitionAnimationTriggers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		private Graphic _targetGraphic;

		[SerializeField]
		[Tooltip("Event sent when the Interaction State changes.")]
		[CustomObfuscation(rename = false)]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when visibility changes.")]
		private VisibilityChangedEventHandler _onVisibilityChanged;

		[Tooltip("Event sent when interaction state changes to Normal.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UnityEvent _onInteractionStateChangedToNormal;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		private UnityEvent _onInteractionStateChangedToHighlighted;

		[Tooltip("Event sent when interaction state changes to Pressed.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToPressed;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Disabled.")]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToDisabled;

		private readonly List<CanvasGroup> _canvasGroupCache;

		private bool _groupsAllowInteraction;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool iYqRpkmMnUjFyaotbVhGmoqkshir;

		[NonSerialized]
		private bool NyqjlerkFIBOqcrEsbpspnhzlBWn;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents;

		private static InteractionStateTransitionArgs _transitionArgs;

		private stlYYrlogjOzidIPUgNgkVVVmZH.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private stlYYrlogjOzidIPUgNgkVVVmZH.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static stlYYrlogjOzidIPUgNgkVVVmZH.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		private stlYYrlogjOzidIPUgNgkVVVmZH.HierarchyEventHelper<IVisibilityChangedHandler, bool> hierarchyVisibilityChangedHandlers => null;

		private stlYYrlogjOzidIPUgNgkVVVmZH.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> hierarchyInteractionStateTransitionHandlers => null;

		public bool interactable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public bool hideWhenIdle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MouseButtonFlags allowedMouseButtons
		{
			get
			{
				return default(MouseButtonFlags);
			}
			set
			{
			}
		}

		public TransitionTypeFlags transitionType
		{
			get
			{
				return default(TransitionTypeFlags);
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

		public InteractionState interactionState => default(InteractionState);

		internal static stlYYrlogjOzidIPUgNgkVVVmZH.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> interactionStateTransitionHandlerDelegate => null;

		public event UnityAction<InteractionStateTransitionArgs> InteractionStateSetEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<bool> VisibilityChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction InteractionStateChangedToNormal
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction InteractionStateChangedToHighlighted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction InteractionStateChangedToPressed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction InteractionStateChangedToDisabled
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		internal TouchInteractable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDidApplyAnimationProperties()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
		}

		internal override void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		internal override void RwvSBPnVuQMkWanLZtawvVoluWr()
		{
		}

		private void JbBDhUGqGQJqgdhNdnZiYJVvdBGO()
		{
		}

		private void cYGadsNABRUwoxLkKpdXiDVewMW(InteractionState P_0, bool P_1)
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

		private void DeIhupdHDdHXVSkozrZpciJVHYi(bool P_0)
		{
		}

		public bool IsInteractable()
		{
			return false;
		}

		internal virtual bool oehOykmIxezsoQoHcgcpCBDSNgC()
		{
			return false;
		}

		internal void NQuqMPKYXPeydLYsVoYpmWimoRx(BaseEventData P_0)
		{
		}

		internal virtual bool xlXQBhwolTgrrjPRJxnvItTggCjf(GameObject P_0)
		{
			return false;
		}

		private bool pSBLdSqqAgSvRNXrolZsiqsKdak(BaseEventData P_0)
		{
			return false;
		}

		private bool pSBLdSqqAgSvRNXrolZsiqsKdak(bool P_0, GameObject P_1)
		{
			return false;
		}

		private InteractionState EFvBNekXmwBPogwIbQoindNrdEAW(BaseEventData P_0)
		{
			return default(InteractionState);
		}

		private bool cHvkPNucgwIelhZlMztFMmuwNPxD(InteractionState P_0)
		{
			return false;
		}

		private void nrSdoZpBWdgEPRHTDgNVjekWTom()
		{
		}

		private void jtcuwSNRkFZqdKbaTOoJGaiXBnL()
		{
		}

		private void gzwPpsgHxRCLyyPctkGHOamHQYX(bool P_0, bool P_1)
		{
		}

		private void EbeocBoRVXuOBhBJOHuWpNRKanm()
		{
		}

		private void AyfhvAcnUrtFhwPRMjnYEritBQA()
		{
		}

		private void bvTAFhqERolFHfOeXbNxGuHwuYYG()
		{
		}

		private void KfJoWiLLFKwEXHStJvzOYcDjVDY()
		{
		}

		internal virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		internal virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		internal virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		internal virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		internal virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		internal virtual void OnDrag(PointerEventData eventData)
		{
		}

		internal virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		internal static bool fKRnKPAtIxHilfMnAXmBRScIChTf(int P_0)
		{
			return false;
		}

		internal static Vector3 IurnnXLSUcpVcAHCRFCYnCihTQo(int P_0)
		{
			return default(Vector3);
		}

		internal static bool itLqycYlSoLOiBAdtzbIshDLjdo(int P_0)
		{
			return false;
		}

		internal static bool xkuJZurlLkLVtPLvCcUwlRogwgM(int P_0)
		{
			return false;
		}

		private static int BnfBgyoNfdiJglWQNQTaAGJVisF(int P_0)
		{
			return 0;
		}

		internal static bool LyPetBVBzrbcqejMIzeMNtZqjVw(MouseButtonFlags P_0, int P_1)
		{
			return false;
		}

		private static bool bHSQRNSYizaOPpkyVSZimqizpSf(MouseButtonFlags P_0, int P_1)
		{
			return false;
		}

		private static int KSlRgMJWIgGEtQVJoKiWhRRapCs(int P_0)
		{
			return 0;
		}

		internal static bool MOzxoncHgDzoIpWtQoJJwwhCTkc(MouseButtonFlags P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		internal static bool LyPetBVBzrbcqejMIzeMNtZqjVw(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			return false;
		}

		internal static bool EFfXaJToauETGPuKxffgChIgfqWG(MouseButtonFlags P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private void bGLtYUFGZnXsDFHvBRDIbaKjAfu(bool P_0)
		{
		}

		[CompilerGenerated]
		private static void fqkQDZLVpGXgaUpWqVvZNHJDJGJ(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
		{
		}
	}
}
