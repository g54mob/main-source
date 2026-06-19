using System.IO;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.ExtContent
{
	[DontSave]
	public class ExtContentUIMusicItemRow : MonoBehaviour
	{
		[SerializeField]
		private GameObject _panelTrackItemButtons;

		[SerializeField]
		private GameObject _panelMainTrackItem;

		[SerializeField]
		private GameObject _goMainTrackItemBGUnselected;

		[SerializeField]
		private GameObject _goMainTrackItemBGSelected;

		[SerializeField]
		private GameObject _goMainTrackItemBGDisabled;

		[SerializeField]
		private TMP_Text _textSongTitle;

		[SerializeField]
		private TMP_Text _textArtistName;

		[SerializeField]
		private DynamicButton _buttonRow;

		[SerializeField]
		private DynamicButton _buttonRemove;

		[SerializeField]
		private DynamicButton _buttonPreviewPlay;

		[SerializeField]
		private DynamicButton _buttonPreviewPlayDisabled;

		[SerializeField]
		private DynamicButton _buttonPreviewPause;

		[SerializeField]
		private Image _imageUpdatePendingIndicator;

		[SerializeField]
		private Image _imageProcessingIndicator;

		[SerializeField]
		private Image _imageInvalidIndicator;

		[SerializeField]
		private GameObject _panelAddNewItem;

		[SerializeField]
		private DynamicButton _buttonAddNew;

		[SerializeField]
		private Color _colorTextError;

		private MusicPackSourceItem _musicPackSourceItem;

		private ExtContentGameItemUIScreen _owningUIScreen;

		private bool _bIsAddNewButtonItem;

		private bool _bIsItemSelected;

		private bool _bAudioInfoKnown;

		private bool _bDecodeFatalError;

		private string _sourceItemId;

		private string _mp3FileName;

		public MusicPackSourceItem MusicPackSourceItem => _musicPackSourceItem;

		public string FileSpec => _musicPackSourceItem.FileSpec;

		public string SongTitle => _musicPackSourceItem.TrackName;

		public string ArtistName => _musicPackSourceItem.ArtistName;

		public bool DecodeFatalError => _bDecodeFatalError;

		public void Init(ExtContentGameItemUIScreen owningUIScreen, bool bIsAddNewButtonItem, string sourceItemId, MusicPackSourceItem musicPackSourceItem = null)
		{
			_owningUIScreen = owningUIScreen;
			_musicPackSourceItem = musicPackSourceItem;
			_bIsAddNewButtonItem = bIsAddNewButtonItem;
			_sourceItemId = sourceItemId;
			_bIsItemSelected = false;
			_mp3FileName = string.Empty;
			if (!_bIsAddNewButtonItem)
			{
				if (_buttonRow != null)
				{
					_buttonRow.onPrimaryDown.AddListener(OnButtonSelectItem);
				}
				if (_buttonRemove != null)
				{
					_buttonRemove.onPrimaryDown.AddListener(OnButtonRemove);
				}
				if (_buttonPreviewPlay != null)
				{
					_buttonPreviewPlay.onPrimaryDown.AddListener(OnButtonPreviewPlay);
				}
				if (_buttonPreviewPause != null)
				{
					_buttonPreviewPause.onPrimaryDown.AddListener(OnButtonPreviewPause);
				}
			}
			else if (_buttonAddNew != null)
			{
				_buttonAddNew.onPrimaryDown.AddListener(OnButtonAddNew);
			}
			base.gameObject.SetActive(value: true);
			_panelMainTrackItem?.SetActive(!_bIsAddNewButtonItem);
			_panelTrackItemButtons?.SetActive(!_bIsAddNewButtonItem);
			_panelAddNewItem?.SetActive(_bIsAddNewButtonItem);
			UpdateMP3FileName();
			UpdateInitialDecodeFatalError();
			RefreshUI();
		}

		public void DeInit()
		{
			if (!_bIsAddNewButtonItem)
			{
				if (_buttonRow != null)
				{
					_buttonRow.onPrimaryDown.RemoveListener(OnButtonSelectItem);
				}
				if (_buttonRemove != null)
				{
					_buttonRemove.onPrimaryDown.RemoveListener(OnButtonRemove);
				}
				if (_buttonPreviewPlay != null)
				{
					_buttonPreviewPlay.onPrimaryDown.RemoveListener(OnButtonPreviewPlay);
				}
				if (_buttonPreviewPause != null)
				{
					_buttonPreviewPause.onPrimaryDown.RemoveListener(OnButtonPreviewPause);
				}
			}
			else if (_buttonAddNew != null)
			{
				_buttonAddNew.onPrimaryDown.RemoveListener(OnButtonAddNew);
			}
			base.gameObject.SetActive(value: false);
		}

		public void SetItemSelected(bool bSelected)
		{
			if (_bIsItemSelected != bSelected)
			{
				_bIsItemSelected = bSelected;
				RefreshUIMusicItemBG();
			}
		}

		public void RefreshUI()
		{
			if (!_bIsAddNewButtonItem)
			{
				RefreshUITextSongTitle();
				RefreshUITextArtistName();
				RefreshUIMusicItemBG();
				RefreshUIPreviewButtons();
			}
		}

		public void SetData(string artistName, string songTitle)
		{
			_musicPackSourceItem.ArtistName = artistName;
			_musicPackSourceItem.TrackName = songTitle;
			RefreshUITextSongTitle();
			RefreshUITextArtistName();
			DynamicPlaylistManager dynamicPlaylistManager = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager;
			if (dynamicPlaylistManager.IsPlayingPreviewAndNotPaused() && dynamicPlaylistManager.IsPlayingPreviewMP3FileSpec(_musicPackSourceItem.FileSpec))
			{
				dynamicPlaylistManager.UpdatePreviewArtistAndSongNames(artistName, songTitle);
			}
		}

		public void OnMusicItemPreviewStatusChanged(DynPlaylistTrackItem updatedTrackItem)
		{
			if (updatedTrackItem != null)
			{
				if (updatedTrackItem._bDecodeFatalError && updatedTrackItem._parentSourceType == DynPlaylistSource.PendingUpdate && updatedTrackItem._itemId == _mp3FileName)
				{
					SetDecodeFatalError(bSet: true);
				}
				RefreshUI();
			}
			else
			{
				ResetRowState();
				RefreshUIPreviewButtons();
			}
		}

		public void FrameUpdate()
		{
			ProcessBusyIndicatorAnimation();
		}

		private void ResetRowState()
		{
			_bAudioInfoKnown = false;
			_bDecodeFatalError = false;
		}

		private void SetDecodeFatalError(bool bSet, bool bShowUserMsg = true)
		{
			if (_bDecodeFatalError != bSet)
			{
				_bDecodeFatalError = bSet;
				RefreshUI();
				if (_bDecodeFatalError && bShowUserMsg)
				{
					_owningUIScreen.OnMusicItemRowDecodeFatalError();
				}
			}
		}

		private void ProcessBusyIndicatorAnimation()
		{
			if (_bAudioInfoKnown || _bDecodeFatalError || !(_imageProcessingIndicator != null) || !(_imageUpdatePendingIndicator != null))
			{
				return;
			}
			DynamicPlaylistManager dynamicPlaylistManager = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager;
			if (dynamicPlaylistManager.AllowUnnormPreviewIndicationEver && dynamicPlaylistManager.AllowUnnormPreviewIndication && dynamicPlaylistManager.IsCurrentlyUpdatingMP3FileAudioInfo(FileSpec))
			{
				if (!_imageProcessingIndicator.gameObject.activeSelf)
				{
					_imageProcessingIndicator.gameObject.SetActive(value: true);
				}
				if (_imageUpdatePendingIndicator.gameObject.activeSelf)
				{
					_imageUpdatePendingIndicator.gameObject.SetActive(value: false);
				}
				ExtContentUIUtils.ProcessBusyIndicatorAnimation(_imageProcessingIndicator, 360f);
			}
		}

		private void UpdateMP3FileName()
		{
			if (!_bIsAddNewButtonItem && _musicPackSourceItem != null && !_musicPackSourceItem.FileSpec.IsNullOrEmpty())
			{
				_mp3FileName = Path.GetFileName(_musicPackSourceItem.FileSpec);
			}
		}

		private void UpdateInitialDecodeFatalError()
		{
			if (!_bIsAddNewButtonItem && _musicPackSourceItem != null && !_musicPackSourceItem.FileSpec.IsNullOrEmpty() && ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager.IsDecodeFatalErrorKnownForMP3FileSpec(_sourceItemId, _musicPackSourceItem.FileSpec))
			{
				SetDecodeFatalError(bSet: true, bShowUserMsg: false);
			}
		}

		private void RefreshUITextSongTitle()
		{
			if (_textSongTitle != null)
			{
				if (_bDecodeFatalError)
				{
					_textSongTitle.text = DynamicPlaylistUI.GetColourMarkupString(_musicPackSourceItem.TrackName, DynamicPlaylistUI.ColorToColorMarkup(_colorTextError));
				}
				else
				{
					_textSongTitle.text = _musicPackSourceItem.TrackName;
				}
			}
		}

		private void RefreshUITextArtistName()
		{
			if (_textArtistName != null)
			{
				string artistDisplayName = DynamicPlaylistManager.GetArtistDisplayName(_musicPackSourceItem.ArtistName);
				_textArtistName.text = artistDisplayName;
			}
		}

		private void RefreshUIMusicItemBG()
		{
			_goMainTrackItemBGSelected?.SetActive(_bIsItemSelected);
			_goMainTrackItemBGUnselected?.SetActive(!_bIsItemSelected && !_bDecodeFatalError);
			_goMainTrackItemBGDisabled?.SetActive(!_bIsItemSelected && _bDecodeFatalError);
		}

		private void RefreshUIPreviewButtons()
		{
			if (!(_buttonPreviewPlay != null) || !(_buttonPreviewPause != null) || !(_buttonPreviewPlayDisabled != null))
			{
				return;
			}
			DynamicPlaylistManager dynamicPlaylistManager = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager;
			if (!_bDecodeFatalError && (dynamicPlaylistManager.Config._bAllowUnnormalisedPreviews || CheckLookupTrackAudioInfo()))
			{
				bool flag = false;
				if (dynamicPlaylistManager.IsPlayingPreview() && !dynamicPlaylistManager.IsPreviewPlaybackPaused() && dynamicPlaylistManager.IsPlayingPreviewMP3FileSpec(_musicPackSourceItem.FileSpec))
				{
					flag = true;
				}
				_buttonPreviewPlay.gameObject.SetActive(!flag);
				_buttonPreviewPause.gameObject.SetActive(flag);
				_buttonPreviewPlayDisabled.gameObject.SetActive(value: false);
				_imageUpdatePendingIndicator?.gameObject.SetActive(value: false);
				_imageProcessingIndicator?.gameObject.SetActive(value: false);
				_imageInvalidIndicator?.gameObject.SetActive(value: false);
				if (dynamicPlaylistManager.AllowUnnormPreviewIndicationEver && dynamicPlaylistManager.AllowUnnormPreviewIndication && !CheckLookupTrackAudioInfo())
				{
					_imageUpdatePendingIndicator?.gameObject.SetActive(value: true);
				}
			}
			else
			{
				_buttonPreviewPlay.gameObject.SetActive(value: false);
				_buttonPreviewPause.gameObject.SetActive(value: false);
				_buttonPreviewPlayDisabled.gameObject.SetActive(value: true);
				_imageUpdatePendingIndicator?.gameObject.SetActive(value: false);
				_imageProcessingIndicator?.gameObject.SetActive(value: false);
				_imageInvalidIndicator?.gameObject.SetActive(value: true);
			}
		}

		private bool CheckLookupTrackAudioInfo()
		{
			_ = _bAudioInfoKnown;
			if (!_bAudioInfoKnown && !_bDecodeFatalError)
			{
				_bAudioInfoKnown = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager.IsMP3FileAudioInfoKnown(FileSpec);
			}
			return _bAudioInfoKnown;
		}

		private void OnButtonSelectItem()
		{
			_owningUIScreen.SelectMusicItemRow(this);
			_owningUIScreen.StartMusicItemRowDragMode(this);
		}

		private void OnButtonRemove()
		{
			_owningUIScreen.RemoveUIMusicItemRow(this);
		}

		private void OnButtonPreviewPlay()
		{
			TogglePlayPreview();
		}

		private void OnButtonPreviewPause()
		{
			TogglePlayPreview();
		}

		private void TogglePlayPreview()
		{
			_owningUIScreen.SelectMusicItemRow(this);
			bool num = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager.TogglePlayPreview(_musicPackSourceItem.FileSpec, _musicPackSourceItem.ArtistName, _musicPackSourceItem.TrackName);
			_owningUIScreen.OnMusicItemPreviewStatusChanged(null);
			if (!num)
			{
				SetDecodeFatalError(bSet: true);
			}
		}

		private void OnButtonAddNew()
		{
			_owningUIScreen.PromptForNewMusicPackItem();
		}
	}
}
