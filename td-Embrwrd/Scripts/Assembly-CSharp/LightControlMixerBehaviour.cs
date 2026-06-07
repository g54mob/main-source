using UnityEngine;
using UnityEngine.Playables;

public class LightControlMixerBehaviour : PlayableBehaviour
{
	private Color m_DefaultColor;

	private float m_DefaultIntensity;

	private float m_DefaultBounceIntensity;

	private float m_DefaultRange;

	private Light m_TrackBinding;

	private bool m_FirstFrameHappened;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
	}

	public override void OnPlayableDestroy(Playable playable)
	{
	}
}
