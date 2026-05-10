using Cinemachine;
using UnityEngine.Playables;

internal sealed class CinemachineMixer : PlayableBehaviour
{
	public delegate PlayableDirector MasterDirectorDelegate();

	public static MasterDirectorDelegate GetMasterPlayableDirector;

	private ICameraOverrideStack m_BrainOverrideStack;

	private int m_BrainOverrideId;

	private bool m_PreviewPlay;

	public override void OnPlayableDestroy(Playable playable)
	{
	}

	public override void PrepareFrame(Playable playable, FrameData info)
	{
	}

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
	}

	private float GetDeltaTime(float deltaTime)
	{
		return 0f;
	}
}
