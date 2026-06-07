using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TextSwitcherMixerBehaviour : PlayableBehaviour
{
	private Color m_DefaultColor;

	private int m_DefaultFontSize;

	private string m_DefaultText;

	private Text m_TrackBinding;

	private bool m_FirstFrameHappened;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
	}

	public override void OnPlayableDestroy(Playable playable)
	{
	}
}
