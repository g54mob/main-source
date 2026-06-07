using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI;
using I18n;
using Pixeye.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Gh.Tk
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Collider))]
	public abstract class BaseInteractable3DUIView : MonoBehaviour, IInteractableUI, ITooltipProvider, IDevCommentaryParent
	{
		protected List<BaseStateVisualizer3D> _visualizers;

		private Func<TooltipData> _tooltipLazy;

		public TooltipData tooltip;

		[Header("Tooltips")]
		public string codexTooltip;

		public string TooltipHeaderKey;

		public string TooltipBodyKey;

		public Vector3 TooltipPadding;

		public TooltipAlignment TooltipPosition;

		public TooltipWidth maxTooltipWidth;

		public Func<string> TooltipBodyStringProvider;

		[Header("Interactions")]
		public bool closeTooltipOnClick;

		public bool openTooltipOnClick;

		[SerializeField]
		protected string playerProfileUnlockKey;

		public bool proxyFirstLinkedHoverTooltip;

		public List<BaseInteractable3DUIView> linkedHover;

		[Header("Animations")]
		public bool resetStateOnEnable;

		public bool triggerClickAnimationWhenDisabled;

		protected static readonly int _isClickedTriggerHash;

		[Header("Sockets")]
		[Tooltip("Socket names must be unique.")]
		[SerializeField]
		private List<GameObject> _sockets;

		[Header("Sounds")]
		public string invalidClickSound;

		public string blockedClickSound;

		public string lockedIdleSound;

		public string lockedClickSound;

		public string hoverSound;

		public string selectedHoverSoundEvent;

		public bool stopHoverSoundOnUnhover;

		public string stopHoverSound;

		public string clickSound;

		public string selectedClickSound;

		[Header("Dev Commentary")]
		public DevCommentaryMarkerMonoBehaviour devCommentaryTransform;

		public TextMeshProI18n label;

		private bool _interactionSuspended;

		private ILookup<string, DOTweenAnimation> _stateTweens;

		[SerializeField]
		private Transform _hideHelper;

		protected static readonly int _isHoveredHash;

		protected static readonly int _isPressedHash;

		protected static readonly int _isSelectedHash;

		protected static readonly int _isEnabledHash;

		protected static readonly int _isBlockedHash;

		protected static readonly int _isLockedHash;

		private bool _isEnabled;

		private bool _isVisible;

		public Func<bool> isBlockedCheck;

		public UnityEvent buttonClickedEvent;

		protected bool _isUnlocking;

		public Func<bool> isSelectedCheck;

		public Func<bool> isEnabledCheck;

		public Func<bool> isVisibleCheck;

		public string info;

		public Dictionary<string, object> data;

		private Animator[] _animators;

		private static readonly Action<Animator, int, object> SetBoolValue;

		private static readonly Action<Animator, int, object> SetIntegerValue;

		private static readonly Action<Animator, int, object> SetTriggerValue;

		private readonly Dictionary<int, Dictionary<AnimatorControllerParameterType, HashSet<int>>> _animatorHashes;

		[SerializeField]
		protected Transform _nudgeRoot;

		protected Tween _nudgeTween;

		protected bool _isSelected;

		protected bool _isPressed;

		protected bool _isHovered;

		[Foldout("Texture Blend", true)]
		public Texture blendTextureA;

		public Texture blendTextureB;

		public Renderer blendTextureRenderer;

		[Tooltip("Duration in Seconds")]
		public float blendChangeDuration;

		[Range(0f, 1f)]
		public float defaultBlendState;

		[Range(0f, 1f)]
		public float selectedBlendState;

		[Range(0f, 1f)]
		public float hoverBlendState;

		private Shader _textureBlendShader;

		private Tween _bleendStateTween;

		[Foldout("Object Toggler", true)]
		public GameObject selectedObject;

		public GameObject[] lockedObjects;

		public GameObject defaultObject;

		public GameObject[] unlockedObjects;

		public GameObject[] lockedClickObjects;

		public GameObject[] lockedIdleObjects;

		protected bool _currentlyPlayingLockedSound;

		[Foldout("Colour Changer", true)]
		public bool changeMaterialColour;

		[SerializeField]
		protected Renderer _recolourRenderer;

		public Color defaultColor;

		public Color defaultEmission;

		public Color hoverColor;

		public Color hoverEmission;

		public Color selectedColor;

		public Color selectedEmission;

		public Color disabledColor;

		public Color disabledEmission;

		[Foldout("Colour Changer", false)]
		[Tooltip("Duration in Seconds")]
		public float colorChangeDuration;

		private Tween _colorTween;

		private MaterialPropertyBlock _mpBlock;

		private static readonly int _shaderKey_Color;

		private Color _tweenTargetColor;

		private Tween _emissionTween;

		private static readonly int _shaderKey_EmissionColor;

		[field: Header("New Visualizers")]
		[field: SerializeField]
		public ScalingVisualizer ScalingVisualizer { get; private set; }

		[field: SerializeField]
		public ObjectVisualizer ObjectVisualizer { get; private set; }

		[field: SerializeField]
		public List<MaterialColorVisualizer> MaterialColorVisualizers { get; private set; }

		[field: SerializeField]
		public List<SpriteColorVisualizer> SpriteColorVisualizers { get; private set; }

		[field: SerializeField]
		public List<TextColorVisualizer> TextColorVisualizers { get; private set; }

		public Func<TooltipData> TooltipLazy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DevCommentaryMarkerMonoBehaviour DevCommentaryMarker => null;

		public bool IsInteractionSuspended
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SkipTransitions { get; protected set; }

		public virtual bool IsHovered
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsPressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSelected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsVisible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual bool IsBlocked => false;

		public virtual bool IsLocked => false;

		public bool IsStateValid { get; protected set; }

		public Renderer RecolourRenderer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event EventHandler TooltipChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs<bool>> OnIsHoveredChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs<bool>> OnIsPressedChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<EventArgs<bool>> OnIsSelectedChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void UpdateStateVisualizers()
		{
		}

		private void InitVisualizers()
		{
		}

		private void CleanUpVisualizers()
		{
		}

		public void SetSocket(string name, GameObject obj)
		{
		}

		public GameObject GetSocket(string name)
		{
			return null;
		}

		private void CheckSocketsAreValid()
		{
		}

		protected virtual TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public void SetCodexTooltip(string codexId)
		{
		}

		public void OnTooltipChanged()
		{
		}

		private void UpdateOverflowTooltip(TextMeshProI18n tmpTextLabel)
		{
		}

		protected void UpdateOverflowTooltip(TextBlock3DUIView richTextLabel)
		{
		}

		protected void UpdateOverflowTooltip(IDisplaysText displaysText, TMP_Text tmpText)
		{
		}

		private void OnLabelChanged(object sender, EventArgs e)
		{
		}

		public virtual TooltipData GetTooltipData()
		{
			return null;
		}

		public virtual Vector3 GetTooltipPosition()
		{
			return default(Vector3);
		}

		protected virtual void OnInteractionSuspendedChanged()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnUIReset(object sender, EventArgs e)
		{
		}

		protected virtual void Start()
		{
		}

		private void OnFeatureUnlockStateChanged(object sender, EventArgs e)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void UpdateAnimatorValues()
		{
		}

		private void UpdateStateTweens()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected void OnValidate()
		{
		}

		private void OnUIStateChanged(object sender, EventArgs e)
		{
		}

		private void UpdateIsHovered()
		{
		}

		protected virtual void OnHoveredChanged()
		{
		}

		public virtual void OnHovering()
		{
		}

		protected virtual void UpdateIsPressed()
		{
		}

		protected virtual void OnSelectedChanged()
		{
		}

		protected virtual void OnVisibleChanged()
		{
		}

		public virtual void OnClicked()
		{
		}

		protected virtual void TriggerUnlocking()
		{
		}

		protected void PlayGlobalSound(string soundToPlay)
		{
		}

		protected void StopGlobalSound(string soundToStop)
		{
		}

		protected void PlaySound(string soundToPlay)
		{
		}

		protected void StopSound(string soundToStop)
		{
		}

		protected virtual void OnClickedInternal()
		{
		}

		protected void CloseTooltipAndPreventReopeningUntilNewMouseHover()
		{
		}

		protected void OpenTooltip()
		{
		}

		[ContextMenu("Check State")]
		public virtual void CheckState()
		{
		}

		public void CheckStateWithoutTransition()
		{
		}

		public void InvalidateState()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		protected void UpdateStateVisuals()
		{
		}

		public void CheckState(object sender, EventArgs e)
		{
		}

		public void SetAnimatorValues(int parameterIdHash, bool value)
		{
		}

		public void SetAnimatorValues(int parameterIdHash, int value)
		{
		}

		protected void SetAnimatorTrigger(int parameterIdHash)
		{
		}

		public void ApplyOnAnimatorsWithParameter(int parameterIdHash, AnimatorControllerParameterType type, object value, Action<Animator, int, object> onApply)
		{
		}

		public virtual void Nudge(bool withSound = true)
		{
		}

		protected void UpdateTextureBlendStates()
		{
		}

		public virtual void UpdateStateObjects()
		{
		}

		protected virtual void OnDisable()
		{
		}

		private MaterialPropertyBlock GetRecolourMPB()
		{
			return null;
		}

		protected void SetColor(Color color, bool skipTransition = false)
		{
		}

		protected void SetEmission(Color color, bool skipTransition = false)
		{
		}

		protected virtual void UpdateColourChanger()
		{
		}

		public void OpenContextMenu(IEnumerable<ContextMenuItem> items, TooltipAlignment alignment)
		{
		}
	}
}
