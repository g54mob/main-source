using UltimateReplay;

public class BarPositionerReplay : ReplayBehaviour
{
	private BarPositioner barPositioner;

	public override void Awake()
	{
		base.Awake();
		barPositioner = GetComponent<BarPositioner>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		barPositioner.enabled = true;
	}
}
