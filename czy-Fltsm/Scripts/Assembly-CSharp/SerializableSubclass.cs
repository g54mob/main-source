public class SerializableSubclass : SerializableBase
{
	public string String;

	public override SerializationMarkers Marker => SerializationMarkers.SerializableSubclass;

	public SerializableSubclass()
	{
	}

	public SerializableSubclass(string s)
	{
		String = s;
	}

	protected override void InternalSerialize()
	{
		WriteString("string", String);
	}

	protected override void InternalDeserialize()
	{
		String = ReadString("string");
	}
}
