using Pug.Conversion;

public class EntityPartConverter : SingleAuthoringComponentConverter<EntityPartAuthoring>
{
	protected override void Convert(EntityPartAuthoring authoring)
	{
		AddComponentData(new EntityPartCD
		{
			mainEntity = GetPrefabDependency(authoring.mainEntity)
		});
	}
}
