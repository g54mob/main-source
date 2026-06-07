using Data.GameState;
using Data.SaveData;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils.Enums;

namespace Presentation.UI.SaveUI
{
	public class CampaignClearSaveUI : MonoBehaviour
	{
		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private Button _clearButton;

		[SerializeField]
		private FactoryClearer _factoryClearer;

		[SerializeField]
		private StringEvent _levelFinishedLoadingEvent;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private PauseStateData _pauseState;

		[SerializeField]
		private PersistentSOLibrary _persistentSOLibrary;

		private void Start()
		{
			_clearButton.onClick.AddListener(OpenPopup);
		}

		private void OnDestroy()
		{
			_clearButton.onClick.RemoveListener(OpenPopup);
		}

		private void OpenPopup()
		{
			MenuModalDialogDto menuModalDialogDto = new MenuModalDialogDto("ModalMisc.ClearSaveWarning", Sizes.S, OnClearSave, showCancelButton: true, OnCancelClearSave);
			menuModalDialogDto.OverrideSuccessButtonTextKey = "ModalGeneric.AcceptButton";
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(menuModalDialogDto));
		}

		private void OnClearSave()
		{
			SaveSystem.DeleteDirectory(SaveSystem.CreateFullLevelsSavePath("Level"));
			_factoryClearer.ClearLevel();
			_persistentSOLibrary.ResetPersistentSOs();
			_levelFinishedLoadingEvent.Fire(SceneManager.GetActiveScene().name);
		}

		private void OnCancelClearSave()
		{
		}
	}
}
