using System;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_ConfirmationDialogue : MonoBehaviour
	{
		[SerializeField]
		private Button confirmButton;

		[SerializeField]
		private Button cancelButton;

		public event Action OnConfirmed;

		public event Action OnCanceled;

		private void OnEnable()
		{
			confirmButton.onClick.AddListener(OnConfirmButtonClick);
			cancelButton.onClick.AddListener(OnCancelButtonClick);
		}

		private void OnDisable()
		{
			confirmButton.onClick.RemoveListener(OnConfirmButtonClick);
			cancelButton.onClick.RemoveListener(OnCancelButtonClick);
		}

		private void OnConfirmButtonClick()
		{
			this.OnConfirmed?.Invoke();
		}

		private void OnCancelButtonClick()
		{
			this.OnCanceled?.Invoke();
		}
	}
}
