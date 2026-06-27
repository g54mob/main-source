using System;
using Restory.Gameplay.EmailSystems;
using Restory.UserInterface.ElementPresets;
using Restory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_MailClientFolderButton : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private TMP_Text unreadEmailsCountText;

		[SerializeField]
		private GUI_PresetSwitcher selectionPresetSwitcher;

		[SerializeField]
		private GUI_PresetSwitcher unreadEmailsPresetSwitcher;

		[SerializeField]
		private EmailFolders emailFolder;

		private bool isSelected;

		public EmailFolders EmailFolder => emailFolder;

		public event Action<GUI_MailClientFolderButton> OnButtonClicked;

		private void OnDisable()
		{
			if (button.MonoShellExists())
			{
				button.onClick.RemoveListener(ResolveButtonClicked);
			}
		}

		public void Activate()
		{
			button.onClick.AddListener(ResolveButtonClicked);
		}

		public void Deactivate()
		{
			button.onClick.RemoveListener(ResolveButtonClicked);
		}

		public void ChangeSelection(bool shouldBeSelected)
		{
			isSelected = shouldBeSelected;
			selectionPresetSwitcher.ActivatePreset((!isSelected) ? PresetName.Normal : PresetName.Selected);
		}

		public void UpdateFolderContents(int unreadEmailsCount)
		{
			unreadEmailsPresetSwitcher.ActivatePreset((unreadEmailsCount <= 0) ? PresetName.Normal : PresetName.Warning);
			unreadEmailsCountText.text = $"({unreadEmailsCount})";
		}

		private void ResolveButtonClicked()
		{
			this.OnButtonClicked?.Invoke(this);
		}
	}
}
