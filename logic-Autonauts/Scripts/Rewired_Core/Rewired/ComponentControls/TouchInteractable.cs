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
			private TouchInteractable wttwPaXRUOyyrwWiLDRfhJyVWQA;

			private InteractionState AQpCUgrvQaJjZZLPsqXVcYYjHjE;

			private float jKpjMRpoaxHyRyRknQTdtgqoaml;

			public TouchInteractable sender
			{
				get
				{
					return wttwPaXRUOyyrwWiLDRfhJyVWQA;
				}
			}

			public InteractionState state
			{
				get
				{
					return AQpCUgrvQaJjZZLPsqXVcYYjHjE;
				}
			}

			public float duration
			{
				get
				{
					return jKpjMRpoaxHyRyRknQTdtgqoaml;
				}
			}

			internal InteractionStateTransitionArgs()
			{
			}

			internal void KZkCmzhSYSECcInSnhPgKBxtRsI(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
				wttwPaXRUOyyrwWiLDRfhJyVWQA = P_0;
				AQpCUgrvQaJjZZLPsqXVcYYjHjE = P_1;
				jKpjMRpoaxHyRyRknQTdtgqoaml = P_2;
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		private bool _visible = true;

		[SerializeField]
		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		[CustomObfuscation(rename = false)]
		private bool _hideWhenIdle;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		[Bitmask(typeof(MouseButtonFlags))]
		private MouseButtonFlags _allowedMouseButtons = MouseButtonFlags.LeftButton;

		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(TransitionTypeFlags))]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[SerializeField]
		private TransitionTypeFlags _transitionType;

		[SerializeField]
		[Tooltip("Settings using for Color Tint transitions.")]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Graphic _targetGraphic;

		[Tooltip("Event sent when the Interaction State changes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition = new InteractionStateTransitionEventHandler();

		[Tooltip("Event sent when visibility changes.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private VisibilityChangedEventHandler _onVisibilityChanged = new VisibilityChangedEventHandler();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Normal.")]
		private UnityEvent _onInteractionStateChangedToNormal = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UnityEvent _onInteractionStateChangedToHighlighted = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Pressed.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private UnityEvent _onInteractionStateChangedToPressed = new UnityEvent();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Disabled.")]
		private UnityEvent _onInteractionStateChangedToDisabled = new UnityEvent();

		private readonly List<CanvasGroup> _canvasGroupCache = new List<CanvasGroup>();

		private bool _groupsAllowInteraction = true;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool tmlENZkWxfXAUYowkKtYqEQUwuh;

		[NonSerialized]
		private bool QlnYBBpzNpDLYXfPrVIqnYFRDKL;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents = true;

		private static InteractionStateTransitionArgs _transitionArgs = new InteractionStateTransitionArgs();

		private huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		[CompilerGenerated]
		private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> CS_0024_003C_003E9__CachedAnonymousMethodDelegate4;

		private huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IVisibilityChangedHandler, bool> hierarchyVisibilityChangedHandlers
		{
			get
			{
				if (__hierarchyVisibilityChangedHandlers == null)
				{
					while (true)
					{
						int num = -1459845963;
						while (true)
						{
							switch (num ^ -1459845961)
							{
							case 0:
								break;
							case 2:
								__hierarchyVisibilityChangedHandlers = new huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IVisibilityChangedHandler, bool>(ZGLBOYJUmHTiKvoIwuYxvndOOeE.visibilityChangedHandlerDelegate);
								__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
								num = -1459845962;
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

		private huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> hierarchyInteractionStateTransitionHandlers
		{
			get
			{
				if (__hierarchyInteractionStateTransitionHandlers == null)
				{
					__hierarchyInteractionStateTransitionHandlers = new huuGkElBkGQiMROGJhgcoZddnWS.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs>(interactionStateTransitionHandlerDelegate);
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
				if (_interactable == value)
				{
					return;
				}
				while (true)
				{
					_interactable = value;
					int num = 220228487;
					while (true)
					{
						switch (num ^ 0xD206B87)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							OnSetProperty();
							return;
						}
						break;
						IL_000a:
						num = 220228486;
					}
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
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -348294559;
				goto IL_000e;
				IL_000e:
				switch (num ^ -348294560)
				{
				case 3:
					break;
				case 1:
					return;
				case 2:
					goto IL_0033;
				default:
					OnSetProperty();
					return;
				}
				goto IL_0009;
				IL_0033:
				fLfGNTIuzupCCAOzuPlZdWUzABYV(value, false);
				num = -348294560;
				goto IL_000e;
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
				if (_transitionType != value)
				{
					_transitionType = value;
					OnSetProperty();
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
					while (true)
					{
						switch (0x1DF5B648 ^ 0x1DF5B649)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_transitionSpriteState = value;
				OnSetProperty();
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
					OnSetProperty();
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
						switch (-995359958 ^ -995359957)
						{
						case 0:
							continue;
						case 1:
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
					goto IL_000e;
				}
				goto IL_0038;
				IL_000e:
				int num = -2033042003;
				goto IL_0013;
				IL_0013:
				switch (num ^ -2033042004)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					return;
				case 3:
					goto IL_0038;
				case 2:
					return;
				}
				goto IL_000e;
				IL_0038:
				_targetGraphic = value;
				OnSetProperty();
				num = -2033042002;
				goto IL_0013;
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

		internal static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> interactionStateTransitionHandlerDelegate
		{
			get
			{
				if (__interactionStateTransitionHandlerDelegate == null)
				{
					while (true)
					{
						int num = 986725116;
						while (true)
						{
							switch (num ^ 0x3AD03AFD)
							{
							case 3:
								break;
							case 1:
								if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate4 == null)
								{
									CS_0024_003C_003E9__CachedAnonymousMethodDelegate4 = delegate(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
									{
										P_0.OnInteractionStateTransition(P_1);
									};
									num = 986725119;
									continue;
								}
								goto case 2;
							case 2:
								__interactionStateTransitionHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate4;
								num = 986725117;
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
				int num = 744888656;
				while (true)
				{
					switch (num ^ 0x2C661951)
					{
					case 4:
						break;
					case 0:
					{
						int num3;
						if (!(_targetGraphic == null))
						{
							num = 744888660;
							num3 = num;
						}
						else
						{
							num = 744888658;
							num3 = num;
						}
						continue;
					}
					case 3:
						_targetGraphic = base.gameObject.GetComponent<Graphic>();
						num = 744888660;
						continue;
					case 1:
					{
						int num2;
						if (!Application.isPlaying)
						{
							num = 744888659;
							num2 = num;
						}
						else
						{
							num = 744888657;
							num2 = num;
						}
						continue;
					}
					case 2:
						return;
					default:
						LDrBKgwaHyVbhFZOTGuIfdzycptJ();
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
			int num3 = default(int);
			bool flag2 = default(bool);
			while (true)
			{
				int num = -1065500374;
				while (true)
				{
					switch (num ^ -1065500371)
					{
					case 11:
						break;
					default:
						return;
					case 1:
						if (_canvasGroupCache[num3].ignoreParentGroups)
						{
							flag2 = true;
							num = -1065500379;
							continue;
						}
						goto case 8;
					case 5:
						flag = false;
						flag2 = true;
						num = -1065500372;
						continue;
					case 9:
						if (num3 >= _canvasGroupCache.Count)
						{
							int num5;
							if (flag2)
							{
								num = -1065500369;
								num5 = num;
							}
							else
							{
								num = -1065500370;
								num5 = num;
							}
							continue;
						}
						goto case 4;
					case 4:
					{
						int num4;
						if (!_canvasGroupCache[num3].interactable)
						{
							num = -1065500376;
							num4 = num;
						}
						else
						{
							num = -1065500372;
							num4 = num;
						}
						continue;
					}
					case 7:
						num = -1065500377;
						continue;
					case 3:
						parent = parent.parent;
						num = -1065500377;
						continue;
					case 8:
						num3++;
						num = -1065500380;
						continue;
					case 2:
						if (flag != _groupsAllowInteraction)
						{
							_groupsAllowInteraction = flag;
							cIMxKKikLZEqzDDbOdedgdvAfBZi();
							num = -1065500371;
							continue;
						}
						return;
					case 6:
						parent.GetComponents(_canvasGroupCache);
						flag2 = false;
						num3 = 0;
						num = -1065500380;
						continue;
					case 10:
					{
						int num2;
						if (!(parent != null))
						{
							num = -1065500369;
							num2 = num;
						}
						else
						{
							num = -1065500373;
							num2 = num;
						}
						continue;
					}
					case 0:
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
			cIMxKKikLZEqzDDbOdedgdvAfBZi();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!Application.isPlaying)
			{
				goto IL_000d;
			}
			goto IL_0040;
			IL_000d:
			int num = -176378287;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -176378288)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					LDrBKgwaHyVbhFZOTGuIfdzycptJ();
					num = -176378288;
					continue;
				case 0:
					goto IL_0040;
				case 4:
					EDRFWYdBVAKrpijoqiItmhEhVql(true);
					num = -176378285;
					continue;
				case 3:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0040:
			xWsxbgwsoHlnXdtgZmQXqIMWcKy(InteractionState.Normal);
			num = -176378284;
			goto IL_0012;
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			CKGLVtyaWfsrMDiOesswTgtVNOH();
			base.OnDisable();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			while (true)
			{
				int num = -487758735;
				while (true)
				{
					switch (num ^ -487758734)
					{
					case 4:
						break;
					default:
						return;
					case 3:
						_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
						if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
						{
							int num3;
							if (_interactable)
							{
								num = -487758732;
								num3 = num;
							}
							else
							{
								num = -487758733;
								num3 = num;
							}
							continue;
						}
						goto case 5;
					case 1:
					{
						int num4;
						if (EventSystem.current != null)
						{
							num = -487758736;
							num4 = num;
						}
						else
						{
							num = -487758732;
							num4 = num;
						}
						continue;
					}
					case 0:
						EventSystem.current.SetSelectedGameObject(null);
						num = -487758732;
						continue;
					case 7:
						EDRFWYdBVAKrpijoqiItmhEhVql(true);
						num = -487758729;
						continue;
					case 6:
						gfrprUAqGUNQMRdrbXPfAcvFcZF(null);
						zcAjFPuWKUaxDhSdZguQrbJsmpm(Color.white, true);
						rqZFqnvavFbwNhorAwwbKxiMYWF(_transitionAnimationTriggers.normalTrigger);
						num = -487758731;
						continue;
					case 5:
						DjwIDxNrRnxnmlVQEChpYiKFMcR();
						cIMxKKikLZEqzDDbOdedgdvAfBZi();
						num = -487758726;
						continue;
					case 2:
					{
						int num2;
						if (!(EventSystem.current.currentSelectedGameObject == base.gameObject))
						{
							num = -487758732;
							num2 = num;
						}
						else
						{
							num = -487758734;
							num2 = num;
						}
						continue;
					}
					case 8:
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
			while (true)
			{
				int num = 1851908240;
				while (true)
				{
					switch (num ^ 0x6E61E091)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					cIMxKKikLZEqzDDbOdedgdvAfBZi();
					num = 1851908243;
				}
			}
		}

		internal override void FindEventHandlers()
		{
			base.FindEventHandlers();
			DjwIDxNrRnxnmlVQEChpYiKFMcR();
		}

		private void CKGLVtyaWfsrMDiOesswTgtVNOH()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			tmlENZkWxfXAUYowkKtYqEQUwuh = false;
			QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
			while (true)
			{
				int num = -1904779330;
				while (true)
				{
					switch (num ^ -1904779329)
					{
					case 3:
						break;
					default:
						return;
					case 2:
						if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
						{
							rqZFqnvavFbwNhorAwwbKxiMYWF(normalTrigger);
							num = -1904779333;
							continue;
						}
						return;
					case 0:
						if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
						{
							gfrprUAqGUNQMRdrbXPfAcvFcZF(null);
							num = -1904779331;
							continue;
						}
						goto case 2;
					case 1:
						if ((_transitionType & TransitionTypeFlags.ColorTint) != TransitionTypeFlags.None)
						{
							zcAjFPuWKUaxDhSdZguQrbJsmpm(Color.white, true);
							num = -1904779329;
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

		private void lMJPoRRdLqpsAHxtHOIHobpOFrX(InteractionState P_0, bool P_1)
		{
			Color color;
			Sprite sprite = default(Sprite);
			string text = default(string);
			UnityEvent unityEvent = default(UnityEvent);
			int num;
			bool flag = default(bool);
			switch (P_0)
			{
			case InteractionState.Disabled:
				color = _transitionColorTint.disabledColor;
				sprite = _transitionSpriteState.disabledSprite;
				text = _transitionAnimationTriggers.disabledTrigger;
				unityEvent = _onInteractionStateChangedToDisabled;
				num = 698427379;
				goto IL_0024;
			case InteractionState.Pressed:
				goto IL_0124;
			case InteractionState.Highlighted:
				goto IL_023c;
			default:
				goto IL_0285;
			case InteractionState.Normal:
				goto IL_029d;
				IL_0024:
				while (true)
				{
					switch (num ^ 0x29A127E2)
					{
					case 0:
						num = 698427370;
						continue;
					default:
						return;
					case 1:
						_onInteractionStateTransition.Invoke(_transitionArgs);
						num = 698427366;
						continue;
					case 4:
						break;
					case 14:
						goto end_IL_0024;
					case 5:
						unityEvent = _onInteractionStateChangedToNormal;
						num = 698427387;
						continue;
					case 16:
						unityEvent = _onInteractionStateChangedToHighlighted;
						num = 698427379;
						continue;
					case 7:
						goto IL_0124;
					case 21:
						sprite = _transitionSpriteState.pressedSprite;
						text = _transitionAnimationTriggers.pressedTrigger;
						unityEvent = _onInteractionStateChangedToPressed;
						num = 698427379;
						continue;
					case 23:
						if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
						{
							gfrprUAqGUNQMRdrbXPfAcvFcZF(sprite);
							num = 698427380;
							continue;
						}
						goto case 22;
					case 17:
						flag = (_transitionType & TransitionTypeFlags.ColorTint) != 0;
						num = 698427360;
						continue;
					case 24:
						if (!_visible)
						{
							color.a = 0f;
							num = 698427361;
							continue;
						}
						goto IL_02f9;
					case 25:
						num = 698427379;
						continue;
					case 19:
						zcAjFPuWKUaxDhSdZguQrbJsmpm(color, P_1);
						num = 698427381;
						continue;
					case 12:
						hierarchyInteractionStateTransitionHandlers.ExecuteOnAll(_transitionArgs);
						num = 698427369;
						continue;
					case 2:
						if (!flag)
						{
							color = Color.white;
							num = 698427386;
							continue;
						}
						goto case 24;
					case 10:
						if (_allowSendingEvents)
						{
							_transitionArgs.KZkCmzhSYSECcInSnhPgKBxtRsI(this, P_0, P_1 ? 0f : _transitionColorTint.fadeDuration);
							num = 698427374;
							continue;
						}
						return;
					case 9:
						goto IL_023c;
					case 22:
						if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
						{
							rqZFqnvavFbwNhorAwwbKxiMYWF(text);
							num = 698427368;
							continue;
						}
						goto case 10;
					case 15:
						goto IL_0285;
					case 8:
						goto IL_029d;
					case 20:
						unityEvent = null;
						num = 698427379;
						continue;
					case 6:
						unityEvent.Invoke();
						num = 698427376;
						continue;
					case 11:
						goto IL_02dd;
					case 3:
						goto IL_02f9;
					case 13:
						if (flag)
						{
							zcAjFPuWKUaxDhSdZguQrbJsmpm(color * _transitionColorTint.colorMultiplier, P_1);
							num = 698427381;
							continue;
						}
						goto case 19;
					case 18:
						return;
					}
					int num2;
					if (unityEvent == null)
					{
						num = 698427376;
						num2 = num;
					}
					else
					{
						num = 698427364;
						num2 = num;
					}
					continue;
					IL_02dd:
					int num3;
					if (_onInteractionStateTransition == null)
					{
						num = 698427366;
						num3 = num;
					}
					else
					{
						num = 698427363;
						num3 = num;
					}
					continue;
					IL_02f9:
					int num4;
					if (!base.gameObject.activeInHierarchy)
					{
						num = 698427368;
						num4 = num;
					}
					else
					{
						num = 698427375;
						num4 = num;
					}
					continue;
					end_IL_0024:
					break;
				}
				goto case InteractionState.Disabled;
				IL_029d:
				color = _transitionColorTint.normalColor;
				sprite = null;
				text = _transitionAnimationTriggers.normalTrigger;
				num = 698427367;
				goto IL_0024;
				IL_0285:
				color = Color.black;
				sprite = null;
				text = string.Empty;
				num = 698427382;
				goto IL_0024;
				IL_023c:
				color = _transitionColorTint.highlightedColor;
				sprite = _transitionSpriteState.highlightedSprite;
				text = _transitionAnimationTriggers.highlightedTrigger;
				num = 698427378;
				goto IL_0024;
				IL_0124:
				color = _transitionColorTint.pressedColor;
				num = 698427383;
				goto IL_0024;
			}
		}

		private void zcAjFPuWKUaxDhSdZguQrbJsmpm(Color P_0, bool P_1)
		{
			if (!(_targetGraphic == null))
			{
				_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, true, true);
			}
		}

		private void gfrprUAqGUNQMRdrbXPfAcvFcZF(Sprite P_0)
		{
			if (image == null)
			{
				while (true)
				{
					switch (-892573949 ^ -892573950)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			image.overrideSprite = P_0;
		}

		private void rqZFqnvavFbwNhorAwwbKxiMYWF(string P_0)
		{
			if ((_transitionType & TransitionTypeFlags.Animation) == 0 || animator == null || !UnityTools.IsActiveAndEnabled(animator) || animator.runtimeAnimatorController == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(P_0))
			{
				while (true)
				{
					switch (0x27379CA5 ^ 0x27379CA7)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
			animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
			animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
			animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
			animator.SetTrigger(P_0);
		}

		private void EDRFWYdBVAKrpijoqiItmhEhVql(bool P_0)
		{
			InteractionState interactionState = _interactionState;
			if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				goto IL_000f;
			}
			goto IL_0042;
			IL_000f:
			int num = -751151131;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ -751151132)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					if (!IsInteractable())
					{
						interactionState = InteractionState.Disabled;
						num = -751151129;
						continue;
					}
					goto IL_0042;
				case 3:
					goto IL_0042;
				case 2:
					return;
				}
				break;
			}
			goto IL_000f;
			IL_0042:
			lMJPoRRdLqpsAHxtHOIHobpOFrX(interactionState, P_0);
			num = -751151130;
			goto IL_0014;
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
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				return false;
			}
			if (tmlENZkWxfXAUYowkKtYqEQUwuh)
			{
				return QlnYBBpzNpDLYXfPrVIqnYFRDKL;
			}
			return false;
		}

		internal void EQnWUlQqOynmEtPVWLCOkLeIdyA(BaseEventData P_0)
		{
			if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				if (!IsInteractable())
				{
					goto IL_0010;
				}
				goto IL_004d;
			}
			return;
			IL_003e:
			InteractionState interactionState = default(InteractionState);
			xWsxbgwsoHlnXdtgZmQXqIMWcKy(interactionState);
			int num = 1989709733;
			goto IL_0015;
			IL_0010:
			num = 1989709728;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x76988FA1)
			{
			case 0:
				break;
			case 1:
				return;
			case 2:
				goto IL_003e;
			case 3:
				goto IL_004d;
			default:
				EDRFWYdBVAKrpijoqiItmhEhVql(false);
				return;
			}
			goto IL_0010;
			IL_004d:
			interactionState = FDkNpFDQeNAEEKqBPeJgHzxDAPDX(P_0);
			if (interactionState == _interactionState)
			{
				return;
			}
			goto IL_003e;
		}

		internal virtual bool IsThisOrTouchRegionGameObject(GameObject P_0)
		{
			return base.gameObject == P_0;
		}

		private bool akCEZtFgQJAaxUlctkimxkYalbj(BaseEventData P_0)
		{
			bool flag = P_0 is PointerEventData;
			return akCEZtFgQJAaxUlctkimxkYalbj(flag, flag ? (P_0 as PointerEventData).pointerPress : null);
		}

		private bool akCEZtFgQJAaxUlctkimxkYalbj(bool P_0, GameObject P_1)
		{
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
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
				goto IL_001c;
			}
			goto IL_00a5;
			IL_0021:
			int num;
			while (true)
			{
				switch (num ^ -306828452)
				{
				case 3:
					break;
				case 2:
					flag |= (QlnYBBpzNpDLYXfPrVIqnYFRDKL && !tmlENZkWxfXAUYowkKtYqEQUwuh && IsThisOrTouchRegionGameObject(P_1)) || (!QlnYBBpzNpDLYXfPrVIqnYFRDKL && tmlENZkWxfXAUYowkKtYqEQUwuh && IsThisOrTouchRegionGameObject(P_1)) || (!QlnYBBpzNpDLYXfPrVIqnYFRDKL && tmlENZkWxfXAUYowkKtYqEQUwuh && P_1 == null);
					num = -306828451;
					continue;
				case 1:
					num = -306828452;
					continue;
				case 4:
					goto IL_00a5;
				default:
					return flag;
				}
				break;
			}
			goto IL_001c;
			IL_00a5:
			flag |= tmlENZkWxfXAUYowkKtYqEQUwuh;
			num = -306828452;
			goto IL_0021;
			IL_001c:
			num = -306828450;
			goto IL_0021;
		}

		private InteractionState FDkNpFDQeNAEEKqBPeJgHzxDAPDX(BaseEventData P_0)
		{
			InteractionState result = default(InteractionState);
			if (IsPressed())
			{
				result = InteractionState.Pressed;
				goto IL_000a;
			}
			int num;
			if (akCEZtFgQJAaxUlctkimxkYalbj(P_0))
			{
				num = -1867940130;
				goto IL_000f;
			}
			return InteractionState.Normal;
			IL_000a:
			num = -1867940129;
			goto IL_000f;
			IL_000f:
			switch (num ^ -1867940130)
			{
			case 2:
				break;
			case 1:
				return result;
			default:
				return InteractionState.Highlighted;
			}
			goto IL_000a;
		}

		private bool xWsxbgwsoHlnXdtgZmQXqIMWcKy(InteractionState P_0)
		{
			if (_interactionState == P_0)
			{
				return false;
			}
			_interactionState = P_0;
			sTNaBwxkAWhrrzeKQGgZnaSgsvh();
			return true;
		}

		private void sTNaBwxkAWhrrzeKQGgZnaSgsvh()
		{
			cCfKIlLyDgEBPqafQdKJQSQrKyA();
		}

		private void cCfKIlLyDgEBPqafQdKJQSQrKyA()
		{
			if (!Application.isPlaying)
			{
				goto IL_0007;
			}
			goto IL_0048;
			IL_0007:
			int num = -379399147;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -379399151)
				{
				case 0:
					break;
				default:
					return;
				case 5:
					fLfGNTIuzupCCAOzuPlZdWUzABYV(_interactionState == InteractionState.Pressed, false);
					num = -379399152;
					continue;
				case 2:
					goto IL_0048;
				case 3:
					return;
				case 4:
					return;
				case 1:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0048:
			int num2;
			if (!_hideWhenIdle)
			{
				num = -379399150;
				num2 = num;
			}
			else
			{
				num = -379399148;
				num2 = num;
			}
			goto IL_000c;
		}

		private void fLfGNTIuzupCCAOzuPlZdWUzABYV(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			while (true)
			{
				_visible = P_0;
				int num = 1447827794;
				while (true)
				{
					switch (num ^ 0x564C1952)
					{
					case 2:
						num = 1447827795;
						continue;
					default:
						return;
					case 1:
						break;
					case 0:
						_varWatch_visible = P_0;
						if (_allowSendingEvents)
						{
							hierarchyVisibilityChangedHandlers.ExecuteOnAll(P_0);
							if (_onVisibilityChanged != null)
							{
								_onVisibilityChanged.Invoke(P_0);
								num = 1447827793;
								continue;
							}
						}
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void LDrBKgwaHyVbhFZOTGuIfdzycptJ()
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
				fLfGNTIuzupCCAOzuPlZdWUzABYV(_visible, true);
				cCfKIlLyDgEBPqafQdKJQSQrKyA();
			}
			DjwIDxNrRnxnmlVQEChpYiKFMcR();
			if (_allowSendingEvents)
			{
				hierarchyVisibilityChangedHandlers.ExecuteOnAll(_visible);
				if (_onVisibilityChanged != null)
				{
					_onVisibilityChanged.Invoke(_visible);
				}
			}
		}

		private void TJyJGniZjWcyLYCUZGcAWcZXGRH()
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

		private void cIMxKKikLZEqzDDbOdedgdvAfBZi()
		{
			TJyJGniZjWcyLYCUZGcAWcZXGRH();
			cCfKIlLyDgEBPqafQdKJQSQrKyA();
			if (!Application.isPlaying)
			{
				EDRFWYdBVAKrpijoqiItmhEhVql(true);
			}
			else
			{
				EDRFWYdBVAKrpijoqiItmhEhVql(false);
			}
		}

		private void DjwIDxNrRnxnmlVQEChpYiKFMcR()
		{
			hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
			while (true)
			{
				int num = -978887322;
				while (true)
				{
					switch (num ^ -978887321)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_002f;
					case 0:
						return;
					}
					break;
					IL_002f:
					hierarchyInteractionStateTransitionHandlers.GetHandlers(base.transform);
					num = -978887321;
				}
			}
		}

		internal virtual void OnPointerDown(PointerEventData P_0)
		{
			if (ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerDown))
			{
				QlnYBBpzNpDLYXfPrVIqnYFRDKL = true;
				EQnWUlQqOynmEtPVWLCOkLeIdyA(P_0);
			}
		}

		internal virtual void OnPointerUp(PointerEventData P_0)
		{
			if (ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerUp))
			{
				QlnYBBpzNpDLYXfPrVIqnYFRDKL = false;
				EQnWUlQqOynmEtPVWLCOkLeIdyA(P_0);
			}
		}

		internal virtual void OnPointerEnter(PointerEventData P_0)
		{
			if (!ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				return;
			}
			while (true)
			{
				tmlENZkWxfXAUYowkKtYqEQUwuh = true;
				EQnWUlQqOynmEtPVWLCOkLeIdyA(P_0);
				int num = 1820898372;
				while (true)
				{
					switch (num ^ 0x6C88B444)
					{
					case 2:
						goto IL_0015;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0015:
					num = 1820898373;
				}
			}
		}

		internal virtual void OnPointerExit(PointerEventData P_0)
		{
			if (!ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			while (true)
			{
				tmlENZkWxfXAUYowkKtYqEQUwuh = false;
				EQnWUlQqOynmEtPVWLCOkLeIdyA(P_0);
				int num = 1415475649;
				while (true)
				{
					switch (num ^ 0x545E71C1)
					{
					case 2:
						goto IL_0015;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0015:
					num = 1415475648;
				}
			}
		}

		internal virtual void OnBeginDrag(PointerEventData P_0)
		{
			ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _allowedMouseButtons, EventTriggerType.BeginDrag);
		}

		internal virtual void OnDrag(PointerEventData P_0)
		{
			ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _allowedMouseButtons, EventTriggerType.Drag);
		}

		internal virtual void OnEndDrag(PointerEventData P_0)
		{
			ULICFcJyRCkoAIPyRCsILRQGufn(P_0.pointerId, _allowedMouseButtons, EventTriggerType.EndDrag);
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

		internal static bool kbMCsiiWOKxlJWHaZJNVHJWBcqKM(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				return false;
			}
			if (dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
			{
				int num = OViWINmCzOOuCPdRWnucIxWjhgA(P_0);
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
			if (gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
			{
				int num3 = default(int);
				while (true)
				{
					int num2 = 398052296;
					while (true)
					{
						switch (num2 ^ 0x17B9CBC9)
						{
						case 0:
							break;
						case 1:
							goto IL_0066;
						default:
							return Input.GetMouseButton(num3);
						}
						break;
						IL_0066:
						if (!Input.mousePresent)
						{
							goto end_IL_0048;
						}
						num3 = XVkcSrDFSNZNHceMrcVCodvWkXtj(P_0);
						if (num3 < 0)
						{
							goto end_IL_0048;
						}
						num2 = 398052299;
					}
					continue;
					end_IL_0048:
					break;
				}
			}
			return false;
		}

		internal static Vector3 LHsXCsNAjXaZWaBWMkQCnCpFObj(int P_0)
		{
			int num = default(int);
			int num2;
			if (dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
			{
				num = OViWINmCzOOuCPdRWnucIxWjhgA(P_0);
				if (num >= 0)
				{
					goto IL_0013;
				}
			}
			else if (gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
			{
				num2 = 1583179851;
				goto IL_0018;
			}
			goto IL_006b;
			IL_006b:
			return Vector3.zero;
			IL_005e:
			if (Input.mousePresent)
			{
				return Input.mousePosition;
			}
			goto IL_006b;
			IL_0031:
			if (Input.touchCount > num)
			{
				return Input.touches[num].position;
			}
			goto IL_006b;
			IL_0013:
			num2 = 1583179848;
			goto IL_0018;
			IL_0018:
			switch (num2 ^ 0x5E5D6849)
			{
			case 0:
				break;
			case 1:
				goto IL_0031;
			default:
				goto IL_005e;
			}
			goto IL_0013;
		}

		internal static bool dCEGGDKGyJKbIviMqMWMahFzaKn(int P_0)
		{
			return P_0 >= 0;
		}

		internal static bool gydVlFlzHNJAJhzgHruavaCUkbP(int P_0)
		{
			if (P_0 != -1 && P_0 != -3)
			{
				return P_0 == -2;
			}
			return true;
		}

		private static int OViWINmCzOOuCPdRWnucIxWjhgA(int P_0)
		{
			if (!dCEGGDKGyJKbIviMqMWMahFzaKn(P_0))
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
					int num2 = 917031643;
					while (true)
					{
						switch (num2 ^ 0x36A8CAD9)
						{
						case 0:
							num2 = 917031640;
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

		internal static bool ULICFcJyRCkoAIPyRCsILRQGufn(MouseButtonFlags P_0, int P_1)
		{
			if (gydVlFlzHNJAJhzgHruavaCUkbP(P_1))
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
			if (dCEGGDKGyJKbIviMqMWMahFzaKn(P_1))
			{
				return true;
			}
			if (mYPgnmeUwGrXxeVvQBksQgONKPig(P_0, P_1))
			{
				return true;
			}
			return false;
		}

		private static bool mYPgnmeUwGrXxeVvQBksQgONKPig(MouseButtonFlags P_0, int P_1)
		{
			switch (P_1)
			{
			default:
				while (true)
				{
					switch (0x318527B4 ^ 0x318527B5)
					{
					case 0:
						continue;
					case 1:
						return false;
					}
					break;
				}
				goto case -1;
			case -1:
				return (P_0 & MouseButtonFlags.LeftButton) != 0;
			case -2:
				return (P_0 & MouseButtonFlags.RightButton) != 0;
			case -3:
				return (P_0 & MouseButtonFlags.MiddleButton) != 0;
			}
		}

		private static int XVkcSrDFSNZNHceMrcVCodvWkXtj(int P_0)
		{
			if (!gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
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

		internal static bool TrwaVKkqmuGmcHocRVPXaUPcSGp(MouseButtonFlags P_0, out int P_1)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 1129751788;
				while (true)
				{
					switch (num ^ 0x4356A4E9)
					{
					case 0:
						break;
					case 2:
						if (Input.GetMouseButton(num2))
						{
							P_1 = (num2 + 1) * -1;
							return true;
						}
						goto IL_003d;
					case 1:
						if (((uint)P_0 & (uint)(1 << num2)) != 0)
						{
							num = 1129751787;
							continue;
						}
						goto IL_003d;
					case 4:
					{
						int num3;
						if (num2 >= 3)
						{
							num = 1129751786;
							num3 = num;
						}
						else
						{
							num = 1129751784;
							num3 = num;
						}
						continue;
					}
					case 5:
						num2 = 0;
						num = 1129751789;
						continue;
					default:
						{
							P_1 = int.MinValue;
							return false;
						}
						IL_003d:
						num2++;
						num = 1129751789;
						continue;
					}
					break;
				}
			}
		}

		internal static bool ULICFcJyRCkoAIPyRCsILRQGufn(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			if (gydVlFlzHNJAJhzgHruavaCUkbP(P_0))
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
			return ULICFcJyRCkoAIPyRCsILRQGufn(P_1, P_0);
			IL_0031:
			int num;
			int num2;
			if (P_1 != MouseButtonFlags.None)
			{
				num = -1977809365;
				num2 = num;
			}
			else
			{
				num = -1977809368;
				num2 = num;
			}
			goto IL_0014;
			IL_000f:
			num = -1977809367;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ -1977809366)
				{
				case 0:
					break;
				case 3:
					goto IL_0031;
				case 1:
					P_1 |= MouseButtonFlags.LeftButton;
					num = -1977809368;
					continue;
				default:
					goto IL_0051;
				}
				break;
			}
			goto IL_000f;
		}

		internal static bool FDenAmVtwBdAcjaFssMofuoOzsP(MouseButtonFlags P_0)
		{
			int num;
			return TrwaVKkqmuGmcHocRVPXaUPcSGp(P_0, out num);
		}

		[CompilerGenerated]
		private void iAYHxWTHITMdErQYniEuboDZJvi(bool P_0)
		{
			_allowSendingEvents = P_0;
		}

		[CompilerGenerated]
		private static void sQjesJDxEpISmyPbpiTeJtmjEEG(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
		{
			P_0.OnInteractionStateTransition(P_1);
		}
	}
}
