using System.Collections;
using System.Collections.Generic;
using ClockStone;
using UnityEngine;

public class MusicPlaylistController : MonoBehaviour
{
	public string penPlaylistName;

	private List<string> playlist = new List<string>();

	private string currentSongName;

	private float currentSongTime;

	private int currentPlaylistIndex;

	private float timeBetweenSongs = 1f;

	private bool playingMuffledSong;

	private string muffledSuffix = "_muffled";

	private string titleTrackA = "music_titlescreenA";

	private string titleTrackB = "music_titlescreenB";

	private string placementTrack = "music_placement";

	private string dogManagementTrack = "music_dogManagement";

	private string breedingCenterTrack = "music_breedingCenterTrack";

	private AudioObject currentAudioObject;

	private Coroutine currentPitchBendingRoutine;

	private Coroutine currentPitchModulationRoutine;

	private int activePlayers;

	private float activePlayerRangeLow = 20f;

	private float activePlayerRangeHigh = 50f;

	private bool musicPlayersMuted;

	private List<InteractableMusicPlayer> activeMusicPlayers = new List<InteractableMusicPlayer>();

	private bool paused;

	private bool placementMode;

	private bool dogManagementMode;

	private bool sfxLocked;

	private GameLocation currentLocation = GameLocation.PENS;

	private Transform mainCamTransform;

	private void Awake()
	{
		StartPlaylist();
	}

	private void Update()
	{
		CheckSongProgress();
		if (Input.GetKeyDown(KeyCode.PageUp) && !CheatEngine.cheatRef.publicBuild)
		{
			AdvancePlaylist();
		}
		CheckMusicPlayerProximity();
	}

	public void RefreshLocation()
	{
		SetGameLocation(currentLocation);
	}

	public void SetGameLocation(GameLocation newLocation)
	{
		if (currentLocation == GameLocation.BREEDING_CENTER && currentAudioObject != null)
		{
			AudioController.Stop(currentAudioObject.audioID, 1f);
			currentAudioObject = null;
		}
		currentLocation = newLocation;
		if (currentLocation == GameLocation.MAIN_MENU)
		{
			if (currentAudioObject != null)
			{
				AudioController.Stop(currentAudioObject.audioID, 0f);
			}
			currentAudioObject = AudioController.PlayMusic(titleTrackA);
		}
		else if (currentLocation == GameLocation.BREEDING_CENTER)
		{
			currentAudioObject = AudioController.PlayMusic(breedingCenterTrack);
		}
		else if (currentLocation == GameLocation.PENS)
		{
			StartPlaylist();
		}
		else if (newLocation == GameLocation.TRANSITION)
		{
			if (currentAudioObject != null)
			{
				AudioController.Stop(currentAudioObject.audioID, 0f);
			}
		}
		else
		{
			Debug.LogError("No implementation for given location: " + newLocation);
		}
	}

	public void RegisterActiveMusicPlayer(InteractableMusicPlayer newPlayer)
	{
		activeMusicPlayers.Add(newPlayer);
		activePlayers = activeMusicPlayers.Count;
	}

	public void UnregisterActiveMusicPlayer(InteractableMusicPlayer player)
	{
		activeMusicPlayers.Remove(player);
		activePlayers = activeMusicPlayers.Count;
		if (activePlayers == 0)
		{
			SFXOverlord.SetMusicVolumeOverride(enabled: false, 1f);
		}
	}

	public void SetSFXLockState(bool val)
	{
		sfxLocked = val;
	}

	public void CheckMusicPlayerProximity()
	{
		if (activePlayers == 0)
		{
			return;
		}
		if (paused || placementMode || dogManagementMode || playingMuffledSong || sfxLocked || currentLocation != GameLocation.PENS)
		{
			if (!musicPlayersMuted)
			{
				musicPlayersMuted = true;
				for (int i = 0; i < activeMusicPlayers.Count; i++)
				{
					activeMusicPlayers[i].Mute();
				}
			}
			SFXOverlord.SetMusicVolumeOverride(enabled: false, 1f);
			return;
		}
		if (musicPlayersMuted)
		{
			musicPlayersMuted = false;
			for (int j = 0; j < activeMusicPlayers.Count; j++)
			{
				activeMusicPlayers[j].Unmute();
			}
		}
		if (mainCamTransform == null)
		{
			mainCamTransform = Camera.main.transform;
		}
		float num = float.PositiveInfinity;
		for (int k = 0; k < activePlayers; k++)
		{
			float num2 = Vector3.Distance(mainCamTransform.position, activeMusicPlayers[k].transform.position);
			if (num2 < num)
			{
				num = num2;
			}
		}
		float percentage = (Mathf.Min(num, activePlayerRangeHigh) - activePlayerRangeLow) / (activePlayerRangeHigh - activePlayerRangeLow);
		if (num <= activePlayerRangeHigh)
		{
			SFXOverlord.SetMusicVolumeOverride(enabled: true, MathUtil.GetValueOfRangePercentage(percentage, 0f, 1f));
		}
		else
		{
			SFXOverlord.SetMusicVolumeOverride(enabled: false, 1f);
		}
	}

	public void OnEnterFileSelect()
	{
		float startTime = 0f;
		AudioObject currentMusic = AudioController.GetCurrentMusic();
		if (currentMusic != null)
		{
			startTime = currentMusic.audioTime;
		}
		currentAudioObject = AudioController.PlayMusic(titleTrackB, 1f, 0f, startTime);
	}

	public void OnReEnterMainMenu()
	{
		float startTime = 0f;
		AudioObject currentMusic = AudioController.GetCurrentMusic();
		if (currentMusic != null)
		{
			startTime = currentMusic.audioTime;
		}
		currentAudioObject = AudioController.PlayMusic(titleTrackA, 1f, 0f, startTime);
	}

	public void OnEnterDogStorage()
	{
		if (!dogManagementMode)
		{
			dogManagementMode = true;
			AudioObject currentMusic = AudioController.GetCurrentMusic();
			if (currentMusic != null)
			{
				currentSongTime = currentMusic.audioTime;
			}
			else
			{
				currentSongTime = 0f;
			}
			if (currentAudioObject != null)
			{
				AudioController.Stop(currentAudioObject.audioID, 1f);
			}
			SFXOverlord.SetMusicVolumeOverride(enabled: false, 1f);
			currentAudioObject = AudioController.PlayMusic(dogManagementTrack);
		}
	}

	public void OnExitDogStorage()
	{
		if (dogManagementMode && !(SingletonMonoBehaviour<AudioController>.Instance == null))
		{
			dogManagementMode = false;
			if (currentAudioObject != null)
			{
				AudioController.Stop(currentAudioObject.audioID, 1f);
			}
			PlaySong(currentSongName, 0f, currentSongTime);
		}
	}

	public void OnEnterPlacementBuildingMode()
	{
		if (!placementMode)
		{
			placementMode = true;
			AudioObject currentMusic = AudioController.GetCurrentMusic();
			if (currentMusic != null)
			{
				currentSongTime = currentMusic.audioTime;
			}
			else
			{
				currentSongTime = 0f;
			}
			if (currentAudioObject != null)
			{
				AudioController.Stop(currentAudioObject.audioID, 1f);
			}
			SFXOverlord.SetMusicVolumeOverride(enabled: false, 1f);
			currentAudioObject = AudioController.PlayMusic(placementTrack);
		}
	}

	public void OnExitPlacementBuildingMode()
	{
		if (placementMode)
		{
			placementMode = false;
			if (currentAudioObject != null)
			{
				AudioController.Stop(currentAudioObject.audioID, 1f);
			}
			PlaySong(currentSongName, 0f, currentSongTime);
		}
	}

	public void Pause()
	{
		if (!paused)
		{
			paused = true;
			AudioObject currentMusic = AudioController.GetCurrentMusic();
			if (currentMusic != null)
			{
				currentSongTime = currentMusic.audioTime;
			}
			else
			{
				currentSongTime = 0f;
			}
			currentAudioObject = null;
			AudioController.StopMusic();
		}
	}

	public void Unpause(bool force = false)
	{
		if (paused || force)
		{
			paused = false;
			PlaySong(currentSongName, 0f, currentSongTime);
		}
	}

	public void SetMuffled()
	{
		if (!playingMuffledSong)
		{
			playingMuffledSong = true;
			AudioObject currentMusic = AudioController.GetCurrentMusic();
			if (!(currentMusic == null))
			{
				PlaySong(currentSongName, 0f, currentMusic.audioTime);
			}
		}
	}

	public void SetNotMuffled()
	{
		if (playingMuffledSong)
		{
			playingMuffledSong = false;
			AudioObject currentMusic = AudioController.GetCurrentMusic();
			if (!(currentMusic == null))
			{
				PlaySong(currentSongName, 0f, currentMusic.audioTime);
			}
		}
	}

	private void StartPlaylist()
	{
		playlist.AddRange(AudioController.GetMusicPlaylist(penPlaylistName));
		CyclePlaylist();
	}

	private void CheckSongProgress()
	{
		if (!paused && !placementMode && !dogManagementMode && !AudioController.IsPlaying(currentSongName) && !AudioController.IsPlaying(currentSongName + muffledSuffix))
		{
			AdvancePlaylist();
		}
	}

	private void AdvancePlaylist()
	{
		if (!paused && !placementMode && !dogManagementMode && currentLocation == GameLocation.PENS)
		{
			currentPlaylistIndex++;
			if (currentPlaylistIndex < playlist.Count)
			{
				currentSongName = playlist[currentPlaylistIndex];
				PlaySong(currentSongName, timeBetweenSongs);
			}
			else
			{
				CyclePlaylist();
			}
		}
	}

	private void CyclePlaylist()
	{
		if (!paused && !placementMode && !dogManagementMode && currentLocation == GameLocation.PENS)
		{
			currentPlaylistIndex = 0;
			ListUtil.ShuffleList(ref playlist);
			while (playlist.Count > 1 && currentSongName == playlist[currentPlaylistIndex])
			{
				ListUtil.ShuffleList(ref playlist);
			}
			currentSongName = playlist[currentPlaylistIndex];
			PlaySong(currentSongName, timeBetweenSongs);
		}
	}

	private string GetPlayableSongForBaseName(string songName)
	{
		if (!playingMuffledSong)
		{
			return songName;
		}
		string text = songName + muffledSuffix;
		if (AudioController.IsValidAudioID(text))
		{
			return text;
		}
		Debug.LogError("Need muffled version of song: " + songName);
		return songName;
	}

	private void PlaySong(string songName, float delay = 0f, float startTime = 0f)
	{
		if (!CheatEngine.cheatRef.muteMusic && currentLocation == GameLocation.PENS && !(SingletonMonoBehaviour<AudioController>.Instance == null))
		{
			string playableSongForBaseName = GetPlayableSongForBaseName(songName);
			if (!AudioController.IsPlaying(playableSongForBaseName))
			{
				SFXOverlord.SetMusicVolumeOverride(enabled: false, 1f);
				currentAudioObject = AudioController.PlayMusic(playableSongForBaseName, 1f, delay, startTime);
			}
		}
	}

	public void RequestPitchBend(float maxChangePercentage, float timeLower = 0.5f, float timeRaise = 0.25f, bool force = false)
	{
		if (currentAudioObject == null)
		{
			return;
		}
		if (currentPitchBendingRoutine != null)
		{
			if (!force)
			{
				return;
			}
			StopCoroutine(currentPitchBendingRoutine);
			currentPitchBendingRoutine = null;
		}
		currentPitchBendingRoutine = StartCoroutine(PitchBendRoutine(maxChangePercentage, timeLower, timeRaise));
	}

	public void RequestPitchModulation(float time)
	{
		if (currentPitchModulationRoutine == null)
		{
			currentPitchModulationRoutine = StartCoroutine(PitchModulationRoutine(time));
		}
	}

	private IEnumerator PitchBendRoutine(float maxChangePercentage, float timeLower, float timeRaise)
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		float num = 0.3f;
		float totalChange = num * maxChangePercentage;
		float currentTimer = 0f;
		while (currentTimer < timeLower)
		{
			currentTimer += Time.deltaTime;
			if (currentTimer > timeLower)
			{
				currentTimer = timeLower;
			}
			float pitch = 1f - MathUtil.GetValueOfRangePercentage(currentTimer / timeLower, 0f, totalChange);
			if (currentAudioObject != null)
			{
				currentAudioObject.primaryAudioSource.pitch = pitch;
			}
			yield return frameWait;
		}
		if (currentAudioObject != null)
		{
			currentAudioObject.primaryAudioSource.pitch = 1f - totalChange;
		}
		currentTimer = 0f;
		while (currentTimer < timeRaise)
		{
			currentTimer += Time.deltaTime;
			if (currentTimer > timeRaise)
			{
				currentTimer = timeRaise;
			}
			float pitch2 = 1f - totalChange + MathUtil.GetValueOfRangePercentage(currentTimer / timeRaise, 0f, totalChange);
			if (currentAudioObject != null)
			{
				currentAudioObject.primaryAudioSource.pitch = pitch2;
			}
			yield return frameWait;
		}
		if (currentAudioObject != null)
		{
			currentAudioObject.primaryAudioSource.pitch = 1f;
		}
		currentPitchBendingRoutine = null;
	}

	private IEnumerator PitchModulationRoutine(float time)
	{
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		float allowedMax = 1.3f;
		float allowedMin = 0.7f;
		float currentTimer = 0f;
		while (currentTimer < time)
		{
			if (currentAudioObject == null)
			{
				currentPitchModulationRoutine = null;
				yield break;
			}
			currentTimer += Time.deltaTime;
			float pitch = currentAudioObject.primaryAudioSource.pitch;
			pitch = ((!(Random.value > 0.5f)) ? (pitch - Time.deltaTime * Random.Range(0.5f, 2f)) : (pitch + Time.deltaTime * Random.Range(0.5f, 2f)));
			pitch = Mathf.Clamp(pitch, allowedMin, allowedMax);
			currentAudioObject.primaryAudioSource.pitch = pitch;
			yield return frameWait;
		}
		if (currentAudioObject != null)
		{
			currentAudioObject.primaryAudioSource.pitch = 1f;
		}
		currentPitchModulationRoutine = null;
	}
}
