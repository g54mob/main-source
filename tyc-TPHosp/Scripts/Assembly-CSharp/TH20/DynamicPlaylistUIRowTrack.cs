using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class DynamicPlaylistUIRowTrack : MonoBehaviour
	{
		[SerializeField]
		private Toggle _toggleEnabled;

		[SerializeField]
		private GameObject _toggleEnabledDimmer;

		[SerializeField]
		private DynamicButton _buttonPreviewPlay;

		[SerializeField]
		private DynamicButton _buttonPreviewPlayDisabled;

		[SerializeField]
		private DynamicButton _buttonPreviewPause;

		[SerializeField]
		private TMP_Text _textArtistAndTrackName;

		[SerializeField]
		private Image _imageUpdatePendingIndicator;

		[SerializeField]
		private Image _imageProcessingIndicator;

		[SerializeField]
		private Image _imageInvalidIndicator;

		private DynamicPlaylistUI _dynamicPlaylistUI;

		private DynamicPlaylistManager _dynamicPlaylistManager;

		private GameObject _rowParent;

		private string _sourceItemId;

		private string _trackItemId;

		private bool _bInitialising;

		private bool _bAudioInfoKnown;

		private bool _bDecodeFatalError;

		private bool _bIsInternalTrack;

		public void Init(DynamicPlaylistUI dynamicPlaylistUI, DynamicPlaylistManager dynamicPlaylistManager, GameObject rowParent, string sourceItemId, string trackItemId)
		{
			_bInitialising = true;
			_dynamicPlaylistUI = dynamicPlaylistUI;
			_dynamicPlaylistManager = dynamicPlaylistManager;
			_rowParent = rowParent;
			_sourceItemId = sourceItemId;
			_trackItemId = trackItemId;
			if (_toggleEnabled != null)
			{
				_toggleEnabled.onValueChanged.AddListener(OnToggleChangeEnabled);
			}
			if (_buttonPreviewPlay != null)
			{
				_buttonPreviewPlay.onPrimaryDown.AddListener(OnButtonPreviewPlay);
			}
			if (_buttonPreviewPause != null)
			{
				_buttonPreviewPause.onPrimaryDown.AddListener(OnButtonPreviewPause);
			}
			_dynamicPlaylistManager.OnTrackAudioInfoUpdated += OnTrackAudioInfoUpdated;
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null)
			{
				_bIsInternalTrack = sourceItem._type == DynPlaylistSource.Internal;
			}
			UpdateMP3FileSpec();
			UpdateFatalErrorStatus();
			RefreshUI();
			_bInitialising = false;
		}

		public void DeInit()
		{
			if (_toggleEnabled != null)
			{
				_toggleEnabled.onValueChanged.RemoveListener(OnToggleChangeEnabled);
			}
			if (_buttonPreviewPlay != null)
			{
				_buttonPreviewPlay.onPrimaryDown.RemoveListener(OnButtonPreviewPlay);
			}
			if (_buttonPreviewPause != null)
			{
				_buttonPreviewPause.onPrimaryDown.RemoveListener(OnButtonPreviewPause);
			}
			_dynamicPlaylistManager.OnTrackAudioInfoUpdated -= OnTrackAudioInfoUpdated;
		}

		public void Update()
		{
		}

		public void RefreshUI()
		{
			RefreshUIEnabledToggleDimmer();
			RefreshUITrackAndArtistNameText();
			RefreshUIToggleEnabledState();
			RefreshUIPreviewButtons();
		}

		public void OnTrackPreviewStatusChanged()
		{
			RefreshUIPreviewButtons();
		}

		public void OnParentExpanded(bool bExpanded)
		{
			base.gameObject.SetActive(bExpanded);
		}

		public void FrameUpdate()
		{
			ProcessBusyIndicatorAnimation();
		}

		private void ProcessBusyIndicatorAnimation()
		{
			if (_bIsInternalTrack || _bAudioInfoKnown || !(_imageProcessingIndicator != null) || !(_imageUpdatePendingIndicator != null))
			{
				return;
			}
			DynamicPlaylistManager dynamicPlaylistManager = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager;
			if (!dynamicPlaylistManager.AllowUnnormPreviewIndicationEver || !dynamicPlaylistManager.AllowUnnormPreviewIndication)
			{
				return;
			}
			DynPlaylistTrackItem trackItem = GetTrackItem();
			if (trackItem == null)
			{
				return;
			}
			string trackItemMP3FileSpec = _dynamicPlaylistManager.GetTrackItemMP3FileSpec(trackItem);
			if (dynamicPlaylistManager.IsCurrentlyUpdatingMP3FileAudioInfo(trackItemMP3FileSpec))
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

		private void UpdateMP3FileSpec()
		{
		}

		private void ResetRowState()
		{
			_bAudioInfoKnown = true;
			_bDecodeFatalError = false;
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null && sourceItem._type != DynPlaylistSource.Internal)
			{
				_bAudioInfoKnown = false;
			}
		}

		private void UpdateFatalErrorStatus()
		{
			DynPlaylistTrackItem trackItem = GetTrackItem();
			if (trackItem != null && trackItem._bDecodeFatalError)
			{
				SetDecodeFatalError(bSet: true, bShowUserMsg: false);
			}
		}

		private void SetDecodeFatalError(bool bSet, bool bShowUserMsg = true)
		{
			if (_bDecodeFatalError == bSet)
			{
				return;
			}
			_bDecodeFatalError = bSet;
			if (_bDecodeFatalError)
			{
				DynPlaylistTrackItem trackItem = GetTrackItem();
				if (trackItem != null)
				{
					trackItem._bDecodeFatalError = _bDecodeFatalError;
					trackItem._bEnabled = false;
				}
			}
			RefreshUI();
			if (_bDecodeFatalError && bShowUserMsg)
			{
				ExtContentMessages.ShowPlayerGeneralErrorMessageBox();
			}
		}

		private DynPlaylistSourceItem GetSourceItem()
		{
			return _dynamicPlaylistManager.FindSourceItemById(_sourceItemId);
		}

		private DynPlaylistTrackItem GetTrackItem()
		{
			DynPlaylistTrackItem result = null;
			DynPlaylistSourceItem sourceItem = GetSourceItem();
			if (sourceItem != null)
			{
				DynPlaylistTrackItem dynPlaylistTrackItem = sourceItem.FindTrackItemById(_trackItemId);
				if (dynPlaylistTrackItem != null)
				{
					result = dynPlaylistTrackItem;
				}
			}
			return result;
		}

		private bool GetPlaylistItems(ref DynPlaylistSourceItem retSourceItem, ref DynPlaylistTrackItem retTrackItem)
		{
			retSourceItem = GetSourceItem();
			if (retSourceItem != null)
			{
				DynPlaylistTrackItem dynPlaylistTrackItem = retSourceItem.FindTrackItemById(_trackItemId);
				if (dynPlaylistTrackItem != null)
				{
					retTrackItem = dynPlaylistTrackItem;
				}
			}
			if (retSourceItem != null)
			{
				return retTrackItem != null;
			}
			return false;
		}

		private void RefreshUIEnabledToggleDimmer()
		{
			if (_toggleEnabledDimmer != null)
			{
				bool active = false;
				DynPlaylistSourceItem retSourceItem = null;
				DynPlaylistTrackItem retTrackItem = null;
				if (GetPlaylistItems(ref retSourceItem, ref retTrackItem) && (!retSourceItem.IsEnabled() || !retTrackItem.IsEnabled()))
				{
					active = true;
				}
				_toggleEnabledDimmer.SetActive(active);
			}
		}

		private void RefreshUITrackAndArtistNameText()
		{
			if (_textArtistAndTrackName != null)
			{
				DynPlaylistSourceItem retSourceItem = null;
				DynPlaylistTrackItem retTrackItem = null;
				if (GetPlaylistItems(ref retSourceItem, ref retTrackItem))
				{
					bool bEnabled = retSourceItem.IsEnabled() && retTrackItem.IsEnabled();
					_textArtistAndTrackName.text = $"{_dynamicPlaylistUI.GetMarkedUpStringTrackName(bEnabled, _bDecodeFatalError, retTrackItem._trackName)} {_dynamicPlaylistUI.GetMarkedUpStringArtistName(bEnabled, _bDecodeFatalError, DynamicPlaylistManager.GetArtistDisplayName(retTrackItem._artistName))}";
				}
			}
		}

		private void RefreshUIPreviewButtons()
		{
			if (!(_buttonPreviewPlay != null) || !(_buttonPreviewPause != null) || !(_buttonPreviewPlayDisabled != null))
			{
				return;
			}
			_buttonPreviewPlayDisabled.gameObject.SetActive(value: true);
			DynPlaylistSourceItem retSourceItem = null;
			DynPlaylistTrackItem retTrackItem = null;
			if (!GetPlaylistItems(ref retSourceItem, ref retTrackItem))
			{
				return;
			}
			DynamicPlaylistManager dynamicPlaylistManager = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager;
			if (!_bDecodeFatalError && (dynamicPlaylistManager.Config._bAllowUnnormalisedPreviews || CheckLookupTrackAudioInfo()))
			{
				bool flag = false;
				if (dynamicPlaylistManager.IsPlayingPreview() && !dynamicPlaylistManager.IsPreviewPlaybackPaused() && _dynamicPlaylistManager.IsPlayingPreviewTrackItem(retTrackItem))
				{
					flag = true;
				}
				_buttonPreviewPlay.gameObject.SetActive(!flag);
				_buttonPreviewPause.gameObject.SetActive(flag);
				_buttonPreviewPlayDisabled.gameObject.SetActive(value: false);
				_imageUpdatePendingIndicator?.gameObject.SetActive(value: false);
				_imageProcessingIndicator?.gameObject.SetActive(value: false);
				_imageInvalidIndicator?.gameObject.SetActive(value: false);
				if (retSourceItem._type != DynPlaylistSource.Internal && dynamicPlaylistManager.AllowUnnormPreviewIndicationEver && dynamicPlaylistManager.AllowUnnormPreviewIndication && !CheckLookupTrackAudioInfo())
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

		private void RefreshUIToggleEnabledState()
		{
			if (_toggleEnabled != null)
			{
				DynPlaylistTrackItem trackItem = GetTrackItem();
				if (trackItem != null)
				{
					_toggleEnabled.isOn = trackItem.IsEnabled();
				}
			}
		}

		private void OnTrackAudioInfoUpdated(DynPlaylistTrackItem updatedTrackItem)
		{
			RefreshUIPreviewButtons();
			DynPlaylistTrackItem trackItem = GetTrackItem();
			if (trackItem == null)
			{
				return;
			}
			if (updatedTrackItem != null)
			{
				if (updatedTrackItem._itemId == trackItem._itemId && updatedTrackItem._fileContentsId == trackItem._fileContentsId)
				{
					SetDecodeFatalError(updatedTrackItem._bDecodeFatalError, bShowUserMsg: false);
					RefreshUI();
				}
			}
			else
			{
				ResetRowState();
				RefreshUI();
			}
		}

		private void OnToggleChangeEnabled(bool bStatus)
		{
			DynPlaylistTrackItem trackItem = GetTrackItem();
			if (trackItem == null)
			{
				return;
			}
			bool flag = true;
			if (!_bInitialising && !bStatus)
			{
				trackItem._bEnabled = false;
				if (_dynamicPlaylistManager.GetNumEnabledTracks() < 1)
				{
					flag = false;
				}
				trackItem._bEnabled = true;
			}
			if (flag)
			{
				trackItem._bEnabled = bStatus;
				RefreshUIToggleEnabledState();
				RefreshUITrackAndArtistNameText();
				RefreshUIEnabledToggleDimmer();
				_dynamicPlaylistUI.OnPlaylistChangesMade();
			}
			else
			{
				RefreshUIToggleEnabledState();
				ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistAtLeastOneTrackMessageTitle), ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistAtLeastOneTrackMessageBody));
			}
		}

		private void OnButtonPreviewPlay()
		{
			TogglePreviewPlayback();
		}

		private void OnButtonPreviewPause()
		{
			TogglePreviewPlayback();
		}

		private void TogglePreviewPlayback()
		{
			DynPlaylistTrackItem trackItem = GetTrackItem();
			if (trackItem != null)
			{
				bool num = _dynamicPlaylistManager.TogglePlayPreview(trackItem);
				_dynamicPlaylistUI.OnTrackPreviewStatusChanged();
				if (!num)
				{
					SetDecodeFatalError(bSet: true);
				}
			}
		}

		private bool CheckLookupTrackAudioInfo()
		{
			_ = _bAudioInfoKnown;
			if (!_bAudioInfoKnown)
			{
				DynPlaylistTrackItem trackItem = GetTrackItem();
				if (trackItem != null)
				{
					if (!trackItem.IsAudioInfoKnown())
					{
						string trackItemMP3FileSpec = _dynamicPlaylistManager.GetTrackItemMP3FileSpec(trackItem);
						if (_dynamicPlaylistManager.IsMP3FileAudioInfoKnown(trackItemMP3FileSpec))
						{
							_bAudioInfoKnown = true;
						}
					}
					else
					{
						_bAudioInfoKnown = true;
					}
				}
			}
			return _bAudioInfoKnown;
		}
	}
}
