using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI.ScheduleTimeline;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class PatronAttractionDialog3DUIView : BaseDialog3DUIView
	{
		public PatronAttractionChart chart;

		public Button3DUIView closeButton;

		public Button3DUIView openBoardButton;

		public Container3DUIView buttonContainer;

		public Button3DUIView payMoneyButton;

		public PatronAttractionAdjustmentWave waveVisual;

		public Button3DUIView switchPayModeButton;

		public PatronAttractionGauges gaugesController;

		[SerializeField]
		private Button3DUIView _pendingGroupsButton;

		[SerializeField]
		private Button3DUIView _confirmedGroupsButton;

		[SerializeField]
		private GameObject categoryButtonTemplate;

		[SerializeField]
		private Transform _starButtonsParent;

		[SerializeField]
		private DraggableAttractionBoard _draggableAttractionBoard;

		private SchedulingTimeline3DUIView[] _scheduleTimelines;

		[SerializeField]
		private EntertainerTimeline3DUIView _entertainerTimeline;

		[SerializeField]
		private Slider3DUIView _boardSlider;

		public GameObject payAnimParticlePrefab;

		public TextMeshProI18n costLabel;

		private Button3DUIView[] _starButtons;

		private string _currentCategory;

		public Animator[] resetOnUIReset;

		private Animator[] _animators;

		private float _magicLevel;

		private float _currentGaugeTimeValue;

		private float _currentGaugeAccuracyValue;

		private Tween _gaugeTweenTime;

		private Tween _gaugeTweenAccuracy;

		public GameObject[] hideOnOpen;

		public GameObject[] showAfterOpen;

		private static readonly int[] _tiers;

		private int _currentCostLabel;

		public static DraggableAttractionBoard DraggableBoard { get; private set; }

		public static PatronAttractionDialog3DUIView Instance { get; private set; }

		public static List<int> VisibleTiers { get; private set; }

		public bool IsInTimeMode { get; set; }

		public float MagicLevel
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		private int CurrentCostLabel
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<float>> MagicLevelChanged
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

		public event EventHandler BoardFullyOpened
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

		public static event EventHandler OnVisiblePawnsMayHaveChanged
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

		protected override void Awake()
		{
		}

		public void Start()
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void SwitchPayMode()
		{
		}

		private void RefreshButtonTooltips()
		{
		}

		private int GetCostForNextOffering()
		{
			return 0;
		}

		private void PayMoney()
		{
		}

		private void UpdateEnchantmentAnimatorValue()
		{
		}

		private void RefreshMagicLevel()
		{
		}

		private void ImproveClarity()
		{
		}

		private void RefreshGauges()
		{
		}

		private void DraggableAttractionBoard_OnBoardDragged(object sender, EventArgs<int> e)
		{
		}

		private void BoardSlider_OnValueChanged(object sender, EventArgs e)
		{
		}

		private IEnumerable<string> GetCategories()
		{
			return null;
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		public void PlayCloseAnimation()
		{
		}

		public void PrepareStartingState()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		public void PostOpen()
		{
		}

		protected override void Opened()
		{
		}

		protected override void OnAnimEventInternal(object sender, AnimationEventArgs e)
		{
		}

		protected override void SetInitialAnimatorValues()
		{
		}

		public static void RefreshVisibleTiers()
		{
		}

		public void RefreshControls()
		{
		}

		public void RefreshBoard()
		{
		}

		private void RefreshPatronStars()
		{
		}

		private static int GetHoursOfFutureVisible()
		{
			return 0;
		}

		private void ChangeVisibleHours(int delta)
		{
		}

		public static IEnumerable<PatronPopulationData> GetPopulation(string category)
		{
			return null;
		}

		private void RefreshGroupButtons()
		{
		}

		private void RefreshFilterButtons()
		{
		}

		public void RefreshWithCurrentFilter(bool useFastAnim = false)
		{
		}

		private void RefreshCostLabel()
		{
		}

		private void UpdateFilterButtonStates()
		{
		}

		public void SetEntertainTimeline(bool showEntertainerTimeline)
		{
		}
	}
}
