using UnityEngine.Playables;

public class TimeDilationMixerBehaviour : PlayableBehaviour
{
	private readonly float defaultTimeScale;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
	}

	public override void OnBehaviourPause(Playable playable, FrameData info)
	{
	}

	public override void OnGraphStop(Playable playable)
	{
	}

	public override void OnPlayableDestroy(Playable playable)
	{
	}
}
