using System;
using System.Diagnostics;
using Aggro.Core;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public static class AudioManager
{
	private static bool _initialized;

	private static VCA _gameVCA;

	private static VCA _musicVCA;

	private static VCA _sfxVCA;

	private static VCA _uiVCA;

	private static VCA _voVCA;

	private static Bus _voBus;

	private static FMOD.Studio.EventInstance _SNAPSHOT_MONO;

	private static FMOD.Studio.EventInstance _lobbyTitleInstance;

	private static FMOD.Studio.EventInstance SNAPSHOT_MONO
	{
		get
		{
			if (!_SNAPSHOT_MONO.isValid())
			{
				_SNAPSHOT_MONO = RuntimeManager.CreateInstance("event:/COC/Snapshots/mono");
			}
			return _SNAPSHOT_MONO;
		}
	}

	[RuntimeInitializeOnLoadMethod]
	private static void RuntimeInit()
	{
		_initialized = false;
		_lobbyTitleInstance = default(FMOD.Studio.EventInstance);
	}

	public static void Initialize()
	{
		if (!_initialized)
		{
			_initialized = true;
			CheckResult(RuntimeManager.StudioSystem.getVCA("vca:/God", out _gameVCA));
			CheckResult(RuntimeManager.StudioSystem.getVCA("vca:/Music", out _musicVCA));
			CheckResult(RuntimeManager.StudioSystem.getVCA("vca:/SFX", out _sfxVCA));
			CheckResult(RuntimeManager.StudioSystem.getVCA("vca:/UI", out _uiVCA));
			CheckResult(RuntimeManager.StudioSystem.getVCA("vca:/VO", out _voVCA));
			CheckResult(RuntimeManager.StudioSystem.getBus("bus:/COC/Verb_Group/VO", out _voBus));
		}
	}

	public static void SetGameVolume(float value)
	{
		CheckResult(_gameVCA.setVolume(value));
	}

	public static void SetMusicVolume(float value)
	{
		CheckResult(_musicVCA.setVolume(value));
	}

	public static void SetSfxVolume(float value)
	{
		CheckResult(_sfxVCA.setVolume(value));
	}

	public static void SetUIVolume(float value)
	{
		CheckResult(_uiVCA.setVolume(value));
	}

	public static void SetVOVolume(float value)
	{
		CheckResult(_voVCA.setVolume(value));
	}

	public static void SetMonoAudio(bool value)
	{
		if (value)
		{
			SNAPSHOT_MONO.start();
		}
		else
		{
			SNAPSHOT_MONO.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		}
	}

	public static void PlaySfx(EventReference eventRef, Entity entity)
	{
		if (entity.TryGetObject<Transform>(out var obj))
		{
			PlaySfx(eventRef, obj.position);
		}
	}

	public static void PlaySfx(EventReference eventRef, Transform transform)
	{
		RuntimeManager.PlayOneShot(eventRef, transform.position);
	}

	public static void PlaySfx(EventReference eventRef, Vector3 position)
	{
		RuntimeManager.PlayOneShot(eventRef, position);
	}

	public static void PlaySfx(EventReference eventRef)
	{
		RuntimeManager.PlayOneShot(eventRef);
	}

	public static bool IsPlayingVO()
	{
		ChannelGroup group;
		RESULT channelGroup = _voBus.getChannelGroup(out group);
		if (channelGroup == RESULT.ERR_STUDIO_NOT_LOADED)
		{
			return false;
		}
		if (!CheckResult(channelGroup))
		{
			return false;
		}
		if (!group.hasHandle())
		{
			return false;
		}
		if (!CheckResult(group.getNumChannels(out var numchannels)))
		{
			return false;
		}
		return numchannels > 0;
	}

	public static void PlayVO(EventReference eventRef)
	{
		_voBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		PlaySfx(eventRef);
	}

	[Conditional("ENABLE_AUDIO_LOGGING")]
	public static void Log(string msg, UnityEngine.Object obj = null)
	{
		UnityEngine.Debug.Log("[AUDIO] " + msg, obj);
	}

	public static string GetEventName(EventReference eventReference)
	{
		return eventReference.Guid.ToString();
	}

	private static bool TryGetEventInstance(EventReference eventRef, out FMOD.Studio.EventInstance sfx)
	{
		if (eventRef.IsNull)
		{
			sfx = default(FMOD.Studio.EventInstance);
			return false;
		}
		RuntimeManager.StudioSystem.getEventByID(eventRef.Guid, out var _event);
		if (!_event.isValid())
		{
			sfx = default(FMOD.Studio.EventInstance);
			return false;
		}
		_event.createInstance(out sfx);
		if (!sfx.isValid())
		{
			return false;
		}
		return true;
	}

	private static void LogError(string msg)
	{
		UnityEngine.Debug.LogError("[AUDIO] " + msg);
	}

	private static void LogException(Exception e)
	{
		UnityEngine.Debug.LogException(e);
	}

	public static bool CheckResult(RESULT result)
	{
		if (result != RESULT.OK)
		{
			LogError($"FMOD error: {result}");
			return false;
		}
		return true;
	}

	public static void CheckStart(FMOD.Studio.EventInstance instance)
	{
		CheckResult(instance.getPlaybackState(out var state));
		if (state == PLAYBACK_STATE.STOPPED || state == PLAYBACK_STATE.STOPPING)
		{
			CheckResult(instance.start());
		}
	}

	public static void CheckStop(FMOD.Studio.EventInstance instance)
	{
		CheckResult(instance.getPlaybackState(out var state));
		if (state != PLAYBACK_STATE.STOPPED && state != PLAYBACK_STATE.STOPPING)
		{
			CheckResult(instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT));
		}
	}

	public static void CheckSetPlayState(FMOD.Studio.EventInstance instance, bool start)
	{
		if (start)
		{
			CheckStart(instance);
		}
		else
		{
			CheckStop(instance);
		}
	}

	public static void CheckSet3DAttributes(FMOD.Studio.EventInstance instance, Transform transform, Vector3 velocity)
	{
		CheckResult(instance.getPlaybackState(out var state));
		if (state == PLAYBACK_STATE.PLAYING)
		{
			CheckResult(instance.set3DAttributes(transform.To3DAttributes(velocity)));
		}
	}

	public static void PlayLobbyTitleMusic()
	{
		if (!_lobbyTitleInstance.isValid())
		{
			EventReference lobbyTitleMusic = GlobalScriptableObject<AudioObject>.instance.lobbyTitleMusic;
			if (!lobbyTitleMusic.IsNull)
			{
				_lobbyTitleInstance = RuntimeManager.CreateInstance(lobbyTitleMusic);
				_lobbyTitleInstance.start();
			}
		}
	}

	public static void StopLobbyTitleMusic()
	{
		if (_lobbyTitleInstance.isValid())
		{
			_lobbyTitleInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			_lobbyTitleInstance.release();
			_lobbyTitleInstance = default(FMOD.Studio.EventInstance);
		}
	}
}
