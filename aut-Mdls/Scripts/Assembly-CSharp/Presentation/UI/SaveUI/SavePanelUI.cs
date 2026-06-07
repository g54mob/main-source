using System;
using System.IO;
using Data.SaveData.PersistentSOs;
using Events.UI.Overlays;
using Logic.Factory;
using Presentation.Locators;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Enums;

namespace Presentation.UI.SaveUI
{
	public class SavePanelUI : MonoBehaviour
	{
		[SerializeField]
		private GameObject _existingSaveParent;

		[SerializeField]
		private GameObject _newSaveParent;

		[SerializeField]
		private RawImage _thumbnailImage;

		[SerializeField]
		private TextMeshProUGUI _saveNameText;

		[SerializeField]
		private TextMeshProUGUI _savePlayTimeText;

		[SerializeField]
		private TextMeshProUGUI _saveLastModifiedText;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private Button _deleteButton;

		[SerializeField]
		private UIMenuManagerLocator _menuManagerLocator;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _createSaveMenuUILocator;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private SavingSpinnerSO _savingSpinnerSO;

		private bool _isDevMap;

		private string _fullSavePath;

		private SaveMenu _saveMenu;

		public void SetNewSavePanel(bool isDevMap)
		{
			_isDevMap = isDevMap;
			_existingSaveParent.SetActive(value: false);
			_newSaveParent.SetActive(value: true);
			_button.onClick.AddListener(CreateNewSave);
		}

		public void SetExistingSavePanel(string saveName, string fullSavePath, SaveInfoPersistentSO saveInfo, SaveMenu saveMenu)
		{
			_saveMenu = saveMenu;
			_saveNameText.SetText(saveName.UnsanitizeSpaces());
			TimeSpan timeSpan = TimeSpan.FromMinutes(saveInfo.TotalPlayTimeMins);
			_savePlayTimeText.SetText(string.Format(LocalizationUtility.GetLocalizedText("LoadSave.PlayTime"), (int)timeSpan.TotalHours, timeSpan.Minutes));
			_saveLastModifiedText.SetText(string.Format("{0} {1} {2}", LocalizationUtility.GetLocalizedText("LoadSave.LastModified"), saveInfo.LastModifiedTime.ToShortDateString(), saveInfo.LastModifiedTime.ToShortTimeString()));
			_existingSaveParent.SetActive(value: true);
			_newSaveParent.SetActive(value: false);
			_fullSavePath = fullSavePath;
			_button.onClick.AddListener(SaveFileButtonPressed);
			_deleteButton.onClick.AddListener(DeleteSave);
			LoadThumbnail(fullSavePath);
		}

		public void SetExistingSavePanel(string saveName, string fullSavePath, SaveMenu saveMenu)
		{
			_saveMenu = saveMenu;
			_saveNameText.SetText(saveName.UnsanitizeSpaces());
			_savePlayTimeText.SetText(string.Format(LocalizationUtility.GetLocalizedText("LoadSave.PlayTime"), "-", "-"));
			_saveLastModifiedText.SetText(string.Format("{0} -", LocalizationUtility.GetLocalizedText("LoadSave.LastModified")));
			_existingSaveParent.SetActive(value: true);
			_newSaveParent.SetActive(value: false);
			_fullSavePath = fullSavePath;
			_button.onClick.AddListener(SaveFileButtonPressed);
			_deleteButton.onClick.AddListener(DeleteSave);
			LoadThumbnail(fullSavePath);
		}

		private void LoadThumbnail(string savePath)
		{
			string path = Path.Combine(savePath, "Thumbnail.png");
			if (File.Exists(path))
			{
				byte[] data = File.ReadAllBytes(path);
				Texture2D texture2D = new Texture2D(2, 2);
				texture2D.LoadImage(data);
				_thumbnailImage.texture = texture2D;
			}
		}

		private void DeleteSave()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("LoadSave.DeleteSaveWarning", Sizes.S, OnClearSave, showCancelButton: true, OnCancelClearSave)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.AcceptButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void OnClearSave()
		{
			SaveSystem.DeleteDirectory(_fullSavePath);
			_saveMenu.RefreshPanels();
		}

		private void OnCancelClearSave()
		{
		}

		private void SaveFileButtonPressed()
		{
			MenuModalDialogDto menuModalDialogDto = new MenuModalDialogDto("LoadSave.OverwriteSaveWarning", Sizes.S, SaveFile, showCancelButton: true);
			menuModalDialogDto.OverrideSuccessButtonTextKey = "ModalGeneric.YesButton";
			menuModalDialogDto.OverrideCancelButtonTextKey = "ModalGeneric.NoButton";
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(menuModalDialogDto));
		}

		private void SaveFile()
		{
			_savingSpinnerSO.ShowSavingSpinner();
			_factorySaver.SaveFactory(_fullSavePath);
			_menuManagerLocator.UIMenuManager.CloseAllOpenMenus();
		}

		private void CreateNewSave()
		{
			_showUIMenuEvent.Fire(new UIMenuMenuData(_createSaveMenuUILocator.UIMenu));
			(_createSaveMenuUILocator.UIMenu as CreateSaveMenu).SetShowDevMapToggleState(_isDevMap);
		}
	}
}
