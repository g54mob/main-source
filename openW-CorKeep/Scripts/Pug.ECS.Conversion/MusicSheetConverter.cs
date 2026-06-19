using Pug.Conversion;

public class MusicSheetConverter : SingleAuthoringComponentConverter<MusicSheetAuthoring>
{
	protected override void Convert(MusicSheetAuthoring authoring)
	{
		AddComponentData(new InstrumentSongInfoCD
		{
			harpTrack = authoring.harpTrack.value,
			fluteTrack = authoring.fluteTrack.value,
			celloTrack = authoring.celloTrack.value,
			ocarinaTrack = authoring.ocarinaTrack.value,
			drumkitTrack = authoring.drumkitTrack.value,
			pianoTrack = authoring.pianoTrack.value
		});
	}
}
