using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.State;

public class FollowOrdersAiActionGoal : CombatAiActionGoal
{
	private readonly EnemyBehaviour enemyOwner;

	public FollowOrdersAiActionGoal(Agent selfAgent)
		: base("FollowOrdersAiActionGoal", selfAgent)
	{
		enemyOwner = (base.AgentOwner as HumanoidInstance)?.EnemyBehaviour;
	}

	public override bool AgentTypeCheck()
	{
		return enemyOwner != null;
	}

	public override bool CanStart(bool isForced = false)
	{
		if (!enemyOwner.Humanoid.IsLeaving)
		{
			return enemyOwner.CurrentOrder != null;
		}
		return false;
	}

	protected override bool ShouldAbort()
	{
		if (!enemyOwner.Humanoid.IsLeaving)
		{
			return enemyOwner.CurrentOrder == null;
		}
		return true;
	}
}
