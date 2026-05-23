using System.Collections.Generic;
using System.IO;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events.UI.Overlays;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Enums;

namespace Presentation.UI.SaveUI
{
	public class LoadAndSaveFileButton : MonoBehaviour
	{
		[SerializeField]
		private GameObject _activeBg;

		[SerializeField]
		private GameObject _existingSaveParent;

		[SerializeField]
		private List<GameObject> _notSupportedParents;

		[SerializeField]
		private List<GameObject> _oldMapParents;

		[Space]
		[SerializeField]
		private Image _isDemoSaveIcon;

		[SerializeField]
		private TextMeshProUGUI _saveNameText;

		[SerializeField]
		private TextInfoPanelContent _saveNameInfoPanelContent;

		[SerializeField]
		private TextMeshProUGUI _saveLastModifiedText;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private Button _deleteButton;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		[SerializeField]
		private Color _saveNameColorDefault;

		[SerializeField]
		private Color _autosaveNameColor;

		[SerializeField]
		private GameObject _saveGameLocked;

		private SaveInfoPersistentSO _saveInfoPersistentSO;

		private LoadMenu _loadMenu;

		private bool _isActive;

		private SaveFile _saveFile;

		private string _saveName;

		private string _fullSavePath;

		private bool _hasOldMap;

		private bool _isAutosave;

		public string SaveName => _saveName;

		public SaveFile SaveFile => _saveFile;

		public SaveInfoPersistentSO SaveInfoPersistentSO => _saveInfoPersistentSO;

		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				_isActive = value;
				_activeBg.SetActive(value);
			}
		}

		private void Awake()
		{
			_deleteButton.onClick.AddListener(DeleteSave);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveAllListeners();
			_deleteButton.onClick.RemoveListener(DeleteSave);
		}

		public void SetExistingButton(SaveFile saveFile, string saveName, string savePath, SaveInfoPersistentSO saveInfo, LoadMenu loadMenu, bool isAutosave = false)
		{
			_saveFile = saveFile;
			_isAutosave = isAutosave;
			_loadMenu = loadMenu;
			saveName = (string.IsNullOrEmpty(saveInfo.GetDisplaySaveName(saveFile)) ? saveName.SanitizeSpaces() : saveInfo.GetDisplaySaveName(saveFile));
			_saveName = saveName;
			_fullSavePath = savePath;
			_saveInfoPersistentSO = saveInfo;
			SetExistingUI(saveName, savePath);
		}

		public void SetExistingButton(SaveFile saveFile, string saveName, string savePath, LoadMenu loadMenu)
		{
			_saveFile = saveFile;
			_isAutosave = false;
			_loadMenu = loadMenu;
			_saveName = saveName;
			_fullSavePath = savePath;
			_saveInfoPersistentSO = null;
			SetExistingUI(saveName, savePath);
		}

		private void SetExistingUI(string saveName, string savePath)
		{
			_saveNameText.SetText(saveName.UnsanitizeSpaces());
			_saveNameInfoPanelContent.UpdateContent(saveName.UnsanitizeSpaces());
			_saveNameText.color = (_isAutosave ? _autosaveNameColor : _saveNameColorDefault);
			if (_saveInfoPersistentSO == null)
			{
				_saveLastModifiedText.SetText("-");
			}
			else
			{
				_saveLastModifiedText.SetText($"{_saveInfoPersistentSO.LastModifiedTime.ToShortDateString()} {_saveInfoPersistentSO.LastModifiedTime.ToShortTimeString()}");
				_isDemoSaveIcon.gameObject.SetActive(_saveInfoPersistentSO.IsDemoSave);
				if (_isAutosave)
				{
					string localizedText = LocalizationUtility.GetLocalizedText("AutoSave.Autosave");
					_saveNameText.SetText(localizedText + " (" + _saveInfoPersistentSO.AutoSaveSourceSaveName.UnsanitizeSpaces() + ")");
				}
			}
			bool flag = _saveInfoPersistentSO != null && _saveInfoPersistentSO.IsSupported;
			_existingSaveParent.SetActive(value: true);
			foreach (GameObject notSupportedParent in _notSupportedParents)
			{
				notSupportedParent.SetActive(!flag);
			}
			_hasOldMap = flag && _saveInfoPersistentSO.IsMapOld;
			foreach (GameObject oldMapParent in _oldMapParents)
			{
				oldMapParent.SetActive(_hasOldMap);
			}
			_deleteButton.gameObject.SetActive(_loadMenu.IsStartScene || Path.GetFullPath(_currentSavePath.Value) != Path.GetFullPath(savePath));
			if (flag)
			{
				_button.onClick.AddListener(ShowSaveFileInfo);
			}
			else
			{
				_button.interactable = false;
			}
			if (!_saveInfoPersistentSO.IsDemoSave)
			{
				_saveGameLocked.SetActive(value: true);
				_button.interactable = false;
				_deleteButton.interactable = false;
			}
		}

		private void ShowSaveFileInfo()
		{
			_loadMenu.ShowSaveFileInfo(this, _saveFile, _isAutosave);
		}

		private void DeleteSave()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("LoadSave.DeleteSaveWarning", Sizes.S, OnClearSave, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.AcceptButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void OnClearSave()
		{
			SaveSystem.DeleteDirectory(_fullSavePath);
			_loadMenu.RefreshButtons(_isActive);
		}
	}
}
