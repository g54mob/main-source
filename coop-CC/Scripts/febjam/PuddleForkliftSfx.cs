using Aggro.Core;

public class PuddleForkliftSfx : EntityBehaviourBase
{
	public AoEEffects aoeEffects;

	protected override void OnUpdateSimulation()
	{
		_ = aoeEffects.playerEffected;
	}
}
