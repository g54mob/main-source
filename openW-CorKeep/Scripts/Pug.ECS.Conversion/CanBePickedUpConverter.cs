using Pug.Conversion;

public class CanBePickedUpConverter : SingleAuthoringComponentConverter<CanBePickedUpAuthoring>
{
	protected override void Convert(CanBePickedUpAuthoring authoring)
	{
		EnsureHasComponent<PickUpItemCD>();
		EnsureHasComponent<DestroyIfInventoryEmptyCD>();
	}
}
