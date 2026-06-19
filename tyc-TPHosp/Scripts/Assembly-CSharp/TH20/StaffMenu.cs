using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.EventStaffHired;
using TH20.EventUnlockItem;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[Serializable]
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffMenu : AnimatedMenuBase, TH20.EventStaffHired.Interface, IGameEventCallback, TH20.EventUnlockItem.Interface
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class StaffMenuSettings
		{
			[Serializable]
			public class StaffTypeToggle
			{
				[SerializeField]
				public StaffDefinition.Type StaffType;

				[SerializeField]
				public PanelItemToggleButton AssignedButton;

				[SerializeField]
				public GameObject AssignedTabBacking;

				[SerializeField]
				public GameObject AssignedTabBackingAlternative;
			}

			[Serializable]
			[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
			public class ViewModeToggle
			{
				[SerializeField]
				public ViewModes ViewMode;

				[SerializeField]
				public GameObject RowPrefab;

				[SerializeField]
				public PanelItemToggleButton AssignedButton;

				[SerializeField]
				public TMP_Text StaffTypeText;

				[SerializeField]
				public RectTransform ColumnHeadersParent;

				[SerializeField]
				public Table Table;

				[SerializeField]
				public AnimationClip TabAnim;

				[SerializeField]
				public string TabAnimStateTrigger;

				[SerializeField]
				public TutorialButtonClickedMessage TutorialButtonClickedMessage;

				[InspectorHeader("Tween Destinations")]
				[SerializeField]
				public bool AllButtonEnabled;

				[SerializeField]
				public bool ShowViewFinder;

				[SerializeField]
				public float FinanceFooterAlpha;

				[SerializeField]
				public float PayRequestAlpha;

				[SerializeField]
				public float BarSizeDeltaX;

				[SerializeField]
				public float MaxBarSizeX;

				[SerializeField]
				public Vector2 PanelSizeDelta;

				[SerializeField]
				public Vector2 TabSelectionPosition;

				[NonSerialized]
				[HideInInspector]
				public int AnimHash;

				[NonSerialized]
				[HideInInspector]
				public int TriggerHash;
			}

			[Header("General")]
			[SerializeField]
			public float ViewFinderBorder;

			[SerializeField]
			public Animator TabAnimator;

			[SerializeField]
			public CanvasGroup FinanceCanvasGroup;

			[SerializeField]
			public CanvasGroup SatisfyPayGroup;

			[SerializeField]
			public CanvasGroup AllPayRiseGroup;

			[SerializeField]
			public DynamicButton AllButton;

			[SerializeField]
			public DynamicButton CloseButton;

			[SerializeField]
			public PanelItemRadioButtonsGroup FilterGroup;

			[SerializeField]
			public PanelItemToggleButton DefaultStaffToggle;

			[SerializeField]
			public RectTransform BarRectTransform;

			[SerializeField]
			public RectTransform PanelRectTransform;

			[SerializeField]
			public RectTransform TabSelectionRectTransform;

			[SerializeField]
			public RectTransform TitleRectTransform;

			[SerializeField]
			public RectTransform ViewFinderRectTransform;

			[SerializeField]
			public Sprite AllButtonDisabled;

			[SerializeField]
			public TMP_Text TitleText;

			[SerializeField]
			public List<StaffTypeToggle> StaffTypeToggles = new List<StaffTypeToggle>();

			[SerializeField]
			public List<ViewModeToggle> ViewModeToggles = new List<ViewModeToggle>();

			[SerializeField]
			public Sprite[] TypeSprites = new Sprite[4];

			[Header("Job Assignment")]
			[SerializeField]
			public int JobIconUnitSize = 50;

			[SerializeField]
			public GameObject JobIconPrefab;

			[SerializeField]
			public RectTransform JobsListContainerBackground;

			[SerializeField]
			public RectTransform JobsListContainer;

			[SerializeField]
			public DynamicButton JobPageLeftButton;

			[SerializeField]
			public DynamicButton JobPageRightButton;

			[SerializeField]
			public GameObject PageMarkerPrefab;

			[SerializeField]
			public RectTransform PageMarkerContainer;

			[SerializeField]
			public Color PageMarkerOffColour;

			[SerializeField]
			public Color PageMarkerOnColour;

			[SerializeField]
			public GameObject JobFilterButtons;

			[SerializeField]
			public DynamicButton JobFilterDiagnosisButton;

			[SerializeField]
			public ButtonAnimator JobFilterDiagnosisButtonAnimator;

			[SerializeField]
			public DynamicButton JobFilterTreatmentButton;

			[SerializeField]
			public ButtonAnimator JobFilterTreatmentButtonAnimator;

			[SerializeField]
			public DynamicButton JobFilterAllButton;

			[SerializeField]
			public ButtonAnimator JobFilterAllButtonAnimator;

			[SerializeField]
			public RoomFilter JobFilterDiagnosis;

			[SerializeField]
			public RoomFilter JobFilterTreatment;

			[SerializeField]
			public GameObject JobColumnBackgroundParent;

			[SerializeField]
			public GameObject JobColumnBackgroundPrefab;

			[SerializeField]
			public Color JobColumnBackgroundColor1;

			[SerializeField]
			public Color JobColumnBackgroundColor2;

			[SerializeField]
			public Color JobColumnInvalidColor;

			[SerializeField]
			public float JobColumnMaximumHeight;

			[SerializeField]
			public float JanitorTabSwapThreshold;

			[Header("Pay Review")]
			[SerializeField]
			public BarGraph SatisfactionBarGraph;

			[SerializeField]
			public ButtonAnimator SatisfyAllPayRequestsButton;

			[SerializeField]
			public PanelItemTrendIcon PaySatisfactionTrend;

			[SerializeField]
			public PanelItemValueViewer OtherOutgoingsText;

			[SerializeField]
			public PanelItemValueViewer YearlyWagesText;

			[SerializeField]
			public PanelItemValueViewer YearlyIncomeText;

			[SerializeField]
			public PanelItemValueViewer YearlyCashFlowText;

			[SerializeField]
			public PanelItemValueViewer SatisfyAllCostText;

			[SerializeField]
			public Sprite AcceptButtonSprite;

			[Header("All Pay Increase")]
			[SerializeField]
			public ButtonAnimator AllPayButton;

			[SerializeField]
			public TMP_Text AllPayButtonText;

			[SerializeField]
			public float AllPayRisePercentage = 0.01f;
		}

		public enum ViewModes
		{
			ViewModeNone = 0,
			ViewModeStaffList = 1,
			ViewModePayReview = 2,
			ViewModeJobAssignment = 3
		}

		private enum JobFilter
		{
			All = 0,
			Diagnosis = 1,
			Treatment = 2
		}

		[SerializeField]
		private StaffMenuData _data;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[InspectorHeader("Maintenance Icons")]
		[SerializeField]
		private Sprite _repairMachineIcon;

		[SerializeField]
		private Sprite _cleanToiletIcon;

		[SerializeField]
		private Sprite _stockMachineIcon;

		[SerializeField]
		private Sprite _waterPlantsIcon;

		[SerializeField]
		private Sprite _emptyBinsIcon;

		[SerializeField]
		private Sprite _sweepUpWasteIcon;

		[SerializeField]
		private Sprite _captureGhostIcon;

		[SerializeField]
		private Sprite _extinguishFireIcon;

		[SerializeField]
		private Sprite _upgradeMachineIcon;

		[SerializeField]
		private Sprite _vehicularIcon;

		private StaffMenuSettings _staffMenuSettings;

		public static int MaxJobIconsPerPage = 15;

		private bool _showViewFinder;

		private float _timeStamp;

		private float _titleWidth;

		private DynamicButton _satisfyAllDynamicButton;

		private CharacterEvents _characterEvents;

		private CharacterManager _characterManager;

		private Image _satisfyAllButtonImage;

		private Level _level;

		private LevelStatsDatabase _statsDatabase;

		private Staff _inspectedStaffMember;

		private StaffDefinition.Type _staffFilter = StaffDefinition.Type.None;

		private Table _table;

		private TMP_Text _currentStaffText;

		private ViewModes _viewMode;

		private StaffMenuSettings.ViewModeToggle _jobAssignmentPanel;

		private WorldState _worldState;

		private StaffMenuRowProvider _staffMenuRowProvider;

		private PanelItemRadioButtonsGroup _tabModeGroup;

		private bool _bShowingViewFinder;

		private JobFilter _jobFilter;

		private int _jobAssignmentCurrentPage;

		private Dictionary<StaffDefinition.Type, PanelItemToggleButton> _staffFilterToggles = new Dictionary<StaffDefinition.Type, PanelItemToggleButton>();

		private List<JobDescription>[] _jobs = new List<JobDescription>[StaffDefinition.AllTypes.Length];

		private PanelItemValueViewer[] _theValueViewers;

		private List<Image> _pageMarkers = new List<Image>();

		private Dictionary<JobDescription, StaffJobColumnBacking> _columnBackings = new Dictionary<JobDescription, StaffJobColumnBacking>();

		public int CurrentJobAssignmentPageIndex => _jobAssignmentCurrentPage;

		public ViewModes ViewMode => _viewMode;

		public void Initialise(Level level)
		{
			_level = level;
			_level.InputManager.AddGraphicRayCaster(_graphicRaycaster);
			_staffMenuSettings = _data.StaffMenuSettings;
			_characterManager = _level.CharacterManager;
			_characterEvents = _level.CharacterEvents;
			_statsDatabase = _level.LevelStatsDatabase;
			_worldState = _level.WorldState;
			if ((bool)_staffMenuSettings.SatisfyAllPayRequestsButton)
			{
				_satisfyAllDynamicButton = _staffMenuSettings.SatisfyAllPayRequestsButton.GetComponent<DynamicButton>();
				if ((bool)_satisfyAllDynamicButton)
				{
					_satisfyAllDynamicButton.onPrimaryDown.AddListener(OnSatisfyPayRequestsButtonClick);
				}
				_staffMenuSettings.SatisfyAllPayRequestsButton.CurrentState = ButtonAnimator.State.Unselectable;
				_staffMenuSettings.SatisfyAllPayRequestsButton.enabled = false;
				_satisfyAllButtonImage = _staffMenuSettings.SatisfyAllPayRequestsButton.GetComponent<Image>();
				if ((bool)_satisfyAllButtonImage)
				{
					_satisfyAllButtonImage.overrideSprite = null;
				}
			}
			_staffMenuSettings.AllPayButton.Button.onPrimaryDown.AddListener(OnAllPayButtonClick);
			_staffMenuSettings.AllPayButtonText.text = string.Format(ScriptLocalization.Menu_StaffPayReview.AllPayIncrease_CS, StringUtils.FormatPercentageValue(_staffMenuSettings.AllPayRisePercentage, prefixPlus: true));
			RefreshJobsList();
			_staffMenuSettings.JobPageLeftButton.onPrimaryDown.AddListener(OnJobAssignmentPageLeftPressed);
			_staffMenuSettings.JobPageRightButton.onPrimaryDown.AddListener(OnJobAssignmentPageRightPressed);
			_staffMenuSettings.JobFilterDiagnosisButton.onPrimaryDown.AddListener(OnJobFilterDiagnosis);
			_staffMenuSettings.JobFilterTreatmentButton.onPrimaryDown.AddListener(OnJobFilterTreatment);
			_staffMenuSettings.JobFilterAllButton.onPrimaryDown.AddListener(OnJobFilterAll);
			PanelItem[] componentsInChildren = GetComponentsInChildren<PanelItem>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Setup();
			}
			if ((bool)_staffMenuSettings.TitleRectTransform)
			{
				_titleWidth = _staffMenuSettings.TitleRectTransform.sizeDelta.x;
			}
			if ((bool)_staffMenuSettings.FilterGroup)
			{
				_theValueViewers = _staffMenuSettings.FilterGroup.GetComponentsInChildren<PanelItemValueViewer>();
				RefreshValueViewers();
			}
			_staffFilterToggles.Clear();
			foreach (StaffMenuSettings.StaffTypeToggle staffTypeToggle in _staffMenuSettings.StaffTypeToggles)
			{
				if ((bool)staffTypeToggle.AssignedButton)
				{
					staffTypeToggle.AssignedButton.Setup();
				}
				StaffDefinition.Type type = staffTypeToggle.StaffType;
				staffTypeToggle.AssignedButton.AddButtonListener(delegate
				{
					UpdateStaffList(force: false, type);
				});
				_staffFilterToggles.Add(staffTypeToggle.StaffType, staffTypeToggle.AssignedButton);
			}
			if ((bool)_staffMenuSettings.DefaultStaffToggle)
			{
				_staffMenuSettings.DefaultStaffToggle.SetPressedState(state: true);
			}
			if ((bool)_staffMenuSettings.CloseButton)
			{
				_staffMenuSettings.CloseButton.onPrimaryDown.AddListener(CloseMenu);
			}
			foreach (StaffMenuSettings.ViewModeToggle viewModeToggle in _staffMenuSettings.ViewModeToggles)
			{
				StaffMenuSettings.ViewModeToggle toggle = viewModeToggle;
				if ((bool)viewModeToggle.AssignedButton)
				{
					viewModeToggle.AssignedButton.Setup();
					viewModeToggle.AssignedButton.AddButtonListener(delegate
					{
						SetViewMode(toggle);
					});
				}
				viewModeToggle.AnimHash = Animator.StringToHash(viewModeToggle.TabAnim.name);
				viewModeToggle.TriggerHash = Animator.StringToHash(viewModeToggle.TabAnimStateTrigger);
				if (viewModeToggle.ViewMode == ViewModes.ViewModeJobAssignment)
				{
					_jobAssignmentPanel = viewModeToggle;
				}
			}
			if (_staffMenuSettings.ViewModeToggles.Count > 0 && _staffMenuSettings.ViewModeToggles[0] != null && _staffMenuSettings.ViewModeToggles[0].AssignedButton != null)
			{
				PanelItemRadioButtonsGroup[] componentsInParent = _staffMenuSettings.ViewModeToggles[0].AssignedButton.GetComponentsInParent<PanelItemRadioButtonsGroup>(includeInactive: true);
				if (componentsInParent != null && componentsInParent.Length != 0)
				{
					_tabModeGroup = componentsInParent[0];
				}
			}
		}

		private void RefreshJobsList()
		{
			StaffDefinition.Type[] allTypes = StaffDefinition.AllTypes;
			foreach (StaffDefinition.Type type in allTypes)
			{
				_jobs[(int)type] = RoomAlgorithms.GetAllJobs(_level.Metagame, _worldState, type);
			}
			FilterJobs(_jobs[0]);
			FilterJobs(_jobs[1]);
			if (_staffMenuRowProvider != null)
			{
				_staffMenuRowProvider.Jobs = _jobs;
			}
		}

		private void FilterJobs(List<JobDescription> jobs)
		{
			jobs.RemoveAll(delegate(JobDescription description)
			{
				if (_jobFilter == JobFilter.All)
				{
					return false;
				}
				if (description is JobRoomDescription jobRoomDescription && jobRoomDescription.Room.Filters != null)
				{
					bool flag = jobRoomDescription.Room.Filters.Contains(_staffMenuSettings.JobFilterDiagnosis);
					bool flag2 = jobRoomDescription.Room.Filters.Contains(_staffMenuSettings.JobFilterTreatment);
					if (_jobFilter == JobFilter.Diagnosis && !flag)
					{
						return true;
					}
					if (_jobFilter == JobFilter.Treatment && !flag2)
					{
						return true;
					}
				}
				return false;
			});
		}

		public void Setup(ViewModes viewMode)
		{
			SetCurrentSelectedStaff(null);
			SetInspectedStaffMember(null);
			foreach (StaffMenuSettings.ViewModeToggle viewModeToggle in _staffMenuSettings.ViewModeToggles)
			{
				bool pressedState = viewModeToggle.ViewMode == viewMode;
				viewModeToggle.AssignedButton.SetPressedState(pressedState);
				if ((bool)viewModeToggle.ColumnHeadersParent)
				{
					viewModeToggle.ColumnHeadersParent.gameObject.SetActive(value: false);
				}
				if ((bool)viewModeToggle.Table)
				{
					viewModeToggle.Table.gameObject.SetActive(value: false);
				}
			}
			if (_tabModeGroup != null && viewMode > ViewModes.ViewModeNone)
			{
				_tabModeGroup.SelectButtonOnly((int)(viewMode - 1));
			}
			SetViewMode(viewMode, forceRefresh: true);
		}

		private void RefreshValueViewers()
		{
			if (_theValueViewers != null)
			{
				PanelItemValueViewer[] theValueViewers = _theValueViewers;
				for (int i = 0; i < theValueViewers.Length; i++)
				{
					theValueViewers[i].UpdateStat(_statsDatabase);
				}
			}
		}

		private IEnumerator TweenMenu(StaffMenuSettings.ViewModeToggle viewModeToggle, float duration)
		{
			bool stop = false;
			float time = 0f;
			float timeScaler = 1f / duration;
			float financeAlpha = _staffMenuSettings.FinanceCanvasGroup.alpha;
			float financeDestAlpha = viewModeToggle.FinanceFooterAlpha;
			Vector2 panelSize = _staffMenuSettings.PanelRectTransform.sizeDelta;
			Vector2 panelDestSize = viewModeToggle.PanelSizeDelta;
			Vector2 barSize = _staffMenuSettings.BarRectTransform.sizeDelta;
			float num = panelDestSize.x + _titleWidth + viewModeToggle.BarSizeDeltaX;
			Vector2 tabStart = _staffMenuSettings.TabSelectionRectTransform.anchoredPosition;
			Vector2 tabDest = viewModeToggle.TabSelectionPosition;
			if (viewModeToggle.ViewMode == ViewModes.ViewModeJobAssignment)
			{
				int staffFilter = (int)_staffFilter;
				int num2 = Mathf.Min(MaxJobIconsPerPage, _jobs[staffFilter].Count);
				int num3 = num2 * _staffMenuSettings.JobIconUnitSize;
				num += (float)(num2 * _staffMenuSettings.JobIconUnitSize);
				panelDestSize.x = _jobAssignmentPanel.PanelSizeDelta.x + (float)num3;
				panelDestSize.x -= (float)_staffMenuSettings.JobIconUnitSize - _staffMenuSettings.ViewFinderBorder;
				RefreshJobColumnBackgroundHeight();
			}
			num = Mathf.Min(num, viewModeToggle.MaxBarSizeX);
			Vector2 barDestSize = new Vector2(num, barSize.y);
			do
			{
				if (time > 1f)
				{
					stop = true;
				}
				float t = EasingsUtils.CubicEaseOut(Mathf.Clamp01(time));
				_staffMenuSettings.BarRectTransform.sizeDelta = Vector2.LerpUnclamped(barSize, barDestSize, t);
				_staffMenuSettings.PanelRectTransform.sizeDelta = Vector2.LerpUnclamped(panelSize, panelDestSize, t);
				_staffMenuSettings.TabSelectionRectTransform.anchoredPosition = Vector2.LerpUnclamped(tabStart, tabDest, t);
				_staffMenuSettings.FinanceCanvasGroup.alpha = Mathf.LerpUnclamped(financeAlpha, financeDestAlpha, t);
				_staffMenuSettings.SatisfyPayGroup.alpha = _staffMenuSettings.FinanceCanvasGroup.alpha;
				_staffMenuSettings.AllPayRiseGroup.alpha = _staffMenuSettings.FinanceCanvasGroup.alpha;
				yield return new WaitForEndOfFrame();
				time += Time.unscaledDeltaTime * timeScaler;
			}
			while (!stop);
			_staffMenuSettings.FinanceCanvasGroup.blocksRaycasts = _staffMenuSettings.FinanceCanvasGroup.alpha >= 0.5f;
			_staffMenuSettings.SatisfyPayGroup.blocksRaycasts = _staffMenuSettings.SatisfyPayGroup.alpha >= 0.5f;
			_staffMenuSettings.AllPayRiseGroup.blocksRaycasts = _staffMenuSettings.AllPayRiseGroup.alpha >= 0.5f;
			_viewMode = viewModeToggle.ViewMode;
			_currentStaffText = viewModeToggle.StaffTypeText;
			_showViewFinder = viewModeToggle.ShowViewFinder;
			if (_inspectedStaffMember != null)
			{
				ShowViewFinder(state: true, canResetCamera: true);
			}
			if (!(_table != null))
			{
				yield break;
			}
			_table.gameObject.SetActive(value: true);
			if ((bool)_table.ColumnHeaders)
			{
				if (_viewMode == ViewModes.ViewModeJobAssignment)
				{
					CreateJobIcons(_staffFilter);
				}
				_table.ColumnHeaders.gameObject.SetActive(value: true);
			}
			UpdateStaffList(force: true, _staffFilter);
		}

		public void SetCurrentSelectedStaff(Staff staff)
		{
			if (staff != null)
			{
				if (_staffMenuRowProvider != null && _staffMenuRowProvider.CurrentSelectedStaff != staff)
				{
					_staffMenuRowProvider.CurrentSelectedStaff = staff;
				}
				if (_staffFilter != StaffDefinition.Type.None && _staffFilter != staff.Definition._type)
				{
					UpdateStaffList(force: true, staff.Definition._type);
					UpdatedSelectedFilterGroupButtonsByStaffType(staff.Definition._type);
				}
			}
			else if (_staffMenuRowProvider != null)
			{
				_staffMenuRowProvider.CurrentSelectedStaff = null;
			}
		}

		public void SetInspectedStaffMember(Staff staff)
		{
			_inspectedStaffMember = staff;
		}

		public void SetViewMode(ViewModes viewMode, bool forceRefresh = false)
		{
			if (_viewMode == viewMode && !forceRefresh)
			{
				return;
			}
			foreach (StaffMenuSettings.ViewModeToggle viewModeToggle in _staffMenuSettings.ViewModeToggles)
			{
				if (viewMode == viewModeToggle.ViewMode)
				{
					SetViewMode(viewModeToggle, forceRefresh);
					break;
				}
			}
		}

		private void SetViewMode(StaffMenuSettings.ViewModeToggle viewModeToggle, bool forceRefresh = false)
		{
			if (_viewMode == viewModeToggle.ViewMode && !forceRefresh)
			{
				return;
			}
			_viewMode = ViewModes.ViewModeNone;
			_showViewFinder = false;
			ShowViewFinder(state: false, canResetCamera: false);
			if (_staffMenuRowProvider == null)
			{
				_staffMenuRowProvider = new StaffMenuRowProvider(_staffFilter, _characterManager, _characterEvents, this, _staffMenuSettings, viewModeToggle.RowPrefab);
				_staffMenuRowProvider.Jobs = _jobs;
				StaffMenuRowProvider staffMenuRowProvider = _staffMenuRowProvider;
				staffMenuRowProvider.OnTogglePressed = (Action<JobDescription>)Delegate.Combine(staffMenuRowProvider.OnTogglePressed, new Action<JobDescription>(CheckColumnValid));
			}
			else
			{
				_staffMenuRowProvider.StaffFilter = _staffFilter;
				_staffMenuRowProvider.RowPrefab = viewModeToggle.RowPrefab;
			}
			if (_table != null)
			{
				_table.RowProvider = null;
				if ((bool)_table.ColumnHeaders)
				{
					_table.ColumnHeaders.gameObject.SetActive(value: false);
				}
				_table.gameObject.SetActive(value: false);
			}
			switch (viewModeToggle.ViewMode)
			{
			case ViewModes.ViewModeStaffList:
				if ((bool)_staffMenuSettings.TitleText)
				{
					_staffMenuSettings.TitleText.text = ScriptLocalization.Staff.ViewModeStaffList_CS;
				}
				break;
			case ViewModes.ViewModePayReview:
				if ((bool)_staffMenuSettings.TitleText)
				{
					_staffMenuSettings.TitleText.text = ScriptLocalization.Staff.ViewModePayReview_CS;
				}
				break;
			case ViewModes.ViewModeJobAssignment:
				if (_staffMenuSettings.TitleText != null)
				{
					_staffMenuSettings.TitleText.text = ScriptLocalization.Tooltip.InspectorDataStaff_Jobs_CS;
				}
				break;
			}
			_jobAssignmentCurrentPage = 0;
			if (_tabModeGroup != null && viewModeToggle.ViewMode > ViewModes.ViewModeNone)
			{
				_tabModeGroup.SelectButtonOnly((int)(viewModeToggle.ViewMode - 1));
			}
			_table = viewModeToggle.Table;
			if (_table != null)
			{
				_table.RowProvider = _staffMenuRowProvider;
				_table.ColumnHeaders = viewModeToggle.ColumnHeadersParent;
			}
			if (viewModeToggle.AllButtonEnabled)
			{
				if (!_staffFilterToggles[StaffDefinition.Type.None].Enabled)
				{
					_staffFilterToggles[StaffDefinition.Type.None].Enabled = true;
				}
			}
			else
			{
				if (_staffFilter == StaffDefinition.Type.None)
				{
					if (_inspectedStaffMember == null)
					{
						_staffFilter = StaffDefinition.Type.Doctor;
					}
					else
					{
						_staffFilter = _inspectedStaffMember.Definition._type;
					}
					UpdatedSelectedFilterGroupButtonsByStaffType(_staffFilter);
				}
				_staffFilterToggles[StaffDefinition.Type.None].Enabled = false;
			}
			if (viewModeToggle.TutorialButtonClickedMessage != null)
			{
				viewModeToggle.TutorialButtonClickedMessage.TryShowMessage();
			}
			StartCoroutine(TweenMenu(viewModeToggle, 0.25f));
		}

		private void UpdatedSelectedFilterGroupButtonsByStaffType(StaffDefinition.Type staffType)
		{
			_staffMenuSettings.FilterGroup.SelectButtonOnly((int)staffType);
		}

		private void CreateJobIcons(StaffDefinition.Type staffType)
		{
			GameObjectUtils.DestroyChildrenImmediate(_staffMenuSettings.JobsListContainer.gameObject);
			GameObjectUtils.DestroyChildrenImmediate(_staffMenuSettings.JobColumnBackgroundParent.gameObject);
			_columnBackings.Clear();
			List<JobDescription> list = _jobs[(int)staffType];
			GetCurrentJobAssignmentIndiciesForPage(list, _jobAssignmentCurrentPage, out var startIndex, out var endIndex);
			Vector2 sizeDelta = _staffMenuSettings.JobsListContainerBackground.sizeDelta;
			sizeDelta.x = (endIndex - startIndex + 1) * _staffMenuSettings.JobIconUnitSize;
			_staffMenuSettings.JobsListContainerBackground.sizeDelta = sizeDelta;
			for (int i = startIndex; i <= endIndex; i++)
			{
				if (i >= list.Count)
				{
					break;
				}
				JobDescription job = list[i];
				StaffJobIcon component = UnityEngine.Object.Instantiate(_staffMenuSettings.JobIconPrefab, _staffMenuSettings.JobsListContainer, worldPositionStays: false).GetComponent<StaffJobIcon>();
				if ((bool)component)
				{
					component.Tooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = job.GetJobAssignmentTooltipString();
					});
					component.Image.overrideSprite = GetIconForJob(job);
					component.Button.onSecondaryDown.AddListener(delegate
					{
						OnJobColumnPressed(job);
					});
				}
				StaffJobColumnBacking component2 = UnityEngine.Object.Instantiate(_staffMenuSettings.JobColumnBackgroundPrefab, _staffMenuSettings.JobColumnBackgroundParent.transform, worldPositionStays: false).GetComponent<StaffJobColumnBacking>();
				component2.DefaultColor = ((i % 2 == 0) ? _staffMenuSettings.JobColumnBackgroundColor1 : _staffMenuSettings.JobColumnBackgroundColor2);
				_columnBackings[job] = component2;
			}
			RefreshJobColumnBackgroundHeight();
			GameObjectUtils.DestroyChildrenImmediate(_staffMenuSettings.PageMarkerContainer.gameObject);
			_pageMarkers.Clear();
			int numJobAssignmentPages = GetNumJobAssignmentPages(list);
			GameObjectUtils.SetActive(_staffMenuSettings.JobPageLeftButton.gameObject, numJobAssignmentPages > 1 && _jobAssignmentCurrentPage > 0);
			GameObjectUtils.SetActive(_staffMenuSettings.JobPageRightButton.gameObject, numJobAssignmentPages > 1 && _jobAssignmentCurrentPage < numJobAssignmentPages - 1);
			if (numJobAssignmentPages <= 1)
			{
				return;
			}
			for (int num = 0; num < numJobAssignmentPages; num++)
			{
				Image component3 = UnityEngine.Object.Instantiate(_staffMenuSettings.PageMarkerPrefab, _staffMenuSettings.PageMarkerContainer, worldPositionStays: false).GetComponent<Image>();
				if (component3 != null)
				{
					_pageMarkers.Add(component3);
				}
			}
		}

		private Sprite GetIconForJob(JobDescription description)
		{
			if (description is JobMaintenanceDescription jobMaintenanceDescription)
			{
				return jobMaintenanceDescription.Description switch
				{
					JobMaintenance.JobDescription.BrokenMachine => _repairMachineIcon, 
					JobMaintenance.JobDescription.BlockedToilet => _cleanToiletIcon, 
					JobMaintenance.JobDescription.OutOfStock => _stockMachineIcon, 
					JobMaintenance.JobDescription.WiltedPlant => _waterPlantsIcon, 
					JobMaintenance.JobDescription.Litter => _emptyBinsIcon, 
					JobMaintenance.JobDescription.MedicalWaste => _sweepUpWasteIcon, 
					JobMaintenance.JobDescription.Vehicular => _vehicularIcon, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
			}
			if (description is JobFireDescription)
			{
				return _extinguishFireIcon;
			}
			if (description is JobGhostDescription)
			{
				return _captureGhostIcon;
			}
			if (description is JobUpgradeDescription)
			{
				return _upgradeMachineIcon;
			}
			Sprite sprite = description.GetJobAssignmentIcon();
			if (sprite == null)
			{
				sprite = description.GetIcon();
			}
			return sprite;
		}

		protected void UpdateStaffList(bool force, StaffDefinition.Type staffType = StaffDefinition.Type.None)
		{
			if (!force && _staffFilter == staffType)
			{
				return;
			}
			_staffFilter = staffType;
			if (_currentStaffText != null)
			{
				switch (_staffFilter)
				{
				case StaffDefinition.Type.Doctor:
					_currentStaffText.text = ScriptLocalization.Menu_Select_Staff.Doctors_CS;
					break;
				case StaffDefinition.Type.Nurse:
					_currentStaffText.text = ScriptLocalization.Menu_Select_Staff.Nurses_CS;
					break;
				case StaffDefinition.Type.Janitor:
					_currentStaffText.text = ScriptLocalization.Menu_Select_Staff.Janitors_CS;
					break;
				case StaffDefinition.Type.Assistant:
					_currentStaffText.text = ScriptLocalization.Menu_Select_Staff.Assistants_CS;
					break;
				default:
					_currentStaffText.text = ScriptLocalization.Menu_Select_Staff.All_CS;
					break;
				}
			}
			_staffMenuRowProvider.StaffFilter = staffType;
			_staffMenuRowProvider.RebuildStaffList();
			foreach (StaffMenuSettings.StaffTypeToggle staffTypeToggle in _staffMenuSettings.StaffTypeToggles)
			{
				if (!staffTypeToggle.AssignedTabBacking)
				{
					continue;
				}
				if (staffTypeToggle.StaffType == StaffDefinition.Type.Janitor && _staffFilter == StaffDefinition.Type.Janitor)
				{
					if (_staffMenuSettings.PanelRectTransform.sizeDelta.x > _staffMenuSettings.JanitorTabSwapThreshold)
					{
						GameObjectUtils.SetActive(staffTypeToggle.AssignedTabBacking, isActive: false);
						GameObjectUtils.SetActive(staffTypeToggle.AssignedTabBackingAlternative, isActive: true);
					}
					else
					{
						GameObjectUtils.SetActive(staffTypeToggle.AssignedTabBacking, isActive: true);
						GameObjectUtils.SetActive(staffTypeToggle.AssignedTabBackingAlternative, isActive: false);
					}
				}
				else
				{
					GameObjectUtils.SetActive(staffTypeToggle.AssignedTabBacking, _staffFilter == staffTypeToggle.StaffType);
					if (staffTypeToggle.AssignedTabBackingAlternative != null)
					{
						GameObjectUtils.SetActive(staffTypeToggle.AssignedTabBackingAlternative, _staffFilter == staffTypeToggle.StaffType);
					}
				}
			}
			if (_viewMode == ViewModes.ViewModeJobAssignment)
			{
				CreateJobIcons(_staffFilter);
				int staffFilter = (int)_staffFilter;
				int num = Mathf.Clamp(_jobs[staffFilter].Count, 6, MaxJobIconsPerPage) * _staffMenuSettings.JobIconUnitSize;
				Vector2 sizeDelta = _jobAssignmentPanel.PanelSizeDelta + Vector2.right * num;
				sizeDelta.x -= (float)_staffMenuSettings.JobIconUnitSize - _staffMenuSettings.ViewFinderBorder;
				_staffMenuSettings.PanelRectTransform.sizeDelta = sizeDelta;
				Vector2 sizeDelta2 = _staffMenuSettings.BarRectTransform.sizeDelta;
				float x = Mathf.Min(sizeDelta.x + _titleWidth + _jobAssignmentPanel.BarSizeDeltaX, _jobAssignmentPanel.MaxBarSizeX);
				Vector2 sizeDelta3 = new Vector2(x, sizeDelta2.y);
				_staffMenuSettings.BarRectTransform.sizeDelta = sizeDelta3;
				int numJobAssignmentPages = GetNumJobAssignmentPages(_jobs[(int)_staffFilter]);
				for (int i = 0; i < numJobAssignmentPages && i < _pageMarkers.Count; i++)
				{
					_pageMarkers[i].color = ((_jobAssignmentCurrentPage == i) ? _staffMenuSettings.PageMarkerOnColour : _staffMenuSettings.PageMarkerOffColour);
				}
				GameObjectUtils.SetActive(_staffMenuSettings.JobFilterButtons, _staffFilter == StaffDefinition.Type.Doctor || _staffFilter == StaffDefinition.Type.Nurse);
				UpdateViewFinder();
			}
			if ((bool)_table)
			{
				_table.Refresh();
			}
			CheckAllColumnsAreValid();
			RefreshJobColumnBackgroundHeight();
		}

		private void CheckAllColumnsAreValid()
		{
			if (_viewMode != ViewModes.ViewModeJobAssignment || _jobs == null || _staffFilter == StaffDefinition.Type.None)
			{
				return;
			}
			int staffFilter = (int)_staffFilter;
			if (staffFilter >= _jobs.Length)
			{
				return;
			}
			_staffMenuRowProvider.RefreshRowAssignment();
			foreach (JobDescription item in _jobs[staffFilter])
			{
				CheckColumnValid(item);
			}
		}

		public void OnStaffHiredEvent(Staff staff, JobApplicant jobApplicant, int fee)
		{
			if (_staffMenuRowProvider != null)
			{
				_staffMenuRowProvider.OnStaffHired(staff);
			}
			RefreshValueViewers();
			CheckAllColumnsAreValid();
		}

		private void OnSatisfyPayRequestsButtonClick()
		{
			if (_staffMenuRowProvider != null)
			{
				_staffMenuRowProvider.SatisfyPayRequest();
			}
		}

		private void OnAllPayButtonClick()
		{
			if (_staffMenuRowProvider != null)
			{
				_staffMenuRowProvider.IncreaseAllPay(_staffMenuSettings.AllPayRisePercentage);
			}
		}

		private void OnStaffDestroyed(Staff staff)
		{
			RefreshValueViewers();
			CheckAllColumnsAreValid();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			if (_staffMenuRowProvider != null)
			{
				StaffMenuRowProvider staffMenuRowProvider = _staffMenuRowProvider;
				staffMenuRowProvider.OnTogglePressed = (Action<JobDescription>)Delegate.Remove(staffMenuRowProvider.OnTogglePressed, new Action<JobDescription>(CheckColumnValid));
				_staffMenuRowProvider.Destroy();
				_staffMenuRowProvider = null;
			}
			_staffMenuSettings.AllPayButton.Button.onPrimaryDown.RemoveListener(OnAllPayButtonClick);
			_staffMenuSettings.JobPageLeftButton.onPrimaryDown.RemoveListener(OnJobAssignmentPageLeftPressed);
			_staffMenuSettings.JobPageRightButton.onPrimaryDown.RemoveListener(OnJobAssignmentPageRightPressed);
			_staffMenuSettings.JobFilterDiagnosisButton.onPrimaryDown.RemoveListener(OnJobFilterDiagnosis);
			_staffMenuSettings.JobFilterTreatmentButton.onPrimaryDown.RemoveListener(OnJobFilterTreatment);
			_staffMenuSettings.JobFilterAllButton.onPrimaryDown.RemoveListener(OnJobFilterAll);
			_level.CameraLogic.SetTrackedObjectFrame(null);
			_level.InputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			if (_staffMenuSettings != null && (bool)_staffMenuSettings.CloseButton)
			{
				_staffMenuSettings.CloseButton.onPrimaryDown.RemoveListener(CloseMenu);
			}
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			RefreshJobsList();
			RefreshValueViewers();
			RegisterEvents();
		}

		public override void CloseMenu()
		{
			UnregisterEvents();
			_inspectedStaffMember = null;
			ShowViewFinder(state: false, canResetCamera: true);
			base.CloseMenu();
		}

		private void RegisterEvents()
		{
			_characterEvents.OnStaffHired.Add(this);
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffResigned, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents3.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpen = (Action<InspectorMenu, Character>)Delegate.Combine(hUDEvents.OnInspectorOpen, new Action<InspectorMenu, Character>(OnInspectorOpen));
			HUDEvents hUDEvents2 = _level.HUDEvents;
			hUDEvents2.OnInspectorClose = (System.Action)Delegate.Combine(hUDEvents2.OnInspectorClose, new System.Action(OnInspectorClose));
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Combine(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			_level.Metagame.OnItemUnlocked.Add(this);
		}

		private void UnregisterEvents()
		{
			_characterEvents.OnStaffHired.Remove(this);
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffResigned, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents3.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpen = (Action<InspectorMenu, Character>)Delegate.Remove(hUDEvents.OnInspectorOpen, new Action<InspectorMenu, Character>(OnInspectorOpen));
			HUDEvents hUDEvents2 = _level.HUDEvents;
			hUDEvents2.OnInspectorClose = (System.Action)Delegate.Remove(hUDEvents2.OnInspectorClose, new System.Action(OnInspectorClose));
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Remove(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			_level.Metagame.OnItemUnlocked.Remove(this);
		}

		protected override void Update()
		{
			base.Update();
			Refresh();
		}

		private void Refresh()
		{
			switch (_viewMode)
			{
			case ViewModes.ViewModeJobAssignment:
				CheckAllColumnsAreValid();
				RefreshJobColumnBackgroundHeight();
				break;
			case ViewModes.ViewModePayReview:
			{
				float time = Time.time;
				if (time > _timeStamp)
				{
					_timeStamp = time + 1f;
					int totalStaffWages = _statsDatabase.TotalStaffWages;
					LevelStatsDatabase.ExpensesBreakdown expensesBreakdown = _statsDatabase.GetExpensesBreakdown(12);
					_statsDatabase.GetPreviousMonthsProfitAndLoss(12, out var _, out var revenue, out var profit);
					_staffMenuSettings.YearlyWagesText.SetValueText(totalStaffWages);
					_staffMenuSettings.OtherOutgoingsText.SetValueText(expensesBreakdown.Other);
					_staffMenuSettings.YearlyIncomeText.SetValueText(revenue);
					_staffMenuSettings.YearlyCashFlowText.SetValueText(profit);
					_staffMenuSettings.PaySatisfactionTrend.SetTrend(0f, 0f);
				}
				int satisfyCost = 0;
				int[] array = new int[5];
				if (_staffMenuRowProvider != null)
				{
					_staffMenuRowProvider.UpdateSatisfyCost(out satisfyCost, out var _, out var satisfiable, array);
					if (satisfiable)
					{
						_staffMenuSettings.SatisfyAllPayRequestsButton.enabled = true;
						_staffMenuSettings.SatisfyAllPayRequestsButton.CurrentState = ButtonAnimator.State.Selectable;
						if ((bool)_satisfyAllButtonImage)
						{
							_satisfyAllButtonImage.overrideSprite = _staffMenuSettings.AcceptButtonSprite;
						}
					}
					else
					{
						_staffMenuSettings.SatisfyAllPayRequestsButton.CurrentState = ButtonAnimator.State.Unselectable;
						_staffMenuSettings.SatisfyAllPayRequestsButton.enabled = false;
						_satisfyAllButtonImage = _staffMenuSettings.SatisfyAllPayRequestsButton.GetComponent<Image>();
						if ((bool)_satisfyAllButtonImage)
						{
							_satisfyAllButtonImage.overrideSprite = null;
						}
					}
					bool flag = _staffMenuRowProvider.AreAllStaffAtMaximumPay();
					_staffMenuSettings.AllPayButton.CurrentState = (flag ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				}
				_staffMenuSettings.SatisfyAllCostText.SetValueText(satisfyCost);
				_staffMenuSettings.SatisfactionBarGraph.MaxValue = Mathf.Max(array);
				for (int i = 0; i < _staffMenuSettings.SatisfactionBarGraph.BarCount; i++)
				{
					_staffMenuSettings.SatisfactionBarGraph.SetBarValue(i, array[i]);
				}
				GameObjectUtils.SetActive(_staffMenuSettings.SatisfactionBarGraph.gameObject, isActive: true);
				break;
			}
			}
		}

		public bool IsShowingViewFinder()
		{
			return _bShowingViewFinder;
		}

		public void HideViewFinder()
		{
			if (_bShowingViewFinder)
			{
				ShowViewFinder(state: false, canResetCamera: true);
			}
		}

		private void UpdateViewFinder()
		{
			if (_bShowingViewFinder)
			{
				ShowViewFinder(state: true, canResetCamera: false);
			}
		}

		private void ShowViewFinder(bool state, bool canResetCamera)
		{
			_bShowingViewFinder = false;
			if ((bool)_staffMenuSettings.ViewFinderRectTransform)
			{
				bool flag = state & _showViewFinder;
				if (flag)
				{
					_bShowingViewFinder = true;
					Vector2 sizeDelta = _staffMenuSettings.PanelRectTransform.sizeDelta;
					float y = sizeDelta.y;
					float x = _staffMenuSettings.ViewFinderRectTransform.anchoredPosition.x - _staffMenuSettings.PanelRectTransform.anchoredPosition.x - sizeDelta.x - _staffMenuSettings.ViewFinderBorder;
					_staffMenuSettings.ViewFinderRectTransform.sizeDelta = new Vector2(x, y);
					_level.CameraLogic.SetTrackedObjectFrame(_staffMenuSettings.ViewFinderRectTransform.GetScreenSpaceRect());
				}
				else if (canResetCamera)
				{
					_level.CameraLogic.SetTrackedObjectFrame(null);
				}
				_staffMenuSettings.ViewFinderRectTransform.gameObject.SetActive(flag);
			}
		}

		private void OnInspectorOpen(InspectorMenu menuRef, Character character)
		{
			if (character is Staff && !IsClosed() && !IsClosing())
			{
				SetCurrentSelectedStaff((Staff)character);
				SetInspectedStaffMember((Staff)character);
				ShowViewFinder(state: true, canResetCamera: false);
			}
		}

		private void OnInspectorClose()
		{
			StopViewFinderTracking();
		}

		private void OnCameraPan(float distance)
		{
			StopViewFinderTracking();
		}

		private void StopViewFinderTracking()
		{
			if (_bShowingViewFinder && !IsClosed() && !IsClosing())
			{
				_level.CameraLogic.TrackObject(null);
				_level.CameraLogic.SetFocalPoint(_level.CameraLogic.GetTargetFocalPoint(), snap: true);
				_inspectedStaffMember = null;
				ShowViewFinder(state: false, canResetCamera: true);
			}
		}

		public void OnItemUnlockedEvent(ISilverUnlockable item)
		{
			RefreshJobsList();
			if (_viewMode == ViewModes.ViewModeJobAssignment)
			{
				UpdateStaffList(force: true, _staffFilter);
			}
		}

		private void OnJobColumnPressed(JobDescription job)
		{
			if (_staffMenuRowProvider != null)
			{
				_staffMenuRowProvider.OnColumnPressed(job);
				_staffMenuRowProvider.RefreshRowJobs();
			}
		}

		public void OnJobRowPressed(Staff staff)
		{
			if (_staffMenuRowProvider != null)
			{
				_staffMenuRowProvider.OnRowPressed(staff);
				_staffMenuRowProvider.RefreshRowJobs();
			}
		}

		private void OnJobAssignmentPageLeftPressed()
		{
			_jobAssignmentCurrentPage = Mathf.Max(_jobAssignmentCurrentPage - 1, 0);
			if (_viewMode == ViewModes.ViewModeJobAssignment)
			{
				_staffMenuRowProvider.RefreshRowJobs();
				UpdateStaffList(force: true, _staffFilter);
			}
		}

		private void CheckColumnValid(JobDescription job)
		{
			if (!_columnBackings.TryGetValue(job, out var value))
			{
				return;
			}
			foreach (Staff staffMember in _characterManager.StaffMembers)
			{
				if (staffMember.Definition._type == _staffFilter && job.IsSuitable(staffMember) && !staffMember.JobExclusions.Contains(job))
				{
					value.SetColor(null);
					return;
				}
			}
			value.SetColor(_staffMenuSettings.JobColumnInvalidColor);
		}

		private void RefreshJobColumnBackgroundHeight()
		{
			float a = (float)_staffMenuSettings.JobIconUnitSize + 10f + (float)_staffMenuRowProvider.NumOfRowsInUsed * 54f;
			a = Mathf.Min(a, _staffMenuSettings.JobColumnMaximumHeight);
			foreach (KeyValuePair<JobDescription, StaffJobColumnBacking> columnBacking in _columnBackings)
			{
				columnBacking.Value.SetColumnPreferredHeight(a);
			}
		}

		private void OnJobAssignmentPageRightPressed()
		{
			int b = _jobs[(int)_staffFilter].Count / MaxJobIconsPerPage;
			_jobAssignmentCurrentPage = Mathf.Min(_jobAssignmentCurrentPage + 1, b);
			if (_viewMode == ViewModes.ViewModeJobAssignment)
			{
				_staffMenuRowProvider.RefreshRowJobs();
				UpdateStaffList(force: true, _staffFilter);
			}
		}

		public static int GetNumJobAssignmentPages(List<JobDescription> jobs)
		{
			if (jobs.Count % MaxJobIconsPerPage != 0)
			{
				return jobs.Count / MaxJobIconsPerPage + 1;
			}
			return jobs.Count / MaxJobIconsPerPage;
		}

		public static void GetCurrentJobAssignmentIndiciesForPage(List<JobDescription> jobs, int pageIndex, out int startIndex, out int endIndex)
		{
			int num = pageIndex * MaxJobIconsPerPage;
			int num2 = num + MaxJobIconsPerPage - 1;
			if (num2 >= jobs.Count)
			{
				num = Mathf.Max(jobs.Count - MaxJobIconsPerPage, 0);
				num2 = jobs.Count - 1;
			}
			num2 = Mathf.Min(jobs.Count - 1, num2);
			startIndex = num;
			endIndex = num2;
		}

		private void OnJobFilterAll()
		{
			SetJobFilter(JobFilter.All);
		}

		private void OnJobFilterDiagnosis()
		{
			SetJobFilter(JobFilter.Diagnosis);
		}

		private void OnJobFilterTreatment()
		{
			SetJobFilter(JobFilter.Treatment);
		}

		private void SetJobFilter(JobFilter filter)
		{
			_jobFilter = filter;
			_staffMenuSettings.JobFilterAllButton.interactable = _jobFilter != JobFilter.All;
			_staffMenuSettings.JobFilterAllButtonAnimator.CurrentState = ((_jobFilter == JobFilter.All) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_staffMenuSettings.JobFilterDiagnosisButton.interactable = _jobFilter != JobFilter.Diagnosis;
			_staffMenuSettings.JobFilterDiagnosisButtonAnimator.CurrentState = ((_jobFilter == JobFilter.Diagnosis) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_staffMenuSettings.JobFilterTreatmentButton.interactable = _jobFilter != JobFilter.Treatment;
			_staffMenuSettings.JobFilterTreatmentButtonAnimator.CurrentState = ((_jobFilter == JobFilter.Treatment) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			RefreshJobsList();
			UpdateStaffList(force: true, _staffFilter);
		}
	}
}
