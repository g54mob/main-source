using System.Collections.Generic;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class TabletGuidance3D : MonoBehaviour
	{
		[Header("Pulse Settings")]
		[SerializeField]
		private float pulseScale;

		[SerializeField]
		private float pulseDuration;

		private Tablet3D tablet;

		private GameObject[] tabButtonObjects;

		private GameObject[] requiredInputButtons;

		private GameObject startButtonObject;

		private GameObject collectButtonObject;

		private GameObject[] minigamePrimaryElements;

		private BaseBreweryStation activeStation;

		private bool isDirty;

		private bool isSetUp;

		private bool anyPulseFailed;

		private readonly HashSet<GameObject> tabButtonPulseTargets;

		private readonly HashSet<GameObject> minigamePulseTargets;

		private readonly HashSet<int> minigameGuidanceDismissed;

		public void Setup(Tablet3D tablet, Button3D startButton, Button3D collectButton, Button3D[] requiredInputs, params GameObject[] minigameElements)
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		public void Bind(BaseBreweryStation station)
		{
		}

		public void Unbind()
		{
		}

		public void OnMinigameActivated(int minigameIndex)
		{
		}

		public void OnMinigameInteracted(int minigameIndex)
		{
		}

		private bool RefreshGuidance()
		{
			return false;
		}

		private int GetGuidedTabIndex(StationState state)
		{
			return 0;
		}

		private bool AreAllRequiredInputsLoaded()
		{
			return false;
		}

		private void PulseEmptyRequiredInputs()
		{
		}

		private void PulseTabButton(int tabIndex)
		{
		}

		private void PulseTabButtonTarget(GameObject go)
		{
		}

		private void StartPulse(GameObject go)
		{
		}

		private void StopPulse(GameObject go)
		{
		}

		private void StopTabButtonPulses()
		{
		}

		private void StopAllPulses()
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

		private void OnTabletShown()
		{
		}

		private void OnTabletHidden()
		{
		}

		private void OnTabChanged(int newTabIndex)
		{
		}
	}
}
