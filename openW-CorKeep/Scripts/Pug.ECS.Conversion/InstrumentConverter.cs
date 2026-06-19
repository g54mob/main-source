using Pug.Conversion;

public class InstrumentConverter : SingleAuthoringComponentConverter<InstrumentAuthoring>
{
	protected override void Convert(InstrumentAuthoring authoring)
	{
		AddComponentData(new InstrumentCD
		{
			instrumentType = authoring.instrumentType,
			noteSound = authoring.noteSound.value,
			noteSoundOctave = authoring.noteSoundOctave.value,
			keyOffsetFromC5 = authoring.keyOffsetFromC5,
			equipSound = authoring.equipSound,
			unequipSound = authoring.unequipSound
		});
	}
}
