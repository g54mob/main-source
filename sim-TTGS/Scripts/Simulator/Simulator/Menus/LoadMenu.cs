using System.IO;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator.Menus
{
	public class LoadMenu : SaveAndLoadBaseMenu
	{
		[Header("Delete confirmation popup")]
		[SerializeField]
		private MenuConfirmationPopup.Terms m_deleteConfirmationPopupTerms;

		private void Load(FileInfo fileInfo)
		{
			SaveManager.SetCurrentSaveFile(fileInfo);
			if (World.Loaded)
			{
				ReloadWorld();
			}
			else
			{
				LoadWorld();
			}
			static void LoadWorld()
			{
				TransientManager<SceneManager>.Instance.LoadScene(SceneManager.Map.WORLD);
			}
			static void ReloadWorld()
			{
				World.Quit();
				TransientManager<SceneManager>.Instance.ReloadScene(SceneManager.Map.WORLD);
			}
		}

		protected override void OnConfirmationPopupValidate(FileInfo fileInfo)
		{
			Load(fileInfo);
		}

		protected override bool OnSaveFileClick_CanShowConfirmationPopup(FileInfo fileInfo)
		{
			return World.Loaded;
		}

		protected override void OnSaveFileClick_DoWithoutConfirmationPopup(FileInfo fileInfo)
		{
			Load(fileInfo);
		}

		protected override void OnInstantiateSaveFile(UI_SaveAndLoadBaseFile saveFile)
		{
			base.OnInstantiateSaveFile(saveFile);
			((UI_LoadFile)saveFile).OnDeleteButtonClickEvent += OnDeleteButtonClick_ShowConfirmationPopup;
		}

		private void OnDeleteButtonClick_ShowConfirmationPopup(FileInfo fileInfo)
		{
			Menus.ConfirmationPopup.Show(m_deleteConfirmationPopupTerms, delegate
			{
				OnDeleteConfirmationPopupValidate(fileInfo);
			});
		}

		private void OnDeleteConfirmationPopupValidate(FileInfo fileInfo)
		{
			SaveManager.SetCurrentSaveFile(fileInfo);
			SaveManager.DeleteSelectedSaveFile();
			Refresh();
		}
	}
}
