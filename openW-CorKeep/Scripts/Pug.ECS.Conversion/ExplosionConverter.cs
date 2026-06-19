using Pug.Conversion;

public class ExplosionConverter : SingleAuthoringComponentConverter<ExplosionAuthoring>
{
	protected override void Convert(ExplosionAuthoring authoring)
	{
		AddComponentData(new ExplosionCD
		{
			damage = authoring.damage,
			tileDamage = authoring.tileDamage,
			radius = authoring.radius
		});
		EnsureHasComponent<OwnerReferenceCD>();
	}
}
