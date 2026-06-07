using System.Collections;
using UnityEngine;

public abstract class LedBarDriverBase : MonoBehaviour
{
	public enum DisplayMode
	{
		NORMAL = 0,
		BLINKING = 1,
		FILLING = 2,
		OFF = 3
	}

	public DisplayMode mode;

	public int ledsCount;

	public int litLedsCount;

	public bool roundUpForNearZero = true;

	protected Coroutine AnimatorCoroutine;

	protected bool initialized;

	protected abstract void UpdateLeds(int amount);

	private void Awake()
	{
		Initialize();
	}

	public virtual void Initialize()
	{
		if (!initialized)
		{
			UpdateLeds(0);
			UpdateValue(0f);
			UpdateAnimator();
			initialized = true;
		}
	}

	private void OnEnable()
	{
		UpdateAnimator();
	}

	public void UpdateValue(float value)
	{
		int num = ValueToLedsCount(value);
		if (num != litLedsCount)
		{
			litLedsCount = num;
			UpdateLeds(litLedsCount);
		}
	}

	public void UpdateDisplayMode(DisplayMode mode)
	{
		if (this.mode != mode)
		{
			this.mode = mode;
			UpdateAnimator();
		}
	}

	protected void UpdateAnimator()
	{
		if (AnimatorCoroutine != null)
		{
			StopCoroutine(AnimatorCoroutine);
		}
		if (mode == DisplayMode.BLINKING || mode == DisplayMode.FILLING)
		{
			AnimatorCoroutine = StartCoroutine(AnimateLeds());
		}
		else
		{
			UpdateLeds(litLedsCount);
		}
	}

	private IEnumerator AnimateLeds()
	{
		if (mode == DisplayMode.BLINKING)
		{
			while (true)
			{
				UpdateLeds(litLedsCount);
				yield return WaitFor.Seconds(1f);
				UpdateLeds(0);
				yield return WaitFor.Seconds(1f);
			}
		}
		if (mode != DisplayMode.FILLING)
		{
			yield break;
		}
		while (true)
		{
			int startingCount = litLedsCount;
			for (int i = litLedsCount; i <= ledsCount; i++)
			{
				if (startingCount != litLedsCount)
				{
					break;
				}
				UpdateLeds(i);
				yield return WaitFor.Seconds(0.3f);
			}
		}
	}

	private int ValueToLedsCount(float value)
	{
		int num = Mathf.FloorToInt((float)ledsCount * Mathf.Clamp01(value));
		if (roundUpForNearZero && num == 0 && value > 0f)
		{
			num = 1;
		}
		if (value >= 0.99f)
		{
			num = ledsCount;
		}
		return num;
	}
}
