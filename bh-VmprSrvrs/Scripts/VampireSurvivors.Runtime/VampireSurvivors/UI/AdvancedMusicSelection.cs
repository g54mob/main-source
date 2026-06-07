using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class AdvancedMusicSelection : BasePopup
	{
		public delegate void OnSelectionChanged();

		private enum NavigationPhase
		{
			TRACKS = 0,
			SETTINGS = 1,
			UNIVERSAL = 2
		}

		[CompilerGenerated]
		private sealed class _003CStart_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AdvancedMusicSelection _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CStart_003Ed__58(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Albums")]
		[SerializeField]
		private RectTransform _AlbumContainer;

		[SerializeField]
		private GameObject _AlbumPrefab;

		[SerializeField]
		private UICarousel _Carousel;

		[SerializeField]
		private CanvasGroup _AlbumGroup;

		[Header("Tracks")]
		[SerializeField]
		private RectTransform _TrackContainer;

		[SerializeField]
		private GameObject _TrackPrefab;

		[SerializeField]
		private CanvasGroup _TrackGroup;

		[Header("Info Panel")]
		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private TextMeshProUGUI _Author;

		[SerializeField]
		private TextMeshProUGUI _Duration;

		[SerializeField]
		private TextMeshProUGUI _Playback;

		[SerializeField]
		private TextMeshProUGUI _Modifier;

		[SerializeField]
		private TextMeshProUGUI _ModifierLabel;

		[SerializeField]
		private TickBoxUI _PlayOnlyDuringGameplay;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Button _ModifierButton;

		[SerializeField]
		private Button _ConfirmButton;

		[SerializeField]
		private Button _PlaybackButton;

		[SerializeField]
		private TickBoxUI _LockSelected;

		[Header("General")]
		[SerializeField]
		private RectTransform _Panel;

		[SerializeField]
		private Button _CloseButton;

		[SerializeField]
		private GameObject _InfoPanel;

		[Header("Sensitivity")]
		[SerializeField]
		private float _HorizontalAlbumNavigationSensitivity;

		private List<KeyValuePair<AlbumType, AlbumData>> _albums;

		private List<GameObject> _spawnedAlbums;

		private List<TrackItemUI> _spawnedTracks;

		private List<BgmModType> _speedList;

		private List<BgmPlaybackType> _playbackList;

		private BgmModType _selectedSpeed;

		private int _speedIndex;

		private BgmPlaybackType _selectedPlayback;

		private int _playbackIndex;

		private int _albumIndex;

		private Rewired.Player _player;

		private TrackItemUI _selectedTrack;

		private DataManager _data;

		private MultiplayerManager _multiplayer;

		private PlayerOptions _playerOptions;

		private DiContainer _diContainer;

		private BgmType _defaultSong;

		private bool _canInteract;

		private bool _axisReset;

		private int _currentTrackIndex;

		private string _currentCacheName;

		private BgmType _currentPlayingTrack;

		private bool _initialLockSelected;

		private BgmType _initialBGMType;

		private BgmModType _initialBGMMod;

		private NavigationPhase _navPhase;

		public event OnSelectionChanged SelectedTrackChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Inject]
		private void Construct(DataManager data, MultiplayerManager multi, PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		private void ChangeAlbum(int index)
		{
		}

		private void SpawnTracksForAlbum()
		{
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__58))]
		private IEnumerator Start()
		{
			return null;
		}

		private bool GetMusicData(BgmType bgmType, out MusicData musicData)
		{
			musicData = null;
			return false;
		}

		private void PlayAtSpeed()
		{
		}

		public void Confirm()
		{
		}

		public void SetCurrentSelectedSong(BgmType current)
		{
		}

		public void ClosePopup()
		{
		}

		private void ReleaseBGM()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetTracksUnlocked()
		{
		}

		private void TogglePlayDuringRun(bool isOn)
		{
		}

		public void AddSpeed(BgmModType bgmMod)
		{
		}

		private void AddPlayback(BgmPlaybackType pb)
		{
		}

		public void SetSpeed(BgmModType speed)
		{
		}

		public void SetPlayback(BgmPlaybackType pb)
		{
		}

		public void PreviousPlayback()
		{
		}

		public void PreviousSpeed()
		{
		}

		public void NextSpeed()
		{
		}

		public void NextPlayback()
		{
		}

		private void OnInputMethodChanged(UIHelper.ActiveInputType newinput)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void VisuallyDisableInfoPanel()
		{
		}

		private void VisuallyEnableInfoPanel()
		{
		}

		private void VisuallyDisableTopPanel()
		{
		}

		private void VisuallyEnableTopPanel()
		{
		}

		private void SetTrackNavigation(Selectable defaultSelected = null)
		{
		}

		private int FindAlbumIndexForTrack(BgmType track)
		{
			return 0;
		}

		private void SetPhase3Navigation()
		{
		}

		private void SetUniversalNavigation()
		{
		}

		public void SelectNextTrack()
		{
		}

		public void SelectTrack(TrackItemUI track)
		{
		}

		public void SelectPreviousTrack()
		{
		}

		private void UpdateInfoPanel()
		{
		}

		public void Populate()
		{
		}

		private void SetDefaultAlbumIndex()
		{
		}

		private Selectable GetDefaultSelectedItem()
		{
			return null;
		}

		private void SpawnAlbums()
		{
		}

		public void SetSelectedTrack(TrackItemUI t)
		{
		}

		private void GenerateTrackNavigation()
		{
		}

		private void SetSpeedName()
		{
		}

		private void SetPlaybackName()
		{
		}

		private TrackItemUI SpawnTrack(BgmType t, MusicData d)
		{
			return null;
		}

		public void ToggleLockSelected(bool b)
		{
		}
	}
}
