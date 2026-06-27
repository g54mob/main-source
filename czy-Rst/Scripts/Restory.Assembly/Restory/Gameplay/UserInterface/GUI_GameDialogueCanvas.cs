using Restory.Gameplay.Common;
using Restory.Gameplay.GameView;
using Restory.UserInterface;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_GameDialogueCanvas : MonoBehaviour, IActiveStateSwitchRequester
	{
		[SerializeField]
		private GUI_ConfirmationDialogue confirmationDialogue;

		[SerializeField]
		private GUI_ExplanationDialogue explanationDialogue;

		[SerializeField]
		private GUI_LocalisedText confirmationLocalisedText;

		[SerializeField]
		private GameObject blockingCurtain;

		[SerializeField]
		private string defaultConfirmationTextLocalizationKey;

		private CameraDirectionSwitcher cameraDirectionSwitcher;

		public GUI_ConfirmationDialogue ConfirmationDialogue => confirmationDialogue;

		public GUI_ExplanationDialogue ExplanationDialogue => explanationDialogue;

		[Inject]
		private void Construct(CameraDirectionSwitcher cameraDirectionSwitcher)
		{
			this.cameraDirectionSwitcher = cameraDirectionSwitcher;
		}

		private void OnEnable()
		{
			cameraDirectionSwitcher.AddBlocker(this);
		}

		private void OnDisable()
		{
			cameraDirectionSwitcher.RemoveBlocker(this);
		}

		public void SetConfirmationTextToDefault()
		{
			confirmationLocalisedText.LocalizationID = defaultConfirmationTextLocalizationKey;
		}

		public void SetConfirmationText(string confirmationTextLocalizationKey)
		{
			confirmationLocalisedText.LocalizationID = confirmationTextLocalizationKey;
		}

		public void ActivateConfirmationDialogue()
		{
			confirmationDialogue.gameObject.SetActive(value: true);
			explanationDialogue.gameObject.SetActive(value: false);
			base.gameObject.SetActive(value: true);
			blockingCurtain.SetActive(value: true);
		}

		public void ActivateExplanationDialogue()
		{
			confirmationDialogue.gameObject.SetActive(value: false);
			explanationDialogue.gameObject.SetActive(value: true);
			base.gameObject.SetActive(value: true);
		}

		public void Deactivate()
		{
			confirmationDialogue.gameObject.SetActive(value: false);
			explanationDialogue.gameObject.SetActive(value: false);
			blockingCurtain.SetActive(value: false);
			base.gameObject.SetActive(value: false);
		}
	}
}
