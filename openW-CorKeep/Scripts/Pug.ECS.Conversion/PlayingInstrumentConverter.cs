using Pug.Conversion;

public class PlayingInstrumentConverter : SingleAuthoringComponentConverter<PlayingInstrumentAuthoring>
{
	protected override void Convert(PlayingInstrumentAuthoring authoring)
	{
		EnsureHasComponent<MusicSheetPlayedCD>();
	}
}
