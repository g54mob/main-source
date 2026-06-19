using Pug.Conversion;

public class CombatRadiusConverter : SingleAuthoringComponentConverter<CombatRadiusAuthoring>
{
	protected override void Convert(CombatRadiusAuthoring authoring)
	{
		float num = authoring.radius - 0.5f;
		AddComponentData(new CombatRadiusCD
		{
			radius = num,
			radiusSq = num * num
		});
	}
}
