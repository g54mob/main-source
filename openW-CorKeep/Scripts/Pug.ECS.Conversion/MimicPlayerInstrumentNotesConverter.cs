using Pug.Conversion;

public class MimicPlayerInstrumentNotesConverter : SingleAuthoringComponentConverter<MimicPlayerInstrumentNotesAuthoring>
{
	protected override void Convert(MimicPlayerInstrumentNotesAuthoring authoring)
	{
		AddComponentData(new MimicPlayerInstrumentNotesCD
		{
			hearRange = authoring.hearRange,
			sfx = authoring.sfx,
			keyOffset = authoring.keyOffset
		});
		EnsureHasBuffer<TrackedNotesBuffer>();
	}
}
