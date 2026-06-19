using Pug.Conversion;

public class IgnoreImmuneZoneConverter : SingleAuthoringComponentConverter<IgnoreImmuneZoneAuthoring>
{
	protected override void Convert(IgnoreImmuneZoneAuthoring authoring)
	{
		EnsureHasComponent<IgnoreImmuneZoneCD>();
	}
}
