namespace Amazon.Runtime.EventStreams
{
	public enum EventStreamHeaderType : byte
	{
		BoolTrue = 0,
		BoolFalse = 1,
		SByte = 2,
		Int16 = 3,
		Int32 = 4,
		Int64 = 5,
		ByteBuf = 6,
		String = 7,
		Timestamp = 8,
		UUID = 9
	}
}
