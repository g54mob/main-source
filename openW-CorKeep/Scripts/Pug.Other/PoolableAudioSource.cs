using System;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class PoolableAudioSource : PoolableSimple, IManagedLateUpdate
{
	private enum State
	{
		none = 0,
		playing = 1,
		fadeOut = 2,
		antiPopMute = 3,
		fadeIn = 4
	}

	public const float SPATIAL_BLEND_DISTANCE = 10f;

	public const float MAX_SPATIAL_DISTANCE = 16f;

	[NonSerialized]
	public SfxID reuseID;

	[NonSerialized]
	public int nonStackableSfxTableID;

	[NonSerialized]
	public Transform transformToFollow;

	[NonSerialized]
	public Entity entityToFollow;

	[NonSerialized]
	public bool followsAnEntityOrTransform;

	[NonSerialized]
	public bool useSpatialSound;

	[NonSerialized]
	public float maxSpatialBlendDistance = 10f;

	[NonSerialized]
	public bool muteVolumeWhilePaused;

	[NonSerialized]
	public bool mutedFromPause;

	[NonSerialized]
	public bool freeAfterStoppedPlaying;

	[NonSerialized]
	public float maxSpatialBlend;

	[NonSerialized]
	public int validAllocationIndex;

	private float volume;

	private float pitch;

	private State state;

	private TimerSimple stateTimer = new TimerSimple(1f, unscaled: true);

	private float volumeBeforeFadeOut;

	private float volumeBeforeFadeIn;

	[field: SerializeField]
	public AudioSource audioSource { get; set; }

	public float GetTimeSinceAudioStartedPlaying()
	{
		if (state != State.none)
		{
			return stateTimer.elapsedTime;
		}
		return -1f;
	}

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void SetVolume(float value)
	{
		volume = value;
		if (!muteVolumeWhilePaused)
		{
			audioSource.volume = volume;
		}
	}

	public void SetPitch(float value)
	{
		pitch = value;
		audioSource.pitch = pitch;
	}

	public void FadeOutAndStop()
	{
		FadeOutAndStop(Manager.audio.reuse_fadeOutDuration);
	}

	public void FadeIn(float duration, bool startVolumeAtZero)
	{
		if (state != State.none && state != State.fadeIn && state != State.antiPopMute)
		{
			state = State.fadeIn;
			stateTimer.Start(duration);
			volumeBeforeFadeIn = (startVolumeAtZero ? 0f : audioSource.volume);
			audioSource.volume = volumeBeforeFadeIn;
		}
	}

	public void FadeOutAndStop(float duration)
	{
		if (state != State.none && state != State.fadeOut && state != State.antiPopMute)
		{
			RemoveFromBeingReusable();
			freeAfterStoppedPlaying = true;
			volumeBeforeFadeOut = audioSource.volume;
			stateTimer.Start(duration);
			state = State.fadeOut;
		}
	}

	public void StopNow(bool antiPop = true)
	{
		RemoveFromBeingReusable();
		freeAfterStoppedPlaying = true;
		if (!antiPop)
		{
			audioSource.Stop();
			state = State.none;
			Free();
		}
		else if (state != State.antiPopMute)
		{
			audioSource.mute = true;
			stateTimer.Start(Manager.audio.reuse_antiPopMuteDuration);
			state = State.antiPopMute;
		}
	}

	public void ManagedLateUpdate()
	{
		switch (state)
		{
		case State.playing:
			if (followsAnEntityOrTransform && (transformToFollow == null || !transformToFollow.gameObject.activeInHierarchy) && entityToFollow == Entity.Null)
			{
				FadeOutAndStop(2f);
			}
			else if (muteVolumeWhilePaused && Time.timeScale == 0f)
			{
				mutedFromPause = true;
				audioSource.volume = 0f;
			}
			else if (mutedFromPause && muteVolumeWhilePaused && Time.timeScale != 0f)
			{
				audioSource.volume = volume;
				mutedFromPause = false;
			}
			else
			{
				audioSource.volume = volume;
			}
			break;
		case State.fadeOut:
			if (!stateTimer.isTimerElapsed)
			{
				audioSource.volume = stateTimer.invElapsedRatio * volumeBeforeFadeOut;
			}
			else
			{
				StopNow();
			}
			break;
		case State.fadeIn:
			if (!stateTimer.isTimerElapsed)
			{
				audioSource.volume = volumeBeforeFadeIn + stateTimer.elapsedRatio * (volume - volumeBeforeFadeIn);
			}
			else
			{
				state = State.playing;
			}
			break;
		case State.antiPopMute:
			if (stateTimer.isTimerElapsed)
			{
				audioSource.Stop();
				state = State.none;
			}
			break;
		}
		if (freeAfterStoppedPlaying && !audioSource.isPlaying && (Application.runInBackground || Application.isFocused))
		{
			Free();
			return;
		}
		UpdatePosition();
		UpdateSpatialBlend();
	}

	public void UpdatePosition()
	{
		if (transformToFollow != null)
		{
			base.transform.position = transformToFollow.position;
			return;
		}
		World clientWorld = Manager.ecs.ClientWorld;
		if (clientWorld != null && EntityUtility.EntityExists(entityToFollow, clientWorld) && EntityUtility.HasComponentData<LocalTransform>(entityToFollow, clientWorld))
		{
			base.transform.position = (Vector3)clientWorld.EntityManager.GetComponentData<LocalTransform>(entityToFollow).Position - (Vector3)Manager.camera.RenderOrigo;
		}
	}

	public void UpdateSpatialBlend()
	{
		if (!useSpatialSound || audioSource == null)
		{
			audioSource.spatialBlend = 0f;
			return;
		}
		float num = ((Manager.main.player != null) ? (Manager.main.player.RenderPosition - base.transform.position).magnitude : Vector3.Distance(audioSource.transform.position, Camera.main.transform.position));
		if (maxSpatialBlend == 0f)
		{
			float spatialBlend = Mathf.Clamp01(num / maxSpatialBlendDistance);
			audioSource.spatialBlend = spatialBlend;
		}
		else if (num >= maxSpatialBlendDistance)
		{
			audioSource.spatialBlend = maxSpatialBlend;
		}
		else
		{
			float t = Mathf.InverseLerp(0f, maxSpatialBlendDistance, num);
			audioSource.spatialBlend = Mathf.Lerp(0f, maxSpatialBlend, t);
		}
	}

	public override void OnOccupied()
	{
		Manager.update.AddToLateUpdate(this);
		audioSource.mute = false;
		stateTimer.Start();
		state = State.playing;
	}

	public override void OnFree()
	{
		base.OnFree();
		validAllocationIndex++;
		Manager.update.RemoveFromLateUpdate(this);
		RemoveFromBeingReusable();
		Manager.audio.RemoveNonStackableAudioSource(this);
		if (audioSource.loop)
		{
			Manager.audio.loopingClips.Remove(this);
		}
		followsAnEntityOrTransform = false;
		transformToFollow = null;
		entityToFollow = Entity.Null;
		audioSource.mute = true;
		stateTimer.Stop();
		state = State.none;
	}

	private void RemoveFromBeingReusable()
	{
		if (AudioManager.IsLegalSfxID(reuseID))
		{
			if (Manager.audio.reuseMap[(int)reuseID] == this)
			{
				Manager.audio.reuseMap[(int)reuseID] = null;
			}
			reuseID = SfxID.__illegal__;
		}
	}
}
