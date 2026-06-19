using Pug.Conversion;

public class ImmuneToSkipLootDropConverter : SingleAuthoringComponentConverter<ImmuneToSkipLootDropAuthoring>
{
	protected override void Convert(ImmuneToSkipLootDropAuthoring authoring)
	{
		EnsureHasComponent<ImmuneToSkipLootDropCD>();
	}
}
