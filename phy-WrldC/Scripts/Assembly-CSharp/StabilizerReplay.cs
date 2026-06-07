using UltimateReplay;

public class StabilizerReplay : ReplayBehaviour
{
	private Stabilizer stabilizer;

	public override void Awake()
	{
		base.Awake();
		stabilizer = GetComponent<Stabilizer>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(stabilizer.IsStabilizerOn);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		stabilizer.SetMaterialEmission(state.ReadBool());
	}
}
