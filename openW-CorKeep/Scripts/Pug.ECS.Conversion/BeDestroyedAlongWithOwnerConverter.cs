using Pug.Conversion;

public class BeDestroyedAlongWithOwnerConverter : SingleAuthoringComponentConverter<BeDestroyedAlongWithOwnerAuthoring>
{
	protected override void Convert(BeDestroyedAlongWithOwnerAuthoring authoring)
	{
		AddComponentData(new BeDestroyedAlongWithOwnerCD
		{
			owner = GetPrefabDependency(authoring.owner)
		});
	}
}
