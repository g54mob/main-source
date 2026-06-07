using System;
using DV.Radio;
using PlaylistsNET.Models;
using Stateless;
using UnityEngine;

public class CassettePlayerController
{
	private enum State
	{
		Global = 0,
		Door_Open = 1,
		Door_Closed = 2,
		Playing = 3,
		Playing_On = 4,
		Playing_Off = 5,
		Paused = 6,
		Paused_On = 7,
		Paused_Off = 8
	}

	private enum Trigger
	{
		Turn_On = 0,
		Turn_Off = 1,
		Door_Close = 2,
		Stop = 3,
		Play = 4,
		Pause = 5,
		Previous = 6,
		Next = 7
	}

	private bool resumeOnUnpause;

	private bool stopOnFocusLost;

	private GameObject parent;

	private AudioSource audioSource;

	private PlaylistPlayer player;

	private bool isOn;

	private State state = State.Door_Closed;

	private StateMachine<State, Trigger> fsm;

	private CassetteInteractionArea interactionArea;

	public bool IsPlaying
	{
		get
		{
			if (fsm.State != State.Playing_On)
			{
				return fsm.State == State.Playing_Off;
			}
			return true;
		}
	}

	public int CurrentPlaylistIndex
	{
		get
		{
			if (player != null)
			{
				return player.GetTrackIndex();
			}
			Cassette insertedCassette = interactionArea.GetInsertedCassette();
			if (insertedCassette != null)
			{
				return insertedCassette.lastPlayedPlaylistEntry;
			}
			return 0;
		}
	}

	public event Action PlaybackStarted;

	public event Action PlaybackPaused;

	public event Action PlaybackStopped;

	public event Action<string> SongChanged;

	public event Action<int> TrackIndexChanged;

	public void TurnOn()
	{
		isOn = true;
		fsm.Fire(Trigger.Turn_On);
	}

	public void TurnOff()
	{
		isOn = false;
		fsm.Fire(Trigger.Turn_Off);
	}

	public void Play()
	{
		fsm.Fire(Trigger.Play);
	}

	public void StopOrEject()
	{
		fsm.Fire(Trigger.Stop);
	}

	public void Pause()
	{
		fsm.Fire(Trigger.Pause);
	}

	public void Previous()
	{
		fsm.Fire(Trigger.Previous);
	}

	public void Next()
	{
		fsm.Fire(Trigger.Next);
	}

	public void OnPowerAndModeChanged(bool isOn, bool isRadio)
	{
		if (isOn && !isRadio)
		{
			TurnOn();
		}
		else
		{
			TurnOff();
		}
	}

	public void OnStopPressed()
	{
		StopOrEject();
	}

	private StateMachine<State, Trigger> MakeFSM()
	{
		StateMachine<State, Trigger> stateMachine = new StateMachine<State, Trigger>(() => state, delegate(State s)
		{
			state = s;
		});
		stateMachine.Configure(State.Global);
		stateMachine.Configure(State.Door_Open).SubstateOf(State.Global).OnEntry(Entry_Door_Open)
			.Permit(Trigger.Door_Close, State.Door_Closed)
			.Ignore(Trigger.Play)
			.Ignore(Trigger.Pause)
			.Ignore(Trigger.Stop)
			.Ignore(Trigger.Next)
			.Ignore(Trigger.Previous);
		stateMachine.Configure(State.Door_Closed).SubstateOf(State.Global).Permit(Trigger.Stop, State.Door_Open)
			.PermitIf(Trigger.Play, State.Playing_On, () => isOn)
			.PermitIf(Trigger.Play, State.Playing_Off, () => !isOn)
			.Ignore(Trigger.Pause)
			.Ignore(Trigger.Turn_On)
			.Ignore(Trigger.Turn_Off);
		stateMachine.Configure(State.Playing).SubstateOf(State.Global).Permit(Trigger.Stop, State.Door_Closed);
		stateMachine.Configure(State.Playing_On).SubstateOf(State.Playing).OnEntry(Entry_Playing_On)
			.OnExit(Exit_Playing_On)
			.InternalTransition(Trigger.Next, HandleNext)
			.InternalTransition(Trigger.Previous, HandlePrevious)
			.Permit(Trigger.Turn_Off, State.Playing_Off)
			.Permit(Trigger.Pause, State.Paused_On)
			.Ignore(Trigger.Play);
		stateMachine.Configure(State.Playing_Off).SubstateOf(State.Playing).Permit(Trigger.Turn_On, State.Playing_On)
			.Permit(Trigger.Pause, State.Paused_Off)
			.Ignore(Trigger.Play)
			.Ignore(Trigger.Next)
			.Ignore(Trigger.Previous);
		stateMachine.Configure(State.Paused).SubstateOf(State.Global).Permit(Trigger.Stop, State.Door_Closed);
		stateMachine.Configure(State.Paused_On).SubstateOf(State.Paused).Permit(Trigger.Turn_Off, State.Paused_Off)
			.Permit(Trigger.Play, State.Playing_On);
		stateMachine.Configure(State.Paused_Off).SubstateOf(State.Paused).Permit(Trigger.Turn_On, State.Paused_On)
			.Permit(Trigger.Play, State.Playing_Off);
		stateMachine.OnUnhandledTrigger(delegate(State state, Trigger trigger)
		{
			Debug.LogWarning($"[CassettePlayer] Unhandled trigger '{trigger}' for state '{state}'");
		});
		return stateMachine;
	}

	public CassettePlayerController(GameObject parent, AudioSource audioSource, CassetteInteractionArea interactionArea)
	{
		this.parent = parent;
		this.audioSource = audioSource;
		this.interactionArea = interactionArea;
		fsm = MakeFSM();
		interactionArea.DoorClosed += delegate
		{
			fsm.Fire(Trigger.Door_Close);
		};
	}

	private void Entry_Door_Open()
	{
		interactionArea.OpenDoor();
	}

	private void Entry_Playing_On()
	{
		Cassette insertedCassette = interactionArea.GetInsertedCassette();
		if (insertedCassette == null)
		{
			Debug.Log("Cassette is null");
			return;
		}
		IBasePlaylist playlist = insertedCassette.GetPlaylist();
		player = parent.AddComponent<PlaylistPlayer>();
		player.StopOnFocusLost = stopOnFocusLost;
		player.audioSource = audioSource;
		player.SetPlaylist(playlist, insertedCassette.lastPlayedPlaylistEntry, insertedCassette.lastPlayedSeekPosition);
		SetupListeners(on: true);
		player.Play();
	}

	private void Exit_Playing_On()
	{
		if (player != null)
		{
			Cassette insertedCassette = interactionArea.GetInsertedCassette();
			if ((bool)insertedCassette)
			{
				insertedCassette.lastPlayedPlaylistEntry = player.GetTrackIndex();
				insertedCassette.lastPlayedSeekPosition = player.GetSeekPosition();
			}
			player.Stop();
			SetupListeners(on: false);
			UnityEngine.Object.Destroy(player);
			player = null;
		}
	}

	private void HandleNext()
	{
		if ((bool)player)
		{
			player.Next();
		}
	}

	private void HandlePrevious()
	{
		if ((bool)player)
		{
			player.Previous();
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			player.SongInfoChanged += SongChanged_Fire;
			player.PlaylistEnded += PlaybackStopped_Fire;
			player.PlaybackStarted += PlaybackStarted_Fire;
			player.PlaybackStopped += PlaybackStopped_Fire;
			player.TrackIndexChanged += TrackIndexChanged_Fire;
			player.ErrorInfo += OnErrorInfo;
		}
		else
		{
			player.SongInfoChanged -= SongChanged_Fire;
			player.PlaylistEnded -= PlaybackStopped_Fire;
			player.PlaybackStarted -= PlaybackStarted_Fire;
			player.PlaybackStopped -= PlaybackStopped_Fire;
			player.TrackIndexChanged -= TrackIndexChanged_Fire;
			player.ErrorInfo -= OnErrorInfo;
		}
	}

	public void OnGamePaused()
	{
		if (player != null && player.Pause())
		{
			resumeOnUnpause = true;
		}
	}

	public void OnGameUnpaused()
	{
		if (resumeOnUnpause)
		{
			if (player != null)
			{
				player.Play();
			}
			resumeOnUnpause = false;
		}
	}

	public void OnPauseInBackgroundPreferenceChanged(bool pause)
	{
		stopOnFocusLost = pause;
		if (player != null)
		{
			player.StopOnFocusLost = stopOnFocusLost;
		}
	}

	private void SongChanged_Fire(string s)
	{
		this.SongChanged?.Invoke(s);
	}

	private void PlaybackStarted_Fire()
	{
		this.PlaybackStarted?.Invoke();
	}

	private void PlaybackStopped_Fire()
	{
		this.PlaybackStopped?.Invoke();
	}

	private void TrackIndexChanged_Fire(int i)
	{
		this.TrackIndexChanged?.Invoke(i);
	}

	private void OnErrorInfo(string err)
	{
		Debug.LogWarning("[CassettePlayer] " + err);
	}
}
