using System;

[Serializable]
public class SavedBuildObject
{
	public ulong UID;

	public SerializableVector3 position;

	public SerializableQuaternion rotation;

	public string resourceString;
}
