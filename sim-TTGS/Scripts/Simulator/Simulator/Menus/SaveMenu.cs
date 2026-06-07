using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class SaveMenu : SaveAndLoadBaseMenu
	{
		[Header("Save Menu")]
		[SerializeField]
		private Button m_newSaveButton;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_newSaveButton.onClick.AddListener(OnNewSaveButtonClick_CreateNewSave);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_newSaveButton.onClick.RemoveListener(OnNewSaveButtonClick_CreateNewSave);
		}

		private void CreateNewSave()
		{
			Save(null);
		}

		private void Save(FileInfo fileInfo)
		{
			SaveManager.SetCurrentSaveFile(fileInfo);
			SaveManager.ManualSave();
			Refresh();
		}

		private void OnNewSaveButtonClick_CreateNewSave()
		{
			CreateNewSave();
		}

		protected override bool OnSaveFileClick_CanShowConfirmationPopup(FileInfo fileInfo)
		{
			return true;
		}

		protected override void OnConfirmationPopupValidate(FileInfo fileInfo)
		{
			Save(fileInfo);
		}

		protected override void OnSaveFileClick_DoWithoutConfirmationPopup(FileInfo fileInfo)
		{
			Save(fileInfo);
		}
	}
}
