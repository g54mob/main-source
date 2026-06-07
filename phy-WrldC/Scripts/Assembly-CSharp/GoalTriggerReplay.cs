using UltimateReplay;

public class GoalTriggerReplay : ReplayBehaviour
{
	private GoalTrigger goalTrigger;

	public override void Awake()
	{
		base.Awake();
		goalTrigger = GetComponent<GoalTrigger>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(goalTrigger.ColorIndex);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		goalTrigger.SetColorWithIndex(state.Read32());
	}
}
