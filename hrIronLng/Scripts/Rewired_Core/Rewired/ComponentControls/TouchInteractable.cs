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
			private TouchInteractable lSOWCwIlShkHWjhBwXUaJVnkenS;

			private InteractionState JtKJRkqIhLnpoEZgBhBGUCTMzVS;

			private float sOOoePepBUnPytaXYmKsFfdPzCp;

			public TouchInteractable sender => lSOWCwIlShkHWjhBwXUaJVnkenS;

			public InteractionState state => JtKJRkqIhLnpoEZgBhBGUCTMzVS;

			public float duration => sOOoePepBUnPytaXYmKsFfdPzCp;

			internal InteractionStateTransitionArgs()
			{
			}

			internal void NGXUBbcPdrBYfEJQGstImmQAGjsO(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
				lSOWCwIlShkHWjhBwXUaJVnkenS = P_0;
				JtKJRkqIhLnpoEZgBhBGUCTMzVS = P_1;
				sOOoePepBUnPytaXYmKsFfdPzCp = P_2;
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

		[Tooltip("Toggles whether the control can be interacted with by the user.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _interactable = true;

		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _visible = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		private bool _hideWhenIdle;

		[Bitmask(typeof(MouseButtonFlags))]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		private MouseButtonFlags _allowedMouseButtons = MouseButtonFlags.LeftButton;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
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

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Sprite State transitions.")]
		[SerializeField]
		private SpriteState _transitionSpriteState;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		private Graphic _targetGraphic;

		[Tooltip("Event sent when the Interaction State changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition = new InteractionStateTransitionEventHandler();

		[Tooltip("Event sent when visibility changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private VisibilityChangedEventHandler _onVisibilityChanged = new VisibilityChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Normal.")]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToNormal = new UnityEvent();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		private UnityEvent _onInteractionStateChangedToHighlighted = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UnityEvent _onInteractionStateChangedToPressed = new UnityEvent();

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Event sent when interaction state changes to Disabled.")]
		private UnityEvent _onInteractionStateChangedToDisabled = new UnityEvent();

		private readonly List<CanvasGroup> _canvasGroupCache = new List<CanvasGroup>();

		private bool _groupsAllowInteraction = true;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool wDYSPwlKjAWglTFTTAdVKNarCnx;

		[NonSerialized]
		private bool TeYWPPoFyMNBbKncGGitZfUyemX;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents = true;

		private static InteractionStateTransitionArgs _transitionArgs = new InteractionStateTransitionArgs();

		private iqJrXCyBXfdczMYruDynMWmAkyE.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private iqJrXCyBXfdczMYruDynMWmAkyE.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static iqJrXCyBXfdczMYruDynMWmAkyE.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		private iqJrXCyBXfdczMYruDynMWmAkyE.HierarchyEventHelper<IVisibilityChangedHandler, bool> hierarchyVisibilityChangedHandlers
		{
			get
			{
				if (__hierarchyVisibilityChangedHandlers == null)
				{
					__hierarchyVisibilityChangedHandlers = new iqJrXCyBXfdczMYruDynMWmAkyE.HierarchyEventHelper<IVisibilityChangedHandler, bool>(WNotAAISpefDpKyNJdcLcBcbogIZ.visibilityChangedHandlerDelegate);
					__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
				}
				return __hierarchyVisibilityChangedHandlers;
			}
		}

		private iqJrXCyBXfdczMYruDynMWmAkyE.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> hierarchyInteractionStateTransitionHandlers
		{
			get
			{
				if (__hierarchyInteractionStateTransitionHandlers == null)
				{
					__hierarchyInteractionStateTransitionHandlers = new iqJrXCyBXfdczMYruDynMWmAkyE.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs>(interactionStateTransitionHandlerDelegate);
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					ueSMjLlWmBWhnBWuPdgEmbJOjZQ(value, false);
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
				MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
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
					MxNDYRdNWvbuwnEvdAejdyZphUD();
				}
			}
		}

		public Animator animator => base.gameObject.GetComponent<Animator>();

		public InteractionState interactionState => _interactionState;

		internal static iqJrXCyBXfdczMYruDynMWmAkyE.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> interactionStateTransitionHandlerDelegate
		{
			get
			{
				if (__interactionStateTransitionHandlerDelegate == null)
				{
					__interactionStateTransitionHandlerDelegate = delegate(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
					{
						P_0.OnInteractionStateTransition(P_1);
					};
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
				MCIJNgzmwLxhAOsfaIeVTogZBDv();
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
				lobXwMhkakKXYKYMfyRgSFyhrnN();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDidApplyAnimationProperties()
		{
			base.OnDidApplyAnimationProperties();
			lobXwMhkakKXYKYMfyRgSFyhrnN();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!Application.isPlaying)
			{
				MCIJNgzmwLxhAOsfaIeVTogZBDv();
			}
			owVaLyjaVgpAiciZcbGSCNFxGwch(InteractionState.Normal);
			HFouMYkIovFCGhCKLgwiiMoSzvrp(true);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			PlxIafttfOvZjUKjXkazhCkmecT();
			base.OnDisable();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			if (PmzPLRTbzhVAsZEWmVqPqmwBgpn())
			{
				if (!_interactable && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
				{
					EventSystem.current.SetSelectedGameObject(null);
				}
				dKGPiKBNnrITbAeUEvTiuFoknEJ(null);
				mGlmsRhWnbDoywJKquuBHiOFKYy(Color.white, true);
				eMgfppuBOkDsihkEzXoqmqlpGsDd(_transitionAnimationTriggers.normalTrigger);
				HFouMYkIovFCGhCKLgwiiMoSzvrp(true);
			}
			UjXMRjUKoYupHsBwzzAyyWNsCgV();
			lobXwMhkakKXYKYMfyRgSFyhrnN();
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
			_allowedMouseButtons = MouseButtonFlags.LeftButton;
			base.Reset();
		}

		internal override void MxNDYRdNWvbuwnEvdAejdyZphUD()
		{
			base.MxNDYRdNWvbuwnEvdAejdyZphUD();
			lobXwMhkakKXYKYMfyRgSFyhrnN();
		}

		internal override void RDNrpouRiMCNDFrHrSWdTBgqpLi()
		{
			base.RDNrpouRiMCNDFrHrSWdTBgqpLi();
			UjXMRjUKoYupHsBwzzAyyWNsCgV();
		}

		private void PlxIafttfOvZjUKjXkazhCkmecT()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			wDYSPwlKjAWglTFTTAdVKNarCnx = false;
			TeYWPPoFyMNBbKncGGitZfUyemX = false;
			if ((_transitionType & TransitionTypeFlags.ColorTint) != TransitionTypeFlags.None)
			{
				mGlmsRhWnbDoywJKquuBHiOFKYy(Color.white, true);
			}
			if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
			{
				dKGPiKBNnrITbAeUEvTiuFoknEJ(null);
			}
			if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
			{
				eMgfppuBOkDsihkEzXoqmqlpGsDd(normalTrigger);
			}
		}

		private void wnmyKPMBoDVdtWcUywEEWSmbufZ(InteractionState P_0, bool P_1)
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
					mGlmsRhWnbDoywJKquuBHiOFKYy(color * _transitionColorTint.colorMultiplier, P_1);
				}
				else
				{
					mGlmsRhWnbDoywJKquuBHiOFKYy(color, P_1);
				}
				if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
				{
					dKGPiKBNnrITbAeUEvTiuFoknEJ(sprite);
				}
				if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
				{
					eMgfppuBOkDsihkEzXoqmqlpGsDd(text);
				}
			}
			if (_allowSendingEvents)
			{
				_transitionArgs.NGXUBbcPdrBYfEJQGstImmQAGjsO(this, P_0, P_1 ? 0f : _transitionColorTint.fadeDuration);
				hierarchyInteractionStateTransitionHandlers.ExecuteOnAll(_transitionArgs);
				if (_onInteractionStateTransition != null)
				{
					_onInteractionStateTransition.Invoke(_transitionArgs);
				}
				unityEvent?.Invoke();
			}
		}

		private void mGlmsRhWnbDoywJKquuBHiOFKYy(Color P_0, bool P_1)
		{
			if (!(_targetGraphic == null))
			{
				_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void dKGPiKBNnrITbAeUEvTiuFoknEJ(Sprite P_0)
		{
			if (!(image == null))
			{
				image.overrideSprite = P_0;
			}
		}

		private void eMgfppuBOkDsihkEzXoqmqlpGsDd(string P_0)
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

		private void HFouMYkIovFCGhCKLgwiiMoSzvrp(bool P_0)
		{
			InteractionState interactionState = _interactionState;
			if (PmzPLRTbzhVAsZEWmVqPqmwBgpn() && !IsInteractable())
			{
				interactionState = InteractionState.Disabled;
			}
			wnmyKPMBoDVdtWcUywEEWSmbufZ(interactionState, P_0);
		}

		public bool IsInteractable()
		{
			if (_groupsAllowInteraction)
			{
				return _interactable;
			}
			return false;
		}

		internal virtual bool efPFnJtobodubpQYOBTayBiBGwP()
		{
			if (!PmzPLRTbzhVAsZEWmVqPqmwBgpn())
			{
				return false;
			}
			if (wDYSPwlKjAWglTFTTAdVKNarCnx)
			{
				return TeYWPPoFyMNBbKncGGitZfUyemX;
			}
			return false;
		}

		internal void XQWPTxZJvVnljinalPFNQOhrbRM(BaseEventData P_0)
		{
			if (PmzPLRTbzhVAsZEWmVqPqmwBgpn() && IsInteractable())
			{
				InteractionState interactionState = IdVwGDKoPcELjTzqaTBfBMoqfUX(P_0);
				if (interactionState != _interactionState)
				{
					owVaLyjaVgpAiciZcbGSCNFxGwch(interactionState);
					HFouMYkIovFCGhCKLgwiiMoSzvrp(false);
				}
			}
		}

		internal virtual bool bvnqUnjCsHckqafilSFkqwdznqm(GameObject P_0)
		{
			return base.gameObject == P_0;
		}

		private bool fGvKzsrjTeeUucZVSalvYJCJBzj(BaseEventData P_0)
		{
			bool flag = P_0 is PointerEventData;
			return fGvKzsrjTeeUucZVSalvYJCJBzj(flag, flag ? (P_0 as PointerEventData).pointerPress : null);
		}

		private bool fGvKzsrjTeeUucZVSalvYJCJBzj(bool P_0, GameObject P_1)
		{
			if (!PmzPLRTbzhVAsZEWmVqPqmwBgpn())
			{
				return false;
			}
			if (efPFnJtobodubpQYOBTayBiBGwP())
			{
				return false;
			}
			bool flag = false;
			if (P_0)
			{
				return flag | ((TeYWPPoFyMNBbKncGGitZfUyemX && !wDYSPwlKjAWglTFTTAdVKNarCnx && bvnqUnjCsHckqafilSFkqwdznqm(P_1)) || (!TeYWPPoFyMNBbKncGGitZfUyemX && wDYSPwlKjAWglTFTTAdVKNarCnx && bvnqUnjCsHckqafilSFkqwdznqm(P_1)) || (!TeYWPPoFyMNBbKncGGitZfUyemX && wDYSPwlKjAWglTFTTAdVKNarCnx && P_1 == null));
			}
			return flag | wDYSPwlKjAWglTFTTAdVKNarCnx;
		}

		private InteractionState IdVwGDKoPcELjTzqaTBfBMoqfUX(BaseEventData P_0)
		{
			if (efPFnJtobodubpQYOBTayBiBGwP())
			{
				return InteractionState.Pressed;
			}
			if (fGvKzsrjTeeUucZVSalvYJCJBzj(P_0))
			{
				return InteractionState.Highlighted;
			}
			return InteractionState.Normal;
		}

		private bool owVaLyjaVgpAiciZcbGSCNFxGwch(InteractionState P_0)
		{
			if (_interactionState == P_0)
			{
				return false;
			}
			_interactionState = P_0;
			vSyhCwwYhrwnUuovhDkETrDNrJn();
			return true;
		}

		private void vSyhCwwYhrwnUuovhDkETrDNrJn()
		{
			zKGGLhhSTTXKwknAtXzYKeDUDyMs();
		}

		private void zKGGLhhSTTXKwknAtXzYKeDUDyMs()
		{
			if (Application.isPlaying && _hideWhenIdle)
			{
				ueSMjLlWmBWhnBWuPdgEmbJOjZQ(_interactionState == InteractionState.Pressed, false);
			}
		}

		private void ueSMjLlWmBWhnBWuPdgEmbJOjZQ(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			_visible = P_0;
			_varWatch_visible = P_0;
			if (_allowSendingEvents)
			{
				hierarchyVisibilityChangedHandlers.ExecuteOnAll(P_0);
				if (_onVisibilityChanged != null)
				{
					_onVisibilityChanged.Invoke(P_0);
				}
			}
		}

		private void MCIJNgzmwLxhAOsfaIeVTogZBDv()
		{
			_varWatch_visible = _visible;
			_varWatch_interactable = IsInteractable();
			bool allowSendingEvents = _allowSendingEvents;
			Action<bool> setValueDelegate = delegate(bool P_0)
			{
				_allowSendingEvents = P_0;
			};
			using (new SetAndRestoreVar<bool>(allowSendingEvents, newValue: false, setValueDelegate))
			{
				ueSMjLlWmBWhnBWuPdgEmbJOjZQ(_visible, true);
				zKGGLhhSTTXKwknAtXzYKeDUDyMs();
			}
			UjXMRjUKoYupHsBwzzAyyWNsCgV();
			if (_allowSendingEvents)
			{
				hierarchyVisibilityChangedHandlers.ExecuteOnAll(_visible);
				if (_onVisibilityChanged != null)
				{
					_onVisibilityChanged.Invoke(_visible);
				}
			}
		}

		private void UILDObpGAluwcFfhafYTwXUigiBa()
		{
			if (_varWatch_visible != _visible)
			{
				_varWatch_visible = _visible;
				if (_allowSendingEvents && _onVisibilityChanged != null)
				{
					hierarchyVisibilityChangedHandlers.ExecuteOnAll(_visible);
					_onVisibilityChanged.Invoke(_visible);
				}
			}
		}

		private void lobXwMhkakKXYKYMfyRgSFyhrnN()
		{
			UILDObpGAluwcFfhafYTwXUigiBa();
			zKGGLhhSTTXKwknAtXzYKeDUDyMs();
			if (!Application.isPlaying)
			{
				HFouMYkIovFCGhCKLgwiiMoSzvrp(true);
			}
			else
			{
				HFouMYkIovFCGhCKLgwiiMoSzvrp(false);
			}
		}

		private void UjXMRjUKoYupHsBwzzAyyWNsCgV()
		{
			hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
			hierarchyInteractionStateTransitionHandlers.GetHandlers(base.transform);
		}

		internal virtual void OnPointerDown(PointerEventData eventData)
		{
			if (HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerDown))
			{
				TeYWPPoFyMNBbKncGGitZfUyemX = true;
				XQWPTxZJvVnljinalPFNQOhrbRM(eventData);
			}
		}

		internal virtual void OnPointerUp(PointerEventData eventData)
		{
			if (HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerUp))
			{
				TeYWPPoFyMNBbKncGGitZfUyemX = false;
				XQWPTxZJvVnljinalPFNQOhrbRM(eventData);
			}
		}

		internal virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				wDYSPwlKjAWglTFTTAdVKNarCnx = true;
				XQWPTxZJvVnljinalPFNQOhrbRM(eventData);
			}
		}

		internal virtual void OnPointerExit(PointerEventData eventData)
		{
			if (HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerExit))
			{
				wDYSPwlKjAWglTFTTAdVKNarCnx = false;
				XQWPTxZJvVnljinalPFNQOhrbRM(eventData);
			}
		}

		internal virtual void OnBeginDrag(PointerEventData eventData)
		{
			HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, _allowedMouseButtons, EventTriggerType.BeginDrag);
		}

		internal virtual void OnDrag(PointerEventData eventData)
		{
			HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, _allowedMouseButtons, EventTriggerType.Drag);
		}

		internal virtual void OnEndDrag(PointerEventData eventData)
		{
			HJbePsKtyjbsvZCFomIPfAKzIWp(eventData.pointerId, _allowedMouseButtons, EventTriggerType.EndDrag);
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

		internal static bool drLtaaDzczryPGXVgVOLzVaFGWL(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (yKhgFVKBryTMtmcFDTYNKQwGtIrr(P_0))
			{
				int num = NXHWVLfbKfrEtSpcfQzxqnyMpXY(P_0);
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
			if (bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0) && Input.mousePresent)
			{
				int num2 = WnZRjLUvhiBmPhtCURFoVswtdrL(P_0);
				if (num2 >= 0)
				{
					return Input.GetMouseButton(num2);
				}
			}
			return false;
		}

		internal static Vector3 CpVfSgBIpqTojStivvwPfHPkOalA(int P_0)
		{
			if (yKhgFVKBryTMtmcFDTYNKQwGtIrr(P_0))
			{
				int num = NXHWVLfbKfrEtSpcfQzxqnyMpXY(P_0);
				if (num >= 0 && Input.touchCount > num)
				{
					return Input.touches[num].position;
				}
			}
			else if (bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0) && Input.mousePresent)
			{
				return Input.mousePosition;
			}
			return Vector3.zero;
		}

		internal static bool yKhgFVKBryTMtmcFDTYNKQwGtIrr(int P_0)
		{
			return P_0 >= 0;
		}

		internal static bool bwOyBTcFasMhiuGZqjMrDjDbDFP(int P_0)
		{
			if (P_0 != -1 && P_0 != -3)
			{
				return P_0 == -2;
			}
			return true;
		}

		private static int NXHWVLfbKfrEtSpcfQzxqnyMpXY(int P_0)
		{
			if (!yKhgFVKBryTMtmcFDTYNKQwGtIrr(P_0))
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

		internal static bool HJbePsKtyjbsvZCFomIPfAKzIWp(MouseButtonFlags P_0, int P_1)
		{
			if (bwOyBTcFasMhiuGZqjMrDjDbDFP(P_1))
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
			if (yKhgFVKBryTMtmcFDTYNKQwGtIrr(P_1))
			{
				return true;
			}
			if (fvwwDoPJNrFRKKMytiLbEHnadIi(P_0, P_1))
			{
				return true;
			}
			return false;
		}

		private static bool fvwwDoPJNrFRKKMytiLbEHnadIi(MouseButtonFlags P_0, int P_1)
		{
			return P_1 switch
			{
				-1 => (P_0 & MouseButtonFlags.LeftButton) != 0, 
				-2 => (P_0 & MouseButtonFlags.RightButton) != 0, 
				-3 => (P_0 & MouseButtonFlags.MiddleButton) != 0, 
				_ => false, 
			};
		}

		private static int WnZRjLUvhiBmPhtCURFoVswtdrL(int P_0)
		{
			if (!bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0))
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

		internal static bool EvThQAjlPBPgHUXNoSHCEtMVLsj(MouseButtonFlags P_0, out int P_1)
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

		internal static bool HJbePsKtyjbsvZCFomIPfAKzIWp(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			if (bwOyBTcFasMhiuGZqjMrDjDbDFP(P_0) && (P_2 == EventTriggerType.PointerEnter || P_2 == EventTriggerType.PointerExit) && P_1 != MouseButtonFlags.None)
			{
				P_1 |= MouseButtonFlags.LeftButton;
			}
			return HJbePsKtyjbsvZCFomIPfAKzIWp(P_1, P_0);
		}

		internal static bool OZFdDoQVLcQGFsSqVeUdHqpttTZ(MouseButtonFlags P_0)
		{
			int num;
			return EvThQAjlPBPgHUXNoSHCEtMVLsj(P_0, out num);
		}

		[CompilerGenerated]
		private void xBfDGvbCsbTWErmbloeVPLfkdftW(bool P_0)
		{
			_allowSendingEvents = P_0;
		}

		[CompilerGenerated]
		private static void htACniiSMOKWjBveBCqAjxkcWqSb(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
		{
			P_0.OnInteractionStateTransition(P_1);
		}
	}
}
