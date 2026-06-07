using UnityEngine;

public class TimeScale
{
	private readonly float _scale;

	public static readonly TimeScale Single = new TimeScale(1f);

	public static readonly TimeScale SingleSlow = new TimeScale(0.75f);

	public static readonly TimeScale Double = new TimeScale(2f);

	public static readonly TimeScale DoubleSlow = new TimeScale(1.5f);

	public static readonly TimeScale ExtraFast = new TimeScale(3.5f);

	public float Scale => _scale;

	public TimeScale(float scale)
	{
		_scale = scale;
	}

	public float ScaleTime(float time)
	{
		return time * _scale;
	}

	public static TimeScale FromScale(float scale)
	{
		if (Mathf.Approximately(scale, SingleSlow.Scale))
		{
			return SingleSlow;
		}
		if (Mathf.Approximately(scale, Double.Scale))
		{
			return Double;
		}
		if (Mathf.Approximately(scale, DoubleSlow.Scale))
		{
			return DoubleSlow;
		}
		return Single;
	}
}
