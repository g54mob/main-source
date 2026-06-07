using System;
using R3;
using UnityEngine;

public readonly struct AchievementDetails : IDisposable
{
	public readonly ReactiveProperty<bool> Unlocked;

	public readonly ReactiveProperty<double> Progress;

	public readonly double Target;

	public Observable<float> Normalized => Progress.DistinctUntilChanged().Select(Target, Normalize).Share();

	public bool HasProgress
	{
		get
		{
			if (!Unlocked.Value)
			{
				return Progress.Value != 0.0;
			}
			return true;
		}
	}

	public AchievementDetails(double target)
		: this(unlocked: false, 0.0, target)
	{
	}

	public AchievementDetails(bool unlocked, double current, double target)
	{
		Unlocked = new ReactiveProperty<bool>(unlocked);
		Progress = new ReactiveProperty<double>(current);
		Target = target;
	}

	private static float Normalize(double x, double target)
	{
		if (!(target <= 0.0))
		{
			return Mathf.Clamp01((float)(x / target));
		}
		return 0f;
	}

	public void Dispose()
	{
		Unlocked.Dispose();
		Progress.Dispose();
	}
}
