using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using FullSerializerSave;
using I2.Loc;
using IdSharp.Tagging.ID3v1;
using IdSharp.Tagging.ID3v2;
using MP3Sharp;
using TH20.ExtContent;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class DynamicPlaylistManager : MustCallDestroy
	{
		public enum EPlaybackMode
		{
			Sequential = 0,
			Shuffle = 1
		}

		public class DynPlaylistSerializedData
		{
			public int _jsonFileVersionNum;

			public bool _bUseRMSNormalisation;

			public float _normalisationdB;

			public EPlaybackMode _currentPlaybackMode;

			public List<DynPlaylistSourceItem> _sourcesList;
		}

		public delegate void OnDynamicPlaylistChangedCallback();

		public delegate void OnTrackAudioInfoUpdatedCallback(DynPlaylistTrackItem trackItem);

		public const int cJSONFileVersionNum_01 = 1;

		public const int cJSONFileVersionNum = 1;

		public const float cPreviewButtonIndicationScale = 0.6f;

		public Vector3 cPreviewButtonIndicationScaleVec = new Vector3(0.6f, 0.6f, 1f);

		public const int cMP3TrackSampleDefaultRate = 44100;

		public const float cRebuildDynamicListPendingTime = 5f;

		public const float cAudioInfoUpdateCoroutinePostponedTime = 5f;

		public const int cMinNumSamplesForDecodeErrorTracks = 1323000;

		public const float cPlaybackStreamDeInitPendingTime = 12f;

		public const float cExternalTrackLeadOutTime = 4f;

		private const bool cVerboseTrackReadLogging = true;

		private const bool cVerboseTrackPlaybackLogging = true;

		private const bool cPerformTrackDurationUpdates = true;

		private const bool cPerformTrackTrimming = true;

		private const string cSepStr1 = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

		private const string cIndentStr = "           ";

		private const bool cAllowNextTrackOverrides = false;

		private const int cOverrideNextItemIndex = 33;

		private const string cOverrideNextItemID = "";

		private Level _level;

		private DynamicPlaylistManagerConfig _config;

		private RadioConfig _radioConfig;

		private AppAudioMixerManager _appAudioMixerManager;

		private float _rebuildDynamicListPendingTimer;

		private bool _bSaveToFilePending;

		private bool _bRebuildEnabledItemsListPending;

		private bool _bEnabledListForceIncludesInternalItems;

		private string _currentPlaybackItemId;

		private int _currentPlaybackFileContentsId;

		private int _currentPlaybackItemIndex;

		private EPlaybackMode _currentPlaybackMode;

		private MonoBehaviour _behaviourToRunCoroutinesOn;

		private Coroutine _audioInfoUpdateCoroutine;

		private bool _bAudioInfoUpdateCoroutinePostponed;

		private float _audioInfoUpdateCoroutinePostponedTimer;

		private float _playbackStreamDeInitPendingTimer;

		private string _audioInfoUpdateProcessingItemId;

		private int _audioInfoUpdateProcessingFilerContentsId;

		private List<DynPlaylistSourceItem> _sourcesList;

		private List<DynPlaylistTrackItem> _enabledTrackItemsList;

		private DynPlaylistSourceItem _sourceTempItemsPendingUpdate;

		private List<DynPlaylistTrackItem> _tempPendingUpdateTrackItemsPendingRemoval;

		private MP3Stream _mp3StreamPlayback;

		private byte[] _mp3StreamPlaybackReadBuffer;

		private AudioClip _audioClipStreamed;

		private int _mp3StreamPlaybackTotalSamplesRead;

		private RadioSong _lastPlayedRadioSong;

		private AudioSource _lastPlayedRadioSongAudioSource;

		private StreamedAudioInstance _streamedAudioPlayback;

		private StreamedAudioInstance _streamedAudioPreview;

		private StreamedAudioInstance _streamedAudioTrackUpdate;

		private bool _bIsPreviewPlaying;

		private bool _bIsPreviewPaused;

		private bool _bPreviewAudioInited;

		private bool _bPreviewUseInternalItemIndex;

		private bool _bInitialExternalContentProcessed;

		private bool _bAllowExternalContentSourceItems;

		private bool _bAllowUnnormPreviewIndication;

		private string _previewMP3FileSpec;

		private string _previewArtistName;

		private string _previewTrackName;

		private string _previewSourceId;

		private string _previewTrackId;

		private int _previewInternalItemIndex;

		private GameObject _previewGameObject;

		private AudioSource _previewAudioSource;

		private GameObject _ownerGameObjectForAudio;

		public Level Level
		{
			get
			{
				return _level;
			}
			set
			{
				_level = value;
			}
		}

		public DynamicPlaylistManagerConfig Config => _config;

		public AppAudioMixerManager AppAudioMixerManager
		{
			get
			{
				return _appAudioMixerManager;
			}
			set
			{
				_appAudioMixerManager = value;
			}
		}

		public EPlaybackMode PlaybackMode
		{
			get
			{
				return _currentPlaybackMode;
			}
			set
			{
				_currentPlaybackMode = value;
			}
		}

		public List<DynPlaylistSourceItem> SourcesList => _sourcesList;

		public bool AllowUnnormPreviewIndicationEver => true;

		public bool AllowUnnormPreviewIndication
		{
			get
			{
				if (AllowUnnormPreviewIndicationEver)
				{
					return _bAllowUnnormPreviewIndication;
				}
				return false;
			}
			set
			{
				_bAllowUnnormPreviewIndication = value;
			}
		}

		public event OnDynamicPlaylistChangedCallback OnDynamicPlaylistChanged;

		public event OnTrackAudioInfoUpdatedCallback OnTrackAudioInfoUpdated;

		public DynamicPlaylistManager(DynamicPlaylistManagerConfig config, RadioConfig radioConfig, MonoBehaviour behaviourToRunCoroutinesOn)
		{
			_sourcesList = new List<DynPlaylistSourceItem>();
			_enabledTrackItemsList = new List<DynPlaylistTrackItem>();
			_streamedAudioPlayback = new StreamedAudioInstance();
			_streamedAudioPreview = new StreamedAudioInstance();
			_streamedAudioTrackUpdate = new StreamedAudioInstance();
			_config = config;
			_radioConfig = radioConfig;
			_behaviourToRunCoroutinesOn = behaviourToRunCoroutinesOn;
			_bAllowUnnormPreviewIndication = true;
			_bAllowExternalContentSourceItems = ShouldAllowExternalContentItems();
			_bInitialExternalContentProcessed = !_bAllowExternalContentSourceItems;
			_audioInfoUpdateProcessingItemId = string.Empty;
			_audioInfoUpdateProcessingFilerContentsId = 0;
			Init();
		}

		public override void Destroy()
		{
			DeInit();
			base.Destroy();
		}

		public void Init()
		{
			TestFloatCultures();
			if (_bAllowExternalContentSourceItems)
			{
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemPreProcess += OnLocallModsGameItemPreProcess;
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemCreated += OnLocallModsItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemUpdated += OnLocallModsItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemDeleted += OnLocallModsItemsDeleted;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemCreated += OnWorkshopItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemUpdated += OnWorkshopItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemDeleted += OnWorkshopItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnPreInstalledItemsProcessed += OnPreInstalledWorkshopItemsProcessed;
				ExtContentUtils.ExtContentManager.WorkshopContentCreationManager.OnPublishStarted += OnPublishStarted;
			}
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			_sourceTempItemsPendingUpdate = new DynPlaylistSourceItem(DynPlaylistSource.PendingUpdate, "@PendingUpdate", "PendingUpdate");
			_tempPendingUpdateTrackItemsPendingRemoval = new List<DynPlaylistTrackItem>();
			PlaybackMode = EPlaybackMode.Sequential;
			LoadFromFile();
			RemovePlatformDisabledSourceItems();
			SetRebuildDynamicListPending();
			InitPlayback();
		}

		public void DeInit()
		{
			if (_bAllowExternalContentSourceItems)
			{
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemPreProcess -= OnLocallModsGameItemPreProcess;
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemCreated -= OnLocallModsItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemUpdated -= OnLocallModsItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceLocalMods.OnGameItemDeleted -= OnLocallModsItemsDeleted;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemCreated -= OnWorkshopItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemUpdated -= OnWorkshopItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemDeleted -= OnWorkshopItemsChanged;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnPreInstalledItemsProcessed -= OnPreInstalledWorkshopItemsProcessed;
				ExtContentUtils.ExtContentManager.WorkshopContentCreationManager.OnPublishStarted -= OnPublishStarted;
			}
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			StopPreview();
			DeInitPreviewAudio();
			StopAudioInfoUpdateCoroutine();
			_streamedAudioPlayback.DeInit();
			_streamedAudioPreview.DeInit();
			_streamedAudioTrackUpdate.DeInit();
		}

		public void SetOwnerGameObjectForAudio(GameObject ownerGameObjectForAudio)
		{
			_ownerGameObjectForAudio = ownerGameObjectForAudio;
		}

		public void Update()
		{
			ProcessDebugInputs();
			ProcessRebuildDynamicListPending();
			ProcessPlaybackStreamDeInitPending();
			ProcessPostponedAudioInfoUpdateCoroutine();
			ProcessSaveToFilePending();
			ProcessRebuildEnabledItemsListPending();
			CheckProcessTempPendingUpdateTrackItemsPendingRemoval();
		}

		public DynPlaylistSourceItem FindSourceItemById(string sourceItemId)
		{
			return _sourcesList.Find((DynPlaylistSourceItem sourecItem) => sourecItem._itemId == sourceItemId);
		}

		public DynPlaylistTrackItem FindTrackItemById(string itemId, int fileContentsId)
		{
			DynPlaylistTrackItem result = null;
			foreach (DynPlaylistSourceItem sources in _sourcesList)
			{
				DynPlaylistTrackItem dynPlaylistTrackItem = sources.FindTrackItemById(itemId, fileContentsId);
				if (dynPlaylistTrackItem != null)
				{
					result = dynPlaylistTrackItem;
					break;
				}
			}
			return result;
		}

		public void InitPlayback()
		{
			_currentPlaybackItemId = string.Empty;
			_currentPlaybackFileContentsId = 0;
		}

		public RadioSong GetNextRadioSong()
		{
			RadioSong result = null;
			if (FindNextPlaybackItem())
			{
				RadioSongMeta currentItemRadioSong = GetCurrentItemRadioSong();
				if (currentItemRadioSong != null && currentItemRadioSong._radioSong != null)
				{
					result = currentItemRadioSong._radioSong;
					int num = (int)currentItemRadioSong._radioSong.Clip.length;
					int num2 = num / 60;
					int num3 = num % 60;
					ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
					ExtContentMessages.LogDebug($"[DYNPLMGR]: Playing RADIO SONG: Samples:{currentItemRadioSong._radioSong.Clip.samples:0000000000}, Durn:{num2:00}:{num3:00}, NormF:{currentItemRadioSong._mp3NormFactor:0.00}, Artist:'{currentItemRadioSong._radioSong.GetArtistDisplayName()}', Track:'{currentItemRadioSong._radioSong.GetSongDisplayName()}'");
					ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
				}
			}
			return result;
		}

		public void NotifyRadioSongStarted(AudioSource audioSource, RadioSong radioSong)
		{
			_lastPlayedRadioSongAudioSource = audioSource;
			_lastPlayedRadioSong = radioSong;
		}

		public void NotifyRadioSongFinishing(AudioSource audioSource, RadioSong radioSong)
		{
			if (radioSong == _lastPlayedRadioSong && _streamedAudioPlayback.Inited && ((_currentPlaybackItemIndex >= 0) & (_currentPlaybackItemIndex < _enabledTrackItemsList.Count)))
			{
				DynPlaylistTrackItem dynPlaylistTrackItem = _enabledTrackItemsList[_currentPlaybackItemIndex];
				if (dynPlaylistTrackItem != null && dynPlaylistTrackItem._parentSourceType != DynPlaylistSource.Internal)
				{
					SetPlaybackStreamDeInitPending();
				}
			}
		}

		public void NotifyRadioSongFinished(AudioSource audioSource, RadioSong radioSong)
		{
			if (radioSong != _lastPlayedRadioSong)
			{
				return;
			}
			if (_lastPlayedRadioSongAudioSource != null && _lastPlayedRadioSongAudioSource.isPlaying)
			{
				_lastPlayedRadioSongAudioSource.Stop();
			}
			_lastPlayedRadioSongAudioSource = null;
			_lastPlayedRadioSong = null;
			if (_streamedAudioPlayback.Inited && ((_currentPlaybackItemIndex >= 0) & (_currentPlaybackItemIndex < _enabledTrackItemsList.Count)))
			{
				DynPlaylistTrackItem dynPlaylistTrackItem = _enabledTrackItemsList[_currentPlaybackItemIndex];
				if (dynPlaylistTrackItem != null && dynPlaylistTrackItem._parentSourceType != DynPlaylistSource.Internal)
				{
					SetPlaybackStreamDeInitPending(0f);
				}
			}
		}

		public void ResetDefaultEnabledStatus(bool bFullReset = false)
		{
			StopPreview();
			StopAudioInfoUpdateCoroutine();
			int i = 0;
			for (int count = _sourcesList.Count; i < count; i++)
			{
				bool flag = _sourcesList[i]._type == DynPlaylistSource.Internal;
				_sourcesList[i]._bEnabled = flag;
				_sourcesList[i]._bExpandedUI = false;
				int j = 0;
				for (int count2 = _sourcesList[i]._trackItems.Count; j < count2; j++)
				{
					if (!flag)
					{
						if (bFullReset)
						{
							_sourcesList[i]._trackItems[j]._bEnabled = true;
							_sourcesList[i]._trackItems[j]._bDecodeErrors = false;
							_sourcesList[i]._trackItems[j]._bDecodeFatalError = false;
							_sourcesList[i]._trackItems[j]._sampleLengthPerChannel = 0;
							_sourcesList[i]._trackItems[j]._normalisationFactor = 0f;
						}
					}
					else
					{
						_sourcesList[i]._trackItems[j]._bEnabled = true;
					}
				}
			}
			if (bFullReset)
			{
				ClearSourceTempItemsPendingUpdate();
				if (this.OnTrackAudioInfoUpdated != null)
				{
					this.OnTrackAudioInfoUpdated(null);
				}
				foreach (GameItemBase allGameItem in ExtContentUtils.ExtContentManager.ContentSourceLocalMods.GetAllGameItems(EContentType.MusicPack))
				{
					foreach (MusicPackSourceItem item in (allGameItem as GameItemMusicPack).Items)
					{
						item.SampleLengthPerChannel = 0;
						item.NormalisationFactor = 0f;
					}
				}
			}
			SetRebuildDynamicListPending(0f);
			SetSaveToFilePending();
		}

		public bool IsDecodeFatalErrorKnownForMP3FileSpec(string sourceItemId, string mp3FileSpec)
		{
			bool result = false;
			DynPlaylistSourceItem dynPlaylistSourceItem = ((!sourceItemId.IsNullOrEmpty()) ? FindSourceItemById(sourceItemId) : _sourceTempItemsPendingUpdate);
			if (dynPlaylistSourceItem != null)
			{
				string fileName = Path.GetFileName(mp3FileSpec);
				int fileContentsId = GetFileContentsId(mp3FileSpec);
				DynPlaylistTrackItem dynPlaylistTrackItem = dynPlaylistSourceItem.FindTrackItemById(fileName, fileContentsId);
				if (dynPlaylistTrackItem != null && dynPlaylistTrackItem._bDecodeFatalError)
				{
					result = true;
				}
			}
			return result;
		}

		public void BuildEnabledItemsList()
		{
			BuildEnabledItemsListImpl();
		}

		public int GetFileContentsId(string mp3FileSpec)
		{
			int result = 0;
			if (!mp3FileSpec.IsNullOrEmpty() && File.Exists(mp3FileSpec))
			{
				result = (int)new FileInfo(mp3FileSpec).Length;
			}
			return result;
		}

		public static string GetPlaybackModeStringLoc(EPlaybackMode playbackMode)
		{
			string result = string.Empty;
			switch (playbackMode)
			{
			case EPlaybackMode.Sequential:
				result = ScriptLocalization.Menu_UGC_MusicPack.PlaybackModeSequential_CS;
				break;
			case EPlaybackMode.Shuffle:
				result = ScriptLocalization.Menu_UGC_MusicPack.PlaybackModeShuffle_CS;
				break;
			}
			return result;
		}

		public static string GetArtistDisplayName(string artistName)
		{
			if (artistName.IsNullOrEmpty())
			{
				return string.Empty;
			}
			return "[" + artistName + "]";
		}

		public bool IsAnyTrackCurrentlyPlaying()
		{
			if (!IsPlayingPreview())
			{
				return _lastPlayedRadioSong != null;
			}
			return true;
		}

		public bool IsAnyTrackCurrentlyPlayingAndNotPaused()
		{
			if (!IsPlayingPreviewAndNotPaused())
			{
				return _lastPlayedRadioSong != null;
			}
			return true;
		}

		public float GetCurrentlyPlayingTrackPositionSecs()
		{
			float result = 0f;
			AudioSource audioSource = (IsPlayingPreviewAndNotPaused() ? _previewAudioSource : _lastPlayedRadioSongAudioSource);
			if (audioSource != null)
			{
				result = audioSource.time;
			}
			return result;
		}

		public bool GetCurrentlyPlayingTrackStaticData(ref string retArtistName, ref string retSongTitle, ref float retDurationSecs)
		{
			bool result = false;
			AudioClip audioClip = null;
			if (IsPlayingPreviewAndNotPaused())
			{
				retArtistName = _previewArtistName;
				retSongTitle = _previewTrackName;
				if (_previewAudioSource != null)
				{
					audioClip = _previewAudioSource.clip;
				}
			}
			else if (_lastPlayedRadioSong != null)
			{
				retArtistName = _lastPlayedRadioSong.GetArtistDisplayName();
				retSongTitle = _lastPlayedRadioSong.GetSongDisplayName();
				audioClip = _lastPlayedRadioSong.Clip;
			}
			if (audioClip != null)
			{
				result = true;
				retDurationSecs = audioClip.length;
			}
			return result;
		}

		public bool IsMP3FileAudioInfoKnown(string mp3FileSpec)
		{
			bool result = false;
			int sampleLength = -1;
			float normalisationFactor = -1f;
			if (SearchTrackItemsForTrackAudioInfo(mp3FileSpec, ref sampleLength, ref normalisationFactor) && sampleLength > 0 && normalisationFactor > 0f)
			{
				result = true;
			}
			return result;
		}

		public bool IsCurrentlyUpdatingMP3FileAudioInfo(string mp3FileSpec)
		{
			bool result = false;
			if (_audioInfoUpdateCoroutine != null && GetFileContentsId(mp3FileSpec) == _audioInfoUpdateProcessingFilerContentsId && Path.GetFileName(mp3FileSpec) == _audioInfoUpdateProcessingItemId)
			{
				result = true;
			}
			return result;
		}

		public bool CheckAddMP3AudioInfoUpdatePending(string mp3FileSpec)
		{
			bool result = false;
			if (_config._bAllowAudioInfoUpdateOnImport && !IsMP3FileAudioInfoKnown(mp3FileSpec))
			{
				string fileName = Path.GetFileName(mp3FileSpec);
				int fileContentsId = GetFileContentsId(mp3FileSpec);
				if (_sourceTempItemsPendingUpdate.FindTrackItemById(fileName, fileContentsId) == null)
				{
					PostponeAudioInfoUpdateCoroutine(0.2f, bForcePostpone: true);
					DynPlaylistTrackItem dynPlaylistTrackItem = AddNewTrackItem(_sourceTempItemsPendingUpdate, fileName);
					dynPlaylistTrackItem._updatePendingFileSpec = mp3FileSpec;
					dynPlaylistTrackItem._fileContentsId = fileContentsId;
					result = true;
				}
			}
			return result;
		}

		public bool CheckRemoveMP3AudioInfoUpdatePending(string mp3FileSpec)
		{
			bool result = false;
			if (_config._bAllowAudioInfoUpdateOnImport)
			{
				string fileName = Path.GetFileName(mp3FileSpec);
				int fileContentsId = GetFileContentsId(mp3FileSpec);
				DynPlaylistTrackItem dynPlaylistTrackItem = _sourceTempItemsPendingUpdate.FindTrackItemById(fileName, fileContentsId);
				if (dynPlaylistTrackItem != null && !dynPlaylistTrackItem.IsAudioInfoKnown())
				{
					DynPlaylistTrackItem dynPlaylistTrackItem2 = FindTrackItemById(fileName, fileContentsId);
					if (dynPlaylistTrackItem2 == null || dynPlaylistTrackItem2.IsAudioInfoKnown())
					{
						PostponeAudioInfoUpdateCoroutine(0.2f);
						_tempPendingUpdateTrackItemsPendingRemoval.Add(dynPlaylistTrackItem);
						ProcessTempPendingUpdateTrackItemsPendingRemoval();
						result = true;
					}
				}
			}
			return result;
		}

		public bool TogglePlayPreview(string mp3FileSpec, string artistName, string trackName, bool bUsePausing = true)
		{
			bool result = TogglePlayPreviewImpl(bUseInternalItemIndex: false, mp3FileSpec, artistName, trackName, -1, -1f, -1, bUsePausing);
			_previewSourceId = string.Empty;
			_previewTrackId = string.Empty;
			return result;
		}

		public bool TogglePlayPreview(DynPlaylistTrackItem trackItem, bool bUsePausing = true)
		{
			bool result = false;
			if (trackItem != null)
			{
				result = ((trackItem._parentSourceType != DynPlaylistSource.Internal) ? TogglePlayPreviewImpl(bUseInternalItemIndex: false, GetTrackItemMP3FileSpec(trackItem), trackItem._artistName, trackItem._trackName, trackItem._sampleLengthPerChannel, trackItem._normalisationFactor, -1, bUsePausing) : TogglePlayPreviewImpl(bUseInternalItemIndex: true, "", trackItem._artistName, trackItem._trackName, -1, -1f, trackItem._internalItemIndex, bUsePausing));
				_previewSourceId = trackItem._parentItemId;
				_previewTrackId = trackItem._itemId;
			}
			return result;
		}

		public bool IsPlayingPreview()
		{
			return _bIsPreviewPlaying;
		}

		public bool IsPlayingPreviewAndNotPaused()
		{
			if (_bIsPreviewPlaying)
			{
				return !_bIsPreviewPaused;
			}
			return false;
		}

		public bool IsPreviewPlaybackPaused()
		{
			return _bIsPreviewPaused;
		}

		public bool IsPlayingPreviewTrackItem(DynPlaylistTrackItem trackItem)
		{
			bool result = false;
			if (_bIsPreviewPlaying && trackItem != null && _previewSourceId == trackItem._parentItemId && _previewTrackId == trackItem._itemId)
			{
				result = true;
			}
			return result;
		}

		public bool IsPlayingPreviewMP3FileSpec(string mp3FileSpec)
		{
			bool result = false;
			if (_bIsPreviewPlaying && _previewMP3FileSpec == mp3FileSpec)
			{
				result = true;
			}
			return result;
		}

		public void StopPreview()
		{
			if (_bIsPreviewPlaying)
			{
				_appAudioMixerManager.SetPreviewMusicChannelFadingOut();
				_previewAudioSource.Stop();
				_bIsPreviewPlaying = false;
				_bIsPreviewPaused = false;
			}
		}

		public void PausePreview(bool bPause = true)
		{
			if (_bIsPreviewPlaying)
			{
				_bIsPreviewPaused = bPause;
				if (_bIsPreviewPaused)
				{
					_previewAudioSource.Pause();
					_appAudioMixerManager.SetPreviewMusicChannelFadingOut();
				}
				else
				{
					_previewAudioSource.UnPause();
					_appAudioMixerManager.SetPreviewMusicChannelFadingIn();
				}
			}
		}

		public void UpdatePreviewArtistAndSongNames(string artistName, string trackName)
		{
			_previewArtistName = artistName;
			_previewTrackName = trackName;
		}

		private bool TogglePlayPreviewImpl(bool bUseInternalItemIndex, string mp3FileSpec, string artistName, string trackName, int sampleLength = -1, float normalisationFactor = -1f, int internalItemIndex = -1, bool bUsePausing = true)
		{
			bool result = true;
			if (!_bIsPreviewPlaying || bUseInternalItemIndex != _bPreviewUseInternalItemIndex || (!bUseInternalItemIndex && _previewMP3FileSpec != mp3FileSpec) || (bUseInternalItemIndex && _previewInternalItemIndex != internalItemIndex))
			{
				result = PlayPreviewImpl(bUseInternalItemIndex, mp3FileSpec, artistName, trackName, sampleLength, normalisationFactor, internalItemIndex);
			}
			else if (bUsePausing)
			{
				bool flag = false;
				if (!_bPreviewUseInternalItemIndex && _streamedAudioPreview.Inited && GetValidNormalisationFactorForMP3File(mp3FileSpec) != _streamedAudioPreview.NormalisationFactor)
				{
					flag = true;
				}
				if (!flag)
				{
					PausePreview(!_bIsPreviewPaused);
				}
				else
				{
					StopPreview();
				}
			}
			else
			{
				StopPreview();
			}
			return result;
		}

		private bool PlayPreviewImpl(bool bUseInternalItemIndex, string mp3FileSpec, string artistName, string trackName, int sampleLength, float normalisationFactor, int internalItemIndex)
		{
			bool result = false;
			StopPreview();
			if (!_bIsPreviewPlaying)
			{
				bool flag = false;
				if (!bUseInternalItemIndex)
				{
					if (!mp3FileSpec.IsNullOrEmpty() && PlatformFileManager.FileExists(mp3FileSpec))
					{
						flag = true;
					}
				}
				else if (internalItemIndex >= 0 && internalItemIndex < _radioConfig.Playlist.Count)
				{
					flag = true;
				}
				if (flag)
				{
					result = true;
					_bPreviewUseInternalItemIndex = bUseInternalItemIndex;
					CheckInitPreviewAudio();
					_streamedAudioPreview.DeInit();
					AudioClip audioClip = null;
					float num = normalisationFactor;
					string empty = string.Empty;
					if (!_bPreviewUseInternalItemIndex)
					{
						empty = Path.GetFileName(mp3FileSpec);
						if (sampleLength <= 0 || normalisationFactor <= 0f)
						{
							SearchTrackItemsForTrackAudioInfo(mp3FileSpec, ref sampleLength, ref normalisationFactor);
						}
						num = GetValidNormalisationFactor(normalisationFactor);
						_streamedAudioPreview.Init("Preview", mp3FileSpec, sampleLength, num, bUseMemoryStream: true, bCreateAudioClip: true, bAllowSeeks: true);
						if (_streamedAudioPreview.Inited && !_streamedAudioPreview.ErrorEncountered)
						{
							_previewMP3FileSpec = mp3FileSpec;
							audioClip = _streamedAudioPreview.AudioClip;
						}
					}
					else
					{
						_previewInternalItemIndex = internalItemIndex;
						empty = _radioConfig.Playlist[_previewInternalItemIndex].SongName;
						audioClip = _radioConfig.Playlist[_previewInternalItemIndex].Clip;
					}
					if (audioClip != null)
					{
						_appAudioMixerManager.SetPreviewMusicChannelFadingIn();
						_bIsPreviewPlaying = true;
						_bIsPreviewPaused = false;
						_previewArtistName = artistName;
						_previewTrackName = trackName;
						_previewAudioSource.clip = audioClip;
						_previewAudioSource.loop = true;
						_previewAudioSource.time = 0f;
						_previewAudioSource.Play();
						int num2 = (int)audioClip.length;
						int num3 = num2 / 60;
						int num4 = num2 % 60;
						ExtContentMessages.LogDebug($"[DYNPLMGR]: Playing PREVIEW: Samples:{audioClip.samples:0000000000}, Durn:{num3:00}:{num4:00}, NormF:{num:0.00}({normalisationFactor:0.00}), Track:'{empty}'");
					}
					else
					{
						result = false;
						_streamedAudioPreview.DeInit();
					}
				}
			}
			return result;
		}

		private float GetValidNormalisationFactorForMP3File(string mp3FileSpec)
		{
			float normalisationFactor = -1f;
			int sampleLength = 0;
			SearchTrackItemsForTrackAudioInfo(mp3FileSpec, ref sampleLength, ref normalisationFactor);
			return GetValidNormalisationFactor(normalisationFactor);
		}

		private void CheckInitPreviewAudio()
		{
			if (!_bPreviewAudioInited)
			{
				InitPreviewAudio();
			}
		}

		private void InitPreviewAudio()
		{
			_previewGameObject = new GameObject("TrackPreview");
			if (_ownerGameObjectForAudio != null)
			{
				_previewGameObject.AddComponent<RectTransform>();
				_previewGameObject.transform.SetParent(_ownerGameObjectForAudio.transform, worldPositionStays: true);
			}
			_previewAudioSource = _previewGameObject.AddComponent<AudioSource>();
			_previewAudioSource.spatialize = false;
			_previewAudioSource.volume = 1f;
			_previewAudioSource.outputAudioMixerGroup = _radioConfig.PreviewMusicAudioMixerGroup;
			_previewAudioSource.priority = 0;
			_bPreviewAudioInited = true;
		}

		private void DeInitPreviewAudio()
		{
			_previewAudioSource = null;
			_previewGameObject = null;
		}

		public bool ReadArtistAndTrackNamesForMP3File(string mp3FileSpec, ref string retArtistName, ref string retTrackName)
		{
			int retLengthMillisecs = -1;
			return ReadArtistAndTrackNamesForMP3File(mp3FileSpec, ref retArtistName, ref retTrackName, ref retLengthMillisecs);
		}

		public bool ReadArtistAndTrackNamesForMP3File(string mp3FileSpec, ref string retArtistName, ref string retTrackName, ref int retLengthMillisecs)
		{
			bool result = false;
			retArtistName = string.Empty;
			retTrackName = string.Empty;
			retLengthMillisecs = 0;
			if (!mp3FileSpec.IsNullOrEmpty() && PlatformFileManager.FileExists(mp3FileSpec))
			{
				try
				{
					if (ID3v2Helper.DoesTagExist(mp3FileSpec))
					{
						IID3v2 iID3v = ID3v2Helper.CreateID3v2(mp3FileSpec);
						if (iID3v != null)
						{
							retArtistName = iID3v.Artist;
							retTrackName = iID3v.Title;
							retLengthMillisecs = (iID3v.LengthMilliseconds.HasValue ? iID3v.LengthMilliseconds.Value : 0);
							result = true;
						}
					}
					else if (ID3v1Helper.DoesTagExist(mp3FileSpec))
					{
						IID3v1 iID3v2 = ID3v1Helper.CreateID3v1(mp3FileSpec);
						if (iID3v2 != null)
						{
							retArtistName = iID3v2.Artist;
							retTrackName = iID3v2.Title;
							result = true;
						}
					}
				}
				catch (Exception ex)
				{
					ExtContentMessages.LogError(string.Format("Exception error encountered whilst reading tags for mp3 file '{1}' - ('{0}')", ex.ToString(), mp3FileSpec));
				}
			}
			if (retArtistName == null)
			{
				retArtistName = string.Empty;
			}
			if (retTrackName == null)
			{
				retTrackName = string.Empty;
			}
			int maxSongAndArtistNameLength = _config._maxSongAndArtistNameLength;
			if (retArtistName.Length > maxSongAndArtistNameLength)
			{
				retArtistName = retArtistName.Substring(0, maxSongAndArtistNameLength);
			}
			if (retTrackName.Length > maxSongAndArtistNameLength)
			{
				retTrackName = retTrackName.Substring(0, maxSongAndArtistNameLength);
			}
			return result;
		}

		public int GetNumEnabledTracks()
		{
			int num = 0;
			foreach (DynPlaylistSourceItem sources in _sourcesList)
			{
				if (sources.IsEnabled())
				{
					num += sources.GetNumEnabledTracks();
				}
			}
			return num;
		}

		private void ClearSourceTempItemsPendingUpdate()
		{
			while (_sourceTempItemsPendingUpdate._trackItems.Count > 0)
			{
				_sourceTempItemsPendingUpdate._trackItems.RemoveAt(0);
			}
		}

		private void SetPlaybackStreamDeInitPending(float pendingDuration = 12f)
		{
			_playbackStreamDeInitPendingTimer = pendingDuration;
			if (_playbackStreamDeInitPendingTimer <= 0f)
			{
				_playbackStreamDeInitPendingTimer = 0f;
				_streamedAudioPlayback.DeInit();
			}
		}

		private void ProcessPlaybackStreamDeInitPending()
		{
			if (_playbackStreamDeInitPendingTimer > 0f)
			{
				_playbackStreamDeInitPendingTimer -= Time.unscaledDeltaTime;
				if (_playbackStreamDeInitPendingTimer <= 0f)
				{
					_playbackStreamDeInitPendingTimer = 0f;
					_streamedAudioPlayback.DeInit();
				}
			}
		}

		private void OnLocallModsGameItemPreProcess(EContentType contentType, GameItemBase gameItemBase)
		{
			if (contentType == EContentType.MusicPack)
			{
				PostponeAudioInfoUpdateCoroutine();
			}
		}

		private void OnLocallModsItemsChanged(GameItemBase gameItemBase)
		{
			if (gameItemBase.ContentType == EContentType.MusicPack)
			{
				OnExternalMusicPackItemsChanged();
			}
		}

		private void OnLocallModsItemsDeleted(GameItemBase gameItemBase)
		{
			if (gameItemBase.ContentType == EContentType.MusicPack)
			{
				OnExternalMusicPackItemsChanged();
				ClearSourceTempItemsPendingUpdate();
			}
		}

		private void OnWorkshopItemsChanged(GameItemBase gameItemBase)
		{
			if (gameItemBase.ContentType == EContentType.MusicPack)
			{
				OnExternalMusicPackItemsChanged();
			}
		}

		private void OnPreInstalledWorkshopItemsProcessed()
		{
			_bInitialExternalContentProcessed = true;
			OnExternalMusicPackItemsChanged();
		}

		private void OnPublishStarted(string publishFolderSpec)
		{
			PostponeAudioInfoUpdateCoroutine();
		}

		private void OnExternalMusicPackItemsChanged()
		{
			StopAudioInfoUpdateCoroutine();
			SetRebuildDynamicListPending(0.1f);
		}

		public void SetRebuildDynamicListPending(float delayTime = 5f)
		{
			if (delayTime <= 0f)
			{
				_rebuildDynamicListPendingTimer = 0f;
				RebuildDynamicList();
			}
			else
			{
				_rebuildDynamicListPendingTimer = delayTime;
			}
		}

		private void ProcessRebuildDynamicListPending()
		{
			if (_rebuildDynamicListPendingTimer > 0f)
			{
				_rebuildDynamicListPendingTimer -= Time.unscaledDeltaTime;
				if (_rebuildDynamicListPendingTimer <= 0f)
				{
					_rebuildDynamicListPendingTimer = 0f;
					RebuildDynamicList();
				}
			}
		}

		public string GetDynamicPlaylistJSONFileSpec()
		{
			return Path.Combine(PlatformFileManager.CloudDirectory, "dynamicplaylist.json");
		}

		public bool LoadFromFile()
		{
			bool result = false;
			string dynamicPlaylistJSONFileSpec = GetDynamicPlaylistJSONFileSpec();
			if (PlatformFileManager.FileExists(dynamicPlaylistJSONFileSpec))
			{
				try
				{
					BinaryReader reader = null;
					PlatformFileManager.Load(dynamicPlaylistJSONFileSpec, out reader);
					string input;
					using (reader)
					{
						input = reader.ReadString();
					}
					if (!fsJsonParser.Parse(input, out var data).Failed)
					{
						fsSerializer obj = CreateSerializer();
						DynPlaylistSerializedData instance = null;
						if (!obj.TryDeserialize(data, ref instance).Failed)
						{
							if (instance._jsonFileVersionNum == 1)
							{
								if (instance._bUseRMSNormalisation == _config._bUseRMSNormalisation && instance._normalisationdB == _config._normalisationdB)
								{
									_sourcesList = instance._sourcesList;
									_currentPlaybackMode = instance._currentPlaybackMode;
									ExtContentMessages.LogDebug($"Successfully loaded {_sourcesList.Count} dynamic playlist source items from '{dynamicPlaylistJSONFileSpec}'");
									result = true;
								}
								else
								{
									ExtContentMessages.LogDebug(string.Format("Dynamic playlist JSON file mismatch of normalisation params (read:{0}, expecting:{1}) reading file '{2}'", string.Format("RMS:{0}, {1}dB", instance._bUseRMSNormalisation ? "Y" : "N", instance._normalisationdB), string.Format("RMS:{0}, {1}dB", _config._bUseRMSNormalisation ? "Y" : "N", _config._normalisationdB), dynamicPlaylistJSONFileSpec));
								}
							}
							else
							{
								ExtContentMessages.LogDebug($"Dynamic playlist JSON file version number mismatch (read:{instance._jsonFileVersionNum}, expecting:{1}) reading file '{dynamicPlaylistJSONFileSpec}'");
							}
						}
						else
						{
							ExtContentMessages.LogError($"Deserialisation error encountered whilst loading file '{dynamicPlaylistJSONFileSpec}'");
						}
					}
					else
					{
						ExtContentMessages.LogError($"JSON parsing error encountered whilst loading file '{dynamicPlaylistJSONFileSpec}'");
					}
				}
				catch (Exception ex)
				{
					ExtContentMessages.LogError(string.Format("Exception error encountered whilst loading file '{1}' - ('{0}') ", ex.ToString(), dynamicPlaylistJSONFileSpec));
				}
			}
			else
			{
				ExtContentMessages.LogDebug($"Dynamic playlist file not found for loading '{dynamicPlaylistJSONFileSpec}'");
			}
			return result;
		}

		public bool SaveToFile()
		{
			bool result = false;
			string dynamicPlaylistJSONFileSpec = GetDynamicPlaylistJSONFileSpec();
			PlatformFileManager.EnsureDirectoryExists(Path.GetDirectoryName(dynamicPlaylistJSONFileSpec));
			DynPlaylistSerializedData dynPlaylistSerializedData = new DynPlaylistSerializedData();
			dynPlaylistSerializedData._jsonFileVersionNum = 1;
			dynPlaylistSerializedData._bUseRMSNormalisation = _config._bUseRMSNormalisation;
			dynPlaylistSerializedData._normalisationdB = _config._normalisationdB;
			dynPlaylistSerializedData._sourcesList = _sourcesList;
			dynPlaylistSerializedData._currentPlaybackMode = _currentPlaybackMode;
			if (!CreateSerializer().TrySerialize(dynPlaylistSerializedData, out var data).Failed)
			{
				string json = fsJsonPrinter.PrettyJson(data);
				try
				{
					Action<BinaryWriter> writeAction = delegate(BinaryWriter binaryWriter)
					{
						binaryWriter.Write(json);
					};
					PlatformFileManager.Save(dynamicPlaylistJSONFileSpec, writeAction, useBackups: false);
					ExtContentMessages.LogDebug($"Successfully saved dynamic playlist '{dynamicPlaylistJSONFileSpec}'");
					result = true;
				}
				catch (Exception ex)
				{
					ExtContentMessages.LogError(string.Format("Exception error encountered whilst saving file '{1}' - ('{0}')", ex.ToString(), dynamicPlaylistJSONFileSpec));
				}
			}
			else
			{
				ExtContentMessages.LogError($"Serialisation error encountered whilst saving file '{dynamicPlaylistJSONFileSpec}'");
			}
			return result;
		}

		private fsSerializer CreateSerializer()
		{
			fsSerializer fsSerializer2 = new fsSerializer();
			fsSerializer2.Config.DefaultMemberSerialization = fsMemberSerialization.OptOut;
			fsSerializer2.Config.EnablePropertySerialization = false;
			fsSerializer2.Config.IgnoreSerializeAttributes = new Type[3]
			{
				typeof(DontSaveAttribute),
				typeof(NonSerializedAttribute),
				typeof(fsIgnoreAttribute)
			};
			return fsSerializer2;
		}

		public void SetSaveToFilePending()
		{
			_bSaveToFilePending = true;
		}

		private void ProcessSaveToFilePending()
		{
			if (_bSaveToFilePending)
			{
				_bSaveToFilePending = false;
				SaveToFile();
			}
		}

		public void SetRebuildEnabledItemsListPending()
		{
			_bRebuildEnabledItemsListPending = true;
		}

		private void ProcessRebuildEnabledItemsListPending()
		{
			if (_bRebuildEnabledItemsListPending)
			{
				_bRebuildEnabledItemsListPending = false;
				BuildEnabledItemsListImpl();
			}
		}

		private void RemovePlatformDisabledSourceItems()
		{
			if (_bAllowExternalContentSourceItems)
			{
				return;
			}
			bool flag = false;
			while (!flag)
			{
				flag = true;
				foreach (DynPlaylistSourceItem sources in _sourcesList)
				{
					if (sources._type != DynPlaylistSource.Internal)
					{
						_sourcesList.Remove(sources);
						flag = false;
						break;
					}
				}
			}
		}

		private void RebuildDynamicList()
		{
			_bAudioInfoUpdateCoroutinePostponed = false;
			StopAudioInfoUpdateCoroutine();
			CheckDuplicateSourceTrackItemRemoval();
			CheckUpdateSourceItemsInternal();
			CheckUpdateSourceItemsExternalLocalMods();
			CheckUpdateSourceItemsExternalWorkshop();
			if (_bInitialExternalContentProcessed)
			{
				EnsureAtLeastOneTrackEnabled();
			}
			BuildEnabledItemsListImpl();
			LogAllDynamicPlaylistItems();
			if (this.OnDynamicPlaylistChanged != null)
			{
				this.OnDynamicPlaylistChanged();
			}
			StartAudioInfoUpdateCoroutine();
		}

		private void CheckDuplicateSourceTrackItemRemoval()
		{
			foreach (DynPlaylistSourceItem sources in _sourcesList)
			{
				if (sources._type == DynPlaylistSource.Internal)
				{
					continue;
				}
				bool flag = false;
				while (!flag)
				{
					flag = true;
					int i = 0;
					for (int count = sources._trackItems.Count; i < count; i++)
					{
						string itemId = sources._trackItems[i]._itemId;
						bool flag2 = false;
						for (int j = i + 1; j < count; j++)
						{
							if (sources._trackItems[j]._itemId == itemId)
							{
								ExtContentMessages.LogDebug($"[DYNPLMGR]: Removed duplicate track '{sources._trackItems[j]._itemId}' from music pack '{sources._sourceName}'");
								flag2 = true;
								sources._trackItems.RemoveAt(j);
								break;
							}
						}
						if (flag2)
						{
							flag = false;
							break;
						}
					}
				}
			}
		}

		private void OnLocalize()
		{
			DynPlaylistSourceItem dynPlaylistSourceItem = FindFirstSourceItemOfType(DynPlaylistSource.Internal, bIncludeInvalidContentItems: true);
			if (dynPlaylistSourceItem != null)
			{
				foreach (DynPlaylistTrackItem trackItem in dynPlaylistSourceItem._trackItems)
				{
					string radioSongItemId = trackItem._itemId;
					RadioSong radioSong = _radioConfig.Playlist.Find((RadioSong item) => item.SongNameLoc.Term == radioSongItemId);
					if (radioSong != null)
					{
						trackItem._artistName = radioSong.GetArtistDisplayName();
						trackItem._trackName = radioSong.GetSongDisplayName();
					}
				}
			}
			if (this.OnDynamicPlaylistChanged != null)
			{
				this.OnDynamicPlaylistChanged();
			}
		}

		private void CheckUpdateSourceItemsInternal()
		{
			DynPlaylistSourceItem dynPlaylistSourceItem = FindFirstSourceItemOfType(DynPlaylistSource.Internal, bIncludeInvalidContentItems: true);
			if (dynPlaylistSourceItem == null)
			{
				dynPlaylistSourceItem = AddNewSourceItem(DynPlaylistSource.Internal, "Internal", ScriptLocalization.Menu_UGC_MusicPack.TwoPointRadio_CS);
			}
			if (dynPlaylistSourceItem == null)
			{
				return;
			}
			dynPlaylistSourceItem._bContentValid = true;
			dynPlaylistSourceItem._sourceName = ScriptLocalization.Menu_UGC_MusicPack.TwoPointRadio_CS;
			int i = 0;
			for (int count = _radioConfig.Playlist.Count; i < count; i++)
			{
				RadioSong radioSong = _radioConfig.Playlist[i];
				radioSong.SongName = $"Internal song {i}";
				string term = radioSong.SongNameLoc.Term;
				DynPlaylistTrackItem dynPlaylistTrackItem = dynPlaylistSourceItem.FindTrackItemById(term);
				if (dynPlaylistTrackItem == null)
				{
					dynPlaylistTrackItem = AddNewTrackItem(dynPlaylistSourceItem, term);
					if (dynPlaylistTrackItem != null)
					{
						dynPlaylistTrackItem._bEnabled = radioSong.EnabledByDefault;
					}
				}
				if (dynPlaylistTrackItem != null)
				{
					dynPlaylistTrackItem._internalItemIndex = i;
					dynPlaylistTrackItem._sampleLengthPerChannel = -1;
					dynPlaylistTrackItem._artistName = radioSong.GetArtistDisplayName();
					dynPlaylistTrackItem._trackName = radioSong.GetSongDisplayName();
				}
			}
			bool flag = false;
			while (!flag)
			{
				flag = true;
				foreach (DynPlaylistTrackItem trackItem in dynPlaylistSourceItem._trackItems)
				{
					string radioSongItemId = trackItem._itemId;
					if (_radioConfig.Playlist.Find((RadioSong item) => item.SongNameLoc.Term == radioSongItemId) == null)
					{
						dynPlaylistSourceItem._trackItems.Remove(trackItem);
						flag = false;
						break;
					}
				}
			}
		}

		private void CheckUpdateSourceItemsExternalLocalMods()
		{
			CheckUpdateSourceItemsExternalGeneral(ExtContentUtils.ExtContentManager.ContentSourceLocalMods, DynPlaylistSource.LocalMod);
		}

		private void CheckUpdateSourceItemsExternalWorkshop()
		{
			CheckUpdateSourceItemsExternalGeneral(ExtContentUtils.ExtContentManager.ContentSourceWorkshop, DynPlaylistSource.Workshop);
		}

		private void CheckUpdateSourceItemsExternalGeneral(ExtContentSourceBase extContentSourceBase, DynPlaylistSource sourceType)
		{
			if (!_bAllowExternalContentSourceItems)
			{
				return;
			}
			bool flag = false;
			List<GameItemBase> allGameItems = extContentSourceBase.GetAllGameItems(EContentType.MusicPack);
			if (allGameItems.Count > 0)
			{
				foreach (GameItemBase item in allGameItems)
				{
					GameItemMusicPack gameItemMusicPack = item as GameItemMusicPack;
					string musicPackItemId = gameItemMusicPack.ContentID;
					bool flag2 = false;
					DynPlaylistSourceItem dynPlaylistSourceItem = _sourcesList.Find((DynPlaylistSourceItem sourecItem) => sourecItem._itemId == musicPackItemId);
					if (dynPlaylistSourceItem != null)
					{
						dynPlaylistSourceItem._bContentValid = true;
						dynPlaylistSourceItem._sourceName = gameItemMusicPack.Title;
						foreach (MusicPackSourceItem item2 in gameItemMusicPack.Items)
						{
							string fileName = Path.GetFileName(item2.FileSpec);
							int fileContentsId = GetFileContentsId(item2.FileSpec);
							DynPlaylistTrackItem dynPlaylistTrackItem = dynPlaylistSourceItem.FindTrackItemById(fileName, fileContentsId);
							if (dynPlaylistTrackItem == null)
							{
								dynPlaylistTrackItem = AddNewTrackItem(dynPlaylistSourceItem, fileName);
							}
							if (dynPlaylistTrackItem != null)
							{
								dynPlaylistTrackItem._artistName = item2.ArtistName;
								dynPlaylistTrackItem._trackName = item2.TrackName;
								dynPlaylistTrackItem._fileContentsId = fileContentsId;
								CheckUpdateAudioInfoFromMusicPackGameItem(gameItemMusicPack, dynPlaylistTrackItem);
								CheckUpdateAudioInfoFromPendingList(dynPlaylistTrackItem);
								ProcessTempPendingUpdateTrackItemsPendingRemoval();
								if (CheckUpdateLocalModMusicPackGameItemFromAudioInfo(gameItemMusicPack, dynPlaylistTrackItem))
								{
									flag2 = true;
								}
							}
						}
						flag = false;
						while (!flag)
						{
							flag = true;
							foreach (DynPlaylistTrackItem trackItem in dynPlaylistSourceItem._trackItems)
							{
								if (gameItemMusicPack.Items.Find((MusicPackSourceItem packTrackItem) => Path.GetFileName(packTrackItem.FileSpec) == trackItem._itemId) == null)
								{
									dynPlaylistSourceItem._trackItems.Remove(trackItem);
									flag = false;
									break;
								}
							}
						}
						int num = 0;
						for (int count = gameItemMusicPack.Items.Count; num < count; num++)
						{
							MusicPackSourceItem musicPackSourceItem = gameItemMusicPack.Items[num];
							string fileName2 = Path.GetFileName(musicPackSourceItem.FileSpec);
							int fileContentsId2 = GetFileContentsId(musicPackSourceItem.FileSpec);
							DynPlaylistTrackItem dynPlaylistTrackItem2 = dynPlaylistSourceItem.FindTrackItemById(fileName2, fileContentsId2);
							int num2 = dynPlaylistSourceItem._trackItems.IndexOf(dynPlaylistTrackItem2);
							if (num2 >= 0 && num2 > num)
							{
								dynPlaylistSourceItem._trackItems[num2] = dynPlaylistSourceItem._trackItems[num];
								dynPlaylistSourceItem._trackItems[num] = dynPlaylistTrackItem2;
							}
						}
					}
					else
					{
						dynPlaylistSourceItem = AddNewSourceItem(sourceType, musicPackItemId, gameItemMusicPack.Title);
						if (dynPlaylistSourceItem != null)
						{
							foreach (MusicPackSourceItem item3 in gameItemMusicPack.Items)
							{
								string fileName3 = Path.GetFileName(item3.FileSpec);
								int fileContentsId3 = GetFileContentsId(item3.FileSpec);
								DynPlaylistTrackItem dynPlaylistTrackItem3 = AddNewTrackItem(dynPlaylistSourceItem, fileName3);
								if (dynPlaylistTrackItem3 != null)
								{
									dynPlaylistTrackItem3._artistName = item3.ArtistName;
									dynPlaylistTrackItem3._trackName = item3.TrackName;
									dynPlaylistTrackItem3._fileContentsId = fileContentsId3;
									CheckUpdateAudioInfoFromMusicPackGameItem(gameItemMusicPack, dynPlaylistTrackItem3);
									CheckUpdateAudioInfoFromPendingList(dynPlaylistTrackItem3);
									ProcessTempPendingUpdateTrackItemsPendingRemoval();
									if (CheckUpdateLocalModMusicPackGameItemFromAudioInfo(gameItemMusicPack, dynPlaylistTrackItem3))
									{
										flag2 = true;
									}
								}
							}
						}
					}
					if (flag2)
					{
						gameItemMusicPack.UpdateMetaDataFile(bSetLastUpdateTimeToNow: false);
					}
				}
			}
			flag = false;
			while (!flag)
			{
				flag = true;
				int num3 = 0;
				for (int count2 = _sourcesList.Count; num3 < count2; num3++)
				{
					DynPlaylistSourceItem sourceItem = _sourcesList[num3];
					if (sourceItem._type == sourceType && allGameItems.Find((GameItemBase gameItem) => gameItem.ContentID == sourceItem._itemId) == null)
					{
						if (sourceType == DynPlaylistSource.LocalMod)
						{
							_sourcesList.Remove(sourceItem);
							flag = false;
							break;
						}
						_sourcesList[num3]._bContentValid = false;
					}
				}
			}
		}

		private DynPlaylistSourceItem FindFirstSourceItemOfType(DynPlaylistSource sourceType, bool bIncludeInvalidContentItems = false)
		{
			return _sourcesList.Find((DynPlaylistSourceItem item) => (item._bContentValid || bIncludeInvalidContentItems) && item._type == sourceType);
		}

		private DynPlaylistSourceItem AddNewSourceItem(DynPlaylistSource sourceType, string sourceItemId, string sourceName)
		{
			DynPlaylistSourceItem dynPlaylistSourceItem = new DynPlaylistSourceItem(sourceType, sourceItemId, sourceName);
			_sourcesList.Add(dynPlaylistSourceItem);
			return dynPlaylistSourceItem;
		}

		private DynPlaylistTrackItem AddNewTrackItem(DynPlaylistSourceItem sourceItem, string itemId)
		{
			DynPlaylistTrackItem dynPlaylistTrackItem = new DynPlaylistTrackItem(sourceItem._type, sourceItem._itemId, itemId);
			sourceItem._trackItems.Add(dynPlaylistTrackItem);
			return dynPlaylistTrackItem;
		}

		private bool CheckUpdateAudioInfoFromPendingList(DynPlaylistTrackItem trackItem)
		{
			bool result = false;
			if (trackItem != null && trackItem._parentSourceType == DynPlaylistSource.LocalMod && !trackItem.IsAudioInfoKnown())
			{
				DynPlaylistTrackItem dynPlaylistTrackItem = _sourceTempItemsPendingUpdate.FindTrackItemById(trackItem._itemId, trackItem._fileContentsId);
				if (dynPlaylistTrackItem != null && dynPlaylistTrackItem.IsAudioInfoKnown())
				{
					trackItem._bDecodeErrors = dynPlaylistTrackItem._bDecodeErrors;
					trackItem._bDecodeFatalError = dynPlaylistTrackItem._bDecodeFatalError;
					trackItem._sampleLengthPerChannel = dynPlaylistTrackItem._sampleLengthPerChannel;
					trackItem._normalisationFactor = dynPlaylistTrackItem._normalisationFactor;
					_tempPendingUpdateTrackItemsPendingRemoval.Add(dynPlaylistTrackItem);
					result = true;
				}
			}
			return result;
		}

		private void CheckProcessTempPendingUpdateTrackItemsPendingRemoval()
		{
			if (_tempPendingUpdateTrackItemsPendingRemoval.Count > 0 && _audioInfoUpdateCoroutine == null)
			{
				ProcessTempPendingUpdateTrackItemsPendingRemoval();
			}
		}

		private bool ProcessTempPendingUpdateTrackItemsPendingRemoval()
		{
			bool result = false;
			while (_tempPendingUpdateTrackItemsPendingRemoval.Count > 0)
			{
				DynPlaylistTrackItem item = _tempPendingUpdateTrackItemsPendingRemoval[0];
				if (_sourceTempItemsPendingUpdate._trackItems.Contains(item))
				{
					result = true;
					_sourceTempItemsPendingUpdate._trackItems.Remove(item);
				}
				_tempPendingUpdateTrackItemsPendingRemoval.RemoveAt(0);
			}
			return result;
		}

		private bool CheckUpdateAudioInfoFromMusicPackGameItem(GameItemMusicPack musicPackGameItem, DynPlaylistTrackItem trackItem)
		{
			bool result = false;
			if (musicPackGameItem != null && trackItem != null)
			{
				if (!trackItem.IsAudioInfoKnown())
				{
					MusicPackSourceItem musicPackSourceItem = musicPackGameItem.Items.Find((MusicPackSourceItem packTrackItem) => Path.GetFileName(packTrackItem.FileSpec) == trackItem._itemId);
					if (musicPackSourceItem != null && musicPackSourceItem.IsAudioInfoKnown())
					{
						trackItem._normalisationFactor = musicPackSourceItem.NormalisationFactor;
						trackItem._sampleLengthPerChannel = musicPackSourceItem.SampleLengthPerChannel;
						result = true;
					}
				}
				trackItem._normalisationFactor = ResetInvalidNormalisationFactor(trackItem._normalisationFactor);
			}
			return result;
		}

		private bool CheckUpdateLocalModMusicPackGameItemFromAudioInfo(GameItemMusicPack musicPackGameItem, DynPlaylistTrackItem trackItem)
		{
			bool result = false;
			if (musicPackGameItem != null && trackItem != null && trackItem._parentSourceType == DynPlaylistSource.LocalMod && trackItem.IsAudioInfoKnown())
			{
				MusicPackSourceItem musicPackSourceItem = musicPackGameItem.Items.Find((MusicPackSourceItem packTrackItem) => Path.GetFileName(packTrackItem.FileSpec) == trackItem._itemId);
				if (musicPackSourceItem != null && !musicPackSourceItem.IsAudioInfoKnown())
				{
					musicPackSourceItem.NormalisationFactor = trackItem._normalisationFactor;
					musicPackSourceItem.SampleLengthPerChannel = trackItem._sampleLengthPerChannel;
					result = true;
				}
			}
			return result;
		}

		private void EnsureAtLeastOneTrackEnabled()
		{
			if (GetNumEnabledTracks() >= 1)
			{
				return;
			}
			ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistAtLeastOneTrackMessageTitle), ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistAtLeastOneTrackMessageBody));
			DynPlaylistSourceItem dynPlaylistSourceItem = FindFirstSourceItemOfType(DynPlaylistSource.Internal, bIncludeInvalidContentItems: true);
			if (dynPlaylistSourceItem != null)
			{
				dynPlaylistSourceItem._bEnabled = true;
				if (dynPlaylistSourceItem.GetNumEnabledTracks() < 1 && dynPlaylistSourceItem._trackItems.Count > 0)
				{
					dynPlaylistSourceItem._trackItems[0]._bEnabled = true;
				}
				SetSaveToFilePending();
			}
		}

		private void BuildEnabledItemsListImpl(bool bIncludeAllInternalItems = false)
		{
			_bEnabledListForceIncludesInternalItems = bIncludeAllInternalItems;
			_enabledTrackItemsList.Clear();
			foreach (DynPlaylistSourceItem sources in _sourcesList)
			{
				bool flag = sources._type == DynPlaylistSource.Internal && bIncludeAllInternalItems;
				if (!(sources.IsEnabled() || flag))
				{
					continue;
				}
				foreach (DynPlaylistTrackItem trackItem in sources._trackItems)
				{
					if (trackItem.IsEnabled() || flag)
					{
						_enabledTrackItemsList.Add(trackItem);
					}
				}
			}
			ExtContentMessages.LogMessage(string.Format("[DYNPLMGR]: Rebuilt enabled items list now containing {0} tracks. Force include internal tracks: {1}", _enabledTrackItemsList.Count, _bEnabledListForceIncludesInternalItems ? "Y" : "N"));
		}

		private bool FindNextPlaybackItem()
		{
			bool result = false;
			int num = -1;
			for (int i = 0; i < 2; i++)
			{
				int count = _enabledTrackItemsList.Count;
				if (count > 0)
				{
					if (_currentPlaybackMode == EPlaybackMode.Sequential)
					{
						int num2 = -1;
						if (!_currentPlaybackItemId.IsNullOrEmpty())
						{
							num2 = _enabledTrackItemsList.FindIndex((DynPlaylistTrackItem item) => item._itemId == _currentPlaybackItemId && item._fileContentsId == _currentPlaybackFileContentsId);
							if (num2 < 0)
							{
								ExtContentMessages.LogError($"[DYNPLMGR]: Find next playlist track. Failed to find current item with id '{_currentPlaybackItemId}' and file contents id '{_currentPlaybackFileContentsId}'");
							}
						}
						if (Level != null && !Level.Config.DesiredStartingRadioTrackID.IsNullOrEmpty() && Level.TimelineManager.CurrentGameDate == new GameDate(0, 0, 0))
						{
							num = _enabledTrackItemsList.FindIndex((DynPlaylistTrackItem item) => item._itemId == Level.Config.DesiredStartingRadioTrackID);
						}
						if (num == -1)
						{
							num = num2 + 1;
							if (num >= count)
							{
								num = 0;
							}
						}
					}
					else if (Level != null && !Level.Config.DesiredStartingRadioTrackID.IsNullOrEmpty() && Level.TimelineManager.CurrentGameDate == new GameDate(0, 0, 0))
					{
						num = _enabledTrackItemsList.FindIndex((DynPlaylistTrackItem item) => item._itemId == Level.Config.DesiredStartingRadioTrackID);
						if (num == -1)
						{
							num = UnityEngine.Random.Range(0, count + 1);
						}
					}
					else
					{
						num = UnityEngine.Random.Range(0, count + 1);
					}
					num = Mathf.Clamp(num, 0, count - 1);
					if (_enabledTrackItemsList[num]._parentSourceType != DynPlaylistSource.Internal)
					{
						CheckUpdateAudioInfoFromPendingList(_enabledTrackItemsList[num]);
						if (_enabledTrackItemsList[num]._sampleLengthPerChannel == 0)
						{
							int num3 = -1;
							int num4 = 0;
							int num5 = num + 1;
							int count2 = _enabledTrackItemsList.Count;
							while (num4 < count2)
							{
								if (num5 >= count2)
								{
									num5 = 0;
								}
								CheckUpdateAudioInfoFromPendingList(_enabledTrackItemsList[num5]);
								if (_enabledTrackItemsList[num5]._sampleLengthPerChannel != 0)
								{
									num3 = num5;
									break;
								}
								num4++;
								num5++;
							}
							if (num3 >= 0)
							{
								num = num3;
							}
							else
							{
								ExtContentMessages.LogError($"[DYNPLMGR]: Find next playlist track. Failed to find alternative track with valid sample length. Invalid track name: '{_enabledTrackItemsList[num]._trackName}'");
								num = -1;
							}
						}
					}
				}
				else
				{
					ExtContentMessages.LogError($"[DYNPLMGR]: Find next playlist track failed. No enables tracks");
				}
				if (num >= 0 || i != 0)
				{
					continue;
				}
				bool flag = false;
				DynPlaylistSourceItem dynPlaylistSourceItem = FindFirstSourceItemOfType(DynPlaylistSource.Internal, bIncludeInvalidContentItems: true);
				if (dynPlaylistSourceItem != null)
				{
					int numEnabledTracks = dynPlaylistSourceItem.GetNumEnabledTracks();
					if (!dynPlaylistSourceItem.IsEnabled() || numEnabledTracks <= 0)
					{
						ExtContentMessages.LogError($"[DYNPLMGR]: Failed to find next playlist track, rebuilding enabled list including all internal tracks ...");
						BuildEnabledItemsListImpl(bIncludeAllInternalItems: true);
						flag = true;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			if (num >= 0 && num < _enabledTrackItemsList.Count)
			{
				_currentPlaybackItemIndex = num;
				_currentPlaybackItemId = _enabledTrackItemsList[_currentPlaybackItemIndex]._itemId;
				_currentPlaybackFileContentsId = _enabledTrackItemsList[_currentPlaybackItemIndex]._fileContentsId;
				ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: NEXT TRACK({7}): {0:00}/{1:00}, Artist:'{2}', TrackName:'{3}', Durn:{4}, ID:{5}, FCID:{8}, ParentID:{6}", _currentPlaybackItemIndex, _enabledTrackItemsList.Count, _enabledTrackItemsList[_currentPlaybackItemIndex]._artistName, _enabledTrackItemsList[_currentPlaybackItemIndex]._trackName, _enabledTrackItemsList[_currentPlaybackItemIndex].GetDurationString(), _enabledTrackItemsList[_currentPlaybackItemIndex]._itemId, _enabledTrackItemsList[_currentPlaybackItemIndex]._itemId, _enabledTrackItemsList[_currentPlaybackItemIndex]._parentItemId, (_currentPlaybackMode == EPlaybackMode.Sequential) ? "SEQ" : "RND", _enabledTrackItemsList[_currentPlaybackItemIndex]._fileContentsId));
				result = true;
			}
			return result;
		}

		private RadioSongMeta GetCurrentItemRadioSong()
		{
			RadioSongMeta result = null;
			DynPlaylistTrackItem dynPlaylistTrackItem = _enabledTrackItemsList[_currentPlaybackItemIndex];
			switch (dynPlaylistTrackItem._parentSourceType)
			{
			case DynPlaylistSource.Internal:
				result = GetTrackItemRadioSongInternal(dynPlaylistTrackItem);
				break;
			case DynPlaylistSource.LocalMod:
				result = CreateTrackItemRadioSongLocalMod(dynPlaylistTrackItem);
				break;
			case DynPlaylistSource.Workshop:
				result = CreateTrackItemRadioSongWorkshop(dynPlaylistTrackItem);
				break;
			}
			return result;
		}

		public string GetTrackItemMP3FileSpec(DynPlaylistTrackItem trackItem)
		{
			string result = string.Empty;
			switch (trackItem._parentSourceType)
			{
			case DynPlaylistSource.LocalMod:
			case DynPlaylistSource.Workshop:
			{
				ExtContentManager extContentManager = ExtContentUtils.ExtContentManager;
				GameItemMusicPack gameItemMusicPack = ((trackItem._parentSourceType == DynPlaylistSource.LocalMod) ? (extContentManager.ContentSourceLocalMods.FindGameItemByID(trackItem._parentItemId) as GameItemMusicPack) : (extContentManager.ContentSourceWorkshop.FindGameItemByID(trackItem._parentItemId) as GameItemMusicPack));
				if (gameItemMusicPack == null)
				{
					break;
				}
				MusicPackSourceItem musicPackSourceItem = gameItemMusicPack.Items.Find((MusicPackSourceItem packTrackItem) => Path.GetFileName(packTrackItem.FileSpec) == trackItem._itemId);
				if (musicPackSourceItem != null)
				{
					string fileSpec = musicPackSourceItem.FileSpec;
					if (!fileSpec.IsNullOrEmpty() && File.Exists(fileSpec))
					{
						result = fileSpec;
					}
				}
				break;
			}
			case DynPlaylistSource.PendingUpdate:
				result = trackItem._updatePendingFileSpec;
				break;
			}
			return result;
		}

		private RadioSongMeta GetTrackItemRadioSongInternal(DynPlaylistTrackItem trackItem)
		{
			RadioSong radioSong = _radioConfig.Playlist.Find((RadioSong findItem) => findItem.SongNameLoc.Term == trackItem._itemId);
			return new RadioSongMeta
			{
				_radioSong = radioSong,
				_mp3NormFactor = 0f
			};
		}

		private RadioSongMeta CreateTrackItemRadioSongLocalMod(DynPlaylistTrackItem trackItem)
		{
			return CreateTrackItemRadioSongExternal(trackItem);
		}

		private RadioSongMeta CreateTrackItemRadioSongWorkshop(DynPlaylistTrackItem trackItem)
		{
			return CreateTrackItemRadioSongExternal(trackItem);
		}

		private RadioSongMeta CreateTrackItemRadioSongExternal(DynPlaylistTrackItem trackItem)
		{
			RadioSongMeta radioSongMeta = null;
			string trackItemMP3FileSpec = GetTrackItemMP3FileSpec(trackItem);
			if (!trackItemMP3FileSpec.IsNullOrEmpty())
			{
				float validNormalisationFactor = GetValidNormalisationFactor(trackItem._normalisationFactor);
				_streamedAudioPlayback.DeInit();
				_streamedAudioPlayback.Init("RadioSong", trackItemMP3FileSpec, trackItem._sampleLengthPerChannel, validNormalisationFactor);
				if (_streamedAudioPlayback.Inited)
				{
					RadioSong radioSong = new RadioSong();
					radioSong.SongNameLoc = default(LocalisedString);
					radioSong.ArtistNameLoc = default(LocalisedString);
					radioSong.ArtistName = trackItem._artistName;
					radioSong.SongName = trackItem._trackName;
					radioSong.Clip = _streamedAudioPlayback.AudioClip;
					radioSong.LeadOutTime = 4f;
					radioSongMeta = new RadioSongMeta();
					radioSongMeta._radioSong = radioSong;
					radioSongMeta._mp3NormFactor = trackItem._normalisationFactor;
				}
			}
			return radioSongMeta;
		}

		private void ProcessDebugInputs()
		{
		}

		private List<DynPlaylistSourceItem> GetCompositeSourcesList()
		{
			List<DynPlaylistSourceItem> list = new List<DynPlaylistSourceItem>();
			if (_config._bAllowAudioInfoUpdateOnImport && _sourceTempItemsPendingUpdate.GetNumEnabledTracks() > 0)
			{
				list.Add(_sourceTempItemsPendingUpdate);
			}
			foreach (DynPlaylistSourceItem sources in _sourcesList)
			{
				list.Add(sources);
			}
			return list;
		}

		private bool SearchTrackItemsForTrackAudioInfo(string mp3FileSpec, ref int sampleLength, ref float normalisationFactor)
		{
			bool flag = false;
			string fileName = Path.GetFileName(mp3FileSpec);
			int fileContentsId = GetFileContentsId(mp3FileSpec);
			List<DynPlaylistSourceItem> compositeSourcesList = GetCompositeSourcesList();
			int i = 0;
			for (int count = compositeSourcesList.Count; i < count; i++)
			{
				if (flag)
				{
					break;
				}
				if (compositeSourcesList[i]._type == DynPlaylistSource.Internal)
				{
					continue;
				}
				int j = 0;
				for (int count2 = compositeSourcesList[i]._trackItems.Count; j < count2; j++)
				{
					if (compositeSourcesList[i]._trackItems[j]._sampleLengthPerChannel > 0 && compositeSourcesList[i]._trackItems[j]._fileContentsId == fileContentsId && compositeSourcesList[i]._trackItems[j]._itemId.Equals(fileName, StringComparison.OrdinalIgnoreCase))
					{
						DynPlaylistTrackItem dynPlaylistTrackItem = compositeSourcesList[i]._trackItems[j];
						if (dynPlaylistTrackItem._sampleLengthPerChannel > 0)
						{
							sampleLength = dynPlaylistTrackItem._sampleLengthPerChannel;
						}
						if (dynPlaylistTrackItem._normalisationFactor > 0f)
						{
							normalisationFactor = dynPlaylistTrackItem._normalisationFactor;
						}
						flag = true;
						break;
					}
				}
			}
			return flag;
		}

		private bool ShouldAllowExternalContentItems()
		{
			return Config._allowExtContentSourceItemsPC;
		}

		private float dBToFloat(float dBValue)
		{
			return Mathf.Pow(10f, dBValue / 20f);
		}

		private float GetValidNormalisationFactor(float inNormalisationFactor)
		{
			float result = inNormalisationFactor;
			if (!IsNormalisationFactorValid(inNormalisationFactor))
			{
				result = dBToFloat(_config._unnormalisedPlaybackdB);
			}
			return result;
		}

		public static bool IsNormalisationFactorValid(float inNormalisationFactor)
		{
			if (inNormalisationFactor > 0f)
			{
				return inNormalisationFactor <= 10f;
			}
			return false;
		}

		public static float ResetInvalidNormalisationFactor(float inNormalisationFactor)
		{
			float num = inNormalisationFactor;
			if (!IsNormalisationFactorValid(num))
			{
				ExtContentMessages.LogError($"Invalid floating point normalisation factor encountered: {num} - resetting to zero");
				num = 0f;
			}
			return num;
		}

		private void StartAudioInfoUpdateCoroutine()
		{
			if (_audioInfoUpdateCoroutine == null)
			{
				_audioInfoUpdateCoroutine = _behaviourToRunCoroutinesOn.StartCoroutine(AudioInfoUpdateCoroutine());
			}
		}

		private void StopAudioInfoUpdateCoroutine()
		{
			if (_audioInfoUpdateCoroutine != null)
			{
				_behaviourToRunCoroutinesOn.StopCoroutine(_audioInfoUpdateCoroutine);
				_audioInfoUpdateCoroutine = null;
				ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
				ExtContentMessages.LogDebug($"[DYNPLMGR]: Stopped track duration update coroutine ...");
				ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			}
			_streamedAudioTrackUpdate.DeInit();
		}

		private void PostponeAudioInfoUpdateCoroutine(float delayTime = 5f, bool bForcePostpone = false)
		{
			_bAudioInfoUpdateCoroutinePostponed = _audioInfoUpdateCoroutine != null || bForcePostpone;
			_audioInfoUpdateCoroutinePostponedTimer = Mathf.Max(0.001f, delayTime);
			StopAudioInfoUpdateCoroutine();
		}

		private void ProcessPostponedAudioInfoUpdateCoroutine()
		{
			if (_bAudioInfoUpdateCoroutinePostponed)
			{
				_audioInfoUpdateCoroutinePostponedTimer -= Time.unscaledDeltaTime;
				if (_audioInfoUpdateCoroutinePostponedTimer <= 0f)
				{
					_bAudioInfoUpdateCoroutinePostponed = false;
					StartAudioInfoUpdateCoroutine();
				}
			}
		}

		private IEnumerator AudioInfoUpdateCoroutine()
		{
			ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			ExtContentMessages.LogDebug($"[DYNPLMGR]: Started track duration update coroutine ...");
			ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			ExtContentManager ecMgr = ExtContentUtils.ExtContentManager;
			int numReadBufferBytes = _config._updateAudioInfoProcessSizeKb * 1024;
			byte[] readBuffer = new byte[numReadBufferBytes];
			float cYieldTime = 0f;
			int numTracksChecked = 0;
			int numTracksDurationKnown = 0;
			int numTracksDurationDetermined = 0;
			int numTracksWithDecodeErrors = 0;
			int numTracksWithDecodeFatalErrors = 0;
			int numTracksExcluded = 0;
			bool bRebuildSourcesListReqd = false;
			float floatSampleScaler = Convert.ToSingle(32768);
			List<DynPlaylistSourceItem> compositeSourcesList = GetCompositeSourcesList();
			int numTracksToCheck = 0;
			int i = 0;
			for (int count = compositeSourcesList.Count; i < count; i++)
			{
				DynPlaylistSourceItem dynPlaylistSourceItem = compositeSourcesList[i];
				if (dynPlaylistSourceItem._bContentValid && dynPlaylistSourceItem._type != DynPlaylistSource.Internal)
				{
					numTracksToCheck += dynPlaylistSourceItem._trackItems.Count;
				}
			}
			int si = 0;
			while (si < compositeSourcesList.Count)
			{
				DynPlaylistSourceItem sourceItem = compositeSourcesList[si];
				int num14;
				if (sourceItem._bContentValid && sourceItem._type != DynPlaylistSource.Internal)
				{
					bool bCurrentLocalModGameItemDirty = false;
					bool bIsLocalModSourceItem = sourceItem._type == DynPlaylistSource.LocalMod;
					for (int ti = 0; ti < sourceItem._trackItems.Count; ti = num14)
					{
						numTracksChecked++;
						DynPlaylistTrackItem trackItem = sourceItem._trackItems[ti];
						if (!trackItem._bDecodeFatalError)
						{
							if (bIsLocalModSourceItem && !trackItem.IsAudioInfoKnown() && CheckUpdateAudioInfoFromPendingList(trackItem))
							{
								if (ecMgr.ContentSourceLocalMods.FindGameItemByID(sourceItem._itemId) is GameItemMusicPack musicPackGameItem && CheckUpdateLocalModMusicPackGameItemFromAudioInfo(musicPackGameItem, trackItem))
								{
									bCurrentLocalModGameItemDirty = true;
								}
								ProcessTempPendingUpdateTrackItemsPendingRemoval();
							}
							if (!trackItem.IsAudioInfoKnown())
							{
								numTracksDurationDetermined++;
								if (numTracksDurationDetermined % 5 == 0)
								{
									SetSaveToFilePending();
								}
								string trackItemMP3FileSpec = GetTrackItemMP3FileSpec(sourceItem._trackItems[ti]);
								if (!trackItemMP3FileSpec.IsNullOrEmpty() && PlatformFileManager.FileExists(trackItemMP3FileSpec))
								{
									string mp3FileName = (_audioInfoUpdateProcessingItemId = Path.GetFileName(trackItemMP3FileSpec));
									_audioInfoUpdateProcessingFilerContentsId = GetFileContentsId(trackItemMP3FileSpec);
									bool bDecodeErrors = false;
									bool bDecodeFatalError = false;
									int num = 0;
									int pcmFrequency = 0;
									float normalisationFactor = 0f;
									float normalisationdB = _config._normalisationdB;
									float num2 = dBToFloat(normalisationdB);
									float num3 = -1f;
									float fSampleValueScaledMaxAbs = -1f;
									_streamedAudioTrackUpdate.DeInit();
									_streamedAudioTrackUpdate.Init("BGUpdate", trackItemMP3FileSpec, -1, -1f, bUseMemoryStream: true, bCreateAudioClip: false);
									if (_streamedAudioTrackUpdate.Inited)
									{
										MP3Stream mp3Stream = _streamedAudioTrackUpdate.MP3Stream;
										int pcmBytesPerSample = 2;
										pcmFrequency = mp3Stream.Frequency;
										int pcmNumChannels = mp3Stream.ChannelCount;
										int num4 = 600 * pcmFrequency * pcmNumChannels;
										int maxDurationNumBytes = num4 * pcmBytesPerSample;
										fSampleValueScaledMaxAbs = -1f;
										double fSampleAmplSquaresTotal = 0.0;
										int totalBytesRead = 0;
										int totalSamplesRead = 0;
										bool bAllBytesRead = false;
										while (!bDecodeErrors && !bAllBytesRead && totalBytesRead < maxDurationNumBytes)
										{
											int num5 = 0;
											try
											{
												num5 = mp3Stream.Read(readBuffer, 0, numReadBufferBytes);
												if (num5 > 0)
												{
													totalBytesRead += num5;
												}
												if (mp3Stream.IsEOF || num5 < numReadBufferBytes)
												{
													bAllBytesRead = true;
												}
											}
											catch (Exception ex)
											{
												bDecodeErrors = true;
												ExtContentMessages.LogDebug($"[DYNPLMGR]: Decode Error reading file '{mp3FileName}'. Bytes read: {totalBytesRead}, Durn:{ExtContentUtils.SecsToMinsAndSecsString(totalBytesRead / (pcmFrequency * pcmBytesPerSample * pcmNumChannels))}, Error: '{ex.ToString()}'");
											}
											if (_config._bPerformTrackNormalisation && !bDecodeErrors)
											{
												int num6 = num5 / pcmBytesPerSample;
												totalSamplesRead += num6;
												int num7 = 0;
												int num8 = 0;
												while (num8 < num6)
												{
													int num9 = readBuffer[num7];
													float num10 = Convert.ToSingle((short)(ushort)((readBuffer[num7 + 1] << 8) | num9)) / floatSampleScaler;
													if (!_config._bUseRMSNormalisation)
													{
														float num11 = Mathf.Abs(num10);
														if (fSampleValueScaledMaxAbs < num11)
														{
															fSampleValueScaledMaxAbs = num11;
														}
													}
													else
													{
														fSampleAmplSquaresTotal += (double)(num10 * num10);
													}
													num8++;
													num7 += 2;
												}
											}
											yield return (cYieldTime > 0f) ? new WaitForSeconds(cYieldTime) : null;
										}
										_streamedAudioTrackUpdate.DeInit();
										num = totalBytesRead / pcmBytesPerSample / pcmNumChannels;
										normalisationFactor = 0f;
										normalisationdB = _config._normalisationdB;
										num2 = dBToFloat(normalisationdB);
										num3 = -1f;
										if (_config._bPerformTrackNormalisation)
										{
											if (_config._bUseRMSNormalisation)
											{
												if (totalSamplesRead > 0)
												{
													num3 = Mathf.Sqrt((float)(fSampleAmplSquaresTotal / (double)totalSamplesRead));
													if (num3 > 0f)
													{
														normalisationFactor = num2 / num3;
													}
												}
											}
											else if (fSampleValueScaledMaxAbs > 0f)
											{
												normalisationFactor = num2 / fSampleValueScaledMaxAbs;
											}
										}
										else
										{
											normalisationFactor = dBToFloat(_config._unnormalisedPlaybackdB);
										}
									}
									else
									{
										bDecodeErrors = true;
									}
									if (bDecodeErrors)
									{
										numTracksWithDecodeErrors++;
										bDecodeFatalError = num <= 1323000;
										if (bDecodeFatalError)
										{
											numTracksExcluded++;
											numTracksWithDecodeFatalErrors++;
											bRebuildSourcesListReqd = true;
											int num12 = _enabledTrackItemsList.FindIndex((DynPlaylistTrackItem item) => item._itemId == trackItem._itemId && item._fileContentsId == trackItem._fileContentsId && item._parentItemId == trackItem._parentItemId);
											if (num12 >= 0)
											{
												_enabledTrackItemsList.RemoveAt(num12);
											}
										}
									}
									trackItem._sampleLengthPerChannel = num;
									trackItem._normalisationFactor = normalisationFactor;
									trackItem._bDecodeErrors = bDecodeErrors;
									trackItem._bDecodeFatalError = bDecodeFatalError;
									if (bDecodeFatalError)
									{
										trackItem._bEnabled = false;
									}
									if (trackItem.IsAudioInfoKnown())
									{
										if (bIsLocalModSourceItem && ecMgr.ContentSourceLocalMods.FindGameItemByID(sourceItem._itemId) is GameItemMusicPack musicPackGameItem2 && CheckUpdateLocalModMusicPackGameItemFromAudioInfo(musicPackGameItem2, trackItem))
										{
											bCurrentLocalModGameItemDirty = true;
										}
										if (_bEnabledListForceIncludesInternalItems)
										{
											SetRebuildEnabledItemsListPending();
										}
									}
									if (this.OnTrackAudioInfoUpdated != null)
									{
										this.OnTrackAudioInfoUpdated(trackItem);
									}
									int num13 = ((pcmFrequency != 0) ? (trackItem._sampleLengthPerChannel / pcmFrequency) : 0);
									_ = num13 / 60;
									_ = num13 % 60;
									ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: AUDIO INFO UPDATED. DecErrs:{4}, Fatal:{7}, Src:'{6}', Trk:'{0}', Samp/Ch:{1:0000000000}, {5}, Durn:{2}", mp3FileName.PadRight(32, '_'), trackItem._sampleLengthPerChannel, trackItem.GetDurationString(), 0, trackItem._bDecodeErrors ? "Y" : "N", string.Format("Norm({0}): F:{1:0.00}, RMS:{2}({3:0.000}), {4}dB({5:0.00}), MaxAbs:{6:0.000}, ", _config._bPerformTrackNormalisation ? "Y" : "N", trackItem._normalisationFactor, _config._bUseRMSNormalisation ? "Y" : "N", num3, (int)normalisationdB, num2, fSampleValueScaledMaxAbs), sourceItem._sourceName.PadRight(20, '_'), trackItem._bDecodeFatalError ? "Y" : "N"));
									yield return (cYieldTime > 0f) ? new WaitForSeconds(cYieldTime) : null;
									_audioInfoUpdateProcessingItemId = string.Empty;
									_audioInfoUpdateProcessingFilerContentsId = 0;
								}
							}
							else
							{
								numTracksDurationKnown++;
							}
						}
						else
						{
							numTracksWithDecodeFatalErrors++;
						}
						yield return (cYieldTime > 0f) ? new WaitForSeconds(cYieldTime) : null;
						if (sourceItem._type != DynPlaylistSource.PendingUpdate)
						{
							ProcessTempPendingUpdateTrackItemsPendingRemoval();
						}
						num14 = ti + 1;
					}
					if (bCurrentLocalModGameItemDirty && ecMgr.ContentSourceLocalMods.FindGameItemByID(sourceItem._itemId) is GameItemMusicPack gameItemMusicPack)
					{
						gameItemMusicPack.UpdateMetaDataFile(bSetLastUpdateTimeToNow: false);
					}
				}
				num14 = si + 1;
				si = num14;
			}
			ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			ExtContentMessages.LogDebug("[DYNPLMGR]: Sample lengths determined:");
			ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: {0} : {1}", "Num tracks to check".PadRight(40, '_'), numTracksToCheck.ToString()));
			ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: {0} : {1}", "Num tracks checked".PadRight(40, '_'), numTracksChecked.ToString()));
			ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: {0} : {1}", "Num tracks with known duration".PadRight(40, '_'), numTracksDurationKnown.ToString()));
			ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: {0} : {1}", "Num tracks duration determined".PadRight(40, '_'), numTracksDurationDetermined.ToString()));
			ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: {0} : {1}", "Num tracks with decode errors".PadRight(40, '_'), numTracksWithDecodeErrors.ToString()));
			ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: {0} : {1}", "Num tracks with fatal decode errors".PadRight(40, '_'), numTracksWithDecodeFatalErrors.ToString()));
			ExtContentMessages.LogDebug(string.Format("[DYNPLMGR]: {0} : {1}", "Num tracks excluded from playlist".PadRight(40, '_'), numTracksExcluded.ToString()));
			ExtContentMessages.LogDebug("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			if (numTracksDurationDetermined > 0 || numTracksWithDecodeErrors > 0)
			{
				SetSaveToFilePending();
			}
			if (bRebuildSourcesListReqd)
			{
				SetRebuildDynamicListPending(0.1f);
			}
			_audioInfoUpdateCoroutine = null;
			yield return null;
		}

		private void LogAllDynamicPlaylistItems()
		{
		}

		private void TestFloatCultures()
		{
			float num = 0f;
			string empty = string.Empty;
			empty = 12.3456f.ToString();
			empty = 12.3456f.ToString(CultureInfo.InvariantCulture);
			empty = 12.3456f.ToString(CultureInfo.GetCultureInfo("fr"));
			empty = "12.3456";
			try
			{
				num = Convert.ToSingle(empty);
			}
			catch (Exception)
			{
			}
			empty = "12.3456";
			try
			{
				num = Convert.ToSingle(empty, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
			}
			empty = "12.3456";
			try
			{
				num = Convert.ToSingle(empty, CultureInfo.GetCultureInfo("fr"));
			}
			catch (Exception)
			{
			}
			empty = "12,3456";
			try
			{
				num = Convert.ToSingle(empty);
			}
			catch (Exception)
			{
			}
			empty = "12,3456";
			try
			{
				num = Convert.ToSingle(empty, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
			}
			empty = "12,3456";
			try
			{
				num = Convert.ToSingle(empty, CultureInfo.GetCultureInfo("fr"));
			}
			catch (Exception)
			{
			}
			empty = "12.3456";
			empty = "12,3456";
		}

		private string GetValidFloatStringValue(string inStr)
		{
			string text = inStr;
			char[] array = text.ToCharArray();
			int i = 0;
			for (int num = array.Length; i < num; i++)
			{
				if (!char.IsDigit(array[i]))
				{
					array[i] = '.';
				}
			}
			text = new string(array);
			while (text.Contains(".."))
			{
				text = text.Replace("..", ".");
			}
			return text;
		}
	}
}
