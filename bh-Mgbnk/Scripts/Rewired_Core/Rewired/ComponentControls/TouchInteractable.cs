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
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public abstract class TouchInteractable : TouchControl, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
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
			private TouchInteractable YoxzlVOaOrbIxcfkxRIBWJjneXGCb;

			private InteractionState ZTwYNOqGSlPEfCFLHPEusLawNgvt;

			private float AzRTxaZWUhLpUyCwgLMbmYbYRddL;

			public TouchInteractable sender => null;

			public InteractionState state => default(InteractionState);

			public float duration => 0f;

			internal InteractionStateTransitionArgs()
			{
			}

			internal void xwMcOwQCJkbnEnkOCdsifigZyoXW(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
			}
		}

		public interface IInteractionStateTransitionHandler
		{
			void OnInteractionStateTransition(InteractionStateTransitionArgs data);
		}

		[Serializable]
		private sealed class MTcCCmZzDTIWWpmTxRRSDQHBhdkK
		{
			public static readonly MTcCCmZzDTIWWpmTxRRSDQHBhdkK _003C_003E9;

			public static VRubiuUbWcigTnrJaYOjDhZZJCsd.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> _003C_003E9__152_0;

			internal void oJBeVagLFQbtTMcRJjjhaeDmsbiw(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
			{
			}
		}

		public const int POINTER_ID_NULL = -2147483648;

		public const int POINTER_ID_MOUSE_LEFT_BUTTON = -1;

		public const int POINTER_ID_MOUSE_RIGHT_BUTTON = -2;

		public const int POINTER_ID_MOUSE_MIDDLE_BUTTON = -3;

		internal const int MAX_MOUSE_BUTTONS = 3;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the control can be interacted with by the user.")]
		private bool _interactable;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		private bool _hideWhenIdle;

		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(MouseButtonFlags))]
		private MouseButtonFlags _allowedMouseButtons;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[Bitmask(typeof(TransitionTypeFlags))]
		private TransitionTypeFlags _transitionType;

		[Tooltip("Settings using for Color Tint transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ColorBlock _transitionColorTint;

		[Tooltip("Settings using for Sprite State transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SpriteState _transitionSpriteState;

		[Tooltip("Settings using for Animation Trigger transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AnimationTriggers _transitionAnimationTriggers;

		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Graphic _targetGraphic;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the Interaction State changes.")]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when visibility changes.")]
		private VisibilityChangedEventHandler _onVisibilityChanged;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Normal.")]
		private UnityEvent _onInteractionStateChangedToNormal;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		private UnityEvent _onInteractionStateChangedToHighlighted;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Pressed.")]
		private UnityEvent _onInteractionStateChangedToPressed;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Disabled.")]
		private UnityEvent _onInteractionStateChangedToDisabled;

		private readonly List<CanvasGroup> _canvasGroupCache;

		private bool _groupsAllowInteraction;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool wClICzBvetppzLQOtPzTmrbeSAFHb;

		[NonSerialized]
		private bool aahCrujdIVaPZilYNpCwRyJPlvMw;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents;

		private static InteractionStateTransitionArgs _transitionArgs;

		private VRubiuUbWcigTnrJaYOjDhZZJCsd.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private VRubiuUbWcigTnrJaYOjDhZZJCsd.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static VRubiuUbWcigTnrJaYOjDhZZJCsd.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		private VRubiuUbWcigTnrJaYOjDhZZJCsd.HierarchyEventHelper<IVisibilityChangedHandler, bool> FVbLGlfJnUyURZfFgxqwMggVxnJ => null;

		private VRubiuUbWcigTnrJaYOjDhZZJCsd.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> DYXKzbvTpQLsfjymhoTErLaYIFNl => null;

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

		internal static VRubiuUbWcigTnrJaYOjDhZZJCsd.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> vhGEdeascCveThdbiGqhFuIEgMuy => null;

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

		internal override void PCavBKUOTQxjogDkKkwMMvzHZTRh()
		{
		}

		internal override void qtZqEKmcBeznBvpwZlLBySPsIsmM()
		{
		}

		private void VEPRWhRzzERRAERQewsgCCDkamJy()
		{
		}

		private void YvcGSeDNUNUaecAOQWsrybwXABjp(InteractionState P_0, bool P_1)
		{
		}

		private void TIoemVcutdssFDqWtKCtwVmKZmev(Color P_0, bool P_1)
		{
		}

		private void SmxjfuAtuqDwhkRDiKuEFQzYJXZM(Sprite P_0)
		{
		}

		private void kRhYNrTOTGPzyGETcYnEDmiFjKsi(string P_0)
		{
		}

		private void DcOodNjPrFAqwYRVLMUUqLLPEBnc(bool P_0)
		{
		}

		public bool IsInteractable()
		{
			return false;
		}

		internal virtual bool SjGLqQCXTLpKRhCblQEzSnJNvLxp()
		{
			return false;
		}

		internal void rSDKCytBOZjlcqojShANaYpxeOoCA(BaseEventData P_0)
		{
		}

		internal virtual bool muEjuLNOgxFpTfrtZBaeqossxvzd(GameObject P_0)
		{
			return false;
		}

		private bool xJppmiJWhlJHmpMmLoMgFkpXciyz(BaseEventData P_0)
		{
			return false;
		}

		private bool HIplkJyURnwHTHoOdWzWCxceVCaG(bool P_0, GameObject P_1)
		{
			return false;
		}

		private InteractionState FQNEKGFCOPCCIFQnxGDseLfhoePib(BaseEventData P_0)
		{
			return default(InteractionState);
		}

		private bool iCLqyYcXkBfVwBgVvYnJkEdTQKJI(InteractionState P_0)
		{
			return false;
		}

		private void UFTxADUzumNnqQMGJHaSAFTWxBHR()
		{
		}

		private void qDCRNUNhPtjVVhefYTDVVnpqtEEkA()
		{
		}

		private void bxMAaapbTaAfSjIJxiEQkvcubOnvA(bool P_0, bool P_1)
		{
		}

		private void rQhSBBPwGDMjNLawqCTmYzXHUgoj()
		{
		}

		private void RkrKcSzeuzNZFqQOvdfhKLyjDjbFA()
		{
		}

		private void cKBtCmIzAfmTQiQQekCMNmyIjnBn()
		{
		}

		private void obCJfPDDNTcRugcslJIIEPKKpUjhb()
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

		internal static bool INUPjGWqdlwyKMAtpgAYFcnTXXMSA(int P_0)
		{
			return false;
		}

		internal static Vector3 BCPeAGoHmajmVdrEpKshcTFpjvWeA(int P_0)
		{
			return default(Vector3);
		}

		internal static bool HyBlOAWZFzRvGEiINAIuhMtplyTC(int P_0)
		{
			return false;
		}

		internal static bool kTioofhhGVvCxLoXdTDTFcZNaMvCA(int P_0)
		{
			return false;
		}

		private static int ZIQCMOENUKdrCTmibFCTuSNziezAb(int P_0)
		{
			return 0;
		}

		internal static bool YlaZcikOPYjJLzQtmQATJPccTxrJ(MouseButtonFlags P_0, int P_1)
		{
			return false;
		}

		private static bool sgAzekEENDtrEtcjoHRNGZyiVfZIA(MouseButtonFlags P_0, int P_1)
		{
			return false;
		}

		private static int WTVDhalFSJAIHgMmQpeuNlyNSkBA(int P_0)
		{
			return 0;
		}

		internal static bool lyEXdLAndjWqCDgKIbjWiFwUfTRcb(MouseButtonFlags P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		internal static bool ESeWtKCEBMvaJODaafiEfambrfsB(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			return false;
		}

		internal static bool oSIyXpZCVZIJmeTLCvTrtnwAALBW(MouseButtonFlags P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private void ZUTYBlrzjAfHvrlTASvUhLuGoEZo(bool P_0)
		{
		}
	}
}
