using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class AsciiAnimation : MonoBehaviour
{
	public static bool allAnimationsEnabled = true;

	public static bool gameplayPaused = false;

	public AsciiSprite Sprite;

	public bool playOnStart;

	public bool looping;

	public bool randomStartTime;

	public bool pauseWithGameplay;

	public float duration = 1f;

	private float elapsedTime;

	private int initialFrame;

	private static readonly float FPS = 30f;

	public float ElapsedTime
	{
		get
		{
			return elapsedTime;
		}
		set
		{
			elapsedTime = value;
			UpdateFrame();
		}
	}

	public bool Playing { get; protected set; }

	public bool Paused { get; protected set; }

	public event Action<AsciiAnimation> OnEnded;

	public event Action<AsciiAnimation> OnLoop;

	public virtual void Play()
	{
		if (!Playing)
		{
			if (randomStartTime)
			{
				ElapsedTime = UnityEngine.Random.Range(0f, duration);
			}
			else
			{
				ElapsedTime = (float)initialFrame * duration / (float)Sprite.FrameCount;
			}
		}
		Playing = true;
		Paused = false;
	}

	public virtual void Stop()
	{
		Playing = false;
		Paused = false;
	}

	public virtual void Pause()
	{
		Paused = true;
	}

	protected virtual void Update()
	{
		if (Playing && !Paused && allAnimationsEnabled && (!gameplayPaused || !pauseWithGameplay))
		{
			UpdateWithDeltaTime(Utils.deltaTime);
		}
	}

	public virtual void UpdateWithDeltaTime(float delta)
	{
		float num = ElapsedTime + delta;
		if (num >= duration)
		{
			if (looping)
			{
				num -= duration;
				FireOnLoop();
			}
			else
			{
				num = duration;
				Stop();
				FireOnEnded();
			}
		}
		ElapsedTime = num;
	}

	protected void FireOnEnded()
	{
		if (this.OnEnded != null)
		{
			this.OnEnded(this);
		}
	}

	protected void FireOnLoop()
	{
		if (this.OnLoop != null)
		{
			this.OnLoop(this);
		}
	}

	private void UpdateFrame()
	{
		if (duration <= 0f)
		{
			Sprite.SetFrameIndex(0);
			Utils.LogWarning("Invalid duration for animation on " + base.gameObject?.ToString() + ". Stopping playback.", base.gameObject);
			Stop();
			return;
		}
		float num = ElapsedTime / duration;
		if (num >= 1f)
		{
			Sprite.SetFrameIndex(Sprite.FrameCount - 1);
		}
		else
		{
			Sprite.SetFrameIndex(Mathf.FloorToInt((float)Sprite.FrameCount * num));
		}
	}

	protected virtual void Awake()
	{
		if (Sprite == null)
		{
			Sprite = GetComponent<AsciiSprite>();
		}
		initialFrame = Sprite.GetFrameIndex();
	}

	protected virtual void Start()
	{
		if (playOnStart)
		{
			Play();
		}
	}

	[StonescriptNativeGetter("duration")]
	public object Property_GetDuration()
	{
		return Mathf.FloorToInt(duration * FPS);
	}

	[StonescriptNativeSetter("duration")]
	public void Property_SetDuration(object value)
	{
		duration = (float)(int)value / FPS;
	}

	[StonescriptNativeGetter("playing")]
	public object Property_GetIsPlaying()
	{
		return Playing;
	}

	[StonescriptNativeGetter("paused")]
	public object Property_GetIsPaused()
	{
		return Paused;
	}

	[StonescriptNativeGetter("playOnStart")]
	public object Property_GetPlayOnStart()
	{
		return playOnStart;
	}

	[StonescriptNativeSetter("playOnStart")]
	public void Property_SetPlayOnStart(object value)
	{
		playOnStart = (bool)value;
	}

	[StonescriptNativeGetter("loop")]
	public object Property_GetLoop()
	{
		return looping;
	}

	[StonescriptNativeSetter("loop")]
	public void Property_SetLoop(object value)
	{
		looping = (bool)value;
	}

	[StonescriptNativeGetter("gamePause")]
	public object Property_GetPauseWithGameplay()
	{
		return pauseWithGameplay;
	}

	[StonescriptNativeSetter("gamePause")]
	public void Property_SetPauseWithGameplay(object value)
	{
		pauseWithGameplay = (bool)value;
	}

	[StonescriptNativeMethod("Pause")]
	public object Method_Pause(List<object> parameters, InvocationContext ctx)
	{
		Pause();
		return null;
	}

	[StonescriptNativeMethod("Play")]
	public object Method_Play(List<object> parameters, InvocationContext ctx)
	{
		Play();
		return null;
	}

	[StonescriptNativeMethod("Stop")]
	public object Method_Stop(List<object> parameters, InvocationContext ctx)
	{
		Stop();
		return null;
	}
}
