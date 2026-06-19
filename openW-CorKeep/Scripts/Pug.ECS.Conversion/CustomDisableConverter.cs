using Pug.Conversion;

public class CustomDisableConverter : SingleAuthoringComponentConverter<CustomDisableAuthoring>
{
	protected override void Convert(CustomDisableAuthoring authoring)
	{
		EnsureHasComponent<DontDisableCD>();
	}
}
