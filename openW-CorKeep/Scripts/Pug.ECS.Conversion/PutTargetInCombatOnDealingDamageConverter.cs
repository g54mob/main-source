using Pug.Conversion;

public class PutTargetInCombatOnDealingDamageConverter : SingleAuthoringComponentConverter<PutTargetInCombatOnDealingDamageAuthoring>
{
	protected override void Convert(PutTargetInCombatOnDealingDamageAuthoring authoring)
	{
		EnsureHasComponent<PutTargetInCombatOnDealingDamageCD>();
	}
}
