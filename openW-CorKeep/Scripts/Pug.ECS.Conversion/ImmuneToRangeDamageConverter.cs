using Pug.Conversion;

public class ImmuneToRangeDamageConverter : SingleAuthoringComponentConverter<ImmuneToRangeDamageAuthoring>
{
	protected override void Convert(ImmuneToRangeDamageAuthoring authoring)
	{
		EnsureHasComponent<ImmuneToRangeDamageCD>();
	}
}
