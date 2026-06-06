using System;
using System.Collections.Generic;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class BoilingTablet3D : MonoBehaviour
	{
		[Header("Tablet")]
		[SerializeField]
		private Tablet3D tablet;

		[Header("Input - Load Buttons")]
		[SerializeField]
		private Button3D cornBtn;

		[SerializeField]
		private Button3D waterBtn;

		[SerializeField]
		private Button3D barrelBtn;

		[SerializeField]
		private Button3D yeastBtn;

		[Header("Input - Indicators")]
		[Tooltip("Shown when the slot IS loaded.")]
		[SerializeField]
		private GameObject cornCheck;

		[SerializeField]
		private GameObject waterCheck;

		[SerializeField]
		private GameObject barrelCheck;

		[SerializeField]
		private GameObject yeastCheck;

		[Tooltip("Shown when the slot is NOT loaded.")]
		[SerializeField]
		private GameObject cornUncheck;

		[SerializeField]
		private GameObject waterUncheck;

		[SerializeField]
		private GameObject barrelUncheck;

		[SerializeField]
		private GameObject yeastUncheck;

		[Header("Input - Check Animation")]
		[SerializeField]
		private TweenConfig checkInAnimation;

		[SerializeField]
		private TweenConfig checkOutAnimation;

		[Header("Process")]
		[SerializeField]
		private Button3D startBtn;

		[SerializeField]
		private ProgressBar3D progressBar;

		[Header("Process - Minigame")]
		[SerializeField]
		private ProcessMinigame3D processMinigame;

		[Header("Process - Sub-Switcher")]
		[SerializeField]
		private MinigameSubSwitcher3D minigameSubSwitcher;

		[SerializeField]
		private SterilizationMinigame3D sterilizationMinigame;

		[Header("Input - Optional Load Buttons")]
		[SerializeField]
		private Button3D opt1Btn;

		[SerializeField]
		private Button3D opt2Btn;

		[SerializeField]
		private Button3D opt3Btn;

		[SerializeField]
		private Button3D opt4Btn;

		[Header("Input - Optional Indicators")]
		[Tooltip("Shown when the optional slot IS loaded.")]
		[SerializeField]
		private GameObject opt1Check;

		[SerializeField]
		private GameObject opt2Check;

		[SerializeField]
		private GameObject opt3Check;

		[SerializeField]
		private GameObject opt4Check;

		[Tooltip("Shown when the optional slot is NOT loaded.")]
		[SerializeField]
		private GameObject opt1Uncheck;

		[SerializeField]
		private GameObject opt2Uncheck;

		[SerializeField]
		private GameObject opt3Uncheck;

		[SerializeField]
		private GameObject opt4Uncheck;

		[Header("Guidance")]
		private TabletGuidance3D guidance;

		[Header("Output")]
		[SerializeField]
		private Button3D collectBtn;

		[Header("Output - Bonus Indicators")]
		[Tooltip("One per bonus bit. Boiling: indices 0-3 = optional materials, 4-5 = minigames.")]
		[SerializeField]
		private BonusIndicator3D[] bonusIndicators;

		[Header("Output - Bonus Label")]
		[Tooltip("Text3D that displays the current total bonus count (0-6).")]
		[SerializeField]
		private Text3D bonusLabel;

		[Header("Output - Skill Label")]
		[Tooltip("Text3D that displays the operator's skill bonus (0-9).")]
		[SerializeField]
		private Text3D skillLabel;

		private BoilingStation2 activeStation;

		private bool isDirty;

		private StationState lastObservedState;

		private readonly Dictionary<GameObject, Vector3> indicatorScales;

		private readonly Dictionary<GameObject, int> indicatorTweenIds;

		private readonly HashSet<int> loadedSlots;

		private static readonly string[] TabNames;

		public BoilingStation2 ActiveStation => null;

		public bool IsShowing => false;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void Show(BoilingStation2 station)
		{
		}

		private void WireButtons()
		{
		}

		private void LoadSlot(int slotIndex)
		{
		}

		private void OnStartClicked()
		{
		}

		private void OnCollectClicked()
		{
		}

		private void RefreshInputTab()
		{
		}

		private void RefreshSlotIndicator(int slotIndex, GameObject check, GameObject uncheck)
		{
		}

		private void SnapSlotIndicators()
		{
		}

		private void SnapSlotIndicator(int slotIndex, GameObject check, GameObject uncheck)
		{
		}

		private void CacheScale(GameObject go)
		{
		}

		private void ScaleIn(GameObject go)
		{
		}

		private void ScaleOut(GameObject go, Action onComplete = null)
		{
		}

		private void RefreshProcessTab()
		{
		}

		private void RefreshOutputTab()
		{
		}

		private void SnapBonusIndicators()
		{
		}

		private void SubscribeToStation()
		{
		}

		private void UnsubscribeFromStation()
		{
		}

		private void HandleStationChanged(BaseBreweryStation station)
		{
		}

		private void HandleTabChanged(int index)
		{
		}

		private void OnTabletHidden()
		{
		}

		private void HandleMinigameSubSwitched(int newIndex)
		{
		}

		private void HandleBubbleMilestone(ProcessMinigame3D minigame)
		{
		}
	}
}
