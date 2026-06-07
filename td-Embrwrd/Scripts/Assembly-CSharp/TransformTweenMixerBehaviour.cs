using UnityEngine;
using UnityEngine.Playables;

public class TransformTweenMixerBehaviour : PlayableBehaviour
{
	private bool m_FirstFrameHappened;

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
	}

	public override void OnPlayableDestroy(Playable playable)
	{
	}

	private static Quaternion AddQuaternions(Quaternion first, Quaternion second)
	{
		return default(Quaternion);
	}

	private static Quaternion ScaleQuaternion(Quaternion rotation, float multiplier)
	{
		return default(Quaternion);
	}

	private static float QuaternionMagnitude(Quaternion rotation)
	{
		return 0f;
	}

	private static Quaternion NormalizeQuaternion(Quaternion rotation)
	{
		return default(Quaternion);
	}
}
