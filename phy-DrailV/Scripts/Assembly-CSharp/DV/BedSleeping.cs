using System.ComponentModel;
using DV.CabControls;
using DV.UI;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class BedSleeping : MonoBehaviour
	{
		public float fadeTime = 1.3f;

		public float waitBeforeUnfade = 1.5f;

		public Transform pillowTarget;

		private ButtonBase bedInteractionButton;

		private SleepingUIController uiController;

		private BedSleepingController Controller => SingletonBehaviour<BedSleepingController>.Instance;

		private bool IsSleeping => Controller.IsSleeping;

		private void Start()
		{
			bedInteractionButton = GetComponentInChildren<ButtonBase>(includeInactive: true);
			bedInteractionButton.Used += OnButtonClicked;
			UpdateButtonInteraction();
			Globals.G.GameParams.PropertyChanged += OnGameParamsChanged;
		}

		private void OnDestroy()
		{
			if (bedInteractionButton != null)
			{
				bedInteractionButton.Used -= OnButtonClicked;
			}
			Globals.G.GameParams.PropertyChanged -= OnGameParamsChanged;
		}

		private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (!(e.PropertyName != "SleepCooldownInHours"))
			{
				UpdateButtonInteraction();
			}
		}

		private void UpdateButtonInteraction()
		{
			bool interactionAllowed = Globals.G.GameParams.SleepCooldownInHours >= 0;
			bedInteractionButton.InteractionAllowed = interactionAllowed;
		}

		private void OnButtonClicked()
		{
			if (IsSleeping || (bool)uiController)
			{
				return;
			}
			if (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.BedSleeping, out var element))
			{
				Debug.LogError(string.Format("Couldn't get {0} element from {1}", CanvasController.ElementType.BedSleeping, "CanvasController"));
				return;
			}
			uiController = element.reference.GetComponentInChildren<SleepingUIController>(includeInactive: true);
			if (!uiController)
			{
				Debug.LogError("Couldn't get SleepingUIController from CanvasController");
				return;
			}
			uiController.Show(Controller.GetSleepingData());
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.BedSleeping, on: true);
			SetupMenuListeners(on: true);
			Controller.TogglePlayerMovement(allowMovement: false);
		}

		private void SetupMenuListeners(bool on)
		{
			if (!(uiController == null))
			{
				uiController.SleepRequested -= OnSleepRequested;
				uiController.CloseRequested -= OnCloseRequested;
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= OnCanvasElementToggled;
				if (on)
				{
					uiController.SleepRequested += OnSleepRequested;
					uiController.CloseRequested += OnCloseRequested;
					SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += OnCanvasElementToggled;
				}
			}
		}

		private void OnSleepRequested(float amountOfSecondsToSleep)
		{
			Controller.Sleep(amountOfSecondsToSleep, fadeTime, waitBeforeUnfade, this);
			SetupMenuListeners(on: false);
			uiController = null;
		}

		private void OnCloseRequested()
		{
			Controller.TogglePlayerMovement(allowMovement: true);
			SetupMenuListeners(on: false);
			uiController = null;
		}

		private void OnCanvasElementToggled(ACanvasController<CanvasController.ElementType>.Element obj)
		{
			if (!SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(CanvasController.ElementType.BedSleeping))
			{
				OnCloseRequested();
			}
		}
	}
}
