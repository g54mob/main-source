using System.Collections.Generic;
using UltimateReplay;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class CustomAudioReplay : ReplayBehaviour
{
	private AudioSource audioSource;

	private List<AudioClip> playedAudioClips;

	private Vector3 gameplayPosition;

	private short gameplayClipIndex;

	private bool gameplayIsLoop;

	private float gameplayVolume;

	private float gameplayPitch;

	private float lastPitch;

	public override void Awake()
	{
		base.Awake();
		audioSource = GetComponent<AudioSource>();
		playedAudioClips = new List<AudioClip>();
		lastPitch = 1f;
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		short num = -1;
		if (audioSource.clip != null)
		{
			if (!playedAudioClips.Contains(audioSource.clip))
			{
				playedAudioClips.Add(audioSource.clip);
			}
			num = (short)playedAudioClips.IndexOf(audioSource.clip);
		}
		gameplayPosition = base.transform.position;
		gameplayClipIndex = num;
		gameplayIsLoop = audioSource.loop;
		gameplayVolume = audioSource.volume;
		gameplayPitch = audioSource.pitch;
	}

	public override void OnReplayEnd()
	{
		base.OnReplayEnd();
		if (gameplayClipIndex >= 0)
		{
			audioSource.clip = playedAudioClips[gameplayClipIndex];
		}
		base.transform.position = gameplayPosition;
		audioSource.loop = gameplayIsLoop;
		audioSource.volume = gameplayVolume;
		audioSource.pitch = gameplayPitch;
		if (audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	public override void OnReplayPlayPause(bool paused)
	{
		base.OnReplayPlayPause(paused);
		if (paused && audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		base.OnReplaySerialize(state);
		state.Write(audioSource.isPlaying);
		if (audioSource.isPlaying)
		{
			if (!playedAudioClips.Contains(audioSource.clip))
			{
				playedAudioClips.Add(audioSource.clip);
			}
			short value = (short)playedAudioClips.IndexOf(audioSource.clip);
			state.Write(base.transform.position);
			state.Write(value);
			state.Write(audioSource.loop);
			state.Write(audioSource.volume);
			state.Write(audioSource.pitch);
		}
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		base.OnReplayDeserialize(state);
		if (state.ReadBool())
		{
			Vector3 position = state.ReadVec3();
			short num = state.Read16();
			bool flag = state.ReadBool();
			float volume = state.ReadFloat();
			float pitch = state.ReadFloat();
			if (num < playedAudioClips.Count)
			{
				base.transform.position = position;
				if (audioSource.clip != playedAudioClips[num])
				{
					audioSource.clip = playedAudioClips[num];
				}
				if (audioSource.loop != flag)
				{
					audioSource.loop = flag;
				}
				audioSource.volume = volume;
				audioSource.pitch = pitch;
				if (!audioSource.isPlaying && base.PlaybackDirection == PlaybackDirection.Forward)
				{
					audioSource.Play();
				}
				else if (audioSource.isPlaying && base.PlaybackDirection == PlaybackDirection.Backward)
				{
					audioSource.Stop();
				}
			}
			lastPitch = pitch;
		}
		else if (audioSource.isPlaying)
		{
			audioSource.Stop();
		}
	}

	public override void OnReplayUpdate()
	{
		base.OnReplayUpdate();
		if (base.PlaybackDirection != PlaybackDirection.Backward && audioSource.isPlaying)
		{
			audioSource.pitch = ReplayTime.TimeScale * lastPitch;
		}
	}
}
