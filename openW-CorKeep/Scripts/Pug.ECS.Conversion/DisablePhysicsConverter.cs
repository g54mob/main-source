using Pug.Conversion;

public class DisablePhysicsConverter : SingleAuthoringComponentConverter<DisablePhysicsAuthoring>
{
	protected override void Convert(DisablePhysicsAuthoring authoring)
	{
		EnsureHasComponent<DisablePhysicsCD>();
	}
}
