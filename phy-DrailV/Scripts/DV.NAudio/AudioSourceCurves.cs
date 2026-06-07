using UnityEngine;

public struct AudioSourceCurves
{
	public AnimationCurve rolloff;

	public AnimationCurve reverb;

	public AnimationCurve spatial;

	public AnimationCurve spread;

	public AudioSourceCurves(AnimationCurve rolloff, AnimationCurve reverb, AnimationCurve spatial, AnimationCurve spread)
	{
		this.rolloff = rolloff;
		this.reverb = reverb;
		this.spatial = spatial;
		this.spread = spread;
	}
}
