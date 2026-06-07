using UltimateReplay;

public class CannonBallReplay : ReplayBehaviour
{
	private CannonBall cannonBall;

	public override void Awake()
	{
		base.Awake();
		cannonBall = GetComponent<CannonBall>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(cannonBall.IsExisting);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		cannonBall.SetExistence(state.ReadBool());
	}
}
