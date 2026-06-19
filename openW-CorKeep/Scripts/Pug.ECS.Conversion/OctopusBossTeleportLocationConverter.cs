using Pug.Conversion;

public class OctopusBossTeleportLocationConverter : SingleAuthoringComponentConverter<OctopusBossTeleportLocationAuthoring>
{
	protected override void Convert(OctopusBossTeleportLocationAuthoring authoring)
	{
		EnsureHasComponent<OctopusBossTeleportLocationCD>();
	}
}
