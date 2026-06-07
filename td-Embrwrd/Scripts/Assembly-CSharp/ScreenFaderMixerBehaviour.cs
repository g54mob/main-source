using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ScreenFaderMixerBehaviour : PlayableBehaviour
{
	private Color m_DefaultColor;

	private Image m_TrackBinding;

	private bool m_FirstFrameHappened;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
	}

	public override void OnPlayableDestroy(Playable playable)
	{
	}
}
