using UltimateReplay;

public class TelescopicPositionerReplay : ReplayBehaviour
{
	private TelescopicPositioner telescopicPositioner;

	public override void Awake()
	{
		base.Awake();
		telescopicPositioner = GetComponent<TelescopicPositioner>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		telescopicPositioner.enabled = true;
	}
}
