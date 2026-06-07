using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;
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
			private TouchInteractable FyNInHlcfpfhBdcWggMMVbkZorCM;

			private InteractionState UTQmkSTjdvnEZOAhSbUbayzAuSfy;

			private float DNjsgamIzfXysmBKjFXwoyamdYvg;

			public TouchInteractable sender => FyNInHlcfpfhBdcWggMMVbkZorCM;

			public InteractionState state => UTQmkSTjdvnEZOAhSbUbayzAuSfy;

			public float duration => DNjsgamIzfXysmBKjFXwoyamdYvg;

			internal InteractionStateTransitionArgs()
			{
			}

			internal void wpuGJcpkiojAeFvsBvchNhbjnYDOA(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
				FyNInHlcfpfhBdcWggMMVbkZorCM = P_0;
				UTQmkSTjdvnEZOAhSbUbayzAuSfy = P_1;
				DNjsgamIzfXysmBKjFXwoyamdYvg = P_2;
			}
		}

		public interface IInteractionStateTransitionHandler
		{
			void OnInteractionStateTransition(InteractionStateTransitionArgs data);
		}

		[Serializable]
		private sealed class VSAQnmurgFMpchsnaqNBBfUxlBun
		{
			public static readonly VSAQnmurgFMpchsnaqNBBfUxlBun _003C_003E9 = new VSAQnmurgFMpchsnaqNBBfUxlBun();

			public static YVQfKeazIqgFlQlVhbEkyBsluncmA.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> _003C_003E9__152_0;

			internal void hOvsNgVjeWiUdWLfEWrwkPAIiNybA(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
			{
				P_0.OnInteractionStateTransition(P_1);
			}
		}

		public const int POINTER_ID_NULL = int.MinValue;

		public const int POINTER_ID_MOUSE_LEFT_BUTTON = -1;

		public const int POINTER_ID_MOUSE_RIGHT_BUTTON = -2;

		public const int POINTER_ID_MOUSE_MIDDLE_BUTTON = -3;

		internal const int MAX_MOUSE_BUTTONS = 3;

		[SerializeField]
		[Tooltip("Toggles whether the control can be interacted with by the user.")]
		[CustomObfuscation(rename = false)]
		private bool _interactable = true;

		[SerializeField]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		[CustomObfuscation(rename = false)]
		private bool _visible = true;

		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _hideWhenIdle;

		[Bitmask(typeof(MouseButtonFlags))]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		private MouseButtonFlags _allowedMouseButtons = MouseButtonFlags.LeftButton;

		[SerializeField]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(TransitionTypeFlags))]
		private TransitionTypeFlags _transitionType;

		[Tooltip("Settings using for Color Tint transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Graphic _targetGraphic;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when the Interaction State changes.")]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition = new InteractionStateTransitionEventHandler();

		[SerializeField]
		[Tooltip("Event sent when visibility changes.")]
		[CustomObfuscation(rename = false)]
		private VisibilityChangedEventHandler _onVisibilityChanged = new VisibilityChangedEventHandler();

		[Tooltip("Event sent when interaction state changes to Normal.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToNormal = new UnityEvent();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		private UnityEvent _onInteractionStateChangedToHighlighted = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Pressed.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToPressed = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Disabled.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToDisabled = new UnityEvent();

		private readonly List<CanvasGroup> _canvasGroupCache = new List<CanvasGroup>();

		private bool _groupsAllowInteraction = true;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool hJTzhxIFfzQTiYkWavAlvqVGkFYb;

		[NonSerialized]
		private bool pLPhhaSJxXCgjjmmWxGfMVCxcFIqA;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents = true;

		private static InteractionStateTransitionArgs _transitionArgs = new InteractionStateTransitionArgs();

		private YVQfKeazIqgFlQlVhbEkyBsluncmA.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private YVQfKeazIqgFlQlVhbEkyBsluncmA.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static YVQfKeazIqgFlQlVhbEkyBsluncmA.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		private YVQfKeazIqgFlQlVhbEkyBsluncmA.HierarchyEventHelper<IVisibilityChangedHandler, bool> GupbiEeIkbEVobPPfEqvzkxlKtrNc
		{
			get
			{
				if (__hierarchyVisibilityChangedHandlers == null)
				{
					__hierarchyVisibilityChangedHandlers = new YVQfKeazIqgFlQlVhbEkyBsluncmA.HierarchyEventHelper<IVisibilityChangedHandler, bool>(eVvlwoVwTviDzZhjEOEIGXcYlnqI.JoqifduGFLgYSEHNXEPDJzsczLwq);
					__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
				}
				return __hierarchyVisibilityChangedHandlers;
			}
		}

		private YVQfKeazIqgFlQlVhbEkyBsluncmA.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> YobYpjKlWIwTVzuWsmFXfMluuAJj
		{
			get
			{
				if (__hierarchyInteractionStateTransitionHandlers == null)
				{
					__hierarchyInteractionStateTransitionHandlers = new YVQfKeazIqgFlQlVhbEkyBsluncmA.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs>(msaldcLCHKlWfbAJbuwsRrRimaet);
					__hierarchyInteractionStateTransitionHandlers.GetHandlers(base.transform);
				}
				return __hierarchyInteractionStateTransitionHandlers;
			}
		}

		public bool interactable
		{
			get
			{
				return _interactable;
			}
			set
			{
				if (_interactable != value)
				{
					_interactable = value;
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

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
					oQkqrcUQooqIwfXjwVSDfhjSMgzr(value, false);
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

		public bool hideWhenIdle
		{
			get
			{
				return _hideWhenIdle;
			}
			set
			{
				if (_hideWhenIdle != value)
				{
					_hideWhenIdle = value;
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

		public MouseButtonFlags allowedMouseButtons
		{
			get
			{
				return _allowedMouseButtons;
			}
			set
			{
				if (_allowedMouseButtons != value)
				{
					_allowedMouseButtons = value;
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

		public TransitionTypeFlags transitionType
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
				GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
				if (_transitionAnimationTriggers != value)
				{
					_transitionAnimationTriggers = value;
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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
				if (!(_targetGraphic == value))
				{
					_targetGraphic = value;
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
				}
			}
		}

		public Animator animator => base.gameObject.GetComponent<Animator>();

		public InteractionState interactionState => _interactionState;

		internal static YVQfKeazIqgFlQlVhbEkyBsluncmA.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> msaldcLCHKlWfbAJbuwsRrRimaet
		{
			get
			{
				if (__interactionStateTransitionHandlerDelegate == null)
				{
					__interactionStateTransitionHandlerDelegate = VSAQnmurgFMpchsnaqNBBfUxlBun._003C_003E9.hOvsNgVjeWiUdWLfEWrwkPAIiNybA;
				}
				return __interactionStateTransitionHandlerDelegate;
			}
		}

		public event UnityAction<InteractionStateTransitionArgs> InteractionStateSetEvent
		{
			add
			{
				_onInteractionStateTransition.AddListener(value);
			}
			remove
			{
				_onInteractionStateTransition.RemoveListener(value);
			}
		}

		public event UnityAction<bool> VisibilityChangedEvent
		{
			add
			{
				_onVisibilityChanged.AddListener(value);
			}
			remove
			{
				_onVisibilityChanged.RemoveListener(value);
			}
		}

		public event UnityAction InteractionStateChangedToNormal
		{
			add
			{
				_onInteractionStateChangedToNormal.AddListener(value);
			}
			remove
			{
				_onInteractionStateChangedToNormal.RemoveListener(value);
			}
		}

		public event UnityAction InteractionStateChangedToHighlighted
		{
			add
			{
				_onInteractionStateChangedToHighlighted.AddListener(value);
			}
			remove
			{
				_onInteractionStateChangedToHighlighted.RemoveListener(value);
			}
		}

		public event UnityAction InteractionStateChangedToPressed
		{
			add
			{
				_onInteractionStateChangedToPressed.AddListener(value);
			}
			remove
			{
				_onInteractionStateChangedToPressed.RemoveListener(value);
			}
		}

		public event UnityAction InteractionStateChangedToDisabled
		{
			add
			{
				_onInteractionStateChangedToDisabled.AddListener(value);
			}
			remove
			{
				_onInteractionStateChangedToDisabled.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		internal TouchInteractable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			if (Application.isPlaying)
			{
				if (_targetGraphic == null)
				{
					_targetGraphic = base.gameObject.GetComponent<Graphic>();
				}
				iHBlpDkwpHpbjROOnMQpWFQzVuyV();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			bool flag = true;
			Transform parent = base.transform;
			while (parent != null)
			{
				parent.GetComponents(_canvasGroupCache);
				bool flag2 = false;
				for (int i = 0; i < _canvasGroupCache.Count; i++)
				{
					if (!_canvasGroupCache[i].interactable)
					{
						flag = false;
						flag2 = true;
					}
					if (_canvasGroupCache[i].ignoreParentGroups)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					break;
				}
				parent = parent.parent;
			}
			if (flag != _groupsAllowInteraction)
			{
				_groupsAllowInteraction = flag;
				fptrtufnrpaQomaApSpHHlZoBHVd();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDidApplyAnimationProperties()
		{
			base.OnDidApplyAnimationProperties();
			fptrtufnrpaQomaApSpHHlZoBHVd();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!Application.isPlaying)
			{
				iHBlpDkwpHpbjROOnMQpWFQzVuyV();
			}
			fWpDpIVsDRQtGJmxeQOEqhkfcsBL(InteractionState.Normal);
			WyoeRRAKgForKYQrMlITPeErpcPYA(true);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			YGxiizcFKQlkcCqgtUyzMeSYDAHT();
			base.OnDisable();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			if (DfQIcSJUPXlHPQKgUHsgOrKCBhBG())
			{
				if (!_interactable && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
				{
					EventSystem.current.SetSelectedGameObject(null);
				}
				BBLFQapWNonTVqanzssFVUqmDjNU(null);
				IeQNTBXYjzHzTymQiWmOyluoOwJB(Color.white, true);
				zhDqtloOcYwcQQopnEUPXjfpWNyR(_transitionAnimationTriggers.normalTrigger);
				WyoeRRAKgForKYQrMlITPeErpcPYA(true);
			}
			lzyAWFqxsDbeSkCOeBWDRGXRbmtDA();
			fptrtufnrpaQomaApSpHHlZoBHVd();
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
			_allowedMouseButtons = MouseButtonFlags.LeftButton;
			base.Reset();
		}

		internal virtual void UrxvCbTTyrcwzAlwHnkPcfjwZqaC()
		{
			sVZbmmHAbiYamQYGsWiqCcsiLjic();
			fptrtufnrpaQomaApSpHHlZoBHVd();
		}

		internal virtual void VPtGcdIWFwGqODRIGeBhZDUxQRBJA()
		{
			base.zufrCMNxgeKWhzoQOBSWuDAOKOwh();
			lzyAWFqxsDbeSkCOeBWDRGXRbmtDA();
		}

		private void YGxiizcFKQlkcCqgtUyzMeSYDAHT()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			hJTzhxIFfzQTiYkWavAlvqVGkFYb = false;
			pLPhhaSJxXCgjjmmWxGfMVCxcFIqA = false;
			if ((_transitionType & TransitionTypeFlags.ColorTint) != TransitionTypeFlags.None)
			{
				IeQNTBXYjzHzTymQiWmOyluoOwJB(Color.white, true);
			}
			if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
			{
				BBLFQapWNonTVqanzssFVUqmDjNU(null);
			}
			if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
			{
				zhDqtloOcYwcQQopnEUPXjfpWNyR(normalTrigger);
			}
		}

		private void LDYQrwgNbDQbEcQyPAYcuafjhnlT(InteractionState P_0, bool P_1)
		{
			Color color;
			Sprite sprite;
			string text;
			UnityEvent unityEvent;
			switch (P_0)
			{
			case InteractionState.Normal:
				color = _transitionColorTint.normalColor;
				sprite = null;
				text = _transitionAnimationTriggers.normalTrigger;
				unityEvent = _onInteractionStateChangedToNormal;
				break;
			case InteractionState.Highlighted:
				color = _transitionColorTint.highlightedColor;
				sprite = _transitionSpriteState.highlightedSprite;
				text = _transitionAnimationTriggers.highlightedTrigger;
				unityEvent = _onInteractionStateChangedToHighlighted;
				break;
			case InteractionState.Pressed:
				color = _transitionColorTint.pressedColor;
				sprite = _transitionSpriteState.pressedSprite;
				text = _transitionAnimationTriggers.pressedTrigger;
				unityEvent = _onInteractionStateChangedToPressed;
				break;
			case InteractionState.Disabled:
				color = _transitionColorTint.disabledColor;
				sprite = _transitionSpriteState.disabledSprite;
				text = _transitionAnimationTriggers.disabledTrigger;
				unityEvent = _onInteractionStateChangedToDisabled;
				break;
			default:
				color = Color.black;
				sprite = null;
				text = string.Empty;
				unityEvent = null;
				break;
			}
			bool flag = (_transitionType & TransitionTypeFlags.ColorTint) != 0;
			if (!flag)
			{
				color = Color.white;
			}
			if (!_visible)
			{
				color.a = 0f;
			}
			if (base.gameObject.activeInHierarchy)
			{
				if (flag)
				{
					IeQNTBXYjzHzTymQiWmOyluoOwJB(color * _transitionColorTint.colorMultiplier, P_1);
				}
				else
				{
					IeQNTBXYjzHzTymQiWmOyluoOwJB(color, P_1);
				}
				if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
				{
					BBLFQapWNonTVqanzssFVUqmDjNU(sprite);
				}
				if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
				{
					zhDqtloOcYwcQQopnEUPXjfpWNyR(text);
				}
			}
			if (_allowSendingEvents)
			{
				_transitionArgs.wpuGJcpkiojAeFvsBvchNhbjnYDOA(this, P_0, P_1 ? 0f : _transitionColorTint.fadeDuration);
				YobYpjKlWIwTVzuWsmFXfMluuAJj.ExecuteOnAll(_transitionArgs);
				if (_onInteractionStateTransition != null)
				{
					_onInteractionStateTransition.Invoke(_transitionArgs);
				}
				unityEvent?.Invoke();
			}
		}

		private void IeQNTBXYjzHzTymQiWmOyluoOwJB(Color P_0, bool P_1)
		{
			if (!(_targetGraphic == null))
			{
				_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void BBLFQapWNonTVqanzssFVUqmDjNU(Sprite P_0)
		{
			if (!(image == null))
			{
				image.overrideSprite = P_0;
			}
		}

		private void zhDqtloOcYwcQQopnEUPXjfpWNyR(string P_0)
		{
			if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None && !(animator == null) && UnityTools.IsActiveAndEnabled(animator) && !(animator.runtimeAnimatorController == null) && !string.IsNullOrEmpty(P_0))
			{
				animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
				animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
				animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
				animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
				animator.SetTrigger(P_0);
			}
		}

		private void WyoeRRAKgForKYQrMlITPeErpcPYA(bool P_0)
		{
			InteractionState interactionState = _interactionState;
			if (DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && !IsInteractable())
			{
				interactionState = InteractionState.Disabled;
			}
			LDYQrwgNbDQbEcQyPAYcuafjhnlT(interactionState, P_0);
		}

		public bool IsInteractable()
		{
			if (_groupsAllowInteraction)
			{
				return _interactable;
			}
			return false;
		}

		internal virtual bool HpmTdMtQcZfhtraXmCUiIBYzbvdhA()
		{
			if (!DfQIcSJUPXlHPQKgUHsgOrKCBhBG())
			{
				return false;
			}
			if (hJTzhxIFfzQTiYkWavAlvqVGkFYb)
			{
				return pLPhhaSJxXCgjjmmWxGfMVCxcFIqA;
			}
			return false;
		}

		internal void qTbQveApfHOMSehJBxKYMzaVLcgX(BaseEventData P_0)
		{
			if (DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable())
			{
				InteractionState interactionState = GjvFfYsyhRjlwLtZssVtJxaDmYFP(P_0);
				if (interactionState != _interactionState)
				{
					fWpDpIVsDRQtGJmxeQOEqhkfcsBL(interactionState);
					WyoeRRAKgForKYQrMlITPeErpcPYA(false);
				}
			}
		}

		internal virtual bool xEwQUZcqFhGubfvZUNKxwzzGTqdF(GameObject P_0)
		{
			return base.gameObject == P_0;
		}

		private bool sBTJJuaTQpaYYzeGQCBfBpenWPag(BaseEventData P_0)
		{
			bool flag = P_0 is PointerEventData;
			return WDJiERFVpjCXhCJYBgAVlQqYCposb(flag, flag ? (P_0 as PointerEventData).pointerPress : null);
		}

		private bool WDJiERFVpjCXhCJYBgAVlQqYCposb(bool P_0, GameObject P_1)
		{
			if (!DfQIcSJUPXlHPQKgUHsgOrKCBhBG())
			{
				return false;
			}
			if (HpmTdMtQcZfhtraXmCUiIBYzbvdhA())
			{
				return false;
			}
			bool flag = false;
			if (P_0)
			{
				return flag | ((pLPhhaSJxXCgjjmmWxGfMVCxcFIqA && !hJTzhxIFfzQTiYkWavAlvqVGkFYb && xEwQUZcqFhGubfvZUNKxwzzGTqdF(P_1)) || (!pLPhhaSJxXCgjjmmWxGfMVCxcFIqA && hJTzhxIFfzQTiYkWavAlvqVGkFYb && xEwQUZcqFhGubfvZUNKxwzzGTqdF(P_1)) || (!pLPhhaSJxXCgjjmmWxGfMVCxcFIqA && hJTzhxIFfzQTiYkWavAlvqVGkFYb && P_1 == null));
			}
			return flag | hJTzhxIFfzQTiYkWavAlvqVGkFYb;
		}

		private InteractionState GjvFfYsyhRjlwLtZssVtJxaDmYFP(BaseEventData P_0)
		{
			if (HpmTdMtQcZfhtraXmCUiIBYzbvdhA())
			{
				return InteractionState.Pressed;
			}
			if (sBTJJuaTQpaYYzeGQCBfBpenWPag(P_0))
			{
				return InteractionState.Highlighted;
			}
			return InteractionState.Normal;
		}

		private bool fWpDpIVsDRQtGJmxeQOEqhkfcsBL(InteractionState P_0)
		{
			if (_interactionState == P_0)
			{
				return false;
			}
			_interactionState = P_0;
			TtjldDxDBgMpUKeeSGyRKxEaHnJw();
			return true;
		}

		private void TtjldDxDBgMpUKeeSGyRKxEaHnJw()
		{
			xvmyiGcSerwUpwdLLJHKzBmIcuAq();
		}

		private void xvmyiGcSerwUpwdLLJHKzBmIcuAq()
		{
			if (Application.isPlaying && _hideWhenIdle)
			{
				oQkqrcUQooqIwfXjwVSDfhjSMgzr(_interactionState == InteractionState.Pressed, false);
			}
		}

		private void oQkqrcUQooqIwfXjwVSDfhjSMgzr(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			_visible = P_0;
			_varWatch_visible = P_0;
			if (_allowSendingEvents)
			{
				GupbiEeIkbEVobPPfEqvzkxlKtrNc.ExecuteOnAll(P_0);
				if (_onVisibilityChanged != null)
				{
					_onVisibilityChanged.Invoke(P_0);
				}
			}
		}

		private void iHBlpDkwpHpbjROOnMQpWFQzVuyV()
		{
			_varWatch_visible = _visible;
			_varWatch_interactable = IsInteractable();
			using (new SetAndRestoreVar<bool>(_allowSendingEvents, false, delegate(bool P_0)
			{
				_allowSendingEvents = P_0;
			}))
			{
				oQkqrcUQooqIwfXjwVSDfhjSMgzr(_visible, true);
				xvmyiGcSerwUpwdLLJHKzBmIcuAq();
			}
			lzyAWFqxsDbeSkCOeBWDRGXRbmtDA();
			if (_allowSendingEvents)
			{
				GupbiEeIkbEVobPPfEqvzkxlKtrNc.ExecuteOnAll(_visible);
				if (_onVisibilityChanged != null)
				{
					_onVisibilityChanged.Invoke(_visible);
				}
			}
		}

		private void McHEPYWFVjGorBeukirgpOhZGTzWA()
		{
			if (_varWatch_visible != _visible)
			{
				_varWatch_visible = _visible;
				if (_allowSendingEvents && _onVisibilityChanged != null)
				{
					GupbiEeIkbEVobPPfEqvzkxlKtrNc.ExecuteOnAll(_visible);
					_onVisibilityChanged.Invoke(_visible);
				}
			}
		}

		private void fptrtufnrpaQomaApSpHHlZoBHVd()
		{
			McHEPYWFVjGorBeukirgpOhZGTzWA();
			xvmyiGcSerwUpwdLLJHKzBmIcuAq();
			if (!Application.isPlaying)
			{
				WyoeRRAKgForKYQrMlITPeErpcPYA(true);
			}
			else
			{
				WyoeRRAKgForKYQrMlITPeErpcPYA(false);
			}
		}

		private void lzyAWFqxsDbeSkCOeBWDRGXRbmtDA()
		{
			GupbiEeIkbEVobPPfEqvzkxlKtrNc.GetHandlers(base.transform);
			YobYpjKlWIwTVzuWsmFXfMluuAJj.GetHandlers(base.transform);
		}

		internal virtual void OnPointerDown(PointerEventData eventData)
		{
			if (JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerDown))
			{
				pLPhhaSJxXCgjjmmWxGfMVCxcFIqA = true;
				qTbQveApfHOMSehJBxKYMzaVLcgX(eventData);
			}
		}

		internal virtual void OnPointerUp(PointerEventData eventData)
		{
			if (JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerUp))
			{
				pLPhhaSJxXCgjjmmWxGfMVCxcFIqA = false;
				qTbQveApfHOMSehJBxKYMzaVLcgX(eventData);
			}
		}

		internal virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				hJTzhxIFfzQTiYkWavAlvqVGkFYb = true;
				qTbQveApfHOMSehJBxKYMzaVLcgX(eventData);
			}
		}

		internal virtual void OnPointerExit(PointerEventData eventData)
		{
			if (JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerExit))
			{
				hJTzhxIFfzQTiYkWavAlvqVGkFYb = false;
				qTbQveApfHOMSehJBxKYMzaVLcgX(eventData);
			}
		}

		internal virtual void OnBeginDrag(PointerEventData eventData)
		{
			JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, _allowedMouseButtons, EventTriggerType.BeginDrag);
		}

		internal virtual void OnDrag(PointerEventData eventData)
		{
			JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, _allowedMouseButtons, EventTriggerType.Drag);
		}

		internal virtual void OnEndDrag(PointerEventData eventData)
		{
			JGWFphEzfGdSUNCbtbtdWjvDOLzcb(eventData.pointerId, _allowedMouseButtons, EventTriggerType.EndDrag);
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			OnPointerDown(eventData);
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			OnPointerUp(eventData);
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			OnPointerEnter(eventData);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			OnPointerExit(eventData);
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			OnBeginDrag(eventData);
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			OnDrag(eventData);
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
			OnEndDrag(eventData);
		}

		internal static bool ZYwGYYdmSzHakANXcUYVgtqvzOUJ(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (YOjWGKtwerAoiAXAEISfxlNHfJJw(P_0))
			{
				int num = UCqtGVcdqIUipwEikYYjAKaBMvEB(P_0);
				if (num < 0)
				{
					return false;
				}
				Touch touch = Input.GetTouch(num);
				if (touch.phase != TouchPhase.Ended)
				{
					return touch.phase != TouchPhase.Canceled;
				}
				return false;
			}
			if (zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0) && Input.mousePresent)
			{
				int num2 = PkzAozGWsUqtyGsgzpbfDLskGwmeB(P_0);
				if (num2 >= 0)
				{
					return Input.GetMouseButton(num2);
				}
			}
			return false;
		}

		internal static Vector3 SlvklMDRFubBrxxwogKeezCPTKAI(int P_0)
		{
			if (YOjWGKtwerAoiAXAEISfxlNHfJJw(P_0))
			{
				int num = UCqtGVcdqIUipwEikYYjAKaBMvEB(P_0);
				if (num >= 0 && Input.touchCount > num)
				{
					return Input.touches[num].position;
				}
			}
			else if (zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0) && Input.mousePresent)
			{
				return Input.mousePosition;
			}
			return Vector3.zero;
		}

		internal static bool YOjWGKtwerAoiAXAEISfxlNHfJJw(int P_0)
		{
			return P_0 >= 0;
		}

		internal static bool zfMRdxEWpVdbDLsvqJxSDUMtmNpl(int P_0)
		{
			if (P_0 != -1 && P_0 != -3)
			{
				return P_0 == -2;
			}
			return true;
		}

		private static int UCqtGVcdqIUipwEikYYjAKaBMvEB(int P_0)
		{
			if (!YOjWGKtwerAoiAXAEISfxlNHfJJw(P_0))
			{
				return -1;
			}
			int touchCount = Input.touchCount;
			for (int i = 0; i < touchCount; i++)
			{
				if (Input.GetTouch(i).fingerId == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal static bool XMYKisHOuAMOphjZpyMUNUzWMhnV(MouseButtonFlags P_0, int P_1)
		{
			if (zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_1))
			{
				if (!Cursor.visible)
				{
					return false;
				}
				if (!Input.mousePresent)
				{
					return false;
				}
			}
			if (YOjWGKtwerAoiAXAEISfxlNHfJJw(P_1))
			{
				return true;
			}
			if (huwFYwviPBIHedLtnJhUNhcSRoNC(P_0, P_1))
			{
				return true;
			}
			return false;
		}

		private static bool huwFYwviPBIHedLtnJhUNhcSRoNC(MouseButtonFlags P_0, int P_1)
		{
			return P_1 switch
			{
				-1 => (P_0 & MouseButtonFlags.LeftButton) != 0, 
				-2 => (P_0 & MouseButtonFlags.RightButton) != 0, 
				-3 => (P_0 & MouseButtonFlags.MiddleButton) != 0, 
				_ => false, 
			};
		}

		private static int PkzAozGWsUqtyGsgzpbfDLskGwmeB(int P_0)
		{
			if (!zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0))
			{
				return -1;
			}
			return P_0 switch
			{
				-1 => 0, 
				-2 => 1, 
				-3 => 2, 
				_ => -1, 
			};
		}

		internal static bool wosOqXdFSlBXaFBgRvyXXgngpsXH(MouseButtonFlags P_0, out int P_1)
		{
			for (int i = 0; i < 3; i++)
			{
				if (((uint)P_0 & (uint)(1 << i)) != 0 && Input.GetMouseButton(i))
				{
					P_1 = (i + 1) * -1;
					return true;
				}
			}
			P_1 = int.MinValue;
			return false;
		}

		internal static bool JGWFphEzfGdSUNCbtbtdWjvDOLzcb(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			if (zfMRdxEWpVdbDLsvqJxSDUMtmNpl(P_0) && (P_2 == EventTriggerType.PointerEnter || P_2 == EventTriggerType.PointerExit) && P_1 != MouseButtonFlags.None)
			{
				P_1 |= MouseButtonFlags.LeftButton;
			}
			return XMYKisHOuAMOphjZpyMUNUzWMhnV(P_1, P_0);
		}

		internal static bool bvaavvcdoRyDQyElLKVutjdctzVO(MouseButtonFlags P_0)
		{
			int num;
			return wosOqXdFSlBXaFBgRvyXXgngpsXH(P_0, out num);
		}

		[CompilerGenerated]
		private void USnuLvIeCSaYHxHzTncJjbnskqJt(bool P_0)
		{
			_allowSendingEvents = P_0;
		}
	}
}
