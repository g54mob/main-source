using Pug.Conversion;

public class DestroyIfPlacementNotValidConverter : SingleAuthoringComponentConverter<DestroyEntityIfPlacementNotValidAuthoring>
{
	protected override void Convert(DestroyEntityIfPlacementNotValidAuthoring authoring)
	{
		EnsureHasComponent<DestroyEntityIfPlacementNotValidCD>();
	}
}
