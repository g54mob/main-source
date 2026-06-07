using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using PajamaLlama.Debugs;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("FMOD Globals")]
	[SerializeField]
	private FMODParameter _dayTime;

	[SerializeField]
	private FMODParameter _gameSpeed;

	[SerializeField]
	private FMODParameter _zoomLevel;

	public void Initialize()
	{
		FMODManager.ApplyAudioPlayerData(Settings.Instance.AudioPlayerData);
		SubscribeToAgentEvents();
		StartCoroutine(PlayMusicCoroutine());
		StartCoroutine(PlayIdlingSoundCoroutine());
		GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, LaunchStinger);
		GameEventDispatcher.AddListener(GameEventType.GameSpeedChange, PauseAudio);
	}

	private void OnDestroy()
	{
		UnsubscribeAgentEvents();
	}

	public static void Play(AudioClipProperties clipProperties)
	{
		if (!(GameManager.AudioManager == null))
		{
			GameManager.AudioManager.Play2D(clipProperties);
		}
	}

	public static void Play(AudioClipProperties clipProperties, Transform source)
	{
		if (!(GameManager.AudioManager == null) && !(source == null))
		{
			GameManager.AudioManager.Play3D(clipProperties, source.position);
		}
	}

	public static void PlayMusic(AudioClipProperties musicProperties)
	{
		if (!(GameManager.AudioManager == null))
		{
			GameManager.AudioManager.Play2D(musicProperties, returnIfLoading: false);
		}
	}

	public static void PlayOneShot(string path, Transform sourceTransform = null)
	{
		if (!string.IsNullOrEmpty(path))
		{
			if (sourceTransform == null)
			{
				RuntimeManager.PlayOneShot(path);
			}
			else
			{
				RuntimeManager.PlayOneShot(path, sourceTransform.position);
			}
		}
	}

	public static void PlayOneShot(EventReference eventReference, Transform sourceTransform = null)
	{
		if (!eventReference.IsNull)
		{
			if ((bool)sourceTransform)
			{
				RuntimeManager.PlayOneShot(eventReference, sourceTransform.position);
			}
			else
			{
				RuntimeManager.PlayOneShot(eventReference);
			}
		}
	}

	public static void PlayOneShotAttached(string path, GameObject source)
	{
		if (!string.IsNullOrEmpty(path))
		{
			RuntimeManager.PlayOneShotAttached(path, source);
		}
	}

	public static void PlayOneShotAttached(EventReference eventReference, GameObject source)
	{
		if (!eventReference.IsNull)
		{
			RuntimeManager.PlayOneShotAttached(eventReference, source);
		}
	}

	public static void SetDayTimeParameter(float value)
	{
		if (!(GameManager.AudioManager == null))
		{
			GameManager.AudioManager._dayTime.SetValue(value);
		}
	}

	public static void SetZoomLevelParameter(float value)
	{
		if (!(GameManager.AudioManager == null))
		{
			GameManager.AudioManager._zoomLevel.SetValue(1f - value);
		}
	}

	private IEnumerator PlayMusicCoroutine()
	{
		while (LoadingScreen.IsLoading)
		{
			yield return null;
		}
		if (GameManager.Settings.PlayMusic)
		{
			if (PersistenceManager.ReturnIsRestoredGame())
			{
				Play2D(GameManager.Settings.AudioSettings.DefaultMusic);
			}
			else
			{
				Play2D(GameManager.Settings.AudioSettings.StingerNewGame);
			}
			Play2D(GameManager.Settings.AudioSettings.DefaultAmbience);
		}
	}

	private void Play2D(AudioClipProperties clipProperties, bool returnIfLoading = true)
	{
		if (!returnIfLoading || !LoadingScreen.IsLoading)
		{
			if (clipProperties == null)
			{
				Debugger.Warning($"No clip received to play!", null, onlyShowInEditor: true);
			}
			else if (!clipProperties.TryFMODOneShot())
			{
				Debug.LogWarningFormat("AudioClipProperties '{0}' has no FMODEvent set!", clipProperties.name);
			}
		}
	}

	private void Play3D(AudioClipProperties clipProperties, Vector3 position)
	{
		if (clipProperties == null)
		{
			Debugger.Warning($"No clip received to play!", null, onlyShowInEditor: true);
		}
		else if (!clipProperties.TryFMODOneShot(position))
		{
			Debug.LogWarningFormat("AudioClipProperties '{0}' has no FMODEvent set!", clipProperties.name);
		}
	}

	public void LaunchStinger(GameEvent gameEvent)
	{
		string text = (gameEvent as BuildableEvent).BuildableProperties.name;
		if (!(text == "SalvagingBoat"))
		{
			if (text == "Sails")
			{
				Play2D(GameManager.Settings.AudioSettings.StingerSails);
			}
		}
		else
		{
			Play2D(GameManager.Settings.AudioSettings.StingerFirstBoat);
		}
	}

	public static void EnableMapAudio(AudioClipProperties adioClipProperties)
	{
		if (GameManager.AudioManager != null)
		{
			GameManager.AudioManager.ToggleMapAudio(active: true, adioClipProperties);
		}
	}

	public static void DisableMapAudio(AudioClipProperties adioClipProperties)
	{
		if (GameManager.AudioManager != null)
		{
			GameManager.AudioManager.ToggleMapAudio(active: false, adioClipProperties);
		}
	}

	private void ToggleMapAudio(bool active, AudioClipProperties audioClipProperties)
	{
		GameManager.WorldMapManager.WorldMap.WorldCameraController.SetAudioListenerEnabled(active);
		CameraController.Instance.SetAudioListenerEnabled(!active);
		Play2D(audioClipProperties);
	}

	public void PauseAudio(GameEvent gameEvent)
	{
		switch (GameSpeedManager.GameSpeed)
		{
		case GameSpeed.Paused:
		case GameSpeed.Zero:
			_gameSpeed.SetValue(0f);
			AudioListener.pause = true;
			return;
		case GameSpeed.One:
			_gameSpeed.SetValue(1f);
			break;
		case GameSpeed.Two:
			_gameSpeed.SetValue(2f);
			break;
		case GameSpeed.Three:
			_gameSpeed.SetValue(3f);
			break;
		case GameSpeed.Four:
			_gameSpeed.SetValue(4f);
			break;
		default:
			throw new NotImplementedException();
		}
		AudioListener.pause = false;
	}

	private void SubscribeToAgentEvents()
	{
		GameEventDispatcher.AddListener(GameEventType.AgentStartProject, PlayOnStartProjectSound);
		GameEventDispatcher.AddListener(GameEventType.AgentDeath, PlayOnAgentDeathSound);
	}

	private void UnsubscribeAgentEvents()
	{
		GameEventDispatcher.RemoveListener(GameEventType.AgentStartProject, PlayOnStartProjectSound);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, PlayOnAgentDeathSound);
	}

	private void PlayOnAgentDeathSound(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent)
		{
			Play3D(agentEvent.Agent.Descriptor.VoicePack.OnDeathSounds, agentEvent.Agent.transform.position);
		}
	}

	private void PlayOnStartProjectSound(GameEvent gameEvent)
	{
		if (gameEvent is AgentEvent agentEvent)
		{
			Play3D(agentEvent.Agent.Descriptor.VoicePack.StartTaskSounds, agentEvent.Agent.transform.position);
		}
	}

	private IEnumerator PlayIdlingSoundCoroutine()
	{
		while (true)
		{
			float seconds = UnityEngine.Random.Range(GameManager.Settings.AudioSettings.IdleVoiceInterval.Minimum, GameManager.Settings.AudioSettings.IdleVoiceInterval.Maximum);
			yield return new WaitForSeconds(seconds);
			IEnumerable<Agent> source = Community.PlayerCommunity.Agents.Where((Agent agent2) => agent2.CurrentActivity == Activity.Idling && agent2.IsAlive);
			int num = source.Count();
			if (num != 0)
			{
				Agent agent = source.ElementAt(UnityEngine.Random.Range(0, num));
				Play3D(agent.Descriptor.VoicePack.IdlingSounds, agent.transform.position);
			}
		}
	}
}
