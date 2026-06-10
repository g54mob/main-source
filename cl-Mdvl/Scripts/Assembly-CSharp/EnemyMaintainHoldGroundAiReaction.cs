using NSMedieval.CombatAi;

public class EnemyMaintainHoldGroundAiReaction : MaintainHoldGroundAiReaction
{
	protected override float MaxDistanceFromHoldVoxel => 30f;

	public EnemyMaintainHoldGroundAiReaction(CombatAiAgent agent)
		: base(agent)
	{
	}
}
