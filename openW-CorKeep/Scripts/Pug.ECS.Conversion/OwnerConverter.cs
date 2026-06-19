using Pug.Conversion;

public class OwnerConverter : SingleAuthoringComponentConverter<OwnerAuthoring>
{
	protected override void Convert(OwnerAuthoring authoring)
	{
		AddComponentData(new OwnerReferenceCD
		{
			owner = GetPrefabDependency(authoring.owner)
		});
	}
}
