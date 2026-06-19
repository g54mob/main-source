using Pug.Conversion;

public class DiggableConverter : SingleAuthoringComponentConverter<DiggableAuthoring>
{
	protected override void Convert(DiggableAuthoring authoring)
	{
		EnsureHasComponent<DiggableCD>();
		EnsureHasComponent<KilledByPlayerCD>(componentIsEnabled: false);
	}
}
