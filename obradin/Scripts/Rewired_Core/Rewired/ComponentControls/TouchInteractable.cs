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
			private TouchInteractable HVvgSnJtYAILMcUpzQRxwCmTIRPz;

			private InteractionState rtvVnhTQYgCakhFQKHBBPREvwqN;

			private float GPnqlAJZovolwSSlXIYvGdssvbs;

			public TouchInteractable sender
			{
				get
				{
					return HVvgSnJtYAILMcUpzQRxwCmTIRPz;
				}
			}

			public InteractionState state
			{
				get
				{
					return rtvVnhTQYgCakhFQKHBBPREvwqN;
				}
			}

			public float duration
			{
				get
				{
					return GPnqlAJZovolwSSlXIYvGdssvbs;
				}
			}

			internal InteractionStateTransitionArgs()
			{
			}

			internal void fuLKaTfKQpOpktgPzRLpUDfEjf(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
				HVvgSnJtYAILMcUpzQRxwCmTIRPz = P_0;
				rtvVnhTQYgCakhFQKHBBPREvwqN = P_1;
				GPnqlAJZovolwSSlXIYvGdssvbs = P_2;
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
		private bool _interactable = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible = true;

		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideWhenIdle;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		[Bitmask(typeof(MouseButtonFlags))]
		private MouseButtonFlags _allowedMouseButtons = MouseButtonFlags.LeftButton;

		[Bitmask(typeof(TransitionTypeFlags))]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
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

		[Tooltip("Settings using for Sprite State transitions.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private SpriteState _transitionSpriteState;

		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		[SerializeField]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[CustomObfuscation(rename = false)]
		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[SerializeField]
		private Graphic _targetGraphic;

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when the Interaction State changes.")]
		[SerializeField]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition = new InteractionStateTransitionEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when visibility changes.")]
		[SerializeField]
		private VisibilityChangedEventHandler _onVisibilityChanged = new VisibilityChangedEventHandler();

		[Tooltip("Event sent when interaction state changes to Normal.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToNormal = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UnityEvent _onInteractionStateChangedToHighlighted = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Pressed.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToPressed = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Disabled.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UnityEvent _onInteractionStateChangedToDisabled = new UnityEvent();

		private readonly List<CanvasGroup> _canvasGroupCache = new List<CanvasGroup>();

		private bool _groupsAllowInteraction = true;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool GXxxUMYvhnAdzwfrIpAYPjIWpue;

		[NonSerialized]
		private bool jYtFWKZUVrechfzATGCgCETBhJCg;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents = true;

		private static InteractionStateTransitionArgs _transitionArgs = new InteractionStateTransitionArgs();

		private GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		[CompilerGenerated]
		private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> CS_0024_003C_003E9__CachedAnonymousMethodDelegate4;

		private GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IVisibilityChangedHandler, bool> hierarchyVisibilityChangedHandlers
		{
			get
			{
				if (__hierarchyVisibilityChangedHandlers == null)
				{
					while (true)
					{
						int num = 1750714405;
						while (true)
						{
							switch (num ^ 0x6859C824)
							{
							case 0:
								break;
							case 1:
								__hierarchyVisibilityChangedHandlers = new GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IVisibilityChangedHandler, bool>(oVmARCrYiJmfeJzWIcWzIboODXP.visibilityChangedHandlerDelegate);
								__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
								num = 1750714406;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				return __hierarchyVisibilityChangedHandlers;
			}
		}

		private GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> hierarchyInteractionStateTransitionHandlers
		{
			get
			{
				if (__hierarchyInteractionStateTransitionHandlers == null)
				{
					__hierarchyInteractionStateTransitionHandlers = new GQyqfJDHwYrVtpSHvKcqDWlbnVJ.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs>(interactionStateTransitionHandlerDelegate);
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
					OnSetProperty();
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
				if (visible == value)
				{
					return;
				}
				while (true)
				{
					SWnzUAEKhgDxxwxmMhpFBvKnnQNm(value, false);
					OnSetProperty();
					int num = -1216865705;
					while (true)
					{
						switch (num ^ -1216865705)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = -1216865706;
					}
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
					OnSetProperty();
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
					OnSetProperty();
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
				if (_transitionType == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 328803669;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0x13992557)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_0033;
				case 3:
					return;
				}
				goto IL_0009;
				IL_0033:
				_transitionType = value;
				OnSetProperty();
				num = 328803668;
				goto IL_000e;
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
				OnSetProperty();
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
				if (_transitionSpriteState.Equals(value))
				{
					goto IL_000e;
				}
				goto IL_0038;
				IL_000e:
				int num = 439141322;
				goto IL_0013;
				IL_0013:
				switch (num ^ 0x1A2CC3CB)
				{
				case 2:
					break;
				case 1:
					return;
				case 0:
					goto IL_0038;
				default:
					OnSetProperty();
					return;
				}
				goto IL_000e;
				IL_0038:
				_transitionSpriteState = value;
				num = 439141320;
				goto IL_0013;
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
				if (_transitionAnimationTriggers == value)
				{
					return;
				}
				while (true)
				{
					_transitionAnimationTriggers = value;
					OnSetProperty();
					int num = 16655975;
					while (true)
					{
						switch (num ^ 0xFE2667)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 16655974;
					}
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
				if (_targetGraphic == value)
				{
					while (true)
					{
						switch (0x78B81B3C ^ 0x78B81B3E)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				_targetGraphic = value;
				OnSetProperty();
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
				if (_targetGraphic == value)
				{
					return;
				}
				while (true)
				{
					_targetGraphic = value;
					int num = -146845867;
					while (true)
					{
						switch (num ^ -146845865)
						{
						case 0:
							goto IL_000f;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000f:
						num = -146845866;
					}
				}
			}
		}

		public Animator animator
		{
			get
			{
				return base.gameObject.GetComponent<Animator>();
			}
		}

		public InteractionState interactionState
		{
			get
			{
				return _interactionState;
			}
		}

		internal static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> interactionStateTransitionHandlerDelegate
		{
			get
			{
				if (__interactionStateTransitionHandlerDelegate == null)
				{
					while (true)
					{
						int num = 1537300041;
						while (true)
						{
							switch (num ^ 0x5BA15648)
							{
							case 2:
								break;
							case 1:
								if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate4 == null)
								{
									CS_0024_003C_003E9__CachedAnonymousMethodDelegate4 = delegate(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
									{
										P_0.OnInteractionStateTransition(P_1);
									};
									num = 1537300040;
									continue;
								}
								goto case 0;
							case 0:
								__interactionStateTransitionHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate4;
								num = 1537300043;
								continue;
							default:
								goto end_IL_0007;
							}
							break;
						}
						continue;
						end_IL_0007:
						break;
					}
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
			while (true)
			{
				int num = 465176595;
				while (true)
				{
					switch (num ^ 0x1BBA0811)
					{
					case 3:
						break;
					default:
						return;
					case 2:
						if (!Application.isPlaying)
						{
							return;
						}
						goto case 1;
					case 0:
						uYzFvpGmRyWWGtLVturUCJxekis();
						num = 465176597;
						continue;
					case 1:
						if (_targetGraphic == null)
						{
							_targetGraphic = base.gameObject.GetComponent<Graphic>();
							num = 465176593;
							continue;
						}
						goto case 0;
					case 4:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			bool flag = true;
			Transform parent = base.transform;
			int num2 = default(int);
			bool flag2 = default(bool);
			while (true)
			{
				int num = -1474431515;
				while (true)
				{
					switch (num ^ -1474431507)
					{
					case 9:
						break;
					default:
						return;
					case 2:
					{
						int num5;
						if (num2 < _canvasGroupCache.Count)
						{
							num = -1474431514;
							num5 = num;
						}
						else
						{
							num = -1474431519;
							num5 = num;
						}
						continue;
					}
					case 6:
						parent = parent.parent;
						num = -1474431508;
						continue;
					case 0:
						flag2 = true;
						num = -1474431512;
						continue;
					case 1:
					{
						int num4;
						if (!(parent != null))
						{
							num = -1474431506;
							num4 = num;
						}
						else
						{
							num = -1474431510;
							num4 = num;
						}
						continue;
					}
					case 5:
						if (_canvasGroupCache[num2].ignoreParentGroups)
						{
							flag2 = true;
							num = -1474431511;
							continue;
						}
						goto case 4;
					case 8:
						num = -1474431508;
						continue;
					case 3:
						if (flag != _groupsAllowInteraction)
						{
							_groupsAllowInteraction = flag;
							NVWqZPEZaDhGVdcEuqvABdsUKUL();
							num = -1474431513;
							continue;
						}
						return;
					case 12:
					{
						int num3;
						if (!flag2)
						{
							num = -1474431509;
							num3 = num;
						}
						else
						{
							num = -1474431506;
							num3 = num;
						}
						continue;
					}
					case 7:
						parent.GetComponents(_canvasGroupCache);
						flag2 = false;
						num2 = 0;
						num = -1474431505;
						continue;
					case 4:
						num2++;
						num = -1474431505;
						continue;
					case 11:
						if (!_canvasGroupCache[num2].interactable)
						{
							flag = false;
							num = -1474431507;
							continue;
						}
						goto case 5;
					case 10:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDidApplyAnimationProperties()
		{
			base.OnDidApplyAnimationProperties();
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!Application.isPlaying)
			{
				uYzFvpGmRyWWGtLVturUCJxekis();
			}
			QLoEsvcQmZHGkQPzbIQPMHMGZBrf(InteractionState.Normal);
			lPSCJgLLeQzAoKcuIadJZzmnIqP(true);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			jAQGAmQgKbqKrhUPStwqorlTNHK();
			while (true)
			{
				int num = -633779060;
				while (true)
				{
					switch (num ^ -633779059)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 0:
						return;
					}
					break;
					IL_0024:
					base.OnDisable();
					num = -633779059;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			while (true)
			{
				int num = -668820843;
				while (true)
				{
					switch (num ^ -668820844)
					{
					case 6:
						break;
					case 0:
						XTdwPHoIYAeXdtxcHVtlnrtFtNI(null);
						num = -668820841;
						continue;
					case 5:
						EventSystem.current.SetSelectedGameObject(null);
						num = -668820844;
						continue;
					case 3:
						GeMaoYWkSWdVuATkrycOOKBsivlD(Color.white, true);
						CnDPxkPDbLAJqkImsyyrmtwSUPMg(_transitionAnimationTriggers.normalTrigger);
						lPSCJgLLeQzAoKcuIadJZzmnIqP(true);
						num = -668820848;
						continue;
					case 4:
						qweXQsffDfaGHLzEsNQlfjGBeBSJ();
						num = -668820842;
						continue;
					case 1:
						if (vWWTQEuzSAtwkwTidoREbMzaAEi())
						{
							if (!_interactable && EventSystem.current != null)
							{
								int num2;
								if (!(EventSystem.current.currentSelectedGameObject == base.gameObject))
								{
									num = -668820844;
									num2 = num;
								}
								else
								{
									num = -668820847;
									num2 = num;
								}
								continue;
							}
							goto case 0;
						}
						goto case 4;
					default:
						NVWqZPEZaDhGVdcEuqvABdsUKUL();
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
			_allowedMouseButtons = MouseButtonFlags.LeftButton;
			base.Reset();
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			NVWqZPEZaDhGVdcEuqvABdsUKUL();
		}

		internal override void FindEventHandlers()
		{
			base.FindEventHandlers();
			qweXQsffDfaGHLzEsNQlfjGBeBSJ();
		}

		private void jAQGAmQgKbqKrhUPStwqorlTNHK()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
			jYtFWKZUVrechfzATGCgCETBhJCg = false;
			while (true)
			{
				int num = 1318606524;
				while (true)
				{
					switch (num ^ 0x4E9856BF)
					{
					case 4:
						break;
					default:
						return;
					case 3:
						if ((_transitionType & TransitionTypeFlags.ColorTint) != TransitionTypeFlags.None)
						{
							GeMaoYWkSWdVuATkrycOOKBsivlD(Color.white, true);
							num = 1318606526;
							continue;
						}
						goto case 1;
					case 2:
					{
						int num2;
						if ((_transitionType & TransitionTypeFlags.Animation) == 0)
						{
							num = 1318606527;
							num2 = num;
						}
						else
						{
							num = 1318606522;
							num2 = num;
						}
						continue;
					}
					case 5:
						CnDPxkPDbLAJqkImsyyrmtwSUPMg(normalTrigger);
						num = 1318606527;
						continue;
					case 1:
						if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
						{
							XTdwPHoIYAeXdtxcHVtlnrtFtNI(null);
							num = 1318606525;
							continue;
						}
						goto case 2;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void SuHWIDfTNsChRxehzCBEFxUUSSd(InteractionState P_0, bool P_1)
		{
			Color color = default(Color);
			Sprite sprite = default(Sprite);
			string text = default(string);
			UnityEvent unityEvent = default(UnityEvent);
			bool flag = default(bool);
			while (true)
			{
				int num = 790786867;
				while (true)
				{
					switch (num ^ 0x2F22732A)
					{
					case 18:
						break;
					default:
						return;
					case 25:
						switch (P_0)
						{
						case InteractionState.Highlighted:
							goto IL_00cd;
						case InteractionState.Normal:
							goto IL_014f;
						case InteractionState.Disabled:
							goto IL_0165;
						case InteractionState.Pressed:
							goto IL_02db;
						}
						num = 790786850;
						continue;
					case 8:
						color = Color.black;
						sprite = null;
						text = string.Empty;
						unityEvent = null;
						num = 790786879;
						continue;
					case 0:
						GeMaoYWkSWdVuATkrycOOKBsivlD(color, P_1);
						num = 790786848;
						continue;
					case 1:
						goto IL_00cd;
					case 17:
						text = _transitionAnimationTriggers.highlightedTrigger;
						num = 790786861;
						continue;
					case 10:
					{
						int num2;
						if ((_transitionType & TransitionTypeFlags.SpriteSwap) == 0)
						{
							num = 790786874;
							num2 = num;
						}
						else
						{
							num = 790786856;
							num2 = num;
						}
						continue;
					}
					case 7:
						unityEvent = _onInteractionStateChangedToHighlighted;
						num = 790786879;
						continue;
					case 21:
						flag = (_transitionType & TransitionTypeFlags.ColorTint) != 0;
						if (!flag)
						{
							color = Color.white;
							num = 790786851;
							continue;
						}
						goto case 9;
					case 14:
						goto IL_014f;
					case 13:
						goto IL_0165;
					case 2:
						XTdwPHoIYAeXdtxcHVtlnrtFtNI(sprite);
						num = 790786874;
						continue;
					case 12:
						hierarchyInteractionStateTransitionHandlers.ExecuteOnAll(_transitionArgs);
						num = 790786849;
						continue;
					case 11:
						if (_onInteractionStateTransition != null)
						{
							_onInteractionStateTransition.Invoke(_transitionArgs);
							num = 790786860;
							continue;
						}
						goto case 6;
					case 22:
						num = 790786879;
						continue;
					case 5:
						text = _transitionAnimationTriggers.pressedTrigger;
						unityEvent = _onInteractionStateChangedToPressed;
						num = 790786879;
						continue;
					case 24:
						if (base.gameObject.activeInHierarchy)
						{
							if (flag)
							{
								GeMaoYWkSWdVuATkrycOOKBsivlD(color * _transitionColorTint.colorMultiplier, P_1);
								num = 790786848;
								continue;
							}
							goto case 0;
						}
						goto case 3;
					case 6:
						if (unityEvent != null)
						{
							unityEvent.Invoke();
							num = 790786862;
							continue;
						}
						return;
					case 3:
						if (_allowSendingEvents)
						{
							_transitionArgs.fuLKaTfKQpOpktgPzRLpUDfEjf(this, P_0, P_1 ? 0f : _transitionColorTint.fadeDuration);
							num = 790786854;
							continue;
						}
						return;
					case 20:
						sprite = _transitionSpriteState.highlightedSprite;
						num = 790786875;
						continue;
					case 15:
						sprite = null;
						text = _transitionAnimationTriggers.normalTrigger;
						unityEvent = _onInteractionStateChangedToNormal;
						num = 790786879;
						continue;
					case 23:
						color.a = 0f;
						num = 790786866;
						continue;
					case 19:
						goto IL_02db;
					case 16:
						if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
						{
							CnDPxkPDbLAJqkImsyyrmtwSUPMg(text);
							num = 790786857;
							continue;
						}
						goto case 3;
					case 9:
					{
						int num3;
						if (!_visible)
						{
							num = 790786877;
							num3 = num;
						}
						else
						{
							num = 790786866;
							num3 = num;
						}
						continue;
					}
					case 4:
						return;
						IL_02db:
						color = _transitionColorTint.pressedColor;
						sprite = _transitionSpriteState.pressedSprite;
						num = 790786863;
						continue;
						IL_0165:
						color = _transitionColorTint.disabledColor;
						sprite = _transitionSpriteState.disabledSprite;
						text = _transitionAnimationTriggers.disabledTrigger;
						unityEvent = _onInteractionStateChangedToDisabled;
						num = 790786876;
						continue;
						IL_00cd:
						color = _transitionColorTint.highlightedColor;
						num = 790786878;
						continue;
						IL_014f:
						color = _transitionColorTint.normalColor;
						num = 790786853;
						continue;
					}
					break;
				}
			}
		}

		private void GeMaoYWkSWdVuATkrycOOKBsivlD(Color P_0, bool P_1)
		{
			if (_targetGraphic == null)
			{
				return;
			}
			while (true)
			{
				_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, true, true);
				int num = -1258863236;
				while (true)
				{
					switch (num ^ -1258863236)
					{
					case 2:
						goto IL_000f;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000f:
					num = -1258863235;
				}
			}
		}

		private void XTdwPHoIYAeXdtxcHVtlnrtFtNI(Sprite P_0)
		{
			if (!(image == null))
			{
				image.overrideSprite = P_0;
			}
		}

		private void CnDPxkPDbLAJqkImsyyrmtwSUPMg(string P_0)
		{
			if ((_transitionType & TransitionTypeFlags.Animation) == 0 || animator == null)
			{
				return;
			}
			while (true)
			{
				int num = -1046599183;
				while (true)
				{
					switch (num ^ -1046599175)
					{
					case 2:
						break;
					default:
						return;
					case 6:
					{
						int num4;
						if (string.IsNullOrEmpty(P_0))
						{
							num = -1046599175;
							num4 = num;
						}
						else
						{
							num = -1046599172;
							num4 = num;
						}
						continue;
					}
					case 7:
					{
						int num3;
						if (animator.runtimeAnimatorController == null)
						{
							num = -1046599175;
							num3 = num;
						}
						else
						{
							num = -1046599169;
							num3 = num;
						}
						continue;
					}
					case 8:
					{
						int num2;
						if (!UnityTools.IsActiveAndEnabled(animator))
						{
							num = -1046599175;
							num2 = num;
						}
						else
						{
							num = -1046599170;
							num2 = num;
						}
						continue;
					}
					case 0:
						return;
					case 4:
						animator.SetTrigger(P_0);
						num = -1046599176;
						continue;
					case 5:
						animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
						animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
						animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
						num = -1046599174;
						continue;
					case 3:
						animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
						num = -1046599171;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void lPSCJgLLeQzAoKcuIadJZzmnIqP(bool P_0)
		{
			InteractionState interactionState = _interactionState;
			if (vWWTQEuzSAtwkwTidoREbMzaAEi() && !IsInteractable())
			{
				while (true)
				{
					int num = 57892628;
					while (true)
					{
						switch (num ^ 0x3735F15)
						{
						case 0:
							break;
						case 1:
							interactionState = InteractionState.Disabled;
							num = 57892631;
							continue;
						default:
							goto end_IL_0017;
						}
						break;
					}
					continue;
					end_IL_0017:
					break;
				}
			}
			SuHWIDfTNsChRxehzCBEFxUUSSd(interactionState, P_0);
		}

		public bool IsInteractable()
		{
			if (_groupsAllowInteraction)
			{
				return _interactable;
			}
			return false;
		}

		internal virtual bool IsPressed()
		{
			if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				return false;
			}
			if (GXxxUMYvhnAdzwfrIpAYPjIWpue)
			{
				return jYtFWKZUVrechfzATGCgCETBhJCg;
			}
			return false;
		}

		internal void tPzLrmyiYkESrTkUqlRUVdqEdkXD(BaseEventData P_0)
		{
			if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				return;
			}
			InteractionState interactionState = default(InteractionState);
			while (true)
			{
				int num = 648021379;
				while (true)
				{
					switch (num ^ 0x26A00582)
					{
					case 2:
						break;
					case 0:
						interactionState = uggeuIdUyZrSjgCSzVUqAalNEEK(P_0);
						if (interactionState == _interactionState)
						{
							return;
						}
						goto default;
					case 3:
						return;
					case 1:
					{
						int num2;
						if (IsInteractable())
						{
							num = 648021378;
							num2 = num;
						}
						else
						{
							num = 648021377;
							num2 = num;
						}
						continue;
					}
					default:
						QLoEsvcQmZHGkQPzbIQPMHMGZBrf(interactionState);
						lPSCJgLLeQzAoKcuIadJZzmnIqP(false);
						return;
					}
					break;
				}
			}
		}

		internal virtual bool IsThisOrTouchRegionGameObject(GameObject P_0)
		{
			return base.gameObject == P_0;
		}

		private bool NWAUGwGzCBNJWVGxFxsoJtCcfsg(BaseEventData P_0)
		{
			bool flag = P_0 is PointerEventData;
			return NWAUGwGzCBNJWVGxFxsoJtCcfsg(flag, flag ? (P_0 as PointerEventData).pointerPress : null);
		}

		private bool NWAUGwGzCBNJWVGxFxsoJtCcfsg(bool P_0, GameObject P_1)
		{
			if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				return false;
			}
			if (IsPressed())
			{
				return false;
			}
			bool flag = false;
			if (P_0)
			{
				goto IL_0019;
			}
			goto IL_0098;
			IL_0098:
			flag |= GXxxUMYvhnAdzwfrIpAYPjIWpue;
			int num = -217565685;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -217565681)
				{
				case 0:
					break;
				case 2:
					flag |= (jYtFWKZUVrechfzATGCgCETBhJCg && !GXxxUMYvhnAdzwfrIpAYPjIWpue && IsThisOrTouchRegionGameObject(P_1)) || (!jYtFWKZUVrechfzATGCgCETBhJCg && GXxxUMYvhnAdzwfrIpAYPjIWpue && IsThisOrTouchRegionGameObject(P_1)) || (!jYtFWKZUVrechfzATGCgCETBhJCg && GXxxUMYvhnAdzwfrIpAYPjIWpue && P_1 == null);
					num = -217565684;
					continue;
				case 1:
					goto IL_0098;
				case 3:
					num = -217565685;
					continue;
				default:
					return flag;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = -217565683;
			goto IL_001e;
		}

		private InteractionState uggeuIdUyZrSjgCSzVUqAalNEEK(BaseEventData P_0)
		{
			InteractionState result;
			if (IsPressed())
			{
				result = InteractionState.Pressed;
				goto IL_000a;
			}
			int num;
			if (NWAUGwGzCBNJWVGxFxsoJtCcfsg(P_0))
			{
				result = InteractionState.Highlighted;
				num = -1684166768;
				goto IL_000f;
			}
			return InteractionState.Normal;
			IL_000a:
			num = -1684166765;
			goto IL_000f;
			IL_000f:
			switch (num ^ -1684166767)
			{
			case 0:
				break;
			case 2:
				return result;
			default:
				return result;
			}
			goto IL_000a;
		}

		private bool QLoEsvcQmZHGkQPzbIQPMHMGZBrf(InteractionState P_0)
		{
			if (_interactionState == P_0)
			{
				return false;
			}
			_interactionState = P_0;
			DpXYztTnOUCrAJINiuODIfCmiek();
			return true;
		}

		private void DpXYztTnOUCrAJINiuODIfCmiek()
		{
			LunFTqfhqohoqAAmuapPhlSpaZF();
		}

		private void LunFTqfhqohoqAAmuapPhlSpaZF()
		{
			if (Application.isPlaying && _hideWhenIdle)
			{
				SWnzUAEKhgDxxwxmMhpFBvKnnQNm(_interactionState == InteractionState.Pressed, false);
			}
		}

		private void SWnzUAEKhgDxxwxmMhpFBvKnnQNm(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			while (true)
			{
				_visible = P_0;
				_varWatch_visible = P_0;
				if (!_allowSendingEvents)
				{
					break;
				}
				hierarchyVisibilityChangedHandlers.ExecuteOnAll(P_0);
				if (_onVisibilityChanged == null)
				{
					break;
				}
				_onVisibilityChanged.Invoke(P_0);
				int num = 751194774;
				while (true)
				{
					switch (num ^ 0x2CC65294)
					{
					case 0:
						goto IL_000d;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_000d:
					num = 751194773;
				}
			}
		}

		private void uYzFvpGmRyWWGtLVturUCJxekis()
		{
			_varWatch_visible = _visible;
			_varWatch_interactable = IsInteractable();
			bool allowSendingEvents = _allowSendingEvents;
			Action<bool> setValueDelegate = delegate(bool P_0)
			{
				_allowSendingEvents = P_0;
			};
			using (new SetAndRestoreVar<bool>(allowSendingEvents, false, setValueDelegate))
			{
				SWnzUAEKhgDxxwxmMhpFBvKnnQNm(_visible, true);
				LunFTqfhqohoqAAmuapPhlSpaZF();
			}
			qweXQsffDfaGHLzEsNQlfjGBeBSJ();
			if (!_allowSendingEvents)
			{
				return;
			}
			hierarchyVisibilityChangedHandlers.ExecuteOnAll(_visible);
			if (_onVisibilityChanged == null)
			{
				return;
			}
			while (true)
			{
				int num = 1034909313;
				while (true)
				{
					switch (num ^ 0x3DAF7680)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_00a0;
					case 0:
						return;
					}
					break;
					IL_00a0:
					_onVisibilityChanged.Invoke(_visible);
					num = 1034909312;
				}
			}
		}

		private void qVsMyoYBvETfokpXbIGIpiZNXPA()
		{
			if (_varWatch_visible == _visible)
			{
				return;
			}
			_varWatch_visible = _visible;
			if (!_allowSendingEvents || _onVisibilityChanged == null)
			{
				return;
			}
			hierarchyVisibilityChangedHandlers.ExecuteOnAll(_visible);
			while (true)
			{
				int num = -654903361;
				while (true)
				{
					switch (num ^ -654903362)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0059;
					case 2:
						return;
					}
					break;
					IL_0059:
					_onVisibilityChanged.Invoke(_visible);
					num = -654903364;
				}
			}
		}

		private void NVWqZPEZaDhGVdcEuqvABdsUKUL()
		{
			qVsMyoYBvETfokpXbIGIpiZNXPA();
			LunFTqfhqohoqAAmuapPhlSpaZF();
			while (true)
			{
				int num = 843005965;
				while (true)
				{
					switch (num ^ 0x323F400C)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (Application.isPlaying)
						{
							goto IL_0044;
						}
						lPSCJgLLeQzAoKcuIadJZzmnIqP(true);
						return;
					case 2:
						goto IL_0044;
					case 3:
						return;
					}
					break;
					IL_0044:
					lPSCJgLLeQzAoKcuIadJZzmnIqP(false);
					num = 843005967;
				}
			}
		}

		private void qweXQsffDfaGHLzEsNQlfjGBeBSJ()
		{
			hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
			hierarchyInteractionStateTransitionHandlers.GetHandlers(base.transform);
		}

		internal virtual void OnPointerDown(PointerEventData P_0)
		{
			if (!jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerDown))
			{
				while (true)
				{
					switch (0x6296A49E ^ 0x6296A49F)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			jYtFWKZUVrechfzATGCgCETBhJCg = true;
			tPzLrmyiYkESrTkUqlRUVdqEdkXD(P_0);
		}

		internal virtual void OnPointerUp(PointerEventData P_0)
		{
			if (!jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerUp))
			{
				return;
			}
			while (true)
			{
				jYtFWKZUVrechfzATGCgCETBhJCg = false;
				tPzLrmyiYkESrTkUqlRUVdqEdkXD(P_0);
				int num = 526871499;
				while (true)
				{
					switch (num ^ 0x1F676BCA)
					{
					case 0:
						goto IL_0015;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0015:
					num = 526871496;
				}
			}
		}

		internal virtual void OnPointerEnter(PointerEventData P_0)
		{
			if (!jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			while (true)
			{
				GXxxUMYvhnAdzwfrIpAYPjIWpue = true;
				int num = 350087842;
				while (true)
				{
					switch (num ^ 0x14DDEAA2)
					{
					case 2:
						num = 350087841;
						continue;
					default:
						return;
					case 3:
						break;
					case 0:
						tPzLrmyiYkESrTkUqlRUVdqEdkXD(P_0);
						num = 350087843;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		internal virtual void OnPointerExit(PointerEventData P_0)
		{
			if (!jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			while (true)
			{
				GXxxUMYvhnAdzwfrIpAYPjIWpue = false;
				int num = -632477730;
				while (true)
				{
					switch (num ^ -632477732)
					{
					case 3:
						num = -632477731;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						tPzLrmyiYkESrTkUqlRUVdqEdkXD(P_0);
						num = -632477732;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal virtual void OnBeginDrag(PointerEventData P_0)
		{
			jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _allowedMouseButtons, EventTriggerType.BeginDrag);
		}

		internal virtual void OnDrag(PointerEventData P_0)
		{
			jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _allowedMouseButtons, EventTriggerType.Drag);
		}

		internal virtual void OnEndDrag(PointerEventData P_0)
		{
			jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_0.pointerId, _allowedMouseButtons, EventTriggerType.EndDrag);
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

		internal static bool RoGStfwaKUBSohbxbjNXJoKcyhPq(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
			{
				int num = fHkXkQWlHQxjztUUubymvvrnmLX(P_0);
				if (num >= 0)
				{
					Touch touch = Input.GetTouch(num);
					if (touch.phase != TouchPhase.Ended)
					{
						return touch.phase != TouchPhase.Canceled;
					}
					return false;
				}
				goto IL_001d;
			}
			int num2;
			if (LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0) && Input.mousePresent)
			{
				num2 = 1591396033;
				goto IL_0022;
			}
			goto IL_0086;
			IL_001d:
			num2 = 1591396034;
			goto IL_0022;
			IL_0022:
			switch (num2 ^ 0x5EDAC6C0)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				goto IL_0074;
			}
			goto IL_001d;
			IL_0074:
			int num3 = eRyxXopMMXoaiMJTJSVEAcbEsQo(P_0);
			if (num3 >= 0)
			{
				return Input.GetMouseButton(num3);
			}
			goto IL_0086;
			IL_0086:
			return false;
		}

		internal static Vector3 eWcGendfQFVDlCeIgDmIKeADLJy(int P_0)
		{
			if (KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
			{
				int num = fHkXkQWlHQxjztUUubymvvrnmLX(P_0);
				while (true)
				{
					int num2 = 534690141;
					while (true)
					{
						switch (num2 ^ 0x1FDEB95C)
						{
						case 2:
							break;
						case 1:
							goto IL_002d;
						default:
							return Input.touches[num].position;
						}
						break;
						IL_002d:
						if (num < 0 || Input.touchCount <= num)
						{
							goto end_IL_000f;
						}
						num2 = 534690140;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			else if (LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0) && Input.mousePresent)
			{
				return Input.mousePosition;
			}
			return Vector3.zero;
		}

		internal static bool KuAJRIwcSXvZzXmlUAMUBQvrtsg(int P_0)
		{
			return P_0 >= 0;
		}

		internal static bool LPtfcWbVHTptcvJrjwlirMYQDgGc(int P_0)
		{
			if (P_0 != -1 && P_0 != -3)
			{
				return P_0 == -2;
			}
			return true;
		}

		private static int fHkXkQWlHQxjztUUubymvvrnmLX(int P_0)
		{
			if (!KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_0))
			{
				return -1;
			}
			int touchCount = Input.touchCount;
			int num = 0;
			while (num < touchCount)
			{
				while (true)
				{
					if (Input.GetTouch(num).fingerId == P_0)
					{
						return num;
					}
					num++;
					int num2 = 1908904702;
					while (true)
					{
						switch (num2 ^ 0x71C792FE)
						{
						case 2:
							num2 = 1908904703;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0032;
						}
						break;
					}
					continue;
					end_IL_0032:
					break;
				}
			}
			return -1;
		}

		internal static bool jxCLxvxCDOJXvcIvfAZYuiRGzsy(MouseButtonFlags P_0, int P_1)
		{
			if (LPtfcWbVHTptcvJrjwlirMYQDgGc(P_1))
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
			if (KuAJRIwcSXvZzXmlUAMUBQvrtsg(P_1))
			{
				return true;
			}
			if (NlXYmpaJmCxcYptqaxkqNnCTOAf(P_0, P_1))
			{
				return true;
			}
			return false;
		}

		private static bool NlXYmpaJmCxcYptqaxkqNnCTOAf(MouseButtonFlags P_0, int P_1)
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

		private static int eRyxXopMMXoaiMJTJSVEAcbEsQo(int P_0)
		{
			if (!LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
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

		internal static bool mrmKZDYUuqVORhTlxFDFBEPmIPc(MouseButtonFlags P_0, out int P_1)
		{
			int num = 0;
			while (num < 3)
			{
				while (true)
				{
					int num2;
					if (((uint)P_0 & (uint)(1 << num)) != 0)
					{
						num2 = 870552820;
						goto IL_000b;
					}
					goto IL_0051;
					IL_000b:
					while (true)
					{
						switch (num2 ^ 0x33E394F4)
						{
						case 3:
							num2 = 870552816;
							continue;
						case 4:
							break;
						case 2:
							P_1 = (num + 1) * -1;
							num2 = 870552821;
							continue;
						case 1:
							return true;
						case 0:
							goto IL_005c;
						default:
							goto end_IL_0030;
						}
						break;
						IL_005c:
						if (Input.GetMouseButton(num))
						{
							num2 = 870552822;
							continue;
						}
						goto IL_0051;
					}
					continue;
					IL_0051:
					num++;
					num2 = 870552817;
					goto IL_000b;
					continue;
					end_IL_0030:
					break;
				}
			}
			P_1 = int.MinValue;
			return false;
		}

		internal static bool jxCLxvxCDOJXvcIvfAZYuiRGzsy(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			if (LPtfcWbVHTptcvJrjwlirMYQDgGc(P_0))
			{
				if (P_2 == EventTriggerType.PointerEnter)
				{
					goto IL_0031;
				}
				if (P_2 == EventTriggerType.PointerExit)
				{
					goto IL_000f;
				}
			}
			goto IL_0051;
			IL_0051:
			return jxCLxvxCDOJXvcIvfAZYuiRGzsy(P_1, P_0);
			IL_0031:
			int num;
			int num2;
			if (P_1 == MouseButtonFlags.None)
			{
				num = 2108440778;
				num2 = num;
			}
			else
			{
				num = 2108440776;
				num2 = num;
			}
			goto IL_0014;
			IL_000f:
			num = 2108440779;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ 0x7DAC40C9)
				{
				case 0:
					break;
				case 2:
					goto IL_0031;
				case 1:
					P_1 |= MouseButtonFlags.LeftButton;
					num = 2108440778;
					continue;
				default:
					goto IL_0051;
				}
				break;
			}
			goto IL_000f;
		}

		internal static bool adosDjbqcDBzBFXIUEkqUggQerO(MouseButtonFlags P_0)
		{
			int num;
			return mrmKZDYUuqVORhTlxFDFBEPmIPc(P_0, out num);
		}

		[CompilerGenerated]
		private void TIIAUsdJpEzwSRRoekHEIuqJAQe(bool P_0)
		{
			_allowSendingEvents = P_0;
		}

		[CompilerGenerated]
		private static void XnvnhlhdnppCrAbCFdwZiBxvDBT(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
		{
			P_0.OnInteractionStateTransition(P_1);
		}
	}
}
