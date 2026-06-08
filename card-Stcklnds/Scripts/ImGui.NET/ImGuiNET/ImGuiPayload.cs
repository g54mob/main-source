namespace ImGuiNET
{
	public struct ImGuiPayload
	{
		public unsafe void* Data;

		public int DataSize;

		public uint SourceId;

		public uint SourceParentId;

		public int DataFrameCount;

		public unsafe fixed byte DataType[33];

		public byte Preview;

		public byte Delivery;
	}
}
