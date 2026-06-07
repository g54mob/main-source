using UnityEngine;
using VRTK;

public struct ArcParams
{
	public float duration;

	public float speed;

	public float length;

	public int segmentCount;

	public void Apply(VRTK_ValveArcPointerRenderer arc)
	{
		if ((bool)arc)
		{
			arc.arcDuration = duration;
			arc.arcSpeed = speed;
			arc.maximumLength = length;
			arc.segmentCount = segmentCount;
		}
	}

	public void Lerp(ArcParams target, float ratio)
	{
		duration = Mathf.Lerp(duration, target.duration, ratio);
		speed = Mathf.Lerp(speed, target.speed, ratio);
		length = Mathf.Lerp(length, target.length, ratio);
		segmentCount = (int)Mathf.Lerp(segmentCount, target.segmentCount, ratio);
	}
}
