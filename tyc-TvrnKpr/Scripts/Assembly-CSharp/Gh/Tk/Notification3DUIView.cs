using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(ShowHideAnimation3DUIView))]
	public class Notification3DUIView : BaseInteractable3DUIView
	{
		public List<GameObject> styles;

		[SerializeField]
		private TextBlock3DUIView _titleText;

		[SerializeField]
		private BoxCollider _standardCollider;

		[SerializeField]
		private BoxCollider _extendedCollider;

		[SerializeField]
		private BoxCollider _checklistTabCollider;

		public Button3DUIView dismissButton;

		public GameObject pipContainer;

		public float pipContainerLength;

		public float pipSpacing;

		public List<GameObject> pipTemplates;

		public List<GameObject> _pips;

		public Material pipPositiveMaterial;

		public Material pipNegativeMaterial;

		public Material pipProgressMaterial;

		private float _previousPipValue;

		private UINotificationData _uiNotificationData;

		private UIController.UINotificationVisualData _visualData;

		[SerializeField]
		private Container3DUIView _checklistParent;

		[SerializeField]
		private GameObject _checklistItemPrefab;

		[SerializeField]
		private GameObject _buttonChecklistItemPrefab;

		private List<NotificationChecklistItem3DUIView> _checklistItems;

		[SerializeField]
		private Transform _checklistBackground;

		[SerializeField]
		private Vector2 _checklistBackgroundPadding;

		[SerializeField]
		private GameObject _collapsedChecklistVisual;

		[SerializeField]
		private Transform _iconSocket;

		[SerializeField]
		private Transform _tabSocket;

		private GameObject _iconInstance;

		private List<GameObject> _tabButtons;

		[SerializeField]
		private Button3DUIView _iconGroupButton;

		public List<GameObject> iconPrefabs;

		private string _currentStyle;

		public Countdown3DUIView _countdownVisual;

		[SerializeField]
		private BasicAnimationEventObserver _animationObserver;

		private NotificationArea3DUIView _notificationArea;

		private SimpleSoundPlayer[] _simpleSoundPlayers;

		private bool _hasStarted;

		[SerializeField]
		private GameObject _otherGroupsButtonPrefab;

		private GameObject _otherGroupsButton;

		[SerializeField]
		private GameObject _tabPlaceholderPrefab;

		private List<GameObject> _tabPlaceholders;

		private int _maxGroupTabs;

		[SerializeField]
		private TextSizeGroup _textSizeGroup;

		[SerializeField]
		private TextSizeGroup _textSizeGroupForButtons;

		[SerializeField]
		private GameObject _patronGroupButtonPrefab;

		[SerializeField]
		private GameObject _patronListItemPrefab;

		private List<PatronCheckListItem3DUIView> _patronListItems;

		private int _activeGroupMemberIndex;

		private List<(UINotificationData data, UIController.UINotificationVisualData visualData)> _groupDatas;

		private new Tween _nudgeTween;

		private Tweener _positionTween;

		public BoxCollider ActiveCollider => null;

		public float CurrentHeight => 0f;

		public ShowHideAnimation3DUIView ShowHideAnimator { get; private set; }

		public string Id => null;

		public NotificationArea3DUIView NotificationArea
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsChecklistOpen => false;

		public static event EventHandler NotificationDestroyed
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

		public static event EventHandler NotificationIsDirty
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

		public event EventHandler ClosedEvent
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

		public event EventHandler OpenedEvent
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

		private void OnNotificationAreaShowHide(object sender, EventArgs e)
		{
		}

		protected override void Awake()
		{
		}

		private void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void UpdateSoundPlayers()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnEnable()
		{
		}

		private static string GetTitleKey(UINotificationData data, UIController.UINotificationVisualData visualData)
		{
			return null;
		}

		private void OnDialogClosedOpenChecklist(object sender, EventArgs e)
		{
		}

		private void UpdateNotification()
		{
		}

		private void Update()
		{
		}

		private void UpdateCountdownVisual()
		{
		}

		private string GetIconName()
		{
			return null;
		}

		private void UpdateIcon()
		{
		}

		private void UpdateGroupTracker()
		{
		}

		private void UpdateActiveTabButton()
		{
		}

		private GameObject GetIconPrefab(string iconName)
		{
			return null;
		}

		private void UpdateChecklistItems()
		{
		}

		private void UpdateChecklistVisuals()
		{
		}

		private GameObject GetPip(int index, float pipScale)
		{
			return null;
		}

		private void UpdatePips()
		{
		}

		private void UpdatePatronPawns()
		{
		}

		public override void OnClicked()
		{
		}

		private void ShowChecklist(bool isShowing, bool resizeNotify = true)
		{
		}

		private void UpdateCollapsedState()
		{
		}

		private void SetGroupUINotificationDatas(List<(UINotificationData, UIController.UINotificationVisualData)> uiNotificationDatas)
		{
		}

		private void SetActiveGroupMember(int index)
		{
		}

		public void AddNotificationToGroup(UINotificationData uiNotificationData, UIController.UINotificationVisualData visualData)
		{
		}

		private void ClearIcon()
		{
		}

		public void RemoveNotificationFromGroup(string id)
		{
		}

		public void UpdateNotificationInGroup(UINotificationData uiNotificationData, UIController.UINotificationVisualData visualData, string dataId)
		{
		}

		public string GetGroupId()
		{
			return null;
		}

		public void SetUINotificationData(UINotificationData uiNotificationData, UIController.UINotificationVisualData visualData)
		{
		}

		public void SetPosition(Vector3 localPosition)
		{
		}

		public void OnDismissNotification()
		{
		}

		private void OnClosed(object sender, EventArgs e)
		{
		}

		private void OnOpened(object sender, EventArgs e)
		{
		}

		private void UpdateTextSize()
		{
		}

		public void Open(bool noAnimation = false)
		{
		}

		public void Close(bool noAnimation = false)
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		public int GetNotificationCount()
		{
			return 0;
		}
	}
}
