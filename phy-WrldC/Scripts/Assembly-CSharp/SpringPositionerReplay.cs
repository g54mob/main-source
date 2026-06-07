using UltimateReplay;

public class SpringPositionerReplay : ReplayBehaviour
{
	private SpringPositioner springPositioner;

	public override void Awake()
	{
		base.Awake();
		springPositioner = GetComponent<SpringPositioner>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		springPositioner.enabled = true;
	}
}
