namespace MessagePack
{
	public struct ExtensionResult
	{
		public sbyte TypeCode { get; private set; }

		public byte[] Data { get; private set; }

		public ExtensionResult(sbyte typeCode, byte[] data)
		{
			TypeCode = typeCode;
			Data = data;
		}
	}
}
