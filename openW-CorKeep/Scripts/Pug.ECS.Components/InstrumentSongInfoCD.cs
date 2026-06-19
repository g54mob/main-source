using Unity.Entities;

public struct InstrumentSongInfoCD : IComponentData, IQueryTypeParameter
{
	public int harpTrack;

	public int fluteTrack;

	public int celloTrack;

	public int ocarinaTrack;

	public int drumkitTrack;

	public int pianoTrack;

	public int GetSongSfxTableID(InstrumentType instrumentType)
	{
		return instrumentType switch
		{
			InstrumentType.Harp => harpTrack, 
			InstrumentType.Flute => fluteTrack, 
			InstrumentType.Cello => celloTrack, 
			InstrumentType.Ocarina => ocarinaTrack, 
			InstrumentType.Drumkit => drumkitTrack, 
			InstrumentType.Piano => pianoTrack, 
			_ => 0, 
		};
	}
}
