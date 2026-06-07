using System;
using System.Collections.Generic;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class StompingTablet3D : MonoBehaviour
	{
		[Header("Tablet")]
		[SerializeField]
		private Tablet3D tablet;

		[Header("Input - Load Buttons")]
		[SerializeField]
		private Button3D grapesBtn;

		[SerializeField]
		private Button3D barrelBtn;

		[Header("Input - Indicators")]
		[Tooltip("Shown when the slot IS loaded.")]
		[SerializeField]
		private GameObject grapesCheck;

		[SerializeField]
		private GameObject barrelCheck;

		[Tooltip("Shown when the slot is NOT loaded.")]
		[SerializeField]
		private GameObject grapesUncheck;

		[SerializeField]
		private GameObject barrelUncheck;

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
		private SterilizationMinigame3D sterilizationMinigame;

		[Header("Output")]
		[SerializeField]
		private Button3D collectBtn;

		[Header("Guidance")]
		private TabletGuidance3D guidance;

		private StompingStation2 activeStation;

		private bool isDirty;

		private StationState lastObservedState;

		private readonly Dictionary<GameObject, Vector3> indicatorScales;

		private readonly Dictionary<GameObject, int> indicatorTweenIds;

		private readonly HashSet<int> loadedSlots;

		public StompingStation2 ActiveStation => null;

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

		public void Show(StompingStation2 station)
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

		private void OnTabletHidden()
		{
		}
	}
}
