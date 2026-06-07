using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.ComponentControls
{
	[Serializable]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
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
			private TouchInteractable yjBLrkrbcHecPSuvACXBJatGbNBe;

			private InteractionState OZZuGcZlelfrvaxSrmPvOUZyCuXl;

			private float tWLfjFAJAauPfMUhyfCTXTjxCvuN;

			public TouchInteractable sender => null;

			public InteractionState state => default(InteractionState);

			public float duration => 0f;

			internal InteractionStateTransitionArgs()
			{
			}

			internal void ClCJMtZZeVUEysnoiGvdioEaoEbp(TouchInteractable P_0, InteractionState P_1, float P_2)
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

		[CustomObfuscation]
		[SerializeField]
		private bool _interactable;

		[CustomObfuscation]
		[SerializeField]
		private bool _visible;

		[SerializeField]
		[CustomObfuscation]
		private bool _hideWhenIdle;

		[CustomObfuscation]
		[SerializeField]
		private MouseButtonFlags _allowedMouseButtons;

		[CustomObfuscation]
		[SerializeField]
		private TransitionTypeFlags _transitionType;

		[CustomObfuscation]
		[SerializeField]
		private ColorBlock _transitionColorTint;

		[SerializeField]
		[CustomObfuscation]
		private SpriteState _transitionSpriteState;

		[SerializeField]
		[CustomObfuscation]
		private AnimationTriggers _transitionAnimationTriggers;

		[CustomObfuscation]
		[SerializeField]
		private Graphic _targetGraphic;

		[SerializeField]
		[CustomObfuscation]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition;

		[CustomObfuscation]
		[SerializeField]
		private VisibilityChangedEventHandler _onVisibilityChanged;

		[SerializeField]
		[CustomObfuscation]
		private UnityEvent _onInteractionStateChangedToNormal;

		[CustomObfuscation]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToHighlighted;

		[SerializeField]
		[CustomObfuscation]
		private UnityEvent _onInteractionStateChangedToPressed;

		[CustomObfuscation]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToDisabled;

		private readonly List<CanvasGroup> _canvasGroupCache;

		private bool _groupsAllowInteraction;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool jpHFALOLDsUlucqzzUZuYLLBnXs;

		[NonSerialized]
		private bool KqHBQBNHrkGLwntKsACAVNIMLBU;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents;

		private static InteractionStateTransitionArgs _transitionArgs;

		private jiAimQXWlXowirDyUeIMGqAsZDV.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private jiAimQXWlXowirDyUeIMGqAsZDV.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static jiAimQXWlXowirDyUeIMGqAsZDV.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		private jiAimQXWlXowirDyUeIMGqAsZDV.HierarchyEventHelper<IVisibilityChangedHandler, bool> hierarchyVisibilityChangedHandlers => null;

		private jiAimQXWlXowirDyUeIMGqAsZDV.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> hierarchyInteractionStateTransitionHandlers => null;

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

		internal static jiAimQXWlXowirDyUeIMGqAsZDV.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> interactionStateTransitionHandlerDelegate => null;

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

		[CustomObfuscation]
		internal TouchInteractable()
		{
		}

		[CustomObfuscation]
		internal override void Awake()
		{
		}

		[CustomObfuscation]
		internal override void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation]
		internal override void OnDidApplyAnimationProperties()
		{
		}

		[CustomObfuscation]
		internal override void OnEnable()
		{
		}

		[CustomObfuscation]
		internal override void OnDisable()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation]
		internal override void Reset()
		{
		}

		internal override void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		internal override void EUAcigCVtcdNGimfhNGKNDeeSwJn()
		{
		}

		private void OpkZfQOoimpucbLizkCUnoGCBeY()
		{
		}

		private void xffgPHrvnrcdgfhkGFMffAuXjMCO(InteractionState P_0, bool P_1)
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

		private void KYjHDWJKlPlCVCfuzVuDISoukCg(bool P_0)
		{
		}

		public bool IsInteractable()
		{
			return false;
		}

		internal virtual bool dBCYcNAjoSqmwCdqowZTiusxKJK()
		{
			return false;
		}

		internal void IcJdSrIgkxStgjJETONqkSpTraDd(BaseEventData P_0)
		{
		}

		internal virtual bool wByjfGONJngXzFPsNQZLuqsRAef(GameObject P_0)
		{
			return false;
		}

		private bool aXqXanIAmKaoHFKjgUkCQuNhAei(BaseEventData P_0)
		{
			return false;
		}

		private bool aXqXanIAmKaoHFKjgUkCQuNhAei(bool P_0, GameObject P_1)
		{
			return false;
		}

		private InteractionState JhArFTlOuOSEoaIPKDbCLCyIWvS(BaseEventData P_0)
		{
			return default(InteractionState);
		}

		private bool dnAfxiQZWWhynPzXKAXjGHONDGr(InteractionState P_0)
		{
			return false;
		}

		private void yNlUVyDdaPAtHCJDNlcfDHXidiez()
		{
		}

		private void aOHMAvhGMjcQrDCeJblvfiJBcDZr()
		{
		}

		private void xPPTbJYPHhGHieHgnbzxiTVuGUP(bool P_0, bool P_1)
		{
		}

		private void RXFSKeWuzpqbJbmNCnoaJjqhFmmh()
		{
		}

		private void BVSVBdUCXJIidkvFIsSmkeGGbXK()
		{
		}

		private void kckhtUMxbCHYHtoyNtsHEKeNtSU()
		{
		}

		private void RwSDEfIjluxnCSNKTTQPggNUQRAO()
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

		internal static bool epmyWgiPcBvZtrKpGLDjhfBhBbL(int P_0)
		{
			return false;
		}

		internal static Vector3 DdSNFgpmaChmcQEQRxuwBFNANTg(int P_0)
		{
			return default(Vector3);
		}

		internal static bool bOsnQHknwGqQwVWvpUXgEGwiezs(int P_0)
		{
			return false;
		}

		internal static bool qcJdFNPidCiAlNllYwnSTZJDTkU(int P_0)
		{
			return false;
		}

		private static int AGEfELMUPVItazeMXhvYwdmgxaV(int P_0)
		{
			return 0;
		}

		internal static bool WVcVKctDnVuoyuoxQGKepGYLPly(MouseButtonFlags P_0, int P_1)
		{
			return false;
		}

		private static bool mljjSeuUSVFkTbOkBuhGQrHSIsh(MouseButtonFlags P_0, int P_1)
		{
			return false;
		}

		private static int XjEIzhxGcINdlKoJeXIcVsoVKpi(int P_0)
		{
			return 0;
		}

		internal static bool DLEUHMKiIlhwKHhpWHJxrIOtNTqM(MouseButtonFlags P_0, out int P_1)
		{
			P_1 = default(int);
			return false;
		}

		internal static bool WVcVKctDnVuoyuoxQGKepGYLPly(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			return false;
		}

		internal static bool NiCCGkvbQOAPWHdObOBGNvfHgZK(MouseButtonFlags P_0)
		{
			return false;
		}

		[CompilerGenerated]
		private void eqksRdfmnNGEXNiZVYkaNlbSMUu(bool P_0)
		{
		}

		[CompilerGenerated]
		private static void wlFLyclaZkFCuORIejszJxeeiFNU(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
		{
		}
	}
}
