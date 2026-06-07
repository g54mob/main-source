using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class SongSelectionPanel : MonoBehaviour
	{
		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private TextMeshProUGUI _SongTitle;

		[SerializeField]
		private TextMeshProUGUI _SpeedName;

		[SerializeField]
		private TickBoxUI _LockSelectedBox;

		private SignalBus _signalBus;

		private DataManager _data;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		private Dictionary<BgmType, MusicData> _musicData;

		private List<BgmModType> _speedList;

		private List<BgmType> _songList;

		private BgmType _selectedSong;

		private BgmModType _selectedSpeed;

		private BgmType _previousSong;

		private int _speedIndex;

		private int _songIndex;

		public static bool UserHasChangedSong;

		private bool _isInitialSet;

		private bool _forceCharacterSongUntilManuallyChanged;

		private float _crossFadeTime;

		[Inject]
		private void Construct(SignalBus signalBus, DataManager data, PlayerOptions player, AdventureManager adventureManager)
		{
		}

		public void Initialize()
		{
		}

		public void Refresh()
		{
		}

		public void MakeVisuallyDisabled()
		{
		}

		public void MakeVisuallyEnabled()
		{
		}

		private void UnlockAllSongsForAdventure()
		{
		}

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}

		public void Stop()
		{
		}

		public void Confirm()
		{
		}

		public void ToggleLockSelected(bool b)
		{
		}

		public void SetStage(StageData s)
		{
		}

		public BgmType GetCurrentSelectedTrack()
		{
			return default(BgmType);
		}

		public void PreviousSong()
		{
		}

		public void NextSong()
		{
		}

		public void PreviousSpeed()
		{
		}

		public void NextSpeed()
		{
		}

		public void SetSpeed(BgmModType speed)
		{
		}

		public void AddSong(BgmType bgm)
		{
		}

		public void AddSpeed(BgmModType bgmMod)
		{
		}

		private bool GetMusicData(BgmType bgmType, out MusicData musicData)
		{
			musicData = null;
			return false;
		}

		private void PlayAtSpeed()
		{
		}

		private void SetSpeedName()
		{
		}

		private void SetIcon()
		{
		}

		private void SetName()
		{
		}
	}
}
