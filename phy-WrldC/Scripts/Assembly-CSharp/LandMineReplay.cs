using UltimateReplay;

public class LandMineReplay : ReplayBehaviour
{
	private LandMine landMine;

	public override void Awake()
	{
		base.Awake();
		landMine = GetComponent<LandMine>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(landMine.IsLedOn);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		landMine.SetLedOnOff(state.ReadBool());
	}
}
