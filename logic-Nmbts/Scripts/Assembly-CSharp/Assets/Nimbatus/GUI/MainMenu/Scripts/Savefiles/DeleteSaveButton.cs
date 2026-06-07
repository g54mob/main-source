using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class DeleteSaveButton : MonoBehaviour
	{
		public DeleteSaveConfirmationPanel DeletePanel;

		private SavefileListUI _parent;

		private SavefileListEntry _selectedSave;

		public void Init(SavefileListUI parent)
		{
			_parent = parent;
			_selectedSave = _parent.SelectedSaveFile;
		}

		public void OnClick()
		{
			if (_selectedSave != null)
			{
				DeletePanel.gameObject.SetActive(true);
				DeletePanel.Init(_parent);
				DeletePanel.Show(Yes, No);
			}
		}

		private void No()
		{
			DeletePanel.gameObject.SetActive(false);
		}

		private void Yes()
		{
			if (_parent.SelectedSaveFile != null)
			{
				SaveManager.DeleteSave(_parent.SelectedSaveFile.Save);
				_parent.SelectedSaveFile = null;
				_parent.FillupSaves();
			}
			DeletePanel.gameObject.SetActive(false);
		}
	}
}
