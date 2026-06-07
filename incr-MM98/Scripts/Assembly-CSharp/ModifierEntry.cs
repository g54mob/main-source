public readonly struct ModifierEntry
{
	public readonly Modifier Modifier;

	public readonly ModifierSourceId SourceId;

	public ModifierEntry(Modifier modifier, ModifierSourceId sourceId)
	{
		Modifier = modifier;
		SourceId = sourceId;
	}
}
