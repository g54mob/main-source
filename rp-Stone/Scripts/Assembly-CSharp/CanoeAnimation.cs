using UnityEngine;

public class CanoeAnimation : AsciiAnimation
{
	public bool loopTake;

	public int initialPivotX = 3;

	public int finalPivotX = -49;

	public float canoeMoveDuration = 10f;

	private float _canoeMoveElapsedTime;

	public override void Play()
	{
		base.Play();
		Init();
	}

	protected override void Awake()
	{
		base.Awake();
		Init();
	}

	private void Init()
	{
		canoeMoveDuration = Mathf.Max(canoeMoveDuration, 0.1f);
		Sprite.pivotX = initialPivotX;
		_canoeMoveElapsedTime = 0f;
	}

	protected override void Update()
	{
		base.Update();
		if (!base.Playing || base.Paused || (AsciiAnimation.gameplayPaused && pauseWithGameplay))
		{
			return;
		}
		_canoeMoveElapsedTime += Utils.deltaTime;
		if (_canoeMoveElapsedTime >= canoeMoveDuration)
		{
			if (loopTake)
			{
				_canoeMoveElapsedTime = 0f;
			}
			else
			{
				_canoeMoveElapsedTime = canoeMoveDuration;
				Stop();
				FireOnEnded();
			}
		}
		Sprite.pivotX = Mathf.FloorToInt((float)initialPivotX + _canoeMoveElapsedTime / canoeMoveDuration * (float)(finalPivotX - initialPivotX));
	}

	public override void UpdateWithDeltaTime(float delta)
	{
		float num = base.ElapsedTime + delta;
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
			}
		}
		base.ElapsedTime = num;
	}
}
