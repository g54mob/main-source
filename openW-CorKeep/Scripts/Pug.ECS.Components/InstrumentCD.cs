using Unity.Entities;

public struct InstrumentCD : IComponentData, IQueryTypeParameter
{
	public InstrumentType instrumentType;

	public int noteSound;

	public int noteSoundOctave;

	public int keyOffsetFromC5;

	public SfxUnityInspectorFriendlyID equipSound;

	public SfxUnityInspectorFriendlyID unequipSound;
}
