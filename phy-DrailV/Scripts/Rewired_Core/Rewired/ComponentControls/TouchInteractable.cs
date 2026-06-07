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
			private TouchInteractable SIsllNdEkNeINvttqKcWyrKlcuCQ;

			private InteractionState uaoVgNNqepBZbGcKZkwihPkVPFYX;

			private float ZxsgJaIVEglxxxirWZzUaSAQsKdt;

			public TouchInteractable sender => SIsllNdEkNeINvttqKcWyrKlcuCQ;

			public InteractionState state => uaoVgNNqepBZbGcKZkwihPkVPFYX;

			public float duration => ZxsgJaIVEglxxxirWZzUaSAQsKdt;

			internal InteractionStateTransitionArgs()
			{
			}

			internal void wktKiMTzgPuXyJzmAQdgBslXzykH(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
				SIsllNdEkNeINvttqKcWyrKlcuCQ = P_0;
				uaoVgNNqepBZbGcKZkwihPkVPFYX = P_1;
				ZxsgJaIVEglxxxirWZzUaSAQsKdt = P_2;
			}
		}

		public interface IInteractionStateTransitionHandler
		{
			void OnInteractionStateTransition(InteractionStateTransitionArgs data);
		}

		[Serializable]
		private sealed class MlzzlxWDyyhyhOulrvKynrxJCIKX
		{
			public static readonly MlzzlxWDyyhyhOulrvKynrxJCIKX _003C_003E9 = new MlzzlxWDyyhyhOulrvKynrxJCIKX();

			public static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> _003C_003E9__152_0;

			internal void EzXbaqjYQRYMQitgyHkrNxNMAoce(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
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
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the control can be interacted with by the user.")]
		private bool _interactable = true;

		[SerializeField]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		[CustomObfuscation(rename = false)]
		private bool _visible = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		private bool _hideWhenIdle;

		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(MouseButtonFlags))]
		private MouseButtonFlags _allowedMouseButtons = MouseButtonFlags.LeftButton;

		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[SerializeField]
		[Bitmask(typeof(TransitionTypeFlags))]
		[CustomObfuscation(rename = false)]
		private TransitionTypeFlags _transitionType;

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Color Tint transitions.")]
		[SerializeField]
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

		[Tooltip("Settings using for Animation Trigger transitions.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
		private bool PPobDgSULmsGqZojTdFrxnegWsbI;

		[NonSerialized]
		private bool qQqrGmXxzubkmCaMCrOVuSrdktRh;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents = true;

		private static InteractionStateTransitionArgs _transitionArgs = new InteractionStateTransitionArgs();

		private PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		private PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IVisibilityChangedHandler, bool> GQzRGmUcRebikSVkHsbBEfhQMjCY
		{
			get
			{
				if (__hierarchyVisibilityChangedHandlers == null)
				{
					__hierarchyVisibilityChangedHandlers = new PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IVisibilityChangedHandler, bool>(nsShjdlYsYEpskQtRuHtqmRolmQW.ZYliaxHjQambqxfFgPKtqXdFthwT);
					__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
				}
				return __hierarchyVisibilityChangedHandlers;
			}
		}

		private PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> RUKhswJtVcSlgxVuPzpjBHzVxyt
		{
			get
			{
				if (__hierarchyInteractionStateTransitionHandlers == null)
				{
					__hierarchyInteractionStateTransitionHandlers = new PIjWQnRQEZKAkUBXkJaRpXLVkaYI.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs>(SpNGjkhsqAFziGXrzYozfOshmUsFA);
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					RpytviYBHzgKcVevXSbeLcqZvMCm(value, false);
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
				jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public Animator animator => base.gameObject.GetComponent<Animator>();

		public InteractionState interactionState => _interactionState;

		internal static PIjWQnRQEZKAkUBXkJaRpXLVkaYI.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> SpNGjkhsqAFziGXrzYozfOshmUsFA
		{
			get
			{
				if (__interactionStateTransitionHandlerDelegate == null)
				{
					__interactionStateTransitionHandlerDelegate = MlzzlxWDyyhyhOulrvKynrxJCIKX._003C_003E9.EzXbaqjYQRYMQitgyHkrNxNMAoce;
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
				lxmTcRQJlnoHPGdLguZvunPOJPtO();
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
				QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDidApplyAnimationProperties()
		{
			base.OnDidApplyAnimationProperties();
			QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!Application.isPlaying)
			{
				lxmTcRQJlnoHPGdLguZvunPOJPtO();
			}
			XmjANPIBQQqTrgcrsabikdosskyMA(InteractionState.Normal);
			eySglzVNvFtoTdOsXcJGKfHDOrndb(true);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			iOThQKOgqwBkgGXeDJJxINaxwDTd();
			base.OnDisable();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			if (uITeqmergHcifeDewaJvLHRSazjqA())
			{
				if (!_interactable && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
				{
					EventSystem.current.SetSelectedGameObject(null);
				}
				OBehNxFuwBcpmrWeEmsOPDJhNEBUA(null);
				FYLdPaHGoTSAtQmuiyHjicbEmMwkA(Color.white, true);
				PgIYLQNgZWCbbdaexdVSJDCiCqJEA(_transitionAnimationTriggers.normalTrigger);
				eySglzVNvFtoTdOsXcJGKfHDOrndb(true);
			}
			lVlCeAAhhsmFOjeYenpEuFsAbcBPB();
			QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
			_allowedMouseButtons = MouseButtonFlags.LeftButton;
			base.Reset();
		}

		internal override void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
			base.jebsoqOBGHhJxfFgdjbRaKVujtZwA();
			QCTiHbMbjMBiDhGopGJUAtTEkvFmB();
		}

		internal override void kvtAMBhXvoFvKTDvbPnZAgXAnVeob()
		{
			base.kvtAMBhXvoFvKTDvbPnZAgXAnVeob();
			lVlCeAAhhsmFOjeYenpEuFsAbcBPB();
		}

		private void iOThQKOgqwBkgGXeDJJxINaxwDTd()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			PPobDgSULmsGqZojTdFrxnegWsbI = false;
			qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
			if ((_transitionType & TransitionTypeFlags.ColorTint) != TransitionTypeFlags.None)
			{
				FYLdPaHGoTSAtQmuiyHjicbEmMwkA(Color.white, true);
			}
			if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
			{
				OBehNxFuwBcpmrWeEmsOPDJhNEBUA(null);
			}
			if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
			{
				PgIYLQNgZWCbbdaexdVSJDCiCqJEA(normalTrigger);
			}
		}

		private void DgMhzmxVzlsPgQOkoZlgnFFqQjBw(InteractionState P_0, bool P_1)
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
					FYLdPaHGoTSAtQmuiyHjicbEmMwkA(color * _transitionColorTint.colorMultiplier, P_1);
				}
				else
				{
					FYLdPaHGoTSAtQmuiyHjicbEmMwkA(color, P_1);
				}
				if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
				{
					OBehNxFuwBcpmrWeEmsOPDJhNEBUA(sprite);
				}
				if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
				{
					PgIYLQNgZWCbbdaexdVSJDCiCqJEA(text);
				}
			}
			if (_allowSendingEvents)
			{
				_transitionArgs.wktKiMTzgPuXyJzmAQdgBslXzykH(this, P_0, P_1 ? 0f : _transitionColorTint.fadeDuration);
				RUKhswJtVcSlgxVuPzpjBHzVxyt.ExecuteOnAll(_transitionArgs);
				if (_onInteractionStateTransition != null)
				{
					_onInteractionStateTransition.Invoke(_transitionArgs);
				}
				unityEvent?.Invoke();
			}
		}

		private void FYLdPaHGoTSAtQmuiyHjicbEmMwkA(Color P_0, bool P_1)
		{
			if (!(_targetGraphic == null))
			{
				_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void OBehNxFuwBcpmrWeEmsOPDJhNEBUA(Sprite P_0)
		{
			if (!(image == null))
			{
				image.overrideSprite = P_0;
			}
		}

		private void PgIYLQNgZWCbbdaexdVSJDCiCqJEA(string P_0)
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

		private void eySglzVNvFtoTdOsXcJGKfHDOrndb(bool P_0)
		{
			InteractionState interactionState = _interactionState;
			if (uITeqmergHcifeDewaJvLHRSazjqA() && !IsInteractable())
			{
				interactionState = InteractionState.Disabled;
			}
			DgMhzmxVzlsPgQOkoZlgnFFqQjBw(interactionState, P_0);
		}

		public bool IsInteractable()
		{
			if (_groupsAllowInteraction)
			{
				return _interactable;
			}
			return false;
		}

		internal virtual bool XAnxKiEsqAoGaxLsQPiYTKBOAuBt()
		{
			if (!uITeqmergHcifeDewaJvLHRSazjqA())
			{
				return false;
			}
			if (PPobDgSULmsGqZojTdFrxnegWsbI)
			{
				return qQqrGmXxzubkmCaMCrOVuSrdktRh;
			}
			return false;
		}

		internal void cBqecUAeoxxZoHcAtIutmfGiHXYSA(BaseEventData P_0)
		{
			if (uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable())
			{
				InteractionState interactionState = pHrNIgpSnMgIcLaAsmkHyaLjbPHL(P_0);
				if (interactionState != _interactionState)
				{
					XmjANPIBQQqTrgcrsabikdosskyMA(interactionState);
					eySglzVNvFtoTdOsXcJGKfHDOrndb(false);
				}
			}
		}

		internal virtual bool CCRTYlKENtSVpmwZvzlIPCFobzki(GameObject P_0)
		{
			return base.gameObject == P_0;
		}

		private bool GyBzVQSqyKUdVegnAaFZpLeKXFnv(BaseEventData P_0)
		{
			bool flag = P_0 is PointerEventData;
			return GyBzVQSqyKUdVegnAaFZpLeKXFnv(flag, flag ? (P_0 as PointerEventData).pointerPress : null);
		}

		private bool GyBzVQSqyKUdVegnAaFZpLeKXFnv(bool P_0, GameObject P_1)
		{
			if (!uITeqmergHcifeDewaJvLHRSazjqA())
			{
				return false;
			}
			if (XAnxKiEsqAoGaxLsQPiYTKBOAuBt())
			{
				return false;
			}
			bool flag = false;
			if (P_0)
			{
				return flag | ((qQqrGmXxzubkmCaMCrOVuSrdktRh && !PPobDgSULmsGqZojTdFrxnegWsbI && CCRTYlKENtSVpmwZvzlIPCFobzki(P_1)) || (!qQqrGmXxzubkmCaMCrOVuSrdktRh && PPobDgSULmsGqZojTdFrxnegWsbI && CCRTYlKENtSVpmwZvzlIPCFobzki(P_1)) || (!qQqrGmXxzubkmCaMCrOVuSrdktRh && PPobDgSULmsGqZojTdFrxnegWsbI && P_1 == null));
			}
			return flag | PPobDgSULmsGqZojTdFrxnegWsbI;
		}

		private InteractionState pHrNIgpSnMgIcLaAsmkHyaLjbPHL(BaseEventData P_0)
		{
			if (XAnxKiEsqAoGaxLsQPiYTKBOAuBt())
			{
				return InteractionState.Pressed;
			}
			if (GyBzVQSqyKUdVegnAaFZpLeKXFnv(P_0))
			{
				return InteractionState.Highlighted;
			}
			return InteractionState.Normal;
		}

		private bool XmjANPIBQQqTrgcrsabikdosskyMA(InteractionState P_0)
		{
			if (_interactionState == P_0)
			{
				return false;
			}
			_interactionState = P_0;
			SnUtbHPwiDgJJcZRlHNcwDmOfPdEA();
			return true;
		}

		private void SnUtbHPwiDgJJcZRlHNcwDmOfPdEA()
		{
			UNylqQzsSlcmtlDwtWAsXhyDaMYk();
		}

		private void UNylqQzsSlcmtlDwtWAsXhyDaMYk()
		{
			if (Application.isPlaying && _hideWhenIdle)
			{
				RpytviYBHzgKcVevXSbeLcqZvMCm(_interactionState == InteractionState.Pressed, false);
			}
		}

		private void RpytviYBHzgKcVevXSbeLcqZvMCm(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			_visible = P_0;
			_varWatch_visible = P_0;
			if (_allowSendingEvents)
			{
				GQzRGmUcRebikSVkHsbBEfhQMjCY.ExecuteOnAll(P_0);
				if (_onVisibilityChanged != null)
				{
					_onVisibilityChanged.Invoke(P_0);
				}
			}
		}

		private void lxmTcRQJlnoHPGdLguZvunPOJPtO()
		{
			_varWatch_visible = _visible;
			_varWatch_interactable = IsInteractable();
			using (new SetAndRestoreVar<bool>(_allowSendingEvents, false, delegate(bool P_0)
			{
				_allowSendingEvents = P_0;
			}))
			{
				RpytviYBHzgKcVevXSbeLcqZvMCm(_visible, true);
				UNylqQzsSlcmtlDwtWAsXhyDaMYk();
			}
			lVlCeAAhhsmFOjeYenpEuFsAbcBPB();
			if (_allowSendingEvents)
			{
				GQzRGmUcRebikSVkHsbBEfhQMjCY.ExecuteOnAll(_visible);
				if (_onVisibilityChanged != null)
				{
					_onVisibilityChanged.Invoke(_visible);
				}
			}
		}

		private void vUjxvWQVNLVWrXPFiwzfJDxlckDW()
		{
			if (_varWatch_visible != _visible)
			{
				_varWatch_visible = _visible;
				if (_allowSendingEvents && _onVisibilityChanged != null)
				{
					GQzRGmUcRebikSVkHsbBEfhQMjCY.ExecuteOnAll(_visible);
					_onVisibilityChanged.Invoke(_visible);
				}
			}
		}

		private void QCTiHbMbjMBiDhGopGJUAtTEkvFmB()
		{
			vUjxvWQVNLVWrXPFiwzfJDxlckDW();
			UNylqQzsSlcmtlDwtWAsXhyDaMYk();
			if (!Application.isPlaying)
			{
				eySglzVNvFtoTdOsXcJGKfHDOrndb(true);
			}
			else
			{
				eySglzVNvFtoTdOsXcJGKfHDOrndb(false);
			}
		}

		private void lVlCeAAhhsmFOjeYenpEuFsAbcBPB()
		{
			GQzRGmUcRebikSVkHsbBEfhQMjCY.GetHandlers(base.transform);
			RUKhswJtVcSlgxVuPzpjBHzVxyt.GetHandlers(base.transform);
		}

		internal virtual void OnPointerDown(PointerEventData eventData)
		{
			if (cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerDown))
			{
				qQqrGmXxzubkmCaMCrOVuSrdktRh = true;
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(eventData);
			}
		}

		internal virtual void OnPointerUp(PointerEventData eventData)
		{
			if (cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerUp))
			{
				qQqrGmXxzubkmCaMCrOVuSrdktRh = false;
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(eventData);
			}
		}

		internal virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				PPobDgSULmsGqZojTdFrxnegWsbI = true;
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(eventData);
			}
		}

		internal virtual void OnPointerExit(PointerEventData eventData)
		{
			if (cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerExit))
			{
				PPobDgSULmsGqZojTdFrxnegWsbI = false;
				cBqecUAeoxxZoHcAtIutmfGiHXYSA(eventData);
			}
		}

		internal virtual void OnBeginDrag(PointerEventData eventData)
		{
			cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, _allowedMouseButtons, EventTriggerType.BeginDrag);
		}

		internal virtual void OnDrag(PointerEventData eventData)
		{
			cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, _allowedMouseButtons, EventTriggerType.Drag);
		}

		internal virtual void OnEndDrag(PointerEventData eventData)
		{
			cWTWoPfxtFMCeZPheBprQnfcNOhy(eventData.pointerId, _allowedMouseButtons, EventTriggerType.EndDrag);
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

		internal static bool KPVKeHyDuDGRnEhncMacOuyMIqYk(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (VNDmieaLiUocagPbDSxfzUBDHEdR(P_0))
			{
				int num = uFxDugUIVZEmuYWKfZCVFARREBIBA(P_0);
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
			if (WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0) && Input.mousePresent)
			{
				int num2 = dkvsECrqwUpZbpSJQkinaiJojUnL(P_0);
				if (num2 >= 0)
				{
					return Input.GetMouseButton(num2);
				}
			}
			return false;
		}

		internal static Vector3 jDjpvJxmiWZSqzgArtDxiAozBibiA(int P_0)
		{
			if (VNDmieaLiUocagPbDSxfzUBDHEdR(P_0))
			{
				int num = uFxDugUIVZEmuYWKfZCVFARREBIBA(P_0);
				if (num >= 0 && Input.touchCount > num)
				{
					return Input.touches[num].position;
				}
			}
			else if (WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0) && Input.mousePresent)
			{
				return Input.mousePosition;
			}
			return Vector3.zero;
		}

		internal static bool VNDmieaLiUocagPbDSxfzUBDHEdR(int P_0)
		{
			return P_0 >= 0;
		}

		internal static bool WCyRkqJXrQwbtkqzoWePgVkiHKPI(int P_0)
		{
			if (P_0 != -1 && P_0 != -3)
			{
				return P_0 == -2;
			}
			return true;
		}

		private static int uFxDugUIVZEmuYWKfZCVFARREBIBA(int P_0)
		{
			if (!VNDmieaLiUocagPbDSxfzUBDHEdR(P_0))
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

		internal static bool cWTWoPfxtFMCeZPheBprQnfcNOhy(MouseButtonFlags P_0, int P_1)
		{
			if (WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_1))
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
			if (VNDmieaLiUocagPbDSxfzUBDHEdR(P_1))
			{
				return true;
			}
			if (SLSTmRqLUNbyVKDazTkVxGqhfuuk(P_0, P_1))
			{
				return true;
			}
			return false;
		}

		private static bool SLSTmRqLUNbyVKDazTkVxGqhfuuk(MouseButtonFlags P_0, int P_1)
		{
			switch (P_1)
			{
			case -1:
				return (P_0 & MouseButtonFlags.LeftButton) != 0;
			case -2:
				return (P_0 & MouseButtonFlags.RightButton) != 0;
			case -3:
				return (P_0 & MouseButtonFlags.MiddleButton) != 0;
			default:
				return false;
			}
		}

		private static int dkvsECrqwUpZbpSJQkinaiJojUnL(int P_0)
		{
			if (!WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0))
			{
				return -1;
			}
			switch (P_0)
			{
			case -1:
				return 0;
			case -2:
				return 1;
			case -3:
				return 2;
			default:
				return -1;
			}
		}

		internal static bool xKpthjOvWrGLEYZzckNkzUxWiphi(MouseButtonFlags P_0, out int P_1)
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

		internal static bool cWTWoPfxtFMCeZPheBprQnfcNOhy(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			if (WCyRkqJXrQwbtkqzoWePgVkiHKPI(P_0) && (P_2 == EventTriggerType.PointerEnter || P_2 == EventTriggerType.PointerExit) && P_1 != MouseButtonFlags.None)
			{
				P_1 |= MouseButtonFlags.LeftButton;
			}
			return cWTWoPfxtFMCeZPheBprQnfcNOhy(P_1, P_0);
		}

		internal static bool tIvoXXrIMIwvUwCpDxwPcEyiNtFC(MouseButtonFlags P_0)
		{
			int num;
			return xKpthjOvWrGLEYZzckNkzUxWiphi(P_0, out num);
		}

		[CompilerGenerated]
		private void BLTTyZvjccMKmtRzqeVpNlJCeNukA(bool P_0)
		{
			_allowSendingEvents = P_0;
		}
	}
}
