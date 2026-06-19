using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ChooseSaveScreen : MenuBase
	{
		private enum Mode
		{
			Save = 0,
			Load = 1
		}

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private Button _deleteButton;

		[SerializeField]
		private Button _saveOrLoadButton;

		[SerializeField]
		private TextMeshProUGUI _saveOrLoadButtonText;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private TMP_InputField _saveFileNameInput;

		[SerializeField]
		private ToggleGroup _saveFileEntryToggleGroup;

		[SerializeField]
		private Transform _saveFileListContainer;

		[SerializeField]
		private GameObject _saveFileListItemPrefab;

		[SerializeField]
		private Image _selectedSaveThumbnailImage;

		[SerializeField]
		private TextMeshProUGUI _selectedSaveNameText;

		[SerializeField]
		private TextMeshProUGUI _selectedSaveDateText;

		[SerializeField]
		private TextMeshProUGUI _selectedSaveLevelText;

		private SaveSystem _saveSystem;

		private LevelList _levelList;

		private MessageBox _messageBox;

		private Action<string> _saveAction;

		private Action<SaveFileHeader> _loadAction;

		private Mode _mode;

		private Texture2D _selectedSaveThumbnailTexture;

		private SaveFileHeader _selectedSave;

		public void Setup(SaveSystem saveSystem, LevelList levelList, MessageBox messageBox, Action<string> saveAction, Action<SaveFileHeader> loadAction)
		{
			_saveSystem = saveSystem;
			_levelList = levelList;
			_messageBox = messageBox;
			_saveAction = saveAction;
			_loadAction = loadAction;
			GameObjectUtils.DestroyChildrenImmediate(_saveFileListContainer.gameObject);
			_deleteButton.onClick.AddListener(DeleteSelectedSave);
			_saveOrLoadButton.onClick.AddListener(CloseAndDoSomethingWithSave);
			_cancelButton.onClick.AddListener(Close);
			_selectedSaveThumbnailTexture = new Texture2D(1, 1);
		}

		public void ShowAsLoadScreen()
		{
			_mode = Mode.Load;
			_titleText.text = ScriptLocalization.Menu_Options.LoadShort_CS;
			_saveOrLoadButtonText.text = ScriptLocalization.Menu_Options.LoadShort_CS;
			GameObjectUtils.SetActive(_saveFileNameInput.gameObject, isActive: false);
			Refresh();
		}

		public void ShowAsSaveScreen()
		{
			_mode = Mode.Save;
			_titleText.text = ScriptLocalization.Menu_Options.SaveShort_CS;
			_saveOrLoadButtonText.text = ScriptLocalization.Menu_Options.SaveShort_CS;
			GameObjectUtils.SetActive(_saveFileNameInput.gameObject, isActive: true);
			Refresh();
		}

		private void Refresh()
		{
			GameObjectUtils.DestroyChildrenImmediate(_saveFileListContainer.gameObject);
			List<SaveFileHeader> saveFiles = _saveSystem.SaveFiles;
			for (int i = 0; i < saveFiles.Count; i++)
			{
				SaveFileHeader saveFile = saveFiles[i];
				UnityEngine.Object.Instantiate(_saveFileListItemPrefab, _saveFileListContainer, worldPositionStays: false).GetComponent<SaveFileListItem>().Setup(saveFile, _saveFileEntryToggleGroup, i == 0, SetSelectedSave);
			}
			if (saveFiles.Count > 0 && !saveFiles[0].IsBroken)
			{
				_selectedSave = saveFiles[0];
				SetSelectedSave(_selectedSave);
			}
			else
			{
				_selectedSave = null;
				DeselectSave();
			}
		}

		private void DeselectSave()
		{
			GameObjectUtils.SetActive(_selectedSaveNameText.gameObject, isActive: false);
			GameObjectUtils.SetActive(_selectedSaveDateText.gameObject, isActive: false);
			GameObjectUtils.SetActive(_selectedSaveLevelText.gameObject, isActive: false);
			GameObjectUtils.SetActive(_selectedSaveThumbnailImage.gameObject, isActive: false);
			if (_mode == Mode.Load)
			{
				GameObjectUtils.SetInteractable(_saveOrLoadButton, interactable: false);
				GameObjectUtils.SetInteractable(_deleteButton, interactable: false);
			}
		}

		private void SetSelectedSave(SaveFileHeader save)
		{
			GameObjectUtils.SetActive(_selectedSaveNameText.gameObject, isActive: true);
			GameObjectUtils.SetActive(_selectedSaveDateText.gameObject, isActive: true);
			GameObjectUtils.SetActive(_selectedSaveLevelText.gameObject, isActive: true);
			GameObjectUtils.SetInteractable(_saveOrLoadButton, interactable: true);
			GameObjectUtils.SetInteractable(_deleteButton, interactable: true);
			_saveFileNameInput.text = save.GetDisplayName();
			_selectedSaveNameText.text = save.GetDisplayName();
			_selectedSaveDateText.text = save.Date.ToString("G");
			LevelConfig levelByID = GetLevelByID(_levelList, save.LevelID);
			_selectedSaveLevelText.text = ((levelByID != null) ? levelByID.GetLocalisedDisplayName() : ScriptLocalization.Menu_Options.UnknownLevel_CS);
			if (save.ThumbnailPNG != null)
			{
				GameObjectUtils.SetActive(_selectedSaveThumbnailImage.gameObject, isActive: true);
				_selectedSaveThumbnailTexture.LoadImage(save.ThumbnailPNG);
				_selectedSaveThumbnailImage.sprite = Sprite.Create(_selectedSaveThumbnailTexture, new Rect(0f, 0f, _selectedSaveThumbnailTexture.width, _selectedSaveThumbnailTexture.height), new Vector2(0f, 0f));
			}
			else
			{
				GameObjectUtils.SetActive(_selectedSaveThumbnailImage.gameObject, isActive: false);
			}
		}

		private static LevelConfig GetLevelByID(LevelList levelList, string levelID)
		{
			foreach (SharedInstance<LevelConfig> level in levelList.Levels)
			{
				if (level.Instance.UniqueId == levelID)
				{
					return level.Instance;
				}
			}
			return null;
		}

		private void DeleteSelectedSave()
		{
			if (_selectedSave != null)
			{
				_messageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages.Delete_Save_File_Title_CS, ScriptLocalization.Menu_Messages.Delete_Save_File_Body_CS, ScriptLocalization.Menu_Messages.OK_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, ActuallyDeleteSelectedSave);
			}
		}

		private void ActuallyDeleteSelectedSave()
		{
			if (_selectedSave != null)
			{
				_saveSystem.Delete(_selectedSave);
				_selectedSave = null;
				Refresh();
			}
		}

		private void CloseAndDoSomethingWithSave()
		{
			GameObjectUtils.DestroyChildrenImmediate(_saveFileListContainer.gameObject);
			if (_mode == Mode.Save)
			{
				_saveAction(_saveFileNameInput.text);
			}
			else
			{
				_loadAction(_selectedSave);
			}
			CloseMenu();
		}

		private void Close()
		{
			GameObjectUtils.DestroyChildrenImmediate(_saveFileListContainer.gameObject);
			CloseMenu();
		}
	}
}
