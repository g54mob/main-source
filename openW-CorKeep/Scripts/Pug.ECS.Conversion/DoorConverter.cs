using Pug.Conversion;

public class DoorConverter : SingleAuthoringComponentConverter<DoorAuthoring>
{
	protected override void Convert(DoorAuthoring authoring)
	{
		EnsureHasComponent<DoorCD>();
		if (authoring.changesColliderByVariation)
		{
			AddComponentData(new ColliderVariationCD
			{
				activeVariation = -1
			});
		}
	}
}
