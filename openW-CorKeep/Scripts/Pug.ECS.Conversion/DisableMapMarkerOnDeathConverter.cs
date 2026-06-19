using Pug.Conversion;

public class DisableMapMarkerOnDeathConverter : SingleAuthoringComponentConverter<DisableMapMarkerOnDeathAuthoring>
{
	protected override void Convert(DisableMapMarkerOnDeathAuthoring authoring)
	{
		EnsureHasComponent<DisableMapMarkerOnDeathCD>();
	}
}
