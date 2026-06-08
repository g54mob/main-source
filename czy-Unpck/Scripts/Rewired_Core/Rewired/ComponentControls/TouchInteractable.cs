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
			private TouchInteractable JrpajstjvMboyPHiKesLfKIOLgf;

			private InteractionState lUdstvFpjmjeYgkuzHaSijamfet;

			private float SOdGYKBWFhuEEDnFgblsxfIhprQ;

			public TouchInteractable sender => JrpajstjvMboyPHiKesLfKIOLgf;

			public InteractionState state => lUdstvFpjmjeYgkuzHaSijamfet;

			public float duration => SOdGYKBWFhuEEDnFgblsxfIhprQ;

			internal InteractionStateTransitionArgs()
			{
			}

			internal void dhodbseVbYqPVvdUgNSOeWdaMYFi(TouchInteractable P_0, InteractionState P_1, float P_2)
			{
				JrpajstjvMboyPHiKesLfKIOLgf = P_0;
				lUdstvFpjmjeYgkuzHaSijamfet = P_1;
				SOdGYKBWFhuEEDnFgblsxfIhprQ = P_2;
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles whether the control can be interacted with by the user.")]
		private bool _interactable = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
		[SerializeField]
		private bool _visible = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
		private bool _hideWhenIdle;

		[Bitmask(typeof(MouseButtonFlags))]
		[Tooltip("The mouse buttons that are allowed to interact with this control.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private MouseButtonFlags _allowedMouseButtons = MouseButtonFlags.LeftButton;

		[SerializeField]
		[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
		[CustomObfuscation(rename = false)]
		[Bitmask(typeof(TransitionTypeFlags))]
		private TransitionTypeFlags _transitionType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Color Tint transitions.")]
		private ColorBlock _transitionColorTint = new ColorBlock
		{
			colorMultiplier = 1f,
			disabledColor = new Color(25f / 32f, 25f / 32f, 25f / 32f, 0.5f),
			highlightedColor = Color.white,
			normalColor = Color.white,
			pressedColor = Color.white,
			fadeDuration = 0.1f
		};

		[SerializeField]
		[Tooltip("Settings using for Sprite State transitions.")]
		[CustomObfuscation(rename = false)]
		private SpriteState _transitionSpriteState;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Settings using for Animation Trigger transitions.")]
		private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

		[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Graphic _targetGraphic;

		[SerializeField]
		[Tooltip("Event sent when the Interaction State changes.")]
		[CustomObfuscation(rename = false)]
		private InteractionStateTransitionEventHandler _onInteractionStateTransition = new InteractionStateTransitionEventHandler();

		[SerializeField]
		[Tooltip("Event sent when visibility changes.")]
		[CustomObfuscation(rename = false)]
		private VisibilityChangedEventHandler _onVisibilityChanged = new VisibilityChangedEventHandler();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Normal.")]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToNormal = new UnityEvent();

		[Tooltip("Event sent when interaction state changes to Highlighted.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToHighlighted = new UnityEvent();

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Pressed.")]
		private UnityEvent _onInteractionStateChangedToPressed = new UnityEvent();

		[CustomObfuscation(rename = false)]
		[Tooltip("Event sent when interaction state changes to Disabled.")]
		[SerializeField]
		private UnityEvent _onInteractionStateChangedToDisabled = new UnityEvent();

		private readonly List<CanvasGroup> _canvasGroupCache = new List<CanvasGroup>();

		private bool _groupsAllowInteraction = true;

		private InteractionState _interactionState;

		[NonSerialized]
		private bool IflsmAOKUdJKTpCZjpeDsuqZbjM;

		[NonSerialized]
		private bool deteGKFsUpKVtiobsxDnfbVWHkL;

		private bool _varWatch_visible;

		private bool _varWatch_interactable;

		private bool _allowSendingEvents = true;

		private static InteractionStateTransitionArgs _transitionArgs = new InteractionStateTransitionArgs();

		private SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

		private SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

		private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

		[CompilerGenerated]
		private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> CS_0024_003C_003E9__CachedAnonymousMethodDelegate4;

		private SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IVisibilityChangedHandler, bool> hierarchyVisibilityChangedHandlers
		{
			get
			{
				if (__hierarchyVisibilityChangedHandlers == null)
				{
					__hierarchyVisibilityChangedHandlers = new SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IVisibilityChangedHandler, bool>(moLZcJhMxPmMTQrJnWJXhMVBgVtf.visibilityChangedHandlerDelegate);
					__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
				}
				return __hierarchyVisibilityChangedHandlers;
			}
		}

		private SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> hierarchyInteractionStateTransitionHandlers
		{
			get
			{
				if (__hierarchyInteractionStateTransitionHandlers == null)
				{
					__hierarchyInteractionStateTransitionHandlers = new SPqVgBBxXOfLJqOnULlpqjJsHJf.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs>(interactionStateTransitionHandlerDelegate);
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
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -926826124;
				goto IL_000e;
				IL_000e:
				switch (num ^ -926826123)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					return;
				case 2:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				_interactable = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
				num = -926826123;
				goto IL_000e;
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
					while (true)
					{
						switch (0x7EC36F67 ^ 0x7EC36F65)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				KEpqQGGfOeHyBrmOlKJIMDckKQh(value, false);
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_allowedMouseButtons == value)
				{
					return;
				}
				while (true)
				{
					_allowedMouseButtons = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 821076574;
					while (true)
					{
						switch (num ^ 0x30F0A25C)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = 821076573;
					}
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
					return;
				}
				while (true)
				{
					_transitionType = value;
					int num = -1396123561;
					while (true)
					{
						switch (num ^ -1396123561)
						{
						case 2:
							goto IL_000a;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000a:
						num = -1396123562;
					}
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
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
					return;
				}
				while (true)
				{
					_transitionSpriteState = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = -232849191;
					while (true)
					{
						switch (num ^ -232849191)
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
						num = -232849192;
					}
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
				if (_transitionAnimationTriggers == value)
				{
					goto IL_0009;
				}
				goto IL_0044;
				IL_0009:
				int num = -2130809106;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -2130809105)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						return;
					case 0:
						wWklIWMVIReShFCdZhfAVVyDQgX();
						num = -2130809109;
						continue;
					case 2:
						goto IL_0044;
					case 4:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0044:
				_transitionAnimationTriggers = value;
				num = -2130809105;
				goto IL_000e;
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
						switch (-2011606042 ^ -2011606044)
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
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
				int num = 369601552;
				goto IL_0013;
				IL_0013:
				switch (num ^ 0x1607AC12)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_0038;
				case 0:
					return;
				}
				goto IL_000e;
				IL_0038:
				_targetGraphic = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
				num = 369601554;
				goto IL_0013;
			}
		}

		public Animator animator => base.gameObject.GetComponent<Animator>();

		public InteractionState interactionState => _interactionState;

		internal static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> interactionStateTransitionHandlerDelegate
		{
			get
			{
				if (__interactionStateTransitionHandlerDelegate == null)
				{
					if (CS_0024_003C_003E9__CachedAnonymousMethodDelegate4 == null)
					{
						goto IL_000e;
					}
					goto IL_0048;
				}
				goto IL_0059;
				IL_0059:
				return __interactionStateTransitionHandlerDelegate;
				IL_000e:
				int num = -219774777;
				goto IL_0013;
				IL_0013:
				while (true)
				{
					switch (num ^ -219774780)
					{
					case 0:
						break;
					case 3:
						CS_0024_003C_003E9__CachedAnonymousMethodDelegate4 = delegate(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
						{
							P_0.OnInteractionStateTransition(P_1);
						};
						num = -219774779;
						continue;
					case 1:
						goto IL_0048;
					default:
						goto IL_0059;
					}
					break;
				}
				goto IL_000e;
				IL_0048:
				__interactionStateTransitionHandlerDelegate = CS_0024_003C_003E9__CachedAnonymousMethodDelegate4;
				num = -219774778;
				goto IL_0013;
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
				int num = -1784882497;
				while (true)
				{
					switch (num ^ -1784882499)
					{
					case 3:
						break;
					case 0:
						if (_targetGraphic == null)
						{
							_targetGraphic = base.gameObject.GetComponent<Graphic>();
							num = -1784882500;
							continue;
						}
						goto default;
					case 4:
						return;
					case 2:
					{
						int num2;
						if (!Application.isPlaying)
						{
							num = -1784882503;
							num2 = num;
						}
						else
						{
							num = -1784882499;
							num2 = num;
						}
						continue;
					}
					default:
						mCfqjvKuqejioobvUrFBzcZtvoG();
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
			int num2 = default(int);
			bool flag2 = default(bool);
			Transform parent = default(Transform);
			bool flag = default(bool);
			while (true)
			{
				int num = -1347248543;
				while (true)
				{
					switch (num ^ -1347248542)
					{
					case 9:
						break;
					default:
						return;
					case 4:
						num2++;
						num = -1347248529;
						continue;
					case 11:
						if (!flag2)
						{
							parent = parent.parent;
							num = -1347248537;
							continue;
						}
						goto case 12;
					case 2:
						num = -1347248537;
						continue;
					case 1:
						parent.GetComponents(_canvasGroupCache);
						flag2 = false;
						num2 = 0;
						num = -1347248534;
						continue;
					case 0:
						if (!_canvasGroupCache[num2].interactable)
						{
							flag = false;
							flag2 = true;
							num = -1347248540;
							continue;
						}
						goto case 6;
					case 14:
						NPOFSRfAiJHJstoMPmTkHgTRYCc();
						num = -1347248539;
						continue;
					case 5:
					{
						int num5;
						if (parent != null)
						{
							num = -1347248541;
							num5 = num;
						}
						else
						{
							num = -1347248530;
							num5 = num;
						}
						continue;
					}
					case 12:
					{
						int num4;
						if (flag == _groupsAllowInteraction)
						{
							num = -1347248539;
							num4 = num;
						}
						else
						{
							num = -1347248536;
							num4 = num;
						}
						continue;
					}
					case 8:
						num = -1347248529;
						continue;
					case 13:
					{
						int num3;
						if (num2 < _canvasGroupCache.Count)
						{
							num = -1347248542;
							num3 = num;
						}
						else
						{
							num = -1347248535;
							num3 = num;
						}
						continue;
					}
					case 3:
						flag = true;
						parent = base.transform;
						num = -1347248544;
						continue;
					case 6:
						if (_canvasGroupCache[num2].ignoreParentGroups)
						{
							flag2 = true;
							num = -1347248538;
							continue;
						}
						goto case 4;
					case 10:
						_groupsAllowInteraction = flag;
						num = -1347248532;
						continue;
					case 7:
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
			while (true)
			{
				int num = 1709441610;
				while (true)
				{
					switch (num ^ 0x65E4024B)
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
					NPOFSRfAiJHJstoMPmTkHgTRYCc();
					num = 1709441611;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnEnable()
		{
			base.OnEnable();
			if (!Application.isPlaying)
			{
				while (true)
				{
					int num = -263946548;
					while (true)
					{
						switch (num ^ -263946547)
						{
						case 2:
							break;
						case 1:
							mCfqjvKuqejioobvUrFBzcZtvoG();
							num = -263946547;
							continue;
						default:
							goto end_IL_000d;
						}
						break;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			MUoEchOXZPsMEOROKtaGiEoDBMP(InteractionState.Normal);
			xFRbkPhHuGXRyWLYlLZgacHeUGUi(true);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnDisable()
		{
			plWofkMyjnoeNofvjgPhBKLAfRiC();
			base.OnDisable();
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
			if (pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				while (true)
				{
					int num = 1300110139;
					while (true)
					{
						switch (num ^ 0x4D7E1B3E)
						{
						case 4:
							break;
						case 5:
							goto IL_005e;
						case 0:
							goto IL_0077;
						case 2:
							if (EventSystem.current.currentSelectedGameObject == base.gameObject)
							{
								EventSystem.current.SetSelectedGameObject(null);
								num = 1300110141;
								continue;
							}
							goto case 3;
						case 3:
							RjthIHqdtMwYHwNCgrsiQiVCbrog(null);
							MGKFSQAMxOCfCESIUMRTldtbNhJC(Color.white, true);
							EMVJCmXWIVhOCFPWBBGqYLMZRMm(_transitionAnimationTriggers.normalTrigger);
							xFRbkPhHuGXRyWLYlLZgacHeUGUi(true);
							num = 1300110143;
							continue;
						default:
							goto end_IL_0031;
						}
						break;
						IL_0077:
						int num2;
						if (EventSystem.current != null)
						{
							num = 1300110140;
							num2 = num;
						}
						else
						{
							num = 1300110141;
							num2 = num;
						}
						continue;
						IL_005e:
						int num3;
						if (!_interactable)
						{
							num = 1300110142;
							num3 = num;
						}
						else
						{
							num = 1300110141;
							num3 = num;
						}
					}
					continue;
					end_IL_0031:
					break;
				}
			}
			iioftihTwbmXdSIcRBzaWOcAnVk();
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		[CustomObfuscation(rename = false)]
		internal override void Reset()
		{
			_targetGraphic = base.gameObject.GetComponent<Graphic>();
			_allowedMouseButtons = MouseButtonFlags.LeftButton;
			while (true)
			{
				int num = -2043979327;
				while (true)
				{
					switch (num ^ -2043979328)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0036;
					case 0:
						return;
					}
					break;
					IL_0036:
					base.Reset();
					num = -2043979328;
				}
			}
		}

		internal override void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			base.wWklIWMVIReShFCdZhfAVVyDQgX();
			NPOFSRfAiJHJstoMPmTkHgTRYCc();
		}

		internal override void bDqKNfDLkzsEdxLPBgplGtPGTwPI()
		{
			base.bDqKNfDLkzsEdxLPBgplGtPGTwPI();
			iioftihTwbmXdSIcRBzaWOcAnVk();
		}

		private void plWofkMyjnoeNofvjgPhBKLAfRiC()
		{
			string normalTrigger = _transitionAnimationTriggers.normalTrigger;
			IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
			deteGKFsUpKVtiobsxDnfbVWHkL = false;
			if ((_transitionType & TransitionTypeFlags.ColorTint) != TransitionTypeFlags.None)
			{
				goto IL_0024;
			}
			goto IL_0075;
			IL_0024:
			int num = 1334748973;
			goto IL_0029;
			IL_0029:
			while (true)
			{
				switch (num ^ 0x4F8EA72C)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					MGKFSQAMxOCfCESIUMRTldtbNhJC(Color.white, true);
					num = 1334748975;
					continue;
				case 0:
					goto IL_005d;
				case 3:
					goto IL_0075;
				case 4:
					return;
				}
				break;
			}
			goto IL_0024;
			IL_005d:
			if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
			{
				EMVJCmXWIVhOCFPWBBGqYLMZRMm(normalTrigger);
				num = 1334748968;
				goto IL_0029;
			}
			return;
			IL_0075:
			if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
			{
				RjthIHqdtMwYHwNCgrsiQiVCbrog(null);
				num = 1334748972;
				goto IL_0029;
			}
			goto IL_005d;
		}

		private void IONEiCIvsiVsXkmUQKvSSaXNlMkE(InteractionState P_0, bool P_1)
		{
			string text = default(string);
			Color color = default(Color);
			Sprite sprite = default(Sprite);
			UnityEvent unityEvent = default(UnityEvent);
			bool flag = default(bool);
			while (true)
			{
				int num = 1437039072;
				while (true)
				{
					switch (num ^ 0x55A779EB)
					{
					case 20:
						break;
					default:
						return;
					case 19:
						if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
						{
							EMVJCmXWIVhOCFPWBBGqYLMZRMm(text);
							num = 1437039086;
							continue;
						}
						goto case 5;
					case 21:
						color = _transitionColorTint.disabledColor;
						sprite = _transitionSpriteState.disabledSprite;
						text = _transitionAnimationTriggers.disabledTrigger;
						unityEvent = _onInteractionStateChangedToDisabled;
						num = 1437039099;
						continue;
					case 14:
						if (!_visible)
						{
							color.a = 0f;
							num = 1437039075;
							continue;
						}
						goto case 8;
					case 7:
						sprite = _transitionSpriteState.pressedSprite;
						num = 1437039083;
						continue;
					case 17:
						if (unityEvent != null)
						{
							unityEvent.Invoke();
							num = 1437039080;
							continue;
						}
						return;
					case 9:
						MGKFSQAMxOCfCESIUMRTldtbNhJC(color, P_1);
						num = 1437039087;
						continue;
					case 5:
						if (_allowSendingEvents)
						{
							_transitionArgs.dhodbseVbYqPVvdUgNSOeWdaMYFi(this, P_0, P_1 ? 0f : _transitionColorTint.fadeDuration);
							hierarchyInteractionStateTransitionHandlers.ExecuteOnAll(_transitionArgs);
							if (_onInteractionStateTransition != null)
							{
								_onInteractionStateTransition.Invoke(_transitionArgs);
								num = 1437039098;
								continue;
							}
							goto case 17;
						}
						return;
					case 0:
						text = _transitionAnimationTriggers.pressedTrigger;
						num = 1437039079;
						continue;
					case 10:
						goto IL_0196;
					case 8:
					{
						int num2;
						if (!base.gameObject.activeInHierarchy)
						{
							num = 1437039086;
							num2 = num;
						}
						else
						{
							num = 1437039097;
							num2 = num;
						}
						continue;
					}
					case 12:
						unityEvent = _onInteractionStateChangedToPressed;
						num = 1437039099;
						continue;
					case 11:
						switch (P_0)
						{
						case InteractionState.Disabled:
							break;
						case InteractionState.Highlighted:
							goto IL_0196;
						default:
							goto IL_0214;
						case InteractionState.Normal:
							goto IL_021e;
						case InteractionState.Pressed:
							goto IL_0281;
						}
						goto case 21;
					case 2:
						goto IL_021e;
					case 4:
						if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
						{
							RjthIHqdtMwYHwNCgrsiQiVCbrog(sprite);
							num = 1437039096;
							continue;
						}
						goto case 19;
					case 15:
						color = Color.black;
						sprite = null;
						text = string.Empty;
						unityEvent = null;
						num = 1437039099;
						continue;
					case 6:
						goto IL_0281;
					case 13:
						num = 1437039076;
						continue;
					case 1:
						num = 1437039099;
						continue;
					case 18:
						if (flag)
						{
							MGKFSQAMxOCfCESIUMRTldtbNhJC(color * _transitionColorTint.colorMultiplier, P_1);
							num = 1437039087;
							continue;
						}
						goto case 9;
					case 16:
						flag = (_transitionType & TransitionTypeFlags.ColorTint) != 0;
						if (!flag)
						{
							color = Color.white;
							num = 1437039077;
							continue;
						}
						goto case 14;
					case 3:
						return;
						IL_0281:
						color = _transitionColorTint.pressedColor;
						num = 1437039084;
						continue;
						IL_021e:
						color = _transitionColorTint.normalColor;
						sprite = null;
						text = _transitionAnimationTriggers.normalTrigger;
						unityEvent = _onInteractionStateChangedToNormal;
						num = 1437039099;
						continue;
						IL_0214:
						num = 1437039078;
						continue;
						IL_0196:
						color = _transitionColorTint.highlightedColor;
						sprite = _transitionSpriteState.highlightedSprite;
						text = _transitionAnimationTriggers.highlightedTrigger;
						unityEvent = _onInteractionStateChangedToHighlighted;
						num = 1437039082;
						continue;
					}
					break;
				}
			}
		}

		private void MGKFSQAMxOCfCESIUMRTldtbNhJC(Color P_0, bool P_1)
		{
			if (_targetGraphic == null)
			{
				return;
			}
			while (true)
			{
				_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, ignoreTimeScale: true, useAlpha: true);
				int num = -155024681;
				while (true)
				{
					switch (num ^ -155024681)
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
					num = -155024682;
				}
			}
		}

		private void RjthIHqdtMwYHwNCgrsiQiVCbrog(Sprite P_0)
		{
			if (image == null)
			{
				while (true)
				{
					switch (0x3B0E0574 ^ 0x3B0E0576)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			image.overrideSprite = P_0;
		}

		private void EMVJCmXWIVhOCFPWBBGqYLMZRMm(string P_0)
		{
			if ((_transitionType & TransitionTypeFlags.Animation) == 0 || animator == null)
			{
				return;
			}
			while (true)
			{
				int num = 2094422658;
				while (true)
				{
					switch (num ^ 0x7CD65A83)
					{
					case 0:
						break;
					case 1:
					{
						int num3;
						if (UnityTools.IsActiveAndEnabled(animator))
						{
							num = 2094422660;
							num3 = num;
						}
						else
						{
							num = 2094422656;
							num3 = num;
						}
						continue;
					}
					case 5:
						animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
						num = 2094422663;
						continue;
					case 3:
						return;
					case 2:
						animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
						animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
						num = 2094422661;
						continue;
					case 6:
						animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
						num = 2094422662;
						continue;
					case 7:
					{
						if (animator.runtimeAnimatorController == null)
						{
							return;
						}
						int num2;
						if (string.IsNullOrEmpty(P_0))
						{
							num = 2094422656;
							num2 = num;
						}
						else
						{
							num = 2094422657;
							num2 = num;
						}
						continue;
					}
					default:
						animator.SetTrigger(P_0);
						return;
					}
					break;
				}
			}
		}

		private void xFRbkPhHuGXRyWLYlLZgacHeUGUi(bool P_0)
		{
			InteractionState interactionState = _interactionState;
			if (pmYjhUyltIKROfKAKRLTAORpQYO() && !IsInteractable())
			{
				while (true)
				{
					int num = -854534733;
					while (true)
					{
						switch (num ^ -854534734)
						{
						case 2:
							break;
						case 1:
							interactionState = InteractionState.Disabled;
							num = -854534734;
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
			IONEiCIvsiVsXkmUQKvSSaXNlMkE(interactionState, P_0);
		}

		public bool IsInteractable()
		{
			if (_groupsAllowInteraction)
			{
				return _interactable;
			}
			return false;
		}

		internal virtual bool EfomNIIerZfdReJWaymsEQFbGDuv()
		{
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				return false;
			}
			if (IflsmAOKUdJKTpCZjpeDsuqZbjM)
			{
				return deteGKFsUpKVtiobsxDnfbVWHkL;
			}
			return false;
		}

		internal void vpbJzwkSvsfcXUnwDyeDqyAFmab(BaseEventData P_0)
		{
			if (pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				if (!IsInteractable())
				{
					goto IL_0010;
				}
				goto IL_0054;
			}
			return;
			IL_0054:
			InteractionState interactionState = uemUVSvfXRRPZnVqIeLbhIHOUoc(P_0);
			int num = -1806540834;
			goto IL_0015;
			IL_0010:
			num = -1806540836;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -1806540833)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					return;
				case 2:
					xFRbkPhHuGXRyWLYlLZgacHeUGUi(false);
					num = -1806540837;
					continue;
				case 6:
					goto IL_0054;
				case 1:
					if (interactionState == _interactionState)
					{
						return;
					}
					goto case 0;
				case 0:
					MUoEchOXZPsMEOROKtaGiEoDBMP(interactionState);
					num = -1806540835;
					continue;
				case 4:
					return;
				}
				break;
			}
			goto IL_0010;
		}

		internal virtual bool NwAEhJMhIkbNQQjjHtkiYeNJUED(GameObject P_0)
		{
			return base.gameObject == P_0;
		}

		private bool RHAkgaYHjJlrwItZkPCbgFgxslK(BaseEventData P_0)
		{
			bool flag = P_0 is PointerEventData;
			return RHAkgaYHjJlrwItZkPCbgFgxslK(flag, flag ? (P_0 as PointerEventData).pointerPress : null);
		}

		private bool RHAkgaYHjJlrwItZkPCbgFgxslK(bool P_0, GameObject P_1)
		{
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				return false;
			}
			if (EfomNIIerZfdReJWaymsEQFbGDuv())
			{
				return false;
			}
			bool flag = false;
			while (true)
			{
				int num = 1980635898;
				while (true)
				{
					switch (num ^ 0x760E1AF8)
					{
					case 0:
						break;
					case 2:
						if (P_0)
						{
							flag |= (deteGKFsUpKVtiobsxDnfbVWHkL && !IflsmAOKUdJKTpCZjpeDsuqZbjM && NwAEhJMhIkbNQQjjHtkiYeNJUED(P_1)) || (!deteGKFsUpKVtiobsxDnfbVWHkL && IflsmAOKUdJKTpCZjpeDsuqZbjM && NwAEhJMhIkbNQQjjHtkiYeNJUED(P_1)) || (!deteGKFsUpKVtiobsxDnfbVWHkL && IflsmAOKUdJKTpCZjpeDsuqZbjM && P_1 == null);
							num = 1980635899;
							continue;
						}
						goto case 1;
					case 1:
						flag |= IflsmAOKUdJKTpCZjpeDsuqZbjM;
						num = 1980635899;
						continue;
					default:
						return flag;
					}
					break;
				}
			}
		}

		private InteractionState uemUVSvfXRRPZnVqIeLbhIHOUoc(BaseEventData P_0)
		{
			if (EfomNIIerZfdReJWaymsEQFbGDuv())
			{
				return InteractionState.Pressed;
			}
			if (RHAkgaYHjJlrwItZkPCbgFgxslK(P_0))
			{
				goto IL_0015;
			}
			InteractionState result = InteractionState.Normal;
			int num = -1797475502;
			goto IL_001a;
			IL_001a:
			switch (num ^ -1797475504)
			{
			case 0:
				break;
			case 1:
				return InteractionState.Highlighted;
			default:
				return result;
			}
			goto IL_0015;
			IL_0015:
			num = -1797475503;
			goto IL_001a;
		}

		private bool MUoEchOXZPsMEOROKtaGiEoDBMP(InteractionState P_0)
		{
			if (_interactionState == P_0)
			{
				goto IL_0009;
			}
			_interactionState = P_0;
			int num = -1548052583;
			goto IL_000e;
			IL_000e:
			switch (num ^ -1548052583)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				VSRPydPzlEkkqKBjRDmYtUcfeiO();
				return true;
			}
			goto IL_0009;
			IL_0009:
			num = -1548052584;
			goto IL_000e;
		}

		private void VSRPydPzlEkkqKBjRDmYtUcfeiO()
		{
			NJzYnypRVchLSTBMHzWIURqgvPf();
		}

		private void NJzYnypRVchLSTBMHzWIURqgvPf()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			while (_hideWhenIdle)
			{
				while (true)
				{
					IL_003a:
					KEpqQGGfOeHyBrmOlKJIMDckKQh(_interactionState == InteractionState.Pressed, false);
					int num = 1879334435;
					while (true)
					{
						switch (num ^ 0x70045E22)
						{
						case 0:
							num = 1879334433;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							goto IL_003a;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void KEpqQGGfOeHyBrmOlKJIMDckKQh(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				goto IL_000c;
			}
			goto IL_0061;
			IL_0061:
			_visible = P_0;
			_varWatch_visible = P_0;
			int num;
			int num2;
			if (!_allowSendingEvents)
			{
				num = -164910561;
				num2 = num;
			}
			else
			{
				num = -164910563;
				num2 = num;
			}
			goto IL_0011;
			IL_000c:
			num = -164910568;
			goto IL_0011;
			IL_0011:
			while (true)
			{
				switch (num ^ -164910564)
				{
				case 2:
					break;
				default:
					return;
				case 4:
					return;
				case 1:
					hierarchyVisibilityChangedHandlers.ExecuteOnAll(P_0);
					if (_onVisibilityChanged != null)
					{
						_onVisibilityChanged.Invoke(P_0);
						num = -164910561;
						continue;
					}
					return;
				case 0:
					goto IL_0061;
				case 3:
					return;
				}
				break;
			}
			goto IL_000c;
		}

		private void mCfqjvKuqejioobvUrFBzcZtvoG()
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
				KEpqQGGfOeHyBrmOlKJIMDckKQh(_visible, true);
				NJzYnypRVchLSTBMHzWIURqgvPf();
			}
			iioftihTwbmXdSIcRBzaWOcAnVk();
			if (!_allowSendingEvents)
			{
				return;
			}
			while (true)
			{
				int num = 523685990;
				while (true)
				{
					switch (num ^ 0x1F36D067)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						hierarchyVisibilityChangedHandlers.ExecuteOnAll(_visible);
						if (_onVisibilityChanged != null)
						{
							goto IL_00a0;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_00a0:
					_onVisibilityChanged.Invoke(_visible);
					num = 523685991;
				}
			}
		}

		private void uIcmosSkKSAtGFldAPtVCIzcQLub()
		{
			if (_varWatch_visible == _visible)
			{
				return;
			}
			_varWatch_visible = _visible;
			if (!_allowSendingEvents)
			{
				return;
			}
			while (true)
			{
				int num = -483224947;
				while (true)
				{
					switch (num ^ -483224948)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (_onVisibilityChanged != null)
						{
							goto IL_0048;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_0048:
					hierarchyVisibilityChangedHandlers.ExecuteOnAll(_visible);
					_onVisibilityChanged.Invoke(_visible);
					num = -483224948;
				}
			}
		}

		private void NPOFSRfAiJHJstoMPmTkHgTRYCc()
		{
			uIcmosSkKSAtGFldAPtVCIzcQLub();
			NJzYnypRVchLSTBMHzWIURqgvPf();
			while (true)
			{
				int num = -1426836650;
				while (true)
				{
					switch (num ^ -1426836649)
					{
					case 2:
						break;
					case 1:
					{
						int num2;
						if (!Application.isPlaying)
						{
							num = -1426836649;
							num2 = num;
						}
						else
						{
							num = -1426836652;
							num2 = num;
						}
						continue;
					}
					case 0:
						xFRbkPhHuGXRyWLYlLZgacHeUGUi(true);
						return;
					default:
						xFRbkPhHuGXRyWLYlLZgacHeUGUi(false);
						return;
					}
					break;
				}
			}
		}

		private void iioftihTwbmXdSIcRBzaWOcAnVk()
		{
			hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
			hierarchyInteractionStateTransitionHandlers.GetHandlers(base.transform);
		}

		internal virtual void OnPointerDown(PointerEventData eventData)
		{
			if (jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerDown))
			{
				deteGKFsUpKVtiobsxDnfbVWHkL = true;
				vpbJzwkSvsfcXUnwDyeDqyAFmab(eventData);
			}
		}

		internal virtual void OnPointerUp(PointerEventData eventData)
		{
			if (!jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerUp))
			{
				while (true)
				{
					switch (0x3ADE0BC2 ^ 0x3ADE0BC3)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			deteGKFsUpKVtiobsxDnfbVWHkL = false;
			vpbJzwkSvsfcXUnwDyeDqyAFmab(eventData);
		}

		internal virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (!jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerEnter))
			{
				goto IL_0014;
			}
			goto IL_003e;
			IL_0014:
			int num = 1918584148;
			goto IL_0019;
			IL_0019:
			switch (num ^ 0x725B4555)
			{
			case 0:
				break;
			case 1:
				return;
			case 2:
				goto IL_003e;
			default:
				vpbJzwkSvsfcXUnwDyeDqyAFmab(eventData);
				return;
			}
			goto IL_0014;
			IL_003e:
			IflsmAOKUdJKTpCZjpeDsuqZbjM = true;
			num = 1918584150;
			goto IL_0019;
		}

		internal virtual void OnPointerExit(PointerEventData eventData)
		{
			if (!jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerExit))
			{
				return;
			}
			while (true)
			{
				IflsmAOKUdJKTpCZjpeDsuqZbjM = false;
				vpbJzwkSvsfcXUnwDyeDqyAFmab(eventData);
				int num = -559097167;
				while (true)
				{
					switch (num ^ -559097167)
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
					num = -559097168;
				}
			}
		}

		internal virtual void OnBeginDrag(PointerEventData eventData)
		{
			jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, _allowedMouseButtons, EventTriggerType.BeginDrag);
		}

		internal virtual void OnDrag(PointerEventData eventData)
		{
			jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, _allowedMouseButtons, EventTriggerType.Drag);
		}

		internal virtual void OnEndDrag(PointerEventData eventData)
		{
			jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, _allowedMouseButtons, EventTriggerType.EndDrag);
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

		internal static bool PYUTplsvvKimYgNZKiMZNosbrtO(int P_0)
		{
			if (P_0 == int.MinValue)
			{
				goto IL_0008;
			}
			int num = default(int);
			int num2;
			if (MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
			{
				num = nXmDrAgQYEMTVswuBxAzYZXiaij(P_0);
				num2 = 1670558264;
				goto IL_000d;
			}
			if (LVbAAmZsiNVWVEZvWStcjqdZghy(P_0) && Input.mousePresent)
			{
				int num3 = yOgfbgbdvVGbAHUtcaxVhMHZIqW(P_0);
				if (num3 >= 0)
				{
					return Input.GetMouseButton(num3);
				}
			}
			return false;
			IL_0008:
			num2 = 1670558265;
			goto IL_000d;
			IL_000d:
			Touch touch = default(Touch);
			while (true)
			{
				switch (num2 ^ 0x6392B23A)
				{
				case 0:
					break;
				case 3:
					return false;
				case 2:
					if (num < 0)
					{
						return false;
					}
					touch = Input.GetTouch(num);
					if (touch.phase != TouchPhase.Ended)
					{
						goto IL_0059;
					}
					return false;
				default:
					return touch.phase != TouchPhase.Canceled;
				}
				break;
				IL_0059:
				num2 = 1670558267;
			}
			goto IL_0008;
		}

		internal static Vector3 cpmXsthbnFhxHDTcLoXFmpmGBNKS(int P_0)
		{
			if (MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
			{
				int num2 = default(int);
				while (true)
				{
					int num = -2019109625;
					while (true)
					{
						switch (num ^ -2019109626)
						{
						case 2:
							break;
						case 1:
							num2 = nXmDrAgQYEMTVswuBxAzYZXiaij(P_0);
							num = -2019109626;
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
				if (num2 >= 0 && Input.touchCount > num2)
				{
					return Input.touches[num2].position;
				}
			}
			else if (LVbAAmZsiNVWVEZvWStcjqdZghy(P_0) && Input.mousePresent)
			{
				return Input.mousePosition;
			}
			return Vector3.zero;
		}

		internal static bool MJGZhOuZtDJJBYrLvPhBeVPeNzW(int P_0)
		{
			return P_0 >= 0;
		}

		internal static bool LVbAAmZsiNVWVEZvWStcjqdZghy(int P_0)
		{
			if (P_0 != -1 && P_0 != -3)
			{
				return P_0 == -2;
			}
			return true;
		}

		private static int nXmDrAgQYEMTVswuBxAzYZXiaij(int P_0)
		{
			if (!MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_0))
			{
				return -1;
			}
			int touchCount = Input.touchCount;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= touchCount)
				{
					num2 = 99191604;
					num3 = num2;
				}
				else
				{
					num2 = 99191607;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x5E98B35)
					{
					case 0:
						num2 = 99191607;
						continue;
					case 2:
						if (Input.GetTouch(num).fingerId == P_0)
						{
							return num;
						}
						num++;
						num2 = 99191606;
						continue;
					case 3:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		internal static bool jlMLntvkuERbFtpXYbjRXNhFHnM(MouseButtonFlags P_0, int P_1)
		{
			if (LVbAAmZsiNVWVEZvWStcjqdZghy(P_1))
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
			if (MJGZhOuZtDJJBYrLvPhBeVPeNzW(P_1))
			{
				return true;
			}
			if (RwLMUlkaXEMWssRQFXNfcXyWKxN(P_0, P_1))
			{
				return true;
			}
			return false;
		}

		private static bool RwLMUlkaXEMWssRQFXNfcXyWKxN(MouseButtonFlags P_0, int P_1)
		{
			while (true)
			{
				int num = -1929028547;
				while (true)
				{
					switch (num ^ -1929028548)
					{
					case 2:
						break;
					case 1:
						switch (P_1)
						{
						default:
							goto IL_0039;
						case -1:
							break;
						case -2:
							return (P_0 & MouseButtonFlags.RightButton) != 0;
						case -3:
							return (P_0 & MouseButtonFlags.MiddleButton) != 0;
						}
						goto default;
					default:
						return (P_0 & MouseButtonFlags.LeftButton) != 0;
					case 3:
						return false;
					}
					break;
					IL_0039:
					num = -1929028545;
				}
			}
		}

		private static int yOgfbgbdvVGbAHUtcaxVhMHZIqW(int P_0)
		{
			if (!LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
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

		internal static bool uvgPsLARFwGrvuIJCgcCjshzWDCu(MouseButtonFlags P_0, out int P_1)
		{
			int num2 = default(int);
			while (true)
			{
				int num = 1824664543;
				while (true)
				{
					switch (num ^ 0x6CC22BDB)
					{
					case 3:
						break;
					case 4:
						num2 = 0;
						num = 1824664539;
						continue;
					case 0:
						num = 1824664538;
						continue;
					case 2:
						if (((uint)P_0 & (uint)(1 << num2)) != 0 && Input.GetMouseButton(num2))
						{
							P_1 = (num2 + 1) * -1;
							return true;
						}
						num2++;
						num = 1824664538;
						continue;
					default:
						if (num2 >= 3)
						{
							P_1 = int.MinValue;
							return false;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		internal static bool jlMLntvkuERbFtpXYbjRXNhFHnM(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
		{
			if (LVbAAmZsiNVWVEZvWStcjqdZghy(P_0))
			{
				if (P_2 == EventTriggerType.PointerEnter)
				{
					goto IL_002d;
				}
				if (P_2 == EventTriggerType.PointerExit)
				{
					goto IL_000f;
				}
			}
			goto IL_003c;
			IL_002d:
			int num;
			if (P_1 != MouseButtonFlags.None)
			{
				P_1 |= MouseButtonFlags.LeftButton;
				num = -1089612452;
				goto IL_0014;
			}
			goto IL_003c;
			IL_003c:
			return jlMLntvkuERbFtpXYbjRXNhFHnM(P_1, P_0);
			IL_000f:
			num = -1089612449;
			goto IL_0014;
			IL_0014:
			switch (num ^ -1089612451)
			{
			case 0:
				break;
			case 2:
				goto IL_002d;
			default:
				goto IL_003c;
			}
			goto IL_000f;
		}

		internal static bool oZwvzbhTHFLSrWQmffrxbbIJDii(MouseButtonFlags P_0)
		{
			int num;
			return uvgPsLARFwGrvuIJCgcCjshzWDCu(P_0, out num);
		}

		[CompilerGenerated]
		private void XBExmunnaUhRgkCjLHZNutGIPOIb(bool P_0)
		{
			_allowSendingEvents = P_0;
		}

		[CompilerGenerated]
		private static void HtvvLxxoIrDTZDtgmCDMHuTeMVj(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
		{
			P_0.OnInteractionStateTransition(P_1);
		}
	}
}
