#define LOG_LEVEL_VERBOSE
using System;
using System.Globalization;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class BackupSaveBox : MonoBehaviour
	{
		public enum BackupType
		{
			Career = 0,
			Level = 1
		}

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _bodyText;

		[SerializeField]
		private TextMeshProUGUI _loadBackupText;

		[SerializeField]
		private TextMeshProUGUI _restartText;

		[SerializeField]
		private DynamicButton _loadBackupButton;

		[SerializeField]
		private DynamicButton _restartButton;

		[SerializeField]
		private Sprite _noAvailableScreenshot;

		[Header("Career preview panel")]
		[SerializeField]
		private GameObject _careerPreviewRoot;

		[SerializeField]
		private Image _careerScreenshot;

		[SerializeField]
		private TextMeshProUGUI _foundationName;

		[SerializeField]
		private TextMeshProUGUI _dataTime;

		[SerializeField]
		private TextMeshProUGUI _starsText;

		[SerializeField]
		private TextMeshProUGUI _silverText;

		[SerializeField]
		private TextMeshProUGUI _foundationValueText;

		[Header("Level preview panel")]
		[SerializeField]
		private GameObject _levelPreviewRoot;

		[SerializeField]
		private Image _levelScreenshot;

		[SerializeField]
		private TextMeshProUGUI _balanceValueLabel;

		[SerializeField]
		private TextMeshProUGUI _hospitalValueLabel;

		[SerializeField]
		private ProgressBarMaskable _reputationProgressBar;

		[SerializeField]
		private ProgressBarMaskable _prestigeProgressBar;

		[SerializeField]
		private TMP_Text _prestigeValueLabel;

		[SerializeField]
		private TMP_Text _saveDateAndTimeLabel;

		[Header("Career locstrings")]
		[SerializeField]
		private LocalisedString _corruptedCareerTitle;

		[SerializeField]
		private LocalisedString _corruptedCareerBody;

		[SerializeField]
		private LocalisedString _corruptedCareerLoadBackup;

		[SerializeField]
		private LocalisedString _corruptedCareerRestart;

		[Header("Level locstrings")]
		[SerializeField]
		private LocalisedString _corruptedLevelTitle;

		[SerializeField]
		private LocalisedString _corruptedLevelBody;

		[SerializeField]
		private LocalisedString _corruptedLevelLoadBackup;

		[SerializeField]
		private LocalisedString _corruptedLevelRestart;

		[Header("No backup locstrings")]
		[SerializeField]
		private LocalisedString _noBackupTitle;

		[SerializeField]
		private LocalisedString _noBackupCareerBody;

		[SerializeField]
		private LocalisedString _noBackupLevelBody;

		public Action OnBackupHandled;

		private App _app;

		private BackupType _type;

		private LevelConfig _levelConfig;

		private int _slot = -1;

		private Texture2D _thumbnailTexture;

		public void Initialise(App app)
		{
			_app = app;
			_loadBackupButton.onPrimaryDown.AddListener(LoadBackup);
			_restartButton.onPrimaryDown.AddListener(delegate
			{
				_app.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages.Delete_Save_File_Title_CS, ScriptLocalization.Menu_Messages.Delete_Save_File_Body_CS, ScriptLocalization.Menu_Messages.OK_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, RestartSave);
			});
			_thumbnailTexture = new Texture2D(1, 1, TextureFormat.DXT1, mipChain: false, linear: false);
		}

		public void ShowCareerBackup(int slot, MetagameSaveHeader backupCareerHeader)
		{
			_type = BackupType.Career;
			_slot = slot;
			_titleText.text = _corruptedCareerTitle.Translation;
			_bodyText.text = _corruptedCareerBody.Translation;
			_restartText.text = _corruptedCareerRestart.Translation;
			_loadBackupText.text = _corruptedCareerLoadBackup.Translation;
			if (backupCareerHeader == null)
			{
				Logging.Warning(LogChannels.Save, "Deleting corrupt career save {0}", slot);
				_app.SaveSystem.DeleteMetagameAndLevelSavesInSlot(_slot);
				ShowNoAvailableBackup();
				return;
			}
			GameObjectUtils.SetActive(_careerPreviewRoot, isActive: true);
			GameObjectUtils.SetActive(_levelPreviewRoot, isActive: false);
			if (_careerScreenshot != null)
			{
				if (backupCareerHeader.ThumbnailPNG != null)
				{
					_thumbnailTexture.LoadImage(backupCareerHeader.ThumbnailPNG);
					_careerScreenshot.overrideSprite = Sprite.Create(_thumbnailTexture, new Rect(0f, 0f, _thumbnailTexture.width, _thumbnailTexture.height), Vector2.zero);
				}
				else
				{
					_careerScreenshot.overrideSprite = _noAvailableScreenshot;
				}
			}
			_foundationName.text = backupCareerHeader.OrganisationName;
			_dataTime.text = backupCareerHeader.Date.ToString(CultureInfo.CurrentCulture);
			_starsText.text = StringUtils.FormatNumber(backupCareerHeader.TotalStars);
			_silverText.text = StringUtils.FormatNumber(backupCareerHeader.TotalSilver);
			_foundationValueText.text = StringUtils.FormatNumber(backupCareerHeader.TotalFoundationValue);
			Show();
		}

		public void ShowLevelBackup(LevelConfig config, SaveFileHeader backupLevelHeader)
		{
			_type = BackupType.Level;
			_levelConfig = config;
			_titleText.text = _corruptedLevelTitle.Translation;
			_bodyText.text = _corruptedLevelBody.Translation;
			_restartText.text = _corruptedLevelRestart.Translation;
			_loadBackupText.text = _corruptedLevelLoadBackup.Translation;
			if (backupLevelHeader == null)
			{
				Logging.Warning(LogChannels.Save, "Deleting corrupt level save {0}", config.UniqueId);
				_app.SaveSystem.DeleteLevelSave(config.UniqueId, _app.SaveSystem.CurrentSaveSlot);
				ShowNoAvailableBackup();
				return;
			}
			if (_levelScreenshot != null)
			{
				if (backupLevelHeader.ThumbnailPNG != null)
				{
					_thumbnailTexture.LoadImage(backupLevelHeader.ThumbnailPNG);
					_levelScreenshot.overrideSprite = Sprite.Create(_thumbnailTexture, new Rect(0f, 0f, _thumbnailTexture.width, _thumbnailTexture.height), Vector2.zero);
				}
				else
				{
					_careerScreenshot.overrideSprite = _noAvailableScreenshot;
				}
			}
			_balanceValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(backupLevelHeader.Balance);
			_hospitalValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(backupLevelHeader.HospitalValue);
			_reputationProgressBar.SetProgressSmooth(backupLevelHeader.Reputation);
			_prestigeProgressBar.SetProgressSmooth(backupLevelHeader.HospitalLevelProgress);
			_prestigeValueLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, backupLevelHeader.HospitalLevel);
			_saveDateAndTimeLabel.text = backupLevelHeader.Date.ToString(CultureInfo.CurrentCulture);
			GameObjectUtils.SetActive(_careerPreviewRoot, isActive: false);
			GameObjectUtils.SetActive(_levelPreviewRoot, isActive: true);
			Show();
		}

		private void Show()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
		}

		private void ShowNoAvailableBackup()
		{
			string bodyText = string.Empty;
			switch (_type)
			{
			case BackupType.Career:
				bodyText = _noBackupCareerBody.Translation;
				break;
			case BackupType.Level:
				bodyText = _noBackupLevelBody.Translation;
				break;
			}
			_app.MessageBox.Show(_noBackupTitle.Translation, bodyText, ScriptLocalization.Menu_Messages.OK_Button_CS, Hide);
		}

		private void LoadBackup()
		{
			switch (_type)
			{
			case BackupType.Career:
				_app.SaveSystem.ApplyBackupCareerSave(_slot);
				break;
			case BackupType.Level:
				_app.SaveSystem.ApplyBackupLevelSave(_levelConfig.UniqueId);
				break;
			default:
				Logging.Error($"Unhandled BackupType {_type}");
				break;
			}
			Hide();
		}

		private void RestartSave()
		{
			switch (_type)
			{
			case BackupType.Career:
				_app.SaveSystem.DeleteMetagameAndLevelSavesInSlot(_slot);
				break;
			case BackupType.Level:
				_app.SaveSystem.DeleteLevelSave(_levelConfig.UniqueId, _app.SaveSystem.CurrentSaveSlot);
				break;
			default:
				Logging.Error($"Unhandled BackupType {_type}");
				break;
			}
			Hide();
		}

		private void Hide()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
			OnBackupHandled.InvokeSafe();
		}
	}
}
