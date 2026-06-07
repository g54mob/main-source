using System;
using DV.Radio;
using Stateless;
using UnityEngine;

public class RadioPlayerController
{
	private enum State
	{
		Off = 0,
		On = 1,
		On_Missing_Playlist = 2
	}

	private enum Trigger
	{
		Turn_On = 0,
		Turn_Off = 1,
		Switch_To_Next_Station = 2,
		Switch_To_Previous_Station = 3
	}

	private GameObject parent;

	private PlaylistPlayer player;

	private int lastPlayedStationIndex;

	private AudioSource audioSource;

	private State state;

	private StateMachine<State, Trigger> fsm;

	public int CurrentStationIndex
	{
		get
		{
			if (!(player != null))
			{
				return lastPlayedStationIndex;
			}
			return player.GetTrackIndex();
		}
	}

	public event Action BufferingStarted;

	public event Action BufferingEnded;

	public event Action<float> BufferingProgress;

	public event Action<string> SongChanged;

	public event Action PlaybackStopped;

	public event Action<int> StationIndexChanged;

	public event Action<string> StationNameChanged;

	public void TurnOff()
	{
		fsm.Fire(Trigger.Turn_Off);
	}

	public void TurnOn()
	{
		fsm.Fire(Trigger.Turn_On);
	}

	public void Next()
	{
		fsm.Fire(Trigger.Switch_To_Next_Station);
	}

	public void Previous()
	{
		fsm.Fire(Trigger.Switch_To_Previous_Station);
	}

	public void OnTuneChanged(bool next)
	{
		if (next)
		{
			Next();
		}
		else
		{
			Previous();
		}
	}

	public void OnPowerAndModeChanged(bool isOn, bool isRadio)
	{
		if (isRadio && isOn)
		{
			TurnOn();
		}
		else
		{
			TurnOff();
		}
	}

	private StateMachine<State, Trigger> MakeFSM()
	{
		StateMachine<State, Trigger> stateMachine = new StateMachine<State, Trigger>(() => state, delegate(State s)
		{
			state = s;
		});
		stateMachine.Configure(State.Off).PermitDynamic(Trigger.Turn_On, DetermineNextStateBasedOnPlaylistValidity).Ignore(Trigger.Turn_Off)
			.Ignore(Trigger.Switch_To_Next_Station)
			.Ignore(Trigger.Switch_To_Previous_Station);
		stateMachine.Configure(State.On).OnEntry(Entry_On).OnExit(Exit_On)
			.Permit(Trigger.Turn_Off, State.Off)
			.InternalTransition(Trigger.Switch_To_Next_Station, HandleStationSwitch)
			.InternalTransition(Trigger.Switch_To_Previous_Station, HandleStationSwitch)
			.Ignore(Trigger.Turn_On);
		stateMachine.Configure(State.On_Missing_Playlist).Permit(Trigger.Turn_Off, State.Off).Ignore(Trigger.Turn_On)
			.Ignore(Trigger.Switch_To_Next_Station)
			.Ignore(Trigger.Switch_To_Previous_Station);
		stateMachine.OnUnhandledTrigger(delegate(State state, Trigger trigger)
		{
			Debug.LogWarning($"[RadioPlayer] Unhandled trigger '{trigger}' for state '{state}'");
		});
		return stateMachine;
	}

	private State DetermineNextStateBasedOnPlaylistValidity()
	{
		if (!PlaylistPlayer.TryGetPlaylist(GetPlaylistPath(), out var _))
		{
			return State.On_Missing_Playlist;
		}
		return State.On;
	}

	public RadioPlayerController(GameObject parent, AudioSource audioSource)
	{
		fsm = MakeFSM();
		this.parent = parent;
		this.audioSource = audioSource;
	}

	private void Entry_On()
	{
		player = parent.AddComponent<PlaylistPlayer>();
		player.audioSource = audioSource;
		player.SetPlaylistFile(GetPlaylistPath(), lastPlayedStationIndex, 0L);
		SetupListeners(on: true);
		player.Play();
	}

	private void Exit_On()
	{
		SetupListeners(on: false);
		lastPlayedStationIndex = player.GetTrackIndex();
		UnityEngine.Object.Destroy(player);
		player = null;
	}

	private void HandleStationSwitch(StateMachine<State, Trigger>.Transition t)
	{
		if (t.Trigger == Trigger.Switch_To_Next_Station)
		{
			player.Next();
		}
		else
		{
			player.Previous();
		}
	}

	public static string GetPlaylistPath()
	{
		return Application.streamingAssetsPath + "/music/Radio.pls";
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			player.BufferingStarted += BufferingStarted_Fire;
			player.BufferingEnded += BufferingEnded_Fire;
			player.BufferingProgress += BufferingProgress_Fire;
			player.SongInfoChanged += SongChanged_Fire;
			player.PlaylistEnded += PlaybackStopped_Fire;
			player.PlaybackStopped += PlaybackStopped_Fire;
			player.TrackIndexChanged += StationIndexChanged_Fire;
			player.StationNameChanged += StationNameChanged_Fire;
			player.ErrorInfo += OnErrorInfo;
		}
		else
		{
			player.BufferingStarted -= BufferingStarted_Fire;
			player.BufferingEnded -= BufferingEnded_Fire;
			player.BufferingProgress -= BufferingProgress_Fire;
			player.SongInfoChanged -= SongChanged_Fire;
			player.PlaylistEnded -= PlaybackStopped_Fire;
			player.PlaybackStopped -= PlaybackStopped_Fire;
			player.TrackIndexChanged -= StationIndexChanged_Fire;
			player.StationNameChanged -= StationNameChanged_Fire;
			player.ErrorInfo -= OnErrorInfo;
		}
	}

	private void BufferingStarted_Fire()
	{
		this.BufferingStarted?.Invoke();
	}

	private void BufferingEnded_Fire()
	{
		this.BufferingEnded?.Invoke();
	}

	private void BufferingProgress_Fire(float p)
	{
		this.BufferingProgress?.Invoke(p);
	}

	private void SongChanged_Fire(string s)
	{
		this.SongChanged?.Invoke(s);
	}

	private void PlaybackStopped_Fire()
	{
		this.PlaybackStopped?.Invoke();
	}

	private void StationIndexChanged_Fire(int i)
	{
		this.StationIndexChanged?.Invoke(i);
	}

	private void StationNameChanged_Fire(string n)
	{
		this.StationNameChanged?.Invoke(n);
	}

	private void OnErrorInfo(string err)
	{
		Debug.LogWarning("[Radio] " + err);
	}

	public void OverrideLastPlayedStationIndex(int overrideValue)
	{
		lastPlayedStationIndex = overrideValue;
	}

	public void OnGamePaused()
	{
		if (player != null)
		{
			player.Stop();
		}
	}

	public void OnGameUnpaused()
	{
		if (player != null)
		{
			player.Play();
		}
	}
}
