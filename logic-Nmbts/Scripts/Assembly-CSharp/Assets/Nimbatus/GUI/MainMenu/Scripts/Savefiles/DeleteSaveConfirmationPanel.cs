using System;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class DeleteSaveConfirmationPanel : MonoBehaviour
	{
		private Action _yesAction;

		private Action _noAction;

		private SavefileListEntry _selectedSave;

		private SavefileListUI _parent;

		public void Init(SavefileListUI parent)
		{
			_parent = parent;
			_selectedSave = _parent.SelectedSaveFile;
		}

		public void Show(Action yesAction, Action noAction)
		{
			_yesAction = yesAction;
			_noAction = noAction;
		}

		public void Update()
		{
			if (_parent != null && _selectedSave != null && _selectedSave != _parent.SelectedSaveFile)
			{
				base.gameObject.SetActive(false);
			}
		}

		public void YesClicked()
		{
			Action yesAction = _yesAction;
			if (yesAction != null)
			{
				yesAction();
			}
		}

		public void NoClicked()
		{
			Action noAction = _noAction;
			if (noAction != null)
			{
				noAction();
			}
		}
	}
}
