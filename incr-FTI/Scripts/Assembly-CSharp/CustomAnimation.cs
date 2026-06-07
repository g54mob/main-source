using DG.Tweening;

public class CustomAnimation
{
	public bool isRunning;

	public bool isReversed;

	public float progress;

	protected float speed = 1f;

	private Ease easeFunction;

	public bool autoReverse;

	public bool isLooping;

	public float from { get; protected set; }

	public float to { get; protected set; } = 1f;

	public CustomAnimation()
	{
	}

	public void StopAndReset()
	{
		isRunning = false;
		progress = 0f;
	}

	public CustomAnimation(float from, float to, float duration, Ease ease)
	{
		this.from = from;
		this.to = to;
		easeFunction = ease;
		if (GameUtility.IsNotZero(duration))
		{
			speed = 1f / duration;
		}
	}

	public void SetSpeed(float s)
	{
		speed = s;
	}

	public void SetEase(Ease ease)
	{
		easeFunction = ease;
	}

	public void Run()
	{
		isReversed = false;
		isRunning = true;
		progress = 0f;
	}

	public void RunReversed()
	{
		isReversed = true;
		isRunning = true;
		progress = 1f;
	}

	public virtual float EasedValue()
	{
		if (autoReverse)
		{
			if (progress < 0.5f)
			{
				return DOVirtual.EasedValue(from, to, progress / 0.5f, easeFunction);
			}
			return DOVirtual.EasedValue(from, to, 1f - (progress - 0.5f) / 0.5f, easeFunction);
		}
		return DOVirtual.EasedValue(from, to, progress, easeFunction);
	}

	public void UpdateAnimation()
	{
		if (!isRunning)
		{
			return;
		}
		if (isReversed)
		{
			progress -= TimeManager.MenuDelta * speed;
			if (progress <= 0f)
			{
				if (isLooping)
				{
					while (progress < 0f)
					{
						progress += 1f;
					}
				}
				else
				{
					isRunning = false;
					progress = 0f;
				}
			}
		}
		else
		{
			progress += TimeManager.MenuDelta * speed;
			if (progress >= 1f)
			{
				if (isLooping)
				{
					while (progress > 1f)
					{
						progress -= 1f;
					}
				}
				else
				{
					isRunning = false;
					progress = 1f;
				}
			}
		}
		UpdateDisplay();
	}

	protected virtual void UpdateDisplay()
	{
	}

	public void SetLooping(bool state)
	{
		isLooping = state;
	}
}
