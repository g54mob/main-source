using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	public class Tooltip3DUIView : MonoBehaviour
	{
		private ITooltipProvider _provider;

		private bool _isContentDirty;

		public List<Renderer> ignoreObjectsForBounds;

		private IEnumerable<GameObject> _ignoreObjectsForHover;

		[SerializeField]
		private TextBlock3DUIView _closeMessage;

		[SerializeField]
		private Container3DUIView _container;

		[SerializeField]
		private Transform _offsetTransform;

		private List<Collider> _lockableColliderCache;

		private bool _hasInteractableElements;

		private float _timeTillLockIn;

		[SerializeField]
		private Countdown3DUIView _lockVisualCountdown;

		[SerializeField]
		private GameObject _unlockedIcon;

		[SerializeField]
		private GameObject _lockedIcon;

		[SerializeField]
		private BoxCollider _lockVisualCollider;

		[SerializeField]
		private MaterialOffsetter _borderVisual;

		private static readonly WeakCollection<Tooltip3DUIView> _openTooltips;

		private bool _isLayoutDirty;

		private GameObject _buttonObj;

		private static string _closeTooltipPromptTextWrapper;

		private static string _closeTooltipPromptText;

		private TextBlock3DUIView.SectionFadeEffect _rightClickToCloseEffect;

		[SerializeField]
		private ContentBlockLayout _contentBlockLayout;

		public NineSliceMeshScaler borderScaler;

		public List<RelativeScaler3DUIView> backgrounds;

		private Vector3 _colliderOverlapPadding;

		private BoxCollider _backgroundCollider;

		public static bool ShowRightClickToCloseMessage { get; set; }

		public static bool ShouldLockBeActive { get; set; }

		public ITooltipProvider Provider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public GameObject ProviderObject => null;

		public TooltipData Data { get; private set; }

		public bool IsLocked { get; private set; }

		public bool IsTimeLocked { get; private set; }

		public static int OverlapTolerance => 0;

		public BoxCollider BackgroundCollider => null;

		public static event EventHandler OnTooltipShown
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

		public static event EventHandler OnTooltipClosed
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

		public static Tooltip3DUIView CreateNestedTooltip(Transform parent, ITooltipProvider provider)
		{
			return null;
		}

		private Bounds GetBounds()
		{
			return default(Bounds);
		}

		public void MarkLayoutDirty()
		{
		}

		public void MarkDirty()
		{
		}

		private void Tooltip3DUIView_TooltipChanged(object sender, EventArgs e)
		{
		}

		private void Update()
		{
		}

		private void UpdateTooltipInput()
		{
		}

		private void UpdateCloseMessageEffect()
		{
		}

		public void Show(TooltipData data, Vector3 source)
		{
		}

		private void UpdateLockedState()
		{
		}

		public bool IsRootTooltip()
		{
			return false;
		}

		public bool IsNestedTooltip()
		{
			return false;
		}

		private void UpdateLockableCache()
		{
		}

		public void ForceLock()
		{
		}

		public void Lock()
		{
		}

		public void Unlock()
		{
		}

		private bool IsInstantLock()
		{
			return false;
		}

		private void UpdateLockVisual()
		{
		}

		private void HideLockingVisuals()
		{
		}

		private void UpdateLockTimer()
		{
		}

		private void UpdatePositionAndSize(Vector3 source)
		{
		}

		private void TryMarkCodexLinkAsVisited()
		{
		}

		public static int GetNumberOfOpenTooltips()
		{
			return 0;
		}

		public void Hide()
		{
		}

		private void UpdateData(TooltipData data)
		{
		}

		private void UpdateButton(GameObject buttonPrefab, Dictionary<string, Action> buttonActions)
		{
		}

		private void Awake()
		{
		}

		private void OnLanguageChanged(object sender, EventArgs eventArgs)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnContentBlockLayoutOnLayoutChanged(object sender, EventArgs eventArgs)
		{
		}

		private void UpdateBlocks()
		{
		}

		public void UpdateLayout()
		{
		}

		private IEnumerable<Renderer> GetBoundsIgnoredRenderers()
		{
			return null;
		}

		private void UpdatePosition(Vector3 source, TooltipAlignment alignment, bool useFallback = true)
		{
		}

		private void UpdateBackgroundCollider()
		{
		}

		private void UpdateBackers()
		{
		}

		private void OnEnable()
		{
		}
	}
}
