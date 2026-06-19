using System;

[Serializable]
public class SavedControlsFile
{
	public ControlMapping defaultUserMapping = new ControlMapping();

	public SerializableDictionary<ulong, ControlMapping> steamUserIDToControlMappingDict;
}
