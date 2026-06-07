public enum SerializationMarkers : byte
{
	Key = 1,
	Byte = 8,
	Boolean = 9,
	Integer = 10,
	Float = 11,
	String = 12,
	SerializableClass = 16,
	SerializableSubclass = 17,
	SerializableEnd = byte.MaxValue
}
