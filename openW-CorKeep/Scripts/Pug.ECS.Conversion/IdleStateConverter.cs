using Pug.Conversion;

public class IdleStateConverter : SingleAuthoringComponentConverter<IdleStateAuthoring>
{
	protected override void Convert(IdleStateAuthoring authoring)
	{
		AddComponentData(new IdleStateCD
		{
			playIdleAnimation = authoring.playIdleAnimation
		});
		EnsureHasComponent<StunnedStateCD>();
		EnsureHasComponent<IsInCombatCD>();
	}
}
