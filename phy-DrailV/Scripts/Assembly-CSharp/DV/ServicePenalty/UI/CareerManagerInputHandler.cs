using System.Collections;
using DV.CabControls;
using DV.Common;
using UnityEngine;

namespace DV.ServicePenalty.UI
{
	public class CareerManagerInputHandler : MonoBehaviour
	{
		public DisplayScreenSwitcher screenController;

		public GameObject nonVrMouseInput;

		[Header("Buttons")]
		public GameObject upButtonGO;

		public GameObject downButtonGO;

		public GameObject cancelButtonGO;

		public GameObject confirmButtonGO;

		public GameObject printInfoButtonGO;

		private ButtonBase upButton;

		private ButtonBase downButton;

		private ButtonBase cancelButton;

		private ButtonBase confirmButton;

		private ButtonBase printInfoButton;

		private void Start()
		{
			if (!VRManager.IsVREnabled())
			{
				nonVrMouseInput.gameObject.SetActive(value: true);
			}
		}

		protected void OnEnable()
		{
			StartCoroutine(WireUpButtons());
		}

		protected void OnDisable()
		{
			StopAllCoroutines();
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				upButton.Used += OnUpPressed;
				downButton.Used += OnDownPressed;
				cancelButton.Used += OnCancelPressed;
				confirmButton.Used += OnConfirmPressed;
				printInfoButton.Used += OnPrintInfoPressed;
				return;
			}
			if (upButton != null)
			{
				upButton.Used -= OnUpPressed;
			}
			if (downButton != null)
			{
				downButton.Used -= OnDownPressed;
			}
			if (cancelButton != null)
			{
				cancelButton.Used -= OnCancelPressed;
			}
			if (confirmButton != null)
			{
				confirmButton.Used -= OnConfirmPressed;
			}
			if (printInfoButton != null)
			{
				printInfoButton.Used -= OnPrintInfoPressed;
			}
		}

		private IEnumerator WireUpButtons()
		{
			while ((upButton = upButtonGO.GetComponent<ButtonBase>()) == null)
			{
				yield return null;
			}
			while ((downButton = downButtonGO.GetComponent<ButtonBase>()) == null)
			{
				yield return null;
			}
			while ((cancelButton = cancelButtonGO.GetComponent<ButtonBase>()) == null)
			{
				yield return null;
			}
			while ((confirmButton = confirmButtonGO.GetComponent<ButtonBase>()) == null)
			{
				yield return null;
			}
			while ((printInfoButton = printInfoButtonGO.GetComponent<ButtonBase>()) == null)
			{
				yield return null;
			}
			SetupListeners(on: true);
		}

		private void OnUpPressed()
		{
			if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseCareerManager))
			{
				screenController.HandleInput(InputAction.Up);
			}
		}

		private void OnDownPressed()
		{
			if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseCareerManager))
			{
				screenController.HandleInput(InputAction.Down);
			}
		}

		private void OnCancelPressed()
		{
			if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseCareerManager))
			{
				screenController.HandleInput(InputAction.Cancel);
			}
		}

		private void OnConfirmPressed()
		{
			if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseCareerManager))
			{
				screenController.HandleInput(InputAction.Confirm);
			}
		}

		private void OnPrintInfoPressed()
		{
			if (GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseCareerManager))
			{
				screenController.HandleInput(InputAction.PrintInfo);
			}
		}
	}
}
