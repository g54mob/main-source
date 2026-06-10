using System;
using System.Collections.Generic;
using FMOD.Studio;
using NaughtyAttributes;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	[NonSerialized]
	public List<MusicCue> cues;

	[Header("Settings")]
	public bool enableMusic;

	[Header("Seconds Between Tracks")]
	public Vector2 silenceBetweenTracks;

	[Header("State")]
	[InfoBox("Current valid cues that the game will select from", EInfoBoxType.Normal)]
	public List<MusicCue> currentValidCues;

	[InfoBox("List of tracks that have already been played and are marked to play only once", EInfoBoxType.Normal)]
	public List<MusicCue> playedOnceTracks;

	public bool isPlaying;

	public float nextTrackTriggerTime;

	[Space(7f)]
	public MusicCue.MusicTriggerGameState currentGameState;

	public MusicCue.MusicTriggerPlayerState currentPlayerSate;

	public MusicCue.MusicTriggerPlayerLocation currentPlayerLocation;

	[Space(7f)]
	[InfoBox("Used to determine priorities when avoiding repeating tracks", EInfoBoxType.Normal)]
	public List<MusicCue> previousTracks;

	private Dictionary<MusicCue, EventInstance> activeTracks;

	public List<MusicCue> activeCuePresets;

	[Header("Accessibility Audio Filters")]
	public AudioController.LoopingSoundInfo hyperacusisFilter;

	public AudioController.LoopingSoundInfo bassReductionFilter;

	private static MusicController _instance;

	public static MusicController Instance => null;

	private void Awake()
	{
	}

	public void SetGameState(MusicCue.MusicTriggerGameState newGameState)
	{
	}

	public void SetPlayerState(MusicCue.MusicTriggerPlayerState newPlayerState)
	{
	}

	public void SetPlayerLocation(MusicCue.MusicTriggerPlayerLocation newPlayerLocation)
	{
	}

	public void MusicTriggerCheck(MusicCue.MusicTriggerEvent passEvent = MusicCue.MusicTriggerEvent.none)
	{
	}

	public bool IsTriggerValid(MusicCue.MusicTrigger trigger, MusicCue.MusicTriggerEvent passEvent, bool debug)
	{
		return false;
	}

	private float GetPreviouslyPlayedBias(MusicCue cue)
	{
		return 0f;
	}

	public void PlayNewTrack(MusicCue newTrack, bool interupt = false)
	{
	}

	private void Update()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StopCurrentTrack()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ForceNextTrack()
	{
	}

	public void AudioFiltersCheck()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StartMusicOnlySnapshot()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StopMusicOnlySnapshot()
	{
	}
}
