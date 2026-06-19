using Pug.Conversion;

public class OverrideLeaveCombatTimeConverter : SingleAuthoringComponentConverter<OverrideLeaveCombatTimeAuthoring>
{
	protected override void Convert(OverrideLeaveCombatTimeAuthoring authoring)
	{
		AddComponentData(new OverrideLeaveCombatTimeCD
		{
			time = authoring.time
		});
	}
}
