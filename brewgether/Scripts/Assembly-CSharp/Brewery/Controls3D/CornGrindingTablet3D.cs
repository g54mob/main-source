using System;
using System.Collections.Generic;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class CornGrindingTablet3D : MonoBehaviour
	{
		[Header("Tablet")]
		[SerializeField]
		private Tablet3D tablet;

		[Header("Input - Load Button")]
		[SerializeField]
		private Button3D cornBtn;

		[Header("Input - Indicators")]
		[Tooltip("Shown when corn IS loaded.")]
		[SerializeField]
		private GameObject cornCheck;

		[Tooltip("Shown when corn is NOT loaded.")]
		[SerializeField]
		private GameObject cornUncheck;

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

		[Header("Process - Sub-Switcher")]
		[SerializeField]
		private MinigameSubSwitcher3D minigameSubSwitcher;

		[Header("Process - Minigames")]
		[SerializeField]
		private KernelSortMinigame3D kernelSortMinigame;

		[SerializeField]
		private GrindPatternMinigame3D grindPatternMinigame;

		[Header("Output")]
		[SerializeField]
		private Button3D collectBtn;

		[Header("Guidance")]
		private TabletGuidance3D guidance;

		private CornGrindingStation2 activeStation;

		private bool isDirty;

		private StationState lastObservedState;

		private readonly Dictionary<GameObject, Vector3> indicatorScales;

		private readonly Dictionary<GameObject, int> indicatorTweenIds;

		private readonly HashSet<int> loadedSlots;

		private static readonly string[] TabNames;

		public CornGrindingStation2 ActiveStation => null;

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

		public void Show(CornGrindingStation2 station)
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
	}
}
