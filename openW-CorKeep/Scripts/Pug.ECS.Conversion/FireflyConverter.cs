using Pug.Conversion;

public class FireflyConverter : SingleAuthoringComponentConverter<FireflyAuthoring>
{
	protected override void Convert(FireflyAuthoring authoring)
	{
		EnsureHasComponent<FireflyCD>();
	}
}
