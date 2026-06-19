using Pug.Conversion;

public class PortalConverter : SingleAuthoringComponentConverter<PortalAuthoring>
{
	protected override void Convert(PortalAuthoring authoring)
	{
		EnsureHasComponent<PortalCD>();
	}
}
